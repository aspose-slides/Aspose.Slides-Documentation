---
title: Kelola BLOB Presentasi di Python via Java untuk Penggunaan Memori Efisien
linktitle: Kelola BLOB
type: docs
weight: 10
url: /id/python-java/manage-blob/
keywords:
- objek besar
- item besar
- file besar
- tambahkan BLOB
- ekspor BLOB
- tambahkan gambar sebagai BLOB
- kurangi memori
- konsumsi memori
- presentasi besar
- file sementara
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kelola data BLOB di Aspose.Slides untuk Python via Java untuk mempermudah operasi file PowerPoint dan OpenDocument untuk penanganan presentasi yang efisien."
---
## **Ikhtisar**

Aspose.Slides menyediakan penanganan berbasis BLOB untuk data biner besar dalam presentasi guna membantu mengurangi konsumsi memori saat bekerja dengan gambar, audio, video, dan file presentasi yang besar.

Artikel ini menunjukkan cara menggunakan proses berbasis BLOB untuk menambahkan media besar ke sebuah presentasi, mengekspor media besar dari sebuah presentasi, dan memuat presentasi besar secara lebih efisien. Artikel ini juga menjelaskan cara menggunakan file sementara selama pemrosesan serta cara mengubah folder yang digunakan untuk menyimpannya.

## **Tentang BLOB**

Sebuah **BLOB** (**Binary Large Object**) biasanya merupakan item besar (foto, presentasi, dokumen, atau media) yang disimpan dalam format biner.

Aspose.Slides untuk Python via Java memungkinkan Anda menggunakan BLOB untuk objek dengan cara yang mengurangi konsumsi memori ketika file besar terlibat.

{{% alert color="info" title="Note" %}}
Untuk mengatasi batasan tertentu saat berinteraksi dengan aliran, Aspose.Slides dapat menyalin konten aliran tersebut. Memuat presentasi besar melalui alirannya akan menghasilkan penyalinan isi presentasi dan menyebabkan pemuatan yang lambat. Oleh karena itu, ketika Anda berniat memuat presentasi besar, kami sangat menyarankan agar Anda menggunakan jalur file presentasi dan bukan alirannya.
{{% /alert %}}

## **Gunakan BLOB untuk Mengurangi Konsumsi Memori**

### **Tambahkan File Besar ke Presentasi Menggunakan BLOB**

[Aspose.Slides](/slides/id/python-java/) untuk Python via Java memungkinkan Anda menambahkan file besar (dalam hal ini, file video besar) melalui proses yang melibatkan BLOB untuk mengurangi konsumsi memori.

Kode Python ini menunjukkan cara menambahkan file video besar melalui proses BLOB ke sebuah presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Buat presentasi baru yang akan ditambahkan video.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Kunci aliran karena kami tidak bermaksud mengakses file video.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Simpan presentasi sambil menjaga konsumsi memori tetap rendah.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Ekspor File Besar dari Presentasi Menggunakan BLOB**

Aspose.Slides untuk Python via Java memungkinkan Anda mengekspor file besar (dalam hal ini, file audio atau video) melalui proses yang melibatkan BLOB dari presentasi. Misalnya, Anda mungkin perlu mengekstrak file media besar dari sebuah presentasi tetapi tidak ingin file tersebut dimuat ke memori komputer Anda. Dengan mengekspor file melalui proses BLOB, Anda dapat menjaga konsumsi memori tetap rendah.

Kode ini dalam Python mendemonstrasikan operasi yang dijelaskan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Kunci file sumber alih-alih memuatnya ke memori.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Transfer data video melalui buffer untuk menjaga konsumsi memori tetap rendah.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Gunakan aliran alih-alih memuat seluruh video ke dalam array byte.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # Jika diperlukan, terapkan langkah yang sama pada file audio.
finally:
    presentation.dispose()
```

### **Tambahkan Gambar sebagai BLOB ke Presentasi**

Dengan metode dari kelas [ImageCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagecollection/), Anda dapat menambahkan gambar besar sebagai aliran sehingga diperlakukan sebagai BLOB.

Kode Python ini menunjukkan cara menambahkan gambar besar melalui proses BLOB:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Buat presentasi baru yang akan ditambahkan gambar.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Kunci aliran karena kami tidak bermaksud mengakses file gambar.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Simpan presentasi sambil menjaga konsumsi memori tetap rendah.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Memori dan Presentasi Besar**

Biasanya, untuk memuat presentasi besar, komputer memerlukan banyak memori sementara. Semua konten presentasi dimuat ke dalam memori dan file (dari mana presentasi dimuat) tidak lagi digunakan.

Pertimbangkan sebuah presentasi PowerPoint besar (large.pptx) yang berisi file video 1,5 GB. Metode standar untuk memuat presentasi dijelaskan dalam kode Python ini:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Namun metode ini mengonsumsi sekitar 1,6 GB memori sementara.

### **Muat Presentasi Besar sebagai BLOB**

Dengan menggunakan penanganan BLOB, Anda dapat memuat presentasi besar dengan memori yang sedikit. Kode Python ini menunjukkan cara menggunakan penanganan BLOB untuk memuat file presentasi besar (large.pptx):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **Ubah Folder untuk File Sementara**

Saat proses BLOB digunakan, komputer Anda membuat file sementara di folder default untuk file sementara. Jika Anda ingin file sementara disimpan di folder lain, Anda dapat mengubah pengaturan penyimpanan menggunakan [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Note" %}}
Saat Anda menggunakan [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath), Aspose.Slides tidak secara otomatis membuat folder untuk menyimpan file sementara. Anda harus membuat folder tersebut secara manual.
{{% /alert %}}

### **Buang Objek Presentasi untuk Membebaskan Memori**

Saat memproses presentasi besar, pastikan instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dibuang dengan benar sehingga memori yang ditempati dilepaskan. Panggil [Presentation.dispose](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#dispose) setelah Anda selesai menggunakan presentasi untuk membebaskan sumber daya yang tidak dikelola.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...proses presentasi...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Lepaskan sumber daya secara eksplisit.
    presentation.dispose()
```

## **FAQ**

**Data apa dalam presentasi Aspose.Slides yang diperlakukan sebagai BLOB dan dikendalikan oleh opsi BLOB?**

Objek biner besar seperti gambar, audio, dan video diperlakukan sebagai BLOB. Seluruh file presentasi juga melibatkan penanganan BLOB saat dimuat atau disimpan. Objek-objek ini diatur oleh kebijakan BLOB yang memungkinkan Anda mengelola penggunaan memori dan mengalihkan ke file sementara bila diperlukan.

**Di mana saya mengonfigurasi aturan penanganan BLOB saat memuat presentasi?**

Gunakan [LoadOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/) dengan [BlobManagementOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/blobmanagementoptions/). Di sana Anda mengatur batas memori untuk BLOB, mengizinkan atau melarang file sementara, memilih jalur root untuk file sementara, dan memilih perilaku penguncian sumber.

**Apakah pengaturan BLOB memengaruhi kinerja, dan bagaimana saya menyeimbangkan kecepatan vs memori?**

Ya. Menyimpan BLOB di memori memaksimalkan kecepatan tetapi meningkatkan konsumsi RAM; menurunkan batas memori memindahkan lebih banyak pekerjaan ke file sementara, mengurangi RAM dengan biaya I/O tambahan. Gunakan metode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/id/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) untuk mencapai keseimbangan yang tepat bagi beban kerja dan lingkungan Anda.

**Apakah opsi BLOB membantu saat membuka presentasi yang sangat besar (misalnya gigabyte)?**

Ya. [BlobManagementOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/blobmanagementoptions/) dirancang untuk skenario tersebut: mengaktifkan file sementara dan menggunakan penguncian sumber dapat secara signifikan mengurangi penggunaan RAM puncak dan menstabilkan pemrosesan untuk dek yang sangat besar.

**Dapatkah saya menggunakan kebijakan BLOB saat memuat dari aliran alih-alih file disk?**

Ya. Aturan yang sama berlaku untuk aliran: instance presentasi dapat memiliki dan mengunci aliran masuk (tergantung pada mode penguncian yang dipilih), dan file sementara digunakan bila diizinkan, menjaga penggunaan memori tetap dapat diprediksi selama pemrosesan.