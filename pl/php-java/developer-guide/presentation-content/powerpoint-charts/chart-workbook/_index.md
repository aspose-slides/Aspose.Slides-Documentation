---
title: Zarządzanie skoroszytami wykresów w prezentacjach przy użyciu PHP
linktitle: Skoroszyt wykresu
type: docs
weight: 70
url: /pl/php-java/chart-workbook/
keywords:
- skoroszyt wykresu
- dane wykresu
- komórka skoroszytu
- etykieta danych
- arkusz
- źródło danych
- zewnętrzny skoroszyt
- zewnętrzne dane
- pamięć podręczna wykresu
- odzyskiwanie skoroszytu
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Odkryj Aspose.Slides dla PHP via Java: łatwo zarządzaj skoroszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z skoroszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu przy użyciu strumieni skoroszytów, używać komórek skoroszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówiono również pracę z zewnętrznymi skoroszytami jako źródłami danych wykresu. Przykłady pokazują, jak utworzyć i przypisać zewnętrzny skoroszyt, pobrać ścieżkę zewnętrznego skoroszytu powiązanego z wykresem oraz edytować dane wykresu, gdy skoroszyt jest dostępny.

W przypadku komórek skoroszytu, które reprezentują brakujące dane, zobacz [Kontrolowanie wyświetlania pustych komórek](/slides/pl/php-java/chart-series/) aby poznać różnicę między pustą komórką a zerem oraz porównanie linii wykresu dostępnych trybów wyświetlania.

## **Dołączanie danych z ukrytych wierszy i kolumn**

Użyj [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/setplotvisiblecellsonly/) aby kontrolować, czy wykres rysuje dane z ukrytych wierszy i kolumn arkusza. Ustaw na `true`, aby rysować tylko widoczne komórki, lub na `false`, aby uwzględnić zarówno widoczne, jak i ukryte komórki. To ustawienie kontroluje rysowanie wykresu; nie ukrywa ani nie odsłania wierszy lub kolumn arkusza.

Pobierz [hidden-source-data.pptx](hidden-source-data.pptx) i umieść w katalogu roboczym. Na pierwszym slajdzie znajduje się wykres słupkowy jako pierwszy kształt. Osadzony arkusz, `Sheet1`, zawiera zakres źródłowy `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Wiersz arkusza | A: Miesiąc | B: Detal | C: Hurt (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | Styczeń | 10 | 30 |
| 3 (ukryty wiersz) | Luty | 40 | 60 |
| 4 | Marzec | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych przez [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getchartdataworkbook/) i odczytaj [ChartDataCell::isHidden](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/ishidden/), aby sprawdzić ich status ukrycia. Ta metoda zgłasza status ukrycia bez jego zmiany. W tym pliku B2 jest widoczny, B3 należy do ukrytego wiersza, a C2 do ukrytej kolumny; przykład wypisuje kolejno `false`, `true` i `true`.

Dla tego przykładu odśwież dane wykresu po zmianie ustawienia rysowania: zachowaj osadzony skoroszyt przy użyciu [readWorkbookStream](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/readworkbookstream/) i ponownie załaduj go przy pomocy [writeWorkbookStream](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/writeworkbookstream/). Przy uwzględnianiu wszystkich komórek użyj także [setRange](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/setrange/), aby przywrócić pełny zakres, w tym ukrytą kategorię luty. Samej zmiany flagi nie wystarczy, aby odświeżyć buforowane dane wykresu i etykiety kategorii w tym przykładzie.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // Odśwież dane wykresu z osadzonego skoroszytu.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Przywróć pełny zakres źródłowy, w tym ukryte kategorie.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Przykład zapisuje `hidden_cells_true.pptx` tylko z widocznymi wartościami detalicznymi (10 i 20) oraz `hidden_cells_false.pptx` ze wszystkimi sześcioma wartościami. Poniższe obrazy ilustrują dwa tryby rysowania. Wiersz 3 i kolumna C pozostają ukryte w obu osadzonych skoroszytach.

| Tylko widoczne komórki (`true`) | Wszystkie komórki (`false`) |
| --- | --- |
| ![Tylko widoczne komórki: wartości detaliczne 10 i 20 dla stycznia i marca.](hidden_cells_True.png) | ![Wszystkie komórki: wartości detaliczne i hurtowe dla stycznia, lutego i marca.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/setdisplayblanksas/) kontroluje, jak wyświetlane są brakujące wartości; nie obejmuje ani nie wyklucza ukrytych danych źródłowych. Zobacz [Kontrolowanie wyświetlania pustych komórek](/slides/pl/php-java/chart-series/#control-the-display-of-empty-cells) dla przykładu.

## **Odczyt i zapis danych wykresu ze skoroszytu**

Aspose.Slides for PHP via Java udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/readworkbookstream/) i [writeWorkbookStream](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/writeworkbookstream/), które umożliwiają odczyt i zapis skoroszytów danych wykresu (zawierających dane wykresu edytowane przy pomocy Aspose.Cells). **Uwaga** dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten przykład otwiera `chart.pptx`, który musi zawierać wykres jako pierwszy kształt na pierwszym slajdzie. Odczytuje osadzony skoroszyt do tablicy bajtów, czyści istniejące serie i kategorie, a następnie zapisuje ten sam skoroszyt z powrotem. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Walidacja układu wykresu po modyfikacji skoroszytu**

Gdy zastąpisz osadzony skoroszyt zmodyfikowanym, wykres zachowuje pierwotne kolekcje serii i kategorii. To niezgodność może spowodować błąd [Chart::validateChartLayout](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/validatechartlayout/) z komunikatem „index out of range”. Wyczyść istniejące serie i kategorie przed zapisaniem zaktualizowanego skoroszytu z powrotem do wykresu. Ten przykład wymaga `chart.pptx` z wykresem jako pierwszym kształtem na pierwszym slajdzie. Komentarz wskazuje, gdzie mogłaby odbywać się edycja skoroszytu; działający przykład zapisuje oryginalny skoroszyt z powrotem i waliduje układ w pamięci.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // Modyfikuj bajty skoroszytu tutaj, na przykład przy użyciu Aspose.Cells.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Wyczyść kolekcje, aby usunąć przestarzałe referencje danych przed zapisaniem skoroszytu. Przed użyciem wykresu odbuduj wymagane mapowania serii i kategorii dla zaktualizowanego skoroszytu.

## **Ustawienie komórki skoroszytu jako etykiety danych wykresu**

Można używać tekstu z komórek skoroszytu jako etykiet danych wykresu. Poniższe kroki pokazują, jak połączyć etykiety w wykresie bąbelkowym z komórkami w jego skoroszycie danych.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu, używając indeksu zerowego.
3. Dodaj wykres bąbelkowy z domyślnymi danymi.
4. Uzyskaj dostęp do serii wykresu.
5. Ustaw komórkę skoroszytu jako etykietę danych.
6. Zapisz prezentację.

Ten przykład otwiera `chart2.pptx`, który musi zawierać co najmniej jeden slajd, i dodaje wykres bąbelkowy z domyślnymi danymi. Używa komórek A10:A12 w arkuszu 0 dla pierwszych trzech etykiet w pierwszej serii, włącza etykiety z komórek i zapisuje wynik jako `resultchart.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zarządzanie arkuszami**

Metoda [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/getworksheets/) zapewnia dostęp do arkuszy w skoroszycie wykresu. Ten przykład tworzy wykres kołowy z domyślnymi danymi i wypisuje nazwę każdego arkusza na konsolę.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Określenie typu źródła danych**

Ten przykład tworzy wykres słupkowy 3D z domyślnymi danymi i ustawia dwie nazwy serii przy użyciu różnych źródeł danych. Pierwsza nazwa używa literału łańcuchowego; druga korzysta z komórki C1 w arkuszu 0. Enumera­tor [DataSourceType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datasourcetype/) wybiera źródło dla każdej nazwy. Wynik jest zapisywany jako `pres.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Wykrywanie nieobsługiwanych formatów osadzonych skoroszytów**

Aspose.Slides nie obsługuje formatu binarnego skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Można użyć metody `getEmbeddedWorkbookType` na [ChartData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/) wraz z enumeratorem [WorkbookType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/workbooktype/), aby wykryć nieobsługiwane formaty i pominąć takie wykresy. Ten przykład sprawdza kształty na pierwszym slajdzie `sample.pptx`, pomija kształty nie będące wykresami i wypisuje komunikat diagnostyczny dla każdego wykresu z osadzonym skoroszytem .xlsb.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // Odczytaj lub zmodyfikuj obsługiwane dane skoroszytu wykresu tutaj.
    }
} finally {
    $presentation->dispose();
}
```

## **Zewnętrzny skoroszyt**

Aspose.Slides obsługuje używanie zewnętrznych skoroszytów jako źródła danych wykresów.

### **Utworzenie zewnętrznego skoroszytu**

Użyj [readWorkbookStream](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/readworkbookstream/) i [setExternalWorkbook](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/setexternalworkbook/), aby wyeksportować osadzony skoroszyt wykresu do pliku i powiązać wykres z tym zewnętrznym skoroszytem.

Ten przykład tworzy wykres kołowy z domyślnymi danymi, zapisuje jego skoroszyt jako `externalWorkbook1.xlsx` i kończy zapis pliku przed przypisaniem pliku jako źródła danych wykresu. Zapisuje połączoną prezentację jako `externalWorkbook.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Ustawienie zewnętrznego skoroszytu**

Korzystając z metody [setExternalWorkbook](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/setexternalworkbook/), możesz przypisać zewnętrzny skoroszyt do wykresu jako jego źródło danych. Metoda ta może być także użyta do zaktualizowania ścieżki do zewnętrznego skoroszytu (jeśli został przeniesiony).

Nie można edytować danych w skoroszytach przechowywanych w zdalnych lokalizacjach lub zasobach, ale można je dalej używać jako zewnętrznego źródła danych. Jeśli podano względną ścieżkę do zewnętrznego skoroszytu, zostaje ona automatycznie przekształcona na pełną ścieżkę.

Ten przykład wymaga `externalWorkbook.xlsx` w katalogu roboczym. Jego arkusz o nazwie `Sheet1` musi zawierać nazwę serii w B1, nazwy kategorii w A2:A4 oraz wartości liczbowe w B2:B4. Przykład tworzy wykres kołowy, łączy skoroszyt i używa [setRange](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/setrange/), aby mapować A1:B4 na jedną serię i trzy kategorie. Zapisuje wynik jako `Presentation_with_externalWorkbook.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/setexternalworkbook/) steruje tym, czy skoroszyt zostanie załadowany.

* Gdy `updateChartData` ma wartość `false`, aktualizowana jest jedynie ścieżka do skoroszytu. Dane wykresu nie są ładowane ani aktualizowane z docelowego skoroszytu, więc skoroszyt może być niedostępny.
* Gdy `updateChartData` ma wartość `true`, dane wykresu są aktualizowane z docelowego skoroszytu.

Poniższy przykład przypisuje przykladowy adres URL z `updateChartData` ustawionym na `false`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnego skoroszytu.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Pobranie ścieżki skoroszytu źródła danych zewnętrznych wykresu**

Aby zidentyfikować skoroszyt powiązany z wykresem, najpierw sprawdź, czy wykres używa zewnętrznego źródła danych. Jeśli tak, możesz pobrać ścieżkę skoroszytu, wykonując następujące kroki.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu, używając indeksu zerowego.
3. Sprawdź, czy pierwszy kształt jest wykresem.
4. Odczytaj typ źródła danych wykresu.
5. Jeśli źródłem jest zewnętrzny skoroszyt, odczytaj jego ścieżkę.

Ten przykład otwiera `externalWorkbook.pptx`, utworzony w poprzednim przykładzie, i sprawdza pierwszy kształt na pierwszym slajdzie. Jeśli jest to wykres powiązany z zewnętrznym skoroszytem, przykład wypisuje [getExternalWorkbookPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getexternalworkbookpath/) na konsoli. Następnie zapisuje kopię prezentacji jako `Result.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Edycja danych wykresu**

Można edytować dane w zewnętrznych skoroszytach tak samo, jak zmienia się zawartość wewnętrznych skoroszytów. Gdy zewnętrzny skoroszyt nie może zostać załadowany, zostaje wyrzucony wyjątek.

Ten przykład wymaga `presentation.pptx` z wykresem jako pierwszym kształtem na pierwszym slajdzie oraz dostępnego zewnętrznego skoroszytu. Ustawia wartość wspieraną komórką pierwszego punktu danych w pierwszej serii na 100 i zapisuje prezentację jako `presentation_out.pptx`. Edycja wartości w komórkach może aktualizować połączony zewnętrzny plik XLSX, dlatego użyj kopii, jeśli musisz zachować oryginalny skoroszyt.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Odzyskiwanie skoroszytu z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego skoroszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć skoroszyt wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/), wywołaj [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) i ustaw [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) na `true` przed otwarciem prezentacji.

Poniższy przykład PHP otwiera `presentation.pptx`, którego pierwszy kształt na pierwszym slajdzie musi być wykresem odwołującym się do niedostępnego zewnętrznego skoroszytu, i uzyskuje dostęp do odzyskanych danych poprzez [Chart::getChartData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/getchartdata/) oraz [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getchartdataworkbook/):

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // Odczytaj lub zmodyfikuj tutaj odzyskane dane skoroszytu.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Jeśli zewnętrzny skoroszyt jest niedostępny, a odzyskiwanie jest wyłączone, Aspose.Slides zgłasza wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych z pamięci podręcznej wykresu jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym skoroszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym skoroszytem?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getdatasourcetype/) oraz [ścieżkę do zewnętrznego skoroszytu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getexternalworkbookpath/); jeśli źródłem jest zewnętrzny skoroszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych skoroszytów i w jaki sposób są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostaje ona automatycznie przekształcona na ścieżkę bezwzględną. Prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX, więc przeniesienie skoroszytu może wymagać aktualizacji linku.

**Czy mogę używać skoroszytów umieszczonych na zasobach sieciowych/udziałach?**

Tak, takie skoroszyty mogą być używane jako zewnętrzne źródło danych. Jednak bezpośrednia edycja zdalnych skoroszytów z poziomu Aspose.Slides nie jest obsługiwana — mogą być jedynie źródłem.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX podczas zapisywania prezentacji?**

Prezentacja przechowuje [link do pliku zewnętrznego](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Edycja danych wykresu oparcie w komórkach może również zaktualizować połączony lokalny plik XLSX. Użyj kopii skoroszytu, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, gdy zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie przyjmuje hasła przy tworzeniu linku. Typowym podejściem jest usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/java/)) i podlinkowanie tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego skoroszytu?**

Tak. Każdy wykres przechowuje własny link. Jeśli wszystkie odwołują się do tego samego pliku, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.