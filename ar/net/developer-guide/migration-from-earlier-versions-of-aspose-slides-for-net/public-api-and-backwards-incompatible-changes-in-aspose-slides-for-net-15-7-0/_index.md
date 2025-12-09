---
title: التغييرات العامة في واجهة برمجة التطبيقات والتغييرات غير المتوافقة في Aspose.Slides لـ .NET 15.7.0
linktitle: Aspose.Slides لـ .NET 15.7.0
type: docs
weight: 180
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- الترحيل
- شفرة قديمة
- شفرة حديثة
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسورة في Aspose.Slides لـ .NET للترحيل السلس لحلول عروض PowerPoint (PPT، PPTX) و ODP."
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع الفئات والطرق والخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 15.7.0 API.

{{% /alert %}} 
## **التغييرات في واجهة برمجة التطبيقات العامة**
#### **تمت إضافة Enum ImagePixelFormat**
تمت إضافة تعداد Aspose.Slides.Export.ImagePixelFormat لتحديد صيغة البكسل للصور المُولَّدة.
#### **تمت إضافة الطريقة IChartDataPoint.GetAutomaticDataPointColor()**
تُعيد لونًا تلقائيًا لنقطة البيانات بناءً على فهرس السلسلة، فهرس نقطة البيانات، ParentSeriesGroup، خاصية IsColorVaried ونمط المخطط. يُستخدم هذا اللون كقيمة افتراضية إذا كان FillType يساوي NotDefined.
#### **تمت إضافة الطريقة RenderToGraphics إلى Slide**
تمت إضافة الطريقة RenderToGraphics (ومُفرِعاتها) إلى Aspose.Slides.Slide لتصوير الشريحة إلى كائن Graphics.
#### **تمت إضافة الخاصية PixelFormat إلى ITiffOptions و TiffOptions**
تمت إضافة الخاصية PixelFormat إلى Aspose.Slides.Export.ITiffOptions و Aspose.Slides.Export.TiffOptions لتحديد صيغة البكسل للصور TIFF المُولَّدة.