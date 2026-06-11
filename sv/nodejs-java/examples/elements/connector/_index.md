---
title: Anslutning
type: docs
weight: 190
url: /sv/nodejs-java/examples/elements/connector/
keywords:
- kodexempel
- Anslutning
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du lägger till, dirigerar och formaterar anslutningar mellan former med Aspose.Slides för Node.js, med JavaScript-exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur man kopplar samman former med anslutningar och ändrar deras mål med hjälp av **Aspose.Slides for Node.js via Java**.

## **Lägg till en anslutning**

Infoga en anslutningsform mellan två punkter på bilden.

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

## **Åtkomst till en anslutning**

Hämta den första anslutningsformen som lades till på en bild.

```js
function accessConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Åtkomst till den första anslutningen på bilden.
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

## **Ta bort en anslutning**

Ta bort en anslutning från bilden.

```js
function removeConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Anta att den första formen är en anslutning och ta bort den.
        slide.getShapes().removeAt(0);

        presentation.save("connector_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Koppla om former**

Fäst en anslutning till två former genom att tilldela start- och slutmål.

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