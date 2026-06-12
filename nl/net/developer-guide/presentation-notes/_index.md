---
title: Beheer presentatienotities in .NET
linktitle: Presentatienotities
type: docs
weight: 110
url: /nl/net/presentation-notes/
keywords:
- notities
- notitiesdia
- notities toevoegen
- notities verwijderen
- notitiestijl
- masternotities
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas presentatienotities aan met Aspose.Slides voor .NET. Werk moeiteloos met PowerPoint- en OpenDocument-notities om uw productiviteit te verhogen."
---
## **Overzicht**

Aspose.Slides ondersteunt het verwijderen van notitieslides uit een presentatie. In dit onderwerp introduceren we deze functionaliteit, inclusief hoe notities te verwijderen en hoe een stijl op notitieslides in een presentatie toe te passen. Aspose.Slides stelt je in staat notities van elke dia te verwijderen en ook styling toe te passen op bestaande notities. Ontwikkelaars kunnen notities op de volgende manieren verwijderen:

- Notities verwijderen van een specifieke dia in een presentatie.
- Notities verwijderen van alle dia’s in een presentatie.

## **Verwijder notities van een dia**
Notities van een specifieke dia kunnen verwijderd worden zoals in het onderstaande voorbeeld wordt getoond:

```c#
// Maak een Presentation-object aan dat een presentatiebestand voorstelt
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Verwijderen van notities van de eerste dia
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Presentatie opslaan op schijf
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Verwijder notities van alle dia’s**
Notities van alle dia’s van een presentatie kunnen verwijderd worden zoals in het onderstaande voorbeeld wordt getoond:

```c#
// Maak een Presentation-object aan dat een presentatiebestand voorstelt 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Notities van alle dia’s verwijderen
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Presentatie opslaan op schijf
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Voeg een notitiesstijl toe**
De property **NotesStyle** is toegevoegd aan de interface [IMasterNotesSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/imasternotesslide) en de klasse [MasterNotesSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/masternotesslide) respectievelijk. Deze property specificeert de stijl van een notitietekst. De implementatie wordt gedemonstreerd in het voorbeeld hieronder.

```c#
// Instantieer de Presentation-klasse die het presentatiebestand voorstelt
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Haal de tekststijl van MasterNotesSlide op
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Stel symbool bullet in voor de alinea's van het eerste niveau
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Sla het PPTX-bestand op naar de schijf
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

**Welke API‑entiteit biedt toegang tot de notities van een specifieke dia?**

Notities worden benaderd via de notitiemanager van de dia: de dia heeft een [NotesSlideManager](https://reference.aspose.com/slides/nl/net/aspose.slides/notesslidemanager/) en een [eigenschap](https://reference.aspose.com/slides/nl/net/aspose.slides/notesslidemanager/notesslide/) die het notitie‑object retourneert, of `null` als er geen notities zijn.

**Zijn er verschillen in notitie‑ondersteuning tussen de verschillende PowerPoint‑versies waarmee de bibliotheek werkt?**

De bibliotheek richt zich op een breed scala aan Microsoft PowerPoint‑formaten (97‑en nieuwer) en ODP; notities worden ondersteund in deze formaten zonder dat er een geïnstalleerde kopie van PowerPoint vereist is.