---
title: Vytvořte Excelové grafy a vložte je do prezentací jako OLE objekty
type: docs
weight: 30
url: /cs/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel graf
- vložit graf
- OLE objekt
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Vytvořte Excelové grafy a vložte je jako OLE objekty do prezentací PowerPoint a OpenDocument pomocí Javy. Podrobný návod s ukázkovým kódem."
---
## **Pozadí**

V PowerPointu je běžnou praxí používat editovatelné grafy k vizuálnímu zobrazení dat. Aspose podporuje vytváření Excel grafů pomocí Aspose.Cells pro Java a tyto grafy lze následně vložit jako OLE objekty do snímků PowerPointu pomocí Aspose.Slides pro Java. Tento článek popisuje nezbytné kroky a poskytuje ukázky kódu v Javě pro vytvoření Excel grafu a vložení jej jako OLE objekt do prezentace PowerPoint pomocí Aspose.Cells a Aspose.Slides.

## **Požadované kroky**

Následující posloupnost kroků je nutná k vytvoření a vložení Excel grafu jako OLE objektu do snímku PowerPoint:

1. Vytvořit Excel graf pomocí Aspose.Cells.
1. Nastavit velikost OLE objektu Excel grafu pomocí Aspose.Cells.
1. Získat obrázek Excel grafu pomocí Aspose.Cells.
1. Vložit Excel graf jako OLE objekt do prezentace PPTX pomocí Aspose.Slides.
1. Nahradit obrázek „EMBEDDED OLE OBJECT“ obrázkem získaným ve třetím kroku, aby se vyřešil [problém s náhledem objektu](/slides/cs/java/object-preview-issue-when-adding-oleobjectframe/).
1. Uložit prezentaci na disk ve formátu PPTX.

## **Implementace požadovaných kroků**

Java implementace výše uvedených kroků je následující:

```java
// Vytvořte sešit.
Workbook workbook = new Workbook();

// Přidejte Excel graf.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Nastavte velikost OLE objektu grafu.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// Získejte obrázek grafu a uložte jej do proudu.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// Uložte sešit do proudu.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// Vytvořte prezentaci.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Přidejte sešit do snímku.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// Uložte prezentaci na disk.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // Vytvořte objekt LoadOptions pro EXCEL_97_TO_2003.
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // Pole názvů buněk.
    String[] cellNames = new String[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Pole dat buněk.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Přidejte nový list pro vyplnění buněk daty.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // Vyplňte datový list daty.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // Přidejte list s grafem.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // Přidejte graf do listu s grafem s řadou dat z datového listu.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // Nastavte list s grafem jako aktivní list.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

Prezentace vytvořená výše uvedenou metodou bude obsahovat Excel graf jako OLE objekt, který lze aktivovat dvojitým kliknutím na rámec OLE objektu.

## **Závěr**

Pomocí Aspose.Cells pro Java v kombinaci s Aspose.Slides pro Java můžeme vytvořit libovolný Excel graf podporovaný Aspose.Cells a vložit jej jako OLE objekt do snímku PowerPoint. Velikost OLE objektu Excel grafu lze také definovat. Koneční uživatelé pak mohou upravovat Excel graf jako jakýkoli jiný OLE objekt.

## **Související sekce**

- [Funkční řešení pro změnu velikosti grafu v PPTX](/slides/cs/java/working-solution-for-chart-resizing-in-pptx/)
- [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/java/object-preview-issue-when-adding-oleobjectframe/)
- [Automatická aktualizace OLE objektů pomocí doplňku PowerPoint](/slides/cs/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)