---
title: Mengonversi PPT ke PPTX dalam C++
linktitle: PPT ke PPTX
type: docs
weight: 20
url: /id/cpp/convert-ppt-to-pptx/
keywords:
- mengonversi PowerPoint
- mengonversi presentasi
- mengonversi slide
- mengonversi PPT
- PPT ke PPTX
- simpan PPT sebagai PPTX
- ekspor PPT ke PPTX
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Mengonversi file PPT lama ke PPTX dalam C++ dengan Aspose.Slides. Menyertakan contoh C++ untuk konversi satu file dan batch, penanganan kesalahan, serta catatan ketepatan."
---
## **Gambaran Umum**

PPT adalah format PowerPoint biner lama, sedangkan PPTX adalah format Open XML yang lebih baru. Aspose.Slides untuk C++ dapat memuat file PPT dan menyimpannya sebagai PPTX tanpa Microsoft PowerPoint. Artikel ini menunjukkan cara mengonversi satu file atau sebuah direktori file dan menjelaskan apa yang harus diverifikasi setelah konversi.

## **Mengonversi File PPT ke PPTX**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/), lalu panggil [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/) dengan argumen [SaveFormat::Pptx](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveformat/). Buang objek presentasi ketika tidak lagi diperlukan untuk melepaskan sumber dayanya.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Muat presentasi PPT lama.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Simpan presentasi dalam format PPTX.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ekstensi file tidak memilih format output secara otomatis; argumen [SaveFormat::Pptx](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveformat/) yang melakukannya. Jaga agar jalur input dan output berbeda bila Anda perlu mempertahankan file PPT asli.

## **Mengonversi Beberapa File PPT**

Contoh berikut mengonversi setiap file `.ppt` dalam satu direktori. Setiap file diproses secara independen, sehingga satu konversi yang gagal tidak menghentikan sisa batch.

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

Untuk beban kerja produksi, log seluruh pengecualian, tentukan apakah file output yang ada boleh ditimpa, dan tulis nama file yang gagal ke antrean retry atau review. File yang rusak, file yang dilindungi kata sandi dan dibuka tanpa kata sandi yang diperlukan, jalur yang tidak dapat diakses, serta konten yang tidak didukung semuanya dapat menyebabkan konversi gagal. Lihat [Password-Protected Presentations](/slides/id/cpp/password-protected-presentation/) untuk memuat file terenkripsi.

## **Ketepatan dan Fitur Warisan**

Konversi biasanya mempertahankan slide, master, tata letak, teks, bentuk, gambar, tabel, dan diagram. Namun, PPT dan PPTX tidak mewakili setiap fitur dengan cara yang persis sama. Fitur warisan yang tidak memiliki padanan PPTX, atau tidak didukung oleh perpustakaan, dapat dinormalisasi, dihilangkan, atau ditampilkan secara berbeda.

Periksa file yang telah dikonversi bila mengandung animasi, transisi, objek OLE tersemat atau tertaut, kontrol ActiveX, media tersemat, font yang tidak umum, atau makro VBA. File PPTX biasa bukan format yang mendukung makro, jadi gunakan alur kerja yang mendukung makro bila VBA harus tetap tersedia. Juga verifikasi bahwa font yang diperlukan dan sumber daya eksternal ada di lingkungan tempat presentasi yang dikonversi akan dibuka atau dirender.

Untuk dokumen penting, buka kembali PPTX yang dihasilkan secara programatis dan periksa jumlah slide serta kontennya, lalu bandingkan tampilan dan perilaku slide‑show di penampil yang dituju. Jangan menganggap panggilan [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/) yang berhasil sebagai bukti bahwa setiap fitur warisan memiliki representasi PPTX yang tepat.

## **Kapan Menggunakan PPTX**

Gunakan PPTX ketika presentasi akan diedit di versi PowerPoint terkini, dipertukarkan dengan sistem yang bekerja dengan paket Open XML, atau disimpan dalam format yang lebih mudah diperiksa dan dipulihkan dibandingkan PPT biner lama. Simpan PPT asli sebagai salinan arsip atau rollback hingga presentasi yang dikonversi melewati pemeriksaan ketepatan Anda.

Jika Anda memerlukan PDF, HTML, gambar, XPS, atau jenis output lain, gunakan panduan khusus format di [Convert Presentations to Multiple Formats](/slides/id/cpp/convert-presentation/) alih-alih mengasumsikan bahwa semua target mempertahankan fitur PowerPoint yang dapat diedit.

## **Konverter Online**

Untuk file sesekali atau perbandingan cepat, Anda dapat menggunakan [online PPT to PPTX converter](https://products.aspose.app/slides/id/conversion/ppt-to-pptx). Untuk konversi berulang, pemrosesan batch, atau penanganan error tingkat aplikasi, gunakan API C++.

## **Artikel Terkait**

- [Save Presentations in C++](/slides/id/cpp/save-presentation/)
- [Supported File Formats](/slides/id/cpp/supported-file-formats/)
- [Open Presentations in C++](/slides/id/cpp/open-presentation/)

## **FAQ**

**Apakah saya dapat mengonversi PPT ke PPTX tanpa Microsoft PowerPoint terpasang?**

Ya. Aspose.Slides untuk C++ memuat dan menyimpan file presentasi tanpa memerlukan Microsoft PowerPoint.

**Apakah konversi PPT ke PPTX akan mempertahankan semua konten secara persis?**

Konversi mempertahankan konten presentasi umum, tetapi ketepatan mutlak tidak dijamin untuk setiap fitur warisan atau yang tidak didukung. Tinjau file yang dihasilkan bila mengandung makro, objek OLE atau ActiveX, media, animasi khusus, atau font yang tidak umum.

**Apakah saya dapat mengonversi file PPT yang dilindungi kata sandi?**

Ya, jika Anda menyediakan kata sandi yang benar saat memuat file. Kata sandi yang hilang atau salah menyebabkan operasi pemuatan gagal.

**Haruskah saya menghapus file PPT setelah konversi?**

Simpan file asli sampai Anda memverifikasi PPTX di penampil dan alur kerja yang penting bagi Anda. Ini memberikan salinan rollback bila fitur warisan dikonversi secara berbeda.