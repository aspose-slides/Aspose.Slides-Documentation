---
title: Maak Excel-grafieken en embed ze in presentaties als OLE-objecten
type: docs
weight: 50
url: /nl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-grafiek
- grafiek embedden
- OLE-object
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak Excel-grafieken en embed ze als OLE-objecten in PowerPoint- en OpenDocument-presentaties met C#/.NET. Stapsgewijze handleiding met codevoorbeelden."
---
## **Achtergrond**

In PowerPoint is het gebruik van bewerkbare grafieken om gegevens grafisch weer te geven een gangbare praktijk. Aspose ondersteunt het maken van Excel‑grafieken met Aspose.Cells voor .NET, en deze grafieken kunnen vervolgens als OLE‑objecten in PowerPoint‑dia's worden ingebed via Aspose.Slides voor .NET. Dit artikel behandelt de noodzakelijke stappen en biedt C#‑codevoorbeelden voor het maken van een Excel‑grafiek en het embedden ervan als OLE‑object in een PowerPoint‑presentatie met behulp van Aspose.Cells en Aspose.Slides.

## **Vereiste stappen**

De volgende reeks stappen is vereist om een Excel‑grafiek te maken en als OLE‑object in een PowerPoint‑dia te embedden:

1. Maak een Excel‑grafiek met Aspose.Cells.
1. Stel de OLE‑grootte van de Excel‑grafiek in met Aspose.Cells.
1. Haal een afbeelding van de Excel‑grafiek op met Aspose.Cells.
1. Embed de Excel‑grafiek als OLE‑object in een PPTX‑presentatie met Aspose.Slides.
1. Vervang de afbeelding "EMBEDDED OLE OBJECT" door de afbeelding verkregen in stap 3 om het [object preview issue](/slides/nl/net/object-preview-issue-when-adding-oleobjectframe/) op te lossen.
1. Sla de presentatie op schijf op in PPTX‑formaat.

## **Implementatie van de vereiste stappen**

De C#‑implementatie van de bovenstaande stappen is als volgt:

```cs
// Stap - 1: Maak een Excel-grafiek met Aspose.Cells.
// ---------------------------------------------------
// Maak een werkmap.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Voeg een Excel-grafiek toe.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Stap - 2: Stel de OLE-grootte van de grafiek in met Aspose.Cells.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// Stap - 3: Haal de afbeelding van de grafiek op met Aspose.Cells.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// Save the workbook to a stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Stap - 4 EN 5
// ==============
// Stap - 4: Embed de grafiek als OLE-object in een .ppt-presentatie met Aspose.Slides.
// ------------------------------------------------------------------------------------------
// Stap - 5: Vervang de afbeelding "EMBEDDED OLE OBJECT" door de afbeelding verkregen in stap 3 om het Object Preview Issue op te lossen.
// --------------------------------------------------------------------------------------------------------------------
// Create a presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // Voeg de werkmap toe aan de dia.
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // Stap - 6: Sla de uiteindelijke presentatie op schijf.
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // Een array van celnamen.
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Een array van celwaarden.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Voeg een nieuw werkblad toe om cellen te vullen met data.
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // Vul het gegevensblad met data.
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // Voeg een grafiekblad toe.
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // Voeg een grafiek toe aan het grafiekblad met gegevensreeksen uit het gegevensblad.
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // Stel het grafiekblad in als actief blad.
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

De presentatie die met bovenstaande methode wordt aangemaakt, bevat de Excel‑grafiek als OLE‑object dat geactiveerd kan worden door dubbel te klikken op het OLE‑objectframe.

## **Conclusie**

Door Aspose.Cells voor .NET te gebruiken in combinatie met Aspose.Slides voor .NET, kunnen we elke door Aspose.Cells ondersteunde Excel‑grafiek maken en de grafiek embedden als OLE‑object in een PowerPoint‑dia. De OLE‑grootte van de Excel‑grafiek kan ook worden gedefinieerd. Eindgebruikers kunnen vervolgens de Excel‑grafiek bewerken zoals elk ander OLE‑object.

## **Gerelateerde secties**

- [Werkende oplossing voor grafiekgrootte aanpassen in PPTX](/slides/nl/net/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/nl/net/object-preview-issue-when-adding-oleobjectframe/)
- [OLE-objecten automatisch bijwerken met een PowerPoint-add-in](/slides/nl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)