---
title: SmartArt
type: docs
weight: 140
url: /pl/nodejs-java/examples/elements/smart-art/
keywords:
- przykład kodu
- SmartArt
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Pracuj z SmartArt w Aspose.Slides for Node.js: twórz, edytuj, konwertuj i stylizuj diagramy w JavaScript dla prezentacji PowerPoint i OpenDocument."
---
Ten artykuł pokazuje, jak dodawać grafiki SmartArt, uzyskiwać do nich dostęp, usuwać je oraz zmieniać układy przy użyciu **Aspose.Slides for Node.js via Java**.

## **Dodaj SmartArt**

Wstaw grafikę SmartArt, używając jednego z wbudowanych układów.

```js
function addSmartArt() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);

        presentation.save("smartart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Dostęp do SmartArt**

Pobierz pierwszy obiekt SmartArt na slajdzie.

```js
function accessSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstSmartArt = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
                firstSmartArt = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń SmartArt**

Usuń kształt SmartArt ze slajdu.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zakładając, że pierwszy kształt to SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Zmień układ SmartArt**

Zaktualizuj typ układu istniejącej grafiki SmartArt.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zakładając, że pierwszy kształt to SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```