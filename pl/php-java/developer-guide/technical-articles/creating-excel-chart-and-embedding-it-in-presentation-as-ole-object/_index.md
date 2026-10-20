---
title: Tworzenie wykresów Excel i osadzanie ich w prezentacjach jako obiekty OLE
type: docs
weight: 30
url: /pl/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Wykres Excel
- osadź wykres
- obiekt OLE
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Utwórz wykres Excel przy użyciu Aspose.Cells for PHP via Java i osadź skoroszyt w prezentacji PowerPoint przy użyciu Aspose.Slides for PHP via Java, w tym podgląd wykresu."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć wykres słupkowy Excel przy użyciu Aspose.Cells for PHP via Java i osadzić jego skoroszyt w prezentacji PowerPoint przy użyciu Aspose.Slides for PHP via Java. Osadzony skoroszyt zawiera zarówno dane źródłowe, jak i wykres. Oddzielny podgląd PNG wyświetla wykres na slajdzie przed aktywacją obiektu OLE.

Wynikiem jest osadzony obiekt Excel, a nie natywny wykres PowerPoint. Edycja skoroszytu poprzez OLE wymaga aplikacji desktopowej obsługującej aktywację OLE oraz kompatybilnej instalacji Excel.

## **Wymagania wstępne**

Skonfiguruj Aspose.Cells for PHP via Java oraz Aspose.Slides for PHP via Java przy użyciu tej samej instancji PHP/Java Bridge. Załaduj oba opakowania PHP i udostępnij biblioteki Java obu produktów mostowi. Microsoft Office nie jest wymagany do generowania prezentacji przy użyciu tych bibliotek.

Pliki wejściowe nie są wymagane: przykład tworzy dane i wykres w pamięci, a następnie zapisuje `OutputChart.pptx` w bieżącym katalogu roboczym. Należy zastosować licencje obu produktów, gdy uruchamiane jest poza trybem ewaluacyjnym.

## **Jak działa osadzanie**

1. Utwórz skoroszyt z arkuszem danych i arkuszem wykresu.  
2. Ustaw arkusz wykresu jako aktywny, aby skoroszyt otwierał się na wykresie.  
3. Ustaw zakres wyświetlania OLE skoroszytu i wyrenderuj wykres do PNG.  
4. Zapisz skoroszyt jako XLSX w pamięci i osadź te bajty na slajdzie.  
5. Przypisz PNG jako podgląd obiektu OLE i zapisz prezentację jako PPTX.

Zakres wyświetlania skoroszytu i ramka na slajdzie pełnią różne role. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) przyjmuje indeksy wierszy i kolumn zaczynające się od zera. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) natomiast przyjmuje wiersz górny, kolumnę lewą, wiersz dolny i kolumnę prawą. Przykład używa indeksu wiersza 55 i indeksu kolumny 25 jako prawego dolnego ograniczenia; wartości te są wyborami układu, a nie liczbą wierszy lub kolumn danych.

Rama slajdu używa jednostki punktów. Przykład dopasowuje ją do slajdu i centruje, zachowując proporcje PNG, zamiast rozciągać podgląd, aby wypełnić slajd.

## **Utwórz i osadź wykres**

Poniższy kompletny przykład wypełnia `DataSheet` czterema wierszami i pięcioma kolumnami wartości. Każdy wiersz staje się serią wykresu. `ChartSheet` jest wybierany jako arkusz aktywny przed zapisaniem skoroszytu.

Skoroszyt jest jawnie zapisywany jako XLSX, co odpowiada rozszerzeniu `xlsx` przekazywanemu do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/). Wyniki liczbowe Java są konwertowane za pomocą `java_values` przed wykonaniem operacji arytmetycznych w PHP, podczas gdy dane binarne pozostają w tablicach bajtów Java. PNG jest ładowany bezpośrednio z jego bajtów, bez pośredniej konwersji bitmapy. Przypisanie go przez [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) zastępuje domyślny placeholder OLE.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Zachowaj PNG i XLSX jako tablice bajtów Java przy przekazywaniu ich do Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // Dopasuj i wyśrodkuj podgląd, zachowując jego proporcje.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Oczekiwany wynik**

`OutputChart.pptx` zawiera jeden slajd z osadzonym skoroszytem Excel i podglądem wykresu. Skoroszyt zawiera oryginalne dane oraz wykres słupkowy z czterema seriami. Podgląd jest wyśrodkowany na slajdzie i zachowuje proporcje.

![Wykres słupkowy Excel wyświetlany jako podgląd osadzonego skoroszytu](excel-chart-ole-preview.png)

W kompatybilnym środowisku PowerPoint na komputerze, w którym dostępny jest Excel, dwukrotne kliknięcie obiektu aktywuje i umożliwi edycję osadzonego skoroszytu. Aktywacja i edycja zależą od wsparcia OLE w aplikacji hosta oraz ustawień zabezpieczeń.

## **Najczęściej zadawane pytania**

**Dlaczego potrzebny jest obraz podglądu?**

Osadzony skoroszyt i jego podgląd na slajdzie są odrębną zawartością. Dostarcz obraz wykresu, aby slajd wyświetlał wykres zamiast domyślnego placeholdera "EMBEDDED OLE OBJECT". Zobacz [Problem podglądu obiektu przy dodawaniu OleObjectFrame](/slides/pl/php-java/object-preview-issue-when-adding-oleobjectframe/).

**Czy podgląd aktualizuje się automatycznie po zmianie skoroszytu w kodzie?**

Traktuj podgląd jako migawkę. Przy programowej aktualizacji danych skoroszytu, wygeneruj ponownie obraz wykresu i zamień podgląd oraz osadzone dane skoroszytu.

**Czy mogę używać XLS zamiast XLSX?**

Tak. Zapisz skoroszyt w formacie XLS i użyj `xls` jako rozszerzenia osadzonych danych. Rozszerzenie musi odpowiadać rzeczywistemu formatowi skoroszytu; samo zmienienie rozszerzenia nie konwertuje danych.

**Dlaczego obiekt może zmienić rozmiar po aktywacji?**

Aplikacja hosta może zaktualizować wyświetlanie obiektu OLE po aktywacji skoroszytu. Zarówno zakres wyświetlania OLE skoroszytu, jak i wymiary ramki slajdu mają znaczenie. Zobacz [Działające rozwiązanie dla zmiany rozmiaru wykresu w PPTX](/slides/pl/java/working-solution-for-chart-resizing-in-pptx/).

## **Powiązane sekcje**

- [Działające rozwiązanie dla zmiany rozmiaru wykresu w PPTX](/slides/pl/java/working-solution-for-chart-resizing-in-pptx/)
- [Problem podglądu obiektu przy dodawaniu OleObjectFrame](/slides/pl/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [Zarządzanie obiektami OLE](/slides/pl/php-java/manage-ole/)