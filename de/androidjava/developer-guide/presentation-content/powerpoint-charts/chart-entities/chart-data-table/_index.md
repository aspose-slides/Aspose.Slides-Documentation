---
title: Diagrammdaten Tabelle
type: docs
url: /androidjava/chart-data-table/
---

## **Schriftarteigenschaften für Diagrammdaten Tabelle setzen**
Aspose.Slides für Android über Java bietet Unterstützung für die Änderung der Farbe von Kategorien in einer Serienfarbe.

1. Instanziieren Sie [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klassenobjekt.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Setzen Sie die Diagrammtabelle.
1. Setzen Sie die Schriftgröße.
1. Speichern Sie die modifizierte Präsentation.

Unten ist ein Beispiel gegeben.

```java
// Erstellen einer leeren Präsentation
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