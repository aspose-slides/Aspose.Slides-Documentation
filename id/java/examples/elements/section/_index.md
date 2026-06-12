---
title: Bagian
type: docs
weight: 90
url: /id/java/examples/elements/section/
keywords:
- contoh kode
- bagian
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Kelola bagian slide dalam Aspose.Slides untuk Java: buat, ganti nama, urutkan kembali, dan grupkan slide dengan contoh Java untuk PPT, PPTX, dan ODP."
---
Contoh mengelola bagian presentasi—menambah, mengakses, menghapus, dan mengganti nama secara programatis menggunakan **Aspose.Slides for Java**.

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

        // Akses bagian berdasarkan indeks.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Bagian**

Hapus sebuah bagian yang sebelumnya ditambahkan.

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

Ubah nama sebuah bagian yang ada.

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