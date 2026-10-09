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
- ambil video
- bingkai video
- sumber web
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengekstrak bingkai video secara programatis dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP via Java. Panduan cepat cara melakukannya."
---
## **Pendahuluan**

Video dapat membantu menjelaskan ide dan menarik perhatian audiens. Aspose.Slides untuk PHP via Java memungkinkan Anda menambahkan bingkai video ke slide, menyesuaikan pengaturan pemutaran, mengelola caption, dan mengekstrak data video yang disematkan.

PowerPoint mendukung video lokal dan tautan ke video daring, seperti video YouTube.

Untuk merepresentasikan data video dan bingkai video, Aspose.Slides menyediakan kelas [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) , kelas [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) , dan tipe relevan lainnya.

## **Buat Bingkai Video yang Disematkan**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat bingkai video untuk menyematkan video dalam presentasi Anda.

Contoh ini menyematkan video lokal pada slide pertama dari presentasi yang ada dan menyimpan hasilnya. Koordinat dan dimensi bingkai dalam poin. Stream tetap terbuka sampai penyimpanan selesai karena [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) menguncinya selama presentasi menggunakannya.

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

Anda juga dapat menyertakan jalur video lokal langsung ke [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). Contoh ini menyematkan video pada slide pertama dari presentasi baru. Video harus tetap dapat diakses hingga presentasi disimpan.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Buat Bingkai Video dengan Video dari Sumber Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) mendukung video daring dalam presentasi. Anda dapat membuat bingkai video yang menautkan ke video daring, seperti video YouTube.

Contoh ini menambahkan tautan video YouTube dan thumbnail ke slide pertama. Ganti identifier video untuk menggunakan video lain. Metode [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) meminta pemutaran otomatis. Mengunduh thumbnail dan memutar video memerlukan akses internet. Penampil presentasi juga harus mendukung pemutaran video daring.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Putar Video dalam Mode Layar Penuh**

Dalam presentasi pelatihan, Anda dapat memutar demonstrasi perangkat lunak dalam mode layar penuh agar audiens dapat melihat detailnya. Panggil [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) dengan `true` untuk mengaktifkan perilaku ini selama pemutaran.

Contoh ini membuka sebuah presentasi, menemukan [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) pertama pada slide pertama, dan mengaktifkan pemutaran layar penuh. Presentasi masukan harus berisi setidaknya satu slide dengan bingkai video yang ada pada slide pertama.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pemutaran layar penuh mengontrol bagaimana video ditampilkan. Secara terpisah, [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) mengontrol apakah video mulai otomatis atau saat diklik, dan [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) mengontrol apakah video diulang. Untuk memilih perilaku mulai, atur mode pemutaran ke [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). Contoh ini mempertahankan pengaturan mulai dan loop yang ada.

## **Putar Ulang Video Setelah Pemutaran**

Dalam presentasi pelatihan, mengembalikan video demonstrasi ke awal membuatnya siap bagi presenter untuk memutar lagi. Panggil [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) dengan `true` untuk mengembalikan video ke awal setelah pemutaran selesai.

Contoh ini membuka sebuah presentasi, menemukan [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) pertama pada slide pertama, dan mengaktifkan pemutaran ulang. Ini menonaktifkan looping sehingga pemutaran dapat selesai dan mengatur pemutaran untuk mulai saat diklik. Presentasi masukan harus berisi setidaknya satu slide dengan bingkai video yang ada pada slide pertama.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pemutaran ulang mengembalikan video ke awal tanpa memulai kembali. Sebaliknya, memanggil [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) dengan `true` mengulang pemutaran secara otomatis. Biarkan looping dinonaktifkan ketika Anda ingin video selesai dan tetap siap diputar ulang. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) secara terpisah mengontrol startup otomatis atau saat diklik; contoh ini menggunakan [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) sehingga presenter yang mengendalikan kapan pemutaran dimulai. Atur mode pemutaran setelah pengaturan loop, seperti yang ditunjukkan dalam contoh. Pemutaran ulang berfungsi terpisah dari [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Potong Bingkai Video**

Gunakan [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) dan [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) untuk melewati bagian awal atau akhir video selama pemutaran. Kedua nilai dalam milidetik. Pemotongan mengubah pengaturan pemutaran tanpa mengubah data video yang disematkan.

**Set Trim Settings**

Contoh ini menyematkan video lokal dan melewati 2,5 detik pertama serta 1 detik terakhir selama pemutaran. Gunakan video lebih panjang dari 3,5 detik sehingga segmen yang dapat diputar tetap ada.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Read Trim Settings**

Contoh ini mencetak nilai pemotongan bingkai video pertama pada slide pertama dalam milidetik. Presentasi harus berisi setidaknya satu slide. Jika slide tersebut tidak memiliki bingkai video, tidak ada yang dicetak. Contoh sebelumnya menghasilkan nilai 2500 dan 1000.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Kelola Caption Video**

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk bingkai video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan diakses melalui metode [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Add Captions to a Video Frame**

Contoh ini menyematkan video lokal dan menambahkan track caption WebVTT berlabel English. Stempel waktu caption harus cocok dengan video. Presentasi yang disimpan mencakup video dan captionnya.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kelas [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari sebuah stream.

**Extract Captions from a Video Frame**

Contoh ini menyimpan semua track caption dari bingkai video pada slide pertama sebagai file WebVTT terpisah. Nomor berurutan menjaga file output tetap unik. Konsol melaporkan jumlah track yang diekstrak. Presentasi harus berisi setidaknya satu slide.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

Setiap objek [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) menampilkan identifier caption, label, data biner, dan teks caption sebagai string UTF-8.

**Remove Captions from a Video Frame**

Contoh ini menghapus semua caption dari bingkai video pada posisi shape pertama di slide pertama dan menyimpan hasilnya. Asumsinya slide dan shape ada serta shape tersebut adalah bingkai video.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jika Anda hanya perlu menghapus satu track caption, gunakan metode [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) atau [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) alih-alih [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

## **Ekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi.

Contoh ini mengekstrak video yang disematkan dari setiap slide ke dalam file biner terpisah yang diberi nomor. Video yang ditautkan dilewati karena tidak memiliki data yang disematkan. Konsol mencetak tipe MIME setiap video dan total jumlahnya. Output menggunakan ekstensi generik `.bin`; ubah sesuai tipe media yang dilaporkan bila diperlukan.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Parameter pemutaran video apa yang dapat diubah untuk bingkai video?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (otomatis atau saat diklik) dan [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). Opsi-opsi ini tersedia melalui metode objek [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Ketika Anda menyematkan video lokal, data biner termasuk dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file video. Ketika Anda menautkan ke video daring dan menambahkan thumbnail, presentasi menyimpan tautan dan gambar pratinjau alih-alih data video, sehingga peningkatan ukuran biasanya lebih kecil.

**Bisakah saya mengganti video dalam bingkai video yang ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) di dalam bingkai sekaligus mempertahankan geometri shape; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang sudah ada.

**Bisakah tipe konten (MIME) video yang disematkan ditentukan?**

Ya. Video yang disematkan memiliki [tipe konten](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.