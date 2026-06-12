---
title: Maak Excel grafieken en embed ze in presentaties als OLE objecten
type: docs
weight: 30
url: /nl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel grafiek
- grafiek insluiten
- OLE object
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Maak Excel grafieken en embed ze als OLE objecten in PowerPoint- en OpenDocument-presentaties met Java. Stapsgewijze handleiding met codevoorbeelden."
---
## **Achtergrond**

In PowerPoint is het gebruik van bewerkbare grafieken om gegevens grafisch weer te geven een gangbare praktijk. Aspose ondersteunt het maken van Excel‑grafieken met Aspose.Cells voor Java, en deze grafieken kunnen vervolgens worden ingesloten als OLE‑objecten in PowerPoint‑dia's via Aspose.Slides voor Java. Dit artikel behandelt de benodigde stappen en biedt Java‑codevoorbeelden voor het maken van een Excel‑grafiek en het insluiten ervan als OLE‑object in een PowerPoint‑presentatie met behulp van Aspose.Cells en Aspose.Slides.

## **Vereiste stappen**

De volgende reeks stappen is vereist om een Excel‑grafiek te maken en in te sluiten als OLE‑object in een PowerPoint‑dia:

1. Maak een Excel‑grafiek met Aspose.Cells.
1. Stel de OLE‑grootte van de Excel‑grafiek in met Aspose.Cells.
1. Haal een afbeelding van de Excel‑grafiek op met Aspose.Cells.
1. Sluit de Excel‑grafiek in als OLE‑object in een PPTX‑presentatie met Aspose.Slides.
1. Vervang de afbeelding "EMBEDDED OLE OBJECT" door de afbeelding die is verkregen in stap 3 om het [probleem met object preview](/slides/nl/java/object-preview-issue-when-adding-oleobjectframe/) op te lossen.
1. Sla de presentatie op schijf op in PPTX‑formaat.

## **Implementatie van de vereiste stappen**

De Java‑implementatie van de bovenstaande stappen is als volgt:

```java
// Maak een werkmap.
Workbook workbook = new Workbook();

// Voeg een Excel-grafiek toe.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Stel de OLE-grootte van de grafiek in.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// Haal de afbeelding van de grafiek op en sla deze op in een stream.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// Sla de werkmap op in een stream.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// Maak een presentatie.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Voeg de werkmap toe aan een dia.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// Sla de presentatie op schijf.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // Maak een EXCEL_97_TO_2003 LoadOptions-object aan.
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // Een array van celnamen.
    String[] cellNames = new String[]
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

    // Voeg een nieuw werkblad toe om cellen te vullen met gegevens.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // Vul het gegevensblad met gegevens.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // Voeg een diagramblad toe.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // Voeg een diagram toe aan het diagramblad met gegevensreeksen van het gegevensblad.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // Stel het diagramblad in als actief blad.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

De presentatie die met de bovenstaande methode wordt gemaakt, bevat de Excel‑grafiek als OLE‑object dat kan worden geactiveerd door dubbel te klikken op het OLE‑objectframe.

## **Conclusie**

Door Aspose.Cells voor Java samen met Aspose.Slides voor Java te gebruiken, kunnen we elke door Aspose.Cells ondersteunde Excel‑grafiek maken en de grafiek als OLE‑object in een PowerPoint‑dia insluiten. De OLE‑grootte van de Excel‑grafiek kan ook worden gedefinieerd. Eindgebruikers kunnen vervolgens de Excel‑grafiek bewerken zoals elk ander OLE‑object.

## **Gerelateerde secties**

- [Werkende oplossing voor het aanpassen van grafiekgrootte in PPTX](/slides/nl/java/working-solution-for-chart-resizing-in-pptx/)
- [Probleem met object preview bij het toevoegen van OleObjectFrame](/slides/nl/java/object-preview-issue-when-adding-oleobjectframe/)
- [OLE-objecten automatisch bijwerken met een PowerPoint‑add‑in](/slides/nl/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)