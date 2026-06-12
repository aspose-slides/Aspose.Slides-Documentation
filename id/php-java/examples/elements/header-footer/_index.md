---
title: HeaderFooter
type: docs
weight: 220
url: /id/php-java/examples/elements/header-footer/
keywords:
- header footer
- tambahkan header footer
- perbarui header footer
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kontrol header dan footer di PHP dengan Aspose.Slides: tambahkan atau edit tanggal/waktu, nomor slide, dan teks footer, tampilkan atau sembunyikan placeholder di seluruh PPT, PPTX, dan ODP."
---
Menampilkan cara menambahkan footer dan memperbarui placeholder tanggal dan waktu menggunakan **Aspose.Slides for PHP via Java**.

## **Tambahkan Footer**
Tambahkan teks ke area footer slide dan buat agar terlihat.

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Perbarui Tanggal dan Waktu**
Ubah placeholder tanggal dan waktu pada slide.

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```