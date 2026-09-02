---
title: Dostosowywanie punktów danych w wykresach Treemap i Sunburst w .NET
linktitle: Punkty danych w wykresach Treemap i Sunburst
type: docs
url: /pl/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- wykres treemap
- wykres sunburst
- wykres hierarchiczny
- punkt danych
- etykieta danych
- kolor gałęzi
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak tworzyć dane hierarchiczne i dostosowywać poziomy, etykiety oraz kolory w wykresach Treemap i Sunburst przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Treemap i Sunburst wyświetlają te same dane hierarchiczne, ale używają różnych układów. Treemap rysuje hierarchię jako zagnieżdżone prostokąty, których pola reprezentują wartości liści. Sunburst rysuje ją jako koncentryczne pierścienie: grupy najwyższego poziomu znajdują się blisko środka, a kategorie liści na zewnętrznym pierścieniu.

W Aspose.Slides for .NET każda wartość liczbowa jest [IChartDataPoint](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatapoint/). Jej kolekcja [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) zapewnia dostęp do liścia i jego grup nadrzędnych. Ten artykuł wyjaśnia to mapowanie i pokazuje, jak tworzyć i formatować oba typy wykresów na podstawie tych samych danych przykładowych.

![Wykres Treemap z gałęziami Consumer i Business](treemap-hierarchy.png)

![Wykres Sunburst z tą samą hierarchią Consumer i Business](sunburst-hierarchy.png)

## **Zrozumienie kategorii, punktów danych i poziomów**

Przykład użyty poniżej ma trzy poziomy kategorii i jedną serię liczbową:

| Gałąź | Pion | Liść | Przychód |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Każdy wiersz tworzy jedną kategorię liścia i jeden punkt danych. Poziomy grupowania opisują ścieżkę od tego liścia do jego rodziców. Dla pierwszego wiersza ścieżka to `Consumer > Computers > Laptops`.

Indeksy w [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) liczą się od liścia w górę:

| `DataPointLevels` indeks | Poziom logiczny | Reprezentacja w Treemap | Reprezentacja w Sunburst |
| ---: | --- | --- | --- |
| `0` | Liść | Prostokąt wartości | Segment zewnętrznego pierścienia |
| `1` | Pion | Prostokąt nadrzędny lub nagłówek | Segment środkowego pierścienia |
| `2` | Gałąź | Prostokąt najwyższego poziomu lub nagłówek | Segment wewnętrznego pierścienia |

Ta kolejność jest taka sama dla obu typów wykresów, mimo że ich układy wizualne różnią się. Segment nadrzędny jest współdzielony przez kilka liści. Aby go sformatować, użyj odpowiedniego poziomu pierwszego punktu danych w tej grupie. Na przykład gałąź `Consumer` zaczyna się od punktu `Laptops`, a pion `Software` od punktu `Licenses`. Przechowywanie odwołań do tych punktów jest jaśniejsze i bezpieczniejsze niż używanie niezrozumiałych wyrażeń typu `dataPoints[0]` czy `dataPoints[6]`.

## **Utwórz i dostosuj oba typy wykresów**

Poniższy kompletny przykład tworzy Treemap na pierwszym slajdzie i Sunburst na drugim slajdzie. Buduje hierarchię, wyświetla wartość dla `Tablets`, stosuje stałe kolory do wybranych poziomów, formatuje etykietę gałęzi i zapisuje prezentację.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // Dodaj kategorie liści. Element grupowania jest ustawiany tylko wtedy, gdy rozpoczyna się nowa grupa;
    // kolejne kategorie pozostają w tej grupie, aż zostanie ustawiony kolejny element.
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // Pokaż kategorię i wartość w liściu Tablets.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // Sformatuj gałąź Consumer za pomocą pierwszego liścia w tej gałęzi.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // Sformatuj pion Software za pomocą pierwszego liścia w tym pionie.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout wpływa na etykiety rodziców w Treemap; Sunburst używa segmentów pierścieni.
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

Komórki kategorii i komórki wartości używają tego samego wiersza arkusza, więc ich pozycje w kolekcji pozostają wyrównane. Gdy pracujesz z istniejącym wykresem zamiast go tworzyć, najpierw sprawdź wiersze kategorii i zapisz nazwane odwołania do punktów danych oraz poziomów, które zamierzasz formatować.

## **Zachowanie i praktyczne uwagi**

### **Różnice między wykresami Treemap i Sunburst**

- Treemap używa pola, aby przekazać wartość, oraz zagnieżdżonych prostokątów, aby przedstawić hierarchię. Właściwość [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseries/parentlabellayout/) steruje tym, jak wyświetlane są etykiety rodziców w tym typie wykresu.
- Sunburst używa kąta, aby przekazać wartość, oraz głębokości pierścienia, aby przedstawić hierarchię. [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseries/parentlabellayout/) nie steruje jego etykietami pierścieni.
- Oba typy wykresów używają tych samych poziomów grupowania kategorii i tej samej kolejności liść‑do‑rodzica w `DataPointLevels`, więc kod budujący dane i formatujący poziomy może być współdzielony.
- Wartości rodziców są obliczane z ich liści potomnych. Nie dodawaj oddzielnych punktów liczbowych dla gałęzi lub pionów.

### **Sortowanie i kolejność segmentów**

Silnik układu wykresu określa ostateczne położenie prostokątów i segmentów pierścieni. Ułóż powiązane wiersze kategorii razem przed ich dodaniem, ale nie polegaj na konkretnym położeniu prostokąta ani kącie początkowym. Jeśli kolejność ma znaczenie, uwzględnij ją w etykietach lub użyj typu wykresu z wyraźną osią kategorii.

### **Motyw i stałe kolory**

Niesformatowane poziomy wykresu dziedziczą kolory z motywu prezentacji. Przykład używa explicite wypełnień RGB dla przewidywalnego wyniku. Jeśli wykres ma podążać za zmianami motywu, użyj kolorów ze schematu zamiast stałych wartości RGB i unikaj nadpisywania każdego poziomu. Sprawdź także kontrast etykiet po zmianie wypełnienia gałęzi lub pionu.

### **Etykiety i dostępna przestrzeń**

PowerPoint może ukrywać lub obcinać etykiety, gdy segment jest zbyt mały. Powiększenie wykresu, skrócenie nazw kategorii lub wyświetlenie mniejszej liczby pól etykiet zazwyczaj daje czytelniejszy rezultat. Etykieta może łączyć nazwę kategorii, nazwę serii i wartość przy użyciu [IDataLabelFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/idatalabelformat/), ale włączanie wszystkich pól często utrudnia odczyt wykresów hierarchicznych.

### **Eksport i renderowanie**

Zapis do PPTX pozostawia wykres edytowalny. Gdy Aspose.Slides renderuje prezentację do PDF lub obrazu, obsługiwane wypełnienia i ustawienia etykiet są renderowane razem z wykresem. Substitucja czcionek oraz niewielkie różnice w dostępnej przestrzeni układu mogą zmienić łamanie linii lub widoczność etykiet, więc zainstaluj wymagane czcionki i zweryfikuj ważne cele eksportu.

## **FAQ**

**Dlaczego zmiana poziomu rodzica wpływa na kilka liści?**

Gałąź lub pion jest współdzielonym segmentem wizualnym. Jego [IChartDataPointLevel](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatapointlevel/) można osiągnąć przez liść potomny, ale formatowanie należy do współdzielonego segmentu rodzica, a nie tylko do tego liścia.

**Dlaczego brak jest etykiety danych?**

Najpierw włącz wymagane pola w obiekcie [IDataLabelFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/idatalabelformat/) etykiety. Następnie sprawdź, czy segment ma wystarczająco miejsca. Układ etykiet rodzica w Treemap, wymiary wykresu, długość etykiety, rozmiar czcionki i liczba włączonych pól wpływają na to, czy etykieta może być wyświetlona.

**Czy mogę ustawić dokładną kolejność lub współrzędne segmentów?**

Możesz kontrolować kolejność wierszy źródłowych i utrzymywać każdą grupę spójną, ale nie możesz przypisać dokładnych prostokątów Treemap ani kątów Sunburst. Silnik układu wykresu oblicza je na podstawie hierarchii, wartości i dostępnej przestrzeni.

**Dlaczego kolory zmieniają się po zmianie motywu prezentacji?**

Wypełnienia oparte na motywie mają podążać za paletą prezentacji. Zastosuj explicite kolory RGB do poziomów, które muszą pozostać stałe, lub zachowaj kolory ze schematu, jeśli preferujesz dostosowanie się do nowego motywu.

**Czy niestandardowe formatowanie zostanie zachowane w eksportach PDF i obrazach?**

Tak, obsługiwane wypełnienia wykresów i ustawienia etykiet są uwzględniane podczas renderowania. Aby uzyskać spójne wyniki na różnych systemach, udostępnij wymagane czcionki i przetestuj ostateczny rozmiar eksportu, ponieważ dopasowanie etykiet zależy od układu.

## **Zobacz także**

- [Create Treemap charts](/slides/pl/net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/pl/net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/pl/net/export-chart/)
- [Manage presentation themes](/slides/pl/net/presentation-theme/)