---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع النسخ السابقة في Aspose.Slides for .NET 15.11.0
linktitle: Aspose.Slides لـ .NET 15.11.0
type: docs
weight: 210
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
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
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتعارضة في Aspose.Slides for .NET لترحيل عروض PowerPoint PPT و PPTX و ODP بسلاسة."
---
{{% alert color="info" %}} 
هذه الصفحة تسرد جميع الفئات، الطرق، الخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 15.11.0 API.
{{% /alert %}} 
## **التغييرات العامة لواجهة برمجة التطبيقات**

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
تسمح الخاصية الجديدة FirstSlideNumber المضافة إلى Presentation بالحصول على رقم الشريحة الأولى أو تعيينه في العرض التقديمي.

عند تحديد قيمة جديدة لـ FirstSlideNumber يتم إعادة حساب جميع أرقام الشرائح.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string path = "sample.pptx";
string newPath = "output.pptx";

using (var pres = new Presentation(path))
{
    int firstSlideNumber = pres.FirstSlideNumber;

    pres.FirstSlideNumber = 10;

    pres.Save(newPath, SaveFormat.Pptx);
}
```