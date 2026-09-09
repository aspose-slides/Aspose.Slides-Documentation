---
title: Kelola OLE dalam Presentasi Menggunakan Python
linktitle: Kelola OLE
type: docs
weight: 40
url: /id/python-java/manage-ole/
keywords:
- objek OLE
- Pengaitan dan Penyematan Objek
- tambahkan OLE
- sematkan OLE
- tambahkan objek
- sematkan objek
- tambahkan file
- sematkan file
- objek tertaut
- file tertaut
- ubah OLE
- ikon OLE
- judul OLE
- ekstrak OLE
- ekstrak objek
- ekstrak file
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: Optimalkan manajemen objek OLE dalam file PowerPoint dan OpenDocument dengan Aspose.Slides for Python via Java. Sematkan, perbarui, dan ekspor konten OLE secara mulus.
---
## **Pengantar**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) adalah teknologi Microsoft yang memungkinkan data dan objek yang dibuat di satu aplikasi ditempatkan di aplikasi lain melalui penautan atau penyisipan.
{{% /alert %}}

Pertimbangkan sebuah diagram yang dibuat di MS Excel. Diagram tersebut kemudian ditempatkan di dalam slide PowerPoint. Diagram Excel itu dianggap sebagai objek OLE.

- Objek OLE dapat muncul sebagai ikon. Dalam kasus ini, saat Anda mengklik ganda ikon, diagram akan terbuka di aplikasi terkait (Excel), atau Anda akan diminta memilih aplikasi untuk membuka atau mengedit objek.
- Objek OLE dapat menampilkan isi sebenarnya, seperti isi diagram. Dalam kasus ini, diagram diaktifkan di PowerPoint, antarmuka diagram dimuat, dan Anda dapat memodifikasi data diagram di dalam PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/id/python-java/) memungkinkan Anda menyisipkan objek OLE ke dalam slide sebagai bingkai objek OLE ([OleObjectFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/)).

## **Menambahkan Bingkai Objek OLE ke Slide**

Andaikan Anda sudah membuat diagram di Microsoft Excel dan ingin menyisipkannya ke dalam slide sebagai bingkai objek OLE menggunakan Aspose.Slides for Python via Java, Anda dapat melakukannya dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Baca file Excel sebagai array byte.
4. Tambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/) ke slide dengan menyertakan array byte dan informasi lain tentang objek OLE.
5. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah ini, kami menambahkan diagram dari file Excel ke slide sebagai bingkai objek OLE menggunakan Aspose.Slides for Python via Java. **Catatan** bahwa konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleembeddeddatainfo/) menerima ekstensi objek yang dapat disisipkan sebagai parameter kedua. Ekstensi ini memungkinkan PowerPoint untuk menginterpretasikan jenis file dengan benar dan memilih aplikasi yang tepat untuk membuka objek OLE ini.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Siapkan data untuk objek OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Tambahkan bingkai objek OLE ke slide.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Menambahkan Bingkai OLE Tertaut**

Aspose.Slides for Python via Java memungkinkan Anda menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/) dengan tautan ke file alih-alih data yang disisipkan.

Kode Python berikut menunjukkan cara menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/) dengan file Excel yang ditautkan ke sebuah slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan bingkai objek OLE dengan file Excel yang ditautkan.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengakses Bingkai Objek OLE**

Jika sebuah objek OLE sudah disisipkan dalam slide, Anda dapat dengan mudah menemukannya atau mengaksesnya dengan cara berikut:

1. Muat presentasi dengan objek OLE yang disisipkan dengan membuat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Akses bentuk [OleObjectFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/). Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang hanya memiliki satu bentuk pada slide pertama. Kami kemudian memeriksa bahwa objek tersebut adalah sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/). Ini adalah bingkai objek OLE yang diinginkan untuk diakses.
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.

Dalam contoh di bawah ini, sebuah bingkai objek OLE (objek diagram Excel yang disisipkan dalam slide) dan data file-nya diakses.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Dapatkan data file yang disematkan.
        # Dapatkan ekstensi file yang disematkan.
        # ...
finally:
    presentation.dispose()
```

### **Mengakses Properti Bingkai OLE Tertaut**

Aspose.Slides memungkinkan Anda mengakses properti bingkai objek OLE yang tertaut.

Kode Python berikut menunjukkan cara memeriksa apakah sebuah objek OLE tertaut dan kemudian memperoleh path ke file yang tertaut:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Periksa apakah objek OLE ditautkan.
        if ole_frame.isObjectLink():
            # Cetak jalur lengkap ke file yang ditautkan.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Cetak jalur relatif ke file yang ditautkan jika ada.
            # Hanya presentasi PPT yang dapat berisi jalur relatif.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Mengubah Data Objek OLE**

{{% alert color="info" title="Note" %}}
Pada bagian ini, contoh kode di bawah ini menggunakan [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).
{{% /alert %}}

Jika sebuah objek OLE sudah disisipkan dalam slide, Anda dapat dengan mudah mengakses objek tersebut dan mengubah datanya dengan cara berikut:

1. Muat presentasi dengan objek OLE yang disisipkan dengan membuat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Akses bentuk bingkai objek OLE. Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang memiliki satu bentuk pada slide pertama. Kami kemudian memeriksa bahwa objek tersebut adalah sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/). Ini adalah bingkai objek OLE yang diinginkan untuk diakses.
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.
5. Buat objek [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) dan akses data OLE.
6. Akses [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) yang diinginkan dan ubah data.
7. Simpan [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) yang diperbarui ke dalam stream.
8. Ubah data objek OLE dari stream.

Dalam contoh di bawah ini, sebuah bingkai objek OLE (objek diagram Excel yang disisipkan dalam slide) diakses, dan data file-nya dimodifikasi untuk memperbarui data diagram.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # Baca data objek OLE sebagai objek Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Modifikasi data workbook.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Ubah data objek bingkai OLE.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menyisipkan Jenis File Lain ke Slide**

Selain diagram Excel, Aspose.Slides for Python via Java memungkinkan Anda menyisipkan jenis file lain ke dalam slide. Misalnya, Anda dapat menyisipkan file HTML, PDF, dan ZIP sebagai objek. Ketika pengguna mengklik ganda objek yang disisipkan, itu secara otomatis terbuka di program terkait, atau pengguna akan diminta untuk memilih program yang sesuai untuk membukanya.

Kode Python berikut menunjukkan cara menyisipkan HTML dan ZIP ke dalam slide:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengatur Jenis File untuk Objek yang Disisipkan**

Saat bekerja dengan presentasi, Anda mungkin perlu mengganti objek OLE lama dengan yang baru atau mengganti objek OLE yang tidak didukung dengan yang didukung. Aspose.Slides for Python via Java memungkinkan Anda mengatur jenis file untuk objek yang disisipkan, sehingga Anda dapat memperbarui data bingkai OLE atau ekstensi filenya.

Kode Python berikut menunjukkan cara mengatur jenis file untuk objek OLE yang disisipkan menjadi `zip`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # Ubah jenis file menjadi ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengatur Gambar Ikon dan Judul untuk Objek yang Disisipkan**

Setelah sebuah objek OLE disisipkan, pratinjau yang terdiri dari gambar ikon secara otomatis ditambahkan. Pratinjau ini adalah apa yang dilihat pengguna sebelum mengakses atau membuka objek OLE. Jika Anda ingin menggunakan gambar dan teks tertentu sebagai elemen dalam pratinjau, Anda dapat mengatur gambar ikon dan judul menggunakan Aspose.Slides for Python via Java.

Kode Python berikut menunjukkan cara mengatur gambar ikon dan judul untuk objek yang disisipkan:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Tambahkan gambar ke sumber daya presentasi.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Atur judul dan gambar untuk pratinjau OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mencegah Bingkai Objek OLE Diubah Ukuran dan Posisinya**

Setelah Anda menambahkan objek OLE yang tertaut ke slide presentasi, ketika Anda membuka presentasi di PowerPoint, Anda mungkin melihat pesan yang meminta Anda memperbarui tautan. Mengklik tombol "Update Links" dapat mengubah ukuran dan posisi bingkai objek OLE karena PowerPoint memperbarui data dari objek OLE yang tertaut dan menyegarkan pratinjau objek. Untuk mencegah PowerPoint meminta pembaruan data objek, setel metode [setUpdateAutomatic](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) dari kelas [OleObjectFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/) ke `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengekstrak File yang Disisipkan**

Aspose.Slides for Python via Java memungkinkan Anda mengekstrak file yang disisipkan dalam slide sebagai objek OLE dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang berisi objek OLE yang ingin Anda ekstrak.
2. Iterasi semua shape dalam presentasi dan akses shape [OleObjectFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/).
3. Akses data file yang disisipkan dari bingkai objek OLE dan tulis ke disk.

Kode Python berikut menunjukkan cara mengekstrak file yang disisipkan dalam slide sebagai objek OLE:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah konten OLE akan dirender saat mengekspor slide ke PDF/gambar?**  
Yang terlihat pada slide yang dirender—ikon/gambar pengganti (pratinjau). Konten OLE "live" tidak dijalankan selama proses rendering. Jika diperlukan, atur gambar pratinjau Anda sendiri untuk memastikan tampilan yang diharapkan dalam PDF yang diekspor.

**Bagaimana cara mengunci objek OLE pada slide agar pengguna tidak dapat memindahkan/mengeditnya di PowerPoint?**  
Kunci shape: Aspose.Slides menyediakan [kunci tingkat shape](/slides/id/python-java/applying-protection-to-presentation/). Ini bukan enkripsi, tetapi secara efektif mencegah pengeditan dan pemindahan yang tidak disengaja.

**Mengapa objek Excel yang tertaut "melompat" atau mengubah ukuran saat saya membuka presentasi?**  
PowerPoint mungkin menyegarkan pratinjau OLE yang tertaut. Untuk tampilan yang stabil, ikuti praktik [Working Solution for Worksheet Resizing](/slides/id/python-java/working-solution-for-worksheet-resizing/)—baik sesuaikan bingkai dengan rentang, atau skala rentang ke bingkai tetap dan atur gambar pengganti yang sesuai.

**Apakah jalur relatif untuk objek OLE yang tertaut akan dipertahankan dalam format PPTX?**  
Dalam PPTX, informasi "jalur relatif" tidak tersedia—hanya jalur lengkap. Jalur relatif ditemukan pada format PPT yang lebih lama. Untuk portabilitas, sebaiknya gunakan jalur absolut yang dapat diandalkan/URI yang dapat diakses atau menyisipkan file.