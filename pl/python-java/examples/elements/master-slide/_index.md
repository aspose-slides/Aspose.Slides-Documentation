---
title: Slajd master
type: docs
weight: 30
url: /pl/python-java/examples/elements/master-slide/
keywords:
- przykład kodu
- slajd master
- dodaj slajd master
- dostęp do slajdu master
- usuń slajd master
- nieużywany slajd master
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zarządzaj slajdami master przy użyciu Aspose.Slides dla Pythona via Java: twórz, uzyskuj dostęp, usuwaj i czyść mastery w prezentacjach PowerPoint i OpenDocument."
---
Master slides tworzą najwyższy poziom hierarchii dziedziczenia slajdów w programie PowerPoint. **master slide** definiuje wspólne elementy projektu, takie jak tła, loga i formatowanie tekstu. **layout slides** dziedziczą po master slides, a **normal slides** dziedziczą po layout slides.

Ten artykuł pokazuje, jak tworzyć, modyfikować i zarządzać master slajdami przy użyciu **Aspose.Slides for Python via Java**.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Dodaj master slajd**

Ten przykład pokazuje, jak utworzyć nowy master slajd poprzez sklonowanie domyślnego. Następnie dodaje banner z nazwą firmy do wszystkich slajdów za pomocą dziedziczenia layoutu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Sklonuj domyślny slajd master.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # Dodaj baner z nazwą firmy na szczycie slajdu master.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # Przypisz nowy slajd master do slajdu układu.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # Przypisz slajd układu do pierwszego slajdu w prezentacji.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Uwaga" %}}
Master slajdy zapewniają możliwość stosowania spójnej identyfikacji wizualnej lub wspólnych elementów projektu we wszystkich slajdach. Zmiany wprowadzone w masterze są automatycznie odzwierciedlane w zależnych layoutach i normalnych slajdach.
{{% /alert %}}

{{% alert color="info" title="Uwaga" %}}
Kształty i formatowanie dodane do master slajdu są dziedziczone przez layout slajdy i, z kolei, przez wszystkie normalne slajdy korzystające z tych layoutów. Poniższy obrazek ilustruje, jak pole tekstowe dodane do master slajdu jest automatycznie renderowane na ostatecznym slajdzie.
{{% /alert %}}

![Przykład dziedziczenia master](master-slide-banner.png)

## **Uzyskaj dostęp do master slajdu**

Możesz uzyskać dostęp do master slajdów poprzez kolekcję masterów prezentacji. Ten przykład pobiera pierwszy master slajd i zmienia jego typ tła.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **Usuń master slajd**

Master slajd może zostać usunięty według indeksu lub referencji, gdy już nie jest używany. Ten przykład przypisuje sklonowany master slajd do prezentacji, a następnie usuwa oryginalny master według indeksu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # Usuń nieużywany pierwotny slajd master według indeksu.
    presentation.getMasters().removeAt(0)

    # Alternatywnie, usuń nieużywany slajd master według referencji:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **Usuń nieużywane master slajdy**

Niektóre prezentacje zawierają master slajdy, które nie są używane. Usunięcie tych slajdów może pomóc zmniejszyć rozmiar pliku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # Usuń wszystkie nieużywane slajdy master, w tym te oznaczone jako Preserve.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```