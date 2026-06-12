---
title: Header dan Footer
type: docs
weight: 220
url: /id/java/examples/elements/header-footer/
keywords:
- contoh kode
- header
- footer
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Kontrol header dan footer slide dengan Aspose.Slides for Java: tambahkan tanggal, nomor slide, dan teks khusus dalam PPT, PPTX, dan ODP dengan contoh Java."
---
Artikel ini menunjukkan cara menambahkan footer dan memperbarui placeholder tanggal dan waktu menggunakan **Aspose.Slides for Java**.

## **Menambahkan Footer**

Tambahkan teks ke area footer pada slide dan buat agar terlihat.

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **Perbarui Tanggal dan Waktu**

Ubah placeholder tanggal dan waktu pada slide.

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```