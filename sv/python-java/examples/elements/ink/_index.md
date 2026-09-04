---
title: Bläck
type: docs
weight: 180
url: /sv/python-java/examples/elements/ink/
keywords:
- kodexempel
- bläck
- åtkomst till bläck
- ta bort bläck
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Åtkomst till och borttagning av bläckformer i Aspose.Slides för Python via Java-presentationer, inklusive PPT-, PPTX- och ODP-filer."
---
Denna artikel ger exempel på hur man kommer åt befintliga bläckformer och tar bort dem med **Aspose.Slides for Python via Java**.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar sedan API:et när JVM körs.

{{% alert color="info" title="Note" %}}
Bläckformer representerar användarinmatning från specialiserade enheter. Aspose.Slides kan inte skapa nya bläcksteg programmässigt, men du kan läsa och modifiera befintligt bläck.
{{% /alert %}}

## **Åtkomst till bläck**

Läs taggarna från den första bläckformen på en bild.

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
            # Använd tag_name vid behov.
finally:
    presentation.dispose()
```

## **Ta bort bläck**

Ta bort en bläckform från bilden om en finns.

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