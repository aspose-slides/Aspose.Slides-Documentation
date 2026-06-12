---
title: Bagian
type: docs
weight: 90
url: /id/androidjava/examples/elements/section/
keywords:
- contoh kode
- bagian
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola bagian slide di Aspose.Slides untuk Android: buat, ganti nama, urutkan kembali, dan kelompokkan slide dengan contoh Java untuk PPT, PPTX, dan ODP."
---
Contoh mengelola bagian presentasi—menambah, mengakses, menghapus, dan mengganti nama secara programatis menggunakan **Aspose.Slides for Android via Java**.

## **Menambahkan Bagian**

Buat sebuah bagian yang dimulai pada slide tertentu.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Tentukan slide yang menandai awal bagian.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Mengakses Bagian**

Baca informasi bagian dari sebuah presentasi.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Akses sebuah bagian berdasarkan indeks.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Bagian**

Hapus bagian yang telah ditambahkan sebelumnya.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Hapus bagian pertama.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Mengganti Nama Bagian**

Ubah nama bagian yang ada.

```java
static void renameSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("Old Name", slide);

        ISection section = presentation.getSections().get_Item(0);
        section.setName("New Name");
    } finally {
        presentation.dispose();
    }
}
```