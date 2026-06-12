---
title: Menyimpan Presentasi dalam C++
linktitle: Simpan Presentasi
type: docs
weight: 80
url: /id/cpp/save-presentation/
keywords:
- menyimpan PowerPoint
- menyimpan OpenDocument
- menyimpan presentasi
- menyimpan slide
- menyimpan PPT
- menyimpan PPTX
- menyimpan ODP
- presentasi ke file
- presentasi ke stream
- tipe tampilan yang ditentukan
- Format Strict Office Open XML
- mode Zip64
- menyegarkan thumbnail
- progres penyimpanan
- C++
- Aspose.Slides
description: "Temukan cara menyimpan presentasi dalam C++ menggunakan Aspose.Slides—mengekspor ke PowerPoint atau OpenDocument sambil mempertahankan tata letak, font, dan efek."
---
## **Gambaran Umum**

[Open Presentations in C++](/slides/id/cpp/open-presentation/) menjelaskan cara menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) untuk membuka sebuah presentasi. Artikel ini menjelaskan cara membuat dan menyimpan presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) berisi isi sebuah presentasi. Baik Anda membuat presentasi dari awal maupun memodifikasi yang sudah ada, Anda perlu menyimpannya setelah selesai. Dengan Aspose.Slides untuk C++, Anda dapat menyimpan ke **file** atau **stream**. Artikel ini menjelaskan berbagai cara menyimpan presentasi.

## **Menyimpan Presentasi ke File**

Simpan presentasi ke file dengan memanggil metode `Save` pada kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/). Berikan nama file dan format penyimpanan ke metode tersebut. Contoh berikut menunjukkan cara menyimpan presentasi dengan Aspose.Slides.

```cpp
// Instansiasi kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>();

// Lakukan beberapa pekerjaan di sini...

// Simpan presentasi ke file.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Menyimpan Presentasi ke Stream**

Anda dapat menyimpan presentasi ke stream dengan memberikan output stream ke metode `Save` pada kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/). Sebuah presentasi dapat ditulis ke banyak tipe stream. Pada contoh di bawah, kami membuat presentasi baru dan menyimpannya ke file stream.

```cpp
// Instansiasikan kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Simpan presentasi ke stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Menyimpan Presentasi dengan Tipe Tampilan yang Sudah Ditentukan**

Aspose.Slides memungkinkan Anda mengatur tampilan awal yang digunakan PowerPoint saat presentasi yang dihasilkan dibuka melalui kelas [ViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/). Gunakan metode [set_LastView](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/set_lastview/) dengan nilai dari enumerasi [ViewType](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewtype/).

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Menyimpan Presentasi dalam Format Strict Office Open XML**

Aspose.Slides memungkinkan Anda menyimpan presentasi dalam format Strict Office Open XML. Gunakan kelas [PptxOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pptxoptions/) dan atur properti conformance-nya saat menyimpan. Jika Anda menetapkan `Conformance.Iso29500_2008_Strict`, file output akan disimpan dalam format Strict Office Open XML.

Contoh di bawah membuat presentasi dan menyimpannya dalam format Strict Office Open XML.

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Instansiasikan kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>();

// Simpan presentasi dalam format Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Menyimpan Presentasi dalam Format Office Open XML dengan Mode Zip64**

File Office Open XML adalah arsip ZIP yang membatasi ukuran tidak terkompresi setiap file, ukuran terkompresi setiap file, dan total ukuran arsip menjadi 4 GB (2^32 byte), serta membatasi jumlah file dalam arsip menjadi 65 535 (2^16‑1). Ekstensi format ZIP64 mengangkat batasan ini menjadi 2^64.

Metode [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) memungkinkan Anda memilih kapan menggunakan ekstensi format ZIP64 saat menyimpan file Office Open XML.

Metode ini dapat digunakan dengan mode berikut:

- `IfNecessary` menggunakan ekstensi format ZIP64 hanya jika presentasi melampaui batasan di atas. Ini adalah mode default.
- `Never` tidak pernah menggunakan ekstensi format ZIP64.
- `Always` selalu menggunakan ekstensi format ZIP64.

Kode berikut menunjukkan cara menyimpan presentasi sebagai PPTX dengan ekstensi format ZIP64 diaktifkan:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Saat Anda menyimpan dengan `Zip64Mode.Never`, sebuah [PptxException](https://reference.aspose.com/slides/id/cpp/aspose.slides/pptxexception/) akan dilempar jika presentasi tidak dapat disimpan dalam format ZIP32.
{{% /alert %}}

## **Menyimpan Presentasi tanpa Menyegarkan Thumbnail**

Metode [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) mengontrol pembuatan thumbnail saat menyimpan presentasi ke PPTX:

- Jika diatur ke `true`, thumbnail akan disegarkan selama proses penyimpanan. Ini adalah nilai default.
- Jika diatur ke `false`, thumbnail saat ini akan dipertahankan. Jika presentasi tidak memiliki thumbnail, tidak ada yang akan dibuat.

Pada kode di bawah, presentasi disimpan ke PPTX tanpa menyegarkan thumbnail-nya.

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Opsi ini membantu mengurangi waktu yang diperlukan untuk menyimpan presentasi dalam format PPTX.
{{% /alert %}}

## **Pembaharuan Progres Penyimpanan dalam Persentase**

Antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprogresscallback/) digunakan melalui metode `set_ProgressCallback` yang disediakan oleh antarmuka [ISaveOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/isaveoptions/) dan kelas abstrak [SaveOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveoptions/). Tetapkan implementasi [IProgressCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprogresscallback/) dengan `set_ProgressCallback` untuk menerima pembaruan progres penyimpanan dalam persentase.

Potongan kode berikut memperlihatkan cara menggunakan `IProgressCallback`.

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Gunakan nilai persentase kemajuan di sini.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose telah mengembangkan aplikasi [free PowerPoint Splitter app](https://products.aspose.app/slides/id/splitter) menggunakan API miliknya. Aplikasi ini memungkinkan Anda membagi sebuah presentasi menjadi beberapa file dengan menyimpan slide terpilih sebagai file PPTX atau PPT baru.
{{% /alert %}}

## **FAQ**

**Apakah "fast save" (penyimpanan inkremental) didukung sehingga hanya perubahan yang ditulis?**

Tidak. Penyimpanan selalu membuat file target lengkap setiap kali; "fast save" inkremental tidak didukung.

**Apakah aman untuk menyimpan instance Presentation yang sama dari beberapa thread?**

Tidak. Sebuah [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) [tidak thread‑safe](/slides/id/cpp/multithreading/); simpan hanya dari satu thread.

**Apa yang terjadi pada hyperlink dan file yang ditautkan secara eksternal saat menyimpan?**

[Hyperlink](/slides/id/cpp/manage-hyperlinks/) dipertahankan. File yang ditautkan secara eksternal (misalnya video dengan jalur relatif) tidak disalin secara otomatis—pastikan jalur yang dirujuk tetap dapat diakses.

**Bisakah saya mengatur/menyimpan metadata dokumen (Penulis, Judul, Perusahaan, Tanggal)?**

Ya. [Properti dokumen](/slides/id/cpp/presentation-properties/) standar didukung dan akan ditulis ke file saat disimpan.