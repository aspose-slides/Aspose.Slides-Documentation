---
title: Hypertextový odkaz
type: docs
weight: 130
url: /cs/nodejs-java/examples/elements/hyperlink/
keywords:
- příklad kódu
- hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Přidejte a spravujte hypertextové odkazy v Aspose.Slides pro Node.js: propojte text, tvary a obrázky, nastavte cíle a akce pro PPT, PPTX a ODP s příklady."
---
Tento článek demonstruje přidávání, přístupu, odstraňování a aktualizaci hypertextových odkazů na tvarech pomocí **Aspose.Slides for Node.js via Java**.

## **Přidání hypertextového odkazu**

Vytvořte obdélníkový tvar s hypertextovým odkazem směřujícím na externí webovou stránku.

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

## **Přístup k hypertextovému odkazu**

Přečtěte hypertextový odkaz z textové části tvaru.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Předpokládáme, že první tvar obsahuje text s hypertextovým odkazem.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranění hypertextového odkazu**

Odstraňte hypertextový odkaz z textu tvaru.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Předpokládáme, že první tvar obsahuje text s hypertextovým odkazem.
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

## **Aktualizace hypertextového odkazu**

Změňte cíl existujícího hypertextového odkazu. Použijte `HyperlinkManager` k úpravě textu, který již obsahuje hypertextový odkaz, což napodobuje způsob, jakým PowerPoint bezpečně aktualizuje hypertextové odkazy.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Předpokládáme, že první tvar obsahuje text s hypertextovým odkazem.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // Změna hypertextového odkazu v existujícím textu by měla být provedena pomocí
        // HyperlinkManager namísto přímého nastavení vlastnosti.
        // To napodobuje, jak PowerPoint bezpečně aktualizuje hypertextové odkazy.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```