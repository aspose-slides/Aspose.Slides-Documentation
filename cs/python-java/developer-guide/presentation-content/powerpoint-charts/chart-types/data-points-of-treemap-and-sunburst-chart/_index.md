---
title: Přizpůsobení datových bodů v grafech Treemap a Sunburst v Pythonu
linktitle: Datové body v grafech Treemap a Sunburst
type: docs
url: /cs/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- graf Treemap
- graf Sunburst
- hierarchický graf
- datový bod
- popisek dat
- barva větve
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak vytvořit hierarchická data a přizpůsobit úrovně, popisky a barvy v grafech Treemap a Sunburst pomocí Aspose.Slides pro Python prostřednictvím Javy."
---
## **Přehled**

Grafy Treemap a Sunburst zobrazují stejný typ hierarchických dat, ale používají odlišné rozvržení. Treemap vykresluje hierarchii jako vnořené obdélníky, jejichž plocha představuje hodnoty listů. Sunburst ji zobrazuje jako soustředné kruhy: skupiny nejvyšší úrovně jsou blízko středu a kategorie listů jsou na vnějším kruhu.

V Aspose.Slides pro Python via Java je každá číselná hodnota objekt typu [ChartDataPoint](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/). Jeho metoda [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) poskytuje přístup k listu a jeho nadřazeným skupinám. Tento článek vysvětluje toto mapování a ukazuje, jak vytvořit a formátovat oba typy grafů ze stejné vzorové sady dat.

![Graf treemap s větvemi Consumer a Business](treemap-hierarchy.png)

![Graf Sunburst se stejnou hierarchií Consumer a Business](sunburst-hierarchy.png)

## **Pochopení kategorií, datových bodů a úrovní**

Níže použitý příklad má tři úrovně kategorií a jednu číselnou řadu:

| Větev | Střed | List | Tržby |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Každý řádek vytváří jednu kategorii listu a jeden datový bod. Úrovně seskupení kategorií popisují cestu od tohoto listu k jeho nadřazeným uzlům. Pro první řádek je cesta `Consumer > Computers > Laptops`.

Indexy vrácené metodou [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) běží od listu směrem nahoru:

| `getDataPointLevels()` index | Logická úroveň | Reprezentace Treemap | Reprezentace Sunburst |
| ---: | --- | --- | --- |
| `0` | List | Obdélník hodnoty | Segment vnějšího kruhu |
| `1` | Střed | Rodičovský obdélník nebo záhlaví | Segment prostředního kruhu |
| `2` | Větev | Obdélník nejvyšší úrovně nebo záhlaví | Segment vnitřního kruhu |

Toto pořadí je stejné pro oba typy grafů, i když se jejich vizuální rozvržení liší. Rodičovský segment je sdílen několika listy. Pro jeho formátování použijte odpovídající úroveň prvního datového bodu v této skupině. Například větev `Consumer` začíná bodem `Laptops`, zatímco střed `Software` začíná bodem `Licenses`. Uchovávání odkazů na tyto body je přehlednější a bezpečnější než používání nevysvětlených výrazů jako `data_points.get_Item(0)` nebo `data_points.get_Item(6)`.

## **Vytvoření a přizpůsobení obou typů grafů**

Následující kompletní příklad vytvoří Treemap na první snímku a Sunburst na druhém snímku. Vytvoří hierarchii, zobrazí hodnotu pro `Tablets`, použije pevné barvy na vybrané úrovně, naformátuje popisek větve a uloží prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # Přidejte kategorie listů. Prvek seskupení se nastaví pouze při zahájení nové skupiny;
        # následující kategorie zůstávají v této skupině, dokud není nastaven další prvek.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # Zobrazit kategorii a hodnotu u listu Tablets.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # Naformátujte větev Consumer pomocí prvního listu v této větvi.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # Naformátujte střed Software pomocí prvního listu v tomto středu.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout ovlivňuje popisky rodičů v Treemap; Sunburst používá segmenty kruhů.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Buňky s kategoriemi a buňky s hodnotami používají stejný řádek listu, takže jejich pozice v kolekcích zůstávají zarovnané. Když pracujete s existujícím grafem místo jeho vytváření, nejprve prozkoumejte řádky kategorií a uložte pojmenované odkazy na datové body a úrovně, které chcete formátovat.

## **Chování a praktické úvahy**

### **Rozdíly mezi Treemap a Sunburst**

- Treemap používá plochu k předání hodnoty a vnořené obdélníky k předání hierarchie. Metoda [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#setParentLabelLayout) řídí, jak se zobrazují popisky nadřazených položek v tomto typu grafu.
- Sunburst používá úhel k předání hodnoty a hloubku kruhu k předání hierarchie. Metoda [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#setParentLabelLayout) neovlivňuje popisky jeho kruhů.
- Oba typy grafů používají stejné úrovně seskupení kategorií a stejný pořadí list‑k‑rodiči vrácené metodou [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/#getDataPointLevels), takže kód pro vytváření dat a formátování úrovní může být sdílen.
- Hodnoty rodičů jsou vypočítány z jejich podřízených listů. Nepřidávejte samostatné číselné body pro větve nebo středky.

### **Řazení a pořadí segmentů**

Engine rozvržení grafu určuje konečné umístění obdélníků a segmentů kruhů. Sesypte související řádky kategorií dohromady před jejich přidáním, ale nespoléhejte se na konkrétní pozici obdélníku nebo počáteční úhel. Pokud má sekvence význam, zahrňte ji do popisků nebo použijte typ grafu s explicitní kategoriální osou.

### **Téma a pevné barvy**

Neformátované úrovně grafu dědí barvy z téma prezentace. Příklad používá explicitní výplně RGB pro předvídatelný výstup. Pokud má graf sledovat změny tématu, použijte barvy ze schématu místo pevných RGB hodnot a nepřepisujte každou úroveň. Také kontrolujte kontrast popisků po změně výplně větve nebo středku.

### **Popisky a dostupný prostor**

PowerPoint může skrývat nebo zkracovat popisky, když je segment příliš malý. Zvýšení velikosti grafu, zkrácení názvů kategorií nebo zobrazení méně polí popisků obvykle vede k čistějšímu výsledku. Popisek může kombinovat název kategorie, název řady a hodnotu pomocí [DataLabelFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabelformat/), ale povolení všech polí často ztěžuje čitelnost hierarchických grafů.

### **Export a vykreslování**

Ukládání do PPTX ponechává graf editovatelný. Když Aspose.Slides vykresluje prezentaci do PDF nebo obrázku, podporované výplně a nastavení popisků jsou vykresleny s grafem. Náhrada písma a malé rozdíly v dostupném prostoru rozvržení mohou změnit zalomení řádků nebo viditelnost popisků, takže nainstalujte požadovaná písma a ověřte důležité exportní cíle.

## **Časté otázky**

**Proč změna úrovně rodiče ovlivní několik listů?**

Větev nebo střed je sdílený vizuální segment. Jeho [ChartDataPointLevel](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapointlevel/) lze získat přes podřízený list, ale formátování patří sdílenému rodičovskému segmentu, nikoli jen tomuto listu.

**Proč chybí popisek dat?**

Nejprve povolte požadovaná pole v objektu popisku [DataLabelFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabelformat/). Pak zkontrolujte, zda má segment dostatek místa. Rozvržení popisků rodičů v Treemap, rozměry grafu, délka popisku, velikost písma a počet povolených polí všechno ovlivňuje, zda lze popisek zobrazit.

**Mohu nastavit přesné pořadí nebo souřadnice segmentů?**

Můžete řídit pořadí zdrojových řádků a udržet každou skupinu souvislou, ale nemůžete přiřadit přesné obdélníky Treemap nebo úhly Sunburst. Engine rozvržení grafu je spočítá z hierarchie, hodnot a dostupného prostoru.

**Proč se barvy změní po změně tématu prezentace?**

Výplně založené na tématu jsou navrženy tak, aby následovaly paletu prezentace. Použijte explicitní barvy RGB u úrovní, které musí zůstat pevné, nebo zachovejte barvy ze schématu, pokud je upřednostněna adaptace na nové téma.

**Zůstane vlastní formátování zachováno v PDF a exportech obrázků?**

Ano, podporované výplně grafu a nastavení popisků jsou zahrnuty při vykreslování. Pro konzistentní výsledky napříč systémy zajistěte dostupnost požadovaných písem a otestujte konečnou velikost exportu, protože přizpůsobení popisků je závislé na rozvržení.

## **Viz také**

- [Vytvořit grafy Treemap](/slides/cs/python-java/create-chart/#create-tree-map-charts)
- [Vytvořit grafy Sunburst](/slides/cs/python-java/create-chart/#create-sunburst-charts)
- [Exportovat grafy prezentace](/slides/cs/python-java/export-chart/)
- [Spravovat témata prezentace](/slides/cs/python-java/presentation-theme/)