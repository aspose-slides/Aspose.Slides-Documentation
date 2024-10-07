---
title: تسمية بيانات الرسم البياني
type: docs
url: /java/chart-data-label/
keywords: "تسمية بيانات الرسم البياني, مسافة التسمية, Java, Aspose.Slides لـ Java"
description: "تعيين تسمية بيانات الرسم البياني في PowerPoint ومسافتها في Java"
---

تظهر تسميات البيانات على الرسم البياني تفاصيل حول سلسلة بيانات الرسم البياني أو نقاط البيانات الفردية. إنها تتيح للقراء التعرف بسرعة على سلسلة البيانات وتساعد أيضًا في جعل الرسوم البيانية أسهل للفهم.

## **تعيين دقة البيانات في تسميات بيانات الرسم البياني**

يوضح هذا الكود بلغة Java كيفية تعيين دقة البيانات في تسمية بيانات الرسم البياني:

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
تتيح Aspose.Slides لـ Java لك تعيين تسميات النسبة المئوية على الرسوم البيانية المعروضة. يوضح هذا الكود بلغة Java العملية:

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
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
    
    // حفظ العرض التقديمي الذي يحتوي على الرسم البياني
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين علامة النسبة المئوية مع تسميات بيانات الرسم البياني**
يوضح هذا الكود بلغة Java كيفية تعيين علامة النسبة المئوية لتسمية بيانات الرسم البياني:

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على مرجع إلى شريحة من خلال مؤشرها
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إنشاء الرسم البياني النسبية المتكدسة على الشريحة
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    
    // تعيين NumberFormatLinkedToSource إلى false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    
    chart.getChartData().getSeries().clear();
    int defaultWorksheetIndex = 0;
    
    // الحصول على ورقة عمل بيانات الرسم البياني
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    
    // إضافة سلاسل جديدة
    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.80));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    
    // تعيين لون التعبئة للسلسلة
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // تعيين خصائص LabelFormat
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // إضافة سلاسل جديدة
    IChartSeries series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.70));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.50));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.20));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    
    // تعيين نوع التعبئة ولونها
    series2.getFormat().getFill().setFillType(FillType.Solid);
    series2.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // كتابة العرض التقديمي على القرص
    pres.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين مسافات التسمية من المحور**
يوضح هذا الكود بلغة Java كيفية تعيين مسافة التسمية من محور الفئة عند التعامل مع رسم بياني موضح من المحاور:

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على مرجع إلى شريحة
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء رسم بياني على الشريحة
    IChart ch = sld.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    
    // تعيين مسافة التسمية من محور
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    
    // كتابة العرض التقديمي على القرص
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعديل موقع التسمية**

عند إنشاء رسم بياني لا يعتمد على أي محور مثل الرسم البياني الدائري، قد تكون تسميات بيانات الرسم البياني قريبة جدًا من حافته. في هذه الحالة، يتعين عليك ضبط موقع تسمية البيانات بحيث يتم عرض خطوط القادة بوضوح.

يوضح هذا الكود بلغة Java كيفية تعديل موقع التسمية على الرسم البياني الدائري:

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