---
title: API العامة والتغييرات غير المتوافقة للعودة في Aspose.Slides لـ .NET 15.7.0
linktitle: Aspose.Slides لـ .NET 15.7.0
type: docs
weight: 180
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- ترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات API العامة والتغييرات المكسرة في Aspose.Slides لـ .NET للقيام بترحيل سلس لحلول عرض PowerPoint PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 

تقوم هذه الصفحة بإدراج جميع الفئات أو الأساليب أو الخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/)، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع واجهة برمجة تطبيقات Aspose.Slides for .NET 15.7.0.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تم إضافة تعداد ImagePixelFormat**
تم إضافة تعداد Aspose.Slides.Export.ImagePixelFormat لتحديد تنسيق البكسل للصور المولّدة.
#### **تم إضافة طريقة IChartDataPoint.GetAutomaticDataPointColor()**
تُعيد لونًا تلقائيًا لنقطة البيانات بناءً على فهرس السلسلة، فهرس نقطة البيانات، ParentSeriesGroup، الخاصية IsColorVaried ونمط المخطط.
يُستخدم هذا اللون افتراضيًا إذا كان FillType يساوي NotDefined.
#### **تم إضافة طريقة RenderToGraphics إلى Slide**
تم إضافة طريقة RenderToGraphics (وتراكيبها) إلى Aspose.Slides.Slide لتصيير شريحة إلى كائن Graphics.
#### **تم إضافة خاصية PixelFormat إلى ITiffOptions و TiffOptions**
تم إضافة خاصية PixelFormat إلى Aspose.Slides.Export.ITiffOptions و Aspose.Slides.Export.TiffOptions لتحديد تنسيق البكسل للصور TIFF المولّدة.