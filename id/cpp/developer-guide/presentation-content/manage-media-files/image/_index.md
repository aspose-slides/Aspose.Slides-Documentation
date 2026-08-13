---
title: Optimalkan Pengelolaan Gambar dalam Presentasi Menggunakan C++
linktitle: Kelola Gambar
type: docs
weight: 10
url: /id/cpp/image/
keywords:
- menambah gambar
- menambah foto
- menambah bitmap
- mengganti gambar
- mengganti foto
- dari web
- latar belakang
- menambah PNG
- menambah JPG
- menambah SVG
- sumber daya SVG eksternal
- resolver SVG
- gambar SVG tertaut
- font SVG
- menambah EMF
- menambah WMF
- menambah TIFF
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Permudah pengelolaan gambar di PowerPoint dan OpenDocument dengan Aspose.Slides untuk C++, mengoptimalkan kinerja dan mengotomatiskan alur kerja Anda."
---
## **Pendahuluan**

Gambar membuat presentasi lebih menarik dan secara visual lebih menarik. Di Microsoft PowerPoint, Anda dapat menyisipkan gambar ke slide dari file, internet, atau sumber lainnya. Demikian pula, Aspose.Slides memungkinkan Anda menambahkan gambar ke slide presentasi dengan beberapa cara. 

{{% alert title="Tip" color="info" %}} 

Aspose menyediakan konverter gratis—[JPEG to PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG to PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan Anda dengan cepat membuat presentasi dari gambar. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Jika Anda ingin menambahkan gambar sebagai bingkai gambar—khususnya jika Anda berencana mengubah ukurannya, menerapkan efek, atau menggunakan opsi pemformatan standar lainnya—lihat [Picture Frame](/slides/id/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Anda dapat mengonversi gambar dari satu format ke format lain. Lihat halaman berikut: konversi [image to JPG](https://products.aspose.com/slides/id/cpp/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/id/cpp/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/id/cpp/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/id/cpp/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/id/cpp/conversion/png-to-svg/), dan [SVG to PNG](https://products.aspose.com/slides/id/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides mendukung gambar dalam format populer seperti JPEG, PNG, BMP, GIF, dan lainnya. 

## **Tambahkan Gambar yang Disimpan Secara Lokal ke Slide**

Anda dapat menambahkan satu atau beberapa gambar yang disimpan di komputer Anda ke slide presentasi. Kode contoh C++ berikut menunjukkan cara menambahkan gambar ke slide:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Tambahkan Gambar dari Web ke Slide**

Jika gambar yang ingin Anda tambahkan ke slide tidak disimpan di komputer Anda, Anda dapat menambahkannya langsung dari web. 

Kode contoh C++ berikut menunjukkan cara menambahkan gambar dari web ke slide:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Tambahkan Gambar ke Slide Master**

Slide master menyimpan dan mengendalikan informasi seperti tema dan tata letak untuk slide yang menggunakannya. Ketika Anda menambahkan gambar ke slide master, gambar tersebut muncul pada setiap slide yang berbasis master itu. 

Kode contoh C++ berikut menunjukkan cara menambahkan gambar ke slide master:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Tambahkan Gambar sebagai Latar Belakang Slide**

Anda dapat menggunakan gambar sebagai latar belakang untuk satu atau beberapa slide. Untuk detailnya, lihat *[Setting Images as Backgrounds for Slides](/slides/id/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Tambahkan SVG ke Presentasi**

Konten SVG dapat ditambahkan ke presentasi menggunakan kelas [SvgImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/svgimage/). Objek [ISvgImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/isvgimage/) yang dihasilkan kemudian dapat ditambahkan ke koleksi gambar presentasi dan digunakan untuk membuat bingkai gambar.

Contoh C++ berikut mengimpor string SVG yang berdiri sendiri. Semua gambar, gaya, dan sumber daya lain yang digunakan SVG ini disematkan langsung dalam konten SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Impor Konten SVG dengan Sumber Daya Eksternal**

File SVG yang diekspor dari alat desain, editor diagram, sistem ikon, dan alur kerja web mungkin merujuk pada sumber daya yang disimpan di luar dokumen SVG. Misalnya, SVG dapat berisi tautan gambar seperti `images/photo.png`, nilai CSS `url(...)`, atau URL font.

Untuk mengimpor konten SVG tersebut, buat implementasi [IExternalResourceResolver](https://reference.aspose.com/slides/id/cpp/aspose.slides.import/iexternalresourceresolver/) dan berikan bersama dengan URI dasar ke konstruktor `SvgImage` yang sesuai. URI dasar mengidentifikasi lokasi dokumen SVG dan digunakan untuk menyelesaikan tautan relatif.

Antarmuka [ISvgImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/isvgimage/) menyediakan akses ke informasi tentang SVG yang diimpor:

- `get_SvgContent()` mengembalikan markup SVG sebagai string.
- `get_SvgData()` mengembalikan konten SVG sebagai array byte.
- `get_BaseUri()` mengembalikan URI dasar yang digunakan untuk tautan relatif.
- `get_ExternalResourceResolver()` mengembalikan resolver yang ditetapkan untuk gambar SVG.

### **Implementasikan Resolver Sumber Daya Eksternal**

Resolver memiliki dua metode:

- [ResolveUri](https://reference.aspose.com/slides/id/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) menggabungkan URI dasar dan tautan sumber daya relatif serta mengembalikan URI absolut. Kembalikan string null ketika tautan tidak dapat diselesaikan atau tidak diizinkan.
- [GetEntity](https://reference.aspose.com/slides/id/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) mengembalikan aliran yang dapat dibaca untuk URI sumber daya absolut. Kembalikan `nullptr` ketika sumber daya tidak ada, diblokir, atau tidak tersedia. Aliran cadangan juga dapat dikembalikan bila sesuai.

Resolver berikut memuat sumber daya yang ditautkan hanya dari direktori lokal yang diizinkan. Sumber daya jaringan dan jalur di luar direktori yang diizinkan diblokir. Gambar cadangan opsional dikembalikan untuk tautan gambar yang tidak dapat diselesaikan.

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // Resolver ini sengaja memperbolehkan hanya file lokal.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // Gunakan fallback hanya untuk sumber daya gambar. Mengembalikan aliran gambar
        // untuk font atau stylesheet yang hilang tidak akan valid.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **Selesaikan Sumber Daya Tertaut Selama Impor SVG**

Misalkan `assets/diagram.svg` berisi referensi relatif seperti:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Contoh C++ berikut menyertakan URI file SVG sebagai URI dasar dan menyediakan resolver khusus. Resolver mengubah tautan gambar relatif menjadi URI absolut dan mengembalikan aliran yang berisi sumber daya tertaut saat Aspose.Slides memproses SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// URI dasar mewakili lokasi dokumen SVG.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kelas `SvgImage` juga menyediakan overload yang menerima data SVG sebagai array byte atau aliran, bersama dengan resolver sumber daya eksternal dan URI dasar.

{{% alert title="Important" color="warning" %}}

Resolver sumber daya membuat sumber daya eksternal tersedia saat Aspose.Slides memproses dan merender SVG. Ia tidak mengubah markup SVG asli atau secara otomatis menyematkan sumber daya yang telah diselesaikan ke dalamnya.

Ketika `ISvgImage` ditambahkan ke koleksi gambar presentasi, file PPTX dapat berisi representasi SVG asli serta gambar raster cadangan. Sumber daya tertaut dapat muncul dalam gambar cadangan yang dihasilkan sementara tautan relatif seperti `images/photo.png` tetap tidak berubah dalam SVG yang disimpan. Aplikasi yang merender representasi SVG asli mungkin mengabaikan konten tertaut ketika sumber daya eksternal asli tidak tersedia.

{{% /alert %}}

### **Buat Gambar SVG Portabel**

Untuk membuat gambar SVG yang tidak bergantung pada file eksternal, jadikan SVG berdiri sendiri sebelum membuat `SvgImage`. Misalnya, ganti URL gambar yang ditautkan dengan URI `data:` yang berisi data gambar:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Setelah semua sumber daya yang diperlukan disematkan dalam konten SVG, buat `SvgImage`, tambahkan ke koleksi gambar presentasi, dan sisipkan ke dalam bingkai gambar seperti pada contoh sebelumnya.

### **Tangani Sumber Daya yang Hilang atau Diblokir**

Kembalikan string null dari `ResolveUri` ketika URI sumber daya tidak valid, dilarang, atau tidak dapat diselesaikan. Kembalikan `nullptr` dari `GetEntity` ketika sumber daya tidak dapat dibaca. Aspose.Slides melanjutkan memproses SVG tanpa sumber daya tersebut bila memungkinkan.

Aliran cadangan dapat dikembalikan untuk sumber daya yang hilang, tetapi isinya harus kompatibel dengan tipe sumber daya yang diminta. Misalnya, kembalikan aliran gambar hanya untuk gambar yang hilang, bukan untuk font atau stylesheet.

{{% alert title="Security" color="warning" %}}

Jangan selesaikan jalur file sewenang-warnag atau URL jaringan yang tidak dibatasi dari file SVG yang tidak tepercaya. Batasi skema, direktori, dan host yang diizinkan. Untuk sumber daya jaringan, terapkan juga batas waktu koneksi, batas ukuran respons, dan validasi konten.

{{% /alert %}}

## **Konversi SVG ke Sekelompok Bentuk**
Aspose.Slides dapat mengonversi SVG menjadi sekumpulan bentuk, serupa dengan fungsi yang bersesuaian di PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Fungsionalitas ini disediakan oleh overload metode [AddGroupShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/) dari antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/) yang mengambil objek [ISvgImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/isvgimage/) sebagai argumen pertama.

Kode contoh C++ berikut menunjukkan cara menggunakan metode ini untuk mengonversi file SVG menjadi sekumpulan bentuk:

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// Nama file SVG sumber
auto svgFileName = System::String(u"sample.svg");

// Nama file presentasi output
auto outPptxPath = System::String(u"presentation.pptx");

// Buat presentasi baru
auto presentation = System::MakeObject<Presentation>();

// Baca konten file SVG
auto svgContent = File::ReadAllText(svgFileName);

// Buat objek SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Dapatkan ukuran slide
auto slideSize = presentation->get_SlideSize()->get_Size();

// Konversi gambar SVG menjadi grup bentuk dan skala ke ukuran slide
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Simpan presentasi dalam format PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Tambahkan Gambar sebagai EMF ke Slide**
Aspose.Slides untuk C++ memungkinkan Anda menghasilkan gambar EMF dari lembar kerja Excel dengan Aspose.Cells dan menambahkannya ke slide presentasi. 

Kode contoh C++ berikut menunjukkan cara melakukannya:

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells untuk C++ harus diinisialisasi sebelum jenis apa pun digunakannya.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Render lembar kerja sebagai EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells mengembalikan halaman yang dirender sebagai buffer, yang kemudian Aspose.Slides tambahkan sebagai gambar.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **Ganti Gambar dalam Koleksi Gambar**

Aspose.Slides memungkinkan Anda mengganti gambar yang disimpan dalam koleksi gambar presentasi, termasuk gambar yang digunakan oleh bentuk slide. Bagian ini menjelaskan beberapa cara memperbarui gambar dalam koleksi. Anda dapat mengganti gambar dengan data byte mentah, instance [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/), atau gambar lain yang sudah ada dalam koleksi.

1. Muat file presentasi yang berisi gambar menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Muat gambar baru dari file ke dalam array byte.
1. Ganti gambar target dengan gambar baru menggunakan array byte.
1. Pada pendekatan kedua, muat gambar ke dalam objek [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) dan ganti gambar target dengan objek tersebut.
1. Pada pendekatan ketiga, ganti gambar target dengan gambar yang sudah ada dalam koleksi gambar presentasi.
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Instansiasi kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Cara pertama.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Cara kedua.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Cara ketiga.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Simpan presentasi ke file.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

Dengan konverter gratis [Text to GIF](https://products.aspose.app/slides/id/text-to-gif) dari Aspose, Anda dapat dengan mudah menganimasikan teks dan membuat GIF dari teks. 

{{% /alert %}}

## **FAQ**

**Apakah resolusi gambar asli tetap utuh setelah penyisipan?**

Ya. Piksel sumber dipertahankan, tetapi tampilan akhir tergantung pada bagaimana [picture](/slides/id/cpp/picture-frame/) diskalakan pada slide dan kompresi apa pun yang diterapkan saat menyimpan.

**Apa cara terbaik untuk mengganti logo yang sama di puluhan slide sekaligus?**

Tempatkan logo pada slide master atau tata letak dan ganti di koleksi gambar presentasi—pembaruan akan menyebar ke semua elemen yang menggunakan sumber daya tersebut.

**Apakah SVG yang disisipkan dapat dikonversi menjadi bentuk yang dapat diedit?**

Ya. Anda dapat mengonversi SVG menjadi grup bentuk, setelah itu bagian individu dapat diedit dengan properti bentuk standar.

**Bagaimana saya dapat mengatur gambar sebagai latar belakang untuk beberapa slide sekaligus?**

[Assign the image as the background](/slides/id/cpp/presentation-background/) pada slide master atau tata letak yang relevan—setiap slide yang menggunakan master/tata letak tersebut akan mewarisi latar belakang.

**Bagaimana cara mencegah presentasi menjadi terlalu besar karena banyak gambar?**

Gunakan kembali satu sumber daya gambar daripada duplikat, pilih resolusi yang wajar, terapkan kompresi saat menyimpan, dan simpan grafik yang berulang pada master bila perlu.