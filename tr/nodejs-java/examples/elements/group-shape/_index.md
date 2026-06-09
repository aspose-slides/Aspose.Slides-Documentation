---
title: Grup Şekli
type: docs
weight: 170
url: /tr/nodejs-java/examples/elements/group-shape/
keywords:
- kod örneği
- grup şekli
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js içinde gruplanmış şekilleri yönetin: PPT, PPTX ve ODP sunumlarında örneklerle grup şekillerini oluşturun, iç içe yerleştirin, hizalayın, sıralayın ve stil verin."
---
**Aspose.Slides for Node.js via Java** kullanarak şekil grupları oluşturma, bu gruplara erişme, gruplamayı kaldırma ve silme örnekleri.

## **Grup Şekli Ekle**

İki temel şekil içeren bir grup oluşturun.

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

## **Grup Şekline Erişme**

Bir slayttan ilk grup şeklini alın.

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

## **Grup Şekli Kaldırma**

Grup şeklini slayttan silin.

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk şeklin bir grup şekli olduğu varsayılıyor.
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Şekilleri Gruplamadan Çıkarma**

Şekilleri grup konteynerinden dışarı taşıyın.

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk şeklin bir grup şekli olduğu varsayılıyor.
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // Gruptan slayta her şekli klonlayın.
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```