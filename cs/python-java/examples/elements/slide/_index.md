---
title: Snímek
type: docs
weight: 10
url: /cs/python-java/examples/elements/slide/
keywords:
- ukázka kódu
- snímek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Spravujte snímky v Aspose.Slides pro Python přes Java: přidávejte, přistupujte, klonujte, měňte pořadí a odstraňujte snímky pomocí ukázek kódu v Pythonu pro prezentace PowerPoint a OpenDocument."
---
Tento článek poskytuje příklady, které ukazují, jak pomocí **Aspose.Slides for Python via Java** přidávat, přistupovat, klonovat, měnit pořadí a odstraňovat snímky.

Balíček nainstalujte podle návodu v [Installation](/slides/cs/python-java/installation/). Každý příklad importuje `asposeslides` před spuštěním JVM a poté importuje API po spuštění JVM.

## **Přidat snímek**

Chcete-li přidat nový snímek, nejprve vyberte rozvržení. Tento příklad používá prázdné rozvržení k přidání prázdného snímku do prezentace.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    presentation.getSlides().addEmptySlide(blank_layout)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Každé rozvržení snímku je odvozeno od hlavního snímku, který určuje celkový design a strukturu zástupných objektů. Obrázek níže ilustruje, jak jsou v PowerPointu organizovány hlavní snímky a jejich přidružená rozvržení.
{{% /alert %}}

![Vztah mezi hlavním snímkem a rozvržením](master-layout-slide.png)

## **Přístup ke snímkům podle indexu**

Přistupujte ke snímkům pomocí jejich nulového indexu nebo najděte index snímku na základě reference. To je užitečné pro iteraci nebo úpravu konkrétních snímků.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Přidejte další prázdný snímek.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # Přístup ke snímkům podle indexu.
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # Získání indexu snímku z reference a poté přístup k němu podle indexu.
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **Klonovat snímek**

Klonujte existující snímek. Klonovaný snímek se automaticky přidá na konec kolekce snímků.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    cloned_slide_index = presentation.getSlides().indexOf(cloned_slide)
finally:
    presentation.dispose()
```

## **Změnit pořadí snímků**

Změňte pořadí snímků přesunutím jednoho na nový index. Tento příklad přesouvá klonovaný snímek na první pozici.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    presentation.getSlides().reorder(0, cloned_slide)
finally:
    presentation.dispose()
```

## **Odstranit snímek**

Odstraňte snímek předáním jeho reference do kolekce snímků. Tento příklad přidá druhý snímek a poté odstraní původní, takže zůstane pouze nový.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    second_slide = presentation.getSlides().addEmptySlide(blank_layout)

    first_slide = presentation.getSlides().get_Item(0)
    presentation.getSlides().remove(first_slide)
finally:
    presentation.dispose()
```