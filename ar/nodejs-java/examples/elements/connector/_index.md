---
title: موصل
type: docs
weight: 190
url: /ar/nodejs-java/examples/elements/connector/
keywords:
- مثال على الكود
- Connector
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعرف على كيفية إضافة وتوجيه وتنسيق الموصلات بين الأشكال باستخدام Aspose.Slides لـ Node.js، مع أمثلة JavaScript لعروض PPT و PPTX و ODP."
---
توضح هذه المقالة كيفية ربط الأشكال بالموصلات وتغيير أهدافها باستخدام **Aspose.Slides for Node.js via Java**.

## **إضافة موصل**

أدخل شكلاً موصلاً بين نقطتين على الشريحة.

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

## **الوصول إلى موصل**

استرجع أول شكل موصل تمت إضافته إلى الشريحة.

```js
function accessConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // الوصول إلى أول موصل على الشريحة.
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

## **إزالة موصل**

احذف موصلًا من الشريحة.

```js
function removeConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // افترض أن الشكل الأول هو موصل وقم بإزالته.
        slide.getShapes().removeAt(0);

        presentation.save("connector_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **إعادة ربط الأشكال**

أرفق موصلًا باثنين من الأشكال عن طريق تعيين أهداف البداية والنهاية.

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