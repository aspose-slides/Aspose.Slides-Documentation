---
title: Hantera presentationsanteckningar i .NET
linktitle: Presentationsanteckningar
type: docs
weight: 110
url: /sv/net/presentation-notes/
keywords:
- anteckningar
- anteckningsbild
- lägg till anteckningar
- ta bort anteckningar
- anteckningsstil
- masteranteckningar
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Anpassa presentationsanteckningar med Aspose.Slides för .NET. Arbeta sömlöst med PowerPoint- och OpenDocument-anteckningar för att öka din produktivitet."
---
## **Översikt**

Aspose.Slides stöder borttagning av anteckningsbilder från en presentation. I det här avsnittet introducerar vi den här funktionen, inklusive hur man tar bort anteckningar och hur man applicerar en stil på anteckningsbilder i en presentation. Aspose.Slides låter dig ta bort anteckningar från vilken bild som helst och även tillämpa formatering på befintliga anteckningar. Utvecklare kan ta bort anteckningar på följande sätt:

- Ta bort anteckningar från en specifik bild i en presentation.
- Ta bort anteckningar från alla bilder i en presentation.

För att läsa eller ändra anteckningssidans dimensioner, byta orientering och kontrollera exportbeteende, se [Anteckningssidans storlek](/slides/sv/net/notes-size/).

## **Ta bort anteckningar från en bild**
Anteckningar för en viss bild kan tas bort enligt exemplet nedan:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera ett Presentation-objekt som representerar en presentationsfil
Presentation presentation = new Presentation("AccessSlides.pptx");

// Tar bort anteckningar från den första bilden
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Spara presentationen till disk
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Ta bort anteckningar från alla bilder**
Anteckningar för alla bilder i en presentation kan tas bort enligt exemplet nedan:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera ett Presentation-objekt som representerar en presentationsfil 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Tar bort anteckningar från alla bilder
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Spara presentationen till disk
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Lägg till en anteckningsstil**
NotesStyle property har lagts till i [IMasterNotesSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/imasternotesslide) gränssnittet och [MasterNotesSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/masternotesslide) klassen respektive. Denna egenskap specificerar stilen för en anteckningstext. Implementeringen visas i exemplet nedan.

```c#
using Aspose.Slides;

// Instansiera Presentation-klassen som representerar presentationsfilen
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Hämta MasterNotesSlide-textstil
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Ställ in symbolpunkt för stycken på första nivån
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Spara PPTX-filen till disken
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **Vanliga frågor**

### Vilken API‑enhet ger åtkomst till anteckningarna för en specifik bild?
Anteckningar nås via bildens notes manager: bilden har en [NotesSlideManager](https://reference.aspose.com/slides/sv/net/aspose.slides/notesslidemanager/) och en [property](https://reference.aspose.com/slides/sv/net/aspose.slides/notesslidemanager/notesslide/) som returnerar anteckningsobjektet, eller `null` om det inte finns några anteckningar.

### Finns det skillnader i anteckningsstöd mellan de PowerPoint‑versioner som biblioteket fungerar med?
Biblioteket riktar sig mot ett brett spektrum av Microsoft PowerPoint‑format (97–nyare) och ODP; anteckningar stöds i dessa format utan att kräva en installerad kopia av PowerPoint.