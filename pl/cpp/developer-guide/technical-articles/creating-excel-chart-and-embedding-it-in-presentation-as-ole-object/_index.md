---
title: Tworzenie wykresów Excel i osadzanie ich w prezentacjach jako obiekty OLE
type: docs
weight: 40
url: /pl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- wykres Excel
- osadzanie wykresu
- obiekt OLE
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Utwórz wykres Excel przy użyciu Aspose.Cells dla C++ i osadź skoroszyt w prezentacji PowerPoint przy użyciu Aspose.Slides, w tym podgląd wykresu."
---
## **Przegląd**

Ten artykuł pokazuje, jak stworzyć wykres słupkowy w Excelu przy użyciu Aspose.Cells for C++ i osadzić jego skoroszyt w prezentacji PowerPoint przy użyciu Aspose.Slides for C++. Osadzony skoroszyt zawiera zarówno dane źródłowe, jak i wykres. Osobny podgląd PNG wyświetla wykres na slajdzie przed aktywacją obiektu OLE.

Wynikiem jest osadzony obiekt Excel, a nie natywny wykres PowerPoint. Edycja skoroszytu przez OLE wymaga aplikacji desktopowej obsługującej aktywację OLE oraz kompatybilnej instalacji Excela.

## **Wymagania wstępne**

Skonfiguruj swój projekt C++ z nagłówkami i bibliotekami dla Aspose.Cells for C++ oraz Aspose.Slides for C++. Umieść przykładowy kod w punkcie wejścia aplikacji, z deklaracjami include na poziomie pliku. Microsoft Office nie jest wymagany do generowania prezentacji przy użyciu tych bibliotek.

Nie są wymagane pliki wejściowe: przykład tworzy dane i wykres w pamięci, a następnie zapisuje `OutputChart.pptx` w bieżącym katalogu roboczym. Zastosuj licencje dla obu produktów podczas uruchamiania poza trybem ewaluacji.

## **Jak działa osadzanie**

1. Utwórz skoroszyt z arkuszem danych i arkuszem wykresu.  
1. Ustaw arkusz wykresu jako aktywny, aby skoroszyt otwierał się na wykresie.  
1. Ustaw zakres wyświetlania OLE skoroszytu i wyrenderuj wykres do PNG.  
1. Zapisz skoroszyt jako XLSX w pamięci i osadź te bajty w slajdzie.  
1. Przypisz PNG jako podgląd obiektu OLE i zapisz prezentację jako PPTX.

Zakres wyświetlania skoroszytu i ramka na slajdzie mają różne role. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) przyjmuje indeksy wierszy i kolumn zaczynające się od zera. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) przyjmuje natomiast górny wiersz, lewą kolumnę, dolny wiersz i prawą kolumnę. Przykład używa indeksu wiersza 55 i indeksu kolumny 25 jako dolno‑prawego granic; te wartości są decyzjami układu, a nie liczbą wierszy lub kolumn danych.

Rama slajdu używa punktów. Przykład dopasowuje ją do slajdu i centrował, zachowując proporcje PNG, zamiast rozciągać podgląd, aby wypełnić slajd.

## **Utwórz i osadź wykres**

Podany kompletny przykład wypełnia `DataSheet` czterema wierszami i pięcioma kolumnami wartości. Każdy wiersz staje się serią wykresu. `ChartSheet` jest wybierany jako aktywny arkusz przed zapisaniem skoroszytu.

Skoroszyt jest jawnie zapisywany jako XLSX, co odpowiada rozszerzeniu `xlsx` przekazywanemu do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG jest ładowany ze strumienia w pamięci bez pośredniej konwersji bitmapy. Aspose.Cells zwraca wektory bajtów, które przykład kopiuje do typu tablicy akceptowanego przez Aspose.Slides. Zainicjuj Aspose.Cells przed użyciem jego obiektów i zwolnij jego zasoby po zniszczeniu tych obiektów. Przypisanie przez [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) zastępuje domyślny placeholder OLE.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Zainicjalizuj Cells przed tworzeniem jakichkolwiek jego obiektów.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // Renderuj podgląd wykresu i osobno serializuj edytowalny skoroszyt.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Skopiuj bufory Cells do typu tablicy używanego przez Slides.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // Dopasuj podgląd do slajdu bez zmiany proporcji.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// Zwolnij zasoby Cells po zniszczeniu wszystkich obiektów Cells.
Aspose::Cells::Cleanup();
```

## **Oczekiwany wynik**

`OutputChart.pptx` zawiera jeden slajd z osadzonym skoroszytem Excel oraz podglądem wykresu. Skoroszyt zawiera oryginalne dane i wykres słupkowy z czterema seriami. Podgląd jest wyśrodkowany na slajdzie i zachowuje proporcje.

![Wykres słupkowy Excel wyświetlany jako podgląd osadzonego skoroszytu](excel-chart-ole-preview.png)

W zgodnym środowisku desktopowym PowerPoint z dostępnym Excelem, dwukrotne kliknięcie obiektu aktywuje i umożliwi edycję osadzonego skoroszytu. Aktywacja i edycja zależą od obsługi OLE oraz ustawień zabezpieczeń aplikacji hosta.

## **FAQ**

**Dlaczego potrzebny jest obraz podglądu?**

Osadzony skoroszyt i jego podgląd slajdu to osobne treści. Dostarcz obraz wykresu, aby slajd pokazywał wykres zamiast domyślnego placeholdera "EMBEDDED OLE OBJECT". Zobacz [Problem z podglądem obiektu przy dodawaniu OleObjectFrame](/slides/pl/cpp/object-preview-issue-when-adding-oleobjectframe/).

**Czy podgląd aktualizuje się automatycznie po zmianie skoroszytu w kodzie?**

Traktuj podgląd jako migawkę. Przy programowej aktualizacji danych skoroszytu, odtwórz obraz wykresu i zastąp podgląd oraz osadzone dane skoroszytu.

**Czy mogę używać XLS zamiast XLSX?**

Tak. Zapisz skoroszyt w formacie XLS i użyj `xls` jako rozszerzenia danych osadzonych. Rozszerzenie musi odpowiadać rzeczywistemu formatowi skoroszytu; samo zmienienie rozszerzenia nie konwertuje danych.

**Dlaczego obiekt może zmienić rozmiar po aktywacji?**

Aplikacja hosta może zaktualizować wygląd obiektu OLE po aktywacji skoroszytu. Zakres wyświetlania OLE skoroszytu i wymiary ramki slajdu mają znaczenie. Zobacz [Działające rozwiązanie dla zmiany rozmiaru wykresu w PPTX](/slides/pl/cpp/working-solution-for-chart-resizing-in-pptx/).

## **Powiązane sekcje**

- [Działające rozwiązanie dla zmiany rozmiaru wykresu w PPTX](/slides/pl/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Problem z podglądem obiektu przy dodawaniu OleObjectFrame](/slides/pl/cpp/object-preview-issue-when-adding-oleobjectframe/)