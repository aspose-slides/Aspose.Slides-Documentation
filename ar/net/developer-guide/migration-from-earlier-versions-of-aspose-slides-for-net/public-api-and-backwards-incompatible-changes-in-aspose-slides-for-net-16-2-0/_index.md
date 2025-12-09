---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 16.2.0
linktitle: Aspose.Slides لـ .NET 16.2.0
type: docs
weight: 230
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
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
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات الجذرية في Aspose.Slides لـ .NET لتسهيل ترحيل حلول عرض PowerPoint PPT و PPTX و ODP الخاصة بك."
---

{{% alert color="primary" %}} 

توفر هذه الصفحة جميع الفئات [مضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) أو [محذوفة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)، والطرق، والخصائص، وما إلى ذلك، وغيرها من التغييرات التي تم إدخالها مع Aspose.Slides for .NET 16.2.0 API.

{{% /alert %}} 
## **تغييرات الواجهة العامة للبرمجة**
#### **تم إزالة الخصائص UpdateDateTimeFields و UpdateSlideNumberFields**
تم إزالة الخصائص UpdateDateTimeFields و UpdateSlideNumberFields من الفئة Aspose.Slides.Presentation ومن الواجهة Aspose.Slides.IPresentation.  
خاصية Text في الفئات Aspose.Slides.TextFrame و Paragraph و Portion والواجهات Aspose.Slides.ITextFrame و IParagraph و IPortion تُعيد النص مع حقول "datetime" محدثة.  
كما أصبحت الخصائص Presentation.DocumentProperties.CreatedTime و LastSavedTime و LastPrinted للقراءة فقط.

#### **تم جعل التعداد Slides.Charts.CategoryAxisType عامًا**
يُستخدم في خصائص IAxis.CategoryAxisType و Axis.CategoryAxisType لتحديد نوع محور الفئة.  
CategoryAxisType.Auto - سيتم تحديد نوع محور الفئة تلقائيًا أثناء التسلسل (هذا السلوك غير مُطبق حاليًا)  
CategoryAxisType.Text - نوع محور الفئة هو Text  
CategoryAxisType.Date - نوع محور الفئة هو DateTime  

#### **استخراج النص السريع**
تم إضافة الطريقة الساكنة الجديدة GetPresentationText إلى فئة Presentation. هناك تحميلان (overloads) لهذه الطريقة:

``` csharp
PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)
``` 

معامل التعداد ExtractionMode يحدد طريقة تنظيم ناتج النص ويمكن ضبطه إلى القيم التالية:  
Unarranged - النص الخام دون مراعاة موضعه على الشريحة  
Arranged - النص مرتّب بنفس ترتيب ظهورها على الشريحة  

يمكن استخدام وضع Unarranged عندما تكون السرعة أمرًا حاسمًا؛ فهو أسرع من وضع Arranged.

يمثل PresentationText النص الخام المستخرج من العرض. يحتوي على خاصية SlidesText من مساحة الأسماء Aspose.Slides.Util التي تُعيد مصفوفة من كائنات ISlideText. كل كائن يمثل النص على الشريحة المقابلة. كائن ISlideText لديه الخصائص التالية:

ISlideText.Text - النص في أشكال الشريحة  
ISlideText.MasterText - النص في أشكال الصفحة الرئيسية لتلك الشريحة  
ISlideText.LayoutText - النص في أشكال صفحة التخطيط لتلك الشريحة  
ISlideText.NotesText - النص في ملاحظات الشريحة  

هناك أيضًا فئة SlideText التي تُنفّذ واجهة ISlideText.

يمكن استخدام الواجهة البرمجية الجديدة كالتالي:

``` csharp
PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)
``` 

#### **إضافة الواجهة ILegacyDiagram والفئة LegacyDiagram**
تم إضافة الواجهة Aspose.Slides.ILegacyDiagram والفئة Aspose.Slides.LegacyDiagram لتمثيل كائن مخطط قديم. المخطط القديم هو تنسيق مخططات من PowerPoint 97-2003.  
توفر الفئة الجديدة طرقًا لتحويل المخطط القديم إلى كائن SmartArt قابل للتحرير أو إلى GroupShape قابل للتحرير.

#### **إضافة عضو جديد إلى تعداد Aspose.Slides.TextAlignment (JustifyLow)**
تم إضافة العضو الجديد JustifyLow إلى تعداد TextAlignment:  
JustifyLow - محاذاة كاشدة منخفضة.

#### **خصائص جديدة لـ Aspose.Slides.IOleObjectFrame و OleObjectFrame**
تمت إضافة خصائص جديدة إلى واجهة IOleObjectFrame والفئة OleObjectFrame التي تنفّذ هذه الواجهة. تُستخدم هذه الخصائص لتوفير معلومات حول كائن مضمّن في العرض:  
EmbeddedFileExtension - تُعيد امتداد الملف للكائن المضمّن الحالي أو سلسلة فارغة إذا لم يكن الكائن رابطًا  
EmbeddedFileLabel - تُعيد اسم ملف كائن OLE المضمّن  
EmbeddedFileName - تُعيد مسار كائن OLE المضمّن  

#### **إضافة الخاصية CategoryAxisType إلى فئتي IAxis و Axis**
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

#### **إضافة الخاصية ShowLabelAsDataCallout إلى فئة DataLabelFormat والواجهة IDataLabelFormat**
تحدد الخاصية ShowLabelAsDataCallout ما إذا كان سيتم عرض تسمية البيانات المحددة في المخطط كمناداة بيانات أو كاسمية بيانات.

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

#### **إضافة الخاصية DrawSlidesFrame إلى PdfOptions و XpsOptions**
تمت إضافة الخاصية المنطقية DrawSlidesFrame إلى الواجهات Aspose.Slides.Export.IPdfOptions و Aspose.Slides.Export.IXpsOptions إلى الفئات المرتبطة Aspose.Slides.Export.PdfOptions و Aspose.Slides.Export.XpsOptions.  
سيتم رسم إطار أسود حول كل شريحة إذا تم تعيين هذه الخاصية إلى true.

``` csharp
using (Presentation pres = new Presentation("input.pptx"))
{
    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });
}
```