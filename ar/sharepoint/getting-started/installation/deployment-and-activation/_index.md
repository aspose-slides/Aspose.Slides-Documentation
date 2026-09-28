---
title: النشر والتفعيل
type: docs
weight: 20
url: /ar/sharepoint/deployment-and-activation/
description: "ما يقوم حل Aspose.Slides for SharePoint بتثبيته على المزرعة عند نشره، وما تضيفه ميزة مجموعة المواقع عند تفعيلها."
---
## **النشر**

أثناء عملية النشر، يحل حل Aspose.Slides for SharePoint:

- يقوم بتثبيت التجميع في ذاكرة التجميع العالمية (Global Assembly Cache) ويضيف إدخالات SafeControl إلى ملف **web.config**. في SharePoint 2010 وما بعده، يكون هذا هو *Aspose.Slides.SharePoint2010.dll*، *Aspose.Slides.SharePoint2013.dll* أو *Aspose.Slides.SharePoint2016.dll* (حزمة SharePoint 2019 تقوم أيضًا بتثبيت *Aspose.Slides.SharePoint2016.dll*). في SharePoint 2007، يكون *Aspose.Slides.SharePointUI.dll*، جنبًا إلى جنب مع *Aspose.Slides.SharePoint.Deployment.dll*.
- ينسخ صفحة التحويل وصورها وغيرها من الملفات الداعمة إلى مجلدات تثبيت SharePoint.
- يثبت الميزة ويجعلها متاحة للتفعيل على مجموعات المواقع.

## **التفعيل**

يتم حزم Aspose.Slides for SharePoint كميزة لمجموعة مواقع ويمكن تفعيلها أو إلغاء تفعيلها على مجموعات المواقع. عند تفعيلها على مجموعة مواقع، تضيف الميزة:

- على SharePoint 2010 وما بعده:
  - العنصر **Convert via Aspose.Slides** إلى قائمة المستندات في مكتبات المستندات؛
  - علامة الشريط **Aspose Tools** مع زر **Convert Slides**، الذي يحول المستندات المحددة؛
  - العنصر **View Slides** إلى قائمة ملفات PPT و PPTX و PPS و PPSX.
- على SharePoint 2007:
  - العنصر **Convert with Aspose.Slides** إلى قائمة المستندات في مكتبات المستندات؛
  - العنصر **Convert All with Aspose.Slides** إلى قائمة **Actions** في مكتبات المستندات.

في SharePoint 2007، يجرى التفعيل أيضًا تغييرات على الدليل الافتراضي لتطبيق الويب الأساسي لمجموعة المواقع. وهو:
- يضيف صفحة إعدادات التحويل إلى ملف خريطة الموقع.
- ينسخ ملفات الموارد الضرورية إلى مجلد App_GlobalResources في الدليل الافتراضي.

يقوم برنامج الإعداد بتفعيل الميزة على مجموعات المواقع التي تختارها أثناء [التثبيت](/slides/ar/sharepoint/installing-aspose-slides-for-sharepoint/).