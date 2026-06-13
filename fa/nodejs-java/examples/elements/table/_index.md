---
title: جدول
type: docs
weight: 120
url: /fa/nodejs-java/examples/elements/table/
keywords:
- مثال کد
- جدول
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "کار با جداول در Aspose.Slides برای Node.js: ایجاد، قالب‌بندی، ادغام سلول‌ها، اعمال سبک‌ها، وارد کردن داده‌ها و خروجی با مثال‌ها برای PPT، PPTX و ODP."
---
نمونه‌هایی برای افزودن جدول‌ها، دسترسی به آن‌ها، حذف آن‌ها و ادغام سلول‌ها با استفاده از **Aspose.Slides for Node.js via Java**.

## **افزودن جدول**

یک جدول ساده با دو ردیف و دو ستون ایجاد کنید.

```js
function addTable() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let widths = java.newArray("double", [80, 80]);
        let heights = java.newArray("double", [30, 30]);
        let table = slide.getShapes().addTable(50, 50, widths, heights);

        presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به جدول**

شکل اولین جدول را از اسلاید بازیابی کنید.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // دسترسی به اولین جدول در اسلاید.
        let firstTable = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
                firstTable = shape;
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

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض کنید اولین شکل یک جدول است.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ادغام سلول‌های جدول**

سلول‌های مجاور یک جدول را به یک سلول واحد ادغام کنید.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض کنید اولین شکل یک جدول است.
        let table = slide.getShapes().get_Item(0);

        // ادغام سلول‌ها.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```