---
title: إدارة تسميات بيانات المخطط في العروض التقديمية باستخدام Java
linktitle: تسمية البيانات
type: docs
url: /ar/java/chart-data-label/
keywords:
- مخطط
- تسمية البيانات
- دقة البيانات
- نسبة مئوية
- مسافة التسمية
- موقع التسمية
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعرّف على طريقة إضافة وتنسيق تسميات بيانات المخططات في عروض PowerPoint باستخدام Aspose.Slides for Java لجعل الشرائح أكثر جاذبية."
---

تُظهر تسميات البيانات على المخطط تفاصيل حول سلسلة بيانات المخطط أو نقاط البيانات الفردية. فهي تتيح للقارئ التعرف سريعًا على سلاسل البيانات وتُسهِّل فهم المخططات.

## **تحديد دقة البيانات في تسميات بيانات المخطط**

يوضح لك هذا الكود بلغة Java كيفية تعيين دقة البيانات في تسمية بيانات المخطط:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");

    pres.save("output.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **عرض النسبة المئوية كتسميات**

تتيح لك مكتبة Aspose.Slides for Java تعيين تسميات النسبة المئوية على المخططات المعروضة. يوضح هذا الكود بلغة Java العملية:
```java
// ينشئ مثيلاً من فئة Presentation
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);
    IChartSeries series;
    double[] total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        IChartCategory cat = chart.getChartData().getCategories().get_Item(k);
    
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + (double) (chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData());
        }
    }
    
    double dataPontPercent = 0f;
    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
    
        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (double) ((series.getDataPoints().get_Item(j).getValue().getData())) / (double) (total_for_Cat[j]) * 100;
    
            IPortion port = new Portion();
            port.setText(String.format("{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8f);
            lbl.getTextFrameForOverriding().setText("");
            IParagraph para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
    
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    
    // يحفظ العرض التقديمي الذي يحتوي على المخطط
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين علامة النسبة المئوية في تسميات بيانات المخطط**

يُظهر لك هذا الكود بلغة Java كيفية تعيين علامة النسبة المئوية لتسمية بيانات المخطط:
```java
// ينشئ مثيلاً من فئة Presentation
Presentation pres = new Presentation();
try {
    // يحصل على مرجع الشريحة عبر الفهرس الخاص بها
    ISlide slide = pres.getSlides().get_Item(0);
    
    // ينشئ مخطط PercentsStackedColumn على الشريحة
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    
    // يحدد NumberFormatLinkedToSource إلى false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    
    chart.getChartData().getSeries().clear();
    int defaultWorksheetIndex = 0;
    
    // يحصل على ورقة عمل بيانات المخطط
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    
    // يضيف سلسلة جديدة
    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.80));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    
    // يحدد لون التعبئة للسلسلة
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // يحدد خصائص تنسيق التسميات
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // يضيف سلسلة جديدة
    IChartSeries series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.70));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.50));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.20));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    
    // يحدد نوع التعبئة واللون
    series2.getFormat().getFill().setFillType(FillType.Solid);
    series2.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // يكتب العرض التقديمي إلى القرص
    pres.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين مسافات التسميات** من المحور

يوضح لك هذا الكود بلغة Java كيفية تعيين مسافة التسمية من محور الفئة عند التعامل مع مخطط مرسم من المحاور:
```java
// ينشئ مثيلاً من فئة Presentation
Presentation pres = new Presentation();
try {
    // يحصل على مرجع الشريحة
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ينشئ مخططًا على الشريحة
    IChart ch = sld.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    
    // يحدد مسافة التسمية من المحور
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    
    // يكتب العرض التقديمي إلى القرص
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **ضبط موقع التسمية**

عند إنشاء مخطط لا يعتمد على أي محور مثل مخطط دائري، قد تكون تسميات بيانات المخطط قريبة جدًا من حافته. في هذه الحالة، عليك ضبط موقع تسمية البيانات بحيث تُظهر خطوط الوصل بوضوح.

يوضح لك هذا الكود بلغة Java كيفية ضبط موقع التسمية على المخطط الدائري:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.getChartData().getSeries();
    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);

    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات الكثيفة؟**

اجمع بين وضع التسميات التلقائي، خطوط الوصل، وتصغير حجم الخط؛ وإذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض التسميات فقط للنقاط القصوى/المهمة.

**كيف يمكنني إلغاء تمكين التسميات للقيم الصفرية أو السالبة أو الفارغة فقط؟**

قُم بترشيح نقاط البيانات قبل تمكين التسميات وأوقف العرض للقيم الصفرية أو السالبة أو القيم المفقودة وفقًا لقاعدة محددة.

**كيف أضمن نمط تسمية متسق عند التصدير إلى PDF/صور؟**

حدد الخطوط صراحة (العائلة، الحجم) وتأكد من أن الخط متاح على جانب العرض لتفادي الاعتماد على خطوط بديلة.