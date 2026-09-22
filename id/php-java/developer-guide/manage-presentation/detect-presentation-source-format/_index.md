---
title: Menentukan Format Presentasi Asli dalam PHP
linktitle: Format Sumber
type: docs
weight: 35
url: /id/php-java/detect-presentation-source-format/
keywords:
- format sumber
- deteksi format presentasi
- PowerPoint
- OpenDocument
- presentasi
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Baca format asli dari presentasi yang dimuat dalam PHP dengan Aspose.Slides untuk PHP via Java, bandingkan API deteksi, dan tangani file, stream, serta format legacy."
---
## **Ikhtisar**

Setelah memuat sebuah presentasi, panggil metode [Presentation::getSourceFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getSourceFormat) untuk menentukan format aslinya. Gunakan metode ini ketika pemrosesan berikutnya bergantung pada format dari mana instance saat ini dimuat.

Format sumber berbeda dari [SaveFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/) yang dipilih untuk file output. Menyimpan ke format lain tidak mengubah format sumber dari instance yang ada.

## **Baca Format Sumber dari File**

Contoh ini memerlukan file `sample.pptx` yang sudah ada. Ia memuat file tersebut dan memilih kebijakan pemrosesan aplikasi menggunakan [Presentation::getSourceFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getSourceFormat), bukan nama file. Ubah jalur input untuk mencoba format lain. Contoh ini mencetak kebijakan yang dipilih; ganti pesan tersebut dengan logika aplikasi Anda.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **Kenali Nilai yang Didukung**

Kelas [SourceFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/sourceformat/) mendefinisikan konstanta integer yang membedakan format presentasi berikut. Ekstensi di bawah ini adalah ekstensi konvensional, bukan rekonstruksi nama file asli.

| Nilai SourceFormat | Ekstensi | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | presentasi PowerPoint 97–2003 |
| `Pptx` | `.pptx` | presentasi Office Open XML |
| `Pptm` | `.pptm` | presentasi Office Open XML dengan makro |
| `Pps` | `.pps` | tayangan slide PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | tayangan slide Office Open XML |
| `Ppsm` | `.ppsm` | tayangan slide Office Open XML dengan makro |
| `Pot` | `.pot` | template PowerPoint 97–2003 |
| `Potx` | `.potx` | template Office Open XML |
| `Potm` | `.potm` | template Office Open XML dengan makro |
| `Odp` | `.odp` | presentasi OpenDocument |
| `Otp` | `.otp` | template presentasi OpenDocument |
| `Fodp` | `.fodp` | presentasi Flat XML ODF |
| `Xml` | `.xml` | presentasi PowerPoint XML |

## **Baca Format Sumber dari Stream**

Contoh ini memerlukan file `sample.pps` yang sudah ada. Membaca byte‑bytenya ke dalam stream memori mensimulasikan input yang diterima tanpa nama file, seperti nilai database atau array byte yang diunggah. Konstruktor [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) menerima hanya stream tersebut.

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT, PPS, dan POT menggunakan format biner yang sama. Saat memuat dengan jalur file, ekstensi dapat membantu membedakan tayangan slide atau template. Tanpa nama file, konten PPS atau POT lama dapat dilaporkan sebagai `SourceFormat::Ppt`; contoh PPS di atas mencetak nilai integer `SourceFormat::Ppt`.

Jika aplikasi Anda harus mempertahankan perbedaan tersebut, simpan nama file asli atau metadata subtipe secara terpisah. Ekstensi merupakan petunjuk yang berguna untuk subtipe lama ini, tetapi tidak boleh menjadi satu‑satunya dasar untuk mengidentifikasi konten presentasi apa pun.

## **Bandingkan Deteksi Sebelum dan Sesudah Memuat**

Gunakan [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationfactory/#getPresentationInfo) dan [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#getLoadFormat) ketika Anda perlu memeriksa file sebelum memuat model objek presentasi secara lengkap. Gunakan [Presentation::getSourceFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getSourceFormat) ketika instance sudah ada.

Contoh ini memerlukan `sample.pptx` dan mencetak nilai integer `LoadFormat::Pptx` serta `SourceFormat::Pptx`, masing‑masing. Dalam produksi, pilih API yang sesuai dengan tahap pemrosesan Anda; presentasi yang sudah dimuat tidak membutuhkan pemeriksaan kedua hanya untuk mendapatkan format sumbernya.

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Hasilnya menggunakan konstanta dari kelas yang berbeda: [LoadFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadformat/) dan [SourceFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/sourceformat/). Jangan membandingkan nilai numeriknya atau mengasumsikan setiap format memiliki hasil deteksi yang identik. PowerPoint XML dapat dilaporkan sebagai `LoadFormat::Unknown` sebelum memuat dan `SourceFormat::Xml` setelah memuat.

## **Pisahkan Format Sumber dan Output**

Contoh ini memerlukan `sample.pptx` dan menulis `converted.odp`. Ia mencetak nilai integer `SourceFormat::Pptx` baik sebelum maupun setelah menyimpan instance asli. Hanya instance baru yang dimuat dari output ODP yang melaporkan `Odp`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Sebuah presentasi yang dibuat dari awal dengan `new Presentation()` melaporkan `SourceFormat::Pptx`. Ia tidak memiliki file input: ini adalah nilai default untuk instance yang baru dibuat, bukan bukti bahwa file PPTX telah dimuat. Lacak apakah aplikasi Anda membuat atau memuat instance secara terpisah jika perbedaan itu penting.

## **Pemetaan Format Sumber ke Ekstensi**

Contoh berikut memerlukan `sample.pptx`. Ia memetakan setiap nilai [SourceFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/sourceformat/) yang saat ini didukung ke ekstensi konvensional, tanpa menguraikan nama file input. Penanganan cadangan mencegah penetapan ekstensi secara diam‑diam untuk nilai yang tidak dikenali.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Pemetaan ini tidak mengonversi file atau memulihkan subtipe PPS/POT lama yang hilang selama pemuatan stream. Untuk penyimpanan sebenarnya, pilih [SaveFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/) secara eksplisit, atau gunakan konversi yang ditunjukkan dalam [Save Presentations in Their Original Format](/slides/id/php-java/save-presentation/#save-presentations-in-their-original-format).

## **Verifikasi Format dengan Menyimpan dan Membuka Kembali**

Contoh mandiri ini membuat sebuah presentasi dan menulis tiga file di direktori kerja, menimpa file dengan nama yang sama. Ia membuka kembali masing‑masing output baik melalui jalur file maupun melalui stream memori. Untuk PPTX dan ODP, kedua jalur melaporkan format yang disimpan. Untuk PPS, memuat lewat jalur melaporkan `Pps`, sementara memuat byte yang sama tanpa nama file melaporkan `Ppt`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Tabel berikut merangkum identifikasi format sumber untuk presentasi dengan ekstensi yang cocok. Nama menunjukkan konstanta; contoh PHP mencetak nilai integernya:

| Format Tersimpan | SourceFormat dari jalur file | SourceFormat dari stream tanpa nama |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` masing‑masing | Sama seperti jalur file |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` masing‑masing | Sama seperti jalur file |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` masing‑masing | Sama seperti jalur file |
| ODP, OTP | `Odp`, `Otp` masing‑masing | Sama seperti jalur file |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Konten PPS/POT diidentifikasi sebagai `Ppt` untuk stream tanpa nama. Tabel ini menjelaskan identifikasi format, bukan preservasi setiap fitur presentasi selama konversi.

## **FAQ**

**Apakah menyimpan ke ODP mengubah format sumber sebuah presentasi yang dimuat dari PPTX?**

Tidak. Instance yang ada masih melaporkan `Pptx`. Instance yang dimuat dari file ODP yang disimpan melaporkan `Odp`.

**Apakah sebuah stream selalu dapat membedakan presentasi lama, tayangan slide, dan template?**

Tidak. PPT, PPS, dan POT berbagi format biner. Simpan nama file atau metadata subtipe secara terpisah ketika perbedaan itu diperlukan.

**API mana yang harus saya gunakan jika presentasi sudah dimuat?**

Baca [Presentation::getSourceFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getSourceFormat). Gunakan [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationfactory/#getPresentationInfo) untuk inspeksi sebelum memuat.