---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 15.7.0
type: docs
weight: 180
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
---

{{% alert color="primary" %}} 

تدرج هذه الصفحة جميع [المضاف](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) أو [المزال](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) من الفئات، والطرق، والخصائص، وما إلى ذلك، والتغييرات الأخرى المقدمة مع واجهة برمجة تطبيقات Aspose.Slides لـ .NET 15.7.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تم إضافة Enums ImagePixelFormat**
تم إضافة Enum Aspose.Slides.Export.ImagePixelFormat لتحديد تنسيق البكسل للصور المولدة.
#### **تم إضافة method IChartDataPoint.GetAutomaticDataPointColor()**
يعيد لونًا تلقائيًا لنقطة البيانات استنادًا إلى فهرس السلسلة، فهرس نقطة البيانات، ParentSeriesGroup، خاصية IsColorVaried ونمط الرسم البياني.
يستخدم هذا اللون بشكل افتراضي إذا كان FillType يساوي NotDefined.
#### **تم إضافة method RenderToGraphics إلى Slide**
تم إضافة method RenderToGraphics (و تحميلاتها) إلى Aspose.Slides.Slide لرسم شريحة إلى كائن Graphics.
#### **تم إضافة Property PixelFormat إلى ITiffOptions و TiffOptions**
تم إضافة Property PixelFormat إلى Aspose.Slides.Export.ITiffOptions و Aspose.Slides.Export.TiffOptions لتحديد تنسيق البكسل للصور TIFF المولدة.