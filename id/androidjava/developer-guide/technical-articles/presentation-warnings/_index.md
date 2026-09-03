---
title: Menangani Peringatan Presentasi di Android
type: docs
weight: 90
url: /id/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback peringatan
- kebijakan peringatan
- kehilangan data
- kerusakan sumber
- masalah kompatibilitas
- substitusi font
- tanda tangan digital
- pemuatan presentasi
- perenderan presentasi
- konversi presentasi
- penyimpanan presentasi
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Pelajari cara mengumpulkan, mengklasifikasikan, dan menangani peringatan saat memuat, merender, mengonversi, dan menyimpan presentasi dengan Aspose.Slides untuk Android via Java."
---
## **Gambaran Umum**

Aspose.Slides dapat melaporkan masalah yang dapat dipulihkan saat memuat, merender, mengonversi, atau menyimpan presentasi. Contohnya termasuk rekaman sumber yang rusak, konten yang tidak dapat dipertahankan, substitusi font, dan batasan format target. Callback peringatan memungkinkan aplikasi mencatat kondisi ini dan memutuskan apakah operasi saat ini dapat dilanjutkan.

Implementasikan antarmuka [IWarningCallback](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iwarningcallback/) dan periksa nilai yang disediakan melalui [IWarningInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iwarninginfo/) dengan memanggil [getWarningType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) dan [getDescription](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iwarninginfo/#getDescription--). Kembalikan [ReturnAction.Continue](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/returnaction/#Continue) untuk menerima peringatan atau [ReturnAction.Abort](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/returnaction/#Abort) untuk menghentikan operasi.

Gunakan [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) untuk peringatan yang muncul saat membuka presentasi. Kelas opsi rendering dan ekspor mewarisi [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), yang menerima peringatan dari proses perenderan slide, konversi, dan penyimpanan. Karena peringatan itu sendiri tidak mengidentifikasi operasi aplikasi, hubungkan setiap instance callback dengan tahap operasi ketika Anda membuat laporan gabungan.

## **Peringatan dan Pengecualian**

Peringatan menggambarkan kondisi yang dapat dipulihkan Aspose.Slides jika callback mengembalikan `ReturnAction.Continue`. Pengecualian berarti operasi yang diminta tidak dapat selesai secara normal; pengecualian tidak diubah menjadi peringatan dan tidak dapat ditangani oleh kebijakan peringatan.

Mengembalikan `ReturnAction.Abort` meminta dispatcher peringatan untuk menghentikan operasi saat ini dengan memunculkan pengecualian. Pengecualian publik tergantung pada operasi dan format presentasi. Misalnya, proses pemuatan dapat menimbulkan [PptxReadException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxreadexception/) atau [PptReadException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptreadexception/), sementara proses penyimpanan atau ekspor dapat menimbulkan [PptxException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxexception/). Tangani pengecualian pada batas operasi dan gunakan laporan peringatan untuk menentukan apakah kebijakan aplikasi yang menyebabkan penghentian, bukan bergantung pada satu subtipe pengecualian atau pesan. Callback mencatat peringatan sebelum mengembalikan `ReturnAction.Abort`, memastikan alasan tetap tersedia bagi aplikasi.

## **Kategori Peringatan**

Kelas [WarningType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/warningtype/) menyediakan konstanta integer untuk kategori berikut:

| Tipe Peringatan | Makna | Kebijakan umum |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | Presentasi sumber mengandung kerusakan yang dapat membuat dokumen yang disimpan dalam format aslinya tidak dapat digunakan. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/warningtype/#DataLoss) | Teks, diagram, gambar, atau data lain mungkin tidak ada setelah pemuatan atau penyimpanan. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | Presentasi dapat kehilangan format penting. | Abort dalam mode validasi ketat; bila tidak, catat dan lanjutkan. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | Perbedaan format yang terbatas mungkin terjadi. | Catat untuk diagnostik dan lanjutkan. |
| [CompatibilityIssue](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | Hasil mungkin tidak dapat dibuka atau berperilaku tidak tepat di beberapa aplikasi atau versi lama. | Log dan lanjutkan kecuali kompatibilitas wajib. |
| [UnexpectedContent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | Sumber berisi konten yang tidak didukung atau tidak dikenali yang efeknya belum diketahui. | Catat dan lanjutkan, atau perlakukan sebagai kesalahan dalam kebijakan ketat. |

Kategori harus menjadi dasar keputusan kebijakan. Simpan nilai yang dikembalikan oleh [getDescription](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) untuk diagnostik, namun jangan bergantung pada teksnya untuk logika aplikasi karena isi pesan dapat bervariasi antar skenario peringatan dan versi produk.

## **Kumpulkan dan Klasifikasikan Peringatan**

Contoh berikut menggunakan satu laporan tingkat aplikasi untuk seluruh pipeline pemrosesan. Setiap instance callback terpisah menandai peringatan dari pemuatan, perenderan, konversi PDF, dan penyimpanan PPTX. Kebijakan abort pada korupsi sumber atau kehilangan data, opsional abort pada kehilangan format mayor, dan melanjutkan untuk peringatan lainnya.

Letakkan `input.pptx` di direktori aplikasi yang dapat ditulisi dan berikan direktori tersebut ke `PresentationWarningExample.run`. Contoh menyimpan outputnya di direktori yang sama. Jalankan pemrosesan presentasi pada thread latar belakang agar antarmuka pengguna Android tetap responsif.

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

Berikan `false` untuk `abortOnMajorFormattingLoss` saat membuat `WarningPolicy` bila perbedaan format mayor dapat diterima. Masalah kompatibilitas, kehilangan format minor, dan konten tak terduga tetap disimpan dalam laporan bahkan ketika operasi berlanjut. Perluas `WarningPolicy.getAction` bila aplikasi harus menolak salah satu kategori tersebut.

## **Skenario Peringatan Umum**

Peringatan dapat muncul pada tahap berbeda dalam alur kerja:

- **Tanda tangan digital:** Presentasi yang ditandatangani dapat menghasilkan peringatan saat pemuatan bahwa tandatangan akan hilang selama pemrosesan. Aspose.Slides melaporkan kondisi `DataLoss` ini melalui [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/). Callback pada tahap pemuatan memungkinkan aplikasi menolak file atau secara eksplisit menerima kehilangan yang dilaporkan.
- **Substitusi font:** Font yang tidak tersedia dapat diganti saat slide dirender atau diekspor. Peringatan substitusi font dilaporkan sebagai `DataLoss`, sehingga kebijakan ketat di atas abort meskipun aplikasi menganggap penggantian tertentu dapat diterima secara visual. Untuk mengamati perilaku ini, gunakan presentasi input yang berisi teks dengan font yang tidak tersedia pada runtime. Deskripsi peringatan mengidentifikasi substitusi; konfigurasikan font yang diperlukan atau [aturan substitusi font](/slides/id/androidjava/font-substitution/) sebelum mencoba lagi.
- **Konten yang tidak didukung atau tidak terduga:** Loader dapat menemukan rekaman atau fitur presentasi yang tidak dikenali. Peringatan semacam itu dapat menggunakan `UnexpectedContent`, atau kategori yang lebih berat bila data atau format diketahui terpengaruh.
- **Kompatibilitas format:** Menyimpan ke format presentasi lain dapat menghilangkan fitur atau menghasilkan hasil yang berperilaku berbeda di beberapa aplikasi. Misalnya, menyimpan presentasi dengan lebih dari delapan panduan gambar horizontal atau vertikal ke PPT lama melaporkan `CompatibilityIssue`. Callback pada tahap penyimpanan dapat mencatat kehilangan dan melanjutkan, atau menolaknya bila semua panduan harus dipertahankan.
- **Perilaku pemuatan:** Opsi pemuatan dan perilaku lama juga dapat menghasilkan peringatan. Contohnya, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) mengidentifikasi penggunaan perilaku penguncian presentasi usang sebagai `CompatibilityIssue`.

Peringatan bergantung pada dokumen sumber, format target, operasi, dan versi Aspose.Slides. Jangan mengasumsikan setiap berkas menghasilkan peringatan atau bahwa skenario selalu masuk ke satu kategori saja.

## **Menangani Operasi yang Dibatalkan dengan Aman**

Ketika callback mengembalikan `ReturnAction.Abort`, jangan gunakan objek yang gagal dimuat dan jangan mengasumsikan bahwa hasil render atau simpan selesai. Operasi dapat berakhir setelah membuat berkas output tetapi sebelum selesai sepenuhnya.

Simpan hasil yang telah divalidasi ke jalur terpisah seperti `validated-output.pptx`. Ganti presentasi yang ada hanya setelah operasi selesai dengan sukses, laporan peringatan memenuhi kebijakan aplikasi, dan output dapat dibuka serta diperiksa. Ini mencegah menimpa berkas sumber yang valid dengan hasil parsial atau ditolak.

Laporan peringatan kosong tidak menjamin setiap fitur sumber telah dipertahankan. Terapkan pemeriksaan konten dan visual tambahan yang diperlukan oleh aplikasi. Lihat juga [Open Presentations](/slides/id/androidjava/open-presentation/) dan [Save Presentations](/slides/id/androidjava/save-presentation/).

## **FAQ**

**Apakah callback peringatan dapat menangani setiap kesalahan Aspose.Slides?**

Tidak. Ia menangani kondisi yang dapat dipulihkan yang dilaporkan sebagai peringatan. Pengecualian yang terjadi terlepas dari callback harus ditangani oleh aplikasi di sekitar pemanggilan pemuatan, perenderan, konversi, atau penyimpanan.

**Apakah mengembalikan `ReturnAction.Continue` menjamin output yang identik?**

Tidak. Itu hanya mengizinkan pemrosesan berlanjut. Kondisi yang dilaporkan masih dapat menyebabkan perbedaan data, format, atau kompatibilitas, sehingga tinjau tipe dan deskripsi peringatan yang terkumpul.

**Bagaimana aplikasi dapat mengidentifikasi operasi yang menghasilkan peringatan?**

Buat instance callback untuk setiap operasi dan simpan tahap yang didefinisikan aplikasi bersama nilai yang dikembalikan oleh [getWarningType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) dan [getDescription](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iwarninginfo/#getDescription--), seperti yang ditunjukkan dalam contoh.