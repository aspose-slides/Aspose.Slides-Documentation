---
title: مدیریت سری‌های داده نمودار در ارائه‌ها با استفاده از JavaScript
linktitle: سری‌های داده
type: docs
url: /fa/nodejs-java/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
- رنگ سری
- نام سری
- نقطه داده
- سلول کتاب‌کار
- فاصله سری
- مقدار منفی
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با JavaScript مدیریت کنید."
---
## **بررسی کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کتاب‌کار داده‌های نمودار ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/) نمایانگر یک مجموعه از مقادیر مرتبط است و هر [ChartDataPoint](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/) در این سری به یک یا چند سلول کتاب‌کار اشاره دارد. اشیاء [ChartCategory](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی شده‌ای را فراهم می‌کنند که توسط سری‌ها به‌اشتراک‌گذاری می‌شوند. بنابراین نام سری، دسته‌ها و مقادیر نقاط به جای اینکه فقط به‌صورت متن نمایشی ذخیره شوند، به اشیاء [ChartDataCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/) متصل می‌شوند.

برای یک نمودار دسته‌ای معمولی، کتاب‌کار پیش‌فرض از ردیف 0 برای نام‌های سری، ستون 0 برای نام‌های دسته و سلول‌های باقی‌مانده برای مقادیر سری استفاده می‌کند. اندیس‌های کاربرگ، ردیف و ستون که به [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#getCell) پاس می‌شوند، صفر‑مبنا هستند. این چیدمان زمانی مفید است که نموداری با داده‌های پیش‌فرض ایجاد می‌کنید، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب‌کار سلول‌های ارجاع‌شده توسط سری‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه محدودهٔ متفاوت هستند:

- تنظیمات سطح سری، مانند [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getFormat)، ظاهر پیش‌فرض تمام نقاط یک سری را فراهم می‌کنند.
- تنظیمات نقطهٔ داده، مانند [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#getFormat)، ظاهر سری را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروه برای سری‌های سازگاری که به همان [ChartSeriesGroup](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseriesgroup/) تعلق دارند، اعمال می‌شود. برای تنظیم گزینه‌هایی مانند همپوشانی یا عرض فاصله، گروه را از طریق [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) دریافت کنید.

وقتی پر کردن صریح برای نقطه یا سری تعیین نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم فرم‌گذاری سری و هم نقطه موجود باشد، فرم‌گذاری نقطه برای آن نقطه برتری دارد.

![نمودار‑سری‑پاورپوینت](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری نمودار**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getOverlap) گزارش می‌دهد که نوارها یا ستون‌ها تا چه حد در یک نمودار 2D همپوشانی دارند، از ‑100 تا 100 درصد. این یک پیش‌بینی فقط‑خواندنی از تنظیمات گروه والد سری است. برای به‌روزرسانی همهٔ سری‌های سازگار در آن گروه از [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) استفاده کنید. این گزینه برای انواع نموداری که نوارها یا ستون‌های گروه‌بندی‌شده را نمایش می‌دهند اعمال می‌شود؛ روی گروه‌های سری نامرتبط در یک نمودار ترکیبی تأثیر ندارد.

مثال زیر همپوشانی گروهی را که شامل اولین سری است تنظیم می‌کند:

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

![همپوشانی سری‌ها](series_overlap.png)

## **تغییر رنگ پر کردن سری**

از [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getFormat) برای تنظیم پر کردن پیش‌فرض یک سری کامل استفاده کنید. اگر برای یک نقطه پر کردن صریحی موجود باشد، تنظیم [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#getFormat) آن نقطه را بازنویسی می‌کند.

مثال زیر یک پر کردن آبی یکدست برای اولین سری اعمال می‌کند:

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

![رنگ سری](series_color.png)

## **تغییر نام سری**

نام سری در کتاب‌کار داده‌های نمودار ذخیره می‌شود و معمولاً در راهنمایی (legend) نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ایجاد‌شده برای یک نمودار ستون خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین سری را دارد. ثابت‌های نام‌گذاری شده در مثال زیر این ساختار را به‌صورت صریح نشان می‌دهند:

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

همچنین می‌توانید سلول ارجاع‌شده توسط [ChartSeries.getName](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getName) را به‌روزرسانی کنید. این روش از فرض یک ردیف و ستون خاص در یک نمودار موجود جلوگیری می‌کند:

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

![نام سری](series_name.png)

## **دریافت رنگ پر کردن خودکار سری**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) رنگی را بر می‌گرداند که از شاخص سری و سبک نمودار محاسبه شده است. این همان رنگی است که وقتی پر کردن سری صریحاً تعریف نشده باشد استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی اختصاص نمی‌دهد.

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

خروجی مثال برای سبک پیش‌فرض نمودار:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

رنگ‌های دقیق به سبک و تم نمودار وابسته‌اند.

## **تنظیم رنگ پر کردن معکوس برای یک سری نمودار**

برای سری‌های نوار، ستون و حباب، [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) می‌تواند مقادیر منفی را با پر کردن متفاوتی نشان دهد. پر کردن معمولی سری را به‌صورت جامد تنظیم کنید، معکوس شدن را فعال کنید و رنگ مقدار منفی را از طریق [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) اختصاص دهید. اعداد منفی در کتاب‌کار تغییری نمی‌کنند؛ فقط رنگ نمایش آن‌ها تغییر می‌یابد.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 کاربرگ نام سری را دارد، ستون 0 نام دسته‌ها و ستون 1 مقادیر را دارد:

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

می‌توانید برای یک نقطه معکوس شدن را از طریق [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) فعال کنید. در مثال زیر معکوس برای سری غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال شده است. این نقطه همچنین مقدار منفی دریافت می‌کند تا اثر قابل رؤیت باشد:

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

## **پاک کردن مقدار نقطهٔ دادهٔ خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول کتاب‌کار پشتیبان آن را به `null` تنظیم کنید. برای یک نمودار ستون، مقدار ترسیم‌شده از طریق [ChartDataPoint.getValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#getValue) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را به‌عنوان خالی طبق تنظیمات مقدار خالی نمودار در نظر می‌گیرد.

مثال زیر فقط نقطهٔ دوم در اولین سری را پاک می‌کند:

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

نمودارهای پراش از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حباب نیز از یک سلول اندازه بهره می‌برند. فقط سلولی را پاک کنید که نمایانگر مقداری است که می‌خواهید حذف کنید. هنگامیکه می‌خواهید نقاط دیگر را نگه دارید، از فراخوانی [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapointcollection/#clear) خودداری کنید؛ این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های پنهان که شامل مقادیر هستند، موردی متفاوت نسبت به سلول‌های خالی هستند. برای شامل یا مستثنی‌کردن داده‌ها از ردیف‌ها و ستون‌های پنهان کاربرگ، به [Include Data from Hidden Rows and Columns](/slides/fa/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول خالی کتاب‌کار نشانگر دادهٔ گمشده است؛ سلولی که `0` دارد نشانگر مقدار عددی شناخته‌شده‌ای است. برای خالی کردن یک سلول، [ChartDataCell.setValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setValue) را با `null` فراخوانی کنید. عدد صفر عددی می‌ماند صرف‌نظر از تنظیم خالی‑سلول.

از [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) برای انتخاب نحوه نمایش سلول‌های خالی استفاده کنید. این تنظیم برای تمام نمودار اعمال می‌شود. این تنظیم نحوهٔ ترسیم خالی‌ها را تغییر می‌دهد بدون این‌که سلول خالی کتاب‌کار را با صفر یا مقدار درون‌خطی پر کند.

مثال خودمستقلی زیر یک نمودار خطی با یک سری ایجاد می‌کند، مقدار روز 3 را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. هیچ فایل ورودی‌ای نیاز نیست. [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/) از کاربرگ 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام سری را دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

    // روز 3 را واقعاً خالی بگذارید، در حالی که دسته‌بندی و نقطه دادهٔ آن را حفظ می‌کند.
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

هر فایل خروجی حالت اختصاص‑داده‌شده پیش از ذخیره را نگه می‌دارد: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ تنها یک نسخه، حالت دلخواه را تنظیم کنید و یک‌بار ارائه را ذخیره کنید به‌جای تکرار روی حالات.

مقایسهٔ زیر همان داده را در هر سه فایل نشان می‌دهد. روز 3 در کتاب‌کار در هر حالت خالی است:

![نمودارهای خطی با داده‌های یکسان: Gap خط را در روز 3 قطع می‌کند، Zero خط را به صفر می‌کشاند و Span روز 2 را به روز 4 متصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی تمام سه حالت را برای مقایسه آسان می‌کند. نمودارهای نوار و ستون خطی برای اتصال میان دسته‌های گمشده ندارند، بنابراین `Span` نمی‌تواند بخشی که در بالا نشان داده شده را تولید کند؛ یک ستون گمشده و یک ستون صفر‑ارتفاع نیز می‌توانند مشابه به‌نظر برسند. به‌طور مشابه، یک نمودار پراش فقط با نشانه‌ها هیچ خطی برای اتصال ندارد. انتظار داشتن سه نتیجهٔ متمایز برای هر نوع نمودار نداشته باشید؛ خروجی مورد استفادهٔ خود را بررسی کنید.

## **تنظیم عرض فاصلهٔ سری**

عرض فاصلهٔ بین خوشه‌های نوار یا ستون مجاور است که به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. مانند همپوشانی، این تنظیم به گروه والد سری تعلق دارد نه به یک سری منفرد. یک‌بار برای گروه [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) فراخوانی کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچک‌تر آن‌ها را فشرده‌تر می‌سازد.

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

![عرض فاصله](gap_width.png)

## **پرسش‌های متداول**

**کدام انواع نمودار از سری داده پشتیبانی می‌کنند؟**

تمام انواع نمودار که توسط شمارندهٔ [ChartType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/) تعریف شده‌اند از داده‌های نمودار استفاده می‌کنند، اما سری‌های آن‌ها همه ساختار مقدار یا تنظیمات یکسانی ندارند. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراش از مقادیر X و Y، و نمودارهای حباب اندازهٔ حباب‌ها را اضافه می‌کنند. از روش ایجاد نقطهٔ داده‌ای استفاده کنید که با نوع سری هماهنگ باشد. گزینه‌هایی مثل همپوشانی و عرض فاصله فقط برای گروه‌های نوار یا ستون سازگار اعمال می‌شود.

**گروه سری نمودار چیست؟**

یک [ChartSeriesGroup](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات رسم در سطح گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک سری به آن دست می‌یابید، لزوماً همهٔ سری‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه ایجادشده داده‌های پیش‌فرض دارد؟**

بله. به‌صورت پیش‌فرض، [ShapeCollection.addChart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/#addChart) سری‌ها، دسته‌ها و مقادیر نمونه را ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا هم مجموعهٔ سری‌ها و هم مجموعهٔ دسته‌ها را قبل از افزودن مجموعهٔ دادهٔ کاملاً سفارشی پاک کنید. یک بارگیری نیز می‌تواند نموداری بدون دادهٔ پیش‌فرض ایجاد کند.

**اشیای نمودار چگونه به سلول‌های کتاب‌کار متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقطهٔ داده به سلول‌های یک [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده المان مربوط به نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر سری را هماهنگ نگه دارید تا هر نقطه زیر دستهٔ مورد نظر ترسیم شود.

**چگونه می‌توان یک نقطه را به‌جای کل سری پاک کرد؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. فقط زمانی که می‌خواهید تمام نقاط یک سری را حذف کنید از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapointcollection/#clear) استفاده کنید. اگر دسته‌ها را نیز حذف می‌کنید، همهٔ سری‌ها را طوری به‌روز کنید که مقادیرشان با مجموعهٔ دسته‌ها منطبق بمانند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقداری که از طریق [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) پیکربندی شده بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فضای خالی، به‌عنوان مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که با معنای دادهٔ گمشده در ارائهٔ شما همخوانی داشته باشد. برای مثال کامل و مقایسهٔ تصویری به بخش [Control the Display of Empty Cells](#control-the-display-of-empty-cells) رجوع کنید.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های نوار، ستون و حباب پشتیبانی‌شده، [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) را فراخوانی کنید و رنگی که توسط [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) برگردانده می‌شود تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**وقتی هم سری و هم نقطه قالب‌بندی شوند، کدام قالب‌بندی برتر است؟**

قالب‌بندی صریح نقطهٔ داده برای همان نقطه برتری دارد. نقاط دیگر به قالب‌بندی صریح سری یا، وقتی قالب‌بندی سری تعریف نشده باشد، به سبک و تم خودکار نمودار ادامه می‌دهند. تنظیمات گروهی مانند همپوشانی و عرض فاصله نحوهٔ چیدمان را کنترل می‌کنند و بازنویسی قالب‌بندی در سطح نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیتی ثابت برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ حد عملی هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد نزدیک یا دور هستند؟**

روی گروه والد سری مناسب [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) فراخوانی کنید. برای افزایش فاصله بین خوشه‌ها مقدار را بزرگتر کنید یا برای نزدیک‌تر کردن خوشه‌ها مقدار را کوچکتر کنید.