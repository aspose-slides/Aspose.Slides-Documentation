---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 15.7.0"
linktitle: "Aspose.Slides لـ .NET 15.7.0"
type: docs
weight: 180
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- ترحيل
- كود قديم
- كود حديث
- نهج تقليدي
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides لـ .NET للترحيل السلس لحلول العروض التقديمية PowerPoint PPT، PPTX و ODP."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات، الأساليب، الخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) والأية تغييرات أخرى تم تقديمها مع Aspose.Slides for .NET 15.7.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تم إضافة تعداد ImagePixelFormat**
تم إضافة تعداد Aspose.Slides.Export.ImagePixelFormat لتحديد تنسيق البكسل للصور المُولدة.
#### **تم إضافة طريقة IChartDataPoint.GetAutomaticDataPointColor()**
تُعيد لونًا تلقائيًا لنقطة البيانات بناءً على فهرس السلسلة، فهرس نقطة البيانات، ParentSeriesGroup، الخاصية IsColorVaried، ونمط المخطط.
يُستخدم هذا اللون افتراضيًا إذا كان FillType يساوي NotDefined.
#### **تم إضافة طريقة RenderToGraphics إلى Slide**
تم إضافة طريقة RenderToGraphics (ومتجاوزاتها) إلى Aspose.Slides.Slide لتصوير شريحة إلى كائن Graphics.
#### **تم إضافة الخاصية PixelFormat إلى ITiffOptions و TiffOptions**
تم إضافة الخاصية PixelFormat إلى Aspose.Slides.Export.ITiffOptions و Aspose.Slides.Export.TiffOptions لتحديد تنسيق البكسل للصور TIFF المُولدة.