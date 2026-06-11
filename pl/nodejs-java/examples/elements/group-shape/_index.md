---
title: Grupa kształtów
type: docs
weight: 170
url: /pl/nodejs-java/examples/elements/group-shape/
keywords:
- przykład kodu
- grupa kształtów
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj grupowanymi kształtami w Aspose.Slides for Node.js: twórz, zagnieżdżaj, wyrównuj, zmieniaj kolejność i stylizuj grupy kształtów przy użyciu przykładów w prezentacjach PPT, PPTX i ODP."
---
Przykłady tworzenia grup kształtów, uzyskiwania do nich dostępu, rozgrupowywania i usuwania przy użyciu **Aspose.Slides for Node.js via Java**.

## **Dodaj grupę kształtów**

Utwórz grupę zawierającą dwa podstawowe kształty.

```js
function addGroupShape() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 60, 0, 50, 50);

        presentation.save("group_shape.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Dostęp do grupy kształtów**

Pobierz pierwszy kształt grupy ze slajdu.

```js
function accessGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstGroup = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                firstGroup = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń grupę kształtów**

Usuń kształt grupy ze slajdu.

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zakładając, że pierwszy kształt jest grupą kształtów.
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Rozgrupuj kształty**

Przenieś kształty poza kontener grupy.

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zakładając, że pierwszy kształt jest grupą kształtów.
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // Sklonuj każdy kształt z grupy na slajd.
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```