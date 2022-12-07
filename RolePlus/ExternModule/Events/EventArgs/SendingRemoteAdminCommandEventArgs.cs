﻿// -----------------------------------------------------------------------
// <copyright file="SendingRemoteAdminCommandEventArgs.cs" company="NaoUnderscore">
// Copyright (c) NaoUnderscore. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace RolePlus.ExternModule.Events.EventArgs
{
    using System.Collections.Generic;
    using System.Reflection;

    using Exiled.API.Features;

    /// <summary>
    /// Contains all informations before sending a remote admin message.
    /// </summary>
    public sealed class SendingRemoteAdminCommandEventArgs : System.EventArgs
    {
        private string _returnMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendingRemoteAdminCommandEventArgs"/> class.
        /// </summary>
        /// <param name="commandSender"><inheritdoc cref="CommandSender"/></param>
        /// <param name="sender"><inheritdoc cref="Sender"/></param>
        /// <param name="name"><inheritdoc cref="Name"/></param>
        /// <param name="arguments"><inheritdoc cref="Arguments"/></param>
        /// <param name="isAllowed"><inheritdoc cref="IsAllowed"/></param>
        public SendingRemoteAdminCommandEventArgs(CommandSender commandSender, Player sender, string name, List<string> arguments, bool isAllowed = true)
        {
            CommandSender = commandSender;
            Sender = sender;
            Name = name;
            Arguments = arguments;
            IsAllowed = isAllowed;
        }

        /// <summary>
        /// Gets the <see cref="CommandSender"/> sending the command.
        /// </summary>
        public CommandSender CommandSender { get; }

        /// <summary>
        /// Gets the player who's sending the command.
        /// </summary>
        public Player Sender { get; }

        /// <summary>
        /// Gets the command name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the command arguments.
        /// </summary>
        public List<string> Arguments { get; }

        /// <summary>
        /// Gets or sets the message that will be returned back to the <see cref="CommandSender"/>.
        /// </summary>
        public string ReplyMessage
        {
            get => _returnMessage;
            set => _returnMessage = $"{Assembly.GetCallingAssembly().GetName().Name}#{value}";
        }

        /// <summary>
        /// Gets or sets a value indicating whether whether or not the command was a success.
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether or not the RemoteAdmin command can be sent.
        /// </summary>
        public bool IsAllowed { get; set; }
    }
}
