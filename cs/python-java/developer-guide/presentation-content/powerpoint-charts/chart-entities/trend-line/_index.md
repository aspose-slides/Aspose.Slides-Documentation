---
title: Přidání čar trendu do grafů v prezentaci v Pythonu
linktitle: Čára trendu
type: docs
url: /cs/python-java/trend-line/
keywords:
- graf
- čára trendu
- exponenciální čára trendu
- lineární čára trendu
- logaritmická čára trendu
- čára trendu klouzavý průměr
- polynomická čára trendu
- čára trendu mocninná
- vlastní čára trendu
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Rychle přidejte a přizpůsobte čáry trendu v grafech PowerPointu pomocí Aspose.Slides pro Python přes Java — praktický průvodce, jak zaujmout své publikum."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přidat do grafů v prezentaci čáry trendu. Ukazuje, jak vytvořit graf, přidat čáry trendu k sériím grafu a pracovat s několika typy čar trendu, včetně exponenciální, lineární, logaritmické, klouzavý průměr, polynomické a mocninné.  
Také popisuje, jak do grafu přidat vlastní čáru vložením tvaru čáry, a obsahuje krátké FAQ o hodnotách projekce čáry trendu dopředu a dozadu a o tom, zda jsou čáry trendu zachovány při exportu do PDF nebo SVG a při vykreslování grafů jako obrázků.

## **Přidání čáry trendu**

Použijte [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) k přidání čáry trendu do série grafu a vyberte její typ pomocí [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/). Příklad vytvoří seskupený sloupcový graf s výchozími daty a přidá dvě čáry trendu ke každé ze svých tří sérií.  
Exponenciální čára trendu skryje svou rovnici a hodnotu R‑kvadrátu pomocí [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) a [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue), zatímco lineární čára trendu je červená. Logaritmická čára trendu používá [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) pro vlastní popisek. Klouzavý průměr používá [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) se třemi datovými body a vlastní [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName).  
Polynomická čára trendu má řád tři, nastavený pomocí [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) a prodlužuje o jednu kategorii dopředu pomocí [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward). Mocninná čára trendu prodlužuje o jednu kategorii dozadu pomocí [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení průsečíku čáry trendu**

Použijte [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) k fixaci hodnoty Y čáry trendu při X = 0. Toto nastavení je podporováno pro lineární, exponenciální a polynomické čáry trendu.  
Například model nákladů na výrobu může vyžadovat, aby začínal od známých fixních nákladů 100, i když měření při nenulových objemech výroby naznačují odlišnou základní úroveň. Pro lineární čáru trendu fixování průsečíku omezuje rovnici `y = ax + b` na `b = 100`; sklon je přizpůsoben datům pod tímto omezením. Nejde jen o posunutí již nasazené čáry. Nastavení průsečíku os určuje, kde se protínají osy grafu, nikoli koeficienty nasazené čáry trendu.  
Následující příklad vytvoří bodový (XY) graf s objemy výroby od 1 do 4 a náklady 170, 200, 230 a 260. Uloží graf s výchozím automatickým průsečíkem, nastaví průsečík na 100 a uloží druhý soubor PPTX. Oba soubory se liší jen nastavením průsečíku. Čára trendu zobrazuje svou rovnici a prodlužuje se zpět k X = 0.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Při automatickém výpočtu tato data dávají `y = 30x + 140`. Nastavení průsečíku na 100 místo toho přibližně dává `y = 43.33x + 100`: vypočtená hodnota při nule odpovídá známé základní úrovni, zatímco čára již neprochází všemi datovými body.

| Automatický průsečík | Fixní průsečík 100 |
| --- | --- |
| ![Lineární čára trendu s automaticky vypočteným průsečíkem 140](intercept-automatic.png) | ![Lineární čára trendu s fixním průsečíkem 100](intercept-fixed.png) |

Oba obrázky používají stejná data a měřítka os. Čáry trendu jsou prodlouženy zpět k X = 0, aby ukázaly své průsečíky.  
Ve výchozím nastavení [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) vrací `NaN`, což představuje nedefinovaný průsečík místo nuly. Průsečík je pak automaticky vypočítán z dat.

## **Přidání vlastní čáry**

Vlastní čára je tvar nakreslený nad grafem, nikoli čára trendu vypočtená z dat sérií. Tento příklad používá [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) k přidání horizontální čáry na snímek nad grafem. Pozice čáry je zadána ve souřadnicích snímku, měřených v bodech, takže začíná na levém okraji grafu a leží v polovině výšky grafu. Její šířka odpovídá šířce grafu. Metoda [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) poskytuje přístup k formátování čáry použitému k aplikaci pevné červené barvy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Co znamenají 'forward' a 'backward' u čáry trendu?**

Jedná se o délky čáry trendu projektované dopředu/dozadu: pro bodové (XY) grafy — v jednotkách osy; pro jiné grafy — v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Zůstane čára trendu zachována při exportu prezentace do PDF nebo SVG, nebo při vykreslování snímku jako obrázku?**

Ano. Aspose.Slides převádí prezentace na [PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/) nebo [SVG](/slides/cs/python-java/render-a-slide-as-an-svg-image/) a vykresluje grafy jako obrázky; čáry trendu, jako součást grafu, jsou při těchto operacích zachovány. K dispozici je také metoda pro [export obrázku grafu](/slides/cs/python-java/create-shape-thumbnails/).