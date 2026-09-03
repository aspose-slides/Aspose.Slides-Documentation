---
title: Menangani Peringatan Presentasi di Java
type: docs
weight: 90
url: /id/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Java
- Aspose.Slides
description: "Pelajari cara mengumpulkan, mengklasifikasikan, dan menangani peringatan saat memuat, merender, mengonversi, dan menyimpan presentasi dengan Aspose.Slides untuk Java."
---
## **Ikhtisar**

Aspose.Slides dapat melaporkan masalah yang dapat dipulihkan saat memuat, merender, mengonversi, atau menyimpan sebuah presentasi. Contohnya meliputi catatan sumber yang rusak, konten yang tidak dapat dipertahankan, substitusi font, dan keterbatasan format target. Callback peringatan memungkinkan aplikasi mencatat kondisi ini dan memutuskan apakah operasi saat ini dapat dilanjutkan.

Implementasikan antarmuka [IWarningCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarningcallback/) dan periksa nilai [getWarningType](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/#getWarningType--) serta [getDescription](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/#getDescription--) yang disediakan melalui [IWarningInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/). Kembalikan [ReturnAction.Continue](https://reference.aspose.com/slides/id/java/com.aspose.slides/returnaction/#Continue) untuk menerima peringatan atau [ReturnAction.Abort](https://reference.aspose.com/slides/id/java/com.aspose.slides/returnaction/#Abort) untuk menghentikan operasi.

Gunakan [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) untuk peringatan yang muncul saat membuka sebuah presentasi. Kelas opsi rendering dan ekspor mewarisi [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), yang menerima peringatan dari proses rendering slide, konversi, dan penyimpanan. Karena peringatan itu sendiri tidak mengidentifikasi operasi aplikasi, asosiasikan setiap instance callback dengan tahap operasi saat Anda membangun laporan gabungan.

## **Peringatan dan Pengecualian**

Sebuah peringatan menggambarkan kondisi yang dapat dipulihkan oleh Aspose.Slides jika callback mengembalikan `ReturnAction.Continue`. Pengecualian berarti operasi yang diminta tidak dapat selesai secara normal; pengecualian tidak diubah menjadi peringatan dan tidak dapat ditangani oleh kebijakan peringatan.

Mengembalikan `ReturnAction.Abort` meminta dispatcher peringatan untuk menghentikan operasi saat ini dengan memunculkan pengecualian. Pengecualian publik tergantung pada operasi dan format presentasi. Misalnya, pemuatan dapat menimbulkan [PptxReadException](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptxreadexception/) atau [PptReadException](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptreadexception/), sementara penyimpanan atau ekspor dapat menimbulkan [PptxException](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptxexception/). Tangani pengecualian di batas operasi dan gunakan laporan peringatan untuk menentukan apakah kebijakan aplikasi menyebabkan penghentian, bukan hanya mengandalkan satu subtipe pengecualian atau pesan. Callback mencatat peringatan sebelum mengembalikan `ReturnAction.Abort`, memastikan alasan tetap tersedia bagi aplikasi.

## **Kategori Peringatan**

Kelas [WarningType](https://reference.aspose.com/slides/id/java/com.aspose.slides/warningtype/) menyediakan konstanta integer untuk kategori berikut:

| Jenis Peringatan | Makna | Kebijakan Tipikal |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/id/java/com.aspose.slides/warningtype/#SourceFileCorruption) | Presentasi sumber mengandung kerusakan yang dapat membuat dokumen dalam format aslinya tidak dapat digunakan. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/id/java/com.aspose.slides/warningtype/#DataLoss) | Teks, grafik, gambar, atau data lain mungkin tidak ada setelah pemuatan atau penyimpanan. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/id/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | Presentasi dapat kehilangan format penting. | Abort dalam mode validasi ketat; jika tidak, catat dan lanjutkan. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/id/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | Perbedaan format terbatas dapat terjadi. | Catat untuk diagnostik dan lanjutkan. |
| [CompatibilityIssue](https://reference.aspose.com/slides/id/java/com.aspose.slides/warningtype/#CompatibilityIssue) | Hasil mungkin tidak dapat dibuka atau berperilaku dengan benar di beberapa aplikasi atau versi lama. | Log dan lanjutkan kecuali kompatibilitas bersifat wajib. |
| [UnexpectedContent](https://reference.aspose.com/slides/id/java/com.aspose.slides/warningtype/#UnexpectedContent) | Sumber berisi konten yang tidak didukung atau tidak dikenali yang efeknya belum diketahui. | Catat dan lanjutkan, atau perlakukan sebagai kesalahan dalam kebijakan ketat. |

Kategori tersebut harus menjadi dasar keputusan kebijakan. Simpan nilai yang dikembalikan oleh [getDescription](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/#getDescription--) untuk diagnostik, tetapi jangan bergantung pada teksnya untuk logika aplikasi karena teks pesan dapat bervariasi antar skenario peringatan dan versi produk.

## **Kumpulkan dan Klasifikasikan Peringatan**

Contoh berikut menggunakan satu laporan tingkat aplikasi untuk seluruh pipeline pemrosesan. Sebuah instance callback terpisah memberi label pada peringatan dari pemuatan, rendering, konversi PDF, dan penyimpanan PPTX. Kebijakan menghentikan operasi pada korupsi sumber atau kehilangan data, optional menghentikan pada kehilangan format besar, dan melanjutkan untuk peringatan lainnya.

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
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
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
                image.save("slide-1.png", ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
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

Berikan `false` untuk `abortOnMajorFormattingLoss` saat membangun `WarningPolicy` bila perbedaan format besar dapat diterima. Masalah kompatibilitas, kehilangan format kecil, dan konten tak terduga tetap disimpan dalam laporan bahkan ketika operasi berlanjut. Perluas `WarningPolicy.getAction` jika aplikasi harus menolak salah satu kategori tersebut.

## **Skenario Peringatan Umum**

Peringatan dapat muncul pada tahap yang berbeda dalam alur kerja:

- **Tanda tangan digital:** Presentasi yang ditandatangani dapat menghasilkan peringatan saat dimuat bahwa tanda tangannya akan hilang selama pemrosesan. Aspose.Slides melaporkan kondisi `DataLoss` ini melalui [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationsignedwarninginfo/). Callback pada tahap load memungkinkan aplikasi menolak file atau secara eksplisit menerima kehilangan yang dilaporkan.
- **Substitusi font:** Font yang tidak tersedia dapat diganti saat slide dirender atau diekspor. Peringatan substitusi font dilaporkan sebagai `DataLoss`, sehingga kebijakan ketat di atas menghentikan operasi meskipun aplikasi menganggap penggantian tertentu dapat diterima secara visual. Untuk mengamati perilaku ini, gunakan presentasi masukan yang berisi teks dengan font yang tidak tersedia pada runtime. Deskripsi peringatan mengidentifikasi substitusi; konfigurasikan font yang diperlukan atau [aturan substitusi font](/slides/id/java/font-substitution/) sebelum mencoba lagi.
- **Konten yang tidak didukung atau tak terduga:** Loader dapat menemukan catatan presentasi atau fitur yang tidak dikenalnya. Peringatan semacam itu mungkin menggunakan `UnexpectedContent`, atau kategori yang lebih berat bila data atau format diketahui terpengaruh.
- **Kompatibilitas format:** Menyimpan ke format presentasi lain dapat menghilangkan fitur atau menghasilkan hasil yang berperilaku berbeda di beberapa aplikasi. Misalnya, menyimpan presentasi dengan lebih dari delapan panduan gambar horizontal atau vertikal ke PPT lama melaporkan `CompatibilityIssue`. Callback pada tahap save dapat mencatat kehilangan tersebut dan melanjutkan, atau menolaknya bila semua panduan harus dipertahankan.
- **Perilaku pemuatan:** Opsi pemuatan dan perilaku warisan dapat menghasilkan peringatan. Contohnya, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) mengidentifikasi penggunaan perilaku kunci presentasi usang sebagai `CompatibilityIssue`.

Peringatan bergantung pada dokumen sumber, format target, operasi, dan versi Aspose.Slides. Jangan mengasumsikan setiap berkas menghasilkan peringatan atau bahwa sebuah skenario selalu masuk ke satu kategori saja.

## **Menangani Operasi yang Dibatalkan dengan Aman**

Ketika callback mengembalikan `ReturnAction.Abort`, jangan gunakan objek yang gagal dimuat dan jangan menganggap output rendering atau penyimpanan selesai. Operasi dapat berakhir setelah membuat berkas output tetapi sebelum selesai sepenuhnya.

Simpan hasil yang telah divalidasi ke jalur terpisah, misalnya `validated-output.pptx`. Gantikan presentasi yang ada hanya setelah operasi selesai dengan sukses, laporan peringatan memenuhi kebijakan aplikasi, dan output dapat dibuka serta diperiksa. Ini mencegah penimpaan berkas sumber yang valid dengan hasil parsial atau ditolak.

Laporan peringatan kosong bukan jaminan bahwa setiap fitur sumber telah dipertahankan. Terapkan pemeriksaan konten dan visual tambahan yang diperlukan aplikasi. Lihat juga [Open Presentations](/slides/id/java/open-presentation/) dan [Save Presentations](/slides/id/java/save-presentation/).

## **FAQ**

**Apakah callback peringatan dapat menangani setiap kesalahan Aspose.Slides?**

Tidak. Callback hanya menangani kondisi yang dapat dipulihkan dan dilaporkan sebagai peringatan. Pengecualian yang terjadi secara terpisah dari callback harus ditangani oleh aplikasi di sekitar pemanggilan load, render, konversi, atau save.

**Apakah mengembalikan `ReturnAction.Continue` menjamin output yang identik?**

Tidak. Itu hanya mengizinkan proses berlanjut. Kondisi yang dilaporkan masih dapat menyebabkan perbedaan data, format, atau kompatibilitas, sehingga perlu meninjau jenis dan deskripsi peringatan yang terkumpul.

**Bagaimana aplikasi mengidentifikasi operasi yang menghasilkan peringatan?**

Buat instance callback untuk setiap operasi dan simpan tahap yang didefinisikan aplikasi bersama nilai yang dikembalikan oleh [getWarningType](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/#getWarningType--) dan [getDescription](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarninginfo/#getDescription--), seperti yang ditunjukkan pada contoh.