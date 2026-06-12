---
title: Slide Master
type: docs
weight: 30
url: /id/php-java/examples/elements/master-slide/
keywords:
- slide master
- tambah slide master
- akses slide master
- hapus slide master
- slide master tidak terpakai
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kelola slide master di PHP dengan Aspose.Slides: buat, edit, kloning, dan format tema, latar belakang, placeholder untuk menyatukan slide dalam PowerPoint dan OpenDocument."
---
Master slide membentuk tingkat teratas dari hierarki pewarisan slide di PowerPoint. **master slide** mendefinisikan elemen desain umum seperti latar belakang, logo, dan pemformatan teks. **Layout slides** mewarisi dari master slide, dan **normal slides** mewarisi dari layout slides.

Artikel ini menunjukkan cara membuat, memodifikasi, dan mengelola master slide menggunakan Aspose.Slides for PHP via Java.

## **Tambah Master Slide**

Contoh ini menunjukkan cara membuat master slide baru dengan menggandakan yang default.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // Klon master slide default.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** Master slide menyediakan cara untuk menerapkan merek yang konsisten atau elemen desain bersama di semua slide. Setiap perubahan yang dilakukan pada master akan secara otomatis tercermin pada layout dan normal slide yang bergantung.

> 💡 **Tip 2:** Setiap bentuk atau pemformatan yang ditambahkan ke master slide akan diwariskan oleh layout slides dan, pada gilirannya, semua normal slides yang menggunakan layout tersebut.  
> Gambar di bawah menggambarkan bagaimana kotak teks yang ditambahkan pada master slide secara otomatis dirender pada slide akhir.

![Contoh Pewarisan Master](master-slide-banner.png)

## **Akses Master Slide**

Anda dapat mengakses master slide menggunakan metode `Presentation::getMasters`. Berikut cara mengambil dan bekerja dengan mereka:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Akses master slide pertama.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Hapus Master Slide**

Master slide dapat dihapus baik berdasarkan indeks maupun referensi.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Hapus berdasarkan indeks.
        $presentation->getMasters()->removeAt(0);

        // Atau hapus berdasarkan referensi.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Hapus Master Slide yang Tidak Dipakai**

Beberapa presentasi berisi master slide yang tidak digunakan. Menghapus slide ini dapat membantu mengurangi ukuran file.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Hapus semua master slide yang tidak terpakai (bahkan yang ditandai sebagai Preserve).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Tip:** Gunakan `removeUnused(true)` untuk membersihkan master slide yang tidak terpakai dan meminimalkan ukuran presentasi.