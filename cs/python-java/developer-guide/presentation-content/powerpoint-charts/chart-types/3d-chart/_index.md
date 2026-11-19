---
title: Přizpůsobení 3D grafů v prezentacích pomocí Pythonu
linktitle: 3D graf
type: docs
url: /cs/python-java/3d-chart/
keywords:
- 3D graf
- rotace
- hloubka
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvářejte 3D grafy v prezentacích PowerPoint pomocí Aspose.Slides pro Python přes Java. Upravit rotaci, výškové proporce, hloubku grafu a rozestupy mezi sériemi s příklady v Pythonu."
---
## **Přehled**

Aspose.Slides for Python via Java umožňuje přizpůsobit zobrazení 3D grafu pomocí metody [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). Tento článek ukazuje, jak upravit rotaci, výškové proporce, hloubku, pravouhlé osy a rozestupy mezi sériemi a poté uložit prezentaci ve formátu PPTX.

## **Nastavení rotace a hloubky 3D grafu**

Příklad níže vytvoří [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) a použije [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) k přidání sloupcového 3D grafu se sloučením na první snímek. Nahradí výchozí řady a kategorie dvěma řadami obsahujícími tři hodnoty každá. Index listu `0` určuje první datový list grafu; řádek `0` obsahuje názvy řad a sloupec `0` obsahuje popisky kategorií.

Metody [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) a [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) nastaví rotaci grafu na 40 ° a 270 ° соответственно. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) nastaví jeho hloubku na 150 % jeho šířky, zatímco [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) povolí pravouhlé osy místo perspektivy. Výsledná prezentace obsahuje vyplněný graf s těmito nastaveními 3D zobrazení.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Úprava výškových proporcí 3D grafu**

Použijte [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) k nastavení výšky 3D grafu jako procenta jeho šířky. Tím se změní proporce 3D scény, aniž by se změnila velikost objektu grafu na snímku.

Následující příklad vytvoří graf typu [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) s výchozími daty: tři řady a čtyři kategorie. Uloží tři prezentace s výškovými proporcemi 50 %, 100 % a 200 %. Pozice grafu, šířka a výška zůstávají pevné. Data, rotace, hloubka, rozestup řad a formátování jsou ve všech třech souborech identické; mění se pouze procento výšky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Následující obrázky ilustrují stejné nastavení výšky v ekvivalentním .NET příkladu a byly exportovány pomocí Microsoft PowerPoint. Menší procento vytváří plošší scénu, zatímco větší procento vytváří vyšší scénu ve stejném objektu grafu. PowerPoint může také upravit intervaly značek os a umístění popisků, aby scénu přizpůsobil.

| Výška: 50% | Výška: 100% | Výška: 200% |
| --- | --- | --- |
| ![3D sloupcový graf s výškou nastavenou na 50 % jeho šířky](height_percent_50.png) | ![3D sloupcový graf s výškou nastavenou na 100 % jeho šířky](height_percent_100.png) | ![3D sloupcový graf s výškou nastavenou na 200 % jeho šířky](height_percent_200.png) |

Tyto metody řídí různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Výška 3D scény jako procento její šířky. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Výška objektu grafu na snímku v bodech. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Hloubka 3D scény jako procento její šířky. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Rozestup mezi řadami podél osy hloubky jako procento šířky markeru. |

Nastavení výšky ovlivňuje 3D sloupcové a pruhové grafy, včetně variant válcových, kuželových a pyramidových, stejně jako 3D čárové, plošné, koláčové a povrchové grafy. Porovnání výše používá ověřený typ `Column3D`. Nastavení nemění vzhled 2D grafu `ClusteredColumn` ani grafu `BubbleWith3D`; tyto názvy jsou členy třídy [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Pro další nastavení vzhledu grafu viz [Formátování grafu](/slides/cs/python-java/chart-formatting/).

## **Úprava mezery mezi sériemi**

Použijte [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) k řízení vzdálenosti mezi datovými řadami podél osy hloubky 3D grafu, vyjádřené jako procento šířky markeru. Používejte hodnoty od **0 to 500**, včetně: `0` odstraní mezeru, zatímco vyšší hodnoty zvětší rozestup. Při pevné hloubce grafu zvětšení mezery ztenčuje markery podél osy hloubky.

Přístup ke skupině získáte pomocí [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). Nastavení se vztahuje na každou řadu v této skupině, nejen na řadu použité k přístupu. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) vrací mezera v hloubce a odráží nastavení nadřazené skupiny.

Toto nastavení ovlivňuje 3D sloupcové a pruhové grafy, včetně jejich válcových, kuželových a pyramidových variant, stejně jako 3D čárové a plošné grafy. Vzhled závisí na tom, zda jsou řady uspořádány v hloubce, seskupeny nebo naskládané. Pro jasné srovnání mezer mezi samostatnými řadami použijte `ChartType.Column3D` z třídy [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Tyto metody řídí různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Rozestup mezi řadami podél osy hloubky jako procento šířky markeru. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Rozestup mezi sousedními skupinami pruhů nebo sloupců jako procento šířky pruhu nebo sloupce. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Celková hloubka grafu jako procento šířky grafu. |

Následující samostatný příklad používá výchozí data grafu, která obsahují tři řady a čtyři kategorie. Uloží dvě prezentace se stejnými daty, rotací, šířkou mezery a hloubkou grafu; mění se jen hloubka mezery.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Následující obrázky ilustrují stejné nastavení hloubky mezery v ekvivalentním .NET příkladu a byly exportovány pomocí Microsoft PowerPoint.

| Hloubka mezery: 0% | Hloubka mezery: 500% |
| --- | --- |
| ![3D sloupcový graf bez mezery mezi řadami podél osy hloubky](gap_depth_0.png) | ![3D sloupcový graf s 500 % mezerou mezi řadami podél osy hloubky](gap_depth_500.png) |

## **Změna typu 3D série a tvaru sloupce**

V seskupeném válcovém grafu první řada začíná s tvarem válcového sloupce. Příklad vypisuje celočíselné hodnoty vrácené metodami [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) a [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) před a po každé změně. Tabulka uvádí odpovídající názvy konstant.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Změna první řady | Typ řady | Tvar sloupce |
| --- | --- | --- |
| Vytvořit graf | `ClusteredCylinder` | `Cylinder` |
| Nastavit typ řady na `ClusteredCone` | `ClusteredCone` | `Cone` |
| Nastavit tvar sloupce na `Box` | `ClusteredColumn3D` | `Box` |

Nastavení tvaru na `Box` také mění typ řady na `ClusteredColumn3D`. Pokud váš kód rozvětvuje podle typu řady, zavolejte `series.getType()` po změně tvaru. Hodnota uložená před přiřazením by stále vybrala větev `ClusteredCone`.

![Porovnání v PowerPointu ukazující první řadu jako válcové, kuželové a obdélníkové sloupce zleva doprava](series-shapes.png)

## **FAQ**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s dalšími 3D typy zpřístupněnými třídou [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) v referenci API vaší nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Graf můžete exportovat jako obrázek pomocí [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) nebo [renderovat celý snímek](/slides/cs/python-java/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete rastrový náhled nebo chcete vložit graf do dokumentů, dashboardů či webových stránek bez nutnosti PowerPointu.

**Jak výkonná je tvorba a renderování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro dosažení nejlepších výsledků udržujte 3D efekty na minimu, vyhýbejte se těžkým texturám na stěnách a vykreslovacích plochách, omezte počet datových bodů na řadu, pokud je to možné, a renderujte do vhodně dimenzovaného výstupu (rozlišení a rozměry), který odpovídá cílovému zobrazení nebo tisku.