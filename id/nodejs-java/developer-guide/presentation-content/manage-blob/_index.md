---
title: Kelola BLOB Presentasi dalam JavaScript untuk Penggunaan Memori yang Efisien
linktitle: Kelola BLOB
type: docs
weight: 10
url: /id/nodejs-java/manage-blob/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola data BLOB dalam JavaScript dengan Aspose.Slides untuk Node.js guna mempermudah operasi file PowerPoint dan OpenDocument untuk penanganan presentasi yang efisien."
---
## **Ikhtisar**

Aspose.Slides menyediakan penanganan berbasis BLOB untuk data biner besar dalam presentasi guna membantu mengurangi penggunaan memori saat bekerja dengan gambar, audio, video, dan file presentasi yang berukuran besar.

Artikel ini menunjukkan cara menggunakan pemrosesan berbasis BLOB untuk menambahkan media besar ke presentasi, mengekspor media besar dari presentasi, dan memuat presentasi besar secara lebih efisien. Artikel ini juga menjelaskan bagaimana file sementara dapat digunakan selama pemrosesan dan cara mengubah folder yang digunakan untuk menyimpannya.

## **Tentang BLOB**

**BLOB** (**Binary Large Object**) biasanya merupakan item besar (foto, presentasi, dokumen, atau media) yang disimpan dalam format biner.  

Aspose.Slides for Node.js via Java memungkinkan Anda menggunakan BLOB untuk objek dengan cara yang mengurangi konsumsi memori ketika berurusan dengan file berukuran besar.

{{% alert title="Info" color="info" %}}
Untuk mengatasi beberapa keterbatasan saat berinteraksi dengan aliran, Aspose.Slides mungkin menyalin konten aliran tersebut. Memuat presentasi besar melalui alirannya akan mengakibatkan penyalinan isi presentasi dan menyebabkan pemuatan yang lambat. Oleh karena itu, ketika Anda bermaksud memuat presentasi besar, kami sangat menyarankan Anda menggunakan jalur file presentasi dan bukan alirannya.
{{% /alert %}}

## **Gunakan BLOB untuk Mengurangi Konsumsi Memori**

### **Tambahkan File Besar melalui BLOB ke Presentasi**

[Aspose.Slides](/slides/id/nodejs-java/) for Node.js via Java memungkinkan Anda menambahkan file besar (dalam contoh ini, file video besar) melalui proses yang melibatkan BLOB untuk mengurangi konsumsi memori.

JavaScript ini menunjukkan cara menambahkan file video besar melalui proses BLOB ke presentasi:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Membuat presentasi baru yang akan ditambahkan video
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Tambahkan video ke presentasi - kami memilih perilaku KeepLocked karena kami
        // tidak berniat mengakses file "veryLargeVideo.avi".
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Menyimpan presentasi. Saat presentasi besar dihasilkan, konsumsi memori
        // tetap rendah selama siklus hidup objek pres
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ekspor File Besar melalui BLOB dari Presentasi**

Aspose.Slides for Node.js via Java memungkinkan Anda mengekspor file besar (dalam contoh ini, file audio atau video) melalui proses yang melibatkan BLOB dari presentasi. Misalnya, Anda mungkin perlu mengekstrak file media besar dari presentasi tetapi tidak ingin file tersebut dimuat ke memori komputer Anda. Dengan mengekspor file melalui proses BLOB, Anda dapat menjaga konsumsi memori tetap rendah.

Kode JavaScript ini mendemonstrasikan operasi yang dijelaskan:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Mengunci file sumber dan TIDAK memuatnya ke memori
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// buat instance Presentation, kunci file "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Simpan setiap video ke file. Untuk mencegah penggunaan memori tinggi, kita memerlukan buffer yang akan digunakan
    // untuk mentransfer data dari aliran video presentasi ke aliran untuk file video yang baru dibuat.
    var buffer = new byte[8 * 1024];
    // Mengiterasi video-video
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Membuka aliran video presentasi. Harap perhatikan bahwa kami sengaja menghindari mengakses properti
        // seperti video.BinaryData - karena properti ini mengembalikan array byte yang berisi video lengkap, yang kemudian
        // menyebabkan byte-byte dimuat ke memori. Kami menggunakan video.GetStream, yang akan mengembalikan Stream - dan TIDAK
        // mengharuskan kami memuat seluruh video ke memori.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
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
    // Jika diperlukan, Anda dapat menerapkan langkah yang sama untuk file audio.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **Tambahkan Gambar sebagai BLOB dalam Presentasi**

Dengan metode dari kelas [**ImageCollection**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ImageCollection) dan [**ImageCollection**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ImageCollection), Anda dapat menambahkan gambar besar sebagai aliran agar diperlakukan sebagai BLOB.

JavaScript ini menunjukkan cara menambahkan gambar besar melalui proses BLOB:

```javascript
var pathToLargeImage = "large_image.jpg";
// membuat presentasi baru yang akan ditambahkan gambar.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Tambahkan gambar ke presentasi - kami memilih perilaku KeepLocked karena kami
        // TIDAK berniat mengakses file "largeImage.png".
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Menyimpan presentasi. Saat presentasi besar dihasilkan, konsumsi memori
        // tetap rendah selama siklus hidup objek pres
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Memori dan Presentasi Besar**

Biasanya, untuk memuat presentasi besar, komputer memerlukan banyak memori sementara. Semua konten presentasi dimuat ke memori dan file (dari mana presentasi dimuat) tidak lagi digunakan.

Pertimbangkan sebuah presentasi PowerPoint besar (large.pptx) yang berisi file video 1,5 GB. Metode standar untuk memuat presentasi dijelaskan dalam kode JavaScript berikut:

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Namun metode ini mengonsumsi sekitar 1,6 GB memori sementara.

### **Muat Presentasi Besar sebagai BLOB**

Melalui proses yang melibatkan BLOB, Anda dapat memuat presentasi besar dengan menggunakan sedikit memori. Kode JavaScript ini menjelaskan implementasi di mana proses BLOB digunakan untuk memuat file presentasi besar (large.pptx):

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ubah Folder untuk File Sementara**

Ketika proses BLOB digunakan, komputer Anda membuat file sementara di folder default untuk file sementara. Jika Anda ingin file sementara disimpan di folder lain, Anda dapat mengubah pengaturan penyimpanan menggunakan `setTempFilesRootPath`:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Saat Anda menggunakan `setTempFilesRootPath`, Aspose.Slides tidak secara otomatis membuat folder untuk menyimpan file sementara. Anda harus membuat folder tersebut secara manual.
{{% /alert %}}

### **Buang Objek Presentasi untuk Membebaskan Memori**

Saat memproses presentasi besar, pastikan instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dibuang dengan benar sehingga memori yang ditempati dilepaskan. Panggil `dispose()` setelah selesai menggunakan presentasi untuk membersihkan sumber daya yang tidak dikelola.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...proses presentasi...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Lepaskan sumber daya secara eksplisit.
presentation.dispose();
```

## **FAQ**

**Data apa dalam presentasi Aspose.Slides yang diperlakukan sebagai BLOB dan dikendalikan oleh opsi BLOB?**  
Objek biner besar seperti gambar, audio, dan video diperlakukan sebagai BLOB. Seluruh file presentasi juga melibatkan penanganan BLOB saat dimuat atau disimpan. Objek-objek ini diatur oleh kebijakan BLOB yang memungkinkan Anda mengelola penggunaan memori dan menumpahkan ke file sementara bila diperlukan.

**Di mana saya mengonfigurasi aturan penanganan BLOB saat memuat presentasi?**  
Gunakan [LoadOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/) dengan [BlobManagementOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/blobmanagementoptions/). Di sana Anda dapat mengatur batas memori untuk BLOB, mengizinkan atau melarang file sementara, memilih jalur root untuk file sementara, dan menentukan perilaku penguncian sumber.

**Apakah pengaturan BLOB memengaruhi kinerja, dan bagaimana menyeimbangkan kecepatan vs memori?**  
Ya. Menyimpan BLOB di memori memaksimalkan kecepatan tetapi meningkatkan konsumsi RAM; menurunkan batas memori memindahkan lebih banyak pekerjaan ke file sementara, mengurangi RAM dengan biaya I/O tambahan. Gunakan metode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) untuk menemukan keseimbangan yang tepat bagi beban kerja dan lingkungan Anda.

**Apakah opsi BLOB membantu saat membuka presentasi yang sangat besar (misalnya gigabyte)?**  
Ya. [BlobManagementOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/blobmanagementoptions/) dirancang untuk skenario tersebut: mengaktifkan file sementara dan menggunakan penguncian sumber dapat secara signifikan mengurangi penggunaan RAM puncak dan menstabilkan pemrosesan untuk dek yang sangat besar.

**Bisakah saya menggunakan kebijakan BLOB saat memuat dari aliran alih-alih file disk?**  
Ya. Aturan yang sama berlaku untuk aliran: instance presentasi dapat memiliki dan mengunci aliran input (tergantung pada mode penguncian yang dipilih), dan file sementara digunakan bila diizinkan, menjaga penggunaan memori tetap dapat diprediksi selama pemrosesan.