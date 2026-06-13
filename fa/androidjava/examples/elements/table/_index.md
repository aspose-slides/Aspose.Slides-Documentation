---
title: جدول
type: docs
weight: 120
url: /fa/androidjava/examples/elements/table/
keywords:
- نمونه کد
- جدول
- پاورپوینت
- سند باز
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "کار با جدول‌ها در Aspose.Slides برای اندروید: ایجاد، قالب‌بندی، ادغام سلول‌ها، اعمال سبک‌ها، وارد کردن داده‌ها و خروجی‌گیری با مثال‌های جاوا برای PPT، PPTX و ODP."
---
نمونه‌هایی برای افزودن جدول‌ها، دسترسی به آن‌ها، حذف آن‌ها و ادغام سلول‌ها با استفاده از **Aspose.Slides for Android via Java**.

## **افزودن جدول**

یک جدول ساده با دو ردیف و دو ستون ایجاد کنید.

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

## **دسترسی به جدول**

اولین شکل جدول در اسلاید را بازیابی کنید.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // دسترسی به اولین جدول در اسلاید.
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

یک جدول را از اسلاید حذف کنید.

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

## **ادغام سلول‌های جدول**

سلول‌های مجاور یک جدول را به یک سلول واحد ادغام کنید.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // ادغام سلول‌ها.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```