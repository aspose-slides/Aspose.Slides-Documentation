---
title: Zarządzanie arkuszami wykresów w prezentacjach przy użyciu PHP
linktitle: Arkusz wykresu
type: docs
weight: 70
url: /pl/php-java/chart-workbook/
keywords:
- arkusz wykresu
- dane wykresu
- komórka arkusza
- etykieta danych
- arkusz
- źródło danych
- zewnętrzny arkusz
- zewnętrzne dane
- pamięć podręczna wykresu
- odzyskiwanie arkusza
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Odkryj Aspose.Slides dla PHP via Java: łatwo zarządzaj arkuszami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z arkuszami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pomocą strumieni arkusza, używać komórek arkusza jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Opisuje również pracę z zewnętrznymi arkuszami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny arkusz, pobrać ścieżkę zewnętrznego arkusza powiązanego z wykresem oraz edytować dane wykresu, gdy arkusz jest dostępny.

W przypadku komórek arkusza reprezentujących brakujące dane, zobacz [Kontrola wyświetlania pustych komórek](/slides/pl/php-java/chart-series/) aby poznać różnicę między pustą komórką a zerem oraz porównanie linii wykresu dostępnych trybów wyświetlania.

## **Dołącz dane z ukrytych wierszy i kolumn**

Użyj [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/), aby kontrolować, czy wykres prezentuje dane z ukrytych wierszy i kolumn arkusza. Ustaw `true`, aby wykresem były tylko widoczne komórki, lub `false`, aby uwzględnić zarówno widoczne, jak i ukryte komórki. To ustawienie kontroluje rysowanie wykresu; nie ukrywa ani nie odsłania wierszy czy kolumn arkusza.

[przykładowa prezentacja](hidden-source-data.pptx) zawiera wykres kolumnowy jako pierwszy kształt na pierwszym slajdzie. Osadzony arkusz, `Sheet1`, zawiera następujący zakres źródłowy, `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Wiersz arkusza | A: Miesiąc | B: Detal | C: Hurt (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | Styczeń | 10 | 30 |
| 3 (ukryty wiersz) | Luty | 40 | 60 |
| 4 | Marzec | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych przez [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) i sprawdź [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/), aby zbadać ich status ukrycia. Metoda zwraca status ukrycia bez jego zmiany. W tym przykładzie B2 jest widoczny, B3 należy do ukrytego wiersza, a C2 do ukrytej kolumny; przykład wypisuje kolejno `false`, `true` i `true`.

Dla tego przykładu odśwież dane wykresu po zmianie ustawienia rysowania: zachowaj osadzony arkusz przy użyciu [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) i wczytaj go ponownie przy użyciu [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). Przy dołączaniu wszystkich komórek użyj także [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/), aby przywrócić pełny zakres, w tym ukrytą kategorię Luty. Samo zmienienie flagi nie odświeża buforowanych danych wykresu i etykiet kategorii w tym przykładzie.

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

            // Odśwież dane wykresu z osadzonego arkusza.
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

Przykład zapisuje dwie wersje prezentacji: jedną z wyłącznie widocznymi wartościami detalicznymi (10 i 20), a drugą ze wszystkimi sześcioma wartościami. Obrazy poniżej ilustrują dwa tryby rysowania. Wiersz 3 i kolumna C pozostają ukryte w obu osadzonych arkuszach.

| Tylko widoczne komórki (`true`) | Wszystkie komórki (`false`) |
| --- | --- |
| ![Tylko widoczne komórki: wartości detaliczne 10 i 20 dla stycznia i marca.](hidden_cells_True.png) | ![Wszystkie komórki: wartości detaliczne i hurtowe dla stycznia, lutego i marca.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) kontroluje, jak wyświetlane są brakujące wartości; nie włącza ani nie wyłącza ukrytych danych źródłowych. Zobacz [Kontrola wyświetlania pustych komórek](/slides/pl/php-java/chart-series/#control-the-display-of-empty-cells) po przykład.

## **Pobierz zakres danych wykresu**

Przed aktualizacją danych arkusza w istniejącej prezentacji, sprawdź zakresy źródłowe, aby zidentyfikować, które komórki arkusza używa dany wykres. Metoda [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) zwraca bieżący zakres danych jako formułę kwalifikowaną arkuszem, np. `Sheet1!$A$1:$D$5`. Tutaj `Sheet1` to nazwa arkusza, `!` oddziela ją od zakresu komórek, a `$A$1:$D$5` określa komórki od A1 do D5 włącznie. Znaki dolara wskazują odwołania bezwzględne do wiersza i kolumny.

Metoda odczytuje bieżący zakres bez zmiany wykresu ani jego arkusza. Jeśli wykres nie używa arkusza jako źródła danych, zgłasza wyjątek. Więcej informacji znajdziesz w [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Ten przykład otwiera prezentację i sprawdza kształty bezpośrednio na każdym slajdzie pod kątem wykresów. Wypisuje nazwę każdego wykresu oraz jego zakres źródłowy. Jeśli wykres nie używa arkusza, wypisuje komunikat i przechodzi do kolejnego wykresu.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Odczyt i zapis danych wykresu z arkusza**

Aspose.Slides for PHP via Java udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) i [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/), które umożliwiają odczyt i zapis arkuszy danych wykresu (zawierających dane wykresu edytowane w Aspose.Cells). **Uwaga**, że dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten przykład używa prezentacji z wykresem jako pierwszym kształtem na pierwszym slajdzie. Odczytuje osadzony arkusz do tablicy bajtów, usuwa istniejące serie i kategorie, a następnie zapisuje ten sam arkusz z powrotem. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

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

### **Zweryfikuj układ wykresu po modyfikacji arkusza**

Gdy zamieniasz osadzony arkusz zmodyfikowanym, wykres zachowuje pierwotne kolekcje serii i kategorii. To niezgodność może spowodować błąd [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) z powodu indeksu poza zakresem. Wyczyść istniejące serie i kategorie przed zapisaniem zmodyfikowanego arkusza z powrotem do wykresu. Ten przykład używa wykresu będącego pierwszym kształtem na pierwszym slajdzie. Komentarz zaznacza miejsce, w którym miałoby nastąpić edytowanie arkusza; działający przykład zapisuje oryginalny arkusz z powrotem i w pamięci weryfikuje układ.

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

        // Modyfikuj bajty arkusza tutaj, na przykład przy użyciu Aspose.Cells.

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

Czyszczenie kolekcji usuwa nieaktualne odwołania danych przed zapisaniem arkusza. Odbuduj wymagane mapowania serii i kategorii dla zaktualizowanego arkusza przed użyciem wykresu.

## **Ustaw niestandardowe formaty liczb dla komórek arkusza**

Użyj [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/), aby kontrolować, jak wartości liczbowe wyświetlane są w osadzonym arkuszu wykresu. Na przykład raport może wymagać wyświetlenia współczynnika konwersji jako procentu z czterema miejscami po przecinku oraz współczynnika wyświetlanego z pięcioma miejscami po przecinku. Trzymaj oba wartości jako liczby, aby pozostały dostępne do obliczeń i rysowania wykresu.

Format liczbowy zmienia wygląd, nie przechowywaną wartość. Format `0.0000%` wyświetla `0.125` jako `12.5000%`; nie zamienia przechowywanej liczby na `12.5`. Analogicznie, `0.00000` wyświetla `0.1234567` jako `0.12346` bez zaokrąglania przechowywanej wartości. Jeśli niestandardowy format jest pustym ciągiem (`""`), używany jest format zwrócony przez [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/).

Poniższy przykład tworzy wykres kolumnowy i uzyskuje dostęp do jego komórek przez [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/). W arkuszu 0, B2 zawiera współczynnik konwersji, a C2 współczynnik. Obie komórki dostarczają wartości wykresu. Przykład włącza także etykiety wartości powiązane z formatami źródłowymi.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Formaty komórek arkusza są oddzielne od formatów ustawionych bezpośrednio na osiach wykresu lub etykietach danych. W tym przykładzie każda etykieta wyświetla wartość swojej komórki źródłowej, ponieważ [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) jest ustawione na `true`, a flagi powiązania formatu liczbowego z źródłem są ustawione na `true` dzięki [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/). Po zapisaniu i ponownym otwarciu prezentacji etykiety wyświetlają `12.5000%` i `0.12346`, jak pokazano poniżej. Oś pionowa używa własnego formatu liczbowego, ustawionego przy pomocy [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) jako `0.00`, przy czym [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) jest ustawione na `false`.

Aby sformatować etykietę danych niezależnie, wyłącz flagę powiązania ze źródłem (`false`) i przypisz format przy użyciu [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/). Nie zmienia to formatu komórki arkusza. Na przykład niezależny format etykiety `0.00` wyświetli pierwszą wartość jako `0.13`, podczas gdy B2 nadal wyświetla `12.5000%`. Zobacz [Chart Data Labels](/slides/pl/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) po bezpośrednie formatowanie etykiet.

![Wykres kolumnowy z etykietami powiązanymi z źródłem wyświetlającymi 12.5000% i 0.12346 oraz niezależnie sformatowaną osią liczbową.](custom-cell-formats.png)

## **Ustaw komórkę arkusza jako etykietę danych wykresu**

Możesz używać tekstu z komórek arkusza jako etykiet danych wykresu.

Ten przykład dodaje wykres bąbelkowy z domyślnymi danymi do pierwszego slajdu istniejącej prezentacji. Używa komórek A10:A12 w arkuszu 0 dla pierwszych trzech etykiet w pierwszej serii, włącza etykiety z komórek i zapisuje zaktualizowaną prezentację.

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

## **Zarządzaj arkuszami**

Metoda [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) zapewnia dostęp do arkuszy w arkuszu wykresu. Ten przykład tworzy wykres kołowy z domyślnymi danymi i wypisuje każdą nazwę arkusza w konsoli.

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

## **Określ typ źródła danych**

Wartości punktów serii mogą być również przechowywane bezpośrednio jako literały liczbowe. Zobacz [Set Series Values Using Numeric Literals](/slides/pl/php-java/chart-series/#set-series-values-using-numeric-literals) po kompletny przykład zapisu i odczytu. Typ źródła wartości punktów jest oddzielny od wewnętrznej lub zewnętrznej konfiguracji arkusza wykresu; użycie literałów liczbowych samo w sobie nie usuwa osadzonego arkusza.

Ten przykład tworzy wykres kolumnowy 3D z domyślnymi danymi i ustawia dwie nazwy serii przy użyciu różnych źródeł danych. Pierwsza nazwa używa literału łańcuchowego; druga używa komórki C1 w arkuszu 0. Enumeracja [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) wybiera źródło dla każdej nazwy. Przykład zapisuje prezentację z zaktualizowanymi nazwami serii.

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

## **Wykryj nieobsługiwane formaty osadzonych arkuszy**

Aspose.Slides nie obsługuje binarnego formatu arkusza Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody `getEmbeddedWorkbookType` na [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) razem z enumeracją [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/), aby wykryć nieobsługiwane formaty i pominąć te wykresy. Ten przykład analizuje kształty na pierwszym slajdzie istniejącej prezentacji, pomija kształty niebędące wykresami i wypisuje komunikat diagnostyczny dla każdego wykresu z osadzonym arkuszem .xlsb.

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

        // Odczytaj lub zmodyfikuj obsługiwane dane arkusza wykresu tutaj.
    }
} finally {
    $presentation->dispose();
}
```

## **Zewnętrzny arkusz**

Aspose.Slides obsługuje użycie zewnętrznych arkuszy jako źródła danych dla wykresów.

### **Utwórz zewnętrzny arkusz**

Użyj [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) i [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), aby wyeksportować osadzony arkusz wykresu do pliku i powiązać wykres z tym zewnętrznym arkuszem.

Ten przykład tworzy wykres kołowy z domyślnymi danymi i eksportuje jego arkusz. Zapisuje plik przed przypisaniem zewnętrznego arkusza jako źródła danych wykresu, a następnie zapisuje powiązaną prezentację.

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

### **Ustaw zewnętrzny arkusz**

Korzystając z metody [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), możesz przypisać zewnętrzny arkusz do wykresu jako jego źródło danych. Metoda ta może być także użyta do aktualizacji ścieżki do zewnętrznego arkusza (jeśli został on przeniesiony).

Nie możesz edytować danych w arkuszach przechowywanych w zdalnych lokalizacjach lub zasobach, ale nadal możesz używać takich arkuszy jako zewnętrznego źródła danych. Jeśli podano względną ścieżkę do zewnętrznego arkusza, zostaje ona automatycznie przekształcona na pełną ścieżkę.

Ten przykład używa zewnętrznego arkusza, którego arkusz nazwany `Sheet1` zawiera nazwę serii w B1, nazwy kategorii w A2:A4 oraz wartości liczbowe w B2:B4. Przykład tworzy wykres kołowy, łączy arkusz i używa [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/), aby mapować A1:B4 na jedną serię i trzy kategorie. Zapisuje prezentację z powiązanym wykresem.

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

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) kontroluje, czy arkusz jest ładowany.

* Gdy `updateChartData` jest `false`, aktualizowana jest tylko ścieżka arkusza. Dane wykresu nie są ładowane ani aktualizowane z docelowego arkusza, więc arkusz może być niedostępny.
* Gdy `updateChartData` jest `true`, dane wykresu są aktualizowane z docelowego arkusza.

Poniższy przykład przypisuje adres URL jako placeholder z `updateChartData` ustawionym na `false`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnego arkusza.

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

### **Uzyskaj ścieżkę zewnętrznego arkusza danych źródłowych wykresu**

Aby zidentyfikować arkusz powiązany z wykresem, sprawdź, czy wykres używa zewnętrznego źródła danych i pobierz jego ścieżkę.

Ten przykład analizuje pierwszy kształt na pierwszym slajdzie prezentacji z powiązanym zewnętrznym arkuszem. Jeśli jest to wykres powiązany z zewnętrznym arkuszem, przykład wypisuje [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) w konsoli. Następnie zapisuje kopię prezentacji.

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

### **Edytuj dane wykresu**

Możesz edytować dane w zewnętrznych arkuszach tak samo, jak w wewnętrznych arkuszach. Gdy zewnętrzny arkusz nie może zostać załadowany, zgłaszany jest wyjątek.

Ten przykład używa wykresu będącego pierwszym kształtem na pierwszym slajdzie i powiązanego z dostępnym zewnętrznym arkuszem. Ustawia wartość opartą na komórce pierwszego punktu danych w pierwszej serii na 100 i zapisuje zaktualizowaną prezentację. Edycja wartości komórek może aktualizować powiązany zewnętrzny plik XLSX, więc używaj kopii, jeśli musisz zachować oryginalny arkusz.

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

### **Odzyskaj arkusz z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego arkusza, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć arkusz wykresu z danych buforowanych w prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), wywołaj [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/), i ustaw [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) na `true` przed otwarciem prezentacji.

Poniższy przykład w PHP odzyskuje dane arkusza dla wykresu będącego pierwszym kształtem na pierwszym slajdzie i odwołującego się do niedostępnego zewnętrznego arkusza. Dostęp do odzyskanych danych uzyskuje poprzez [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) i [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Odczytaj lub zmodyfikuj odzyskane dane arkusza tutaj.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Jeśli zewnętrzny arkusz jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłasza wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie buforowanych danych wykresu jest dopuszczalnym rozwiązaniem awaryjnym, ponieważ bufor może nie zawierać zmian wprowadzonych w zewnętrznym arkuszu po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym arkuszem?**

Tak. Wykres ma [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) oraz [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); jeśli źródłem jest zewnętrzny arkusz, możesz odczytać pełną ścieżkę, aby mieć pewność, że używany jest plik zewnętrzny.

**Czy względne ścieżki do zewnętrznych arkuszy są obsługiwane i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, jest ona automatycznie konwertowana na ścieżkę bezwzględną. Prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX, więc przeniesienie arkusza może wymagać aktualizacji łącza.

**Czy mogę używać arkuszy znajdujących się na zasobach/sieciach udostępnionych?**

Tak, takie arkusze mogą być używane jako zewnętrzne źródło danych. Jednak edytowanie zdalnych arkuszy bezpośrednio z Aspose.Slides nie jest obsługiwane - mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Prezentacja przechowuje [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Edycja danych wykresu powiązanych z komórkami może także aktualizować powiązany lokalny plik XLSX. Użyj kopii arkusza, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, jeśli zewnętrzny plik jest chroniony hasłem?**

Aspose.Slides nie akceptuje hasła przy tworzeniu łącza. Typowe podejście to usunięcie ochrony wcześniej lub przygotowanie odkodowanej kopii (na przykład przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/java/)) i połączenie się z tą kopią.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego arkusza?**

Tak. Każdy wykres przechowuje własne łącze. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.