---
title: Simpan Presentasi dalam C++
linktitle: Simpan Presentasi
type: docs
weight: 80
url: /id/cpp/save-presentation/
keywords:
- simpan PowerPoint
- simpan OpenDocument
- simpan presentasi
- simpan slide
- simpan PPT
- simpan PPTX
- simpan ODP
- presentasi ke file
- presentasi ke stream
- tipe tampilan yang telah ditentukan
- Format Office Open XML yang Ketat
- mode Zip64
- menyegarkan thumbnail
- kemajuan penyimpanan
- C++
- Aspose.Slides
description: "Simpan presentasi PowerPoint dan OpenDocument ke file atau stream dalam C++ dengan Aspose.Slides, serta konfigurasikan output PPTX dan pelaporan kemajuan."
---
## **Ringkasan**

Setelah Anda membuat presentasi atau [buka presentasi yang sudah ada](/slides/id/cpp/open-presentation/), gunakan metode [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/) untuk menulis hasilnya. Aspose.Slides untuk C++ dapat menyimpan presentasi ke file atau stream dalam format PowerPoint, OpenDocument, PDF, dan format lainnya. Bagian‑bagian berikut mencakup operasi penyimpanan standar dan opsi yang tersedia untuk output PPTX.

## **Simpan Presentasi ke File**

Untuk menyimpan presentasi ke file, berikan path output dan nilai [SaveFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveformat/) ke metode [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/). Nilai format menentukan jenis file yang dibuat oleh Aspose.Slides.

Contoh berikut membuat presentasi dan menyimpannya sebagai file PPTX:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Tambahkan atau ubah konten presentasi di sini.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Simpan Presentasi dalam Format Aslinya**

Untuk contoh deteksi file dan stream, perilaku presentasi yang baru dibuat, dan perbedaan antara format sumber dan output, lihat [Determine the Original Presentation Format](/slides/id/cpp/detect-presentation-source-format/).

Dalam aplikasi pemrosesan batch, format input mungkin tidak diketahui sebelumnya. Setelah memuat file, baca format aslinya dengan [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/get_sourceformat/). Berikan nilai [SourceFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/sourceformat/) yang dihasilkan ke [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides.util/slideutil/tosaveformat/) untuk memperoleh nilai [SaveFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveformat/) yang sesuai, kemudian gunakan [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/) untuk menulis presentasi yang telah dimodifikasi.

Contoh lengkap berikut memproses setiap file di direktori input, memperbarui judulnya, dan menyimpannya ke direktori output dalam format asalnya:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides.util/slideutil/tosaveformat/) memetakan PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, dan PowerPoint XML ke format penyimpanan presentasi yang bersesuaian. Ia memetakan hanya format sumber presentasi; tidak dimaksudkan untuk memilih format ekspor seperti PDF, HTML, TIFF, atau gambar. Memberikan nilai [SourceFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/sourceformat/) yang tidak didukung atau tidak valid menghasilkan [ArgumentException](https://reference.aspose.com/slides/id/cpp/system/argumentexception/).

File PPT, PPS, dan POT lama menggunakan kontainer biner yang sama. Ketika presentasi semacam itu dimuat dari stream tanpa ekstensi file, file PPS atau POT dapat diidentifikasi sebagai PPT. Jika perlu menjaga subtipe lama ini, pertahankan nama file atau metadata format asli secara terpisah dan gunakan saat memilih nama file dan format output.

## **Simpan Presentasi ke Stream**

Untuk menulis presentasi tanpa bergantung pada path file akhir, berikan [Stream](https://reference.aspose.com/slides/id/cpp/system.io/stream/) yang dapat ditulisi dan nilai [SaveFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveformat/) ke metode [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/). Pendekatan ini berguna ketika output harus dikembalikan dari layanan web, disimpan di basis data, atau diproses dalam memori.

Contoh berikut menyimpan presentasi baru ke stream file:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **Simpan Presentasi dengan Tipe Tampilan yang Ditentukan**

Anda dapat menentukan tampilan di mana PowerPoint membuka presentasi yang disimpan secara awal. Panggil [ViewProperties::set_LastView](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/set_lastview/) dengan nilai [ViewType](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewtype/) sebelum menyimpan.

Contoh berikut mengonfigurasi tampilan Slide Master sebagai tampilan awal:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Simpan Presentasi dalam Format Office Open XML yang Ketat**

Untuk membuat file PPTX yang mematuhi profil Strict dari Office Open XML, buat instance [PptxOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pptxoptions/) dan panggil [PptxOptions::set_Conformance](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pptxoptions/set_conformance/) dengan `Conformance::Iso29500_2008_Strict`. Kemudian berikan opsi tersebut ke metode [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/).

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Simpan Presentasi dalam Format Office Open XML dengan Mode Zip64**

Arsip ZIP standar membatasi ukuran terkompresi dan tidak terkompresi tiap entri, total ukuran arsip, serta jumlah entri. Karena file PPTX adalah arsip ZIP, presentasi yang sangat besar dapat melampaui batas tersebut. Ekstensi ZIP64 meningkatkan batas ukuran dan jumlah entri yang berlaku.

Gunakan [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) untuk mengontrol apakah Aspose.Slides menulis ekstensi ZIP64:

- `IfNecessary` menggunakan ZIP64 hanya ketika presentasi melebihi batas ZIP standar. Ini adalah mode default.
- `Never` menonaktifkan ekstensi ZIP64.
- `Always` selalu menulis ekstensi ZIP64.

Contoh berikut selalu mengaktifkan ekstensi ZIP64 untuk presentasi output:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
Jika `Zip64Mode` diatur ke `Never` dan presentasi tidak dapat muat dalam batas ZIP standar, operasi penyimpanan akan melempar [PptxException](https://reference.aspose.com/slides/id/cpp/aspose.slides/pptxexception/).
{{% /alert %}}

## **Simpan Presentasi dalam Format Office Open XML dengan Tingkat Kompresi**

Untuk output PPTX, Anda dapat menyeimbangkan kecepatan penyimpanan dengan ukuran file dengan memanggil [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/). Enumerasi [CompressionLevel](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/compressionlevel/) menyediakan nilai berikut:

- `None` menyimpan data tanpa kompresi.
- `Level1` memberikan kompresi tercepat dan output terkompresi terbesar.
- `Level2` hingga `Level5` secara bertahap lebih mengutamakan output yang lebih kecil daripada kecepatan penyimpanan.
- `Level6` menyeimbangkan kecepatan penyimpanan dan ukuran file. Ini adalah level default.
- `Level7` dan `Level8` lebih mengutamakan output yang lebih kecil dibandingkan kecepatan penyimpanan.
- `Level9` memberikan kompresi terkuat dan membutuhkan waktu pemrosesan paling lama.

Contoh berikut menyimpan presentasi tanpa kompresi:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

Contoh berikut menggunakan tingkat kompresi maksimum:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Simpan Presentasi tanpa Menyegarkan Thumbnail**

Saat presentasi disimpan sebagai PPTX, [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) mengontrol thumbnail dokumen:

- `true` menghasilkan kembali thumbnail selama operasi penyimpanan. Ini adalah nilai default.
- `false` mempertahankan thumbnail yang ada. Jika presentasi tidak memiliki thumbnail, Aspose.Slides tidak membuatnya.

Contoh berikut menyimpan presentasi tanpa menyegarkan thumbnailnya:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Menonaktifkan penyegaran thumbnail dapat mengurangi waktu yang diperlukan untuk menyimpan file PPTX.
{{% /alert %}}

## **Simpan Pembaruan Progres dalam Persentase**

Untuk memantau operasi penyimpanan, implementasikan antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprogresscallback/) dan berikan implementasinya ke [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/isaveoptions/set_progresscallback/). Aspose.Slides kemudian memanggil [IProgressCallback::Reporting](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprogresscallback/reporting/) dengan nilai progres selama ekspor.

Contoh berikut melaporkan progres ekspor PDF ke konsol:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose menyediakan [PowerPoint Splitter](https://products.aspose.app/slides/id/splitter) gratis yang dibangun dengan API Aspose.Slides. Alat ini menyimpan slide terpilih dari presentasi sebagai file PPT atau PPTX terpisah.
{{% /alert %}}

## **FAQ**

**Apakah Aspose.Slides mendukung penyimpanan incremental atau “fast save”?**

Tidak. Setiap operasi penyimpanan menulis file output lengkap alih‑alih memperbarui hanya bagian yang berubah.

**Dapatkah beberapa thread menyimpan instance Presentation yang sama?**

Tidak. Sebuah [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) tidak [aman untuk thread](/slides/id/cpp/multithreading/). Akses dan simpan tiap instance hanya dari satu thread pada satu waktu.

**Apa yang terjadi pada hyperlink dan file yang ditautkan secara eksternal ketika saya menyimpan presentasi?**

[Hyperlink](/slides/id/cpp/manage-hyperlinks/) tetap berada di presentasi. Aspose.Slides tidak menyalin file yang ditautkan secara eksternal, sehingga presentasi yang disimpan harus tetap dapat mengakses lokasi file tersebut.

**Apakah saya dapat menyimpan metadata dokumen seperti penulis, judul, perusahaan, dan tanggal pembuatan?**

Ya. Atur [properti dokumen](/slides/id/cpp/presentation-properties/) yang sesuai sebelum menyimpan, dan Aspose.Slides akan menuliskannya ke file output.