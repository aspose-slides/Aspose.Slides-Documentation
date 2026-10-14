---
title: سفارشی‌سازی نمودارهای دایره‌ای در ارائه‌ها با استفاده از JavaScript
linktitle: نمودار دایره‌ای
type: docs
url: /fa/nodejs-java/pie-chart/
keywords:
- نمودار دایره‌ای
- مدیریت نمودار
- سفارشی‌سازی نمودار
- گزینه‌های نمودار
- تنظیمات نمودار
- گزینه‌های ترسیم
- رنگ برش
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی نمودارهای دایره‌ای در JavaScript با Aspose.Slides برای Node.js از طریق Java. تنظیم نمودارهای ثانویه، نمایش برچسب‌های داده، و اعمال رنگ‌های خودکار برش در PowerPoint."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با نمودارهای دایره‌ای در Aspose.Slides کار کنید. نشان می‌دهد چگونه گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie را پیکربندی کنید و چگونه رنگ‌گذاری خودکار برش‌ها را برای یک نمودار دایره‌ای استاندارد فعال کنید.

مثال‌ها بر روی وظایف سفارشی‌سازی نمودار متمرکز هستند، مانند افزودن یک نمودار به اسلاید، تنظیم تنظیمات سری و برچسب، جایگزینی داده‌های پیش‌فرض نمودار با دسته‌ها و مقادیر سفارشی، و ذخیره ارائه به‌روز شده.

## **گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie**

Aspose.Slides for Node.js via Java از گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie پشتیبانی می‌کند. این گزینه‌ها اندازه نمودار ثانویه و چگونگی تقسیم نقاط داده بین دو نمودار را کنترل می‌کنند.

مثال زیر یک نمودار Pie of Pie در یک ارائه جدید ایجاد می‌کند و مقادیر نقاط داده را به‌عنوان برچسب نمایش می‌دهد. متد [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) اندازه نمودار ثانویه را به 149٪ از نمودار اصلی تنظیم می‌کند. [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) تقسیم بر مبنای درصد را انتخاب می‌کند و [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) آستانه را به 53٪ تنظیم می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // مقادیر را نمایش داده و نمودار ثانویه را پیکربندی کنید.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **انتخاب دسته‌ها برای نمودار ثانویه**

از تقسیم سفارشی زمانی استفاده کنید که بخواهید دسته‌های خاصی را در نمودار ثانویه گروه‌بندی کنید بدون توجه به مقادیر درصدی آن‌ها. برای مثال، یک گزارش فروش ممکن است Online و Events را با هم نشان دهد تا خوانندگان بتوانند این دو کانال را مقایسه کنند، حتی اگر هر کدام 35٪ و 10٪ از کل فروش را تشکیل دهند.

متد [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) را با [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) فراخوانی کنید و نقاط را از طریق [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) انتخاب کنید. متد [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) مجموعه یک شاخص صفر‑محور در سری می‌پذیرد؛ برای افزودن شیء نقطه داده از [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) استفاده کنید. در این مثال، شاخص 1 Online را انتخاب می‌کند و نقطه در شاخص 3 Events را انتخاب می‌کند. Partners نیز به‌طور موقت افزوده می‌شود، سپس با استفاده از [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem) حذف می‌شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // داده‌های پیش‌فرض را با فروش بر حسب کانال جایگزین کنید.
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Online را با استفاده از شاخص صفر-محور و Events را با شیء نقطه داده انتخاب کنید.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Partners را از انتخاب حذف کنید بدون اینکه داده منبع آن را حذف کنید.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) و Events (10) به‌عنوان برش‌های جداگانه در نمودار ثانویه ظاهر می‌شوند. در نمودار اصلی، آن‌ها توسط یک برش ترکیبی با مقدار 45، به‌همراه Retail (40) و Partners (15) نشان داده می‌شوند. حذف Partners از انتخاب سفارشی باعث می‌شود در نمودار اصلی باقی بماند؛ این حذف دسته یا مقدار آن را از داده‌های منبع نمودار حذف نمی‌کند.

تصویر زیر ارائه ذخیره‌شده را در PowerPoint نشان می‌دهد:

![نمودار Pie of Pie با Online و Events در نمودار ثانویه و مقدار ترکیبی 45 آن‌ها در نمودار اصلی](pie_of_pie_custom.png)

## **تنظیم رنگ خودکار برش‌های نمودار دایره‌ای**

Aspose.Slides for Node.js via Java می‌تواند به‌صورت خودکار رنگ‌های متفاوتی به برش‌های نمودار دایره‌ای اختصاص دهد. مثال زیر یک نمودار دایره‌ای با عنوان مرکزیت‌یافته ایجاد می‌کند و داده‌های پیش‌فرض را با سه دسته فصلی و مقادیرشان جایگزین می‌کند. متد [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) مقادیر 20، 50 و 30 را به‌عنوان برچسب نشان می‌دهد، در حالی که [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) رنگ متمایزی برای هر برش فعال می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // افزودن عنوان مرکزی به نمودار.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // جایگزین کردن داده‌های پیش‌فرض با استفاده از اولین برگه کاری.
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // مقادیر را نشان دهید و رنگ‌های متفاوتی به برش‌ها اختصاص دهید.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سؤالات متداول**

**آیا انواع Pie of Pie و Bar of Pie پشتیبانی می‌شوند؟**

بله، کتابخانه [supports](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) یک نمودار ثانویه برای نمودارهای دایره‌ای، شامل انواع Pie of Pie و Bar of Pie را دارد.

**آیا می‌توانم فقط نمودار را به‌صورت تصویر (مثلاً PNG) استخراج کنم؟**

بله، می‌توانید [export the chart itself as an image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (مانند PNG) را بدون استخراج کل ارائه انجام دهید.