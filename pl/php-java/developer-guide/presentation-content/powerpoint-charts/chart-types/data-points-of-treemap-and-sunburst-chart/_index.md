---
title: Dostosowanie punktów danych w wykresach Treemap i Sunburst w PHP
linktitle: Punkty danych w wykresach Treemap i Sunburst
type: docs
url: /pl/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- wykres treemap
- wykres sunburst
- wykres hierarchiczny
- punkt danych
- etykieta danych
- kolor gałęzi
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak tworzyć dane hierarchiczne i dostosowywać poziomy, etykiety oraz kolory w wykresach Treemap i Sunburst przy użyciu Aspose.Slides dla PHP poprzez Java."
---
## **Przegląd**

Wykresy Treemap i Sunburst wyświetlają ten sam rodzaj danych hierarchicznych, ale używają różnych układów. Treemap rysuje hierarchię jako zagnieżdżone prostokąty, których pola przedstawiają wartości liści. Sunburst przedstawia ją jako koncentryczne pierścienie: grupy najwyższego poziomu znajdują się blisko środka, a kategorie liściowe – na zewnętrznym pierścieniu.

W Aspose.Slides for PHP via Java każdy numeryczny punkt to [ChartDataPoint](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapoint/). Jego metoda [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) zapewnia dostęp do liścia i jego grup nadrzędnych. Ten artykuł wyjaśnia to mapowanie i pokazuje, jak utworzyć oraz sformatować oba typy wykresów z tych samych przykładowych danych.

![Wykres Treemap z gałęziami Consumer i Business](treemap-hierarchy.png)

![Wykres Sunburst z tą samą hierarchią Consumer i Business](sunburst-hierarchy.png)

## **Zrozumienie kategorii, punktów danych i poziomów**

Poniższy przykład zawiera trzy poziomy kategorii i jedną serię numeryczną:

| Oddział | Gałąź | Liść | Przychód |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Każdy wiersz tworzy jedną kategorię liścia i jeden punkt danych. Poziomy grupowania kategorii opisują ścieżkę od tego liścia do jego rodziców. Dla pierwszego wiersza ścieżka to `Consumer > Computers > Laptops`.

Indeksy zwracane przez [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) liczą od liścia w górę:

| `getDataPointLevels()` index | Poziom logiczny | Reprezentacja w Treemap | Reprezentacja w Sunburst |
| ---: | --- | --- | --- |
| `0` | Liść | Prostokąt wartości | Segment pierścienia zewnętrznego |
| `1` | Gałąź | Prostokąt rodzica lub nagłówek | Segment pierścienia środkowego |
| `2` | Oddział | Prostokąt najwyższego poziomu lub nagłówek | Segment pierścienia wewnętrznego |

Ta kolejność jest taka sama dla obu typów wykresów, mimo że ich układy wizualne się różnią. Segment rodzica jest współdzielony przez kilka liści. Aby go sformatować, użyj odpowiedniego poziomu pierwszego punktu danych w tej grupie. Na przykład gałąź `Consumer` zaczyna się od punktu `Laptops`, a gałąź `Software` od punktu `Licenses`. Przechowywanie odwołań do tych punktów jest czytelniejsze i bezpieczniejsze niż używanie niezrozumiałych wyrażeń typu `$dataPoints->get_Item(0)` czy `$dataPoints->get_Item(6)`.

## **Utworzenie i dostosowanie obu typów wykresów**

Poniższy kompletny przykład tworzy wykres Treemap na pierwszym slajdzie i wykres Sunburst na drugim slajdzie. Buduje hierarchię, wyświetla wartość dla `Tablets`, nakłada stałe kolory na wybrane poziomy, formatuje etykietę gałęzi i zapisuje prezentację.

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // Dodaj kategorie liści. Element grupowania jest ustawiany tylko gdy rozpoczyna się nowa grupa;
        // kolejne kategorie pozostają w tej grupie, aż zostanie ustawiony kolejny element.
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // Pokaż kategorię i wartość na liściu Tablets.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Formatuj gałąź Consumer poprzez pierwszy liść w tej gałęzi.
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // Formatuj gałąź pośrednią Software poprzez pierwszy liść w tej gałęzi.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout wpływa na etykiety rodziców w Treemap; Sunburst używa segmentów pierścieni.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Komórki kategorii i komórki wartości używają tego samego wiersza arkusza, więc ich pozycje w kolekcji pozostają wyrównane. Gdy pracujesz z istniejącym wykresem zamiast go tworzyć, najpierw sprawdź wiersze kategorii i przechowaj nazwane odwołania do punktów danych oraz poziomów, które zamierzasz sformatować.

## **Zachowanie i praktyczne uwagi**

### **Różnice między Treemap a Sunburst**

- Treemap wykorzystuje pole powierzchni do przekazywania wartości i zagnieżdżone prostokąty do przekazywania hierarchii. Metoda [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/#setParentLabelLayout) kontroluje, jak wyświetlane są etykiety rodziców w tym typie wykresu.
- Sunburst wykorzystuje kąt do przekazywania wartości i głębokość pierścienia do przekazywania hierarchii. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/#setParentLabelLayout) nie kontroluje etykiet pierścieni.
- Oba typy wykresów używają tych samych poziomów grupowania kategorii i tej samej kolejności liść‑do‑rodzica zwracanej przez [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapoint/#getDataPointLevels), więc kod budujący dane i formatujący poziomy może być współdzielony.
- Wartości rodziców są obliczane na podstawie ich liści potomnych. Nie dodawaj oddzielnych punktów liczbowych dla gałęzi lub gałęzi pośrednich.

### **Sortowanie i kolejność segmentów**

Silnik układu wykresu określa ostateczne położenie prostokątów i segmentów pierścieni. Grupuj powiązane wiersze kategorii razem przed ich dodaniem, ale nie polegaj na konkretnym położeniu prostokąta ani kącie początkowym. Jeśli kolejność ma znaczenie, uwzględnij ją w etykietach lub użyj typu wykresu z wyraźną osią kategorii.

### **Motyw i stałe kolory**

Niesformatowane poziomy wykresu dziedziczą kolory z motywu prezentacji. Przykład używa jawnych wypełnień RGB, aby uzyskać przewidywalny wynik. Jeśli wykres ma podążać za zmianami motywu, używaj kolorów schematu zamiast stałych wartości RGB i unikaj nadpisywania każdego poziomu. Sprawdź także kontrast etykiet po zmianie wypełnienia gałęzi lub gałęzi pośredniej.

### **Etykiety i dostępna przestrzeń**

PowerPoint może ukrywać lub obcinać etykiety, gdy segment jest zbyt mały. Zwiększenie rozmiaru wykresu, skrócenie nazw kategorii lub wyświetlenie mniejszej liczby pól etykiety zazwyczaj daje czytelniejszy rezultat. Etykieta może łączyć nazwę kategorii, nazwę serii i wartość za pomocą [DataLabelFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datalabelformat/), ale włączanie wszystkich pól często utrudnia odczyt wykresów hierarchicznych.

### **Eksport i renderowanie**

Zapis do formatu PPTX pozostawia wykres edytowalny. Gdy Aspose.Slides renderuje prezentację do PDF lub obrazu, obsługiwane wypełnienia i ustawienia etykiet są renderowane razem z wykresem. Substitucja czcionek oraz niewielkie różnice w dostępnej przestrzeni układu mogą zmienić łamanie wierszy lub widoczność etykiet, dlatego zainstaluj wymagane czcionki i zweryfikuj kluczowe cele eksportu.

## **FAQ**

**Dlaczego zmiana poziomu rodzica wpływa na kilka liści?**

Gałąź lub gałąź pośrednia to współdzielony segment wizualny. Jej [ChartDataPointLevel](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapointlevel/) jest dostępny przez liść potomny, ale formatowanie należy do współdzielonego segmentu rodzica, a nie wyłącznie do tego liścia.

**Dlaczego brakuje etykiety danych?**

Najpierw włącz wymagane pola w obiekcie [DataLabelFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datalabelformat/) etykiety. Następnie sprawdź, czy segment ma wystarczającą przestrzeń. Układ rodzica w Treemap, wymiary wykresu, długość etykiety, rozmiar czcionki i liczba włączonych pól wpływają na to, czy etykieta może być wyświetlona.

**Czy mogę ustawić dokładną kolejność lub współrzędne segmentów?**

Możesz kontrolować kolejność wierszy źródłowych i utrzymywać każdą grupę spójną, ale nie możesz przypisać dokładnych prostokątów Treemap ani kątów Sunburst. Silnik układu wykresu oblicza je na podstawie hierarchii, wartości i dostępnej przestrzeni.

**Dlaczego kolory zmieniają się po zmianie motywu prezentacji?**

Wypełnienia oparte na motywie są przeznaczone do podążania za paletą prezentacji. Zastosuj jawne kolory RGB do poziomów, które muszą pozostać stałe, lub używaj kolorów schematu, gdy preferowane jest dostosowanie się do nowego motywu.

**Czy niestandardowe formatowanie zostanie zachowane w eksportach PDF i obrazów?**

Tak, obsługiwane wypełnienia wykresu i ustawienia etykiet są uwzględniane podczas renderowania. Aby uzyskać spójne wyniki na różnych systemach, udostępnij wymagane czcionki i przetestuj ostateczny rozmiar eksportu, ponieważ dopasowanie etykiet zależy od układu.

## **Zobacz także**

- [Create Treemap charts](/slides/pl/php-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/pl/php-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/pl/php-java/export-chart/)
- [Manage presentation themes](/slides/pl/php-java/presentation-theme/)