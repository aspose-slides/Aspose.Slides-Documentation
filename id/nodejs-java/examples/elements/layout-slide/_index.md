---
title: Slide Tata Letak
type: docs
weight: 20
url: /id/nodejs-java/examples/elements/layout-slide/
keywords:
- contoh kode
- slide tata letak
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kuasai slide tata letak di Aspose.Slides untuk Node.js: pilih, terapkan, dan sesuaikan tata letak slide, placeholder, dan master dengan contoh untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara bekerja dengan **Layout Slides** di Aspose.Slides untuk Node.js via Java. Sebuah layout slide mendefinisikan desain dan format yang diwarisi oleh slide biasa. Anda dapat menambahkan, mengakses, menggandakan, dan menghapus layout slide, serta membersihkan yang tidak terpakai untuk mengurangi ukuran presentasi.

## **Menambahkan Layout Slide**

Anda dapat membuat layout slide khusus untuk mendefinisikan format yang dapat digunakan kembali.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // Buat slide tata letak dengan tipe tata letak kosong dan nama khusus.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Catatan 1:** Layout slide berfungsi sebagai templat untuk slide individual. Anda dapat mendefinisikan elemen umum sekali dan menggunakannya kembali di banyak slide.

> 💡 **Catatan 2:** Ketika Anda menambahkan bentuk atau teks ke layout slide, semua slide yang berbasis pada layout tersebut akan menampilkan konten bersama ini secara otomatis.
> Screenshot di bawah menunjukkan dua slide, masing-masing mewarisi kotak teks dari layout slide yang sama.

![Slide yang Menginherit Konten Layout](layout-slide-result.png)

## **Mengakses Layout Slide**

Layout slide dapat diakses melalui indeks atau tipe layout (misalnya `Blank`, `Title`, `SectionHeader`, dll.).

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Akses slide tata letak berdasarkan indeks.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Akses slide tata letak berdasarkan tipe.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Layout Slide**

Anda dapat menghapus layout slide tertentu jika tidak lagi diperlukan.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Dapatkan slide tata letak berdasarkan tipe dan hapus.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Layout Slide yang Tidak Digunakan**

Untuk mengurangi ukuran presentasi, Anda mungkin ingin menghapus layout slide yang tidak digunakan oleh slide biasa mana pun.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Secara otomatis menghapus semua slide tata letak yang tidak direferensikan oleh slide apa pun.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Menggandakan Layout Slide**

Anda dapat menduplikasi layout slide menggunakan metode `addClone`.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Dapatkan slide tata letak yang ada berdasarkan tipe.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // Gandakan slide tata letak ke akhir koleksi slide tata letak.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Ringkasan:** Layout slide adalah alat yang kuat untuk mengelola format konsisten di seluruh slide. Aspose.Slides memungkinkan kontrol penuh atas pembuatan, pengelolaan, dan pengoptimalan layout slide.