---
title: Łącznik
type: docs
weight: 190
url: /pl/nodejs-java/examples/elements/connector/
keywords:
- przykład kodu
- Łącznik
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak dodawać, kierować i stylizować łączniki pomiędzy kształtami przy użyciu Aspose.Slides dla Node.js, z przykładami JavaScript dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł pokazuje, jak połączyć kształty przy użyciu łączników i zmienić ich docelowe elementy przy użyciu **Aspose.Slides for Node.js via Java**.

## **Dodaj łącznik**

Wstaw kształt łącznika pomiędzy dwa punkty na slajdzie.

```js
function addConnector() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        presentation.save("connector.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Uzyskaj dostęp do łącznika**

Pobierz pierwszy kształt łącznika dodany do slajdu.

```js
function accessConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Uzyskaj dostęp do pierwszego łącznika na slajdzie.
        let connector = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                connector = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń łącznik**

Usuń łącznik ze slajdu.

```js
function removeConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Załóż, że pierwszy kształt jest łącznikiem i usuń go.
        slide.getShapes().removeAt(0);

        presentation.save("connector_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ponowne połączenie kształtów**

Dołącz łącznik do dwóch kształtów, przypisując początkowy i końcowy cel.

```js
function reconnectShapes() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 50, 50);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```