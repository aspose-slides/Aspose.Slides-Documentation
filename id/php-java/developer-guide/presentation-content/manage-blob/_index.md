---
title: Kelola BLOB Presentasi di PHP untuk Penggunaan Memori Efisien
linktitle: Kelola BLOB
type: docs
weight: 10
url: /id/php-java/manage-blob/
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
- PHP
- Aspose.Slides
description: "Kelola data BLOB di Aspose.Slides untuk PHP via Java untuk mempermudah operasi file PowerPoint dan OpenDocument guna penanganan presentasi yang efisien."
---
## **Gambaran Umum**

Aspose.Slides menyediakan penanganan berbasis BLOB untuk data biner besar dalam presentasi guna membantu mengurangi konsumsi memori saat bekerja dengan gambar, audio, video, dan file presentasi berukuran besar.

Artikel ini menunjukkan cara menggunakan pemrosesan berbasis BLOB untuk menambahkan media besar ke sebuah presentasi, mengekspor media besar dari presentasi, dan memuat presentasi besar secara lebih efisien. Artikel ini juga menjelaskan bagaimana file sementara dapat digunakan selama pemrosesan dan cara mengubah folder yang digunakan untuk menyimpannya.

## **Tentang BLOB**

**BLOB** (**Binary Large Object**) biasanya merupakan item besar (foto, presentasi, dokumen, atau media) yang disimpan dalam format biner.  

Aspose.Slides untuk PHP via Java memungkinkan Anda menggunakan BLOB untuk objek dengan cara yang mengurangi konsumsi memori ketika berurusan dengan file besar.

{{% alert title="Info" color="info" %}}
Untuk mengatasi beberapa batasan saat berinteraksi dengan aliran, Aspose.Slides dapat menyalin konten aliran tersebut. Memuat sebuah presentasi besar melalui alirannya akan menghasilkan penyalinan isi presentasi dan menyebabkan pemuatan yang lambat. Oleh karena itu, ketika Anda berniat memuat sebuah presentasi besar, kami sangat menyarankan agar Anda menggunakan jalur file presentasi dan bukan alirannya.
{{% /alert %}}

## **Gunakan BLOB untuk Mengurangi Konsumsi Memori**

### **Tambahkan File Besar melalui BLOB ke Presentasi**

[Aspose.Slides](/slides/id/php-java/) for Java memungkinkan Anda menambahkan file besar (dalam hal ini, file video besar) melalui proses yang melibatkan BLOB untuk mengurangi konsumsi memori.

Kode Java ini menunjukkan cara menambahkan file video besar melalui proses BLOB ke sebuah presentasi:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Membuat presentasi baru yang akan ditambahkan video
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Mari tambahkan video ke presentasi - kami memilih perilaku KeepLocked karena kami
      # tidak berniat mengakses file "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Menyimpan presentasi. Saat presentasi besar dioutputkan, konsumsi memori
      # tetap rendah selama siklus hidup objek pres
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ekspor File Besar melalui BLOB dari Presentasi**

Aspose.Slides untuk PHP via Java memungkinkan Anda mengekspor file besar (misalnya file audio atau video) melalui proses yang melibatkan BLOB dari presentasi. Sebagai contoh, Anda mungkin perlu mengekstrak file media besar dari sebuah presentasi tetapi tidak ingin file tersebut dimuat ke memori komputer Anda. Dengan mengekspor file melalui proses BLOB, Anda dapat menjaga konsumsi memori tetap rendah.

Kode berikut mendemonstrasikan operasi yang dijelaskan:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Mengunci file sumber dan TIDAK memuatnya ke memori
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Membuat instance Presentation, mengunci file "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Simpan setiap video ke file. Untuk mencegah penggunaan memori tinggi, kami memerlukan buffer yang akan digunakan
    # untuk mentransfer data dari stream video presentasi ke stream untuk file video yang baru dibuat.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Mengiterasi video-video
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Membuka stream video presentasi. Harap dicatat bahwa kami sengaja menghindari mengakses properti
      # seperti video.BinaryData - karena properti ini mengembalikan array byte yang berisi video penuh, yang kemudian
      # menyebabkan byte-byte dimuat ke memori. Kami menggunakan video.GetStream, yang akan mengembalikan Stream - dan TIDAK
      # memaksa kami memuat seluruh video ke memori.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # Konsumsi memori akan tetap rendah terlepas dari ukuran video atau presentasi.
    }
    # Jika diperlukan, Anda dapat menerapkan langkah yang sama untuk file audio.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Tambahkan Gambar sebagai BLOB ke Presentasi**

Dengan metode dari kelas [ImageCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagecollection/) Anda dapat menambahkan gambar besar sebagai aliran agar diperlakukan sebagai BLOB.

Kode PHP ini menunjukkan cara menambahkan gambar besar melalui proses BLOB:

```php
  $pathToLargeImage = "large_image.jpg";
  # membuat presentasi baru yang akan ditambahkan gambar.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Mari tambahkan gambar ke presentasi - kami memilih perilaku KeepLocked karena kami
      # TIDAK berniat mengakses file "largeImage.png" file.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Menyimpan presentasi. Saat presentasi besar dioutputkan, konsumsi memori
      # tetap rendah selama siklus hidup objek pres
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Memori dan Presentasi Besar**

Biasanya, untuk memuat sebuah presentasi besar, komputer memerlukan banyak memori sementara. Seluruh konten presentasi dimuat ke memori dan file (dari mana presentasi dimuat) tidak lagi digunakan.

Pertimbangkan sebuah presentasi PowerPoint besar (large.pptx) yang berisi file video 1,5 GB. Metode standar untuk memuat presentasi dijelaskan dalam kode PHP berikut:

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Namun metode ini mengkonsumsi sekitar 1,6 GB memori sementara.

### **Muat Presentasi Besar sebagai BLOB**

Melalui proses yang melibatkan BLOB, Anda dapat memuat presentasi besar sambil menggunakan sedikit memori. Kode PHP ini menjelaskan implementasi di mana proses BLOB digunakan untuk memuat file presentasi besar (large.pptx):

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ubah Folder untuk File Sementara**

Saat proses BLOB digunakan, komputer Anda membuat file sementara di folder default untuk file sementara. Jika Anda ingin file sementara disimpan di folder lain, Anda dapat mengubah pengaturan penyimpanan menggunakan `setTempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
Saat Anda menggunakan `setTempFilesRootPath`, Aspose.Slides tidak secara otomatis membuat folder untuk menyimpan file sementara. Anda harus membuat folder tersebut secara manual.
{{% /alert %}}

### **Buang Objek Presentation untuk Membebaskan Memori**

Saat memproses presentasi besar, pastikan instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dibuang dengan benar sehingga memori yang ditempati dilepaskan. Panggil `dispose()` setelah selesai menggunakan presentasi untuk membebaskan sumber daya yang tidak dikelola.

```php
$presentation = new Presentation("large.pptx");

# ...proses presentasi...
$presentation->save("large.pdf", SaveFormat::Pdf);

# Lepaskan sumber daya secara eksplisit.
$presentation->dispose();
```

## **FAQ**

**Data apa dalam presentasi Aspose.Slides yang diperlakukan sebagai BLOB dan dikendalikan oleh opsi BLOB?**  
Objek biner besar seperti gambar, audio, dan video diperlakukan sebagai BLOB. Seluruh file presentasi juga melibatkan penanganan BLOB saat dimuat atau disimpan. Objek-objek ini diatur oleh kebijakan BLOB yang memungkinkan Anda mengelola penggunaan memori dan penulisan ke file sementara bila diperlukan.

**Di mana saya mengkonfigurasi aturan penanganan BLOB saat memuat presentasi?**  
Gunakan [LoadOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/) dengan [BlobManagementOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/blobmanagementoptions/). Di sana Anda dapat menetapkan batas memori dalam untuk BLOB, mengizinkan atau melarang file sementara, memilih jalur akar untuk file sementara, dan menentukan perilaku penguncian sumber.

**Apakah pengaturan BLOB memengaruhi kinerja, dan bagaimana saya menyeimbangkan kecepatan vs memori?**  
Ya. Menjaga BLOB dalam memori memaksimalkan kecepatan tetapi meningkatkan konsumsi RAM; menurunkan batas memori mengalihkan lebih banyak pekerjaan ke file sementara, mengurangi RAM dengan biaya I/O tambahan. Gunakan metode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/id/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) untuk mencapai keseimbangan yang tepat bagi beban kerja dan lingkungan Anda.

**Apakah opsi BLOB membantu saat membuka presentasi yang sangat besar (misalnya gigabyte)?**  
Ya. [BlobManagementOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/blobmanagementoptions/) dirancang untuk skenario tersebut: mengaktifkan file sementara dan menggunakan penguncian sumber dapat secara signifikan mengurangi penggunaan RAM puncak dan menstabilkan pemrosesan untuk deck yang sangat besar.

**Bisakah saya menggunakan kebijakan BLOB saat memuat dari aliran alih-alih file disk?**  
Ya. Aturan yang sama berlaku untuk aliran: instance presentasi dapat memiliki dan mengunci aliran input (tergantung pada mode penguncian yang dipilih), dan file sementara digunakan bila diizinkan, menjaga penggunaan memori tetap dapat diprediksi selama pemrosesan.