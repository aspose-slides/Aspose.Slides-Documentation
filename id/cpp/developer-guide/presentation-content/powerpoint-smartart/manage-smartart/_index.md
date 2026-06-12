---
title: Kelola SmartArt dalam Presentasi PowerPoint Menggunakan C++
linktitle: Kelola SmartArt
type: docs
weight: 10
url: /id/cpp/manage-smartart/
keywords:
- SmartArt
- Teks SmartArt
- tipe tata letak
- properti tersembunyi
- diagram organisasi
- diagram organisasi bergambar
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara membuat dan mengedit SmartArt PowerPoint dengan Aspose.Slides untuk C++ menggunakan contoh kode yang jelas dan mempercepat desain serta otomatisasi slide."
---
## **Ikhtisar**

SmartArt adalah diagram PowerPoint yang dibuat dari node, bentuk node, dan tata letak. Dengan Aspose.Slides untuk C++, Anda dapat membuat SmartArt, membaca teks dari node‑nya, mengubah tata letaknya, memeriksa node tersembunyi, mengonfigurasi tata letak diagram organisasi, dan membuat diagram organisasi bergambar.

## **Dapatkan Teks dari Objek SmartArt**

Sebuah node SmartArt dapat berisi satu atau lebih bentuk. Untuk membaca teks yang terlihat, iterasi melalui [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/smartart/get_allnodes/), kemudian baca [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) yang dikembalikan oleh [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/smartartshape/get_textframe/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **Ubah Tipe Tata Letak Objek SmartArt**

Tata letak SmartArt mengatur bagaimana node disusun dan dihubungkan. Contoh berikut membuat objek SmartArt dengan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, mengubahnya menjadi nilai `BasicProcess`, dan menyimpan presentasi.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Periksa Apakah Node SmartArt Tersembunyi**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) menunjukkan apakah node tersembunyi dalam model data SmartArt. Node tersembunyi dapat ada dalam struktur bahkan ketika tata letak yang dipilih tidak menampilkannya sebagai elemen diagram yang terlihat.

Contoh berikut menambahkan node ke objek SmartArt yang menggunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` dan memeriksa status tersembunyi node tersebut.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Dapatkan atau Atur Tata Letak Diagram Organisasi**

Untuk diagram SmartArt yang menggunakan tata letak diagram organisasi, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) dan [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) menentukan bagaimana node anak diatur di bawah node induk. Misalnya, Anda dapat mengatur node anak menggantung di sebelah kiri, kanan, atau kedua sisi, tergantung pada [OrganizationChartLayoutType](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/organizationchartlayouttype/) yang dipilih.

Contoh berikut membuat diagram organisasi dan mengatur tata letak untuk node pertama ke nilai [OrganizationChartLayoutType](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Buat Diagram Organisasi Bergambar**

Diagram organisasi bergambar adalah tata letak SmartArt yang dirancang untuk diagram hierarki yang mencakup placeholder gambar. Gunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` ketika menambahkan objek SmartArt ke slide.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Apakah SmartArt mendukung pencerminan atau pembalikan untuk bahasa RTL?**

Ya. Metode [SmartArt::set_IsReversed](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/smartart/set_isreversed/) mengubah arah diagram dari kiri-ke-kanan menjadi kanan-ke-kiri, atau sebaliknya, ketika tata letak SmartArt yang dipilih mendukung pembalikan.

**Bagaimana saya dapat menyalin SmartArt ke slide yang sama atau ke presentasi lain sambil mempertahankan pemformatan?**

Anda dapat [menyalin bentuk SmartArt](/slides/id/cpp/shape-manipulations/) dengan [ShapeCollection::AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/shapecollection/addclone/) atau [menyalin seluruh slide](/slides/id/cpp/clone-slides/) yang berisi SmartArt. Kedua pendekatan mempertahankan ukuran, posisi, dan pemformatan.

**Bagaimana saya merender SmartArt ke gambar raster untuk pratinjau atau ekspor web?**

[Render slide](/slides/id/cpp/convert-powerpoint-to-png/) atau seluruh presentasi ke PNG atau JPEG. SmartArt dirender sebagai bagian dari slide.

**Bagaimana saya dapat menemukan objek SmartArt tertentu pada slide jika ada beberapa?**

Tetapkan nilai [Shape::set_AlternativeText](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/set_alternativetext/) atau [Shape::set_Name](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/set_name/) yang khas pada bentuk SmartArt, cari nilai tersebut di [BaseSlide::get_Shapes](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseslide/get_shapes/), lalu periksa bahwa bentuk yang cocok adalah [ISmartArt](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/ismartart/).