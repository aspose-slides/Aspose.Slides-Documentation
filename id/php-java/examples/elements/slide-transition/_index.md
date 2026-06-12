---
title: TransisiSlide
type: docs
weight: 110
url: /id/php-java/examples/elements/slide-transition/
keywords:
- transisi slide
- tambahkan transisi slide
- akses transisi slide
- hapus transisi slide
- durasi transisi
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kontrol transisi slide dalam PHP dengan Aspose.Slides: pilih jenis, kecepatan, suara, dan pengaturan waktu untuk memoles presentasi dalam PPT, PPTX, dan ODP."
---
Menunjukkan cara menerapkan efek transisi slide dan penjadwalan dengan **Aspose.Slides for PHP via Java**.

## **Tambahkan Transisi Slide**

Terapkan efek transisi fade pada slide pertama.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Terapkan transisi fade.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Akses Transisi Slide**

Baca jenis transisi yang ditetapkan untuk sebuah slide.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Akses jenis transisi.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Hapus Transisi Slide**

Hilangkan semua efek transisi dengan mengatur jenisnya ke `None`.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Hapus transisi dengan mengatur none.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Atur Durasi Transisi**

Tentukan berapa lama slide ditampilkan sebelum berpindah secara otomatis.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // dalam milidetik.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```