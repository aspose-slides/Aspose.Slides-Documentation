---
title: Kelola Bingkai Video dalam Presentasi di Android
linktitle: Bingkai Video
type: docs
weight: 10
url: /id/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengekstrak bingkai video secara programatis dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Android via Java. Panduan cepat langkah demi langkah."
---
## **Pendahuluan**

Video dapat membantu menjelaskan ide dan melibatkan audiens. Aspose.Slides untuk Android melalui Java memungkinkan Anda menambahkan bingkai video ke slide, menyesuaikan pengaturan pemutaran, mengelola caption, dan mengekstrak data video yang disematkan.

PowerPoint mendukung video lokal dan tautan ke video daring, seperti video YouTube.

Untuk merepresentasikan data video dan bingkai video, Aspose.Slides menyediakan antarmuka [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) , antarmuka [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) , dan tipe relevan lainnya.

## **Buat Bingkai Video yang Disematkan**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat bingkai video untuk menyematkan video dalam presentasi Anda.

Contoh ini menyematkan video lokal pada slide pertama dari presentasi yang sudah ada dan menyimpan hasilnya. Koordinat dan dimensi bingkai dalam satuan poin. Stream tetap terbuka hingga penyimpanan selesai karena [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) mengunci stream selama presentasi menggunakannya.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Anda juga dapat memberikan jalur video lokal secara langsung ke [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Contoh ini menyematkan video pada slide pertama dari presentasi baru. Video harus tetap dapat diakses hingga presentasi disimpan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Buat Bingkai Video dengan Video dari Sumber Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) mendukung video daring dalam presentasi. Anda dapat membuat bingkai video yang menautkan ke video daring, seperti video YouTube.

Contoh ini menambahkan tautan video YouTube dan thumbnail ke slide pertama. Ganti identifier video untuk menggunakan video lain. Metode [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) meminta pemutaran otomatis. Mengunduh thumbnail dan memutar video memerlukan akses internet. Penampil presentasi juga harus mendukung pemutaran video daring.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Putar Video dalam Mode Layar Penuh**

Dalam presentasi pelatihan, Anda dapat memutar demonstrasi perangkat lunak dalam mode layar penuh agar audiens dapat melihat detailnya. Panggil [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) dengan `true` untuk mengaktifkan perilaku ini selama pemutaran.

Contoh ini membuka presentasi, menemukan [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) pertama pada slide pertama, dan mengaktifkan pemutaran layar penuh. Presentasi input harus berisi setidaknya satu slide dengan bingkai video yang ada pada slide pertama.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pemutaran layar penuh mengontrol bagaimana video ditampilkan. Secara terpisah, [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) mengontrol apakah video mulai otomatis atau saat diklik, dan [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) mengontrol apakah video berulang. Untuk memilih perilaku mulai, atur mode pemutaran ke [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). Contoh ini mempertahankan pengaturan mulai dan loop yang ada.

## **Mundur Video Setelah Pemutaran**

Dalam presentasi pelatihan, mengembalikan video demonstrasi ke awal membuatnya siap diputar kembali oleh presenter. Panggil [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) dengan `true` untuk mengembalikan video ke awal setelah pemutaran selesai.

Contoh ini membuka presentasi, menemukan [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) pertama pada slide pertama, dan mengaktifkan pemutaran mundur. Ini menonaktifkan looping sehingga pemutaran dapat selesai dan mengatur pemutaran agar dimulai saat diklik. Presentasi input harus berisi setidaknya satu slide dengan bingkai video yang ada pada slide pertama.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pemutaran mundur mengembalikan video ke awal tanpa memulai kembali. Sebaliknya, memanggil [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) dengan `true` akan mengulang pemutaran secara otomatis. Nonaktifkan looping ketika Anda ingin video selesai dan tetap siap diputar ulang. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) secara terpisah mengontrol start otomatis atau on‑click; contoh ini menggunakan [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) sehingga presenter yang mengontrol kapan pemutaran dimulai. Atur mode pemutaran setelah pengaturan loop, sebagaimana ditunjukkan dalam contoh. Pemutaran mundur bekerja independen dari [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Memangkas Bingkai Video**

Gunakan [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) dan [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) untuk melewatkan bagian awal atau akhir video selama pemutaran. Kedua nilai dalam milidetik. Pemangkasan mengubah pengaturan pemutaran tanpa memodifikasi data video yang disematkan.

**Atur Pengaturan Pemangkasan**

Contoh ini menyematkan video lokal dan melewatkan 2,5 detik pertama serta 1 detik terakhir selama pemutaran. Gunakan video yang lebih lama dari 3,5 detik agar segmen yang dapat diputar tetap ada.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Baca Pengaturan Pemangkasan**

Contoh ini mencetak nilai pemangkasan dari bingkai video pertama pada slide pertama dalam milidetik. Presentasi harus berisi setidaknya satu slide. Jika slide tersebut tidak memiliki bingkai video, tidak ada yang dicetak. Contoh sebelumnya menghasilkan nilai 2500 dan 1000.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Kelola Caption Video**

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk bingkai video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui metode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Tambahkan Caption ke Bingkai Video**

Contoh ini menyematkan video lokal dan menambahkan track caption WebVTT berlabel English. Stempel waktu caption harus cocok dengan video. Presentasi yang disimpan mencakup video dan captionnya.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Antarmuka [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari stream.

**Ekstrak Caption dari Bingkai Video**

Contoh ini menyimpan semua track caption dari bingkai video pada slide pertama sebagai file WebVTT terpisah. Nomor urut menjaga file output tetap berbeda. Konsol melaporkan jumlah track yang diekstrak. Presentasi harus berisi setidaknya satu slide.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Setiap objek [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) menampilkan identifier caption, label, data biner, dan teks caption sebagai string UTF‑8.

**Hapus Caption dari Bingkai Video**

Contoh ini menghapus semua caption dari bingkai video pada posisi shape pertama di slide pertama dan menyimpan hasilnya. Asumsinya slide dan shape ada serta shape tersebut adalah bingkai video.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jika Anda hanya perlu menghapus satu track caption, gunakan metode [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) atau [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) alih-alih [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--) .

## **Ekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi.

Contoh ini mengekstrak video yang disematkan dari setiap slide menjadi file biner bernomor terpisah. Video yang ditautkan dilewatkan karena tidak memiliki data yang disematkan. Konsol mencetak tipe MIME setiap video serta total hitungan. Output menggunakan ekstensi umum `.bin`; ubah sesuai tipe media yang dilaporkan bila diperlukan.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Parameter pemutaran video apa yang dapat diubah untuk sebuah bingkai video?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (otomatis atau pada klik) dan [looping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Opsi ini tersedia melalui metode objek [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) .

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Saat Anda menyematkan video lokal, data biner termasuk dalam dokumen, sehingga ukuran presentasi bertambah proporsional dengan ukuran file. Saat Anda menautkan ke video daring dan menambahkan thumbnail, presentasi menyimpan tautan dan gambar pratinjau alih‑alih data video, sehingga peningkatan ukuran biasanya lebih kecil.

**Bisakah saya mengganti video dalam bingkai video yang ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [video content](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) di dalam bingkai sambil mempertahankan geometri shape; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang ada.

**Apakah tipe konten (MIME) video yang disematkan dapat dipastikan?**

Ya. Video yang disematkan memiliki [content type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.