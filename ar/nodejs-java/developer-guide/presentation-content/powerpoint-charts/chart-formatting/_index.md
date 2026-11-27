---
title: تنسيق مخططات العرض التقديمي في JavaScript
linktitle: تنسيق المخطط
type: docs
weight: 60
url: /ar/nodejs-java/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخطط
- كيان المخطط
- خصائص المخطط
- إعدادات المخطط
- خيارات المخطط
- خصائص الخط
- حد مستدير
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides لـ Node.js عبر Java وارتقِ بعرض PowerPoint الخاص بك باستخدام محاور مخصصة، خطوط، تنسيقات رقمية، وحدود مخطط مستديرة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق المخططات في عروض PowerPoint باستخدام Aspose.Slides. تُظهر كيفية تخصيص عناصر المخطط الأساسية مثل المحاور، وخطوط الشبكة، والعناوين، والأساطير، ومنطقة الرسم، وتعبئات الجدران لتحسين مظهر البيانات وقابليتها للقراءة.

كما تُظهر كيفية ضبط خصائص الخط لنص المخطط، وتطبيق تنسيقات رقمية مُعدة مسبقًا على بيانات المخطط، وتمكين الزوايا المستديرة لمنطقة المخطط. معًا، تُظهر هذه الأمثلة كيفية التحكم في كل من النمط البصري وعرض البيانات للمخططات في العرض التقديمي.

للحصول على تعبئات وتحديدات منفصلة للفترات الصاعدة والهابطة، راجع [مثال مخطط الأسهم](/slides/ar/nodejs-java/create-chart/#create-stock-charts).

## **تنسيق كائنات المخطط**

استخدم [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) لتنسيق عناوين المخطط، والمحاور، وخطوط الشبكة، والأساطير، ومنطقة الرسم. تُنشئ هذه المثال مخططًا خطيًا مع علامات وبيانات افتراضية، ثم تطبق أنماط نص وخط منفصلة على محوري القيمة والفئة. يتم تحديد أحجام الخطوط وعرض الخطوط بالنقاط؛ تُدوَّر تسميات الفئة بزاوية 45 درجة.

يستخدم محور القيمة الدالة [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setNumberFormat) بشكل مستقل عن خلايا المصدر. يمتد نطاقه من -2 إلى 15، مع فواصل رئيسية قدرها 2 وفواصل فرعية قدرها 0.5. يجمع المثال أيضًا تنسيق النسبة المئوية مع الدالة [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setDisplayUnit) المضبوطة على الآلاف، لذا يجب تعديل هذه الإعدادات وفقًا لمعنى وحجم البيانات الخاصة بك. يبقى الأسطورة خارج منطقة الرسم لأن الدالة [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#setOverlay) تُستدعى بقيمة `false`. يتم تكوين تعبئات الجدار الخلفي والأرضية عبر [getBackWall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getBackWall) و [getFloor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getFloor)، ولكن هذه الأسطح تُظهر فقط في المخططات ثلاثية الأبعاد.

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

## **تعيين خصائص الخط للمخطط**

قم بتعيين حجم الخط الافتراضي لنص المخطط عبر [Chart.getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getTextFormat). تُنشئ هذه المثال مخطط أعمدة متجمع بحجم خط 20 نقطة وتُمكّن تسميات القيم للسلسلة الأولى عبر [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue). يمكن لعناصر النص التي لديها إعدادات خط صريحة خاصة بها أن تتجاوز الإعداد الافتراضي للمخطط.

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

## **إعادة استخدام تنسيق إطار النص لوسيلة إيضاح المخطط**

لمطابقة وسيلة الإيضاح مع عنوان الشريحة، قم بضبط خط العنوان عبر [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) في الفقرة الأولى. استدعِ الدالة [copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyFrom) على التنسيق الذي تُرجعه وسيلة الإيضاح من [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#getTextFormat). يقوم بنسخ إعدادات إطار النص، وتنسيق الفقرة الأولى، وخصائص الخط الافتراضية لتلك الفقرة. يبقى التنسيق المطبّق مباشرة على أجزاء فردية أو على فقرات لاحقة محليًا على المصدر.

تستخدم المثال عنوانًا بCalibri غامق بحجم 26 نقطة وباللون النيلي كنموذج. بعد تنسيق وسيلة الإيضاح، تستدعي الدالة [copyTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyTo) لتطبيق نفس التنسيق على تسمية توضيحية منفصلة.

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

في العرض التقديمي المحفوظ، تتطابق وسيلة الإيضاح والتسمية التوضيحية مع العنوان من حيث الحجم والوزن واللون. لا تزال وسيلة الإيضاح تعرض أسماء السلاسل، وتحتفظ التسمية التوضيحية بنصها الخاص. إذا كان هناك جزء في التسمية التوضيحية يملك حجم خط صريحًا مسبقًا، فإن ذلك الحجم يحظى بالأولوية على الإعداد الافتراضي للفقرة المنسوخة.

| قبل النسخ | بعد النسخ |
| --- | --- |
| ![مخطط مبيعات ربع سنوية مع تسميات وسيلة إيضاح سوداء عادية وتسمية توضيحية سوداء](legend-formatting-before.png) | ![نفس المخطط مع تسميات وسيلة إيضاح أكبر، غامقة، باللون النيلي وتسمية توضيحية متطابقة](legend-formatting.png) |

## **تعيين التنسيق الرقمي**

استخدم [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#setPresetNumberFormat) لتطبيق تنسيق رقمي مدمج على خلايا دفتر عمل المخطط. تُنشئ هذه المثال مخطط أعمدة متجمع ببيانات افتراضية مدعومة بالخلية وتطبق فهرس التنسيق 10 (`0.00%`) على كل خلية قيمة للمتسلسلة. يُغيّر هذا طريقة عرض القيم في دفتر العمل دون تعديل الأرقام الأساسية؛ على سبيل المثال، يتم عرض 0.25 كـ 25.00٪. يمكن تكوين تنسيقات المحاور وتسمية البيانات بشكل منفصل.

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

القائمة التالية تُظهر مؤشرات تنسيقات الأرقام المدمجة مع صيغ Excel النموذجية للغة الإنجليزية (الولايات المتحدة). قد تختلف سلاسل التنسيق وعرضها حسب التطبيق والمنطقة، خاصةً بالنسبة للعملة والتواريخ. بعض صيغ Excel تختلف أيضًا عن القيم الافتراضية في معيار OOXML، كما هو موضح في [ملاحظات تنفيذ تنسيق الأرقام من مايكروسوفت](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| المؤشر | التنسيق |
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

## **تعيين حدود مستديرة لمنطقة المخطط**

استدعِ الدالة [Chart.setRoundedCorners](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setRoundedCorners) مع القيمة `true` لتقويس زوايا منطقة المخطط. تُنشئ هذه المثال مخطط أعمدة متجمع وتستخدم [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) لإعطاء حدوده لونًا رماديًا صلبًا ونمط خط أحادي قبل حفظ العرض التقديمي.

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

## **تحرير تعليقات المخطط الحالية**

يمكن أن يحتوي المخطط على أشكال مخصصة، مثل ملاحظة نصية تشرح حالة تقرير. يمكن الوصول إلى هذه الأشكال عبر [Chart.getUserShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getUserShapes). المجموعة التي تُرجعها الدالة [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) تحتوي على الأشكال المملوكة للمخطط.

صناديق النص العادية الموضوعة فوق المخطط تنتمي إلى الشريحة، حتى لو بدت كجزء من المخطط. يؤدي التكرار عبر [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) إلى العثور على المخطط وأشكال الشريحة العادية، لكنه لا يسرد الأشكال الفردية داخل المخطط. عناوين المخطط وتسمية البيانات هي عناصر مخطط منفصلة، وليست ملاحظات مخصصة في هذه المجموعة.

قم بتنزيل [chart-annotations.pptx](chart-annotations.pptx) وضعه في دليل العمل الخاص بالتطبيق. تحتوي الشريحة الأولى على مخطط مع ملاحظة غير مجمعة تحمل النص "النتائج الأولية"، وخط مملوك للمخطط، وصندوق نص عادي على الشريحة يحمل النص "تراكب الشريحة". يجد المثال أول مخطط في تلك الشريحة ويغيّر الملاحظة إلى "النتائج النهائية" عندما يكون التقرير جاهزًا للنشر. يتحقق من وجود مجموعة فارغة ولا يحرّر إلا [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) يحتوي على إطار نص غير فارغ تُرجعه الدالة [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) والنص المتوقع.

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

يبقى الخط وصندوق نص الشريحة دون تغيير. توضح الصور التالية الإدخال والنتيجة المحفوظة والمفتوحة مرة أخرى:

| قبل التعديل | بعد التعديل |
| --- | --- |
| ![ملاحظة مخطط تُظهر "النتائج الأولية"](chart-annotations-before.png) | ![ملاحظة مخطط تُظهر "النتائج النهائية"](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}

المثال يفحص فقط الأشكال المملوكة للمخطط في المستوى العلوي. إذا كانت الملاحظة داخل [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/)، فافحص مجموعة [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) كذلك. كرر ذلك بشكل متكرر للمجموعات المتداخلة، مطبقًا نفس فحوصات النص على الأشكال التابعة لها. المجموعة نفسها حاوية؛ لا تعاملها كصندوق نص.

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تعيين تعبئات شبه شفافة للأعمدة/المناطق مع الحفاظ على الحدود غير شفافة؟**

نعم. يتم تكوين شفافية التعبئة والحدود بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عند تداخلها؟**

قلل حجم الخط، عطل مكونات التسمية غير الضرورية (مثلاً الفئات)، ضبط موضع التسمية، إظهار التسميات فقط للنقاط المختارة إذا لزم الأمر، أو غير الصيغة إلى "القيمة + الأسطورة".

**هل يمكنني تطبيق تعبئات تدرجية أو بنمط على السلاسل؟**

نعم. تدعم السلاسل تعبئات صلبة، وتدرجية، وبنمط. في التطبيق العملي، استخدم التدرجات باعتدال وتجنب التركيبات التي تقلل التباين مع الشبكة والنص.