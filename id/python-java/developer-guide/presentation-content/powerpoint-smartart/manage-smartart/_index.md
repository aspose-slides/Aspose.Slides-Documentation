---
title: Kelola SmartArt dalam Presentasi PowerPoint Menggunakan Python
linktitle: Kelola SmartArt
type: docs
weight: 10
url: /id/python-java/manage-smartart/
keywords:
- SmartArt
- Teks SmartArt
- tipe tata letak
- properti tersembunyi
- diagram organisasi
- diagram organisasi gambar
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara membuat dan mengedit SmartArt PowerPoint dengan Aspose.Slides untuk Python via Java menggunakan contoh kode yang jelas yang mempercepat desain slide dan otomatisasi."
---
## **Gambaran Umum**

SmartArt adalah diagram PowerPoint yang dibuat dari node, bentuk node, dan tata letak. Dengan Aspose.Slides untuk Python via Java, Anda dapat membuat SmartArt, membaca teks dari node-nya, mengubah tata letaknya, memeriksa node tersembunyi, mengonfigurasi tata letak diagram organisasi, dan membuat diagram organisasi berbasis gambar.

## **Mengambil Teks dari Objek SmartArt**

Sebuah node SmartArt dapat berisi satu atau lebih bentuk. Untuk membaca teks yang terlihat, iterasi melalui [SmartArt.getAllNodes](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/#getAllNodes), kemudian baca [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) yang dikembalikan oleh [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartshape/#getTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape

        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **Mengubah Tipe Tata Letak Objek SmartArt**

Tata letak SmartArt mengontrol cara node diatur dan terhubung. Contoh berikut membuat objek SmartArt dengan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, mengubahnya menjadi nilai `BasicProcess`, dan menyimpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Memeriksa Apakah Node SmartArt Tersembunyi**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartnode/#isHidden) menunjukkan apakah node tersembunyi dalam model data SmartArt. Node tersembunyi dapat ada dalam struktur meskipun tata letak yang dipilih tidak menampilkannya sebagai elemen diagram yang terlihat.

Contoh berikut menambahkan node ke objek SmartArt yang menggunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` dan memeriksa status tersembunyi node tersebut.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mendapatkan atau Menetapkan Tata Letak Diagram Organisasi**

Untuk diagram SmartArt yang menggunakan tata letak diagram organisasi, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) dan [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) mendefinisikan bagaimana node anak diatur di bawah node induk. Misalnya, Anda dapat mengatur node anak agar menggantung dari kiri, kanan, atau kedua sisi, tergantung pada [OrganizationChartLayoutType](https://reference.aspose.com/slides/id/python-java/aspose.slides/organizationchartlayouttype/) yang dipilih.

Contoh berikut membuat diagram organisasi dan mengatur tata letak untuk node pertama ke nilai [OrganizationChartLayoutType](https://reference.aspose.com/slides/id/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Membuat Diagram Organisasi Gambar**

Diagram organisasi gambar adalah tata letak SmartArt yang dirancang untuk diagram hierarki yang menyertakan placeholder gambar. Gunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` saat menambahkan objek SmartArt ke slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah SmartArt mendukung pencerminan atau pembalikan untuk bahasa RTL?**

Ya. Metode [SmartArt.setReversed](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/#setReversed) mengubah arah diagram dari kiri-ke-kanan menjadi kanan-ke-kiri, atau sebaliknya, ketika tata letak SmartArt yang dipilih mendukung pembalikan.

**Bagaimana cara menyalin SmartArt ke slide yang sama atau ke presentasi lain sambil mempertahankan format?**

Anda dapat [mengkloning bentuk SmartArt](/slides/id/python-java/shape-manipulations/) dengan [ShapeCollection.addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addClone) atau [mengkloning seluruh slide](/slides/id/python-java/clone-slides/) yang berisi SmartArt. Kedua pendekatan menjaga ukuran, posisi, dan format.

**Bagaimana cara merender SmartArt menjadi gambar raster untuk pratinjau atau ekspor web?**

[Render slide](/slides/id/python-java/convert-powerpoint-to-png/) atau seluruh presentasi ke PNG atau JPEG. SmartArt dirender sebagai bagian dari slide.

**Bagaimana saya dapat menemukan objek SmartArt tertentu pada slide jika ada beberapa?**

Tetapkan nilai [Shape.getAlternativeText](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getAlternativeText) atau [Shape.getName](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getName) yang khas pada bentuk SmartArt, cari nilai tersebut dalam [BaseSlide.getShapes](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/#getShapes), kemudian periksa apakah bentuk yang cocok adalah [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/).