---
title: Erstellen eines Excel-Diagramms und Einbetten als OLE-Objekt in eine Präsentation
type: docs
weight: 50
url: /net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

In PowerPoint-Folien ist die Verwendung von bearbeitbaren Diagrammen zur grafischen Darstellung der Daten eine gängige Praxis. Aspose unterstützt die Erstellung von Excel-Diagrammen mit Aspose.Cells für .NET, und diese Diagramme können anschließend als OLE-Objekt in der PowerPoint-Folie über Aspose.Slides für .NET eingebettet werden. Dieser Artikel behandelt die erforderlichen Schritte sowie die Implementierung in C# und VB.NET, um ein MS Excel-Diagramm als OLE-Objekt in einer PowerPoint-Präsentation mithilfe von Aspose.Cells für .NET und Aspose.Slides für .NET zu erstellen und einzubetten.

{{% /alert %}} 
## **Erforderliche Schritte**
Die folgenden Schritte sind erforderlich, um ein Excel-Diagramm als OLE-Objekt in die PowerPoint-Folie einzufügen:

1. Erstellen Sie ein Excel-Diagramm mit Aspose.Cells für .NET.
2. Setzen Sie die OLE-Größe des Excel-Diagramms mit Aspose.Cells für .NET.
3. Erhalten Sie das Bild des Excel-Diagramms mit Aspose.Cells für .NET.
4. Betten Sie das Excel-Diagramm als OLE-Objekt in die PPTX-Präsentation mithilfe von Aspose.Slides für .NET ein.
5. Ersetzen Sie das geänderte Objektbild durch das in Schritt 3 erhaltene Bild, um das Problem mit dem geänderten Objekt zu beheben.
6. Schreiben Sie die Ausgabepräsentation im PPTX-Format auf die Festplatte.

## **Implementierung der erforderlichen Schritte**
Die Implementierung der obigen Schritte in C# und Visual Basic ist wie folgt:

```c#
//Schritt - 1: Erstellen Sie ein Excel-Diagramm mit Aspose.Cells
//--------------------------------------------------
//Workbook erstellen
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Ein Excel-Diagramm hinzufügen
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Schritt - 2: Setzen Sie die OLE-Größe des Diagramms mit Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Schritt - 3: Erhalten Sie das Bild des Diagramms mit Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Workbook auf Stream speichern
MemoryStream wbStream = wb.SaveToStream();
//Schritt - 4 UND 5
//-----------------------------------------------------------
//Schritt - 4: Betten Sie das Diagramm als OLE-Objekt in .ppt-Präsentation mit Aspose.Slides ein
//-----------------------------------------------------------
//Schritt - 5: Ersetzen Sie das geänderte Objektbild durch das in Schritt 3 erhaltene Bild, um das Problem mit dem geänderten Objekt zu beheben
//-----------------------------------------------------------
//Erstellen Sie eine Präsentation
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Fügen Sie das Workbook zur Folie hinzu
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Schritt - 6: Schreiben Sie die Ausgabepräsentation auf die Festplatte
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook wb, int chartRows, int chartCols)
{
    //Array von Zellennamen
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Array von Zellendaten
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Fügen Sie ein neues Arbeitsblatt hinzu, um Zellen mit Daten zu füllen
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "Datenblatt";
    dataSheet.Name = sheetName;
    //Datenblatt mit Daten füllen
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Fügen Sie ein Diagrammblatt hinzu
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "Diagrammblatt";
    //Fügen Sie ein Diagramm im Diagrammblatt mit Datenreihen aus dem Datenblatt hinzu
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Setzen Sie das Diagrammblatt als aktives Blatt
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```

```c#
static void AddExcelChartInPresentation(Presentation pres, ISlide sld, Stream wbStream, Bitmap imgChart)
{
    float oleWidth = pres.SlideSize.Size.Width;
    float oleHeight = pres.SlideSize.Size.Height;

    byte[] chartOleData = new byte[wbStream.Length];
    wbStream.Position = 0;
    wbStream.Read(chartOleData, 0, chartOleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oof = sld.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        imgChart.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	imageStream.Position = 0;
        IPPImage ppImage = pres.Images.AddImage(imageStream);

        oof.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

{{% alert color="primary" %}} 

Die durch die obige Methode erstellte Präsentation wird das Excel-Diagramm als OLE-Objekt enthalten, das durch Doppelklicken auf den OLE-Objekt-Rahmen aktiviert werden kann.

{{% /alert %}} 
## **Fazit**
{{% alert color="primary" %}} 

Durch die Verwendung von Aspose.Cells für .NET zusammen mit Aspose.Slides für .NET können wir eines der von Aspose.Cells für .NET unterstützten Excel-Diagramme erstellen und das erstellte Diagramm als OLE-Objekt in einer PowerPoint-Folie einbetten. Die OLE-Größe des Excel-Diagramms kann ebenfalls definiert werden. Die Endbenutzer können das Excel-Diagramm wie jedes andere OLE-Objekt weiterbearbeiten.

{{% /alert %}} 
## **Verwandte Abschnitte**
[Funktionsfähige Lösung für Diagrammgrößenänderung](/slides/net/working-solution-for-chart-resizing-in-pptx/)[Problem mit geändertem Objekt](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)