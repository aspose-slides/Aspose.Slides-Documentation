---
title: Nagłówek i stopka
type: docs
weight: 220
url: /pl/python-java/examples/elements/header-footer/
keywords:
- przykład kodu
- nagłówek
- stopka
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Steruj nagłówkami i stopkami slajdów za pomocą Aspose.Slides dla Pythona poprzez Javę: dodawaj daty, numery slajdów i własny tekst w prezentacjach PPT, PPTX i ODP."
---
Ten artykuł pokazuje, jak dodać stopki oraz zaktualizować znaczniki daty i godziny przy użyciu **Aspose.Slides for Python via Java**.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Dodaj stopkę**

Dodaj tekst do obszaru stopki slajdu i spraw, aby był widoczny.

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

## **Zaktualizuj datę i godzinę**

Zmień znacznik daty i godziny na slajdzie.

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