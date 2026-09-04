---
title: Poznámka
type: docs
weight: 240
url: /cs/python-java/examples/elements/note/
keywords:
- příklad kódu
- poznámka
- poznámka řečníka
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Pracujte s poznámkami snímků v Aspose.Slides pro Python přes Java: přidávejte, čtěte, odstraňujte a aktualizujte poznámky řečníka v prezentacích PowerPoint a OpenDocument."
---
Tento článek demonstruje, jak pomocí **Aspose.Slides for Python via Java** přidávat, číst, odstraňovat a aktualizovat poznámkové snímky.

Balíček nainstalujte podle popisu v [Installation](/slides/cs/python-java/installation/). Každý příklad importuje `asposeslides` před spuštěním JVM a poté po spuštění JVM importuje API.

## **Přidat poznámkový snímek**

Vytvořte poznámkový snímek a přiřaďte mu text.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")
finally:
    presentation.dispose()
```

## **Přistupovat k poznámkovému snímku**

Přečtěte text z existujícího poznámkového snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **Odstranit poznámkový snímek**

Odstraňte poznámkový snímek přidružený k snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getNotesSlideManager().addNotesSlide()
    slide.getNotesSlideManager().removeNotesSlide()
finally:
    presentation.dispose()
```

## **Aktualizovat text poznámkového snímku**

Změňte text poznámkového snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("Old")
    notes_slide.getNotesTextFrame().setText("Updated")
finally:
    presentation.dispose()
```