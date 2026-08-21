---
title: Beheren van tekenrichtlijnen in presentaties in JavaScript
linktitle: Tekenrichtlijnen
type: docs
weight: 85
url: /nl/nodejs-java/drawing-guides/
keywords:
- tekenrichtlijn
- horizontale richtlijn
- verticale richtlijn
- uitlijningsrichtlijn
- slideweergave
- master-slide
- layout-slide
- notitie-master
- handout-master
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Voeg horizontale en verticale tekenrichtlijnen toe, benader ze en verwijder ze in PowerPoint-presentaties met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Tekenrichtlijnen zijn verstelbare horizontale en verticale lijnen die gebruikers helpen vormen consequent uit te lijnen tijdens het bewerken van een presentatie in PowerPoint. Ze zijn vooral handig wanneer een applicatie een presentatie genereert die later handmatig wordt verfijnd: de applicatie kan dezelfde uitlijningshulpmiddelen opslaan die auteurs moeten volgen bij het toevoegen of verplaatsen van inhoud.

Tekenrichtlijnen zijn bewerkingshulpmiddelen, geen slide‑inhoud. Ze verschijnen niet in een diavoorstelling of gerenderde output. Aspose.Slides for Node.js via Java maakt ze beschikbaar via de [DrawingGuidesCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/drawingguidescollection/)‑klasse. Een richtlijn wordt weergegeven door [DrawingGuide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/drawingguide/) en heeft een oriëntatie, een positie en een kleur.

De positie wordt gemeten in punten vanaf de linkerbovenhoek van de betreffende slide of master. Een verticale richtlijn gebruikt een horizontale coördinaat, doorgaans tussen nul en de breedte van de slide. Een horizontale richtlijn gebruikt een verticale coördinaat, doorgaans tussen nul en de hoogte van de slide.

## **Richtlijnen toevoegen aan de slide‑weergave**

Gebruik [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) om richtlijnen te beheren die tijdens het bewerken van normale slides worden weergegeven. Roep [DrawingGuidesCollection.add](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/drawingguidescollection/#add) aan met een [Orientation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/orientation/)‑waarde en een positie in punten.

Het volgende voorbeeld voegt één verticale richtlijn toe rechts van het midden van de slide en één horizontale richtlijn eronder:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tekenrichtlijnen benaderen**

De methoden [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/drawingguidescollection/#getCount) en [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) geven toegang tot bestaande richtlijnen. De methoden [DrawingGuide.getOrientation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/drawingguide/#getPosition) en [DrawingGuide.getColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/drawingguide/#getColor) retourneren waarden die ook gewijzigd kunnen worden via de bijbehorende setter‑methoden.

Het volgende voorbeeld leest de slide‑view‑richtlijnen uit de hierboven gemaakte presentatie:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Richtlijnen toevoegen aan master‑ en layout‑slides**

Een slide‑master en elk van zijn layout‑slides kunnen hun eigen verzamelingen van tekenrichtlijnen hebben. Gebruik [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) voor een master‑slide en [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) voor een layout‑slide.

Het volgende voorbeeld voegt een verticale richtlijn toe aan de eerste master‑slide en een horizontale richtlijn aan de eerste layout‑slide:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Richtlijnen toevoegen aan notitie‑ en handout‑masters**

Notitie‑masters en handout‑masters ondersteunen ook tekenrichtlijnen. Gebruik [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) en [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) om hun verzamelingen te benaderen. Als een presentatie een van deze masters niet bevat, maakt `MasterNotesSlideManager.setDefaultMasterNotesSlide` of `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` de standaardmaster aan en retourneert deze.

Het volgende voorbeeld voegt een horizontale richtlijn toe aan een notitie‑master en een verticale richtlijn aan een handout‑master:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tekenrichtlijnen wissen**

Roep [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/drawingguidescollection/#clear) aan om alle richtlijnen uit een bepaalde collectie te verwijderen. Het wissen van één collectie heeft geen effect op richtlijnen die in een andere scope zijn opgeslagen.

Het volgende voorbeeld wist de slide‑view‑richtlijnen en alle richtlijnen op slide‑masters, layout‑slides, de notitie‑master en de handout‑master zonder ontbrekende masters aan te maken:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Verschijnen tekenrichtlijnen in een diavoorstelling of geëxporteerde afbeeldingen?**

Nee. Tekenrichtlijnen zijn uitlijningshulpmiddelen voor bewerking en worden niet gerenderd als presentatiewaarde.

**Kan een tekenrichtlijn direct aan een individuele normale slide worden toegevoegd?**

Normale slide‑bewerkingsrichtlijnen worden opgeslagen in de slide‑view‑eigenschappen van de presentatie. Er zijn aparte richtlijncollecties beschikbaar voor slide‑masters, layout‑slides, notitie‑masters en handout‑masters.

**Welke eenheden worden gebruikt voor de posities van richtlijnen?**

Posities worden opgegeven in punten, waarbij 72 punten gelijk zijn aan één duim. Verticale posities worden gemeten vanaf de linkerrand, en horizontale posities vanaf de bovenzijde.

**Verwijdert het wissen van tekenrichtlijnen vormen of verandert het slide‑inhoud?**

Nee. De methode [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/drawingguidescollection/#clear) verwijdert alleen de richtlijnen in de geselecteerde collectie. Vormen en andere slide‑inhoud blijven ongewijzigd.