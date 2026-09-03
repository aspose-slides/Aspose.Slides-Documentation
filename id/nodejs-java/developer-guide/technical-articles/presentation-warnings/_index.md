---
title: Menangani Peringatan Presentasi di Node.js
type: docs
weight: 90
url: /id/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/mendapatkan-callback-peringatan-untuk-substitusi-font-di-aspose-slides/
keywords:
- callback peringatan
- kebijakan peringatan
- kehilangan data
- korupsi sumber
- masalah kompatibilitas
- substitusi font
- tanda tangan digital
- pemuat presentasi
- perenderan presentasi
- konversi presentasi
- penyimpanan presentasi
- PowerPoint
- OpenDocument
- JavaScript
- Node.js
- Aspose.Slides
description: "Pelajari cara mengumpulkan, mengklasifikasikan, dan menangani peringatan saat memuat, merender, mengonversi, dan menyimpan presentasi dengan Aspose.Slides untuk Node.js via Java."
---
## **Overview**

Aspose.Slides dapat melaporkan masalah yang dapat dipulihkan saat memuat, merender, mengonversi, atau menyimpan presentasi. Contohnya termasuk rekaman sumber yang rusak, konten yang tidak dapat dipertahankan, substitusi font, dan batasan format target. Callback peringatan memungkinkan aplikasi mencatat kondisi ini dan memutuskan apakah operasi saat ini dapat dilanjutkan.

Gunakan `java.newProxy` untuk mengimplementasikan antarmuka Java [IWarningCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarningcallback/) dalam JavaScript dan periksa nilai [getWarningType](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/#getWarningType--) dan [getDescription](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/#getDescription--) yang disediakan melalui [IWarningInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/). Kembalikan [ReturnAction.Continue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/returnaction/#Continue) untuk menerima peringatan atau [ReturnAction.Abort](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/returnaction/#Abort) untuk menghentikan operasi.

Gunakan [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) untuk peringatan yang muncul saat membuka presentasi. Kelas opsi rendering dan ekspor mewarisi [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveoptions/#setWarningCallback), yang menerima peringatan dari perenderan slide, konversi, dan penyimpanan. Karena peringatan itu sendiri tidak mengidentifikasi operasi aplikasi, hubungkan setiap instance callback dengan tahap operasi saat Anda membuat laporan gabungan.

## **Warnings and Exceptions**

Sebuah peringatan menggambarkan kondisi yang dapat dipulihkan oleh Aspose.Slides jika callback mengembalikan `ReturnAction.Continue`. Sebuah pengecualian berarti operasi yang diminta tidak dapat selesai secara normal; pengecualian tidak dikonversi menjadi peringatan dan tidak dapat ditangani oleh kebijakan peringatan.

Mengembalikan `ReturnAction.Abort` meminta dispatcher peringatan untuk menghentikan operasi saat ini dengan menaikkan pengecualian. Pengecualian publik bergantung pada operasi dan format presentasi. Misalnya, pemuatan dapat menghasilkan [PptxReadException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxreadexception/) atau [PptReadException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptreadexception/), sementara penyimpanan atau ekspor dapat menghasilkan [PptxException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxexception/). Tangkap kesalahan dari jembatan Java pada batas operasi dan gunakan laporan peringatan untuk menentukan apakah kebijakan aplikasi menyebabkan penghentian alih-alih bergantung pada satu subtipe pengecualian atau pesan. Callback mencatat peringatan sebelum mengembalikan `ReturnAction.Abort`, memastikan alasan tetap tersedia bagi aplikasi.

## **Warning Categories**

Kelas [WarningType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/warningtype/) menyediakan konstanta integer untuk kategori berikut:

| Tipe peringatan | Arti | Kebijakan umum |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | Presentasi sumber berisi korupsi yang dapat membuat dokumen yang disimpan dalam format aslinya tidak dapat digunakan. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/warningtype/#DataLoss) | Teks, diagram, gambar, atau data lain mungkin tidak ada setelah memuat atau menyimpan. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | Presentasi dapat kehilangan pemformatan penting. | Abort in strict validation mode; otherwise record and continue. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | Perbedaan pemformatan terbatas dapat terjadi. | Record for diagnostics and continue. |
| [CompatibilityIssue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | Hasil mungkin tidak dapat dibuka atau berperilaku dengan benar di beberapa aplikasi atau versi lama. | Log and continue unless compatibility is mandatory. |
| [UnexpectedContent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | Sumber berisi konten yang tidak didukung atau tidak dikenali yang efeknya mungkin belum diketahui. | Record and continue, or treat as an error in a strict policy. |

Kategori harus menjadi panduan keputusan kebijakan. Simpan nilai yang dikembalikan oleh [getDescription](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/#getDescription--) untuk diagnostik, tetapi jangan bergantung pada rumusannya untuk logika aplikasi karena teks pesan dapat bervariasi antar skenario peringatan dan versi produk.

## **Collect and Classify Warnings**

Contoh JavaScript berikut menggunakan satu laporan tingkat aplikasi untuk seluruh pipeline pemrosesan. Instance callback terpisah memberi label peringatan dari pemuatan, perenderan, konversi PDF, dan penyimpanan PPTX. Kebijakan membatalkan pada korupsi sumber atau kehilangan data, secara opsional membatalkan pada kehilangan format utama, dan melanjutkan untuk peringatan lainnya.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

Berikan `false` untuk `abortOnMajorFormattingLoss` saat membangun `WarningPolicy` jika perbedaan format utama dapat diterima. Masalah kompatibilitas, kehilangan format minor, dan konten tak terduga tetap dipertahankan dalam laporan meskipun operasi berlanjut. Perluas `WarningPolicy.getAction` jika aplikasi harus menolak salah satu kategori tersebut.

## **Common Warning Scenarios**

Peringatan dapat muncul pada tahap berbeda dalam alur kerja:

- **Digital signatures:** Sebuah presentasi yang ditandatangani dapat menghasilkan peringatan selama pemuatan bahwa tanda tangannya akan hilang selama pemrosesan. Aspose.Slides melaporkan kondisi `DataLoss` ini melalui [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationsignedwarninginfo/). Callback tahap pemuatan memungkinkan aplikasi menolak file atau secara eksplisit menerima kehilangan yang dilaporkan.
- **Font substitution:** Font yang tidak tersedia dapat digantikan saat slide dirender atau diekspor. Peringatan substitusi font dilaporkan sebagai `DataLoss`, sehingga kebijakan ketat di atas membatalkan meskipun aplikasi menganggap penggantian tertentu dapat diterima secara visual. Untuk mengamati perilaku ini, gunakan presentasi input yang berisi teks dengan font yang tidak tersedia bagi runtime. Deskripsi peringatan mengidentifikasi substitusi; konfigurasikan font yang diperlukan atau [font substitution rules](/slides/id/nodejs-java/font-substitution/) sebelum mencoba kembali.
- **Unsupported or unexpected content:** Loader dapat menemukan rekaman atau fitur presentasi yang tidak dikenalnya. Peringatan semacam itu mungkin menggunakan `UnexpectedContent`, atau kategori yang lebih serius ketika data atau pemformatan diketahui terpengaruh.
- **Format compatibility:** Menyimpan ke format presentasi lain dapat menghilangkan fitur atau menghasilkan hasil yang berperilaku berbeda pada beberapa aplikasi. Misalnya, menyimpan presentasi dengan lebih dari delapan panduan gambar horizontal atau vertikal ke PPT lama melaporkan `CompatibilityIssue`. Callback tahap penyimpanan dapat mencatat kehilangan dan melanjutkan, atau menolaknya jika menjaga semua panduan wajib.
- **Loading behavior:** Opsi pemuatan dan perilaku legacy juga dapat menghasilkan peringatan. Misalnya, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) mengidentifikasi penggunaan perilaku penguncian presentasi usang sebagai `CompatibilityIssue`.

Peringatan bergantung pada dokumen sumber, format target, operasi, dan versi Aspose.Slides. Jangan mengasumsikan setiap file menghasilkan peringatan atau bahwa sebuah skenario selalu terhubung ke satu kategori saja.

## **Safely Handle Aborted Operations**

Ketika sebuah callback mengembalikan `ReturnAction.Abort`, jangan gunakan objek yang gagal dimuat dan jangan menganggap output perenderan atau penyimpanan selesai. Operasi dapat berakhir setelah membuat file output tetapi sebelum selesai sepenuhnya.

Simpan hasil yang telah divalidasi ke jalur terpisah seperti `validated-output.pptx`. Ganti presentasi yang ada hanya setelah operasi selesai dengan sukses, laporan peringatan memenuhi kebijakan aplikasi, dan output dapat dibuka serta diperiksa. Ini menghindari penimpaan file sumber yang valid dengan hasil parsial atau ditolak.

Laporan peringatan kosong bukan jaminan bahwa setiap fitur sumber telah dipertahankan. Terapkan pemeriksaan konten dan visual tambahan yang diperlukan oleh aplikasi. Lihat juga [Open Presentations](/slides/id/nodejs-java/open-presentation/) dan [Save Presentations](/slides/id/nodejs-java/save-presentation/).

## **FAQ**

**Can a warning callback handle every Aspose.Slides error?**

Tidak. Ia menangani kondisi yang dapat dipulihkan yang dilaporkan sebagai peringatan. Pengecualian yang terjadi terpisah dari callback harus ditangani oleh aplikasi di sekitar panggilan pemuatan, perenderan, konversi, atau penyimpanan.

**Does returning `ReturnAction.Continue` guarantee identical output?**

Tidak. Itu hanya memungkinkan pemrosesan berlanjut. Kondisi yang dilaporkan masih dapat menyebabkan perbedaan data, pemformatan, atau kompatibilitas, jadi tinjau tipe peringatan dan deskripsi yang terkumpul.

**How can an application identify the operation that produced a warning?**

Buat instance callback untuk setiap operasi dan simpan tahap yang didefinisikan aplikasi bersama nilai yang dikembalikan oleh [getWarningType](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/#getWarningType--) dan [getDescription](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/#getDescription--), seperti yang ditunjukkan dalam contoh.