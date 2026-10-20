---
title: Excel-Diagramme erstellen und sie in Präsentationen als OLE-Objekte einbetten
type: docs
weight: 50
url: /de/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-Diagramm
- Diagramm einbetten
- OLE-Objekt
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen Sie ein Excel-Diagramm mit Aspose.Cells für .NET und betten Sie die Arbeitsmappe in eine PowerPoint-Präsentation mit Aspose.Slides ein, einschließlich einer Diagramm-Vorschau."
---
## **Übersicht**

Dieser Artikel zeigt, wie man ein Excel‑Säulendiagramm mit Aspose.Cells für .NET erstellt und dessen Arbeitsmappe in eine PowerPoint‑Präsentation mit Aspose.Slides für .NET einbettet. Die eingebettete Arbeitsmappe enthält sowohl die Quelldaten als auch das Diagramm. Eine separate PNG‑Vorschau zeigt das Diagramm auf der Folie, bevor das OLE‑Objekt aktiviert wird.

Das Ergebnis ist ein eingebettetes Excel‑Objekt, kein natives PowerPoint‑Diagramm. Das Bearbeiten der Arbeitsmappe über OLE erfordert eine Desktop‑Anwendung, die OLE‑Aktivierung unterstützt, sowie eine kompatible Excel‑Installation.

## **Voraussetzungen**

Fügen Sie Ihrem C#‑Projekt Verweise auf Aspose.Cells für .NET und Aspose.Slides für .NET hinzu. Das Beispiel verwendet Top‑Level‑Statements und erfordert C# 9 oder höher. Microsoft Office ist nicht erforderlich, um die Präsentation mit diesen Bibliotheken zu erzeugen.

Es werden keine Eingabedateien benötigt: Das Beispiel erstellt die Daten und das Diagramm im Speicher und schreibt anschließend `OutputChart.pptx` in das aktuelle Arbeitsverzeichnis. Aktivieren Sie Lizenzen für beide Produkte, wenn Sie außerhalb des Evaluierungsmodus arbeiten.

## **Wie die Einbettung funktioniert**

1. Erstellen Sie eine Arbeitsmappe mit einem Daten‑Arbeitsblatt und einem Diagrammblatt.  
1. Machen Sie das Diagrammblatt aktiv, sodass die Arbeitsmappe mit dem Diagramm geöffnet wird.  
1. Setzen Sie den OLE‑Anzeigebereich der Arbeitsmappe und rendern Sie das Diagramm als PNG.  
1. Speichern Sie die Arbeitsmappe als XLSX im Speicher und betten Sie diese Bytes in eine Folie ein.  
1. Weisen Sie das PNG als Vorschau des OLE‑Objekts zu und speichern Sie die Präsentation als PPTX.

Der Anzeigebereich der Arbeitsmappe und der Rahmen auf der Folie haben unterschiedliche Rollen. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) erwartet nullbasierte Start‑/End‑Zeilen‑ und Spaltenindizes. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) hingegen erwartet die oberste Zeile, linke Spalte, unterste Zeile und rechte Spalte. Das Beispiel verwendet den Zeilenindex 55 und den Spaltenindex 25 als untere rechte Grenze; diese Werte sind Layout‑Entscheidungen und nicht die Anzahl der Datenzeilen oder -spalten.

Der Folienrahmen verwendet Punkte. Das Beispiel passt ihn innerhalb der Folie an und zentriert ihn, wobei das Seitenverhältnis des PNG beibehalten wird, anstatt die Vorschau zu strecken, um die Folie auszufüllen.

## **Diagramm erstellen und einbetten**

Das folgende vollständige Beispiel füllt `DataSheet` mit vier Zeilen und fünf Spalten von Werten. Jede Zeile wird zu einer Diagrammserie. `ChartSheet` wird vor dem Speichern der Arbeitsmappe als aktives Blatt ausgewählt.

Die Arbeitsmappe wird explizit als XLSX gespeichert, sodass die `xlsx`‑Erweiterung, die an [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) übergeben wird, übereinstimmt. Das PNG wird direkt aus seinem Stream geladen, ohne eine Zwischenschritt‑Bitmap‑Konvertierung. Die Zuweisung über [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) ersetzt den Standard‑OLE‑Platzhalter.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// Rendern Sie die Diagrammvorschau und serialisieren Sie die editierbare Arbeitsmappe separat.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Fit the preview within the slide without changing its aspect ratio.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Erwartetes Ergebnis**

`OutputChart.pptx` enthält eine Folie mit einer eingebetteten Excel‑Arbeitsmappe und einer Diagramm‑Vorschau. Die Arbeitsmappe enthält die Originaldaten und ein Säulendiagramm mit vier Serien. Die Vorschau ist auf der Folie zentriert und behält ihre Proportionen bei.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

In einer kompatiblen Desktop‑PowerPoint‑Umgebung mit verfügbarem Excel kann das Objekt per Doppelklick aktiviert und die eingebettete Arbeitsmappe bearbeitet werden. Aktivierung und Bearbeitung hängen von der OLE‑Unterstützung und den Sicherheitseinstellungen der Host‑Anwendung ab.

## **FAQ**

**Warum wird ein Vorschaubild benötigt?**

Die eingebettete Arbeitsmappe und ihre Folien‑Vorschau sind getrennte Inhalte. Stellen Sie ein Diagrammbild bereit, damit die Folie das Diagramm anstelle des Standard‑„EMBEDDED OLE OBJECT“-Platzhalters zeigt. Siehe [Problem mit der Objektvorschau beim Hinzufügen von OleObjectFrame](/slides/de/net/object-preview-issue-when-adding-oleobjectframe/).

**Wird die Vorschau automatisch aktualisiert, wenn ich die Arbeitsmappe im Code ändere?**

Betrachten Sie die Vorschau als Momentaufnahme. Wenn Sie die Arbeitsmappendaten programmatisch aktualisieren, erzeugen Sie das Diagrammbild neu und ersetzen sowohl die Vorschau als auch die eingebetteten Arbeitsmappendaten.

**Kann ich XLS anstelle von XLSX verwenden?**

Ja. Speichern Sie die Arbeitsmappe im XLS‑Format und verwenden Sie `xls` als eingebettete Daten‑Erweiterung. Die Erweiterung muss dem tatsächlichen Arbeitsmappenformat entsprechen; das reine Ändern der Erweiterung konvertiert die Daten nicht.

**Warum könnte das Objekt nach der Aktivierung die Größe ändern?**

Die Host‑Anwendung kann die Darstellung des OLE‑Objekts aktualisieren, wenn sie die Arbeitsmappe aktiviert. Sowohl der OLE‑Anzeigebereich der Arbeitsmappe als auch die Folienrahmen‑Abmessungen spielen dabei eine Rolle. Siehe [Lösung für Diagrammgrößenanpassung in PPTX](/slides/de/net/working-solution-for-chart-resizing-in-pptx/).

## **Verwandte Abschnitte**

- [Lösung für Diagrammgrößenanpassung in PPTX](/slides/de/net/working-solution-for-chart-resizing-in-pptx/)
- [Problem mit der Objektvorschau beim Hinzufügen von OleObjectFrame](/slides/de/net/object-preview-issue-when-adding-oleobjectframe/)
- [OLE‑Objekte automatisch aktualisieren mit einem PowerPoint‑Add‑In](/slides/de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)