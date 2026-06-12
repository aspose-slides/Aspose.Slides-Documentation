---
title: Kelola Frame Video dalam Presentasi Menggunakan PHP
linktitle: Frame Video
type: docs
weight: 10
url: /id/php-java/video-frame/
keywords:
- menambahkan video
- membuat video
- menyematkan video
- mengekstrak video
- mengambil video
- frame video
- sumber web
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengekstrak frame video secara programatik dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP via Java. Panduan singkat yang cepat."
---
## **Introduction**

Video yang ditempatkan dengan tepat dalam sebuah presentasi dapat membuat pesan Anda lebih menarik dan meningkatkan tingkat keterlibatan dengan audiens Anda. 

PowerPoint memungkinkan Anda menambahkan video ke slide dalam sebuah presentasi dengan dua cara:

* Tambahkan atau sematkan video lokal (disimpan di mesin Anda)
* Tambahkan video daring (dari sumber web seperti YouTube).

Untuk memungkinkan Anda menambahkan video (objek video) ke sebuah presentasi, Aspose.Slides menyediakan kelas [Video](https://reference.aspose.com/slides/id/php-java/aspose.slides/video/), kelas [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/), dan tipe relevan lainnya.

## **Create Embedded Video Frames**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat frame video untuk menyematkan video tersebut dalam presentasi Anda. 

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi slide melalui indeksnya. 
1. Tambahkan objek [Video](https://reference.aspose.com/slides/id/php-java/aspose.slides/video/) dan berikan path file video untuk menyematkan video ke dalam presentasi.
1. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/) untuk membuat frame bagi video.
1. Simpan presentasi yang telah dimodifikasi. 

Kode PHP berikut menunjukkan cara menambahkan video yang disimpan secara lokal ke dalam sebuah presentasi:

```php
  # Membuat instance kelas Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Memuat video
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Mendapatkan slide pertama dan menambahkan videoframe
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

Sebagai alternatif, Anda dapat menambahkan video dengan langsung memberikan path file ke metode [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addvideoframe/):

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


## **Create Video Frames with Video from Web Sources**

Microsoft [PowerPoint 2013 dan yang lebih baru](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) mendukung video YouTube dalam presentasi. Jika video yang ingin Anda gunakan tersedia secara daring (misalnya di YouTube), Anda dapat menambahkannya ke presentasi melalui tautan webnya. 

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi slide melalui indeksnya. 
1. Tambahkan objek [Video](https://reference.aspose.com/slides/id/php-java/aspose.slides/video/) dan berikan tautan ke video.
1. Atur thumbnail untuk frame video. 
1. Simpan presentasi. 

Kode PHP berikut menunjukkan cara menambahkan video dari web ke slide dalam presentasi PowerPoint:

```php
  # Membuat instance objek Presentation yang merepresentasikan file presentasi
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

## **Manage Video Captions**

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk frame video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui metode [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Add Captions to a Video Frame**

Untuk menambahkan caption ke frame video:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Tambahkan video ke dalam presentasi.
1. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/) ke slide.
1. Gunakan koleksi [CaptionsCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/captionscollection/) yang dikembalikan oleh [getCaptionTracks](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/#getCaptionTracks) untuk menambahkan trek caption WebVTT.
1. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara menambahkan caption ke frame video:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Menambahkan trek caption baru dari file WebVTT.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kelas [CaptionsCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/captionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari sebuah stream.

**Extract Captions from a Video Frame**

Untuk mengekstrak caption dari frame video:

1. Muat presentasi yang berisi video.
2. Temukan objek [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/) yang menjadi target.
3. Iterasi melalui koleksi [getCaptionTracks](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/#getCaptionTracks).
4. Simpan setiap trek caption ke file `.vtt`.

Kode berikut menunjukkan cara mengekstrak caption dari frame video:

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
                // Menyimpan trek caption ke file WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Setiap objek [Captions](https://reference.aspose.com/slides/id/php-java/aspose.slides/captions/) menampilkan identifier caption, label, data biner, dan teks caption sebagai string UTF-8.

**Remove Captions from a Video Frame**

Untuk menghapus caption dari frame video:

1. Muat presentasi yang berisi video.
2. Dapatkan objek [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/) yang menjadi target.
3. Hapus trek caption dari koleksi [getCaptionTracks](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/#getCaptionTracks).
4. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara menghapus semua caption dari frame video:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // tipe: VideoFrame

    // Menghapus semua caption dari frame video.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jika Anda perlu menghapus hanya satu trek caption, gunakan metode [remove](https://reference.aspose.com/slides/id/php-java/aspose.slides/captionscollection/#remove) atau [removeAt](https://reference.aspose.com/slides/id/php-java/aspose.slides/captionscollection/#removeAt) alih-alih [clear](https://reference.aspose.com/slides/id/php-java/aspose.slides/captionscollection/#clear).

## **Extract Video from Slides**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) untuk memuat presentasi yang berisi video.
2. Iterasi melalui semua objek [Slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/).
3. Iterasi melalui semua objek [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/) untuk menemukan sebuah [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/).
4. Simpan video ke disk.

Kode PHP berikut menunjukkan cara mengekstrak video pada slide presentasi:

```php
  # Membuat instance objek Presentation yang merepresentasikan file presentasi
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

**Parameter pemutaran video apa yang dapat diubah untuk VideoFrame?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/setplaymode/) (otomatis atau pada klik) dan [pengulangan](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/setplayloopmode/). Opsi-opsi ini tersedia melalui properti objek [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/).

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Ketika Anda menyematkan video lokal, data biner disertakan dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Ketika Anda menambahkan video daring, sebuah tautan dan thumbnail disematkan, sehingga peningkatan ukuran lebih kecil.

**Bisakah saya mengganti video dalam VideoFrame yang sudah ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/setembeddedvideo/) di dalam frame sambil mempertahankan geometri shape; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang sudah ada.

**Apakah tipe konten (MIME) dari video yang disematkan dapat ditentukan?**

Ya. Video yang disematkan memiliki [tipe konten](https://reference.aspose.com/slides/id/php-java/aspose.slides/video/getcontenttype/) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.