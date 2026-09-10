---
title: Přizpůsobení bublinových grafů v prezentacích pomocí Pythonu
linktitle: Bublinový graf
type: docs
url: /cs/python-java/bubble-chart/
keywords:
- bublinový graf
- velikost bubliny
- škálování velikosti
- reprezentace velikosti
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte výkonné bublinové grafy v PowerPointu pomocí Aspose.Slides pro Python přes Java a snadno vylepšete vizualizaci dat."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s bublinovými grafy v Aspose.Slides. Popisuje dvě konkrétní možnosti přizpůsobení: škálování velikosti bublin pomocí metody [setBubbleSizeScale](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) a řízení toho, jak jsou hodnoty velikosti bublin reprezentovány pomocí metody [setBubbleSizeRepresentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation).

Příklady ukazují, jak vytvořit bublinový graf, upravit jeho škálování velikosti a přepnout reprezentaci velikosti bublin na šířku. Článek také obsahuje krátkou sekci FAQ, která objasňuje podporu typu grafu „Bubble with 3-D“, uvádí, že praktická omezení grafu závisí na výkonu a cílové verzi PowerPointu, a vysvětluje, že export zachovává vzhled grafu pomocí renderovacího enginu Aspose.Slides.

## **Škálování velikosti bublinového grafu**
Aspose.Slides for Python via Java podporuje škálování velikosti bublinových grafů prostřednictvím metod [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) a [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale). Následující příklad ukazuje, jak škálovat velikosti bublin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zobrazit data jako velikosti bublin v grafu**
Metody [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) a [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) jsou k dispozici ve třídě [ChartSeriesGroup](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/). Reprezentace velikosti bublin určuje, jak jsou hodnoty velikosti bublin v grafu zobrazeny. Možné hodnoty jsou [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bubblesizerepresentationtype/#Area) a [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bubblesizerepresentationtype/#Width). Výčtová hodnota [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bubblesizerepresentationtype/) specifikuje možné způsoby, jak reprezentovat data jako velikosti bublin v grafu. Následující příklad ukazuje, jak reprezentovat velikosti bublin pomocí šířky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Je podporován „bubble chart with 3‑D effect“ a jak se liší od běžného grafu?**

Ano. Existuje samostatný typ grafu „Bubble with 3‑D“. Používá 3‑D stylizaci na bubliny, ale nepřidává další osu; data zůstávají X‑Y‑S (velikost). Tento typ je k dispozici ve třídě [chart type](https://reference.aspose.com/slides/cs/python-java/aspose.slides/charttype/).

**Existuje limit na počet sérií a bodů v bublinovém grafu?**

Na úrovni API neexistuje pevný limit; omezení jsou určena výkonem a cílovou verzí PowerPointu. Doporučuje se udržet počet bodů na rozumné úrovni pro čitelnost a rychlost vykreslování.

**Jak export ovlivní vzhled bublinového grafu (PDF, obrázky)?**

Export do podporovaných formátů zachovává vzhled grafu; vykreslování provádí engine Aspose.Slides. Pro rastrové/vektorové formáty platí obecná pravidla vykreslování grafiky (rozlišení, anti‑aliasing), takže zvolte dostatečné DPI pro tisk.