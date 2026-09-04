---
title: Hiperłącze
type: docs
weight: 130
url: /pl/python-java/examples/elements/hyperlink/
keywords:
- przykład kodu
- hiperłącze
- dodaj hiperłącze
- odczytaj hiperłącze
- usuń hiperłącze
- zaktualizuj hiperłącze
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dodawaj i zarządzaj hiperłączami w Aspose.Slides dla Pythona poprzez Java: twórz, odczytuj, usuwaj i aktualizuj linki w prezentacjach PPT, PPTX i ODP."
---
Ten artykuł demonstruje dodawanie, odczytywanie, usuwanie i aktualizowanie hiperłączy w kształtach przy użyciu **Aspose.Slides for Python via Java**.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Dodaj hiperłącze**

Utwórz prostokątny kształt z hiperłączem prowadzącym do zewnętrznej witryny.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))
finally:
    presentation.dispose()
```

## **Uzyskaj dostęp do hiperłącza**

Odczytaj informacje o hiperłączu z fragmentu tekstu kształtu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    hyperlink = text_portion.getPortionFormat().getHyperlinkClick()
finally:
    presentation.dispose()
```

## **Usuń hiperłącze**

Usuń hiperłącze z tekstu kształtu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    text_portion.getPortionFormat().setHyperlinkClick(None)
finally:
    presentation.dispose()
```

## **Zaktualizuj hiperłącze**

Zmień docelowy adres istniejącego hiperłącza. Użyj [HyperlinkManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkmanager/), aby zmodyfikować tekst, który już zawiera hiperłącze, co naśladuje sposób, w jaki PowerPoint bezpiecznie aktualizuje hiperłącza.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://old.example.com"))

    # Zmiana hiperłącza w istniejącym tekście powinna być wykonana przy użyciu
    # HyperlinkManager zamiast bezpośredniego ustawiania właściwości.
    # To imituje sposób, w jaki PowerPoint bezpiecznie aktualizuje hiperłącza.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```