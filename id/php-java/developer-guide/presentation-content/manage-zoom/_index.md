---
title: Kelola Zoom Presentasi di PHP
linktitle: Kelola Zoom
type: docs
weight: 60
url: /id/php-java/manage-zoom/
keywords:
- zoom
- frame zoom
- zoom slide
- zoom bagian
- zoom ringkasan
- tambahkan zoom
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Buat dan sesuaikan Zoom dengan Aspose.Slides untuk PHP via Java — melompat antar bagian, menambahkan gambar mini dan transisi dalam presentasi PowerPoint."
---
## **Pendahuluan**

Zoom PowerPoint memungkinkan Anda menavigasi antar slide dan bagian tertentu selama pertunjukan slide. Dengan Aspose.Slides untuk PHP melalui Java, Anda dapat membuat zoom slide, zoom bagian, dan zoom ringkasan serta menyesuaikan pratinjau, batas, dan transisinya.

![Ikhtisar zoom PowerPoint](overview.png)

* Untuk merangkum seluruh presentasi dalam satu slide, gunakan [Ringkasan Zoom](#summary-zoom).
* Untuk menampilkan hanya slide tertentu, gunakan [Zoom Slide](#slide-zoom).
* Untuk menampilkan hanya satu bagian, gunakan [Zoom Bagian](#section-zoom).

## **Zoom Slide**

Zoom slide dapat membuat presentasi Anda lebih dinamis, memungkinkan Anda menavigasi bebas antar slide dalam urutan apa pun tanpa mengganggu alur presentasi. Zoom slide cocok untuk presentasi singkat tanpa banyak bagian, tetapi Anda tetap dapat menggunakannya dalam berbagai skenario presentasi.

Zoom slide memungkinkan Anda menjelajahi informasi terkait dari satu slide ikhtisar.

![Memilih slide untuk zoom slide](slidezoomsel.png)

Untuk objek zoom slide, Aspose.Slides menyediakan enumerasi [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/zoomimagetype/), kelas [ZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/), dan metode pada kelas [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **Membuat Frame Zoom**

Gunakan [ShapeCollection::addZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addZoomFrame) untuk menempatkan tautan ke slide individual pada slide ikhtisar. Contoh ini membuat dua slide target dengan latar belakang dan label yang berbeda, lalu menambahkan pratinjau masing‑masing ke slide pertama dan menyimpan presentasi sebagai PPTX. Posisi dan ukuran frame ditentukan dalam poin.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $secondSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $thirdSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());

    $secondSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $secondSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $secondSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");

    $thirdSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $thirdSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 189, 183, 107);
    $thirdSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

    $textBox = $thirdSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Third Slide");

    $overviewSlide->getShapes()->addZoomFrame(20, 20, 250, 200, $secondSlide);
    $overviewSlide->getShapes()->addZoomFrame(200, 250, 250, 200, $thirdSlide);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Membuat Frame Zoom dengan Gambar Kustom**

Berikan gambar kustom ke [ShapeCollection::addZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addZoomFrame) untuk mengganti pratinjau default slide target. Contoh ini membutuhkan gambar lokal, memuatnya dengan [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile), dan menambahkannya ke presentasi menggunakan [ImageCollection::addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/#addImage). Frame yang dihasilkan menampilkan gambar tersebut sambil tetap menautkan ke slide kedua.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $overviewSlide->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $previewImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Memformat Frame Zoom**

Contoh ini menyesuaikan dua frame zoom slide. Ia menetapkan gambar lokal ke frame pertama melalui [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage), dan memberi frame kedua batas pink dash‑dot berukuran lima poin melalui [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat). Memberikan `false` ke [ZoomObject::setShowBackground](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setShowBackground) menyembunyikan latar belakang frame kedua. Gambar lokal diperlukan untuk pratinjau kustom; kedua frame tetap mempertahankan target slide mereka dalam PPTX yang disimpan.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $secondSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $thirdSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());

    $secondSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $secondSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $secondSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");

    $thirdSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $thirdSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 189, 183, 107);
    $thirdSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

    $textBox = $thirdSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Third Slide");

    $firstZoomFrame = $overviewSlide->getShapes()->addZoomFrame(20, 20, 250, 200, $secondSlide);
    $secondZoomFrame = $overviewSlide->getShapes()->addZoomFrame(200, 250, 250, 200, $thirdSlide);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $firstZoomFrame->setZoomImage($previewImage);

    $secondZoomFrame->getLineFormat()->setWidth(5);
    $secondZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 105, 180);
    $secondZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($color);
    $secondZoomFrame->getLineFormat()->setDashStyle(LineDashStyle::DashDot);

    $secondZoomFrame->setShowBackground(false);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zoom Bagian**

Zoom bagian menautkan ke sebuah bagian dalam presentasi Anda. Gunakan untuk mengunjungi kembali sebuah topik atau menunjukkan bagaimana bagian‑bagian berbeda dalam presentasi saling terhubung.

![Memilih bagian untuk zoom bagian](seczoomsel.png)

Untuk objek zoom bagian, Aspose.Slides menyediakan kelas [SectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) dan metode pada kelas [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **Membuat Frame Zoom Bagian**

Buat sebuah bagian dengan [SectionCollection::addSection](https://reference.aspose.com/slides/php-java/aspose.slides/sectioncollection/#addSection), lalu berikan bagian yang dikembalikan ke [ShapeCollection::addSectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSectionZoomFrame). Contoh ini menempatkan zoom bagian pada slide pertama dan menautkannya ke bagian yang dimulai dengan slide berwarna. Posisi dan ukuran frame ditentukan dalam poin, dan presentasi disimpan sebagai PPTX.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $section = $presentation->getSections()->addSection("Section 1", $slide);
    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Membuat Frame Zoom Bagian dengan Gambar Kustom**

Overload gambar dari [ShapeCollection::addSectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSectionZoomFrame) memungkinkan Anda menampilkan pratinjau kustom tanpa mengubah bagian tujuan. Contoh ini membutuhkan gambar lokal, yang dimuat dengan [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) dan ditambahkan melalui [ImageCollection::addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/#addImage). Presentasi yang disimpan berisi zoom bagian pada slide pertama yang ditautkan ke bagian yang baru dibuat.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $section = $presentation->getSections()->addSection("Section 1", $slide);
    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section, $previewImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Mengubah Bagian Target Zoom Bagian**

Gunakan [SectionZoomFrame::setTargetSection](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/#setTargetSection) untuk mengarahkan ulang zoom bagian yang ada tanpa membuatnya kembali. Pilih sebuah bagian terisi dari koleksi [Presentation::getSections](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSections) pada presentasi yang sama. Menetapkan bagian kosong membiarkan target saat ini tidak berubah, jadi periksa [Section::getSlidesListOfSection](https://reference.aspose.com/slides/php-java/aspose.slides/section/#getSlidesListOfSection) sebelum menetapkannya. Lihat [Manage Slide Sections](/slides/id/php-java/slide-section/) untuk informasi lebih lanjut tentang bagian.

Contoh berikut memuat berkas presentasi, yang harus berisi beberapa bagian terisi, sebuah zoom bagian yang ada bernama `Section navigation`, dan sebuah bagian dengan nama unik `Results`. Ia mencari semua slide untuk zoom tersebut dan menemukan tujuan berdasarkan nama, bukan indeks koleksi yang dapat berubah ketika bagian diurutkan ulang. Jika nama tidak unik, gunakan [Section::getSectionId](https://reference.aspose.com/slides/php-java/aspose.slides/section/#getSectionId) untuk mengidentifikasi tujuan.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("section-zoom.pptx");
try {
    $zoom = null;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($i = 0; $i < $slideCount; $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($j = 0; $j < $shapeCount; $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISectionZoomFrame")) && java_values($shape->getName()) === "Section navigation") {
                $zoom = $shape;
                break;
            }
        }
        if ($zoom != null) {
            break;
        }
    }

    $targetSection = null;
    $sectionCount = java_values($presentation->getSections()->size());
    for ($i = 0; $i < $sectionCount; $i++) {
        $section = $presentation->getSections()->get_Item($i);
        if (java_values($section->getName()) === "Results") {
            $targetSection = $section;
            break;
        }
    }

    if ($zoom == null || $targetSection == null) {
        echo "The section zoom or destination section was not found.", PHP_EOL;
    } else if (java_values($targetSection->getSlidesListOfSection()->size()) == 0) {
        echo "The destination section is empty.", PHP_EOL;
    } else {
        $currentSection = $zoom->getTargetSection();
        echo "Current section: " . (java_is_null($currentSection) ? "" : java_values($currentSection->getName())), PHP_EOL;
        $zoom->setTargetSection($targetSection);
        $presentation->save("section-zoom-updated.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

### **Memformat Frame Zoom Bagian**

Contoh ini memindahkan dan mengubah ukuran zoom bagian menjadi 100 × 75 poin, menetapkan gambar lokal melalui [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage), dan menerapkan batas coklat dash‑dot berukuran 2,5 poin. Ia mengaktifkan [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) untuk kembali ke slide asal setelah bagian, menonaktifkan [ZoomObject::setShowBackground](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setShowBackground), serta mengatur [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) ke 1,5 detik. Gambar lokal diperlukan untuk pratinjau kustom.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $section = $presentation->getSections()->addSection("Section 1", $slide);

    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section);
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $sectionZoomFrame->setZoomImage($previewImage);

    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);

    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($color);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle::DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);

    $sectionZoomFrame->setTransitionDuration(1.5);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zoom Ringkasan**

Zoom ringkasan menyediakan ikhtisar bagian‑bagian presentasi. Selama pertunjukan slide, Anda dapat menggunakannya untuk melompat ke sebuah bagian, melewatkan ke depan, atau mengunjungi kembali sebuah topik tanpa mengikuti urutan slide.

![Memilih bagian untuk zoom ringkasan](sumzoomsel.png)

Untuk objek zoom ringkasan, Aspose.Slides menyediakan kelas [SummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/), dan [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/), serta metode pada kelas [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **Membuat Zoom Ringkasan**

Gunakan [ShapeCollection::addSummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSummaryZoomFrame) untuk membuat ikhtisar bagian‑bagian presentasi. Contoh ini membuat empat bagian dengan latar belakang slide yang berbeda dan menambahkan zoom ringkasan ke slide pertama. Posisi dan ukuran frame ditentukan dalam poin, dan ikhtisar yang dihasilkan disimpan dalam presentasi PPTX.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 127, 255, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 3", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 100, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 4", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Menambah dan Menghapus Bagian Zoom Ringkasan**

Zoom ringkasan menyimpan objek [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/) dalam [SummaryZoomFrame::getSummaryZoomCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection). Contoh ini membuat ikhtisar dua bagian, menambahkan bagian ketiga menggunakan [SummaryZoomSectionCollection::addSummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection), dan menghapus entri bagian pertama menggunakan [SummaryZoomSectionCollection::removeSummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection). Penghapusan entri tidak mengubah bagian presentasi dan slidennya.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $firstSection = $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 127, 255, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $thirdSection = $presentation->getSections()->addSection("Section 3", $slide);

    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($thirdSection);

    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($firstSection);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Memformat Bagian Zoom Ringkasan**

Contoh ini memformat entri pertama dalam [SummaryZoomFrame::getSummaryZoomCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection), menggunakan indeks berbasis nol `0`. Ia memerlukan gambar lokal untuk [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage), menerapkan batas hitam dash‑dot berukuran 1,5 poin, dan mengatur [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) ke 1,5 detik. Memberikan `false` ke [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) menonaktifkan pengembalian otomatis ke slide ringkasan untuk entri ini.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $summarySection->setZoomImage($previewImage);
    $summarySection->setReturnToParent(false);

    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle::DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);

    $summarySection->setTransitionDuration(1.5);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apakah saya dapat mengontrol pengembalian ke slide ‘parent’ setelah menampilkan target?**

Ya. Panggil [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) dengan `true` untuk kembali ke slide asal setelah konten target ditampilkan.

**Apakah saya dapat menyesuaikan ‘kecepatan’ atau durasi transisi Zoom?**

Ya. Gunakan [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) untuk mengatur durasi transisi dalam detik.

**Apakah ada batasan berapa banyak objek Zoom yang dapat dimiliki sebuah presentasi?**

Tidak ada batas API keras yang didokumentasikan. Batas praktis tergantung pada kompleksitas keseluruhan presentasi dan kinerja penampil. Anda dapat menambahkan banyak frame Zoom, tetapi pertimbangkan ukuran berkas dan waktu render.