---
title: Beheer presentatienotities op Android
linktitle: Presentatienotities
type: docs
weight: 110
url: /nl/androidjava/presentation-notes/
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
- Android
- Java
- Aspose.Slides
description: "Pas presentatienotities aan met Aspose.Slides voor Android via Java. Werk moeiteloos met PowerPoint- en OpenDocument-notities om uw productiviteit te verhogen."
---
## **Overzicht**

Aspose.Slides ondersteunt het verwijderen van notitieslides uit een presentatie. In dit onderwerp introduceren we deze functionaliteit, inclusief hoe u notities verwijdert en hoe u een stijl toepast op notitieslides in een presentatie. Aspose.Slides stelt u in staat notities van elke dia te verwijderen en tevens stijlen toe te passen op bestaande notities. Ontwikkelaars kunnen notities op de volgende manieren verwijderen:

- Notities van een specifieke dia in een presentatie verwijderen.
- Notities van alle dia’s in een presentatie verwijderen.

Om de afmetingen van de notitiepagina te lezen of te wijzigen, de oriëntatie te wijzigen en het exportgedrag te controleren, zie [Notes Page Size](/slides/nl/androidjava/notes-size/).

## **Notities van een dia verwijderen**
Notities van een specifieke dia kunnen worden verwijderd zoals getoond in het onderstaande voorbeeld:

```java
import com.aspose.slides.*;

// Instantieer een Presentation‑object dat een presentatie‑bestand voorstelt
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

## **Notities van een presentatie verwijderen**
Notities van alle dia’s in een presentatie kunnen worden verwijderd zoals getoond in het onderstaande voorbeeld:

```java
import com.aspose.slides.*;

// Instantieer een Presentation‑object dat een presentatie‑bestand voorstelt
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Notities van alle dia's verwijderen
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
[getNotesStyle](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--)‑methode is toegevoegd aan de [IMasterNotesSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IMasterNotesSlide)‑interface en de [MasterNotesSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/MasterNotesSlide)‑klasse respectievelijk. Deze eigenschap geeft de stijl van een notitietekst aan. De implementatie wordt gedemonstreerd in het onderstaande voorbeeld.

```java
import com.aspose.slides.*;

// Instantieer een Presentation object dat een presentatie bestand voorstelt
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Haal de tekststijl van MasterNotesSlide op
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Stel symboolkogel in voor de alinea's van het eerste niveau
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Welke API‑entiteit biedt toegang tot de notities van een specifieke dia?**

Notities worden benaderd via de notitiemanager van de dia: de dia heeft een [NotesSlideManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/notesslidemanager/) en een [method](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) die het notitie‑object retourneert, of `null` als er geen notities zijn.

**Zijn er verschillen in notitie‑ondersteuning tussen de PowerPoint‑versies waarmee de bibliotheek werkt?**

De bibliotheek richt zich op een breed scala aan Microsoft PowerPoint‑formaten (97‑en nieuwer) en ODP; notities worden ondersteund in deze formaten zonder dat een geïnstalleerde copy van PowerPoint nodig is.