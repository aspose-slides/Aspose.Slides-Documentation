---
title: Hantera presentationsnoteringar i Python
linktitle: Presentationsnoteringar
type: docs
weight: 110
url: /sv/python-net/presentation-notes/
keywords:
- noteringar
- noteringsbild
- lägg till noteringar
- ta bort noteringar
- noteringsstil
- masternoteringar
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Anpassa presentationsnoteringar med Aspose.Slides för Python via .NET. Arbeta sömlöst med noteringar i PowerPoint och OpenDocument för att öka din produktivitet."
---
## **Översikt**

Aspose.Slides stöder att ta bort noteringsbilder från en presentation. I det här avsnittet kommer vi att introducera den här funktionen, inklusive hur du tar bort noteringar och hur du tillämpar en stil på noteringsbilder i en presentation. Aspose.Slides låter dig ta bort noteringar från vilken bild som helst och även applicera stil på befintliga noteringar. Utvecklare kan ta bort noteringar på följande sätt:

- Ta bort noteringar från en specifik bild i en presentation.
- Ta bort noteringar från alla bilder i en presentation.

## **Ta bort noteringar från bild**
Noteringar från en viss bild kan tas bort som visas i exemplet nedan:

```py
import aspose.slides as slides

# Instansiera ett Presentation-objekt som representerar en presentationsfil 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Tar bort noteringar från den första bilden
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # spara presentation till disk
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ta bort noteringar från alla bilder**
Noteringar från alla bilder i en presentation kan tas bort som visas i exemplet nedan:

```py
import aspose.slides as slides

# Instansiera ett Presentation-objekt som representerar en presentationsfil 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Tar bort noteringar från alla bilder
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # spara presentation till disk
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Lägg till NotesStyle**
Egenskapen [notes_style](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masternotesslide/notes_style/) har lagts till i klassen [MasterNotesSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masternotesslide/). Denna egenskap anger stilen för en noteringstext. Implementeringen demonstreras i exemplet nedan.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar presentationsfilen
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Hämta MasterNotesSlide-textstil
        notesStyle = notesMaster.notes_style

        #Sätt symbolbullet för första nivåparagrafer
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # spara PPTX-filen till disken
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Vilken API‑entitet ger åtkomst till noteringarna för en specifik bild?**

Noteringar nås via bildens notes manager: bilden har en [NotesSlideManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/notesslidemanager/) och en [property](https://reference.aspose.com/slides/sv/python-net/aspose.slides/notesslidemanager/notes_slide/) som returnerar noteringsobjektet, eller `None` om det inte finns några noteringar.

**Finns det skillnader i noteringsstöd mellan de PowerPoint‑versioner som biblioteket fungerar med?**

Biblioteket riktar sig mot ett brett spektrum av Microsoft PowerPoint‑format (97 och senare) samt ODP; noteringar stöds i dessa format utan att kräva en installerad kopia av PowerPoint.