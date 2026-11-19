---
title: Přizpůsobení 3D grafů v prezentacích pomocí Pythonu
linktitle: 3D graf
type: docs
url: /cs/python-net/3d-chart/
keywords:
- 3D graf
- otočení
- hloubka
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vytvořte 3D grafy v prezentacích PowerPoint pomocí Aspose.Slides pro Python prostřednictvím .NET. Upravit otočení, výškové proporce, hloubku grafu a mezery mezi řadami pomocí příkladů v Pythonu."
---
## **Přehled**

Aspose.Slides for Python via .NET umožňuje přizpůsobit zobrazení 3D grafu pomocí vlastnosti [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/). Tento článek ukazuje, jak upravit otočení, výškové proporce, hloubku, pravouhlé osy a mezery mezi řadami a poté prezentaci uložit ve formátu PPTX.

## **Nastavení otočení a hloubky 3D grafu**

Níže uvedený příklad vytvoří [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) a pomocí [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) přidá na první snímek vrstvený 3D sloupcový graf. Nahradí výchozí řady a kategorie dvěma řadami, z nichž každá obsahuje tři hodnoty. Index listu `0` označuje první datový list grafu; řádek `0` obsahuje názvy řad a sloupec `0` obsahuje popisky kategorií.

Vlastnosti [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) a [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) nastaví otočení grafu na 40 a 270 stupňů. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) určuje jeho hloubku jako 150 % šířky, zatímco [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) zapíná pravouhlé osy místo perspektivy. Výsledná prezentace obsahuje naplněný graf s těmito nastaveními 3D pohledu.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Úprava výškových proporcí 3D grafu**

Použijte [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) pro nastavení výšky 3D grafu jako procenta jeho šířky. Tím se změní proporce 3D scény, aniž by se měnil rozměr grafu na snímku.

Následující příklad vytvoří graf typu [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) s výchozími daty: tři řady a čtyři kategorie. Uloží tři prezentace s výškovými proporcemi 50 %, 100 % a 200 %. Pozice, šířka a výška grafu zůstává pevná. Data, otočení, hloubka, mezery řad a formátování jsou v všech třech souborech identické; mění se jen výškové procento.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

Následující obrázky byly exportovány z vygenerovaných prezentací pomocí Microsoft PowerPoint. Nižší procento vytváří plošší scénu, vyšší procento vyšší scénu ve stejném grafickém objektu. PowerPoint může také upravit intervaly os a umístění popisků, aby scéna lépe zapadala.

| Výška: 50% | Výška: 100% | Výška: 200% |
| --- | --- | --- |
| ![3D sloupcový graf s výškou nastavenou na 50 procent šířky](height_percent_50.png) | ![3D sloupcový graf s výškou nastavenou na 100 procent šířky](height_percent_100.png) | ![3D sloupcový graf s výškou nastavenou na 200 procent šířky](height_percent_200.png) |

Tyto vlastnosti řídí různé aspekty grafu:

| Vlastnost | Efekt |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Výška 3D scény jako procento šířky. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Výška objektu grafu na snímku v bodech. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Hloubka 3D scény jako procento šířky. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Mezera mezi řadami podél osy hloubky jako procento šířky značky. |

Nastavení výšky ovlivňuje 3D sloupcové a pruhové grafy, včetně variant válcových, kuželových a pyramídových, stejně jako 3D čárové, plošné, koláčové a povrchové grafy. Výše uvedené srovnání používá ověřený typ `COLUMN_3D`. Nastavení nemění vzhled 2D grafu `CLUSTERED_COLUMN` ani grafu `BUBBLE_WITH_3D`; tyto názvy jsou členy výčtu [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Další nastavení vzhledu grafu najdete v sekci [Chart Formatting](/slides/cs/python-net/chart-formatting/).

## **Úprava mezery mezi řadami**

Použijte [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) pro řízení vzdálenosti mezi datovými řadami podél osy hloubky 3D grafu, vyjádřeno jako procento šířky značky. Používejte hodnoty od **0 do 500**, včetně: `0` odstraní mezeru, vyšší hodnoty mezeru zvětší. Při pevné hloubce grafu zvyšuje se tím řídka značka podél osy hloubky.

Přístup ke skupině získáte přes [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). Nastavení se vztahuje na všechny řady v této skupině, nikoli jen na řadu použitou pro přístup. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) je jen pro čtení a odráží nastavení nadřazené skupiny.

Toto nastavení ovlivňuje 3D sloupcové a pruhové grafy, včetně jejich válcových, kuželových a pyramídových variant, stejně jako 3D čárové a plošné grafy. Vzhled závisí na tom, zda jsou řady uspořádány v hloubce, seskupeny nebo vrstveny. Pro přehledné srovnání mezer mezi samostatnými řadami použijte `ChartType.COLUMN_3D` z výčtu [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

Tyto vlastnosti řídí různé aspekty grafu:

| Vlastnost | Efekt |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Mezera mezi řadami podél osy hloubky jako procento šířky značky. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Mezera mezi sousedními skupinami sloupců nebo pruhů jako procento jejich šířky. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Celková hloubka grafu jako procento šířky. |

Následující samostatný příklad používá výchozí data grafu, která obsahují tři řady a čtyři kategorie. Uloží dvě prezentace se stejnými daty, otočením, šířkou mezery a hloubkou grafu; mění se jen mezera v hloubce.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Následující obrázky byly exportovány z vygenerovaných prezentací pomocí Microsoft PowerPoint.

| Mezery v hloubce: 0% | Mezery v hloubce: 500% |
| --- | --- |
| ![3D sloupcový graf bez mezery mezi řadami podél osy hloubky](gap_depth_0.png) | ![3D sloupcový graf s mezerou 500 % mezi řadami podél osy hloubky](gap_depth_500.png) |

## **Změna typu 3D řady a tvaru pruhu**

U seskupeného válcového grafu první řada začíná válcovými pruhy. Příklad čte [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) a [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) před a po každé změně.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| Změna první řady | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Vytvoření grafu | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Nastavení `type` na `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Nastavení `bar_3d_shape` na `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Nastavení tvaru na `BOX` také změní typ řady na `CLUSTERED_COLUMN_3D`. Pokud váš kód rozvětvuje podle typu řady, čtěte `series.type` po změně tvaru. Hodnota načtená před přiřazením by stále vybrala větev `CLUSTERED_CONE`.

![Porovnání v PowerPoint ukazující první řadu jako válce, kužele a obdélníkové sloupce zleva doprava](series-shapes.png)

## **Často kladené otázky**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s souvisejícími 3D typy dostupnými skrze výčet [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) v referenční dokumentaci API vaší nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Graf můžete exportovat do obrázku pomocí [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) nebo [renderovat celý snímek](/slides/cs/python-net/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete rastrový náhled nebo chcete vložit graf do dokumentů, dashboardů či webových stránek bez nutnosti PowerPointu.

**Jaký je výkon při vytváření a vykreslování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky držte 3D efekty na minimu, vyhněte se těžkým texturám na stěnách a výsečích, omezte počet datových bodů na řadu, pokud je to možné, a vykreslujte do odpovídající velikosti výstupu (rozlišení a rozměry), aby odpovídal cílovému zobrazení nebo tisku.