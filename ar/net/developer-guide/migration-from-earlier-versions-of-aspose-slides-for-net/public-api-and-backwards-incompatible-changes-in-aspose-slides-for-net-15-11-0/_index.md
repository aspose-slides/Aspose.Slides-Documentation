---
title: تغييرات واجهة برمجة التطبيقات العامة وغير المتوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 15.11.0
linktitle: Aspose.Slides for .NET 15.11.0
type: docs
weight: 210
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- ترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- باوربوينت
- مستند مفتوح
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتكسرة في Aspose.Slides for .NET لتسهيل ترحيل حلول عروض PowerPoint PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 

تُدرج هذه الصفحة جميع الفئات أو الأساليب أو الخصائص أو غيرها التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/)، وكذلك التغييرات الأخرى التي تم تقديمها في واجهة برمجة تطبيقات Aspose.Slides for .NET الإصدار 15.11.0.

{{% /alert %}} 
## **التغييرات العامة في واجهة البرمجة**

#### **تم حذف الخصائص القديمة في فئة DataLabelCollection**
تم حذف الخصائص القديمة في فئة DataLabelCollection:
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
تسمح الخاصية الجديدة FirstSlideNumber المضافة إلى فئة Presentation بالحصول على رقم الشريحة الأولى في العرض أو تعيينه.

عند تحديد قيمة جديدة لـ FirstSlideNumber يتم إعادة حساب أرقام جميع الشرائح.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```