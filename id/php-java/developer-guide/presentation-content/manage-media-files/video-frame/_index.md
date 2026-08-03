---
title: Kelola Bingkai Video dalam Presentasi Menggunakan PHP
linktitle: Bingkai Video
type: docs
weight: 10
url: /id/php-java/video-frame/
keywords:
- tambahkan video
- buat video
- sematkan video
- ekstrak video
- mengambil video
- bingkai video
- sumber web
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengekstrak bingkai video secara programatik dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP via Java. Panduan singkat cara melakukannya."
---
## **Pendahuluan**

Video yang ditempatkan dengan tepat dalam presentasi dapat membuat pesan Anda lebih menarik dan meningkatkan tingkat keterlibatan dengan audiens. 

PowerPoint memungkinkan Anda menambahkan video ke slide dalam presentasi dengan dua cara:

* Tambahkan atau sematkan video lokal (disimpan di komputer Anda)
* Tambahkan video daring (dari sumber web seperti YouTube).

Untuk memungkinkan Anda menambahkan video (objek video) ke presentasi, Aspose.Slides menyediakan kelas [Video](https://reference.aspose.com/slides/id/php-java/aspose.slides/video/), kelas [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/), dan tipe relevan lainnya.

## **Buat Bingkai Video Tertanam**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat bingkai video untuk menyematkan video dalam presentasi Anda. 

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi slide melalui indeksnya. 
1. Tambahkan objek [Video](https://reference.aspose.com/slides/id/php-java/aspose.slides/video/) dan berikan jalur file video untuk menyematkan video dalam presentasi.
1. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/) untuk membuat bingkai video.
1. Simpan presentasi yang telah dimodifikasi. 

Kode PHP berikut menunjukkan cara menambahkan video yang disimpan secara lokal ke presentasi:

```php
  # Membuat instance kelas Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Memuat video
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Mengambil slide pertama dan menambahkan bingkai video
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Menyimpan presentasi ke disk
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Sebagai alternatif, Anda dapat menambahkan video dengan memberikan jalur file secara langsung ke metode [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addvideoframe/) :

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Buat Bingkai Video dengan Video dari Sumber Web**

Microsoft [PowerPoint 2013 dan yang lebih baru](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) mendukung video YouTube dalam presentasi. Jika video yang ingin Anda gunakan tersedia secara daring (misalnya di YouTube), Anda dapat menambahkannya ke presentasi melalui tautan webnya. 

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi slide melalui indeksnya. 
1. Tambahkan objek [Video](https://reference.aspose.com/slides/id/php-java/aspose.slides/video/) dan berikan tautan ke video.
1. Atur thumbnail untuk bingkai video. 
1. Simpan presentasi. 

Kode PHP berikut menunjukkan cara menambahkan video dari web ke slide dalam presentasi PowerPoint:

```php
  # Membuat objek Presentation yang mewakili file presentasi
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **Potong Bingkai Video**

Aspose.Slides memungkinkan Anda mengontrol bagian video yang diputar dengan mengatur nilai trim-from-start dan trim-from-end melalui [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/#setTrimFromStart) dan [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/#setTrimFromEnd). Kedua nilai ditentukan dalam milidetik dan menentukan berapa banyak waktu yang dilewati dari awal dan akhir video, masing‑masing. Pengaturan ini mengubah pengaturan pemutaran video dalam presentasi; mereka tidak memotong atau mengubah data biner video yang disematkan.

**Atur Pengaturan Pemotongan**

Untuk membuat bingkai video dan mengatur pengaturan pemotongannya:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Tambahkan objek [Video](https://reference.aspose.com/slides/id/php-java/aspose.slides/video/) ke presentasi.
1. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/) ke slide.
1. Atur nilai trim-from-start dan trim-from-end melalui [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/#setTrimFromStart) dan [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/#setTrimFromEnd).
1. Simpan presentasi yang telah dimodifikasi.

Contoh kode berikut melewati 2,5 detik pertama dan satu detik terakhir dari video yang disematkan selama pemutaran:

```php
$presentation = new Presentation();
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $video = $presentation->getVideos()->addVideo(
        $videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);

    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

**Baca Pengaturan Pemotongan**

Untuk memeriksa pengaturan pemotongan yang ada, muat presentasi, temukan objek [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/) di antara shape pada slide pertama, dan baca nilai melalui [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/#getTrimFromStart) dan [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/#getTrimFromEnd).

Contoh kode berikut menemukan bingkai video pertama pada slide pertama dan melaporkan pengaturan pemotongannya dalam milidetik:

```php
$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trimFromStart = java_values($videoFrame->getTrimFromStart());
            $trimFromEnd = java_values($videoFrame->getTrimFromEnd());

            echo "Trim from start: " . $trimFromStart . " ms\n";
            echo "Trim from end: " . $trimFromEnd . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Kelola Teks Tertutup Video**

Aspose.Slides memungkinkan Anda mengelola teks tertutup (closed captions) untuk bingkai video dalam presentasi PowerPoint. Teks tertutup disimpan dalam format WebVTT dan dapat diakses melalui metode [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Tambahkan Teks Tertutup ke Bingkai Video**

Untuk menambahkan teks tertutup ke bingkai video:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Tambahkan video ke presentasi.
1. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/) ke slide.
1. Gunakan koleksi [CaptionsCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/captionscollection/) yang dikembalikan oleh [getCaptionTracks](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/#getCaptionTracks) untuk menambahkan trek teks WebVTT.
1. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara menambahkan teks tertutup ke bingkai video:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Menambahkan trek teks baru dari file WebVTT.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kelas [CaptionsCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/captionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan teks dari stream.

**Ekstrak Teks Tertutup dari Bingkai Video**

Untuk mengekstrak teks tertutup dari bingkai video:

1. Muat presentasi yang berisi video.
1. Temukan objek [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/) target.
1. Iterasi melalui koleksi [getCaptionTracks](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Simpan setiap trek teks ke file `.vtt`.

Kode berikut menunjukkan cara mengekstrak teks tertutup dari bingkai video:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // Menyimpan trek teks ke file WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Setiap objek [Captions](https://reference.aspose.com/slides/id/php-java/aspose.slides/captions/) menampilkan identifier teks, label, data biner, dan teks caption sebagai string UTF‑8.

**Hapus Teks Tertutup dari Bingkai Video**

Untuk menghapus teks tertutup dari bingkai video:

1. Muat presentasi yang berisi video.
1. Dapatkan objek [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/) target.
1. Hapus trek teks dari koleksi [getCaptionTracks](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara menghapus semua teks tertutup dari bingkai video:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // tipe: VideoFrame

    // Menghapus semua teks tertutup dari bingkai video.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jika Anda perlu menghapus hanya satu trek teks, gunakan metode [remove](https://reference.aspose.com/slides/id/php-java/aspose.slides/captionscollection/#remove) atau [removeAt](https://reference.aspose.com/slides/id/php-java/aspose.slides/captionscollection/#removeAt) alih‑alih [clear](https://reference.aspose.com/slides/id/php-java/aspose.slides/captionscollection/#clear).

## **Ekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) untuk memuat presentasi yang berisi video.
2. Iterasi melalui semua objek [Slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/).
3. Iterasi melalui semua objek [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/) untuk menemukan [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/).
4. Simpan video ke disk.

Kode PHP berikut menunjukkan cara mengekstrak video pada slide presentasi:

```php
  # Membuat objek Presentation yang mewakili file presentasi
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Mendapatkan ekstensi file
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Parameter pemutaran video mana yang dapat diubah untuk VideoFrame?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/setplaymode/) (otomatis atau saat diklik) dan [pengulangan](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/setplayloopmode/). Opsi ini tersedia melalui properti objek [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/).

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Ketika Anda menyematkan video lokal, data biner termasuk dalam dokumen, sehingga ukuran presentasi bertambah secara proporsional dengan ukuran file. Ketika Anda menambahkan video daring, tautan dan thumbnail disematkan, sehingga peningkatan ukuran lebih kecil.

**Bisakah saya mengganti video dalam VideoFrame yang ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/setembeddedvideo/) di dalam bingkai sambil mempertahankan geometri shape; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang ada.

**Dapatkah tipe konten (MIME) video yang disematkan ditentukan?**

Ya. Video yang disematkan memiliki [tipe konten](https://reference.aspose.com/slides/id/php-java/aspose.slides/video/getcontenttype/) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.