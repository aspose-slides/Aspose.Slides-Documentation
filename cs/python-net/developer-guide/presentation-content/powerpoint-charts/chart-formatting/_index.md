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
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se formátování grafů v Aspose.Slides pro Python pomocí .NET a vylepšete svou prezentaci v PowerPointu nebo OpenDocument profesionálním a poutavým vzhledem."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides formátovat grafy v prezentacích PowerPoint. Ukazuje, jak přizpůsobit klíčové prvky grafu, jako jsou osy, mřížkové čáry, nadpisy, legendy, oblast vykreslení a výplně stěn, aby se zlepšila vzhled a čitelnost dat v grafu.

Dále demonstruje, jak nastavit vlastnosti písma pro text v grafu, použít předdefinované i vlastní číselné formáty pro data grafu a povolit zaoblené rohy pro oblast grafu. Tyto příklady ukazují, jak řídit jak vizuální styl, tak prezentaci dat v grafu v prezentaci.

## **Formátování prvků grafu**

Aspose.Slides pro Python umožňuje vývojářům přidávat vlastní grafy do snímků od začátku. Tato sekce popisuje, jak formátovat různé prvky grafu, včetně kategorií a hodnotových os.

Aspose.Slides poskytuje jednoduché API pro správu prvků grafu a aplikaci vlastního formátování:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty požadovaného typu (v tomto příkladu `ChartType.LINE_WITH_MARKERS`).
1. Přistupte k hodnotové ose grafu a nastavte následující:
   1. Nastavte **formát čáry** pro hlavní mřížkové čáry hodnotové osy.
   1. Nastavte **formát čáry** pro vedlejší mřížkové čáry hodnotové osy.
   1. Nastavte **formát čísla** pro hodnotovou osu.
   1. Nastavte **min, max, hlavní a vedlejší jednotky** pro hodnotovou osu.
   1. Nastavte **vlastnosti textu** pro popisky hodnotové osy.
   1. Nastavte **název** pro hodnotovou osu.
   1. Nastavte **formát čáry** pro hodnotovou osu.
1. Přistupte k osy kategorií grafu a nastavte následující:
   1. Nastavte **formát čáry** pro hlavní mřížkové čáry osy kategorií.
   1. Nastavte **formát čáry** pro vedlejší mřížkové čáry osy kategorií.
   1. Nastavte **vlastnosti textu** pro popisky osy kategorií.
   1. Nastavte **název** pro osu kategorií.
   1. Nastavte **umístění popisků** pro osu kategorií.
   1. Nastavte **úhel otočení** pro popisky osy kategorií.
1. Přistupte k legendě grafu a nastavte její **vlastnosti textu**.
1. Zobrazte legendu grafu tak, aby nepřekrývala graf.
1. Přistupte k **sekundární hodnotové ose** grafu a nastavte následující:
   1. Povolit sekundární **hodnotovou osu**.
   1. Nastavte **formát čáry** pro sekundární hodnotovou osu.
   1. Nastavte **formát čísla** pro sekundární hodnotovou osu.
   1. Nastavte **min, max, hlavní a vedlejší jednotky** pro sekundární hodnotovou osu.
1. Vykreslete první sérii grafu na sekundární hodnotové ose.
1. Nastavte barvu výplně zadní stěny grafu.
1. Nastavte barvu výplně oblasti vykreslení grafu.
1. Zapište upravenou prezentaci do souboru PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte ukázkový graf.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Nastavte název grafu.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Nastavte formát hlavních mřížkových čar pro hodnotovou osu.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Nastavte formát vedlejších mřížkových čar pro hodnotovou osu.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Nastavte číselný formát hodnotové osy.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Nastavte maximum, minimum, hlavní a vedlejší jednotku hodnotové osy.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Nastavte textové vlastnosti hodnotové osy.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Nastavte název hodnotové osy.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Nastavte formát hlavních mřížkových čar pro osu kategorií.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Nastavte formát vedlejších mřížkových čar pro osu kategorií.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Nastavte textové vlastnosti osy kategorií.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Nastavte název osy kategorií.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Nastavte umístění popisků osy kategorií.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Nastavte úhel otáčení popisků osy kategorií.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Nastavte textové vlastnosti legendy.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Zobrazte legendu grafu překrývající graf.
    chart.legend.overlay = True
                
    # Nastavte barvu zadní stěny grafu.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Nastavte barvu oblasti vykreslení.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Uložte prezentaci.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení vlastností písma v grafu**

Aspose.Slides pro Python podporuje nastavení vlastností souvisejících s písmem pro grafy. Postupujte podle následujících kroků pro konfiguraci vlastností písma v grafu:

1. Vytvořte objekt [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Přidejte graf do snímku.
1. Nastavte výšku písma.
1. Uložte upravenou prezentaci.

Níže je uveden ukázkový kód.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení číselného formátu**

Aspose.Slides pro Python poskytuje jednoduché API pro správu formátů dat v grafu:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty libovolného požadovaného typu.
1. Nastavte předdefinovaný číselný formát z dostupných předdefinovaných hodnot.
1. Procházejte buňky dat grafu v každé sérii a nastavte číselný formát.
1. Uložte prezentaci.
1. Nastavte vlastní číselný formát.
1. Procházejte buňky dat grafu v každé sérii a nastavte jiný číselný formát.
1. Uložte prezentaci.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte výchozí seskupený sloupcový graf.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Nastavte předdefinovaný číselný formát.
    # Procházejte každou sérii grafu.
    for series in chart.chart_data.series:
        # Procházejte každou datovou položku v sérii.
        for cell in series.data_points:
            # Nastavte číselný formát.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Uložte prezentaci.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Dostupné předdefinované číselné formáty a jejich odpovídající indexy jsou uvedeny níže.

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Nastavení zaoblených hran pro oblast grafu**

Aspose.Slides pro Python podporuje konfiguraci oblasti grafu pomocí vlastnosti `Chart.has_rounded_corners`.

1. Vytvořte objekt [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Přidejte graf do snímku.
3. Nastavte typ výplně a barvu výplně grafu.
4. Nastavte vlastnost zaoblených rohů na `True`.
5. Uložte upravenou prezentaci.

Ukázka je uvedena níže.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Mohu nastavit poloprůhledné výplně pro sloupce/oblasti a přitom nechat okraj neprůhledný?**

Ano. Průhlednost výplně a obrysu jsou konfigurovány odděleně. To je užitečné pro zlepšení čitelnosti mřížky a dat v hustých vizualizacích.

**Jak mohu řešit popisky dat, když se překrývají?**

Zmenšte velikost písma, zakažte nepodstatné součásti popisků (například kategorie), nastavte odsazení/umístění popisku, zobrazte popisky jen pro vybrané body, pokud je to nutné, nebo přepněte formát na „hodnota + legenda“.

**Mohu aplikovat přechodové nebo vzorové výplně na série?**

Ano. Obvykle jsou k dispozici jak plné, tak přechodové/vzorové výplně. V praxi používejte přechody střídmě a vyhněte se kombinacím, které snižují kontrast vůči mřížce a textu.