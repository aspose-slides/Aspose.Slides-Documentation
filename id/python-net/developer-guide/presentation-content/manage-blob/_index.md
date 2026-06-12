---
title: Kelola BLOB dalam Presentasi dengan Python untuk Penggunaan Memori yang Efisien
linktitle: Kelola BLOB
type: docs
weight: 10
url: /id/python-net/manage-blob/
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
- berkas sementara
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kelola data BLOB di Aspose.Slides untuk Python via .NET untuk mempermudah operasi berkas PowerPoint dan OpenDocument guna penanganan presentasi yang efisien."
---
## **Overview**

Aspose.Slides menyediakan penanganan berbasis BLOB untuk data biner besar dalam presentasi guna membantu mengurangi konsumsi memori saat bekerja dengan gambar, audio, video, dan file presentasi yang besar.

Artikel ini menunjukkan cara menggunakan pemrosesan berbasis BLOB untuk menambahkan media besar ke presentasi, mengekspor media besar dari presentasi, dan memuat presentasi besar secara lebih efisien. Artikel ini juga menjelaskan bagaimana file sementara dapat digunakan selama pemrosesan dan bagaimana mengubah folder yang digunakan untuk menyimpannya.

## **About BLOB**

**BLOB** (**Binary Large Object**) biasanya merupakan item besar (foto, presentasi, dokumen, atau media) yang disimpan dalam format biner. 

Aspose.Slides for Python via .NET memungkinkan Anda menggunakan BLOB untuk objek dengan cara yang mengurangi konsumsi memori ketika berkas besar terlibat. 

## **Use BLOB to Reduce Memory Consumption**

### **Add Large File through BLOB to a Presentation**

[Aspose.Slides](/slides/id/python-net/) for .NET memungkinkan Anda menambahkan berkas besar (dalam contoh ini, berkas video besar) melalui proses yang melibatkan BLOB untuk mengurangi konsumsi memori.

Python berikut menunjukkan cara menambahkan berkas video besar melalui proses BLOB ke presentasi:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Membuat presentasi baru tempat video akan ditambahkan
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Mari tambahkan video ke presentasi - kami memilih perilaku KeepLocked karena kami
        # tidak bermaksud mengakses berkas "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Menyimpan presentasi. Saat presentasi besar dihasilkan, konsumsi memori
        # tetap rendah selama siklus hidup objek pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Export Large File Through BLOB from Presentation**
Aspose.Slides for Python via .NET memungkinkan Anda mengekspor berkas besar (misalnya berkas audio atau video) melalui proses yang melibatkan BLOB dari presentasi. Sebagai contoh, Anda mungkin perlu mengekstrak berkas media besar dari presentasi tetapi tidak ingin berkas tersebut dimuat ke memori komputer Anda. Dengan mengekspor berkas melalui proses BLOB, Anda dapat menjaga konsumsi memori tetap rendah. 

Kode Python berikut mendemonstrasikan operasi yang dijelaskan:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Simpan setiap video ke sebuah file. Untuk mencegah penggunaan memori yang tinggi, kita memerlukan buffer yang akan digunakan
	# untuk mentransfer data dari aliran video presentasi ke aliran untuk file video yang baru dibuat.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Iterasi melalui video-video
    index = 0
    # Jika perlu, Anda dapat menerapkan langkah yang sama untuk berkas audio. 
    for video in pres.videos:
		# Membuka aliran video presentasi. Harap dicatat bahwa kami sengaja menghindari mengakses properti
		# seperti video.BinaryData - karena properti ini mengembalikan array byte yang berisi video lengkap, yang kemudian
		# menyebabkan byte dimuat ke memori. Kami menggunakan video.GetStream, yang akan mengembalikan Stream - dan TIDAK
		#  memerlukan kami untuk memuat seluruh video ke dalam memori.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **Add Image as BLOB in Presentation**
Dengan metode dari kelas [**ImageCollection**](https://reference.aspose.com/slides/id/python-net/aspose.slides/imagecollection/) , Anda dapat menambahkan gambar besar sebagai aliran sehingga diperlakukan sebagai BLOB. 

Kode Python berikut menunjukkan cara menambahkan gambar besar melalui proses BLOB:

```py
import aspose.slides as slides

# membuat presentasi baru tempat gambar akan ditambahkan.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Memory and Large Presentations**

Biasanya, untuk memuat presentasi besar, komputer membutuhkan banyak memori sementara. Semua konten presentasi dimuat ke memori dan berkas (dari mana presentasi dimuat) tidak lagi digunakan. 

Pertimbangkan sebuah presentasi PowerPoint besar (large.pptx) yang berisi berkas video 1,5 GB. Metode standar untuk memuat presentasi dijelaskan dalam kode Python berikut:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Namun metode ini mengkonsumsi sekitar 1,6 GB memori sementara. 

### **Load a Large Presentation as BLOB**

Melalui proses yang melibatkan BLOB, Anda dapat memuat presentasi besar sambil menggunakan sedikit memori. Kode Python berikut menjelaskan implementasi di mana proses BLOB digunakan untuk memuat berkas presentasi besar (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **Change the Folder for Temporary Files**

Saat proses BLOB digunakan, komputer Anda membuat file sementara di folder default untuk file sementara. Jika Anda ingin file sementara disimpan di folder lain, Anda dapat mengubah pengaturan penyimpanan menggunakan `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}

Saat Anda menggunakan `temp_files_root_path`, Aspose.Slides tidak secara otomatis membuat folder untuk menyimpan file sementara. Anda harus membuat folder tersebut secara manual. 

{{% /alert %}}

### **Dispose Presentation Objects to Release Memory**

Saat memproses presentasi besar, pastikan instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dibuang dengan benar sehingga memori yang dipakai dilepaskan. Cara yang disarankan adalah menggunakan context manager (`with slides.Presentation(...) as presentation:`) seperti yang ditunjukkan pada contoh di atas; ini secara otomatis menutup presentasi dan membebaskan sumber daya yang tidak dikelola ketika blok selesai.

Jika Anda membuat presentasi tanpa blok `with`, panggil secara eksplisit `presentation.dispose()` setelah selesai menggunakannya, dan hapus referensi yang tersisa agar garbage collector Python dapat mengambil kembali memori.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...proses presentasi...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# Lepaskan sumber daya secara eksplisit.
presentation.dispose()
```

## **FAQ**

**What data in an Aspose.Slides presentation is treated as BLOB and controlled by BLOB options?**

Objek biner besar seperti gambar, audio, dan video diperlakukan sebagai BLOB. Seluruh berkas presentasi juga melibatkan penanganan BLOB ketika dimuat atau disimpan. Objek-objek ini diatur oleh kebijakan BLOB yang memungkinkan Anda mengelola penggunaan memori dan menumpahkan ke file sementara bila diperlukan.

**Where do I configure BLOB handling rules during presentation loading?**

Gunakan [LoadOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/) dengan [BlobManagementOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/blobmanagementoptions/). Di sana Anda mengatur batas memori untuk BLOB, mengizinkan atau melarang file sementara, memilih root path untuk file sementara, dan memilih perilaku penguncian sumber.

**Do BLOB settings affect performance, and how do I balance speed vs memory?**

Ya. Menyimpan BLOB di memori memaksimalkan kecepatan tetapi meningkatkan konsumsi RAM; menurunkan batas memori memindahkan lebih banyak pekerjaan ke file sementara, mengurangi RAM dengan biaya I/O tambahan. Sesuaikan ambang [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/id/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) untuk mencapai keseimbangan yang tepat bagi beban kerja dan lingkungan Anda.

**Do BLOB options help when opening extremely large presentations (e.g., gigabytes)?**

Ya. [BlobManagementOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/blobmanagementoptions/) dirancang untuk skenario tersebut: mengaktifkan file sementara dan menggunakan penguncian sumber dapat secara signifikan mengurangi penggunaan RAM puncak dan menstabilkan pemrosesan untuk deck yang sangat besar.

**Can I use BLOB policies when loading from streams instead of disk files?**

Ya. Aturan yang sama berlaku untuk stream: instance presentasi dapat memiliki dan mengunci stream input (tergantung pada mode penguncian yang dipilih), dan file sementara digunakan bila diizinkan, menjaga penggunaan memori tetap dapat diprediksi selama pemrosesan.