---
title: Hyperlink
type: docs
weight: 130
url: /id/php-java/examples/elements/hyperlink/
keywords:
- hyperlink
- tambahkan hyperlink
- akses hyperlink
- hapus hyperlink
- perbarui hyperlink
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Tambahkan, edit, dan hapus hyperlink dalam PHP dengan Aspose.Slides: teks tautan, bentuk, slide, URL, dan email; atur target serta aksi untuk PPT, PPTX, dan ODP."
---
Menunjukkan cara menambahkan, mengakses, menghapus, dan memperbarui hyperlink pada bentuk menggunakan **Aspose.Slides for PHP via Java**.

## **Menambahkan Hyperlink**

Buat bentuk persegi panjang dengan hyperlink yang mengarah ke situs web eksternal.

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Mengakses Hyperlink**

Baca informasi hyperlink dari bagian teks sebuah bentuk.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Dengan asumsi bentuk pertama berisi hyperlink.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **Menghapus Hyperlink**

Hapus hyperlink dari teks sebuah bentuk.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Dengan asumsi bentuk pertama berisi hyperlink.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Memperbarui Hyperlink**

Ubah target hyperlink yang sudah ada. Gunakan `HyperlinkManager` untuk memodifikasi teks yang sudah berisi hyperlink, meniru cara PowerPoint memperbarui hyperlink dengan aman.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Dengan asumsi bentuk pertama berisi hyperlink.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // Mengubah hyperlink dalam teks yang ada harus dilakukan melalui
        // HyperlinkManager daripada menyetel properti secara langsung.
        // Ini meniru cara PowerPoint memperbarui hyperlink dengan aman.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```