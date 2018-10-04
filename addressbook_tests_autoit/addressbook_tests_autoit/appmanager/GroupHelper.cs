using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;
using System.IO;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUPWINTITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.3dd72c21",
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                    GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.3dd72c21",
                    "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            };

            CloseGroupsDialogue();

            return list;
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.3dd72c23");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
            return;
        }

        public void Remove(int groupNumber)
        {

            OpenGroupsDialogue();

            aux.ControlTreeView(
                        GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.3dd72c21",
                        "Select", "#0|#" + groupNumber, "");
            aux.Sleep(500);
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.3dd72c21");

            aux.WinWait(DELETEGROUPWINTITLE, "", 500);
            aux.WinWaitActive(DELETEGROUPWINTITLE, "", 500);

            aux.ControlClick(DELETEGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.3dd72c23");

            CloseGroupsDialogue();
            return;
        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.3dd72c24");
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.3dd72c212");
            aux.WinWaitActive(GROUPWINTITLE, "", 500);
        }
    }
}