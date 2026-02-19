---
title: Folienübergang
type: docs
weight: 110
url: /de/nodejs-java/examples/elements/slide-transition/
keywords:
- Codebeispiel
- Folienübergang
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Meistern Sie Folienübergänge in Aspose.Slides für Node.js: Fügen Sie Effekte und Zeitdauern hinzu, passen Sie sie an und sequenzieren Sie sie mit Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert die Anwendung von Folienübergangseffekten und Zeitabfolgen mit **Aspose.Slides for Node.js via Java**.

## **Folienübergang hinzufügen**

Wenden Sie einen Fade‑Übergangseffekt auf die erste Folie an.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Fade-Übergang anwenden.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Zugriff auf einen Folienübergang**

Lesen Sie den aktuell einer Folie zugewiesenen Übergangstyp.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zugriff auf den Übergangstyp.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Folienübergang entfernen**

Entfernen Sie alle Übergangseffekte, indem Sie den Typ auf `None` setzen.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Übergang entfernen, indem None gesetzt wird.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Übergangsdauer festlegen**

Geben Sie an, wie lange die Folie angezeigt wird, bevor sie automatisch weitergeht.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // in Millisekunden.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```