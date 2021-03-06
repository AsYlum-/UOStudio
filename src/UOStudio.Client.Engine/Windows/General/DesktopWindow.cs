﻿using ImGuiNET;
using Num = System.Numerics;

namespace UOStudio.Client.Engine.Windows.General
{
    public sealed class DesktopWindow : Window
    {
        private readonly ImGuiDockNodeFlags _dockspaceFlags = ImGuiDockNodeFlags.None;

        public DesktopWindow()
            : base("Desktop")
        {
            Show();
        }

        protected override ImGuiWindowFlags GetWindowFlags()
        {
            var windowFlags = ImGuiWindowFlags.NoDocking;
            var viewport = ImGui.GetMainViewport();
            ImGui.SetNextWindowPos(viewport.GetWorkPos());
            ImGui.SetNextWindowSize(viewport.GetWorkSize());
            ImGui.SetNextWindowViewport(viewport.ID);
            ImGui.SetNextWindowBgAlpha(0.2f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);
            windowFlags |= ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse |
                           ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove |
                           ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;

            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Num.Vector2(0.0f, 0.0f));
            return windowFlags;
        }

        protected override void DrawInternal()
        {
            ImGui.PopStyleVar();
            ImGui.PopStyleVar(2);

            var io = ImGui.GetIO();
            if ((io.ConfigFlags & ImGuiConfigFlags.DockingEnable) == ImGuiConfigFlags.DockingEnable)
            {
                var dockspaceId = ImGui.GetID(Caption);
                ImGui.DockSpace(dockspaceId, new Num.Vector2(0, 0), _dockspaceFlags);
            }
        }

        protected override void DrawEnd()
        {
        }
    }
}
