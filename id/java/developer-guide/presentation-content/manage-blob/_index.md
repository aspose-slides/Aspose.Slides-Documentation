---
title: Kelola BLOB Presentasi di Java untuk Penggunaan Memori yang Efisien
linktitle: Kelola BLOB
type: docs
weight: 10
url: /id/java/manage-blob/
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
- Java
- Aspose.Slides
description: "Kelola data BLOB di Aspose.Slides untuk Java guna menyederhanakan operasi file PowerPoint dan OpenDocument untuk penanganan presentasi yang efisien."
---
## **Gambaran Umum**

Aspose.Slides menyediakan penanganan berbasis BLOB untuk data biner besar dalam presentasi guna membantu mengurangi konsumsi memori saat bekerja dengan gambar, audio, video, dan berkas presentasi berukuran besar.

Artikel ini menunjukkan cara menggunakan pemrosesan berbasis BLOB untuk menambahkan media besar ke presentasi, mengekspor media besar dari presentasi, dan memuat presentasi besar dengan lebih efisien. Artikel ini juga menjelaskan bagaimana berkas sementara dapat digunakan selama pemrosesan dan cara mengubah folder yang digunakan untuk menyimpannya.

## **Tentang BLOB**

**BLOB** (**Binary Large Object**) biasanya merupakan item berukuran besar (foto, presentasi, dokumen, atau media) yang disimpan dalam format biner. 

Aspose.Slides for Java memungkinkan Anda menggunakan BLOB untuk objek dengan cara yang mengurangi konsumsi memori ketika berkas besar terlibat. 

{{% alert title="Info" color="info" %}}
Untuk mengatasi beberapa batasan saat berinteraksi dengan aliran, Aspose.Slides dapat menyalin konten aliran tersebut. Memuat presentasi besar melalui alirannya akan mengakibatkan penyalinan isi presentasi dan menyebabkan pemuatan yang lambat. Oleh karena itu, ketika Anda berniat memuat presentasi besar, sangat disarankan untuk menggunakan jalur berkas presentasi dan bukan alirannya.
{{% /alert %}}

## **Gunakan BLOB untuk Mengurangi Konsumsi Memori**

### **Tambahkan Berkas Besar melalui BLOB ke Presentasi**

[Aspose.Slides](/slides/id/java/) for Java memungkinkan Anda menambahkan berkas besar (dalam contoh ini, berkas video besar) melalui proses yang melibatkan BLOB untuk mengurangi konsumsi memori.

Contoh Java ini menunjukkan cara menambahkan berkas video besar melalui proses BLOB ke presentasi:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Membuat presentasi baru tempat video akan ditambahkan
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Mari tambahkan video ke presentasi - kami memilih perilaku KeepLocked karena kami
        // tidak bermaksud mengakses berkas "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Menyimpan presentasi. Saat presentasi besar dihasilkan, konsumsi memori
        // tetap rendah selama siklus hidup objek pres 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ekspor Berkas Besar melalui BLOB dari Presentasi**

Aspose.Slides for Java memungkinkan Anda mengekspor berkas besar (misalnya berkas audio atau video) melalui proses yang melibatkan BLOB dari presentasi. Misalnya, Anda mungkin perlu mengekstrak berkas media besar dari presentasi tetapi tidak ingin berkas tersebut dimuat ke memori komputer Anda. Dengan mengekspor berkas melalui proses BLOB, Anda dapat menjaga konsumsi memori tetap rendah. 

Kode Java berikut mendemonstrasikan operasi yang dijelaskan:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Mengunci berkas sumber dan TIDAK memuatnya ke memori
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// buat instance Presentation, kunci berkas "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Mari simpan setiap video ke berkas. Untuk mencegah penggunaan memori tinggi, kita memerlukan buffer yang akan digunakan
    // untuk mentransfer data dari aliran video presentasi ke aliran untuk berkas video yang baru dibuat.
    byte[] buffer = new byte[8 * 1024];

    // Iterasi melalui video-video
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Membuka aliran video presentasi. Harap dicatat bahwa kami sengaja menghindari mengakses properti
        // seperti video.BinaryData - karena properti ini mengembalikan array byte yang berisi video lengkap, yang kemudian
        // menyebabkan byte dimuat ke memori. Kami menggunakan video.GetStream, yang akan mengembalikan Stream - dan TIDAK
        //  memerlukan kami untuk memuat seluruh video ke memori.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Konsumsi memori akan tetap rendah terlepas dari ukuran video atau presentasi.
    }
    // Jika diperlukan, Anda dapat menerapkan langkah yang sama untuk berkas audio. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Tambahkan Gambar sebagai BLOB ke Presentasi**

Dengan metode dari antarmuka [**IImageCollection**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IImageCollection) dan kelas [**ImageCollection**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ImageCollection), Anda dapat menambahkan gambar besar sebagai aliran agar diperlakukan sebagai BLOB. 

Kode Java ini menunjukkan cara menambahkan gambar besar melalui proses BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// membuat presentasi baru tempat gambar akan ditambahkan.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Mari tambahkan gambar ke presentasi - kami memilih perilaku KeepLocked karena kami
		// TIDAK berniat mengakses berkas "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Menyimpan presentasi. Saat presentasi besar dihasilkan, konsumsi memori
		// tetap rendah selama siklus hidup objek pres
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Memori dan Presentasi Besar**

Secara umum, untuk memuat presentasi besar, komputer memerlukan banyak memori sementara. Semua konten presentasi dimuat ke dalam memori dan berkas (dari mana presentasi dimuat) tidak lagi digunakan. 

Pertimbangkan sebuah presentasi PowerPoint besar (large.pptx) yang berisi berkas video 1,5 GB. Metode standar untuk memuat presentasi dijelaskan dalam kode Java berikut:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Namun metode ini mengonsumsi sekitar 1,6 GB memori sementara. 

### **Muat Presentasi Besar sebagai BLOB**

Melalui proses yang melibatkan BLOB, Anda dapat memuat presentasi besar dengan menggunakan sedikit memori. Kode Java berikut menjelaskan implementasi di mana proses BLOB digunakan untuk memuat berkas presentasi besar (large.pptx):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ubah Folder untuk Berkas Sementara**

Saat proses BLOB digunakan, komputer Anda membuat berkas sementara di folder default untuk berkas sementara. Jika Anda ingin berkas sementara disimpan di folder lain, Anda dapat mengubah pengaturan penyimpanan menggunakan `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Ketika Anda menggunakan `TempFilesRootPath`, Aspose.Slides tidak secara otomatis membuat folder untuk menyimpan berkas sementara. Anda harus membuat folder tersebut secara manual. 
{{% /alert %}}

### **Bebaskan Objek Presentasi untuk Melepaskan Memori**

Saat memproses presentasi besar, pastikan bahwa instance [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) dibuang dengan benar sehingga memori yang ditempati dilepaskan. Panggil `dispose()` setelah selesai menggunakan presentasi untuk membebaskan sumber daya yang tidak dikelola.

```java
Presentation presentation = new Presentation("large.pptx");

// ...proses presentasi...
presentation.save("large.pdf", SaveFormat.Pdf);

// Lepaskan sumber daya secara eksplisit.
presentation.dispose();
```

## **FAQ**

**Data apa dalam presentasi Aspose.Slides yang diperlakukan sebagai BLOB dan dikendalikan oleh opsi BLOB?**

Objek biner besar seperti gambar, audio, dan video diperlakukan sebagai BLOB. Seluruh berkas presentasi juga melibatkan penanganan BLOB saat dimuat atau disimpan. Objek-objek ini diatur oleh kebijakan BLOB yang memungkinkan Anda mengelola penggunaan memori dan menumpahkan ke berkas sementara bila diperlukan.

**Di mana saya mengonfigurasi aturan penanganan BLOB selama pemuatan presentasi?**

Gunakan [LoadOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/) dengan [BlobManagementOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/blobmanagementoptions/). Di sana Anda menetapkan batas memori untuk BLOB, mengizinkan atau menolak berkas sementara, memilih jalur akar untuk berkas sementara, dan memilih perilaku penguncian sumber.

**Apakah pengaturan BLOB memengaruhi kinerja, dan bagaimana saya menyeimbangkan kecepatan vs memori?**

Ya. Menyimpan BLOB di memori memaksimalkan kecepatan tetapi meningkatkan konsumsi RAM; menurunkan batas memori mengalihkan lebih banyak pekerjaan ke berkas sementara, mengurangi RAM dengan biaya I/O tambahan. Gunakan metode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/id/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) untuk mencapai keseimbangan yang tepat bagi beban kerja dan lingkungan Anda.

**Apakah opsi BLOB membantu saat membuka presentasi yang sangat besar (misalnya gigabyte)?**

Ya. [BlobManagementOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/blobmanagementoptions/) dirancang untuk skenario tersebut: mengaktifkan berkas sementara dan menggunakan penguncian sumber dapat secara signifikan mengurangi penggunaan RAM puncak dan menstabilkan pemrosesan untuk dek yang sangat besar.

**Bisakah saya menggunakan kebijakan BLOB saat memuat dari aliran alih-alih berkas disk?**

Ya. Aturan yang sama berlaku untuk aliran: instance presentasi dapat memiliki dan mengunci aliran masukan (tergantung pada mode penguncian yang dipilih), dan berkas sementara digunakan bila diizinkan, menjaga penggunaan memori tetap dapat diprediksi selama pemrosesan.