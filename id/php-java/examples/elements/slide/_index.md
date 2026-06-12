---
title: Slide
type: docs
weight: 10
url: /id/php-java/examples/elements/slide/
keywords:
- slide
- tambah slide
- akses slide
- indeks slide
- gandakan slide
- susun ulang slide
- hapus slide
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kelola slide di PHP dengan Aspose.Slides: buat, gandakan, susun ulang, sembunyikan, atur latar belakang dan ukuran, terapkan transisi, dan ekspor untuk PowerPoint dan OpenDocument."
---
Artikel ini menyediakan serangkaian contoh yang menunjukkan cara bekerja dengan slide menggunakan **Aspose.Slides for PHP via Java**. Anda akan belajar cara menambahkan, mengakses, menggandakan, mengubah urutan, dan menghapus slide menggunakan kelas `Presentation`.

Setiap contoh di bawah ini mencakup penjelasan singkat diikuti oleh potongan kode dalam PHP.

## **Add a Slide**

Untuk menambahkan slide baru, Anda harus terlebih dahulu memilih tata letak. Dalam contoh ini, kami menggunakan tata letak `Blank` dan menambahkan slide kosong ke presentasi.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // Setiap slide didasarkan pada sebuah tata letak, yang pada gilirannya didasarkan pada slide master.
        // Gunakan tata letak Blank untuk membuat slide baru.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Tambahkan slide kosong baru menggunakan tata letak yang dipilih.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip:** Setiap tata letak slide berasal dari slide master, yang menentukan desain keseluruhan dan struktur placeholder. Gambar di bawah ini menggambarkan bagaimana slide master dan tata letak terkaitnya diatur di PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Access Slides by Index**

Anda dapat mengakses slide menggunakan indeks mereka.

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Akses slide berdasarkan indeks.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Clone a Slide**

Contoh ini menunjukkan cara menggandakan slide yang ada. Slide yang digandakan secara otomatis ditambahkan ke akhir koleksi slide.

```php
function cloneSlide() {
    // Secara default, presentasi berisi satu slide kosong.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Gandakan slide pertama; slide tersebut akan ditambahkan di akhir presentasi.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // Indeks slide yang digandakan adalah 1 (slide kedua dalam presentasi).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Reorder Slides**

Anda dapat mengubah urutan slide dengan memindahkan satu ke indeks baru. Dalam hal ini, kami memindahkan slide ke posisi pertama.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // Pindahkan slide ke posisi pertama (yang lain bergeser ke bawah).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a Slide**

Untuk menghapus slide, cukup referensikan dan panggil `remove`. Contoh ini menghapus slide berdasarkan indeks dan berdasarkan referensi.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Hapus slide berdasarkan indeks.
        $presentation->getSlides()->removeAt(0);

        // Hapus slide berdasarkan referensi.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```