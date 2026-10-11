---
title: Hantera presentationsanteckningar i Python
linktitle: Presentationsanteckningar
type: docs
weight: 110
url: /sv/python-net/presentation-notes/
keywords:
- anteckningar
- anteckningsbild
- lägg till anteckningar
- ta bort anteckningar
- anteckningsstil
- huvudanteckningar
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Anpassa presentationsanteckningar med Aspose.Slides för Python via .NET. Arbeta sömlöst med PowerPoint- och OpenDocument-anteckningar för att öka din produktivitet."
---
## **Översikt**

Aspose.Slides stöder att ta bort anteckningsbilder från en presentation. I det här avsnittet presenterar vi den här funktionen, inklusive hur man tar bort anteckningar och hur man tillämpar en stil på anteckningsbilder i en presentation. Aspose.Slides låter dig ta bort anteckningar från vilken bild som helst och även tillämpa formatering på befintliga anteckningar. Utvecklare kan ta bort anteckningar på följande sätt:

- Ta bort anteckningar från en specifik bild i en presentation.
- Ta bort anteckningar från alla bilder i en presentation.

För att läsa eller ändra anteckningssidans dimensioner, växla orientering och kontrollera exportbeteende, se [Anteckningssidans storlek](/slides/sv/python-net/notes-size/).

## **Ta bort anteckningar från en bild**
Anteckningar från en specifik bild kan tas bort som visas i exemplet nedan:

```py
import aspose.slides as slides

# Skapa ett Presentation-objekt som representerar en presentationsfil 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Tar bort anteckningar från den första bilden
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # Spara presentationen till disk
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ta bort anteckningar från alla bilder**
Anteckningar från alla bilder i en presentation kan tas bort som visas i exemplet nedan:

```py
import aspose.slides as slides

# Skapa ett Presentation-objekt som representerar en presentationsfil 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Tar bort anteckningar från alla bilder
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # spara presentationen till disk
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Applicera en anteckningsstil**
Egenskapen [notes_style](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masternotesslide/notes_style/) har lagts till i klassen [MasterNotesSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masternotesslide/). Denna egendom specificerar stilen för anteckningstexten. Implementeringen demonstreras i exemplet nedan.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar presentationsfilen
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Hämta MasterNotesSlide-textstilen
        notesStyle = notesMaster.notes_style

        #Set symbolbulle för stycken på första nivån
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # spara PPTX-filen till disken
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Vilken API‑enhet ger åtkomst till anteckningarna för en specifik bild?**

Anteckningar nås via bildens anteckningshanterare: bilden har en [NotesSlideManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/notesslidemanager/) och en [property](https://reference.aspose.com/slides/sv/python-net/aspose.slides/notesslidemanager/notes_slide/) som returnerar anteckningsobjektet, eller `None` om det inte finns några anteckningar.

**Finns det skillnader i anteckningsstöd mellan de PowerPoint‑versioner som biblioteket fungerar med?**

Biblioteket riktar sig mot ett brett spektrum av Microsoft PowerPoint‑format (97–nyare) och ODP; anteckningar stöds i dessa format utan att kräva en installerad kopia av PowerPoint.