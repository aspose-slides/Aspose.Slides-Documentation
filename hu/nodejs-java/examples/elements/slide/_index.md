---
title: Dia
type: docs
weight: 10
url: /hu/nodejs-java/examples/elements/slide/
keywords:
- kód példa
- dia
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Diák kezelése az Aspose.Slides for Node.js segítségével: létrehozás, klónozás, átrendezés, átméretezés, háttér beállítása, és áttűnések alkalmazása PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk példákat mutat be, amelyek szemléltetik, hogyan dolgozhatunk diák használatával a **Aspose.Slides for Node.js via Java** segítségével. Megtanulja, hogyan adhat hozzá, érhet el, klónozhat, átrendezhet és távolíthat el diákat a `Presentation` osztály használatával.

Az alábbi minden példa rövid magyarázatot tartalmaz, majd egy JavaScript kódrészletet.

## **Dia hozzáadása**

Új dia hozzáadásához először ki kell választani egy elrendezést. Ebben a példában a `Blank` elrendezést használjuk, és egy üres diát adunk a bemutatóhoz.

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

> 💡 **Megjegyzés:** Minden diával elrendezés egy mester diából származik, amely meghatározza az általános dizájnt és a helyőrző struktúrát. Az alábbi kép szemlélteti, hogyan vannak szervezve a mester diák és a hozzájuk tartozó elrendezések a PowerPointban.

![Mester és elrendezés kapcsolata](master-layout-slide.png)

## **Diák elérése index szerint**

Az indexük használatával elérhetők a diák. Ez hasznos a diák bejárásához vagy egyes diák módosításához.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Diához index alapján fér hozzá.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Dia klónozása**

Ezzel a példával bemutatjuk, hogyan lehet klónozni egy meglévő diát. A klónozott dia automatikusan a dia gyűjtemény végére kerül.

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

## **Diák újrarendezése**

A diák sorrendjét megváltoztathatjuk egy diát egy új indexre mozgatva. Ebben az esetben egy diát az első pozícióba helyezzük.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Diák átrendezése a második dia első pozícióba mozgatásával.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Dia eltávolítása**

Egy dia eltávolításához egyszerűen hivatkozzunk rá, és hívjuk a `remove` metódust. Ez a példa hozzáad egy második diát, majd eltávolítja az eredetit, csak az újat hagyva meg.

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