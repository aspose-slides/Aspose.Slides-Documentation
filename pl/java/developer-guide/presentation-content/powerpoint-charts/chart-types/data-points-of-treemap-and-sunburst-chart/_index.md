---
title: Dostosowywanie punktów danych w wykresach Treemap i Sunburst w Javie
linktitle: Punkty danych w wykresach Treemap i Sunburst
type: docs
url: /pl/java/data-points-of-treemap-and-sunburst-chart/
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć dane hierarchiczne i dostosowywać poziomy, etykiety oraz kolory w wykresach Treemap i Sunburst za pomocą Aspose.Slides for Java."
---
## **Przegląd**

Diagramy Treemap i Sunburst wyświetlają ten sam rodzaj danych hierarchicznych, ale używają różnych układów. Treemap rysuje hierarchię jako zagnieżdżone prostokąty, których pola reprezentują wartości liści. Sunburst przedstawia ją jako koncentryczne pierścienie: grupy najwyższego poziomu znajdują się blisko środka, a kategorie liści na zewnętrznym pierścieniu.

W Aspose.Slides for Java każdy wartość liczbową reprezentuje [IChartDataPoint](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatapoint/). Jego metoda [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) umożliwia dostęp do liścia oraz jego grup nadrzędnych. Ten artykuł wyjaśnia to mapowanie i pokazuje, jak tworzyć i formatować oba typy wykresów na podstawie tych samych danych przykładowych.

![Wykres Treemap z gałęziami Consumer i Business](treemap-hierarchy.png)

![Wykres Sunburst z tą samą hierarchią Consumer i Business](sunburst-hierarchy.png)

## **Zrozumienie kategorii, punktów danych i poziomów**

Przykład użyty poniżej ma trzy poziomy kategorii i jedną serię liczbową:

| Branch | Stem | Leaf | Revenue |
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

Indeksy zwracane przez [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) biegną od liścia w górę:

| `getDataPointLevels()` index | Poziom logiczny | Reprezentacja Treemap | Reprezentacja Sunburst |
| ---: | --- | --- | --- |
| `0` | Liść | Prostokąt wartości | Segment zewnętrznego pierścienia |
| `1` | Pniak | Prostokąt rodzica lub nagłówek | Segment środkowego pierścienia |
| `2` | Gałąź | Prostokąt najwyższego poziomu lub nagłówek | Segment wewnętrznego pierścienia |

Ta kolejność jest taka sama dla obu typów wykresów, mimo że ich układy wizualne różnią się. Segment rodzica jest współdzielony przez kilka liści. Aby sformatować go, użyj odpowiedniego poziomu pierwszego punktu danych w tej grupie. Na przykład gałąź `Consumer` zaczyna się od punktu `Laptops`, natomiast pniak `Software` zaczyna się od punktu `Licenses`. Przechowywanie odwołań do tych punktów jest czytelniejsze i bezpieczniejsze niż używanie niewyjaśnionych wyrażeń, takich jak `dataPoints.get_Item(0)` czy `dataPoints.get_Item(6)`.

## **Utworzenie i dostosowanie obu typów wykresów**

Poniższy kompletny przykład tworzy wykres Treemap na pierwszym slajdzie i Sunburst na drugim slajdzie. Buduje hierarchię, wyświetla wartość dla `Tablets`, stosuje stałe kolory do wybranych poziomów, formatuje etykietę gałęzi i zapisuje prezentację.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Dodaj kategorie liści. Element grupujący jest ustawiany tylko wtedy, gdy rozpoczyna się nowa grupa;
        // kolejne kategorie pozostają w tej grupie, aż zostanie ustawiony kolejny element.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // Pokaż nazwę kategorii i wartość dla liścia Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Sformatuj gałąź Consumer przy użyciu pierwszego liścia w tej gałęzi.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Sformatuj pniak Software przy użyciu pierwszego liścia w tym pniaku.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout wpływa na etykiety rodziców w Treemap; Sunburst używa segmentów pierścieni.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Komórki kategorii i komórki wartości używają tego samego wiersza arkusza, więc ich pozycje w kolekcji pozostają wyrównane. Gdy pracujesz z istniejącym wykresem zamiast go tworzyć, najpierw sprawdź wiersze kategorii i przechowuj nazwane odwołania do punktów danych oraz poziomów, które zamierzasz sformatować.

## **Zachowanie i praktyczne uwagi**

### **Różnice między Treemap a Sunburst**

- Treemap używa pola do przedstawiania wartości oraz zagnieżdżonych prostokątów do przedstawiania hierarchii. Metoda [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) kontroluje, jak etykiety rodziców są wyświetlane w tym typie wykresu.
- Sunburst używa kąta do przedstawiania wartości oraz głębokości pierścienia do przedstawiania hierarchii. Metoda [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) nie kontroluje etykiet pierścieni.
- Oba typy wykresów używają tych samych poziomów grupowania kategorii i tej samej kolejności liść‑do‑rodzica zwracanej przez [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), więc kod budujący dane i formatujący poziomy może być współdzielony.
- Wartości rodziców są obliczane na podstawie ich liści potomnych. Nie dodawaj oddzielnych punktów liczbowych dla gałęzi lub pniaków.

### **Sortowanie i kolejność segmentów**

Silnik układu wykresu określa ostateczne położenie prostokątów i segmentów pierścieni. Uporządkuj powiązane wiersze kategorii razem przed ich dodaniem, ale nie polegaj na konkretnej pozycji prostokąta ani kącie początkowym. Jeśli kolejność ma znaczenie, uwzględnij ją w etykietach lub użyj typu wykresu z wyraźną osią kategorii.

### **Motyw i stałe kolory**

Niesformatowane poziomy wykresu dziedziczą kolory z motywu prezentacji. Przykład używa explicite wypełnień RGB, aby uzyskać przewidywalny wynik. Jeśli wykres ma podążać za zmianami motywu, używaj kolorów ze schematu zamiast stałych wartości RGB i unikaj nadpisywania każdego poziomu. Sprawdź także kontrast etykiet po zmianie wypełnienia gałęzi lub pniaka.

### **Etykiety i dostępna przestrzeń**

PowerPoint może ukrywać lub obcinać etykiety, gdy segment jest zbyt mały. Zwiększenie rozmiaru wykresu, skrócenie nazw kategorii lub wyświetlenie mniejszej liczby pól etykiet zazwyczaj daje czytelniejszy rezultat. Etykieta może łączyć nazwę kategorii, nazwę serii i wartość za pomocą [IDataLabelFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idatalabelformat/), ale włączenie wszystkich pól często utrudnia odczyt wykresów hierarchicznych.

### **Eksport i renderowanie**

Zapis do PPTX zachowuje możliwość edycji wykresu. Gdy Aspose.Slides renderuje prezentację do PDF lub obrazu, obsługiwane wypełnienia i ustawienia etykiet są renderowane wraz z wykresem. Zastępowanie czcionek oraz niewielkie różnice w dostępnej przestrzeni układu mogą zmienić łamanie linii lub widoczność etykiet, dlatego zainstaluj wymagane czcionki i zweryfikuj istotne cele eksportu.

## **Najczęściej zadawane pytania**

**Dlaczego zmiana poziomu rodzica wpływa na kilka liści?**

Gałąź lub pniak jest współdzielonym segmentem wizualnym. Jego [IChartDataPointLevel](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatapointlevel/) można osiągnąć poprzez liść potomny, ale formatowanie należy do współdzielonego segmentu rodzica, a nie tylko do tego liścia.

**Dlaczego brakuje etykiety danych?**

Najpierw włącz wymagane pola w obiekcie [IDataLabelFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idatalabelformat/) etykiety. Następnie sprawdź, czy segment ma wystarczająco dużo miejsca. Układ etykiet rodzica w Treemap, wymiary wykresu, długość etykiety, rozmiar czcionki i liczba włączonych pól wpływają na to, czy etykieta może być wyświetlona.

**Czy mogę ustawić dokładną kolejność lub współrzędne segmentów?**

Możesz kontrolować kolejność wierszy źródłowych i utrzymywać każdą grupę spójną, ale nie możesz przypisać dokładnych prostokątów Treemap ani kątów Sunburst. Silnik układu wykresu oblicza je na podstawie hierarchii, wartości i dostępnej przestrzeni.

**Dlaczego kolory zmieniają się po zmianie motywu prezentacji?**

Wypełnienia oparte na motywie są projektowane tak, aby podążały za paletą prezentacji. Zastosuj explicite kolory RGB do poziomów, które muszą pozostać stałe, albo używaj kolorów ze schematu, gdy preferowane jest dostosowanie do nowego motywu.

**Czy niestandardowe formatowanie zostanie zachowane w eksportach PDF i obrazów?**

Tak, obsługiwane wypełnienia wykresu i ustawienia etykiet są uwzględniane podczas renderowania. Aby uzyskać spójne wyniki na różnych systemach, udostępnij wymagane czcionki i przetestuj ostateczny rozmiar eksportu, ponieważ dopasowanie etykiet zależy od układu.

## **Zobacz także**

- [Utwórz wykresy Treemap](/slides/pl/java/create-chart/#create-tree-map-charts)
- [Utwórz wykresy Sunburst](/slides/pl/java/create-chart/#create-sunburst-charts)
- [Eksportuj wykresy prezentacji](/slides/pl/java/export-chart/)
- [Zarządzaj motywami prezentacji](/slides/pl/java/presentation-theme/)