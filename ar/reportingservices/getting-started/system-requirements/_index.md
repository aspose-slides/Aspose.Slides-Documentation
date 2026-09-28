---
title: متطلبات النظام
type: docs
weight: 15
url: /ar/reportingservices/system-requirements/
keywords:
- متطلبات النظام
- خدمات تقارير Microsoft SQL Server
- SSRS
- خادم Power BI للتقارير
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "تحقق من خوادم التقارير والإصدارات وإصدار .NET Framework الذي يحتاجه Aspose.Slides for Reporting Services قبل تثبيته."
---
## **نظرة عامة**

Aspose.Slides for Reporting Services يعمل داخل خادم التقرير كملحق عرض. تُظهر هذه الصفحة ما يحتاجه جهاز خادم التقرير قبل أن [تثبيت](/slides/ar/reportingservices/installing-aspose-slides-for-reporting-services/)ه. لا يلزم Microsoft PowerPoint ولا Microsoft Office.

## **خوادم التقارير المدعومة**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, for paginated (RDL) reports

كل من خوادم التقارير 32‑بت و64‑بت مدعومة. يستخدم SQL Server 2005 بناءً خاصاً بالملحق؛ جميع الإصدارات اللاحقة وخادم Power BI Report Server يستخدمون نفس البناء. [التثبيت يدويًا](/slides/ar/reportingservices/install-manually/) يُظهر أي ملف يجب نسخه.

إذا لم يكن إصدار خادم التقرير الخاص بك مدرجاً في هذه القائمة، اسأل في [منتدى الدعم المجاني](https://forum.aspose.com/c/slides/ar/11) قبل النشر.

## **إصدارات خادم التقرير**

بالنسبة إلى SQL Server 2016 Reporting Services وما بعده وكذلك Power BI Report Server، تدعم Microsoft ملحقات العرض في إصدارات Enterprise وStandard وDeveloper وEvaluation؛ إصدارات Web وExpress لا تدعمها. راجع [ميزات Reporting Services المدعومة حسب الإصدارات](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). يتخطى مُثبت MSI مث_instances إصدارات Express من SQL Server 2016 وما قبله.

## **إطار عمل .NET**

يجب تثبيت .NET Framework 3.5 على جهاز خادم التقرير. تم بناء تجميعات الملحق لتعمل على .NET Framework 2.0 runtime، ويتوقف مُثبت MSI مع رسالة إذا كان .NET Framework 3.5 مفقوداً. في Windows Server، أضف **.NET Framework 3.5 Features** في معالج إضافة الأدوار والميزات؛ راجع [تثبيت .NET Framework 3.5 على Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **الأذونات**

يُغيّر تثبيت الملحق الملفات في مجلد خادم التقرير، لذا تحتاج كلا طريقتي التثبيت إلى حقوق مسؤول محلي. إذا بدأت مُثبت MSI بدون هذه الحقوق، سيعرض إعادة تشغيل نفسه بامتيازات المسؤول.

## **الأسئلة الشائعة**

**هل أحتاج إلى Microsoft PowerPoint على خادم التقرير؟**

لا. يخلق الملحق العروض التقديمية بنفسه؛ لا يلزم تثبيت PowerPoint ولا Microsoft Office.

**هل يمكنني تثبيت الملحق على إصدار Express؟**

لا. إصدارات Express لا تدعم ملحقات العرض. يُخفى مُثبت MSI مث_instances Express من SQL Server 2016 وما قبله؛ في الإصدارات الأحدث، لا تُحدِّد مث_instance Express.

**ما الصيغ التي يضيفها الملحق إلى قائمة التصدير؟**

PPT, PPS, PPTX, PPSX, ODP and XPS. راجع [الصيغ المدعومة](/slides/ar/reportingservices/supported-file-formats/).