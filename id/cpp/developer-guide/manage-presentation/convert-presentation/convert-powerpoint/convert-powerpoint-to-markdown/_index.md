---
title: Mengonversi Presentasi PowerPoint ke Markdown dalam C++
linktitle: PowerPoint ke Markdown
type: docs
weight: 140
url: /id/cpp/convert-powerpoint-to-markdown/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke MD
- presentasi ke MD
- slide ke MD
- PPT ke MD
- PPTX ke MD
- simpan PowerPoint sebagai Markdown
- simpan presentasi sebagai Markdown
- simpan slide sebagai Markdown
- simpan PPT sebagai MD
- simpan PPTX sebagai MD
- ekspor PPT ke MD
- ekspor PPTX ke MD
- ekspor gambar Markdown
- tautan gambar CDN
- PowerPoint
- presentasi
- Markdown
- C++
- Aspose.Slides
description: "Konversi presentasi PPT dan PPTX ke Markdown dalam C++ serta kontrol dimana gambar bitmap, metafile, dan SVG yang diekspor disimpan dan dirujuk."
---
## **Ikhtisar**

Aspose.Slides untuk C++ dapat mengonversi presentasi PPT dan PPTX ke Markdown untuk dokumentasi, situs statis, migrasi konten, dan alur kerja kontrol versi. Anda dapat memilih varian Markdown, mengontrol cara konten slide dirender, dan menentukan di mana gambar yang diekspor disimpan serta bagaimana Markdown yang dihasilkan mereferensikannya.

Secara default, ekspor Markdown menggunakan output hanya teks. Untuk mengekspor konten visual, atur metode [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) ke nilai `Sequential` atau `Visual` dari enumerasi [MarkdownExportType](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/markdownexporttype/). `Sequential` merender item slide secara terpisah dan berurutan, sedangkan `Visual` menjaga item yang dikelompokkan bersama untuk mempertahankan hubungan visual mereka. Nilai `TextOnly` tidak menghasilkan sumber daya gambar, sehingga peristiwa penyimpanan gambar tidak dipanggil dalam mode tersebut.

## **Konversi Presentasi ke Markdown**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/), lalu panggil metode [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/) dengan nilai `Md` dari enumerasi [SaveFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveformat/).

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Pilih Varian Markdown**

Metode [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) mengontrol spesifikasi Markdown yang digunakan untuk output. Enumerasi [Flavor](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/flavor/) mencakup CommonMark, GitHub Flavored Markdown, dan varian lain yang didukung.

Contoh berikut mengekspor presentasi sebagai CommonMark:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **Ekspor Gambar Menggunakan Perilaku Penyimpanan Lokal Default**

Kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/markdownsaveoptions/) menyediakan dua metode untuk mengonfigurasi gambar yang disimpan secara lokal:

- [set_BasePath](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) menentukan direktori dasar untuk dokumen Markdown dan sumber dayanya.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) menentukan subdirektori gambar. Nilai defaultnya adalah `Images`.

Contoh berikut merender konten visual, menulis gambar ke `output/assets`, dan membuat referensi gambar relatif dalam dokumen Markdown:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Perilaku ini juga berfungsi sebagai cadangan ketika handler penyimpanan gambar khusus mengembalikan `false`.

## **Sesuaikan Penyimpanan Gambar dan Tautan Markdown**

Gunakan peristiwa `MarkdownSaveOptions::ImageSaving` untuk sumber daya bitmap dan metafile non‑SVG yang dihasilkan selama ekspor Markdown. Delegasi [MarkdownImageSavingHandler](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) menerima objek [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) , objek [ImageFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/imageformat/) , dan tautan Markdown yang dihasilkan sebagai parameter `System::String&`. Simpan atau unggah gambar dengan format yang diberikan, dan gantikan `link` dengan referensi yang harus muncul dalam output Markdown.

Sumber daya yang dihasilkan dalam format SVG ditangani secara terpisah. Berlangganan ke peristiwa `MarkdownSaveOptions::SvgImageSaving`, yang delegasi [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) menerima objek [ISvgImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/isvgimage/) dan parameter `System::String& link`. SVG tidak memiliki argumen `ImageFormat`; tulis atau unggah data XML‑nya melalui metode [ISvgImage::get_SvgData](https://reference.aspose.com/slides/id/cpp/aspose.slides/isvgimage/get_svgdata/) . Bergantung pada mode ekspor dan pengelompokan visual, SVG dalam presentasi sumber dapat diubah menjadi raster atau digabungkan dengan konten lain; sumber daya non‑SVG yang dihasilkan kemudian diteruskan ke `ImageSaving`. Berlangganan kedua peristiwa ketika setiap sumber daya visual yang diekspor memerlukan pemrosesan khusus.

Nilai kembalian handler menentukan siapa yang memproses gambar:

- Kembalikan `true` setelah handler menyimpan, mengunggah, mengubah, atau memproses gambar dengan cara lain dan menetapkan nilai yang valid ke `link`. Aspose.Slides menulis nilai tersebut ke dokumen Markdown dan tidak melakukan penyimpanan lokal default.
- Kembalikan `false` untuk membiarkan Aspose.Slides menyimpan gambar secara lokal dan menghasilkan tautannya menurut [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) dan [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Handler yang mengembalikan `true` mengambil tanggung jawab atas gambar. Jika mengembalikan `true` tanpa menetapkan tautan yang valid dan tidak kosong, ekspor akan gagal dengan `InvalidOperationException`.
{{% /alert %}}

### **Simpan Gambar ke Direktori Asal CDN dan Gunakan URL Eksternal**

Contoh berikut menganggap `cdn-origin/presentations/quarterly-report` sebagai direktori asal CDN yang dipasang atau disinkronkan. Setiap handler mengekstrak nama file yang dihasilkan, menyimpan gambar ke direktori khusus tersebut, dan menggantikan referensi lokal yang dihasilkan dengan URL CDN publik. Contoh itu sendiri tidak melakukan unggahan jaringan: URL menjadi valid hanya setelah direktori dipasang sebagai asal CDN atau file‑filenya dipublikasikan ke CDN. Untuk penyimpanan objek, ganti penulisan sistem file dengan operasi unggah SDK penyimpanan dan tetapkan `link` hanya setelah unggahan berhasil.

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Handler bitmap sengaja mengembalikan `false` untuk gambar yang lebih kecil dari 128 × 128 piksel, sehingga Aspose.Slides menyimpan gambar tersebut ke `output/fallback-images` dengan perilaku default. Sumber daya bitmap dan metafile yang lebih besar, serta sumber daya SVG, ditangani oleh kode khusus. Sebagai contoh, referensi lokal yang dihasilkan seperti `fallback-images/image1.png` menjadi `https://cdn.example.com/presentations/quarterly-report/image1.png`. Handler hanya menggunakan path sistem operasi saat menulis file; tautan yang ditulis ke Markdown menggunakan garis miring depan dan nama file yang di‑URL‑encode. Terapkan aturan yang sama saat membangun tautan relatif: gunakan `/`, bukan pemisah direktori spesifik platform.

## **FAQ**

**Apakah satu handler dapat memproses gambar raster dan gambar SVG?**

Tidak. Gunakan `MarkdownSaveOptions::ImageSaving` untuk sumber daya bitmap dan metafile yang dihasilkan dan `MarkdownSaveOptions::SvgImageSaving` untuk sumber daya yang dihasilkan sebagai SVG. Yang pertama menyediakan objek [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) dan [ImageFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/imageformat/); yang kedua menyediakan objek [ISvgImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/isvgimage/) yang data SVG‑nya dapat dibaca dengan [ISvgImage::get_SvgData](https://reference.aspose.com/slides/id/cpp/aspose.slides/isvgimage/get_svgdata/). SVG sumber yang dirasterisasi selama ekspor diproses oleh `ImageSaving`.

**Apa yang terjadi ketika handler penyimpanan gambar mengembalikan `false`?**

Aspose.Slides menggunakan perilaku penyimpanan lokal default. Lokasi gambar dan referensi yang dihasilkan dikontrol oleh [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) dan [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

**Apakah handler dapat memberikan URL tanpa menyimpan gambar secara lokal?**

Ya. Handler dapat mengunggah gambar ke penyimpanan objek atau meneruskannya ke layanan lain, menetapkan URL hasil ke `link`, dan mengembalikan `true`. Handler harus menyelesaikan pemrosesan sendiri; mengembalikan `true` mencegah penyimpanan lokal default.

**Mengapa ekspor Markdown melempar `InvalidOperationException` dari handler?**

Pengecualian ini terjadi ketika handler mengembalikan `true` tetapi tidak menyediakan tautan yang valid. Tetapkan jalur relatif atau URL eksternal yang harus ditulis ke Markdown sebelum mengembalikan `true`.

**Pemisa jalur mana yang harus digunakan oleh tautan gambar?**

Gunakan garis miring depan dalam tautan Markdown dan URL. Gunakan `Path::Combine` hanya untuk jalur sistem file, kemudian bangun atau normalisasi referensi Markdown secara terpisah.

**Apakah hyperlink dipertahankan selama ekspor Markdown?**

Ya. Teks [hyperlinks](/slides/id/cpp/manage-hyperlinks/) dipertahankan sebagai tautan Markdown standar. Slide [transitions](/slides/id/cpp/slide-transition/) dan [animations](/slides/id/cpp/powerpoint-animation/) tidak dikonversi.

**Apakah presentasi dapat dikonversi ke Markdown secara paralel?**

Anda dapat memproses file presentasi yang berbeda secara paralel, tetapi jangan membagikan instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang sama antara thread. Ikuti [multithreading guidelines](/slides/id/cpp/multithreading/) dan gunakan instance terpisah untuk setiap file.