---
title: Diaovergang
type: docs
weight: 110
url: /nl/nodejs-java/examples/elements/slide-transition/
keywords:
- codevoorbeeld
- diaovergang
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheers diaovergangen in Aspose.Slides voor Node.js: voeg toe, pas aan en plaats effect‑ en duurreeksen met voorbeelden voor PPT‑, PPTX‑ en ODP‑presentaties."
---
Dit artikel laat zien hoe u overgangseffecten en timing voor dia's kunt toepassen met **Aspose.Slides for Node.js via Java**.

## **Diaovergang toevoegen**

Pas een vervaging overgangseffect toe op de eerste dia.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Pas een vervagingsovergang toe.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Toegang tot een diaovergang**

Lees het overgangstype dat momenteel aan een dia is toegewezen.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Toegang tot het overgangstype.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Diaovergang verwijderen**

Verwijder elk overgangseffect door het type op `None` in te stellen.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Verwijder overgang door none in te stellen.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Overgangsduur instellen**

Geef aan hoe lang de dia wordt getoond voordat deze automatisch wordt voortgezet.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // in milliseconden.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```