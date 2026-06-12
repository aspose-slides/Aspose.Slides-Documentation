---
title: Vytvořte Excel grafy a vložte je do prezentací jako OLE objekty
type: docs
weight: 50
url: /cs/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel graf
- vložit graf
- OLE objekt
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvořte Excel grafy a vložte je jako OLE objekty do prezentací PowerPoint a OpenDocument pomocí C#/.NET. Průvodce krok za krokem s ukázkami kódu."
---
## **Pozadí**

V PowerPointu je běžné používat editovatelné grafy k zobrazování dat graficky. Aspose podporuje vytváření Excel grafů pomocí Aspose.Cells pro .NET a tyto grafy lze poté vložit jako OLE objekty do snímků PowerPointu prostřednictvím Aspose.Slides pro .NET. Tento článek popisuje potřebné kroky a poskytuje ukázky kódu v C# pro vytvoření Excel grafu a jeho vložení jako OLE objektu do prezentace PowerPoint pomocí Aspose.Cells a Aspose.Slides.

## **Požadované kroky**

Následující posloupnost kroků je potřeba k vytvoření a vložení Excel grafu jako OLE objektu do snímku PowerPointu:

1. Vytvořte Excel graf pomocí Aspose.Cells.
1. Nastavte velikost OLE objektu Excel grafu pomocí Aspose.Cells.
1. Získejte obrázek Excel grafu pomocí Aspose.Cells.
1. Vložte Excel graf jako OLE objekt do PPTX prezentace pomocí Aspose.Slides.
1. Nahraďte obrázek „EMBEDDED OLE OBJECT“ obrázkem získaným ve kroku 3, aby se vyřešil [problém s náhledem objektu](/slides/cs/net/object-preview-issue-when-adding-oleobjectframe/).
1. Uložte prezentaci na disk ve formátu PPTX.

## **Implementace požadovaných kroků**

Implementace v C# výše uvedených kroků vypadá takto:

```cs
// Krok - 1: Vytvořte Excel graf pomocí Aspose.Cells.
// ---------------------------------------------------
// Vytvořte sešit.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Přidejte Excel graf.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Krok - 2: Nastavte velikost OLE objektu grafu pomocí Aspose.Cells.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// Krok - 3: Získejte obrázek grafu pomocí Aspose.Cells.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// Uložte sešit do proudu.
MemoryStream workbookStream = workbook.SaveToStream();

// Krok - 4 A 5
// ==============
 // Krok - 4: Vložte graf jako OLE objekt do .ppt prezentace pomocí Aspose.Slides.
 // ------------------------------------------------------------------------------------------
 // Krok - 5: Nahraďte obrázek "EMBEDDED OLE OBJECT" obrázkem získaným ve kroku 3, aby se vyřešil problém s náhledem objektu.
 // --------------------------------------------------------------------------------------------------------------------
 // Vytvořte prezentaci.
 using (Presentation presentation = new Presentation())
 {
     ISlide slide = presentation.Slides[0];
     // Přidejte sešit do snímku.
     AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);
 
     // Krok - 6: Uložte výstupní prezentaci na disk.
     // -----------------------------------------------
     presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // Pole názvů buněk.
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Pole hodnot buněk.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Přidejte nový list pro naplnění buněk daty.
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // Naplňte datový list daty.
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // Přidejte list s grafem.
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // Přidejte graf do listu s grafem s datovými řadami z datového listu.
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // Nastavte list s grafem jako aktivní list.
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

Prezentace vytvořená výše uvedenou metodou bude obsahovat Excel graf jako OLE objekt, který lze aktivovat dvojitým kliknutím na rámec OLE objektu.

## **Závěr**

Pomocí Aspose.Cells pro .NET spolu s Aspose.Slides pro .NET můžeme vytvořit libovolný Excel graf podporovaný Aspose.Cells a vložit ho jako OLE objekt do snímku PowerPointu. Velikost OLE objektu Excel grafu lze také definovat. Koneční uživatelé pak mohou upravovat Excel graf jako jakýkoli jiný OLE objekt.

## **Související sekce**

- [Fungující řešení pro změnu velikosti grafu v PPTX](/slides/cs/net/working-solution-for-chart-resizing-in-pptx/)
- [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/net/object-preview-issue-when-adding-oleobjectframe/)
- [Automatická aktualizace OLE objektů pomocí PowerPoint Add-In](/slides/cs/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)