---
title: Tworzenie wykresów Excel i osadzanie ich w prezentacjach jako obiekty OLE
type: docs
weight: 50
url: /pl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- wykres Excel
- osadź wykres
- obiekt OLE
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Twórz wykresy Excel i osadzaj je jako obiekty OLE w prezentacjach PowerPoint i OpenDocument przy użyciu C#/.NET. Przewodnik krok po kroku z przykładami kodu."
---
## **Tło**

W PowerPoint używanie edytowalnych wykresów do graficznego przedstawiania danych jest powszechną praktyką. Aspose wspiera tworzenie wykresów Excel przy użyciu Aspose.Cells dla .NET, a te wykresy można następnie osadzić jako obiekty OLE w slajdach PowerPoint za pomocą Aspose.Slides dla .NET. Ten artykuł opisuje niezbędne kroki i zawiera przykłady kodu C# do tworzenia wykresu Excel i osadzania go jako obiekt OLE w prezentacji PowerPoint przy użyciu Aspose.Cells i Aspose.Slides.

## **Wymagane kroki**

1. Utwórz wykres Excel przy użyciu Aspose.Cells.  
2. Ustaw rozmiar OLE wykresu Excel przy użyciu Aspose.Cells.  
3. Uzyskaj obraz wykresu Excel przy użyciu Aspose.Cells.  
4. Osadź wykres Excel jako obiekt OLE w prezentacji PPTX przy użyciu Aspose.Slides.  
5. Zastąp obraz „EMBEDDED OLE OBJECT” obrazem uzyskanym w kroku 3, aby rozwiązać [object preview issue](/slides/pl/net/object-preview-issue-when-adding-oleobjectframe/).  
6. Zapisz prezentację na dysku w formacie PPTX.

## **Implementacja wymaganych kroków**

Implementacja w języku C# powyższych kroków przedstawia się następująco:

```cs
// Krok - 1: Utwórz wykres Excel przy użyciu Aspose.Cells.
// ---------------------------------------------------
// Utwórz skoroszyt.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Dodaj wykres Excel.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Krok - 2: Ustaw rozmiar OLE wykresu przy użyciu Aspose.Cells.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// Krok - 3: Pobierz obraz wykresu przy użyciu Aspose.Cells.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// Zapisz skoroszyt do strumienia.
MemoryStream workbookStream = workbook.SaveToStream();

// Krok - 4 I 5
// ==============
 // Krok - 4: Osadź wykres jako obiekt OLE w prezentacji .ppt przy użyciu Aspose.Slides.
// ------------------------------------------------------------------------------------------
 // Krok - 5: Zastąp obraz "EMBEDDED OLE OBJECT" obrazem uzyskanym w kroku 3, aby rozwiązać problem podglądu obiektu.
// --------------------------------------------------------------------------------------------------------------------
 // Utwórz prezentację.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // Dodaj skoroszyt do slajdu.
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // Krok - 6: Zapisz wyjściową prezentację na dysku.
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // Tablica nazw komórek.
    string[] cellNames = new string[]
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
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // Wypełnij arkusz danych danymi.
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // Dodaj arkusz wykresu.
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // Dodaj wykres do arkusza wykresu, używając serii danych z arkusza danych.
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // Ustaw arkusz wykresu jako aktywny arkusz.
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

Prezentacja utworzona w powyższy sposób będzie zawierać wykres Excel jako obiekt OLE, który można aktywować podwójnym kliknięciem ramki obiektu OLE.

## **Podsumowanie**

Używając Aspose.Cells for .NET razem z Aspose.Slides for .NET, możemy tworzyć dowolny wykres Excel obsługiwany przez Aspose.Cells i osadzać go jako obiekt OLE w slajdzie PowerPoint. Rozmiar OLE wykresu Excel również może być określony. Użytkownicy końcowi mogą następnie edytować wykres Excel tak jak każdy inny obiekt OLE.

## **Powiązane sekcje**

- [Rozwiązanie działające dla zmiany rozmiaru wykresu w PPTX](/slides/pl/net/working-solution-for-chart-resizing-in-pptx/)
- [Problem z podglądem obiektu przy dodawaniu OleObjectFrame](/slides/pl/net/object-preview-issue-when-adding-oleobjectframe/)
- [Automatyczna aktualizacja obiektów OLE za pomocą dodatku PowerPoint](/slides/pl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)