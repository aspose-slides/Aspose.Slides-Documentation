---
title: مدیریت کارنامه‌های نمودار در ارائه‌ها با استفاده از JavaScript
linktitle: کارنامه نمودار
type: docs
weight: 70
url: /fa/nodejs-java/chart-workbook/
keywords:
- کارنامه نمودار
- داده نمودار
- سلول کارنامه
- برچسب داده
- برگه کاری
- منبع داده
- کارنامه خارجی
- داده خارجی
- کش نمودار
- بازیابی کارنامه
- پاورپوینت
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides برای Node.js از طریق Java را کشف کنید: به‌راحتی کارنامه‌های نمودار را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **نمای کلی**

این مقاله نحوه کار با کارنامه‌های نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کارنامه بخوانید و بنویسید، از سلول‌های کارنامه به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های برگه‌ها دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را تعیین کنید.

همچنین کار با کارنامه‌های خارجی به‌عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کارنامه خارجی ایجاد و اختصاص دهید، مسیر یک کارنامه خارجی پیوند داده شده به نمودار را بازیابی کنید و داده‌های نمودار را زمانی که کارنامه در دسترس است ویرایش کنید.

برای سلول‌های کارنامه که داده‌های مفقودی را نشان می‌دهند، به [کنترل نمایش سلول‌های خالی](/slides/fa/nodejs-java/chart-series/) مراجعه کنید تا تفاوت بین سلول خالی و صفر و مقایسهٔ نمودار خطی حالت‌های نمایش موجود را ببینید.

## **شمول داده‌ها از سطرها و ستون‌های مخفی**

از [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) برای کنترل اینکه آیا یک نمودار فقط داده‌های سلول‌های مرئی برگه را ترسیم می‌کند یا نه استفاده کنید. مقدار `true` فقط سلول‌های مرئی را ترسیم می‌کند و مقدار `false` هر دو سلول مرئی و مخفی را شامل می‌شود. این تنظیم فقط ترسیم نمودار را کنترل می‌کند؛ سطرها یا ستون‌های برگه را مخفی یا نمایان نمی‌کند.

[ارائه نمونه](hidden-source-data.pptx) شامل یک نمودار ستونی به‌عنوان اولین شکل در اولین اسلاید است. برگهٔ جاسازی‌شده، `Sheet1`، دامنهٔ منبع `A1:C4` را دارد. سطر 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها هنوز مقدار دارند.

| سطر برگه | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (سطر مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

دسترسی به سلول‌های منبع از طریق [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) و خواندن [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) برای بررسی وضعیت مخفی بودن آن‌ها. این روش وضعیت مخفی را بدون تغییر آن گزارش می‌دهد. در این فایل، B2 مرئی است، B3 متعلق به سطر مخفی و C2 متعلق به ستون مخفی؛ مثال به ترتیب `false`، `true` و `true` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم ترسیم، داده‌های نمودار را تازه کنید: کارنامهٔ جاسازی‌شده را با [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) نگه داشته و با [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) دوباره بارگذاری کنید. هنگام شامل‌کردن همه سلول‌ها، از [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) نیز برای بازگرداندن دامنهٔ کامل، شامل دستهٔ مخفی فوریه، استفاده کنید؛ فقط تغییر پرچم کافی نیست تا داده‌های کش‌شدهٔ نمونهٔ این نمونه تجدید شود. مثال قبل از فراخوانی متد نوشتن، بافر Node.js را به آرایهٔ بایت جاوا تبدیل می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // داده‌های نمودار را از کارنامهٔ جاسازی‌شده تازه کنید.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // دامنهٔ منبع کامل را بازگردانید، شامل دسته‌های مخفی.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

مثال دو نسخهٔ ارائه را ذخیره می‌کند: یکی فقط مقادیر خرده‌فروشی مرئی (10 و 20) و دیگری تمام شش مقدار. تصاویر زیر دو حالت ترسیم را نشان می‌دهند. سطر 3 و ستون C در هر دو کارنامهٔ جاسازی‌شده مخفی می‌مانند.

| فقط سلول‌های مرئی (`true`) | همه سلول‌ها (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی که مقدار دارد متفاوت از یک سلول خالی است. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) کنترل می‌کند مقادیر مفقود چگونه نمایش داده شوند؛ این تنظیم شامل یا حذف دادهٔ منبع مخفی را انجام نمی‌دهد. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/nodejs-java/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **بازیابی دامنهٔ دادهٔ یک نمودار**

قبل از به‌روزرسانی داده‌های کارنامه در یک ارائهٔ موجود، دامنه‌های منبع را بررسی کنید تا بفهمید هر نمودار از کدام سلول‌های برگه استفاده می‌کند. متد [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) دامنهٔ دادهٔ فعلی را به‌صورت فرمولی با مشخصات برگه، مانند `Sheet1!$A$1:$D$5` برمی‌گرداند. در اینجا، `Sheet1` نام برگه است، `!` آن را از دامنهٔ سلول‌ها جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را شامل می‌شود. علامت دلار نشانگر مراجع مطلق سطر و ستون است.

این متد دامنهٔ فعلی را بدون تغییر نمودار یا کارنامه می‌خواند. اگر نمودار کارنامه‌ای به‌عنوان منبع داده نداشته باشد، `InvalidOperationException` پرتاب می‌کند. برای جزئیات بیشتر، به [مرجع API ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) مراجعه کنید.

این مثال ارائه‌ای را باز می‌کند و شکل‌های هر اسلاید را برای یافتن نمودارها بررسی می‌کند. نام هر نمودار و دامنهٔ منبع آن را چاپ می‌کند. اگر نموداری کارنامهٔ خارجی نداشته باشد، پیامی چاپ می‌کند و به نمودار بعدی می‌رود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **خواندن و نوشتن دادهٔ نمودار از کارنامه**

Aspose.Slides for Node.js via Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) و [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) را ارائه می‌دهد که امکان خواندن و نوشتن کارنامه‌های دادهٔ نمودار (شامل داده‌های ویرایش‌شده با Aspose.Cells) را می‌دهد. **توجه** داشته باشید که دادهٔ نمودار باید به همان شکل سازماندهی شده باشد یا ساختاری مشابه منبع داشته باشد.

این مثال ارائه‌ای با یک نمودار به‌عنوان اولین شکل در اولین اسلاید دارد. کارنامهٔ جاسازی‌شده را به آرایهٔ بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کارنامه را دوباره می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **اعتبارسنجی چیدمان نمودار پس از تغییر کارنامه**

هنگامی که کارنامهٔ جاسازی‌شده با یک کارنامهٔ اصلاح‌شده جایگزین می‌شود، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شکست [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) با خطای «index‑out‑of‑range» شود. قبل از نوشتن کارنامهٔ به‌روزشده، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نموداری استفاده می‌کند که اولین شکل در اولین اسلاید است. نظرات مکان‌هایی را نشان می‌دهند که در آن‌ها ویرایش کارنامه انجام می‌شود؛ مثال اجرایی کارنامهٔ اصلی را دوباره می‌نویسد و چیدمان را در حافظه اعتبارسنجی می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // در اینجا بایت‌های کارنامه را تغییر دهید، برای مثال با استفاده از Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

پاک‌سازی مجموعه‌ها قبل از نوشتن کارنامه، ارجاعات دادهٔ منسوخ را حذف می‌کند. پیش از استفاده از نمودار، هر سری و نگاشت دستهٔ مورد نیاز برای کارنامهٔ به‌روزشده را بازسازی کنید.

## **تنظیم قالب عددی سفارشی برای سلول‌های کارنامه**

از [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) برای کنترل نحوه نمایش مقادیر عددی در کارنامهٔ جاسازی‌شدهٔ نمودار استفاده کنید. به‌عنوان مثال، ممکن است گزارش به نرخ تبدیل به‌صورت درصد با چهار رقم اعشار و ضریب با پنج رقم اعشار نیاز داشته باشد. هر دو مقدار را عددی نگه دارید تا برای محاسبات و ترسیم نمودار در دسترس باشند.

قالب عددی فقط نمایش را تغییر می‌دهد، نه مقدار ذخیره‌شده. قالب `0.0000%` مقدار `0.125` را به‌صورت `12.5000%` نمایش می‌دهد؛ عدد ذخیره‌شده به `12.5` تبدیل نمی‌شود. به‌ همین ترتیب، `0.00000` عدد `0.1234567` را به‌صورت `0.12346` نشان می‌دهد بدون این‌که مقدار ذخیره‌شده را گرد کند. اگر قالب سفارشی یک رشتهٔ خالی (`""`) باشد، قالبی که توسط [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) برگردانده می‌شود استفاده می‌شود.

مثال زیر یک نمودار ستونی ایجاد می‌کند و سلول‌های آن را از طریق [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) دسترسی می‌یابد. در برگهٔ 0، B2 حاوی نرخ تبدیل و C2 حاوی ضریب است. هر دو سلول مقادیر نمودار را فراهم می‌کنند. مثال همچنین برچسب‌های مقداری را که به قالب‌های منبع مرتبط هستند فعال می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

قالب‌های سلول کارنامه جدا از قالب‌های تنظیم‌شده مستقیم بر محورهای نمودار یا برچسب‌های داده‌اند. در این مثال، هر برچسب مقدار سلول منبع خود را نشان می‌دهد چون [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) برابر `true` است و به دلیل تنظیم [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) برابر `true`، قالب عددی منبع را دنبال می‌کند. پس از ذخیره و بازگشای ارائه، برچسب‌ها `12.5000%` و `0.12346` را نمایش می‌دهند، همان‌طور که در زیر نشان داده شده است. محور عمودی قالب عددی خود را دارد؛ با [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) به `0.00` تنظیم شده و [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) برابر `false` است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم پیوند به منبع آن را به `false` تنظیم کنید و با [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) قالبی اختصاص دهید. این کار قالب سلول کارنامه را تغییر نمی‌دهد. به‌عنوان مثال، قالب مستقل `0.00` اولین مقدار را به `0.13` نمایش می‌دهد، در حالی که B2 هنوز `12.5000%` را نشان می‌دهد. برای قالب‌بندی مستقیم برچسب‌ها به [برچسب‌های دادهٔ نمودار](/slides/fa/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) مراجعه کنید.

تصویر زیر پس از بازگشایی ارائهٔ ذخیره‌شده رندر شده است:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **تنظیم یک سلول کارنامه به‌عنوان برچسب دادهٔ نمودار**

می‌توانید متن سلول‌های کارنامه را به عنوان برچسب دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با دادهٔ پیش‌فرض به اولین اسلاید یک ارائهٔ موجود اضافه می‌کند. از سلول‌های A10:A12 در برگهٔ 0 برای اولین سه برچسب در سری اول استفاده می‌کند، برچسب‌ها از سلول‌ها را فعال می‌سازد و ارائهٔ به‌روزشده را ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مدیریت برگه‌ها**

متد [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) دسترسی به برگه‌های کارنامهٔ نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض می‌سازد و نام هر برگه را در کنسول چاپ می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **مشخص کردن نوع منبع داده**

مقادیر نقاط سری می‌توانند مستقیماً به صورت Literals عددی ذخیره شوند. برای مثال کامل به [تنظیم مقادیر سری با Literals عددی](/slides/fa/nodejs-java/chart-series/#set-series-values-using-numeric-literals) مراجعه کنید. نوع منبع مقادیر نقطه‌ای جدا از پیکربندی کارنامهٔ داخلی یا خارجی نمودار است؛ استفاده از Literals عددی به‌تنهایی کارنامهٔ جاسازی‌شده را حذف نمی‌کند.

این مثال یک نمودار ستونی 3D با دادهٔ پیش‌فرض می‌سازد و دو نام سری را با منابع داده متفاوت تنظیم می‌کند. نام اول از یک Literal رشته‌ای استفاده می‌کند؛ نام دوم از سلول C1 در برگهٔ 0 استفاده می‌کند. شمارش [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روزشده ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تشخیص قالب‌های کارنامهٔ جاسازی‌شدهٔ پشتیبانی‌نشده**

Aspose.Slides قالب کارنامهٔ باینری Excel (.xlsb) را که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید با متد `getEmbeddedWorkbookType` روی [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) قالب‌های پشتیبانی‌نشده را شناسایی و از آن نمودارها عبور کنید. این مثال شکل‌های اولین اسلاید یک ارائهٔ موجود را بررسی می‌کند، شکل‌های غیرنموداری را عبور می‌دهد و برای هر نمودار دارای کارنامهٔ .xlsb یک پیام تشخيصی چاپ می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // خواندن یا تغییر داده‌های کارنامهٔ پشتیبانی‌شدهٔ نمودار در اینجا.
    }
} finally {
    presentation.dispose();
}
```

## **کارنامهٔ خارجی**

Aspose.Slides از استفاده از کارنامه‌های خارجی به‌عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کارنامهٔ خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) و [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) برای استخراج یک کارنامهٔ نمودار جاسازی‌شده به یک فایل و پیوند نمودار به آن کارنامهٔ خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض می‌سازد و کارنامهٔ آن را صادر می‌کند. پس از تکمیل نوشتن فایل، کارنامهٔ خارجی را به‌عنوان منبع دادهٔ نمودار اختصاص داده و ارائهٔ پیوندشده را ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **تنظیم یک کارنامهٔ خارجی**

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) می‌توانید یک کارنامهٔ خارجی را به‌عنوان منبع دادهٔ نمودار اختصاص دهید. این روش همچنین می‌تواند برای به‌روزرسانی مسیر کارنامهٔ خارجی (اگر منتقل شده باشد) استفاده شود.

اگرچه نمی‌توانید داده را در کارنامه‌های ذخیره‌شده در مکان‌های دوردست یا منابع ویرایش کنید، همچنان می‌توانید از چنین کارنامه‌هایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کارنامهٔ خارجی داده شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کارنامهٔ خارجی استفاده می‌کند که برگهٔ آن با نام `Sheet1` شامل نام سری در B1، نام دسته‌ها در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای می‌سازد، کارنامه را پیوند می‌دهد و با [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) A1:B4 را به یک سری و سه دسته نگاشت می‌کند. ارائه با نمودار پیوندشده ذخیره می‌شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پارامتر `updateChartData` متد [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) کنترل می‌کند آیا کارنامه بارگذاری شود یا نه.

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر کارنامه به‌روزرسانی می‌شود. دادهٔ نمودار از کارنامه هدف بارگذاری یا به‌روزرسانی نمی‌شود، بنابراین کارنامه می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `true` باشد، دادهٔ نمودار از کارنامه هدف به‌روزرسانی می‌شود.

مثال زیر یک URL جایگزین با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای را حفظ می‌کند و ارائه را بدون بارگذاری کارنامهٔ در دسترس نیست ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **دریافت مسیر کارنامهٔ منبع دادهٔ خارجی یک نمودار**

برای تعیین کارنامهٔ پیوند داده شده به یک نمودار، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کارنامهٔ آن را بازیابی کنید.

این مثال اولین شکل در اولین اسلاید یک ارائهٔ دارای کارنامهٔ خارجی پیوندشده را بررسی می‌کند. اگر شکل یک نمودار پیوند به کارنامهٔ خارجی باشد، [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه را ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ویرایش دادهٔ نمودار**

می‌توانید داده‌های کارنامه‌های خارجی را همان‌طور که داده‌های کارنامه‌های داخلی را ویرایش می‌کنید، تغییر دهید. وقتی کارنامهٔ خارجی قابل بارگذاری نباشد، استثنا پرتاب می‌شود.

این مثال از یک نمودار که اولین شکل در اولین اسلاید است و به یک کارنامهٔ خارجی قابل دسترس پیوند دارد استفاده می‌کند. مقدار نقطهٔ دادهٔ اول در سری اول را به 100 تنظیم می‌کند و ارائهٔ به‌روزشده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوندشده را به‌روزرسانی کند، بنابراین در صورت نیاز به حفظ کارنامهٔ اصلی، از یک کپی استفاده کنید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **بازیابی کارنامه از کش نمودار**

اگر یک نمودار از کارنامهٔ خارجی که گم شده یا در دسترس نیست استفاده می‌کند، Aspose.Slides می‌تواند کارنامهٔ نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، یک [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) ایجاد کنید، [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/) را فراخوانی کنید و [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) را به `true` تنظیم کنید.

مثال JavaScript زیر کارنامهٔ داده را برای یک نمودار که اولین شکل در اولین اسلاید است و به یک کارنامهٔ خارجی در دسترس نیست، بازیابی می‌کند. داده‌های بازیابی‌شده را از طریق [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) و [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) دسترسی می‌یابد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // در اینجا داده‌های کارنامه بازیابی‌شده را بخوانید یا تغییر دهید.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

اگر کارنامهٔ خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنا پرتاب می‌کند. فقط در زمانی که استفاده از داده‌های کش‌شدهٔ نمودار گزینهٔ قابل قبول است، بازیابی را فعال کنید، زیرا کش ممکن است شامل تغییرات ایجادشده در کارنامهٔ خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **پرسش‌های متداول**

**آیا می‌توانم تعیین کنم آیا یک نمودار خاص به یک کارنامهٔ خارجی یا جاسازی‌شده پیوند دارد؟**

بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) و [مسیر به کارنامهٔ خارجی](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) است؛ اگر منبع یک کارنامهٔ خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کارنامه‌های خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی تعیین کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کارنامه ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کارنامه‌های قرارگیری در منابع/به‌اشتراک‌گذاری‌های شبکه استفاده کنم؟**

بله، چنین کارنامه‌هایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کارنامه‌های دوردست از Aspose.Slides پشتیبانی نمی‌شود؛ فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [پیوند به فایل خارجی](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) را ذخیره می‌کند. ویرایش داده‌های نمودار مبتنی بر سلول می‌تواند فایل XLSX محلی پیوندشده را نیز به‌روزرسانی کند. اگر فایل اصلی باید بدون تغییر بماند، از یک کپی کارنامه استفاده کنید.

**اگر فایل خارجی با رمزعبور محافظت شده باشد، چه باید کرد؟**

Aspose.Slides هنگام پیوند گذرواژه‌ای نمی‌پذیرد. یک روش رایج حذف محافظت از قبل یا تهیه یک کپی رمزگشایی‌شده (به عنوان مثال با [Aspose.Cells](https://reference.aspose.com/cells/java/)) و پیوند به آن کپی است.

**آیا می‌توان چندین نمودار را به یک کارنامهٔ خارجی ارجاع داد؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر نمودار در بارگذاری بعدی داده‌ها منعکس می‌شود.