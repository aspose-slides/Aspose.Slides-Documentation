---
title: Funktionale Lösung für die Größenänderung von Arbeitsblättern
type: docs
weight: 40
url: /de/net/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

Es wurde beobachtet, dass in eine PowerPoint-Präsentation eingebettete Excel-Arbeitsblätter als OLE über Aspose-Komponenten nach der ersten Aktivierung auf einem unbekannten Maßstab skaliert werden. Dieses Verhalten erzeugt einen erheblichen visuellen Unterschied der Präsentation zwischen dem Zustand vor und nach der Diagrammaktivierung. Wir haben dieses Problem im Detail untersucht und die Lösung für dieses Problem gefunden, die in diesem Artikel behandelt wird.

{{% /alert %}} 
## **Hintergrund**
Im [Artikel „Ole-Frames hinzufügen“]() haben wir erklärt, wie man ein Ole-Frame in einer PowerPoint-Präsentation mit Aspose.Slides für .NET hinzufügt. Um das [Problem „Objekt geändert“](/slides/de/net/object-changed-issue-when-adding-oleobjectframe/) zu berücksichtigen, haben wir das Arbeitsblattbild des ausgewählten Bereichs dem Chart OLE-Objekt-Frame zugewiesen. In der Ausgangspräsentation wird das Excel-Diagramm aktiviert, wenn wir doppelt auf den OLE-Objekt-Frame klicken, der das Arbeitsblattbild zeigt. Die Endbenutzer können alle gewünschten Änderungen in der tatsächlichen Excel-Arbeitsmappe vornehmen und dann zur betreffenden Folie zurückkehren, indem sie außerhalb der aktivierten Excel-Arbeitsmappe klicken. Die Größe des OLE-Objekt-Frames ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor wird für unterschiedliche Größen von OLE-Objekt-Frames und eingebetteten Excel-Arbeitsmappen unterschiedlich sein.

## **Ursache der Größenänderung**
Da die Excel-Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie, ihre ursprüngliche Größe bei der ersten Aktivierung beizubehalten. Andererseits hat der OLE-Objekt-Frame seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Excel-Arbeitsmappe die Größe und stellen sicher, dass sie im richtigen Verhältnis als Teil des Einbettungsprozesses ist. Basierend auf den Unterschieden in der Fenstergröße von Excel und der Größe / Position des OLE-Objekt-Frames erfolgt die Größenänderung. 

## **Funktionale Lösung**
Es gibt zwei mögliche Lösungen, um den Größenänderungseffekt zu vermeiden.

- Die Größe des Ole-Frames in PPT anpassen, um die Größe in Bezug auf die Höhe/Breite der gewünschten Anzahl von Zeilen/Spalten im Ole-Frame zu entsprechen.
- Die Größe des Ole-Frames konstant halten und die Größe der beteiligten Zeilen/Spalten anpassen, um in die ausgewählte Ole-Frame-Größe zu passen.

## **Ole-Frame-Größe an die ausgewählten Zeilen/Spalten der Arbeitsmappe anpassen**
In diesem Ansatz lernen wir, wie man die Ole-Frame-Größe der eingebetteten Excel-Arbeitsmappe entsprechend der kumulierten Größe der Anzahl der beteiligten Zeilen und Spalten im Excel-Arbeitsblatt festlegt.

## **Beispiel**
Angenommen, wir haben ein Excel-Vorlagendokument definiert und möchten dieses als Ole-Frame in die Präsentation einfügen. In diesem Fall wird die Größe des OLE-Objekt-Frames zuerst basierend auf der kumulierten Höhe der Zeilen und der Breite der Spalten der beteiligten Arbeitsbuchzeilen und -spalten berechnet. Anschließend setzen wir die Größe des Ole-Frames auf den berechneten Wert. Um die rote **Eingebettetes Objekt**-Meldung für den Ole-Frame in PowerPoint zu vermeiden, werden wir auch das Bild der gewünschten Teile der Zeilen und Spalten in der Arbeitsmappe abrufen und dieses als Ole-Frame-Bild festlegen.

```csharp
WorkbookDesigner workbookDesigner = new WorkbookDesigner();
workbookDesigner.Workbook = new Workbook("AsposeTest.xls");

Presentation presentation = new Presentation("AsposeTest.ppt");

Slide slide = (Slide)presentation.Slides[0];

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

String fileName = "AsposeTest_Ole.ppt";
presentation.Save(fileName, Aspose.Slides.Export.SaveFormat.Ppt);
```

```csharp
private static Size SetOleAccordingToSelectedRowsCloumns(Workbook workbook, Int32 startRow, Int32 endRow, Int32 startCol,Int32 endCol, Int32 dataSheetIdx)
{
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    double actualHeight = 0, actualWidth = 0;

    for (int i = startRow; i <= endRow; i++)
        actualHeight += work.Cells.GetRowHeightInch(i);

    for (int i = startCol; i <= endCol; i++)
        actualWidth += work.Cells.GetColumnWidthInch(i);
    //Neue Zeilen- und Spaltenhöhe setzen

    return new Size((int)(Math.Round(actualWidth, 2) * 576), (int)(Math.Round(actualHeight, 2) * 576));
}
```
```csharp
private static void AddOleFrame(Slide slide, Int32 startRow, Int32 endRow, Int32 startCol, Int32 endCol,
    Int32 dataSheetIdx, Int32 x, Int32 y, Double OleWidth, Double OleHeight,
    Presentation presentation, WorkbookDesigner workbookDesigner,
    Boolean onePagePerSheet, Int32 outputWidth, Int32 outputHeight)
{
    String tempFileName = Path.GetTempFileName();
    if (startRow == 0)
    {
        startRow++;
        endRow++;
    }

    //Aktiven Blattindex der Arbeitsmappe festlegen
    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //Arbeitsmappe und ausgewähltes Arbeitsblatt abrufen  
    Workbook workbook = workbookDesigner.Workbook;
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    //OLE-Größe basierend auf den ausgewählten Zeilen und Spalten festlegen
    Size SlideOleSize = SetOleAccordingToSelectedRowsCloumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.Width;
    OleHeight = SlideOleSize.Height;

    //OLE-Größe in der Arbeitsmappe festlegen
    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;

    //Bildeinstellungen festlegen, um das Arbeitsblattbild zu erfassen
    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;

    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);
    String ext = ".bmp";
    render.ToImage(0, tempFileName + ext);
    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);
    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;
    image.Save(newTempFileName, System.Drawing.Imaging.ImageFormat.Bmp);

    //Bild zur Folienbildersammlung hinzufügen
    var ppImage = presentation.Images.AddImage(File.ReadAllBytes(newTempFileName));

    //Arbeitsmappe in einen Stream speichern und in ein Byte-Array kopieren
    Stream mstream = workbook.SaveToStream();
    byte[] chartOleData = new byte[mstream.Length];
    mstream.Position = 0;
    mstream.Read(chartOleData, 0, chartOleData.Length);

    //OLE-Objekt-Frame hinzufügen
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),
        Convert.ToInt32(OleHeight), dataInfo);

    //OLE-Frame-Bild und Alternativtext-Eigenschaft festlegen    
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    oleObjectFrame.AlternativeText = "image" + ppImage;
}
```

```csharp
private static Image ScaleImage(Image image, Int32 outputWidth, Int32 outputHeight)
{
    if (outputWidth == 0 && outputHeight == 0)
    {
        outputWidth = image.Width;
        outputHeight = image.Height;
    }
    Bitmap outputImage = new Bitmap(outputWidth, outputHeight, image.PixelFormat);
    outputImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    Graphics graphics = Graphics.FromImage(outputImage);
    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    System.Drawing.Rectangle srcDestRect = new System.Drawing.Rectangle(0, 0, outputWidth, outputHeight);
    graphics.DrawImage(image, srcDestRect, srcDestRect, GraphicsUnit.Pixel);
    graphics.Dispose();

    return outputImage;
}
```

## **Größenänderung der Zeilenhöhe und Spaltenbreite des Arbeitsblatts entsprechend der Ole-Frame-Größe**
In diesem Ansatz lernen wir, wie man die Höhen der beteiligten Zeilen und die Breite der beteiligten Spalten gemäß der benutzerdefinierten Ole-Frame-Größe ändert.

## **Beispiel**
Angenommen, wir haben ein Excel-Vorlagendokument definiert und möchten dieses als Ole-Frame in die Präsentation einfügen. In diesem Fall setzen wir die Größe des Ole-Frames und skalieren die Größe der Zeilen und Spalten, die im Ole-Frame-Bereich beteiligt sind. Wir speichern dann die Arbeitsmappe im Stream, um Änderungen zu speichern, und konvertieren sie in ein Byte-Array, um sie im Ole-Frame hinzuzufügen. Um die rote **Eingebettetes Objekt**-Meldung für den Ole-Frame in PowerPoint zu vermeiden, werden wir auch das Bild der gewünschten Teile der Zeilen und Spalten in der Arbeitsmappe abrufen und dieses als Ole-Frame-Bild festlegen.

```csharp
WorkbookDesigner workbookDesigner = new WorkbookDesigner();
workbookDesigner.Workbook = new Workbook("AsposeTest.xls");

Presentation presentation = new Presentation("AsposeTest.ppt");

Slide slide = (Slide)presentation.Slides[0];

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

String fileName = "AsposeTest_Ole.ppt";
presentation.Save(fileName, Aspose.Slides.Export.SaveFormat.Ppt);
```

```csharp
private static void SetOleAccordingToCustomHeighWidth(Workbook workbook, Int32 startRow,
    Int32 endRow, Int32 startCol, Int32 endCol, double slideWidth, double slideHeight, Int32 dataSheetIdx)
{
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    double actualHeight = 0, actualWidth = 0;

    double newHeight = slideHeight;
    double newWidth = slideWidth;
    double tem = 0;
    double newTem = 0;

    for (int i = startRow; i <= endRow; i++)
        actualHeight += work.Cells.GetRowHeightInch(i);

    for (int i = startCol; i <= endCol; i++)
        actualWidth += work.Cells.GetColumnWidthInch(i);
    //Neue Zeilen- und Spaltenhöhe setzen

    for (int i = startRow; i <= endRow; i++)
    {
        tem = work.Cells.GetRowHeightInch(i);
        newTem = (tem / actualHeight) * newHeight;
        work.Cells.SetRowHeightInch(i, newTem);
    }

    for (int i = startCol; i <= endCol; i++)
    {
        tem = work.Cells.GetColumnWidthInch(i);
        newTem = (tem / actualWidth) * newWidth;
        work.Cells.SetColumnWidthInch(i, newTem);
    }
}
```

```csharp
private static void AddOleFrame(Slide slide, Int32 startRow, Int32 endRow, Int32 startCol, Int32 endCol,
    Int32 dataSheetIdx, Int32 x, Int32 y, Double OleWidth, Double OleHeight,
    Presentation presentation, WorkbookDesigner workbookDesigner,
    Boolean onePagePerSheet, Int32 outputWidth, Int32 outputHeight)
{
    String tempFileName = Path.GetTempFileName();
    if (startRow == 0)
    {
        startRow++;
        endRow++;
    }

    //Aktiven Blattindex der Arbeitsmappe festlegen
    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //Arbeitsmappe und ausgewähltes Arbeitsblatt abrufen  
    Workbook workbook = workbookDesigner.Workbook;
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    //OLE-Größe basierend auf den ausgewählten Zeilen und Spalten festlegen
    Size SlideOleSize = SetOleAccordingToSelectedRowsCloumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.Width;
    OleHeight = SlideOleSize.Height;

    //OLE-Größe in der Arbeitsmappe festlegen
    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;

    //Bildeinstellungen festlegen, um das Arbeitsblattbild zu erfassen
    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;

    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);
    String ext = ".bmp";
    render.ToImage(0, tempFileName + ext);
    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);
    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;
    image.Save(newTempFileName, System.Drawing.Imaging.ImageFormat.Bmp);

    //Bild zur Folienbildersammlung hinzufügen
    var ppImage = presentation.Images.AddImage(File.ReadAllBytes(newTempFileName));

    //Arbeitsmappe in einen Stream speichern und in ein Byte-Array kopieren
    Stream mstream = workbook.SaveToStream();
    byte[] chartOleData = new byte[mstream.Length];
    mstream.Position = 0;
    mstream.Read(chartOleData, 0, chartOleData.Length);

    //OLE-Objekt-Frame hinzufügen
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),
        Convert.ToInt32(OleHeight), dataInfo);

    //OLE-Frame-Bild und Alternativtext-Eigenschaft festlegen    
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    oleObjectFrame.AlternativeText = "image" + ppImage;
}
```

```csharp
private static Image ScaleImage(Image image, Int32 outputWidth, Int32 outputHeight)
{
    if (outputWidth == 0 && outputHeight == 0)
    {
        outputWidth = image.Width;
        outputHeight = image.Height;
    }
    Bitmap outputImage = new Bitmap(outputWidth, outputHeight, image.PixelFormat);
    outputImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    Graphics graphics = Graphics.FromImage(outputImage);
    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    System.Drawing.Rectangle srcDestRect = new System.Drawing.Rectangle(0, 0, outputWidth, outputHeight);
    graphics.DrawImage(image, srcDestRect, srcDestRect, GraphicsUnit.Pixel);
    graphics.Dispose();

    return outputImage;
}
```

## **Fazit**

{{% alert color="primary" %}} Es gibt zwei Ansätze zur Behebung des Problems mit der Größenänderung des Arbeitsblatts. Die Auswahl des geeigneten Ansatzes hängt von den Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren auf dieselbe Weise, unabhängig davon, ob die Präsentationen aus einer Vorlage oder von Grund auf neu erstellt werden. Außerdem gibt es in der Lösung keine Begrenzung der Größe des OLE-Objekt-Frames. {{% /alert %}} 
## **Verwandte Abschnitte**
[Erstellen und Einfügen eines Excel-Diagramms als OLE-Objekt in die Präsentation](/slides/de/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE-Objekte automatisch aktualisieren](/slides/de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)