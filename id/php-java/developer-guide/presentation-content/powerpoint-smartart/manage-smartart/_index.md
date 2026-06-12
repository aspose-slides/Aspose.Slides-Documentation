---
title: Kelola SmartArt dalam Presentasi PowerPoint Menggunakan PHP
linktitle: Kelola SmartArt
type: docs
weight: 10
url: /id/php-java/manage-smartart/
keywords:
- SmartArt
- Teks SmartArt
- tipe tata letak
- properti tersembunyi
- bagan organisasi
- bagan organisasi gambar
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara membuat dan mengedit SmartArt PowerPoint dengan Aspose.Slides untuk PHP melalui Java menggunakan contoh kode yang jelas yang mempercepat desain slide dan otomatisasi."
---
## **Gambaran Umum**

SmartArt adalah diagram PowerPoint yang dibuat dari node, bentuk node, dan tata letak. Dengan Aspose.Slides untuk PHP melalui Java, Anda dapat membuat SmartArt, membaca teks dari node-nya, mengubah tata letaknya, memeriksa node tersembunyi, mengkonfigurasi tata letak bagan organisasi, dan membuat bagan organisasi bergambar.

## **Dapatkan Teks dari Objek SmartArt**

Sebuah node SmartArt dapat berisi satu atau lebih bentuk. Untuk membaca teks yang terlihat, iterasi melalui [SmartArt::getAllNodes](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/#getAllNodes), kemudian baca [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) yang dikembalikan oleh [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartartshape/#getTextFrame).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Ubah Tipe Tata Letak Objek SmartArt**

Tata letak SmartArt mengontrol bagaimana node diatur dan dihubungkan. Contoh berikut membuat objek SmartArt dengan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, mengubahnya menjadi nilai `BasicProcess`, dan menyimpan presentasi.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Periksa Apakah Node SmartArt Tersembunyi**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartartnode/ishidden/) menunjukkan apakah node tersembunyi dalam model data SmartArt. Node tersembunyi dapat ada dalam struktur bahkan ketika tata letak yang dipilih tidak menampilkannya sebagai elemen diagram yang terlihat.

Contoh berikut menambahkan node ke objek SmartArt yang menggunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` dan memeriksa status tersembunyi node tersebut.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Dapatkan atau Atur Tata Letak Bagan Organisasi**

Untuk diagram SmartArt yang menggunakan tata letak bagan organisasi, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) dan [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) menentukan bagaimana node anak diatur di bawah node induk. Misalnya, Anda dapat mengatur node anak menggantung di kiri, kanan, atau kedua sisi, tergantung pada [OrganizationChartLayoutType](https://reference.aspose.com/slides/id/php-java/aspose.slides/organizationchartlayouttype/) yang dipilih.

Contoh berikut membuat bagan organisasi dan mengatur tata letak untuk node pertama ke nilai [OrganizationChartLayoutType](https://reference.aspose.com/slides/id/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Buat Bagan Organisasi Gambar**

Bagan organisasi gambar adalah tata letak SmartArt yang dirancang untuk diagram hierarki yang menyertakan placeholder gambar. Gunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` saat menambahkan objek SmartArt ke slide.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apakah SmartArt mendukung pencerminan atau pembalikan untuk bahasa RTL?**

Ya. Metode [SmartArt::setReversed](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/setreversed/) mengubah arah diagram dari kiri-ke-kanan menjadi kanan-ke-kiri, atau sebaliknya, ketika tata letak SmartArt yang dipilih mendukung pembalikan.

**Bagaimana cara menyalin SmartArt ke slide yang sama atau ke presentasi lain sambil mempertahankan format?**

Anda dapat [mengkloning bentuk SmartArt](/slides/id/php-java/shape-manipulations/) dengan [ShapeCollection::addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addclone/) atau [mengkloning seluruh slide](/slides/id/php-java/clone-slides/) yang berisi SmartArt. Kedua pendekatan mempertahankan ukuran, posisi, dan pemformatan.

**Bagaimana cara merender SmartArt ke gambar raster untuk pratinjau atau ekspor web?**

[Render slide](/slides/id/php-java/convert-powerpoint-to-png/) atau seluruh presentasi ke PNG atau JPEG. SmartArt dirender sebagai bagian dari slide.

**Bagaimana saya dapat menemukan objek SmartArt tertentu pada slide jika ada beberapa?**

Tetapkan nilai [Shape::getAlternativeText](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getalternativetext/) atau [Shape::getName](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getname/) yang khas pada bentuk SmartArt, cari nilai tersebut dalam [BaseSlide::getShapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/#getShapes), kemudian pastikan bahwa bentuk yang cocok adalah [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/).