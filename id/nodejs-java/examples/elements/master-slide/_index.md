---
title: Slide Master
type: docs
weight: 30
url: /id/nodejs-java/examples/elements/master-slide/
keywords:
  - contoh kode
  - slide master
  - PowerPoint
  - OpenDocument
  - presentasi
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Jelajahi contoh slide master Aspose.Slides untuk Node.js: buat, edit, dan gayakan master, placeholder, serta tema dalam PPT, PPTX, dan ODP dengan kode yang jelas."
---
Slide master membentuk tingkat teratas dari hierarki pewarisan slide di PowerPoint. **Slide master** mendefinisikan elemen desain umum seperti latar belakang, logo, dan pemformatan teks. **Slide tata letak** mewarisi dari slide master, dan **slide normal** mewarisi dari slide tata letak.

Artikel ini menunjukkan cara membuat, memodifikasi, dan mengelola slide master menggunakan Aspose.Slides untuk Node.js melalui Java.

## **Menambahkan Slide Master**

Contoh ini menunjukkan cara membuat slide master baru dengan menggandakan slide default. Kemudian menambahkan spanduk nama perusahaan ke semua slide melalui pewarisan tata letak.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Kloning slide master default.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // Tambahkan spanduk dengan nama perusahaan ke bagian atas slide master.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // Tetapkan slide master baru ke slide tata letak.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Tetapkan slide tata letak ke slide pertama dalam presentasi.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Catatan 1:** Slide master menyediakan cara untuk menerapkan branding yang konsisten atau elemen desain bersama di seluruh slide. Setiap perubahan yang dilakukan pada master akan secara otomatis tercermin pada slide tata letak dan slide normal yang bergantung.  
> 
> 💡 **Catatan 2:** Setiap bentuk atau pemformatan yang ditambahkan ke slide master akan diwarisi oleh slide tata letak dan, pada gilirannya, semua slide normal yang menggunakan tata letak tersebut.  
> 
> Gambar di bawah ini menggambarkan bagaimana kotak teks yang ditambahkan pada slide master secara otomatis ditampilkan pada slide akhir.

![Contoh Pewarisan Master](master-slide-banner.png)

## **Mengakses Slide Master**

Anda dapat mengakses slide master menggunakan koleksi master presentasi. Berikut cara mengambil dan bekerja dengan mereka:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // Ubah tipe latar belakang.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Slide Master**

Slide master dapat dihapus baik berdasarkan indeks maupun referensi.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Hapus slide master berdasarkan indeks.
        presentation.getMasters().removeAt(0);

        // Hapus slide master berdasarkan referensi.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Slide Master yang Tidak Digunakan**

Beberapa presentasi berisi slide master yang tidak digunakan. Menghapus slide tersebut dapat membantu mengurangi ukuran file.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Hapus semua slide master yang tidak terpakai (bahkan yang ditandai sebagai Preserve).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```