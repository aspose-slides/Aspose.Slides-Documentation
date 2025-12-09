---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 16.2.0"
linktitle: "Aspose.Slides لـ .NET 16.2.0"
type: docs
weight: 230
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
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
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتقطعة في Aspose.Slides لـ .NET للانتقال بسلاسة حلول العروض التقديمية PowerPoint بصيغ PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع الفئات [المضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) أو [المزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) والطرق والخصائص وما إلى ذلك، وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 16.2.0 API.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تمت إزالة الخصائص UpdateDateTimeFields و UpdateSlideNumberFields**
تمت إزالة الخصائص UpdateDateTimeFields و UpdateSlideNumberFields من الفئة Aspose.Slides.Presentation ومن الواجهة Aspose.Slides.IPresentation.
خاصية Text في الفئات Aspose.Slides.TextFrame و Paragraph و Portion وفي الواجهات Aspose.Slides.ITextFrame و IParagraph و IPortion تُعيد النص مع حقول "datetime" المحدثة.
كما أصبحت الخصائص Presentation.DocumentProperties.CreatedTime و LastSavedTime و LastPrinted للقراءة فقط.
#### **تم تحويل التعداد Slides.Charts.CategoryAxisType إلى عام**
يُستخدم في خصائص IAxis.CategoryAxisType و Axis.CategoryAxisType لتحديد نوع محور الفئة.
- `CategoryAxisType.Auto` - سيتم تحديد نوع محور الفئة تلقائيًا أثناء التسلسل (هذا السلوك غير مُطبق حاليًا)
- `CategoryAxisType.Text` - نوع محور الفئة هو Text
- `CategoryAxisType.Date` - نوع محور الفئة هو DateTime
#### **استخراج النص السريع**
تم إضافة طريقة ثابتة جديدة GetPresentationText إلى فئة Presentation. هناك تحميلان (overloads) لهذه الطريقة:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

معامل التعداد ExtractionMode يشير إلى الوضع المستخدم لتنظيم مخرجات النص ويمكن تعيينه إلى القيم التالية:
- `Unarranged` - النص الخام دون مراعاة موضعه على الشريحة
- `Arranged` - يُوضع النص بالترتيب نفسه كما هو على الشريحة

يمكن استخدام وضع Unarranged عندما تكون السرعة حاسمة، فهو أسرع من وضع Arranged.
يمثل PresentationText النص الخام المستخرج من العرض. يحتوي على خاصية SlidesText من مساحة الاسم Aspose.Slides.Util والتي تُعيد مجموعة من كائنات ISlideText. كل كائن يمثل النص على الشريحة المقابلة. كائن ISlideText يحتوي على الخصائص التالية:
- `ISlideText.Text` - النص على أشكال الشريحة
- `ISlideText.MasterText` - النص على أشكال الصفحة الرئيسية لهذه الشريحة
- `ISlideText.LayoutText` - النص على أشكال صفحة التخطيط لهذه الشريحة
- `ISlideText.NotesText` - النص على أشكال صفحة الملاحظات لهذه الشريحة
هناك أيضًا فئة SlideText التي تُطبق الواجهة ISlideText.
يمكن استخدام الواجهة الجديدة كالتالي:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **تم إضافة الواجهة ILegacyDiagram والفئة LegacyDiagram**
تم إضافة الواجهة Aspose.Slides.ILegacyDiagram والفئة Aspose.Slides.LegacyDiagram لتمثيل كائن مخطط Legacy. كائن مخطط Legacy هو صيغة قديمة للمخططات من PowerPoint 97-2003.
توفر الفئة الجديدة طرقًا لتحويل مخطط Legacy إلى كائن SmartArt حديث قابل للتحرير أو إلى GroupShape قابل للتحرير.
#### **تمت إضافة عضو جديد إلى تعداد Aspose.Slides.TextAlignment (JustifyLow)**
تمت إضافة عضو جديد إلى تعداد TextAlignment:
JustifyLow - محاذاة منخفضة باستخدام الكاشدة.
#### **خصائص جديدة لـ Aspose.Slides.IOleObjectFrame و OleObjectFrame**
تمت إضافة خصائص جديدة إلى واجهة IOleObjectFrame والفئة OleObjectFrame التي تُطبق هذه الواجهة. تُستخدم هذه الخصائص لتوفير معلومات حول كائن مضمّن في العرض:
- `EmbeddedFileExtension` - يُرجِع امتداد الملف للكائن المضمّن الحالي أو سلسلة فارغة إذا لم يكن الكائن رابطًا
- `EmbeddedFileLabel` - يُرجِع اسم ملف كائن OLE المضمّن
- `EmbeddedFileName` - يُرجِع مسار كائن OLE المضمّن
#### **تمت إضافة خاصية CategoryAxisType إلى فئتي IAxis و Axis**
تحدد خاصية CategoryAxisType نوع محور الفئة.

``` csharp

 using (Presentation pres = new Presentation(sourcePptxFileName))

{

   IChart chart = pres.Slides[0].Shapes[0] as IChart;

   chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;

   chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;

   chart.Axes.HorizontalAxis.MajorUnit = 1;

   chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

   pres.Save(pptxOutPath, SaveFormat.Pptx);

}

``` 
#### **تمت إضافة خاصية ShowLabelAsDataCallout إلى فئة DataLabelFormat والواجهة IDataLabelFormat**
تحدد خاصية ShowLabelAsDataCallout ما إذا كان سيتم عرض تسمية البيانات للمرسوم البياني المحدد كنداء بيانات أو كتسمية بيانات.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

   pres.Save(pptxFileName, SaveFormat.Pptx);

}

``` 
#### **تمت إضافة خاصية DrawSlidesFrame إلى PdfOptions و XpsOptions**
تمت إضافة الخاصية المنطقية DrawSlidesFrame إلى الواجهات Aspose.Slides.Export.IPdfOptions و Aspose.Slides.Export.IXpsOptions وإلى الفئات المرتبطة Aspose.Slides.Export.PdfOptions و Aspose.Slides.Export.XpsOptions.
سيتم رسم إطار أسود حول كل شريحة إذا تم تعيين هذه الخاصية إلى 'true'.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```