---
title: Optimalkan Manajemen Gambar dalam Presentasi Menggunakan PHP
linktitle: Kelola Gambar
type: docs
weight: 10
url: /id/php-java/image/
keywords:
- tambahkan gambar
- tambahkan gambar
- ganti gambar
- koleksi gambar
- bingkai gambar
- gambar tertaut
- latar belakang
- tambahkan PNG
- tambahkan JPG
- tambahkan SVG
- SVG ke bentuk
- sumber daya SVG eksternal
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara menambahkan, menggunakan kembali, menautkan, mengganti, dan mengelola gambar raster serta SVG dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk PHP via Java."
---
## **Pendahuluan**

Aspose.Slides untuk PHP melalui Java menyediakan beberapa cara untuk bekerja dengan gambar, dan setiap cara melayani tujuan yang berbeda. Anda dapat menyimpan gambar dalam presentasi, menampilkannya dalam bingkai gambar, menggunakannya sebagai latar belakang slide, menautkan ke gambar eksternal, mengganti sumber daya gambar bersama, atau mengonversi konten SVG menjadi bentuk yang dapat diedit.

Artikel ini berfokus pada sumber daya gambar dan bagaimana mereka digunakan di seluruh presentasi. Untuk pemotongan, transparansi, efek, peregangan, dan pemformatan lain yang diterapkan pada bingkai gambar individu, lihat [Picture Frame](/slides/id/php-java/picture-frame/).

## **Memahami Model Gambar**

Konsep API berikut terkait erat tetapi tidak dapat dipertukarkan:

- Koleksi gambar presentasi ([presentation image collection]) menyimpan sumber daya gambar yang digunakan oleh presentasi. Gunakan [ImageCollection::addImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagecollection/) untuk menambahkan data gambar dan memperoleh sumber daya [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/).
- [Picture frame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/) adalah bentuk yang menampilkan gambar pada slide, tata letak, atau master. Gunakan [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addpictureframe/) untuk menempatkan sumber daya gambar pada slide.
- Latar belakang slide menggunakan gambar sebagai bagian dari isian slide bukan sebagai bentuk. Oleh karena itu tidak berperilaku seperti bingkai gambar.
- [PPImage::replaceImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) menggantikan sumber daya gambar. Jika beberapa elemen presentasi menggunakan sumber daya tersebut, semuanya akan menggunakan pengganti.
- Mengonversi SVG menjadi bentuk menciptakan bentuk slide yang dapat diedit. Setelah konversi, konten tidak lagi dikelola sebagai satu sumber daya gambar.

Alur kerja tipikalnya adalah: menambahkan data gambar ke koleksi gambar, menerima sebuah [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/), dan kemudian menggunakan sumber daya tersebut dalam satu atau lebih bingkai gambar atau isian.

## **Menambahkan Gambar Tersemat**

Untuk menyisipkan gambar lokal, muat berkas, tambahkan ke koleksi gambar, dan buat bingkai gambar yang menggunakan `PPImage` yang dikembalikan.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Gambar yang ditambahkan dengan cara ini tersemat dalam presentasi, sehingga berkas hasil tidak bergantung pada ketersediaan berkas gambar asli.

### **Menambahkan Gambar dari Web**

Ketika gambar tersedia melalui HTTP atau HTTPS, unduh byte-nya, tambahkan ke koleksi gambar presentasi, dan gunakan sumber daya gambar yang dikembalikan dengan cara yang sama seperti gambar lokal.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dalam aplikasi yang berjalan lama, gunakan kembali klien HTTP atau strategi manajemen koneksi yang sesuai dengan aplikasi daripada terus-menerus membuat infrastruktur jaringan yang tidak diperlukan. Juga validasi URL remote, ukuran respons, dan tipe konten ketika sumber tidak tepercaya.

## **Menggunakan Ulang Gambar di Seluruh Slide**

Jika gambar yang sama diperlukan lebih dari satu kali, tambahkan ke presentasi satu kali dan gunakan kembali [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) yang dikembalikan saat membuat bingkai gambar tambahan. Ini menghindari memuat berulang data sumber yang sama dan menjadikan hubungan antara sumber daya gambar bersama dan penggunaannya eksplisit.

Untuk grafik yang harus muncul secara otomatis pada banyak slide, seperti logo perusahaan, pertimbangkan menempatkan bingkai gambar pada [slide master](/slides/id/php-java/slide-master/) atau tata letak alih-alih menambahkan bentuk yang setara pada setiap slide.

## **Menggunakan Gambar sebagai Latar Belakang Slide**

Gambar latar belakang ditetapkan pada isian slide; tidak ditambahkan sebagai bentuk bingkai gambar. Ini berguna ketika gambar harus menutupi latar belakang slide dan tidak boleh dimanipulasi sebagai objek slide biasa.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Untuk opsi latar belakang tambahan, termasuk latar belakang master dan tata letak, lihat [Presentation Background](/slides/id/php-java/presentation-background/).

## **Gambar Tersemat dan Gambar Tertaut**

Gambar tersemat dan gambar tertaut memiliki trade‑off portabilitas dan ukuran berkas yang berbeda:

- **Gambar tersemat:** data gambar disimpan di dalam presentasi. Presentasi menjadi mandiri, tetapi ukuran berkas mencakup data gambar.
- **Gambar tertaut:** presentasi menyimpan jalur atau URL ke gambar eksternal. Ini dapat mengurangi ukuran presentasi, tetapi sumber eksternal harus tetap dapat diakses saat presentasi dibuka atau dirender.

Gambar tertaut dapat dibuat dengan menetapkan jalur atau URL eksternal melalui [Picture::setLinkPathLong](https://reference.aspose.com/slides/id/php-java/aspose.slides/picture/) daripada menanamkan data gambar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Gunakan gambar tertaut hanya ketika lingkungan penyebaran dapat mengakses sumber eksternal secara andal. Untuk presentasi yang harus berfungsi secara offline atau dipindahkan antar sistem, gambar tersemat biasanya lebih aman.

## **Bekerja dengan Gambar SVG**

SVG adalah format vektor, sehingga berguna untuk ikon, diagram, dan grafik lain yang harus skala tanpa kehilangan detail seperti gambar raster. Aspose.Slides mendukung SVG baik sebagai sumber daya gambar maupun sebagai sumber untuk bentuk slide yang dapat diedit.

### **Menambahkan SVG sebagai Gambar**

Buat sebuah [SvgImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgimage/), tambahkan ke koleksi gambar, dan tempatkan sumber daya gambar yang dihasilkan dalam bingkai gambar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Berkas SVG dengan Sumber Daya Eksternal**

SVG dapat merujuk ke gambar eksternal, stylesheet, atau font. Untuk kasus ini, [SvgImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgimage/) menyediakan konstruktor yang menerima [ExternalResourceResolver](https://reference.aspose.com/slides/id/php-java/aspose.slides/externalresourceresolver/) dan URI dasar. Resolver dapat memetakan URI relatif ke URI absolut yang diizinkan dan mengembalikan aliran untuk sumber daya yang diminta.

Resolver membuat sumber daya eksternal tersedia saat Aspose.Slides memproses SVG, tetapi tidak menulis ulang SVG menjadi dokumen mandiri. Jika SVG harus tetap portabel, sematkan sumber daya yang diperlukan dalam SVG itu sendiri, misalnya dengan menggunakan URI `data:` untuk gambar yang tertaut.

Ketika berkas SVG berasal dari sumber yang tidak tepercaya, batasi skema, lokasi berkas, dan host yang dapat diakses oleh resolver. Resolver jaringan juga harus menerapkan batas waktu, batas ukuran respons, dan validasi konten.

### **Mengonversi SVG menjadi Bentuk yang Dapat Diedit**

Aspose.Slides dapat mengonversi SVG menjadi grup bentuk slide yang dapat diedit, serupa dengan perintah PowerPoint yang bersesuaian.

![PowerPoint Popup Menu](img_01_01.png)

Gunakan overload [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addgroupshape/) yang menerima [SvgImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgimage/) untuk melakukan konversi.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Gunakan konversi SVG-ke-bentuk ketika elemen vektor individu perlu diedit sebagai bentuk PowerPoint. Jika SVG hanya perlu ditampilkan, menyimpannya sebagai gambar lebih sederhana dan menghindari pembuatan banyak bentuk terpisah.

## **Mengganti Sumber Daya Gambar yang Ada**

Gunakan [PPImage::replaceImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) ketika Anda ingin mengganti sumber daya gambar yang ada. Ini sangat berguna untuk grafik bersama seperti logo.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jika beberapa bingkai gambar, latar belakang, master, atau tata letak menggunakan sumber daya gambar yang sama, mengganti sumber daya tersebut memperbarui semua penggunaan tersebut. Jika hanya satu bingkai gambar yang harus berubah, tetapkan gambar yang berbeda ke bingkai itu alih-alih mengganti sumber daya bersama.

`PPImage::replaceImage` juga menyediakan overload yang menerima array byte atau [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) lain.

## **Panduan Praktis Manajemen Gambar**

### **Mengendalikan Ukuran Presentasi**

Gambar raster besar dapat membuat presentasi menjadi terlalu besar. Gunakan gambar sumber dengan dimensi yang sesuai untuk ukuran tampilan yang dimaksud, gunakan kembali sumber daya gambar bersama bila memungkinkan, dan hindari menanamkan salinan berulang dari grafik resolusi penuh yang sama.

Untuk gambar raster yang sudah ditempatkan dalam bingkai gambar, [PictureFillFormat::compressImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/) dapat mengurangi data gambar sesuai dengan resolusi dan pengaturan pemotongan yang dipilih. Ini adalah pemrosesan bingkai gambar, bukan manajemen koleksi gambar, jadi lihat [Picture Frame](/slides/id/php-java/picture-frame/) untuk operasi pemformatan terkait.

### **Pilih Antara Konten Tersemat dan Tertaut**

Menanamkan membuat presentasi portabel karena semua data gambar yang diperlukan menyertai berkas. Menautkan dapat mengurangi ukuran berkas, tetapi menambahkan ketergantungan eksternal. Gunakan tautan hanya ketika ketergantungan itu dapat diterima dan stabil.

### **Gunakan Kembali Branding Bersama**

Untuk logo, watermark, atau grafik dekoratif yang berulang, gunakan satu sumber daya gambar dan gunakan kembali. Jika grafik tersebut merupakan bagian dari desain presentasi bukan konten slide, tempatkan pada master atau tata letak sehingga diwarisi oleh slide yang sesuai.

### **Jaga Sumber Daya SVG Portabel**

SVG yang mandiri lebih mudah dipindahkan dan dirender secara konsisten dibandingkan SVG yang bergantung pada berkas eksternal atau sumber daya jaringan. Bila memungkinkan, sematkan sumber daya yang diperlukan sebelum mengimpor SVG. Konversi SVG menjadi bentuk hanya ketika elemen vektor individu perlu diedit.

### **Gunakan API Gambar Lintas Platform Modern**

Untuk kode PHP via Java yang baru, gunakan API Aspose.Slides [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/) dan [Images](https://reference.aspose.com/slides/id/php-java/aspose.slides/images/) alih-alih API publik warisan yang berbasis pada `java.awt.image.BufferedImage`. Lihat [Modern API](/slides/id/php-java/modern-api/) untuk panduan migrasi.

WMF dan EMF memerlukan pertimbangan khusus. Ketika format ini diteruskan melalui [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/), [ImageCollection::addImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagecollection/) mengonversi metafile menjadi representasi PNG raster sebelum disisipkan. Jika mempertahankan data metafile penting, gunakan overload [ImageCollection::addImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagecollection/) berbasis aliran. Membuat konten EMF dari spreadsheet atau produk lain merupakan alur kerja integrasi terpisah dan berada di luar lingkup artikel ini.

## **FAQ**

**What is the difference between the image collection and a picture frame?**

Koleksi gambar menyimpan sumber daya gambar yang dapat digunakan kembali. Bingkai gambar adalah bentuk slide yang menampilkan salah satu sumber daya tersebut dan menyediakan pemformatan khusus gambar seperti pemotongan dan efek.

**What is the best way to replace the same logo everywhere?**

Jika logo sudah dibagikan sebagai satu sumber daya gambar, ganti sumber daya itu dengan [PPImage::replaceImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/). Untuk branding di seluruh presentasi, menempatkan logo pada master atau tata letak juga dapat mengurangi duplikasi konten slide.

**Why does a linked image disappear on another computer?**

Gambar tertaut bergantung pada berkas atau URL eksternal. Jika sumber daya itu tidak dapat dijangkau dari komputer lain, gambar tertaut mungkin tidak tersedia. Sematkan gambar ketika presentasi harus mandiri.

**Can an inserted SVG be edited as PowerPoint shapes?**

Ya. Konversi SVG dengan [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addgroupshape/); grup yang dihasilkan berisi bentuk slide yang dapat diedit alih-alih satu gambar SVG.

**How can I keep presentations with many images smaller?**

Gunakan kembali sumber daya gambar bersama, hindari sumber raster yang terlalu besar, kompres gambar raster yang cocok bila perlu, simpan branding berulang pada master atau tata letak, dan gunakan gambar tertaut hanya ketika ketergantungan eksternal dapat diterima.