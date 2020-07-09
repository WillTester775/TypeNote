using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.StdWin;

namespace TypeNote
{
    [TestClass]
    public class UftDeveloperTest : UnitTestClassBase<UftDeveloperTest>
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            GlobalSetup(context);
        }

        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            var notepadWindow = Desktop.Describe<IWindow>(new WindowDescription
            {
                IsChildWindow = false,
                IsOwnedWindow = false,
                WindowClassRegExp = @"Notepad",
                WindowTitleRegExp = @"Notepad"
            });
            var editEditor = notepadWindow.Describe<IEditor>(new EditorDescription
            {
                NativeClass = @"Edit"
            });
            
            editEditor.SetCursorPosition(0, 0);
            editEditor.SendKeys("hello world");

        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            GlobalTearDown();
        }
    }
}
