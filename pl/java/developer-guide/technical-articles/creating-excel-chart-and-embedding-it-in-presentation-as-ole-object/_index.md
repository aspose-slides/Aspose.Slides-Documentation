---
title: Tworzenie wykresów Excel i osadzanie ich w prezentacjach jako obiekty OLE
type: docs
weight: 30
url: /pl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Wykres Excel
- osadź wykres
- obiekt OLE
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Tworzenie wykresów Excel i osadzanie ich jako obiekty OLE w prezentacjach PowerPoint i OpenDocument przy użyciu Java. Przewodnik krok po kroku z przykładami kodu."
---
## **Tło**

W programie PowerPoint używanie edytowalnych wykresów do graficznego wyświetlania danych jest powszechną praktyką. Aspose obsługuje tworzenie wykresów Excel przy użyciu Aspose.Cells for Java, a te wykresy mogą być następnie osadzane jako obiekty OLE na slajdach PowerPoint za pośrednictwem Aspose.Slides for Java. Ten artykuł opisuje niezbędne kroki i zawiera przykłady kodu Java do tworzenia wykresu Excel i osadzania go jako obiektu OLE w prezentacji PowerPoint przy użyciu Aspose.Cells i Aspose.Slides.

## **Wymagane kroki**

Poniższa kolejność kroków jest wymagana do utworzenia i osadzenia wykresu Excel jako obiektu OLE na slajdzie PowerPoint:

1. Utwórz wykres Excel przy użyciu Aspose.Cells.
1. Ustaw rozmiar OLE wykresu Excel przy użyciu Aspose.Cells.
1. Uzyskaj obraz wykresu Excel przy użyciu Aspose.Cells.
1. Osadź wykres Excel jako obiekt OLE w prezentacji PPTX przy użyciu Aspose.Slides.
1. Zastąp obraz „EMBEDDED OLE OBJECT” obrazem uzyskanym w kroku 3, aby rozwiązać problem [problem podglądu obiektu](/slides/pl/java/object-preview-issue-when-adding-oleobjectframe/).
1. Zapisz prezentację na dysku w formacie PPTX.

## **Implementacja wymaganych kroków**

Implementacja w Javie powyższych kroków wygląda następująco:

```java
// Utwórz skoroszyt.
Workbook workbook = new Workbook();

// Dodaj wykres Excel.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Ustaw rozmiar OLE wykresu.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// Pobierz obraz wykresu i zapisz go do strumienia.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// Zapisz skoroszyt do strumienia.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// Utwórz prezentację.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Dodaj skoroszyt do slajdu.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// Zapisz prezentację na dysku.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // Utwórz obiekt LoadOptions typu EXCEL_97_TO_2003.
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // Tablica nazw komórek.
    String[] cellNames = new String[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Tablica danych komórek.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Dodaj nowy arkusz, aby wypełnić komórki danymi.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // Wypełnij arkusz danych danymi.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // Dodaj arkusz wykresu.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // Dodaj wykres do arkusza wykresu z serią danych z arkusza danych.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // Ustaw arkusz wykresu jako aktywny arkusz.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

Prezentacja utworzona w powyższy sposób będzie zawierać wykres Excel jako obiekt OLE, który można aktywować podwójnym kliknięciem w ramkę obiektu OLE.

## **Podsumowanie**

Korzystając z Aspose.Cells for Java w połączeniu z Aspose.Slides for Java, możemy tworzyć dowolny wykres Excel obsługiwany przez Aspose.Cells i osadzać go jako obiekt OLE na slajdzie PowerPoint. Rozmiar OLE wykresu Excel również może być określony. Użytkownicy końcowi mogą następnie edytować wykres Excel tak jak każdy inny obiekt OLE.

## **Powiązane sekcje**

- [Działające rozwiązanie dla zmiany rozmiaru wykresu w PPTX](/slides/pl/java/working-solution-for-chart-resizing-in-pptx/)
- [Problem podglądu obiektu przy dodawaniu OleObjectFrame](/slides/pl/java/object-preview-issue-when-adding-oleobjectframe/)
- [Automatyczna aktualizacja obiektów OLE przy użyciu dodatku PowerPoint](/slides/pl/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)