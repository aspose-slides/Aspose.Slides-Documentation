---
title: مدیریت مجموعه داده‌های نمودار در ارائه‌ها با استفاده از JavaScript
linktitle: مجموعه داده
type: docs
url: /fa/nodejs-java/chart-series/
keywords:
- مجموعه نمودار
- همپوشانی مجموعه
- رنگ مجموعه
- نام مجموعه
- نقطه داده
- سلول کتاب‌کار
- فاصله مجموعه
- مقدار منفی
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "بیاموزید چگونه مجموعه‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فواصل و مقادیر منفی را در ارائه‌ها با JavaScript مدیریت کنید."
---
## **نمای کلی**

یک نمودار می‌تواند مقادیر ترسیم‌شده خود را در سلول‌های کتاب‌کار یا به‌صورت عددی مستقیم ذخیره کند. یک [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) نمایانگر یک مجموعه از مقادیر مرتبط است و هر [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) نمایانگر یک نقطه در آن مجموعه است. اشیاء [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) برچسب‌ها یا مقادیر گروهی را که توسط مجموعه‌ها مشترک هستند فراهم می‌کنند. در نمودارهای ایجاد شده با داده‌های پیش‌فرض، نام‌های مجموعه، دسته‌ها و مقادیر نقاط از اشیاء [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) در کتاب‌کار نمودار استفاده می‌شود.

برای یک نمودار دسته‌ای معمولی، کتاب‌کار پیش‌فرض از ردیف 0 برای نام‌های مجموعه، ستون 0 برای نام‌های دسته و بقیهٔ سلول‌ها برای مقادیر مجموعه استفاده می‌کند. شاخص‌های برگه، ردیف و ستون که به ‎[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/)‎ ارسال می‌شوند صفر‑مبنا هستند. این چیدمان هنگام ایجاد نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائهٔ بارگذاری‌شده، قبل از تغییر مقادیر کتاب‌کار سلول‌های مرجع شده توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه محدودهٔ متفاوت هستند:

- تنظیمات در سطح مجموعه، مانند ‎[ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/)‎، ظاهر پیش‌فرض همهٔ نقاط یک مجموعه را فراهم می‌کند.
- تنظیمات نقطه‑داده، مانند ‎[ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/)‎، ظاهر مجموعه را برای یک نقطهٔ خاص بازنویسی می‌کند.
- تنظیمات گروهی بر روی مجموعه‌های سازگاری که به همان ‎[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/)‎ تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی نظیر پوشش‌پذیری یا عرض فاصله، از ‎[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/)‎ استفاده کنید.

زمانی که پر کردن صریح برای نقطه یا مجموعه‌ای تعیین نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات مجموعه و هم تنظیمات نقطه موجود باشد، تنظیمات نقطه برای آن نقطه اولویت دارد.

![نمودار‑سری‑پاورپوینت](chart-series-powerpoint.png)

در یک نمودار استوانه‌ای خوشه‌ای، ببینید چگونه ‎[changing the 3D series type or bar shape](/slides/fa/nodejs-java/3d-chart/#change-the-3d-series-type-and-bar-shape)‎ بر اولین مجموعه تأثیر می‌گذارد.

## **تنظیم مقادیر مجموعه با عددهای صریح**

از عددهای صریح زمانی استفاده کنید که مقادیر مجموعه از داده‌های برنامه یا محاسبات می‌آیند و نیازی به ارجاع به سلول‌های برگه کار نیست. قبل از اختصاص نتیجهٔ ‎[getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/)‎ هر نقطه، ‎[setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/)‎ را با ‎[DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/)‎ فراخوانی کنید و سپس ‎[setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/)‎ را اعمال کنید.

تنظیم مجموعهٔ کنترل‌کنندهٔ نوع منبع تمام مقادیر نقطه‌ها در آن مجموعه را تعیین می‌کند. هر مقدار نقطه با ‎[getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/)‎ نوع انتخاب‌شده را گزارش می‌دهد؛ آن را از طریق تنظیم مجموعه تغییر دهید. با ‎`Worksheet`‎، از ‎[getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/)‎ برای دسترسی به سلول مرجع استفاده کنید. با ‎`DoubleLiterals`‎، از ‎[getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/)‎ یا ‎`setAsLiteralDouble`‎ برای خواندن یا نوشتن مستقیم عدد استفاده کنید.

مثال زیر یک نمودار ستونی با مجموعه‌ها و دسته‌های پیش‌فرض ایجاد می‌کند، سپس مقادیر محاسبه‌شدهٔ 10، 20 و … را به نقاط موجود مجموعهٔ اول اختصاص می‌دهد. سپس ارائه را ذخیره، باز می‌کند و مقادیر ذخیره‌شده را چاپ می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

نوع منبع مقدار نقطه جدا از ‎[ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/)‎ است که پیکربندی کتاب‌کار داخلی یا خارجی نمودار را مشخص می‌کند. استفاده از عددهای صریح به تنهایی کتاب‌کار توکار را حذف نمی‌کند. در این مثال، کتاب‌کار برای برچسب‌های دسته، نام‌های مجموعه و سایر مجموعه‌ها در دسترس باقی می‌ماند. برای مدیریت کتاب‌کار، بخش ‎[Chart Workbook](/slides/fa/nodejs-java/chart-workbook/)‎ را ببینید.

برای نمودارهای پراکندگی و حبابی، از ‎[setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/)‎ و ‎[setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/)‎ برای انتخاب منابع ‎[getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/)‎ و ‎[getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/)‎ استفاده کنید. نمودارهای حبابی همچنین از ‎[setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/)‎ برای ‎[getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/)‎ بهره می‌‏برند. هر منبع مربوطه را قبل از اختصاص عدد با `DoubleLiterals` تنظیم کنید و سپس از روش ‎`setAsLiteralDouble`‎ استفاده کنید.

## **تنظیم تداخل مجموعهٔ نمودار**

‎[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/)‎ گزارش می‌دهد که میله‌ها یا ستون‌ها در یک نمودار دو‑بعدی تا چه حد هم‑پوشانی دارند، مقادیر بین ‎-100‎ تا ‎100‎ درصد. این یک تصویر‌نگاری فقط‑خواندنی از تنظیمات گروه مجموعه والد است. برای به‑روزرسانی تمام مجموعه‌های سازگار در آن گروه، از ‎[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/)‎ استفاده کنید. این گزینه برای انواع نمودارهایی که میله‌ها یا ستون‌های گروهی نمایش می‌دهند اعمال می‌شود؛ برای گروه‌های مجموعهٔ نامرتبط در یک نمودار ترکیبی اثر ندارد.

مثال زیر تداخل را برای گروهی که شامل اولین مجموعه است تنظیم می‌کند:

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

    // چارت جدید شامل مجموعه‌های نمونه، دسته‌ها و مقادیر است.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![تداخل مجموعه‌ها](series_overlap.png)

## **تغییر رنگ پر کردن مجموعه**

از ‎[ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/)‎ برای تنظیم پر کردن پیش‌فرض تمام مجموعه استفاده کنید. اگر یک نقطه قبلاً پر کردن صریح داشته باشد، تنظیم ‎[ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/)‎ آن، پر کردن مجموعه را برای همان نقطه بازنویسی می‌کند.

مثال زیر پر کردن آبی ثابت را به اولین مجموعه اعمال می‌کند:

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

نام یک مجموعه در کتاب‌کار داده‌های نمودار ذخیره می‌شود و به‌طور معمول در افسانه (legend) نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ایجاد شده برای یک نمودار ستون خوشه‌ای، سلول ‎B1‎ (ردیف 0، ستون 1) شامل نام اولین مجموعه است. ثابت‌های نام‌گذاری در مثال زیر این ساختار را واضح می‌کند:

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

همچنین می‌توانید سلولی را که توسط ‎[ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/)‎ ارجاع داده می‌شود، به‌روزرسانی کنید. این روش از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

### **ایجاد مجموعه‌ای با نام از چند سلول**

یک نام مجموعه ترکیبی زمانی مفید است که نام محصول و بازهٔ گزارش‌گیری در سلول‌های جداگانهٔ کتاب‌کار ذخیره شوند. به‌عنوان مثال، می‌توانید `Product A` در ‎B1‎ و `2026` در ‎C1‎ را به یک نام مجموعه ترکیب کنید در حالی که هر دو بخش به سلول‌های منبع خود متصل می‌مانند.

از ‎[ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/)‎ برای دریافت محدودهٔ نام استفاده کنید، سپس آن مجموعه را به ‎[ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/)‎ بدهید. آرگومان ‎`skipHiddenCells`‎ تعیین می‌کند که آیا سلول‌های مخفی شامل شوند یا نه: `true` آنها را مستثنی می‌کند، `false` شامل می‌کند. این مثال از `false` برای شامل شدن تمام سلول‌های محدودهٔ نام استفاده می‌کند.

مثال زیر یک ارائه با یک مجموعه و دو نقطه داده ایجاد می‌کند. سلول‌های ‎B1:C1‎ فقط نام مجموعه را فراهم می‌کنند؛ ‎A2:A3‎ برچسب‌های دسته و ‎B2:B3‎ مقادیر عددی را فراهم می‌کنند.

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

    // این دو سلول نام مجموعه را تامین می‌کنند.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // سلول‌های جداگانه، دسته‌ها و نقاط داده عددی را تامین می‌کنند.
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

نام مجموعهٔ حاصل `Product A 2026` است، با یک فاصله بین دو مقدار سلول. افسانه این را به‌عنوان یک ورودی برای هر دو ستون نمایش می‌دهد. تصویر زیر نتیجه را نشان می‌دهد:

![نمودار ستونی با مقادیر North و South و نام مجموعه ترکیبی Product A 2026 در افسانه](composite_series_name.png)

## **دریافت رنگ پر کردن خودکار مجموعه**

‎[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/)‎ رنگی را برمی‌گرداند که از شاخص مجموعه و سبک نمودار محاسبه می‌شود. این رنگ هنگامیکه پر کردن مجموعه صریح تعریف نشده باشد، به‌کار می‌رود. فراخوانی این متد رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی ایجاد نمی‌کند.

مثال زیر رنگ خودکار هر مجموعه پیش‌فرض را چاپ می‌کند:

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

## **تنظیم رنگ پر کردن وارون برای مجموعهٔ نمودار**

برای مجموعه‌های میله‌ای، ستونی و حبابی، ‎[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/)‎ می‌تواند مقادیر منفی را با پر کردن متفاوتی نمایش دهد. پر کردن معمولی مجموعه را به حالت ثابت تنظیم کنید، وارونگی را فعال کنید و رنگ منفی را از طریق ‎[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/)‎ اختصاص دهید. اعداد منفی در کتاب‌کار تغییری نمی‌کنند؛ تنها رنگ نمایش آن‌ها تغییر می‌یابد.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 برگه کار شامل نام مجموعه، ستون 0 شامل نام‌های دسته و ستون 1 شامل مقادیر است:

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

![رنگ پر کردن ثابت وارون](inverted_solid_fill_color.png)

می‌توانید وارونگی را برای یک نقطه توسط ‎[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/)‎ فعال کنید. در مثال زیر وارونگی برای مجموعه غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال است. این نقطه همچنین مقدار منفی دریافت می‌کند تا اثر قابل‌مشاهده باشد:

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

## **پاک‌کردن مقدار نقطهٔ دادهٔ خاص**

برای خالی کردن یک نقطه بدون حذف سایر نقاط، سلول کتاب‌کار آن را به `null` تنظیم کنید. در یک نمودار ستونی، مقدار ترسیم‌شده از طریق ‎[ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/)‎ در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را به‌عنوان خالی براساس تنظیمات خالی‌بودن نمودار در نظر می‌گیرد.

مثال زیر تنها نقطه دوم مجموعهٔ اول را پاک می‌کند:

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

نمودارهای پراکندگی از سلول‌های جداگانهٔ X و Y استفاده می‌کنند و نمودارهای حبابی نیز از یک سلول اندازه استفاده می‌کنند. فقط سلولی که نمایانگر مقداری است که می‌خواهید حذف کنید را پاک کنید. هنگام نیاز به حفظ سایر نقاط، ‎[ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/)‎ را صدا نزنید، زیرا این متد تمام نقاط دادهٔ مجموعه را حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که دارای مقادیر هستند موردی متفاوت نسبت به سلول‌های خالی هستند. برای شامل یا مستثنی کردن داده‌ها از ردیف‌ها و ستون‌های مخفی، به ‎[Include Data from Hidden Rows and Columns](/slides/fa/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns)‎ مراجعه کنید.

یک سلول کتاب‌کار خالی نشان‌دهندهٔ دادهٔ گمشده است؛ سلولی که ‎`0`‎ داشته باشد نشان‌دهندهٔ یک مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، ‎[ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/)‎ را با `null` فراخوانی کنید. عدد صفر عددی صفر می‌ماند بدون در نظر گرفتن تنظیم خالی‑سلول.

از ‎[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/)‎ برای انتخاب نحوهٔ نمایش سلول‌های خالی استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود و نحوهٔ ترسیم خالی‌ها را بدون پر کردن سلول خالی با صفر یا مقدار درونیافته تغییر می‌دهد.

مثال زیر یک نمودار خطی با یک مجموعه ایجاد می‌کند، مقدار روز 3 را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به پروندهٔ ورودی نیست. ‎[ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/)‎ از برگه 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را نگه می‌دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

    // روز ۳ را واقعاً خالی بگذارید، در حالی که دسته‌بندی و نقطهٔ دادهٔ آن را حفظ می‌کنید.
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

هر پروندهٔ خروجی حالت انتخاب‌شده پیش از ذخیره‌سازی را ذخیره می‌کند: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ تنها یک نسخه، حالت دلخواه را تنظیم کنید و یک‌بار ارائه را ذخیره کنید.

مقایسهٔ زیر همان داده‌ها را در هر سه پرونده نشان می‌دهد. روز 3 در هر حالت در کتاب‌کار خالی است:

![نمودارهای خطی با داده‌های یکسان: Gap خط را در روز 3 قطع می‌کند، Zero خط را به صفر می‌کشد، و Span روز 2 را به روز 4 وصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده بسته به نوع نمودار متفاوت است. یک نمودار خطی سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای میله‌ای و ستونی خطی برای اتصال بین دسته‌های گمشده ندارند، بنابراین `Span` نمی‌تواند بخشی که در بالا نشان داده شده است ایجاد کند؛ یک ستون گمشده و یک ستون صفر‑ارتفاع می‌توانند مشابه به‌نظر برسند. به‌طور مشابه، یک نمودار پراکندگی فقط با نشانگرها خطی برای اتصال ندارد. انتظار نتایج متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصلهٔ مجموعه**

عرض فاصلهٔ بین خوشه‌های میله‌ای یا ستونی، به‌صورت درصدی از عرض میله یا ستون محاسبه می‌شود. همانند تداخل، این تنظیم به گروه مجموعهٔ والد تعلق دارد نه به یک مجموعهٔ منفرد. یک بار برای گروه ‎[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/)‎ فراخوانی کنید. مقدار بزرگ‌تر فضای بین خوشه‌ها را بیشتر می‌کند؛ مقدار کوچکتر آن‌ها را فشرده‌تر می‌سازد.

مثال زیر عرض فاصله را تغییر می‌دهد و تنها ارائهٔ نهایی را ذخیره می‌کند:

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

## **نمایش یا مخفی‌کردن خطوط مجموعه**

خطوط مجموعه به‌صورت بصری بخش‌های مربوط به یک نمودار را به‌هم می‌پیوندد. برای نمایش یا مخفی‌کردن آن‌ها در نمودارهای میله‌ای پشته‌ای و OfPie پشتیبانی‌شده، از ‎[ChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setserieslines/)‎ استفاده کنید. در نمودارهای میله‌ای و ستونی پشته‌ای دو‑بعدی، این خطوط مرزهای پشتهٔ مربوطه را بین دسته‌ها متصل می‌کند. در نمودارهای Pie of Pie و Bar of Pie، این خطوط نمودار اصلی را به نمودار ثانویه متصل می‌کند. این تنظیم برای دیگر انواع نمودار عمومی نیست.

دست به گروه از طریق ‎[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/)‎ بگیرید. تنظیم برای تمام مجموعه‌های آن گروه اعمال می‌شود. ‎[ChartSeries.hasSeriesLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/hasserieslines/)‎ فقط‑خواندنی است و تنظیم والد را نشان می‌دهد؛ برای به‌روزرسانی، setter گروه را فراخوانی کنید.

مثال زیر یک نمودار ‎[PieOfPie](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)‎ با داده‌های پیش‌فرض ایجاد می‌کند. همان نمودار را ابتدا با خطوط مجموعه فعال و سپس غیرفعال ذخیره می‌کند تا دو ارائه برای مقایسه تولید شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 400);
    const series = chart.getChartData().getSeries().get_Item(0);
    const seriesGroup = series.getParentSeriesGroup();

    seriesGroup.setSeriesLines(true);
    presentation.save("series_lines_enabled.pptx", aspose.slides.SaveFormat.Pptx);

    seriesGroup.setSeriesLines(false);
    presentation.save("series_lines_disabled.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| خطوط مجموعه فعال | خطوط مجموعه غیرفعال |
| --- | --- |
| ![نمودار Pie of Pie با خطوط مجموعه فعال](series_lines_enabled.png) | ![نمودار Pie of Pie با خطوط مجموعه غیرفعال](series_lines_disabled.png) |
| دو خط اصلی پیک را به پیک ثانویه وصل می‌کنند. | هر دو پیک قابل مشاهده‌اند، اما خطوط اتصال مخفی‌اند. |

خطوط مجموعه متفاوت از خطوط رهبری برچسب داده هستند که برچسب‌ها را به نقاط داده متصل می‌کنند؛ خطوط شبکه که فواصل را بر روی محورهای نمودار نشان می‌دهند؛ و خطوط در نمودار خطی که مقادیر داده‌ها را نشان می‌دهند. این تنظیم آن‌ها را کنترل نمی‌کند.

## **سوالات متداول**

**کدام انواع نمودار از مجموعه‌های داده پشتیبانی می‌کنند؟**

تمام انواع نمودارهای نشان‌داده‌شده توسط شمارش ‎[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)‎ از داده‌های نمودار استفاده می‌کنند، اما مجموعه‌های آن‌ها ساختار یا تنظیمات مقدار یکسانی ندارند. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حبابی به اندازهٔ حباب افزوده می‌شود. از روش ایجاد نقطه‑داده‌ای که با نوع مجموعه سازگار است استفاده کنید. گزینه‌هایی نظیر تداخل و عرض فاصله فقط برای گروه‌های میله‌ای یا ستونی سازگار اعمال می‌شوند.

**یک گروه مجموعهٔ نمودار چیست؟**

یک ‎[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/)‎ شامل مجموعه‌های سازگاری است که تنظیمات ترسیم سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه دسترسی پیدا می‌کنید لزوماً همهٔ مجموعه‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه ایجاد‌شده داده‌های پیش‌فرض دارد؟**

بله. به‌طور پیش‌فرض، ‎[ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/)‎ مجموعه‌ها، دسته‌ها و مقادیر نمونه ایجاد می‌کند. می‌توانید آن سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعه و دسته‌ها را پاک کنید. یک overload نیز می‌تواند نمودار را بدون داده‌های پیش‌فرض ایجاد کند.

**شیوهٔ اتصال اشیای نمودار به سلول‌های کتاب‌کار چگونه است؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطه‑داده به سلول‌های یک ‎[ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/)‎ ارجاع می‌دهند. تغییر یک سلول مرجع‌دار، عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را هم‌راستا نگه‌دارید تا هر نقطه زیر دستهٔ موردنظر ترسیم شود.

**چگونه یک نقطه را به‌جای کل مجموعه پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان یک نقطهٔ خالی حفظ شود. ‎[ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/)‎ را فقط زمانی به‌کار ببرید که می‌خواهید تمام نقاط آن مجموعه حذف شوند، زیرا این متد تمام نقاط دادهٔ مجموعه را حذف می‌کند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه بستگی به نوع نمودار و مقداری که از طریق ‎[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/)‎ پیکربندی شده دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌عنوان فاصله، مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنای دادهٔ گمشده در ارائهٔ شما را بازتاب دهد. برای مثال کامل و مقایسهٔ بصری، بخش ‎[Control the Display of Empty Cells](#control-the-display-of-empty-cells)‎ را ببینید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های میله‌ای، ستونی و حبابی پشتیبانی‌شده، ‎[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/)‎ را فراخوانی کنید و رنگی که توسط ‎[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/)‎ برگردانده می‌شود، تنظیم کنید. می‌توانید این رفتار را برای یک نقطهٔ جداگانه با ‎[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/)‎ بازنویسی کنید. این متدها تنها قالب‌بندی را تحت‌اثر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**در صورتی که هم مجموعه و هم نقطه قالب‌بندی شوند، کدام‌یک برتر است؟**

قالب‌بندی صریح نقطه‑داده برای آن نقطه اولویت دارد. سایر نقاط همچنان از قالب‌بندی صریح مجموعه یا، در صورت عدم تعریف قالب‌بندی مجموعه، از سبک و تم خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند تداخل و عرض فاصله طرح‌بندی را کنترل می‌کنند و بازنویسی قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌هایی که یک نمودار می‌تواند داشته باشد وجود دارد؟**

Aspose.Slides محدودیتی ثابت برای تعداد مجموعه‌ها تعیین نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندر و قابلیت خواندن نمودار تعیین‌کنندهٔ حد وجنی هستند.

**چه کاری باید انجام داد وقتی ستون‌ها بیش از حد نزدیک یا دور از هم هستند؟**

بر روی گروه مجموعهٔ والد مناسب، ‎[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/)‎ را فراخوانی کنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها بیشتر شود یا کاهش دهید تا خوشه‌ها نزدیک‌تر شوند.