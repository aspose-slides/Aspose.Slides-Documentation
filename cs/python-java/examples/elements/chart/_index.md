---
title: Graf
type: docs
weight: 60
url: /cs/python-java/examples/elements/chart/
keywords:
- graf
- přidat graf
- přístup k grafu
- odstranit graf
- aktualizovat graf
- ukázky kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvořte, přistupujte, odstraňujte a aktualizujte grafy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides for Python via Java."
---
Tento článek ukazuje, jak přidávat, přistupovat, odstraňovat a aktualizovat grafy v prezentaci pomocí **Aspose.Slides for Python via Java**.

Nainstalujte balíček podle instrukcí v [Installation](/slides/cs/python-java/installation/). Každý příklad importuje `asposeslides` před spuštěním JVM, poté importuje API po spuštění JVM. Nejprve spusťte příklad pro přidání, aby se vytvořil soubor `chart.pptx` pro další příklady.

## **Přidání grafu**

Přidejte plošný graf na první snímek a uložte prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Přidejte plošný graf na první snímek.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přístup ke grafu**

Najděte první graf v kolekci tvarů na prvním snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Přístup k prvnímu grafu na snímku.
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **Odstranění grafu**

Odstraňte první graf ze snímku a uložte upravenou prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Najděte a odstraňte první graf na snímku.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aktualizace dat grafu**

Zobrazte název grafu, změňte jeho text a uložte aktualizovanou prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Najděte první graf na snímku.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # Zobrazte název grafu a změňte jeho text.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```