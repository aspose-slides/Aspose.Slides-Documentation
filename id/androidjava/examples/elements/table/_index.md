---
title: Tabel
type: docs
weight: 120
url: /id/androidjava/examples/elements/table/
keywords:
- contoh kode
- tabel
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Bekerja dengan tabel di Aspose.Slides for Android: buat, format, gabungkan sel, terapkan gaya, impor data, dan ekspor dengan contoh Java untuk PPT, PPTX, dan ODP."
---
Contoh menambahkan tabel, mengaksesnya, menghapusnya, dan menggabungkan sel menggunakan **Aspose.Slides for Android via Java**.

## **Tambah Tabel**

Buat tabel sederhana dengan dua baris dan dua kolom.

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

## **Akses Tabel**

Ambil shape tabel pertama pada slide.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Akses tabel pertama pada slide.
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

## **Hapus Tabel**

Hapus tabel dari slide.

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

## **Gabungkan Sel Tabel**

Gabungkan sel‑sel bersebelahan dari tabel menjadi satu sel.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Gabungkan sel.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```