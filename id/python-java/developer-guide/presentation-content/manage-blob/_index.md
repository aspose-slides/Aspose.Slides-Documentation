---
title: Kelola BLOB Presentasi di Python via Java untuk Penggunaan Memori Efisien
linktitle: Kelola BLOB
type: docs
weight: 10
url: /id/python-java/manage-blob/
keywords:
- objek besar
- item besar
- berkas besar
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
description: "Kelola data BLOB di Aspose.Slides untuk Python via Java guna menyederhanakan operasi file PowerPoint dan OpenDocument untuk penanganan presentasi yang efisien."
---
## **Ikhtisar**

Aspose.Slides menyediakan penanganan berbasis BLOB untuk data biner besar dalam presentasi guna membantu mengurangi konsumsi memori saat bekerja dengan gambar, audio, video, dan berkas presentasi yang besar.

Artikel ini menunjukkan cara menggunakan pemrosesan berbasis BLOB untuk menambahkan media besar ke presentasi, mengekspor media besar dari presentasi, dan memuat presentasi besar dengan lebih efisien. Artikel ini juga menjelaskan bagaimana file sementara dapat digunakan selama pemrosesan dan cara mengubah folder yang digunakan untuk menyimpannya.

## **Tentang BLOB**

**BLOB** (**Binary Large Object**) biasanya merupakan item besar (foto, presentasi, dokumen, atau media) yang disimpan dalam format biner.

Aspose.Slides for Python via Java memungkinkan Anda menggunakan BLOB untuk objek dengan cara yang mengurangi konsumsi memori ketika berkas besar terlibat.

{{% alert color="info" title="Catatan" %}}
Untuk mengatasi beberapa keterbatasan saat berinteraksi dengan aliran, Aspose.Slides mungkin menyalin konten aliran tersebut. Memuat presentasi besar melalui alirannya akan mengakibatkan penyalinan isi presentasi dan menyebabkan pemuatan yang lambat. Oleh karena itu, ketika Anda bermaksud memuat presentasi besar, kami sangat menyarankan agar Anda menggunakan jalur berkas presentasi dan bukan alirannya.
{{% /alert %}}

## **Gunakan BLOB untuk Mengurangi Konsumsi Memori**

### **Menambahkan File Besar melalui BLOB ke Presentasi**

[Aspose.Slides](/slides/id/python-java/) for Python via Java memungkinkan Anda menambahkan file besar (dalam hal ini, file video besar) melalui proses yang melibatkan BLOB untuk mengurangi konsumsi memori.

Kode Python ini menunjukkan cara menambahkan file video besar melalui proses BLOB ke sebuah presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Buat presentasi baru tempat video akan ditambahkan.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Jaga aliran terkunci karena kami tidak bermaksud mengakses file video.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Simpan presentasi sambil menjaga konsumsi memori tetap rendah.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Ekspor File Besar melalui BLOB dari Presentasi**
Aspose.Slides for Python via Java memungkinkan Anda mengekspor file besar (misalnya file audio atau video) melalui proses yang melibatkan BLOB dari presentasi. Misalnya, Anda mungkin perlu mengekstrak file media besar dari presentasi tetapi tidak ingin file tersebut dimuat ke memori komputer Anda. Dengan mengekspor file melalui proses BLOB, Anda dapat menjaga konsumsi memori tetap rendah.

Kode Python ini mendemonstrasikan operasi yang dijelaskan:

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

### **Menambahkan Gambar sebagai BLOB ke Presentasi**
Dengan metode dari kelas [ImageCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagecollection/), Anda dapat menambahkan gambar besar sebagai aliran agar diperlakukan sebagai BLOB.

Kode Python ini menunjukkan cara menambahkan gambar besar melalui proses BLOB:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Buat presentasi baru tempat gambar akan ditambahkan.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Jaga aliran terkunci karena kami tidak bermaksud mengakses file gambar.
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

Biasanya, untuk memuat presentasi besar, komputer memerlukan banyak memori sementara. Semua konten presentasi dimuat ke memori dan berkas (yang dari mana presentasi dimuat) tidak lagi digunakan.

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

Melalui proses yang melibatkan BLOB, Anda dapat memuat presentasi besar sambil menggunakan sedikit memori. Kode Python ini menjelaskan implementasi di mana proses BLOB digunakan untuk memuat berkas presentasi besar (large.pptx):

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

{{% alert color="info" title="Catatan" %}}
Ketika Anda menggunakan [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath), Aspose.Slides tidak secara otomatis membuat folder untuk menyimpan file sementara. Anda harus membuat folder tersebut secara manual.
{{% /alert %}}

### **Hapus Objek Presentasi untuk Membebaskan Memori**

Saat memproses presentasi besar, pastikan bahwa instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dibuang dengan benar sehingga memori yang ditempati dilepaskan. Panggil [Presentation.dispose](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#dispose) setelah Anda selesai menggunakan presentasi untuk membebaskan sumber daya yang tidak terkelola.

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
    # Bebaskan sumber daya secara eksplisit.
    presentation.dispose()
```

## **FAQ**

**Data apa dalam presentasi Aspose.Slides yang diperlakukan sebagai BLOB dan dikontrol oleh opsi BLOB?**  
Objek biner besar seperti gambar, audio, dan video diperlakukan sebagai BLOB. Seluruh berkas presentasi juga melibatkan penanganan BLOB saat dimuat atau disimpan. Objek-objek ini diatur oleh kebijakan BLOB yang memungkinkan Anda mengelola penggunaan memori dan memindahkan data ke file sementara bila diperlukan.

**Di mana saya mengonfigurasi aturan penanganan BLOB selama pemuatan presentasi?**  
Gunakan [LoadOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/) bersama [BlobManagementOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/blobmanagementoptions/). Di sana Anda dapat menetapkan batas memori untuk BLOB, mengizinkan atau menolak file sementara, memilih jalur akar untuk file sementara, dan menentukan perilaku penguncian sumber.

**Apakah pengaturan BLOB memengaruhi kinerja, dan bagaimana cara menyeimbangkan kecepatan vs memori?**  
Ya. Menyimpan BLOB di memori memaksimalkan kecepatan tetapi meningkatkan konsumsi RAM; menurunkan batas memori mengalihkan lebih banyak pekerjaan ke file sementara, mengurangi RAM dengan biaya I/O tambahan. Gunakan metode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/id/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) untuk menemukan keseimbangan yang tepat bagi beban kerja dan lingkungan Anda.

**Apakah opsi BLOB membantu saat membuka presentasi yang sangat besar (misalnya gigabyte)?**  
Ya. [BlobManagementOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/blobmanagementoptions/) dirancang untuk skenario tersebut: mengaktifkan file sementara dan menggunakan penguncian sumber dapat secara signifikan mengurangi penggunaan RAM puncak dan menstabilkan pemrosesan untuk dek yang sangat besar.

**Bisakah saya menggunakan kebijakan BLOB saat memuat dari aliran alih-alih berkas disk?**  
Ya. Aturan yang sama berlaku untuk aliran: instance presentasi dapat memiliki dan mengunci aliran input (tergantung pada mode penguncian yang dipilih), dan file sementara digunakan bila diizinkan, menjaga penggunaan memori tetap dapat diprediksi selama pemrosesan.