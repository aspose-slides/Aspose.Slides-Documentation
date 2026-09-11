---
title: Kelola Node Bentuk SmartArt dalam Presentasi Menggunakan Python
linktitle: Node Bentuk SmartArt
type: docs
weight: 30
url: /id/python-java/manage-smartart-shape-node/
keywords:
- node SmartArt
- node anak
- tambahkan node
- posisi node
- akses node
- hapus node
- posisi kustom
- node asisten
- format isi
- render node
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Kelola node bentuk SmartArt dalam file PPT dan PPTX dengan Aspose.Slides untuk Python via Java. Dapatkan contoh kode yang jelas dan tips untuk menyederhanakan presentasi Anda."
---
## **Gambaran Umum**

Grafik SmartArt dalam presentasi PowerPoint diatur melalui node yang berisi teks dan menentukan struktur diagram. Aspose.Slides memungkinkan Anda bekerja dengan node SmartArt ini secara programatis: menambah node dan node anak baru, menyisipkan node anak pada posisi tertentu, mengakses node yang ada, dan membaca teks, tingkat, serta posisi mereka.

Artikel ini menjelaskan cara mengelola node bentuk SmartArt. Artikel ini menunjukkan cara menghapus node, bekerja dengan node anak berdasarkan indeks atau posisi, mengubah node asisten menjadi node biasa, menyesuaikan posisi, ukuran, dan rotasi bentuk node SmartArt, mengatur format isi node, dan membuat gambar thumbnail untuk node anak SmartArt.

## **Menambahkan Node SmartArt**
Aspose.Slides untuk Python via Java menyediakan API untuk mengelola bentuk SmartArt. Contoh berikut menambahkan node dan node anak ke bentuk SmartArt.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan muat presentasi yang berisi bentuk SmartArt.
1. Dapatkan slide pertama berdasarkan indeksnya.
1. Iterasi melalui setiap bentuk pada slide pertama.
1. Periksa apakah bentuk tersebut merupakan instance [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/).
1. [Tambahkan node baru](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartnodecollection/#addNode) ke [koleksi node](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/#getAllNodes) bentuk SmartArt dan atur teksnya melalui TextFrame([https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/)).
1. [Tambahkan] [node anak](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartnode/#getChildNodes) ke node baru dan atur teksnya melalui TextFrame([https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/)).
1. Simpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menambahkan Node SmartArt pada Posisi Tertentu**
Contoh berikut menambahkan node anak pada posisi tertentu dalam sebuah node SmartArt.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
1. Dapatkan slide pertama berdasarkan indeksnya.
1. Tambahkan bentuk [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/) dengan tata letak [StackedList](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartlayouttype/#StackedList) ke slide.
1. Akses node pertama dalam bentuk SmartArt yang ditambahkan.
1. Tambahkan node anak ke node yang dipilih pada posisi 2 menggunakan [addNodeByPosition](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) dan atur teksnya.
1. Simpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengakses Node SmartArt**
Contoh berikut mengakses node dalam bentuk SmartArt. Tata letak yang dikembalikan oleh [getLayout](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/#getLayout) bersifat read-only dan ditetapkan saat bentuk SmartArt ditambahkan.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan muat presentasi yang berisi bentuk SmartArt.
1. Dapatkan slide pertama berdasarkan indeksnya.
1. Iterasi melalui setiap bentuk pada slide pertama.
1. Periksa apakah bentuk tersebut merupakan instance [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/) .
1. Iterasi melalui semua [node](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/#getAllNodes) dalam bentuk SmartArt.
1. Baca dan tampilkan posisi, tingkat, serta teks masing-masing node SmartArt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **Mengakses Node Anak SmartArt**
Contoh berikut mengakses node anak dalam setiap node pada bentuk SmartArt.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan muat presentasi yang berisi bentuk SmartArt.
1. Dapatkan slide pertama berdasarkan indeksnya.
1. Iterasi melalui setiap bentuk pada slide pertama.
1. Periksa apakah bentuk tersebut merupakan instance [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/) .
1. Iterasi melalui semua [node](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/#getAllNodes) dalam bentuk SmartArt.
1. Untuk setiap node, iterasi melalui [node anak](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartnode/#getChildNodes).
1. Baca dan tampilkan posisi, tingkat, dan teks [node anak](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **Mengakses Node Anak SmartArt pada Posisi Tertentu**
Contoh berikut mengakses node anak pada indeks tertentu dalam koleksi node induknya.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
1. Dapatkan slide pertama berdasarkan indeksnya.
1. Tambahkan bentuk SmartArt dengan tata letak [StackedList](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartlayouttype/#StackedList) .
1. Akses bentuk SmartArt yang ditambahkan.
1. Akses node pada indeks 0 dalam bentuk SmartArt.
1. Akses node anak pada indeks 1 menggunakan [get_Item](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartnodecollection/#get_Item) .
1. Baca dan tampilkan posisi, tingkat, dan teks [node anak](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartnode/#getChildNodes) .

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **Menghapus Node SmartArt**
Contoh berikut menghapus node dari bentuk SmartArt.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan muat presentasi yang berisi bentuk SmartArt.
1. Dapatkan slide pertama berdasarkan indeksnya.
1. Iterasi melalui setiap bentuk pada slide pertama.
1. Periksa apakah bentuk tersebut merupakan instance [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/) .
1. Periksa bahwa bentuk [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/) memiliki setidaknya satu node.
1. Pilih node SmartArt yang akan dihapus.
1. Hapus node yang dipilih menggunakan [removeNode](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartnodecollection/#removeNode) .
1. Simpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menghapus Node SmartArt dari Posisi Tertentu**
Contoh berikut menghapus node anak pada indeks tertentu dalam koleksi node SmartArt.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan muat presentasi yang berisi bentuk SmartArt.
1. Dapatkan slide pertama berdasarkan indeksnya.
1. Iterasi melalui setiap bentuk pada slide pertama.
1. Periksa apakah bentuk tersebut merupakan instance [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/) .
1. Akses node SmartArt pada indeks 0 jika ada.
1. Periksa bahwa node SmartArt yang dipilih memiliki setidaknya dua node anak.
1. Hapus node anak pada indeks 1 menggunakan [removeNode](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartnodecollection/#removeNode) .
1. Simpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menetapkan Posisi Kustom untuk Node Anak dalam Objek SmartArt**
Aspose.Slides untuk Python via Java mendukung pengaturan posisi [SmartArtShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartshape/) menggunakan [setX](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#setX) dan [setY](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#setY). Contoh berikut menetapkan posisi, ukuran, dan rotasi kustom untuk bentuk node SmartArt. Menambahkan node baru menghitung ulang posisi dan ukuran semua node. Penempatan kustom memungkinkan Anda mengatur node sesuai kebutuhan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Memeriksa Node Asisten**
{{% alert color="info" title="Note" %}} 

Bagian ini mengeksplorasi bentuk SmartArt yang ditambahkan ke slide presentasi secara programatis menggunakan Aspose.Slides untuk Python via Java.

{{% /alert %}} 

Bentuk SmartArt sumber berikut digunakan dalam contoh ini.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**Gambar: Bentuk SmartArt sumber pada slide**|

Contoh berikut mengidentifikasi node asisten dalam koleksi node SmartArt dan mengubahnya menjadi node normal.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan muat presentasi yang berisi bentuk SmartArt.
1. Dapatkan slide pertama berdasarkan indeksnya.
1. Iterasi melalui setiap bentuk pada slide pertama.
1. Periksa apakah bentuk tersebut merupakan instance [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/) .
1. Iterasi melalui semua node dalam bentuk SmartArt dan periksa apakah mereka merupakan [Assistant Nodes](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartnode/#isAssistant) .
1. Ubah setiap node asisten menjadi node normal.
1. Simpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Gambar: Node asisten diubah dalam bentuk SmartArt pada slide**|

## **Mengatur Format Isi Node**
Aspose.Slides untuk Python via Java memungkinkan penambahan bentuk SmartArt khusus dan mengatur format isinya. Artikel ini menjelaskan cara membuat dan mengakses bentuk SmartArt serta mengatur format isinya menggunakan Aspose.Slides untuk Python via Java.

Silakan ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
1. Dapatkan slide berdasarkan indeksnya.
1. Tambahkan bentuk [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/) dengan tata letak [ClosedChevronProcess](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess) .
1. Atur [FillFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getFillFormat) untuk node bentuk SmartArt.
1. Tuliskan presentasi yang dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Membuat Thumbnail Node Anak SmartArt**
Untuk membuat thumbnail node anak SmartArt, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
1. [Tambahkan bentuk SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addSmartArt) .
1. Dapatkan node berdasarkan indeksnya.
1. Dapatkan gambar thumbnail.
1. Simpan gambar thumbnail dalam format gambar apa pun yang diinginkan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah animasi SmartArt didukung?**

Ya. SmartArt diperlakukan sebagai bentuk biasa, sehingga Anda dapat [menerapkan animasi standar](/slides/id/python-java/shape-animation/) (masuk, keluar, penekanan, jalur gerakan) dan menyesuaikan timing. Anda juga dapat memberi animasi pada bentuk di dalam node SmartArt bila diperlukan.

**Bagaimana cara menemukan SmartArt tertentu pada slide secara andal jika ID internalnya tidak diketahui?**

Berikan dan cari berdasarkan [teks alternatif](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getAlternativeText). Menetapkan teks alternatif yang berbeda pada SmartArt memungkinkan Anda menemukannya secara programatis tanpa bergantung pada pengidentifikasi internal.

**Akankah tampilan SmartArt tetap terjaga saat mengonversi presentasi ke PDF?**

Ya. Aspose.Slides merender SmartArt dengan fidelitas visual tinggi selama [ekspor PDF](/slides/id/python-java/convert-powerpoint-to-pdf/), menjaga tata letak, warna, dan efek.

**Bisakah saya mengekstrak gambar seluruh SmartArt (untuk pratinjau atau laporan)?**

Ya. Anda dapat merender bentuk SmartArt ke [format raster](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage) atau ke [SVG](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#writeAsSvgToBytes) untuk output vektor yang skalabel, sehingga cocok untuk thumbnail, laporan, atau penggunaan web.