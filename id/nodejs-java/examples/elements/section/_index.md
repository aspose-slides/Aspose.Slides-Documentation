---
title: Bagian
type: docs
weight: 90
url: /id/nodejs-java/examples/elements/section/
keywords:
- contoh kode
- bagian
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola bagian slide di Aspose.Slides untuk Node.js via Java: membuat, mengganti nama, menyusun ulang, dan mengelompokkan slide dengan contoh JavaScript untuk PPT, PPTX, dan ODP."
---
Contoh untuk mengelola bagian presentasi—menambah, mengakses, menghapus, dan mengganti nama secara programatis menggunakan **Aspose.Slides for Node.js via Java**.

## **Tambah Bagian**

Buat sebuah bagian yang dimulai pada slide tertentu.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Tentukan slide yang menandai awal bagian.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Akses Bagian**

Baca informasi bagian dari sebuah presentasi.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Akses sebuah bagian berdasarkan indeks.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Hapus Bagian**

Hapus sebuah bagian yang sebelumnya telah ditambahkan.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Hapus bagian pertama.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ganti Nama Bagian**

Ubah nama bagian yang ada.

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```