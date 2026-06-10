---
title: Excel-diagramok létrehozása és beágyazása prezentációkba OLE objektumként
type: docs
weight: 50
url: /hu/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- diagram beágyazása
- OLE-objektum
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Excel-diagramok létrehozása és beágyazása OLE objektumként PowerPoint és OpenDocument prezentációkba C#/.NET használatával. Lépésről lépésre útmutató kódmintákkal."
---
## **Háttér**

A PowerPointban a szerkeszthető diagramok használata az adatok grafikus megjelenítésére gyakori gyakorlat. Az Aspose támogatja az Excel-diagramok létrehozását az Aspose.Cells for .NET segítségével, és ezeket a diagramokat OLE objektumokként be lehet ágyazni a PowerPoint diákba az Aspose.Slides for .NET-en keresztül. Ez a cikk bemutatja a szükséges lépéseket, és C# kódmintákat biztosít egy Excel-diagram létrehozásához és OLE objektumként történő beágyazásához egy PowerPoint prezentációba az Aspose.Cells és az Aspose.Slides használatával.

## **Szükséges lépések**

A következő lépéssorozatra van szükség egy Excel-diagram OLE objektumként történő létrehozásához és beágyazásához egy PowerPoint diára:

1. Hozzon létre egy Excel-diagramot az Aspose.Cells használatával.
2. Állítsa be az Excel-diagram OLE méretét az Aspose.Cells segítségével.
3. Szerezzen képet az Excel-diagramról az Aspose.Cells segítségével.
4. Ágyazza be az Excel-diagramot OLE objektumként egy PPTX prezentációba az Aspose.Slides használatával.
5. Cserélje ki az "EMBEDDED OLE OBJECT" képet a 3. lépésben megszerzett képre a [objektum előnézeti probléma](/slides/hu/net/object-preview-issue-when-adding-oleobjectframe/) megoldásához.
6. Mentse a prezentációt a lemezre PPTX formátumban.

## **A szükséges lépések megvalósítása**

A fenti lépések C# megvalósítása a következő:

```cs
// 1. lépés: Excel-diagram létrehozása az Aspose.Cells használatával.
// ---------------------------------------------------
// Munkafüzet létrehozása.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Excel-diagram hozzáadása.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// 2. lépés: A diagram OLE méretének beállítása az Aspose.Cells használatával.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// 3. lépés: A diagram képének lekérése az Aspose.Cells használatával.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// A munkafüzet mentése stream-be.
MemoryStream workbookStream = workbook.SaveToStream();

// 4. és 5. lépés
// ==============
 // 4. lépés: A diagram beágyazása OLE objektumként egy .ppt prezentációba az Aspose.Slides használatával.
// ------------------------------------------------------------------------------------------
// 5. lépés: Az "EMBEDDED OLE OBJECT" képet cserélje ki a 3. lépésben kapott képre az objektum előnézeti probléma megoldásához.
// --------------------------------------------------------------------------------------------------------------------
// Prezentáció létrehozása.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // A munkafüzet hozzáadása a diára.
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // 6. lépés: A kimeneti prezentáció mentése lemezre.
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // A cellanevek tömbje.
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // A cellák adatainak tömbje.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Új munkalap hozzáadása a cellák adatkitöltéséhez.
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // Az adatlap feltöltése adatokkal.
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // Diagramműlap hozzáadása.
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // Diagram hozzáadása a diagramműlaphoz az adatlap adatsorával.
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // A diagramműlap beállítása aktív munkalapként.
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

A fenti módszerrel létrehozott prezentáció tartalmazni fogja az Excel-diagramot OLE objektumként, amely a OLE objektumkeret duplakattintásával aktiválható.

## **Összegzés**

Az Aspose.Cells for .NET és az Aspose.Slides for .NET együttes használatával létrehozhatunk bármilyen, az Aspose.Cells által támogatott Excel-diagramot, és beágyazhatjuk a diagramot OLE objektumként egy PowerPoint diára. Az Excel-diagram OLE mérete is meghatározható. A végfelhasználók ezután a Excel-diagramot a többi OLE objektumhoz hasonlóan szerkeszthetik.

## **Kapcsolódó szakaszok**

- [Működő megoldás a diagram átméretezésére PPTX-ben](/slides/hu/net/working-solution-for-chart-resizing-in-pptx/)
- [Objektum előnézeti probléma OleObjectFrame hozzáadásakor](/slides/hu/net/object-preview-issue-when-adding-oleobjectframe/)
- [OLE-objektumok automatikus frissítése PowerPoint kiegészítő használatával](/slides/hu/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)