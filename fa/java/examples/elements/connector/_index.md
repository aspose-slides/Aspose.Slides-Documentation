---
title: کانکتور
type: docs
weight: 190
url: /fa/java/examples/elements/connector/
keywords:
- مثال کد
- Connector
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "نحوه افزودن، مسیردهی و استایل‌دهی به کانکتورها بین اشکال را با Aspose.Slides for Java بیاموزید، همراه با مثال‌های جاوا برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه اشکال را با کانکتورها متصل کرده و هدف‌های آن‌ها را با استفاده از **Aspose.Slides for Java** تغییر دهید.

## **افزودن یک کانکتور**

یک شکل کانکتور را بین دو نقطه روی اسلاید وارد کنید.

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

## **دسترسی به یک کانکتور**

اولین شکل کانکتور اضافه شده به اسلاید را بازیابی کنید.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // دسترسی به اولین کانکتور روی اسلاید.
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

## **حذف یک کانکتور**

یک کانکتور را از اسلاید حذف کنید.

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

## **اتصال مجدد اشکال**

یک کانکتور را به دو شکل متصل کنید با انتساب هدف‌های شروع و پایان.

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