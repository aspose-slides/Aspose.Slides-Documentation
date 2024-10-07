---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 15.11.0
type: docs
weight: 210
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
---

{{% alert color="primary" %}} 

تُدرج هذه الصفحة جميع [الإضافات](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) أو [الإلغاءات](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) من الفئات والطرق والخصائص وما إلى ذلك، والتغييرات الأخرى التي تم إدخالها مع Aspose.Slides لـ .NET 15.11.0 API.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**

#### **تم حذف الخصائص المهملة في فئة DataLabelCollection**
تم حذف الخصائص المهملة في فئة DataLabelCollection:
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
تسمح الخاصية الجديدة FirstSlideNumber المضافة إلى Presentation بالحصول على أو تعيين رقم الشريحة الأولى في العرض التقديمي.

عند تحديد قيمة جديدة لـ FirstSlideNumber، يتم إعادة حساب جميع أرقام الشرائح.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```