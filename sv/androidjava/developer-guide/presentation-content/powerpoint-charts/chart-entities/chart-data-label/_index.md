---
title: Hantera diagramdataetiketter i presentationer på Android
linktitle: Dataetikett
type: docs
url: /sv/androidjava/chart-data-label/
keywords:
- diagram
- dataetikett
- dataprecision
- procent
- etikettdistans
- etikettplacering
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig att lägga till och formatera diagramdataetiketter i PowerPoint-presentationer med Aspose.Slides för Android via Java för mer engagerande bilder."
---
## **Introduktion**

Dataetiketter på ett diagram visar detaljer om diagrammets dataserier eller enskilda datapunkter. De låter läsarna snabbt identifiera dataserier och de gör också diagrammen lättare att förstå.

## **Ställ in dataprecision i diagrammets dataetiketter**

Den här Java-koden visar hur du ställer in dataprecisionen i en diagramdataetikett:

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

## **Visa procent som etiketter**
Aspose.Slides för Android via Java låter dig ange procentetiketter på visade diagram. Den här Java-koden demonstrerar hur det görs:

```java
// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Hämtar den första sliden
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
    
    // Sparar presentationen som innehåller diagrammet
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ange procenttecken med diagrammets dataetiketter**
Den här Java-koden visar hur du anger procenttecknet för en diagramdataetikett:

```java
// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Hämtar en slids referens via dess index
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Skapar diagrammet PercentsStackedColumn på en slide
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    
    // Ställer in NumberFormatLinkedToSource till false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    
    chart.getChartData().getSeries().clear();
    int defaultWorksheetIndex = 0;
    
    // Hämtar diagrammets dataarbetsblad
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    
    // Lägger till ny serie
    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.80));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    
    // Ställer in fyllningsfärgen för serien
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Ställer in egenskaper för LabelFormat
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Lägger till ny serie
    IChartSeries series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.70));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.50));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.20));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    
    // Ställer in fyllningstyp och färg
    series2.getFormat().getFill().setFillType(FillType.Solid);
    series2.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // Skriver presentationen till disk
    pres.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ställ in etikettdistans från en axel**
Den här Java-koden visar hur du anger etikettdistansen från en kategoriaxel när du arbetar med ett diagram som ritas från axlar:

```java
// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Hämtar en slids referens
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Skapar ett diagram på sliden
    IChart ch = sld.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    
    // Ställer in etikettdistansen från en axel
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    
    // Skriver presentationen till disk
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Justera etikettens placering**

När du skapar ett diagram som inte använder någon axel, till exempel ett cirkeldiagram, kan diagrammets dataetiketter hamna för nära kanten. I så fall måste du justera etikettens placering så att ledlinjerna visas tydligt.

Den här Java-koden visar hur du justerar etikettens placering i ett cirkeldiagram:

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

**Hur kan jag förhindra att dataetiketter överlappar i täta diagram?**

Kombinera automatisk placering av etiketter, ledlinjer och minskad teckenstorlek; vid behov dölja vissa fält (till exempel kategorin) eller visa etiketter endast för extrema eller nyckelpunkter.

**Hur kan jag inaktivera etiketter bara för noll-, negativa eller tomma värden?**

Filtrera datapunkter innan du aktiverar etiketter och stäng av visning för värden som är 0, negativa värden eller saknade värden enligt en definierad regel.

**Hur kan jag säkerställa en enhetlig etikettstil vid export till PDF/bilder?**

Ange explicit teckensnitt (familj, storlek) och verifiera att teckensnittet finns tillgängligt på renderingssidan för att undvika reservteckensnitt.