---
title: جدول
type: docs
weight: 120
url: /ar/androidjava/examples/elements/table/
keywords:
- مثال برمجي
- جدول
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "العمل مع الجداول في Aspose.Slides لنظام Android: إنشاء، تنسيق، دمج الخلايا، تطبيق الأنماط، استيراد البيانات، وتصديرها باستخدام أمثلة Java لملفات PPT وPPTX وODP."
---
أمثلة على إضافة جداول، الوصول إليها، حذفها، ودمج الخلايا باستخدام **Aspose.Slides for Android via Java**.

## **إضافة جدول**

إنشاء جدول بسيط يحتوي على صفين وعمودين.

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

استرجاع الشكل الأول للجدول في الشريحة.

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

دمج الخلايا المتجاورة في جدول لتصبح خلية واحدة.

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