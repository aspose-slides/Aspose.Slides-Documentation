---
title: قالب‌بندی نمودارهای ارائه در .NET
linktitle: قالب‌بندی نمودار
type: docs
weight: 60
url: /fa/net/chart-formatting/
keywords:
- قالب‌بندی نمودار
- قالب‌بندی نمودار
- موجودیت نمودار
- ویژگی‌های نمودار
- تنظیمات نمودار
- گزینه‌های نمودار
- ویژگی‌های قلم
- حاشیه گرد
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یادگیری قالب‌بندی نمودار در Aspose.Slides برای .NET و ارتقاء ارائه PowerPoint شما با محورها، قلم‌ها، قالب‌های عددی سفارشی و حاشیه‌های گرد نمودار."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides نمودارها را در ارائه‌های PowerPoint قالب‌بندی کنید. نشان می‌دهد چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، راهنمایی‌ها، ناحیه‌ نمودار و پرکردن‌های دیوار را سفارشی کنید تا ظاهر و خوانایی داده‌های نمودار بهبود یابد.

همچنین نحوه تنظیم ویژگی‌های قلم برای متن نمودار، اعمال قالب‌های عددی پیش‌فرض به داده‌های نمودار، و فعال‌سازی گوشه‌های گرد برای ناحیه نمودار را نشان می‌دهد. این مثال‌ها نشان می‌دهند چگونه می‌توان هم سبک بصری و هم ارائه داده‌های نمودار را در یک ارائه کنترل کرد.

## **قالب‌بندی موجودیت‌های نمودار**

از [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) برای قالب‌بندی عناوین نمودار، محورها، خطوط شبکه، راهنمایی‌ها و ناحیه نمودار استفاده کنید. این مثال یک نمودار خطی با نشانگرها و داده‌های پیش‌فرض ایجاد می‌کند، سپس سبک‌های متنی و خطی جداگانه‌ای را به محور مقدار و محور دسته‌بندی آن اعمال می‌نماید. اندازه‌های قلم و عرض خطوط بر حسب پوینت مشخص شده‌اند؛ برچسب‌های دسته‌بندی به زاویه ۴۵ درجه چرخانده می‌شوند.

محور مقدار از [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) به‌طور مستقل از سلول‌های منبع استفاده می‌کند. مقیاس آن از -۲ تا ۱۵ است، با فواصل اصلی ۲ و فواصل فرعی ۰.۵. این مثال همچنین قالب‌بندی درصدی را با [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) تنظیم‌شده بر روی هزارها ترکیب می‌کند، بنابراین این تنظیمات را با معنی و مقیاس داده‌های خود سازگار کنید. راهنمایی خارج از ناحیه نمودار باقی می‌ماند چون [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) غیرفعال است. پر کردن‌های دیوار پشتی و کف از طریق [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) و [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/) پیکربندی می‌شوند، اما این سطوح فقط در نمودارهای سه‌بعدی قابل مشاهده هستند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **تنظیم ویژگی‌های قلم برای یک نمودار**

اندازه قلم پیش‌فرض برای متن نمودار را از طریق [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/) تنظیم کنید. این مثال یک نمودار ستونی خوشه‌ای با قلم ۲۰ پوینتی ایجاد می‌کند و برچسب‌های مقدار را برای اولین سری از طریق [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) فعال می‌نماید. عناصر متنی با تنظیمات قلم صریح می‌توانند پیش‌فرض نمودار را لغو کنند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **تنظیم قالب عددی**

از [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) برای اعمال یک قالب عددی داخلی به سلول‌های کار کتاب نمودار استفاده کنید. این مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض و پشتیبانی شده توسط سلول ایجاد می‌کند و شاخص قالب ۱۰ (`0.00%`) را به هر سلول مقدار سری اعمال می‌نماید. این کار باعث می‌شود مقادیر در کار کتاب بدون تغییر اعداد پایه متفاوت نمایش داده شوند؛ به‌عنوان مثال 0.25 به‌صورت 25.00% نمایش داده می‌شود. قالب‌های محور و برچسب‌های داده می‌توانند به‌صورت جداگانه پیکربندی شوند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

جدول زیر فهرست شاخص‌های قالب عددی داخلی را به همراه قالب‌های نمونه Excel برای منطقه انگلیسی (ایالات متحده) ارائه می‌دهد. رشته‌های قالب دقیق و نمایش آن‌ها می‌تواند بسته به برنامه و منطقه متفاوت باشد، به‌ویژه برای ارز و تاریخ‌ها. برخی قالب‌های Excel نیز با پیش‌فرض‌های استاندارد OOXML متفاوت هستند، همان‌طور که در [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) توضیح داده شده است.

| شناسه | قالب |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **تنظیم حاشیه‌های گرد ناحیه نمودار**

[ IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) را فعال کنید تا گوشه‌های ناحیه نمودار گرد شوند. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و از [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) برای دادن رنگ خاکستری ثابت و سبک خط تک به بیرونی آن استفاده می‌کند قبل از ذخیره ارائه.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **ویرایش حاشیه‌نویس‌های موجود در نمودار**

یک نمودار می‌تواند اشکال سفارشی مانند حاشیه‌نویس متنی که وضعیت گزارش را توضیح می‌دهد، داشته باشد. به این اشکال از طریق [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/) دسترسی پیدا کنید، که همچنین تحت [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) در مرجع API نمودار فهرست شده است. مجموعه [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) آن شامل اشکال متعلق به نمودار می‌باشد.

یک جعبه متن عادی که روی نمودار قرار می‌گیرد به اسلاید تعلق دارد، حتی اگر به‌نظر برسد بخشی از نمودار است. پیمایش [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) نمودار و اشکال عادی اسلاید را پیدا می‌کند، اما اشکال جداگانه داخل نمودار را فهرست نمی‌کند. عناوین نمودار و برچسب‌های داده عناصر جداگانه‌ای از نمودار هستند، نه حاشیه‌نویس‌های سفارشی در این مجموعه.

فایل [chart-annotations.pptx](chart-annotations.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اسلاید اول آن شامل یک نمودار با حاشیه‌نویس غیرگروه‌بندی شده با متن «Preliminary results»، یک خط متعلق به نمودار و یک جعبه متن اسلایدی معمولی با متن «Slide overlay» است. این مثال اولین نمودار موجود در آن اسلاید را پیدا کرده و حاشیه‌نویس را به «Final results» تغییر می‌دهد وقتی گزارش آماده انتشار باشد. ابتدا بررسی می‌کند که مجموعه خالی نیست و تنها یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) با [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) غیر تهی و متن مورد انتظار ویرایش می‌کند.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

خط و جعبه متن اسلاید بدون تغییر می‌مانند. تصاویر زیر ورودی و نتیجه ذخیره‌شده و بازگردانده‌شده را نشان می‌دهند:

| قبل از ویرایش | بعد از ویرایش |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
مثال فقط اشکال سطح بالای متعلق به نمودار را بررسی می‌کند. اگر حاشیه‌نویسی داخل یک [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/) باشد، مجموعه [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) آن گروه را نیز بررسی کنید. این کار را به‌صورت بازگشتی برای گروه‌های تو در تو انجام دهید و همان بررسی‌های متنی را بر روی اشکال فرزندشان اعمال کنید. یک گروه خودش یک مخزن است؛ آن را به‌عنوان یک جعبه متن در نظر نگیرید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم پرکردن‌های نیمه‌شفاف برای ستون‌ها/نواحی تنظیم کنم در حالی که مرزها مات نیستند؟**

بله. شفافیت پرکردن و خط بیرونی به‌صورت جداگانه پیکربندی می‌شوند. این کار برای بهبود خوانایی شبکه و داده‌ها در نمودارهای پرجزئی مفید است.

**چگونه می‌توانم با برچسب‌های داده که هم‌پوشانی دارند برخورد کنم؟**

اندازه قلم را کاهش دهید، مؤلفه‌های غیرضروری برچسب (مانند دسته‌ها) را غیرفعال کنید، موقعیت برچسب را تنظیم کنید، در صورت نیاز فقط برای نقاط منتخب برچسب نشان دهید، یا قالب را به «مقدار + راهنما» تغییر دهید.

**آیا می‌توانم پرکردن‌های گرادیان یا الگو را به سری‌ها اعمال کنم؟**

بله. سری‌ها از پرکردن‌های جامد، گرادیان و الگو پشتیبانی می‌کنند. در عمل، از گرادیان‌ها با احتیاط استفاده کنید و ترکیب‌هایی که تضاد را با شبکه و متن کاهش می‌دهند، اجتناب کنید.