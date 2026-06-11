---
title: Gruppform
type: docs
weight: 170
url: /sv/nodejs-java/examples/elements/group-shape/
keywords:
- kodexempel
- gruppform
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera grupperade former i Aspose.Slides för Node.js: skapa, nästla, justera, omordna och formatera gruppformer med exempel i PPT-, PPTX- och ODP-presentationer."
---
Exempel på att skapa grupper av former, komma åt dem, lösa upp dem och ta bort dem med **Aspose.Slides for Node.js via Java**.

## **Lägg till en gruppform**

Skapa en grupp som innehåller två enkla former.

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

## **Kom åt en gruppform**

Hämta den första gruppformen från en bild.

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

## **Ta bort en gruppform**

Radera en gruppform från bilden.

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Antar att den första formen är en gruppform.
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Lösa upp former**

Flytta former ur en gruppbehållare.

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Antar att den första formen är en gruppform.
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // Klona varje form från gruppen till bilden.
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```