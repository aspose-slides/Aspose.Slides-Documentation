---
title: Tangani Peringatan Presentasi dalam PHP
type: docs
weight: 90
url: /id/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback peringatan
- kebijakan peringatan
- kehilangan data
- korupsi sumber
- masalah kompatibilitas
- substitusi font
- tanda tangan digital
- pemuatan presentasi
- rendering presentasi
- konversi presentasi
- penyimpanan presentasi
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Pelajari cara mengumpulkan, mengklasifikasikan, dan menanggapi peringatan saat memuat, merender, mengonversi, dan menyimpan presentasi dengan Aspose.Slides untuk PHP melalui Java."
---
## **Ikhtisar**

Aspose.Slides dapat melaporkan masalah yang dapat dipulihkan saat memuat, merender, mengonversi, atau menyimpan sebuah presentasi. Contohnya termasuk catatan sumber yang rusak, konten yang tidak dapat dipertahankan, substitusi font, dan batasan format tujuan. Callback peringatan memungkinkan aplikasi mencatat kondisi ini dan memutuskan apakah operasi saat ini dapat melanjutkan.

Buat kelas PHP dengan metode publik `warning` dan expose melalui PHP Java Bridge sebagai antarmuka Java [IWarningCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarningcallback/) menggunakan `java_closure`. Periksa nilai [getWarningType](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/#getWarningType--) dan [getDescription](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/#getDescription--) yang disediakan melalui [IWarningInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/). Kembalikan [ReturnAction::Continue](https://reference.aspose.com/slides/id/php-java/aspose.slides/returnaction/#Continue) untuk menerima peringatan atau [ReturnAction::Abort](https://reference.aspose.com/slides/id/php-java/aspose.slides/returnaction/#Abort) untuk menghentikan operasi.

Gunakan [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setWarningCallback) untuk peringatan yang muncul saat membuka sebuah presentasi. Kelas opsi render dan ekspor mewarisi [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveoptions/#setWarningCallback), yang menerima peringatan dari rendering slide, konversi, dan penyimpanan. Karena peringatan itu sendiri tidak mengidentifikasi operasi aplikasi, kaitkan setiap instance callback dengan tahap operasi saat Anda membangun laporan gabungan.

## **Peringatan dan Pengecualian**

Pengecualian Java diekspos ke PHP melalui PHP Java Bridge; tangkap mereka pada batas operasi, seperti yang ditunjukkan pada contoh di bawah. Tautan antarmuka Java dalam artikel ini menjelaskan kontrak callback yang digunakan oleh bridge.

Sebuah peringatan menggambarkan kondisi yang dapat dipulihkan oleh Aspose.Slides jika callback mengembalikan `ReturnAction::Continue`. Sebuah pengecualian berarti operasi yang diminta tidak dapat selesai secara normal; pengecualian tidak diubah menjadi peringatan dan tidak dapat ditangani oleh kebijakan peringatan.

Mengembalikan `ReturnAction::Abort` meminta dispatcher peringatan untuk menghentikan operasi saat ini dengan memunculkan pengecualian. Pengecualian publik tergantung pada operasi dan format presentasi. Misalnya, pemuatan dapat menghasilkan [PptxReadException](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxreadexception/) atau [PptReadException](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptreadexception/), sementara penyimpanan atau ekspor dapat menghasilkan [PptxException](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxexception/). Tangani pengecualian pada batas operasi dan gunakan laporan peringatan untuk menentukan apakah kebijakan aplikasi yang menyebabkan penghentian alih-alih bergantung pada satu subtipe pengecualian atau pesan. Callback mencatat peringatan sebelum mengembalikan `ReturnAction::Abort`, memastikan alasan tetap tersedia bagi aplikasi.

## **Kategori Peringatan**

Kelas [WarningType](https://reference.aspose.com/slides/id/php-java/aspose.slides/warningtype/) menyediakan konstanta integer untuk kategori berikut:

| Jenis Peringatan | Arti | Kebijakan umum |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/id/php-java/aspose.slides/warningtype/#SourceFileCorruption) | Presentasi sumber berisi korupsi yang dapat membuat dokumen yang disimpan dalam format aslinya tidak dapat digunakan. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/id/php-java/aspose.slides/warningtype/#DataLoss) | Teks, diagram, gambar, atau data lain mungkin tidak ada setelah memuat atau menyimpan. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/id/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | Presentasi dapat kehilangan format penting. | Abort in strict validation mode; otherwise record and continue. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/id/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | Perbedaan format terbatas dapat terjadi. | Record for diagnostics and continue. |
| [CompatibilityIssue](https://reference.aspose.com/slides/id/php-java/aspose.slides/warningtype/#CompatibilityIssue) | Hasil mungkin tidak dapat dibuka atau berperilaku dengan benar di beberapa aplikasi atau versi lama. | Log and continue unless compatibility is mandatory. |
| [UnexpectedContent](https://reference.aspose.com/slides/id/php-java/aspose.slides/warningtype/#UnexpectedContent) | Sumber berisi konten yang tidak didukung atau tidak dikenali yang efeknya mungkin belum diketahui. | Record and continue, or treat as an error in a strict policy. |

Kategori harus menjadi dasar keputusan kebijakan. Simpan nilai yang dikembalikan oleh [getDescription](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/#getDescription--) untuk diagnostik, tetapi jangan bergantung pada kata-katanya untuk logika aplikasi karena teks pesan dapat bervariasi antara skenario peringatan dan versi produk.

## **Kumpulkan dan Klasifikasikan Peringatan**

Contoh berikut menggunakan satu laporan tingkat aplikasi untuk seluruh pipeline pemrosesan. Instance callback terpisah memberi label peringatan dari pemuatan, rendering, konversi PDF, dan penyimpanan PPTX. Kebijakan membatalkan pada korupsi sumber atau kehilangan data, secara opsional membatalkan pada kehilangan format mayor, dan melanjutkan untuk peringatan lainnya. Callback mengonversi nilai peringatan ke nilai PHP asli dengan `java_values` sebelum mencatat dan membandingkannya.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

Berikan `false` untuk `abortOnMajorFormattingLoss` saat membuat `WarningPolicy` jika perbedaan format mayor dapat diterima. Masalah kompatibilitas, kehilangan format minor, dan konten tak terduga tetap disimpan dalam laporan meskipun operasi berlanjut. Perluas `WarningPolicy::getAction` jika aplikasi harus menolak salah satu kategori tersebut.

## **Skenario Peringatan Umum**

Peringatan dapat muncul pada tahap berbeda dalam alur kerja:

- **Tanda tangan digital:** Sebuah presentasi yang ditandatangani dapat menghasilkan peringatan saat pemuatan bahwa tanda tangannya akan hilang selama proses. Aspose.Slides melaporkan kondisi `DataLoss` ini melalui [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationsignedwarninginfo/). Callback pada tahap pemuatan memungkinkan aplikasi menolak file atau secara eksplisit menerima kehilangan yang dilaporkan.
- **Substitusi font:** Font yang tidak tersedia dapat diganti saat slide dirender atau diekspor. Peringatan substitusi font dilaporkan sebagai `DataLoss`, sehingga kebijakan ketat di atas membatalkan meskipun aplikasi menganggap penggantian tertentu dapat diterima secara visual. Untuk mengamati perilaku ini, gunakan presentasi masukan yang berisi teks dengan font yang tidak tersedia pada runtime. Deskripsi peringatan mengidentifikasi substitusi; konfigurasikan font yang diperlukan atau [aturan substitusi font](/slides/id/php-java/font-substitution/) sebelum mencoba lagi.
- **Konten yang tidak didukung atau tak terduga:** Loader dapat menemukan catatan atau fitur presentasi yang tidak dikenalnya. Peringatan semacam itu dapat menggunakan `UnexpectedContent`, atau kategori yang lebih serius bila data atau format diketahui terpengaruh.
- **Kompatibilitas format:** Menyimpan ke format presentasi lain dapat menghilangkan fitur atau menghasilkan hasil yang berperilaku berbeda di beberapa aplikasi. Misalnya, menyimpan presentasi dengan lebih dari delapan panduan gambar horizontal atau delapan panduan vertikal ke PPT lama melaporkan `CompatibilityIssue`. Callback pada tahap penyimpanan dapat mencatat kehilangan tersebut dan melanjutkan, atau menolaknya jika harus mempertahankan semua panduan.
- **Perilaku pemuatan:** Opsi pemuatan dan perilaku lama juga dapat menghasilkan peringatan. Misalnya, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) mengidentifikasi penggunaan perilaku penguncian presentasi usang sebagai `CompatibilityIssue`.

Peringatan bergantung pada dokumen sumber, format target, operasi, dan versi Aspose.Slides. Jangan menganggap setiap file menghasilkan peringatan atau bahwa sebuah skenario selalu berhubungan dengan satu kategori saja.

## **Menangani Operasi yang Dibatalkan dengan Aman**

Ketika callback mengembalikan `ReturnAction::Abort`, jangan gunakan objek yang gagal dimuat dan jangan menganggap bahwa output rendering atau penyimpanan sudah lengkap. Operasi dapat berhenti setelah membuat file output namun sebelum selesai.

Simpan hasil yang telah divalidasi ke jalur terpisah seperti `validated-output.pptx`. Ganti presentasi yang ada hanya setelah operasi selesai dengan sukses, laporan peringatan memenuhi kebijakan aplikasi, dan output dapat dibuka serta diperiksa. Ini mencegah menimpa file sumber yang valid dengan hasil parsial atau ditolak.

Laporan peringatan yang kosong bukan jaminan bahwa setiap fitur sumber telah dipertahankan. Terapkan pemeriksaan konten dan visual tambahan yang diperlukan oleh aplikasi. Lihat juga [Open Presentations](/slides/id/php-java/open-presentation/) dan [Save Presentations](/slides/id/php-java/save-presentation/).

## **FAQ**

**Bisakah callback peringatan menangani setiap kesalahan Aspose.Slides?**

Tidak. Itu menangani kondisi yang dapat dipulihkan yang dilaporkan sebagai peringatan. Pengecualian yang terjadi secara terpisah dari callback harus ditangani oleh aplikasi di sekitar panggilan pemuatan, rendering, konversi, atau penyimpanan.

**Apakah mengembalikan `ReturnAction::Continue` menjamin output yang identik?**

Tidak. Itu hanya mengizinkan pemrosesan berlanjut. Kondisi yang dilaporkan masih dapat menyebabkan perbedaan data, format, atau kompatibilitas, jadi tinjau jenis peringatan dan deskripsinya yang dikumpulkan.

**Bagaimana sebuah aplikasi dapat mengidentifikasi operasi yang menghasilkan peringatan?**

Buat instance callback untuk setiap operasi dan simpan tahap yang didefinisikan aplikasi bersama nilai yang dikembalikan oleh [getWarningType](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/#getWarningType--) dan [getDescription](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/#getDescription--), seperti yang ditunjukkan pada contoh.