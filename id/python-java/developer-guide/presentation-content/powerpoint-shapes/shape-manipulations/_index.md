---
title: Kelola Bentuk Presentasi di Python via Java
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/python-java/shape-manipulations/
keywords:
- Bentuk PowerPoint
- Bentuk presentasi
- Bentuk pada slide
- Temukan bentuk
- Gandakan bentuk
- Hapus bentuk
- Sembunyikan bentuk
- Ubah urutan bentuk
- Dapatkan ID bentuk interop
- Teks alternatif bentuk
- Titik penyesuaian bentuk
- Penyesuaian bentuk preset
- Geometri bentuk
- Format tata letak bentuk
- Bentuk sebagai SVG
- Bentuk ke SVG
- Selaraskan bentuk
- Balikkan bentuk
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara mengidentifikasi, menyesuaikan, menggandakan, menghapus, menyembunyikan, mengubah urutan, mengekspor, menyelaraskan, dan membalikkan bentuk presentasi dengan Aspose.Slides untuk Python via Java."
---
## **Ringkasan**

Aspose.Slides untuk Python via Java merepresentasikan bentuk pada slide sebagai [ShapeCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/) yang terurut. Koleksi ini sekaligus menjadi tempat Anda menemukan dan memodifikasi bentuk serta sumber urutan tumpukan mereka: indeks `0` adalah bentuk paling belakang, sementara indeks terakhir adalah bentuk paling depan.

Artikel ini mengikuti model tersebut. Pertama dijelaskan cara mengidentifikasi bentuk secara andal dan memodifikasi titik penyesuaian bentuk yang telah ditetapkan, kemudian ditunjukkan cara menggandakan, menghapus, menyembunyikan, dan mengubah urutan bentuk. Bagian akhir mencakup pemformatan tingkat tata letak, ekspor SVG, penyelarasan, dan pengaturan flip. Setiap contoh bersifat independen, sehingga Anda dapat menggunakan hanya operasi yang diperlukan alur kerja Anda.

## **Identifikasi dan Temukan Bentuk**

Indeks koleksi nyaman saat memproses file yang sudah diketahui, tetapi bukan pengenal yang stabil. Menambah, menghapus, atau mengubah urutan bentuk dapat mengubah indeksnya. Pilih pengenal sesuai cara presentasi dibuat dan dipelihara:

- [Nama](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getName) berguna untuk templat yang dikendalikan pengembang dan mudah diperiksa di Panel Seleksi PowerPoint. Nama dapat diedit dan tidak dijamin unik, sehingga tetapkan konvensi penamaan bila kode bergantung padanya.
- [TeksAlternatif](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getAlternativeText) berguna ketika deskripsi aksesibilitas atau tag yang disediakan penulis sudah mengidentifikasi bentuk. Teks ini terlihat oleh pengguna, dapat dilokalkan atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan diam‑diam menggunakan teks aksesibilitas yang berarti sebagai kunci basis data.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getOfficeInteropShapeId) adalah pengenal baca‑saja yang unik dalam satu slide dan sesuai dengan ID bentuk yang dipakai oleh PowerPoint interop. Gunakan bila mengintegrasikan dengan PowerPoint atau ketika Anda memerlukan referensi tak ambigu selama masa hidup sebuah bentuk. Bentuk yang digandakan atau dibuat ulang merupakan bentuk berbeda dan menerima IDnya masing‑masing.

Metode terkait [getUniqueId](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getUniqueId) mengembalikan pengenal dengan ruang lingkup presentasi, tetapi pengenal itu ditujukan untuk add‑in dan dapat dipindahkan. Jangan menganggapnya sebagai kunci eksternal permanen. Jika identitas jangka panjang penting, simpan pemetaan di data aplikasi dan validasikan bahwa bentuk yang diharapkan masih ada.

Contoh berikut mencari berdasarkan nama dengan perbandingan tepat dan melaporkan ID interop berskala slide. Ketika templat tidak berisi bentuk yang diharapkan, kode melaporkan hasil itu alih‑alih melanjutkan dengan objek yang salah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

Saat sebuah operasi spesifik untuk tipe bentuk, periksa tipe sebelum menggunakan anggota tipe‑spesifik. Contoh ini memperbarui teks dan teks alternatif hanya bila objek bernama tersebut adalah sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **Identifikasi dan Modifikasi Penyesuaian Bentuk Praset**

Bentuk geometri preset dapat mengekspos titik penyesuaian yang mengendalikan fitur seperti ukuran sudut, proporsi panah, atau sudut busur. Akses mereka melalui koleksi baca‑saja [GeometryShape.getAdjustments](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometryshape/#getAdjustments). Koleksi itu disediakan oleh bentuk, tetapi setiap [AdjustValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/) berisi nilai yang dapat diubah.

Jangan hanya mengandalkan indeks koleksi tetap. Iterasi melalui penyesuaian dan periksa metode baca‑saja [getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getType), yang nilai [ShapeAdjustmentType](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeadjustmenttype/)‑nya menjelaskan apa yang dikendalikan penyesuaian. Metode baca‑saja [getName](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getName) memberikan informasi identifikasi tambahan dan sangat berguna ketika preset berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

Gunakan metode nilai yang sesuai dengan arti penyesuaian:

| Tipe Penyesuaian | Tujuan | Nilai yang diubah |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Ukuran sudut membulat | [setRawValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Ketebalan ekor panah | [setRawValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Panjang kepala panah | [setRawValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Lebar kepala panah | [setRawValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Sudut mulai pizza atau busur | [setAngleValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | Sudut akhir pizza atau busur | [setAngleValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getType) dan [getName](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getName) mengembalikan informasi baca‑saja. [getRawValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getRawValue) dan [setRawValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#setRawValue) bekerja dengan integer dalam satuan geometri native preset, sementara [getAngleValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getAngleValue) dan [setAngleValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#setAngleValue) bekerja dengan sudut dalam derajat. Jumlah, urutan, arti, dan rentang nilai yang sah bergantung pada [ShapeType](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometryshape/#getShapeType) preset. Nilai yang sah untuk satu preset mungkin tidak sah atau menghasilkan efek berbeda pada preset lain.

Ketika [getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getType) mengembalikan [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeadjustmenttype/#Custom), API tidak mengenali makna semantik standar. Periksa [getName](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getName), tipe preset, dan nilai yang ada, dan biarkan penyesuaian tidak berubah kecuali arti dan rentang yang diharapkan diketahui. Bahkan untuk tipe yang dikenali, periksa apakah tipe yang sama muncul lebih dari sekali sebelum memilih nilai. Artikel [Connector](/slides/id/python-java/connector/) menunjukkan situasi ini dengan penyesuaian bengkok penghubung.

Contoh lengkap berikut membuat versi default dan versi yang dimodifikasi dari tiga bentuk preset. Ia mengiterasi setiap penyesuaian, melaporkan namanya dan tipenya, mengubah nilai yang berkaitan dengan ukuran melalui [setRawValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#setRawValue), mengubah sudut melalui [setAngleValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#setAngleValue), dan menyimpan hasilnya. Kolom kiri mempertahankan geometri default; kolom kanan menunjukkan persegi panjang bulat yang disesuaikan, panah empat arah, dan pizza.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Menambahkan header untuk kolom bentuk default dan yang disesuaikan.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Memeriksa tipe semantik sebelum mengubah nilai membuat kode eksplisit tentang niatnya dan menghindari asumsi bahwa indeks koleksi tertentu memiliki arti yang sama pada bentuk preset yang berbeda.

## **Modifikasi Koleksi Bentuk**

Metode tambah, gandakan, hapus, dan ubah urutan beroperasi pada koleksi secara langsung. Jika sebuah operasi mengubah jumlah atau urutan bentuk, jangan terus mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Gandakan Sebuah Bentuk**

[addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addClone) membuat salinan independen dan menambahkannya ke koleksi target. [insertClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#insertClone) juga membuat salinan tetapi menempatkannya pada indeks urutan‑z yang ditentukan. Overload yang menerima koordinat memindahkan klon tanpa mengubah ukurannya; overload dengan lebar dan tinggi dapat mengubah ukuran juga.

Contoh ini membuat slide tujuan, menggandakan persegi panjang berlabel ke depan, dan menyisipkan klon kedua ke belakang. Perubahan pada salah satu klon tidak memodifikasi bentuk sumber.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Penggandaan menyalin konten dan pemformatan bentuk, termasuk nama dan teks alternatifnya. Berikan pengenal logis baru pada klon bila nilai‑nilai tersebut harus unik. Sumber daya yang digunakan oleh bentuk kompleks ditangani oleh presentasi, tetapi klon tetap menjadi item koleksi baru dengan identitas bentuk baru.

### **Hapus Bentuk**

[remove](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#remove) menghapus objek bentuk tertentu dari koleksinya. Saat menghapus beberapa kecocokan selama iterasi berindeks, telusuri dari akhir sehingga setiap indeks yang tersisa tetap valid.

Contoh ini menghapus setiap bentuk dengan nama yang ditentukan. Ia membaca bentuk pada indeks saat ini, bukan item koleksi tetap, dan tidak melakukan cast yang tidak perlu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Setelah penghapusan, jumlah bentuk dan indeks bentuk‑bentuk berikutnya berubah. Referensi ke bentuk yang tidak terpengaruh tetap lebih dapat diandalkan daripada indeks yang disimpan. Pertimbangkan juga penghubung, animasi, dan fitur presentasi lain yang mungkin merujuk ke objek yang dihapus; menghapus bentuk yang terlihat dapat mengubah lebih dari sekadar tampilan slide.

### **Sembunyikan Sebuah Bentuk**

Menetapkan [Hidden](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#setHidden) ke `True` menjaga bentuk tetap berada di koleksi tetapi mencegahnya muncul dalam tayangan slide normal. Indeks, pemformatan, dan kontennya tetap tersedia bagi kode, sehingga menyembunyikan cocok untuk elemen opsional yang mungkin dipulihkan nanti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Menyembunyikan bukan berarti menghapus atau mengamankan. Objek masih dapat ditemukan dan ditampilkan kembali oleh pengguna atau kode, dan tetap menjadi bagian dari berkas presentasi.

### **Ubah Urutan‑Z**

Bentuk yang saling tumpang tindih digambar sesuai urutan koleksi. [reorder](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#reorder) memindahkan bentuk yang ada ke indeks target tanpa menggandakannya. Indeks `0` adalah belakang; [size](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#size) minus satu adalah depan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Persegi panjang dibuat pertama dan awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Selesaikan urutan‑z setelah menambah atau menggandakan semua bentuk terkait, karena operasi tersebut menambah atau menyisipkan item koleksi baru dan dapat mengubah tumpukan yang diharapkan.

## **Periksa Bentuk pada Slide Tata Letak**

Slide normal, slide tata letak, dan slide master memiliki koleksi bentuk terpisah. Bentuk dalam koleksi tata letak bukan objek yang sama dengan bentuk yang diposisikan serupa pada slide normal. Periksa bentuk tata letak ketika Anda perlu memahami atau mengubah pemformatan yang disediakan oleh tata letak.

Contoh berikut membaca setiap [FillFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getFillFormat) dan [LineFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getLineFormat) pada bentuk tata letak tanpa mengasumsikan bahwa setiap bentuk adalah sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

Menyunting tata letak dapat memengaruhi banyak slide yang menggunakannya. Sebelum mengubah bentuk tata letak, tentukan apakah slide normal mewarisi objek tersebut atau memiliki penimpaan lokal, dan uji setiap slide yang memakai tata letak itu.

## **Ekspor Bentuk ke SVG**

Metode `writeAsSvg` pada [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/) menulis konten ter‑render satu bentuk ke aliran. Hasilnya berisi bentuk tersebut, bukan latar belakang slide keseluruhan atau bentuk tetangga.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Pertahankan presentasi terbuka saat merender. Output bergantung pada pemformatan bentuk serta sumber daya seperti font dan gambar. Jika Anda memerlukan seluruh komposisi, ekspor slide bukan bentuk individu. Pemanggil memegang aliran dan harus menutupnya.

## **Menyelaraskan Bentuk**

Overload [SlideUtil.alignShapes](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideutil/#alignShapes) menyelaraskan semua bentuk atau indeks koleksi terpilih. [ShapesAlignmentType](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Atur `align_to_slide` ke `True` untuk menggunakan tepi slide; atur ke `False` untuk menyelaraskan bentuk terpilih relatif satu sama lain.

Contoh ini menyelaraskan tiga bentuk ke tepi atas slide. Referensi bentuk yang dikembalikan dikonversi ke indeks mereka saat ini tepat sebelum penyelarasan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Penyelarasan mengubah posisi, bukan urutan‑z. Penyelarasan relatif biasanya memerlukan minimal dua bentuk, sementara distribusi horizontal atau vertikal membutuhkan cukup bentuk untuk menentukan jarak. Hitung ulang indeks bila Anda memodifikasi koleksi sebelum memanggil metode.

## **Flip Bentuk**

Kelas [ShapeFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertikal, serta rotasi. Nilai [getFlipH](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeframe/#getFlipH) dan [getFlipV](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeframe/#getFlipV) menggunakan [NullableBool](https://reference.aspose.com/slides/id/python-java/aspose.slides/nullablebool/): `True` mengaktifkan flip, `False` menonaktifkannya, dan `NotDefined` mempertahankan keadaan tak ditentukan/default.

Presentasi input di bawah ini berisi satu bentuk yang tidak di‑flip.

![The shape before flipping](shape_to_be_flipped.png)

Contoh ini mempertahankan semua nilai frame lainnya dan hanya mengganti dua pengaturan flip. Ini penting karena menetapkan [Frame](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#setFrame) baru menggantikan seluruh frame.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bentuk yang disimpan tercermin secara horizontal dan vertikal sambil mempertahankan posisi, ukuran, dan rotasinya.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Haruskah saya menggunakan indeks koleksi sebagai pengenal bentuk?**

Hanya untuk pemrosesan singkat ketika koleksi tidak akan berubah sebelum indeks digunakan. Lebih baik gunakan konvensi [Nama](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getName) atau [TeksAlternatif](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getAlternativeText) yang divalidasi untuk templat yang dibuat, atau [OfficeInteropShapeId](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getOfficeInteropShapeId) untuk pekerjaan interop berskala slide.

**Apakah menyembunyikan bentuk menghapusnya dari urutan‑z?**

Tidak. Bentuk tersembunyi tetap berada di koleksi pada indeks yang sama. Ia dapat ditemukan, diubah urutannya, diedit, atau dibuat terlihat kembali.

**Mengapa bentuk yang digandakan muncul di depan bentuk lain?**

[addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addClone) menambahkan klon ke akhir koleksi, yang merupakan depan urutan‑z. Gunakan [insertClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#insertClone) untuk memilih indeks awal atau [reorder](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#reorder) setelah semua bentuk ditambahkan.

**Bisakah saya menggunakan indeks tetap untuk mengidentifikasi penyesuaian bentuk preset?**

Hanya setelah memvalidasi preset dan tata letak koleksi secara tepat. Lebih baik iterasi melalui [GeometryShape.getAdjustments](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometryshape/#getAdjustments) dan memeriksa [AdjustValue.getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getType); gunakan [AdjustValue.getName](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getName) sebagai informasi tambahan ketika tipe semantik yang sama muncul lebih dari sekali.