---
title: جدول
type: docs
weight: 120
url: /ar/nodejs-java/examples/elements/table/
keywords:
- مثال على الكود
- جدول
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "العمل مع الجداول في Aspose.Slides for Node.js: إنشاء، تنسيق، دمج الخلايا، تطبيق الأنماط، استيراد البيانات، وتصدير مع أمثلة لـ PPT و PPTX و ODP."
---
أمثلة على إضافة الجداول، والوصول إليها، وإزالتها، ودمج الخلايا باستخدام **Aspose.Slides for Node.js via Java**.

## **إضافة جدول**

إنشاء جدول بسيط بصفين وعمودين.

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

## **الوصول إلى جدول**

استرجاع الشكل الجدولي الأول من الشريحة.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // الوصول إلى أول جدول في الشريحة.
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

## **إزالة جدول**

حذف جدول من الشريحة.

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // افترض أن الشكل الأول هو جدول.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **دمج خلايا الجدول**

دمج الخلايا المتجاورة في جدول إلى خلية واحدة.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // افترض أن الشكل الأول هو جدول.
        let table = slide.getShapes().get_Item(0);

        // دمج الخلايا.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```