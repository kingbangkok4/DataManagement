using Serenity.Navigation;
using System.Runtime.InteropServices;
using Administration = DataManagement.Administration.Pages;

[assembly: NavigationLink(1000, "หน้าหลัก", url: "~/", permission: "", icon: "fa-tachometer")]

[assembly: NavigationMenu(1100, "ห้องสอน", icon: "fa fa-dropbox")]
[assembly: NavigationLink(1200, "ห้องสอน/จองห้องสอน", typeof(DataManagement.Modules.Room.Page.RoomController), icon: "fa fa-file-text-o")]

[assembly: NavigationMenu(2000, "อุปกรณ์", icon: "	fa fa-hand-scissors-o")]
[assembly: NavigationLink(2200, "อุปกรณ์/ยืมอุปกรณ์", typeof(DataManagement.Modules.Resource.Page.ResourceController), icon: "fa fa-check-square-o")]
[assembly: NavigationLink(2200, "อุปกรณ์/คืนอุปกรณ์", typeof(DataManagement.Modules.Resource.Page.ReturnResourceController), icon: "fa fa-dot-circle-o")]

[assembly: NavigationMenu(3000, "รายงาน", icon: "fa fa-line-chart")]
[assembly: NavigationLink(3200, "รายงาน/รายงานการจองห้อง", typeof(DataManagement.Modules.Report.Page.RoomReportController), icon: "fa fa-area-chart")]
[assembly: NavigationLink(3300, "รายงาน/รายงานการยืมอุปกรณ์ ", typeof(DataManagement.Modules.Report.Page.ResourceReportController), icon: "fa fa-line-chart")]