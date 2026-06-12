---
title: Dia
type: docs
weight: 10
url: /nl/nodejs-java/examples/elements/slide/
keywords:
- codevoorbeeld
- dia
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer dia's in Aspose.Slides for Node.js: maak, kloon, herschik, wijzig de grootte, stel achtergronden in en pas overgangen toe voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel biedt een reeks voorbeelden die laten zien hoe u met dia's kunt werken met **Aspose.Slides for Node.js via Java**. U leert hoe u dia's kunt toevoegen, benaderen, klonen, opnieuw ordenen en verwijderen met behulp van de `Presentation`-klasse.

Elk voorbeeld hieronder bevat een korte uitleg, gevolgd door een codefragment in JavaScript.

## **Dia toevoegen**

Om een nieuwe dia toe te voegen, moet u eerst een lay-out selecteren. In dit voorbeeld gebruiken we de `Blank`-lay-out en voegen we een lege dia toe aan de presentatie.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Opmerking:** Elke dia-lay-out is afgeleid van een master-dia, die het algemene ontwerp en de structuur van tijdelijke aanduidingen definieert. De afbeelding hieronder illustreert hoe master-dia's en hun bijbehorende lay-outs zijn georganiseerd in PowerPoint.

![Relatie tussen master en lay-out](master-layout-slide.png)

## **Dia's benaderen op index**

U kunt dia's benaderen met behulp van hun index. Dit is handig om door dia's te itereren of specifieke dia's te wijzigen.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Toegang tot een dia op index.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Kloon een dia**

Dit voorbeeld toont hoe u een bestaande dia kunt klonen. De gekloonde dia wordt automatisch toegevoegd aan het einde van de dia-collectie.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Dia's opnieuw ordenen**

U kunt de volgorde van dia's wijzigen door er een naar een nieuwe index te verplaatsen. In dit geval verplaatsen we een dia naar de eerste positie.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Dia's opnieuw ordenen door de tweede dia naar de eerste positie te verplaatsen.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Dia verwijderen**

Om een dia te verwijderen, verwijst u er simpelweg naar en roept u `remove` aan. Dit voorbeeld voegt een tweede dia toe en verwijdert vervolgens de oorspronkelijke, waardoor alleen de nieuwe overblijft.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```