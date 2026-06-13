---
title: صادرات گزارش به پاورپوینت بدون نصب Aspose.Slides.ReportingService روی سرور
type: docs
weight: 120
url: /fa/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}}
Aspose.Slides for Reporting Service می‌تواند بدون نصب بر روی سرور استفاده شود. این رویکرد زمانی مناسب است که نیاز داشته باشید خروجی به PowerPoint را در برنامه خود ادغام کنید اما دسترسی به سرویس محدود باشد.
{{% /alert %}} {{% alert color="primary" %}}
راه‌حل Visual Studio که این رویکرد را نشان می‌دهد می‌تواند در [here](attachments/10289165/10453062.zip) یافت شود.
{{% /alert %}}

فرآیند رندر شامل دو بخش است:

1. گزارش را به RPL با استفاده از Reporting Service Web Service رندر کنید. اطلاعات بیشتر درباره Reporting Service Web Service را می‌توانید در [here](http://technet.microsoft.com/en-us/library/ms152787.aspx) ببینید.
2. RPL را به PowerPoint با استفاده از Aspose.Slides for Reporting service برای ReportViewer رندر کنید. این اسمبلی در {Aspose.Slides for Reporting Services home directory}\bin\RV2010 واقع است.
## **نحوه پیاده‌سازی خروجی به PowerPoint:**
1) پروکسی سرویس وب را ایجاد کنید (جزئیات را در [here](http://technet.microsoft.com/en-us/library/ms155134.aspx) ببینید) و آن را به راه‌حل خود اضافه کنید.

2) یک مرجع به Aspose.Slides.ReportingServices.dll برای ReportViewer 2010 اضافه کنید.

3) از این کلاس برای یکپارچه‌سازی پروکسی سرویس وب و Aspose.Slides for Reporting Service استفاده کنید

``` xml

 class PowerpointRenderer

{

/// <summary>
/// دریافت یا تنظیم URL پایه سرویس وب XML که کلاینت درخواست می‌کند.
/// </summary>
/// <value>
/// URL پایه سرویس وب XML که کلاینت درخواست می‌کند. مقدار پیش‌فرض System.String.Empty است.
/// </value>
public string ReportingServiceUrl { get; set; }

/// <summary>
/// دریافت یا تنظیم نام کاربری برای Reporting Service.
/// </summary>
/// <value>
/// نام کاربری.
/// </value>
public string Username { get; set; }

/// <summary>
/// دریافت یا تنظیم گذرواژه برای Reporting Service.
/// </summary>
/// <value>
/// گذرواژه.
/// </value>
public string Password { get; set; }

/// <summary>
/// گزارش مشخص‌شده را به فایل رندر می‌کند.
/// </summary>
/// <param name="outputFileName">نام فایل خروجی.</param>
/// <param name="reportPath">مسیر گزارش.</param>
/// <param name="format">قالب ارائه خروجی.</param>
public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{

using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))

{

Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

//شروع فرآیند رندر
//در اینجا فرمت خروجی PPT انتخاب می‌شود و خروجی به خروجی‌استریم داده می‌شود
renderer.StartRendering(format, false);
int page = 1;

//این حلقه تمام صفحات گزارش را مرور می‌کند
while (true)

{

using (MemoryStream rplStream = CreateRplStream(page, reportPath))

{

//اگر rplStream خالی باشد، به پایان گزارش رسیده‌ایم
if (rplStream.Length == 0)

break;

//صفحه گزارش را به‌عنوان اسلاید به سند اضافه می‌کنیم
renderer.RenderPage(rplStream);

}

page++;

}

//متد پایان را فراخوانی می‌کنیم تا ارائهٔ تازه‌ساخته شده را به خروجی‌استریم بازگردانیم
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

4) اکنون می‌توانید گزارش را با کد زیر صادر کنید:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}}
فرآیند خروجی در اینجا از شکست‌های صفحه نرم مشابه Word یا Excel استفاده می‌کند، بنابراین نتیجه ممکن است با ارائه‌ای که با روش استاندارد صادر شده متفاوت باشد.
{{% /alert %}}