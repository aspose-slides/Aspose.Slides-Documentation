---
title: Menangani Peringatan Presentasi di .NET
type: docs
weight: 120
url: /id/net/presentation-warnings/
aliases:
- /net/mendapatkan-callback-peringatan-untuk-substitusi-font-di-aspose-slides/
keywords:
- callback peringatan
- kebijakan peringatan
- kehilangan data
- korupsi sumber
- masalah kompatibilitas
- substitusi font
- tanda tangan digital
- pemuatan presentasi
- perenderan presentasi
- konversi presentasi
- penyimpanan presentasi
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengumpulkan, mengklasifikasikan, dan menangani peringatan saat memuat, merender, mengonversi, dan menyimpan presentasi dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Aspose.Slides dapat melaporkan masalah yang dapat dipulihkan saat memuat, merender, mengonversi, atau menyimpan presentasi. Contohnya termasuk catatan sumber yang rusak, konten yang tidak dapat dipertahankan, substitusi font, dan batasan format target. Callback peringatan memungkinkan aplikasi mencatat kondisi ini dan memutuskan apakah operasi saat ini dapat dilanjutkan.

Implementasikan antarmuka [IWarningCallback](https://reference.aspose.com/slides/id/net/aspose.slides.warnings/iwarningcallback/) dan periksa properti [WarningType](https://reference.aspose.com/slides/id/net/aspose.slides.warnings/iwarninginfo/warningtype/) serta [Description](https://reference.aspose.com/slides/id/net/aspose.slides.warnings/iwarninginfo/description/) yang disediakan melalui [IWarningInfo](https://reference.aspose.com/slides/id/net/aspose.slides.warnings/iwarninginfo/). Kembalikan [ReturnAction.Continue](https://reference.aspose.com/slides/id/net/aspose.slides.warnings/returnaction/) untuk menerima peringatan atau `ReturnAction.Abort` untuk menghentikan operasi.

Gunakan [LoadOptions.WarningCallback](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/warningcallback/) untuk peringatan yang muncul saat membuka presentasi. Kelas opsi rendering dan ekspor mewarisi [SaveOptions.WarningCallback](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveoptions/warningcallback/), yang menerima peringatan dari perenderan slide, konversi, dan penyimpanan. Karena peringatan itu sendiri tidak mengidentifikasi operasi aplikasi, hubungkan setiap instance callback dengan tahap operasi ketika Anda membangun laporan gabungan.

## **Peringatan dan Pengecualian**

Sebuah peringatan menggambarkan kondisi yang dapat dipulihkan Aspose.Slides jika callback mengembalikan `ReturnAction.Continue`. Sebuah pengecualian berarti operasi yang diminta tidak dapat diselesaikan secara normal; pengecualian tidak diubah menjadi peringatan dan tidak dapat ditangani oleh kebijakan peringatan.

Mengembalikan `ReturnAction.Abort` meminta dispatcher peringatan untuk menghentikan operasi saat ini dengan memunculkan pengecualian. Pengecualian publik tergantung pada operasi dan format presentasi. Misalnya, pemuatan dapat menimbulkan [PptxReadException](https://reference.aspose.com/slides/id/net/aspose.slides/pptxreadexception/) atau [PptReadException](https://reference.aspose.com/slides/id/net/aspose.slides/pptreadexception/), sementara penyimpanan atau ekspor dapat menimbulkan [PptxException](https://reference.aspose.com/slides/id/net/aspose.slides/pptxexception/). Tangani pengecualian pada batas operasi dan gunakan laporan peringatan untuk menentukan apakah kebijakan aplikasi yang menyebabkan penghentian alih-alih mengandalkan satu subtipe pengecualian atau pesan. Callback mencatat peringatan sebelum mengembalikan `ReturnAction.Abort`, memastikan alasan tetap tersedia bagi aplikasi.

## **Kategori Peringatan**

Enumerasi [WarningType](https://reference.aspose.com/slides/id/net/aspose.slides.warnings/warningtype/) menyediakan kategori berikut:

| Jenis peringatan | Makna | Kebijakan umum |
| --- | --- | --- |
| `SourceFileCorruption` | Presentasi sumber berisi kerusakan yang dapat membuat dokumen yang disimpan dalam format aslinya tidak dapat digunakan. | Hentikan. |
| `DataLoss` | Teks, diagram, gambar, atau data lain mungkin tidak ada setelah pemuatan atau penyimpanan. | Hentikan. |
| `MajorFormattingLoss` | Presentasi mungkin kehilangan format penting. | Hentikan dalam mode validasi ketat; jika tidak, catat dan lanjutkan. |
| `MinorFormattingLoss` | Perbedaan format terbatas mungkin terjadi. | Catat untuk diagnostik dan lanjutkan. |
| `CompatibilityIssue` | Hasil mungkin tidak dapat dibuka atau berperilaku tidak benar pada beberapa aplikasi atau versi lama. | Catat dan lanjutkan kecuali kompatibilitas wajib. |
| `UnexpectedContent` | Sumber mengandung konten yang tidak didukung atau tidak dikenali yang efeknya belum diketahui. | Catat dan lanjutkan, atau perlakukan sebagai kesalahan dalam kebijakan ketat. |

Kategori harus menjadi dasar keputusan kebijakan. Simpan `Description` untuk diagnostik, tetapi jangan bergantung pada isinya untuk logika aplikasi karena teks pesan dapat bervariasi antara skenario peringatan dan versi produk.

## **Kumpulkan dan Klasifikasikan Peringatan**

Contoh berikut menggunakan satu laporan tingkat aplikasi untuk seluruh pipeline pemrosesan. Sebuah instance callback terpisah menandai peringatan dari pemuatan, perenderan, konversi PDF, dan penyimpanan PPTX. Kebijakan menghentikan pada korupsi sumber atau kehilangan data, opsional menghentikan pada kehilangan format mayor, dan melanjutkan untuk peringatan lain.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

Atur `abortOnMajorFormattingLoss` ke `false` ketika perbedaan format mayor dapat diterima. Masalah kompatibilitas, kehilangan format minor, dan konten tak terduga tetap dipertahankan dalam laporan meskipun operasi berlanjut. Perluas `WarningPolicy.GetAction` jika aplikasi harus menolak salah satu kategori tersebut.

## **Skenario Peringatan Umum**

Peringatan dapat muncul pada tahap alur kerja yang berbeda:

- **Tanda tangan digital:** Sebuah presentasi yang ditandatangani dapat menghasilkan peringatan saat dimuat bahwa tandatangannya akan hilang selama pemrosesan. Aspose.Slides melaporkan kondisi `DataLoss` ini melalui [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/id/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). Callback pada tahap pemuatan memungkinkan aplikasi menolak file atau secara eksplisit menerima kehilangan yang dilaporkan.
- **Substitusi font:** Font yang tidak tersedia dapat diganti saat slide dirender atau diekspor. Peringatan substitusi font dilaporkan sebagai `DataLoss`, sehingga kebijakan ketat di atas menghentikan bahkan jika aplikasi menganggap penggantian tertentu secara visual dapat diterima. Untuk mengamati perilaku ini, gunakan presentasi masukan yang berisi teks dengan font yang tidak tersedia pada runtime. Deskripsi peringatan mengidentifikasi substitusi; konfigurasikan font yang diperlukan atau [aturan substitusi font](/slides/id/net/font-substitution/) sebelum mencoba lagi.
- **Konten yang tidak didukung atau tidak terduga:** Loader dapat menemukan catatan atau fitur presentasi yang tidak dikenalnya. Peringatan semacam itu dapat menggunakan `UnexpectedContent`, atau kategori yang lebih parah ketika data atau format diketahui terpengaruh.
- **Kompatibilitas format:** Menyimpan ke format presentasi lain dapat menghilangkan fitur atau menghasilkan hasil yang berperilaku berbeda pada beberapa aplikasi. Misalnya, menyimpan presentasi dengan lebih dari delapan panduan gambar horizontal atau vertikal ke PPT lama melaporkan `CompatibilityIssue`. Callback pada tahap penyimpanan dapat mencatat kehilangan dan melanjutkan, atau menolaknya jika semua panduan harus dipertahankan.
- **Perilaku pemuatan:** Opsi pemuatan dan perilaku lama juga dapat menghasilkan peringatan. Misalnya, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/id/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) mengidentifikasi penggunaan perilaku kunci presentasi usang sebagai `CompatibilityIssue`.

Peringatan bergantung pada dokumen sumber, format target, operasi, dan versi Aspose.Slides. Jangan mengasumsikan bahwa setiap file menghasilkan peringatan atau bahwa sebuah skenario selalu berhubungan dengan satu kategori saja.

## **Menangani Operasi yang Dibatalkan dengan Aman**

Ketika sebuah callback mengembalikan `ReturnAction.Abort`, jangan gunakan objek yang gagal dimuat dan jangan menganggap bahwa output perenderan atau penyimpanan sudah lengkap. Operasi dapat berakhir setelah membuat berkas output tetapi sebelum menyelesaikannya.

Simpan hasil yang telah divalidasi ke jalur terpisah seperti `validated-output.pptx`. Ganti presentasi yang ada hanya setelah operasi selesai dengan sukses, laporan peringatan memenuhi kebijakan aplikasi, dan output dapat dibuka serta diperiksa. Ini menghindari penimpaan berkas sumber yang valid dengan hasil parsial atau ditolak.

Laporan peringatan kosong bukan jaminan bahwa setiap fitur sumber telah dipertahankan. Terapkan pemeriksaan konten dan visual tambahan yang diperlukan oleh aplikasi. Lihat juga [Open Presentations](/slides/id/net/open-presentation/) dan [Save Presentations](/slides/id/net/save-presentation/).

## **FAQ**

**Apakah callback peringatan dapat menangani setiap kesalahan Aspose.Slides?**

Tidak. Ia menangani kondisi yang dapat dipulihkan yang dilaporkan sebagai peringatan. Pengecualian yang terjadi secara terpisah dari callback harus ditangani oleh aplikasi di sekitar pemanggilan pemuatan, perenderan, konversi, atau penyimpanan.

**Apakah mengembalikan `ReturnAction.Continue` menjamin output yang identik?**

Tidak. Itu hanya memperbolehkan pemrosesan berlanjut. Kondisi yang dilaporkan masih dapat menyebabkan perbedaan data, format, atau kompatibilitas, jadi tinjau jenis dan deskripsi peringatan yang dikumpulkan.

**Bagaimana aplikasi dapat mengidentifikasi operasi yang menghasilkan peringatan?**

Buat instance callback untuk setiap operasi dan simpan tahap yang didefinisikan aplikasi bersama `WarningType` dan `Description`, seperti yang ditunjukkan pada contoh.