---
title: Formátování grafů v prezentacích pomocí Pythonu
linktitle: Formátování grafu
type: docs
weight: 60
url: /cs/python-net/chart-formatting/
keywords:
- formát grafu
- formátování grafu
- entita grafu
- vlastnosti grafu
- nastavení grafu
- volby grafu
- vlastnosti písma
- zaoblený okraj
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se formátovat grafy v Aspose.Slides pro Python pomocí .NET a vylepšete svou prezentaci PowerPointu pomocí vlastních os, písem, číselných formátů a zaoblených okrajů grafu."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides formátovat grafy v prezentacích PowerPoint. Ukazuje, jak přizpůsobit klíčové prvky grafu, jako jsou osy, mřížkové čáry, názvy, legendy, oblast vykreslení a výplně stěn, aby se zlepšil vzhled a čitelnost dat v grafu.

Také demonstruje, jak nastavit vlastnosti písma pro text v grafu, použít předdefinované číselné formáty na data grafu a povolit zaoblené rohy oblasti grafu. Tyto příklady společně ukazují, jak řídit jak vizuální styl, tak prezentaci dat grafů v prezentaci.

Pro samostatné výplně a okraje na rostoucích a klesajících intervalech viz [příklad akciového grafu](/slides/cs/python-net/create-chart/#create-stock-charts).

## **Formátování entit grafu**

Použijte [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) k formátování názvů grafu, os, mřížkových čar, legend a oblasti vykreslení. Tento příklad vytváří čárový graf s markery a výchozími daty, poté aplikuje samostatné textové a čárové styly na jeho hodnotovou a kategoriální osu. Velikosti písma a šířky čar jsou zadány v bodech; popisky kategorií jsou otočeny o 45 stupňů.

Hodnotová osa používá [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) nezávisle na zdrojových buňkách. Její měřítko jde od -2 do 15, s hlavními intervaly 2 a vedlejšími intervaly 0,5. Příklad také kombinuje formátování procent s [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) nastaveným na tisíce, takže přizpůsobte tato nastavení významu a velikosti vašich dat. Legenda zůstává mimo oblast vykreslení, protože [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) je zakázáno. Výplně zadní stěny a podlahy jsou konfigurovány pomocí [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) a [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), ale tyto plochy jsou viditelné pouze v 3D grafech.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení vlastností písma pro graf**

Nastavte výchozí velikost písma pro text v grafu pomocí [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). Tento příklad vytváří seskupený sloupcový graf s písmenem 20 bodů a povoluje popisky hodnot pro první sérii pomocí [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Textové prvky s vlastními explicitními nastaveními písma mohou přepsat výchozí nastavení grafu.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Opětovné použití formátování textového rámce pro legendu grafu**

Aby legenda odpovídala nadpisu snímku, nastavte písmo pomocí [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) na první odstavci nadpisu. Zavolejte [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) na [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) legendy. Zkopíruje nastavení textového rámce, formátování prvního odstavce a výchozí vlastnosti písma tohoto odstavce. Formátování aplikované přímo na jednotlivé úseky nebo na pozdější odstavce zůstává lokální pro zdroj.

Příklad používá nadpis tučný, námořnický, 26‑bodový Calibri jako šablonu. Po stylizaci legendy použije [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) k aplikaci stejného formátování na samostatný popisek.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

V uložené prezentaci legenda a popisek odpovídají nadpisu ve velikosti, tloušťce a barvě. Legenda stále zobrazuje názvy sérií a popisek si zachovává svůj vlastní text. Pokud má úsek v popisku již explicitní velikost písma, tato velikost má přednost před zkopírovaným výchozím odstavcem.

| Před kopírováním | Po kopírování |
| --- | --- |
| ![Čtvrtletní graf prodeje s běžnými černými popisky legendy a černým popiskem](legend-formatting-before.png) | ![Stejný graf s většími, tučnými námořnickými popisky legendy a odpovídajícím popiskem](legend-formatting.png) |

## **Nastavení číselného formátu**

Použijte [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) k aplikaci vestavěného číselného formátu na buňky pracovního sešitu grafu. Tento příklad vytváří seskupený sloupcový graf s výchozími, buňkou podloženými daty a aplikuje formát s indexem 10 (`0.00%`) na každou buňku hodnoty série. Tím se změní způsob, jakým jsou hodnoty zobrazeny v pracovním sešitu, aniž by se změnily podkladové čísla; například 0,25 se zobrazí jako 25,00 %. Formáty os a popisků dat lze konfigurovat samostatně.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Následující tabulka uvádí vestavěné indexy číselných formátů s reprezentativními formáty Excelu pro jazyk anglický (Spojené státy). Přesné řetězce formátů a jejich zobrazení se mohou lišit podle aplikace a locale, zejména u měn a dat. Některé formáty Excelu se také liší od výchozích hodnot v standardu OOXML, jak je popsáno v [poznámkách k implementaci číselných formátů společnosti Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Formát |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Nastavení zaoblených okrajů oblasti grafu**

Povolte [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) k zaoblení rohu oblasti grafu. Příklad vytváří seskupený sloupcový graf a používá [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) aby jeho obrys získal plnou šedou barvu a jednovrstvý styl před uložením prezentace.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **Úprava existujících anotací grafu**

Graf může obsahovat vlastní tvary, například textovou anotaci vysvětlující stav zprávy. Přístup k těmto tvarům získáte přes [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). Jeho kolekce [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) obsahuje tvary vlastněné grafem.

Běžná textová oblast umístěná nad grafem patří ke snímku, i když vypadá jako součást grafu. Procházení [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) najde graf a běžné tvary snímku, ale nevyjmenuje jednotlivé tvary uvnitř grafu. Názvy grafu a popisky dat jsou samostatné prvky grafu, ne vlastní anotace v této kolekci.

Stáhněte [chart-annotations.pptx](chart-annotations.pptx) a umístěte jej do pracovního adresáře aplikace. Jeho první snímek obsahuje graf s neseskupenou anotací „Preliminary results“, čárou vlastněnou grafem a běžnou textovou oblastí snímku s textem „Slide overlay“. Příklad najde první graf na tomto snímku a změní anotaci na „Final results“, když je zpráva připravena k publikaci. Kontroluje, zda je kolekce prázdná, a upravuje pouze [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) s [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/), který není `None` a obsahuje očekávaný text.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

Čára a textová oblast snímku zůstávají nezměněny. Následující obrázky ukazují vstup a uložený, znovu otevřený výsledek:

| Před úpravou | Po úpravě |
| --- | --- |
| ![Anotace grafu s textem Předběžné výsledky](chart-annotations-before.png) | ![Anotace grafu s textem Konečné výsledky](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Příklad kontroluje pouze tvary na nejvyšší úrovni vlastněné grafem. Pokud je anotace uvnitř [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), prozkoumejte také kolekci [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) této skupiny. Opakujte to rekurzivně pro vnořené skupiny a použijte stejné kontroly textu na jejich podřízené tvary. Skupina sama je kontejner; nepovažujte ji za textové pole.
{{% /alert %}}

## **Často kladené otázky**

**Mohu nastavit poloprůhledné výplně pro sloupce/oblasti při zachování neprůhledného okraje?**

Ano. Průhlednost výplně a obrys jsou konfigurovány odděleně. To je užitečné pro zlepšení čitelnosti mřížky a dat v hustých vizualizacích.

**Jak mohu řešit překrývající se popisky dat?**

Zmenšete velikost písma, vypněte nepodstatné součásti popisků (například kategorie), upravte umístění popisku, zobrazte popisky jen pro vybrané body, pokud je to nutné, nebo přepněte formát na „hodnota + legenda“.

**Mohu aplikovat gradientní nebo vzorové výplně na řady?**

Ano. Řady podporují plné, gradientní i vzorové výplně. V praxi používejte gradienty střídmě a vyhněte se kombinacím, které snižují kontrast s mřížkou a textem.