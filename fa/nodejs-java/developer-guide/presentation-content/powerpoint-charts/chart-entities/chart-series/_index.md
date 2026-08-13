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
- سلول کارکتاب
- فاصله سری
- مقدار منفی
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کارکتاب، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با JavaScript مدیریت کنید."
---
## **مرور کلی**

یک نمودار داده‌های رسم‌شده خود را در یک کار‑کتاب داده‌های نمودار ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/) یک مجموعه از مقادیر مرتبط را نشان می‌دهد و هر [ChartDataPoint](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/) در این سری به یک یا چند سلول کار‑کتاب ارجاع می‌دهد. اشیای [ChartCategory](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین سری‌ها را فراهم می‌کنند. بنابراین نام سری، دسته‌بندی‌ها و مقادیر نقاط به اشیای [ChartDataCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/) متصل هستند و فقط به‌عنوان متن نمایش ذخیره نمی‌شوند.

برای یک نمودار دسته‌ای معمولی، کار‑کتاب پیش‌فرض از ردیف 0 برای نام سری‌ها، ستون 0 برای نام دسته‌ها و سلول‌های باقی‌مانده برای مقادیر سری استفاده می‌کند. شاخص‌های کار‑برگه، ردیف و ستون که به ‎[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#getCell)‎ ارسال می‌شوند، صفر‑پایه‌اند. این ساختار زمانی مفید است که نموداری را با داده‌های پیش‌فرض ایجاد می‌کنید، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کار‑کتاب، سلول‌های ارجاع‌شده توسط سری‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار سه حوزه مختلف دارند:

- تنظیمات سطح سری، مانند ‎[ChartSeries.getFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getFormat)‎، ظاهر پیش‌فرض تمام نقاط یک سری را فراهم می‌کند.
- تنظیمات نقطه داده، مانند ‎[ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#getFormat)‎، ظاهر سری را برای یک نقطه نادیده می‌گیرد.
- تنظیمات گروه برای سری‌های سازگاری که به همان ‎[ChartSeriesGroup](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseriesgroup/)‎ تعلق دارند اعمال می‌شود. هنگام نیاز به تنظیم گزینه‌هایی مانند همپوشانی یا عرض فاصله، از ‎[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup)‎ برای دسترسی به گروه استفاده کنید.

زمانی که هیچ پرکننده صریحی برای نقطه یا سری تعیین نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کنند. وقتی هر دو قالب‌بندی سری و نقطه وجود داشته باشد، قالب‌بندی نقطه برای آن نقطه اولویت دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری نمودار**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getOverlap) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار 2D تا چه حد همپوشانی دارند، از -100 تا 100 درصد. این یک پیش‌نمایش فقط‑خواندنی از تنظیمات گروه سری والد است. برای به‌روزرسانی تمام سری‌های سازگار در آن گروه، از [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) استفاده کنید. این گزینه برای انواع نمودارهایی که نوارها یا ستون‌های گروهی نمایش می‌دهند اعمال می‌شود؛ بر گروه‌های سری نامرتبط در یک نمودار ترکیبی تأثیر نمی‌گذارد.

مثال زیر همپوشانی را برای گروهی که شامل اولین سری است تنظیم می‌کند:

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

## **تغییر رنگ پرکننده سری**

از [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getFormat) برای تنظیم پرکننده پیش‌فرض یک سری کامل استفاده کنید. اگر یک نقطه قبلاً پرکننده صریحی داشته باشد، تنظیم ‎[ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#getFormat)‎ آن پرکننده سری را برای آن نقطه نادیده می‌گیرد.

مثال زیر یک پرکننده آبی واحد را به اولین سری اعمال می‌کند:

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

نام یک سری در کار‑کتاب داده‌های نمودار ذخیره می‌شود و معمولاً در افسانه نمایش داده می‌شود. در کار‑کتاب پیش‌فرض ایجاد شده برای یک نمودار ستون خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین سری را شامل می‌شود. ثابت‌های نامبرده در مثال زیر این ساختار را صریح می‌نمایند:

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

همچنین می‌توانید سلولی که توسط ‎[ChartSeries.getName](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getName)‎ ارجاع شده است، به‌روزرسانی کنید. این رویکرد از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

## **دریافت رنگ پرکننده خودکار سری**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) رنگی را برمی‌گرداند که از شاخص سری و سبک نمودار محاسبه می‌شود. این همان رنگی است که زمانی که پرکننده سری صریحاً تعریف نشده باشد، استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پرکننده جدیدی اختصاص نمی‌دهد.

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

## **تنظیم رنگ پرکننده معکوس برای یک سری نمودار**

برای سری‌های نوار، ستون و حباب، ‎[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative)‎ می‌تواند مقادیر منفی را با پرکننده متفاوت نمایش دهد. پرکننده معمولی سری را به حالت صلب تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از ‎[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor)‎ دریافت کنید. اعداد منفی در کار‑کتاب بدون تغییر می‌مانند؛ تنها رنگ نمایش آنها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 کار‑برگه نام سری را دارد، ستون 0 نام دسته‌ها و ستون 1 مقادیر را دارد:

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

![رنگ پرکننده صلب معکوس](inverted_solid_fill_color.png)

می‌توانید معکوس‌سازی را برای یک نقطه از طریق ‎[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative)‎ فعال کنید. در مثال زیر، معکوس‌سازی برای سری غیرفعال و فقط برای نقطه منتخب فعال می‌شود. همچنین به نقطه مقدار منفی اختصاص داده می‌شود تا اثر مشاهده شود:

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

## **پاک کردن مقدار نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشتوانهٔ آن را به `null` تنظیم کنید. برای یک نمودار ستون، مقدار رسم‌شده از طریق ‎[ChartDataPoint.getValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#getValue)‎ در دسترس است. نقطه داده در همان موقعیت دسته‌مانند می‌ماند، اما نمودار مقدار آن را به‌عنوان مقدار خالی مطابق تنظیمات مقدار خالی نمودار در نظر می‌گیرد.

مثال زیر فقط نقطه دوم در اولین سری را پاک می‌کند:

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

نمودارهای پراکنده از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حباب نیز یک سلول اندازه دارند. فقط سلولی را که نشان‌دهنده مقدار مورد نظر برای حذف است، پاک کنید. هنگام تمایل به نگه داشتن نقاط دیگر، از ‎[ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapointcollection/#clear)‎ استفاده نکنید، زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **تنظیم عرض فاصله سری**

عرض فاصله فاصله بین خوشه‌های نوار یا ستون مجاور است و به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. همانند همپوشانی، این مقدار به گروه سری والد تعلق دارد نه به یک سری منفرد. برای گروه یک بار ‎[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth)‎ را فراخوانی کنید. مقدار بزرگتر فضا بین خوشه‌ها را زیاد می‌کند؛ مقدار کوچکتر آن‌ها را متراکم‌تر می‌سازد.

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

## **سوالات متداول**

**کدام انواع نمودار از سری‌های داده پشتیبانی می‌کنند؟**

تمام انواع نمودار که توسط ‎[ChartType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/)‎ تعریف می‌شوند از داده‌های نمودار استفاده می‌کنند، اما ساختار یا تنظیمات مقدار سری آن‌ها یکسان نیست. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حباب اندازه حباب‌ها را اضافه می‌کنند. از متد ایجاد نقطه داده‌ای که با نوع سری مطابقت دارد استفاده کنید. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های نوار یا ستون سازگار اعمال می‌شوند.

**یک گروه سری نمودار چیست؟**

‎[ChartSeriesGroup](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseriesgroup/)‎ شامل سری‌های سازگاری است که تنظیمات رسم سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک سری به آن دست یافته‌اید لزوماً همهٔ سری‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه‌ساخته دارای داده‌های پیش‌فرض است؟**

بله. به‌طور پیش‌فرض، ‎[ShapeCollection.addChart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/#addChart)‎ نمونه‌ای از سری‌ها، دسته‌ها و مقادیر را ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه‌ دادهٔ کاملاً سفارشی، هر دو مجموعهٔ سری و دسته را پاک کنید. همچنین یک overload می‌تواند نموداری بدون داده‌های پیش‌فرض ایجاد کند.

**اشیای نمودار چگونه به سلول‌های کار‑کتاب متصل هستند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های ‎[ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/)‎ ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده عنصر مربوط به نمودار را به‌روزرسانی می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر سری را هم‌راستا نگه دارید تا هر نقطه زیر دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را به‌جای کل سری پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. از ‎[ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapointcollection/#clear)‎ فقط زمانی استفاده کنید که قصد حذف تمام نقاط آن سری را دارید. اگر دسته‌ها را نیز حذف می‌کنید، برای حفظ هم‌راستایی مقادیر هر سری را به‌روزرسانی کنید.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقداری که از طریق ‎[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs)‎ پیکربندی شده است بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به صورت گپ، به عنوان مقدار صفر یا با اتصال نقاط مجاور نمایش دهند. تنظیمی را انتخاب کنید که معنای داده‌های گمشده در ارائهٔ شما را بهتر منعکس کند.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های نوار، ستون و حباب پشتیبانی‌شده، ‎[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative)‎ را فراخوانی کنید و رنگی که از ‎[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor)‎ برمی‌گردد تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ تک‌تکه با ‎[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative)‎ بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**زمانی که هم سری و هم نقطه قالب‌بندی شوند، کدام‌یک برتری دارد؟**

قالب‌بندی صریح نقطه داده برای آن نقطه اولویت دارد. نقاط دیگر به قالب‌بندی صریح سری یا، زمانی که قالب‌بندی سری تعریف نشده باشد، به سبک و تم خودکار نمودار ادامه می‌دهند. تنظیمات گروه مانند همپوشانی و عرض فاصله، که مربوط به چیدمان هستند، به‌عنوان بازنویسی قالب‌بندی نقطه‑سطحی عمل نمی‌کنند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت شمار ثابت جداگانه‌ای برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ حد معقولی هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها یک‌دیگر را خیلی نزدیک یا خیلی دور هستند؟**

‎[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth)‎ را بر روی گروه سری والد مناسب فراخوانی کنید. برای افزایش فضا بین خوشه‌ها مقدار را بزرگتر کنید یا برای نزدیک‌تر کردن خوشه‌ها مقدار را کوچک‌تر کنید.