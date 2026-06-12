---
title: Gambar
type: docs
weight: 50
url: /id/nodejs-java/examples/elements/picture/
keywords:
- contoh kode
- gambar
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Bekerja dengan gambar di Aspose.Slides untuk Node.js: menyisipkan, memangkas, mengompres, mewarnai ulang, dan mengekspor gambar dengan contoh untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menyisipkan dan mengakses gambar menggunakan **Aspose.Slides for Node.js via Java**. Contoh di bawah membaca sebuah gambar dari file, menempatkannya pada slide, dan kemudian mengambilnya.

## **Tambah Gambar**

Kode ini membaca sebuah gambar dari file dan menyisipkannya sebagai bingkai gambar pada slide pertama.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // Sisipkan bingkai gambar yang menampilkan gambar pada slide pertama.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Akses Gambar**

Contoh ini memastikan sebuah slide berisi bingkai gambar dan kemudian mengakses yang pertama ditemukan.

```js
function accessPicture() {
    let presentation = new aspose.slides.Presentation("picture.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pictureFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                pictureFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```