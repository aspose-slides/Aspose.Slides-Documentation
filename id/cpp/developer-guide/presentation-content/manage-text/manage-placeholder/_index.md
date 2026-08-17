---
title: Kelola Placeholder Presentasi dalam C++
linktitle: Kelola Placeholder
type: docs
weight: 10
url: /id/cpp/manage-placeholder/
keywords:
- placeholder
- placeholder teks
- placeholder gambar
- placeholder diagram
- placeholder konten
- teks prompt
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara memeriksa dan mengedit placeholder teks, gambar, diagram, dan konten serta memahami pewarisan placeholder dengan Aspose.Slides untuk C++."
---
## **Gambaran Umum**

Placeholder adalah bentuk yang menyimpan posisi untuk jenis konten tertentu dalam templat presentasi. Contoh umum meliputi placeholder judul, isi, gambar, diagram, dan placeholder konten serbaguna. Tidak seperti bentuk biasa, placeholder dapat mewarisi posisi, ukuran, pemformatan, dan pengaturan lainnya dari slide tata letak atau slide master.

Aspose.Slides mengekspos informasi placeholder melalui metode [IShape::get_Placeholder](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_placeholder/). Metode ini mengembalikan objek [IPlaceholder](https://reference.aspose.com/slides/id/cpp/aspose.slides/iplaceholder/) atau `nullptr` untuk bentuk normal. Gunakan [IPlaceholder::get_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/iplaceholder/get_type/) untuk menentukan apa yang dimaksudkan placeholder tersebut.

Antarmuka bentuk tetap penting setelah Anda mengetahui tipe placeholder:

- Placeholder teks, gambar, diagram, atau konten kosong biasanya direpresentasikan oleh [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/).
- Placeholder gambar yang sudah terisi dapat direpresentasikan oleh [IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/).
- Placeholder diagram yang sudah terisi dapat direpresentasikan oleh [IChart](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichart/).
- Placeholder konten dapat berisi berbagai jenis konten. Periksa baik [IPlaceholder::get_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/iplaceholder/get_type/) maupun antarmuka bentuk runtime alih-alih mengasumsikan setiap placeholder adalah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/iplaceholder/get_type/) menjelaskan peran placeholder; hal itu tidak menjamin tipe runtime bentuk. Selalu lakukan pemeriksaan tipe sebelum mengakses anggota teks, gambar, diagram, tabel, atau media khusus.
{{% /alert %}}

## **Memahami Pewarisan Placeholder**

Placeholder membentuk hierarki:

1. Slide master mendefinisikan gaya yang dapat digunakan kembali dan, dalam beberapa kasus, placeholder pada tingkat master.
2. Slide tata letak mendefinisikan susunan yang digunakan oleh satu atau lebih slide normal dan dapat mewarisi dari master.
3. Slide normal berisi placeholder untuk slide tersebut dan dapat mewarisi dari tata letaknya.

Panggil [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/getbaseplaceholder/) untuk naik satu level dalam hierarki ini. Placeholder slide biasanya mengembalikan placeholder tata letaknya; placeholder tata letak dapat mengembalikan placeholder masternya. Metode ini mengembalikan `nullptr` ketika bentuk tidak memiliki placeholder dasar.

Contoh berikut mencantumkan placeholder pada slide pertama dan melaporkan placeholder dasarnya:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

Menyunting placeholder pada slide normal membuat atau mengubah override lokal untuk slide tersebut. Menyunting tata letak atau master terkait dapat memengaruhi semua slide yang masih mewarisi pengaturan itu. Bentuk lokal biasa tidak memiliki placeholder dasar dan tidak mulai mewarisi hanya karena menempati koordinat yang sama.

## **Ubah Teks dalam Placeholder**

Placeholder judul, judul-terpusat, subjudul, isi, dan teks biasanya mendukung teks. Periksa keberadaan [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) sebelum menggunakan metode [get_TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/get_textframe/)‑nya.

Contoh ini memperbarui placeholder judul pertama pada slide pertama dan menyimpan hasilnya:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

Pola ini menghindari casting placeholder gambar, diagram, tabel, atau media ke [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/). Ia juga mengidentifikasi placeholder berdasarkan tujuan alih‑alih mengandalkan indeks bentuk yang rapuh.

## **Setel Teks Prompt pada Tata Letak**

Teks prompt adalah instruksi pada waktu desain yang ditampilkan dalam placeholder kosong, seperti *Click to add title*. Tetapkan teks prompt khusus pada placeholder tata letak daripada mencoba mengaksesnya melalui koleksi bentuk slide normal. Akses tata letak melalui [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/get_layoutslide/) dan iterasikan [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslide/get_shapes/).

Contoh berikut mengubah prompt judul dan subjudul pada tata letak yang digunakan oleh slide pertama:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

Teks prompt bukan konten slide normal. Ia ditujukan untuk placeholder kosong dalam aplikasi penyuntingan seperti PowerPoint. Setelah pengguna atau program menyediakan konten nyata, prompt tidak lagi ditampilkan. Mengubah prompt juga tidak menggantikan teks yang ada pada slide yang menggunakan tata letak tersebut.

## **Perbarui Placeholder Gambar**

Ada dua kasus yang perlu ditangani:

- Jika placeholder gambar sudah terisi dan direpresentasikan oleh [IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/), ganti gambar melalui [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/get_picture/) dan [ISlidesPicture::set_Image](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidespicture/set_image/).
- Jika masih berupa placeholder kosong, tambahkan frame gambar pada koordinat placeholder dengan [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/addpictureframe/) dan hapus placeholder kosong.

Contoh berikut mendukung kedua kasus dan menyimpan presentasi:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

Pengganti yang dibuat untuk placeholder kosong adalah frame gambar lokal, bukan placeholder baru, karena [IShape::get_Placeholder](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_placeholder/) bersifat read‑only. Ia mempertahankan posisi yang dicadangkan tetapi tidak lagi mewarisi perilaku khusus placeholder. Jika mempertahankan hubungan placeholder penting, persiapkan dan isi placeholder di PowerPoint terlebih dahulu, lalu perbarui [IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/) yang dihasilkan dengan Aspose.Slides.

Untuk transparansi gambar, pemotongan, dan efek khusus gambar lainnya, lihat [Manage Picture Frames](/slides/id/cpp/picture-frame/). Operasi tersebut merupakan milik frame gambar atau isi gambar, bukan metadata placeholder.

## **Bekerja dengan Placeholder Diagram dan Konten**

Placeholder diagram yang sudah terisi dapat direpresentasikan oleh [IChart](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichart/). Contoh ini menemukan diagram tersebut berdasarkan tipe placeholder dan antarmuka runtime, mengubah judulnya, dan menyimpan berkas:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

Placeholder konten umum biasanya memiliki [PlaceholderType::Object](https://reference.aspose.com/slides/id/cpp/aspose.slides/placeholdertype/). Di PowerPoint ia berfungsi sebagai peluncur untuk beberapa tipe konten, termasuk diagram, tabel, diagram, gambar, dan media. Setelah terisi, periksa antarmuka bentuk aktual untuk mengetahui apa yang dikandungnya. Tata letak khusus juga dapat mengekspos [PlaceholderType::Chart](https://reference.aspose.com/slides/id/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/id/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/id/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/id/cpp/aspose.slides/placeholdertype/), atau [PlaceholderType::Diagram](https://reference.aspose.com/slides/id/cpp/aspose.slides/placeholdertype/).

Aspose.Slides tidak mengubah placeholder [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) kosong menjadi [IChart](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichart/) hanya dengan mengubah [IPlaceholder::get_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/iplaceholder/get_type/); tipenya bersifat read‑only. Untuk mengisi area diagram atau konten kosong secara programatik, tambahkan objek yang diperlukan pada koordinat placeholder kemudian hapus placeholder kosong. Contoh berikut melakukan hal itu untuk sebuah diagram:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

Diagram yang ditambahkan adalah diagram lokal biasa. Ia menempati area placeholder tetapi tidak mewarisi dari placeholder tata letak. Gunakan artikel manajemen diagram khusus [chart management articles](/slides/id/cpp/powerpoint-charts/) ketika Anda perlu mengganti kategori, seri, atau data workbook‑nya.

## **Contoh Lengkap: Perbarui Konten Teks atau Gambar**

Contoh end‑to‑end berikut membuka templat, mencari slide pertama untuk placeholder judul atau gambar, memeriksa tipe placeholder dan bentuk, memperbarui konten yang sesuai, dan menyimpan output. Contoh ini sengaja menghindari asumsi indeks bentuk atau casting setiap placeholder ke antarmuka yang sama.

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **Tanya Jawab**

**Apa itu placeholder dasar?**

Placeholder dasar adalah bentuk yang sesuai pada tata letak atau master yang dari situ placeholder lain mewarisi. Gunakan [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/getbaseplaceholder/) untuk mengambilnya. Bentuk lokal biasa mengembalikan `nullptr` karena tidak termasuk dalam hierarki placeholder.

**Apakah saya dapat mengubah semua judul slide dengan menyunting placeholder tata letak?**

Anda dapat mengubah pemformatan atau teks prompt yang diwariskan melalui tata letak, tetapi konten judul yang sudah ada disimpan pada slide normal. Untuk mengganti teks judul sebenarnya di seluruh presentasi, iterasikan slide‑slide dan perbarui setiap placeholder judul.

**Bagaimana cara mengelola placeholder tanggal, nomor slide, header, dan footer?**

Gunakan manajer header dan footer pada tingkat slide, tata letak, master, catatan, atau handout yang sesuai. Lihat [Manage Presentation Header and Footer](/slides/id/cpp/presentation-header-and-footer/) untuk contoh lengkap.