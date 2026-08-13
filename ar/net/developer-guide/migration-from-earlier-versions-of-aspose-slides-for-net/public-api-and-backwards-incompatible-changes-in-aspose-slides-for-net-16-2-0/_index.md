---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 16.2.0
linktitle: Aspose.Slides لـ .NET 16.2.0
type: docs
weight: 230
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- الترحيل
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
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتقطعة في Aspose.Slides لـ .NET للترحيل السلس لحلول عروض PowerPoint (PPT, PPTX) و ODP."
---
{{% alert color="info" %}} 

هذه الصفحة تسرد جميع الفئات [added](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) أو [removed](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)، الطرق، الخصائص وما إلى ذلك، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 16.2.0 API.

{{% /alert %}} 
## **التغييرات العامة لواجهة برمجة التطبيقات**
#### **تمت إزالة الخاصيتين UpdateDateTimeFields و UpdateSlideNumberFields**
تمت إزالة الخصائص UpdateDateTimeFields و UpdateSlideNumberFields من الفئة Aspose.Slides.Presentation ومن الواجهة Aspose.Slides.IPresentation.
تعيد الخاصية Text في الفئات Aspose.Slides.TextFrame و Paragraph و Portion والواجهات Aspose.Slides.ITextFrame و IParagraph و IPortion النص مع الحقول "datetime" المحدثة.
كما أصبحت الخصائص Presentation.DocumentProperties.CreatedTime و LastSavedTime و LastPrinted للقراءة فقط.
#### **تم تحويل تعداد Slides.Charts.CategoryAxisType إلى عام**
يستخدم في خاصيتي IAxis.CategoryAxisType و Axis.CategoryAxisType لتحديد نوع محور الفئة.
CategoryAxisType.Auto – سيتم تحديد نوع محور الفئة تلقائيًا أثناء التسلسل (هذا السلوك غير مُطبق حاليًا)
CategoryAxisType.Text – نوع محور الفئة هو نص
CategoryAxisType.Date – نوع محور الفئة هو تاريخ/وقت
#### **استخراج النص بسرعة**
تمت إضافة الطريقة الساكنة الجديدة GetPresentationText إلى فئة Presentation. هناك تحميلان لهذه الطريقة:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

المعامل enum ExtractionMode يحدد وضع تنظيم ناتج النص ويمكن تعيينه إلى القيم التالية:
Unarranged – النص الخام دون مراعاة موقعه على الشريحة
Arranged – يُرتب النص بنفس ترتيب عرضه على الشريحة

يمكن استخدام وضع Unarranged عندما يكون السرعة أمرًا حاسمًا؛ فهو أسرع من وضع Arranged.

PresentationText يمثل النص الخام المستخرج من العرض. يحتوي على خاصية SlidesText من مساحة الاسم Aspose.Slides.Util التي تُعيد مصفوفة من كائنات ISlideText. كل كائن يمثل النص على الشريحة المقابلة. كائن ISlideText يحتوي على الخصائص التالية:

ISlideText.Text – النص على أشكال الشريحة
ISlideText.MasterText – النص على أشكال الصفحة الرئيسية لتلك الشريحة
ISlideText.LayoutText – النص على أشكال صفحة التخطيط لتلك الشريحة
ISlideText.NotesText – النص على أشكال صفحة الملاحظات لتلك الشريحة

هناك أيضًا فئة SlideText التي تُنفّذ الواجهة ISlideText.

يمكن استخدام الواجهة البرمجية الجديدة بهذه الطريقة:

``` csharp
using System;
using Aspose.Slides;

// استخراج النص دون مراعاة موقعه على الشريحة (أسرع وضع).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// استخراج النص المرتب بنفس ترتيب وجوده على الشريحة.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **تم إضافة الواجهة ILegacyDiagram وفئة LegacyDiagram**
تم إضافة الواجهة Aspose.Slides.ILegacyDiagram والفئة Aspose.Slides.LegacyDiagram لتمثيل كائن مخطط قديم. كائن المخطط القديم هو صيغة مخططات قديمة من PowerPoint 97-2003.
توفر الفئة الجديدة طرقًا لتحويل المخطط القديم إلى كائن SmartArt قابل للتحرير حديثًا أو إلى GroupShape قابل للتحرير.
#### **تم إضافة عضو جديد إلى تعداد Aspose.Slides.TextAlignment (JustifyLow)**
تم إضافة عضو جديد إلى تعداد TextAlignment:
JustifyLow – ضبط المحاذاة الكاشدة منخفضًا.
#### **خصائص جديدة لـ Aspose.Slides.IOleObjectFrame و OleObjectFrame**
تمت إضافة خصائص جديدة إلى واجهة IOleObjectFrame والفئة OleObjectFrame التي تُطبق هذه الواجهة. تُستخدم هذه الخصائص لتقديم معلومات عن كائن مضمّن في العرض:
EmbeddedFileExtension – تُرجع امتداد الملف للكائن المضمّن الحالي أو سلسلة فارغة إذا لم يكن الكائن رابطًا
EmbeddedFileLabel – تُرجع اسم ملف كائن OLE المضمّن
EmbeddedFileName – تُرجع مسار كائن OLE المضمّن
#### **تمت إضافة خاصية CategoryAxisType إلى فئتي IAxis و Axis**
تحدد الخاصية CategoryAxisType نوع محور الفئة.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string sourcePptxFileName = "chart.pptx";
string pptxOutPath = "chart_out.pptx";

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
تحدد الخاصية ShowLabelAsDataCallout ما إذا كان سيتم عرض تسمية بيانات المخطط المحدد كقيمة استدعاء بيانات أو كتسمية بيانات.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string pptxFileName = "callout_labels.pptx";

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
تمت إضافة الخاصية المنطقية DrawSlidesFrame إلى الواجهات Aspose.Slides.Export.IPdfOptions و Aspose.Slides.Export.IXpsOptions وإلى الفئات المرتبطة Aspose.Slides.Export.PdfOptions و Aspose.Slides.Export.XpsOptions.
سيتم رسم إطار أسود حول كل شريحة إذا تم تعيين هذه الخاصية إلى 'true'.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```