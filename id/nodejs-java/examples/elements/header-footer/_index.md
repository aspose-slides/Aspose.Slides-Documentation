---
title: Header dan Footer
type: docs
weight: 220
url: /id/nodejs-java/examples/elements/header-footer/
keywords:
- contoh kode
- header
- footer
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kontrol header dan footer slide dengan Aspose.Slides for Node.js: tambahkan tanggal, nomor slide, dan teks khusus dalam PPT, PPTX, dan ODP dengan contoh JavaScript."
---
Artikel ini menunjukkan cara menambahkan footer dan memperbarui placeholder tanggal dan waktu menggunakan **Aspose.Slides for Node.js via Java**.

## **Menambahkan Footer**

Tambahkan teks ke area footer pada slide dan buat agar terlihat.

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Perbarui Tanggal dan Waktu**

Ubah placeholder tanggal dan waktu pada slide.

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```