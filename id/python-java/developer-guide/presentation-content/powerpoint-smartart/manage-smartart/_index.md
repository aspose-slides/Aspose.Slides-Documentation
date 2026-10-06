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
- bagan organisasi
- bagan organisasi bergambar
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara membuat dan mengedit SmartArt PowerPoint dengan Aspose.Slides untuk Python melalui Java menggunakan contoh kode yang jelas yang mempercepat desain slide dan otomatisasi."
---
## **Ikhtisar**

SmartArt adalah diagram PowerPoint yang dibuat dari node, bentuk node, dan tata letak. Dengan Aspose.Slides untuk Python melalui Java, Anda dapat membuat SmartArt, membaca teks dari node-nya, mengubah tata letaknya, memeriksa node tersembunyi, mengonfigurasi tata letak bagan organisasi, dan membuat bagan organisasi bergambar.

## **Dapatkan Teks dari Objek SmartArt**

Sebuah node SmartArt dapat berisi satu atau lebih bentuk. Untuk membaca teks dari bentuk node, iterasi melalui [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes), kemudian baca [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) yang dikembalikan oleh [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame).

Contoh ini memerlukan presentasi dengan setidaknya satu slide dan objek SmartArt sebagai bentuk pertama pada slide tersebut. Ia mencetak setiap frame teks yang tersedia ke konsol.

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

## **Ubah Tipe Tata Letak Objek SmartArt**

Tata letak SmartArt mengontrol bagaimana node diatur dan terhubung. Contoh berikut membuat objek SmartArt dengan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, mengubahnya menjadi nilai `BasicProcess`, dan menyimpan presentasi. Posisi dan ukuran yang diberikan ke [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) diukur dalam poin. Gunakan [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) untuk mengubah tata letak.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Periksa Apakah Node SmartArt Tersembunyi**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) menunjukkan apakah node tersembunyi dalam model data SmartArt. Node yang tersembunyi dapat ada dalam struktur meskipun tata letak yang dipilih tidak menampilkannya sebagai elemen diagram yang terlihat.

Contoh berikut menambahkan node ke objek SmartArt yang menggunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` dan memeriksa status tersembunyi node yang ditambahkan. Ia mencetak pesan jika node tersembunyi dan menyimpan diagram.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dapatkan atau Atur Tata Letak Bagan Organisasi**

Untuk diagram SmartArt yang menggunakan tata letak bagan organisasi, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) dan [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) menentukan bagaimana node anak diatur di bawah node induk. Misalnya, Anda dapat mengatur node anak menggantung dari kiri, kanan, atau kedua sisi, tergantung pada [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) yang dipilih.

Contoh berikut membuat bagan organisasi dan mengatur tata letak untuk node pertama ke nilai [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. Indeks berbasis nol `0` memilih node tingkat atas pertama; node anaknya menggunakan susunan yang dipilih. Presentasi yang telah dimodifikasi kemudian disimpan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Buat Bagan Organisasi Bergambar**

Bagan organisasi bergambar adalah tata letak SmartArt yang dirancang untuk diagram hierarki yang mencakup placeholder gambar. Gunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` saat menambahkan objek SmartArt ke slide. Contoh ini menyimpan diagram dengan placeholder gambar; tidak mengisi placeholder dengan gambar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Konversi Diagram Legacy menjadi Grup Bentuk**

Saat memodernisasi presentasi yang ada, Anda mungkin perlu memperbarui bagan organisasi yang awalnya dibuat di PowerPoint 97–2003. Aspose.Slides merepresentasikan diagram legacy ini sebagai objek [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/). Gunakan [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) untuk mengonversi diagram menjadi grup bentuk sehingga Anda dapat mengedit elemen visual individu. Lihat [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) untuk detail.

Konversi menambahkan grup baru ke koleksi bentuk tanpa menghapus diagram asli. Setelah konversi berhasil, hapus yang asli dengan [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) untuk menghindari konten duplikat. Kumpulkan diagram legacy ke dalam daftar sebelum mengonversinya sehingga penambahan dan penghapusan bentuk tidak mengganggu iterasi.

Contoh berikut membuka sebuah presentasi, mencari setiap slide, mengonversi diagram menjadi grup bentuk, dan menyimpan presentasi yang diperbarui sebagai PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Presentasi yang disimpan berisi grup bentuk yang dapat diedit menggantikan diagram legacy yang dikonversi, tanpa diagram asli yang tersisa di sampingnya. Buka PPTX di PowerPoint untuk mengedit elemen individu dalam setiap grup, seperti teks, isi, atau posisinya.

## **FAQ**

**Apakah SmartArt mendukung pencerminan atau pembalikan untuk bahasa RTL?**

Ya. Metode [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) mengubah arah diagram dari kiri-ke-kanan ke kanan-ke-kiri, atau sebaliknya, ketika tata letak SmartArt yang dipilih mendukung pembalikan.

**Bagaimana saya dapat menyalin SmartArt ke slide yang sama atau ke presentasi lain sambil mempertahankan format?**

Anda dapat [menyalin bentuk SmartArt](/slides/id/python-java/shape-manipulations/) dengan [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) atau [menyalin seluruh slide](/slides/id/python-java/clone-slides/) yang berisi SmartArt. Kedua pendekatan mempertahankan ukuran, posisi, dan format.

**Bagaimana cara saya merender SmartArt ke gambar raster untuk pratinjau atau ekspor web?**

[Merender slide](/slides/id/python-java/convert-powerpoint-to-png/) atau seluruh presentasi ke PNG atau JPEG. SmartArt dirender sebagai bagian dari slide.

**Bagaimana saya dapat menemukan objek SmartArt tertentu pada slide jika ada beberapa?**

Gunakan [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) atau [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) untuk menetapkan teks alternatif atau nama yang khas pada bentuk SmartArt, cari nilai itu di [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes), dan kemudian periksa bahwa bentuk yang cocok adalah [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/).