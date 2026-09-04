---
title: Sidhuvud och sidfot
type: docs
weight: 220
url: /sv/python-java/examples/elements/header-footer/
keywords:
- kodexempel
- rubrik
- sidfot
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Kontrollera bildrubriker och sidfötter med Aspose.Slides för Python via Java: lägg till datum, bildnummer och anpassad text i PPT, PPTX och ODP-presentationer."
---
Denna artikel visar hur du lägger till sidfötter och uppdaterar datum- och tidsplatshållare med **Aspose.Slides for Python via Java**.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar sedan API:et när JVM körs.

## **Lägg till en sidfot**

Lägg till text i sidfotområdet på en bild och gör den synlig.

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

## **Uppdatera datum och tid**

Ändra datum- och tidsplatshållaren på en bild.

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