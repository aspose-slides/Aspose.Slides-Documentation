---
title: Slide Tata Letak
type: docs
weight: 20
url: /id/java/examples/elements/layout-slide/
keywords:
- contoh kode
- slide tata letak
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Kuasai layout slide di Aspose.Slides untuk Java: pilih, terapkan, dan sesuaikan tata letak slide, placeholder, dan master dengan contoh Java untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara bekerja dengan **Layout Slides** di Aspose.Slides untuk Java. Sebuah layout slide menentukan desain dan pemformatan yang diwariskan oleh slide normal. Anda dapat menambahkan, mengakses, mengkloning, dan menghapus layout slide, serta membersihkan yang tidak terpakai untuk mengurangi ukuran presentasi.

## **Menambahkan Layout Slide**

Anda dapat membuat layout slide khusus untuk mendefinisikan pemformatan yang dapat digunakan kembali. Sebagai contoh, Anda dapat menambahkan kotak teks yang muncul di semua slide yang menggunakan layout ini.

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

> 💡 **Catatan 1:** Layout slides berfungsi sebagai templat untuk slide individual. Anda dapat mendefinisikan elemen umum sekali dan menggunakannya kembali di banyak slide.

> 💡 **Catatan 2:** Ketika Anda menambahkan bentuk atau teks ke layout slide, semua slide yang didasarkan pada layout tersebut akan menampilkan konten bersama ini secara otomatis. > Tangkapan layar di bawah menunjukkan dua slide, masing-masing mewarisi kotak teks dari layout slide yang sama.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Mengakses Layout Slide**

Layout slides dapat diakses melalui indeks atau melalui tipe layout (misalnya `Blank`, `Title`, `SectionHeader`, dll.).

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

## **Menghapus Layout Slide**

Anda dapat menghapus layout slide tertentu jika tidak lagi diperlukan.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Dapatkan slide tata letak berdasarkan tipe dan hapus.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Layout Slide yang Tidak Digunakan**

Untuk mengurangi ukuran presentasi, Anda mungkin ingin menghapus layout slide yang tidak digunakan oleh slide normal mana pun.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Secara otomatis menghapus semua slide tata letak yang tidak direferensikan oleh slide manapun.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Menggandakan Layout Slide**

Anda dapat menggandakan layout slide menggunakan metode `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Dapatkan slide tata letak yang ada berdasarkan tipe.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Kloning slide tata letak ke akhir koleksi slide tata letak.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Ringkasan:** Layout slides adalah alat yang kuat untuk mengelola pemformatan konsisten di seluruh slide. Aspose.Slides memungkinkan kontrol penuh atas pembuatan, pengelolaan, dan pengoptimalan layout slide.