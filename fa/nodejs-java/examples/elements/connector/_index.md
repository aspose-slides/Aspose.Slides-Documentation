---
title: اتصال‌گر
type: docs
weight: 190
url: /fa/nodejs-java/examples/elements/connector/
keywords:
- مثال کد
- اتصال‌گر
- پاورپوینت
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "بیاموزید چگونه اتصال‌گرها را بین اشکال اضافه، مسیردهی و استایل کنید با استفاده از Aspose.Slides برای Node.js، با مثال‌های JavaScript برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد چگونه اشکال را با اتصال‌گرها متصل کنید و هدف‌های آن‌ها را با استفاده از **Aspose.Slides for Node.js via Java** تغییر دهید.

## **افزودن یک اتصال**

یک شکل اتصال‌گر را بین دو نقطه در اسلاید وارد کنید.

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

## **دسترسی به یک اتصال**

اولین شکل اتصال‌گری که به اسلاید اضافه شده است را بازیابی کنید.

```js
function accessConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // دسترسی به اولین اتصال‌گر در اسلاید.
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

## **حذف یک اتصال**

یک اتصال‌گر را از اسلاید حذف کنید.

```js
function removeConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض کنید اولین شکل یک اتصال‌گر است و آن را حذف کنید.
        slide.getShapes().removeAt(0);

        presentation.save("connector_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **اتصال مجدد اشکال**

یک اتصال‌گر را به دو شکل متصل کنید با اختصاص اهداف شروع و پایان.

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