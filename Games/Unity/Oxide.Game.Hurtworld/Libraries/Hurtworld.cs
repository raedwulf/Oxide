﻿using System.Reflection;

using Oxide.Core.Libraries;
using Oxide.Plugins;

namespace Oxide.Game.Hurtworld.Libraries
{
    /// <summary>
    /// A library containing utility shortcut functions for Hurtworld
    /// </summary>
    public class Hurtworld : Library
    {
        /// <summary>
        /// Returns if this library should be loaded into the global namespace
        /// </summary>
        /// <returns></returns>
        public override bool IsGlobal => false;

        /// <summary>
        /// Gets private bindingflag for accessing private methods, fields, and properties
        /// </summary>
        [LibraryFunction("PrivateBindingFlag")]
        public BindingFlags PrivateBindingFlag() => (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

        /// <summary>
        /// Converts a string into a quote safe string
        /// </summary>
        /// <param name="str"></param>
        [LibraryFunction("QuoteSafe")]
        public string QuoteSafe(string str) => str.Quote();

        /// <summary>
        /// Broadcasts a chat message to all players
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        [LibraryFunction("BroadcastChat")]
        public void BroadcastChat(string name, string message = null)
        {
            GameManager.Instance.SendLog(string.Concat("[Broadcast] ", message != null ? $"{name} {message}" : name));
            ChatManager.Instance.RPC("RelayChat", uLink.RPCMode.Others, message != null ? $"{name} {message}" : name);
        }

        /// <summary>
        /// Sends a chat message to the player
        /// </summary>
        /// <param name="session"></param>
        /// <param name="name"></param>
        /// <param name="message"></param>
        [LibraryFunction("SendChatMessage")]
        public void SendChatMessage(PlayerSession session, string name, string message = null)
        {
            ChatManager.Instance.RPC("RelayChat", session.Player, message != null ? $"{name} {message}" : name);
        }
    }
}
