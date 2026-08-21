---
title: Hantera ritningsguider i presentationer i JavaScript
linktitle: Ritningsguider
type: docs
weight: 85
url: /sv/nodejs-java/drawing-guides/
keywords:
- ritningsguide
- horisontell guide
- vertikal guide
- justeringsguide
- bildvy
- masterbild
- layoutbild
- anteckningsmaster
- utdelningsmaster
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lägg till, hämta och rensa horisontella och vertikala ritningsguider i PowerPoint-presentationer med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Ritningsguider är justerbara horisontella och vertikala linjer som hjälper användare att justera former konsekvent när de redigerar en presentation i PowerPoint. De är särskilt användbara när ett program genererar en presentation som senare ska finjusteras manuellt: programmet kan spara samma justeringshjälpmedel som författare bör följa när de lägger till eller flyttar innehåll.

Ritningsguider är redigeringshjälpmedel, inte bildinnehåll. De visas inte i ett bildspel eller renderad output. Aspose.Slides för Node.js via Java exponerar dem via klassen [DrawingGuidesCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/drawingguidescollection/) . En guide representeras av [DrawingGuide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/drawingguide/) och har en orientering, en position och en färg.

Positionen mäts i punkter från det övre vänstra hörnet av den aktuella bilden eller mastern. En vertikal guide använder en horisontell koordinat, vanligtvis mellan noll och bildens bredd. En horisontell guide använder en vertikal koordinat, vanligtvis mellan noll och bildens höjd.

## **Lägg till guider i bildvyn**

Använd [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) för att hantera guider som visas medan du redigerar vanliga bilder. Anropa [DrawingGuidesCollection.add](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/drawingguidescollection/#add) med ett [Orientation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/orientation/)‑värde och en position i punkter.

Följande exempel lägger till en vertikal guide till höger om bildens centrum och en horisontell guide under den:

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

## **Åtkomst till ritningsguider**

Metoderna [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/drawingguidescollection/#getCount) och [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) ger åtkomst till befintliga guider. Metoderna [DrawingGuide.getOrientation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/drawingguide/#getPosition) och [DrawingGuide.getColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/drawingguide/#getColor) returnerar värden som också kan ändras via motsvarande setter‑metoder.

Följande exempel läser bild‑vye‑guiderna från presentationen som skapades ovan:

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

## **Lägg till guider i master‑ och layoutbilder**

En slide‑master och varje layout‑slide kan ha sina egna ritningsguide‑samlingar. Använd [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) för en master‑slide och [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) för en layout‑slide.

Följande exempel lägger till en vertikal guide till den första master‑sliden och en horisontell guide till den första layout‑sliden:

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

## **Lägg till guider i antecknings‑ och utdelnings‑mastrar**

Antecknings‑mastrar och utdelnings‑mastrar stödjer också ritningsguider. Använd [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) och [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) för att komma åt deras samlingar. Om en presentation saknar någon av dessa mastrar skapar `MasterNotesSlideManager.setDefaultMasterNotesSlide` eller `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` standard‑mastern och returnerar den.

Följande exempel lägger till en horisontell guide till en antecknings‑master och en vertikal guide till en utdelnings‑master:

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

## **Rensa ritningsguider**

Anropa [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/drawingguidescollection/#clear) för att ta bort alla guider från en viss samling. Att rensa en samling påverkar inte guider som lagras i en annan omfattning.

Följande exempel rensar bild‑vye‑guiderna samt alla guider på slide‑mastrar, layout‑slides, antecknings‑mastern och utdelnings‑mastern utan att skapa saknade mastrar:

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

**Visas ritningsguider i ett bildspel eller exporterade bilder?**

Nej. Ritningsguider är justeringshjälpmedel för redigering och renderas inte som presentationsinnehåll.

**Kan en ritningsguide läggas till direkt på en enskild normal bild?**

Redigeringsguider för normala bilder lagras i presentationens bild‑vye‑egenskaper. Separata guide‑samlingar finns för slide‑mastrar, layout‑bilder, antecknings‑mastrar och utdelnings‑mastrar.

**Vilka enheter används för guidepositioner?**

Positioner anges i punkter, där 72 punkter motsvarar en tum. Vertikala positioner mäts från vänster kant, och horisontella positioner mäts från övre kanten.

**Tar rensning av ritningsguider bort former eller ändrar bildens innehåll?**

Nej. Metoden [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/drawingguidescollection/#clear) tar bara bort guiden i den valda samlingen. Former och annat bildinnehåll förblir oförändrade.