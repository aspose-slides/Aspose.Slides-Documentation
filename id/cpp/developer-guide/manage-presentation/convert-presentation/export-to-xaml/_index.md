---
title: Ekspor Presentasi ke XAML dalam C++
linktitle: Presentasi ke XAML
type: docs
weight: 30
url: /id/cpp/export-to-xaml/
keywords:
- ekspor PowerPoint
- ekspor OpenDocument
- ekspor presentasi
- konversi PowerPoint
- konversi OpenDocument
- konversi presentasi
- PowerPoint ke XAML
- OpenDocument ke XAML
- presentasi ke XAML
- PPT ke XAML
- PPTX ke XAML
- ODP ke XAML
- simpan PPT sebagai XAML
- simpan PPTX sebagai XAML
- simpan ODP sebagai XAML
- ekspor PPT ke XAML
- ekspor PPTX ke XAML
- ekspor ODP ke XAML
- C++
- Aspose.Slides
description: "Konversi slide PowerPoint dan OpenDocument ke XAML dalam C++ menggunakan Aspose.Slides—solusi cepat tanpa Office yang mempertahankan tata letak Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengekspor presentasi PowerPoint ke XAML menggunakan Aspose.Slides. Ini mencakup pengantar singkat tentang XAML, menunjukkan cara menyimpan presentasi ke XAML dengan pengaturan default, dan mendemonstrasikan cara menyesuaikan ekspor melalui [XamlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/xamloptions/), termasuk mengekspor slide tersembunyi. Artikel ini juga menjawab beberapa pertanyaan umum terkait font fallback, kompatibilitas stack XAML, dan perilaku ekspor slide tersembunyi.

## **Tentang XAML**

XAML adalah bahasa markup berbasis XML yang digunakan untuk menggambarkan antarmuka pengguna dalam kerangka kerja seperti WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), dan Xamarin.Forms.

Anda dapat bekerja dengan file XAML dalam desainer visual atau menulis dan mengedit markup secara langsung.

## **Ekspor Presentasi ke XAML dengan Opsi Default**

Contoh C++ berikut menunjukkan cara mengekspor presentasi ke XAML dengan pengaturan default:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

Secara default, slide yang diekspor disimpan dalam subfolder `pres` dari direktori kerja saat ini proses, seperti yang dikembalikan oleh [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/id/cpp/system.io/directory/getcurrentdirectory/). Folder dibuat secara otomatis, dan gambar yang diperlukan juga disimpan di sana.

Nama folder output diambil dari nama file sumber tanpa ekstensi. Untuk `pres.pptx`, file output dinamai `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, dan seterusnya. Bahkan jika Anda memberikan path absolut ke presentasi input, folder output dibuat relatif terhadap direktori kerja saat ini, bukan berdampingan dengan file input.

## **Ekspor Presentasi ke XAML dengan Opsi Kustom**

Gunakan antarmuka [IXamlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/ixamloptions/) untuk mengontrol bagaimana Aspose.Slides mengekspor presentasi ke XAML.

Untuk menyimpan output ke lokasi kustom, implementasikan [IXamlOutputSaver](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/ixamloutputsaver/) dan berikan instance implementasi Anda kepada metode [set_OutputSaver](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) pada [XamlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/xamloptions/).

Untuk menyertakan slide tersembunyi dalam output XAML, berikan `true` ke metode [set_ExportHiddenSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/), seperti yang ditunjukkan pada contoh C++ berikut:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **Tangkap Semua Artefak XAML yang Dihasilkan**

Ekspor XAML dapat menghasilkan dokumen XAML untuk setiap slide yang diekspor serta gambar terpisah dan sumber daya pendukung. Berikan [IXamlOutputSaver](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/ixamloutputsaver/) kustom ke [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) untuk menerima artefak-artefak ini alih-alih menggunakan penyimpan file sistem default. Mulai ekspor dengan overload [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/) khusus XAML yang menerima opsi XAML.

### **Pahami Siklus Hidup Callback**

- `path` mengidentifikasi artefak dan dapat mencakup direktori relatif. Simpan informasi ini karena XAML mungkin merujuk sumber daya menggunakan path relatif.
- `data` berisi byte artefak. Gambar dan sumber daya biner lainnya tidak boleh didekode sebagai teks.
- Penyimpan bertanggung jawab untuk menyimpan atau mempersist data sebelum mengembalikan. Contoh-contoh menyalin setiap array byte ke memori milik aplikasi.
- Anggap ekspor berhasil hanya ketika operasi penyimpanan presentasi selesai dan setiap callback telah selesai dengan sukses. Jangan menelan kesalahan penyimpanan atau memulai penulisan latar belakang yang tidak terpantau. Jika persisten terjadi setelahnya, laporkan keberhasilan keseluruhan hanya setelah langkah tersebut juga berhasil.

[XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) juga berlaku untuk penyimpan kustom. Pengaturan default, `false`, mengecualikan dokumen XAML slide tersembunyi. Mengaturnya ke `true` menyertakan mereka serta semua sumber daya yang diperlukan untuk ekspor mereka. Jumlah sumber daya bergantung pada presentasi; jangan mengasumsikan satu callback per slide atau urutan callback tetap.

### **Ekspor ke Memori dan Periksa Artefak**

Contoh lengkap ini memuat `pres.pptx`, mengumpulkan setiap artefak dalam sebuah [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/id/cpp/system.collections.generic/dictionary/), dan mencetak nama, tipe, serta jumlah byte-nya. Itu mempertahankan nama yang diberikan secara tepat. Nama duplikat menyebabkan koleksi gagal alih-alih menimpa artefak secara diam-diam.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // Dekode hanya XAML, dan hanya saat inspeksi tekstual diperlukan.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

Panggil `InMemoryXamlExample::Run` dari aplikasi Anda. Pemeriksaan ekstensi berguna untuk inspeksi; pertahankan semua artefak, termasuk tipe sumber daya yang tidak familiar. Biarkan byte tetap tidak berubah saat menyimpan atau mentransmisikannya. Gunakan [Encoding::GetString](https://reference.aspose.com/slides/id/cpp/system.text/encoding/getstring/) dengan encoding UTF-8 hanya untuk XAML yang memerlukan pemrosesan teks.

### **Kemas Artefak yang Dikumpulkan dalam Arsip ZIP**

Contoh terpisah ini mengumpulkan ekspor, memvalidasi namanya, dan menulis byte asli ke dalam arsip ZIP. Nama arsip unik memisahkan pekerjaan ekspor yang bersamaan. Entri ZIP menggunakan garis miring maju dan mempertahankan direktori relatif. Nama yang tidak aman atau nama yang berbenturan setelah normalisasi menolak seluruh paket sebelum ditulis.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // Simpan menyelesaikan direktori ZIP; tutup file sebelum melaporkan keberhasilan.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

Panggil `ZipXamlExample::Run` dari aplikasi Anda. Contoh ini menggunakan `Aspose::Zip::ZipFile` dari runtime C++ untuk menulis satu arsip lokal; eksportor sendiri tidak menulis file XAML atau gambar terpisah. Untuk penyimpanan remote, ganti tahap penulisan arsip dengan unggahan array byte yang dikumpulkan. Gunakan pengidentifikasi pekerjaan ekspor ditambah nama artefak relatif lengkap sebagai kunci blob, atau simpan pengidentifikasi pekerjaan, nama relatif, dan data biner dalam baris basis data. Publikasikan pekerjaan hanya setelah semua unggahan selesai atau transaksi basis data dikomit. Bersihkan output parsial jika persisten gagal.

Untuk presentasi besar, penyimpan kustom dapat menyimpan setiap artefak langsung ke penyimpanan aplikasi untuk menghindari menyimpan salinan tambahan seluruh ekspor di memori aplikasi. Eksportor masih mengumpulkan semua artefak yang dihasilkan di memori sebelum memanggil penyimpan. Jaga setiap callback tetap sinkron dari perspektif eksportor: kembalikan hanya setelah tujuan menerima byte, dan izinkan kegagalan mencapai pemanggil.

### **Pertahankan Nama Sumber Daya dan Verifikasi Referensi**

- Normalisasi pemisah path ketika tujuan memerlukannya, tetapi pertahankan direktori relatif. Jangan hanya menggunakan [Path::GetFileName](https://reference.aspose.com/slides/id/cpp/system.io/path/getfilename/) kecuali setiap nama yang dihasilkan diketahui unik dan referensi sumber daya tetap valid.
- Terapkan validasi nama spesifik tujuan. Saat menulis file terpisah, tolak path berakar dan segmen traversal, selesaikan tujuan dengan [Path::GetFullPath](https://reference.aspose.com/slides/id/cpp/system.io/path/getfullpath/), dan verifikasi tetap berada di bawah direktori ekspor yang dimaksud, termasuk pemisah direktori dalam pemeriksaan kepemilikan. Gunakan direktori yang dikontrol aplikasi tanpa tautan simbolik yang dapat mengarahkan penulisan.
- Gunakan penyimpan dan namespace penyimpanan terpisah untuk setiap pekerjaan ekspor. Deteksi tabrakan setelah normalisasi pemisah dan sesuai dengan aturan sensitivitas huruf kapital tujuan.
- Sebelum dipublikasikan, parsing setiap dokumen XAML sebagai XML dan periksa referensi sumber daya berbasis file, seperti atribut `Source` atau `ImageSource` pada gambar. Seleseikan setiap URI relatif terhadap direktori artefak XAML yang memuatnya, normalisasi nama penyimpanan yang dihasilkan, dan konfirmasi bahwa kunci dictionary, entri ZIP, atau objek yang disimpan yang bersesuaian ada. Perlakukan URI eksternal dan ekspresi markup XAML terpisah dari nama file relatif.

Sebagai contoh, jika `pres/Slide_1.xaml` merujuk `images/image1.png`, sumber daya yang disimpan harus tersedia sebagai `pres/images/image1.png`. Menyimpan hanya `image1.png` akan memutus hubungan tersebut. Untuk penyimpanan objek, pertahankan tata letak yang sama di bawah prefiks pekerjaan dan buat URL sumber daya tersebut dapat diakses oleh konsumen XAML. Buka kembali ZIP yang selesai untuk memverifikasi nama entri dan byte sumber daya, serta muat slide representatif di lingkungan XAML target untuk memastikan gambar ter‑resolve dengan benar.

## **FAQ**

**Bagaimana saya dapat memastikan font yang dapat diprediksi jika font asli tidak tersedia di mesin?**

Gunakan [set_DefaultRegularFont](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) dalam [XamlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/xamloptions/) — ini digunakan sebagai font fallback selama ekspor ketika font asli tidak ada. Ini tidak menjamin bahwa XAML yang dihasilkan merujuk font fallback atau bahwa font tersebut tersedia di mesin target. Pastikan bahwa font yang dirujuk oleh XAML tersedia di lingkungan tempat XAML ditampilkan.

**Apakah XAML yang diekspor hanya dimaksudkan untuk WPF, atau dapat digunakan juga di stack XAML lain?**

Aspose.Slides mengekspor XAML WPF melalui API publiknya. Kompatibilitas dengan stack XAML lain, seperti UWP dan Xamarin.Forms, tidak dijamin. Uji markup yang dihasilkan di lingkungan target Anda.

**Apakah slide tersembunyi didukung, dan bagaimana saya dapat mencegah mereka diekspor secara default?**

Secara default, slide tersembunyi tidak disertakan. Anda dapat mengontrol perilaku ini melalui [set_ExportHiddenSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) dalam [XamlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/xamloptions/) — biarkan dinonaktifkan jika Anda tidak perlu mengekspornya.