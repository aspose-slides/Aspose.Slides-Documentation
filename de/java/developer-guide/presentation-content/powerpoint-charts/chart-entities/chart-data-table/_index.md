---
title: Diagrammdaten Tabelle
type: docs
url: /java/chart-data-table/
---

## **Schriftarteigenschaften für Diagrammdaten Tabelle festlegen**
Aspose.Slides für Java bietet Unterstützung zum Ändern der Farbe von Kategorien in einer Farbserie. 

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klassenobjekt.
1. Fügen Sie das Diagramm auf der Folie hinzu.
1. Legen Sie die Diagrammtabelle fest.
1. Legen Sie die Schriftgröße fest.
1. Speichern Sie die modifizierte Präsentation.

Nachfolgend ein Beispiel. 

```java
// Erstellen Sie eine leere Präsentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```