---
title: Přidat trendové čáry do prezentačních grafů v Pythonu
linktitle: Trendová čára
type: docs
url: /cs/python-java/trend-line/
keywords:
- graf
- trendová čára
- exponenciální trendová čára
- lineární trendová čára
- logaritmická trendová čára
- trendová čára klouzavého průměru
- polynomická trendová čára
- mocninná trendová čára
- vlastní trendová čára
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Rychle přidejte a přizpůsobte trendové čáry v grafech PowerPointu pomocí Aspose.Slides pro Python přes Java — praktický průvodce, jak zaujmout své publikum."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přidat do prezentačních grafů trendové čáry. Ukazuje, jak vytvořit graf, přidat trendové čáry k řadám grafu a pracovat s několika typy trendových čar, včetně exponenciální, lineární, logaritmické, klouzavého průměru, polynomické a mocninné.

Také popisuje, jak do grafu přidat vlastní čáru vložením tvaru čáry, a obsahuje krátké FAQ o hodnotách projekce trendové čáry dopředu a dozadu a o tom, zda jsou trendové čáry zachovány při exportu do PDF nebo SVG a při renderování grafů jako obrázky.

## **Přidat trendovou čáru**

Aspose.Slides for Python via Java poskytuje jednoduché API pro správu různých trendových čar grafu:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty a požadovaným typem (v tomto příkladu je použit [ChartType.ClusteredColumn](https://reference.aspose.com/slides/cs/python-java/aspose.slides/charttype/#ClusteredColumn)).
1. Přidejte exponenciální trendovou čáru k řadě grafu 1.
1. Přidejte lineární trendovou čáru k řadě grafu 1.
1. Přidejte logaritmickou trendovou čáru k řadě grafu 2.
1. Přidejte trendovou čáru klouzavého průměru k řadě grafu 2.
1. Přidejte polynomickou trendovou čáru k řadě grafu 3.
1. Přidejte mocninnou trendovou čáru k řadě grafu 3.
1. Zapište upravenou prezentaci do souboru PPTX.

Následující kód vytvoří graf s trendovými čárami.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    # Vytvořte seskupený sloupcový graf.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # Přidejte exponenciální trendovou čáru do řady grafu 1.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # Přidejte lineární trendovou čáru do řady grafu 1.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Přidejte logaritmickou trendovou čáru do řady grafu 2.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # Přidejte trendovou čáru klouzavého průměru do řady grafu 2.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # Přidejte polynomickou trendovou čáru do řady grafu 3.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # Přidejte mocninnou trendovou čáru do řady grafu 3.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # Uložte prezentaci.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přidat vlastní čáru**

Aspose.Slides for Python via Java poskytuje jednoduché API pro přidání vlastních čar do grafu. Pro přidání prosté čáry do grafu na vybraném snímku postupujte takto:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
- Získejte odkaz na snímek podle jeho indexu.
- Vytvořte nový graf pomocí metody [addChart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addChart) třídy [ShapeCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/).
- Přidejte tvar čáry pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addAutoShape) s parametrem [ShapeType.Line](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#Line).
- Nastavte barvu čáry tvaru.
- Zapište upravenou prezentaci do souboru PPTX.

Následující kód vytvoří graf s vlastní čárou.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Co znamenají pojmy „dopředu“ a „dozadu“ u trendové čáry?**

Jedná se o délky trendové čáry promítnuté dopředu nebo dozadu: u rozptylových (XY) grafů jsou měřeny v jednotkách osy; u jiných grafů jsou měřeny v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Zachová se trendová čára při exportu prezentace do PDF nebo SVG, nebo při renderování snímku jako obrázku?**

Ano. Aspose.Slides převádí prezentace na [PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/cs/python-java/render-a-slide-as-an-svg-image/) a renderuje grafy do obrázků; trendové čáry jako součást grafu jsou při těchto operacích zachovány. K dispozici je také metoda pro [export obrázku grafu](/slides/cs/python-java/create-shape-thumbnails/).