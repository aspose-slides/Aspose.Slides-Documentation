---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET 16.2.0
type: docs
weight: 230
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
---

{{% alert color="primary" %}} 

تحتوي هذه الصفحة على قائمة بجميع [المضافات](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) أو [المزالة](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) من الفئات والطرق والخصائص وما إلى ذلك، والتغييرات الأخرى المقدمة مع واجهة برمجة التطبيقات Aspose.Slides لـ .NET 16.2.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تمت إزالة الخصائص UpdateDateTimeFields و UpdateSlideNumberFields**
تمت إزالة الخصائص UpdateDateTimeFields و UpdateSlideNumberFields من فئة Aspose.Slides.Presentation ومن واجهة Aspose.Slides.IPresentation.
تُعيد خاصية النص في Aspose.Slides.TextFrame، الفقرة، Portion النص مع حقول "datetime" المحدثة.
أيضًا، أصبحت الخصائص Presentation.DocumentProperties.CreatedTime و LastSavedTime و LastPrinted للقراءة فقط.
#### **تحويل Enum Slides.Charts.CategoryAxisType إلى عام**
تستخدم في الخصائص IAxis.CategoryAxisType و Axis.CategoryAxisType لتحديد نوع محور الفئة.
CategoryAxisType.Auto - سيتم تحديد نوع محور الفئة تلقائياً أثناء التسلسل (هذا السلوك غير متوفر حالياً).
CategoryAxisType.Text - نوع محور الفئة هو نص.
CategoryAxisType.Date - نوع محور الفئة هو DateTime.
#### **استخراج النص بسرعة**
تمت إضافة أسلوب ثابت جديد GetPresentationText إلى فئة Presentation. يوجد نوعان من التحميلات لهذا الأسلوب:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

تشير حجة نوع استخراج البيانات ExtractionMode إلى الوضع لتنظيم نتائج النص ويمكن تعيينها إلى القيم التالية:
Unarranged - النص الخام بدون احترام للمكان على الشريحة.
Arranged - يتم وضع النص بنفس ترتيب وجوده على الشريحة.

يمكن استخدام وضع Unarranged عندما تكون السرعة حرجة، فهو أسرع من وضع Arranged.

يمثل PresentationText النص الخام المستخرج من العرض التقديمي. يحتوي على خاصية SlidesText من مساحة أسماء Aspose.Slides.Util التي تُعيد مصفوفة من كائنات ISlideText. يمثل كل كائن النص على الشريحة المعنية. تحتوي كائنات ISlideText على الخصائص التالية:

ISlideText.Text - النص على أشكال الشريحة.
ISlideText.MasterText - النص على أشكال الصفحة الرئيسية لهذه الشريحة.
ISlideText.LayoutText - النص على أشكال الصفحة التخطيطية لهذه الشريحة.
ISlideText.NotesText - النص على أشكال صفحة الملاحظات لهذه الشريحة.

هناك أيضًا فئة SlideText التي تنفذ واجهة ISlideText.

يمكن استخدام واجهة برمجة التطبيقات الجديدة بهذه الطريقة:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **تمت إضافة واجهة ILegacyDiagram وفئة LegacyDiagram**
تمت إضافة واجهة Aspose.Slides.ILegacyDiagram وفئة Aspose.Slides.LegacyDiagram لتمثيل كائن الرسم البياني القديم. كائن الرسم البياني القديم هو تنسيق قديم للرسم البياني من PowerPoint 97-2003.
توفر هذه الفئة الجديدة طرقاً لتحويل الرسم البياني القديم إلى كائن SmartArt القابل للتعديل الحديث أو إلى GroupShape القابل للتعديل.
#### **إضافة عنصر جديد إلى enum Aspose.Slides.TextAlignment (JustifyLow)**
تمت إضافة عنصر جديد إلى enum TextAlignment:
JustifyLow - محاذاة كاشيدة منخفضة.
#### **خصائص جديدة لـ Aspose.Slides.IOleObjectFrame و OleObjectFrame**
تمت إضافة خصائص جديدة إلى واجهة IOleObjectFrame وفئة OleObjectFrame التي تنفذ هذه الواجهة. تُستخدم هذه الخصائص لتوفير معلومات حول الكائن المضمن في العرض التقديمي:
EmbeddedFileExtension - تُعيد امتداد الملف للكائن المضمن الحالي أو سلسلة فارغة إذا لم يكن الكائن رابطًا.
EmbeddedFileLabel - تُعيد اسم ملف كائن OLE المضمن.
EmbeddedFileName - تُعيد مسار كائن OLE المضمن.
#### **تمت إضافة خاصية CategoryAxisType إلى الفئات IAxis و Axis**
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
#### **تمت إضافة خاصية ShowLabelAsDataCallout إلى فئة DataLabelFormat وواجهة IDataLabelFormat**
تحدد خاصية ShowLabelAsDataCallout ما إذا كانت علامة البيانات الخاصة بالرسم البياني ستظهر كعلامة بيانات أو كدعوة بيانات.

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
تمت إضافة خاصية Boolean DrawSlidesFrame إلى واجهات Aspose.Slides.Export.IPdfOptions و Aspose.Slides.Export.IXpsOptions وإلى الفئات ذات الصلة Aspose.Slides.Export.PdfOptions و Aspose.Slides.Export.XpsOptions.
سيتم رسم الإطار الأسود حول كل شريحة إذا تم تعيين هذه الخاصية إلى 'true'.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

``` 