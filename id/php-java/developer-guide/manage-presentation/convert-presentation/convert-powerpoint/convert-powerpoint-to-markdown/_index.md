---
title: Konversi Presentasi PowerPoint ke Markdown dalam PHP
linktitle: PowerPoint ke Markdown
type: docs
weight: 140
url: /id/php-java/convert-powerpoint-to-markdown/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke MD
- presentasi ke MD
- slide ke MD
- PPT ke MD
- PPTX ke MD
- simpan PowerPoint sebagai Markdown
- simpan presentasi sebagai Markdown
- simpan slide sebagai Markdown
- simpan PPT sebagai MD
- simpan PPTX sebagai MD
- ekspor PPT ke MD
- ekspor PPTX ke MD
- ekspor gambar Markdown
- tautan gambar CDN
- PowerPoint
- presentasi
- Markdown
- PHP
- Aspose.Slides
description: "Konversi presentasi PPT dan PPTX ke Markdown dalam PHP serta mengontrol di mana gambar bitmap, metafile, dan SVG yang diekspor disimpan dan dirujuk."
---
## **Gambaran Umum**

Aspose.Slides untuk PHP via Java dapat mengonversi presentasi PPT dan PPTX ke Markdown untuk dokumentasi, situs statis, migrasi konten, dan alur kerja kontrol versi. Anda dapat memilih varian Markdown, mengontrol cara konten slide dirender, dan menentukan dimana gambar yang diekspor disimpan serta bagaimana Markdown yang dihasilkan merujuknya.

Secara default, ekspor Markdown menggunakan output hanya teks. Untuk mengekspor konten visual, atur jenis ekspor dengan metode [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownsaveoptions/) menjadi nilai `Sequential` atau `Visual` dari enumerasi [MarkdownExportType](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownexporttype/). `Sequential` merender item slide secara terpisah dan berurutan, sedangkan `Visual` menjaga item yang dikelompokkan bersama untuk mempertahankan hubungan visual mereka. Nilai `TextOnly` tidak menghasilkan sumber daya gambar, sehingga callback penyimpanan gambar tidak dipanggil dalam mode tersebut.

## **Konversi Presentasi ke Markdown**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/), kemudian panggil metode [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dengan nilai `Md` dari enumerasi [SaveFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Pilih Variasi Markdown**

Metode [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownsaveoptions/) mengontrol spesifikasi Markdown yang digunakan untuk output. Enumerasi [Flavor](https://reference.aspose.com/slides/id/php-java/aspose.slides/flavor/) mencakup CommonMark, GitHub Flavored Markdown, dan varian lain yang didukung.

Contoh berikut mengekspor presentasi sebagai CommonMark:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **Ekspor Gambar Menggunakan Perilaku Penyimpanan Lokal Default**

Kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownsaveoptions/) menyediakan dua metode untuk mengkonfigurasi gambar yang disimpan secara lokal:

- [setBasePath](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownsaveoptions/) menentukan direktori dasar untuk dokumen Markdown dan sumber dayanya.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownsaveoptions/) menentukan subdirektori gambar. Nilai defaultnya adalah `Images`.

Contoh berikut merender konten visual, menulis gambar ke `output/assets`, dan membuat referensi gambar relatif dalam dokumen Markdown:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Perilaku ini juga berfungsi sebagai cadangan ketika handler penyimpanan gambar khusus mengembalikan `false`.

## **Sesuaikan Penyimpanan Gambar dan Tautan Markdown**

Gunakan metode [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownsaveoptions/) untuk mendaftar callback bagi sumber daya bitmap dan metafile non-SVG yang dihasilkan selama ekspor Markdown. Callback `MarkdownImageSavingHandler`‑nya menerima objek [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/), nilai [ImageFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/imageformat/), dan tautan Markdown yang dihasilkan sebagai array string Java satu elemen. Simpan atau unggah gambar dengan format yang diberikan, dan ganti `$link[0]` dengan referensi yang harus muncul dalam output Markdown.

Sumber daya yang dihasilkan dalam format SVG ditangani secara terpisah. Daftarkan callback dengan metode [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownsaveoptions/). Callback `MarkdownSvgImageSavingHandler`‑nya menerima objek [ISvgImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/isvgimage/) dan array string Java satu elemen `$link`. SVG tidak memiliki argumen `ImageFormat`; tulis atau unggah data XMLnya dari metode [ISvgImage::getSvgData](https://reference.aspose.com/slides/id/php-java/aspose.slides/isvgimage/) sebagai gantinya. Bergantung pada mode ekspor dan pengelompokan visual, SVG dalam presentasi sumber dapat dirasterisasi atau digabungkan dengan konten lain; sumber daya non‑SVG yang dihasilkan kemudian diteruskan ke callback penyimpanan gambar. Daftarkan kedua callback ketika setiap sumber daya visual yang diekspor memerlukan pemrosesan khusus.

Di PHP via Java, implementasikan setiap callback dalam kelas PHP dan gunakan `java_closure` untuk mengekspos objek tersebut sebagai antarmuka Java yang bersesuaian.

{{% alert color="info" title="Note" %}}
Mulai PHP/Java Bridge dengan `JAVA_PREFER_VALUES` diaktifkan sebelum memuat `Java.inc`. Metode [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) mengembalikan `void`, dan mode aliran default jembatan tidak dapat memanggil callback PHP selama panggilan yang diantri tersebut. Contoh lengkap di bawah menyertakan inisialisasi yang diperlukan.
{{% /alert %}}

Nilai balik handler menentukan siapa yang memproses gambar:

- Kembalikan `true` setelah handler menyimpan, mengunggah, mengubah, atau memproses gambar dengan cara lain dan menetapkan nilai yang valid ke `$link[0]`. Aspose.Slides menulis nilai tersebut ke dokumen Markdown dan tidak melakukan penyimpanan lokal default.
- Kembalikan `false` untuk membiarkan Aspose.Slides menyimpan gambar secara lokal dan menghasilkan tautannya sesuai nilai yang diatur oleh [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownsaveoptions/) dan [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Handler yang mengembalikan `true` mengambil tanggung jawab atas gambar. Jika mengembalikan `true` tanpa menetapkan tautan yang valid dan tidak kosong, ekspor gagal dengan `InvalidOperationException`.
{{% /alert %}}

### **Simpan Gambar ke Direktori Asal CDN dan Gunakan URL Eksternal**

Contoh berikut menganggap `cdn-origin/presentations/quarterly-report` sebagai direktori asal CDN yang dipasang atau disinkronkan. Setiap handler mengekstrak nama berkas yang dihasilkan, menyimpan gambar ke direktori khusus tersebut, dan mengganti referensi lokal yang dihasilkan dengan URL CDN publik. Contoh ini tidak melakukan unggahan jaringan: URL menjadi valid hanya setelah direktori dipasang sebagai asal CDN atau berkas‑berkasnya dipublikasikan ke CDN. Untuk penyimpanan objek, ganti penulisan sistem berkas dengan operasi unggah SDK penyimpanan dan tetapkan `$link[0]` hanya setelah unggahan berhasil.

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Handler bitmap secara sengaja mengembalikan `false` untuk gambar yang lebih kecil dari 128 × 128 piksel, sehingga Aspose.Slides menyimpan gambar tersebut ke `output/fallback-images` menggunakan perilaku default. Sumber daya bitmap dan metafile yang lebih besar, serta sumber daya SVG, ditangani oleh kode khusus. Misalnya, referensi lokal yang dihasilkan seperti `fallback-images/image1.png` menjadi `https://cdn.example.com/presentations/quarterly-report/image1.png`. Handler hanya menggunakan jalur sistem operasi saat menulis berkas; tautan yang ditulis ke Markdown menggunakan garis miring maju dan nama berkas yang di‑URL‑escape. Terapkan aturan yang sama saat membangun tautan relatif: gunakan `/`, bukan pemisah direktori spesifik platform.

## **FAQ**

**Apakah satu handler dapat memproses gambar raster dan gambar SVG sekaligus?**

Tidak. Gunakan [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownsaveoptions/) untuk sumber daya bitmap dan metafile yang dihasilkan dan [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownsaveoptions/) untuk sumber daya yang dihasilkan sebagai SVG. Yang pertama menyediakan objek [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/) dan nilai [ImageFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/imageformat/); yang kedua menyediakan objek [ISvgImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/isvgimage/) yang data SVG‑nya dapat dibaca dengan [ISvgImage::getSvgData](https://reference.aspose.com/slides/id/php-java/aspose.slides/isvgimage/). SVG sumber yang dirasterisasi selama ekspor diproses oleh callback penyimpanan gambar.

**Apa yang terjadi ketika handler penyimpanan gambar mengembalikan `false`?**

Aspose.Slides menggunakan perilaku penyimpanan lokal defaultnya. Lokasi gambar dan referensi yang dihasilkan dikendalikan oleh nilai yang diatur dengan [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownsaveoptions/) dan [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownsaveoptions/).

**Dapatkah sebuah handler memberikan URL tanpa menyimpan gambar secara lokal?**

Ya. Handler dapat mengunggah gambar ke penyimpanan objek atau meneruskannya ke layanan lain, menetapkan URL yang dihasilkan ke `$link[0]`, dan mengembalikan `true`. Handler harus menyelesaikan pemrosesan sendiri; mengembalikan `true` mencegah penyimpanan lokal default.

**Mengapa ekspor Markdown melempar `InvalidOperationException` dari sebuah handler?**

Pengecualian ini terjadi ketika handler mengembalikan `true` tetapi tidak memberikan tautan yang valid. Tetapkan jalur relatif atau URL eksternal yang harus ditulis ke Markdown sebelum mengembalikan `true`.

**Pemseparator jalur mana yang harus digunakan oleh tautan gambar?**

Gunakan garis miring maju dalam tautan Markdown dan URL. Gunakan `DIRECTORY_SEPARATOR` hanya untuk jalur sistem berkas, kemudian susun atau normalisasi referensi Markdown secara terpisah.

**Apakah tautan hiperteks dipertahankan selama ekspor Markdown?**

Ya. Teks [hyperlinks](/slides/id/php-java/manage-hyperlinks/) dipertahankan sebagai tautan Markdown standar. [transitions](/slides/id/php-java/slide-transition/) dan [animations](/slides/id/php-java/powerpoint-animation/) pada slide tidak dikonversi.

**Apakah presentasi dapat dikonversi ke Markdown secara paralel?**

Anda dapat memproses berkas presentasi yang berbeda secara paralel, tetapi jangan berbagi instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) yang sama antar thread. Ikuti [multithreading guidelines](/slides/id/php-java/multithreading/) dan gunakan instance terpisah untuk setiap berkas.