---
title: مدیریت برچسب‌های داده نمودار در ارائه‌ها با استفاده از JavaScript
linktitle: برچسب داده
type: docs
url: /fa/nodejs-java/chart-data-label/
keywords:
- نمودار
- برچسب داده
- دقت داده
- درصد
- فاصله برچسب
- محل برچسب
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌های داده نمودار را در ارائه‌های PowerPoint با استفاده از JavaScript و Aspose.Slides برای Node.js از طریق Java اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **مقدمه**

برچسب‌های داده اطلاعاتی دربارهٔ سری‌های نمودار و نقاط دادهٔ تک‌تک نمایش می‌دهند و به خوانندگان کمک می‌کنند تا مقادیر را شناسایی و نمودار را درک کنند. این مقاله توضیح می‌دهد چگونه مقادیر را قالب‌بندی کنید، درصدها را نمایش دهید، متن برچسب را بخوانید، برچسب‌ها را فراتر از حداکثر محور کنترل کنید، فاصلهٔ برچسب محور دسته‌بندی را تنظیم کنید و موقعیت برچسب‌های نمودار دایره‌ای را تعیین کنید.

## **تنظیم دقت داده در برچسب‌های داده نمودار**

از [setNumberFormatOfValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) برای قالب‌بندی مقادیر سری استفاده کنید. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند، جدول دادهٔ آن را نمایش می‌دهد و برچسب‌های مقدار را برای سری اول فعال می‌سازد. قالب `#,##0.00` جداکنندهٔ هزارگان و دو رقم اعشار را بدون تغییر مقادیر اصلی نشان می‌دهد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    const series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **نمایش درصد به‌عنوان برچسب‌ها**

برای یک نمودار ستونی انباشته، هر مقدار را به عنوان درصدی از مجموع دستهٔ خود محاسبه کنید و متن را به قاب متن بازگردانده‌شده توسط [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) اختصاص دهید. این مثال از داده‌های پیش‌فرض نمودار استفاده می‌کند و درصدها را با دو رقم اعشار در قلم 8 نقاط نمایش می‌دهد. دسته‌هایی که مجموع آن‌ها صفر است برای جلوگیری از تقسیم بر صفر نادیده گرفته می‌شوند. اگر داده‌های نمودار تغییر کرد، متن سفارشی برچسب را مجدداً محاسبه کنید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);

    const categoryTotals = new Array(chart.getChartData().getCategories().size()).fill(0);
    for (let k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
            const series = chart.getChartData().getSeries().get_Item(i);
            const pointValue = series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += Number(pointValue);
        }
    }

    for (let x = 0; x < chart.getChartData().getSeries().size(); x++) {
        const series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            const pointValue = series.getDataPoints().get_Item(j).getValue().getData();
            const dataPointPercent = (Number(pointValue) / categoryTotals[j]) * 100;

            const portion = new aspose.slides.Portion();
            portion.setText(dataPointPercent.toFixed(2) + " %");
            portion.getPortionFormat().setFontHeight(8);

            label.getTextFrameForOverriding().setText("");
            const paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم علامت درصد با برچسب‌های داده نمودار**

وقتی مقادیر به صورت کسری ذخیره می‌شوند، از [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) برای نمایش درصدها استفاده کنید. برای اعمال قالب برچسب به‌طور مستقل از سلول‌های منبع، `false` را به [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) پاس دهید.

این مثال یک نمودار ستونی 100٪ انباشته با سری‌های قرمز و آبی در چهار دسته ایجاد می‌کند. هر جفت مقدار مجموعاً برابر 1 است. قالب برچسب `0.0%` مقدار 0.30 را به‌صورت 30.0٪ نشان می‌دهد، در حالی که محور عمودی از دو رقم اعشار استفاده می‌کند. هر دو سری از متن برچسب سفید، 10 نقطه‌ای استفاده می‌کنند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    for (let i = 0; i < 4; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    const seriesNames = ["Reds", "Blues"];
    const white = java.getStaticFieldValue("java.awt.Color", "WHITE");
    const seriesColors = [java.getStaticFieldValue("java.awt.Color", "RED"), java.getStaticFieldValue("java.awt.Color", "BLUE")];
    const values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]];

    for (let i = 0; i < seriesNames.length; i++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (let j = 0; j < 4; j++) {
            const valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        const labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(white);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **خواندن متن واقعی برچسب‌های داده**

از [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) برای بازیابی متنی که توسط تنظیمات برچسب داده تولید شده استفاده کنید. این کار هنگام استخراج برچسب‌ها برای گزارش‌ها، جستجو در محتوای ارائه یا اعتبارسنجی نمودارهای تولید شده مفید است. در مثال زیر، قالب پیش‌فرض [قالب برچسب داده](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/) هر نام دسته، نام سری و مقدار را ترکیب می‌کند. یک نقطه مقدار خود را به‌عنوان درصد قالب‌بندی می‌کند و دیگری از متن سفارشی بازگردانده‌شده توسط [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) استفاده می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    const secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    const northSeriesCell = workbook.getCell(0, 0, 1, "North");
    const north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    const northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    const northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    const southSeriesCell = workbook.getCell(0, 0, 2, "South");
    const south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    const southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    const southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        const format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const point = series.getDataPoints().get_Item(j);
            const label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            console.log("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

عدد ذخیره‌شده در یک نقطه داده همچنان `0.75` می‌ماند، حتی وقتی برچسب آن `75%` همراه با نام‌های دسته و سری نمایش می‌دهد. متن سفارشی متن برچسب تولید شده را جایگزین می‌کند. [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) در هر دو حالت رشتهٔ برچسب نهایی را برمی‌گرداند. به‌طور جداگانه [isVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/isvisible/) را بررسی کنید، همان‌طور که در بالا نشان داده شد، زمانی که فقط برچسب‌های قابل مشاهده را می‌خواهید استخراج کنید.

## **کنترل برچسب‌های داده فراتر از حداکثر محور**

هنگامی که بازهٔ محور را به‌صورت دستی محدود می‌کنید، ممکن است برخی نقاط داده بیش از حداکثر آن باشند. از [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) برای کنترل نمایش برچسب‌های آن‌ها استفاده کنید. این تنظیم فقط دیداری برچسب را تغییر می‌دهد؛ بازهٔ محور یا مقادیر دادهٔ زمینه‌ای را تغییر نمی‌دهد.

مثال زیر یک نمودار ستونی خوشه‌ای 2D با مقادیر 60 و 120 ایجاد می‌کند. `false` را به [setAutomaticMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) پاس می‌دهد و حداکثر را با [setMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmaxvalue/) بر محور عمودی به 100 تنظیم می‌کند. اسلاید اول اجازه نمایش برچسب‌ها فراتر از حداکثر را می‌دهد؛ یک کپی از آن اسلاید این ویژگی را غیرفعال می‌کند. هر دو اسلاید در `DataLabelsOverMaximum.pptx` ذخیره می‌شوند.

با [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) برچسب‌های مقدار را فعال کنید. این تنظیم در سطح نمودار به‌تنهایی نمایش مقدار را فعال نمی‌کند و برچسب‌های منفردی که نمایش مقدارشان غیرفعال شده است را نیز نادیده نمی‌گیرد. این مثال مقادیر را برای تمام سری‌ها فعال می‌کند و با [setPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setposition/) برچسب‌ها را در انتهای بیرونی هر ستون قرار می‌دهد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();

    const firstCategory = workbook.getCell(0, 1, 0, "Within range");
    const secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    const seriesName = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    const firstValue = workbook.getCell(0, 1, 1, 60);
    const secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    const secondSlide = presentation.getSlides().addClone(slide);
    const secondChart = secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تصاویر زیر اسلایدهای ذخیره‌شده را که توسط Microsoft PowerPoint رندر شده‌اند نشان می‌دهند. با مقدار `true`، برچسب **120** در مرز بالایی قابل مشاهده است؛ با مقدار `false`، مخفی می‌شود. برچسب **60** همچنان قابل مشاهده است، حداکثر محور در **100** باقی می‌ماند و نقطه دادهٔ دوم در هر دو حالت **120** است.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![نمودار PowerPoint نشان‌دهندهٔ برچسب مقدار 120 با حداکثر محور 100](data-labels-over-maximum-true.png) | ![نمودار PowerPoint مخفی‌کنندهٔ برچسب مقدار 120 با حداکثر محور 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
این مثال از یک نمودار ستونی 2D با محور مقدار استفاده می‌کند. نمودارهایی که محور مقدار ندارند، مانند نمودارهای دایره‌ای و دونات، حداکثر محور برای محدود کردن به این شکل ندارند.
{{% /alert %}}

## **تنظیم فاصله برچسب از محور**

از [setLabelOffset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlabeloffset/) برای کنترل فاصله بین برچسب‌های محور دسته‌بندی و خود محور استفاده کنید. مقدار بر حسب درصد حداکثر اندازهٔ قلم برچسب‌های محور است. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و فاصلهٔ برچسب محور افقی را به 500 تنظیم می‌کند. این تنظیم برچسب‌های محور دسته‌بندی را تحت‌تأثیر قرار می‌دهد نه برچسب‌های متصل به نقاط دادهٔ تک‌تک.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم محل برچسب**

در یک نمودار دایره‌ای، موقعیت برچسب‌های داده را برای بهبود فواصل و ایجاد فضای کافی برای خطوط راهنما تنظیم کنید.

این مثال مقدار اولین نقطه داده را نمایش می‌دهد، برچسب آن را بیرون قطعه قرار می‌دهد و با استفاده از [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) و [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) جابه‌جایی افقی و عمودی آن را تنظیم می‌کند. این جابه‌جایی‌ها به‌ترتیب نسبت به عرض و ارتفاع نمودار هستند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    const series = chart.getChartData().getSeries();

    const label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(java.newFloat(0.71));
    label.setY(java.newFloat(0.04));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![نمودار دایره‌ای با موقعیت برچسب داده تنظیم‌شده](pie-chart-adjusted-label.png)

## **قالب‌بندی خطوط راهنما**

زمانی که برچسب‌های نمودار دایره‌ای خارج از قطعات خود قرار می‌گیرند، خطوط راهنما به خواننده کمک می‌کند تا هر مقدار را به قطعهٔ صحیح متصل کند. یک رنگ متضاد و خط کمی ضخیم می‌تواند این ارتباط را قابل‌دنبال‌تر کند، در حالی که شفافیت و سبک خط‌چین خطوط را از نظر بصری کمتر مزاحم می‌سازد.

از [getLeaderLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelcollection/getleaderlinesformat/) برای قالب‌بندی خطوط راهنما در سطح مجموعهٔ برچسب‌های دادهٔ سری استفاده کنید. تنظیمات در `series.getLabels().getLeaderLinesFormat().getLine()` به کل مجموعه اعمال می‌شود، نه به‌صورت تک‌تک برچسب.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند، مقادیر را بیرون قطعات نمایش می‌دهد و با [setShowLeaderLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowleaderlines/) خطوط راهنما را فعال می‌کند. دو برچسب با استفاده از جابه‌جایی‌های [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) و [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) دورتر از قطعاتشان قرار می‌گیرند؛ این جابه‌جایی‌ها به‌صورت کسری از عرض و ارتفاع نمودار بیان می‌شوند. هیچ ارائهٔ ورودی مورد نیاز نیست.

متد [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) خط را با رنگ آبی ثابت و مقدار آلفای 191 از 255 تنظیم می‌کند که تقریباً 25٪ شفافیت می‌دهد. [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/) ضخامت را به 2 نقطه تنظیم می‌کند و [setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setdashstyle/) خط را خط‌چین می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 80, 50, 560, 400);
    chart.setLegend(false);

    const series = chart.getChartData().getSeries().get_Item(0);

    const labelFormat = series.getLabels().getDefaultDataLabelFormat();
    labelFormat.setShowValue(true);
    labelFormat.setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    labelFormat.setShowLeaderLines(true);

    // دو برچسب را از قطعاتشان دورتر ببرید.
    series.getLabels().get_Item(0).setX(java.newFloat(0.10));
    series.getLabels().get_Item(0).setY(java.newFloat(-0.05));
    series.getLabels().get_Item(1).setX(java.newFloat(-0.10));
    series.getLabels().get_Item(1).setY(java.newFloat(0.05));

    const line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 30, 90, 160, 191);
    line.getFillFormat().getSolidFillColor().setColor(lineColor);
    line.setWidth(2);
    line.setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    presentation.save("FormattedLeaderLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

فعال‌سازی خطوط راهنما تضمین نمی‌کند که برای هر برچسب یک خط ظاهر شود. قابلیت مشاهده بستگی به مکان‌گذاری برچسب و رفتار چیدمان نمودار دارد. در این مثال، دو برچسب جابجا شده خطوط راهنمای قابل رؤیتی دارند؛ برچسب‌هایی که نزدیک به قطعات خود می‌مانند نیازی به آن ندارند.

تصویر زیر `FormattedLeaderLines.pptx` ذخیره‌شده را که با Aspose.Slides رندر شده نشان می‌دهد:

![نمودار دایره‌ای با خطوط راهنمای آبی، نیمه‌شفاف، خط‌چین که دو برچسب بیرونی را به قطعاتشان متصل می‌کند](formatted-leader-lines.png)

## **افزودن چند ردیف برچسب داده بالای نمودار ستونی**

این مثال یک نمودار ستونی با دو ردیف برچسب داده بالای ناحیهٔ ترسیم ایجاد می‌کند. سری A ستون‌های قابل مشاهده را نمایش می‌دهد، در حالی که سری‌های B و C برچسب‌های اضافی را فراهم می‌کنند. ستون‌های آن‌ها با حذف پرشدن و خط بیرونی مخفی می‌شوند. متد [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) همهٔ سه سری را با همان مرکزهای دسته هم‌تراز می‌کند.

تنظیمات [ChartPlotArea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartplotarea/) فضای لازم برای ردیف‌های برچسب را رزرو می‌کند. پس از اینکه [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) موقعیت‌های پیش‌فرض را محاسبه کرد، [DataLabel.setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) و [DataLabel.setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) هم‌ترازی افقی را حفظ کرده و جابه‌جایی‌های عمودی را اعمال می‌کنند تا برچسب‌ها در دو ردیف چینند. اعداد همچنان برچسب‌های دادهٔ مرتبط با مقادیر سری هستند؛ فقط عناوین ردیف به‌صورت اشکال متنی جداگانه‌اند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categories = ["North", "South", "East", "West"];
    const seriesNames = ["Series A", "Series B", "Series C"];
    const seriesValues = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]];

    for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        const categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        const seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        const series = chart.getChartData().getSeries().add(seriesCell, aspose.slides.ChartType.ClusteredColumn);

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // ستون‌های B و C را مخفی کنید، اما برچسب‌های داده آنها را نگه دارید.
            series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            const labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
            labelFill.getSolidFillColor().setColor(black);
            series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.InsideBase);
        }
    }

    // تمام سه سری را با همان مرکزهای دسته هم‌تراز کنید.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(java.newByte(100));

    // برای این مثال فشرده خطوط شبکه کمتری استفاده کنید.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // فضای بالای ناحیه رسم را برای دو ردیف برچسب داده رزرو کنید.
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    chart.getPlotArea().setX(java.newFloat(0.15));
    chart.getPlotArea().setY(java.newFloat(0.32));
    chart.getPlotArea().setWidth(java.newFloat(0.80));
    chart.getPlotArea().setHeight(java.newFloat(0.48));
    chart.validateChartLayout();

    for (let seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const rowTop = seriesIndex == 1 ? 0.15 : 0.03;

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // موقعیت افقی پیش‌فرض را حفظ کنید. Y یک جابجایی است از
            // موقعیت پیش‌فرض برچسب، بیان‌شده به‌صورت کسری از ارتفاع نمودار.
            dataLabel.setX(0);
            dataLabel.setY(java.newFloat(rowTop - dataLabel.getActualY() / chart.getHeight()));
        }

        // فقط عنوان ردیف یک شکل متنی جداگانه است.
        const rowHeading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        const headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        headingFormat.getFillFormat().getSolidFillColor().setColor(black);
    }

    presentation.save("multiple-rows-of-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![نمودار ستونی با دو ردیف برچسب داده بالای ناحیهٔ ترسیم](multiple-rows-of-labels.png)

## **پرسش‌های متداول**

**چگونه می‌توان از overlapping برچسب‌های داده در نمودارهای پر تراکم جلوگیری کرد؟**

از قرارگیری خودکار برچسب‌ها، خطوط راهنما و کاهش اندازهٔ قلم استفاده کنید؛ در صورت لزوم، برخی فیلدها (مثلاً دسته) را مخفی کنید یا فقط برچسب‌های مقادیر حاشیه‌ای یا نقاط کلیدی را نشان دهید.

**چگونه می‌توان برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کرد؟**

قبل از فعال‌سازی برچسب‌ها نقاط داده را فیلتر کنید و نمایش مقادیر 0، مقادیر منفی یا مقادیر گمشده را طبق قاعدهٔ تعریف‌شده خاموش کنید.

**چگونه می‌توان سبک برچسب را به‌صورت یکدست هنگام خروجی به PDF/تصاویر تضمین کرد؟**

قلم خانواده و اندازه را به‌صورت صریح تنظیم کنید و اطمینان حاصل کنید قلم موردنظر در محیط رندر موجود است تا از استفاده از قلم پیش‌فرض جلوگیری شود.