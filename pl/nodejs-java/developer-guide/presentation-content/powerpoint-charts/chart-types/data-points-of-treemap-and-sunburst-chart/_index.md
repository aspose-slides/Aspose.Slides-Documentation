---
title: Dostosowywanie punktów danych w wykresach Treemap i Sunburst przy użyciu JavaScript
linktitle: Punkty danych w wykresach Treemap i Sunburst
type: docs
url: /pl/nodejs-java/data-points-of-treemap-and-sunburst-chart/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak tworzyć dane hierarchiczne oraz dostosowywać poziomy, etykiety i kolory w wykresach Treemap i Sunburst przy użyciu Aspose.Slides dla Node.js via Java."
---
## **Przegląd**

Wykresy Treemap i Sunburst wyświetlają ten sam rodzaj danych hierarchicznych, ale używają różnych układów. Treemap rysuje hierarchię jako zagnieżdżone prostokąty, których pola reprezentują wartości liści. Sunburst przedstawia ją jako koncentryczne pierścienie: grupy najwyższego poziomu znajdują się blisko środka, a kategorie liściowe są na zewnętrznym pierścieniu.

W Aspose.Slides for Node.js via Java każda wartość liczbowa jest elementem [ChartDataPoint](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatapoint/). Metoda [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) zapewnia dostęp do liścia oraz jego grup nadrzędnych. Ten artykuł wyjaśnia to mapowanie i pokazuje, jak tworzyć oraz formatować oba typy wykresów na podstawie tego samego zestawu danych.

![Wykres Treemap z gałęziami Consumer i Business](treemap-hierarchy.png)

![Wykres Sunburst z tą samą hierarchią Consumer i Business](sunburst-hierarchy.png)

## **Zrozumienie kategorii, punktów danych i poziomów**

Przykład użyty poniżej zawiera trzy poziomy kategorii i jedną serię liczbową:

| Gałąź | Stem | Liść | Przychód |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Każdy wiersz tworzy jedną kategorię liściową i jeden punkt danych. Poziomy grupowania opisują ścieżkę od tego liścia do jego rodziców. Dla pierwszego wiersza ścieżka to `Consumer > Computers > Laptops`.

Indeksy zwracane przez [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) idą od liścia w górę:

| indeks `getDataPointLevels()` | Poziom logiczny | Reprezentacja Treemap | Reprezentacja Sunburst |
| ---: | --- | --- | --- |
| `0` | Liść | Prostokąt wartości | Segment pierścienia zewnętrznego |
| `1` | Stem | Prostokąt lub nagłówek rodzica | Segment pierścienia środkowego |
| `2` | Branch | Prostokąt lub nagłówek najwyższego poziomu | Segment pierścienia wewnętrznego |

Ta kolejność jest taka sama dla obu typów wykresów, mimo że ich układy wizualne się różnią. Segment rodzica jest współdzielony przez kilka liści. Aby sformatować go, użyj odpowiedniego poziomu pierwszego punktu danych w tej grupie. Na przykład gałąź `Consumer` zaczyna się od punktu `Laptops`, a stem `Software` od punktu `Licenses`. Przechowywanie odniesień do tych punktów jest czytelniejsze i bezpieczniejsze niż używanie nieopisanych wyrażeń typu `dataPoints.get_Item(0)` lub `dataPoints.get_Item(6)`.

## **Utwórz i dostosuj oba typy wykresów**

Poniższy kompletny przykład tworzy wykres Treemap na pierwszym slajdzie i wykres Sunburst na drugim slajdzie. Buduje hierarchię, wyświetla wartość dla `Tablets`, stosuje stałe kolory do wybranych poziomów, formatuje etykietę gałęzi i zapisuje prezentację.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Dodaj kategorie liści. Element grupujący jest ustawiany tylko wtedy, gdy rozpoczyna się nowa grupa;
        // kolejne kategorie pozostają w tej grupie, aż zostanie ustawiony kolejny element.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Pokaż kategorię i wartość w liściu Tablets.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formatuj gałąź Consumer poprzez pierwszy liść w tej gałęzi.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // Formatuj stem Software poprzez pierwszy liść w tym stemie.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout wpływa na etykiety rodziców w Treemap; Sunburst używa segmentów pierścieni.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Komórki kategorii i komórki wartości używają tego samego wiersza arkusza, więc ich pozycje w kolekcji pozostają wyrównane. Gdy pracujesz z istniejącym wykresem zamiast go tworzyć, najpierw sprawdź wiersze kategorii i przechowuj nazwane odwołania do punktów danych oraz poziomów, które zamierzasz sformatować.

## **Zachowanie i praktyczne rozważania**

### **Różnice między Treemap a Sunburst**

- Treemap używa pola, aby przekazać wartość, oraz zagnieżdżonych prostokątów, aby przekazać hierarchię. Metoda [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) kontroluje, jak etykiety rodziców pojawiają się w tym typie wykresu.
- Sunburst używa kąta, aby przekazać wartość, oraz głębokości pierścieni, aby przekazać hierarchię. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) nie kontroluje etykiet pierścieni w tym wykresie.
- Oba typy wykresów używają tych samych poziomów grupowania kategorii i tej samej kolejności liść‑do‑rodzica zwracanej przez [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels), więc kod budujący dane i kod formatujący poziomy może być współdzielony.
- Wartości rodziców są obliczane na podstawie ich liści potomnych. Nie dodawaj oddzielnych punktów liczbowych dla gałęzi lub stemów.

### **Sortowanie i kolejność segmentów**

Silnik układu wykresu określa ostateczne położenie prostokątów i segmentów pierścieni. Ułóż powiązane wiersze kategorii razem przed ich dodaniem, ale nie polegaj na określonej pozycji prostokąta ani kącie początkowym. Jeśli kolejność niesie znaczenie, uwzględnij ją w etykietach lub użyj typu wykresu z wyraźną osią kategorii.

### **Motyw i stałe kolory**

Niefortmatowane poziomy wykresu dziedziczą kolory z motywu prezentacji. Przykład używa jawnych wypełnień RGB dla przewidywalnego wyniku. Jeśli wykres ma podążać za zmianami motywu, używaj kolorów schematów zamiast stałych wartości RGB i unikaj nadpisywania każdego poziomu. Sprawdź także kontrast etykiet po zmianie wypełnienia gałęzi lub stemu.

### **Etykiety i dostępna przestrzeń**

PowerPoint może ukrywać lub przycinać etykiety, gdy segment jest zbyt mały. Zwiększenie rozmiaru wykresu, skrócenie nazw kategorii lub wyświetlenie mniejszej liczby pól etykiet zazwyczaj daje klarowniejszy wynik. Etykieta może łączyć nazwę kategorii, nazwę serii i wartość za pomocą [DataLabelFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/datalabelformat/), ale włączenie każdego pola często utrudnia czytelność wykresów hierarchicznych.

### **Eksport i renderowanie**

Zapis do PPTX zachowuje możliwość edycji wykresu. Gdy Aspose.Slides renderuje prezentację do PDF lub obrazu, obsługiwane wypełnienia i ustawienia etykiet są renderowane razem z wykresem. Substytucja czcionek oraz niewielkie różnice w dostępnej przestrzeni układu mogą zmienić łamanie linii lub widoczność etykiet, więc zainstaluj wymagane czcionki i zweryfikuj ważne cele eksportu.

## **FAQ**

**Dlaczego zmiana poziomu rodzica wpływa na kilka liści?**

Gałąź lub stem jest współdzielonym segmentem wizualnym. Jego [ChartDataPointLevel](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatapointlevel/) można osiągnąć przez liść potomny, ale formatowanie dotyczy współdzielonego segmentu rodzica, nie tylko tego liścia.

**Dlaczego brakuje etykiety danych?**

Najpierw włącz wymagane pola w obiekcie [DataLabelFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/datalabelformat/) etykiety. Następnie sprawdź, czy segment ma wystarczająco miejsca. Układ etykiet rodziców w Treemap, wymiary wykresu, długość etykiety, rozmiar czcionki i liczba włączonych pól wpływają na to, czy etykieta może być wyświetlona.

**Czy mogę ustawić dokładną kolejność lub współrzędne segmentów?**

Możesz kontrolować kolejność wierszy źródłowych i utrzymywać każdą grupę spójnie, ale nie możesz przypisać dokładnych prostokątów Treemap ani kątów Sunburst. Silnik układu wykresu oblicza je na podstawie hierarchii, wartości i dostępnej przestrzeni.

**Dlaczego kolory zmieniają się po zmianie motywu prezentacji?**

Wypełnienia oparte na motywie są zaprojektowane tak, by podążały za paletą prezentacji. Zastosuj jawne kolory RGB dla poziomów, które muszą pozostać stałe, lub używaj kolorów schematów, gdy preferowane jest dostosowanie do nowego motywu.

**Czy niestandardowe formatowanie zostanie zachowane w eksportach PDF i obrazu?**

Tak, obsługiwane wypełnienia wykresu i ustawienia etykiet są uwzględniane podczas renderowania. Aby uzyskać spójne wyniki na różnych systemach, udostępnij wymagane czcionki i przetestuj końcowy rozmiar eksportu, ponieważ dopasowywanie etykiet zależy od układu.

## **Zobacz także**

- [Utwórz wykresy Treemap](/slides/pl/nodejs-java/create-chart/#creating-tree-map-charts)
- [Utwórz wykresy Sunburst](/slides/pl/nodejs-java/create-chart/#creating-sunburst-charts)
- [Eksportuj wykresy z prezentacji](/slides/pl/nodejs-java/export-chart/)
- [Zarządzaj motywami prezentacji](/slides/pl/nodejs-java/presentation-theme/)