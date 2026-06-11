---
title: Hyperlänk
type: docs
weight: 130
url: /sv/nodejs-java/examples/elements/hyperlink/
keywords:
- kodexempel
- hyperlänk
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lägg till och hantera hyperlänkar i Aspose.Slides för Node.js: länka text, former och bilder, ange mål och åtgärder för PPT, PPTX och ODP med exempel."
---
Denna artikel demonstrerar hur man lägger till, får åtkomst till, tar bort och uppdaterar hyperlänkar på former med hjälp av **Aspose.Slides for Node.js via Java**.

## **Add a Hyperlink**
Skapa en rektangelform med en hyperlänk som pekar på en extern webbplats.

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

## **Access a Hyperlink**
Läs hyperlänken från en forms textavsnitt.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Antar att den första formen innehåller texten med hyperlänk.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Hyperlink**
Rensa hyperlänken från en forms text.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Antar att den första formen innehåller texten med hyperlänk.
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

## **Update a Hyperlink**
Ändra målet för en befintlig hyperlänk. Använd `HyperlinkManager` för att modifiera text som redan innehåller en hyperlänk, vilket efterliknar hur PowerPoint uppdaterar hyperlänkar säkert.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Antar att den första formen innehåller texten med hyperlänk.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // Att ändra en hyperlänk i befintlig text bör göras via
        // HyperlinkManager snarare än att sätta egenskapen direkt.
        // Detta efterliknar hur PowerPoint säkert uppdaterar hyperlänkar.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```