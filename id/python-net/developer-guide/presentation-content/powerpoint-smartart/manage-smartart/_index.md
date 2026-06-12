---
title: Kelola SmartArt dalam Presentasi PowerPoint Menggunakan Python
linktitle: Kelola SmartArt
type: docs
weight: 10
url: /id/python-net/manage-smartart/
keywords:
- SmartArt
- teks dari SmartArt
- tipe tata letak
- properti tersembunyi
- diagram organisasi
- diagram organisasi gambar
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara membuat dan mengedit SmartArt PowerPoint dengan Aspose.Slides untuk Python via .NET menggunakan contoh kode yang jelas yang mempercepat desain slide dan otomatisasi."
---
## **Gambaran Umum**

SmartArt adalah diagram PowerPoint yang dibuat dari node, bentuk node, dan tata letak. Dengan Aspose.Slides untuk Python via .NET, Anda dapat membuat SmartArt, membaca teks dari node-nya, mengubah tata letaknya, memeriksa node tersembunyi, mengkonfigurasi tata letak diagram organisasi, dan membuat diagram organisasi gambar.

## **Mendapatkan Teks dari Objek SmartArt**

Sebuah node SmartArt dapat berisi satu atau lebih bentuk. Untuk membaca teks yang terlihat, iterasi melalui [SmartArt.all_nodes](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartart/all_nodes/), kemudian baca [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) yang dikembalikan oleh [SmartArtShape.text_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartartshape/text_frame/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **Mengubah Tipe Tata Letak Objek SmartArt**

Tata letak SmartArt mengontrol bagaimana node diatur dan terhubung. Contoh berikut membuat objek SmartArt dengan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, mengubahnya menjadi nilai `BASIC_PROCESS`, dan menyimpan presentasi.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Memeriksa Apakah Node SmartArt Tersembunyi**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartartnode/is_hidden/) menunjukkan apakah node disembunyikan dalam model data SmartArt. Node tersembunyi dapat ada dalam struktur meskipun tata letak yang dipilih tidak menampilkannya sebagai elemen diagram yang terlihat.

Contoh berikut menambahkan node ke objek SmartArt yang menggunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` dan memeriksa status tersembunyi node tersebut.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mendapatkan atau Menetapkan Tata Letak Diagram Organisasi**

Untuk diagram SmartArt yang menggunakan tata letak diagram organisasi, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) menentukan bagaimana node anak diatur di bawah node induk. Misalnya, Anda dapat mengatur node anak menggantung dari kiri, kanan, atau kedua sisi, tergantung pada [OrganizationChartLayoutType](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/organizationchartlayouttype/) yang dipilih.

Contoh berikut membuat diagram organisasi dan menetapkan tata letak untuk node pertama ke nilai [OrganizationChartLayoutType](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Membuat Diagram Organisasi Gambar**

Diagram organisasi gambar adalah tata letak SmartArt yang dirancang untuk diagram hierarki yang menyertakan placeholder gambar. Gunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` saat menambahkan objek SmartArt ke slide.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah SmartArt mendukung pencerminan atau pembalikan untuk bahasa RTL?**

Ya. Properti [SmartArt.is_reversed](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartart/is_reversed/) mengubah arah diagram dari kiri-ke-kanan ke kanan-ke-kiri, atau sebaliknya, ketika tata letak SmartArt yang dipilih mendukung pembalikan.

**Bagaimana saya dapat menyalin SmartArt ke slide yang sama atau ke presentasi lain sambil mempertahankan format?**

Anda dapat [mengkloning bentuk SmartArt](/slides/id/python-net/shape-manipulations/) dengan [ShapeCollection.add_clone](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_clone/) atau [mengkloning seluruh slide](/slides/id/python-net/clone-slides/) yang berisi SmartArt. Kedua pendekatan tersebut mempertahankan ukuran, posisi, dan format.

**Bagaimana cara saya merender SmartArt ke gambar raster untuk pratinjau atau ekspor web?**

[Render slide](/slides/id/python-net/convert-powerpoint-to-png/) atau seluruh presentasi ke PNG atau JPEG. SmartArt dirender sebagai bagian dari slide.

**Bagaimana saya dapat menemukan objek SmartArt tertentu pada slide jika ada beberapa?**

Tetapkan nilai [Shape.alternative_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/alternative_text/) atau [Shape.name](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/name/) yang khas pada bentuk SmartArt, cari nilai tersebut di [Slide.shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/shapes/), dan kemudian pastikan bahwa bentuk yang cocok adalah [SmartArt](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartart/).