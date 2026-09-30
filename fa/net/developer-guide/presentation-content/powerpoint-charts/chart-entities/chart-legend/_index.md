---
title: سفارشی‌سازی اسطوره‌های نمودار در ارائه‌ها در .NET
linktitle: اسطوره نمودار
type: docs
url: /fa/net/chart-legend/
keywords:
- اسطوره نمودار
- موقعیت اسطوره
- اندازه فونت
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اسطوره‌های نمودار را با Aspose.Slides برای .NET سفارشی کنید تا ارائه‌های PowerPoint را با قالب‌بندی اختصاصی اسطوره بهینه‌سازی کنید."
---
## **بررسی کلی**

Aspose.Slides for .NET گزینه‌هایی برای سفارشی‌سازی اسطوره‌های نمودار در ارائه‌های PowerPoint ارائه می‌دهد. این مقاله نشان می‌دهد چگونه یک اسطوره را مکان‌یابی و اندازه‌گذاری کرد، اندازه فونت کل اسطوره را تنظیم کرد، یک ورودی اسطوره را به‌صورت جداگانه قالب‌بندی کرد و ورودی‌های انتخابی را مخفی یا بازیابی کرد.

سؤالات متداول رفتارهای مرتبط را پوشش می‌دهد، از جمله رزرو فضای اسطوره، نمایش برچسب‌های چندخطی، و ارث‌بری قالب‌بندی از تم ارائه.

## **موقعیت‌یابی اسطوره**

از ویژگی‌های [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/), و [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) اسطوره استفاده کنید تا موقعیت و اندازه آن را به عنوان کسری از ابعاد نمودار مشخص کنید.

این مثال یک ارائه ایجاد می‌کند و یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض را به اولین اسلاید اضافه می‌کند. تقسیم افست‌ها و ابعاد مورد نظر اسطوره بر عرض و ارتفاع نمودار، آن‌ها را به مقادیر نسبی تبدیل می‌کند: اسطوره ۵۰ نقطه از گوشه بالایی‑چپ نمودار فاصله دارد و به اندازه ۱۰۰ در ۱۰۰ نقطه تنظیم می‌شود.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **تنظیم اندازه فونت اسطوره**

از [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) اسطوره برای دسترسی به قالب‌بندی متن آن استفاده کنید و [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) را بر حسب نقطه تنظیم کنید.

این مثال یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند و متن اسطوره را به ۲۰ نقطه تنظیم می‌کند. همچنین حدهای خودکار برای محور عمودی را غیرفعال می‌کند و دامنه آن را از -5 تا ۱۰ تنظیم می‌نماید.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **تنظیم اندازه فونت یک ورودی اسطوره به‌صورت فردی**

از مجموعه [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) اسطوره برای دسترسی به قالب‌بندی یک ورودی خاص استفاده کنید. شاخص‌های ورودی از صفر شروع می‌شوند، بنابراین شاخص `1` به ورودی دوم اشاره دارد.

این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند که داده‌های پیش‌فرض آن حداقل شامل دو سری است. این ورودی دوم اسطوره را با متن ضخیم، ایتالیک و به اندازه ۲۰ نقطه با رنگ آبی قالب‌بندی می‌کند.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **مخفی کردن ورودی‌های فردی اسطوره**

برای حذف یک سری کمکی از اسطوره در حالی که داده‌های آن قابل مشاهده می‌مانند، [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) را از طریق [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/) به `true` تنظیم کنید. این کار تنها ورودی انتخاب‌شده اسطوره را مخفی می‌کند؛ سری یا نقاط داده آن حذف نمی‌شود. در مقابل، تنظیم [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) به `false` تمام اسطوره را مخفی می‌کند.

مثال زیر یک نمودار ستونی خوشه‌ای با چندین سری با استفاده از داده‌های پیش‌فرض ایجاد می‌کند. ورودی اسطوره سری دوم (شاخص `1`) را مخفی می‌کند و ارائه را ذخیره می‌نماید. سپس با تنظیم `Hide` به `false` ورودی را بازمی‌گرداند و یک نسخه دوم ذخیره می‌کند. ستون‌ها در هر دو فایل قابل مشاهده باقی می‌مانند.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// ورودی یکسان را بدون تغییر داده‌های نمودار بازیابی کنید.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

مقایسه زیر همان نمودار را با همه ورودی‌های قابل مشاهده و با ورودی دوم مخفی نشان می‌دهد. ستون‌های سری دوم بدون تغییر باقی می‌مانند.

![مقایسه نموداری که همه ورودی‌های اسطوره قابل مشاهده هستند و سری ۲ از اسطوره مخفی شده است؛ همه ستون‌ها قابل مشاهده باقی می‌مانند.](hide-legend-entry.png)

در نمودارهای ستونی، نوار و خطی، ورودی‌های اسطوره سری‌ها را شناسایی می‌کنند. برای نمودارهای دایره‌ای، آن‌ها نقاط دادهٔ فردی (برش‌ها) را شناسایی می‌کنند، بنابراین به‌جای آن از [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) روی برش انتخابی استفاده کنید. API این ویژگی نقطه‑داده را برای انواع نمودارهای `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` و `BarOfPie` مستند کرده است. فرض نکنید این ویژگی برای نمودارهای دونات نیز اعمال می‌شود، که در این فهرست گنجانده نشده‌اند.

## **سؤالات متداول**

**آیا می‌توانم نمودار فضای مورد نیاز اسطوره را رزرو کند به‌جای پوشاندن آن؟**  
بله. مقدار [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) را به `false` تنظیم کنید تا به‌جای اجازهٔ هم‌پوشانی با ناحیهٔ نمودار، فضای اسطوره رزرو شود.

**آیا می‌توانم برچسب‌های اسطوره چندخطی ایجاد کنم؟**  
بله. برچسب‌های طولانی می‌توانند در صورتی که عرض موجود کافی نباشد، به‌صورت خودکار به‌خط بعدی بروند. همچنین می‌توانید در نام‌های سری از نویسه‌های جدید خط استفاده کنید تا شکسته‌خط درخواست شود.

**چگونه می‌توانم اسطوره را مطابق با طرح رنگی تم ارائه تنظیم کنم؟**  
رنگ‌ها، پرکردگی‌ها و قلم‌های اسطوره را تنظیم نکنید تا بتواند قالب‌بندی تم را به ارث ببرد. قالب‌بندی صریح تنظیمات تم مربوطه را بازنویسی می‌کند.