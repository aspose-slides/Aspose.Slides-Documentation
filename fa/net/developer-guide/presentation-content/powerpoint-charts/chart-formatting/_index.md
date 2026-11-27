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
description: "قالب‌بندی نمودارها را در Aspose.Slides برای .NET بیاموزید و ارائه PowerPoint خود را با محورها، قلم‌ها، قالب‌های عددی و حاشیه‌های گرد نمودار سفارشی‌سازی کنید."
---
## **مرور کلی**

این مقاله نحوه قالب‌بندی نمودارها در ارائه‌های PowerPoint را با استفاده از Aspose.Slides توضیح می‌دهد. در آن نشان داده می‌شود که چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، راهنمایی‌ها، ناحیه‌نقشه و پرکردن دیوارها را سفارشی کنید تا ظاهر و خوانایی داده‌های نمودار بهبود یابد.

همچنین نحوه تنظیم ویژگی‌های قلم برای متن نمودار، اعمال قالب‌های عددی پیش‌گزیده به داده‌های نمودار و فعال‌سازی گوشه‌های گرد برای ناحیه نمودار را نشان می‌دهد. این مثال‌ها نحوه کنترل سبک بصری و ارائه داده‌های نمودارها در یک ارائه را نشان می‌دهند.

برای پر کردن‌های جداگانه و خطوط مرزی در فواصل صعودی و نزولی، به [نمونه نمودار سهام](/slides/fa/net/create-chart/#create-stock-charts) مراجعه کنید.

## **قالب‌بندی موجودیت‌های نمودار**

از [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) برای قالب‌بندی عناوین نمودار، محورها، خطوط شبکه، راهنمایی‌ها و ناحیه‌نقشه استفاده کنید. این مثال یک نمودار خطی با علامت‌گذاران و داده‌های پیش‌فرض ایجاد می‌کند، سپس سبک‌های متن و خط را به محوری مقدار و محوری دسته‌بندی اعمال می‌کند. اندازه‌های قلم و ضخامت خطوط به نقطه تعیین می‌شوند؛ برچسب‌های دسته‌بندی به اندازه 45 درجه چرخش می‌یابند.

محور مقدار از [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) مستقل از سلول‌های منبع استفاده می‌کند. مقیاس آن از -2 تا 15 است، با فواصل اصلی 2 و فواصل فرعی 0.5. مثال همچنین قالب‌بندی درصدی را با [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) تنظیم شده بر روی هزارها ترکیب می‌کند، بنابراین این تنظیمات را بر اساس معنی و مقیاس داده‌های خود تنظیم کنید. راهنمایی خارج از ناحیه‌نقشه می‌ماند زیرا [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) غیرفعال است. پرکردن‌های دیوار خلفی و کف از طریق [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) و [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/) پیکربندی می‌شوند، اما این سطوح تنها در نمودارهای سه‌بعدی قابل مشاهده هستند.

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

اندازه قلم پیش‌فرض برای متن نمودار را از طریق [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/) تنظیم کنید. این مثال یک نمودار ستون خوشه‌ای با قلم 20 نقطه‌ای ایجاد می‌کند و برچسب‌های مقدار را برای اولین سری از طریق [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) فعال می‌سازد. عناصر متنی با تنظیمات قلم صریح می‌توانند پیش‌فرض نمودار را بازنویسی کنند.

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

## **استفاده مجدد از قالب‌بندی فریم متن برای راهنمایی نمودار**

برای همسان‌سازی یک راهنمایی با عنوان اسلاید، قلم را در [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) اولین پاراگراف تنظیم کنید. روی [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/) راهنمایی، متد [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/) را فراخوانی کنید. این متد تنظیمات فریم متن، قالب‌بندی اولین پاراگراف و ویژگی‌های قلم پیش‌فرض آن پاراگراف را می‌خواند. قالب‌بندی که مستقیماً بر بخش‌های فردی یا پاراگراف‌های بعدی اعمال می‌شود، به منبع محدود می‌ماند.

مثال از یک عنوان 26‑نقطه‌ای Calibri برجسته با رنگ سرمه‌ای به‌عنوان قالب استفاده می‌کند. پس از استایل‌دهی به راهنمایی، از [CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/) برای اعمال همان قالب‌بندی به یک زیرنویس جداگانه استفاده می‌شود.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var heading = shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
var sourceTextFrame = heading.AddTextFrame("Quarterly sales");
var font = sourceTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
font.LatinFont = new FontData("Calibri");
font.FontHeight = 26;
font.FontBold = NullableBool.True;
font.FillFormat.FillType = FillType.Solid;
font.FillFormat.SolidFillColor.Color = Color.FromArgb(32, 64, 96);

var chart = shapes.AddChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
chart.Style = StyleType.Style3;
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.GetCell(0, 0, 1).Value = "Retail";
workbook.GetCell(0, 0, 2).Value = "Online";
workbook.GetCell(0, 0, 3).Value = "Wholesale";
for (var quarter = 1; quarter <= 4; quarter++)
    workbook.GetCell(0, quarter, 0).Value = $"Q{quarter}";

chart.HasLegend = true;
chart.Legend.Position = LegendPositionType.Bottom;
chart.Legend.TextFormat.CopyFrom(sourceTextFrame);

var caption = shapes.AddAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
var captionTextFrame = caption.AddTextFrame("Sales in millions of dollars");
chart.Legend.TextFormat.CopyTo(captionTextFrame);

presentation.Save("legend-formatting.pptx", SaveFormat.Pptx);
```

در ارائه ذخیره‌شده، راهنمایی و زیرنویس از نظر اندازه، وزن و رنگ با عنوان مطابقت دارند. راهنمایی همچنان نام سری‌ها را نشان می‌دهد و زیرنویس متن خود را حفظ می‌کند. اگر بخشی از زیرنویس قبلاً اندازه قلم صریح داشته باشد، آن اندازه بر پیش‌فرض پاراگراف کپی‌شده ارجحیت دارد.

| قبل از کپی | بعد از کپی |
| --- | --- |
| ![نمودار فروش فصلی با برچسب‌های راهنمایی سیاه ساده و زیرنویس سیاه](legend-formatting-before.png) | ![نمودار همان با برچسب‌های راهنمایی بزرگ‌تر، بولد و سرمه‌ای و زیرنویس تطبیق‌پذیر](legend-formatting.png) |

## **تنظیم قالب عددی**

از [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) برای اعمال قالب عددی داخلی به سلول‌های کارنامه نمودار استفاده کنید. این مثال یک نمودار ستون خوشه‌ای با داده‌های پیش‌فرض و پشتیبانی سلولی ایجاد می‌کند و ایندکس قالب 10 (`0.00%`) را به هر سلول مقدار سری اعمال می‌نماید. این کار نحوه نمایش مقادیر را در کارنامه تغییر می‌دهد بدون اینکه عددهای زیرین تغییر کنند؛ برای مثال 0.25 به‌صورت 25.00% نمایش داده می‌شود. قالب‌های محور و برچسب‌های داده می‌توانند به‌صورت جداگانه تنظیم شوند.

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

جدول زیر فهرست ایندکس‌های قالب عددی داخلی را به‌همراه قالب‌های نمایشی معادل در اکسل برای زبان انگلیسی (ایالات متحده) ارائه می‌دهد. رشته‌های قالب دقیق و نحوه نمایش آن‌ها ممکن است بسته به برنامه و زبان متفاوت باشد، به‌ویژه برای ارز و تاریخ‌ها. برخی قالب‌های اکسل نیز با پیش‌فرض‌های استاندارد OOXML متفاوت هستند، همان‌طور که در [یادداشت‌های پیاده‌سازی قالب عددی مایکروسافت](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) توصیف شده است.

| شاخص | قالب |
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

## **تنظیم گوشه‌های گرد ناحیه نمودار**

با فعال کردن [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) گوشه‌های ناحیه نمودار را گرد کنید. این مثال یک نمودار ستون خوشه‌ای ایجاد می‌کند و با استفاده از [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) برای خطوط مرزی آن رنگ خاکستری ثابت و سبک تک‌خطی اعمال می‌کند پیش از ذخیره‌سازی ارائه.

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

## **ویرایش حاشیه‌نویسی‌های موجود در نمودار**

یک نمودار می‌تواند شامل اشکال سفارشی باشد، مانند یک حاشیه‌نویسی متنی که وضعیت گزارشی را توضیح می‌دهد. به این اشکال از طریق [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/) دسترسی داشته باشید که همچنین در زیر [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) در مستندات API نمودار فهرست شده است. مجموعه [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) آن شامل اشکال متعلق به نمودار می‌شود.

یک جعبه متن عادی که بر روی نمودار قرار می‌گیرد به اسلاید تعلق دارد، حتی اگر شبیه بخشی از نمودار به نظر برسد. با پیمایش [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) می‌توانید نمودار و اشکال عادی اسلاید را پیدا کنید، اما اشکال منفرد داخل نمودار را فهرست نمی‌کند. عناوین نمودار و برچسب‌های داده عناصر جداگانه‌ای هستند نه حاشیه‌نویسی‌های سفارشی در این مجموعه.

[chart-annotations.pptx](chart-annotations.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اسلاید اول آن شامل یک نمودار با حاشیه‌نویسی غیرگروه‌بندی شده «Preliminary results»، یک خط متعلق به نمودار و یک جعبه متن اسلایدی عادی «Slide overlay» است. مثال اولین نمودار در آن اسلاید را پیدا می‌کند و حاشیه‌نویسی را به «Final results» تغییر می‌دهد زمانی که گزارش آماده انتشار شود. این نمونه ابتدا بررسی می‌کند که مجموعه خالی نیست و فقط اشکالی از نوع [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) با [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) غیر خالی و متن مورد انتظار را ویرایش می‌کند.

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

خط و جعبه متن اسلاید دست نخورده می‌مانند. تصاویر زیر ورودی و نتیجه‌ی ذخیره‌شده و بازنشانی‌شده را نشان می‌دهند:

| قبل از ویرایش | بعد از ویرایش |
| --- | --- |
| ![حاشیه‌نویسی نمودار با متن Preliminary results](chart-annotations-before.png) | ![حاشیه‌نویسی نمودار با متن Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
مثال فقط اشکال سطح‑بالای متعلق به نمودار را بررسی می‌کند. اگر حاشیه‌نویسی داخل یک [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/) باشد، مجموعه [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) آن گروه را نیز بررسی کنید. این کار را به‌صورت بازگشتی برای گروه‌های تو در تو انجام دهید و همان بررسی‌های متنی را بر اشکال فرزند اعمال کنید. یک گروه خود یک محفظه است؛ آن را به‌عنوان جعبه متن در نظر نگیرید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم پرکردن‌های نیمه‌شفاف برای ستون‌ها/ناحیه‌ها تنظیم کنم در حالی که حاشیه را مات نگه می‌دارم؟**

بله. شفافیت پرکردن و خطوط مرزی به‌صورت جداگانه پیکربندی می‌شوند. این کار برای بهبود خوانایی شبکه و داده‌ها در نمایه‌های متراکم مفید است.

**چگونه می‌توانم با برچسب‌های داده که همپوشانی دارند مواجه شوم؟**

اندازه قلم را کاهش دهید، مؤلفه‌های غیرضروری برچسب (مثلاً دسته‌ها) را غیرفعال کنید، موقعیت برچسب را تنظیم کنید، در صورت نیاز فقط برچسب‌های نقاط انتخابی را نشان دهید یا قالب را به «value + legend» تغییر دهید.

**آیا می‌توانم پرکردن‌های گرادیان یا الگو را بر سری‌ها اعمال کنم؟**

بله. سری‌ها از پرکردن‌های جامد، گرادیان و الگو پشتیبانی می‌کنند. در عمل، از گرادیان‌ها به‌طور متعادل استفاده کنید و ترکیب‌های کاهش کنتراست با شبکه و متن را پرهیز کنید.