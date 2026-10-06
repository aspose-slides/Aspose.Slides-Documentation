---
title: Kelola SmartArt dalam Presentasi PowerPoint Menggunakan Python
linktitle: Kelola SmartArt
type: docs
weight: 10
url: /id/python-net/manage-smartart/
keywords:
- SmartArt
- teks SmartArt
- tipe tata letak
- properti tersembunyi
- bagan organisasi
- bagan organisasi gambar
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara membuat dan mengedit SmartArt PowerPoint dengan Aspose.Slides untuk Python via .NET menggunakan contoh kode yang jelas yang mempercepat desain slide dan otomatisasi."
---
## **Ringkasan**

SmartArt adalah diagram PowerPoint yang dibuat dari node, bentuk node, dan tata letak. Dengan Aspose.Slides for Python via .NET, Anda dapat membuat SmartArt, membaca teks dari node‑nya, mengubah tata letaknya, memeriksa node tersembunyi, mengkonfigurasi tata letak bagan organisasi, dan membuat bagan organisasi dengan gambar.

## **Dapatkan Teks dari Objek SmartArt**

Sebuah node SmartArt dapat berisi satu atau beberapa bentuk. Untuk membaca teks dari bentuk node, iterasi melalui [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/), lalu baca [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) yang dikembalikan oleh [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/).

Contoh ini memerlukan presentasi dengan setidaknya satu slide dan objek SmartArt sebagai bentuk pertama pada slide tersebut. Ini mencetak setiap bingkai teks yang tersedia ke konsol.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **Ubah Tipe Tata Letak Objek SmartArt**

Tata letak SmartArt mengontrol bagaimana node diatur dan dihubungkan. Contoh berikut membuat objek SmartArt dengan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, mengubahnya menjadi nilai `BASIC_PROCESS`, dan menyimpan presentasi. Posisi dan ukuran yang diberikan ke [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) diukur dalam poin. Atur [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) untuk mengubah tata letak.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Periksa Apakah Node SmartArt Tersembunyi**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) menunjukkan apakah node tersembunyi dalam model data SmartArt. Node tersembunyi dapat ada dalam struktur meskipun tata letak yang dipilih tidak menampilkannya sebagai elemen diagram yang terlihat.

Contoh berikut menambahkan node ke objek SmartArt yang menggunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` dan memeriksa status tersembunyi node yang ditambahkan. Ini mencetak pesan jika node tersembunyi dan menyimpan diagram.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **Dapatkan atau Atur Tata Letak Bagan Organisasi**

Untuk diagram SmartArt yang menggunakan tata letak bagan organisasi, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) menentukan bagaimana node anak diatur di bawah node induk. Misalnya, Anda dapat mengatur node anak tergantung pada sisi kiri, kanan, atau kedua sisi, tergantung pada [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) yang dipilih.

Contoh berikut membuat bagan organisasi dan mengatur tata letak untuk node pertama ke nilai [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`. Indeks berbasis nol `0` memilih node tingkat atas pertama; node anaknya menggunakan susunan yang dipilih. Presentasi yang dimodifikasi kemudian disimpan.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Buat Bagan Organisasi Gambar**

Bagan organisasi gambar adalah tata letak SmartArt yang dirancang untuk diagram hierarki yang menyertakan placeholder gambar. Gunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` saat menambahkan objek SmartArt ke slide. Contoh ini menyimpan diagram dengan placeholder gambar; tidak mengisi placeholder dengan gambar.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Ubah Diagram Warisan menjadi Grup Bentuk**

Saat memodernisasi presentasi yang ada, Anda mungkin perlu memperbarui bagan organisasi yang awalnya dibuat di PowerPoint 97–2003. Aspose.Slides merepresentasikan diagram warisan ini sebagai objek [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/). Gunakan [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) untuk mengubah diagram menjadi grup bentuk sehingga Anda dapat mengedit elemen visual individu. Lihat [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) untuk detail.

Konversi menambahkan grup baru ke koleksi bentuk tanpa menghapus diagram asli. Setelah konversi berhasil, hapus yang asli dengan [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) untuk menghindari konten duplikat. Kumpulkan diagram warisan ke dalam daftar sebelum mengonversinya sehingga penambahan dan penghapusan bentuk tidak mengganggu iterasi.

Contoh berikut membuka presentasi, mencari setiap slide, mengonversi diagram menjadi grup bentuk, dan menyimpan presentasi yang diperbarui sebagai PPTX.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

Presentasi yang disimpan berisi grup bentuk yang dapat diedit menggantikan diagram warisan yang telah dikonversi, tanpa diagram asli yang tersisa di sampingnya. Buka PPTX di PowerPoint untuk mengedit elemen individu dalam setiap grup, seperti teks, isi, atau posisinya.

## **FAQ**

**Apakah SmartArt mendukung pencerminan atau pembalikan untuk bahasa RTL?**

Ya. Properti [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) mengubah arah diagram dari kiri-ke-kanan menjadi kanan-ke-kiri, atau sebaliknya, ketika tata letak SmartArt yang dipilih mendukung pembalikan.

**Bagaimana saya dapat menyalin SmartArt ke slide yang sama atau ke presentasi lain sambil mempertahankan pemformatan?**

Anda dapat [mengkloning bentuk SmartArt](/slides/id/python-net/shape-manipulations/) dengan [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) atau [mengkloning seluruh slide](/slides/id/python-net/clone-slides/) yang berisi SmartArt. Kedua pendekatan mempertahankan ukuran, posisi, dan pemformatan.

**Bagaimana saya merender SmartArt ke gambar raster untuk pratinjau atau ekspor web?**

[Render slide](/slides/id/python-net/convert-powerpoint-to-png/) atau seluruh presentasi ke PNG atau JPEG. SmartArt dirender sebagai bagian dari slide.

**Bagaimana saya dapat menemukan objek SmartArt tertentu di slide jika ada beberapa?**

Setel nilai [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) atau [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) yang khas pada bentuk SmartArt, cari nilai tersebut di [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), dan kemudian periksa bahwa bentuk yang cocok adalah [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).