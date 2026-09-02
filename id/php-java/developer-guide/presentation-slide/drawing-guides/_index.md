---
title: Kelola Garis Panduan dalam Presentasi di PHP
linktitle: Garis Panduan
type: docs
weight: 85
url: /id/php-java/drawing-guides/
keywords:
- garis panduan
- garis panduan horizontal
- garis panduan vertikal
- garis panduan penyelarasan
- tampilan slide
- slide master
- slide tata letak
- master catatan
- master handout
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Tambahkan, akses, dan bersihkan garis panduan horizontal serta vertikal dalam presentasi PowerPoint menggunakan Aspose.Slides untuk PHP via Java."
---
## **Ikhtisar**

Garis panduan adalah garis horizontal dan vertikal yang dapat disesuaikan yang membantu pengguna menyelaraskan bentuk secara konsisten saat mengedit presentasi di PowerPoint. Mereka sangat berguna ketika sebuah aplikasi menghasilkan presentasi yang kemudian akan disempurnakan secara manual: aplikasi dapat menyimpan bantuan penyelarasan yang sama yang harus diikuti penulis saat menambahkan atau memindahkan konten.

Garis panduan adalah bantuan pengeditan, bukan konten slide. Mereka tidak muncul dalam tampilan slide atau output yang dirender. Aspose.Slides untuk PHP via Java mengeksposnya melalui kelas [DrawingGuidesCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/drawingguidescollection/). Sebuah panduan direpresentasikan oleh [DrawingGuide](https://reference.aspose.com/slides/id/php-java/aspose.slides/drawingguide/) dan memiliki orientasi, posisi, dan warna.

Posisi diukur dalam poin dari sudut kiri‑atas slide atau master yang relevan. Garis panduan vertikal menggunakan koordinat horizontal, biasanya antara nol dan lebar slide. Garis panduan horizontal menggunakan koordinat vertikal, biasanya antara nol dan tinggi slide.

## **Menambahkan Garis Panduan ke Tampilan Slide**

Gunakan [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/id/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) untuk mengelola panduan yang ditampilkan saat mengedit slide normal. Panggil [DrawingGuidesCollection::add](https://reference.aspose.com/slides/id/php-java/aspose.slides/drawingguidescollection/#add) dengan nilai [Orientation](https://reference.aspose.com/slides/id/php-java/aspose.slides/orientation/) dan posisi dalam poin.

Contoh berikut menambahkan satu panduan vertikal di sebelah kanan tengah slide dan satu panduan horizontal di bawahnya:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Mengakses Garis Panduan**

Metode [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/id/php-java/aspose.slides/drawingguidescollection/#getCount) dan [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/id/php-java/aspose.slides/drawingguidescollection/#get_Item) menyediakan akses ke panduan yang ada. Metode [DrawingGuide::getOrientation](https://reference.aspose.com/slides/id/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/id/php-java/aspose.slides/drawingguide/#getPosition), dan [DrawingGuide::getColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/drawingguide/#getColor) mengembalikan nilai yang juga dapat diubah melalui metode setter yang bersangkutan.

Contoh berikut membaca panduan tampilan slide dari presentasi yang dibuat di atas:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Menambahkan Garis Panduan ke Slide Master dan Layout**

Sebuah slide master dan setiap slide layoutnya dapat memiliki koleksi garis panduan masing‑masing. Gunakan [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/#getDrawingGuides) untuk slide master dan [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#getDrawingGuides) untuk slide layout.

Contoh berikut menambahkan satu panduan vertikal ke slide master pertama dan satu panduan horizontal ke slide layout pertama:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menambahkan Garis Panduan ke Master Catatan dan Handout**

Master catatan dan master handout juga mendukung garis panduan. Gunakan [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/id/php-java/aspose.slides/masternotesslide/#getDrawingGuides) dan [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) untuk mengakses koleksinya. Jika sebuah presentasi tidak berisi salah satu master ini, ambil manajer yang sesuai dengan [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) atau [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager), lalu buat master default dengan `setDefaultMasterNotesSlide` atau `setDefaultMasterHandoutSlide`.

Contoh berikut menambahkan satu panduan horizontal ke master catatan dan satu panduan vertikal ke master handout:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menghapus Garis Panduan**

Panggil [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/id/php-java/aspose.slides/drawingguidescollection/#clear) untuk menghapus semua panduan dari koleksi tertentu. Menghapus satu koleksi tidak memengaruhi panduan yang disimpan di ruang lingkup lain.

Contoh berikut menghapus panduan tampilan slide serta semua panduan pada slide master, slide layout, master catatan, dan master handout tanpa membuat master yang hilang:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apakah garis panduan muncul dalam tampilan slide atau gambar yang diekspor?**

Tidak. Garis panduan adalah bantuan penyelarasan untuk pengeditan dan tidak dirender sebagai konten presentasi.

**Apakah sebuah garis panduan dapat ditambahkan langsung ke slide normal individu?**

Panduan pengeditan slide normal disimpan dalam properti tampilan slide presentasi. Koleksi panduan terpisah tersedia untuk slide master, slide layout, master catatan, dan master handout.

**Unit apa yang digunakan untuk posisi panduan?**

Posisi ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Posisi vertikal diukur dari tepi kiri, dan posisi horizontal diukur dari tepi atas.

**Apakah menghapus garis panduan menghilangkan bentuk atau mengubah konten slide?**

Tidak. Metode [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/id/php-java/aspose.slides/drawingguidescollection/#clear) hanya menghapus panduan dalam koleksi yang dipilih. Bentuk dan konten slide lainnya tetap tidak berubah.