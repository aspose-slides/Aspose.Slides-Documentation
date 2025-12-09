---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 15.7.0"
linktitle: "Aspose.Slides لـ .NET 15.7.0"
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
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتقطعة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول عروض PowerPoint (PPT، PPTX) و ODP."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات والطرق والخصائص وما إلى ذلك التي تم [مضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 15.7.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تم إضافة تعداد ImagePixelFormat**
تمت إضافة تعداد Aspose.Slides.Export.ImagePixelFormat لتحديد تنسيق البكسل للصور المُنشأة.
#### **تم إضافة طريقة IChartDataPoint.GetAutomaticDataPointColor()**
تُرجع لونًا تلقائيًا لنقطة البيانات بناءً على فهرس السلسلة، فهرس نقطة البيانات، ParentSeriesGroup، الخاصية IsColorVaried ونمط المخطط.
يُستخدم هذا اللون بشكل افتراضي إذا كان FillType يساوي NotDefined.
#### **تم إضافة طريقة RenderToGraphics إلى Slide**
تمت إضافة طريقة RenderToGraphics (وتحميلاتها) إلى Aspose.Slides.Slide لتصوير شريحة إلى كائن Graphics.
#### **تم إضافة خاصية PixelFormat إلى ITiffOptions و TiffOptions**
تمت إضافة خاصية PixelFormat إلى Aspose.Slides.Export.ITiffOptions و Aspose.Slides.Export.TiffOptions لتحديد تنسيق البكسل للصور TIFF المُنشأة.