---
title: مدیریت برچسب‌های داده نمودار در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: برچسب داده
type: docs
url: /fa/nodejs-java/chart-data-label/
keywords:
- نمودار
- برچسب داده
- دقت داده
- درصد
- فاصله برچسب
- موقعیت برچسب
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌های داده نمودار را در ارائه‌های PowerPoint با استفاده از جاوااسکریپت و Aspose.Slides برای Node.js از طریق جاوا اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **مقدمه**

برچسب‌های داده اطلاعاتی دربارهٔ مجموعه‌های نمودار و نقاط دادهٔ فردی نمایش می‌دهند و به خوانندگان کمک می‌کنند تا مقادیر را شناسایی و نمودار را درک کنند. این مقاله نحوهٔ قالب‌بندی مقادیر، نمایش درصدها، خواندن متن برچسب، کنترل برچسب‌ها فراتر از حداکثر محور، تنظیم فاصلهٔ برچسب‌های محور دسته و موقعیت‌گذاری برچسب‌های نمودار دایره‌ای را توضیح می‌دهد.

## **تنظیم دقت عددی در برچسب‌های دادهٔ نمودار**

از [setNumberFormatOfValues](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) برای قالب‌بندی مقادیر مجموعه استفاده کنید. این مثال یک نمودار خطی با دادهٔ پیش‌فرض ایجاد می‌کند، جدول دادهٔ آن را نمایش می‌دهد و برچسب‌های مقدار را برای اولین مجموعه فعال می‌کند. قالب `#,##0.00` جداکنندهٔ هزارگان و دو رقم اعشار را بدون تغییر مقدارهای پایه نمایش می‌دهد.

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

## **نمایش درصد به‌عنوان برچسب**

برای نمودار ستونی انباشته، هر مقدار را به‌عنوان درصدی از مجموع دستهٔ خود محاسبه کنید و متن را به قاب متنی که توسط [getTextFrameForOverriding](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) برگردانده می‌شود، اختصاص دهید. این مثال از دادهٔ پیش‌فرض نمودار استفاده می‌کند و درصدها را با دو رقم اعشار در فونت 8 پوینت نمایش می‌دهد. دسته‌هایی که مجموعشان صفر است برای جلوگیری از تقسیم بر صفر نادیده گرفته می‌شوند. اگر دادهٔ نمودار تغییر کند متن سفارشی برچسب را مجدداً محاسبه کنید.

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

## **تنظیم علامت درصد با برچسب‌های دادهٔ نمودار**

زمانی که مقادیر به‌صورت کسر ذخیره می‌شوند، از [setNumberFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) برای نمایش درصدها استفاده کنید. برای اعمال قالب برچسب مستقل از سلول‌های منبع، `false` را به [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) پاس بدهید.

این مثال یک نمودار ستونی 100٪ انباشته با مجموعه‌های قرمز و آبی در چهار دسته ایجاد می‌کند. هر جفت مقدار به‌هم می‌رسد تا 1 شود. قالب برچسب `0.0%` مقدار 0.30 را به‌صورت 30.0٪ نمایش می‌دهد، در حالی که محور عمودی از دو رقم اعشار استفاده می‌کند. هر دو مجموعه متن برچسب سفید با اندازهٔ 10 پوینت استفاده می‌کنند.

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

از [getActualLabelText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) برای دریافت متنی که توسط تنظیمات یک برچسب داده تولید می‌شود استفاده کنید. این عملکرد هنگام استخراج برچسب‌ها برای گزارش‌ها، جستجوی محتویات ارائه یا اعتبارسنجی نمودارهای تولید شده مفید است. در مثال زیر، قالب پیش‌فرض [data label format](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabelformat/) نام هر دسته، نام مجموعه و مقدار را ترکیب می‌کند. یک نقطه مقدار خود را به‌صورت درصد قالب‌بندی می‌کند و نقطهٔ دیگر متن سفارشی را از [getTextFrameForOverriding](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) دریافت می‌کند.

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

عدد ذخیره‌شده در یک نقطه داده همچنان `0.75` باقی می‌ماند، حتی وقتی برچسب آن `75%` به همراه نام دسته و نام مجموعه را نشان می‌دهد. متن سفارشی متن تولید شده برچسب را جایگزین می‌کند. [getActualLabelText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) در هر دو حالت رشتهٔ نهایی برچسب را برمی‌گرداند. همان‌طور که در بالا نشان داده شد، برای استخراج فقط برچسب‌های قابل مشاهده، به‌طور جداگانه [isVisible](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabel/isvisible/) را بررسی کنید.

## **کنترل برچسب‌های داده فراتر از حداکثر محور**

زمانی که بازهٔ محوری را به‌صورت دستی محدود می‌کنید، ممکن است برخی نقاط داده از حداکثر آن فراتر بروند. از [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) برای کنترل نمایش برچسب‌های این نقاط استفاده کنید. این تنظیم فقط نمایش برچسب را تغییر می‌دهد؛ بازهٔ محور یا مقادیر پایه را تحت تأثیر قرار نمی‌دهد.

مثال زیر یک نمودار ستونی خوشه‌ای دو‌بعدی با مقادیر 60 و 120 ایجاد می‌کند. `false` را به [setAutomaticMaxValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) پاس می‌دهد و حداکثر را با [setMaxValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/axis/setmaxvalue/) بر روی محور عمودی به 100 تنظیم می‌کند. اسلاید اول اجازهٔ نمایش برچسب‌ها فراتر از حداکثر را می‌دهد؛ یک کپی از آن اسلاید این قابلیت را غیرفعال می‌کند. هر دو اسلاید در `DataLabelsOverMaximum.pptx` ذخیره می‌شوند.

با [setShowValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) برچسب‌های مقدار را فعال کنید. تنظیم سطح نمودار به‌تنهایی نمایش مقدار را فعال نمی‌کند و نمی‌تواند نمایش مقدار غیرفعال یک برچسب جداگانه را نادیده بگیرد. این مثال مقادیر را برای کل مجموعه فعال می‌کند و از [setPosition](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabelformat/setposition/) برای قرار دادن برچسب‌ها در انتهای بیرونی هر ستون استفاده می‌کند.

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

تصاویر زیر اسلایدهای ذخیره‌شده را که توسط Microsoft PowerPoint رندر شده‌اند، نشان می‌دهند. با مقدار `true`، برچسب **120** در مرز بالا قابل مشاهده است؛ با مقدار `false`، مخفی می‌شود. برچسب **60** همچنان قابل مشاهده است، حداکثر محور در **100** می‌ماند و نقطهٔ دادهٔ دوم در هر دو حالت **120** باقی می‌ماند.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
این مثال از یک نمودار ستونی دو‌بعدی با محور مقدار استفاده می‌کند. نمودارهایی که محور مقدار ندارند، مانند نمودارهای دایره‌ای و دونات، حداکثر محور برای محدود‌سازی به این شکل ندارند.
{{% /alert %}}

## **تنظیم فاصلهٔ برچسب از محور**

از [setLabelOffset](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/axis/setlabeloffset/) برای کنترل فاصلهٔ بین برچسب‌های محور دسته و محور استفاده کنید. مقدار به‌صورت درصدی از حداکثر اندازهٔ قلم برچسب‌های محور محاسبه می‌شود. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و فاصلهٔ برچسب محور افقی را به 500 تنظیم می‌کند. این تنظیم برچسب‌های محور دسته را تحت تأثیر قرار می‌دهد، نه برچسب‌های متصل به نقاط دادهٔ منفرد.

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

## **تنظیم موقعیت برچسب**

در یک نمودار دایره‌ای، موقعیت برچسب‌های داده را برای بهبود فواصل و ایجاد فضای کافی برای خطوط راهنما تنظیم کنید.

این مثال مقدار اولین نقطه داده را نمایش می‌دهد، برچسب آن را خارج از برش قرار می‌دهد و افست‌های افقی و عمودی آن را با استفاده از [setX](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabel/setx/) و [setY](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabel/sety/) تنظیم می‌کند. این افست‌ها به ترتیب نسبت به عرض و ارتفاع نمودار هستند.

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **سؤالات رایج**

**چگونه می‌توان از هم‌پوشانی برچسب‌های داده در نمودارهای پرجمعیت جلوگیری کرد؟**

استفاده ترکیبی از جایگذاری خودکار برچسب، خطوط راهنما و کاهش اندازهٔ قلم؛ در صورت نیاز، برخی فیلدها (مانند دسته) را مخفی کنید یا فقط برای مقادیر افراطی یا نقاط کلیدی برچسب نشان دهید.

**چگونه می‌توان برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کرد؟**

قبل از فعال‌سازی برچسب‌ها نقاط داده را فیلتر کنید و نمایش برای مقادیر 0، مقادیر منفی یا مقادیر گمشده را بر اساس قاعده‌ای تعریف‌شده غیرفعال کنید.

**چگونه می‌توان سبک برچسب را به‌صورت یکسان هنگام خروجی به PDF/تصویر حفظ کرد؟**

به‌صورت صریح خانواده و اندازهٔ قلم را تنظیم کنید و اطمینان حاصل کنید که قلم در محیط رندر موجود است تا از استفادهٔ جایگزین جلوگیری شود.