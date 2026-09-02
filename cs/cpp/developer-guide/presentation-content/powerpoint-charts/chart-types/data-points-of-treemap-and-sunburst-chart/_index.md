---
title: Přizpůsobení datových bodů v grafech Treemap a Sunburst v C++
linktitle: Datové body v grafech Treemap a Sunburst
type: docs
url: /cs/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- graf Treemap
- graf Sunburst
- hierarchický graf
- datový bod
- popisek dat
- barva větve
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak vytvořit hierarchická data a přizpůsobit úrovně, popisky a barvy v grafech Treemap a Sunburst pomocí Aspose.Slides pro C++."
---
## **Přehled**

Treemap a Sunburst grafy zobrazují stejný typ hierarchických dat, ale používají odlišné rozvržení. Treemap vykresluje hierarchii jako vnořené obdélníky, jejichž plochy představují hodnoty listů. Sunburst ji vykresluje jako soustředné kruhy: skupiny nejvyšší úrovně jsou blízko středu a kategorie listů jsou na vnější kružnici.

V Aspose.Slides pro C++ je každá číselná hodnota objekt typu [IChartDataPoint](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/). Jeho metoda [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) poskytuje přístup k listu a jeho nadřazeným skupinám. Tento článek vysvětluje toto mapování a ukazuje, jak vytvořit a formátovat oba typy grafů ze stejných ukázkových dat.

![Graf Treemap s pobočkami Consumer a Business](treemap-hierarchy.png)

![Graf Sunburst se stejnou hierarchií Consumer a Business](sunburst-hierarchy.png)

## **Pochopení kategorií, datových bodů a úrovní**

Ukázková data níže mají tři úrovně kategorií a jednu číselnou sérii:

| Pobočka | Stonek | List | Obrat |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Každý řádek vytvoří jednu kategorii listu a jeden datový bod. Úrovně seskupování kategorií popisují cestu od tohoto listu k jeho nadřazeným položkám. Pro první řádek je cesta `Consumer > Computers > Laptops`.

Indexy vrácené metodou [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) běží od listu směrem nahoru:

| `get_DataPointLevels()` index | Logická úroveň | Reprezentace treemap | Reprezentace sunburst |
| ---: | --- | --- | --- |
| `0` | Leaf | Value rectangle | Outer-ring segment |
| `1` | Stem | Parent rectangle or header | Middle-ring segment |
| `2` | Branch | Top-level rectangle or header | Inner-ring segment |

Toto pořadí je stejné pro oba typy grafů, i když se jejich vizuální rozvržení liší. Nadřazený segment je sdílen několika listy. Pro jeho formátování použijte odpovídající úroveň prvního datového bodu v dané skupině. Například větev `Consumer` začíná bodem `Laptops`, zatímco stonek `Software` začíná bodem `Licenses`. Udržování odkazů na tyto body je přehlednější a bezpečnější než používání nevysvětlených výrazů jako `dataPoints->idx_get(0)` nebo `dataPoints->idx_get(6)`.

## **Vytvoření a přizpůsobení obou typů grafů**

Následující kompletní příklad vytvoří Treemap na první snímku a Sunburst na druhém snímku. Vytvoří hierarchii, zobrazí hodnotu pro `Tablets`, použije pevné barvy pro vybrané úrovně, formátuje popisek větev a uloží prezentaci.

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

    // Přidejte listové kategorie. Skupinová položka je nastavena pouze při zahájení nové skupiny;
    // následující kategorie zůstávají v této skupině, dokud není nastavena další položka.
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

    // Zobrazte kategorii a hodnotu na listu Tablets.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Formátujte větev Consumer pomocí prvního listu v této větvi.
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

    // Formátujte stonek Software pomocí prvního listu v tomto stonku.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout ovlivňuje popisky nadřazených položek v Treemap; Sunburst používá segmenty kruhů.
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

Buňky kategorií a hodnot používají stejný řádek pracovního listu, takže jejich pozice v kolekcích zůstávají zarovnané. Když pracujete s existujícím grafem místo jeho vytváření, nejprve prozkoumejte řádky kategorií a uložte pojmenované odkazy na datové body a úrovně, které chcete formátovat.

## **Chování a praktické úvahy**

### **Rozdíly mezi Treemap a Sunburst**

- Treemap používá plochu k vyjádření hodnoty a vnořené obdélníky k vyjádření hierarchie. Metoda [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) řídí, jak se zobrazují popisky nadřazených položek v tomto typu grafu.
- Sunburst používá úhel k vyjádření hodnoty a hloubku kruhu k vyjádření hierarchie. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) neovlivňuje popisky jeho kruhů.
- Oba typy grafů používají stejné úrovně seskupování kategorií a stejné pořadí list‑na‑nadřazený vrácené metodou [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/), takže kód pro tvorbu dat a formátování úrovní může být sdílen.
- Hodnoty nadřazených položek jsou vypočítány z jejich podřízených listů. Nepřidávejte samostatné číselné body pro větev nebo stonek.

### **Řazení a pořadí segmentů**

Engine pro rozvržení grafu určuje konečnou polohu obdélníků a kruhových segmentů. Před jejich přidáním seskupte související řádky kategorií dohromady, ale nespoléhejte se na konkrétní pozici obdélníku nebo počáteční úhel. Pokud sekvence nese význam, zahrňte ji do popisků nebo použijte typ grafu s explicitní osou kategorií.

### **Motiv a pevné barvy**

Neformátované úrovně grafu dědí barvy z motivu prezentace. Příklad používá explicitní výplně RGB pro předvídatelný výstup. Pokud má graf sledovat změny motivu, použijte barvy schématu místo pevných hodnot RGB a vyhněte se přepisování každé úrovně. Také po změně výplně větve nebo stoneku zkontrolujte kontrast popisků.

### **Popisky a dostupný prostor**

PowerPoint může skrýt nebo zkrátit popisky, když je segment příliš malý. Zvětšení velikosti grafu, zkrácení názvů kategorií nebo zobrazení méně polí popisků obvykle vede k přehlednějšímu výsledku. Popisek může kombinovat název kategorie, název série a hodnotu pomocí [IDataLabelFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/idatalabelformat/), ale povolení všech polí často ztěžuje čitelnost hierarchických grafů.

### **Export a vykreslování**

Uložení do PPTX zachová graf editovatelný. Když Aspose.Slides vykresluje prezentaci do PDF nebo obrázku, podporované výplně a nastavení popisků jsou vykresleny společně s grafem. Náhrada písem a malé rozdíly v dostupném prostoru rozvržení mohou změnit zalomení řádků nebo viditelnost popisků, proto nainstalujte požadovaná písma a ověřte důležité cíle exportu.

## **Často kladené otázky**

**Proč změna úrovně nadřazené položky ovlivní několik listů?**

Větev nebo stonek je sdílený vizuální segment. Jeho [IChartDataPointLevel](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapointlevel/) lze dosáhnout přes podřízený list, ale formátování patří sdílenému nadřazenému segmentu, nikoli jen tomuto listu.

**Proč chybí datový popisek?**

Nejprve povolte požadovaná pole na objektu [IDataLabelFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/idatalabelformat/) popisku. Pak zkontrolujte, zda má segment dostatek místa. Rozvržení popisků nadřazených položek Treemap, rozměry grafu, délka popisku, velikost písma a počet povolených polí všechno ovlivňuje, zda lze popisek zobrazit.

**Mohu nastavit přesné pořadí nebo souřadnice segmentů?**

Můžete řídit pořadí řádků zdroje a udržet každou skupinu souvislou, ale nemůžete přiřadit přesné obdélníky Treemap ani úhly Sunburst. Engine pro rozvržení grafu je vypočítá z hierarchie, hodnot a dostupného prostoru.

**Proč se barvy mění po změně motivu prezentace?**

Výplně založené na motivu jsou navrženy tak, aby následovaly paletu prezentace. Použijte explicitní barvy RGB pro úrovně, které musí zůstat pevné, nebo zachovejte barvy schématu, pokud je preferováno přizpůsobení novému motivu.

**Zůstane vlastní formátování zachováno při exportu do PDF a obrázků?**

Ano, podporované výplně grafu a nastavení popisků jsou zahrnuty během vykreslování. Pro konzistentní výsledky napříč systémy zajistěte dostupnost požadovaných písem a otestujte konečnou velikost exportu, protože umístění popisků je závislé na rozvržení.

## **Související odkazy**

- [Vytvoření grafů Treemap](/slides/cs/cpp/create-chart/#create-tree-map-charts)
- [Vytvoření grafů Sunburst](/slides/cs/cpp/create-chart/#create-sunburst-charts)
- [Export grafů z prezentace](/slides/cs/cpp/export-chart/)
- [Správa motivů prezentace](/slides/cs/cpp/presentation-theme/)