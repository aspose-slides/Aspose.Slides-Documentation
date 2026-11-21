---
title: Beheer presentatienotities in Java
linktitle: Presentatienotities
type: docs
weight: 110
url: /nl/java/presentation-notes/
keywords:
- notities
- notitieslide
- notities toevoegen
- notities verwijderen
- notitiestijl
- hoofnotities
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Pas presentatienotities aan met Aspose.Slides voor Java. Werk naadloos met PowerPoint- en OpenDocument-notities om uw productiviteit te verhogen."
---
## **Overzicht**

Aspose.Slides ondersteunt het verwijderen van notitieslides uit een presentatie. In dit onderwerp introduceren we deze functie, inclusief hoe notities te verwijderen en hoe een stijl toe te passen op notitieslides in een presentatie. Aspose.Slides maakt het mogelijk notities van elke dia te verwijderen en ook styling toe te passen op bestaande notities. Ontwikkelaars kunnen notities op de volgende manieren verwijderen:

- Verwijder notities van een specifieke dia in een presentatie.
- Verwijder notities van alle dia’s in een presentatie.

Om de afmetingen van de notitiepagina te lezen of te wijzigen, de oriëntatie om te schakelen en het exportgedrag te controleren, zie [Notitiepaginaformaat](/slides/nl/java/notes-size/).

## **Notities van een dia verwijderen**
Notities van een specifieke dia kunnen worden verwijderd zoals getoond in het onderstaande voorbeeld:

```java
import com.aspose.slides.*;

// Maak een Presentation-object aan dat een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Notities van de eerste dia verwijderen
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Presentatie opslaan op schijf
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Notities uit een presentatie verwijderen**
Notities van alle dia’s in een presentatie kunnen worden verwijderd zoals getoond in het onderstaande voorbeeld:

```java
import com.aspose.slides.*;

// Maak een Presentation-object aan dat een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Notities van alle dia’s verwijderen
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Presentatie opslaan op schijf
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een notitiestijl toevoegen**
[getNotesStyle](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--)‑methode is toegevoegd aan de interface [IMasterNotesSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IMasterNotesSlide) en de klasse [MasterNotesSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/MasterNotesSlide) respectievelijk. Deze eigenschap specificeert de stijl van notitietekst. De implementatie wordt gedemonstreerd in het onderstaande voorbeeld.

```java
import com.aspose.slides.*;

// Maak een Presentation-object aan dat een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Haal de tekststijl van MasterNotesSlide op
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Stel een symboolkogel in voor de alinea's van het eerste niveau
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

Notities worden benaderd via de notities‑manager van de dia: de dia heeft een [NotesSlideManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/notesslidemanager/) en een [method](https://reference.aspose.com/slides/nl/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) die het notitiesobject retourneert, of `null` als er geen notities zijn.

**Zijn er verschillen in notitie‑ondersteuning tussen de PowerPoint‑versies waarmee de bibliotheek werkt?**

De bibliotheek richt zich op een breed scala aan Microsoft PowerPoint‑formaten (97‑en nieuwer) en ODP; notities worden ondersteund in deze formaten zonder dat er een geïnstalleerde kopie van PowerPoint nodig is.