---
title: Hyperlink
type: docs
weight: 130
url: /nl/nodejs-java/examples/elements/hyperlink/
keywords:
- codevoorbeeld
- hyperlink
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Voeg hyperlinks toe en beheer ze in Aspose.Slides voor Node.js: koppel tekst, vormen en afbeeldingen, stel doelen en acties in voor PPT, PPTX en ODP met voorbeelden."
---
Dit artikel toont hoe u hyperlinks op vormen kunt toevoegen, benaderen, verwijderen en bijwerken met behulp van **Aspose.Slides for Node.js via Java**.

## **Hyperlink toevoegen**

Maak een rechthoekige vorm met een hyperlink die verwijst naar een externe website.

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

## **Hyperlink benaderen**

Lees de hyperlink uit een tekstgedeelte van een vorm.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Aannemende dat de eerste vorm de tekst met hyperlink bevat.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Hyperlink verwijderen**

Verwijder de hyperlink uit de tekst van een vorm.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Aannemende dat de eerste vorm de tekst met hyperlink bevat.
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

## **Hyperlink bijwerken**

Wijzig het doel van een bestaande hyperlink. Gebruik `HyperlinkManager` om tekst die al een hyperlink bevat te wijzigen, wat nabootst hoe PowerPoint hyperlinks veilig bijwerkt.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Aannemende dat de eerste vorm de tekst met hyperlink bevat.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // Een hyperlink in bestaande tekst wijzigen moet gebeuren via
        // HyperlinkManager in plaats van de eigenschap rechtstreeks in te stellen.
        // Dit bootst na hoe PowerPoint hyperlinks veilig bijwerkt.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```