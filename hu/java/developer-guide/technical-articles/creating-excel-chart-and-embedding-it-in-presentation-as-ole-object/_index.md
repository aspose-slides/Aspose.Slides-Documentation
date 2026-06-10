---
title: Excel diagramok létrehozása és beágyazása prezentációkba OLE objektumként
type: docs
weight: 30
url: /hu/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel diagram
- diagram beágyazása
- OLE objektum
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Excel diagramok létrehozása és beágyazása OLE objektumként PowerPoint és OpenDocument prezentációkba Java-val. Lépésről lépésre útmutató kódrészletekkel."
---
## **Háttér**

A PowerPointban a szerkeszthető diagramok használata az adatok grafikus megjelenítésére gyakori gyakorlat. Az Aspose támogatja az Excel-diagramok létrehozását az Aspose.Cells for Java segítségével, és ezeket a diagramokat OLE objektumként be lehet ágyazni a PowerPoint diákba az Aspose.Slides for Java segítségével. Ez a cikk bemutatja a szükséges lépéseket, és Java kódrészleteket biztosít egy Excel-diagram létrehozásához és OLE objektumként való beágyazásához egy PowerPoint‑prezentációba az Aspose.Cells és az Aspose.Slides használatával.

## **Szükséges lépések**

Az alábbi lépéssorozatra van szükség egy Excel-diagram OLE objektumként való létrehozásához és beágyazásához egy PowerPoint diára:

1. Hozzon létre egy Excel-diagramot az Aspose.Cells segítségével.
1. Állítsa be az Excel-diagram OLE méretét az Aspose.Cells használatával.
1. Szerezzen képet az Excel-diagramból az Aspose.Cells segítségével.
1. Ágyazza be az Excel-diagramot OLE objektumként egy PPTX prezentációba az Aspose.Slides használatával.
1. Cserélje le a "EMBEDDED OLE OBJECT" képet a 3. lépésben kapott képre a [objektum előnézeti probléma](/slides/hu/java/object-preview-issue-when-adding-oleobjectframe/) megoldásához.
1. Mentse a prezentációt lemezre PPTX formátumban.

## **A szükséges lépések megvalósítása**

Az előbbiekben ismertetett lépések Java megvalósítása a következő:

```java
// Munkafüzet létrehozása.
Workbook workbook = new Workbook();

// Excel-diagram hozzáadása.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// A diagram OLE méretének beállítása.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// A diagram képének lekérése és streambe mentése.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// Munkafüzet mentése streambe.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// Prezentáció létrehozása.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Munkafüzet hozzáadása egy diára.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// Prezentáció mentése lemezre.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // EXCEL_97_TO_2003 LoadOptions objektum létrehozása.
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // A cellanevek tömbje.
    String[] cellNames = new String[]
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

    // Új munkalap hozzáadása a cellák adatokkal való feltöltéséhez.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // A adatlap feltöltése adatokkal.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // Diagramlap hozzáadása.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // Diagram hozzáadása a diagramlaphoz a adatlap sorozataival.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // A diagramlap beállítása aktív lapként.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

A fenti módszerrel létrehozott prezentáció tartalmazni fogja az Excel-diagramot OLE objektumként, amely az OLE objektumkeret dupla kattintásával aktiválható.

## **Következtetés**

Az Aspose.Cells for Java és az Aspose.Slides for Java együttes használatával bármilyen, az Aspose.Cells által támogatott Excel-diagramot létrehozhatunk, és beágyazhatjuk a diagramot OLE objektumként egy PowerPoint-diára. Az Excel-diagram OLE mérete is meghatározható. A végfelhasználók ezután a diagramot bármely más OLE objektumhoz hasonlóan szerkeszthetik.

## **Kapcsolódó szakaszok**

- [Működő megoldás a diagram átméretezésére PPTX-ben](/slides/hu/java/working-solution-for-chart-resizing-in-pptx/)
- [Objektum előnézeti probléma OleObjectFrame hozzáadásakor](/slides/hu/java/object-preview-issue-when-adding-oleobjectframe/)
- [OLE objektumok automatikus frissítése PowerPoint kiegészítő használatával](/slides/hu/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)