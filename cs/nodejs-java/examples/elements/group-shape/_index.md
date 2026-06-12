---
title: Skupinový tvar
type: docs
weight: 170
url: /cs/nodejs-java/examples/elements/group-shape/
keywords:
- příklad kódu
- skupinový tvar
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte seskupené tvary v Aspose.Slides pro Node.js: vytvářejte, vkládejte, zarovnávejte, přeskupujte a stylizujte skupinové tvary s příklady v prezentacích PPT, PPTX a ODP."
---
Příklady vytváření skupin tvarů, jejich přístupu, rozbalení a odstranění pomocí **Aspose.Slides for Node.js via Java**.

## **Přidat skupinový tvar**

Vytvořte skupinu obsahující dva základní tvary.

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

## **Přístup ke skupinovému tvaru**

Načtěte první skupinový tvar ze snímku.

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

## **Odstranit skupinový tvar**

Smažte skupinový tvar ze snímku.

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Předpokládáme, že první tvar je skupinový tvar.
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Rozbalení tvarů**

Přesuňte tvary ze skupinového kontejneru.

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Předpokládáme, že první tvar je skupinový tvar.
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // Zkopírujte každý tvar ze skupiny na snímek.
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```