---
title: Atrament
type: docs
weight: 180
url: /pl/python-java/examples/elements/ink/
keywords:
- przykład kodu
- atrament
- dostęp do atramentu
- usuwanie atramentu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dostęp i usuwanie kształtów atramentu w prezentacjach Aspose.Slides dla Pythona przez Java, w tym pliki PPT, PPTX i ODP."
---
Ten artykuł zawiera przykłady dostępu do istniejących kształtów atramentu oraz ich usuwania przy użyciu **Aspose.Slides for Python via Java**.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

{{% alert color="info" title="Note" %}}
Kształty atramentu reprezentują dane wprowadzane przez użytkownika z wyspecjalizowanych urządzeń. Aspose.Slides nie może programowo tworzyć nowych pociągnięć atramentu, ale można odczytywać i modyfikować istniejący atrament.
{{% /alert %}}

## **Dostęp do atramentu**

Odczytaj znaczniki z pierwszego kształtu atramentu na slajdzie.

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
            # Użyj tag_name w razie potrzeby.
finally:
    presentation.dispose()
```

## **Usuwanie atramentu**

Usuń kształt atramentu z slajdu, jeśli istnieje.

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