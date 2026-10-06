---
title: Kelola SmartArt dalam Presentasi PowerPoint Menggunakan PHP
linktitle: Kelola SmartArt
type: docs
weight: 10
url: /id/php-java/manage-smartart/
keywords:
- SmartArt
- Teks SmartArt
- jenis tata letak
- properti tersembunyi
- bagan organisasi
- bagan organisasi bergambar
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara membuat dan mengedit SmartArt PowerPoint dengan Aspose.Slides untuk PHP via Java menggunakan contoh kode yang jelas yang mempercepat desain slide dan otomatisasi."
---
## **Ringkasan**

SmartArt adalah diagram PowerPoint yang dibuat dari node, bentuk node, dan tata letak. Dengan Aspose.Slides untuk PHP via Java, Anda dapat membuat SmartArt, membaca teks dari node-nya, mengubah tata letaknya, memeriksa node tersembunyi, mengkonfigurasi tata letak bagan organisasi, dan membuat bagan organisasi bergambar.

## **Dapatkan Teks dari Objek SmartArt**

Sebuah node SmartArt dapat berisi satu atau lebih bentuk. Untuk membaca teks dari bentuk node, iterasi melalui [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/), kemudian baca [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) yang dikembalikan oleh [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/).

Contoh ini memerlukan presentasi dengan setidaknya satu slide dan objek SmartArt sebagai bentuk pertama pada slide tersebut. Ini mencetak setiap bingkai teks yang tersedia ke konsol.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Ubah Jenis Tata Letak Objek SmartArt**

Tata letak SmartArt mengontrol cara node disusun dan dihubungkan. Contoh berikut membuat objek SmartArt dengan nilai `BasicBlockList` dari [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/), mengubahnya menjadi nilai `BasicProcess`, dan menyimpan presentasi. Posisi dan ukuran yang diberikan ke [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) diukur dalam poin. Gunakan [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) untuk mengubah tata letak.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Periksa Apakah Node SmartArt Tersembunyi**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) menunjukkan apakah node tersembunyi dalam model data SmartArt. Node tersembunyi dapat ada dalam struktur meskipun tata letak yang dipilih tidak menampilkannya sebagai elemen diagram yang terlihat.

Contoh berikut menambahkan node ke objek SmartArt yang menggunakan nilai `RadialCycle` dari [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/), dan memeriksa status tersembunyi node yang ditambahkan. Ini mencetak pesan jika node tersembunyi dan menyimpan diagram.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Dapatkan atau Atur Tata Letak Bagan Organisasi**

Untuk diagram SmartArt yang menggunakan tata letak bagan organisasi, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) dan [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) menentukan bagaimana node anak disusun di bawah node induk. Misalnya, Anda dapat mengatur node anak menggantung dari kiri, kanan, atau kedua sisi, tergantung pada [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) yang dipilih.

Contoh berikut membuat bagan organisasi dan mengatur tata letak untuk node pertama ke nilai `LeftHanging` dari [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/). Indeks berbasis nol `0` memilih node tingkat atas pertama; node anaknya menggunakan susunan yang dipilih. Presentasi yang telah dimodifikasi kemudian disimpan.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Buat Bagan Organisasi Bergambar**

Bagan organisasi bergambar adalah tata letak SmartArt yang dirancang untuk diagram hierarki yang mencakup placeholder gambar. Gunakan nilai `PictureOrganizationChart` dari [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) saat menambahkan objek SmartArt ke slide. Contoh ini menyimpan diagram dengan placeholder gambar; ia tidak mengisi placeholder tersebut dengan gambar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Konversi Diagram Legacy menjadi Grup Bentuk**

Saat memodernisasi presentasi yang ada, Anda mungkin perlu memperbarui bagan organisasi yang awalnya dibuat di PowerPoint 97–2003. Aspose.Slides merepresentasikan diagram legacy ini sebagai objek [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/). Gunakan [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) untuk mengonversi diagram menjadi grup bentuk sehingga Anda dapat menyunting elemen visual individu. Lihat [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) untuk detail.

Konversi menambahkan grup baru ke koleksi bentuk tanpa menghapus diagram asli. Setelah konversi berhasil, hapus yang asli dengan [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) untuk menghindari konten duplikat. Kumpulkan diagram legacy ke dalam daftar sebelum mengonversinya sehingga penambahan dan penghapusan bentuk tidak mengganggu iterasi.

Contoh berikut membuka presentasi, mencari setiap slide, mengonversi diagram menjadi grup bentuk, dan menyimpan presentasi yang diperbarui sebagai PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Presentasi yang disimpan berisi grup bentuk yang dapat disunting menggantikan diagram legacy yang dikonversi, tanpa diagram asli yang tersisa di sampingnya. Buka PPTX di PowerPoint untuk menyunting elemen individu dalam setiap grup, seperti teks, isian, atau posisi mereka.

## **FAQ**

**Apakah SmartArt mendukung pencerminan atau pembalikan untuk bahasa RTL?**

Ya. Metode [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) mengubah arah diagram dari kiri-ke-kanan menjadi kanan-ke-kiri, atau sebaliknya, ketika tata letak SmartArt yang dipilih mendukung pembalikan.

**Bagaimana saya dapat menyalin SmartArt ke slide yang sama atau ke presentasi lain sambil mempertahankan format?**

Anda dapat [mengkloning bentuk SmartArt](/slides/id/php-java/shape-manipulations/) dengan [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) atau [mengkloning seluruh slide](/slides/id/php-java/clone-slides/) yang berisi SmartArt. Kedua pendekatan mempertahankan ukuran, posisi, dan format.

**Bagaimana saya merender SmartArt menjadi gambar raster untuk pratinjau atau ekspor web?**

[Render slide](/slides/id/php-java/convert-powerpoint-to-png/) atau seluruh presentasi ke PNG atau JPEG. SmartArt dirender sebagai bagian dari slide.

**Bagaimana saya dapat menemukan objek SmartArt tertentu pada slide jika ada beberapa?**

Gunakan [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) atau [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) untuk menetapkan teks alternatif atau nama yang khas pada bentuk SmartArt, cari nilai tersebut dalam [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes), dan kemudian periksa bahwa bentuk yang cocok adalah [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/).