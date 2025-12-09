---
title: التغييرات العامة في واجهة برمجة التطبيقات والتغييرات غير المتوافقة للخلف في Aspose.Slides لـ .NET 15.11.0
linktitle: Aspose.Slides لـ .NET 15.11.0
type: docs
weight: 210
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- الترحيل
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
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات والطرق والخصائص وما إلى ذلك التي تم [مضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/)، بالإضافة إلى التغييرات الأخرى التي تم إدخالها في واجهة برمجة تطبيقات Aspose.Slides for .NET 15.11.0.

{{% /alert %}} 
## **تغييرات API العامة**

#### **تم حذف الخصائص المهجورة في فئة DataLabelCollection**
تم حذف الخصائص المهجورة في فئة DataLabelCollection:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **تمت إضافة الخاصية الجديدة FirstSlideNumber إلى فئة Presentation**
الخاصية الجديدة FirstSlideNumber المضافة إلى Presentation تتيح الحصول على رقم الشريحة الأولى أو تعيينه في العرض التقديمي.

عند تحديد قيمة جديدة لـ FirstSlideNumber يتم إعادة حساب أرقام جميع الشرائح.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```