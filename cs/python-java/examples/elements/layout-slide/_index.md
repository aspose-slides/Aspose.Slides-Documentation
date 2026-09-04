---
title: Rozložení snímku
type: docs
weight: 20
url: /cs/python-java/examples/elements/layout-slide/
keywords:
- příklad kódu
- rozložení snímku
- přidat rozložení snímku
- přístup k rozložení snímku
- odstranit rozložení snímku
- nepoužité rozložení snímku
- klonovat rozložení snímku
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Spravujte rozložení snímků pomocí Aspose.Slides pro Python přes Java: přidávejte, přistupujte, odstraňujte, čistěte a klonujte rozvržení v prezentacích PowerPoint a OpenDocument."
---
Tento článek demonstruje, jak pracovat s **layout slides** pomocí Aspose.Slides pro Python prostřednictvím Javy. Layout slide definuje design a formátování zděděné normálními snímky. Můžete přidávat, přistupovat, klonovat a odstraňovat layout slides a také čistit nepoužívané, abyste snížili velikost prezentace.

Nainstalujte balíček podle popisu v [Installation](/slides/cs/python-java/installation/). Každý příklad importuje `asposeslides` před spuštěním JVM a následně importuje API po spuštění JVM.

## **Přidat layout slide**

Vytvořte vlastní layout slide pro definování opakovaně použitelného formátování. Následující příklad přidá textové pole do nového layoutu a poté vytvoří dva snímky, které jej používají.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Vytvořte layout slide s prázdným typem a vlastním názvem.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # Přidejte textové pole do layout slide.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # Přidejte dva snímky, které zdědí text z layoutu.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Poznámka 1:** Layout slides fungují jako šablony pro jednotlivé snímky. Můžete definovat společné prvky jednou a znovu je použít v mnoha snímcích.

> 💡 **Poznámka 2:** Když přidáte tvary nebo text do layout slide, všechny snímky založené na tomto rozvržení zobrazí sdílený obsah automaticky.  
> Níže uvedená snímka ukazuje dva snímky, které dědí textové pole ze stejného layout slide.

![Snímky dědící obsah layoutu](layout-slide-result.png)

## **Přístup k layout slide**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Přístup k layout slide podle indexu.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # Přístup k layout slide podle typu.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **Odstranit layout slide**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **Odstranit nepoužívané layout slides**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **Klonovat layout slide**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Shrnutí:** Layout slides pomáhají udržovat konzistentní formátování napříč prezentací. Aspose.Slides vám umožňuje vytvářet, spravovat, znovu používat a čistit rozvržení podle potřeby.