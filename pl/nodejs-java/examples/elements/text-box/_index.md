---
title: Pole tekstowe
type: docs
weight: 40
url: /pl/nodejs-java/examples/elements/text-box/
keywords:
- przykład kodu
- pole tekstowe
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Pracuj z polami tekstowymi w Aspose.Slides dla Node.js: dodawaj, formatuj, wyrównuj, zawijaj, automatycznie dopasowuj i stylizuj tekst przy użyciu JavaScript dla prezentacji PPT, PPTX i ODP."
---
W Aspose.Slides **pole tekstowe** jest reprezentowane przez `AutoShape`. Prawie każdy kształt może zawierać tekst, ale typowe pole tekstowe nie ma wypełnienia ani obramowania i wyświetla tylko tekst.

Ten przewodnik wyjaśnia, jak programowo dodawać, uzyskiwać dostęp i usuwać pola tekstowe.

## **Dodaj pole tekstowe**

Pole tekstowe to po prostu `AutoShape` bez wypełnienia i obramowania oraz z pewnym sformatowanym tekstem. Oto, jak je utworzyć:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Utwórz kształt prostokątny (domyślnie wypełniony obramowaniem i bez tekstu).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Usuń wypełnienie i obramowanie, aby wyglądało jak typowe pole tekstowe.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Ustaw formatowanie tekstu.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Przypisz rzeczywistą treść tekstu.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Uwaga:** Każde `AutoShape`, które zawiera niepusty `TextFrame`, może pełnić funkcję pola tekstowego.

## **Uzyskaj dostęp do pola tekstowego**

Pobierz pierwsze pole tekstowe ze slajdu.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Tylko AutoShape mogą zawierać edytowalny tekst.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń pola tekstowe według zawartości**

Ten przykład znajduje i usuwa wszystkie pola tekstowe na pierwszym slajdzie, które zawierają określone słowo kluczowe:

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Wskazówka:** Zawsze twórz kopię kolekcji kształtów przed jej modyfikacją podczas iteracji, aby uniknąć błędów modyfikacji kolekcji.