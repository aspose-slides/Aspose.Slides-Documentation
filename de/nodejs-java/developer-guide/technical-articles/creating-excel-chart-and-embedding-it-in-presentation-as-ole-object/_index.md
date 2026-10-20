---
title: Excel-Diagramme erstellen und als OLE-Objekte in Präsentationen einbetten
type: docs
weight: 30
url: /de/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-Diagramm
- Diagramm einbetten
- OLE-Objekt
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen Sie ein Excel-Diagramm mit Aspose.Cells für Node.js über Java und betten Sie die Arbeitsmappe in eine PowerPoint-Präsentation mit Aspose.Slides ein, inklusive einer Diagrammvorschau."
---
## **Übersicht**

Dieser Artikel zeigt, wie man ein Excel‑Säulendiagramm mit Aspose.Cells für Node.js über Java erstellt und dessen Arbeitsmappe in einer PowerPoint‑Präsentation mit Aspose.Slides für Node.js über Java einbettet. Die eingebettete Arbeitsmappe enthält sowohl die Quelldaten als auch das Diagramm. Eine separate PNG‑Vorschau zeigt das Diagramm auf der Folie, bevor das OLE‑Objekt aktiviert wird.

Das Ergebnis ist ein eingebettetes Excel‑Objekt, kein natives PowerPoint‑Diagramm. Das Bearbeiten der Arbeitsmappe über OLE erfordert eine Desktop‑Anwendung, die OLE‑Aktivierung unterstützt, sowie eine kompatible Excel‑Installation.

## **Voraussetzungen**

Installieren Sie die Node.js‑Pakete `aspose.cells`, `aspose.slides.via.java` und `java`. Führen Sie die Beispiele als zwei CommonJS‑Skripte in separaten Node.js‑Prozessen aus: zuerst `create-chart.js`, dann `embed-chart.js`, wobei das gleiche Arbeitsverzeichnis verwendet wird. Beide Aspose‑Pakete initialisieren die Java‑Brücke beim Laden, daher halten diese Beispiele sie in separaten Prozessen. Microsoft Office ist nicht erforderlich, um die Präsentation mit diesen Bibliotheken zu erzeugen.

Keine vorhandene Arbeitsmappe oder Bild ist erforderlich. Das erste Skript erstellt `ChartWorkbook.xlsx` und `ChartPreview.png`; das zweite liest diese Dateien und schreibt `OutputChart.pptx` in das aktuelle Arbeitsverzeichnis. Wenden Sie Lizenzen für beide Produkte an, wenn Sie außerhalb des Evaluierungsmodus arbeiten.

## **Wie das Einbetten funktioniert**

1. Erstellen Sie eine Arbeitsmappe mit einem Daten‑Arbeitsblatt und einem Diagrammblatt.  
1. Machen Sie das Diagrammblatt aktiv, damit die Arbeitsmappe mit dem Diagramm geöffnet wird.  
1. Setzen Sie den OLE‑Anzeige‑Bereich der Arbeitsmappe und rendern Sie das Diagramm nach PNG.  
1. Speichern Sie die Arbeitsmappe als XLSX und betten Sie ihre Bytes in einer Folie in einem separaten Node.js‑Prozess ein.  
1. Weisen Sie das PNG als Vorschau des OLE‑Objekts zu und speichern Sie die Präsentation als PPTX.  

Der Anzeigebereich der Arbeitsmappe und der Rahmen auf der Folie haben unterschiedliche Rollen. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) verwendet nullbasierte Start‑/End‑Zeilen‑ und Spaltenindizes. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) hingegen erwartet die obere Zeile, linke Spalte, untere Zeile und rechte Spalte. Das Beispiel verwendet Zeilenindex 55 und Spaltenindex 25 als untere‑rechte Grenze; diese Werte sind Layout‑Entscheidungen und nicht die Anzahl der Datenzeilen oder -spalten.

Der Folienrahmen verwendet Punkte. Das Beispiel passt ihn innerhalb der Folie an und zentriert ihn, während das Seitenverhältnis des PNG beibehalten wird, anstatt die Vorschau zu strecken, um die Folie auszufüllen.

## **Diagramm erstellen und einbetten**

Speichern Sie das erste Beispiel als `create-chart.js`. Es füllt `DataSheet` mit vier Zeilen und fünf Spalten von Werten. Jede Zeile wird zu einer Diagrammserie. `ChartSheet` wird vor dem Speichern der Arbeitsmappe als aktives Blatt ausgewählt.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // Diagrammvorschau rendern und die editierbare Arbeitsmappe separat serialisieren.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// Alle synchronen Vorgänge sind abgeschlossen; stoppen Sie den Java-Bridge-Prozess.
process.exit(0);
```

Speichern Sie das folgende Beispiel als `embed-chart.js`. Führen Sie es aus, nachdem `create-chart.js` beide Eingabedateien erstellt hat. Es zentriert den OLE‑Rahmen und behält das Seitenverhältnis des Vorschaubildes bei.

Das zweite Skript bettet die gespeicherte Arbeitsmappe ein und verwendet das PNG als Vorschau. Die Arbeitsmappe wird explizit als XLSX gespeichert, passend zur `xlsx`‑Erweiterung, die an [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/) übergeben wird. Das PNG wird direkt aus seinen Bytes geladen, ohne eine Zwischenkonvertierung in ein Bitmap. Die Java‑Brücke erfordert explizite Java‑Byte‑Arrays für das Bild und die Arbeitsmappendaten sowie Java‑Float‑Werte für die Koordinaten des Folienrahmens. Das Zuweisen über [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) ersetzt den Standard‑OLE‑Platzhalter.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // Passe die Vorschau innerhalb der Folie an, ohne das Seitenverhältnis zu ändern.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// Alle synchronen Vorgänge sind abgeschlossen; stoppen Sie den Java-Bridge-Prozess.
process.exit(0);
```

## **Erwartetes Ergebnis**

`OutputChart.pptx` enthält eine Folie mit einer eingebetteten Excel‑Arbeitsmappe und einer Diagrammvorschau. Die Arbeitsmappe enthält die Originaldaten und ein Säulendiagramm mit vier Serien. Die Vorschau ist auf der Folie zentriert und behält ihre Proportionen bei.

![Excel‑Säulendiagramm, angezeigt als Vorschau einer eingebetteten Arbeitsmappe](excel-chart-ole-preview.png)

In einer kompatiblen Desktop‑PowerPoint‑Umgebung mit verfügbarem Excel können Sie das Objekt doppelklicken, um die eingebettete Arbeitsmappe zu aktivieren und zu bearbeiten. Aktivierung und Bearbeitung hängen von der OLE‑Unterstützung und den Sicherheitseinstellungen der Host‑Anwendung ab.

## **FAQ**

**Warum wird ein Vorschaubild benötigt?**

Die eingebettete Arbeitsmappe und ihre Folienvorschau sind separate Inhalte. Stellen Sie ein Diagrammbild bereit, damit die Folie das Diagramm anzeigt, anstatt den Standard‑„EMBEDDED OLE OBJECT“-Platzhalter. Siehe [Problem mit der Objektvorschau beim Hinzufügen von OleObjectFrame](/slides/de/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**Aktualisiert sich die Vorschau automatisch, wenn ich die Arbeitsmappe im Code ändere?**

Betrachten Sie die Vorschau als Schnappschuss. Wenn Sie die Arbeitsmappendaten programmatisch aktualisieren, erzeugen Sie das Diagrammbild neu und ersetzen sowohl die Vorschau als auch die eingebetteten Arbeitsmappendaten.

**Kann ich XLS anstelle von XLSX verwenden?**

Ja. Speichern Sie die Arbeitsmappe im XLS‑Format und verwenden Sie `xls` als Erweiterung für die eingebetteten Daten. Die Erweiterung muss dem tatsächlichen Arbeitsmappenformat entsprechen; das alleinige Ändern der Erweiterung konvertiert die Daten nicht.

**Warum könnte sich das Objekt nach der Aktivierung in der Größe ändern?**

Die Host‑Anwendung kann die Darstellung des OLE‑Objekts aktualisieren, wenn sie die Arbeitsmappe aktiviert. Der OLE‑Anzeigebereich der Arbeitsmappe und die Abmessungen des Folienrahmens sind beide relevant. Siehe [Lösungsansatz für Diagrammgrößenänderung in PPTX](/slides/de/java/working-solution-for-chart-resizing-in-pptx/).

## **Verwandte Abschnitte**

- [Lösungsansatz für Diagrammgrößenänderung in PPTX](/slides/de/java/working-solution-for-chart-resizing-in-pptx/)
- [Problem mit der Objektvorschau beim Hinzufügen von OleObjectFrame](/slides/de/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)