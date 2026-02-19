---
title: مجموعة أشكال
type: docs
weight: 170
url: /ar/java/examples/elements/group-shape/
keywords:
- مثال برمجي
- مجموعة أشكال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة الأشكال المجمعة في Aspose.Slides for Java: إنشاء، تعشيق، محاذاة، إعادة ترتيب، وتنسيق مجموعات الأشكال باستخدام أمثلة Java في عروض PPT و PPTX و ODP."
---
أمثلة لإنشاء مجموعات من الأشكال، والوصول إليها، وفك التجميع، والإزالة باستخدام **Aspose.Slides for Java**.

## **إضافة مجموعة أشكال**

إنشاء مجموعة تحتوي على شكلين أساسيين.

```java
static void addGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى مجموعة أشكال**

استرجاع أول مجموعة أشكال من الشريحة.

```java
static void accessGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        IGroupShape firstGroup = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IGroupShape) {
                firstGroup = (IGroupShape) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة مجموعة أشكال**

حذف مجموعة أشكال من الشريحة.

```java
static void removeGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();

        slide.getShapes().remove(group);
    } finally {
        presentation.dispose();
    }
}
```

## **فك تجميع الأشكال**

نقل الأشكال خارج حاوية المجموعة.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // نقل الشكل خارج المجموعة.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```