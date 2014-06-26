﻿using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using Altman.ModelCore;
using PluginFramework;
using Plugin_ShellManager;

namespace Plugin_ShellManager
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IPlugin))]
    public class Plugin : IControlPlugin
    {
        private UserControl _userControl;
        private PluginAttribute _pluginAttribute;
        private IPluginSetting _pluginSetting;
        private IHostService _hostService;

        [ImportingConstructor]
        public Plugin([Import("IHostService")]IHostService service)
        {
            _pluginAttribute = new PluginAttribute();
            _pluginSetting = new PluginSetting();
            _hostService = service;
        }

        public IPluginAttribute PluginAttribute
        {
            get { return _pluginAttribute; }
        }

        public IPluginSetting PluginSetting
        {
            get { return _pluginSetting; }
        }

        public IHostService HostService
        {
            get { return _hostService; }
        }

        public UserControl GetUi(ShellStruct data)
        {
            return _userControl = new ShellManagerControl(_hostService, data);
        }

        public void Dispose()
        {
            if (_userControl != null)
                _userControl.Dispose();
        }
    }
}