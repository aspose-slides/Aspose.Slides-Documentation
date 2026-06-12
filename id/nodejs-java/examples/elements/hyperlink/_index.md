---
title: Hyperlink
type: docs
weight: 130
url: /id/nodejs-java/examples/elements/hyperlink/
keywords:
- contoh kode
- hyperlink
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Menambahkan dan mengelola hyperlink di Aspose.Slides untuk Node.js: tautkan teks, bentuk, dan gambar, atur target serta aksi untuk PPT, PPTX, dan ODP dengan contoh."
---
Artikel ini menunjukkan cara menambahkan, mengakses, menghapus, dan memperbarui hyperlink pada bentuk menggunakan **Aspose.Slides for Node.js via Java**.

## **Menambahkan Hyperlink**

Buat bentuk persegi panjang dengan hyperlink yang mengarah ke situs web eksternal.

```js
function addHyperlink() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = new aspose.slides.Hyperlink("https://www.aspose.com");
        textPortion.getPortionFormat().setHyperlinkClick(hyperlink);

        presentation.save("hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Mengakses Hyperlink**

Baca hyperlink dari bagian teks sebuah bentuk.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Mengasumsikan bentuk pertama berisi teks dengan hyperlink.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Hyperlink**

Hapus hyperlink dari teks sebuah bentuk.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Mengasumsikan bentuk pertama berisi teks dengan hyperlink.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setHyperlinkClick(null);

        presentation.save("hyperlink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Memperbarui Hyperlink**

Ubah target hyperlink yang sudah ada. Gunakan `HyperlinkManager` untuk memodifikasi teks yang sudah berisi hyperlink, yang meniru cara PowerPoint memperbarui hyperlink secara aman.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Mengasumsikan bentuk pertama berisi teks dengan hyperlink.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // Mengubah hyperlink dalam teks yang ada harus dilakukan melalui
        // HyperlinkManager bukan dengan mengatur properti secara langsung.
        // Ini meniru cara PowerPoint memperbarui hyperlink dengan aman.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```