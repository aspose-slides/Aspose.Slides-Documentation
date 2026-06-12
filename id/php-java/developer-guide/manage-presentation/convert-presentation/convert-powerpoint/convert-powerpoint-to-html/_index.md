---
title: Konversi Presentasi PowerPoint ke HTML dalam PHP
linktitle: PowerPoint ke HTML
type: docs
weight: 30
url: /id/php-java/convert-powerpoint-to-html/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke HTML
- presentasi ke HTML
- slide ke HTML
- PPT ke HTML
- PPTX ke HTML
- simpan PowerPoint sebagai HTML
- simpan presentasi sebagai HTML
- simpan slide sebagai HTML
- simpan PPT sebagai HTML
- simpan PPTX sebagai HTML
- ekspor PPT ke HTML
- ekspor PPTX ke HTML
- PHP
- Aspose.Slides
description: "Konversi presentasi PowerPoint ke HTML dalam PHP. Gunakan Aspose.Slides untuk mengekspor file PPT dan PPTX, slide terpilih, catatan, font, gambar, SVG, dan media."
---
## **Gambaran Umum**

Aspose.Slides for PHP via Java dapat menyimpan presentasi PowerPoint sebagai HTML tanpa Microsoft PowerPoint. Konversi dasar terdiri dari satu pemuatan [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dan pemanggilan `save` dengan [SaveFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/). Gunakan [HtmlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmloptions/) ketika Anda perlu mengontrol tata letak yang diekspor, font, gambar, catatan, komentar, keluaran SVG, atau sumber daya yang ditautkan.

Panduan ini berfokus pada skenario ekspor HTML yang praktis:

- Mengekspor seluruh presentasi atau slide yang dipilih.
- Menghasilkan HTML dengan tata letak tetap, responsif, atau berbasis SVG.
- Menyertakan catatan pembicara dan komentar.
- Mengontrol kualitas gambar dan data gambar yang dipotong.
- Menyematkan font atau menyimpan file font secara terpisah.
- Memilih cara penulisan dan referensi sumber daya eksternal serta file media.

Secara bawaan, ekspor HTML menghasilkan dokumen HTML yang berdiri sendiri di mana sebagian besar sumber daya disematkan. Ini memudahkan berbagi satu file, tetapi dapat meningkatkan ukuran output. Untuk penerbitan web, pertimbangkan sumber daya eksternal, DPI gambar yang lebih rendah, dan hanya menyematkan font yang tidak tersedia secara andal di lingkungan target.

## **Mengonversi Presentasi ke HTML**

Untuk mengekspor presentasi ke HTML, muat dengan [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dan simpan dengan [SaveFormat.Html](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Contoh ini menulis satu file HTML. Objek presentasi dibuang pada blok `finally`, yang akan melepaskan pegangan file dan sumber daya perenderan setelah ekspor.

## **Menggunakan HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmloptions/) adalah kelas konfigurasi utama untuk ekspor HTML. Pengaturan umum meliputi:

- `SlidesLayoutOptions`: menambahkan catatan, komentar, handout, atau informasi tata letak lainnya.
- `HtmlFormatter`: mengubah struktur dokumen HTML atau mendelegasikan pemformatan ke sebuah kontroler.
- `SlideImageFormat`: mengubah cara slide direpresentasikan, misalnya sebagai SVG.
- `PicturesCompression`: mengontrol DPI gambar dan ukuran output.
- `DeletePicturesCroppedAreas`: mempertahankan atau menghapus data gambar yang dipotong.
- `SvgResponsiveLayout`: membuat konten SVG yang diekspor menyesuaikan diri dengan kontainer-nya.
- `ShowHiddenSlides`: menyertakan slide tersembunyi bila diperlukan.

Bagian berikut menampilkan opsi paling umum secara terpisah sehingga Anda dapat menggabungkan hanya yang dibutuhkan oleh alur kerja Anda.

## **Mengonversi Slide Terpilih ke HTML**

Overload `save` yang menerima nomor slide menggunakan posisi slide berbasis 1. Loop di bawah ini menyimpan setiap slide ke file HTML terpisah.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

Gunakan pola ini ketika sebuah situs web atau aplikasi memerlukan satu halaman HTML per slide. Jika setiap slide harus memiliki tata letak yang sama, buat satu instance [HtmlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmloptions/) dan berikan ke setiap pemanggilan `save`.

## **Membuat HTML Responsif**

[ResponsiveHtmlController](https://reference.aspose.com/slides/id/php-java/aspose.slides/responsivehtmlcontroller/) menyediakan keluaran HTML responsif melalui [HtmlFormatter](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmlformatter/). Gunakan ketika halaman yang diekspor harus lebih baik menyesuaikan lebar browser.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Untuk tata letak responsif berbasis SVG, atur `SvgResponsiveLayout` pada [HtmlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmloptions/). Ini berguna ketika konten slide diekspor sebagai markup SVG yang dapat diskalakan.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Menyertakan Catatan Pembicara dan Komentar**

Gunakan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/notescommentslayoutingoptions/) melalui `HtmlOptions.SlidesLayoutOptions` untuk menyertakan catatan pembicara atau komentar. Catatan dan komentar tersembunyi secara default kecuali Anda menentukan posisinya.

Misalkan presentasi sumber berisi catatan pembicara:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Kode berikut mengekspor konten slide beserta catatan pembicara di bawah slide.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

HTML yang diekspor mencakup area catatan:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Untuk mengekspor komentar, atur `CommentsPosition`, misalnya ke `CommentsPositions.Right` atau `CommentsPositions.Bottom`. Jika Anda hanya memerlukan komentar, hilangkan `NotesPosition`. Jika Anda memerlukan keduanya, atur kedua properti tersebut.

## **Mengontrol Kualitas Gambar dan Area yang Dipotong**

Ekspor HTML dapat mengompres gambar slide untuk mengurangi ukuran output. Atur `PicturesCompression` ke nilai dari [PicturesCompression](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturescompression/) ketika Anda memerlukan kualitas gambar yang lebih tinggi.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Secara bawaan, area yang dipotong dari gambar dapat dihapus dari output yang diekspor. Simpan data yang dipotong hanya ketika pengguna harus dapat memulihkan atau memeriksa bagian gambar yang tersembunyi tersebut. Menyimpannya dapat meningkatkan ukuran HTML.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Menambahkan CSS**

Untuk gaya sederhana, berikan string CSS ke [HtmlFormatter](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmlformatter/) melalui `createDocumentFormatter`. Ini mengubah dokumen HTML di sekelilingnya sementara Aspose.Slides tetap merender konten slide.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Untuk tajuk dokumen khusus, file CSS yang ditautkan, atau markup khusus di sekitar slide dan bentuk, gunakan kontroler pemformatan khusus dan berikan ke [HtmlFormatter](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmlformatter/) dengan `createCustomFormatter`.

## **Menyematkan Font**

Jika lingkungan target mungkin tidak memiliki font presentasi yang diinstal, sematkan font dalam HTML dengan [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/id/php-java/aspose.slides/embedallfontshtmlcontroller/). Menyematkan meningkatkan kesetiaan visual tetapi menambah ukuran output.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Kecualikan font hanya ketika Anda yakin bahwa browser atau sistem target sudah menyediakannya. Untuk font merek atau font yang jarang digunakan, menyematkan biasanya lebih aman.

## **Menautkan File Font Ali Menyematkannya**

Untuk mengurangi ukuran file HTML, Anda dapat menulis data font ke file WOFF terpisah dan menambahkan aturan `@font-face` ke HTML. Dalam PHP via Java, skenario ini biasanya diimplementasikan dengan kelas pembantu Java kecil yang memperluas [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/id/php-java/aspose.slides/embedallfontshtmlcontroller/), menulis byte font ke direktori output, dan menyisipkan aturan `@font-face` ke HTML yang dihasilkan. Kompilasi pembantu tersebut, tambahkan ke classpath PHP Java Bridge, lalu buat instance‑nya dari PHP dengan `new Java(...)`.

Saat membangun pembantu semacam itu, pilih dua jalur dengan sengaja:

- Jalur output sistem berkas, tempat file font yang dihasilkan ditulis.
- Jalur URL, yang dipakai browser dari dokumen HTML untuk memuat file font tersebut.

## **Menyimpan Sumber Daya Secara Eksternal**

HTML yang berdiri sendiri mudah dipindahkan, tetapi sumber daya Base64 yang disematkan dapat membuat file menjadi besar. Jika aplikasi Anda memerlukan file gambar eksternal, sediakan kontroler link/semat khusus ke konstruktor [HtmlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmloptions/).

Ketika Anda mengeksternalisasi sumber daya, pilih dua jalur dengan sengaja:

- Jalur output sistem berkas, tempat aplikasi Anda menulis gambar, font, audio, atau video yang dihasilkan.
- Jalur URL, yang dipakai browser dari dokumen HTML untuk memuat file‑file tersebut.

Pertahankan konsistensi jalur ini dengan tata letak penyebaran Anda agar HTML yang dihasilkan dapat memuat sumber daya eksternal setelah dipindahkan ke server web atau direktori lain.

## **Mengekspor File Media**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoplayerhtmlcontroller/) mengekspor file video dan audio serta menulis HTML yang dapat memutarnya di browser. Konstruktornya menerima:

- `path`: direktori output yang digunakan oleh HTML dan file media yang dihasilkan.
- `fileName`: nama file HTML yang sedang dibuat.
- `baseUri`: awalan URI absolut yang digunakan dalam tautan HTML ke file media.

Jika file HTML berada di `html-output/presentation.html`, `path` harus mengacu ke `html-output`, dan `baseUri` harus mengacu ke direktori yang sama dari sudut pandang browser. Untuk pratinjau lokal, Anda dapat membangun URI `file:///` dari direktori output. Untuk aplikasi yang dipublikasikan, gunakan URL absolut dari direktori output yang dipublikasikan.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

Gunakan direktori output yang unik per pekerjaan ekspor, terutama dalam aplikasi server. Jalur output yang dibagi dapat menyebabkan file dari konversi yang berbeda saling menimpa.

## **Kinerja dan Manajemen Sumber Daya**

Konversi HTML adalah operasi perenderan, sehingga waktu pemrosesan dan penggunaan memori bergantung pada jumlah slide, resolusi gambar, font, efek, diagram, dan media yang disematkan. Nilai DPI `PicturesCompression` yang lebih tinggi, font yang disematkan, output SVG, dan area gambar yang dipotong yang dipertahankan dapat meningkatkan kesetiaan tetapi biasanya menambah ukuran output.

Untuk konversi batch:

- Segera buang setiap instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
- Gunakan direktori output terpisah untuk pekerjaan terpisah.
- Hindari menyematkan font umum kecuali kesetiaan memerlukannya.
- Turunkan DPI gambar ketika HTML hanya untuk pratinjau atau thumbnail.
- Simpan presentasi sumber, HTML yang dihasilkan, dan sumber daya eksternal bersama hingga jalur penyebaran final.

## **FAQ**

**Apakah tautan hiperteks dipertahankan dalam output HTML?**

Ya. Tautan hiperteks pada presentasi diekspor ke HTML dan tetap dapat diklik bila URL target valid.

**Bisakah saya mengonversi presentasi ke HTML secara paralel?**

Ya, tetapi jangan bagikan satu instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) antar thread. Proses file yang berbeda dengan instance presentasi, aliran, dan direktori output yang terpisah.

**Apakah objek Presentation thread‑safe?**

Tidak. Satu instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) harus dimuat, dimodifikasi, disimpan, dan dibuang pada satu thread. Untuk pekerjaan paralel, buat instance independen per thread atau proses.

**Mengapa file HTML yang dihasilkan berukuran besar?**

Ekspor bawaan dapat menyematkan sumber daya langsung ke dalam HTML. Font yang disematkan, gambar DPI tinggi, media, konten SVG, dan area gambar yang dipotong yang dipertahankan semuanya menambah ukuran. Gunakan sumber daya eksternal, kecualikan font umum dari penyematan, dan turunkan `PicturesCompression` ketika ukuran output lebih penting daripada kesetiaan maksimum.

**Mengapa ukuran font PowerPoint seperti 24 pt muncul sebagai 17,999819 pt di HTML?**

Hal ini dapat terjadi karena PowerPoint dan HTML menggunakan model DPI yang berbeda. PowerPoint menyimpan ukuran teks dalam poin tipografi berdasarkan 72 DPI, sementara tata letak HTML didasarkan pada piksel CSS dalam model 96 DPI. Ketika Aspose.Slides mengekspor presentasi ke HTML, ukuran font diterjemahkan antara kedua sistem tersebut, dan konversi dapat memperkenalkan perbedaan pembulatan kecil.

Nilai‑nilai ini tidak menunjukkan perubahan visual ukuran font yang nyata. Mereka hanya efek samping matematis dari konversi metrik teks antara PowerPoint dan HTML.

**Bagaimana saya harus memilih baseUri untuk ekspor media?**

Pilih `baseUri` dari sudut pandang browser dan berikan sebagai URI absolut. Untuk pratinjau lokal, Anda dapat menurunkannya dari direktori output dengan URI berkas Java. Untuk penyebaran, gunakan URL absolut dari direktori media yang dipublikasikan. Sistem berkas `path` dan `baseUri` browser tidak harus berupa string yang sama, tetapi harus menggambarkan lokasi sumber daya yang sama.

**Bisakah saya menyertakan slide tersembunyi?**

Ya. Atur `ShowHiddenSlides` menjadi `true` pada [HtmlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmloptions/) ketika slide tersembunyi harus diekspor.