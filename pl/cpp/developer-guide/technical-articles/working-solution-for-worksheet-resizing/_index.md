---
title: Rozwiązanie praktyczne dla zmiany rozmiaru arkusza
type: docs
weight: 130
url: /pl/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- obraz podglądu
- zmiana rozmiaru obrazu
- Excel
- arkusz
- PowerPoint
- prezentacja
- C++
- Aspose.Slides dla C++
description: "Rozwiązanie praktyczne dla zmiany rozmiaru arkusza w prezentacjach PowerPoint przy użyciu C++"
---
{{% alert color="info" title="Note" %}}
Arkusze Excel osadzone jako obiekty OLE w prezentacji PowerPoint przy użyciu komponentów Aspose mogą nieoczekiwanie zmieniać rozmiar po ich pierwszej aktywacji. To zachowanie powoduje zauważalną różnicę wizualną między obiektem OLE przed i po aktywacji. Ten artykuł wyjaśnia problem i opisuje dwa sposoby rozwiązania go.
{{% /alert %}}

## **Tło**

W artykule [Zarządzanie OLE](/slides/pl/cpp/manage-ole/), wyjaśniliśmy, jak dodać ramkę OLE do prezentacji PowerPoint przy użyciu Aspose.Slides dla C++. Aby rozwiązać [problem podglądu obiektu](/slides/pl/cpp/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wybranego obszaru arkusza do ramki obiektu OLE. W wynikowej prezentacji, po dwukrotnym kliknięciu ramki obiektu OLE wyświetlającej obraz arkusza, aktywowany jest skoroszyt Excel. Użytkownicy mogą wprowadzić dowolne zmiany w rzeczywistym skoroszycie Excel, a następnie powrócić do slajdu, klikając poza aktywowanym skoroszytem Excel. Rozmiar ramki obiektu OLE zmieni się, gdy użytkownik wróci do slajdu. Współczynnik zmiany rozmiaru będzie się różnić w zależności od rozmiaru ramki obiektu OLE i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Ponieważ skoroszyt Excel ma własny rozmiar okna, próbuje zachować swój pierwotny rozmiar po pierwszej aktywacji. Z drugiej strony ramka obiektu OLE ma własny rozmiar. Według Microsoft, gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar, aby zapewnić zachowanie właściwych proporcji w ramach procesu osadzania. Zmiana rozmiaru zachodzi na podstawie różnic między rozmiarem okna Excel a rozmiarem i pozycją ramki obiektu OLE.

## **Rozwiązanie**

Istnieją dwa możliwe rozwiązania, aby uniknąć efektu zmiany rozmiaru.

- Skaluj ramkę OLE w prezentacji PowerPoint, aby dopasować całkowitą wysokość i szerokość wybranych wierszy i kolumn.
- Utrzymaj stały rozmiar ramki OLE i skaluj wybrane wiersze oraz kolumny, aby zmieściły się w niej.

### **Skalowanie rozmiaru ramki OLE**

To podejście ustawia rozmiar ramki OLE, aby dopasować całkowitą wysokość i szerokość wybranych wierszy i kolumn w osadzonym arkuszu Excel.

Przykład ładuje istniejący skoroszyt Excel i wybiera pierwsze 10 wierszy oraz 13 kolumn jego pierwszego arkusza, używając indeksów zerowych. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) określa wyświetlany zakres. Podgląd jest renderowany z rozdzielczością 96 DPI, a jego wymiary w pikselach są konwertowane na punkty przy użyciu 72 punktów na cal. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) osadza zmodyfikowany skoroszyt w ramce o tych wymiarach. Podgląd jest przypisany poprzez [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) w celu zastąpienia symbolu zastępczego „EMBEDDED OLE OBJECT” w zapisaniej prezentacji.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Ustaw wyświetlany rozmiar, gdy plik skoroszytu jest używany jako obiekt OLE w PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Pobierz szerokość i wysokość obrazu OLE w punktach.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// Musimy użyć zmodyfikowanego skoroszytu.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Dodaj obraz OLE do zasobów prezentacji.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Utwórz ramkę obiektu OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

Pomocnik podglądu używa [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) do wyboru zakresu i usuwa marginesy, nagłówki oraz stopki. Z włączoną opcją [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/), [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) renderuje zakres jako obraz PNG. Pomocnik kopiuje wyrenderowane dane obrazu do nowego strumienia pamięci ustawionego na początek, aby użyć go w prezentacji.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **Skalowanie rozmiaru zakresu komórek**

To podejście skaluje wysokości wybranych wierszy oraz szerokości wybranych kolumn, aby dopasować je do niestandardowego rozmiaru ramki OLE.

Przykład ładuje istniejący skoroszyt Excel i wybiera pierwsze 10 wierszy oraz 13 kolumn jego pierwszego arkusza, używając indeksów zerowych. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) określa wyświetlany zakres, a poniższy pomocnik skaluje ten zakres, aby pasował do ramki o szerokości 400 punktów i wysokości 100 punktów. Po zapisaniu zmodyfikowanego skoroszytu do tablicy bajtów, [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) osadza go w określonym rozmiarze. Podgląd renderowany z rozdzielczością 96 DPI jest przypisany poprzez [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/), dzięki czemu zapisana prezentacja wyświetla wybrane komórki zamiast domyślnego symbolu zastępczego.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Ustaw wyświetlany rozmiar, gdy plik skoroszytu jest używany jako obiekt OLE w PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Przeskaluj zakres komórek, aby dopasować go do rozmiaru ramki.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Musimy użyć zmodyfikowanego skoroszytu.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Dodaj obraz OLE do zasobów prezentacji.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Utwórz ramkę obiektu OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

Pomocnik skalowania oblicza osobne współczynniki szerokości i wysokości dla wybranego zakresu, zachowując względne szerokości jego kolumn oraz względne wysokości jego wierszy. Przed zastosowaniem ich przy pomocy [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) i [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/), konwertuje obliczone wymiary z punktów na cale. Wybrany zakres musi mieć niezerową szerokość i wysokość.

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">Oczekiwana szerokość zakresu komórek w punktach.</param>
/// <param name="height">Oczekiwana wysokość zakresu komórek w punktach.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

Ten pomocnik podglądu renderuje przeskalowany zakres przy użyciu [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/). Używa [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/), aby ograniczyć drukowanie do tego zakresu, usuwa marginesy, nagłówki i stopki oraz zwraca strumień PNG ustawiony na początek.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **Wnioski**

{{% alert color="info" title="Note" %}}
Istnieją dwa podejścia do naprawy problemu zmiany rozmiaru arkusza. Wybierz podejście, które najlepiej odpowiada Twoim wymaganiom i przypadkowi użycia. Oba podejścia działają w ten sam sposób, niezależnie od tego, czy prezentacje są tworzone z szablonu, czy od podstaw. Dodatkowo w tym rozwiązaniu nie ma limitu rozmiaru ramki obiektu OLE.
{{% /alert %}}

## **FAQ**

**Dlaczego osadzony arkusz Excel zmienia rozmiar po pierwszej aktywacji w PowerPoint?**

Dzieje się tak, ponieważ Excel próbuje zachować pierwotny rozmiar okna po aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby zachować proporcje, co może powodować zmianę rozmiaru.

**Czy można całkowicie zapobiec temu problemowi ze zmianą rozmiaru?**

Tak. Skalując ramkę OLE, aby pasowała do rozmiaru zakresu komórek Excel, lub skalując zakres komórek, aby pasował do żądanego rozmiaru ramki OLE, możesz zapobiec niepożądanej zmianie rozmiaru.

**Jaką metodę skalowania powinienem użyć, skalowanie ramki OLE czy skalowanie zakresu komórek?**

Wybierz **skalowanie ramki OLE**, jeśli chcesz zachować pierwotne rozmiary wierszy i kolumn Excel. Wybierz **skalowanie zakresu komórek**, jeśli potrzebujesz stałego rozmiaru ramki OLE w prezentacji.

**Czy te rozwiązania będą działać, jeśli moja prezentacja oparta jest na szablonie?**

Tak. Oba rozwiązania działają zarówno dla prezentacji tworzonych z szablonów, jak i od podstaw.

**Czy istnieje limit rozmiaru ramki OLE przy użyciu tych metod?**

Nie. Możesz ustawić ramkę obiektu OLE na dowolny rozmiar, pod warunkiem odpowiedniego skalowania.

**Czy istnieje sposób na uniknięcie tekstu zastępczego „EMBEDDED OLE OBJECT” w PowerPoint?**

Tak. Pobierając migawkę docelowego zakresu komórek Excel i ustawiając ją jako obraz zastępczy ramki OLE, możesz wyświetlić własny obraz podglądu zamiast domyślnego symbolu zastępczego.

## **Powiązane artykuły**

[Tworzenie wykresu Excel i osadzenie go w prezentacji jako obiekt OLE](/slides/pl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)