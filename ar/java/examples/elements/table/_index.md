---
title: جدول
type: docs
weight: 120
url: /ar/java/examples/elements/table/
keywords:
- مثال على الكود
- جدول
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "العمل مع الجداول في Aspose.Slides for Java: إنشاء، تنسيق، دمج الخلايا، تطبيق الأنماط، استيراد البيانات، وتصدير مع أمثلة Java لصيغ PPT و PPTX و ODP."
---
أمثلة لإضافة الجداول، الوصول إليها، حذفها، ودمج الخلايا باستخدام **Aspose.Slides for Java**.

## **إضافة جدول**

إنشاء جدول بسيط بصفّين وعمودين.

```java
static void addTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى جدول**

استرجاع أول شكل جدول في الشريحة.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // الوصول إلى أول جدول في الشريحة.
        ITable firstTable = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                firstTable = (ITable) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **حذف جدول**

حذف جدول من الشريحة.

```java
static void removeTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        slide.getShapes().remove(table);
    } finally {
        presentation.dispose();
    }
}
```

## **دمج خلايا الجدول**

دمج خلايا متجاورة في جدول لتصبح خلية واحدة.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // دمج الخلايا.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```