---
title: تحويل ODP من OpenOffice
type: docs
weight: 10
url: /ar/python-net/convert-openoffice-odp/
keywords:
- تحويل OpenDocument
- تحويل ODP
- ODP إلى PDF
- ODP إلى PPT
- ODP إلى PPTX
- ODP إلى XPS
- ODP إلى HTML
- ODP إلى TIFF
- ODP إلى SWF
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تحويل ملفات OpenDocument ODP إلى PDF أو PPT أو PPTX أو XPS أو HTML أو TIFF أو SWF باستخدام Python و Aspose.Slides: أمثلة على الشفرة، جودة عالية، تحويل دفعي، وتخصيص."
---

[**واجهة برمجة تطبيقات Aspose.Slides**](https://products.aspose.com/slides/python-net/) تسمح لك بتحويل عروض ODP من OpenOffice إلى العديد من التنسيقات. واجهة برمجة التطبيقات المستخدمة لتحويل ملفات ODP إلى تنسيقات مستندات أخرى هي نفس المستخدمة لعمليات تحويل PowerPoint (PPT و PPTX).

تظهر لك هذه الأمثلة كيفية تحويل مستندات ODP إلى تنسيقات أخرى (فقط قم بتغيير ملف ODP المصدر):

- [تحويل ODP إلى HTML](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [تحويل ODP إلى PDF](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [تحويل ODP إلى TIFF](/slides/ar/python-net/convert-powerpoint-to-tiff/)
- [تحويل ODP إلى SWF Flash](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [تحويل ODP إلى XPS](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [تحويل ODP إلى PDF مع الملاحظات](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [تحويل ODP إلى TIFF مع الملاحظات](/slides/ar/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

على سبيل المثال، إذا كنت بحاجة إلى تحويل عرض ODP إلى PDF، يمكن القيام بذلك بهذه الطريقة:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```