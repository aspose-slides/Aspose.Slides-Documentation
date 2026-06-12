---
title: Beheer presentatienotities in Java
linktitle: Presentatienotities
type: docs
weight: 110
url: /nl/java/presentation-notes/
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
- Java
- Aspose.Slides
description: "Pas de notities van de presentatie aan met Aspose.Slides voor Java. Werk naadloos met PowerPoint- en OpenDocument-notities om uw productiviteit te verhogen."
---
## **Overzicht**

Aspose.Slides ondersteunt het verwijderen van notitieslides uit een presentatie. In dit onderwerp introduceren we deze functie, inclusief hoe u notities kunt verwijderen en hoe u een stijl kunt toepassen op notitieslides in een presentatie. Aspose.Slides stelt u in staat om notities van elke dia te verwijderen en ook opmaak toe te passen op bestaande notities. Ontwikkelaars kunnen notities op de volgende manieren verwijderen:

- Notities verwijderen van een specifieke dia in een presentatie.
- Notities verwijderen van alle dia's in een presentatie.

## **Notities verwijderen van een dia**
Notities van een specifieke dia kunnen worden verwijderd zoals weergegeven in het onderstaande voorbeeld:

```java
// Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Notities van de eerste dia verwijderen
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Presentatie opslaan naar schijf
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Notities verwijderen uit een presentatie**
Notities van alle dia's van een presentatie kunnen worden verwijderd zoals weergegeven in het onderstaande voorbeeld:

```java
// Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Notities van alle dia's verwijderen
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Presentatie opslaan naar schijf
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een notitiestijl toevoegen**
De [getNotesStyle](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) methode is toegevoegd aan de interface [IMasterNotesSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IMasterNotesSlide) en de klasse [MasterNotesSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/MasterNotesSlide) respectievelijk. Deze eigenschap geeft de stijl van een notitietekst aan. De implementatie wordt gedemonstreerd in het onderstaande voorbeeld.

```java
// Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Verkrijg de tekststijl van de MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Stel een symbool bullet in voor de alinea's op het eerste niveau
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Welke API‑entity biedt toegang tot de notities van een specifieke dia?**

Notities worden benaderd via de notitie‑manager van de dia: de dia heeft een [NotesSlideManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/notesslidemanager/) en een [method](https://reference.aspose.com/slides/nl/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) die het notitie‑object retourneert, of `null` als er geen notities zijn.

**Zijn er verschillen in notitieondersteuning tussen de PowerPoint‑versies waarmee de bibliotheek werkt?**

De bibliotheek richt zich op een breed scala aan Microsoft PowerPoint‑formaten (97‑en nieuwer) en ODP; notities worden ondersteund in deze formaten zonder dat er een geïnstalleerde kopie van PowerPoint nodig is.