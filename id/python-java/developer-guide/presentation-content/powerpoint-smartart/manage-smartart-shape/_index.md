---
title: Kelola Grafik SmartArt dalam Presentasi Menggunakan Python
linktitle: Grafik SmartArt
type: docs
weight: 20
url: /id/python-java/manage-smartart-shape/
keywords:
- Objek SmartArt
- Grafik SmartArt
- Gaya SmartArt
- Warna SmartArt
- Buat SmartArt
- Tambahkan SmartArt
- Sunting SmartArt
- Ubah SmartArt
- Akses SmartArt
- Tipe tata letak SmartArt
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Otomatisasi pembuatan, penyuntingan, dan penataan gaya SmartArt PowerPoint dalam Python menggunakan Aspose.Slides, dengan contoh kode singkat dan panduan berfokus pada kinerja."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda membuat dan mengelola grafik SmartArt dalam presentasi PowerPoint secara programatis. Artikel ini menjelaskan cara menambahkan bentuk SmartArt ke slide, mengakses bentuk SmartArt yang ada, menemukan SmartArt berdasarkan jenis tata letak tertentu, dan memperbarui tampilan visualnya dengan mengubah gaya SmartArt atau gaya warna.

Contoh-contoh menunjukkan cara bekerja dengan bentuk SmartArt melalui koleksi bentuk slide presentasi, memeriksa apakah sebuah bentuk adalah SmartArt, dan kemudian mengubah atau memeriksa propertinya.

## **Membuat Bentuk SmartArt**
Aspose.Slides untuk Python via Java menyediakan API untuk membuat bentuk SmartArt. Untuk membuat bentuk SmartArt dalam sebuah slide, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Dapatkan slide berdasarkan indeksnya.
1. [Tambahkan bentuk SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addSmartArt) dengan menentukan [SmartArtLayoutType](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartlayouttype/).
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # Dapatkan slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan bentuk SmartArt.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # Simpan presentasi.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Gambar: Bentuk SmartArt yang ditambahkan ke slide**|

## **Mengakses Bentuk SmartArt pada Slide**
Contoh berikut mengakses bentuk SmartArt pada slide presentasi. Ia melakukan iterasi melalui setiap bentuk pada slide dan memeriksa apakah bentuk tersebut merupakan instance [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Iterasi melalui setiap bentuk pada slide pertama.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **Mengakses Bentuk SmartArt dengan Tipe Tata Letak Tertentu**
Contoh berikut mengakses bentuk [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/) dengan tipe tata letak tertentu, yang dikembalikan oleh [SmartArt.getLayout](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/#getLayout).

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan muat presentasi yang berisi bentuk SmartArt.
1. Dapatkan slide pertama berdasarkan indeksnya.
1. Iterasikan setiap bentuk pada slide pertama.
1. Periksa apakah bentuk tersebut merupakan instance [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/).
1. Periksa apakah bentuk SmartArt memiliki tipe tata letak yang ditentukan dan lakukan operasi yang diperlukan.

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Iterasi melalui setiap bentuk pada slide pertama.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Periksa tata letak SmartArt.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **Mengubah Gaya Bentuk SmartArt**
Contoh ini menunjukkan cara mengubah gaya cepat sebuah bentuk SmartArt.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan muat presentasi yang berisi bentuk SmartArt.
1. Dapatkan slide pertama berdasarkan indeksnya.
1. Iterasikan setiap bentuk pada slide pertama.
1. Periksa apakah bentuk tersebut merupakan instance [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/).
1. Temukan bentuk SmartArt dengan gaya yang ditentukan.
1. Tetapkan gaya baru untuk bentuk SmartArt.
1. Simpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Iterasi melalui setiap bentuk pada slide pertama.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Periksa dan ubah gaya SmartArt.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Gambar: Bentuk SmartArt dengan gaya yang diubah**|

## **Mengubah Gaya Warna Bentuk SmartArt**
Contoh ini mengakses bentuk SmartArt dengan gaya warna tertentu dan mengubah gaya tersebut.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan muat presentasi yang berisi bentuk SmartArt.
1. Dapatkan slide pertama berdasarkan indeksnya.
1. Iterasikan setiap bentuk pada slide pertama.
1. Periksa apakah bentuk tersebut merupakan instance [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/).
1. Temukan bentuk SmartArt dengan gaya warna yang ditentukan.
1. Tetapkan gaya warna baru untuk bentuk SmartArt.
1. Simpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Iterasi melalui setiap bentuk pada slide pertama.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Periksa dan ubah gaya SmartArt.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Gambar: Bentuk SmartArt dengan gaya warna yang diubah**|

## **FAQ**

**Apakah saya dapat memberi animasi pada SmartArt sebagai satu objek?**

Ya. SmartArt merupakan sebuah bentuk, sehingga Anda dapat menerapkan [animasi standar](/slides/id/python-java/powerpoint-animation/) melalui API animasi (masuk, keluar, penekanan, jalur gerak) sama seperti pada bentuk lainnya.

**Bagaimana saya dapat menemukan SmartArt tertentu pada slide jika saya tidak mengetahui ID internalnya?**

Tetapkan dan gunakan [teks alternatif](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#setAlternativeText) kemudian cari bentuk berdasarkan nilai tersebut—ini adalah cara yang disarankan untuk menemukan bentuk target.

**Apakah saya dapat mengelompokkan SmartArt dengan bentuk lain?**

Ya. Anda dapat mengelompokkan SmartArt dengan bentuk lain (gambar, tabel, dll.) dan kemudian [memanipulasi grup](/slides/id/python-java/group/).

**Bagaimana saya mendapatkan gambar dari SmartArt tertentu (misalnya, untuk pratinjau atau laporan)?**

Ekspor thumbnail/gambar dari bentuk; perpustakaan dapat [merender bentuk individual](/slides/id/python-java/create-shape-thumbnails/) ke file raster (PNG/JPG/TIFF).

**Apakah tampilan SmartArt akan tetap terjaga saat mengonversi seluruh presentasi ke PDF?**

Ya. Mesin rendering menargetkan fidelitas tinggi untuk [ekspor PDF](/slides/id/python-java/convert-powerpoint-to-pdf/), dengan berbagai opsi kualitas dan kompatibilitas.