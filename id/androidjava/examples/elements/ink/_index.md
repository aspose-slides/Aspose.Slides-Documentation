---
title: Tinta
type: docs
weight: 180
url: /id/androidjava/examples/elements/ink/
keywords:
- contoh kode
- tinta
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Bekerja dengan Tinta di Aspose.Slides untuk Android: gambar, impor, dan edit goresan, sesuaikan warna dan lebar, serta ekspor ke PPT, PPTX, dan ODP menggunakan contoh Java."
---
Artikel ini menyediakan contoh cara mengakses bentuk tinta yang ada dan menghapusnya menggunakan **Aspose.Slides for Android via Java**.

> ❗ **Catatan:** Bentuk tinta mewakili input pengguna dari perangkat khusus. Aspose.Slides tidak dapat membuat goresan tinta baru secara programatik, tetapi Anda dapat membaca dan memodifikasi tinta yang ada.

## **Akses Tinta**

Baca tag dari bentuk tinta pertama pada slide.

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // Gunakan tagName sesuai kebutuhan.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Hapus Tinta**

Hapus bentuk tinta dari slide jika ada.

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```