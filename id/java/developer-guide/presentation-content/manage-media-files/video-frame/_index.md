---
title: "Kelola Bingkai Video dalam Presentasi Menggunakan Java"
linktitle: "Bingkai Video"
type: docs
weight: 10
url: /id/java/video-frame/
keywords:
- "menambahkan video"
- "membuat video"
- "menyematkan video"
- "mengekstrak video"
- "mengambil video"
- "bingkai video"
- "sumber web"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "Java"
- "Aspose.Slides"
description: "Pelajari cara menambahkan dan mengekstrak bingkai video secara programatik pada slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Java. Panduan cepat cara melakukannya."
---
## **Pendahuluan**

Video dapat membantu menjelaskan ide dan melibatkan audiens. Aspose.Slides untuk Java memungkinkan Anda menambahkan bingkai video ke slide, menyesuaikan pengaturan pemutaran, mengelola caption, dan mengekstrak data video yang disematkan.

PowerPoint mendukung video lokal dan tautan ke video daring, seperti video YouTube.

Untuk merepresentasikan data video dan bingkai video, Aspose.Slides menyediakan antarmuka [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) antarmuka [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) dan tipe relevan lainnya.

## **Buat Bingkai Video yang Disematkan**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat bingkai video untuk menyematkan video ke dalam presentasi Anda.

Contoh ini menyematkan video lokal pada slide pertama dari presentasi yang ada dan menyimpan hasilnya. Koordinat dan dimensi bingkai dalam satuan poin. Aliran tetap terbuka sampai penyimpanan selesai karena [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) menjaga aliran tetap terkunci saat presentasi menggunakannya.

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

Anda juga dapat memberikan jalur video lokal secara langsung ke [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Contoh ini menyematkan video pada slide pertama dari presentasi baru. Video harus tetap dapat diakses hingga presentasi disimpan.

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

Contoh ini menambahkan tautan video YouTube dan thumbnail ke slide pertama. Ganti pengidentifikasi video untuk menggunakan video lain. Metode [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) meminta pemutaran otomatis. Mengunduh thumbnail dan memutar video memerlukan akses internet. Penampil presentasi juga harus mendukung pemutaran video daring.

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

Dalam presentasi pelatihan, Anda dapat memutar demonstrasi perangkat lunak dalam mode layar penuh agar audiens dapat melihat detailnya. Panggil [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) dengan `true` untuk mengaktifkan perilaku ini selama pemutaran.

Contoh ini membuka sebuah presentasi, menemukan [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) pertama pada slide pertama, dan mengaktifkan pemutaran layar penuh. Presentasi masukan harus berisi setidaknya satu slide dengan bingkai video yang ada pada slide pertama.

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

Pemutaran layar penuh mengontrol bagaimana video ditampilkan. Secara terpisah, [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) mengontrol apakah video dimulai secara otomatis atau saat diklik, dan [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) mengontrol apakah video berulang. Untuk memilih perilaku awal, atur mode pemutaran ke [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). Contoh ini mempertahankan pengaturan start dan loop yang ada.

## **Mundurkan Video Setelah Pemutaran**

Dalam presentasi pelatihan, mengembalikan video demonstrasi ke awalnya membuatnya siap bagi presenter untuk memutar lagi. Panggil [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) dengan `true` untuk mengembalikan video ke awal setelah pemutaran selesai.

Contoh ini membuka sebuah presentasi, menemukan [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) pertama pada slide pertama, dan mengaktifkan mundur. Ia menonaktifkan looping sehingga pemutaran dapat selesai dan mengatur pemutaran untuk dimulai saat diklik. Presentasi masukan harus berisi setidaknya satu slide dengan bingkai video yang ada pada slide pertama.

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

Munduran mengembalikan video ke awalnya tanpa memulai lagi. Sebaliknya, memanggil [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) dengan `true` akan mengulang pemutaran secara otomatis. Biarkan looping dinonaktifkan ketika Anda menginginkan video selesai dan tetap siap diputar ulang. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) secara terpisah mengontrol pemutaran otomatis atau saat diklik; contoh ini menggunakan [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) sehingga presenter mengontrol kapan pemutaran dimulai. Atur mode pemutaran setelah pengaturan loop, seperti yang ditunjukkan dalam contoh. Munduran bekerja secara independen dari [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Potong Bingkai Video**

Gunakan [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) dan [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) untuk melewati bagian awal atau akhir video selama pemutaran. Kedua nilai dalam milidetik. Pemotongan mengubah pengaturan pemutaran tanpa memodifikasi data video yang disematkan.

**Atur Pengaturan Pemotongan**

Contoh ini menyematkan video lokal dan melewati 2,5 detik pertama serta satu detik terakhir selama pemutaran. Gunakan video yang lebih lama dari 3,5 detik agar segmen yang dapat diputar tetap ada.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Baca Pengaturan Pemotongan**

Contoh ini mencetak nilai pemotongan dari bingkai video pertama pada slide pertama dalam milidetik. Presentasi harus berisi setidaknya satu slide. Jika slide tersebut tidak memiliki bingkai video, tidak ada yang dicetak. Contoh sebelumnya menghasilkan nilai 2500 dan 1000.

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

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk bingkai video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui metode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Tambahkan Caption ke Bingkai Video**

Contoh ini menyematkan video lokal dan menambahkan trek caption WebVTT berlabel English. Stempel waktu caption harus cocok dengan video. Presentasi yang disimpan mencakup video dan caption-nya.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Antarmuka [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari aliran.

**Ekstrak Caption dari Bingkai Video**

Contoh ini menyimpan semua trek caption dari bingkai video pada slide pertama sebagai file WebVTT terpisah. Nomor urut menjaga file output tetap berbeda. Konsol melaporkan jumlah trek yang diekstrak. Presentasi harus berisi setidaknya satu slide.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Setiap objek [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) mengekspos pengidentifikasi caption, label, data biner, dan teks caption sebagai string UTF-8.

**Hapus Caption dari Bingkai Video**

Contoh ini menghapus semua caption dari bingkai video pada posisi shape pertama di slide pertama dan menyimpan hasilnya. Contoh mengasumsikan slide dan shape ada serta shape tersebut merupakan bingkai video.

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

Jika Anda perlu menghapus hanya satu trek caption, gunakan metode [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) atau [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) alih-alih [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--).

## **Ekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi.

Contoh ini mengekstrak video yang disematkan dari setiap slide menjadi file biner terpisah dengan nomor. Video yang ditautkan dilewati karena tidak memiliki data yang disematkan. Konsol mencetak tipe MIME tiap video dan total jumlahnya. Output menggunakan ekstensi umum `.bin`; ubah sesuai tipe media yang dilaporkan bila diperlukan.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
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

**Parameter pemutaran video apa yang dapat diubah untuk bingkai video?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (otomatis atau saat klik) dan [pengulangan](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Opsi-opsi ini tersedia melalui metode objek [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) .

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Ketika Anda menyematkan video lokal, data biner disertakan dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Ketika Anda menautkan ke video daring dan menambahkan thumbnail, presentasi menyimpan tautan dan gambar pratinjau alih-alih data video, sehingga peningkatan ukuran biasanya lebih kecil.

**Bisakah saya mengganti video dalam bingkai video yang ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) dalam bingkai sambil mempertahankan geometri shape; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang ada.

**Apakah tipe konten (MIME) dari video yang disematkan dapat ditentukan?**

Ya. Video yang disematkan memiliki [tipe konten](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.