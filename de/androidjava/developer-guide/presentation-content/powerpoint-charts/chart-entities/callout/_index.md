---
title: Verwalten von Callouts in Präsentationsdiagrammen auf Android
linktitle: Callout
type: docs
url: /de/androidjava/callout/
keywords:
- Diagramm-Callout
- Callout verwenden
- Datenbeschriftung
- Beschriftungsformat
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen und formatieren Sie Callouts in Aspose.Slides für Android mit prägnanten Java-Code-Beispielen, die mit PPT und PPTX kompatibel sind, um Präsentations-Workflows zu automatisieren."
---

## **Verwendung von Callouts**
Neue Methoden [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) und [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) wurden zur Klasse [DataLabelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabelformat) und zum Interface [IDataLabelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat) hinzugefügt. Diese Methoden bestimmen, ob die Datenbeschriftung des angegebenen Diagramms als Daten‑Callout oder als Datenbeschriftung angezeigt wird.
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400);
    
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    
    pres.save("DisplayCharts.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Callout für ein Donut‑Diagramm festlegen**
Aspose.Slides für Android via Java bietet Unterstützung für das Festlegen der Callout‑Form der Datenbeschriftung einer Serie in einem Donut‑Diagramm. Nachfolgend ein Beispiel.
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, false);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    int seriesIndex = 0;
    while (seriesIndex < 15)
    {
        IChartSeries series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize((byte)20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    int categoryIndex = 0;
    while (categoryIndex < 15)
    {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        int i = 0;
        while (i < chart.getChartData().getSeries().size())
        {
            IChartSeries iCS = chart.getChartData().getSeries().get_Item(i);
            IChartDataPoint dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(LineDashStyle.Solid);
            if (i == chart.getChartData().getSeries().size() - 1)
            {
                IDataLabel lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.LIGHT_GRAY);
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX((float) lbl.getX()+ (float)0.5);
                lbl.setY((float)lbl.getY()+ (float)0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Werden Callouts beim Konvertieren einer Präsentation zu PDF, HTML5, SVG oder Bildern beibehalten?**

Ja. Callouts sind Teil der Diagrammdarstellung, sodass sie beim Export nach [PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/), [HTML5](/slides/de/androidjava/export-to-html5/), [SVG](/slides/de/androidjava/render-a-slide-as-an-svg-image/) oder [Rasterbildern](/slides/de/androidjava/convert-powerpoint-to-png/) zusammen mit der Formatierung der Folie erhalten bleiben.

**Werden benutzerdefinierte Schriftarten in Callouts unterstützt und kann ihr Aussehen beim Export beibehalten werden?**

Ja. Aspose.Slides unterstützt das [Einbetten von Schriftarten](/slides/de/androidjava/embedded-font/) in die Präsentation und steuert das Einbetten von Schriftarten bei Exporten wie [PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/), sodass die Callouts auf verschiedenen Systemen gleich aussehen.