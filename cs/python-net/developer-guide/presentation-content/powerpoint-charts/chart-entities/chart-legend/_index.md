---
title: Přizpůsobení legend grafů v prezentacích pomocí Pythonu
linktitle: Legenda grafu
type: docs
url: /cs/python-net/chart-legend/
keywords:
- legenda grafu
- umístění legendy
- velikost písma
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Přizpůsobte legendy grafů pomocí Aspose.Slides pro Python via .NET a optimalizujte prezentace PowerPoint s cíleným formátováním legend."
---
## **Přehled**

Aspose.Slides for Python via .NET poskytuje možnosti přizpůsobení legendy grafu v prezentacích PowerPoint. Tento článek ukazuje, jak umístit a změnit velikost legendy, nastavit velikost písma pro celou legendu, formátovat jednotlivý záznam legendy a skrýt nebo obnovit vybrané záznamy.

Často kladené otázky (FAQ) pokrývají související chování, včetně rezervování místa pro legendu, zobrazování víceřádkových popisků a dědění formátování z motivu prezentace.

## **Umístění legendy**

Použijte vlastnosti legendy [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/), a [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) k určení její polohy a velikosti jako zlomků rozměrů grafu.

V tomto příkladu se vytvoří prezentace a na první snímek se přidá seskupený sloupcový graf s výchozími daty. Rozdělením požadovaných posunů a rozměrů legendy šířkou a výškou grafu je převede na relativní hodnoty: legenda je posunuta o 50 bodů od levého horního rohu grafu a má rozměry 100 × 100 bodů.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Vyjádřete polohu a velikost legendy vzhledem k grafu.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení velikosti písma legendy**

Použijte vlastnost legendy [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) k získání přístupu k jejímu formátování textu a nastavte [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) v bodech.

V tomto příkladu se vytvoří graf s výchozími daty a nastaví se text legendy na 20 bodů. Také se zakáže automatické ohraničení pro vertikální osu a nastaví se její rozsah od -5 do 10.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení velikosti písma jednotlivého záznamu legendy**

Použijte kolekci legendy [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) k získání formátování konkrétního záznamu. Indexy záznamů jsou nulově založené, takže index `1` odkazuje na druhý záznam.

V tomto příkladu se vytvoří seskupený sloupcový graf, jehož výchozí data obsahují alespoň dvě řady. Druhý záznam legendy se formátuje tučným, kurzívou a modrým textem o velikosti 20 bodů.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Skrytí jednotlivých záznamů legendy**

Aby se vyloučila pomocná řada z legendy a přitom zůstala její data viditelná, nastavte [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) na `True` pomocí [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/). Tím se skryje pouze vybraný záznam legendy; řada ani její datové body nejsou odstraněny. Nastavením [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) na `False` se naproti tomu skryje celá legenda.

Následující příklad vytvoří seskupený sloupcový graf s více řadami pomocí výchozích dat. Skryje záznam legendy druhé řady (index `1`) a uloží prezentaci. Poté záznam obnoví nastavením [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) na `False` a uloží druhou kopii. Sloupce zůstávají v obou souborech viditelné.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Obnovte stejný záznam bez změny dat grafu.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

Porovnání níže zobrazuje stejný graf se všemi viditelnými záznamy legendy a s legendou, kde je řada 2 skryta; všechny sloupce zůstávají viditelné. ![Porovnání grafu se všemi viditelnými záznamy legendy a s legendou, kde je řada 2 skryta; všechny sloupce zůstávají viditelné.](hide-legend-entry.png)

U sloupcových, pruhových a čarových grafů záznamy legendy identifikují řady. U koláčových grafů identifikují jednotlivé datové body (segmenty), takže místo toho použijte [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) na vybraný segment. API tuto vlastnost datového bodu dokumentuje pro typy grafů `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE` a `BAR_OF_PIE`. Nepředpokládejte, že se vztahuje i na prstencové grafy, které v tomto seznamu nejsou uvedeny.

## **Často kladené otázky**

**Mohu nechat graf vyhradit místo pro legendu místo jejího překrývání?**  
Ano. Nastavte [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) na `False`, aby legenda vyhradila místo místo toho, aby překrývala oblast vykreslování.

**Mohu vytvořit víceřádkové popisky legendy?**  
Ano. Dlouhé popisky se mohou zalamovat, pokud není k dispozici dostatečná šířka. Můžete také použít znaky nového řádku v názvech řad k požádání o zalomení řádku.

**Jak zajistit, aby legenda používala barevné schéma motivu prezentace?**  
Nechte barvy, výplně a písma legendy nenastavené, aby mohla dědit formátování motivu. Explicitní formátování přepíše odpovídající nastavení motivu.