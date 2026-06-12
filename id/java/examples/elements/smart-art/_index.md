---
title: SmartArt
type: docs
weight: 140
url: /id/java/examples/elements/smart-art/
keywords:
- contoh kode
- SmartArt
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Bekerja dengan SmartArt di Aspose.Slides for Java: buat, edit, konversi, dan gaya diagram menggunakan Java untuk presentasi PowerPoint dan OpenDocument."
---
Artikel ini menunjukkan cara menambahkan grafik SmartArt, mengaksesnya, menghapusnya, dan mengubah tata letak menggunakan **Aspose.Slides for Java**.

## **Menambahkan SmartArt**

Masukkan grafik SmartArt menggunakan salah satu tata letak bawaan.

```java
static void addSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
    } finally {
        presentation.dispose();
    }
}
```

## **Mengakses SmartArt**

Ambil objek SmartArt pertama pada slide.

```java
static void accessSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        ISmartArt firstSmartArt = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ISmartArt) {
                firstSmartArt = (ISmartArt) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus SmartArt**

Hapus shape SmartArt dari slide.

```java
static void removeSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        slide.getShapes().remove(smartArt);
    } finally {
        presentation.dispose();
    }
}
```

## **Mengubah Tata Letak SmartArt**

Perbarui tipe tata letak grafik SmartArt yang ada.

```java
static void changeSmartArtLayout() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
        smartArt.setLayout(SmartArtLayoutType.VerticalPictureList);
    } finally {
        presentation.dispose();
    }
}
```