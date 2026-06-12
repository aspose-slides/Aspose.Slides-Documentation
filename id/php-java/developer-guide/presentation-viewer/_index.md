---
title: Buat Penampil Presentasi di PHP
linktitle: Penampil Presentasi
type: docs
weight: 50
url: /id/php-java/presentation-viewer/
keywords:
- lihat presentasi
- penampil presentasi
- buat penampil presentasi
- lihat PPT
- lihat PPTX
- lihat ODP
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Buat penampil presentasi khusus menggunakan Aspose.Slides untuk PHP via Java. Tampilkan file PowerPoint dan OpenDocument dengan mudah tanpa Microsoft PowerPoint."
---
## **Pendahuluan**

Aspose.Slides untuk PHP via Java digunakan untuk membuat file presentasi dengan slide. Slide tersebut dapat dilihat dengan membuka presentasi di Microsoft PowerPoint, misalnya. Namun, terkadang pengembang perlu melihat slide sebagai gambar di penampil gambar pilihan mereka atau membuat penampil presentasi mereka sendiri. Dalam kasus seperti itu, Aspose.Slides memungkinkan Anda mengekspor slide tunggal sebagai gambar. Artikel ini menjelaskan cara melakukannya.

## **Hasilkan Gambar SVG dari Slide**

Untuk menghasilkan gambar SVG dari slide presentasi dengan Aspose.Slides, ikuti langkah-langkah di bawah ini:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Buka aliran file.
1. Simpan slide sebagai gambar SVG ke aliran file.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```

## **Hasilkan SVG dengan ID Bentuk Kustom**

Aspose.Slides dapat digunakan untuk menghasilkan [SVG](https://docs.fileformat.com/page-description-language/svg/) dari slide dengan ID bentuk kustom. Untuk melakukannya, gunakan metode `setId` dari [SvgShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` dapat digunakan untuk mengatur ID bentuk.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```
```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```

## **Buat Gambar Thumbnail Slide**

Aspose.Slides membantu Anda menghasilkan gambar thumbnail slide. Untuk menghasilkan thumbnail slide menggunakan Aspose.Slides, ikuti langkah-langkah di bawah ini:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Dapatkan gambar thumbnail slide yang direferensikan dengan skala yang ditentukan.
1. Simpan gambar thumbnail dalam format gambar apa pun yang diinginkan.

```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Buat Thumbnail Slide dengan Dimensi yang Ditentukan Pengguna**

Untuk membuat gambar thumbnail slide dengan dimensi yang ditentukan pengguna, ikuti langkah-langkah di bawah ini:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Dapatkan gambar thumbnail slide yang direferensikan dengan dimensi yang ditentukan.
1. Simpan gambar thumbnail dalam format gambar apa pun yang diinginkan.

```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Buat Thumbnail Slide dengan Catatan Pembicara**

Untuk menghasilkan thumbnail slide dengan catatan pembicara menggunakan Aspose.Slides, ikuti langkah-langkah di bawah ini:

1. Buat instance kelas [RenderingOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/renderingoptions/).
1. Gunakan metode `RenderingOptions.setSlidesLayoutOptions` untuk mengatur posisi catatan pembicara.
1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Dapatkan gambar thumbnail slide yang direferensikan dengan opsi rendering.
1. Simpan gambar thumbnail dalam format gambar apa pun yang diinginkan.

```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```

## **Contoh Langsung**

Anda dapat mencoba aplikasi gratis [**Aspose.Slides Viewer**](https://products.aspose.app/slides/id/viewer/) untuk melihat apa yang dapat Anda implementasikan dengan API Aspose.Slides:

![Penampil PowerPoint Online](online-PowerPoint-viewer.png)

## **FAQ**

**Apakah saya dapat menyematkan penampil presentasi dalam aplikasi web?**

Ya. Anda dapat menggunakan Aspose.Slides di sisi server untuk merender slide sebagai gambar atau HTML dan menampilkannya di browser. Fitur navigasi dan zoom dapat diimplementasikan dengan JavaScript untuk pengalaman interaktif.

**Apa cara terbaik menampilkan slide di dalam penampil kustom?**

Pendekatan yang disarankan adalah merender setiap slide sebagai gambar (mis., PNG atau SVG) atau mengubahnya menjadi HTML menggunakan Aspose.Slides, lalu menampilkan output di dalam picture box (untuk desktop) atau kontainer HTML (untuk web).

**Bagaimana cara menangani presentasi besar dengan banyak slide?**

Untuk deck besar, pertimbangkan lazy-loading atau rendering slide berdasarkan permintaan. Ini berarti menghasilkan konten slide hanya saat pengguna menavigasinya, mengurangi memori dan waktu pemuatan.