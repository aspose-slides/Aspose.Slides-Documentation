---
title: التثبيت باستخدام مثبت MSI
type: docs
weight: 20
url: /ar/reportingservices/install-with-msi-installer/
keywords:
- مثبت MSI
- التثبيت
- خدمات تقارير SQL Server
- خادم تقارير Power BI
- Aspose.Slides for Reporting Services
description: "قم بتثبيت Aspose.Slides for Reporting Services باستخدام مثبت MSI الخاص به: ما يحتاجه المثبت، ما يغيّره على كل نسخة من خادم التقارير، وكيفية التحقق من النتيجة."
---
## **التثبيت**

مثبت MSI هو أبسط طريقة لتثبيت Aspose.Slides for Reporting Services. يحتاج إلى .NET Framework 3.5 وحقوق المسؤول على خادم التقارير؛ راجع [متطلبات النظام](/slides/ar/reportingservices/system-requirements/).

1. قم بتنزيل مثبت MSI، *Aspose.Slides for Reporting Services XX.XX*، من [صفحة التنزيل](https://releases.aspose.com/slides/reportingservices/) وانسخه إلى خادم التقارير.
1. شغّله كمسؤول. إذا كان .NET Framework 3.5 مفقودًا، يتوقف المثبت مع رسالة؛ قم بتثبيت ميزات .NET Framework 3.5 وشغّله مرة أخرى.
1. قبول اتفاقية الترخيص.
1. في صفحة **Custom Setup**، تُظهر شجرة الخصائص كل نسخة من SQL Server Reporting Services وPower BI Report Server التي يكتشفها المثبت على الجهاز. لترك نسخة دون تغيير، انقر على أيقونتها واختر **Entire feature will be unavailable**. لا تدعم الإصدارات Express ملحقات العرض، لذا لا تقم باختيار نسخة Express. يخفى المثبت نسخ Express من SQL Server 2016 وما قبله.
1. اختر **Next**، ثم **Install**.

الميزة الاختيارية **Rpl Export** غير مُحددة بشكل افتراضي. تُضيف ملحقًا مخفيًا يحفظ التقارير بتنسيق RPL، وهو مفيد عند إرسال تقرير مشكلة إلى Aspose؛ راجع [تصدير التقارير إلى تنسيق RPL](/slides/ar/reportingservices/exporting-reports-to-rpl-format/).

## **ما يغيّر المثبت**

يحفظ المثبت ملفاته في *Aspose\Aspose.Slides for Reporting Services* داخل مجلد Program Files — *Program Files (x86)* على نظام Windows 64‑bit، لأن المثبت هو حزمة 32‑bit. ثم، لكل نسخة مختارة، يقوم بـ:

- ينسخ *Aspose.Slides.ReportingServices.dll* إلى مجلد *ReportServer\bin* الخاص بالنسخة — بناءً لـ SQL Server 2005، أو بناءً لـ SQL Server 2008 وما بعده وPower BI Report Server؛
- يضيف ستة امتدادات عرض — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS وASODP — إلى عنصر `<Render>` في *rsreportserver.config*؛
- يضيف مجموعة شفرة تُمنح التجميع الثقة الكاملة إلى *rssrvpolicy.config*؛
- يحفظ نسخة من كل ملف تكوين يغيّره، مع إضافة *.bak* إلى اسم الملف.

[التثبيت يدويًا](/slides/ar/reportingservices/install-manually/) يوضح هذه التغييرات خطوة بخطوة.

إذا تعذر تكوين نسخة، يذكرها المثبت في رسالة ويكتب التفاصيل إلى *rserrors<date>.log* في مجلد التثبيت. قم بتثبيت الامتداد على تلك النسخة يدويًا.

## **تحقق من التثبيت**

افتح تقريرًا مُرقّمًا في بوابة الويب (Report Manager على SQL Server 2014 وما قبله) وافتح قائمة **Export**. الآن تشمل هذه الصيغ:

- PPT - عرض PowerPoint عبر Aspose.Slides
- PPS - عرض شرائح PowerPoint عبر Aspose.Slides
- PPTX - عرض PowerPoint 2007 عبر Aspose.Slides
- PPSX - عرض شرائح PowerPoint 2007 عبر Aspose.Slides
- ODP - عرض OpenDocument عبر Aspose.Slides
- XPS - عبر Aspose.Slides

بدون ترخيص، تحوي الملفات المصدرة علامة مائية تجريبية؛ راجع [التراخيص](/slides/ar/reportingservices/license-aspose-slides-for-reporting-services/).

## **متى تثبت يدويًا**

ثبت الامتداد [يدويًا](/slides/ar/reportingservices/install-manually/) بدلًا من ذلك عندما:

- لا يستطيع المثبت تكوين نسخة، على سبيل المثال بسبب إعدادات الأمان على الخادم؛
- بعد الترقية، تريد استبدال التجميع فقط بدلًا من إلغاء تثبيت النسخة القديمة وتشغيل المثبت الجديد.

إلغاء تثبيت المنتج يزيل التجميع وإدخالات التكوين من كل نسخة.