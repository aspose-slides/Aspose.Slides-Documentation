---
title: Dostosowywanie punktów danych w wykresach Treemap i Sunburst na Androidzie
linktitle: Punkty danych w wykresach Treemap i Sunburst
type: docs
url: /pl/androidjava/data-points-of-treemap-and-sunburst-chart/
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
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć dane hierarchiczne i dostosowywać poziomy, etykiety oraz kolory w wykresach Treemap i Sunburst przy użyciu Aspose.Slides dla Androida w Java."
---
## **Przegląd**

Treemap i Sunburst wyświetlają ten sam rodzaj danych hierarchicznych, ale używają różnych układów. Treemap rysuje hierarchię jako zagnieżdżone prostokąty, których pola reprezentują wartości liści. Sunburst przedstawia ją jako koncentryczne pierścienie: grupy najwyższego poziomu znajdują się blisko środka, a kategorie liści na zewnętrznym pierścieniu.

W Aspose.Slides dla Androida via Java, każda wartość numeryczna jest [IChartDataPoint](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/). Jego metoda [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) zapewnia dostęp do liścia i jego grup nadrzędnych. Ten artykuł wyjaśnia to mapowanie i pokazuje, jak utworzyć oraz sformatować oba typy wykresów na podstawie tych samych danych przykładowych.

![Wykres Treemap z gałęziami Consumer i Business](treemap-hierarchy.png)

![Wykres Sunburst z tą samą hierarchią Consumer i Business](sunburst-hierarchy.png)

## **Zrozumienie kategorii, punktów danych i poziomów**

Przykład użyty poniżej ma trzy poziomy kategorii i jedną serię numeryczną:

| Gałąź | Pnia | Liść | Przychód |
| --- | --- | --- | ---: |
| Konsument | Komputery | Laptopy | 12 |
| Konsument | Komputery | Komputery stacjonarne | 8 |
| Konsument | Mobilne | Telefony | 15 |
| Konsument | Mobilne | Tablety | 6 |
| Biznes | Usługi | Konsulting | 10 |
| Biznes | Usługi | Wsparcie | 7 |
| Biznes | Oprogramowanie | Licencje | 11 |
| Biznes | Oprogramowanie | Subskrypcje | 14 |

Każdy wiersz tworzy jedną kategorię liścia i jeden punkt danych. Poziomy grupowania kategorii opisują ścieżkę od tego liścia do jego rodziców. Dla pierwszego wiersza ścieżka to `Consumer > Computers > Laptops`.

Indeksy zwracane przez [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) są liczone od liścia w górę:

| `getDataPointLevels()` indeks | Poziom logiczny | Reprezentacja Treemap | Reprezentacja Sunburst |
| ---: | --- | --- | --- |
| `0` | Liść | Prostokąt wartości | Segment zewnętrznego pierścienia |
| `1` | Pnia | Prostokąt rodzica lub nagłówek | Segment środkowego pierścienia |
| `2` | Gałąź | Prostokąt najwyższego poziomu lub nagłówek | Segment wewnętrznego pierścienia |

Ta kolejność jest taka sama dla obu typów wykresów, mimo że ich układy wizualne się różnią. Segment rodzica jest współdzielony przez kilka liści. Aby go sformatować, użyj odpowiedniego poziomu pierwszego punktu danych w tej grupie. Na przykład gałąź `Consumer` zaczyna się od punktu `Laptops`, podczas gdy pion `Software` zaczyna się od punktu `Licenses`. Przechowywanie odniesień do tych punktów jest czytelniejsze i bezpieczniejsze niż używanie niewyjaśnionych wyrażeń, takich jak `dataPoints.get_Item(0)` czy `dataPoints.get_Item(6)`.

## **Utworzenie i dostosowanie obu typów wykresów**

Pon below pełny przykład tworzy wykres Treemap na pierwszym slajdzie i wykres Sunburst na drugim slajdzie. Buduje hierarchię, wyświetla wartość dla `Tablets`, stosuje stałe kolory do wybranych poziomów, formatuje etykietę gałęzi i zapisuje prezentację.

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

        // Dodaj kategorie liści. Element grupujący jest ustawiany tylko wtedy, gdy zaczyna się nowa grupa;
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

        // Pokaż kategorię i wartość na liściu Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Sformatuj gałąź Consumer poprzez pierwszy liść w tej gałęzi.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Sformatuj pień Software poprzez pierwszy liść w tym pniu.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout wpływa na etykiety rodziców w Treemap; Sunburst używa segmentów pierścienia.
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

### **Różnice między Treemap i Sunburst**

- Treemap używa pola do przekazywania wartości i zagnieżdżonych prostokątów do przekazywania hierarchii. Metoda [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) kontroluje, jak wyświetlane są etykiety rodziców w tym typie wykresu.
- Sunburst używa kąta do przekazywania wartości i głębokości pierścienia do przedstawiania hierarchii. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) nie kontroluje etykiet pierścieni.
- Oba typy wykresów używają tych samych poziomów grupowania kategorii oraz tego samego porządku liść-do-rodzica zwracanego przez [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), więc kod budujący dane i formatujący poziomy może być współdzielony.
- Wartości rodziców są obliczane na podstawie ich potomnych liści. Nie dodawaj osobnych punktów liczbowych dla gałęzi lub pni.

### **Sortowanie i kolejność segmentów**

Silnik układu wykresu określa ostateczne rozmieszczenie prostokątów i segmentów pierścieni. Zgrupuj powiązane wiersze kategorii przed ich dodaniem, ale nie polegaj na określonej pozycji prostokąta ani kącie początkowym. Jeśli kolejność ma znaczenie, uwzględnij ją w etykietach lub użyj typu wykresu z wyraźną osią kategorii.

### **Motyw i stałe kolory**

Nie sformatowane poziomy wykresu dziedziczą kolory z motywu prezentacji. Przykład używa wyraźnych wypełnień RGB dla przewidywalnych wyników. Jeśli wykres ma podążać za zmianami motywu, użyj kolorów schematu zamiast stałych wartości RGB i unikaj nadpisywania każdego poziomu. Sprawdź również kontrast etykiet po zmianie wypełnienia gałęzi lub pnia.

### **Etykiety i dostępna przestrzeń**

PowerPoint może ukrywać lub obcinać etykiety, gdy segment jest zbyt mały. Zwiększenie rozmiaru wykresu, skrócenie nazw kategorii lub wyświetlenie mniejszej liczby pól etykiety zazwyczaj daje klarowniejszy wynik. Etykieta może łączyć nazwę kategorii, nazwę serii i wartość przy użyciu [IDataLabelFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idatalabelformat/), ale włączenie wszystkich pól często utrudnia czytanie wykresów hierarchicznych.

### **Eksport i renderowanie**

Zapisywanie do PPTX zachowuje wykres jako edytowalny. Gdy Aspose.Slides renderuje prezentację do PDF lub obrazu, obsługiwane wypełnienia i ustawienia etykiet są renderowane wraz z wykresem. Zastąpienie czcionek i niewielkie różnice w dostępnej przestrzeni układu mogą zmienić łamanie linii lub widoczność etykiet, dlatego zainstaluj wymagane czcionki i zweryfikuj ważne cele eksportu.

## **FAQ**

**Dlaczego zmiana poziomu rodzica wpływa na kilka liści?**

Gałąź lub pień jest współdzielonym segmentem wizualnym. Jego [IChartDataPointLevel](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapointlevel/) można uzyskać przez potomny liść, ale formatowanie dotyczy współdzielonego segmentu rodzica, a nie tylko tego liścia.

**Dlaczego brakuje etykiety danych?**

Najpierw włącz wymagane pola w obiekcie [IDataLabelFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idatalabelformat/) etykiety. Następnie sprawdź, czy segment ma wystarczająco dużo miejsca. Układ etykiety rodzica w Treemap, wymiary wykresu, długość etykiety, rozmiar czcionki i liczba włączonych pól wpływają na to, czy etykieta może być wyświetlona.

**Czy mogę ustawić dokładną kolejność lub współrzędne segmentów?**

Możesz kontrolować kolejność wierszy źródłowych i utrzymać każdą grupę jako ciągłą, ale nie możesz przypisać dokładnych prostokątów Treemap ani kątów Sunburst. Silnik układu wykresu oblicza je na podstawie hierarchii, wartości i dostępnej przestrzeni.

**Dlaczego kolory zmieniają się po zmianie motywu prezentacji?**

Wypełnienia oparte na motywie są zaprojektowane tak, aby podążały za paletą prezentacji. Zastosuj wyraźne kolory RGB do poziomów, które mają pozostać stałe, lub zachowaj kolory schematu, gdy preferowane jest dostosowanie do nowego motywu.

**Czy niestandardowe formatowanie będzie zachowane w eksportach do PDF i obrazów?**

Tak, obsługiwane wypełnienia wykresu i ustawienia etykiet są uwzględniane podczas renderowania. Aby uzyskać spójne wyniki na różnych systemach, udostępnij wymagane czcionki i przetestuj ostateczny rozmiar eksportu, ponieważ dopasowanie etykiet zależy od układu.

## **Zobacz także**

- [Utwórz wykresy Treemap](/slides/pl/androidjava/create-chart/#create-tree-map-charts)
- [Utwórz wykresy Sunburst](/slides/pl/androidjava/create-chart/#create-sunburst-charts)
- [Eksportuj wykresy prezentacji](/slides/pl/androidjava/export-chart/)
- [Zarządzaj motywami prezentacji](/slides/pl/androidjava/presentation-theme/)