---
title: Mesterdia
type: docs
weight: 30
url: /hu/nodejs-java/examples/elements/master-slide/
keywords:
- kódrészlet
- mesterdia
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Node.js mesterdia példákat: hozzon létre, szerkesszen és formázzon mestereket, helyfoglalókat és témákat PPT, PPTX és ODP formátumban egyértelmű kóddal."
---
A mesterdiák a diaöröklési hierarchia legfelső szintjét alkotják a PowerPointban. Egy **mesterdia** közös tervezési elemeket határoz meg, például háttérképeket, logókat és szövegformázást. **Elrendezési diák** öröklik a mesterdiákat, és **normál diák** öröklik az elrendezési diát.

Ez a cikk bemutatja, hogyan hozhatunk létre, módosíthatunk és kezelhetünk mesterdiákat az Aspose.Slides for Node.js via Java használatával.

## **Mesterdia hozzáadása**

Ez a példa azt mutatja be, hogyan hozhatunk létre egy új mesterdiát az alapértelmezett klónozásával. Ezután egy vállalati névfeliratot ad hozzá az összes diára az elrendezési öröklődésen keresztül.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Klónozza az alapértelmezett mesterdiát.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // Adjon hozzá egy vállalati névfeliratot a mesterdia tetejére.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // Rendelje hozzá az új mesterdiát egy elrendezési diához.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Rendelje hozzá az elrendezési diát a bemutató első diájához.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Megjegyzés 1:** A mesterdiák lehetővé teszik a konzisztens márka vagy közös tervezési elemek alkalmazását az összes dián. A mesterben végzett módosítások automatikusan megjelennek a kapcsolódó elrendezési és normál diákon.

> 💡 **Megjegyzés 2:** A mesterdiára hozzáadott alakzatok vagy formázások öröklődnek az elrendezési diákra, és továbbá az azokhoz tartozó normál diákra.
> Az alábbi kép szemlélteti, hogyan jelenik meg automatikusan egy mesterdiára felvett szövegdoboz a végső dián.

![Master Inheritance Example](master-slide-banner.png)

## **Mesterdia elérése**

A mesterdiák a bemutató mestergyűjteményén keresztül érhetők el. Íme, hogyan kérhetők le és használhatók:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // Változtassa meg a háttér típusát.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Mesterdia eltávolítása**

A mesterdiák eltávolíthatók index vagy hivatkozás alapján.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Távolítson el egy mesterdia index alapján.
        presentation.getMasters().removeAt(0);

        // Távolítson el egy mesterdia hivatkozás alapján.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Használaton kívüli mesterdiák eltávolítása**

Egyes bemutatók tartalmaznak használaton kívüli mesterdiákat. Ezek eltávolítása csökkentheti a fájlméretet.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Távolítsa el az összes használaton kívüli mesterdiát (még a Megőrzésként megjelölt diákat is).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```