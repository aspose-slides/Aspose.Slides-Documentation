---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET 15.7.0
linktitle: Aspose.Slides لـ .NET 15.7.0
type: docs
weight: 180
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- ترحيل
- شفرة قديمة
- شفرة حديثة
- منهجية قديمة
- منهجية حديثة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات الكاسرة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول عرض PowerPoint PPT و PPTX و ODP الخاصة بك."
---
{{% alert color="info" %}} 

تُدرج هذه الصفحة جميع الفئات، والطرق، والخصائص، وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) ، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 15.7.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تم إضافة Enum ImagePixelFormat**
تم إضافة Enum Aspose.Slides.Export.ImagePixelFormat لتحديد تنسيق البكسل للصور التي تم إنشاؤها.
#### **تم إضافة طريقة IChartDataPoint.GetAutomaticDataPointColor()**
تعيد لونًا تلقائيًا لنقطة البيانات استنادًا إلى فهرس السلسلة، فهرس نقطة البيانات، ParentSeriesGroup، الخاصية IsColorVaried، ونمط المخطط. يُستخدم هذا اللون افتراضيًا إذا كانت FillType تساوي NotDefined.
#### **تم إضافة طريقة RenderToGraphics إلى Slide**
تم إضافة طريقة RenderToGraphics (ومشتقاتها) إلى Aspose.Slides.Slide لعرض شريحة إلى كائن Graphics.
#### **تم إضافة خاصية PixelFormat إلى ITiffOptions و TiffOptions**
تم إضافة خاصية PixelFormat إلى Aspose.Slides.Export.ITiffOptions و Aspose.Slides.Export.TiffOptions لتحديد تنسيق البكسل للصور TIFF التي تم إنشاؤها.