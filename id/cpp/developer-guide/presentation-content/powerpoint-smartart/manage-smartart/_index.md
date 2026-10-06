---
title: Mengelola SmartArt dalam Presentasi PowerPoint Menggunakan C++
linktitle: Kelola SmartArt
type: docs
weight: 10
url: /id/cpp/manage-smartart/
keywords:
- SmartArt
- Teks SmartArt
- jenis tata letak
- properti tersembunyi
- diagram organisasi
- diagram organisasi gambar
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara membuat dan mengedit SmartArt PowerPoint dengan Aspose.Slides untuk C++ menggunakan contoh kode yang jelas yang mempercepat desain slide dan otomatisasi."
---
## **Overview**

SmartArt adalah diagram PowerPoint yang dibuat dari node, bentuk node, dan tata letak. Dengan Aspose.Slides untuk C++, Anda dapat membuat SmartArt, membaca teks dari node‑nya, mengubah tata letaknya, memeriksa node tersembunyi, mengonfigurasi tata letak diagram organisasi, dan membuat diagram organisasi bergambar.

## **Get Text from a SmartArt Object**

Sebuah node SmartArt dapat berisi satu atau lebih bentuk. Untuk membaca teks dari bentuk‑bentuk node, iterasikan melalui [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/), lalu baca [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) yang dikembalikan oleh [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/).

Contoh ini memerlukan presentasi dengan setidaknya satu slide dan objek SmartArt sebagai bentuk pertama pada slide tersebut. Ia mencetak setiap bingkai teks yang tersedia ke konsol.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **Change the Layout Type of a SmartArt Object**

Tata letak SmartArt mengontrol bagaimana node disusun dan dihubungkan. Contoh berikut membuat objek SmartArt dengan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, mengubahnya menjadi nilai `BasicProcess`, dan menyimpan presentasi. Posisi dan ukuran yang diberikan ke [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) diukur dalam poin. Gunakan [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) untuk mengubah tata letak.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Check Whether a SmartArt Node Is Hidden**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) menunjukkan apakah node tersembunyi dalam model data SmartArt. Node tersembunyi dapat ada dalam struktur meskipun tata letak yang dipilih tidak menampilkannya sebagai elemen diagram yang terlihat.

Contoh berikut menambahkan node ke objek SmartArt yang menggunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` dan memeriksa status tersembunyi node yang ditambahkan. Ia mencetak pesan bila node tersembunyi dan menyimpan diagram.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Get or Set the Organization Chart Layout**

Untuk diagram SmartArt yang menggunakan tata letak diagram organisasi, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) dan [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) menentukan bagaimana node anak diatur di bawah node induk. Misalnya, Anda dapat mengatur node anak agar menggantung di kiri, kanan, atau kedua sisi, tergantung pada [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) yang dipilih.

Contoh berikut membuat diagram organisasi dan mengatur tata letak untuk node pertama menjadi nilai [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`. Indeks berbasis nol `0` memilih node tingkat atas pertama; node anaknya menggunakan pengaturan yang dipilih. Presentasi yang dimodifikasi kemudian disimpan.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Create a Picture Organization Chart**

Diagram organisasi bergambar adalah tata letak SmartArt yang dirancang untuk diagram hierarki yang menyertakan placeholder gambar. Gunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` saat menambahkan objek SmartArt ke slide. Contoh ini menyimpan diagram dengan placeholder gambar; placeholder tidak diisi dengan gambar.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Convert Legacy Diagrams to Groups of Shapes**

Saat memodernisasi presentasi yang ada, Anda mungkin perlu memperbarui diagram organisasi yang dibuat di PowerPoint 97–2003. Aspose.Slides merepresentasikan diagram lama ini sebagai objek [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/). Gunakan [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/) untuk mengonversi diagram menjadi grup bentuk sehingga Anda dapat menyunting elemen visual secara individual. Lihat [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/) untuk detailnya.

Konversi menambahkan grup baru ke koleksi bentuk tanpa menghapus diagram asli. Setelah konversi berhasil, hapus yang asli dengan [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) untuk menghindari duplikat konten. Kumpulkan diagram lama ke dalam vektor sebelum mengonversinya sehingga penambahan dan penghapusan bentuk tidak mengganggu iterasi.

Contoh berikut membuka presentasi, mencari setiap slide, mengonversi diagram menjadi grup bentuk, dan menyimpan presentasi yang diperbarui sebagai PPTX.

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Presentasi yang disimpan berisi grup bentuk yang dapat disunting menggantikan diagram lama yang telah dikonversi, tanpa diagram asli yang tersisa di sampingnya. Buka file PPTX di PowerPoint untuk menyunting elemen individual dalam setiap grup, seperti teks, isian, atau posisinya.

## **FAQ**

**Does SmartArt support mirroring or reversing for RTL languages?**

Ya. Metode [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) mengubah arah diagram dari kiri‑ke‑kanan ke kanan‑ke‑kiri, atau sebaliknya, ketika tata letak SmartArt yang dipilih mendukung pembalikan.

**How can I copy SmartArt to the same slide or to another presentation while preserving formatting?**

Anda dapat [clone the SmartArt shape](/slides/id/cpp/shape-manipulations/) dengan [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) atau [clone the whole slide](/slides/id/cpp/clone-slides/) yang berisi SmartArt. Kedua pendekatan mempertahankan ukuran, posisi, dan pemformatan.

**How do I render SmartArt to a raster image for preview or web export?**

[Render the slide](/slides/id/cpp/convert-powerpoint-to-png/) atau seluruh presentasi ke PNG atau JPEG. SmartArt dirender sebagai bagian dari slide.

**How can I find a specific SmartArt object on a slide if there are several?**

Tetapkan teks alternatif yang unik dengan [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) atau nilai [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) pada bentuk SmartArt, cari nilai tersebut di [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/), lalu pastikan bentuk yang cocok adalah [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/).