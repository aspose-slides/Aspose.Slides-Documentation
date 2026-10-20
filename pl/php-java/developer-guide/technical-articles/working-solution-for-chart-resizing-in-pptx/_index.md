---
title: Działające rozwiązanie dla zmiany rozmiaru wykresu w PPTX
type: docs
weight: 40
url: /pl/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- zmiana rozmiaru wykresu
- wykres Excel
- obiekt OLE
- osadź wykres
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Napraw nieoczekiwaną zmianę rozmiaru wykresu w PPTX przy użyciu osadzonych obiektów Excel OLE z Aspose.Slides dla PHP via Java. Ustaw stałe wymiary wykresu, aby utrzymać spójność rozmiarów wykresu i ramki OLE."
---
## **Przegląd**

Wykresy Excel osadzone jako obiekty OLE w prezentacjach PowerPoint przy użyciu komponentów Aspose mogą zmieniać rozmiar po pierwszej aktywacji. Może to powodować zauważalną różnicę w wyglądzie wykresu przed i po aktywacji. Ten artykuł wyjaśnia, dlaczego zachodzi zmiana rozmiaru i pokazuje, jak jej zapobiec, dopasowując stałe wymiary wykresu do ramki OLE.

W [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/pl/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) wyjaśniliśmy, jak utworzyć wykres Excel przy użyciu Aspose.Cells dla PHP via Java i osadzić go w prezentacji PowerPoint przy użyciu Aspose.Slides dla PHP via Java. Aby rozwiązać problem [object preview issue](/slides/pl/php-java/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wykresu do ramki obiektu OLE wykresu. W wygenerowanej prezentacji, po dwukrotnym kliknięciu ramki obiektu OLE wyświetlającej obraz wykresu, wykres Excel zostaje aktywowany. Użytkownicy mogą edytować osadzony skoroszyt Excel, a następnie wrócić do slajdu, klikając poza aktywowanym skoroszytem. Rozmiar ramki obiektu OLE zmienia się, gdy użytkownik wraca do slajdu, a współczynnik zmiany rozmiaru zależy od pierwotnych rozmiarów zarówno ramki obiektu OLE, jak i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Osadzony skoroszyt Excel ma własne wymiary okna, które Excel stara się zachować przy pierwszej aktywacji obiektu. Ramka OLE na slajdzie ma niezależnie zdefiniowane wymiary. Gdy skoroszyt Excel zostaje aktywowany, Excel i PowerPoint negocjują rozmiar obiektu, aby utrzymać jego proporcje w ramach procesu osadzania. Różnice między oknem skoroszytu a ramką OLE mogą więc powodować zmianę rozmiaru obiektu.

## **Rozwiązanie działające**

Dopasuj rozmiar wykresu do ramki OLE na slajdzie i utrzymaj wymiary wykresu niezależne od okna skoroszytu. To rozwiązanie działa zarówno z nową prezentacją, jak i istniejącym szablonem.

Przykład wymaga Aspose.Cells dla PHP via Java oraz Aspose.Slides dla PHP via Java. Skonfiguruj oba produkty z tym samym wystąpieniem PHP/Java Bridge, załaduj oba wrappery PHP i udostępnij obie biblioteki Java mostowi. Nie są wymagane żadne pliki wejściowe. Tworzy prosty wykres kolumnowy na aktywnym arkuszu wykresu i osadza skoroszyt w formacie XLS. Nie przypisuje się obrazu podglądu wykresu; wykres staje się widoczny po aktywacji obiektu OLE w PowerPoint.

Przykład tworzy nową prezentację z ramką OLE o wymiarach 9,5 × 4 cala, umieszczoną 0,5 cala od lewej krawędzi i 1 cala od góry. Współrzędne i wymiary slajdu są podane w punktach (72 punkty na cal). Dla istniejącej prezentacji zobacz [Use a Template](#use-a-template).

## **Ustaw stały rozmiar wykresu**

Ustaw [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) na false, aby wymiary wykresu były niezależne od okna skoroszytu. Ustaw wymiary [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) za pomocą [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) i [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height), konwertując punkty na piksele przy użyciu 96 pikseli na cal: ramka o wymiarach 684 × 288 punktów odpowiada wykresowi o wymiarach 912 × 384 pikseli. Ustaw [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) na wartość CUSTOM typu [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/). Przykład osadza skoroszyt przy pomocy [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) i zapisuje prezentację z ramką OLE o wymiarach 9,5 × 4 cala.

Wyniki liczbowe Java są konwertowane przy użyciu `java_values` przed ich użyciem jako indeksy PHP. Bajty skoroszytu pozostają w tablicy bajtów Java przy przekazywaniu ich do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/).

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Współrzędne slajdu i wymiary podane są w punktach (72 punkty na cal).
        $width = 684; // 9.5 cala.
        $height = 288; // 4 cale.

        $chart->setSizeWithWindow(false);
        // Konwertuj punkty na piksele wykresu używając 96 pikseli na cal.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Użyj szablonu**

Logika określania rozmiaru jest taka sama dla istniejącej prezentacji. Aby dostosować przykład:

1. Wczytaj prezentację szablonu zamiast tworzyć pustą prezentację.
1. Sprawdź, czy pierwszy slajd zawiera co najmniej trzy kształty, a następnie użyj kształtu o indeksie 2 jako zastępnika.
1. Pobierz szerokość i wysokość ramki z tego kształtu zamiast używać stałych wartości 684 i 288. Zachowaj niezmienione obliczenia rozmiaru.
1. Dodaj ramkę OLE na pozycję zastępnika zamiast stałych współrzędnych 36 i 72.
1. Usuń zastępnik przed zapisaniem prezentacji.

## **FAQ**

**Dlaczego mój osadzony wykres Excel zmienia rozmiar po aktywowaniu go w PowerPoint?**  
Dzieje się tak, ponieważ Excel próbuje przywrócić pierwotny rozmiar okna przy pierwszej aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby zachować proporcje, co może powodować zmianę rozmiaru.

**Jak mogę zachować spójność rozmiarów wykresu i ramki OLE?**  
Ustaw stałe wymiary wykresu, które odpowiadają ramce OLE, oraz użyj niestandardowego rozmiaru wydruku wykresu przed osadzeniem skoroszytu. Powyższy przykład pokazuje wymagane ustawienia i konwersje jednostek.

**Czy dopasowanie rozmiaru okna skoroszytu wystarczy?**  
Dopasowanie samego rozmiaru okna skoroszytu nie zapewnia pewnego zapobieżenia zmianie rozmiaru ramki OLE po aktywacji. Użyj stałych wymiarów wykresu, jak pokazano w przykładzie.

**Czy to rozwiązanie działa zarówno z prezentacjami opartymi na szablonie, jak i nowymi prezentacjami?**  
Tak. Dla szablonu użyj wymiarów i pozycji zastępnika. Dla nowej prezentacji określ wymiary i pozycję ramki bezpośrednio.

**Czy mogę użyć tego przykładu z wykresami utworzonymi w innych programach arkuszy kalkulacyjnych?**  
Przykład wykorzystuje skoroszyt Excel utworzony za pomocą Aspose.Cells. Nie pokazuje zachowania aktywacji dla innych programów arkuszy kalkulacyjnych.

## **Powiązane sekcje**

- [Tworzenie wykresów Excel i osadzanie ich jako obiekty OLE w prezentacjach](/slides/pl/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)