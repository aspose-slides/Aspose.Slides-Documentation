---
title: موصل
type: docs
weight: 190
url: /ar/java/examples/elements/connector/
keywords:
- مثال على الكود
- موصل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة وتوجيه وتنسيق الموصلات بين الأشكال باستخدام Aspose.Slides for Java، مع أمثلة Java لعروض PPT وPPTX وODP."
---
توضح هذه المقالة كيفية ربط الأشكال بالموصلات وتغيير أهدافها باستخدام **Aspose.Slides for Java**.

## **إضافة موصل**

إدراج شكل موصل بين نقطتين على الشريحة.

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

## **الوصول إلى موصل**

استرجاع أول شكل موصل تمت إضافته إلى الشريحة.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // الوصول إلى أول موصل على الشريحة.
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

## **إزالة موصل**

حذف موصل من الشريحة.

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

## **إعادة ربط الأشكال**

إرفاق موصل إلى شكلين عن طريق تعيين أهداف البداية والنهاية.

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