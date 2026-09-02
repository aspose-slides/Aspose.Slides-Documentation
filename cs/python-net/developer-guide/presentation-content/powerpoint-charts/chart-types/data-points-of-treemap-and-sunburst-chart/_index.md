---
title: Přizpůsobení datových bodů v grafech Treemap a Sunburst v Pythonu
linktitle: Datové body v grafech Treemap a Sunburst
type: docs
url: /cs/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- graf Treemap
- graf Sunburst
- hierarchický graf
- datový bod
- datový popisek
- barva větve
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak vytvořit hierarchická data a přizpůsobit úrovně, popisky a barvy v grafech Treemap a Sunburst pomocí Aspose.Slides pro Python přes .NET."
---
## **Přehled**

Grafy Treemap a Sunburst zobrazují stejný typ hierarchických dat, ale používají odlišné rozvržení. Treemap vykresluje hierarchii jako vnořené obdélníky, jejichž plochy představují hodnoty listů. Sunburst vykresluje data jako soustředné kruhy: skupiny nejvyšší úrovně jsou blízko středu a kategorie listů jsou na vnějším kruhu.

V Aspose.Slides pro Python přes .NET je každá číselná hodnota objekt typu [ChartDataPoint](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/). Jeho kolekce [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) poskytuje přístup k listu a jeho nadřazeným skupinám. Tento článek vysvětluje toto mapování a ukazuje, jak vytvořit a formátovat oba typy grafů ze stejných ukázkových dat.

![Graf Treemap s větvemi Consumer a Business](treemap-hierarchy.png)

![Graf Sunburst se stejnou hierarchií Consumer a Business](sunburst-hierarchy.png)

## **Pochopení kategorií, datových bodů a úrovní**

Níže použitý příklad obsahuje tři úrovně kategorií a jednu číselnou sérii:

| Větev | Stvol | List | Příjem |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Každý řádek vytvoří jednu kategorii listu a jeden datový bod. Úrovně seskupení kategorií popisují cestu od tohoto listu k jeho nadřazeným prvkům. Pro první řádek je cesta `Consumer > Computers > Laptops`.

Indexy v [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) jsou počítány od listu směrem nahoru:

| `data_point_levels` index | Logická úroveň | Reprezentace Treemap | Reprezentace Sunburst |
| ---: | --- | --- | --- |
| `0` | List | Obdélník hodnoty | Segment vnějšího kruhu |
| `1` | Stvol | Obdélník nebo záhlaví rodiče | Segment prostředního kruhu |
| `2` | Větev | Obdélník nebo záhlaví nejvyšší úrovně | Segment vnitřního kruhu |

Toto pořadí je stejné pro oba typy grafů, i když se jejich vizuální rozvržení liší. Segment rodiče je sdílen několika listy. Pro jeho formátování použijte odpovídající úroveň prvního datového bodu v této skupině. Například větev `Consumer` začíná bodem `Laptops`, zatímco stvol `Software` začíná bodem `Licenses`. Uchovávání odkazů na tyto body je přehlednější a bezpečnější než používání nejasných výrazů jako `data_points[0]` nebo `data_points[6]`.

## **Vytvoření a přizpůsobení obou typů grafů**

Následující kompletní příklad vytvoří Treemap na první snímku a Sunburst na druhém snímku. Vytvoří hierarchii, zobrazí hodnotu pro `Tablets`, použije pevné barvy na vybrané úrovně, naformátuje popisek větve a uloží prezentaci.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # Přidejte kategorie listů. Prvek seskupení se nastaví pouze při zahájení nové skupiny;
    # následující kategorie zůstávají v této skupině, dokud není nastaven další prvek.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # Zobrazte název kategorie a hodnotu u listu Tablets.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # Naformátujte větev Consumer pomocí prvního listu v této větvi.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # Naformátujte stvol Software pomocí prvního listu v tomto stvolu.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout ovlivňuje popisky rodičů v Treemap; Sunburst používá segmenty kruhů.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

Buňky kategorií a buňky hodnot používají stejný řádek pracovního listu, takže jejich pozice v kolekcích zůstávají zarovnané. Když pracujete s existujícím grafem místo jeho tvorby, nejprve zkontrolujte řádky kategorií a uložte pojmenované odkazy na datové body a úrovně, které chcete formátovat.

## **Chování a praktické úvahy**

### **Rozdíly mezi Treemap a Sunburst**

- Treemap používá plochu k vyjádření hodnoty a vnořené obdélníky k vyjádření hierarchie. Vlastnost [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/parent_label_layout/) řídí, jak se zobrazí popisky rodičů v tomto typu grafu.
- Sunburst používá úhel k vyjádření hodnoty a hloubku kruhu k vyjádření hierarchie. [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/parent_label_layout/) neovlivňuje popisky kruhů.
- Oba typy grafů používají stejné úrovně seskupení kategorií a stejný pořadí list‑k‑rodiči v `data_point_levels`, takže kód pro vytváření dat a formátování úrovní může být sdílen.
- Hodnoty rodičů jsou vypočítány z jejich podřízených listů. Nepřidávejte samostatné číselné body pro větve nebo stvoly.

### **Řazení a pořadí segmentů**

Engine pro rozvržení grafu určuje konečné umístění obdélníků a segmentů kruhů. Před jejich přidáním uspořádejte související řádky kategorií dohromady, ale nespoléhejte se na konkrétní pozici obdélníku nebo počáteční úhel. Pokud má posloupnost význam, zahrňte ji do popisků nebo použijte typ grafu s explicitní kategoriální osou.

### **Motiv a pevné barvy**

Neformátované úrovně grafu dědí barvy z motivu prezentace. Příklad používá explicitní výplně RGB pro předvídatelný výstup. Pokud má graf sledovat změny motivu, použijte barvy ze schématu místo pevných hodnot RGB a vyhněte se přepisování každé úrovně. Po změně výplně větve nebo stvolu také zkontrolujte kontrast popisků.

### **Popisky a dostupný prostor**

PowerPoint může skrýt nebo zkrátit popisky, když je segment příliš malý. Zvýšení velikosti grafu, zkrácení názvů kategorií nebo zobrazení méně polí popisků obvykle vede k jasnějšímu výsledku. Popisek může kombinovat název kategorie, název série a hodnotu pomocí [DataLabelFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabelformat/), ale povolení všech polí často ztěžuje čtení hierarchických grafů.

### **Export a vykreslování**

Uložení do PPTX zachovává graf editovatelný. Když Aspose.Slides vykresluje prezentaci do PDF nebo obrázku, podporované výplně a nastavení popisků jsou vykresleny společně s grafem. Substituce fontů a malé rozdíly v dostupném prostoru rozvržení mohou změnit zalamování řádků nebo viditelnost popisků, proto nainstalujte požadované fonty a ověřte důležité cíle exportu.

## **Často kladené otázky**

**Proč změna úrovně rodiče ovlivní několik listů?**

Větev nebo stvol je sdílený vizuální segment. Jeho [ChartDataPointLevel](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapointlevel/) lze získat přes podřízený list, ale formátování patří sdílenému segmentu rodiče, nikoli jen danému listu.

**Proč chybí datový popisek?**

Nejprve povolte požadovaná pole v objektu [DataLabelFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabelformat/) popisku. Poté zkontrolujte, zda má segment dostatek místa. Rozvržení popisků rodičů v Treemap, rozměry grafu, délka popisku, velikost písma a počet povolených polí všechno ovlivňuje, zda může být popisek zobrazen.

**Mohu nastavit přesné pořadí nebo souřadnice segmentů?**

Můžete řídit pořadí řádků ve zdroji a udržet každou skupinu souvislou, ale nemůžete přiřadit přesné obdélníky Treemap ani úhly Sunburst. Engine pro rozvržení grafu je vypočítá z hierarchie, hodnot a dostupného prostoru.

**Proč se barvy změní po změně motivu prezentace?**

Barvy založené na motivu jsou navrženy tak, aby sledovaly paletu prezentace. Použijte explicitní RGB barvy na úrovně, které mají zůstat pevné, nebo zachovejte barvy ze schématu, když je preferováno přizpůsobení novému motivu.

**Zůstane vlastní formátování zachováno v PDF a obrázkových exportech?**

Ano, podporované výplně grafu a nastavení popisků jsou zahrnuty během vykreslování. Pro konzistentní výsledky napříč systémy zajistěte dostupnost požadovaných fontů a otestujte finální velikost exportu, protože přizpůsobení popisků je závislé na rozvržení.

## **Související odkazy**

- [Create Treemap charts](/slides/cs/python-net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/cs/python-net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/cs/python-net/export-chart/)
- [Manage presentation themes](/slides/cs/python-net/presentation-theme/)