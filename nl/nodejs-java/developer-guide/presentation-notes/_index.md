---
title: Beheer presentatienotities in JavaScript
linktitle: Presentatienotities
type: docs
weight: 110
url: /nl/nodejs-java/presentation-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Pas presentatienotities aan in JavaScript met Aspose.Slides voor Node.js. Werk moeiteloos met PowerPoint- en OpenDocument-notities om uw productiviteit te verhogen."
---
## **Overzicht**

Aspose.Slides ondersteunt het verwijderen van notitieslides uit een presentatie. In dit onderwerp introduceren we deze functie, inclusief hoe notities te verwijderen en hoe een stijl toe te passen op notitieslides in een presentatie. Aspose.Slides stelt u in staat notities van elke dia te verwijderen en ook opmaak toe te passen op bestaande notities. Ontwikkelaars kunnen notities op de volgende manieren verwijderen:

- Verwijder notities van een specifieke dia in een presentatie.
- Verwijder notities van alle dia's in een presentatie.

Om de afmetingen van de notitiepagina te lezen of te wijzigen, de oriëntatie te wijzigen en het exportgedrag te controleren, zie [Notes Page Size](/slides/nl/nodejs-java/notes-size/).

## **Notities van een dia verwijderen**
Notities van een specifieke dia kunnen worden verwijderd zoals getoond in het voorbeeld hieronder:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieer een Presentation-object dat een presentatiebestand voorstelt
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Notities van de eerste dia verwijderen
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Presentatie opslaan op schijf
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Notities van een presentatie verwijderen**
Notities van alle dia's in een presentatie kunnen worden verwijderd zoals getoond in het voorbeeld hieronder:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieer een Presentation-object dat een presentatiebestand voorstelt
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Notities van alle dia's verwijderen
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Presentatie opslaan op schijf
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **NotesStyle toevoegen**
[getNotesStyle](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) methode is toegevoegd aan de [MasterNotesSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/MasterNotesSlide) klasse en respectievelijk aan de [MasterNotesSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/MasterNotesSlide) klasse. Deze eigenschap specificeert de stijl van een notitstekst. De implementatie wordt gedemonstreerd in het voorbeeld hieronder.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieer een Presentation-object dat een presentatiebestand voorstelt
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Haal de tekststijl van de MasterNotesSlide op
        var notesStyle = notesMaster.getNotesStyle();
        // Stel symboolbullet in voor de alinea's op het eerste niveau
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Welke API‑entiteit biedt toegang tot de notities van een specifieke dia?**

Notities worden benaderd via de notities‑manager van de dia: de dia heeft een [NotesSlideManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notesslidemanager/) en een [method](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) die het notitie‑object teruggeeft, of `null` als er geen notities zijn.

**Zijn er verschillen in notitie‑ondersteuning tussen de PowerPoint‑versies waarmee de bibliotheek werkt?**

De bibliotheek richt zich op een breed scala aan Microsoft PowerPoint‑formaten (97‑en nieuwer) en ODP; notities worden ondersteund in deze formaten zonder afhankelijk te zijn van een geïnstalleerde kopie van PowerPoint.