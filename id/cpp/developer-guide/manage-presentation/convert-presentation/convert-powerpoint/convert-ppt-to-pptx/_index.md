---
title: "Konversi PPT ke PPTX dalam C++"
linktitle: "PPT ke PPTX"
type: docs
weight: 20
url: /id/cpp/convert-ppt-to-pptx/
keywords:
- "konversi PowerPoint"
- "konversi presentasi"
- "konversi slide"
- "konversi PPT"
- "PPT ke PPTX"
- "simpan PPT sebagai PPTX"
- "ekspor PPT ke PPTX"
- "PowerPoint"
- "presentasi"
- "C++"
- "Aspose.Slides"
description: "Konversi file PPT lama ke PPTX dalam C++ dengan Aspose.Slides. Menyertakan contoh C++ untuk konversi satu file dan batch, penanganan kesalahan, serta catatan kesetiaan."
---
## **Gambaran Umum**

PPT adalah format PowerPoint biner warisan, sementara PPTX adalah format Open XML yang lebih baru. Aspose.Slides untuk C++ dapat memuat file PPT dan menyimpannya sebagai PPTX tanpa Microsoft PowerPoint. Artikel ini menunjukkan cara mengonversi satu file atau sebuah direktori file dan menjelaskan apa yang harus diverifikasi setelah konversi.

## **Mengonversi File PPT ke PPTX**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/), kemudian panggil [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/) dengan [SaveFormat::Pptx](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveformat/). Hapus (dispose) presentasi ketika tidak lagi diperlukan untuk melepaskan sumber dayanya.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ekstensi file tidak memilih format output secara otomatis; argumen [SaveFormat::Pptx](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveformat/)lah yang melakukannya. Jaga agar jalur input dan output berbeda jika Anda perlu mempertahankan file PPT asli.

## **Mengonversi Beberapa File PPT**

Contoh berikut mengonversi setiap file `.ppt` dalam satu direktori. Setiap file diproses secara independen, sehingga satu konversi yang gagal tidak menghentikan batch yang lain.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

Untuk beban kerja produksi, log seluruh pengecualian, tentukan apakah file output yang ada dapat ditimpa, dan tulis nama file yang gagal ke antrean retry atau review. File yang rusak, file yang dilindungi kata sandi dibuka tanpa kata sandi yang diperlukan, jalur yang tidak dapat diakses, dan konten yang tidak didukung dapat menyebabkan konversi gagal. Lihat [Password-Protected Presentations](/cpp/password-protected-presentation/) untuk memuat file terenkripsi.

## **Kesetiaan dan Fitur Warisan**

Konversi biasanya mempertahankan slide, master, tata letak, teks, bentuk, gambar, tabel, dan diagram. Namun, PPT dan PPTX tidak mewakili setiap fitur dengan cara yang persis sama. Fitur warisan yang tidak memiliki padanan PPTX, atau tidak didukung oleh perpustakaan, mungkin dinormalisasi, diabaikan, atau ditampilkan secara berbeda.

Periksa file yang telah dikonversi ketika berisi animasi, transisi, objek OLE yang disematkan atau ditautkan, kontrol ActiveX, media yang disematkan, font yang tidak umum, atau makro VBA. File PPTX biasa bukan format yang mendukung makro, sehingga gunakan alur kerja yang mendukung makro bila VBA harus tetap tersedia. Juga pastikan font yang diperlukan dan sumber daya eksternal ada di lingkungan tempat presentasi yang dikonversi akan dibuka atau dirender.

Untuk dokumen penting, buka kembali PPTX yang dihasilkan secara programatik dan periksa jumlah slide utama serta kontennya, kemudian bandingkan tampilan dan perilaku slide-shownya di penampil yang dimaksud. Jangan menganggap pemanggilan [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/) yang berhasil sebagai bukti bahwa setiap fitur warisan memiliki representasi PPTX yang persis.

## **Kapan Menggunakan PPTX**

Gunakan PPTX ketika presentasi akan diedit di versi PowerPoint terkini, dipertukarkan dengan sistem yang bekerja dengan paket Open XML, atau disimpan dalam format yang lebih mudah diperiksa dan dipulihkan dibandingkan PPT biner warisan. Simpan PPT asli sebagai salinan arsip atau rollback sampai presentasi yang dikonversi melewati pemeriksaan kesetiaan Anda.

Jika Anda memerlukan PDF, HTML, gambar, XPS, atau jenis output lain sebagai gantinya, gunakan panduan khusus format di [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) daripada mengasumsikan bahwa semua target mempertahankan fitur PowerPoint yang dapat diedit.

## **Konverter Online**

Untuk file sesekali atau perbandingan cepat, Anda dapat menggunakan [online PPT to PPTX converter](https://products.aspose.app/slides/id/conversion/ppt-to-pptx). Untuk konversi yang dapat diulang, pemrosesan batch, atau penanganan kesalahan tingkat aplikasi, gunakan API C++.

## **Artikel Terkait**

- [Simpan Presentasi dalam C++](/cpp/save-presentation/)
- [Format File yang Didukung](/cpp/supported-file-formats/)
- [Buka Presentasi dalam C++](/cpp/open-presentation/)

## **FAQ**

**Bisakah saya mengonversi PPT ke PPTX tanpa Microsoft PowerPoint terpasang?**

Ya. Aspose.Slides untuk C++ memuat dan menyimpan file presentasi tanpa memerlukan Microsoft PowerPoint.

**Apakah konversi PPT ke PPTX akan mempertahankan semua konten secara persis?**

Ini mempertahankan konten presentasi umum, tetapi kesetiaan yang tepat tidak dijamin untuk setiap fitur warisan atau yang tidak didukung. Tinjau file yang dihasilkan ketika berisi makro, objek OLE atau ActiveX, media, animasi khusus, atau font yang tidak umum.

**Bisakah saya mengonversi file PPT yang dilindungi kata sandi?**

Ya, jika Anda menyediakan kata sandi yang benar saat memuat file. Kata sandi yang hilang atau salah menyebabkan operasi pemuatan gagal.

**Haruskah saya menghapus file PPT setelah konversi?**

Simpan file asli sampai Anda memverifikasi PPTX di penampil dan alur kerja yang penting bagi Anda. Ini memberikan salinan rollback jika fitur warisan dikonversi secara berbeda.