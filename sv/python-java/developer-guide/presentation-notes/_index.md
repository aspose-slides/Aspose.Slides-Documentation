---
title: Hantera presentationsanteckningar i Python via Java
linktitle: Presentationsanteckningar
type: docs
weight: 110
url: /sv/python-java/presentation-notes/
keywords:
- anteckningar
- anteckningsbild
- lägga till anteckningar
- ta bort anteckningar
- anteckningsstil
- masteranteckningar
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Anpassa presentationsanteckningar med Aspose.Slides för Python via Java. Arbeta sömlöst med PowerPoint- och OpenDocument-anteckningar för att öka din produktivitet."
---
## **Översikt**

Aspose.Slides stöder borttagning av anteckningsbilder från en presentation. Detta ämne introducerar den här funktionen, inklusive hur man tar bort anteckningar och hur man använder en stil på anteckningsbilder i en presentation. Aspose.Slides låter dig ta bort anteckningar från vilken bild som helst och tillämpa formatering på befintliga anteckningar. Utvecklare kan ta bort anteckningar på följande sätt:

- Ta bort anteckningar från en specifik bild i en presentation.
- Ta bort anteckningar från alla bilder i en presentation.

För att läsa eller ändra notssidans dimensioner, byta orientering och kontrollera exportbeteendet, se [Notssidans storlek](/slides/sv/python-java/notes-size/).

## **Ta bort anteckningar från en bild**

Anteckningar från en specifik bild kan tas bort som visas i exemplet nedan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instansiera ett Presentation-objekt som representerar en presentationsfil.
presentation = Presentation("presWithNotes.pptx")
try:
    # Ta bort anteckningar från den första bilden.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Spara presentationen till disk.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ta bort anteckningar från en presentation**

Anteckningar från alla bilder i en presentation kan tas bort som visas i exemplet nedan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instansiera ett Presentation-objekt som representerar en presentationsfil.
presentation = Presentation("presWithNotes.pptx")
try:
    # Ta bort anteckningar från alla bilder.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Spara presentationen till disk.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lägg till en anteckningsstil**

Metoden [getNotesStyle](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masternotesslide/#getNotesStyle) i klassen [MasterNotesSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masternotesslide/) ger åtkomst till stilen för anteckningstext. Implementeringen demonstreras i exemplet nedan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Instansiera ett Presentation-objekt som representerar en presentationsfil.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Hämta masteranteckningssidans textstil.
        notes_style = notes_master.getNotesStyle()

        # Ange symbolpunkter för stycken på första nivån.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Vilken API‑enhet ger åtkomst till anteckningarna för en specifik bild?**

Anteckningar nås via bildens notes manager: bilden har en [NotesSlideManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notesslidemanager/) och en [getNotesSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notesslidemanager/#getNotesSlide)-metod som returnerar anteckningsobjektet, eller `None` om det inte finns några anteckningar.

**Finns det skillnader i stöd för anteckningar mellan de PowerPoint‑versioner som biblioteket fungerar med?**

Biblioteket riktar sig mot ett brett spektrum av Microsoft PowerPoint-format (97 och senare) samt ODP; anteckningar stöds i dessa format utan att bero på en installerad kopia av PowerPoint.