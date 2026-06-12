---
title: Snímek
type: docs
weight: 10
url: /cs/nodejs-java/examples/elements/slide/
keywords:
- ukázka kódu
- snímek
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Ovládejte snímky v Aspose.Slides pro Node.js: vytvářejte, klonujte, přeskupujte, měňte velikost, nastavujte pozadí a aplikujte přechody pro prezentace PPT, PPTX a ODP."
---
Tento článek poskytuje řadu příkladů, které ukazují, jak pracovat s snímky pomocí **Aspose.Slides for Node.js via Java**. Naučíte se, jak přidávat, přistupovat, klonovat, přeskupovat a odstraňovat snímky pomocí třídy `Presentation`.

Každý příklad níže obsahuje stručné vysvětlení následované úryvkem kódu v JavaScriptu.

## **Přidat snímek**

Pro přidání nového snímku musíte nejprve vybrat rozložení. V tomto příkladu používáme rozložení `Blank` a přidáváme prázdný snímek do prezentace.

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

> 💡 **Poznámka:** Každé rozložení snímku je odvozeno od hlavního snímku, který určuje celkový design a strukturu zástupných prvků. Níže uvedený obrázek ilustruje, jak jsou hlavní snímky a jejich přidružená rozložení v PowerPointu organizována.

![Vztah mezi hlavním snímkem a rozložením](master-layout-slide.png)

## **Přístup k snímkům podle indexu**

K snímkům můžete přistupovat pomocí jejich indexu. To je užitečné při procházení nebo úpravě konkrétních snímků.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Přístup k snímku podle indexu.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Klonovat snímek**

Tento příklad demonstruje, jak klonovat existující snímek. Klonovaný snímek je automaticky přidán na konec kolekce snímků.

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

## **Přeskupit snímky**

Pořadí snímků můžete změnit přesunutím jednoho na nový index. V tomto případě přesuneme snímek na první pozici.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Přeskupit snímky přesunutím druhého snímku na první pozici.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit snímek**

Pro odstranění snímku jej jednoduše odkažte a zavolejte `remove`. Tento příklad přidá druhý snímek a poté odstraní původní, takže zůstane jen nový.

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