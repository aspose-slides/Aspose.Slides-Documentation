---
title: Záhlaví a zápatí
type: docs
weight: 220
url: /cs/python-java/examples/elements/header-footer/
keywords:
- příklad kódu
- záhlaví
- zápatí
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Ovládejte záhlaví a zápatí snímků pomocí Aspose.Slides pro Python přes Java: přidejte data, čísla snímků a vlastní text do prezentací PPT, PPTX a ODP."
---
Tento článek ukazuje, jak přidat zápatí a aktualizovat zástupné symboly data a času pomocí **Aspose.Slides for Python via Java**.

Balíček nainstalujete podle popisu v [Installation](/slides/cs/python-java/installation/). Každý příklad importuje `asposeslides` před spuštěním JVM a poté importuje API po spuštění JVM.

## **Přidat zápatí**

Přidejte text do oblasti zápatí snímku a zajistěte, aby byl viditelný.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **Aktualizovat datum a čas**

Upravte zástupný symbol data a času na snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```