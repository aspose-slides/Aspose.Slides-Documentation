---
title: Přizpůsobení datových bodů v grafech Treemap a Sunburst v .NET
linktitle: Datové body v grafech Treemap a Sunburst
type: docs
url: /cs/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- graf treemap
- graf sunburst
- hierarchický graf
- datový bod
- popisek dat
- barva větve
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se vytvářet hierarchická data a přizpůsobovat úrovně, popisky a barvy v grafech Treemap a Sunburst pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Grafy Treemap a Sunburst zobrazují stejný typ hierarchických dat, ale používají odlišné rozložení. Treemap vykresluje hierarchii jako vnořené obdélníky, jejichž plochy představují hodnoty listů. Sunburst ji zobrazuje jako soustředné kruhy: skupiny nejvyšší úrovně jsou blízko středu a kategorie listů jsou na vnějším kruhu.

V Aspose.Slides pro .NET je každá číselná hodnota objekt typu [IChartDataPoint](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/). Jeho kolekce [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) poskytuje přístup k listu a jeho nadřazeným skupinám. Tento článek vysvětluje toto mapování a ukazuje, jak vytvořit a formátovat oba typy grafů ze stejných ukázkových dat.

![Graf Treemap s větvemi Consumer a Business](treemap-hierarchy.png)

![Graf Sunburst se stejnou hierarchií Consumer a Business](sunburst-hierarchy.png)

## **Pochopení kategorií, datových bodů a úrovní**

Vzor použité níže má tři úrovně kategorií a jeden číselný řad:

| Větev | Kmen | List | Příjem |
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

Indexy v [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) běží od listu směrem nahoru:

| `DataPointLevels` index | Logická úroveň | Reprezentace Treemap | Reprezentace Sunburst |
| ---: | --- | --- | --- |
| `0` | List | Obdélník hodnoty | Segment vnějšího kruhu |
| `1` | Kmen | Obdélník nebo záhlaví nadřazeného | Segment prostředního kruhu |
| `2` | Větev | Obdélník nebo záhlaví nejvyšší úrovně | Segment vnitřního kruhu |

Toto pořadí je stejné pro oba typy grafů, i když se jejich vizuální rozložení liší. Nadřazený segment je sdílený několika listy. Pro formátování použijte odpovídající úroveň prvního datového bodu v dané skupině. Například větev `Consumer` začíná bodem `Laptops`, zatímco kmen `Software` začíná bodem `Licenses`. Uchovávání odkazů na tyto body je přehlednější a bezpečnější než používání nevysvětlených výrazů jako `dataPoints[0]` nebo `dataPoints[6]`.

## **Vytvoření a přizpůsobení obou typů grafů**

Následující kompletní příklad vytvoří Treemap na první snímku a Sunburst na druhém snímku. Vytvoří hierarchii, zobrazí hodnotu pro `Tablets`, použije pevné barvy na vybrané úrovně, naformátuje popisek větve a uloží prezentaci.

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

    // Přidejte kategorie listů. Prvku seskupení se nastaví pouze při zahájení nové skupiny;
    // následující kategorie zůstávají v této skupině, dokud se nenastaví další prvek.
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

    // Zobrazte kategorii a hodnotu na listu Tablets.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // Naformátujte větev Consumer pomocí prvního listu v této větvi.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // Naformátujte kmen Software pomocí prvního listu v tomto kmenu.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout ovlivňuje popisky nadřazených položek v Treemap; Sunburst používá segmenty kruhů.
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

Buňky kategorií a buňky hodnot používají stejný řádek listu, takže jejich pozice v kolekcích zůstávají zarovnané. Když pracujete s existujícím grafem místo jeho vytváření, nejprve prozkoumejte řádky kategorií a uložte pojmenované odkazy na datové body a úrovně, které chcete formátovat.

## **Chování a praktické úvahy**

### **Rozdíly mezi Treemap a Sunburst**

- Treemap používá plochu k vyjádření hodnoty a vnořené obdélníky k vyjádření hierarchie. Vlastnost [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/parentlabellayout/) řídí, jak se zobrazují popisky nadřazených položek v tomto typu grafu.
- Sunburst používá úhel k vyjádření hodnoty a hloubku kruhu k vyjádření hierarchie. [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/parentlabellayout/) neovlivňuje popisky jeho kruhů.
- Oba typy grafů používají stejné úrovně seskupování kategorií a stejný pořádek list‑k‑nadřazenému v `DataPointLevels`, takže kód pro vytváření dat a formátování úrovní může být sdílen.
- Hodnoty nadřazených položek jsou vypočítány z jejich podřízených listů. Nepřidávejte samostatné číselné body pro větve nebo kmene.

### **Řazení a pořadí segmentů**

Engine rozložení grafu určuje konečné umístění obdélníků a segmentů kruhu. Před jejich přidáním seskupte související řádky kategorií, ale nespoléhejte se na konkrétní pozici obdélníku nebo počáteční úhel. Pokud má sekvence význam, zahrňte ji do popisků nebo použijte typ grafu s explicitní kategoriální osou.

### **Motiv a pevné barvy**

Neformátované úrovně grafu dědí barvy z motivu prezentace. Příklad používá explicitní výplně RGB pro předvídatelný výstup. Pokud má graf sledovat změny motivu, použijte barvy schématu místo pevných hodnot RGB a vyhněte se přepsání každé úrovně. Také po změně výplně větve nebo kmene zkontrolujte kontrast popisků.

### **Popisky a dostupný prostor**

PowerPoint může skrýt nebo oříznout popisky, když je segment příliš malý. Zvětšení velikosti grafu, zkrácení názvů kategorií nebo zobrazení méně polí popisků obvykle vede k přehlednějšímu výsledku. Popisek může kombinovat název kategorie, název řady a hodnotu pomocí [IDataLabelFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/idatalabelformat/), ale povolení všech polí často ztěžuje čitelnost hierarchických grafů.

### **Export a vykreslování**

Ukládání do PPTX zachovává graf editovatelný. Když Aspose.Slides vykresluje prezentaci do PDF nebo obrázku, podporované výplně a nastavení popisků jsou vykresleny s grafem. Náhrada písem a drobné rozdíly v dostupném prostoru mohou změnit zalomení řádků nebo viditelnost popisků, takže nainstalujte požadovaná písma a ověřte důležité cíle exportu.

## **Často kladené otázky**

**Proč změna úrovně nadřazené položky ovlivní několik listů?**  
Větev nebo kmen je sdílený vizuální segment. Jeho [IChartDataPointLevel](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapointlevel/) lze dosáhnout přes podřízený list, ale formátování patří sdílenému nadřazenému segmentu, nikoli jen tomuto listu.

**Proč chybí datový popisek?**  
Nejprve povolte požadovaná pole na objektu [IDataLabelFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/idatalabelformat/) popisku. Pak zkontrolujte, zda má segment dostatek místa. Rozložení popisků nadřazených položek v Treemap, rozměry grafu, délka popisku, velikost písma a počet povolených polí vše ovlivňuje, zda lze popisek zobrazit.

**Mohu nastavit přesné pořadí nebo souřadnice segmentů?**  
Můžete řídit pořadí řádků zdroje a udržet každou skupinu souvislou, ale nemůžete přiřadit přesné obdélníky Treemap ani úhly Sunburst. Engine rozložení grafu je spočítá z hierarchie, hodnot a dostupného prostoru.

**Proč se barvy mění po změně motivu prezentace?**  
Výplně založené na motivu jsou navrženy tak, aby následovaly paletu prezentace. Použijte explicitní barvy RGB pro úrovně, které mají zůstat pevné, nebo zachovejte barvy schématu, pokud je upřednostněna adaptace na nový motiv.

**Zůstane vlastní formátování zachováno v exportu do PDF a obrázku?**  
Ano, podporované výplně grafu a nastavení popisků jsou zahrnuty při vykreslování. Pro konzistentní výsledky napříč systémy zajistěte dostupnost požadovaných písem a otestujte finální velikost exportu, protože umístění popisků je závislé na rozložení.

## **Související odkazy**

- [Create Treemap charts](/slides/cs/net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/cs/net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/cs/net/export-chart/)
- [Manage presentation themes](/slides/cs/net/presentation-theme/)