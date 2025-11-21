---
title: Diagramm-Datentabelle
type: docs
url: /de/nodejs-java/chart-data-table/
---

## **Schriftart‑Eigenschaften für Diagramm‑Datentabelle festlegen**

Aspose.Slides für Node.js über Java bietet Unterstützung zum Ändern der Farbe von Kategorien in einer Serienfarbe.

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klassenobjekt.
1. Fügen Sie der Folie ein Diagramm hinzu.
1. Setzen Sie die Diagrammtabelle.
1. Setzen Sie die Schriftgröße.
1. Speichern Sie die modifizierte Präsentation.

Unten steht ein Beispiel.  
```javascript
// Leere Präsentation erstellen
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kann ich kleine Legenden‑Schlüssel neben den Werten in der Diagrammdaten‑tabelle anzeigen?**

Ja. Die Datentabelle unterstützt [Legenden‑Schlüssel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datatable/setshowlegendkey/), und Sie können sie ein- oder ausschalten.

**Wird die Datentabelle beim Exportieren der Präsentation in PDF, HTML oder Bilder beibehalten?**

Ja. Aspose.Slides rendert das Diagramm als Teil der Folie, sodass das exportierte [PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/de/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/de/nodejs-java/convert-powerpoint-to-png/) das Diagramm mit seiner Datentabelle enthält.

**Werden Datentabellen für Diagramme unterstützt, die aus einer Vorlagendatei stammen?**

Ja. Für jedes Diagramm, das aus einer bestehenden Präsentation oder Vorlage geladen wird, können Sie mithilfe der Diagrammeigenschaften prüfen und ändern, ob eine Datentabelle [angezeigt wird](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/hasdatatable/) angezeigt wird.

**Wie kann ich schnell herausfinden, welche Diagramme in einer Datei die Datentabelle aktiviert haben?**

Untersuchen Sie die Eigenschaft jedes Diagramms, die angibt, ob die Datentabelle [angezeigt wird](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/hasdatatable/) und durchlaufen Sie die Folien, um die Diagramme zu identifizieren, bei denen sie aktiviert ist.