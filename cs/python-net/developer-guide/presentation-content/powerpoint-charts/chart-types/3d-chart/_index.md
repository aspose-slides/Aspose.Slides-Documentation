---
title: Přizpůsobení 3D grafů v prezentacích v Pythonu
linktitle: 3D Graf
type: docs
url: /cs/python-net/3d-chart/
keywords:
- 3D graf
- otáčení
- hloubka
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vytvořte 3D grafy v prezentacích PowerPoint pomocí Aspose.Slides pro Python přes .NET. Nastavte otáčení, výškové poměry, hloubku grafu a mezery mezi sériemi pomocí příkladů v Pythonu."
---
## **Přehled**

Aspose.Slides pro Python prostřednictvím .NET vám umožňuje přizpůsobit zobrazení 3D grafu pomocí vlastnosti [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) . Tento článek ukazuje, jak nastavit otáčení, výškové poměry, hloubku, pravouhlé osy a mezery mezi sériemi a poté uložit prezentaci ve formátu PPTX.

## **Nastavení otáčení a hloubky 3D grafu**

Níže uvedený příklad vytvoří [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) a použije [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) k přidání vrstveného 3D sloupcového grafu na první snímek. Nahradí výchozí série a kategorie dvěma sériemi, z nichž každá obsahuje tři hodnoty. Index listu `0` určuje první datový list grafu; řádek `0` obsahuje názvy sérií a sloupec `0` obsahuje popisky kategorií.

Vlastnosti [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) a [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) nastaví otáčení grafu na 40 a 270 stupňů. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) určuje jeho hloubku na 150 % šířky, zatímco [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) povolí pravouhlé osy místo perspektivy. Výsledná prezentace obsahuje vyplněný graf s těmito nastaveními 3D zobrazení.

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

## **Použití obrázkového výplně na povrch 3D grafu**

Můžete nezávisle vyplnit [side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), [back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) a [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) 3D grafu. Nastavte [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) povrchu na `PICTURE` a přiřaďte obrázek. Aby se na povrch vešla jedna kopie obrázku, nastavte jak [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/), tak [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) povrchu na `STRETCH`.

Uložte [arrow.png](arrow.png) do pracovního adresáře. Příklad otáčí graf a zvyšuje maximální hodnotu na svislé ose, aby byl podlaha viditelná mezi sloupci. Duplikuje snímek dvakrát a poté na každém snímku aplikuje šipku na jiný povrch. Všechny tři grafy sdílejí stejná data, úhel pohledu i pozadí.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint zobrazuje tři snímky následujícím způsobem.

| Boční stěna | Zadní stěna | Podlaha |
| --- | --- | --- |
| ![Šipka směřující do grafu podél boční stěny](side-wall.png) | ![Šipka směřující doprava přes zadní stěnu](back-wall.png) | ![Šipka směřující doprava přes podlahu mezi sloupci](floor.png) |

## **Úprava výškových poměrů 3D grafu**

Použijte [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) k nastavení výšky 3D grafu jako procenta jeho šířky. Tím se změní poměry 3D scény, aniž by se změnily rozměry objektu grafu na snímku.

Následující příklad vytvoří graf [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) s výchozími daty: tři série a čtyři kategorie. Uloží tři prezentace s výškovými poměry 50 %, 100 % a 200 %. Pozice, šířka a výška grafu zůstávají pevné. Data, otáčení, hloubka, mezery mezi sériemi a formátování jsou ve všech třech souborech identické; mění se pouze procento výšky.

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

Následující obrázky byly exportovány z vygenerovaných prezentací pomocí Microsoft PowerPoint. Menší procento vytváří plošší scénu, zatímco větší procento vytváří vyšší scénu ve stejném objektu grafu. PowerPoint může také upravit intervaly značek os a umístění popisků, aby scéna zapasovala.

| Výška: 50 % | Výška: 100 % | Výška: 200 % |
| --- | --- | --- |
| ![3D sloupcový graf s výškou nastavena na 50 % šířky](height_percent_50.png) | ![3D sloupcový graf s výškou nastavena na 100 % šířky](height_percent_100.png) | ![3D sloupcový graf s výškou nastavena na 200 % šířky](height_percent_200.png) |

Tyto vlastnosti řídí různé aspekty grafu:

| Vlastnost | Efekt |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Výška 3D scény jako procento její šířky. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Výška objektu grafu na snímku v bodech. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Hloubka 3D scény jako procento šířky. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Mezera mezi sériemi podél osy hloubky, jako procento šířky značky. |

Nastavení výšky ovlivňuje 3D sloupcové a pruhové grafy, včetně varianty válec, kužel a pyramida, stejně jako 3D čárové, plošné, koláčové a povrchové grafy. Výše uvedené srovnání používá ověřený typ `COLUMN_3D`. Nastavení nemění vzhled 2D grafu `CLUSTERED_COLUMN` ani grafu `BUBBLE_WITH_3D`; tyto názvy jsou členy výčtu [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Další nastavení vzhledu grafu najdete v [Chart Formatting](/slides/cs/python-net/chart-formatting/).

## **Úprava mezery mezi sériemi**

Použijte [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) k řízení vzdálenosti mezi datovými sériemi podél osy hloubky 3D grafu, vyjádřené v procentech šířky značky. Používejte hodnoty od **0 do 500**, včetně: `0` odstraní mezeru, vyšší hodnoty mezery zvětší. Při pevné hloubce grafu zvětšení mezery způsobí, že značky podél osy hloubky budou tenčí.

Přístup ke skupině získáte pomocí [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). Nastavení se použije na všechny série v této skupině, ne jen na sérii, která k přístupu použita byla. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) je jen pro čtení a odráží nastavení nadřazené skupiny.

Toto nastavení ovlivňuje 3D sloupcové a pruhové grafy, včetně jejich variant válec, kužel a pyramida, stejně jako 3D čárové a plošné grafy. Vzhled závisí na tom, zda jsou série uspořádány v hloubce, seskupeny nebo vrstveny. Pro jasné porovnání mezer mezi jednotlivými sériemi použijte `ChartType.COLUMN_3D` z výčtu [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

Tyto vlastnosti řídí různé aspekty grafu:

| Vlastnost | Efekt |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Mezera mezi sériemi podél osy hloubky, jako procento šířky značky. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Mezera mezi sousedními shluky pruhů nebo sloupců, jako procento šířky pruhu nebo sloupce. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Celková hloubka grafu jako procento šířky grafu. |

Následující samostatný příklad používá výchozí data grafu, která obsahují tři série a čtyři kategorie. Uloží dvě prezentace s identickými daty, otáčením, šířkou mezery a hloubkou grafu; mění se jen hloubka mezery.

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

| Hloubka mezery: 0 % | Hloubka mezery: 500 % |
| --- | --- |
| ![3D sloupcový graf bez mezery mezi sériemi podél osy hloubky](gap_depth_0.png) | ![3D sloupcový graf s 500 % mezerou mezi sériemi podél osy hloubky](gap_depth_500.png) |

## **Změna typu 3D série a tvaru sloupce**

Ve sloupcovém grafu seskupeném do válců první série začíná válcovými sloupci. Příklad čte [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) a [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) před a po každé změně.

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

| Změna první série | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Vytvořit graf | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Nastavit `type` na `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Nastavit `bar_3d_shape` na `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Nastavení tvaru na `BOX` také mění typ série na `CLUSTERED_COLUMN_3D`. Pokud váš kód rozvětvuje podle typu série, přečtěte `series.type` po změně tvaru. Hodnota uložená v mezipaměti před přiřazením by stále vedla k větvi `CLUSTERED_CONE`.

![Porovnání v PowerPointu ukazující první sérii jako válce, kužely a obdélníkové sloupce zleva doprava](series-shapes.png)

## **FAQ**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s souvisejícími 3D typy dostupnými prostřednictvím výčtu [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Pro přesný, aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) v API referenci vaší nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Můžete exportovat graf jako obrázek pomocí [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) nebo [render the entire slide](/slides/cs/python-net/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete rastrový náhled nebo chcete vložit graf do dokumentů, dashboardů nebo webových stránek bez nutnosti PowerPointu.

**Jak výkonná je tvorba a vykreslování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky udržujte 3D efekty na minimu, vyhněte se těžkým texturám na stěnách a ploše grafu, omezte počet datových bodů na sérii, pokud je to možné, a renderujte do adekvátně velkého výstupu (rozlišení a rozměry), který odpovídá cílovému zobrazení nebo tisku.