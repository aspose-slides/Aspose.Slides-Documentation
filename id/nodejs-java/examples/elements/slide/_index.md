---
title: Slide
type: docs
weight: 10
url: /id/nodejs-java/examples/elements/slide/
keywords:
- contoh kode
- slide
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kontrol slide dalam Aspose.Slides untuk Node.js: buat, gandakan, ubah urutan, ubah ukuran, atur latar belakang, dan terapkan transisi untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menyediakan serangkaian contoh yang menunjukkan cara bekerja dengan slide menggunakan **Aspose.Slides for Node.js via Java**. Anda akan belajar cara menambahkan, mengakses, menggandakan, mengubah urutan, dan menghapus slide menggunakan kelas `Presentation`.

Setiap contoh di bawah ini mencakup penjelasan singkat diikuti oleh cuplikan kode dalam JavaScript.

## **Menambahkan Slide**

Untuk menambahkan slide baru, Anda harus terlebih dahulu memilih tata letak. Pada contoh ini, kami menggunakan tata letak `Blank` dan menambahkan slide kosong ke presentasi.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Catatan:** Setiap tata letak slide diturunkan dari master slide, yang menentukan desain keseluruhan dan struktur placeholder. Gambar di bawah ini menggambarkan bagaimana master slide dan tata letaknya diatur di PowerPoint.

![Hubungan Master dan Layout](master-layout-slide.png)

## **Mengakses Slide berdasarkan Indeks**

Anda dapat mengakses slide menggunakan indeksnya. Ini berguna untuk mengiterasi atau memodifikasi slide tertentu.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Akses slide berdasarkan indeks.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Menggandakan Slide**

Contoh ini menunjukkan cara menggandakan slide yang ada. Slide yang digandakan secara otomatis ditambahkan ke akhir koleksi slide.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Mengubah Urutan Slide**

Anda dapat mengubah urutan slide dengan memindahkan satu ke indeks baru. Dalam kasus ini, kami memindahkan slide ke posisi pertama.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Atur ulang slide dengan memindahkan slide kedua ke posisi pertama.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Slide**

Untuk menghapus slide, cukup referensikan dan panggil `remove`. Contoh ini menambahkan slide kedua dan kemudian menghapus slide asli, menyisakan hanya yang baru.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```