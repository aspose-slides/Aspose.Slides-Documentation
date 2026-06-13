---
title: ส่งออกรายงานเป็น PowerPoint โดยไม่ต้องติดตั้ง Aspose.Slides.ReportingService บนเซิร์ฟเวอร์
type: docs
weight: 120
url: /th/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}}

Aspose.Slides for Reporting Service สามารถใช้งานได้โดยไม่ต้องติดตั้งบนเซิร์ฟเวอร์ วิธีนี้เหมาะสำหรับเมื่อคุณต้องการรวมการส่งออกเป็น PowerPoint ในแอปพลิเคชันของคุณแต่การเข้าถึงบริการถูกจำกัด

{{% /alert %}} {{% alert color="primary" %}}

โซลูชัน Visual Studio ที่แสดงวิธีการสามารถหาได้จาก [ที่นี่](attachments/10289165/10453062.zip)

{{% /alert %}}

กระบวนการเรนเดอร์ประกอบด้วยสองส่วน:

1. เรนเดอร์รายงานเป็น RPL ด้วย Reporting Service Web Service ดูข้อมูลเพิ่มเติมเกี่ยวกับ Reporting Service Web Service [ที่นี่](http://technet.microsoft.com/en-us/library/ms152787.aspx).
1. เรนเดอร์ RPL เป็น PowerPoint โดยใช้ Aspose.Slides for Reporting service สำหรับ ReportViewer ไฟล์แอสเซมบลีอยู่ที่ {Aspose.Slides for Reporting Services home directory}\bin\RV2010  

## **วิธีการนำการส่งออกเป็น PowerPoint ไปใช้:**
1) สร้าง web service proxy (ดูรายละเอียด [ที่นี่](http://technet.microsoft.com/en-us/library/ms155134.aspx)) และเพิ่มลงในโซลูชันของคุณ

2) เพิ่มการอ้างอิงไปยัง Aspose.Slides.ReportingServices.dll สำหรับ ReportViewer 2010

3) ใช้คลาสนี้เพื่อรวม web service proxy กับ Apose.Slides for Reporting Service

``` xml

 class PowerpointRenderer

{

/// <summary>
/// รับหรือกำหนดค่า URL พื้นฐานของบริการเว็บ XML ที่คลายเอ็นต์กำลังร้องขอ
/// </summary>
/// <value>
/// URL พื้นฐานของบริการเว็บ XML ที่คลายเอ็นต์กำลังร้องขอ ค่าเริ่มต้นคือ System.String.Empty
/// </value>
public string ReportingServiceUrl { get; set; }


/// <summary>
— รับหรือกำหนดชื่อผู้ใช้สำหรับ Reporting Service.
/// </summary>
/// <value>
/// ชื่อผู้ใช้.
/// </value>
public string Username { get; set; }

/// <summary>
/// รับหรือกำหนดรหัสผ่านสำหรับ Reporting Service.
/// </summary>
/// <value>
/// รหัสผ่าน.
/// </value>
public string Password { get; set; }

/// <summary>
/// ทำการเรนเดอร์รายงานที่ระบุไปยังไฟล์
/// </summary>
/// <param name="outputFileName">ชื่อของไฟล์ผลลัพธ์</param>
/// <param name="reportPath">เส้นทางของรายงาน</param>
/// <param name="format">รูปแบบการนำเสนอผลลัพธ์</param>
public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{
using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))
{
Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();
//start rendering process
//here we are choosing to export in PPT format and providing outputStream
renderer.StartRendering(format, false);
int page = 1;
//this cycle iterates through all pages of report
while (true)
{
using (MemoryStream rplStream = CreateRplStream(page, reportPath))
{
 //if rplStream is empty then we reached end of report
if (rplStream.Length == 0)
break;
//add report page as slide to the document
renderer.RenderPage(rplStream);
}
page++;
}
//call finish method to flush our newly created presentation to output stream
renderer.FinishRendering(pptSteam);
}

}

private MemoryStream CreateRplStream(int page, string reportPath)

{
ReportExecutionService _executionService = new ReportExecutionService();
_executionService.Url = ReportingServiceUrl + "/ReportExecution2005.asmx";
_executionService.Credentials = new System.Net.NetworkCredential(Username, Password, string.Empty);
string extension;
Warning[] warnings;
string[] streamIds;
string mimeType;
string encoding;
var executionInfo = _executionService.LoadReport(reportPath, null);
string deviceInfo = String.Format(
@"<DeviceInfo>
<StartPage>{0}</StartPage>
<EndPage>{0}</EndPage>
<SecondaryStreams>Embedded</SecondaryStreams>
</DeviceInfo>", page);
byte[] result = _executionService.Render("RPL", deviceInfo, out extension, out mimeType, out encoding, out warnings, out streamIds);
return new MemoryStream(result);
}

}
```

4) ตอนนี้คุณสามารถส่งออกรายงานผ่านโค้ดนี้ได้:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}}

กระบวนการส่งออกที่นี่ใช้การแบ่งหน้าแบบอ่อนคล้ายกับ Word หรือ Excel ดังนั้นผลลัพธ์อาจแตกต่างจากการนำเสนอที่ส่งออกโดยใช้วิธีมาตรฐาน

{{% /alert %}}