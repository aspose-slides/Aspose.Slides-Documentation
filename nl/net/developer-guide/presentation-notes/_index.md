---
title: Beheer presentatienotities in .NET
linktitle: Presentatienotities
type: docs
weight: 110
url: /nl/net/presentation-notes/
keywords:
- notities
- notitieslide
- notities toevoegen
- notities verwijderen
- notitiestijl
- master‑notities
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas presentatienotities aan met Aspose.Slides voor .NET. Werk moeiteloos met PowerPoint‑ en OpenDocument‑notities om uw productiviteit te verhogen."
---
## **Overzicht**

Aspose.Slides ondersteunt het verwijderen van notitieslides uit een presentatie. In dit onderwerp introduceren we deze functie, inclusief hoe notities te verwijderen en hoe een stijl toe te passen op notitieslides in een presentatie. Aspose.Slides maakt het mogelijk om notities van elke dia te verwijderen en tevens styling toe te passen op bestaande notities. Ontwikkelaars kunnen notities op de volgende manieren verwijderen:

- Verwijder notities van een specifieke dia in een presentatie.
- Verwijder notities van alle dia’s in een presentatie.

Om de afmetingen van de notitiepagina te lezen of te wijzigen, de oriëntatie te wisselen en het exportgedrag te bekijken, zie [Notes Page Size](/slides/nl/net/notes-size/).

## **Verwijder notities van een dia**
Notities van een specifieke dia kunnen worden verwijderd zoals getoond in het onderstaande voorbeeld:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een Presentation object aan dat een presentatiebestand vertegenwoordigt
Presentation presentation = new Presentation("AccessSlides.pptx");

// Verwijderen van notities van de eerste dia
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Sla de presentatie op op schijf
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Verwijder notities van alle dia’s**
Notities van alle dia’s van een presentatie kunnen worden verwijderd zoals getoond in het onderstaande voorbeeld:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Verwijderen van notities van alle dia's
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Sla de presentatie op op schijf
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Voeg een notitiestijl toe**
De eigenschap **NotesStyle** is toegevoegd aan de [IMasterNotesSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/imasternotesslide) interface en de [MasterNotesSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/masternotesslide) klasse respectievelijk. Deze eigenschap geeft de stijl van een notitietekst aan. De implementatie wordt gedemonstreerd in het onderstaande voorbeeld.

```c#
using Aspose.Slides;

// Instantieer de Presentation-klasse die het presentatiebestand vertegenwoordigt
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Haal de tekstopmaak van MasterNotesSlide op
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Stel symboolbullet in voor alinea's op het eerste niveau
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Sla het PPTX-bestand op op de schijf
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

### Welke API‑entiteit biedt toegang tot de notities van een specifieke dia?

Notities worden benaderd via de notitiesmanager van de dia: de dia heeft een [NotesSlideManager](https://reference.aspose.com/slides/nl/net/aspose.slides/notesslidemanager/) en een [property](https://reference.aspose.com/slides/nl/net/aspose.slides/notesslidemanager/notesslide/) die het notitie‑object retourneert, of `null` als er geen notities zijn.

### Zijn er verschillen in notitie‑ondersteuning tussen de PowerPoint‑versies waarmee de bibliotheek werkt?

De bibliotheek richt zich op een breed scala aan Microsoft PowerPoint‑formaten (97‑en nieuwer) en ODP; notities worden in deze formaten ondersteund zonder afhankelijk te zijn van een geïnstalleerde kopie van PowerPoint.