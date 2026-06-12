---
title: Slide
type: docs
weight: 10
url: /id/java/examples/elements/slide/
keywords:
- contoh kode
- slide
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Mengontrol slide di Aspose.Slides for Java: membuat, mengkloning, mengubah urutan, mengubah ukuran, mengatur latar belakang, dan menerapkan transisi dengan Java untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menyediakan serangkaian contoh yang menunjukkan cara bekerja dengan slide menggunakan **Aspose.Slides for Java**. Anda akan belajar cara menambahkan, mengakses, mengkloning, mengubah urutan, dan menghapus slide menggunakan kelas `Presentation`.

Setiap contoh di bawah ini mencakup penjelasan singkat diikuti dengan cuplikan kode dalam Java.

## **Tambahkan Slide**

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

> 💡 **Catatan:** Setiap tata letak slide diturunkan dari slide master, yang menentukan desain keseluruhan dan struktur placeholder. Gambar di bawah menggambarkan bagaimana slide master dan tata letak terkaitnya diatur dalam PowerPoint.

![Hubungan Master dan Layout](master-layout-slide.png)

## **Akses Slide berdasarkan Indeks**

Anda dapat mengakses slide menggunakan indeksnya, atau menemukan indeks sebuah slide berdasarkan referensi. Ini berguna untuk iterasi atau memodifikasi slide tertentu.

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

        // Dapatkan indeks slide dari referensi, kemudian akses berdasarkan indeks.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Klon Slide**

Contoh ini menunjukkan cara mengkloning slide yang ada. Slide yang diklon otomatis ditambahkan ke akhir koleksi slide.

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

## **Urutkan Ulang Slide**

Anda dapat mengubah urutan slide dengan memindahkan satu ke indeks baru. Dalam kasus ini, kami memindahkan slide yang diklon ke posisi pertama.

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

## **Hapus Slide**

Untuk menghapus slide, cukup referensikan dan panggil `remove`. Contoh ini menambahkan slide kedua lalu menghapus slide asli, sehingga hanya slide baru yang tersisa.

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