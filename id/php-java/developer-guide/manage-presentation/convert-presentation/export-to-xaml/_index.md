---
title: Ekspor Presentasi ke XAML dalam PHP
linktitle: Presentasi ke XAML
type: docs
weight: 30
url: /id/php-java/export-to-xaml/
keywords:
- ekspor PowerPoint
- ekspor OpenDocument
- ekspor presentasi
- konversi PowerPoint
- konversi OpenDocument
- konversi presentasi
- PowerPoint ke XAML
- OpenDocument ke XAML
- presentasi ke XAML
- PPT ke XAML
- PPTX ke XAML
- ODP ke XAML
- simpan PPT sebagai XAML
- simpan PPTX sebagai XAML
- simpan ODP sebagai XAML
- ekspor PPT ke XAML
- ekspor PPTX ke XAML
- ekspor ODP ke XAML
- PHP
- Aspose.Slides
description: "Konversi slide PowerPoint dan OpenDocument ke XAML menggunakan Aspose.Slides untuk PHP via Java — solusi cepat tanpa Office yang menjaga tata letak Anda tetap utuh."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengekspor presentasi PowerPoint ke XAML menggunakan Aspose.Slides. Artikel ini mencakup pengenalan singkat tentang XAML, menunjukkan cara menyimpan presentasi ke XAML dengan pengaturan default, dan mendemonstrasikan cara menyesuaikan ekspor melalui [XamlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/xamloptions/), termasuk mengekspor slide tersembunyi. Artikel ini juga menjawab beberapa pertanyaan umum terkait font fallback, kompatibilitas tumpukan XAML, dan perilaku ekspor slide tersembunyi.

## **Tentang XAML**

XAML adalah bahasa markup berbasis XML yang digunakan untuk mendeskripsikan antarmuka pengguna dalam kerangka kerja seperti WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), dan Xamarin.Forms.

Anda dapat bekerja dengan file XAML di desainer visual atau menulis dan mengedit markup secara langsung.

## **Ekspor Presentasi ke XAML dengan Opsi Default**

Contoh PHP berikut menunjukkan cara mengekspor presentasi ke XAML dengan pengaturan default. Inisialisasi PHP Java Bridge dan muat `aspose.slides.php` sebelum menjalankan contoh dalam artikel ini. Letakkan `pres.pptx` di direktori kerja server Java Bridge, atau sediakan jalur absolut yang dapat diakses oleh server tersebut.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

Secara default, slide yang diekspor disimpan dalam subfolder `pres` di direktori kerja saat ini server Java Bridge. Folder ini dibuat secara otomatis, dan semua gambar yang diperlukan juga disimpan di sana.

Nama folder output diambil dari nama file sumber tanpa ekstensi. Untuk `pres.pptx`, file output bernama `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, dan seterusnya. Bahkan jika Anda memberikan jalur absolut ke presentasi input, folder output tetap dibuat relatif terhadap direktori kerja server Java Bridge, bukan di samping file input.

## **Ekspor Presentasi ke XAML dengan Opsi Kustom**

Gunakan antarmuka [IXamlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/ixamloptions/) untuk mengontrol bagaimana Aspose.Slides mengekspor presentasi ke XAML.

Untuk menyimpan output ke lokasi kustom, sediakan proxy Java yang mengimplementasikan [IXamlOutputSaver](https://reference.aspose.com/slides/id/java/com.aspose.slides/ixamloutputsaver/) dan berikan instance implementasi Anda ke metode [setOutputSaver](https://reference.aspose.com/slides/id/php-java/aspose.slides/xamloptions/#setOutputSaver) dari [XamlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/xamloptions/).

Untuk menyertakan slide tersembunyi dalam output XAML, panggil [setExportHiddenSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) dengan nilai `true`, seperti pada contoh PHP berikut:

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **Tangkap Semua Artifak XAML yang Dihasilkan**

Ekspor XAML dapat menghasilkan dokumen XAML untuk setiap slide yang diekspor serta gambar dan sumber daya pendukung terpisah. Tetapkan [IXamlOutputSaver](https://reference.aspose.com/slides/id/java/com.aspose.slides/ixamloutputsaver/) kustom ke [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/id/php-java/aspose.slides/xamloptions/#setOutputSaver) untuk menerima artifak tersebut alih-alih menggunakan penyimpan sistem berkas default. Mulai ekspor dengan overload [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save) khusus XAML yang menerima opsi XAML.

Fungsi `java_closure` pada PHP Java Bridge mengekspos objek PHP sebagai antarmuka Java. Jaga agar penyimpan PHP dan proksinya tetap hidup hingga ekspor selesai. Tautan antarmuka mengarah ke API Java yang diimplementasikan oleh proxy.

### **Memahami Siklus Hidup Callback**

Ekspor memanggil [IXamlOutputSaver::save](https://reference.aspose.com/slides/id/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) secara terpisah untuk setiap artifak yang dihasilkan:

- `path` mengidentifikasi artifak dan dapat berisi direktori relatif. Simpan informasi ini karena XAML mungkin merujuk sumber daya dengan jalur relatif.
- `data` berisi byte artifak. Gambar dan sumber daya biner lainnya tidak boleh didekode sebagai teks.
- Penyimpan bertanggung jawab mempertahankan atau menyimpan data sebelum mengembalikan nilai. Contoh mengonversi setiap array byte Java menjadi string biner PHP yang dimiliki aplikasi.
- Anggap ekspor berhasil hanya ketika operasi penyimpanan presentasi mengembalikan nilai dan setiap callback telah selesai dengan sukses. Jangan menelan kesalahan penyimpanan atau memulai penulisan latar belakang yang tidak terpantau. Jika persistensi terjadi setelahnya, laporkan keberhasilan keseluruhan hanya setelah langkah tersebut juga berhasil.

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) juga berlaku untuk penyimpan kustom. Pengaturan default, `false`, mengecualikan dokumen XAML slide tersembunyi. Menetapkan `true` menyertakannya serta sumber daya yang diperlukan untuk ekspornya. Jumlah sumber daya bergantung pada presentasi; jangan mengasumsikan satu callback per slide atau urutan callback yang tetap.

### **Ekspor ke Memori dan Periksa Artifak**

Contoh lengkap ini memuat `pres.pptx`, mengumpulkan setiap artifak dalam array asosiatif PHP berisi string biner, dan mencetak nama, tipe, serta jumlah byte. Nama yang diberikan dipertahankan persis. Nama duplikat menandai kumpulan sebagai tidak valid alih-alih menimpa artifak secara diam-diam. Contoh memeriksa hal ini sebelum menggunakan hasil.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // Hanya XAML yang diperlakukan sebagai teks UTF-8 untuk inspeksi opsional.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

Pemeriksaan ekstensi berguna untuk inspeksi; pertahankan semua artifak, termasuk tipe sumber daya yang tidak dikenal. Biarkan byte tidak berubah saat menyimpan atau mentransmisikannya. String PHP dapat menyimpan data biner, termasuk byte nol. Anggap string sebagai teks UTF-8 hanya saat memeriksa XAML; jangan mengonversi byte gambar atau sumber daya.

### **Kemasan Artifak yang Dikumpulkan dalam Arsip ZIP**

Contoh terpisah ini mengumpulkan ekspor, memvalidasi nama-namanya, dan menulis byte asli ke dalam arsip ZIP. Direktori pekerjaan yang dibuat secara eksklusif memisahkan tugas ekspor yang bersamaan. Contoh ini memerlukan ekstensi PHP Phar dengan dukungan ZIP. Entri ZIP menggunakan garis miring maju dan mempertahankan direktori relatif. Nama tidak aman atau nama yang bertabrakan setelah normalisasi menolak seluruh paket sebelum ditulis.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

Contoh menggunakan [PharData](https://www.php.net/manual/en/class.phardata.php) untuk menulis satu arsip ZIP lokal di direktori kerja proses PHP; eksportor sendiri tidak menulis file XAML atau gambar terpisah. Untuk penyimpanan remote, ganti tahap penulisan arsip dengan mengunggah string biner yang dikumpulkan. Gunakan pengidentifikasi pekerjaan ekspor plus nama artifak relatif penuh sebagai kunci blob, atau simpan pengidentifikasi pekerjaan, nama relatif, dan data biner dalam baris basis data. Publikasikan pekerjaan hanya setelah semua unggahan selesai atau transaksi basis data dikomit. Bersihkan output parsial jika persistensi gagal.

Untuk presentasi besar, penyimpan kustom dapat menyimpan setiap artifak langsung ke penyimpanan aplikasi untuk menghindari menyimpan salinan lengkap ekspor di memori aplikasi. Jaga setiap callback tetap sinkron dari perspektif eksportor: kembalikan nilai hanya setelah tujuan menerima byte, dan izinkan kegagalan menjangkau pemanggil.

### **Pertahankan Nama Sumber Daya dan Verifikasi Referensi**

- Normalisasi pemisah jalur bila tujuan memerlukannya, tetapi pertahankan direktori relatif. Jangan gunakan hanya [basename](https://www.php.net/manual/en/function.basename.php) kecuali setiap nama yang dihasilkan sudah diketahui unik dan referensi sumber daya tetap valid.
- Terapkan validasi nama khusus tujuan. Saat menulis file terpisah, tolak jalur berakar dan segmen travers, resolusi tujuan ke jalur absolut, dan verifikasi tetap berada di bawah direktori ekspor yang dimaksud, termasuk pemisah direktori dalam pemeriksaan containment. Gunakan direktori yang dikontrol aplikasi tanpa tautan simbolik yang dapat mengalihkan penulisan.
- Gunakan penyimpan dan namespace penyimpanan terpisah untuk setiap pekerjaan ekspor. Deteksi tabrakan setelah normalisasi pemisah dan sesuai aturan sensitivitas huruf tujuan.
- Sebelum dipublikasikan, parsing setiap dokumen XAML sebagai XML dan inspeksi referensi sumber daya berbasis file, seperti atribut `Source` atau `ImageSource` pada gambar. Resolusi setiap URI relatif terhadap direktori artifak XAML yang berisi, normalisasi nama penyimpanan yang dihasilkan, dan pastikan kunci peta, entri ZIP, atau objek yang disimpan ada. Tangani URI eksternal dan ekspresi markup XAML secara terpisah dari nama file relatif.

Sebagai contoh, jika `pres/Slide_1.xaml` merujuk ke `images/image1.png`, sumber daya yang disimpan harus tersedia sebagai `pres/images/image1.png`. Menyimpan hanya `image1.png` akan memutus hubungan tersebut. Untuk penyimpanan objek, pertahankan tata letak yang sama di bawah prefiks pekerjaan dan buat URL sumber daya tersebut dapat diakses oleh konsumen XAML. Buka kembali ZIP yang selesai untuk memverifikasi nama entri dan byte sumber daya, serta muat slide representatif di lingkungan XAML target untuk memastikan gambar terresolusi dengan benar.

## **FAQ**

**Bagaimana cara memastikan font tetap konsisten bila font asli tidak tersedia di mesin?**

Panggil [setDefaultRegularFont](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) pada [XamlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/xamloptions/) — font ini akan digunakan sebagai fallback selama ekspor ketika font asli hilang. Hal ini tidak menjamin bahwa XAML yang dihasilkan merujuk ke font fallback atau bahwa font tersebut tersedia di mesin target. Pastikan font yang dirujuk oleh XAML tersedia di lingkungan tempat XAML ditampilkan.

**Apakah XAML yang diekspor hanya ditujukan untuk WPF, atau dapat digunakan di tumpukan XAML lain juga?**

Aspose.Slides mengekspor XAML WPF melalui API publiknya. Kompatibilitas dengan tumpukan XAML lain, seperti UWP dan Xamarin.Forms, tidak dijamin. Uji markup yang dihasilkan di lingkungan target Anda.

**Apakah slide tersembunyi didukung, dan bagaimana cara mencegahnya agar tidak diekspor secara default?**

Secara default, slide tersembunyi tidak disertakan. Anda dapat mengontrol perilaku ini melalui [setExportHiddenSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) pada [XamlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/xamloptions/) — tetap nonaktifkan jika Anda tidak memerlukan ekspor slide tersembunyi.