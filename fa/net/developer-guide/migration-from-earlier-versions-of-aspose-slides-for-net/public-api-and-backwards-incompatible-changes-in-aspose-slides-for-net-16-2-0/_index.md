---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای .NET 16.2.0
linktitle: Aspose.Slides برای .NET 16.2.0
type: docs
weight: 230
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده را در Aspose.Slides برای .NET بررسی کنید تا به‌سادگی راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 
این صفحه تمام کلاس‌ها، متدها، خصوصیت‌ها و موارد مشابه افزودنی یا حذف شده و دیگر تغییراتی که با API Aspose.Slides برای .NET 16.2.0 معرفی شده‌اند را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**
#### **خصوصیات UpdateDateTimeFields و UpdateSlideNumberFields حذف شده‌اند**
خصوصیات UpdateDateTimeFields و UpdateSlideNumberFields از کلاس Aspose.Slides.Presentation و از اینترفیس Aspose.Slides.IPresentation حذف شده‌اند.  
خصوصیت Text در کلاس‌های Aspose.Slides.TextFrame، Paragraph، Portion و اینترفیس‌های Aspose.Slides.ITextFrame، IParagraph، IPortion متنی با فیلدهای «datetime» به‌روز شده را برمی‌گرداند.  
همچنین خصوصیات Presentation.DocumentProperties.CreatedTime، LastSavedTime و LastPrinted فقط‑خواندنی شده‌اند.  
#### **enum Slides.Charts.CategoryAxisType به صورت عمومی تبدیل شد**
در خصوصیات IAxis.CategoryAxisType و Axis.CategoryAxisType برای تعیین نوع محور دسته‌بندی استفاده می‌شود.  
- CategoryAxisType.Auto : نوع محور دسته‌بندی به‌صورت خودکار در زمان سریال‌سازی تعیین می‌شود (در حال حاضر پیاده‌سازی نشده)  
- CategoryAxisType.Text : نوع محور دسته‌بندی متن است  
- CategoryAxisType.Date : نوع محور دسته‌بندی تاریخ/زمان است  
#### **استخراج سریع متن**
متد ایستاتیک جدید GetPresentationText به کلاس Presentation افزوده شده است. دو overload برای این متد وجود دارد:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

آرگومان enum ExtractionMode حالت سازماندهی خروجی متن را مشخص می‌کند و می‌تواند یکی از مقادیر زیر باشد:  
- Unarranged : متن خام بدون توجه به موقعیت در اسلاید  
- Arranged : متن بر همان ترتیب که در اسلاید قرار دارد، سازماندهی می‌شود  

حالت Unarranged زمانی مفید است که سرعت بحرانی باشد؛ این حالت سریع‌تر از Arranged است.

PresentationText متن خام استخراج‌شده از ارائه را نشان می‌دهد. این کلاس دارای خصوصیت SlidesText از فضای نام Aspose.Slides.Util است که آرایه‌ای از اشیای ISlideText را برمی‌گرداند. هر شیء متن اسلاید مربوطه را نمایندگی می‌کند. اشیای ISlideText دارای خصوصیات زیر هستند:

- ISlideText.Text : متن شکل‌های اسلاید  
- ISlideText.MasterText : متن شکل‌های صفحهٔ اصلی برای این اسلاید  
- ISlideText.LayoutText : متن شکل‌های صفحهٔ طرح‌بندی برای این اسلاید  
- ISlideText.NotesText : متن شکل‌های صفحهٔ یادداشت‌ها برای این اسلاید  

کلاس SlideText نیز پیاده‌سازی ISlideText است.

API جدید می‌تواند به شکل زیر استفاده شود:

``` csharp
using System;
using Aspose.Slides;

// متن را بدون توجه به موقعیت آن در اسلاید استخراج کنید (سریع‌ترین حالت).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// متن را به همان ترتیب که در اسلاید قرار دارد استخراج کنید.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **اینترفیس ILegacyDiagram و کلاس LegacyDiagram افزوده شد**
اینترفیسی به نام Aspose.Slides.ILegacyDiagram و کلاسی به نام Aspose.Slides.LegacyDiagram برای نمایندگی شیء دیاگرام قدیمی اضافه شده‌اند. شیء دیاگرام قدیمی فرمت قدیمی دیاگرام‌های PowerPoint 97‑2003 است. کلاس جدید متدهایی برای تبدیل دیاگرام قدیمی به شیء SmartArt قابل ویرایش مدرن یا به GroupShape قابل ویرایش فراهم می‌کند.  
#### **عضوی جدید در enum Aspose.Slides.TextAlignment اضافه شد (JustifyLow)**
یک مقدار جدید به enum TextAlignment اضافه شد:  
- JustifyLow : تراز کردن کاشی‌دار (Kashida) به صورت کم.  
#### **خصوصیات جدید برای Aspose.Slides.IOleObjectFrame و OleObjectFrame**
خصوصیات جدیدی به اینترفیس IOleObjectFrame و کلاس OleObjectFrame اضافه شده است. این خصوصیات برای ارائه اطلاعات دربارهٔ شیء جاسازی‌شده در ارائه استفاده می‌شوند:  
- EmbeddedFileExtension : پسوند فایل شیء جاسازی‌شده را برمی‌گرداند یا رشتهٔ خالی اگر شیء لینک نباشد  
- EmbeddedFileLabel : نام فایل شیء OLE جاسازی‌شده را برمی‌گرداند  
- EmbeddedFileName : مسیر شیء OLE جاسازی‌شده را برمی‌گرداند  
#### **خصوصیت جدید CategoryAxisType به کلاس‌های IAxis و Axis اضافه شد**
خصوصیت CategoryAxisType نوع محور دسته‌بندی را مشخص می‌کند.

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
#### **خصوصیت جدید ShowLabelAsDataCallout به کلاس DataLabelFormat و اینترفیس IDataLabelFormat اضافه شد**
خصوصیت ShowLabelAsDataCallout تعیین می‌کند که برچسب داده‌های نمودار به‌عنوان فراخوان داده یا به‌عنوان برچسب داده نمایش داده شود.

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
#### **خصوصیت DrawSlidesFrame به PdfOptions و XpsOptions اضافه شد**
خصوصیت بولی DrawSlidesFrame به اینترفیس‌های Aspose.Slides.Export.IPdfOptions، Aspose.Slides.Export.IXpsOptions و کلاس‌های مرتبط Aspose.Slides.Export.PdfOptions، Aspose.Slides.Export.XpsOptions اضافه شد.  
اگر این خصوصیت مقدار true داشته باشد، قاب سیاه حول هر اسلاید رسم می‌شود.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```