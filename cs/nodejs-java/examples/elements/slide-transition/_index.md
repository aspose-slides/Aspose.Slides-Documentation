---
title: Přechod snímku
type: docs
weight: 110
url: /cs/nodejs-java/examples/elements/slide-transition/
keywords:
- příklad kódu
- přechod snímku
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Ovládejte přechody snímků v Aspose.Slides pro Node.js: přidávejte, přizpůsobujte a řaďte efekty a jejich trvání pomocí příkladů pro prezentace PPT, PPTX a ODP."
---
Tento článek demonstruje použití efektů přechodu snímků a časování s **Aspose.Slides for Node.js via Java**.

## **Přidat přechod snímku**

Použijte efekt postupného přechodu na první snímek.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Použít přechod typu zhasnutí.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k přechodu snímku**

Přečtěte typ přechodu aktuálně přiřazený ke snímku.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Přístup k typu přechodu.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit přechod snímku**

Vymažte jakýkoli efekt přechodu nastavením typu na `None`.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Odstranit přechod nastavením None.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Nastavit dobu trvání přechodu**

Určete, jak dlouho je snímek zobrazen před automatickým přechodem.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // v milisekundách.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```