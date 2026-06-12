---
title: ActiveX
type: docs
weight: 200
url: /id/php-java/examples/elements/activex/
keywords:
- ActiveX
- kontrol ActiveX
- menambahkan ActiveX
- mengakses ActiveX
- menghapus ActiveX
- properti ActiveX
- contoh kode
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara menemukan, mengedit, dan menghapus kontrol ActiveX di PHP dengan Aspose.Slides, termasuk pembaruan properti untuk presentasi PowerPoint."
---
Menunjukkan cara menambahkan, mengakses, menghapus, dan mengkonfigurasi kontrol ActiveX dalam sebuah presentasi menggunakan **Aspose.Slides for PHP via Java**.

## **Menambahkan Kontrol ActiveX**

Menyisipkan kontrol ActiveX baru.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Menambahkan kontrol ActiveX baru.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // Membuang presentasi.
        $presentation->dispose();
    }
}
```

## **Mengakses Kontrol ActiveX**

Membaca informasi dari kontrol ActiveX pertama pada slide.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Mengakses kontrol ActiveX pertama.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // Membuang presentasi.
        $presentation->dispose();
    }
}
```

## **Menghapus Kontrol ActiveX**

Menghapus kontrol ActiveX yang ada dari slide.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // Hapus kontrol ActiveX pertama.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // Membuang presentasi.
        $presentation->dispose();
    }
}
```

## **Mengatur Properti ActiveX**

Mengonfigurasi beberapa properti ActiveX.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Mengasumsikan kontrol pertama adalah yang kami tambahkan.
        $control = $slide->getControls()->get_Item(0);

        // Mengonfigurasi properti.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // Membuang presentasi.
        $presentation->dispose();
    }
}
```