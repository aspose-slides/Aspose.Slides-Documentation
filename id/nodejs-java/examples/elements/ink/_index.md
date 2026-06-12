---
title: Tinta
type: docs
weight: 180
url: /id/nodejs-java/examples/elements/ink/
keywords:
- contoh kode
- tinta
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Bekerja dengan Tinta di Aspose.Slides untuk Node.js: menggambar, mengimpor, dan mengedit goresan, mengatur warna dan lebar, serta mengekspor ke PPT, PPTX, dan ODP menggunakan contoh."
---
Artikel ini menyediakan contoh cara mengakses bentuk tinta yang ada dan menghapusnya menggunakan **Aspose.Slides for Node.js via Java**.

> ❗ **Catatan:** Bentuk tinta mewakili input pengguna dari perangkat khusus. Aspose.Slides tidak dapat membuat goresan tinta baru secara programatik, tetapi Anda dapat membaca dan memodifikasi tinta yang ada.

## **Akses Tinta**

Ambil bentuk tinta pertama pada slide.

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Hapus Tinta**

Hapus bentuk tinta dari slide.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Mengasumsikan bentuk tinta adalah bentuk pertama pada slide.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```