---
title: Mengonversi Slide Presentasi menjadi Gambar di C++
linktitle: Slide ke Gambar
type: docs
weight: 41
url: /id/cpp/convert-slide/
keywords:
- mengonversi slide
- mengekspor slide
- slide ke gambar
- menyimpan slide sebagai gambar
- slide ke EMF
- slide ke PNG
- slide ke JPEG
- slide ke bitmap
- slide ke TIFF
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Mengonversi slide dari presentasi PPT, PPTX, dan ODP menjadi PNG, JPEG, GIF, TIFF, EMF, dan format gambar lainnya di C++ dengan Aspose.Slides untuk C++."
---
## **Pendahuluan**

Aspose.Slides untuk C++ dapat merender slide individu dari presentasi PowerPoint dan OpenDocument sebagai PNG, JPEG, GIF, TIFF, dan format gambar lainnya.

Untuk mengonversi slide menjadi gambar, ikuti langkah-langkah berikut:

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Pilih slide yang ingin Anda render.
3. Jika diperlukan, konfigurasikan rendering dengan kelas [RenderingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/renderingoptions/) atau [TiffOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/).
4. Panggil metode [ISlide::GetImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/getimage/). Metode ini mengembalikan objek [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/).
5. Panggil metode [IImage::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/save/) dan tentukan format keluaran dengan nilai [ImageFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/imageformat/).

## **Konversi Slide ke Gambar PNG**

Konversi paling sederhana menggunakan pengaturan rendering default. Objek [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) yang dihasilkan dapat diproses dalam memori atau disimpan ke file.

Contoh C++ berikut merender slide pertama dan menyimpannya sebagai gambar PNG:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Konversi Slide ke Gambar dengan Ukuran Kustom**

Gunakan overload [ISlide::GetImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/getimage/) yang menerima nilai [Size](https://reference.aspose.com/slides/id/cpp/system.drawing/size/) untuk merender slide dengan dimensi piksel yang tepat.

Contoh berikut membuat gambar JPEG 1820 × 1040:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Konversi Slide dengan Catatan dan Komentar ke Gambar**

Secara default, gambar slide tidak menyertakan catatan atau komentar. Tetapkan objek [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/notescommentslayoutingoptions/) ke metode [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) untuk mengontrol di mana catatan dan komentar muncul.

Contoh berikut menempatkan catatan terpotong di bawah slide dan komentar di sebelah kanannya:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
Untuk konversi slide-ke-gambar, jangan atur metode [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) ke [BottomFull](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/notespositions/). Catatan dapat berisi lebih banyak teks daripada ukuran gambar tetap yang dapat menampungnya. Gunakan [BottomTruncated](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/notespositions/) sebagai gantinya.
{{% /alert %}}

## **Konversi Slide ke Gambar Menggunakan Opsi TIFF**

Kelas [TiffOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/) memungkinkan Anda mengontrol ukuran, resolusi, dan properti lainnya dari gambar TIFF yang dirender.

Contoh berikut merender slide pertama sebagai gambar TIFF 2160 × 2880 pada 300 DPI:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Konversi Semua Slide ke Gambar**

Iterasikan koleksi slide untuk mengonversi seluruh presentasi menjadi serangkaian gambar. Slide tersembunyi disertakan kecuali Anda secara eksplisit melewatkannya.

Contoh berikut merender setiap slide sebagai gambar JPEG dengan faktor skala horizontal dan vertikal sebesar 2:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Buat Output Enhanced Metafile**

Enhanced Metafile (EMF) berguna ketika grafik berbasis vektor harus dipertukarkan dengan Microsoft Office atau aplikasi Windows lainnya yang mendukung metafile Windows. Tidak seperti gambar berbasis piksel, EMF dapat mempertahankan operasi menggambar vektor yang dapat diskalakan tanpa kehilangan ketajaman yang sama. Namun, EMF terutama merupakan format kompatibilitas untuk aplikasi dengan dukungan metafile Windows, bukan format pertukaran universal. Selain itu, konten slide yang kompleks, seperti gambar bitmap dan beberapa efek, dapat disimpan sebagai elemen raster di dalam kontainer metafile vektor.

### **Ekspor Slide ke EMF**

Metode [ISlide::WriteAsEmf](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/writeasemf/) menulis sebuah [ISlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/) ke aliran target dalam format EMF. Contoh berikut memuat presentasi, memilih slide pertama, dan menulisnya ke aliran file EMF:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

Pemanggil memiliki aliran yang diteruskan ke [ISlide::WriteAsEmf](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/writeasemf/) dan harus menutup atau membuangnya. Aspose.Slides menulis pada posisi saat ini dari aliran dan membiarkannya tetap terbuka.

### **Konversi Gambar SVG ke EMF dan Tambahkan ke Presentasi**

Gunakan [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/id/cpp/aspose.slides/isvgimage/writeasemf/) untuk mengonversi konten SVG ke EMF. Byte yang dihasilkan dapat ditambahkan ke presentasi melalui [IImageCollection::AddImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimagecollection/addimage/) dan ditempatkan pada slide dengan [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/addpictureframe/).

Contoh berikut membuat [SvgImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/svgimage/) dari markup SVG, mengonversinya menjadi EMF dalam memori, menyisipkan metafile pada slide pertama, dan menyimpan presentasi:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/id/cpp/aspose.slides/isvgimage/writeasemf/) tidak mengambil kepemilikan aliran tujuan. Setelah menulis, posisi aliran berada di akhir data yang dihasilkan. Contoh memanggil [MemoryStream::ToArray](https://reference.aspose.com/slides/id/cpp/system.io/memorystream/toarray/) untuk mendapatkan buffer lengkap terlepas dari posisi aliran saat ini, kemudian mengirimkan array byte tersebut ke [IImageCollection::AddImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimagecollection/addimage/). Jaga aliran tetap terbuka sampai konsumen selesai membacanya, dan tutup setelahnya.

Pembuatan EMF tersedia pada sistem operasi yang didukung oleh Aspose.Slides untuk C++, namun rendering dapat berbeda antar platform ketika font atau ketergantungan grafis native tidak tersedia. Instal font yang digunakan oleh konten sumber atau konfigurasikan substitusi yang sesuai, ikuti [platform requirements](/slides/id/cpp/system-requirements/) untuk Aspose.Slides untuk C++, dan validasi hasilnya di aplikasi tujuan yang mengonsumsi EMF. Aplikasi Linux dan macOS sering memiliki dukungan yang terbatas atau tidak konsisten untuk menampilkan dan menyunting metafile Windows.

## **Render Emoji Berwarna**

{{% alert title="Note" color="info" %}}
Untuk merender emoji berwarna dengan benar saat mengonversi slide presentasi menjadi gambar, font emoji yang digunakan dalam presentasi harus diinstal dan tersedia di sistem yang melakukan konversi. Misalnya, jika presentasi menggunakan **Segoe UI Emoji** dan font ini tidak ada, emoji dapat muncul dalam monokrom pada gambar output.
{{% /alert %}}

## **FAQ**

**Apakah Aspose.Slides mendukung rendering slide dengan animasi?**

Tidak. Metode [ISlide::GetImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/getimage/) merender gambar statis dari slide dan tidak mengekspor animasi.

**Apakah slide tersembunyi dapat diekspor sebagai gambar?**

Ya. Slide tersembunyi dapat dirender seperti slide biasa. Sertakan mereka dalam loop pemrosesan, seperti yang ditunjukkan pada contoh di atas.

**Apakah bayangan dan efek lainnya dipertahankan dalam gambar slide?**

Ya. Aspose.Slides merender bayangan, transparansi, dan efek grafis lain yang didukung dalam gambar slide.