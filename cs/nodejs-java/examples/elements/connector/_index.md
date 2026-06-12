---
title: Konektor
type: docs
weight: 190
url: /cs/nodejs-java/examples/elements/connector/
keywords:
- ukázka kódu
- Konektor
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro Node.js přidávat, směrovat a stylovat konektory mezi tvary, s příklady v JavaScriptu pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak propojit tvary pomocí konektorů a změnit jejich cíle pomocí **Aspose.Slides for Node.js via Java**.

## **Přidat konektor**

Vložte tvar konektoru mezi dva body na snímku.

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

## **Přístup ke konektoru**

Získejte první tvar konektoru přidaný do snímku.

```js
function accessConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Přístup k prvnímu konektoru na snímku.
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

## **Odstranit konektor**

Odstraňte konektor ze snímku.

```js
function removeConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Předpokládejme, že první tvar je konektor a odstraňte jej.
        slide.getShapes().removeAt(0);

        presentation.save("connector_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Znovupřipojit tvary**

Připojte konektor ke dvěma tvarům přiřazením počátečního a koncového cíle.

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