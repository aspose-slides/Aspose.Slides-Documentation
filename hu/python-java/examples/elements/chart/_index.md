---
title: Diagram
type: docs
weight: 60
url: /hu/python-java/examples/elements/chart/
keywords:
- diagram
- diagram hozzáadása
- diagram elérése
- diagram eltávolítása
- diagram frissítése
- kódpéldák
- PowerPoint
- OpenDocument
- bemutató
- Python
- Java
- Aspose.Slides
description: "Diagramok létrehozása, elérése, eltávolítása és frissítése PowerPoint és OpenDocument bemutatókban az Aspose.Slides for Python via Java használatával."
---
Ez a cikk bemutatja, hogyan lehet diagramokat hozzáadni, elérni, eltávolítani és frissíteni egy bemutatóban a **Aspose.Slides for Python via Java** használatával.

Telepítse a csomagot a [Installation](/slides/hu/python-java/installation/) leírása szerint. Minden példa a JVM indítása előtt importálja a `asposeslides`-t, majd a JVM futása közben importálja az API-t. Futtassa először a hozzáadási példát, hogy létrehozza a `chart.pptx` fájlt a többi példához.

## **Diagram hozzáadása**

Adjon hozzá egy területdiagramot az első diára, és mentse a bemutatót.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Területdiagram hozzáadása az első diára.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Diagram elérése**

Keresse meg az első diagramot az első dia alakzatgyűjteményében.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Az első diagram elérése a dián.
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

## **Diagram eltávolítása**

Az első diagramot távolítsa el a diáról, és mentse a módosított bemutatót.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Keresse meg és távolítsa el az első diagramot a dián.
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

## **Diagram adatainak frissítése**

Jelenítse meg a diagram címét, módosítsa a szövegét, és mentse a frissített bemutatót.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Keresse meg az első diagramot a dián.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # Jelenítse meg a diagram címét és módosítsa a szövegét.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```