---
title: Slide
type: docs
weight: 10
url: /id/androidjava/examples/elements/slide/
keywords:
- contoh kode
- slide
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kontrol slide di Aspose.Slides untuk Android: buat, gandakan, ubah urutan, ubah ukuran, atur latar belakang, dan terapkan transisi dengan Java untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menyediakan serangkaian contoh yang menunjukkan cara bekerja dengan slide menggunakan **Aspose.Slides for Android via Java**. Anda akan belajar cara menambah, mengakses, menggandakan, mengubah urutan, dan menghapus slide menggunakan kelas `Presentation`.

Setiap contoh di bawah ini mencakup penjelasan singkat diikuti dengan potongan kode dalam Java.

## **Menambahkan Slide**

Untuk menambahkan slide baru, Anda harus terlebih dahulu memilih tata letak. Pada contoh ini, kami menggunakan tata letak `Blank` dan menambahkan slide kosong ke presentasi.

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Catatan:** Setiap tata letak slide berasal dari slide master, yang menentukan desain keseluruhan dan struktur placeholder. Gambar di bawah ini menggambarkan bagaimana slide master dan tata letaknya yang terkait diatur dalam PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Mengakses Slide berdasarkan Indeks**

Anda dapat mengakses slide menggunakan indeksnya, atau menemukan indeks sebuah slide berdasarkan referensi. Ini berguna untuk melakukan iterasi atau memodifikasi slide tertentu.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Tambahkan slide kosong lainnya.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Akses slide berdasarkan indeks.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Dapatkan indeks slide dari referensi, lalu akses dengan indeks.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Menggandakan Slide**

Contoh ini menunjukkan cara menggandakan slide yang ada. Slide yang digandakan secara otomatis ditambahkan ke akhir koleksi slide.

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Mengubah Urutan Slide**

Anda dapat mengubah urutan slide dengan memindahkan satu ke indeks baru. Dalam kasus ini, kami memindahkan slide yang digandakan ke posisi pertama.

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Slide**

Untuk menghapus slide, cukup referensikan dan panggil `remove`. Contoh ini menambahkan slide kedua dan kemudian menghapus slide asli, sehingga hanya slide baru yang tersisa.

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```