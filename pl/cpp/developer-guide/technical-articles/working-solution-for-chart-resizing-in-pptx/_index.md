---
title: Rozwiązanie działające dla zmiany rozmiaru wykresu w PPTX
type: docs
weight: 60
url: /pl/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- zmiana rozmiaru wykresu
- wykres Excel
- obiekt OLE
- osadzanie wykresu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Napraw nieoczekiwaną zmianę rozmiaru wykresu w PPTX przy użyciu osadzonych obiektów Excel OLE w Aspose.Slides dla C++. Ustaw stałe wymiary wykresu, aby zachować spójność rozmiarów wykresu i ramki OLE."
---
## **Tło**

Wykresy Excel osadzone jako obiekty OLE w prezentacjach PowerPoint przy użyciu komponentów Aspose mogą zmieniać rozmiar po ich pierwszej aktywacji. Może to powodować zauważalną różnicę w wyglądzie wykresu przed i po aktywacji. Ten artykuł wyjaśnia, dlaczego dochodzi do zmiany rozmiaru i pokazuje, jak temu zapobiec, dopasowując stałe wymiary wykresu do ramki OLE.

W [Utwórz wykresy Excel i osadź je jako obiekty OLE w prezentacjach](/slides/pl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), wyjaśniliśmy, jak stworzyć wykres Excel przy użyciu Aspose.Cells for C++ i osadzić go w prezentacji PowerPoint przy użyciu Aspose.Slides for C++. Aby rozwiązać [problem podglądu obiektu](/slides/pl/cpp/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wykresu do ramki obiektu OLE wykresu. W wynikowej prezentacji, po dwukrotnym kliknięciu ramki obiektu OLE wyświetlającej obraz wykresu, wykres Excel jest aktywowany. Użytkownicy mogą edytować osadzony skoroszyt Excel, a następnie wrócić do slajdu, klikając poza aktywowanym skoroszytem. Rozmiar ramki obiektu OLE zmienia się, gdy użytkownik wraca do slajdu, a współczynnik zmiany rozmiaru zależy od pierwotnych rozmiarów zarówno ramki obiektu OLE, jak i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Osadzony skoroszyt Excel ma własne wymiary okna, które Excel stara się zachować przy pierwszej aktywacji obiektu. Ramka OLE na slajdzie ma niezależnie określone wymiary. Gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar obiektu, aby utrzymać jego proporcje w ramach procesu osadzania. Różnice między oknem skoroszytu a ramką OLE mogą więc powodować zmianę rozmiaru obiektu.

## **Rozwiązanie**

Dopasuj rozmiar wykresu do ramki OLE na slajdzie i utrzymaj wymiary wykresu niezależne od okna skoroszytu. To rozwiązanie działa zarówno z nową prezentacją, jak i istniejącym szablonem.

Przykład wymaga Aspose.Cells for C++ oraz Aspose.Slides for C++. Tworzy prosty wykres kolumnowy na aktywnej arkuszu wykresu i osadza skoroszyt w formacie XLS. Nie przypisano obrazu podglądu wykresu; wykres staje się widoczny po aktywacji obiektu OLE w PowerPoint.

Umieść kod przykładu w punkcie wejścia aplikacji, z deklaracjami `#include` na poziomie pliku. Zainicjalizuj Aspose.Cells przed tworzeniem jego obiektów i zwolnij jego zasoby po ich zniszczeniu. Przykład kopiuje wektor bajtów skoroszytu zwrócony przez Aspose.Cells do tablicy akceptowanej przez Aspose.Slides.

Przykład tworzy nową prezentację z ramką OLE o wymiarach 9,5 × 4 cala, umieszczoną 0,5 cala od lewej krawędzi i 1 cala od góry. Współrzędne i wymiary slajdu podawane są w punktach (72 punkty na cal). Dla istniejącej prezentacji zobacz [Użyj szablonu](#use-a-template).

## **Ustaw stały rozmiar wykresu**

Ustaw [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) na `false`, aby wymiary wykresu były niezależne od okna skoroszytu. Ustaw wymiary [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) przy pomocy [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) i [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), konwertując punkty na piksele przy 96 pikselach na cal: ramka o wymiarach 684 × 288 punktów odpowiada wykresowi o wymiarach 912 × 384 piksele. Ustaw [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) na wartość `Custom` typu [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). Przykład osadza skoroszyt przy pomocy [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) i zapisuje prezentację z ramką OLE o wymiarach 9,5 × 4 cala.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Współrzędne i wymiary slajdu są w punktach (72 punkty na cal).
    auto width = 684.f; // 9,5 cala.
    auto height = 288.f; // 4 cale.

    chart.SetSizeWithWindow(false);
    // Konwertuj punkty na piksele wykresu przy użyciu 96 pikseli na cal.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Skopiuj wektor bajtów Cells do typu tablicy akceptowanego przez Slides.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Użyj szablonu**

Logika wymiarowania jest taka sama dla istniejącej prezentacji. Aby dostosować przykład:

1. Załaduj prezentację szablonu zamiast tworzyć pustą prezentację.
1. Sprawdź, czy pierwszy slajd zawiera co najmniej trzy kształty, a następnie użyj kształtu o indeksie 2 jako symbolu zastępczego.
1. Pobierz szerokość i wysokość ramki z tego kształtu zamiast używać stałych wartości 684 i 288. Zachowaj niezmienione obliczenia wymiarów.
1. Dodaj ramkę OLE w pozycji symbolu zastępczego zamiast stałych współrzędnych 36 i 72.
1. Usuń symbol zastępczy przed zapisaniem prezentacji.

## **FAQ**

**Dlaczego mój osadzony wykres Excel zmienia rozmiar po aktywacji w PowerPoint?**

Dzieje się tak, ponieważ Excel próbuje przywrócić pierwotny rozmiar okna przy pierwszej aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby zachować proporcje, co może powodować zmianę rozmiaru.

**Jak utrzymać spójność rozmiarów wykresu i ramki OLE?**

Ustaw stałe wymiary wykresu, które odpowiadają ramce OLE, i użyj niestandardowego rozmiaru wydruku wykresu przed osadzeniem skoroszytu. Powyższy przykład pokazuje wymagane ustawienia i konwersje jednostek.

**Czy dopasowanie rozmiaru okna skoroszytu wystarczy?**

Dopasowanie samego rozmiaru okna skoroszytu nie zapobiega w sposób niezawodny zmianie rozmiaru ramki OLE po aktywacji. Użyj stałych wymiarów wykresu, jak pokazano w przykładzie.

**Czy to rozwiązanie działa zarówno z prezentacjami opartymi na szablonie, jak i nowymi prezentacjami?**

Tak. Dla szablonu użyj wymiarów i pozycji symbolu zastępczego. Dla nowej prezentacji podaj wymiary i pozycję ramki bezpośrednio.

**Czy mogę użyć tego przykładu z wykresami utworzonymi w innych programach arkuszy?**

Przykład używa skoroszytu Excel utworzonego przy pomocy Aspose.Cells. Nie demonstruje zachowania aktywacji dla innych programów arkuszy.

## **Powiązane sekcje**

- [Utwórz wykresy Excel i osadź je jako obiekty OLE w prezentacjach](/slides/pl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)