---
title: مدیریت سری‌های داده نمودار در ارائه‌ها با JavaScript
linktitle: سری داده‌ها
type: docs
url: /fa/nodejs-java/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
- رنگ سری
- نام سری
- نقطه داده
- سلول کتاب کاری
- فاصله سری
- مقدار منفی
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب کاری، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با JavaScript مدیریت کنید."
---
## **مرور کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کتاب‌کار داده‌های نمودار ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/) نمایانگر یک مجموعه از مقادیر مرتبط است و هر [ChartDataPoint](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/) در این مجموعه به یک یا چند سلول کتاب‌کار اشاره می‌کند. اشیاء [ChartCategory](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین مجموعه‌ها را فراهم می‌کنند. بنابراین نام مجموعه، دسته‌ها و مقادیر نقاط به اشیاء [ChartDataCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/) متصل هستند نه این که فقط به عنوان متن نمایش ذخیره شوند.

برای یک نمودار دسته‌ای معمولی، کتاب‌کار پیش‌فرض از ردیف 0 برای نام‌های مجموعه، ستون 0 برای نام‌های دسته و سلول‌های باقی‌مانده برای مقادیر مجموعه استفاده می‌کند. شاخص‌های کاربرگ، ردیف و ستون که به [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#getCell) منتقل می‌شوند، صفر‑پایه‌اند. این چیدمان زمانی مفید است که یک نمودار با داده‌های پیش‌فرض ایجاد می‌کنید، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، سلول‌های ارجاع‌شده توسط مجموعه‌ها، دسته‌ها و نقاط داده را پیش از تغییر مقادیر کتاب‌کار بررسی کنید.

تنظیمات نمودار در سه حوزه مختلف تقسیم می‌شوند:

- تنظیمات سطح مجموعه، مانند [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getFormat)، ظاهر پیش‌فرض همه نقاط یک مجموعه را فراهم می‌کند.
- تنظیمات نقطه داده، مانند [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#getFormat)، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروه بر روی مجموعه‌های سازگاری که به همان [ChartSeriesGroup](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند همپوشانی یا عرض فاصله، از [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) دسترسی پیدا کنید.

زمانی که پر کردن صریحی برای نقطه یا مجموعه تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم فرمت مجموعه و هم فرمت نقطه حضور دارند، فرمت نقطه برای آن نقطه اولویت دارد.

![نمودار-سری-پاورپوینت](chart-series-powerpoint.png)

## **تنظیم همپوشانی مجموعه نمودار**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getOverlap) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار دو‑بعدی تا چه اندازه با یکدیگر همپوشانی دارند، از ‑۱۰۰ تا ۱۰۰ درصد. این یک تصویر فقط‑خواندنی از تنظیمات در گروه سری والد است. برای به‌روزرسانی همه مجموعه‌های سازگار در آن گروه از [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) استفاده کنید. این گزینه فقط به انواع نمودارهایی که نوارها یا ستون‌های گروهی نمایش می‌دهند اعمال می‌شود؛ برای گروه‌های سری نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر همپوشانی گروهی که شامل اولین مجموعه است را تنظیم می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // نمودار جدید شامل مجموعه‌های نمونه، دسته‌ها و مقادیر است.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![همپوشانی مجموعه](series_overlap.png)

## **تغییر رنگ پر کردن مجموعه**

از [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getFormat) برای تنظیم پر کردن پیش‌فرض یک مجموعه کامل استفاده کنید. اگر یک نقطه قبلاً پر کردن صریحی داشته باشد، تنظیمات [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#getFormat) آن پر کردن را برای آن نقطه بازنویسی می‌کند.

مثال زیر پر کردن آبی جامد را بر روی اولین مجموعه اعمال می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![رنگ مجموعه](series_color.png)

## **تغییر نام مجموعه**

نام یک مجموعه در کتاب‌کار داده‌های نمودار ذخیره می‌شود و معمولاً در افسانه (legend) نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ایجاد شده برای یک نمودار ستونی خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین مجموعه را شامل می‌شود. ثابت‌های نام‌گذاری‌شده در مثال زیر این ساختار را به‌وضوح نشان می‌دهند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

همچنین می‌توانید سلولی را که توسط [ChartSeries.getName](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getName) ارجاع داده شده است، به‌روزرسانی کنید. این روش از فرض یک ردیف و ستون خاص در یک نمودار موجود جلوگیری می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![نام مجموعه](series_name.png)

## **دریافت رنگ پر کردن خودکار مجموعه**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) رنگی را برمی‌گرداند که بر اساس اندیس مجموعه و سبک نمودار محاسبه می‌شود. این رنگ زمانی استفاده می‌شود که پر کردن مجموعه به‌صورت صریح تعریف نشده باشد. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی اختصاص نمی‌دهد.

مثال زیر رنگ خودکار هر یک از مجموعه‌های پیش‌فرض را چاپ می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

خروجی نمونه برای سبک پیش‌فرض نمودار:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

رنگ‌های دقیق بسته به سبک و تم نمودار متفاوت هستند.

## **تنظیم رنگ پر کردن معکوس برای یک مجموعه نمودار**

برای مجموعه‌های نوار، ستون و حباب، [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) می‌تواند مقادیر منفی را با پر کردن متفاوتی نمایش دهد. پر کردن معمولی مجموعه را به‌صورت جامد تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) اختصاص دهید. اعداد منفی در کتاب‌کار دست نخورده می‌مانند؛ فقط رنگ نمایش‌شان تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 کاربرگ شامل نام مجموعه، ستون 0 شامل نام‌های دسته و ستون 1 شامل مقادیر است:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![رنگ پر کردن جامد معکوس](inverted_solid_fill_color.png)

می‌توانید معکوس‌سازی را برای یک نقطه از طریق [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) فعال کنید. در مثال زیر، معکوس‌سازی برای مجموعه غیرفعال و فقط برای نقطه منتخب فعال شده است. برای مشاهده اثر، به نقطه نیز مقدار منفی اختصاص داده می‌شود:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پاک‌سازی مقدار نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف بقیه نقاط، سلول کتاب‌کار پشتیبان آن را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [ChartDataPoint.getValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#getValue) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات مقدار خالی نمودار به‌صورت خالی در نظر می‌گیرد.

مثال زیر فقط نقطه دوم در اولین مجموعه را پاک می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نمودارهای پراکندگی از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حباب نیز از سلول اندازه استفاده می‌کنند. فقط سلولی را که نمایانگر مقدار مورد نظر شما برای حذف است، پاک کنید. هنگام حفظ بقیه نقاط، از فراخوانی [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapointcollection/#clear) خودداری کنید؛ زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

یک سلول خالی در کتاب‌کار نمایانگر داده‌های گمشده است؛ یک سلول حاوی `0` نمایانگر مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، [ChartDataCell.setValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setValue) را با `null` فراخوانی کنید. عدد صفر عددی صفر باقی می‌ماند صرف‌نظر از تنظیم خالی‑سلول.

از [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) برای انتخاب نحوه نمایش سلول‌های خالی استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود. این گزینه نحوه ترسیم خالی‌ها را تغییر می‌دهد بدون اینکه سلول خالی کتاب‌کار را با صفر یا مقدار درونی‌سازی‌شده پر کند.

مثال خودمحور زیر یک نمودار خطی با یک مجموعه ایجاد می‌کند، مقدار روز ۳ را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/) از کاربرگ 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را نگه می‌دارد. داده نهایی `10, 20, empty, 30, 40` است.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // روز 3 را واقعاً خالی بگذارید، در حالی که دسته‌بندی و نقطه دادهٔ آن را حفظ می‌کنید.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

هر فایل خروجی حالت اختصاص داده‌شده پیش از ذخیره‌سازی را ذخیره می‌کند: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیره تنها یک نسخه، حالت دلخواه را تنظیم کنید و یک بار ارائه را ذخیره کنید به‌جای این‌که بر روی حالت‌ها تکرار کنید.

مقایسه زیر همان داده را در هر سه فایل نشان می‌دهد. روز ۳ در هر حالت در کتاب‌کار خالی است:

![نمودارهای خطی با داده‌های یکسان: Gap در روز ۳ خط را قطع می‌کند، Zero خط را به صفر می‌برد و Span روز ۲ را به روز ۴ متصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده بستگی به نوع نمودار دارد. یک نمودار خطی سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای نوار و ستونی خطی برای اتصال بین دسته‌های گمشده ندارند، بنابراین `Span` نمی‌تواند بخش متصل‌شده‌ای که در بالا نشان داده شد تولید کند؛ یک ستون خالی و یک ستون ارتفاع صفر نیز می‌توانند شباهت داشته باشند. به‌طور مشابه، یک نمودار پراکندگی تنها با نشانگرها خطی برای اتصال ندارد. انتظار نتایج سه‌گانه متفاوت برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصله مجموعه**

عرض فاصله، فضای بین خوشه‌های نوار یا ستونی مجاور است که به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. مشابه همپوشانی، این تنظیم متعلق به گروه سری والد است نه به یک مجموعه. برای گروه یک بار [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) فراخوانی کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را فشرده‌تر می‌کند.

مثال زیر عرض فاصله را تغییر می‌دهد و فقط ارائه نهایی را ذخیره می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![عرض فاصله](gap_width.png)

## **سوالات متداول**

**کدام انواع نمودار از مجموعه داده‌ها پشتیبانی می‌کنند؟**

تمام انواع نمودارهایی که توسط شمارش‌گر [ChartType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/) نمایان می‌شوند از داده‌های نمودار استفاده می‌کنند، اما مجموعه‌های آن‌ها همه ساختار یا تنظیمات مقدار یکسانی ندارند. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حباب علاوه بر آن اندازه حباب‌ها را دارند. از روش ایجاد نقطه داده‌ای استفاده کنید که با نوع مجموعه مطابقت داشته باشد. گزینه‌هایی مانند همپوشانی و عرض فاصله تنها برای گروه‌های نوار یا ستونی سازگار اعمال می‌شوند.

**یک گروه مجموعه نمودار چیست؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseriesgroup/) مجموعه‌ای از مجموعه‌های سازگار است که تنظیمات نموداری سطح‑گروه را به اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه دسترسی پیدا می‌کنید لزوماً بر همه مجموعه‌های نمودار تأثیر نمی‌گذارد.

**آیا یک نمودار تازه‌ساخته داده‌های پیش‌فرض دارد؟**

بله. به‌صورت پیش‌فرض، [ShapeCollection.addChart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/#addChart) نمونه‌ای از مجموعه‌ها، دسته‌ها و مقادیر را ایجاد می‌کند. می‌توانید آن سلول‌ها را ویرایش کنید یا قبل از افزودن یک مجموعه داده کاملاً سفارشی، هر دو مجموعه و دسته‌ها را پاک کنید. یک overload همچنین می‌تواند نموداری بدون داده‌های پیش‌فرض ایجاد کند.

**چگونه اشیاء نمودار به سلول‌های کتاب‌کار متصل می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطه‌داده به سلول‌های یک [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده، عنصر مربوط به نمودار را به‌روزرسانی می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را هم‌راستا نگه دارید تا هر نقطه زیر دسته مورد نظر ترسیم شود.

**چگونه یک نقطه را به‌جای کل مجموعه پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دسته نقطه به‌عنوان نقطهٔ خالی حفظ شود. فقط زمانی از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapointcollection/#clear) استفاده کنید که قصد حذف تمام نقاط آن مجموعه را دارید. اگر هم‌زمان دسته‌ها را حذف می‌کنید، هر مجموعه را به‌روزرسانی کنید تا مقادیر آن‌ها با مجموعهٔ دسته هم‌راستا بمانند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه بسته به نوع نمودار و مقدار تنظیم‌شده از طریق [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) متفاوت است. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنای داده‌های گمشده در ارائهٔ شما را منعکس کند. برای مثال کامل و مقایسهٔ بصری به بخش **کنترل نمایش سلول‌های خالی** مراجعه کنید.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های نوار، ستون و حباب پشتیبانی‌شده، [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) را فراخوانی کنید و رنگ بازگردانده‌شده توسط [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) بازنویسی کنید. این روش‌ها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**در هنگام قالب‌بندی هم مجموعه و هم نقطه، کدام یک برنده است؟**

قالب‌بندی صریح نقطه داده برای آن نقطه اولویت دارد. سایر نقاط همچنان از قالب صریح مجموعه یا، زمانی که قالب مجموعه تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند همپوشانی و عرض فاصله کنترل چیدمان را بر عهده دارند و بازنویسی قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابتی برای تعداد مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندرینگ و قابل خواندن بودن نمودار، حد مفید را تعیین می‌کنند.

**زمانی که ستون‌ها بیش از حد نزدیک یا بسیار پراکنده هستند، چه کاری باید انجام دهم؟**

از [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) برای گروه سری والد مناسب استفاده کنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها بیشتر شود یا کاهش دهید تا خوشه‌ها به هم نزدیک‌تر شوند.