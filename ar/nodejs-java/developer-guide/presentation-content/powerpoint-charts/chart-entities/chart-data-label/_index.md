---
title: تسمية بيانات المخطط
type: docs
url: /ar/nodejs-java/chart-data-label/
keywords: "تسمية بيانات المخطط، مسافة التسمية، Java، Aspose.Slides for Node.js عبر Java"
description: "تعيين تسمية بيانات مخطط PowerPoint والمسافة باستخدام JavaScript"
---

تُظهر تسميات البيانات في المخطط تفاصيل حول سلسلة بيانات المخطط أو نقاط البيانات الفردية. إنها تسمح للقراء بالتعرف بسرعة على سلاسل البيانات كما تجعل المخططات أسهل للفهم.

## **تحديد دقة البيانات في تسميات بيانات المخطط**

يظهر لك هذا الكود JavaScript كيفية تحديد دقة البيانات في تسمية بيانات المخطط:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **عرض النسبة المئوية كتسميات**

تتيح لك Aspose.Slides لـ Node.js عبر Java تعيين تسميات النسبة المئوية على المخططات المعروضة. يوضح لك هذا الكود JavaScript العملية:
```javascript
// ينشئ مثالًا من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);
    var series;
    var total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (var k = 0; k < chart.getChartData().getCategories().size(); k++) {
        var cat = chart.getChartData().getCategories().get_Item(k);
        for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData();
        }
    }
    var dataPontPercent = 0.0;
    for (var x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
        for (var j = 0; j < series.getDataPoints().size(); j++) {
            var lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (series.getDataPoints().get_Item(j).getValue().getData() / total_for_Cat[j]) * 100;
            var port = new aspose.slides.Portion();
            port.setText(java.callStaticMethodSync("java.lang.String", "format", "{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8.0);
            lbl.getTextFrameForOverriding().setText("");
            var para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    // يحفظ العرض التقديمي الذي يحتوي على المخطط
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين رمز النسبة المئوية في تسميات بيانات المخطط**

يظهر لك هذا الكود JavaScript كيفية تعيين رمز النسبة المئوية لتسمية بيانات المخطط:
```javascript
// ينشئ مثيلاً من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // يحصل على مرجع الشريحة عبر فهرستها
    var slide = pres.getSlides().get_Item(0);
    // ينشئ مخطط PercentsStackedColumn على شريحة
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    // يضبط الخاصية NumberFormatLinkedToSource إلى false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    chart.getChartData().getSeries().clear();
    var defaultWorksheetIndex = 0;
    // يحصل على ورقة عمل بيانات المخطط
    var workbook = chart.getChartData().getChartDataWorkbook();
    // يضيف سلسلة جديدة
    var series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    // يضبط لون تعبئة السلسلة
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // يضبط خصائص تنسيق التسمية (LabelFormat)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // يضيف سلسلة جديدة
    var series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.7));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.5));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.2));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    // يضبط نوع التعبئة واللون
    series2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    // يكتب العرض التقديمي إلى القرص
    pres.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحديد مسافة التسميات من المحور**

يظهر لك هذا الكود JavaScript كيفية تعيين مسافة التسمية من محور الفئة عندما تتعامل مع مخطط مرسوم من المحاور:
```javascript
// ينشئ مثيلاً من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // يحصل على مرجع الشريحة
    var sld = pres.getSlides().get_Item(0);
    // ينشئ مخططًا على الشريحة
    var ch = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    // يضبط مسافة التسمية من المحور
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    // يكتب العرض التقديمي إلى القرص
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **ضبط موقع التسمية**

عند إنشاء مخطط لا يعتمد على أي محور مثل مخطط الدائرة، قد تكون تسميات بيانات المخطط قريبة جدًا من حافته. في هذه الحالة، عليك ضبط موقع تسمية البيانات بحيث تُعرض خطوط الربط بوضوح.

يظهر لك هذا الكود JavaScript كيفية ضبط موقع التسمية في مخطط الدائرة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    var series = chart.getChartData().getSeries();
    var label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71);
    label.setY(0.04);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **الأسئلة الشائعة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات الكثيفة؟**

اجمع بين وضعية التسمية التلقائية، وخطوط الربط، وتقليل حجم الخط؛ وإذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض التسميات فقط للنقاط المتطرفة/الرئيسية.

**كيف يمكنني إيقاف تشغيل التسميات للقيم الصفرية أو السلبية أو الفارغة فقط؟**

قم بتصفية نقاط البيانات قبل تمكين التسميات وأوقف العرض للقيم الصفرية أو السلبية أو القيم المفقودة وفقًا لقاعدة محددة.

**كيف يمكنني ضمان تناسق نمط التسمية عند التصدير إلى PDF/صور؟**

حدد الخطوط (العائلة، الحجم) صراحةً وتأكد من أن الخط متاح على جانب العرض لتفادي الاعتماد على الخط الاحتياطي.