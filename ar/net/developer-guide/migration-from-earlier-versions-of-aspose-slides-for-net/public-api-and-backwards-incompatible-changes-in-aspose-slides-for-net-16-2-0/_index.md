---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للوراء في Aspose.Slides ل .NET 16.2.0
linktitle: Aspose.Slides ل .NET 16.2.0
type: docs
weight: 230
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- تحويل
- شفرة قديمة
- شفرة حديثة
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتقطعة في Aspose.Slides ل .NET لتسهيل نقل حلول عروض PowerPoint PPT و PPTX و ODP الخاصة بك."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات [added](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) أو [removed](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) أو الأساليب أو الخصائص وما إلى ذلك، وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 16.2.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تم إزالة الخصائص UpdateDateTimeFields و UpdateSlideNumberFields**
تمت إزالة الخصائص UpdateDateTimeFields و UpdateSlideNumberFields من الفئة Aspose.Slides.Presentation ومن الواجهة Aspose.Slides.IPresentation.
خاصية Text في الفئات Aspose.Slides.TextFrame و Paragraph و Portion والواجهات Aspose.Slides.ITextFrame و IParagraph و IPortion تُعيد النص مع حقول "datetime" المحدثة.
كما أصبحت الخصائص Presentation.DocumentProperties.CreatedTime و LastSavedTime و LastPrinted للقراءة فقط.
#### **تم تحويل تعداد Slides.Charts.CategoryAxisType إلى عام**
يُستخدم في خصائص IAxis.CategoryAxisType و Axis.CategoryAxisType لتحديد نوع محور الفئة.
CategoryAxisType.Auto - سيتم تحديد نوع محور الفئة تلقائيًا أثناء التسلسل (هذا السلوك غير مُطبق حاليًا)
CategoryAxisType.Text - نوع محور الفئة هو Text
CategoryAxisType.Date - نوع محور الفئة هو DateTime
#### **استخراج نص سريع**
تمت إضافة الطريقة الساكنة الجديدة GetPresentationText إلى الفئة Presentation. هناك overloads اثنان لهذه الطريقة:

``` csharp
 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)
``` 

معامل التعداد ExtractionMode يحدد وضع تنظيم ناتج النص ويمكن تعيينه إلى القيم التالية:
Unarranged - النص الخام دون احترام الموقع على الشريحة
Arranged - يُرتب النص بنفس ترتيب ظهوره على الشريحة

يمكن استخدام وضع Unarranged عندما تكون السرعة حرجة، فهو أسرع من وضع Arranged.

PresentationText يمثل النص الخام المستخرج من العرض. يحتوي على خاصية SlidesText من مساحة الاسم Aspose.Slides.Util التي تُعيد مصفوفة من كائنات ISlideText. كل كائن يمثل النص على الشريحة المقابلة. كائن ISlideText يمتلك الخصائص التالية:

ISlideText.Text - النص على أشكال الشريحة
ISlideText.MasterText - النص على أشكال الصفحة الرئيسية لهذه الشريحة
ISlideText.LayoutText - النص على أشكال صفحة التخطيط لهذه الشريحة
ISlideText.NotesText - النص على أشكال صفحة الملاحظات لهذه الشريحة

هناك أيضًا فئة SlideText التي تُنفّذ واجهة ISlideText.

يمكن استخدام API الجديد كالتالي:

``` csharp
 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)
``` 
#### **تم إضافة الواجهة ILegacyDiagram والفئة LegacyDiagram**
تمت إضافة الواجهة Aspose.Slides.ILegacyDiagram والفئة Aspose.Slides.LegacyDiagram لتمثيل كائن مخطط قديم. كائن المخطط القديم هو تنسيق قديم للمخططات من PowerPoint 97-2003.
توفر الفئة الجديدة طرقًا لتحويل المخطط القديم إلى كائن SmartArt قابل للتحرير حديث أو إلى GroupShape قابل للتحرير.
#### **إضافة عضو جديد إلى تعداد Aspose.Slides.TextAlignment (JustifyLow)**
تمت إضافة عضو جديد إلى تعداد TextAlignment:
JustifyLow - محاذاة كاشدة منخفضة.
#### **خصائص جديدة لـ Aspose.Slides.IOleObjectFrame و OleObjectFrame**
تمت إضافة خصائص جديدة إلى واجهة IOleObjectFrame والفئة OleObjectFrame التي تنفّذ هذه الواجهة. تُستخدم هذه الخصائص لتوفير معلومات حول كائن مضمن في العرض:
EmbeddedFileExtension - يُعيد امتداد الملف للكائن المضمن الحالي أو سلسلة فارغة إذا لم يكن الكائن رابطًا
EmbeddedFileLabel - يُعيد اسم ملف كائن OLE المضمن
EmbeddedFileName - يُعيد مسار كائن OLE المضمن
#### **تم إضافة الخاصية CategoryAxisType إلى فئات IAxis و Axis**
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
#### **تمت إضافة الخاصية ShowLabelAsDataCallout إلى فئة DataLabelFormat والواجهة IDataLabelFormat**
تحدد الخاصية ShowLabelAsDataCallout ما إذا كان سيتم عرض تسمية بيانات المخطط المحدد كـ "data callout" أم كتسمية بيانات.

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
#### **تمت إضافة الخاصية DrawSlidesFrame إلى PdfOptions و XpsOptions**
تمت إضافة الخاصية البوليانية DrawSlidesFrame إلى الواجهات Aspose.Slides.Export.IPdfOptions و Aspose.Slides.Export.IXpsOptions وإلى الفئات المرتبطة Aspose.Slides.Export.PdfOptions و Aspose.Slides.Export.XpsOptions.
سيتم رسم الإطار الأسود حول كل شريحة إذا تم تعيين هذه الخاصية إلى true.

``` csharp
 using (Presentation pres = new Presentation("input.pptx"))
{
    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });
}
```