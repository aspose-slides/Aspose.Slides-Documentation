---
title: Beheer presentatienotities op Android
linktitle: Presentatienotities
type: docs
weight: 110
url: /nl/androidjava/presentation-notes/
keywords:
- notities
- notitieslide
- notities toevoegen
- notities verwijderen
- notitiestijl
- masternotities
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Pas presentatienotities aan met Aspose.Slides voor Android via Java. Werk naadloos met PowerPoint- en OpenDocument-notities om uw productiviteit te verhogen."
---
## **Overzicht**

Aspose.Slides ondersteunt het verwijderen van notitie‑slides uit een presentatie. In dit onderwerp introduceren we deze functie, inclusief hoe je notities verwijdert en hoe je een stijl toepast op notitie‑slides in een presentatie. Aspose.Slides stelt je in staat notities van elke slide te verwijderen en ook opmaak toe te passen op bestaande notities. Ontwikkelaars kunnen notities op de volgende manieren verwijderen:

- Verwijder notities van een specifieke slide in een presentatie.
- Verwijder notities van alle slides in een presentatie.

## **Notities van een slide verwijderen**
Notities van een bepaalde slide kunnen verwijderd worden zoals getoond in het voorbeeld hieronder:

```java
// Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Notities van de eerste slide verwijderen
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Presentatie opslaan op de schijf
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Notities van een presentatie verwijderen**
Notities van alle slides van een presentatie kunnen verwijderd worden zoals getoond in het voorbeeld hieronder:

```java
// Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Notities van alle slides verwijderen
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Presentatie opslaan op de schijf
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een notitiestijl toevoegen**
[getNotesStyle](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) methode is toegevoegd aan [IMasterNotesSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IMasterNotesSlide) interface en [MasterNotesSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/MasterNotesSlide) klasse respectievelijk. Deze eigenschap specificeert de stijl van een notitietekst. De implementatie wordt gedemonstreerd in het voorbeeld hieronder.

```java
// Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Haal de tekststijl van de MasterNotesSlide op
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Set symboolbullet voor alinea's van het eerste niveau
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Welke API‑entiteit biedt toegang tot de notities van een specifieke slide?**

Notities worden benaderd via de notitiemanager van de slide: de slide heeft een [NotesSlideManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/notesslidemanager/) en een [method](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) die het notitie‑object retourneert, of `null` als er geen notities zijn.

**Zijn er verschillen in notitie‑ondersteuning tussen de verschillende PowerPoint‑versies waarvoor de bibliotheek werkt?**

De bibliotheek richt zich op een breed scala aan Microsoft PowerPoint‑formaten (97–nieuwer) en ODP; notities worden ondersteund in deze formaten zonder dat er een geïnstalleerde kopie van PowerPoint nodig is.