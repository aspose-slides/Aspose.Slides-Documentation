---
title: مجموعة الأشكال
type: docs
weight: 170
url: /ar/nodejs-java/examples/elements/group-shape/
keywords:
- مثال على الكود
- مجموعة أشكال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة الأشكال المجمعة في Aspose.Slides لـ Node.js: إنشاء، تجميع، محاذاة، إعادة ترتيب، وتنسيق مجموعة الأشكال مع أمثلة في عروض PPT و PPTX و ODP."
---
أمثلة لإنشاء مجموعات من الأشكال، والوصول إليها، وفك التجميع، وإزالة باستخدام **Aspose.Slides for Node.js via Java**.

## **إضافة شكل مجموعة**

إنشاء مجموعة تحتوي على شكلين أساسيين.

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

## **الوصول إلى شكل مجموعة**

استرجاع أول شكل مجموعة من الشريحة.

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

## **إزالة شكل مجموعة**

حذف شكل مجموعة من الشريحة.

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // با افتراض أن الشكل الأول هو مجموعة أشكال.
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **فك تجميع الأشكال**

نقل الأشكال خارج حاوية المجموعة.

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // با افتراض أن الشكل الأول هو مجموعة أشكال.
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // انسخ كل شكل من المجموعة إلى الشريحة.
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```