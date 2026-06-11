---
title: Skapa Excel-diagram och bädda in dem i presentationer som OLE-objekt
type: docs
weight: 30
url: /sv/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- bädda in diagram
- OLE-objekt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Skapa Excel-diagram och bädda in dem som OLE-objekt i PowerPoint- och OpenDocument-presentationer med Java. Steg-för-steg-guide med kodexempel."
---
## **Bakgrund**

I PowerPoint är det vanligt att använda redigerbara diagram för att visa data grafiskt. Aspose stöder skapandet av Excel-diagram med Aspose.Cells för Java, och dessa diagram kan sedan bäddas in som OLE-objekt i PowerPoint-bilder via Aspose.Slides för Java. Denna artikel beskriver de nödvändiga stegen och erbjuder Java‑kodexempel för att skapa ett Excel-diagram och bädda in det som ett OLE‑objekt i en PowerPoint‑presentation med Aspose.Cells och Aspose.Slides.

## **Nödvändiga steg**

1. Skapa ett Excel-diagram med Aspose.Cells.  
1. Ställ in OLE‑storleken för Excel-diagrammet med Aspose.Cells.  
1. Hämta en bild av Excel-diagrammet med Aspose.Cells.  
1. Bädda in Excel-diagrammet som ett OLE‑objekt i en PPTX-presentation med Aspose.Slides.  
1. Byt ut bilden "EMBEDDED OLE OBJECT" mot bilden som erhölls i steg 3 för att lösa [objekt‑förhandsgranskningsproblemet](/slides/sv/java/object-preview-issue-when-adding-oleobjectframe/).  
1. Spara presentationen till disk i PPTX-format.

## **Implementering av de nödvändiga stegen**

Java‑implementeringen av stegen ovan är enligt följande:

```java
// Skapa en arbetsbok.
Workbook workbook = new Workbook();

// Lägg till ett Excel-diagram.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Ställ in OLE-storleken för diagrammet.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// Hämta diagrambilden och spara den till en ström.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// Spara arbetsboken till en ström.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// Skapa en presentation.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Lägg till arbetsboken på en bild.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// Spara presentationen till disk.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // Skapa ett EXCEL_97_TO_2003 LoadOptions-objekt.
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // En array av cellnamn.
    String[] cellNames = new String[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // En array av celldata.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Lägg till ett nytt arbetsblad för att fylla celler med data.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // Fyll i datasbladet med data.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // Lägg till ett diagramblad.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // Lägg till ett diagram på diagrambladet med dataserier från datasbladet.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // Ställ in diagrambladet som ett aktivt blad.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

Presentation som skapats med metoden ovan kommer att innehålla Excel-diagrammet som ett OLE‑objekt som kan aktiveras genom att dubbelklicka på OLE‑objekt‑ramen.

## **Slutsats**

Genom att använda Aspose.Cells för Java tillsammans med Aspose.Slides för Java kan vi skapa vilket Excel‑diagram som helst som stöds av Aspose.Cells och bädda in diagrammet som ett OLE‑objekt i en PowerPoint‑bild. OLE‑storleken för Excel‑diagrammet kan också definieras. Slutanvändare kan sedan redigera Excel‑diagrammet på samma sätt som alla andra OLE‑objekt.

## **Relaterade avsnitt**

- [Fungerande lösning för diagramändring i PPTX](/slides/sv/java/working-solution-for-chart-resizing-in-pptx/)  
- [Objekt‑förhandsgranskningsproblem vid tillägg av OleObjectFrame](/slides/sv/java/object-preview-issue-when-adding-oleobjectframe/)  
- [Uppdatera OLE‑objekt automatiskt med ett PowerPoint‑tillägg](/slides/sv/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)