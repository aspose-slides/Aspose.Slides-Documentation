---
title: Bild
type: docs
weight: 10
url: /sv/nodejs-java/examples/elements/slide/
keywords:
- kodexempel
- bild
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Styr bilder i Aspose.Slides för Node.js: skapa, klona, omordna, ändra storlek, sätta bakgrunder och applicera övergångar för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln innehåller en serie exempel som visar hur du arbetar med bilder med **Aspose.Slides for Node.js via Java**. Du kommer att lära dig hur du lägger till, får åtkomst till, klonar, omordnar och tar bort bilder med hjälp av klassen `Presentation`.

Varje exempel nedan innehåller en kort förklaring följt av ett kodavsnitt i JavaScript.

## **Lägg till en bild**

För att lägga till en ny bild måste du först välja en layout. I det här exemplet använder vi layouten `Blank` och lägger till en tom bild i presentationen.

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

> 💡 **Obs:** Varje bildlayout härstammar från en huvudbild, som definierar den övergripande designen och platshållarstrukturen. Bilden nedan visar hur huvudbilder och deras tillhörande layouter organiseras i PowerPoint.

![Relation mellan huvudbild och layout](master-layout-slide.png)

## **Åtkomst till bilder via index**

Du kan få åtkomst till bilder med hjälp av deras index. Detta är användbart för att iterera igenom eller ändra specifika bilder.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Åtkomst till en bild via index.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Klona en bild**

Det här exemplet visar hur du klonar en befintlig bild. Den klonade bilden läggs automatiskt till i slutet av bildsamlingen.

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

## **Omordna bilder**

Du kan ändra ordningen på bilder genom att flytta en till ett nytt index. I detta fall flyttar vi en bild till den första positionen.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Ordna om bilder genom att flytta den andra bilden till första positionen.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort en bild**

För att ta bort en bild, referera helt enkelt till den och anropa `remove`. Detta exempel lägger till en andra bild och tar sedan bort den ursprungliga, så att bara den nya återstår.

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