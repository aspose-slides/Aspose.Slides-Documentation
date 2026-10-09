---
title: Zarządzanie książkami wykresów w prezentacjach przy użyciu PHP
linktitle: Książka wykresu
type: docs
weight: 70
url: /pl/php-java/chart-workbook/
keywords:
- książka wykresu
- dane wykresu
- komórka książki
- etykieta danych
- arkusz
- źródło danych
- zewnętrzna książka
- zewnętrzne dane
- pamięć podręczna wykresu
- odzyskiwanie książki
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Odkryj Aspose.Slides dla PHP via Java: bez wysiłku zarządzaj książkami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z książkami roboczymi wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pośrednictwem strumieni książek roboczych, używać komórek książki roboczej jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Opisuje także pracę z zewnętrznymi książkami roboczymi jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzną książkę roboczą, pobrać ścieżkę zewnętrznej książki powiązanej z wykresem oraz edytować dane wykresu, gdy książka jest dostępna.

Dla komórek książki roboczej, które reprezentują brakujące dane, zobacz [Kontrola wyświetlania pustych komórek](/slides/pl/php-java/chart-series/) aby poznać różnicę między pustą komórką a zerem oraz porównanie trybów wyświetlania w wykresie liniowym.

## **Dołącz dane z ukrytych wierszy i kolumn**

Użyj [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) aby kontrolować, czy wykres rysuje dane z ukrytych wierszy i kolumn arkusza. Ustaw `true`, aby rysować tylko widoczne komórki, lub `false`, aby uwzględnić zarówno widoczne, jak i ukryte komórki. To ustawienie kontroluje rysowanie wykresu; nie ukrywa ani nie odsłania wierszy lub kolumn arkusza.

[przykładowa prezentacja](hidden-source-data.pptx) zawiera wykres kolumnowy jako pierwszy obiekt na pierwszym slajdzie. Osadzony arkusz, `Sheet1`, zawiera następujący zakres źródłowy, `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Wiersz arkusza | A: Miesiąc | B: Sprzedaż detaliczna | C: Sprzedaż hurtowa (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | Styczeń | 10 | 30 |
| 3 (ukryty wiersz) | Luty | 40 | 60 |
| 4 | Marzec | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych poprzez [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) i odczytaj [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/), aby sprawdzić ich status ukrycia. Metoda ta zwraca status ukrycia bez jego zmiany. W tym przykładzie B2 jest widoczny, B3 należy do ukrytego wiersza, a C2 do ukrytej kolumny; przykład wypisuje `false`, `true` i `true` odpowiednio.

Dla tego przykładu odśwież dane wykresu po zmianie ustawienia rysowania: zachowaj osadzoną książkę roboczą przy użyciu [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) i załaduj ją ponownie przy pomocy [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). Przy uwzględnianiu wszystkich komórek użyj także [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/), aby przywrócić pełny zakres, w tym ukryty luty. Same zmiany flagi nie są wystarczające do odświeżenia buforowanych danych wykresu i etykiet kategorii w tym przykładzie.

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

            // Odśwież dane wykresu z osadzonej książki roboczej.
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

Przykład zapisuje dwie wersje prezentacji: jedną zawierającą tylko widoczne wartości detaliczne (10 i 20), a drugą ze wszystkimi sześcioma wartościami. Poniższe obrazy ilustrują dwa tryby rysowania. Wiersz 3 i kolumna C pozostają ukryte w obu osadzonych książkach roboczych.

| Tylko widoczne komórki (`true`) | Wszystkie komórki (`false`) |
| --- | --- |
| ![Tylko widoczne komórki: wartości sprzedaży detalicznej 10 i 20 dla stycznia i marca.](hidden_cells_True.png) | ![Wszystkie komórki: wartości sprzedaży detalicznej i hurtowej dla stycznia, lutego i marca.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) kontroluje, jak wyświetlane są brakujące wartości; nie obejmuje ani nie wyklucza ukrytych danych źródłowych. Zobacz [Kontrola wyświetlania pustych komórek](/slides/pl/php-java/chart-series/#control-the-display-of-empty-cells) po przykład.

## **Pobranie zakresu danych wykresu**

Przed aktualizacją danych książki roboczej w istniejącej prezentacji sprawdź zakresy źródłowe, aby zidentyfikować, które komórki arkusza używa każdy wykres. Metoda [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) zwraca bieżący zakres danych jako formułę kwalifikowaną arkuszem, np. `Sheet1!$A$1:$D$5`. Tutaj `Sheet1` to nazwa arkusza, `!` oddziela ją od zakresu komórek, a `$A$1:$D$5` określa komórki od A1 do D5, włącznie. Znaki dolara oznaczają odwołania bezwzględne do wierszy i kolumn.

Metoda odczytuje bieżący zakres bez zmiany wykresu ani jego książki roboczej. Jeśli wykres nie używa książki jako źródła danych, zgłasza wyjątek. Po więcej informacji zobacz [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Ten przykład otwiera prezentację i sprawdza obiekty bezpośrednio na każdym slajdzie pod kątem wykresów. Wypisuje nazwę każdego wykresu i jego zakres źródłowy. Jeśli wykres nie używa książki, wypisuje komunikat i przechodzi do kolejnego wykresu.

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

## **Odczyt i zapis danych wykresu z książki roboczej**

Aspose.Slides for PHP via Java udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) i [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/), które pozwalają odczytywać i zapisywać książki danych wykresu (zawierające dane wykresu edytowane przy pomocy Aspose.Cells). **Uwaga**, dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Przykład używa prezentacji z wykresem jako pierwszym obiektem na pierwszym slajdzie. Odczytuje osadzoną książkę do tablicy bajtów, czyści istniejące serie i kategorie oraz zapisuje tę samą książkę z powrotem. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

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

### **Sprawdzenie układu wykresu po modyfikacji książki roboczej**

Gdy zastąpisz osadzoną książkę zmodyfikowaną wersją, wykres zachowuje oryginalne kolekcje serii i kategorii. To niedopasowanie może spowodować, że [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) zakończy się błędem indeksu poza zakresem. Wyczyść istniejące serie i kategorie przed zapisaniem zaktualizowanej książki do wykresu. Przykład używa wykresu, który jest pierwszym obiektem na pierwszym slajdzie. Komentarz wskazuje, gdzie miałoby nastąpić edytowanie książki; działający przykład zapisuje oryginalną książkę z powrotem i w pamięci waliduje układ.

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

Czyszczenie kolekcji usuwa przestarzałe odwołania danych przed zapisaniem książki. Zbuduj ponownie wymagane mapowania serii i kategorii dla zaktualizowanej książki przed użyciem wykresu.

## **Ustawienie komórki książki roboczej jako etykiety danych wykresu**

Możesz używać tekstu z komórek książki jako etykiet danych wykresu.

Przykład dodaje wykres bąbelkowy z domyślnymi danymi do pierwszego slajdu istniejącej prezentacji. Używa komórek A10:A12 w arkuszu 0 jako pierwszych trzech etykiet w pierwszej serii, włącza etykiety z komórek i zapisuje zaktualizowaną prezentację.

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

Metoda [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) zapewnia dostęp do arkuszy w książce danych wykresu. Przykład tworzy wykres kołowy z domyślnymi danymi i wypisuje nazwę każdego arkusza na konsoli.

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

Przykład tworzy trójwymiarowy wykres kolumnowy z domyślnymi danymi i ustawia dwie nazwy serii przy użyciu różnych źródeł danych. Pierwsza nazwa używa literału łańcucha znaków; druga korzysta z komórki C1 w arkuszu 0. Enumeracja [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) wybiera źródło dla każdej nazwy. Przykład zapisuje prezentację z zaktualizowanymi nazwami serii.

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

## **Wykrywanie nieobsługiwanych formatów osadzonych książek roboczych**

Aspose.Slides nie obsługuje formatu binarnego skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Można użyć metody `getEmbeddedWorkbookType` na [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) wraz z enumeracją [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/), aby wykryć nieobsługiwane formaty i pominąć takie wykresy. Przykład sprawdza obiekty na pierwszym slajdzie istniejącej prezentacji, pomija nie‑wykresowe obiekty i wypisuje komunikat diagnostyczny dla każdego wykresu z osadzonym skoroszytem .xlsb.

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

        // Odczytaj lub zmodyfikuj obsługiwane dane książki wykresu tutaj.
    }
} finally {
    $presentation->dispose();
}
```

## **Zewnętrzna książka robocza**

Aspose.Slides obsługuje użycie zewnętrznych książek roboczych jako źródła danych dla wykresów.

### **Utworzenie zewnętrznej książki roboczej**

Użyj [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) i [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), aby wyeksportować osadzony skoroszyt wykresu do pliku i podłączyć wykres do tej zewnętrznej książki.

Przykład tworzy wykres kołowy z domyślnymi danymi i eksportuje jego skoroszyt. Zapisuje plik przed przypisaniem zewnętrznej książki jako źródła danych wykresu, a następnie zapisuje powiązaną prezentację.

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

### **Ustawienie zewnętrznej książki roboczej**

Korzystając z metody [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), możesz przypisać zewnętrzną książkę do wykresu jako jego źródło danych. Metoda ta może być także użyta do aktualizacji ścieżki do zewnętrznej książki (jeśli została przeniesiona).

Chociaż nie można edytować danych w książkach przechowywanych w zdalnych lokalizacjach lub zasobach, nadal można ich używać jako zewnętrznego źródła danych. Jeśli podano względną ścieżkę do zewnętrznej książki, zostaje ona automatycznie przekształcona na ścieżkę pełną.

Przykład używa zewnętrznej książki, której arkusz o nazwie `Sheet1` zawiera nazwę serii w B1, nazwy kategorii w A2:A4 oraz wartości liczbowe w B2:B4. Przykład tworzy wykres kołowy, podłącza książkę i używa [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/), aby odwzorować A1:B4 na jedną serię i trzy kategorie. Zapisuje prezentację z podłączonym wykresem.

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

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) kontroluje, czy książka zostanie załadowana.

* Gdy `updateChartData` jest `false`, aktualizowana jest tylko ścieżka do książki. Dane wykresu nie są ładowane ani aktualizowane z docelowej książki, więc książka może być niedostępna.
* Gdy `updateChartData` jest `true`, dane wykresu są aktualizowane z docelowej książki.

Poniższy przykład przypisuje przykładowy adres URL z `updateChartData` ustawionym na `false`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnej książki.

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

### **Pobranie ścieżki zewnętrznego źródła danych książki roboczej wykresu**

Aby zidentyfikować książkę powiązaną z wykresem, sprawdź, czy wykres używa zewnętrznego źródła danych i pobierz jego ścieżkę.

Przykład sprawdza pierwszy obiekt na pierwszym slajdzie prezentacji z podłączonym zewnętrznym skoroszytem. Jeśli jest to wykres podłączony do zewnętrznej książki, przykład wypisuje [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) w konsoli. Następnie zapisuje kopię prezentacji.

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

Możesz edytować dane w zewnętrznych książkach w taki sam sposób, w jaki zmieniasz zawartość wewnętrznych książek. Gdy zewnętrzna książka nie może zostać załadowana, zostaje zgłoszony wyjątek.

Przykład używa wykresu, który jest pierwszym obiektem na pierwszym slajdzie i jest podłączony do dostępnej zewnętrznej książki. Ustawia wartość opartą na komórce pierwszego punktu danych w pierwszej serii na 100 i zapisuje zaktualizowaną prezentację. Edycja wartości komórek może aktualizować podłączony zewnętrzny plik XLSX, więc użyj kopii, jeśli musisz zachować oryginalną książkę.

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

### **Odzyskiwanie książki roboczej z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznej książki, której brakuje lub jest niedostępna, Aspose.Slides może odtworzyć książkę wykresu z danych buforowanych w prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), wywołaj [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) i ustaw [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) na `true` przed otwarciem prezentacji.

Poniższy przykład w PHP odzyskuje dane książki dla wykresu będącego pierwszym obiektem na pierwszym slajdzie i odwołującego się do niedostępnej zewnętrznej książki. Uzyskuje dostęp do odzyskanych danych przez [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) i [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Odczytaj lub zmodyfikuj odzyskane dane skoroszytu tutaj.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Jeśli zewnętrzna książka jest niedostępna i odzyskiwanie jest wyłączone, Aspose.Slides zgłosi wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie buforowanych danych wykresu jest dopuszczalnym rozwiązaniem awaryjnym, ponieważ bufor może nie zawierać zmian dokonanych w zewnętrznej książce po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrzną czy osadzoną książką roboczą?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) oraz [ścieżkę do zewnętrznej książki roboczej](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); jeśli źródłem jest zewnętrzna książka, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy względne ścieżki do zewnętrznych książek są obsługiwane i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostaje ona automatycznie przekształcona na ścieżkę bezwzględną. Prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX, więc przeniesienie książki może wymagać aktualizacji odnośnika.

**Czy mogę używać książek znajdujących się w zasobach sieciowych/udostępnionych?**

Tak, takie książki mogą być używane jako zewnętrzne źródło danych. Jednak edytowanie zdalnych książek bezpośrednio z Aspose.Slides nie jest obsługiwane – mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX podczas zapisu prezentacji?**

Prezentacja przechowuje [odwołanie do zewnętrznego pliku](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Edycja danych wykresu opartej na komórkach może również zaktualizować powiązany lokalny plik XLSX. Użyj kopii książki, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, jeśli zewnętrzny plik jest chroniony hasłem?**

Aspose.Slides nie akceptuje hasła przy łączeniu. Typowe rozwiązanie to usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (na przykład przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/java/)) i podłączenie do tej kopii.

**Czy wiele wykresów może odwoływać się do tej samej zewnętrznej książki?**

Tak. Każdy wykres przechowuje własny odnośnik. Jeśli wszystkie wskazują ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym załadowaniu danych.