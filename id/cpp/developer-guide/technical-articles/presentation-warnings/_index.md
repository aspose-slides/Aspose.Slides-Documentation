---
title: Menangani Peringatan Presentasi di C++
type: docs
weight: 70
url: /id/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- C++
- Aspose.Slides
description: "Pelajari cara mengumpulkan, mengklasifikasikan, dan menanggapi peringatan saat memuat, merender, mengonversi, dan menyimpan presentasi dengan Aspose.Slides untuk C++."
---
## **Ikhtisar**

Aspose.Slides dapat melaporkan masalah yang dapat dipulihkan saat memuat, merender, mengonversi, atau menyimpan presentasi. Contohnya termasuk catatan sumber yang rusak, konten yang tidak dapat dipertahankan, substitusi font, dan keterbatasan format target. Callback peringatan memungkinkan aplikasi mencatat kondisi ini dan memutuskan apakah operasi saat ini dapat dilanjutkan.

Implementasikan antarmuka [IWarningCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides.warnings/iwarningcallback/) dan periksa metode [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/id/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) serta [IWarningInfo::get_Description](https://reference.aspose.com/slides/id/cpp/aspose.slides.warnings/iwarninginfo/get_description/) yang disediakan melalui [IWarningInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides.warnings/iwarninginfo/). Kembalikan [ReturnAction::Continue](https://reference.aspose.com/slides/id/cpp/aspose.slides.warnings/returnaction/) untuk menerima peringatan atau `ReturnAction::Abort` untuk menghentikan operasi.

Gunakan [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_warningcallback/) untuk peringatan yang muncul saat membuka presentasi. Kelas opsi rendering dan ekspor mewarisi [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveoptions/set_warningcallback/), yang menerima peringatan dari rendering slide, konversi, dan penyimpanan. Karena peringatan itu sendiri tidak mengidentifikasi operasi aplikasi, kaitkan setiap instance callback dengan tahap operasi ketika Anda membangun laporan gabungan.

## **Peringatan dan Pengecualian**

Peringatan menggambarkan kondisi yang dapat dipulihkan Aspose.Slides jika callback mengembalikan `ReturnAction::Continue`. Pengecualian berarti operasi yang diminta tidak dapat selesai secara normal; pengecualian tidak diubah menjadi peringatan dan tidak dapat ditangani oleh kebijakan peringatan.

Mengembalikan `ReturnAction::Abort` meminta dispatcher peringatan untuk menghentikan operasi saat ini dengan mengeluarkan pengecualian. Pengecualian publik tergantung pada operasi dan format presentasi. Misalnya, proses pemuatan dapat menghasilkan [PptxReadException](https://reference.aspose.com/slides/id/cpp/aspose.slides/pptxreadexception/) atau [PptReadException](https://reference.aspose.com/slides/id/cpp/aspose.slides/pptreadexception/), sementara penyimpanan atau ekspor dapat menghasilkan [PptxException](https://reference.aspose.com/slides/id/cpp/aspose.slides/pptxexception/). Tangani pengecualian pada batas operasi dan gunakan laporan peringatan untuk menentukan apakah kebijakan aplikasi yang menyebabkan penghentian, bukan hanya mengandalkan satu subtipe pengecualian atau pesan. Callback mencatat peringatan sebelum mengembalikan `ReturnAction::Abort`, memastikan alasan tetap tersedia bagi aplikasi.

## **Kategori Peringatan**

Entitas enumerasi [WarningType](https://reference.aspose.com/slides/id/cpp/aspose.slides.warnings/warningtype/) menyediakan kategori berikut:

| Tipe peringatan | Arti | Kebijakan tipikal |
| --- | --- | --- |
| `SourceFileCorruption` | Presentasi sumber berisi korupsi yang dapat membuat dokumen yang disimpan dalam format aslinya tidak dapat digunakan. | Abort. |
| `DataLoss` | Teks, diagram, gambar, atau data lain mungkin tidak ada setelah pemuatan atau penyimpanan. | Abort. |
| `MajorFormattingLoss` | Presentasi dapat kehilangan format penting. | Abort dalam mode validasi ketat; jika tidak, catat dan lanjutkan. |
| `MinorFormattingLoss` | Perbedaan format terbatas dapat terjadi. | Catat untuk diagnostik dan lanjutkan. |
| `CompatibilityIssue` | Hasil mungkin tidak dapat dibuka atau berperilaku dengan benar di beberapa aplikasi atau versi lama. | Log dan lanjutkan kecuali kompatibilitas wajib. |
| `UnexpectedContent` | Sumber berisi konten yang tidak didukung atau tidak dikenali yang efeknya belum diketahui. | Catat dan lanjutkan, atau perlakukan sebagai kesalahan dalam kebijakan ketat. |

Kategori harus menjadi dasar keputusan kebijakan. Simpan deskripsi peringatan untuk diagnostik, tetapi jangan bergantung pada teksnya untuk logika aplikasi karena teks pesan dapat bervariasi antara skenario peringatan dan versi produk.

## **Kumpulkan dan Klasifikasikan Peringatan**

Contoh berikut menggunakan satu laporan tingkat aplikasi untuk seluruh pipeline pemrosesan. Instance callback terpisah menandai peringatan dari pemuatan, rendering, konversi PDF, dan penyimpanan PPTX. Kebijakan menghentikan pada korupsi sumber atau kehilangan data, secara opsional menghentikan pada kehilangan format utama, dan melanjutkan untuk peringatan lainnya.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

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
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

Setel `abortOnMajorFormattingLoss` ke `false` ketika perbedaan format utama dapat diterima. Masalah kompatibilitas, kehilangan format minor, dan konten tak terduga tetap disimpan dalam laporan meskipun operasi dilanjutkan. Perluas `WarningPolicy::GetAction` jika aplikasi harus menolak salah satu kategori tersebut.

## **Skenario Peringatan Umum**

Peringatan dapat muncul pada tahap alur kerja yang berbeda:

- **Tanda tangan digital:** Presentasi yang ditandatangani dapat menghasilkan peringatan saat dimuat bahwa tanda tangannya akan hilang selama pemrosesan. Aspose.Slides melaporkan kondisi `DataLoss` ini melalui [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). Callback pada tahap pemuatan memungkinkan aplikasi menolak berkas atau secara eksplisit menerima kehilangan yang dilaporkan.
- **Substitusi font:** Font yang tidak tersedia dapat diganti saat slide dirender atau diekspor. Peringatan substitusi font dilaporkan sebagai `DataLoss`, sehingga kebijakan ketat di atas menghentikan bahkan jika aplikasi menganggap penggantian tertentu dapat diterima secara visual. Untuk mengamati perilaku ini, gunakan presentasi masukan yang berisi teks dengan font yang tidak tersedia pada runtime. Deskripsi peringatan mengidentifikasi substitusi; konfigurasikan font yang diperlukan atau [aturan substitusi font](/slides/id/cpp/font-substitution/) sebelum mencoba lagi.
- **Konten yang tidak didukung atau tidak terduga:** Loader dapat menemukan catatan presentasi atau fitur yang tidak dikenalnya. Peringatan semacam itu mungkin menggunakan `UnexpectedContent`, atau kategori lebih serius bila data atau format diketahui terpengaruh.
- **Kompatibilitas format:** Menyimpan ke format presentasi lain dapat menghilangkan fitur atau menghasilkan hasil yang berperilaku berbeda di beberapa aplikasi. Misalnya, menyimpan presentasi dengan lebih dari delapan panduan gambar horizontal atau vertikal ke PPT lama melaporkan `CompatibilityIssue`. Callback pada tahap penyimpanan dapat mencatat kehilangan dan melanjutkan, atau menolaknya jika semua panduan harus dipertahankan.
- **Perilaku pemuatan:** Opsi pemuatan dan perilaku legacy juga dapat menghasilkan peringatan. Contohnya, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) mengidentifikasi penggunaan perilaku penguncian presentasi usang sebagai `CompatibilityIssue`.

Peringatan bergantung pada dokumen sumber, format target, operasi, dan versi Aspose.Slides. Jangan mengasumsikan setiap berkas menghasilkan peringatan atau bahwa satu skenario selalu masuk ke satu kategori saja.

## **Menangani Operasi yang Dihentikan dengan Aman**

Ketika callback mengembalikan `ReturnAction::Abort`, jangan gunakan objek yang gagal dimuat dan jangan menganggap output rendering atau penyimpanan selesai. Operasi dapat berakhir setelah membuat berkas output tetapi sebelum selesai sepenuhnya.

Simpan hasil yang telah divalidasi ke jalur terpisah seperti `validated-output.pptx`. Ganti presentasi yang ada hanya setelah operasi selesai dengan sukses, laporan peringatan memenuhi kebijakan aplikasi, dan output dapat dibuka serta diperiksa. Ini menghindari penimpaan berkas sumber yang valid dengan hasil parsial atau ditolak.

Laporan peringatan kosong bukan jaminan bahwa setiap fitur sumber telah dipertahankan. Terapkan pemeriksaan konten dan visual tambahan yang diperlukan oleh aplikasi. Lihat juga [Buka Presentasi](/slides/id/cpp/open-presentation/) dan [Simpan Presentasi](/slides/id/cpp/save-presentation/).

## **FAQ**

**Apakah callback peringatan dapat menangani setiap kesalahan Aspose.Slides?**

Tidak. Callback menangani kondisi yang dapat dipulihkan dan dilaporkan sebagai peringatan. Pengecualian yang terjadi terlepas dari callback harus ditangani oleh aplikasi di sekitar pemanggilan pemuatan, rendering, konversi, atau penyimpanan.

**Apakah mengembalikan `ReturnAction::Continue` menjamin output yang identik?**

Tidak. Itu hanya memungkinkan pemrosesan berlanjut. Kondisi yang dilaporkan masih dapat menyebabkan perbedaan data, format, atau kompatibilitas, jadi tinjau tipe peringatan dan deskripsinya yang terkumpul.

**Bagaimana aplikasi mengidentifikasi operasi yang menghasilkan peringatan?**

Buat instance callback untuk setiap operasi dan simpan tahap yang ditentukan aplikasi bersama tipe peringatan serta deskripsinya, seperti yang ditunjukkan dalam contoh.