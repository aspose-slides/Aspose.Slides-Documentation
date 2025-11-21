---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للوراء في Aspose.Slides for .NET 16.2.0
linktitle: Aspose.Slides for .NET 16.2.0
type: docs
weight: 230
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- الهجرة
- الكود القديم
- الكود الحديث
- النهج القديم
- النهج الحديث
- PowerPoint
- OpenDocument
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات الجذرية في Aspose.Slides for .NET لتسهيل ترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP الخاصة بك."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات، والأساليب، والخصائص، وما إلى ذلك، التي تم [المضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) أو [المزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) لها، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع واجهة برمجة تطبيقات Aspose.Slides for .NET 16.2.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تمت إزالة الخصائص UpdateDateTimeFields و UpdateSlideNumberFields**
تمت إزالة الخصائص UpdateDateTimeFields و UpdateSlideNumberFields من الفئة Aspose.Slides.Presentation ومن الواجهة Aspose.Slides.IPresentation.  
الخاصية Text في الفئات Aspose.Slides.TextFrame، Paragraph، Portion والواجهات Aspose.Slides.ITextFrame، IParagraph، IPortion تُعيد النص مع حقول "datetime" المحدثة.  
كما أصبحت الخصائص Presentation.DocumentProperties.CreatedTime و LastSavedTime و LastPrinted للقراءة فقط.  
#### **تم تحويل التعداد Slides.Charts.CategoryAxisType إلى public**
يُستخدم في خصائص IAxis.CategoryAxisType و Axis.CategoryAxisType لتحديد نوع محور الفئة.  
CategoryAxisType.Auto - سيتم تحديد نوع محور الفئة تلقائيًا أثناء السلسلة (هذا السلوك غير مُطبق حاليًا)  
CategoryAxisType.Text - نوع محور الفئة هو Text  
CategoryAxisType.Date - نوع محور الفئة هو DateTime  
#### **استخراج النص السريع**
تمت إضافة الطريقة الساكنة الجديدة GetPresentationText إلى الفئة Presentation. هناك تحميلان (overloads) لهذه الطريقة:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

معامل التعداد ExtractionMode يحدد وضع تنظيم ناتج النص ويمكن ضبطه على القيم التالية:  
Unarranged - النص الخام دون مراعاة موضعه على الشريحة  
Arranged - النص يتم ترتيبه بنفس ترتيب الشريحة  

يمكن استخدام وضع Unarranged عندما تكون السرعة حرجة، فهو أسرع من وضع Arranged.  

PresentationText يمثل النص الخام المستخرج من العرض التقديمي. يحتوي على خاصية SlidesText من مساحة الاسم Aspose.Slides.Util والتي تُعيد مصفوفة من كائنات ISlideText. كل كائن يمثل النص على الشريحة المقابلة. كائن ISlideText يحتوي على الخصائص التالية:  
ISlideText.Text - النص على أشكال الشريحة  
ISlideText.MasterText - النص على أشكال الصفحة الرئيسية لهذه الشريحة  
ISlideText.LayoutText - النص على أشكال صفحة التخطيط لهذه الشريحة  
ISlideText.NotesText - النص على أشكال صفحة الملاحظات لهذه الشريحة  

هناك أيضًا فئة SlideText التي تنفذ واجهة ISlideText.  

يمكن استخدام الواجهة الجديدة هكذا:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **تمت إضافة الواجهة ILegacyDiagram والفئة LegacyDiagram**
تمت إضافة الواجهة Aspose.Slides.ILegacyDiagram والفئة Aspose.Slides.LegacyDiagram لتمثيل كائن مخطط قديم. كائن المخطط القديم هو تنسيق قديم للمخططات من PowerPoint 97-2003.  
توفر الفئة الجديدة طرقًا لتحويل المخطط القديم إلى كائن SmartArt حديث قابل للتحرير أو إلى GroupShape قابل للتحرير.  
#### **تمت إضافة عضو جديد إلى تعداد Aspose.Slides.TextAlignment (JustifyLow)**
تمت إضافة عضو جديد إلى تعداد TextAlignment: JustifyLow - محاذاة كاشدة منخفضة.  
#### **خصائص جديدة لـ Aspose.Slides.IOleObjectFrame و OleObjectFrame**
تمت إضافة خصائص جديدة إلى واجهة IOleObjectFrame والفئة OleObjectFrame التي تنفذ هذه الواجهة. تُستخدم هذه الخصائص لتوفير معلومات حول كائن مضمّن في العرض التقديمي:  
EmbeddedFileExtension - يُرجع امتداد الملف للكائن المضمّن الحالي أو سلسلة فارغة إذا لم يكن الكائن رابطًا  
EmbeddedFileLabel - يُرجع اسم ملف كائن OLE المضمّن  
EmbeddedFileName - يُرجع مسار كائن OLE المضمّن  
#### **تمت إضافة الخاصية CategoryAxisType إلى الفئتين IAxis و Axis**
تحدد الخاصية CategoryAxisType نوع محور الفئة.

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
#### **تمت إضافة الخاصية ShowLabelAsDataCallout إلى الفئة DataLabelFormat والواجهة IDataLabelFormat**
تحدد الخاصية ShowLabelAsDataCallout ما إذا كان سيتم عرض تسمية بيانات المخطط المحدد كصندوق شرح بيانات أو كتسمية بيانات.

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
#### **تمت إضافة الخاصية DrawSlidesFrame إلى الفئتين PdfOptions و XpsOptions**
تمت إضافة الخاصية المنطقية DrawSlidesFrame إلى الواجهات Aspose.Slides.Export.IPdfOptions و Aspose.Slides.Export.IXpsOptions وإلى الفئات المرتبطة Aspose.Slides.Export.PdfOptions و Aspose.Slides.Export.XpsOptions. سيتم رسم إطار أسود حول كل شريحة إذا تم تعيين هذه الخاصية إلى "true".

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```