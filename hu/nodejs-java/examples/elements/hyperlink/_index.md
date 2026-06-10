---
title: Hiperhivatkozás
type: docs
weight: 130
url: /hu/nodejs-java/examples/elements/hyperlink/
keywords:
- kódrészlet
- hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása és kezelése az Aspose.Slides for Node.js-ben: szöveg, alakzatok és képek, célok és műveletek beállítása PPT, PPTX és ODP esetén példákkal."
---
Ez a cikk bemutatja a hiperhivatkozások hozzáadását, elérését, eltávolítását és frissítését alakzatokon a **Aspose.Slides for Node.js via Java** használatával.

## **Hiperhivatkozás hozzáadása**

Hozzon létre egy téglalap alakzatot, amely egy külső weboldalra mutató hiperhivatkozással rendelkezik.

```js
function addHyperlink() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = new aspose.slides.Hyperlink("https://www.aspose.com");
        textPortion.getPortionFormat().setHyperlinkClick(hyperlink);

        presentation.save("hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Hiperhivatkozás elérése**

Olvassa el a hiperhivatkozást az alakzat szövegrészéből.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezve, hogy az első alakzat a hiperhivatkozást tartalmazó szöveget tartalmaz.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Hiperhivatkozás eltávolítása**

Távolítsa el a hiperhivatkozást az alakzat szövegéből.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezve, hogy az első alakzat a hiperhivatkozást tartalmazó szöveget tartalmaz.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setHyperlinkClick(null);

        presentation.save("hyperlink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Hiperhivatkozás frissítése**

Módosítsa egy meglévő hiperhivatkozás célját. Használja a `HyperlinkManager`-t a már hiperhivatkozást tartalmazó szöveg módosításához, amely a PowerPoint hiperhivatkozásainak biztonságos frissítését imitálja.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezve, hogy az első alakzat a hiperhivatkozást tartalmazó szöveget tartalmaz.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // Meglévő szövegben lévő hiperhivatkozás módosítását a következővel kell elvégezni:
        // a HyperlinkManager-rel, ahelyett, hogy közvetlenül állítaná be a tulajdonságot.
        // Ez a PowerPoint módjára utánozza a hiperhivatkozások biztonságos frissítését.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```