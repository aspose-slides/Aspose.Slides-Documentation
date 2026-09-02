---
title: Kelola Picture Frame dalam Presentasi Menggunakan PHP
linktitle: Bingkai Gambar
type: docs
weight: 10
url: /id/php-java/picture-frame/
keywords:
- bingkai gambar
- tambahkan bingkai gambar
- buat bingkai gambar
- gambar tersemat
- gambar tertaut
- ekstrak gambar
- gambar raster
- gambar SVG
- potong gambar
- hapus area terpotong
- kompres gambar
- StretchOffset
- pemformatan bingkai gambar
- skala relatif
- efek gambar
- rasio aspek
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Buat, format, tautkan, potong, ekstrak, dan kompres bingkai gambar dalam presentasi dengan Aspose.Slides untuk PHP via Java."
---
## **Ikhtisar**

Picture frame adalah bentuk slide yang menampilkan gambar. Di Aspose.Slides, sumber gambar dan bentuk yang menampilkannya adalah objek terpisah: sebuah [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) memiliki sumber gambar tersemat melalui [ImageCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagecollection/), sementara [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/) mengontrol posisi gambar, ukuran, format garis, rotasi, pemangkasan, efek gambar, dan pengaturan tingkat bingkai lainnya.

Pemisahan ini berguna ketika gambar yang sama ditampilkan lebih dari satu kali. Tambahkan gambar ke presentasi sekali, simpan [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) yang dikembalikan, dan gunakan sumber gambar itu saat membuat picture frame.

Picture frame dapat berisi gambar raster seperti PNG atau JPEG serta gambar vektor SVG. Mereka juga dapat merujuk ke gambar tertaut alih-alih menyimpan byte gambar di dalam presentasi. Pilihan ini memengaruhi portabilitas, ukuran file, ekstraksi, dan perilaku ekspor, sehingga penting untuk memutuskan bagaimana gambar harus disimpan sebelum menerapkan pemformatan atau optimasi.

## **Menambahkan dan Memformat Gambar Tersemat**

Untuk gambar tersemat, tambahkan data gambar ke presentasi dan buat picture frame dengan [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addpictureframe/). Gambar menjadi bagian dari paket presentasi, sehingga presentasi tetap mandiri saat dipindahkan ke komputer lain.

Contoh berikut menambahkan gambar JPEG, membuat frame dengan dimensi asli gambar, dan menerapkan format garis serta rotasi:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Picture frame mengontrol geometri yang ditampilkan; mengubah ukuran frame tidak mengubah dimensi piksel asli yang disimpan dalam sumber gambar tersemat. Perbedaan ini menjadi penting saat memotong atau mengompres gambar belakangan.

## **Gunakan Skala Relatif**

[PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/) menyediakan skala lebar dan tinggi relatif untuk frame melalui [setRelativeScaleWidth](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/setrelativescalewidth/) dan [setRelativeScaleHeight](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Nilai `1.0` sesuai dengan 100% ukuran gambar asli. Skala relatif berguna ketika alur kerja harus mempertahankan hubungan dengan ukuran gambar sumber alih-alih menghitung dimensi akhir secara manual.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Skala relatif mengubah pengaturan skala frame; tidak melakukan resample atau kompresi pada gambar tersemat.

## **Gambar Tersemat dan Tertaut**

Gambar tersemat menyimpan data gambar di dalam presentasi dan oleh karena itu merupakan pilihan paling aman untuk portabilitas dan rendering yang dapat diprediksi. Gambar tertaut menyimpan lokasi eksternal melalui metode [Picture::setLinkPathLong](https://reference.aspose.com/slides/id/php-java/aspose.slides/picture/setlinkpathlong/) alih-alih menyematkan data gambar dengan cara yang sama.

Gambar tertaut dapat mengurangi jumlah data gambar yang disimpan dalam PPTX, tetapi memperkenalkan ketergantungan eksternal. File tertaut harus tetap dapat diakses oleh aplikasi yang membuka atau merender presentasi. Jika jalur berubah, file dipindahkan, atau sumber tidak tersedia, gambar tertaut mungkin tidak ditampilkan sebagaimana mestinya. Untuk presentasi yang harus dikirim via email, diarsipkan, atau dirender di lingkungan terisolasi, gambar tersemat biasanya lebih dapat diandalkan.

### **Menambahkan Gambar Tertaut**

Contoh berikut membuat picture frame dan menunjukkannya ke file gambar lokal. Contoh ini hanya menangani penautan gambar; penautan video merupakan alur media terpisah dan sengaja tidak dicampur dalam contoh ini.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Gunakan tautan ketika manajemen file eksternal memang diinginkan. Jangan gunakan mereka hanya sebagai pengganti kompresi: PPTX kecil dengan ketergantungan gambar yang rusak biasanya kurang berguna dibandingkan presentasi mandiri yang lebih besar.

## **Mengekstrak Gambar dari Picture Frame**

Sebelum mengekstrak gambar dari presentasi yang ada, periksa bahwa bentuk tersebut memang merupakan [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/) dan bahwa ia berisi gambar tersemat. Picture frame tertaut mungkin tidak berisi byte gambar yang dapat diekstrak dengan cara yang sama.

### **Mengekstrak Gambar Raster**

API gambar modern menggunakan [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/) secara langsung. Contoh berikut menemukan gambar raster tersemat pertama pada slide dan menyimpannya sebagai PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Menyimpan melalui [IImage::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/#save) mengonversi gambar yang diekstrak ke format keluaran yang diminta. Jika Anda memerlukan byte yang terkode yang disimpan dalam presentasi alih-alih file raster yang telah dikonversi, gunakan data biner sumber gambar tersebut.

### **Mengekstrak Gambar SVG**

Untuk gambar SVG, [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) menyediakan objek [SvgImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgimage/). Ini memungkinkan Anda mengambil data SVG secara langsung alih-alih merasterkan gambar terlebih dahulu.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Menyimpan konten SVG sebagai SVG mempertahankan sumber vektor di dalam presentasi. Ekspor raster seperti PNG atau JPEG secara otomatis merender konten vektor ke piksel. Ekspor slide ke PDF atau SVG juga merupakan operasi rendering, jadi grafik yang diekspor tidak boleh dianggap sebagai salinan byte-per-byte dari SVG tersemat asli; gunakan data [SvgImage::getSvgData](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgimage/getsvgdata/) ketika sumber vektor asli diperlukan.

## **Memotong Gambar**

Pemotongan mengubah bagian gambar yang terlihat di dalam frame. Nilai pemotongan pada [PictureFillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/) adalah persentase dari dimensi gambar sumber. Pemotongan pada awalnya tidak menghapus piksel tersembunyi dari gambar tersemat; ia hanya mengubah wilayah yang terlihat.

Contoh berikut menemukan picture frame dengan aman dan menerapkan nilai pemotongan:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
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
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Karena data gambar tersembunyi masih ada, pemotongan dapat diubah nanti tanpa kehilangan piksel asli. Jika ukuran file lebih penting daripada kemampuan untuk mengembalikan, wilayah yang dipotong dapat dihapus secara fisik seperti yang dijelaskan pada bagian berikut.

## **Menghapus Data Gambar yang Dipotong**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) menghapus data gambar di luar area pemotongan saat ini dan mengembalikan sumber gambar yang dihasilkan. Ini dapat mengurangi ukuran file, tetapi merupakan optimasi destruktif: setelah presentasi disimpan, piksel yang dihapus tidak lagi tersedia untuk operasi un‑crop di kemudian hari.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
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
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Metode ini dapat menambahkan sumber gambar baru ke presentasi. Jika gambar asli juga digunakan oleh picture frame lain, frame‑frame tersebut masih memerlukan sumber yang ada, sehingga menghapus area terpotong tidak selalu mengurangi total jumlah gambar. Memotong konten WMF atau EMF dengan metode ini merasterkan hasil yang dipotong menjadi PNG.

## **Mengompres Gambar Raster**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) mengurangi resolusi gambar raster relatif terhadap ukuran saat gambar ditampilkan. Ia juga dapat menghapus wilayah yang dipotong dalam operasi yang sama. Metode mengembalikan `true` ketika gambar di‑resize atau dipotong dan `false` ketika tidak ada perubahan yang diperlukan.

Gunakan nilai [PicturesCompression](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturescompression/) yang telah ditentukan sebelumnya ketika resolusi target standar sudah cukup:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
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
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Nilai DPI positif khusus dapat diberikan alih-alih nilai yang telah ditentukan ketika target tertentu diperlukan.

Kompresi ditujukan untuk gambar raster. Konten SVG dan metafile tidak berkurang oleh alur kompresi raster ini. Juga ingat bahwa resolusi lebih rendah dan wilayah yang dihapus tidak dapat dipulihkan dari presentasi yang telah dioptimasi. Pilih resolusi target berdasarkan ukuran terbesar dimana gambar akan benar-benar dilihat atau diekspor, bukan dengan menerapkan DPI terendah secara global.

## **Kelola Efek Transformasi Gambar**

Untuk alur kerja lengkap yang mencakup kecerahan, kontras, transformasi warna, blur, efek alfa, rantai terurut, inspeksi, penghapusan, dan verifikasi putar‑balik, lihat [Efek Transformasi Gambar](/php-java/image-transform-effects/).

## **Kunci Geometri Picture Frame**

Pengaturan [PictureFrameLock](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframelock/) mengontrol operasi penyuntingan mana yang dinonaktifkan untuk picture frame. Misalnya, [setAspectRatioLocked](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) menjaga proporsi bentuk saat diubah ukuran.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kunci ini berlaku pada bentuk picture frame. Ia tidak memaksa gambar sumber untuk di‑resample atau diubah secara permanen ke rasio aspek yang sama.

## **Sesuaikan Nilai StretchOffset**

Ketika mode isi gambar adalah stretch, nilai stretch‑offset pada [PictureFillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/) mendefinisikan persegi isi relatif terhadap bounding box picture frame. Persentase positif membuat inset dari tepi, sementara persentase negatif membuat outset.

Ini berbeda dari pemotongan. Nilai pemotongan memilih bagian gambar sumber yang terlihat; stretch offset mengubah persegi tempat isi gambar yang terlihat diregangkan.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
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

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Gunakan stretch offset untuk penempatan isi. Gunakan properti pemotongan ketika tujuan Anda adalah menyembunyikan tepi gambar sumber.

## **Pertimbangan Penyimpanan, Ukuran File, dan Ekspor**

Trade‑off utama lebih mudah dikelola ketika penyimpanan gambar dan pemformatan picture frame diperlakukan terpisah:

- **Gambar tersemat** membuat presentasi mandiri dan paling dapat diandalkan untuk berbagi serta rendering sisi server, tetapi gambar raster berukuran besar meningkatkan ukuran PPTX dan penggunaan memori.
- **Gambar tertaut** dapat membuat paket lebih kecil, tetapi presentasi bergantung pada file eksternal yang tetap tersedia di jalur atau lokasi yang disimpan.
- **Pemotongan** pada awalnya tidak destruktif. Piksel tersembunyi tetap tersemat sampai area terpotong secara eksplisit dihapus atau dihapus selama kompresi.
- **Kompresi** dapat mengurangi ukuran file secara signifikan untuk gambar raster yang terlalu besar, tetapi mengorbankan resolusi sumber. Kompresi sebaiknya diterapkan setelah ukuran pada slide yang diinginkan diketahui.
- **Gambar SVG** sebaiknya tetap sebagai SVG ketika preservasi vektor penting. Ekstrak SVG tersemat langsung ketika Anda membutuhkan sumber vektor itu sendiri. Ekspor slide raster selalu mengonversi slide yang dirender ke piksel.
- **Gambar berulang** sebaiknya menggunakan kembali sumber [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) yang ada bila memungkinkan, alih-alih memuat berkas yang sama berulang kali ke alur kerja presentasi.

Untuk presentasi besar, optimasi gambar biasanya paling efektif bila dilakukan secara selektif: pertahankan logo dan diagram sebagai konten vektor, kompres foto sesuai ukuran tampilan sebenarnya, hapus piksel yang dipotong hanya ketika pengeditan lanjutan tidak diperlukan, dan hindari tautan eksternal kecuali manajemen ketergantungan memang menjadi bagian dari desain penyebaran.

## **FAQ**

**Apa perbedaan antara picture frame dan sumber gambar?**

[PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) mewakili sumber gambar yang terkait dengan presentasi. [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/) adalah bentuk pada slide yang menampilkan gambar dan menyimpan geometri serta pemformatan tingkat bingkai seperti ukuran, rotasi, nilai pemotongan, efek, dan kunci.

**Haruskah saya menyematkan atau menautkan gambar?**

Sematkan gambar ketika presentasi harus portabel, diarsipkan, atau dirender tanpa akses ke sumber eksternal. Tautkan gambar hanya ketika menyimpan file gambar di luar PPTX memang disengaja dan lokasi eksternal dapat dipelihara secara handal.

**Apakah pemotongan mengurangi ukuran file PPTX?**

Tidak secara otomatis. Pengaturan pemotongan normal menyembunyikan bagian gambar sumber tetapi tetap menyimpan piksel di baliknya. Gunakan [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) atau kompresi gambar dengan penghapusan area terpotong ketika piksel tersebut dapat dibuang secara permanen.

**Apakah saya dapat mengembalikan kualitas gambar setelah kompresi?**

Tidak. Kompresi dapat menurunkan resolusi raster yang disimpan, dan penghapusan area terpotong membuang data gambar. Simpan gambar sumber asli di luar presentasi bila pengeditan resolusi tinggi di masa mendatang mungkin diperlukan.

**Bagaimana sebaiknya menangani gambar SVG?**

Pertahankan konten SVG sebagai SVG ketika fidelitas vektor penting. [SvgImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgimage/) yang tersemat dapat diekstrak langsung. Merender slide ke format raster seperti PNG atau JPEG akan merasterkan SVG sebagai bagian dari gambar slide.

**Bagaimana saya dapat menghindari cast yang tidak aman saat membaca slide yang ada?**

Periksa tipe bentuk sebelum menggunakan anggota khusus picture frame. Pemeriksaan `java_instanceof` terhadap [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/) menghindari cast yang tidak valid dan memungkinkan kode menangani slide yang tidak berisi picture frame.