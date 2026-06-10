---
title: Diátmenet
type: docs
weight: 110
url: /hu/nodejs-java/examples/elements/slide-transition/
keywords:
- kód példa
- diátmenet
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg a diátmenetek kezelését az Aspose.Slides for Node.js-ben: hozzáadás, testreszabás és a hatások és időtartamok sorozatba rendezése PPT, PPTX és ODP prezentációk példáival."
---
Ez a cikk bemutatja a diákátmeneti hatások és időzítések alkalmazását az **Aspose.Slides for Node.js via Java** használatával.

## **Diákátmenet hozzáadása**

Alkalmazzon elhalványuló átmeneti hatást az első diára.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Alkalmazzon elhalványuló átmenetet.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Diákátmenet elérése**

Olvassa el a diára jelenleg beállított átmenet típusát.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Hozzáférés az átmenet típusához.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Diákátmenet eltávolítása**

Törölje az összes átmeneti hatást a típus `None` beállításával.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Az átmenet eltávolítása a None beállításával.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Átmenet időtartamának beállítása**

Adja meg, mennyi ideig jelenjen meg a dia, mielőtt automatikusan tovább lép.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // ezredmásodpercben.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```