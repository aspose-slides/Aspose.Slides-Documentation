---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 15.11.0
linktitle: Aspose.Slides for .NET 15.11.0
type: docs
weight: 210
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- الهجرة
- رمز قديم
- رمز حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides for .NET لتحديث حلول العروض التقديمية PowerPoint PPT و PPTX و ODP بسلاسة."
---

{{% alert color="primary" %}} 
تُظهر هذه الصفحة جميع الفئات، الأساليب، الخصائص وما إلى ذلك المضافة أو المُزالة، وغيرها من التغييرات التي تم تقديمها في واجهة برمجة تطبيقات Aspose.Slides for .NET 15.11.0 API.
{{% /alert %}} 
## **التغييرات العامة لواجهة برمجة التطبيقات**

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

#### **تم إضافة الخاصية الجديدة FirstSlideNumber إلى فئة Presentation**
تسمح الخاصية الجديدة FirstSlideNumber المضافة إلى فئة Presentation بالحصول على رقم الشريحة الأولى أو تعيينه في العرض التقديمي.

عند تحديد قيمة جديدة لـ FirstSlideNumber يتم إعادة حساب أرقام جميع الشرائح.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```