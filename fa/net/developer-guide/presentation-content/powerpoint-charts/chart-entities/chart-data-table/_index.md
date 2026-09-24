---
title: سفارشی‌سازی جداول داده‌های نمودار در ارائه‌ها در .NET
linktitle: جدول داده
type: docs
url: /fa/net/chart-data-table/
keywords:
- داده نمودار
- جدول داده
- ویژگی‌های قلم
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قلم‌های جدول داده نمودار، حاشیه‌ها و کلیدهای افسانه را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای .NET و C# سفارشی کنید."
---
## **نمای کلی**

Aspose.Slides برای .NET به شما امکان می‌دهد جدول داده‌های یک نمودار را نمایش دهید و قالب‌بندی متن، حاشیه‌ها و کلیدهای افسانه‌ای آن را سفارشی کنید. این مقاله توضیح می‌دهد چگونه جدول را فعال کنید، متن آن را فرمت‌بندی کنید، هر نوع حاشیره را کنترل کنید و کلیدهای افسانه‌ای را نشان یا مخفی کنید. مثال‌ها نمودارهای پیکربندی‌شده را در فایل‌های PPTX ذخیره می‌کنند.

## **تنظیم ویژگی‌های قلم**

برای نمایش جدول داده‌های یک نمودار، ویژگی [HasDataTable](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chart/hasdatatable/) را به `true` تنظیم کنید. برای دسترسی به جدول و پیکربندی قالب‌بندی متن آن از [ChartDataTable](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chart/chartdatatable/) استفاده کنید.

1. پرزنتیشن را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بارگذاری کنید.
1. یک نمودار ستونی خوشه‌ای به اسلاید اول اضافه کنید.
1. جدول داده‌های نمودار را فعال کنید.
1. متن بولد را با [FontBold](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/fontbold/) فعال کنید و [FontHeight](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/fontheight/) را به `20` برای متن با اندازه 20 پوینت تنظیم کنید.
1. نسخهٔ اصلاح‌شدهٔ ارائه را ذخیره کنید.

مثال زیر به فایل `test.pptx` در پوشهٔ کاری با حداقل یک اسلاید نیاز دارد. این مثال یک نمودار با داده‌های پیش‌فرض را در موقعیت (50, 50) اضافه می‌کند، با عرض 600 پوینت و ارتفاع 400 پوینت. فایل ذخیره‌شدهٔ `output.pptx` شامل نمودار با جدول داده‌ها فعال و تنظیمات قلم مشخص‌شده است.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **سفارشی‌سازی حاشیه‌های جدول داده‌ها**

جدول را با [IChart.HasDataTable](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/hasdatatable/) فعال کنید و از طریق [IChart.ChartDataTable](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/chartdatatable/) به آن دسترسی پیدا کنید. می‌توانید سه نوع حاشیه را به‌صورت مستقل کنترل کنید:

- [HasBorderHorizontal](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/idatatable/hasborderhorizontal/) حاشیه‌های افقی سلول‌ها را کنترل می‌کند.
- [HasBorderVertical](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/idatatable/hasbordervertical/) حاشیه‌های عمودی سلول‌ها را کنترل می‌کند.
- [HasBorderOutline](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/idatatable/hasborderoutline/) حاشیهٔ بیرونی جدول را کنترل می‌کند.

هر ویژگی را به `true` تنظیم کنید تا حاشیهٔ مربوطه نمایش داده شود یا به `false` برای مخفی کردن آن. مثال زیر یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند، حاشیه‌های افقی و حاشیهٔ بیرونی را نمایش می‌دهد و حاشیه‌های عمودی را مخفی می‌کند. این مثال نیازی به فایل ورودی ندارد. موقعیت و اندازهٔ نمودار بر حسب پوینت مشخص می‌شود.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

مقایسهٔ زیر همان جدول را با کلیدهای افسانهٔ فعال و غیرفعال نشان می‌دهد. تمام حاشیه‌ها فعال می‌مانند و افسانهٔ جداگانهٔ نمودار در هر دو حالت مخفی است.

![جداول داده‌های نمودار با کلیدهای افسانه در سمت چپ نشان داده شده و در سمت راست مخفی شده‌اند](data-table-borders.png)

## **نمایش یا مخفی کردن کلیدهای افسانه**

کلیدهای افسانه، نشانگرهای رنگی کوچک کنار نام‌های سری‌ها در جدول داده‌ها هستند. آنها به خوانندگان کمک می‌کنند تا هر ردیف جدول را به یک سری نمودار مرتبط کنند. برای نمایش این نشانگرها، ویژگی [ShowLegendKey](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/idatatable/showlegendkey/) را به `true` تنظیم کنید یا برای مخفی کردن آنها به `false`.

افسانهٔ جداگانهٔ نمودار توسط [IChart.HasLegend](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/haslegend/) کنترل می‌شود. این تنظیمات مستقل هستند: مخفی کردن افسانهٔ جداگانه، کلیدهای داخل جدول داده‌ها را مخفی نمی‌کند و مخفی کردن کلیدهای جدول، افسانهٔ جداگانه را مخفی نمی‌کند.

مثال زیر یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند، جدول داده‌های آن را فعال می‌سازد و کلیدهای افسانه را داخل آن نشان می‌دهد در حالی که افسانهٔ جداگانه مخفی می‌شود. تمام حاشیه‌های جدول به‌وضوح فعال هستند. نیازی به ارائهٔ ورودی نیست. برای مخفی کردن فقط کلیدهای جدول، مقدار `dataTable.ShowLegendKey` را به `false` تغییر دهید.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

مقایسهٔ زیر همان جدول را با کلیدهای افسانهٔ فعال و غیرفعال نشان می‌دهد. تمام حاشیه‌ها فعال می‌مانند و افسانهٔ جداگانهٔ نمودار در هر دو حالت مخفی است.

![جداول داده‌های نمودار با کلیدهای افسانه در سمت چپ نشان داده شده و در سمت راست مخفی شده‌اند](data-table-legend-keys.png)

## **سؤالات متداول**

**آیا می‌توانم کلیدهای افسانه را در جدول داده‌های یک نمودار نشان دهم؟**

بله. ویژگی [ShowLegendKey](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/datatable/showlegendkey/) را به `true` تنظیم کنید تا کلیدهای افسانه نمایش داده شوند یا به `false` برای مخفی کردن آنها.

**آیا جدول داده‌ها هنگام خروجی گرفتن ارائه به PDF، HTML یا تصاویر حفظ می‌شود؟**

بله. Aspose.Slides هنگام خروجی گرفتن به [PDF](/slides/fa/net/convert-powerpoint-to-pdf/)، [HTML](/slides/fa/net/convert-powerpoint-to-html/)، یا [images](/slides/fa/net/convert-powerpoint-to-png/)، نمودار و جدول داده‌های نمایش‌داده‌شده را به‌عنوان بخشی از اسلاید رندر می‌کند.

**آیا می‌توانم با جدول داده‌ها در نمودارهایی که از یک قالب بارگذاری شده‌اند کار کنم؟**

بله. برای نموداری که از یک ارائه یا قالب موجود بارگذاری شده است، می‌توانید از [HasDataTable](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chart/hasdatatable/) برای بررسی یا تغییر وضعیت نمایش جدول داده‌ها استفاده کنید.

**چگونه می‌توانم نمودارهایی را پیدا کنم که جدول داده آن‌ها فعال باشد؟**

در هر اسلاید، تمام اشکال را پیمایش کنید، نمودارها را شناسایی کنید و ویژگی [HasDataTable](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chart/hasdatatable/) آن‌ها را بررسی کنید. مقدار `true` نشان می‌دهد که جدول داده فعال است.