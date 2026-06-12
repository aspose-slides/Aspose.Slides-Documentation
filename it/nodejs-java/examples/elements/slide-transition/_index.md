---
title: Transizione di Diapositiva
type: docs
weight: 110
url: /it/nodejs-java/examples/elements/slide-transition/
keywords:
- esempio di codice
- transizione di diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci le transizioni diapositive in Aspose.Slides per Node.js: aggiungi, personalizza e sequenzia effetti e durate con esempi per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come applicare effetti di transizione delle diapositive e tempi con **Aspose.Slides for Node.js via Java**.

## **Aggiungi una transizione di diapositiva**

Applica un effetto di transizione dissolvenza alla prima diapositiva.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Applica una transizione di dissolvenza.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a una transizione di diapositiva**

Leggi il tipo di transizione attualmente assegnato a una diapositiva.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Accedi al tipo di transizione.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi una transizione di diapositiva**

Rimuovi qualsiasi effetto di transizione impostando il tipo su `None`.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Rimuovi la transizione impostandola su None.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Imposta la durata della transizione**

Specifica per quanto tempo la diapositiva viene visualizzata prima di avanzare automaticamente.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // in millisecondi.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```