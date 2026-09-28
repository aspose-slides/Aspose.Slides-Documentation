---
title: التثبيت اليدوي
type: docs
weight: 30
url: /ar/reportingservices/install-manually/
keywords:
- التثبيت اليدوي
- rsreportserver.config
- rssrvpolicy.config
- خدمات تقارير SQL Server
- خادم تقارير Power BI
- Aspose.Slides لخدمات التقارير
description: "تثبيت Aspose.Slides لخدمات التقارير يدويًا من حزمة ZIP التي تحتوي على ملفات DLL فقط: أي تجميعة يجب نسخها، وما الذي يجب إضافته إلى rsreportserver.config و rssrvpolicy.config."
---
## **نظرة عامة**

اتبع الخطوات التالية لتثبيت Aspose.Slides for Reporting Services دون مثبت MSI، من حزمة ZIP *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* على [صفحة التحميل](https://releases.aspose.com/slides/ar/reportingservices/). وهي تسجل نفس الإضافات مثل [مثبت MSI](/slides/ar/reportingservices/install-with-msi-installer/). كررها لكل نسخة من خادم التقارير.

قبل البدء، تحقق من [متطلبات النظام](/slides/ar/reportingservices/system-requirements/). تحتاج إلى صلاحيات المسؤول المحلي على خادم التقارير.

## **اختيار التجميعة**

تحتوي حزمة ZIP على عدة بنى. انسخ ملفًا واحدًا *Aspose.Slides.ReportingServices.dll* إلى خادم التقارير:

| الملف في حزمة ZIP | الاستخدام |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 وما بعده لخدمات التقارير، وPower BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 لخدمات التقارير |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | ليس لخادم تقارير: تطبيقات تصدر من التحكم ReportViewer 2010 أو 2012، انظر [استخدام Aspose.Slides مع ReportViewer 2010 و 2012](/slides/ar/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | اختياري: يحفظ التقارير بصيغة RPL لتقارير الأخطاء، انظر [تصدير التقارير إلى صيغة RPL](/slides/ar/reportingservices/exporting-reports-to-rpl-format/) |

## **إيجاد مجلد خادم التقارير**

تشير الخطوات التالية إلى مجلد *ReportServer* الخاص بخادم التقارير، الذي يحتوي على *rsreportserver.config* و *rssrvpolicy.config*. في تثبيت افتراضي، يكون:

| خادم التقارير | المجلد الافتراضي *ReportServer* |
| :- | :- |
| SQL Server 2017 وما بعده لخدمات التقارير | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 وما قبلها لخدمات التقارير | `C:\Program Files\Microsoft SQL Server\<مجلد النسخة>\Reporting Services\ReportServer`، حيث يكون مجلد النسخة على سبيل المثال `MSRS13.MSSQLSERVER` لـ SQL Server 2016 أو `MSSQL.x` لـ SQL Server 2005 |

لمزيد من المواقع، راجع مقالة ملف تكوين Microsoft’s [RsReportServer.config configuration file](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file).

## **تثبيت الامتداد**

1. انسخ التجميعة التي اخترتها إلى المجلد الفرعي *bin* داخل مجلد *ReportServer*.

   يجب ألا يحمل الملف المنسوخ أذونات NTFS معينة صراحةً، وإلا سيُحرم خادم التقارير من الوصول عند تحميل التجميعة ولن تظهر صيغ التصدير الجديدة. انقر بزر الماوس الأيمن على الملف، اختر **Properties**، وفي تبويب **Security** احذف أي أذونات معينة صراحةً، واترك الأذونات الموروثة فقط. إذا ظهر خيار **Unblock** في تبويب **General**، فاختره.

2. احفظ نسخة من *rsreportserver.config*، ثم افتح الملف في محرر نصوص. أضف هذه الإدخالات داخل عنصر `<Render>`:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   كل إدخال يسجل صيغة تصدير واحدة؛ يجب أن يكون `Name` فريدًا بين امتدادات العرض. مس installer MSI يسجل نفس الأسماء والأنواع الستة. احذف إدخالًا إذا لم ترغب في ظهور صيغته في قائمة التصدير.

3. احفظ نسخة من *rssrvpolicy.config*، ثم افتح الملف في محرر نصوص. ابحث عن مجموعة التعليمات البرمجية التي يكون `Description` الخاص بها هو "This code group grants MyComputer code Execution permission." وأضف مجموعة التعليمات البرمجية هذه كأخر عنصر فرعي لها:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` هو المفتاح العام لتجميعة Aspose.Slides.ReportingServices. احتفظ به في سطر واحد.

4. احفظ كلا الملفين. يقرأ خادم التقارير ملفات التكوين مرة أخرى كلما تم حفظها. إذا احتوى ملف على XML غير صالح، سيتجاهله خادم التقارير أو لن يبدأ، لذا استعد نسختك إذا حدث أي خطأ.

## **التحقق من التثبيت**

افتح تقريرًا مقسمًا إلى صفحات في بوابة الويب (Report Manager على SQL Server 2014 وما قبله) وافتح قائمة **Export**. الآن تشمل هذه الصيغ:

- PPT - عرض PowerPoint عبر Aspose.Slides
- PPS - عرض شريحة PowerPoint عبر Aspose.Slides
- PPTX - عرض PowerPoint 2007 عبر Aspose.Slides
- PPSX - عرض شريحة PowerPoint 2007 عبر Aspose.Slides
- ODP - عرض OpenDocument عبر Aspose.Slides
- XPS - عبر Aspose.Slides

اختر واحدة منها لتصدير التقرير. يفتح الملف في التطبيق المرتبط بصيغته.

![تقرير تم تصديره إلى PowerPoint بواسطة Aspose.Slides for Reporting Services](install-manually_2.png)

إذا لم تظهر الصيغ، تفقد أذونات NTFS للتجميعة المنسوخة. بدون ترخيص، تحمل الملفات المصدرة علامة مائية للتقييم؛ راجع [Licensing](/slides/ar/reportingservices/license-aspose-slides-for-reporting-services/).