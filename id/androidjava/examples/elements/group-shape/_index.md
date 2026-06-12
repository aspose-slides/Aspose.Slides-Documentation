---
title: Bentuk Grup
type: docs
weight: 170
url: /id/androidjava/examples/elements/group-shape/
keywords:
- contoh kode
- bentuk grup
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola bentuk yang dikelompokkan di Aspose.Slides untuk Android: buat, susun, sejajarkan, urutkan kembali, dan gaya bentuk grup dengan contoh Java dalam presentasi PPT, PPTX, dan ODP."
---
Contoh membuat grup bentuk, mengaksesnya, mengeluarkan grup, dan menghapus menggunakan **Aspose.Slides for Android via Java**.

## **Menambahkan Bentuk Grup**

Buat grup yang berisi dua bentuk dasar.

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

## **Mengakses Bentuk Grup**

Ambil bentuk grup pertama dari slide.

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

## **Menghapus Bentuk Grup**

Hapus bentuk grup dari slide.

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

## **Melepas Grup Bentuk**

Pindahkan bentuk keluar dari kontainer grup.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Pindahkan bentuk keluar dari grup.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```