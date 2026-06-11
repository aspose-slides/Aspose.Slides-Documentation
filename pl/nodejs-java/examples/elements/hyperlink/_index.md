---
title: Hiperłącze
type: docs
weight: 130
url: /pl/nodejs-java/examples/elements/hyperlink/
keywords:
- przykład kodu
- hiperłącze
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dodawaj i zarządzaj hiperłączami w Aspose.Slides for Node.js: łącz tekst, kształty i obrazy, ustawiaj cele i akcje dla PPT, PPTX i ODP z przykładami."
---
Ten artykuł demonstruje dodawanie, odczytywanie, usuwanie i aktualizowanie hiperłączy na kształtach przy użyciu **Aspose.Slides for Node.js via Java**.

## **Add a Hyperlink**
Utwórz kształt prostokąta z hiperłączem prowadzącym do zewnętrznej witryny.

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
Odczytaj hiperłącze z fragmentu tekstu kształtu.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zakładając, że pierwszy kształt zawiera tekst z hiperłączem.
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
Wyczyść hiperłącze z tekstu kształtu.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zakładając, że pierwszy kształt zawiera tekst z hiperłączem.
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
Zmień cel istniejącego hiperłącza. Użyj `HyperlinkManager` aby zmodyfikować tekst, który już zawiera hiperłącze, co naśladuje sposób, w jaki PowerPoint bezpiecznie aktualizuje hiperłącza.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zakładając, że pierwszy kształt zawiera tekst z hiperłączem.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // Zmiana hiperłącza w istniejącym tekście powinna być wykonana za pomocą
        // HyperlinkManager zamiast ustawiania właściwości bezpośrednio.
        // To naśladuje sposób, w jaki PowerPoint bezpiecznie aktualizuje hiperłącza.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```