---
title: مدیریت سری‌های داده نمودار در ارائه‌ها با JavaScript
linktitle: سری‌های داده
type: docs
url: /fa/nodejs-java/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
- رنگ سری
- نام سری
- نقطه داده
- سلول کارنامه
- فاصله سری
- مقدار منفی
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کارنامه، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با JavaScript مدیریت کنید."
---
## **بررسی کلی**

یک نمودار داده‌های ترسیم شده خود را در یک کارنامه داده‌های نمودار (chart data workbook) ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) یک مجموعه از مقادیر مرتبط را نمایندگی می‌کند و هر [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) در سری به یک یا چند سلول کارنامه ارجاع می‌دهد. اشیاء [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین سری‌ها را فراهم می‌کنند. بنابراین نام سری، دسته‌بندی‌ها و مقادیر نقاط به اشیاء [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) متصل هستند نه اینکه فقط به صورت متن نمایش ذخیره شوند.

برای یک نمودار دسته‌ای معمولی، کارنامه پیش‌فرض از ردیف 0 برای نام‌های سری، ستون 0 برای نام‌های دسته و سلول‌های باقی‌مانده برای مقادیر سری استفاده می‌کند. شاخص‌های برگه، ردیف و ستون که به [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getCell) پاس داده می‌شوند، صفر‑مبنایی هستند. این چیدمان هنگام ایجاد یک نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری شده، قبل از تغییر مقادیر کارنامه، سلول‌های ارجاع داده شده توسط سری‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار در سه حوزه مختلف قرار دارند:

- تنظیمات سطح سری، مانند [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getFormat)، ظاهر پیش‌فرض تمام نقاط یک سری را تعیین می‌کند.
- تنظیمات نقطه داده، مانند [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#getFormat)، ظاهر سری را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی برای سری‌های سازگاری که به یک [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) تعلق دارند، اعمال می‌شود. برای تنظیم گزینه‌هایی مانند همپوشانی یا عرض فاصله، گروه را از طریق [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) دسترسی پیدا کنید.

زمانی که پر کردن نقطه یا سری به‌صورت صریح تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات سری و هم تنظیمات نقطه موجود باشد، تنظیمات نقطه برای آن نقطه برتر است.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری نمودار**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getOverlap) مقدار همپوشانی نوارها یا ستون‌ها را در یک نمودار ۲‑بعدی از ‑۱۰۰ تا ۱۰۰ درصد گزارش می‌دهد. این یک تصویر فقط‑خواندنی از تنظیمات گروه سری والد است. برای به‌روزرسانی همه سری‌های سازگار در آن گروه، از [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) استفاده کنید. این گزینه برای انواع نمودارهایی که نوارها یا ستون‌های گروهی را نمایش می‌دهند، اعمال می‌شود؛ بر گروه‌های سری نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر همپوشانی گروه حاوی اولین سری را تنظیم می‌کند:

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

    // نمودار جدید شامل سری‌های نمونه، دسته‌ها و مقادیر است.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The series overlap](series_overlap.png)

## **تغییر رنگ پر کردن سری**

از [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getFormat) برای تنظیم پر کردن پیش‌فرض یک سری کامل استفاده کنید. اگر برای یک نقطه پر کردن صریحی تنظیم شده باشد، تنظیم [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#getFormat) آن، پر کردن سری را برای همان نقطه بازنویسی می‌کند.

مثال زیر پر کردن آبی ثابت را به اولین سری اعمال می‌کند:

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

![The color of the series](series_color.png)

## **تغییر نام سری**

نام یک سری در کارنامه داده‌های نمودار ذخیره می‌شود و معمولاً در راهنما (legend) نمایش داده می‌شود. در کارنامه پیش‌فرض ایجاد شده برای یک نمودار ستون خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین سری را شامل می‌شود. ثابت‌های نام‌گذاری در مثال زیر این ساختار را صریح می‌کند:

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

همچنین می‌توانید سلول ارجاع داده شده توسط [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getName) را به‌روزرسانی کنید. این روش از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

![The series name](series_name.png)

### **ایجاد سری با نامی از چند سلول**

یک نام سری ترکیبی وقتی مفید است که نام محصول و دوره گزارش در سلول‌های جداگانه کارنامه ذخیره شوند. به عنوان مثال می‌توانید `Product A` در B1 و `2026` در C1 را به یک نام سری ترکیب کنید در حالی که هر دو بخش به سلول‌های منبع خود متصل می‌مانند.

از [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getCellCollection) برای بازیابی ناحیه نام استفاده کنید، سپس آن مجموعه را به [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/#add) پاس دهید. پارامتر `skipHiddenCells` تعیین می‌کند که آیا سلول‌های مخفی شامل شوند یا نه: `true` آن‌ها را حذف می‌کند، در حالی که `false` شامل می‌شود. این مثال از `false` برای شامل شدن تمام سلول‌های ناحیه نام استفاده می‌کند.

مثال زیر یک ارائه با یک سری و دو نقطه داده ایجاد می‌کند. سلول‌های B1:C1 فقط نام سری را فراهم می‌کنند؛ A2:A3 برچسب‌های دسته را، و B2:B3 مقادیر عددی را فراهم می‌کنند.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // این دو سلول نام سری را فراهم می‌کنند.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // سلول‌های جداگانه دسته‌ها و نقاط داده عددی را فراهم می‌کنند.
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نام سری حاصل `Product A 2026` است، با یک فاصله بین دو مقدار سلولی. راهنما این را به عنوان یک ورودی برای هر دو ستون نمایش می‌دهد. تصویر زیر نتیجه را نشان می‌دهد:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **دریافت رنگ پر کردن خودکار سری**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) رنگی را بر می‌گرداند که بر اساس اندیس سری و سبک نمودار محاسبه می‌شود. این همان رنگی است که هنگام عدم تعریف صریح پر کردن سری استفاده می‌شود. فراخوانی این متد رنگ محاسبه‌شده را می‌خواند؛ رنگ جدیدی را تنظیم نمی‌کند.

مثال زیر رنگ خودکار هر سری پیش‌فرض را چاپ می‌کند:

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

رنگ‌های دقیق به سبک و تم نمودار بستگی دارند.

## **تنظیم رنگ پر کردن معکوس برای یک سری نمودار**

برای سری‌های نوار، ستون و حباب، [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) می‌تواند مقادیر منفی را با پر کردن متفاوتی نمایش دهد. پر کردن معمولی سری را به حالت ثابت (solid) تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) اختصاص دهید. اعداد منفی در کارنامه بدون تغییر می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 برگه نام سری را دارد، ستون 0 نام دسته‌ها و ستون 1 مقادیر را دارد:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

می‌توانید برای یک نقطه خاص معکوس‌سازی را از طریق [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) فعال کنید. در مثال زیر، معکوس‌سازی برای کل سری غیرفعال و فقط برای نقطه انتخاب‌شده فعال شده است. همچنین مقدار منفی به نقطه اختصاص داده شده تا اثر قابل مشاهده باشد:

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

## **پاک کردن مقدار یک نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشتیبان آن را به `null` تنظیم کنید. برای یک نمودار ستون، مقدار ترسیم‌شده از طریق [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#getValue) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را به‌عنوان خالی براساس تنظیمات مقادیر خالی نمودار در نظر می‌گیرد.

مثال زیر تنها نقطه دوم در اولین سری را پاک می‌کند:

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

نمودارهای پراکندگی از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حباب نیز از یک سلول اندازه استفاده می‌کنند. فقط سلولی که نمایانگر مقداری است که می‌خواهید حذف کنید را پاک کنید. هنگامیکه می‌خواهید نقاط دیگر را نگه دارید، از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/#clear) استفاده نکنید، زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که مقادیر دارند موردی متفاوت نسبت به سلول‌های خالی هستند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی برگه، به [Include Data from Hidden Rows and Columns](/slides/fa/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول خالی کارنامه نمایانگر دادهٔ گمشده است؛ سلولی که مقدار `0` دارد نمایانگر مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، با `null` به [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#setValue) فراخوانی کنید. مقدار عددی صفر همچنان صفر می‌ماند، صرف‌نظر از تنظیم خالی‑سلول.

از [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) برای انتخاب نحوه نمایش خالی‌ها در نمودار استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود. نحوهٔ ترسیم خالی‌ها را تغییر می‌دهد بدون اینکه سلول خالی کارنامه با صفر یا مقدار برآوردی پر شود.

مثال زیر یک نمودار خطی با یک سری ایجاد می‌کند، مقدار روز ۳ را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) از برگه 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام سری را دارد. داده نهایی `10, 20, empty, 30, 40` است.

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

    // روز ۳ را واقعاً خالی بگذارید، در حالی که دسته‌بندی و نقطه دادهٔ آن را حفظ می‌کنید.
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

هر فایل خروجی حالت تعیین‌شده قبل از ذخیره را شامل می‌شود: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ تنها یک نسخه، حالت موردنظر را تنظیم کنید و یک‌بار ارائه را ذخیره کنید به‌جای تکرار بر حالت‌ها.

مقایسهٔ زیر همان داده را در هر سه فایل نشان می‌دهد. روز ۳ در هر مورد در کارنامه خالی است:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی تمام سه حالت را به راحتی مقایسه می‌کند. نمودارهای نوار و ستون خطی برای اتصال بین دسته‌های گمشده ندارند، بنابراین `Span` نمی‌تواند قطعهٔ اتصال نشان داده‌شده را تولید کند؛ یک ستون گمشده و یک ستون صفر‑ارتفاع نیز می‌توانند مشابه به‌نظر برسند. به‌طور مشابه، یک نمودار پراکندگی فقط با علامت‌ها خط متصل‌کننده‌ای ندارد. انتظار نتایج متمایز برای تمام انواع نمودارها نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصله سری**

عرض فاصله، فضای بین خوشه‌های نوار یا ستون مجاور است که به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. همانند همپوشانی، این تنظیم به گروه سری والد تعلق دارد نه به یک سری منفرد. یک بار برای گروه فراخوانی کنید [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth). مقدار بزرگ‌تر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچک‌تر آن‌ها را فشرده‌تر می‌سازد.

مثال زیر عرض فاصله را تغییر می‌دهد و فقط ارائهٔ نهایی را ذخیره می‌کند:

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

![The gap width](gap_width.png)

## **سؤال‌های متداول**

**کدام انواع نمودار از سری داده پشتیبانی می‌کنند؟**

تمام انواع نمودارهای موجود در شمارش [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) از داده‌های نمودار استفاده می‌کنند، اما ساختار مقدار یا تنظیمات سری‌های آن‌ها همسان نیست. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی مقادیر X و Y، و نمودارهای حباب اندازه حباب‌ها را اضافه می‌کنند. از روش ایجاد نقطه داده‌ای که با نوع سری مطابقت دارد استفاده کنید. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های نوار یا ستون سازگار اعمال می‌شوند.

**یک گروه سری نمودار چیست؟**

یک [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات رسم سطح‑گروه را به اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک سری به دست می‌آید لزوماً تمام سری‌های نمودار را تحت تأثیر قرار نمی‌دهد.

**آیا یک نمودار تازه ایجاد شده داده‌های پیش‌فرض دارد؟**

بله. به‌صورت پیش‌فرض، [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addChart) سری‌ها، دسته‌ها و مقادیر نمونه ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعه سری و دسته را پاک کنید. یک overload نیز می‌تواند نمودار را بدون داده پیش‌فرض ایجاد کند.

**اشیاء نمودار چگونه به سلول‌های کارنامه متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقاط داده به سلول‌های یک [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‑داده‌شده عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر سری را طوری تنظیم کنید که هر نقطه زیر دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را به‌جای کل سری پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان یک نقطهٔ خالی حفظ شود. از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/#clear) فقط زمانی استفاده کنید که قصد حذف تمام نقاط آن سری را داشته باشید. اگر دسته‌ها را نیز حذف می‌کنید، هر سری را به‌گونه‌ای به‌روز کنید که مقادیر آن‌ها با مجموعه دسته‌ها هم‌راستا بمانند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقدار تنظیم‌شده از طریق [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، مقدار صفر یا اتصال نقاط همسایه نشان دهند. تنظیمی را انتخاب کنید که با معنای دادهٔ گمشده در ارائهٔ شما مطابقت دارد. برای مثال کامل و مقایسهٔ تصویری به بخش [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های نوار، ستون و حباب پشتیبانی‌شده، [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) را فراخوانی کنید و رنگی که توسط [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) برگردانده می‌شود را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) بازنویسی کنید. این روش‌ها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**زمانی که هم سری و هم نقطه قالب‌بندی شوند، کدام برنده است؟**

قالب‌بندی صریح نقطه داده برای همان نقطه برتر است. سایر نقاط همچنان از قالب‌بندی صریح سری یا، اگر قالب‌بندی سری تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند همپوشانی و عرض فاصله نحوهٔ چیدمان را کنترل می‌کنند و بازنویسی قالب‌بندی در سطح نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندرینگ و قابلیت خوانایی نمودار، حد مفیدی تعیین می‌کنند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد به‌هم نزدیک یا دور هستند؟**

بر روی گروه سری والد مناسب [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) فراخوانی کنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها عریض‌تر شود یا مقدار را کاهش دهید تا خوشه‌ها به‌یکدیگر نزدیک‌تر شوند.