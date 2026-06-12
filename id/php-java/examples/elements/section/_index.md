---
title: Bagian
type: docs
weight: 90
url: /id/php-java/examples/elements/section/
keywords:
- bagian
- bagian slide
- tambah bagian
- akses bagian
- hapus bagian
- ganti nama bagian
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kelola bagian slide di PHP dengan Aspose.Slides: buat, ganti nama, urutkan ulang dengan mudah, pindahkan slide antar bagian, dan kontrol visibilitas untuk PPT, PPTX, dan ODP."
---
Contoh mengelola bagian presentasi—menambah, mengakses, menghapus, dan mengganti nama secara programatis menggunakan **Aspose.Slides for PHP via Java**.

## **Tambah Bagian**

Buat bagian yang dimulai pada slide tertentu.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Tentukan slide yang menandai awal bagian.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Akses Bagian**

Baca informasi bagian dari presentasi.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // Akses bagian dengan indeks.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Hapus Bagian**

Hapus bagian yang sebelumnya ditambahkan.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // Hapus bagian.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ganti Nama Bagian**

Ubah nama bagian yang ada.

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```