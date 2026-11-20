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
description: "Pelajari cara menambahkan dan mengekstrak bingkai video secara terprogram dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Android via Java. Panduan cepat cara melakukannya."
---
## **Pendahuluan**

Video dapat membantu menjelaskan ide dan melibatkan audiens. Aspose.Slides for Android via Java memungkinkan Anda menambahkan bingkai video ke slide, menyesuaikan pengaturan pemutaran, mengelola caption, dan mengekstrak data video yang tersemat.

PowerPoint mendukung video lokal dan tautan ke video online, seperti video YouTube.

Untuk merepresentasikan data video dan bingkai video, Aspose.Slides menyediakan antarmuka [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) , antarmuka [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) , dan tipe terkait lainnya.

## **Buat Bingkai Video yang Tersemat**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat bingkai video untuk menanamkan video dalam presentasi Anda.

Contoh ini menanamkan video lokal pada slide pertama dari presentasi yang ada dan menyimpan hasilnya. Koordinat dan dimensi bingkai dalam satuan poin. Stream tetap terbuka sampai penyimpanan selesai karena [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) menguncinya selama presentasi menggunakannya.

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

Anda juga dapat memberikan jalur video lokal langsung ke [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Contoh ini menanamkan video pada slide pertama dari presentasi baru. Video harus tetap dapat diakses hingga presentasi disimpan.

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

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) mendukung video online dalam presentasi. Anda dapat membuat bingkai video yang menautkan ke video online, seperti video YouTube.

Contoh ini menambahkan tautan video YouTube dan thumbnail ke slide pertama. Ganti identifier video untuk menggunakan video lain. Metode [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) meminta pemutaran otomatis. Mengunduh thumbnail dan memutar video memerlukan akses internet. Penampil presentasi juga harus mendukung pemutaran video online.

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

Dalam presentasi pelatihan, Anda dapat memutar demonstrasi perangkat lunak dalam mode layar penuh sehingga audiens dapat melihat detailnya. Panggil [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) dengan `true` untuk mengaktifkan perilaku ini selama pemutaran.

Contoh ini membuka sebuah presentasi, menemukan [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) pertama pada slide pertama, dan mengaktifkan pemutaran layar penuh. Presentasi input harus berisi setidaknya satu slide dengan bingkai video yang ada pada slide pertama.

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

Pemutaran layar penuh mengontrol bagaimana video ditampilkan. Secara terpisah, [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) mengontrol apakah video mulai otomatis atau dengan klik, dan [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) mengontrol apakah video berulang. Untuk memilih perilaku mulai, setel mode pemutaran ke [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). Contoh ini mempertahankan pengaturan mulai dan loop yang ada.

## **Mundur Video Setelah Pemutaran**

Dalam presentasi pelatihan, mengembalikan video demonstrasi ke awalnya membuatnya siap untuk diputar kembali oleh presenter. Panggil [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) dengan `true` untuk mengembalikan video ke awal setelah pemutaran selesai.

Contoh ini membuka sebuah presentasi, menemukan [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) pertama pada slide pertama, dan mengaktifkan fungsi rewind. Itu menonaktifkan loop agar pemutaran dapat selesai dan mengatur pemutaran untuk mulai dengan klik. Presentasi input harus berisi setidaknya satu slide dengan bingkai video yang ada pada slide pertama.

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

Fungsi rewind mengembalikan video ke awal tanpa memulai kembali. Sebaliknya, memanggil [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) dengan `true` mengulang pemutaran secara otomatis. Biarkan loop nonaktif ketika Anda ingin video selesai dan tetap siap diputar ulang. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) secara terpisah mengontrol pemutaran otomatis atau dengan klik; contoh ini menggunakan [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) sehingga presenter mengendalikan kapan pemutaran dimulai. Atur mode pemutaran setelah pengaturan loop, seperti yang ditunjukkan dalam contoh. Fungsi rewind bekerja terpisah dari [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Potong Bingkai Video**

Gunakan [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) dan [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) untuk melewatkan bagian awal atau akhir video selama pemutaran. Kedua nilai dalam milidetik. Pemotongan mengubah pengaturan pemutaran tanpa memodifikasi data video yang tersemat.

**Atur Pengaturan Pemotongan**

Contoh ini menanamkan video lokal dan melewatkan 2,5 detik pertama serta satu detik terakhir selama pemutaran. Gunakan video yang lebih panjang daripada 3,5 detik agar segmen yang dapat diputar tetap ada.

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

Aspose.Slides memungkinkan Anda mengelola closed caption untuk bingkai video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan tersedia melalui metode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

### **Tambahkan Caption ke Bingkai Video**

Contoh ini menanamkan video lokal dan menambahkan trek caption WebVTT berlabel English. Stempel waktu caption harus cocok dengan video. Presentasi yang disimpan mencakup video dan captionnya.

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

### **Ekstrak Caption dari Bingkai Video**

Contoh ini menyimpan semua trek caption dari bingkai video pada slide pertama sebagai file WebVTT terpisah. Nomor berurutan menjaga file output tetap berbeda. Konsol melaporkan jumlah trek yang diekstrak. Presentasi harus berisi setidaknya satu slide.

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

Setiap objek [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) menampilkan identifier caption, label, data biner, dan teks caption sebagai string UTF-8.

### **Hapus Caption dari Bingkai Video**

Contoh ini menghapus semua caption dari bingkai video pada posisi shape pertama di slide pertama dan menyimpan hasilnya. Diasumsikan bahwa slide dan shape ada serta shape tersebut merupakan bingkai video.

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

Jika Anda perlu menghapus hanya satu trek caption, gunakan metode [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) atau [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) alih-alih [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--) .

### **Cari Caption Video**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) mengembalikan trek WebVTT lengkap, termasuk header, baris timing, dan teks caption. Anda dapat mencari cue dalam memori untuk menemukan frasa yang diucapkan dan stempel waktunya. Misalnya, trek English pada slide 2 mungkin berisi teks berikut.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Contoh ini membuka `captioned_media.pptx` dan menggunakan [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) untuk membaca trek setiap bingkai video tingkat atas pada setiap slide. Dalam cue teks biasa, baris timing berisi `-->`, dan baris kosong mengakhiri cue. Ketika caption berisi “café” dalam huruf apa pun, contoh ini mencetak nomor slide, label trek, baris timing asli, dan caption lengkap.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringBuilder caption = new StringBuilder();
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            if (caption.length() > 0) {
                                caption.append('\n');
                            }
                            caption.append(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Mencari “café” menghasilkan satu kecocokan untuk trek contoh. Pencarian mengecualikan header trek dan mempertahankan pengaturan timing dalam output.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Ekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang tersemat dalam presentasi.

Contoh ini mengekstrak video tersemat dari setiap slide ke dalam file biner terpisah yang bernomor. Video yang ditautkan dilewati karena tidak memiliki data tersemat. Konsol mencetak tipe MIME setiap video dan jumlah total. Output menggunakan ekstensi `.bin` umum; ubah sesuai tipe media yang dilaporkan bila diperlukan.

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

**Parameter pemutaran video apa yang dapat diubah untuk bingkai video?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (otomatis atau dengan klik) dan [looping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Opsi ini tersedia melalui metode objek [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) .

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Ketika Anda menanamkan video lokal, data biner disertakan dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Ketika Anda menautkan ke video online dan menambahkan thumbnail, presentasi menyimpan tautan dan gambar pratinjau alih-alih data video, sehingga peningkatan ukuran biasanya lebih kecil.

**Bisakah saya mengganti video dalam bingkai video yang ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) dalam bingkai sambil mempertahankan geometri shape; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang ada.

**Apakah tipe konten (MIME) video yang tersemat dapat ditentukan?**

Ya. Video yang tersemat memiliki [tipe konten](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.