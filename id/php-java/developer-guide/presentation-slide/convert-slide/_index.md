---
title: Konversi Slide Presentasi menjadi Gambar di PHP
linktitle: Slide ke Gambar
type: docs
weight: 35
url: /id/php-java/convert-slide/
keywords:
- konversi slide
- ekspor slide
- slide ke gambar
- simpan slide sebagai gambar
- slide ke EMF
- slide ke PNG
- slide ke JPEG
- slide ke bitmap
- slide ke TIFF
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Konversi slide dari presentasi PPT, PPTX, dan ODP menjadi PNG, JPEG, GIF, TIFF, EMF, dan format gambar lainnya dalam PHP dengan Aspose.Slides."
---
## **Pendahuluan**

Aspose.Slides for PHP via Java dapat merender slide individual dari presentasi PowerPoint dan OpenDocument sebagai PNG, JPEG, GIF, TIFF, dan format gambar lainnya.

Untuk mengonversi slide menjadi gambar, ikuti langkah‑langkah berikut:

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2. Pilih slide yang ingin Anda render.
3. Jika diperlukan, konfigurasikan rendering dengan kelas [RenderingOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/renderingoptions/) atau [TiffOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/) .
4. Panggil metode [Slide::getImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getImage) . Metode ini mengembalikan objek [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/) .
5. Panggil metode [IImage::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/#save) . dan tentukan format output menggunakan nilai [ImageFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/imageformat/) .

## **Konversi Slide menjadi Gambar PNG**

Konversi paling sederhana menggunakan pengaturan rendering default. Objek [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/) yang dihasilkan dapat diproses di memori atau disimpan ke file.

Contoh PHP berikut merender slide pertama dan menyimpannya sebagai gambar PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Konversi Slide menjadi Gambar dengan Ukuran Kustom**

Gunakan overload [Slide::getImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getImage) yang menerima nilai [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) untuk merender slide dengan dimensi piksel yang tepat.

Contoh berikut membuat gambar JPEG berukuran 1820 × 1040:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Konversi Slide dengan Catatan dan Komentar menjadi Gambar**

Secara default, gambar slide tidak menyertakan catatan atau komentar. Berikan objek [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/notescommentslayoutingoptions/) ke metode [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) untuk mengontrol di mana catatan dan komentar muncul.

Contoh berikut menempatkan catatan yang dipotong di bawah slide dan komentar di sebelah kanannya:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Untuk konversi slide ke gambar, jangan mengirim [BottomFull](https://reference.aspose.com/slides/id/php-java/aspose.slides/notespositions/) ke metode [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/id/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) . Catatan dapat berisi lebih banyak teks daripada ukuran gambar tetap yang dapat menampungnya. Gunakan [BottomTruncated](https://reference.aspose.com/slides/id/php-java/aspose.slides/notespositions/) sebagai gantinya.
{{% /alert %}}

## **Konversi Slide menjadi Gambar Menggunakan Opsi TIFF**

Kelas [TiffOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/) memungkinkan Anda mengontrol ukuran, resolusi, dan properti lain dari gambar TIFF yang dirender.

Contoh berikut merender slide pertama sebagai gambar TIFF 2160 × 2880 pada 300 DPI:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Dukungan TIFF tidak dijamin pada versi Java sebelum JDK 9.
{{% /alert %}}

## **Konversi Semua Slide menjadi Gambar**

Iterasi melalui koleksi slide untuk mengonversi seluruh presentasi menjadi serangkaian gambar. Slide tersembunyi disertakan kecuali Anda secara eksplisit melewatinya.

Contoh berikut merender setiap slide sebagai gambar JPEG dengan faktor skala horizontal dan vertikal sebesar 2:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Buat Output Metafile Ditingkatkan**

Enhanced Metafile (EMF) berguna ketika grafik berbasis vektor harus dipertukarkan dengan Microsoft Office atau aplikasi Windows lain yang mendukung metafile Windows. Tidak seperti gambar berbasis piksel, EMF dapat mempertahankan operasi menggambar vektor yang dapat diskalakan tanpa kehilangan ketajaman yang sama. Namun, EMF terutama merupakan format kompatibilitas untuk aplikasi dengan dukungan metafile Windows, bukan format pertukaran universal. Selain itu, konten slide yang kompleks, seperti gambar bitmap dan beberapa efek, dapat disimpan sebagai elemen raster di dalam wadah metafile vektor.

### **Ekspor Slide ke EMF**

Metode [Slide::writeAsEmf](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#writeAsEmf) menulis slide ke aliran target dalam format EMF. Contoh berikut memuat presentasi, memilih slide pertama, dan menulisnya ke aliran file EMF:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Pemanggil memiliki aliran yang diteruskan ke [Slide::writeAsEmf](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#writeAsEmf) dan bertanggung jawab menutupnya, seperti yang ditunjukkan di atas.

### **Konversi Gambar SVG ke EMF dan Tambahkan ke Presentasi**

Gunakan [SvgImage::writeAsEmf](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgimage/#writeAsEmf) untuk mengonversi konten SVG ke EMF. Byte yang dihasilkan dapat ditambahkan ke presentasi melalui [ImageCollection::addImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagecollection/#addImage) dan ditempatkan pada slide dengan [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/#addPictureFrame) .

Contoh berikut membuat [SvgImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgimage/) dari markup SVG, mengonversinya ke EMF dalam memori, menyisipkan metafile pada slide pertama, dan menyimpan presentasi:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgimage/#writeAsEmf) tidak mengambil kepemilikan aliran tujuan. Sebuah [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) menyimpan semua data yang dihasilkan dalam memori, sehingga tidak diperlukan reset posisi sebelum memanggil `toByteArray`. Array byte yang dikembalikan tetap valid setelah aliran ditutup.

Pembuatan EMF tersedia pada sistem operasi yang didukung oleh Aspose.Slides for PHP via Java yang dipilih dan konfigurasi JDK, tetapi rendering dapat berbeda antar platform ketika font atau dependensi grafik tidak tersedia. Instal font yang digunakan oleh konten sumber atau konfigurasikan substitusi yang sesuai, ikuti [persyaratan platform](/slides/id/php-java/system-requirements/) untuk Aspose.Slides for PHP via Java, dan validasi hasilnya di aplikasi target yang mengonsumsi EMF. Aplikasi Linux dan macOS sering memiliki dukungan terbatas atau tidak konsisten untuk menampilkan dan mengedit metafile Windows.

## **Render Emoji Berwarna**

{{% alert title="Note" color="info" %}}
Untuk merender emoji berwarna dengan benar saat mengonversi slide presentasi menjadi gambar, font emoji yang digunakan dalam presentasi harus diinstal dan tersedia pada sistem yang melakukan konversi. Misalnya, jika presentasi menggunakan **Segoe UI Emoji** dan font ini tidak ada, emoji dapat muncul dalam monokrom pada gambar keluaran.
{{% /alert %}}

## **FAQ**

**Apakah Aspose.Slides mendukung rendering slide dengan animasi?**

Tidak. Metode [Slide::getImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getImage) merender gambar statik dari slide dan tidak mengekspor animasi.

**Bisakah slide tersembunyi diekspor sebagai gambar?**

Ya. Slide tersembunyi dapat dirender seperti slide biasa. Sertakan mereka dalam loop pemrosesan, seperti yang ditunjukkan pada contoh di atas.

**Apakah bayangan dan efek lainnya dipertahankan dalam gambar slide?**

Ya. Aspose.Slides merender bayangan, transparansi, dan efek grafis lain yang didukung dalam gambar slide.