---
title: اتصال‌دهنده
type: docs
weight: 190
url: /fa/androidjava/examples/elements/connector/
keywords:
- نمونه کد
- اتصال‌دهنده
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه با استفاده از Aspose.Slides برای Android، اتصال‌دهنده‌ها را بین اشکال اضافه، مسیر دهید و استایل کنید، همراه با مثال‌های Java برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه اشکال را با اتصال‌دهنده‌ها متصل کنید و هدف‌های آن‌ها را با استفاده از **Aspose.Slides for Android via Java** تغییر دهید.

## **Add a Connector**
یک شکل اتصال‌دهنده را بین دو نقطه در اسلاید وارد کنید.

```java
static void addConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Connector**
شکل اولین اتصال‌دهنده‌ای که به اسلاید اضافه شده است را بازیابی کنید.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // دسترسی به اولین اتصال‌دهنده در اسلاید.
        IConnector connector = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IConnector) {
                connector = (IConnector) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Connector**
یک اتصال‌دهنده را از اسلاید حذف کنید.

```java
static void removeConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        slide.getShapes().remove(connector);
    } finally {
        presentation.dispose();
    }
}
```

## **Reconnect Shapes**
یک اتصال‌دهنده را به دو شکل متصل کنید با اختصاص هدف‌های شروع و پایان.

```java
static void reconnectShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```