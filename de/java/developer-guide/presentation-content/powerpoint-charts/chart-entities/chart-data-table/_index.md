---
title: Diagrammdatentabellen in Präsentationen mit Java anpassen
linktitle: Datentabelle
type: docs
url: /de/java/chart-data-table/
keywords:
- Diagrammdaten
- Datentabelle
- Schrifteigenschaften
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Passen Sie Diagrammdatentabellen in Java für PPT und PPTX mit Aspose.Slides an, um Effizienz und Attraktivität in Präsentationen zu steigern."
---

## **Schrifteigenschaften für Diagrammdatentabelle festlegen**
Aspose.Slides für Java bietet Unterstützung zum Ändern der Farbe von Kategorien in einer Serienfarbe.

1. Instanziieren Sie das Klassenobjekt [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Fügen Sie dem Folie ein Diagramm hinzu.
1. Diagrammtabelle festlegen.
1. Schriftgröße festlegen.
1. Speichern Sie die geänderte Präsentation.

Unten finden Sie ein Beispiel.  
```java
// Leere Präsentation erstellen
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


## **FAQ**

**Kann ich kleine Legenden‑Schlüssel neben den Werten in der Datentabelle des Diagramms anzeigen?**

Ja. Die Datentabelle unterstützt [Legenden‑Schlüssel](https://reference.aspose.com/slides/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-), und Sie können sie ein‑ oder ausschalten.

**Wird die Datentabelle beim Exportieren der Präsentation in PDF, HTML oder Bilder beibehalten?**

Ja. Aspose.Slides rendert das Diagramm als Teil der Folie, sodass das exportierte [PDF](/slides/de/java/convert-powerpoint-to-pdf/)/[HTML](/slides/de/java/convert-powerpoint-to-html/)/[image](/slides/de/java/convert-powerpoint-to-png/) das Diagramm mit seiner Datentabelle enthält.

**Werden Datentabellen für Diagramme unterstützt, die aus einer Vorlagendatei stammen?**

Ja. Für jedes Diagramm, das aus einer vorhandenen Präsentation oder Vorlage geladen wird, können Sie mithilfe der Diagrammeigenschaften prüfen und ändern, ob eine Datentabelle [angezeigt wird](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--).

**Wie kann ich schnell herausfinden, welche Diagramme in einer Datei die Datentabelle aktiviert haben?**

Prüfen Sie die Eigenschaft jedes Diagramms, die anzeigt, ob die Datentabelle [angezeigt wird](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--), und iterieren Sie über die Folien, um die Diagramme zu identifizieren, bei denen sie aktiviert ist.