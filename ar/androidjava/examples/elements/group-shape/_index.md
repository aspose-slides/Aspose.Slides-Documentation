---
title: مجموعة الأشكال
type: docs
weight: 170
url: /ar/androidjava/examples/elements/group-shape/
keywords:
- مثال على الكود
- مجموعة أشكال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة الأشكال المُجمَّعة في Aspose.Slides لأجهزة Android: إنشاء، تضمين، محاذاة، إعادة ترتيب، وتنسيق أشكال المجموعة باستخدام أمثلة Java في عروض PPT و PPTX و ODP."
---
أمثلة على إنشاء مجموعات من الأشكال، الوصول إليها، فك التجميع، والإزالة باستخدام **Aspose.Slides for Android via Java**.

## **إضافة شكل مجموعة**

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

## **الوصول إلى شكل مجموعة**

استرداد أول شكل مجموعة من الشريحة.

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

## **إزالة شكل مجموعة**

حذف شكل مجموعة من الشريحة.

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