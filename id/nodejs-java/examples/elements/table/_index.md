---
title: Tabel
type: docs
weight: 120
url: /id/nodejs-java/examples/elements/table/
keywords:
- contoh kode
- tabel
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Bekerja dengan tabel di Aspose.Slides untuk Node.js: buat, format, gabungkan sel, terapkan gaya, impor data, dan ekspor dengan contoh untuk PPT, PPTX, dan ODP."
---
Contoh menambahkan tabel, mengaksesnya, menghapusnya, dan menggabungkan sel menggunakan **Aspose.Slides for Node.js via Java**.

## **Add a Table**

Buat tabel sederhana dengan dua baris dan dua kolom.

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

## **Access a Table**

Ambil bentuk tabel pertama dari slide.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Akses tabel pertama pada slide.
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

## **Remove a Table**

Hapus tabel dari slide.

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Anggap bentuk pertama adalah tabel.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Merge Table Cells**

Gabungkan sel yang berdekatan dalam tabel menjadi satu sel.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Anggap bentuk pertama adalah tabel.
        let table = slide.getShapes().get_Item(0);

        // Gabungkan sel.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```