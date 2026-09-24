---
title: Diagrammdaten‑tabellen in Präsentationen mit JavaScript anpassen
linktitle: Daten‑tabelle
type: docs
url: /de/nodejs-java/chart-data-table/
keywords:
- Diagrammdaten
- Daten‑tabelle
- Schrifteigenschaften
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Diagrammdaten‑tabellen, Rahmen und Legenden‑Schlüssel in PowerPoint‑Präsentationen mit Aspose.Slides für Node.js über Java anpassen."
---
## **Übersicht**

Aspose.Slides für Node.js über Java ermöglicht das Anzeigen einer Diagrammdaten‑tabelle und das Anpassen von Textformatierung, Rahmen und Legenden‑Schlüsseln. Dieser Artikel erklärt, wie man die Tabelle aktiviert, ihren Text formatiert, jede Art von Rahmen steuert und Legenden‑Schlüssel ein‑ oder ausblendet. Die Beispiele speichern die konfigurierten Diagramme in PPTX‑Dateien.

## **Schriftattribute festlegen**

Um die Daten‑tabelle eines Diagramms anzuzeigen, übergeben Sie `true` an [setDataTable](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/setdatatable/). Verwenden Sie [getChartDataTable](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/getchartdatatable/), um auf die Tabelle zuzugreifen und deren Textformatierung zu konfigurieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) .
2. Fügen Sie der ersten Folie ein gruppiertes Säulendiagramm hinzu.
3. Aktivieren Sie die Daten‑tabelle des Diagramms.
4. Aktivieren Sie fettgedruckten Text mit [setFontBold](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setfontbold) und übergeben Sie `20` an [setFontHeight](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setfontheight) für Text mit 20 Punkt.
5. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel erfordert `input.pptx` im Arbeitsverzeichnis mit mindestens einer Folie. Es fügt ein Diagramm mit Standarddaten an der Position (50, 50) hinzu, mit einer Breite von 600 Punkten und einer Höhe von 400 Punkten. Die gespeicherte `output.pptx` enthält das Diagramm mit aktivierter Daten‑tabelle und den angegebenen Schriftarteinstellungen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Daten‑tabellen‑rahmen anpassen**

Aktivieren Sie die Tabelle mit [Chart.setDataTable](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/setdatatable/) und greifen Sie über [Chart.getChartDataTable](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/getchartdatatable/) darauf zu. Sie können drei Arten von Rahmen unabhängig steuern:

- [setBorderHorizontal](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/datatable/setborderhorizontal/) steuert horizontale Zellenrahmen.
- [setBorderVertical](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/datatable/setbordervertical/) steuert vertikale Zellenrahmen.
- [setBorderOutline](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/datatable/setborderoutline/) steuert den äußeren Rahmen der Tabelle.

Übergeben Sie `true` an jede Methode, um deren Rahmen anzuzeigen, oder `false`, um sie auszublenden. Das folgende Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten, zeigt horizontale Rahmen und den äußeren Rahmen an und blendet vertikale Rahmen aus. Es benötigt keine Eingabedatei. Position und Größe des Diagramms werden in Punkten angegeben.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der Vergleich unten verwendet dieselben Diagrammdaten und dieselbe Legenden‑Schlüssel‑Einstellung in allen vier Fällen. Ausgangspunkt ist ein Diagramm mit allen aktivierten Rahmen; jede weitere Variante deaktiviert jeweils genau einen Rahmentyp. Die Variante unten links entspricht den Rahmeneinstellungen des Beispiels.

![Diagrammdaten‑tabellen mit allen Rahmen aktiviert, keine horizontalen Rahmen, keine vertikalen Rahmen und kein äußerer Rahmen](data-table-borders.png)

## **Legenden‑Schlüssel ein‑ oder ausblenden**

Legenden‑Schlüssel sind kleine farbige Markierungen neben den Seriennamen in der Daten‑tabelle. Sie helfen den Lesern, jede Tabellenzeile einer Diagrammserie zuzuordnen. Übergeben Sie `true` an [setShowLegendKey](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/datatable/setshowlegendkey/), um diese Markierungen anzuzeigen, oder `false`, um sie zu verbergen.

Die separate Legende des Diagramms wird über [Chart.setLegend](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/setlegend/) gesteuert. Diese Einstellungen sind unabhängig: Das Verbergen der separaten Legende blendet die Schlüssel in der Daten‑tabelle nicht aus, und das Verbergen der Tabellenschlüssel blendet die separate Legende nicht aus.

Das folgende Beispiel erstellt ein Diagramm mit Standarddaten, aktiviert dessen Daten‑tabelle und zeigt Legenden‑Schlüssel darin an, während die separate Legende ausgeblendet wird. Alle Tabellengrenzen sind explizit aktiviert. Es wird keine Eingabepräsentation benötigt. Um ausschließlich die Tabellenschlüssel zu verbergen, übergeben Sie `false` an [setShowLegendKey](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/datatable/setshowlegendkey/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der Vergleich unten zeigt dieselbe Tabelle mit aktivierten und deaktivierten Legenden‑Schlüsseln. Alle Rahmen bleiben aktiviert, und die separate Diagrammlegende ist in beiden Fällen ausgeblendet.

![Diagrammdaten‑tabellen mit Legenden‑Schlüsseln links angezeigt und rechts ausgeblendet](data-table-legend-keys.png)

## **FAQ**

**Kann ich Legenden‑Schlüssel in der Daten‑tabelle eines Diagramms anzeigen?**

Ja. Übergeben Sie `true` an [setShowLegendKey](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/datatable/setshowlegendkey/), um Legenden‑Schlüssel anzuzeigen, oder `false`, um sie zu verbergen.

**Wird die Daten‑tabelle beim Exportieren der Präsentation nach PDF, HTML oder Bildern erhalten bleiben?**

Ja. Aspose.Slides rendert das Diagramm und seine angezeigte Daten‑tabelle als Teil der Folie beim Export nach [PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/de/nodejs-java/convert-powerpoint-to-html/) oder [Bildern](/slides/de/nodejs-java/convert-powerpoint-to-png/).

**Kann ich mit Daten‑tabellen in Diagrammen arbeiten, die aus einer Vorlage geladen wurden?**

Ja. Für ein Diagramm, das aus einer bestehenden Präsentation oder Vorlage geladen wurde, verwenden Sie [hasDataTable](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/hasdatatable/) und [setDataTable](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/setdatatable/), um zu prüfen oder zu ändern, ob seine Daten‑tabelle angezeigt wird.

**Wie kann ich Diagramme finden, bei denen die Daten‑tabelle aktiviert ist?**

Iterieren Sie über die Shapes jeder Folie, identifizieren Sie die Diagramme und rufen Sie deren [hasDataTable](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/hasdatatable/)‑Methode auf. Der Rückgabewert `true` bedeutet, dass die Daten‑tabelle aktiviert ist.