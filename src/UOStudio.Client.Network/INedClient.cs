﻿using System;
using System.Net;

namespace UOStudio.Client.Network
{
    public interface INedClient
    {
        event Action<EndPoint, int> Connected;

        void Connect(string address, int port);

        void Disconnect();

        void SendMessage(string message);
    }
}