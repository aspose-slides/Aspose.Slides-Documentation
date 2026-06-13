---
title: API عمومی و تغییرات ناسازگار معکوس در Aspose.Slides برای .NET 16.2.0
linktitle: Aspose.Slides برای .NET 16.2.0
type: docs
weight: 230
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- مهاجرت
- کد قدیمی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات مخرب در Aspose.Slides برای .NET را بررسی کنید تا به‌راحتی راه‌حل‌های ارائه PowerPoint PPT، PPTX و ODP خود را مهاجرت کنید."
---
{{% alert color="primary" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و موارد مشابهی را که [اضافه‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) یا [حذف‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) هستند، و سایر تغییراتی که با Aspose.Slides for .NET 16.2.0 API معرفی شده‌اند، فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
#### **ویژگی‌های UpdateDateTimeFields و UpdateSlideNumberFields حذف شده‌اند**
ویژگی‌های UpdateDateTimeFields و UpdateSlideNumberFields از کلاس Aspose.Slides.Presentation و از اینترفیس Aspose.Slides.IPresentation حذف شده‌اند.
ویژگی Text در کلاس‌های Aspose.Slides.TextFrame، Paragraph، Portion و اینترفیس‌های Aspose.Slides.ITextFrame، IParagraph، IPortion متن را با فیلدهای «datetime» به‌روز شده باز می‌گرداند.
همچنین ویژگی‌های Presentation.DocumentProperties.CreatedTime، LastSavedTime و LastPrinted فقط‑خواندنی شده‌اند.
#### **enum Slides.Charts.CategoryAxisType به حالت عمومی تغییر یافت**
در ویژگی‌های IAxis.CategoryAxisType و Axis.CategoryAxisType برای تعیین نوع محور دسته‌بندی استفاده می‌شود.
- CategoryAxisType.Auto : نوع محور دسته‌بندی به‌صورت خودکار در زمان سریال‌سازی تعیین می‌شود (این رفتار در حال حاضر پیاده‌سازی نشده است)
- CategoryAxisType.Text : نوع محور دسته‌بندی Text است
- CategoryAxisType.Date : نوع محور دسته‌بندی DateTime است
#### **استخراج سریع متن**
متد ایستاتیک جدید GetPresentationText به کلاس Presentation اضافه شده است. دو overload برای این متد وجود دارد:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

آرگومان enum ExtractionMode حالت سازماندهی خروجی متن را تعیین می‌کند و می‌تواند مقادیر زیر را داشته باشد:
- Unarranged : متن خام بدون توجه به موقعیت در اسلاید
- Arranged : متن به همان ترتیبی که در اسلاید قرار دارد سازماندهی می‌شود

حالت Unarranged زمانی مفید است که سرعت مهم باشد؛ این حالت سریع‌تر از حالت Arranged است.

PresentationText متن خام استخراج‌شده از ارائه را نشان می‌دهد. این کلاس ویژگی SlidesText از فضای نام Aspose.Slides.Util را در اختیار می‌گذارد که یک آرایه از اشیاء ISlideText را برمی‌گرداند. هر شیء متن اسلاید مربوطه را نمایندگی می‌کند. اشیاء ISlideText دارای ویژگی‌های زیر هستند:

- ISlideText.Text : متن روی اشکال اسلاید
- ISlideText.MasterText : متن روی اشکال صفحه اصلی برای این اسلاید
- ISlideText.LayoutText : متن روی اشکال صفحه چیدمان برای این اسلاید
- ISlideText.NotesText : متن روی اشکال صفحه یادداشت‌ها برای این اسلاید

همچنین کلاس SlideText که اینترفیس ISlideText را پیاده‌سازی می‌کند موجود است.

API جدید می‌تواند به این شکل استفاده شود:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **اینترفیس ILegacyDiagram و کلاس LegacyDiagram اضافه شدند**
اینترفیس Aspose.Slides.ILegacyDiagram و کلاس Aspose.Slides.LegacyDiagram برای نمایاندن شیء نمودار قدیمی افزوده شدند. شیء نمودار قدیمی قالب قدیمی نمودارها از PowerPoint 97‑2003 است.
کلاس جدید متدهایی برای تبدیل نمودار قدیمی به شیء SmartArt قابل ویرایش مدرن یا به GroupShape قابل ویرایش فراهم می‌کند.
#### **مقدار جدید Enum Aspose.Slides.TextAlignment اضافه شد (JustifyLow)**
یک مقدار جدید به enum TextAlignment افزوده شد:
- JustifyLow : ترازو کردن با کشش کَشی‌دا به صورت کم.

#### **ویژگی‌های جدید برای Aspose.Slides.IOleObjectFrame و OleObjectFrame**
ویژگی‌های جدیدی به اینترفیس IOleObjectFrame و کلاس OleObjectFrame که این اینترفیس را پیاده‌سازی می‌کند، اضافه شد. این ویژگی‌ها برای ارائه اطلاعات درباره شیء嵌入 شده در ارائه استفاده می‌شوند:
- EmbeddedFileExtension : پسوند فایل برای شیء嵌入 شده فعلی را برمی‌گرداند یا رشته خالی اگر شیء لینک نباشد
- EmbeddedFileLabel : نام فایل شیء OLE嵌入 شده را برمی‌گرداند
- EmbeddedFileName : مسیر شیء OLE嵌入 شده را برمی‌گرداند

#### **ویژگی جدید CategoryAxisType به کلاس‌های IAxis و Axis اضافه شد**
ویژگی CategoryAxisType نوع محور دسته‌بندی را مشخص می‌کند.

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
#### **ویژگی جدید ShowLabelAsDataCallout به کلاس DataLabelFormat و اینترفیس IDataLabelFormat اضافه شد**
ویژگی ShowLabelAsDataCallout تعیین می‌کند که آیا برچسب دادهٔ نمودار مشخص‌شده به صورت فراخوانی داده یا به صورت برچسب داده نمایش داده شود.

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
#### **ویژگی Boolean DrawSlidesFrame به PdfOptions و XpsOptions اضافه شد**
ویژگی Boolean DrawSlidesFrame به اینترفیس‌های Aspose.Slides.Export.IPdfOptions، Aspose.Slides.Export.IXpsOptions و به کلاس‌های مرتبط Aspose.Slides.Export.PdfOptions و Aspose.Slides.Export.XpsOptions اضافه شده است.
اگر این ویژگی مقدار «true» داشته باشد، قاب مشکی دور هر اسلاید رسم می‌شود.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```