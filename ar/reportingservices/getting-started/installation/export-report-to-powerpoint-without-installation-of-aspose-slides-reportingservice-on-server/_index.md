---
title: تصدير التقرير إلى Powerpoint بدون تثبيت Aspose.Slides.ReportingService على الخادم
type: docs
weight: 120
url: /reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---

{{% alert color="primary" %}} 

يمكن استخدام Aspose.Slides لخدمة التقارير بدون تثبيت على الخادم. هذه الطريقة مناسبة عندما تحتاج إلى دمج تصدير إلى Powerpoint في تطبيقك ولكن الوصول إلى الخدمة محدود.

{{% /alert %}} {{% alert color="primary" %}} 

يمكن العثور على حل Visual Studio الذي يوضح النهج [هنا](attachments/10289165/10453062.zip).

{{% /alert %}} 

تتكون عملية العرض من جزئين:

1. عرض التقرير إلى RPL باستخدام خدمة ويب تقارير. راجع المزيد من المعلومات حول خدمة ويب التقارير [هنا](http://technet.microsoft.com/en-us/library/ms152787.aspx).
1. عرض RPL إلى Powerpoint باستخدام Aspose.Slides لخدمة التقارير لعرض التقرير. التجميع موجود في ﻿﻿﻿﻿﻿{Aspose.Slides لخدمات التقارير home directory}\bin\RV2010
## **كيفية تنفيذ التصدير إلى PowerPoint:**
 1) إنشاء Proxy خدمة الويب (راجع التفاصيل [هنا](http://technet.microsoft.com/en-us/library/ms155134.aspx)) وإضافته إلى الحل الخاص بك.

 2) إضافة مرجع إلى Aspose.Slides.ReportingServices.dll لعرض التقرير 2010.

 3) استخدم هذه الفئة لدمج Proxy خدمة الويب و Aspose.Slides لخدمة التقارير

``` xml

 class PowerpointRenderer

{

/// <summary>

/// يحصل أو يحدد عنوان URL الأساسي لخدمة الويب XML التي يطلبها العميل.

/// </summary>

/// <value>

/// عنوان URL الأساسي لخدمة الويب XML التي يطلبها العميل. القيمة الافتراضية هي System.String.Empty.

/// </value>

public string ReportingServiceUrl { get; set; }


/// <summary>

/// يحصل أو يحدد اسم المستخدم لخدمة التقارير.

/// </summary>

/// <value>

/// اسم المستخدم.

/// </value>

public string Username { get; set; }

/// <summary>

/// يحصل أو يحدد كلمة المرور لخدمة التقارير.

/// </summary>

/// <value>

/// كلمة المرور.

/// </value>

public string Password { get; set; }

/// <summary>

/// يعرض التقرير المحدد إلى ملف.

/// </summary>

/// <param name="outputFileName">اسم ملف الخرج.</param>

/// <param name="reportPath">مسار التقرير.</param>

/// <param name="format">تنسيق العرض الإخراجي.</param>

public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{

using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))

{

Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

//بدء عملية العرض

//هنا نحن نختار التصدير بتنسيق PPT وتوفير outputStream

renderer.StartRendering(format, false);

int page = 1;

//تكرر هذه الدورة عبر جميع صفحات التقرير

while (true)

{

using (MemoryStream rplStream = CreateRplStream(page, reportPath))

{

//إذا كان rplStream فارغًا، فنحن نكون قد وصلنا إلى نهاية التقرير

if (rplStream.Length == 0)

break;

//إضافة صفحة التقرير كشريحة إلى المستند

renderer.RenderPage(rplStream);

}

page++;

}

//استدعاء طريقة الانتهاء لتفريغ العرض التقديمي الذي تم إنشاؤه حديثًا إلى output stream

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

```

 4) الآن يمكنك تصدير التقرير من خلال هذا الكود:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<اسم الخادم>/Reportserver";

powerpointRenderer.Username = "اسم المستخدم";

powerpointRenderer.Password = "كلمة المرور";

powerpointRenderer.Render("test.ppt", "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}} 

تستخدم عملية التصدير هنا فواصل صفحات ناعمة مشابهة لWord أو Excel، لذا قد يختلف الناتج عن العرض التقديمي الذي تم تصديره باستخدام النهج القياسي.

{{% /alert %}}