---
title: Menangani Peringatan Presentasi dalam Python melalui Java
type: docs
weight: 90
url: /id/python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Python
- Java
- Aspose.Slides
description: "Pelajari cara mengumpulkan, mengklasifikasikan, dan menangani peringatan saat memuat, merender, mengonversi, dan menyimpan presentasi dengan Aspose.Slides untuk Python melalui Java."
---
## **Gambaran Umum**

Aspose.Slides dapat melaporkan masalah yang dapat dipulihkan saat memuat, merender, mengonversi, atau menyimpan presentasi. Contohnya termasuk rekaman sumber yang rusak, konten yang tidak dapat dipertahankan, substitusi font, dan keterbatasan format target. Callback peringatan memungkinkan aplikasi mencatat kondisi ini dan memutuskan apakah operasi saat ini dapat dilanjutkan.

Implementasikan antarmuka `IWarningCallback` melalui `jpype.JProxy` dan periksa nilai `getWarningType` serta `getDescription` yang disediakan melalui `IWarningInfo`. Kembalikan [ReturnAction.Continue](https://reference.aspose.com/slides/id/python-java/aspose.slides/returnaction/#Continue) untuk menerima peringatan atau [ReturnAction.Abort](https://reference.aspose.com/slides/id/python-java/aspose.slides/returnaction/#Abort) untuk menghentikan operasi.

Gunakan [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setWarningCallback) untuk peringatan yang muncul saat membuka presentasi. Kelas opsi rendering dan ekspor mewarisi [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveoptions/#setWarningCallback), yang menerima peringatan dari perenderan slide, konversi, dan penyimpanan. Karena peringatan itu sendiri tidak mengidentifikasi operasi aplikasi, kaitkan setiap instance callback dengan tahap operasi saat Anda membuat laporan gabungan.

## **Peringatan dan Pengecualian**

Sebuah peringatan menjelaskan kondisi yang dapat dipulihkan oleh Aspose.Slides jika callback mengembalikan `ReturnAction.Continue`. Sebuah pengecualian berarti operasi yang diminta tidak dapat selesai secara normal; pengecualian tidak diubah menjadi peringatan dan tidak dapat ditangani oleh kebijakan peringatan.

Mengembalikan `ReturnAction.Abort` meminta dispatcher peringatan untuk menghentikan operasi saat ini dengan melempar pengecualian. Pengecualian publik tergantung pada operasi dan format presentasi. Misalnya, pemuatan dapat menghasilkan [PptxReadException](https://reference.aspose.com/slides/id/python-java/aspose.slides/pptxreadexception/) atau [PptReadException](https://reference.aspose.com/slides/id/python-java/aspose.slides/pptreadexception/), sementara penyimpanan atau ekspor dapat menghasilkan [PptxException](https://reference.aspose.com/slides/id/python-java/aspose.slides/pptxexception/). Tangani pengecualian di batas operasi dan gunakan laporan peringatan untuk menentukan apakah kebijakan aplikasi yang menyebabkan penghentian, bukan bergantung pada satu subtipe pengecualian atau pesan. Callback mencatat peringatan sebelum mengembalikan `ReturnAction.Abort`, memastikan alasan tetap tersedia bagi aplikasi.

## **Kategori Peringatan**

Kelas [WarningType](https://reference.aspose.com/slides/id/python-java/aspose.slides/warningtype/) menyediakan konstanta integer untuk kategori berikut:

| Jenis Peringatan | Arti | Kebijakan Umum |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/id/python-java/aspose.slides/warningtype/#SourceFileCorruption) | Presentasi sumber mengandung kerusakan yang dapat membuat dokumen yang disimpan dalam format aslinya tidak dapat digunakan. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/id/python-java/aspose.slides/warningtype/#DataLoss) | Teks, diagram, gambar, atau data lain mungkin tidak ada setelah memuat atau menyimpan. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/id/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | Presentasi dapat kehilangan format penting. | Abort dalam mode validasi ketat; bila tidak, catat dan lanjutkan. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/id/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | Perbedaan format terbatas mungkin terjadi. | Catat untuk diagnostik dan lanjutkan. |
| [CompatibilityIssue](https://reference.aspose.com/slides/id/python-java/aspose.slides/warningtype/#CompatibilityIssue) | Hasil mungkin tidak dapat dibuka atau berperilaku tidak benar di beberapa aplikasi atau versi lama. | Log dan lanjutkan kecuali kompatibilitas wajib. |
| [UnexpectedContent](https://reference.aspose.com/slides/id/python-java/aspose.slides/warningtype/#UnexpectedContent) | Sumber berisi konten yang tidak didukung atau tidak dikenali yang efeknya belum diketahui. | Catat dan lanjutkan, atau perlakukan sebagai kesalahan dalam kebijakan ketat. |

Kategori harus menjadi dasar keputusan kebijakan. Simpan nilai yang dikembalikan oleh `getDescription` untuk diagnostik, tetapi jangan bergantung pada bunyiannya dalam logika aplikasi karena teks pesan dapat berbeda antara skenario peringatan dan versi produk.

## **Kumpulkan dan Klasifikasikan Peringatan**

Contoh berikut menggunakan satu laporan tingkat aplikasi untuk seluruh alur pemrosesan. Instance callback terpisah menandai peringatan dari pemuatan, perenderan, konversi PDF, dan penyimpanan PPTX. Kebijakan membatalkan operasi pada korupsi sumber atau kehilangan data, opsional membatalkan pada kehilangan format utama, dan melanjutkan untuk peringatan lainnya.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

Berikan `False` untuk `abort_on_major_formatting_loss` saat membuat `WarningPolicy` bila perbedaan format utama dapat diterima. Masalah kompatibilitas, kehilangan format minor, dan konten tak terduga tetap disimpan dalam laporan meskipun operasi dilanjutkan. Perluas `WarningPolicy.get_action` jika aplikasi harus menolak salah satu kategori tersebut.

## **Skenario Peringatan Umum**

Peringatan dapat muncul pada tahap yang berbeda dalam alur kerja:

- **Tanda tangan digital:** Presentasi yang ditandatangani dapat menghasilkan peringatan saat dimuat bahwa tanda tangannya akan hilang selama pemrosesan. Aspose.Slides melaporkan kondisi `DataLoss` ini melalui `IPresentationSignedWarningInfo`. Callback pada tahap muat memungkinkan aplikasi menolak berkas atau secara eksplisit menerima kehilangan yang dilaporkan.
- **Substitusi font:** Font yang tidak tersedia dapat diganti saat slide dirender atau diekspor. Peringatan substitusi font dilaporkan sebagai `DataLoss`, sehingga kebijakan ketat di atas membatalkan meskipun aplikasi mungkin menganggap penggantian tertentu dapat diterima secara visual. Untuk mengamati perilaku ini, gunakan presentasi masukan yang berisi teks dengan font yang tidak tersedia pada runtime. Deskripsi peringatan mengidentifikasi substitusi; konfigurasikan font yang diperlukan atau [font substitution rules](/slides/id/python-java/font-substitution/) sebelum mencoba lagi.
- **Konten yang tidak didukung atau tak terduga:** Loader dapat menemukan rekaman atau fitur presentasi yang tidak dikenalnya. Peringatan semacam itu mungkin menggunakan `UnexpectedContent`, atau kategori yang lebih berat bila data atau format diketahui terpengaruh.
- **Kompatibilitas format:** Menyimpan ke format presentasi lain dapat menghilangkan fitur atau menghasilkan hasil yang berperilaku berbeda di beberapa aplikasi. Misalnya, menyimpan presentasi dengan lebih dari delapan panduan gambar horizontal atau vertikal ke PPT lama melaporkan `CompatibilityIssue`. Callback pada tahap simpan dapat mencatat kehilangan itu dan melanjutkan, atau menolaknya bila semua panduan harus dipertahankan.
- **Perilaku pemuatan:** Opsi pemuatan dan perilaku lama juga dapat menghasilkan peringatan. Misalnya, `IObsoletePresLockingBehaviorWarningInfo` mengidentifikasi penggunaan perilaku penguncian presentasi usang sebagai `CompatibilityIssue`.

Peringatan bergantung pada dokumen sumber, format target, operasi, dan versi Aspose.Slides. Jangan mengasumsikan setiap berkas menghasilkan peringatan atau bahwa sebuah skenario selalu masuk ke satu kategori saja.

## **Menangani Operasi yang Dibatalkan dengan Aman**

Ketika callback mengembalikan `ReturnAction.Abort`, jangan gunakan objek yang gagal dimuat dan jangan menganggap bahwa output perenderan atau penyimpanan sudah selesai. Operasi dapat berakhir setelah membuat berkas output tetapi sebelum selesai sepenuhnya.

Simpan hasil yang telah divalidasi ke jalur terpisah seperti `validated-output.pptx`. Ganti presentasi yang ada hanya setelah operasi selesai berhasil, laporan peringatan memenuhi kebijakan aplikasi, dan output dapat dibuka serta diperiksa. Ini mencegah penimpaan berkas sumber yang valid dengan hasil parsial atau ditolak.

Laporan peringatan kosong bukan jaminan bahwa setiap fitur sumber telah dipertahankan. Terapkan pemeriksaan konten dan visual tambahan yang diperlukan oleh aplikasi. Lihat juga [Open Presentations](/slides/id/python-java/open-presentation/) dan [Save Presentations](/slides/id/python-java/save-presentation/).

## **FAQ**

**Apakah callback peringatan dapat menangani setiap kesalahan Aspose.Slides?**

Tidak. Callback menangani kondisi yang dapat dipulihkan dan dilaporkan sebagai peringatan. Pengecualian yang terjadi secara terpisah dari callback harus ditangani oleh aplikasi di sekitar panggilan memuat, merender, mengonversi, atau menyimpan.

**Apakah mengembalikan `ReturnAction.Continue` menjamin output identik?**

Tidak. Itu hanya mengizinkan pemrosesan berlanjut. Kondisi yang dilaporkan tetap dapat menyebabkan perbedaan data, format, atau kompatibilitas, jadi tinjau jenis dan deskripsi peringatan yang terkumpul.

**Bagaimana aplikasi dapat mengidentifikasi operasi yang menghasilkan peringatan?**

Buat instance callback untuk setiap operasi dan simpan tahap yang didefinisikan aplikasi bersama nilai yang dikembalikan oleh `getWarningType` dan `getDescription`, seperti yang ditunjukkan dalam contoh.