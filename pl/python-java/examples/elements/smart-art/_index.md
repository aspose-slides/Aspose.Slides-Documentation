---
title: SmartArt
type: docs
weight: 140
url: /pl/python-java/examples/elements/smart-art/
keywords:
- przykład kodu
- SmartArt
- dodaj SmartArt
- dostęp do SmartArt
- usuń SmartArt
- układ SmartArt
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Pracuj ze SmartArt w Aspose.Slides for Python via Java: dodawaj, uzyskuj dostęp, usuwaj i zmieniaj układy diagramów w prezentacjach PowerPoint i OpenDocument."
---
Ten artykuł pokazuje, jak dodać grafiki SmartArt, uzyskać do nich dostęp, usunąć je oraz zmienić układy przy użyciu **Aspose.Slides for Python via Java**.

Zainstaluj pakiet zgodnie z opisem w [Instalacja](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Add SmartArt**
Wstaw grafikę SmartArt, korzystając z jednego z wbudowanych układów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **Access SmartArt**
Pobierz pierwszy obiekt SmartArt na slajdzie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **Remove SmartArt**
Usuń kształt SmartArt ze slajdu.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **Change SmartArt Layout**
Zaktualizuj typ układu istniejącej grafiki SmartArt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```