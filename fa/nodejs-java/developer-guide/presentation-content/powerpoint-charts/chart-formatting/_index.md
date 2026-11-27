---
title: قالب‌بندی نمودارهای ارائه در JavaScript
linktitle: قالب‌بندی نمودار
type: docs
weight: 60
url: /fa/nodejs-java/chart-formatting/
keywords:
- قالب‌بندی نمودار
- قالب‌بندی نمودار
- موجودیت نمودار
- خصوصیات نمودار
- تنظیمات نمودار
- گزینه‌های نمودار
- خصوصیات قلم
- حاشیهٔ گرد
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یادگیری قالب‌بندی نمودار در Aspose.Slides برای Node.js از طریق Java و ارتقاء ارائه PowerPoint شما با محورهای سفارشی، قلم‌ها، قالب‌های عددی و حاشیه‌های گرد نمودار."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه می‌توان نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides قالب‌بندی کرد. همچنین نشان می‌دهد چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، راهنمایی‌ها، ناحیهٔ ترسیم و پر کردن دیوارها را سفارشی کنیم تا ظاهر و قابلیت خواندن داده‌های نمودار بهبود یابد.

همچنین نحوهٔ تنظیم خصوصیات قلم برای متن نمودار، اعمال قالب‌های عددی پیش‌تنظیم‌شده بر داده‌های نمودار و فعال‌سازی گوشه‌های گرد برای ناحیهٔ نمودار نشان داده می‌شود. این مثال‌ها به شما امکان می‌دهند هم سبک بصری و هم ارائهٔ داده‌های نمودار را در یک ارائه کنترل کنید.

برای پرکردن و خطوط جداگانه در بازه‌های صعودی و نزولی، به [مثال نمودار سهام](/slides/fa/nodejs-java/create-chart/#create-stock-charts) مراجعه کنید.

## **قالب‌بندی موجودیت‌های نمودار**

از [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) برای قالب‌بندی عناوین نمودار، محورها، خطوط شبکه، راهنمایی‌ها و ناحیهٔ ترسیم استفاده کنید. این مثال یک نمودار خطی با نشانگرها و داده‌های پیش‌فرض ایجاد می‌کند، سپس سبک‌های متن و خط را به طور جداگانه برای محور مقادیر و محور دسته‌ها اعمال می‌نماید. اندازهٔ قلم و عرض خطوط بر حسب نقطه مشخص شده‌اند؛ برچسب‌های دسته با زاویهٔ 45 درجه چرخانده می‌شوند.

محور مقادیر به صورت مستقل از سلول‌های منبع از [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setNumberFormat) استفاده می‌کند. مقیاس آن از -2 تا 15 است، با فواصل اصلی 2 و فواصل فرعی 0.5. این مثال همچنین قالب‌بندی درصدی را با [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setDisplayUnit) که به هزارها تنظیم شده ترکیب می‌کند، بنابراین این تنظیمات را بر حسب معنی و مقیاس داده‌های خود تنظیم کنید. راهنمایی به دلیل فراخوانی [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#setOverlay) با مقدار `false` در خارج از ناحیهٔ ترسیم می‌ماند. پرکردن پشت‌دیوار و کف از طریق [getBackWall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getBackWall) و [getFloor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getFloor) پیکربندی می‌شود، اما این سطوح تنها در نمودارهای سه‌بعدی قابل مشاهده هستند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    let chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    chartTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15);
    chart.getAxes().getVerticalAxis().setMinValue(-2);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);

    let valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkGreen));
    valueAxisText.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    let valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    let categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    categoryAxisText.setLatinFont(new aspose.slides.FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    let categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    let legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    legendText.setFontHeight(16);
    legendText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    legendText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    legendText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkRed));

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.LightCyan));

    presentation.save("FormattedChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم خصوصیات قلم برای یک نمودار**

اندازهٔ پیش‌فرض قلم برای متن نمودار را از طریق [Chart.getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getTextFormat) تنظیم کنید. این مثال یک نمودار ستونی خوشه‌ای با قلم 20 نقطه‌ای ایجاد می‌کند و برچسب‌های مقدار را برای اولین سری با استفاده از [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) فعال می‌سازد. عناصر متنی با تنظیمات قلم صریح خود می‌توانند پیش‌فرض نمودار را بازنویسی کنند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استفاده مجدد از قالب‌بندی قاب متن برای راهنمایی نمودار**

برای تطبیق راهنمایی با عنوان اسلاید، قلم عنوان را از طریق [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) در اولین پاراگراف تنظیم کنید. بر روی قالبی که توسط [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#getTextFormat) راهنمایی بازگردانده می‌شود، متد [copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyFrom) را فراخوانی کنید. این متد تنظیمات قاب متن، قالب‌بندی اولین پاراگراف و خصوصیات پیش‌فرض قلم آن پاراگراف را کپی می‌کند. قالب‌بندی اعمال‌شده مستقیم به بخش‌های جداگانه یا به پاراگراف‌های بعدی فقط به منبع مربوط می‌شود.

مثال از یک عنوان بولد، 26 نقطه‌ای Calibri به رنگ سرمه‌ای به‌عنوان الگو استفاده می‌کند. پس از استایل‌دهی به راهنمایی، متد [copyTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyTo) فراخوانی می‌شود تا همان قالب‌بندی به یک کپشن جداگانه اعمال شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const heading = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 20, 640, 40, false);
    const sourceTextFrame = heading.addTextFrame("Quarterly sales");
    const font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new aspose.slides.FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    font.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    font.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 32, 64, 96));

    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(java.newByte(aspose.slides.StyleType.Style3));
    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (let quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(java.newByte(aspose.slides.LegendPositionType.Bottom));
    const legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    const caption = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 460, 640, 40, false);
    const captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در ارائهٔ ذخیره‌شده، راهنمایی و کپشن از نظر اندازه، وزن و رنگ با عنوان مطابقت دارند. راهنمایی همچنان نام‌های سری‌ها را نمایش می‌دهد و کپشن متن خود را حفظ می‌کند. اگر بخشی در کپشن قبلاً دارای اندازهٔ قلم صریح باشد، آن اندازه بر پیش‌فرض پاراگراف کپی‌شده اولویت دارد.

| قبل از کپی | بعد از کپی |
| --- | --- |
| ![نمودار فروش فصلی با برچسب‌های راهنمایی سیاه معمولی و یک کپشن سیاه](legend-formatting-before.png) | ![نمودار مشابه با برچسب‌های راهنمایی نیرویی بزرگ‌تر، بولد و کپشن متطابق](legend-formatting.png) |

## **تنظیم قالب عددی**

از [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#setPresetNumberFormat) برای اعمال یک قالب عددی پیش‌تنظیم‌شده به سلول‌های کتاب‌کار نمودار استفاده کنید. این مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض، پشتیبانی‌شده توسط سلول‌ها ایجاد می‌کند و ایندکس قالب 10 (`0.00%`) را به هر سلول مقدار سری اعمال می‌سازد. این کار نحوهٔ نمایش مقادیر را در کتاب‌کار بدون تغییر عددهای پایه تغییر می‌دهد؛ برای مثال، مقدار 0.25 به صورت 25.00% نمایش داده می‌شود. قالب‌های محور و برچسب داده‌ها می‌توانند به‌صورت جداگانه پیکربندی شوند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    let series = chart.getChartData().getSeries();

    for (let i = 0; i < series.size(); i++) {
        let chartSeries = series.get_Item(i);
        for (let j = 0; j < chartSeries.getDataPoints().size(); j++) {
            let dataPoint = chartSeries.getDataPoints().get_Item(j);
            dataPoint.getValue().getAsCell().setPresetNumberFormat(java.newByte(10)); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

جدول زیر فهرست ایندکس‌های قالب عددی پیش‌ساخته همراه با قالب‌های نمونهٔ Excel برای پایگاه محلی انگلیسی (ایالات متحده) را نشان می‌دهد. رشته‌های قالب دقیق و نمایش آن‌ها می‌تواند بسته به برنامه و محل متفاوت باشد، به‌ویژه برای ارزها و تاریخ‌ها. برخی قالب‌های Excel همچنین با پیش‌فرض‌های استاندارد OOXML متفاوت هستند، همان‌طور که در [یادداشت‌های پیاده‌سازی قالب عددی مایکروسافت](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) توضیح داده شده است.

| شاخص | قالب |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **تنظیم گوشه‌های گرد ناحیه نمودار**

متد [Chart.setRoundedCorners](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setRoundedCorners) را با مقدار `true` فراخوانی کنید تا گوشه‌های ناحیهٔ نمودار گرد شوند. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و از [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) برای تنظیم خط پیرامون آن با رنگ خاکستری ثابت و سبک خطوط تک‌خطی استفاده می‌کند قبل از ذخیرهٔ ارائه.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chart.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ویرایش حاشیه‌نویسی‌های موجود در نمودار**

یک نمودار می‌تواند اشکال سفارشی، مانند حاشیه‌نویسی متنی که وضعیت یک گزارش را توضیح می‌دهد، داشته باشد. این اشکال را از طریق [Chart.getUserShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getUserShapes) دسترسی پیدا کنید. مجموعه‌ای که توسط [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) بازگردانده می‌شود شامل اشکال متعلق به نمودار است.

یک جعبه متن عادی که روی نمودار قرار می‌گیرد متعلق به اسلاید است، حتی اگر شبیه بخشی از نمودار به نظر برسد. با پیمایش [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) می‌توانید نمودار و اشکال عادی اسلاید را پیدا کنید، اما اشکال جداگانه داخل نمودار فهرست نمی‌شوند. عناوین نمودار و برچسب‌های داده عناصر جداگانه‌ای هستند، نه حاشیه‌نویسی‌های سفارشی در این مجموعه.

فایل [chart-annotations.pptx](chart-annotations.pptx) را دانلود کنید و در پوشهٔ کاری برنامه قرار دهید. اسلاید اول آن شامل یک نمودار با حاشیه‌نویسی غیرگروه‌بندی شده «نتایج اولیه»، یک خط متعلق به نمودار و یک جعبه متن عادی اسلایدی با متن «پوشش اسلاید» است. مثال اولین نمودار را در آن اسلاید پیدا می‌کند و حاشیه‌نویسی را به «نتایج نهایی» تغییر می‌دهد هنگامی که گزارش آمادهٔ انتشار شود. ابتدا بررسی می‌کند که مجموعهٔ خالی نباشد و فقط یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) با قاب متن غیر‌خالی که توسط [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) بازگردانده شده و متن مورد انتظار دارد، ویرایش می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation("chart-annotations.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = null;
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
            chart = shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        console.log("No chart or chart-owned shapes found.");
    } else {
        let updated = false;
        for (let i = 0; i < chart.getUserShapes().getShapes().size(); i++) {
            let shape = chart.getUserShapes().getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let annotation = shape;
                if (annotation.getTextFrame() != null && annotation.getTextFrame().getText() === "Preliminary results") {
                    annotation.getTextFrame().setText("Final results");
                    updated = true;
                    break;
                }
            }
        }

        if (updated) {
            presentation.save("chart-annotations-updated.pptx", aspose.slides.SaveFormat.Pptx);
        } else {
            console.log("No matching text annotation found.");
        }
    }
} finally {
    presentation.dispose();
}
```

خط و جعبه متن اسلاید بدون تغییر باقی می‌مانند. تصاویر زیر ورودی و نتیجهٔ ذخیره‌سازی‑بازگشایی شده را نشان می‌دهند:

| قبل از ویرایش | بعد از ویرایش |
| --- | --- |
| ![حاشیه‌نویسی نمودار با متن «نتایج اولیه»](chart-annotations-before.png) | ![حاشیه‌نویسی نمودار با متن «نتایج نهایی»](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
مثال فقط اشکال سطح‑بالای متعلق به نمودار را بررسی می‌کند. اگر حاشیه‌نویسی درون یک [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) باشد، مجموعهٔ [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) آن گروه را نیز بررسی کنید. این کار را به‌صورت بازگشتی برای گروه‌های تو در تو تکرار کنید و همان بررسی‌های متنی را روی اشکال فرزندشان اعمال کنید. یک گروه خودش یک ظرف است؛ آن را به عنوان جعبهٔ متن در نظر نگیرید.
{{% /alert %}}

## **پرسش‌های متداول**

**آیا می‌توانم پرکردن نیمه‌شفاف برای ستون‌ها/ناحیه‌ها تنظیم کنم در حالی که حاشیه را مات نگه دارم؟**

بله. شفافیت پرکردن و خط مرزی به‌صورت جداگانه پیکربندی می‌شوند. این کار برای بهبود خوانایی شبکه و داده‌ها در نمایش‌های پرجزئی مفید است.

**چگونه می‌توانم با برچسب‌های داده‌ای که با هم تداخل دارند برخورد کنم؟**

اندازهٔ قلم را کاهش دهید، اجزاء غیرضروری برچسب‌ها (مثلاً دسته‌ها) را غیرفعال کنید، موقعیت برچسب را تنظیم کنید، در صورت نیاز فقط برای نقاط منتخب برچسب نمایش دهید، یا قالب را به «مقدار + راهنما» تغییر دهید.

**آیا می‌توانم پرکردن گرادیان یا الگو را به سری‌ها اعمال کنم؟**

بله. سری‌ها از پرکردن‌های ثابت، گرادیان و الگو پشتیبانی می‌کنند. در عمل، از گرادیان‌ها به‌طور مقتصدانه استفاده کنید و از ترکیب‌هایی که کنتراست با شبکه و متن را کاهش می‌دهند خودداری کنید.