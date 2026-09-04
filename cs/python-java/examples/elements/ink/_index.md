---
title: Inkoust
type: docs
weight: 180
url: /cs/python-java/examples/elements/ink/
keywords:
- příklad kódu
- inkoust
- přístup k inkoustu
- odstranit inkoust
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Přístup a odstraňování inkoustových tvarů v Aspose.Slides for Python via Java prezentacích, včetně souborů PPT, PPTX a ODP."
---
Tento článek poskytuje příklady, jak přistupovat k existujícím inkoustovým tvarům a odstraňovat je pomocí **Aspose.Slides for Python via Java**.

Nainstalujte balíček podle pokynů v [Installation](/slides/cs/python-java/installation/). Každý příklad načte `asposeslides` před spuštěním JVM a poté načte API po spuštění JVM.

{{% alert color="info" title="Poznámka" %}}
Inkoustové tvary představují vstup uživatele ze specializovaných zařízení. Aspose.Slides nemůže programově vytvářet nové inkoustové tahy, ale můžete číst a upravovat existující inkoust.
{{% /alert %}}

## **Přístup k inkoustu**

Přečtěte značky z první inkoustové podoby na snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # Použijte tag_name podle potřeby.
finally:
    presentation.dispose()
```

## **Odstranit inkoust**

Odstraňte inkoustovou podobu ze snímku, pokud existuje.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```