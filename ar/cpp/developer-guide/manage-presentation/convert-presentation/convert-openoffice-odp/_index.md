---
title: تحويل OpenOffice ODP
type: docs
weight: 10
url: /cpp/convert-openoffice-odp/
keywords: "تحويل ODP إلى PDF، ODP إلى HTML، ODP إلى TIFF"
description: "تحويل ODP إلى PDF، ODP إلى PPT، ODP إلى PPTX، ODP إلى HTML وأشكال أخرى باستخدام Aspose.Slides."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) يسمح لك بتحويل عروض OpenOffice ODP إلى العديد من الأشكال. واجهة برمجة التطبيقات المستخدمة لتحويل ملفات ODP إلى صيغ وثائق أخرى هي نفس المستخدمة لعمليات تحويل PowerPoint (PPT و PPTX).

تظهر لك هذه الأمثلة كيفية تحويل مستندات ODP إلى صيغ أخرى (فقط قم بتغيير ملف ODP المصدر):

- [تحويل ODP إلى HTML](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-html/)
- [تحويل ODP إلى PDF](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [تحويل ODP إلى TIFF](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-tiff/)
- [تحويل ODP إلى SWF Flash](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [تحويل ODP إلى XPS](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [تحويل ODP إلى PDF مع الملاحظات](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [تحويل ODP إلى TIFF مع الملاحظات](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

على سبيل المثال، إذا كنت بحاجة إلى تحويل عرض تقديمي ODP إلى PDF، يمكن القيام بذلك بهذه الطريقة:

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
```