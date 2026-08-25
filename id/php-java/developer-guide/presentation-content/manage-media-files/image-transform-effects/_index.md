---
title: Mengelola Efek Transformasi Gambar dalam Presentasi dengan PHP
linktitle: Efek Transformasi Gambar
type: docs
weight: 11
url: /id/php-java/image-transform-effects/
keywords:
- transformasi gambar
- efek gambar
- kecerahan
- kontras
- skala abu-abu
- duotone
- tint
- HSL
- penggantian warna
- blur
- transparansi
- efek alfa
- rantai efek
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Terapkan, rangkai, inspeksi, hapus, dan verifikasi efek transformasi gambar untuk bingkai gambar dengan Aspose.Slides untuk PHP via Java."
---
## **Gambaran Umum**

Aspose.Slides merepresentasikan penyesuaian gambar sebagai koleksi terurut dari operasi transformasi gambar. Untuk sebuah bingkai gambar, mulailah dengan [Picture](https://reference.aspose.com/slides/id/php-java/aspose.slides/picture/) bingkai tersebut dan akses [Picture::getImageTransform](https://reference.aspose.com/slides/id/php-java/aspose.slides/picture/getimagetransform/). [ImageTransformOperationCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/) yang dikembalikan memungkinkan Anda menambahkan, menelusuri, memeriksa, menghapus, dan membersihkan efek tanpa menulis ulang byte gambar asli.

Artikel ini menunjukkan alur kerja lengkap untuk kecerahan dan kontras, transformasi warna, blur, transparansi, rantai efek berurutan, nilai efektif, penghapusan, dan verifikasi putar‑balik PPTX.

## **Pahami Kepemilikan Efek dan Penggunaan Ulang Gambar**

Sebuah sumber gambar dan gambar yang menampilkannya adalah objek yang berbeda:

- [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) menyimpan atau merujuk data gambar sumber yang dimiliki oleh presentasi.
- [Picture](https://reference.aspose.com/slides/id/php-java/aspose.slides/picture/) merupakan bagian dari isian gambar dan merujuk ke sumber gambar sambil menyimpan koleksi transformasi gambar.
- [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/) adalah bentuk slide yang memiliki isian gambar terkait, geometri, pengaturan crop, dan pemformatan tingkat bingkai lainnya.

Karena itu, operasi transformasi gambar tidak mengubah byte di [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/). Ketika `PPImage` yang sama diberikan ke [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addpictureframe/) lebih dari sekali, setiap bingkai gambar baru menerima `Picture` dan koleksi transformasinya masing‑masing. Menerapkan grayscale pada satu bingkai tidak membuat bingkai lain menjadi grayscale, meskipun semuanya menggunakan sumber gambar tertanam yang sama.

Model `Picture::getImageTransform` yang sama juga digunakan oleh isian gambar lain, seperti bentuk atau latar belakang slide. Contoh di bawah berfokus pada bingkai gambar.

## **Gunakan Rentang Parameter dan Satuan yang Valid**

Metode yang ditunjukkan menggunakan rentang semantik dan satuan berikut. Pertahankan nilai dalam rentang ini meskipun versi perpustakaan tertentu tidak menolak setiap nilai di luar rentang secara langsung; format presentasi target dapat menormalisasi, menghilangkan, atau menolak data tidak valid saat menyimpan atau ketika PowerPoint membuka file.

| Operasi | Parameter | Rentang dan satuan yang valid |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` hingga `100`, persen; `0` tidak mengubah komponen. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | Tidak ada parameter numerik. Alpha tidak berubah. |
| [addDuotoneEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Dua warna untuk piksel gelap dan terang. Saluran RGB dan alpha di `java.awt.Color` menggunakan `0` hingga `255`. |
| [addTintEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue `0` inklusif hingga `360` eksklusif, dalam derajat; amount `-100` hingga `100`, persen. |
| [addHSLEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue `0` inklusif hingga `360` eksklusif, dalam derajat; saturasi dan luminance `-100` hingga `100`, persen. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Warna pengganti menggunakan nilai saluran `0` hingga `255`. Nilai alpha yang ada tidak berubah. |
| [addBlurEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius tidak negatif dan diukur dalam point; `grow` adalah Boolean yang mengontrol apakah konten blur dapat meluas di luar batas asli. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Persen tidak negatif. Gunakan `0` hingga `100` untuk skala opasitas biasa: `0` sepenuhnya transparan dan `100` mempertahankan alpha yang ada. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` hingga `100`, persen opasitas. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` hingga `100`, persen ambang alpha. Nilai di bawahnya menjadi transparan; nilai pada atau di atasnya menjadi tidak transparan. |

Untuk modulasi alpha tetap, transparansi dan opasitas bersifat komplementer. Misalnya, transparansi 35 % bersesuaian dengan nilai modulasi alpha 65 %.

## **Terapkan Kecerahan dan Kontras**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) mengembalikan operasi [Luminance](https://reference.aspose.com/slides/id/php-java/aspose.slides/luminance/). Pengaturan skalar disediakan saat operasi dibuat. [Luminance::getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/luminance/geteffective/) mengembalikan nilai hanya‑baca yang dihitung yang dapat diperiksa atau dicatat.

Contoh berikut meningkatkan kecerahan sebesar 15 % dan kontras sebesar 20 %, lalu menampilkan pratinjau tanpa mengubah gambar tertanam:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` adalah efek brightness dan contrast standar DrawingML. Ketika pengaturan tersebut harus tetap dapat diedit setelah putar‑balik PPTX, buka kembali presentasi yang disimpan dan verifikasi baik tipe operasi maupun nilai efektifnya.

## **Terapkan Transformasi Warna**

Efek warna dapat diterapkan secara independen pada bingkai gambar yang menggunakan satu sumber gambar. Contoh berikut membuat lima bingkai dan menerapkan grayscale, duotone, tint, penyesuaian HSL, serta penggantian warna.

[Duotone](https://reference.aspose.com/slides/id/php-java/aspose.slides/duotone/) memiliki dua parameter warna yang dapat diedit secara terpisah: `color1` untuk piksel gelap, sedangkan `color2` untuk piksel terang. Ini menjadi contoh berguna untuk efek yang pengaturannya lebih kompleks daripada satu nilai skalar.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) mengganti setiap warna piksel dengan satu warna tetap sambil mempertahankan alpha. Ini berbeda dari [addColorChangeEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), yang memetakan satu warna sumber ke warna lain dan menampilkan format warna sumber serta target.

## **Tambahkan Blur, Transparansi, dan Efek Alpha**

[addBlurEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) memengaruhi semua saluran warna, termasuk alpha. Atur `grow` ke `true` ketika tepi blur dapat meluas di luar batas gambar asli.

Untuk transparansi seragam, gunakan [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Ini mengalikan setiap nilai alpha yang ada, sehingga piksel yang sebagian transparan tetap berbeda secara proporsional. [addAlphaReplaceEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) malah menetapkan satu nilai alpha ke semua piksel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) mengubah alpha menjadi dua tingkat berdasarkan ambang.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Operasi alpha tanpa parameter lainnya meliputi [addAlphaCeilingEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), yang membuat setiap alpha selain nol menjadi sepenuhnya tidak transparan; [addAlphaFloorEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), yang membuat setiap alpha di bawah 100 % sepenuhnya transparan; dan [addAlphaInverseEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), yang mengubah alpha menjadi `100% - alpha`.

## **Bangun Rantai Efek Berurutan**

Setiap metode `add...Effect` menambahkan operasi baru ke akhir koleksi. Renderer menggunakan koleksi sebagai pipeline berurutan: output operasi 0 menjadi input operasi 1, dan seterusnya. Akibatnya, operasi yang sama dalam urutan berbeda dapat menghasilkan gambar yang berbeda.

Sebagai contoh, grayscale diikuti tint pertama‑tama menghapus informasi kromatik lalu mewarnai ulang hasil luminance. Tint diikuti grayscale menghilangkan tint kembali. Demikian pula, penggantian alpha dapat menimpa nilai alpha yang dihitung oleh operasi sebelumnya, sementara modulasi alpha mempertahankan perbedaan relatifnya.

Contoh berikut membangun rantai empat operasi, menyimpannya sebagai PPTX, membuka kembali presentasi, memeriksa baik tipe operasi maupun urutannya, serta menampilkan hasil yang dibuka kembali:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Koleksi tidak memberlakukan matriks kompatibilitas yang membatasi operasi warna, alpha, dan blur ke rantai terpisah. Mereka dapat digabungkan, namun kombinasi tidak selalu berguna. Penggantian warna tetap menghilangkan variasi RGB yang dihasilkan oleh efek warna sebelumnya; grayscale setelah duotone menghapus dua warna yang dipilih; dan operasi alpha ceiling, floor, replacement, atau bi‑level dapat membuang detail alpha yang dibuat sebelumnya. Bangun rantai sesuai urutan pemrosesan piksel yang diinginkan daripada memperlakukan itemnya sebagai flag pemformatan yang tidak berurutan.

## **Periksa Nilai yang Dapat Diedit dan Nilai Efektif**

Operasi yang dapat diedit adalah objek yang disimpan dalam `Picture::getImageTransform`. Bergantung pada efeknya, objek tersebut dapat mengekspose anggota yang dapat ditulis secara langsung. Misalnya, [Blur](https://reference.aspose.com/slides/id/php-java/aspose.slides/blur/) mengekspose nilai `radius` dan `grow` yang dapat ditulis, [AlphaModulateFixed](https://reference.aspose.com/slides/id/php-java/aspose.slides/alphamodulatefixed/) mengekspose `amount` yang dapat ditulis, dan [AlphaBiLevel](https://reference.aspose.com/slides/id/php-java/aspose.slides/alphabilevel/) mengekspose `threshold` yang dapat ditulis. Efek warna seperti [Duotone](https://reference.aspose.com/slides/id/php-java/aspose.slides/duotone/) mengekspose objek [ColorFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/colorformat/) yang dapat diubah.

Beberapa operasi, termasuk [Luminance](https://reference.aspose.com/slides/id/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/id/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/id/php-java/aspose.slides/tint/), dan [AlphaReplace](https://reference.aspose.com/slides/id/php-java/aspose.slides/alphareplace/), tidak mengekspose skalar penciptaannya sebagai properti yang dapat ditulis. Untuk mengubah pengaturan tersebut, hapus operasi dan tambahkan pengganti pada posisi yang diperlukan.

Data efektif yang dikembalikan oleh `getEffective()` dihitung dan hanya‑baca. Data ini berguna untuk menyelesaikan warna yang bergantung pada tema serta membaca nilai normalisasi yang digunakan renderer, tetapi bukan permukaan pengeditan lain. Contoh berikut menelusuri rantai dan memeriksa nilai efektif di mana API yang bersangkutan menyediakannya:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Efek tanpa parameter seperti grayscale, alpha ceiling, dan alpha inverse masih memiliki objek data‑efektif, namun tidak ada pengaturan skalar untuk dicetak. Keberadaan dan posisinya dalam koleksi merupakan informasi penting.

## **Hapus atau Bersihkan Transformasi Gambar**

Gunakan [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/removeat/) untuk menghapus satu operasi berdasarkan indeks. Karena indeks bergeser setelah penghapusan, cari target terlebih dahulu dan hapus setelah penelusuran. Gunakan [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagetransformoperationcollection/clear/) untuk menghapus seluruh rantai.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Menghapus atau membersihkan transformasi hanya mengubah pemformatan gambar. Itu tidak menghapus, mengompresi ulang, atau mengubah sumber daya [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) yang dipakai ulang.

## **Pertimbangkan Format Presentasi dan Target Ekspor**

Transformasi gambar berasal dari DrawingML, sehingga PPTX adalah format yang dapat diedit paling disarankan untuk rantai efek. Bahkan dengan PPTX, tidak setiap operasi memiliki portabilitas yang identik:

- Operasi DrawingML standar seperti luminance, grayscale, duotone, tint, HSL, blur, dan operasi alpha umum memiliki peluang terbaik untuk bertahan setelah putar‑balik PPTX. Selalu buka kembali file yang dihasilkan dan periksa koleksi ketika preservasi menjadi keharusan.
- Format PPT biner mendahului model efek DrawingML lengkap. Menyimpan ke PPT dapat menghilangkan operasi yang tidak didukung, mengurangi rantai ke subset yang didukung, atau memperkirakan tampilan. Jangan gunakan PPT sebagai format verifikasi untuk rantai yang dapat diedit secara kompleks.
- Rendering ke PNG, JPEG, TIFF, PDF, SVG, HTML, atau output visual lainnya menerapkan rantai yang didukung pada tampilan yang dirender. Output tersebut tidak berisi `ImageTransformOperationCollection` yang dapat diedit; format raster meratakan hasil menjadi piksel, dan ekspor dokumen atau vektor menyimpan representasi rendering mereka sendiri.
- Efek tidak membuat gambar tertaut menjadi mandiri. Rendering gambar yang ditautkan tetap bergantung pada ketersediaan sumber daya tertaut saat presentasi dimuat.

Berbagai konsumen presentasi dapat merender kasus tepi secara berbeda, terutama ketika beberapa operasi alpha atau kuantisasi warna digabungkan. Untuk output kritis, uji baik putar‑balik yang dapat diedit maupun format ekspor akhir dengan versi Aspose.Slides yang sama digunakan dalam produksi.

## **FAQ**

**Apakah efek transformasi gambar mengubah data gambar tertanam?**

Tidak. Operasi tersebut milik `Picture` yang digunakan oleh isian gambar. Byte `PPImage` yang mendasarinya tetap tidak berubah.

**Apakah dua bingkai gambar yang menggunakan gambar yang sama berbagi efeknya?**

Tidak. Menggunakan kembali `PPImage` menghindari duplikasi data gambar, tetapi tiap bingkai gambar biasanya memiliki `Picture` dan koleksi transformasi gambar yang terpisah.

**Dapatkah efek warna, blur, dan alpha digabungkan?**

Ya. Koleksi menerima mereka dalam satu rantai berurutan. Pertimbangkan apa yang dilakukan tiap operasi pada output operasi sebelumnya karena operasi penggantian dan ambang dapat membuang detail warna atau alpha yang lebih awal.

**Mengapa nilai efektif bersifat hanya‑baca?**

Data efektif mewakili nilai yang dihitung untuk rendering, termasuk warna yang diselesaikan. Edit operasi yang disimpan dalam koleksi transformasi pada tempat anggota yang dapat ditulis; bila tidak, hapus dan tambahkan pengganti dengan parameter penciptaan baru.

**Format apa yang sebaiknya saya gunakan untuk mempertahankan rantai transformasi?**

Gunakan PPTX dan verifikasi file dengan membukanya kembali. PPT lama tidak dapat merepresentasikan model efek DrawingML lengkap, dan format ekspor yang dirender hanya mempertahankan tampilan, bukan operasi transformasi yang dapat diedit.