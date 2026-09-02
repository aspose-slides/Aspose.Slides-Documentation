---
title: Dostosowywanie punktów danych w wykresach Treemap i Sunburst w C++
linktitle: Punkty danych w wykresach Treemap i Sunburst
type: docs
url: /pl/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- wykres treemap
- wykres sunburst
- wykres hierarchiczny
- punkt danych
- etykieta danych
- kolor gałęzi
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak tworzyć dane hierarchiczne i dostosowywać poziomy, etykiety oraz kolory w wykresach Treemap i Sunburst przy użyciu Aspose.Slides dla C++."
---
## **Przegląd**

Wykresy Treemap i Sunburst wyświetlają ten sam typ danych hierarchicznych, ale używają różnych układów. Treemap rysuje hierarchię jako zagnieżdżone prostokąty, których pola reprezentują wartości liści. Sunburst przedstawia ją jako koncentryczne pierścienie: grupy najwyższego poziomu znajdują się blisko środka, a kategorie liściowe na zewnętrznym pierścieniu.

W Aspose.Slides for C++ każdy numeryczny wynik jest [IChartDataPoint](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapoint/). Jego metoda [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) zapewnia dostęp do liścia oraz jego grup nadrzędnych. Ten artykuł wyjaśnia to mapowanie i pokazuje, jak utworzyć oraz sformatować oba typy wykresów na podstawie tych samych danych przykładowych.

![Wykres Treemap z gałęziami Konsument i Biznes](treemap-hierarchy.png)

![Wykres Sunburst z tą samą hierarchią Konsument i Biznes](sunburst-hierarchy.png)

## **Zrozumienie kategorii, punktów danych i poziomów**

Przykład użyty poniżej ma trzy poziomy kategorii i jedną serię numeryczną:

| Oddział | Gałąź | Liść | Przychód |
| --- | --- | --- | ---: |
| Konsument | Komputery | Laptopy | 12 |
| Konsument | Komputery | Komputery stacjonarne | 8 |
| Konsument | Mobilny | Telefony | 15 |
| Konsument | Mobilny | Tablety | 6 |
| Biznes | Usługi | Doradztwo | 10 |
| Biznes | Usługi | Wsparcie | 7 |
| Biznes | Oprogramowanie | Licencje | 11 |
| Biznes | Oprogramowanie | Subskrypcje | 14 |

Każdy wiersz tworzy jedną kategorię liścia i jeden punkt danych. Poziomy grupowania kategorii opisują ścieżkę od tego liścia do jego nadrzędnych elementów. Dla pierwszego wiersza ścieżka to `Konsument > Komputery > Laptopy`.

Indeksy zwracane przez [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) liczą od liścia w górę:

| `get_DataPointLevels()` indeks | Poziom logiczny | Reprezentacja w Treemap | Reprezentacja w Sunburst |
| ---: | --- | --- | --- |
| `0` | Liść | Prostokąt wartości | Segment pierścienia zewnętrznego |
| `1` | Gałąź | Prostokąt lub nagłówek rodzica | Segment pierścienia środkowego |
| `2` | Oddział | Prostokąt lub nagłówek najwyższego poziomu | Segment pierścienia wewnętrznego |

Ta kolejność jest taka sama dla obu typów wykresów, mimo że ich wizualne układy się różnią. Segment rodzica jest współdzielony przez kilka liści. Aby go sformatować, użyj odpowiedniego poziomu pierwszego punktu danych w tej grupie. Na przykład gałąź `Konsument` rozpoczyna się od punktu `Laptopy`, a gałąź `Oprogramowanie` od punktu `Licencje`. Przechowywanie odwołań do tych punktów jest czytelniejsze i bezpieczniejsze niż używanie nieopisanych wyrażeń takich jak `dataPoints->idx_get(0)` lub `dataPoints->idx_get(6)`.

## **Tworzenie i dostosowywanie obu typów wykresów**

Poniższy kompletny przykład tworzy wykres Treemap na pierwszym slajdzie i wykres Sunburst na drugim slajdzie. Buduje hierarchię, wyświetla wartość dla `Tablety`, stosuje stałe kolory do wybranych poziomów, formatuje etykietę gałęzi i zapisuje prezentację.

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // Dodaj kategorie liści. Element grupowania jest ustawiany tylko wtedy, gdy rozpoczyna się nowa grupa;
    // kolejne kategorie pozostają w tej grupie, aż zostanie ustawiony kolejny element.
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // Pokaż nazwę kategorii i wartość w liściu Tablety.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Sformatuj gałąź Consumer poprzez pierwszy liść w tej gałęzi.
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // Sformatuj szczebel Software poprzez pierwszy liść w tym szczeblu.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout wpływa na etykiety rodziców w Treemap; Sunburst używa segmentów pierścieni.
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Komórki kategorii i komórki wartości używają tego samego wiersza arkusza, więc ich pozycje w kolekcji pozostają wyrównane. Gdy pracujesz z istniejącym wykresem zamiast tworzyć nowy, najpierw sprawdź wiersze kategorii i zachowaj nazwane odwołania do punktów danych oraz poziomów, które zamierzasz sformatować.

## **Zachowanie i praktyczne uwagi**

### **Różnice między wykresami Treemap i Sunburst**

- Treemap wykorzystuje pole do przekazywania wartości i zagnieżdżone prostokąty do przekazywania hierarchii. Metoda [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) steruje tym, jak etykiety rodziców pojawiają się w tym typie wykresu.
- Sunburst wykorzystuje kąt do przekazywania wartości i głębokość pierścienia do przekazywania hierarchii. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) nie steruje etykietami pierścieni.
- Oba typy wykresów używają tych samych poziomów grupowania kategorii oraz tej samej kolejności liść‑do‑rodzic zwracanej przez [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/), więc kod budowania danych i formatowania poziomów może być współdzielony.
- Wartości rodziców są obliczane z ich liści potomnych. Nie dodawaj osobnych punktów liczbowych dla gałęzi lub gałęzi podrzędnych.

### **Sortowanie i kolejność segmentów**

Silnik układu wykresu określa ostateczne położenie prostokątów i segmentów pierścieni. Uporządkuj powiązane wiersze kategorii razem przed ich dodaniem, ale nie polegaj na konkretnej pozycji prostokąta ani kącie początkowym. Jeśli kolejność niesie znaczenie, uwzględnij ją w etykietach lub użyj typu wykresu z wyraźną osią kategorii.

### **Motyw i stałe kolory**

Niesformatowane poziomy wykresu dziedziczą kolory z motywu prezentacji. Przykład używa jawnych wypełnień RGB dla przewidywalnego wyniku. Jeśli wykres ma podążać za zmianami motywu, używaj kolorów schematu zamiast stałych wartości RGB i unikaj nadpisywania każdego poziomu. Sprawdź również kontrast etykiet po zmianie wypełnienia gałęzi lub gałęzi podrzędnej.

### **Etykiety i dostępna przestrzeń**

PowerPoint może ukrywać lub przycinać etykiety, gdy segment jest zbyt mały. Zwiększenie rozmiaru wykresu, skrócenie nazw kategorii lub wyświetlenie mniejszej liczby pól etykiety zazwyczaj daje czytelniejszy rezultat. Etykieta może łączyć nazwę kategorii, nazwę serii i wartość za pomocą [IDataLabelFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/idatalabelformat/), ale włączanie każdego pola często sprawia, że wykresy hierarchiczne stają się trudne do odczytania.

### **Eksport i renderowanie**

Zapis do PPTX pozostawia wykres edytowalny. Gdy Aspose.Slides renderuje prezentację do PDF lub obrazu, obsługiwane wypełnienia i ustawienia etykiet są renderowane wraz z wykresem. Zastąpienie czcionek i niewielkie różnice w dostępnej przestrzeni układu mogą zmienić łamanie linii lub widoczność etykiet, więc zainstaluj wymagane czcionki i zweryfikuj ważne cele eksportu.

## **Najczęściej zadawane pytania**

**Dlaczego zmiana poziomu rodzica wpływa na wiele liści?**

Gałąź lub gałąź podrzędna to współdzielony segment wizualny. Jej [IChartDataPointLevel](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapointlevel/) można osiągnąć przez liść potomny, ale formatowanie należy do współdzielonego segmentu rodzica, a nie tylko do tego liścia.

**Dlaczego brakuje etykiety danych?**

Najpierw włącz wymagane pola w obiekcie [IDataLabelFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/idatalabelformat/) etykiety. Następnie sprawdź, czy segment ma wystarczająco dużo miejsca. Układ etykiet rodziców w Treemap, wymiary wykresu, długość etykiety, rozmiar czcionki i liczba włączonych pól wpływają na to, czy etykieta może być wyświetlona.

**Czy mogę ustawić dokładną kolejność lub współrzędne segmentów?**

Możesz kontrolować kolejność wierszy źródłowych i utrzymać każdą grupę jako ciągłą, ale nie możesz przypisać dokładnych prostokątów Treemap ani kątów Sunburst. Silnik układu wykresu oblicza je na podstawie hierarchii, wartości i dostępnej przestrzeni.

**Dlaczego kolory zmieniają się po zmianie motywu prezentacji?**

Wypełnienia oparte na motywie są projektowane tak, aby podążały za paletą prezentacji. Zastosuj wyraźne kolory RGB do poziomów, które muszą pozostać stałe, lub zachowaj kolory schematu, gdy preferujesz dopasowanie do nowego motywu.

**Czy niestandardowe formatowanie zostanie zachowane w eksportach PDF i obrazów?**

Tak, obsługiwane wypełnienia wykresu i ustawienia etykiet są uwzględniane podczas renderowania. Aby uzyskać spójne wyniki na różnych systemach, udostępnij wymagane czcionki i przetestuj ostateczny rozmiar eksportu, ponieważ dopasowanie etykiet zależy od układu.

## **Zobacz także**

- [Create Treemap charts](/slides/pl/cpp/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/pl/cpp/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/pl/cpp/export-chart/)
- [Manage presentation themes](/slides/pl/cpp/presentation-theme/)