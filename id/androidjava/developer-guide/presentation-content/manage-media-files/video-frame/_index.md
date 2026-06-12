---
title: Kelola Bingkai Video dalam Presentasi di Android
linktitle: Bingkai Video
type: docs
weight: 10
url: /id/androidjava/video-frame/
keywords:
- menambahkan video
- membuat video
- menyematkan video
- mengekstrak video
- mengambil video
- bingkai video
- sumber web
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengekstrak bingkai video secara programatis dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Android melalui Java. Panduan cara cepat."
---
## **Pendahuluan**

Video yang ditempatkan dengan tepat dalam presentasi dapat membuat pesan Anda lebih menarik dan meningkatkan tingkat keterlibatan dengan audiens. 

PowerPoint memungkinkan Anda menambahkan video ke slide dalam sebuah presentasi dengan dua cara:

* Menambahkan atau menyematkan video lokal (disimpan di mesin Anda)
* Menambahkan video daring (dari sumber web seperti YouTube).

Untuk memungkinkan Anda menambahkan video (objek video) ke sebuah presentasi, Aspose.Slides menyediakan antarmuka [IVideo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivideo/) , antarmuka [IVideoFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivideoframe/) , dan tipe relevan lainnya.

## **Buat Bingkai Video Tertanam**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat bingkai video untuk menyematkan video ke dalam presentasi Anda. 

1. Buat sebuah instance dari kelas [Presentation ](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation)class.
1. Dapatkan referensi slide melalui indeksnya. 
1. Tambahkan objek [IVideo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivideo/) dan berikan jalur file video untuk menyematkan video pada presentasi.
1. Tambahkan objek [IVideoFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivideoframe/) untuk membuat bingkai bagi video.
1. Simpan presentasi yang telah dimodifikasi. 

Kode Java berikut menunjukkan cara menambahkan video yang disimpan secara lokal ke dalam presentasi:

```java
// Membuat instance kelas Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Memuat video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Mendapatkan slide pertama dan menambahkan bingkai video
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Menyimpan presentasi ke disk
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Sebagai alternatif, Anda dapat menambahkan video dengan memberikan jalur file secara langsung ke metode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Buat Bingkai Video dengan Video dari Sumber Web**

Microsoft [PowerPoint 2013 dan yang lebih baru](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) mendukung video YouTube dalam presentasi. Jika video yang ingin Anda gunakan tersedia secara daring (misalnya di YouTube), Anda dapat menambahkannya ke presentasi melalui tautan webnya. 

1. Buat sebuah instance dari kelas [Presentation ](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation)class
1. Dapatkan referensi slide melalui indeksnya. 
1. Tambahkan objek [IVideo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivideo/) dan berikan tautan ke video.
1. Atur gambar mini untuk bingkai video. 
1. Simpan presentasi. 

Kode Java berikut menunjukkan cara menambahkan video dari web ke slide dalam presentasi PowerPoint:

```java
// Membuat instance objek Presentation yang mewakili file presentasi 
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // Menambahkan bingkai video
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Memuat thumbnail
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **Kelola Caption Video**

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk bingkai video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui metode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Tambah Caption ke Bingkai Video**

Untuk menambahkan caption ke bingkai video:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) .
1. Tambahkan video ke presentasi.
1. Tambahkan objek [IVideoFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivideoframe/) ke slide.
1. Gunakan [ICaptionsCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icaptionscollection/) yang dikembalikan oleh [getCaptionTracks](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) untuk menambahkan trek caption WebVTT.
1. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara menambahkan caption ke bingkai video:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Menambahkan trek caption baru dari file WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Antarmuka [ICaptionsCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icaptionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari aliran.

**Ekstrak Caption dari Bingkai Video**

Untuk mengekstrak caption dari bingkai video:

1. Muat presentasi yang berisi video.
1. Temukan objek [IVideoFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivideoframe/) target.
1. Iterasi melalui trek caption yang dikembalikan oleh [getCaptionTracks](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Simpan setiap trek caption ke file `.vtt`.

Kode berikut menunjukkan cara mengekstrak caption dari bingkai video:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Menyimpan trek caption ke file WebVTT.
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Setiap objek [ICaptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icaptions/) menampilkan identifier caption, label, data biner, dan data caption sebagai string UTF-8.

**Hapus Caption dari Bingkai Video**

Untuk menghapus caption dari bingkai video:

1. Muat presentasi yang berisi video.
1. Dapatkan objek [IVideoFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivideoframe/) target.
1. Hapus trek caption dari koleksi yang dikembalikan oleh [getCaptionTracks](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara menghapus semua caption dari bingkai video:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Menghapus semua caption dari bingkai video.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jika Anda perlu menghapus hanya satu trek caption, gunakan metode [remove](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) atau [removeAt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) alih-alih [clear](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icaptionscollection/#clear--).

## **Ekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) untuk memuat presentasi yang berisi video.
2. Iterasi melalui semua objek [ISlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islide/) .
3. Iterasi melalui semua objek [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/) untuk menemukan [VideoFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/videoframe/) .
4. Simpan video ke disk.

Kode Java berikut menunjukkan cara mengekstrak video pada slide presentasi:

```java
// Membuat instance objek Presentation yang mewakili file presentasi 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                //Mendapatkan ekstensi file
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Parameter pemutaran video apa yang dapat diubah untuk VideoFrame?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (auto atau klik) dan [pengulangan](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Opsi ini tersedia melalui properti objek [VideoFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/videoframe/) .

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Saat Anda menyematkan video lokal, data biner termasuk dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Saat Anda menambahkan video daring, tautan dan gambar mini disematkan, sehingga peningkatan ukuran lebih kecil.

**Dapatkah saya mengganti video dalam VideoFrame yang ada tanpa mengubah posisinya dan ukurannya?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) di dalam bingkai sambil mempertahankan geometri bentuk; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang ada.

**Apakah tipe konten (MIME) dari video yang disematkan dapat ditentukan?**

Ya. Video yang disematkan memiliki [tipe konten](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/video/#getContentType--) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.