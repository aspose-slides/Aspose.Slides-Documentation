---
title: نشر سهل وخفيف الوزن
type: docs
weight: 50
url: /ar/reportingservices/easy-and-lightweight-deployment/
description: "تعرف على كيفية نشر Aspose.Slides for Reporting Services: تجميع واحد في مجلد bin لخادم التقارير، مسجَّل في تكوين خادم التقارير."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for Reporting Services هو [ملحق عرض](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) لـ Microsoft SQL Server Reporting Services و Power BI Report Server.
يتم توفير Aspose.Slides for Reporting Services كحزمة MSI واحدة يمكن تثبيتها على أجهزة الكمبيوتر التي تعمل بخادم تقارير مدعوم، إما 32 بت أو 64 بت؛ راجع [متطلبات النظام](/slides/ar/reportingservices/system-requirements/).

كما أنه من السهل نشر وإدارة Aspose.Slides for Reporting Services يدويًا، لأنه يتكون من تجميع .NET واحد *Aspose.Slides* *.ReportingServices.dll*، مكتوب بالكامل بلغة C#، متوافق مع CLS ويحتوي فقط على شفرة مُدارة آمنة.

{{% /alert %}}

يتضمن ملف ZIP تنزيل بنائين من Aspose.Slides.ReportingServices.dll لخوادم التقارير:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – مبني لـ Microsoft SQL Server 2005 و .NET Framework 2.0 (استخدام للـ x86 و x64)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – مبني لـ Microsoft SQL Server 2008 وما بعده، Power BI Report Server و .NET Framework 2.0 (استخدام للـ x86 و x64)

يقوم مثبت MSI بتثبيت نفس البنائين ويختار الأنسب لكل مثيل من خادم التقارير. [التثبيت يدويًا](/slides/ar/reportingservices/install-manually/) يسرد كل ملف في تنزيل ZIP.

عند التثبيت، يتم نسخ Aspose.Slides.ReportingServices.dll إلى دليل ReportServer\bin وتحديث ملف التكوين بحيث يكون Reporting Services على علم بملحق العرض الجديد. يتم تنفيذ هذه الخطوات بواسطة مثبت Aspose.Slides for Reporting Services، ولكن يمكنك أيضًا تنفيذها يدويًا كما هو موضح لاحقًا في هذه الوثائق.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**الشكل**: تم نسخ Aspose.Slides.ReportingServices.dll إلى دليل **ReportServer\bin**.