---
title: Ekstraksi Teks Lanjutan dari Presentasi di PHP
linktitle: Ekstrak Teks
type: docs
weight: 90
url: /id/php-java/extract-text-from-presentation/
keywords:
- ekstrak teks
- ekstrak teks dari slide
- ekstrak teks dari presentasi
- ekstrak teks dari PowerPoint
- ekstrak teks dari OpenDocument
- ekstrak teks dari PPT
- ekstrak teks dari PPTX
- ekstrak teks dari ODP
- ambil teks
- ambil teks dari slide
- ambil teks dari presentasi
- ambil teks dari PowerPoint
- ambil teks dari OpenDocument
- ambil teks dari PPT
- ambil teks dari PPTX
- ambil teks dari ODP
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Ekstrak teks dengan cepat dari presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP via Java. Ikuti panduan langkah demi langkah kami yang sederhana untuk menghemat waktu."
---
## **Gambaran Umum**

Mengekstrak teks dari presentasi adalah tugas yang umum namun penting bagi pengembang yang bekerja dengan konten slide. Baik Anda menangani file Microsoft PowerPoint dalam format PPT atau PPTX, maupun presentasi OpenDocument (ODP), mengakses dan mengambil data tekstual dapat menjadi kritis untuk analisis, otomatisasi, pengindeksan, atau tujuan migrasi konten.

Artikel ini menyediakan panduan komprehensif tentang cara mengekstrak teks secara efisien dari berbagai format presentasi, termasuk PPT, PPTX, dan ODP, menggunakan Aspose.Slides for PHP via Java. Anda akan belajar cara secara sistematis mengiterasi elemen presentasi untuk secara akurat mengambil konten teks yang Anda perlukan.

## **Ekstrak Teks dari Slide**

Aspose.Slides for PHP via Java menyediakan kelas [SlideUtil](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideutil/). Kelas ini menyediakan beberapa metode statis yang overloaded untuk mengekstrak semua teks dari presentasi atau slide. Untuk mengekstrak teks dari slide dalam sebuah presentasi, gunakan metode [getAllTextBoxes](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideutil/#getAllTextBoxes). Metode ini menerima objek bertipe [BaseSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/) sebagai parameter. Saat dijalankan, metode tersebut memindai seluruh slide untuk teks dan mengembalikan array objek bertipe [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/), mempertahankan semua format teks.

Potongan kode berikut mengekstrak semua teks dari slide pertama presentasi:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Ekstrak Teks dari Presentasi**

Untuk memindai teks dari seluruh presentasi, gunakan metode statis [getAllTextFrames](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideutil/#getAllTextFrames) yang disediakan oleh kelas [SlideUtil](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideutil/). Metode ini menerima dua parameter:

1. Pertama, objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) yang mewakili presentasi PowerPoint atau OpenDocument yang akan diambil teksnya.
2. Kedua, nilai `boolean` yang menunjukkan apakah slide master harus disertakan saat memindai teks dari presentasi.

Metode ini mengembalikan array objek bertipe [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/), termasuk informasi format teks. Kode di bawah ini memindai teks dan detail format dari sebuah presentasi, termasuk slide master.

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Ekstraksi Teks Terklasifikasi dan Cepat**

Kelas [PresentationFactory](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationfactory/) juga menyediakan metode untuk mengekstrak semua teks dari presentasi:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

Argument enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/id/php-java/aspose.slides/textextractionarrangingmode/) menunjukkan mode untuk mengatur hasil ekstraksi teks dan dapat disetel ke nilai berikut:

- `Unarranged` - Teks mentah tanpa memperhatikan posisinya pada slide.
- `Arranged` - Teks diatur dalam urutan yang sama seperti pada slide.

Mode unarranged dapat digunakan ketika kecepatan sangat penting; mode ini lebih cepat daripada mode arranged.

[PresentationText](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationtext/) mewakili teks mentah yang diekstrak dari presentasi. Metode `getSlidesText`-nya mengembalikan array objek di mana setiap objek mewakili teks pada slide yang bersesuaian. Setiap objek yang dikembalikan memiliki metode berikut:

- `getText` - Teks dalam bentuk-bentuk pada slide.
- `getMasterText` - Teks dalam bentuk-bentuk slide master yang terkait dengan slide ini.
- `getLayoutText` - Teks dalam bentuk-bentuk slide tata letak yang terkait dengan slide ini.
- `getNotesText` - Teks dalam bentuk-bentuk slide catatan yang terkait dengan slide ini.
- `getCommentsText` - Teks dalam komentar yang terkait dengan slide ini.

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **FAQ**

**Seberapa cepat Aspose.Slides memproses presentasi besar selama ekstraksi teks?**

Aspose.Slides dioptimalkan untuk kinerja tinggi dan dapat memproses bahkan [presentasi besar](/slides/id/php-java/open-presentation/), menjadikannya cocok untuk skenario pemrosesan waktu nyata atau massal.

**Apakah Aspose.Slides dapat mengekstrak teks dari tabel dan grafik dalam presentasi?**

Ya. Aspose.Slides dapat mengekstrak teks dari banyak elemen slide, termasuk tabel dan objek terkait grafik, sehingga Anda dapat mengakses dan menganalisis konten tekstual dalam struktur presentasi yang umum.

**Apakah saya memerlukan lisensi khusus Aspose.Slides untuk mengekstrak teks dari presentasi?**

Anda dapat mengekstrak teks menggunakan versi trial gratis Aspose.Slides, meskipun akan memiliki [batasan tertentu](/slides/id/php-java/licensing/), seperti memproses hanya sejumlah slide terbatas. Untuk penggunaan tanpa batas dan menangani presentasi yang lebih besar, disarankan untuk membeli lisensi penuh.