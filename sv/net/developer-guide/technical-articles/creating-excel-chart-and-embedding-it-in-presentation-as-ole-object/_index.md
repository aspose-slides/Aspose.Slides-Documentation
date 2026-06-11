---
title: Skapa Excel-diagram och bädda in dem i presentationer som OLE-objekt
type: docs
weight: 50
url: /sv/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- bädda in diagram
- OLE-objekt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa Excel-diagram och bädda in dem som OLE-objekt i PowerPoint- och OpenDocument-presentationer med C#/.NET. Steg‑för‑steg‑guide med kodexempel."
---
## **Bakgrund**

I PowerPoint är det vanligt att använda redigerbara diagram för att visuellt visa data. Aspose stödjer att skapa Excel-diagram med Aspose.Cells för .NET, och dessa diagram kan sedan bäddas in som OLE-objekt i PowerPoint‑bilder via Aspose.Slides för .NET. Denna artikel täcker de nödvändiga stegen och ger C#‑kodexempel för att skapa ett Excel-diagram och bädda in det som ett OLE‑objekt i en PowerPoint‑presentation med Aspose.Cells och Aspose.Slides.

## **Nödvändiga steg**

Följande sekvens av steg krävs för att skapa och bädda in ett Excel-diagram som ett OLE‑objekt i en PowerPoint‑bild:

1. Skapa ett Excel-diagram med Aspose.Cells.  
2. Ange OLE‑storleken för Excel-diagrammet med Aspose.Cells.  
3. Hämta en bild av Excel-diagrammet med Aspose.Cells.  
4. Bädda in Excel-diagrammet som ett OLE‑objekt i en PPTX‑presentation med Aspose.Slides.  
5. Byt ut bilden "EMBEDDED OLE OBJECT" mot bilden som erhölls i steg 3 för att lösa [objektförhandsgranskningsproblem](/slides/sv/net/object-preview-issue-when-adding-oleobjectframe/).  
6. Spara presentationen till disk i PPTX‑format.

## **Implementering av de nödvändiga stegen**

C#‑implementeringen av stegen ovan är som följer:

```cs
// Steg - 1: Skapa ett Excel-diagram med Aspose.Cells.
// ---------------------------------------------------
// Skapa en arbetsbok.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Lägg till ett Excel-diagram.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Steg - 2: Ange OLE-storleken för diagrammet med Aspose.Cells.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// Steg - 3: Hämta bilden av diagrammet med Aspose.Cells.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// Spara arbetsboken till en ström.
MemoryStream workbookStream = workbook.SaveToStream();

// Steg - 4 OCH 5
// ==============
 // Steg - 4: Bädda in diagrammet som ett OLE-objekt i en .ppt-presentation med Aspose.Slides.
// ------------------------------------------------------------------------------------------
// Steg - 5: Byt ut bilden "EMBEDDED OLE OBJECT" mot bilden som erhölls i steg 3 för att åtgärda problemet med objektförhandsgranskning.
// --------------------------------------------------------------------------------------------------------------------
 // Create a presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // Lägg till arbetsboken på bilden.
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // Steg - 6: Spara den färdiga presentationen till disk.
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // En array av cellnamn.
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // En array av cellvärden.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Lägg till ett nytt kalkylblad för att fylla celler med data.
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // Fyll dataarket med data.
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // Lägg till ett diagramark.
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // Lägg till ett diagram på diagramarket med dataserier från dataarket.
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // Ange diagramarket som ett aktivt blad.
    workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
    return chartSheetIndex;
}
```

```cs
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] oleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(oleData, 0, oleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

        imageStream.Position = 0;
        IPPImage ppImage = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

Presentation som skapas med metoden ovan kommer att innehålla Excel-diagrammet som ett OLE‑objekt som kan aktiveras genom att dubbelklicka på OLE‑objektets ram.

## **Slutsats**

Genom att använda Aspose.Cells för .NET tillsammans med Aspose.Slides för .NET kan vi skapa alla Excel-diagram som stöds av Aspose.Cells och bädda in diagrammet som ett OLE‑objekt i en PowerPoint‑bild. OLE‑storleken för Excel-diagrammet kan också definieras. Slutanvändare kan sedan redigera Excel-diagrammet precis som vilket annat OLE‑objekt som helst.

## **Relaterade avsnitt**

- [Fungerande lösning för diagramändring i PPTX](/slides/sv/net/working-solution-for-chart-resizing-in-pptx/)
- [Problem med förhandsgranskning av objekt när OleObjectFrame läggs till](/slides/sv/net/object-preview-issue-when-adding-oleobjectframe/)
- [Uppdatera OLE‑objekt automatiskt med ett PowerPoint‑tillägg](/slides/sv/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)