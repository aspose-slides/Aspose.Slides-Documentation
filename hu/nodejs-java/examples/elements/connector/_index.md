---
title: Csatlakozó
type: docs
weight: 190
url: /hu/nodejs-java/examples/elements/connector/
keywords:
- kódpélda
- Csatlakozó
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, irányíthat és formázhat csatlakozókat alakzatok között az Aspose.Slides for Node.js használatával, JavaScript példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet alakzatokat csatlakoztatni csatlakozókkal, és megváltoztatni azok célpontjait a **Aspose.Slides for Node.js via Java** használatával.

## **Csatlakozó hozzáadása**

Szúrjon be egy csatlakozó alakzatot a dián két pont közé.

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

## **Csatlakozó elérése**

Hozza vissza az első, a diára hozzáadott csatlakozó alakzatot.

```js
function accessConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // A dián lévő első csatlakozó elérése.
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

## **Csatlakozó eltávolítása**

Távolítsa el a csatlakozót a diáról.

```js
function removeConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Tegyük fel, hogy az első alakzat egy csatlakozó, és távolítsuk el.
        slide.getShapes().removeAt(0);

        presentation.save("connector_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Alakzatok újbóli csatlakoztatása**

Csatlakoztasson egy csatlakozót két alakzathoz a kezdő és végpont célpontjainak megadásával.

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