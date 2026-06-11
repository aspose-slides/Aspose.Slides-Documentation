---
title: Rozwiązanie działające dla zmiany rozmiaru arkusza
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
- Aspose.Slides for C++
description: "Rozwiązanie działające dla zmiany rozmiaru arkusza w prezentacjach PowerPoint przy użyciu C++"
---
{{% alert color="primary" %}}
Zaobserwowano, że arkusze Excel osadzone jako obiekty OLE w prezentacji PowerPoint za pośrednictwem komponentów Aspose są skalowane do nieokreślonego rozmiaru po pierwszej aktywacji. Zachowanie to powoduje zauważalną różnicę wizualną w prezentacji między stanem przed i po aktywacji obiektu OLE. Zbadaliśmy ten problem szczegółowo i przedstawiliśmy rozwiązanie, które opisano w tym artykule.
{{% /alert %}}

## **Tło**

W artykule [Zarządzaj OLE](/slides/pl/cpp/manage-ole/), wyjaśniliśmy, jak dodać ramkę OLE do prezentacji PowerPoint przy użyciu Aspose.Slides for C++. Aby rozwiązać [problem podglądu obiektu](/slides/pl/cpp/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wybranego obszaru arkusza do ramki obiektu OLE. W wygenerowanej prezentacji, po dwukrotnym kliknięciu ramki OLE wyświetlającej obraz arkusza, aktywowany jest skoroszyt Excel. Użytkownicy mogą wprowadzić dowolne zmiany w rzeczywistym skoroszycie Excel, a następnie powrócić do slajdu, klikając poza aktywnym skoroszytem Excel. Rozmiar ramki OLE zmieni się, gdy użytkownik wróci do slajdu. Współczynnik zmiany rozmiaru będzie się różnił w zależności od rozmiaru ramki OLE i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Ponieważ skoroszyt Excel posiada własny rozmiar okna, próbuje zachować pierwotny rozmiar przy pierwszej aktywacji. Z kolei ramka obiektu OLE ma własny rozmiar. Według Microsoftu, gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar, aby zapewnić utrzymanie prawidłowych proporcji w procesie osadzania. Zmiana rozmiaru zachodzi w oparciu o różnice pomiędzy rozmiarem okna Excel a rozmiarem i pozycją ramki obiektu OLE.

## **Rozwiązanie**

Istnieją dwa możliwe rozwiązania, aby uniknąć efektu zmiany rozmiaru.

- Skalowanie rozmiaru ramki OLE w prezentacji PowerPoint tak, aby odpowiadał wysokości i szerokości żądanej liczby wierszy i kolumn w ramce OLE.
- Zachowanie stałego rozmiaru ramki OLE i skalowanie rozmiaru uczestniczących wierszy i kolumn, aby zmieściły się w wybranym rozmiarze ramki OLE.

### **Skalowanie rozmiaru ramki OLE**

W tym podejściu nauczymy się, jak ustawić rozmiar ramki OLE osadzonego skoroszytu Excel, aby odpowiadał łącznemu rozmiarowi uczestniczących wierszy i kolumn w arkuszu Excel.

Załóżmy, że mamy szablon arkusza Excel i chcemy dodać go do prezentacji jako ramkę OLE. W tym scenariuszu rozmiar ramki OLE zostanie najpierw obliczony na podstawie łącznych wysokości wierszy i szerokości kolumn uczestniczących w skoroszycie. Następnie ustawimy rozmiar ramki OLE na tę obliczoną wartość. Aby uniknąć czerwonego komunikatu „EMBEDDED OLE OBJECT” dla ramki OLE w PowerPoint, przechwycimy także obraz żądanych fragmentów wierszy i kolumn w skoroszycie i ustawimy go jako obraz ramki OLE.

```cpp
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

```cpp
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

W tym podejściu nauczymy się, jak skalować wysokości uczestniczących wierszy i szerokość uczestniczących kolumn, aby dopasować je do niestandardowego rozmiaru ramki OLE.

Załóżmy, że mamy szablon arkusza Excel i chcemy dodać go do prezentacji jako ramkę OLE. W tym scenariuszu ustawimy rozmiar ramki OLE i skalujemy rozmiar wierszy oraz kolumn, które uczestniczą w obszarze ramki OLE. Następnie zapisujemy skoroszyt do strumienia, aby zastosować zmiany, i konwertujemy go na tablicę bajtów w celu dodania do ramki OLE. Aby uniknąć czerwonego komunikatu „EMBEDDED OLE OBJECT” dla ramki OLE w PowerPoint, przechwycimy także obraz żądanych fragmentów wierszy i kolumn w skoroszycie i ustawimy go jako obraz ramki OLE.

```cpp
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

// Skaluj zakres komórek, aby dopasować go do rozmiaru ramki.
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

```cpp
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

```cpp
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

## **Podsumowanie**

{{% alert color="primary" %}}
Istnieją dwa podejścia do rozwiązania problemu zmiany rozmiaru arkusza. Wybór odpowiedniego podejścia zależy od konkretnych wymagań i scenariusza użycia. Oba podejścia działają tak samo, niezależnie od tego, czy prezentacje są tworzone na podstawie szablonu, czy od zera. Dodatkowo w tym rozwiązaniu nie ma ograniczenia co do rozmiaru ramki OLE.
{{% /alert %}}

## **FAQ**

**Dlaczego osadzony arkusz Excel zmienia rozmiar po pierwszej aktywacji w PowerPoint?**  
Dzieje się tak, ponieważ Excel próbuje zachować pierwotny rozmiar okna po aktywacji, podczas gdy ramka OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby utrzymać proporcje, co może prowadzić do zmiany rozmiaru.

**Czy można całkowicie zapobiec temu problemowi ze zmianą rozmiaru?**  
Tak. Skalując ramkę OLE tak, aby pasowała do rozmiaru zakresu komórek Excel, lub skalując zakres komórek, aby pasował do żądanego rozmiaru ramki OLE, można uniknąć niepożądanej zmiany rozmiaru.

** którą metodę skalowania powinienem wybrać, skalowanie ramki OLE czy skalowanie zakresu komórek?**  
Wybierz **skalowanie ramki OLE**, jeśli chcesz zachować pierwotne rozmiary wierszy i kolumn w Excelu. Wybierz **skalowanie zakresu komórek**, jeśli potrzebujesz stałego rozmiaru ramki OLE w prezentacji.

**Czy te rozwiązania działają, jeśli moja prezentacja jest oparta na szablonie?**  
Tak. Oba rozwiązania działają zarówno dla prezentacji utworzonych na podstawie szablonów, jak i tworzonych od podstaw.

**Czy istnieje limit rozmiaru ramki OLE przy stosowaniu tych metod?**  
Nie. Możesz ustawić dowolny rozmiar ramki OLE, o ile odpowiednio skalujesz zawartość.

**Czy istnieje sposób, aby uniknąć tekstu zastępczego „EMBEDDED OLE OBJECT” w PowerPoint?**  
Tak. Tworząc zrzut docelowego zakresu komórek Excel i ustawiając go jako obraz zastępczy ramki OLE, możesz wyświetlić własny podgląd zamiast domyślnego tekstu zastępczego.

## **Powiązane artykuły**

[Tworzenie wykresu Excel i osadzanie go w prezentacji jako obiekt OLE](/slides/pl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)