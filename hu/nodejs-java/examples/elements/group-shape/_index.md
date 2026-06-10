---
title: Csoport alakzat
type: docs
weight: 170
url: /hu/nodejs-java/examples/elements/group-shape/
keywords:
- kód példa
- csoport alakzat
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js segítségével csoportosított alakzatok kezelése: csoport alakzatok létrehozása, egymásba ágyazása, igazítása, átrendezése és stílusozása PPT, PPTX és ODP prezentációk példáival."
---
Példák alakcsoportok létrehozására, azok elérésére, csoportosítás felbontására és eltávolítására **Aspose.Slides for Node.js via Java**.

## **Csoport alakzat hozzáadása**

Hozzon létre egy csoportot, amely két alap alakzatot tartalmaz.

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

## **Csoport alakzat elérése**

Hozza vissza az első csoport alakzatot a diából.

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

## **Csoport alakzat eltávolítása**

Törölje a csoport alakzatot a diáról.

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezve, hogy az első alakzat egy csoport alakzat.
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Alakzatok felbontása**

Helyezze ki az alakzatokat a csoport konténerből.

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezve, hogy az első alakzat egy csoport alakzat.
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // Klónozza az egyes alakzatokat a csoportból a diára.
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```