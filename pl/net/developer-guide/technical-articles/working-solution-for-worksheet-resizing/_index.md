---
title: Rozwiązanie działające dla zmiany rozmiaru arkusza
type: docs
weight: 40
url: /pl/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- obraz podglądu
- zmiana rozmiaru obrazu
- Excel
- arkusz
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Napraw rozmiarowanie OLE arkusza Excel w prezentacjach: dwa sposoby utrzymania spójności ramek obiektów — skalowanie ramki lub arkusza — w formatach PPT i PPTX."
---
{{% alert color="info" title="Note" %}}
Arkusze Excel osadzone jako obiekty OLE w prezentacji PowerPoint przy użyciu komponentów Aspose mogą nieoczekiwanie zmienić rozmiar po ich pierwszej aktywacji. To zachowanie tworzy zauważalną różnicę wizualną między obiektem OLE przed i po aktywacji. Ten artykuł wyjaśnia problem i opisuje dwa sposoby jego rozwiązania.
{{% /alert %}}

## **Tło**

W artykule [Manage OLE](/slides/pl/net/manage-ole/) wyjaśniliśmy, jak dodać ramkę OLE do prezentacji PowerPoint przy użyciu Aspose.Slides dla .NET. Aby rozwiązać [problem podglądu obiektu](/slides/pl/net/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wybranego obszaru arkusza do ramki obiektu OLE. W wygenerowanej prezentacji, po dwukrotnym kliknięciu ramki obiektu OLE wyświetlającej obraz arkusza, aktywowany jest skoroszyt Excel. Użytkownicy mogą wprowadzić dowolne zmiany w rzeczywistym skoroszycie Excel, a następnie wrócić do slajdu, klikając poza aktywowanym skoroszytem Excel. Rozmiar ramki obiektu OLE zmieni się, gdy użytkownik wróci do slajdu. Współczynnik zmiany rozmiaru będzie się różnić w zależności od rozmiaru ramki obiektu OLE i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Ponieważ skoroszyt Excel ma własny rozmiar okna, stara się zachować pierwotny rozmiar po pierwszej aktywacji. Z drugiej strony ramka obiektu OLE ma własny rozmiar. Zgodnie z informacjami Microsoftu, gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar, aby zapewnić utrzymanie prawidłowych proporcji w ramach procesu osadzania. Zmiana rozmiaru zachodzi na podstawie różnic między rozmiarem okna Excel a rozmiarem i pozycją ramki obiektu OLE.

## **Rozwiązanie**

Istnieją dwa możliwe rozwiązania, aby uniknąć efektu zmiany rozmiaru.

- Skaluj ramkę OLE w prezentacji PowerPoint, aby dopasować całkowitą wysokość i szerokość wybranych wierszy i kolumn.
- Utrzymaj stały rozmiar ramki OLE i skaluj wybrane wiersze i kolumny, aby pasowały do niej.

### **Skalowanie rozmiaru ramki OLE**

To podejście ustawia rozmiar ramki OLE tak, aby odpowiadał całkowitej wysokości i szerokości wybranych wierszy i kolumn w osadzonym arkuszu Excel.

Przykład ładuje istniejący skoroszyt Excel i wybiera pierwsze 10 wierszy oraz 13 kolumn pierwszego arkusza, używając indeksów zerowych. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) definiuje wyświetlany zakres. Podgląd jest renderowany w 96 DPI, a jego wymiary w pikselach są konwertowane na punkty przy użyciu 72 punktów na cal. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) osadza zmodyfikowany skoroszyt w ramce o tych wymiarach. Podgląd jest przypisany przez [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) w celu zastąpienia symbolu zastępczego „EMBEDDED OLE OBJECT” w zapisanej prezentacji.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Ustaw wyświetlany rozmiar, gdy plik skoroszytu jest używany jako obiekt OLE w programie PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Pobierz szerokość i wysokość obrazu OLE w punktach.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Musimy użyć zmodyfikowanego skoroszytu.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Dodaj obraz OLE do zasobów prezentacji.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Utwórz ramkę obiektu OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Pomocnik podglądu ustawia [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) na wybrany zakres i usuwa marginesy, nagłówki oraz stopki. Po włączeniu [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) renderuje zakres jako obraz PNG. Pomocnik przewija strumień obrazu przed jego zwróceniem do użycia w prezentacji.

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **Skalowanie rozmiaru zakresu komórek**

To podejście skaluje wysokości wybranych wierszy i szerokości wybranych kolumn, aby dopasować je do niestandardowego rozmiaru ramki OLE.

Przykład ładuje istniejący skoroszyt Excel i wybiera pierwsze 10 wierszy oraz 13 kolumn pierwszego arkusza, używając indeksów zerowych. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) definiuje wyświetlany zakres, a poniższy pomocnik skaluje ten zakres, aby pasował do ramki o szerokości 400 punktów i wysokości 100 punktów. Po zapisaniu zmodyfikowanego skoroszytu do strumienia, [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) osadza go w określonym rozmiarze. Podgląd renderowany w 96 DPI jest przypisany przez [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/), dzięki czemu zapisana prezentacja wyświetla wybrane komórki zamiast domyślnego symbolu zastępczego.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Ustaw wyświetlany rozmiar, gdy plik skoroszytu jest używany jako obiekt OLE w programie PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skaluj zakres komórek, aby pasował do rozmiaru ramki.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Musimy użyć zmodyfikowanego skoroszytu.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Dodaj obraz OLE do zasobów prezentacji.
var oleImage = presentation.Images.AddImage(imageStream);

// Utwórz ramkę obiektu OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Pomocnik skalowania oblicza osobne współczynniki szerokości i wysokości dla wybranego zakresu, zachowując względne szerokości kolumn i względne wysokości wierszy. Przed zastosowaniem ich przy użyciu [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) i [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/) konwertuje obliczone wymiary z punktów na cale. Wybrany zakres musi mieć niezerową szerokość i wysokość.

```cs
/// <param name="width">Oczekiwana szerokość zakresu komórek w punktach.</param>
/// <param name="height">Oczekiwana wysokość zakresu komórek w punktach.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

Ten pomocnik podglądu renderuje przeskalowany zakres przy użyciu [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/). Ogranicza [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) do tego zakresu, usuwa marginesy, nagłówki i stopki oraz zwraca strumień PNG ustawiony na początek.

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **Wnioski**

{{% alert color="info" title="Note" %}}
Istnieją dwa podejścia do rozwiązania problemu zmiany rozmiaru arkusza. Wybierz podejście, które najlepiej odpowiada Twoim wymaganiom i przypadkowi użycia. Oba podejścia działają tak samo, niezależnie od tego, czy prezentacje są tworzone z szablonu, czy od podstaw. Dodatkowo w tym rozwiązaniu nie ma ograniczenia wielkości ramki obiektu OLE.
{{% /alert %}}

## **FAQ**

**Dlaczego osadzony arkusz Excel zmienia rozmiar przy pierwszej aktywacji w PowerPoint?**  
Dzieje się tak, ponieważ Excel stara się zachować oryginalny rozmiar okna przy aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby utrzymać proporcje, co może powodować zmianę rozmiaru.

**Czy można całkowicie zapobiec temu problemowi ze zmianą rozmiaru?**  
Tak. Skalując ramkę OLE tak, aby pasowała do rozmiaru zakresu komórek Excel, lub skalując zakres komórek tak, aby pasował do żądanego rozmiaru ramki OLE, można całkowicie zapobiec niechcianej zmianie rozmiaru.

**Którą metodę skalowania powinienem wybrać, skalowanie ramki OLE czy skalowanie zakresu komórek?**  
Wybierz **skalowanie ramki OLE**, jeśli chcesz zachować oryginalne rozmiary wierszy i kolumn w Excelu. Wybierz **skalowanie zakresu komórek**, jeśli chcesz mieć stały rozmiar ramki OLE w swojej prezentacji.

**Czy te rozwiązania będą działać, jeśli moja prezentacja opiera się na szablonie?**  
Tak. Oba rozwiązania działają zarówno dla prezentacji tworzonych z szablonów, jak i od podstaw.

**Czy istnieje limit rozmiaru ramki OLE przy użyciu tych metod?**  
Nie. Możesz ustawić ramkę obiektu OLE na dowolny rozmiar, pod warunkiem odpowiedniego ustawienia skali.

**Czy istnieje sposób na uniknięcie tekstu zastępczego „EMBEDDED OLE OBJECT” w PowerPoint?**  
Tak. Pobierając migawkę docelowego zakresu komórek Excel i ustawiając ją jako obraz zastępczy ramki OLE, możesz wyświetlić własny obraz podglądu zamiast domyślnego symbolu zastępczego.

## **Powiązane artykuły**

[Tworzenie wykresu Excel i osadzanie go w prezentacji jako obiekt OLE](/slides/pl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Automatyczna aktualizacja obiektów OLE przy użyciu dodatku MS PowerPoint](/slides/pl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)