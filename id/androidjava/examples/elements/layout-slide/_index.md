---
title: Slide Tata Letak
type: docs
weight: 20
url: /id/androidjava/examples/elements/layout-slide/
keywords:
- contoh kode
- slide tata letak
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kuasi slide tata letak di Aspose.Slides untuk Android: pilih, terapkan, dan sesuaikan tata letak slide, placeholder, dan master dengan contoh Java untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara bekerja dengan **Layout Slides** di Aspose.Slides untuk Android melalui Java. Sebuah layout slide mendefinisikan desain dan pemformatan yang diwarisi oleh slide biasa. Anda dapat menambah, mengakses, menggandakan, dan menghapus layout slide, serta membersihkan yang tidak terpakai untuk mengurangi ukuran presentasi.

## **Tambah Layout Slide**

Anda dapat membuat layout slide khusus untuk mendefinisikan pemformatan yang dapat digunakan kembali. Misalnya, Anda dapat menambahkan kotak teks yang muncul di semua slide yang menggunakan layout ini.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Buat slide tata letak dengan tipe tata letak kosong dan nama khusus.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Tambahkan kotak teks ke slide tata letak.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Tambahkan dua slide menggunakan tata letak ini; keduanya akan mewarisi teks dari tata letak.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Catatan 1:** Layout slide berfungsi sebagai templat untuk slide individual. Anda dapat mendefinisikan elemen umum sekali dan menggunakannya kembali di banyak slide.

> 💡 **Catatan 2:** Ketika Anda menambahkan bentuk atau teks ke layout slide, semua slide yang berdasarkan layout tersebut akan menampilkan konten bersama ini secara otomatis.
> Gambar di bawah ini menunjukkan dua slide, masing‑masing mewarisi kotak teks dari layout slide yang sama.

![Slide yang Mewarisi Konten Layout](layout-slide-result.png)

## **Akses Layout Slide**

Layout slide dapat diakses berdasarkan indeks atau tipe layout (misalnya, `Blank`, `Title`, `SectionHeader`, dll.).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Akses slide tata letak berdasarkan indeks.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Akses slide tata letak berdasarkan tipe.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Hapus Layout Slide**

Anda dapat menghapus layout slide tertentu jika tidak lagi dibutuhkan.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Ambil slide tata letak berdasarkan tipe dan hapus.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Hapus Layout Slide yang Tidak Digunakan**

Untuk mengurangi ukuran presentasi, Anda mungkin ingin menghapus layout slide yang tidak digunakan oleh slide biasa mana pun.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Secara otomatis menghapus semua slide tata letak yang tidak dirujuk oleh slide manapun.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Gandakan Layout Slide**

Anda dapat menduplikasi layout slide menggunakan metode `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Dapatkan slide tata letak yang ada berdasarkan tipe.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Gandakan slide tata letak ke akhir koleksi slide tata letak.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Ringkasan:** Layout slide merupakan alat yang kuat untuk mengelola pemformatan konsisten di seluruh slide. Aspose.Slides memungkinkan kontrol penuh atas pembuatan, pengelolaan, dan optimalisasi layout slide.