---
title: Bildövergång
type: docs
weight: 110
url: /sv/nodejs-java/examples/elements/slide-transition/
keywords:
- kodexempel
- bildövergång
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Behärska bildövergångar i Aspose.Slides för Node.js: lägg till, anpassa och sekvensera effekter och varaktigheter med exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln demonstrerar hur man tillämpar bildövergångseffekter och tidsinställningar med **Aspose.Slides for Node.js via Java**.

## **Lägg till en bildövergång**

Applicera en toningsövergång på den första bilden.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Applicera en toningsövergång.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Åtkomst till en bildövergång**

Läs vilken övergångstyp som för närvarande är tilldelad en bild.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Åtkomst till övergångstypen.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort en bildövergång**

Rensa alla övergångseffekter genom att sätta typen till `None`.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Ta bort övergången genom att sätta none.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ange övergångstid**

Ange hur länge bilden visas innan den automatiskt går vidare.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // i millisekunder.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```