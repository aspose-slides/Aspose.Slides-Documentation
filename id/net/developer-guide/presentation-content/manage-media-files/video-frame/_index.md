---
title: Mengelola Frame Video dalam Presentasi di .NET
linktitle: Frame Video
type: docs
weight: 10
url: /id/net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengekstrak frame video secara programatis dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET. Panduan cepat cara melakukannya."
---
## **Pendahuluan**

Video yang ditempatkan dengan tepat dalam presentasi dapat membuat pesan Anda lebih menarik dan meningkatkan tingkat keterlibatan dengan audiens.

PowerPoint memungkinkan Anda menambahkan video ke slide dalam presentasi dengan dua cara:

* Menambahkan atau menyematkan video lokal (disimpan di mesin Anda)
* Menambahkan video daring (dari sumber web seperti YouTube).

Untuk memungkinkan Anda menambahkan video (objek video) ke presentasi, Aspose.Slides menyediakan antarmuka [IVideo](https://reference.aspose.com/slides/id/net/aspose.slides/ivideo/), antarmuka [IVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/) serta tipe relevan lainnya.

## **Membuat Frame Video yang Disematkan**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat frame video untuk menyematkan video dalam presentasi Anda.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan objek [IVideo](https://reference.aspose.com/slides/id/net/aspose.slides/ivideo/) dan berikan jalur file video untuk menyematkan video ke presentasi. 
4. Tambahkan objek [IVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/) untuk membuat frame bagi video.  
5. Simpan presentasi yang telah dimodifikasi. 

Kode C# berikut menunjukkan cara menambahkan video yang disimpan secara lokal ke presentasi:

```c#
 // Membuat instance kelas Presentation
 using (Presentation pres = new Presentation("pres.pptx"))
 {
     // Memuat video
     using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
     {
         IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
         
         // Mendapatkan slide pertama dan menambahkan videoframe
         pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
         
         // Menyimpan presentasi ke disk
         pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
     }
 }
```
Sebagai alternatif, Anda dapat menambahkan video dengan memberikan jalur file secara langsung ke metode [AddVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addvideoframe/):

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Membuat Frame Video dengan Video dari Sumber Web**
Microsoft [PowerPoint 2013 dan yang lebih baru](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) mendukung video YouTube dalam presentasi. Jika video yang ingin Anda gunakan tersedia secara daring (misalnya di YouTube), Anda dapat menambahkannya ke presentasi melalui tautan websitenya. 

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan objek [IVideo](https://reference.aspose.com/slides/id/net/aspose.slides/ivideo/) dan berikan tautan ke video.
4. Atur thumbnail untuk frame video. 
5. Simpan presentasi. 

Kode C# berikut menunjukkan cara menambahkan video dari web ke slide dalam presentasi PowerPoint:

```c#
public static void Run()
{
    // Membuat instance objek Presentation yang mewakili file presentasi 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Menambahkan VideoFrame
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Memuat thumbnail
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Mengelola Caption Video**

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk frame video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui properti [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/captiontracks/).

**Menambahkan Caption ke Frame Video**

Untuk menambahkan caption ke frame video:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
2. Tambahkan video ke presentasi.
3. Tambahkan objek [IVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/) ke slide.
4. Gunakan koleksi [CaptionTracks](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/captiontracks/) untuk menambahkan trek caption WebVTT.
5. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara menambahkan caption ke frame video:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Menambahkan trek caption baru dari file WebVTT.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

Antarmuka [ICaptionsCollection](https://reference.aspose.com/slides/id/net/aspose.slides/icaptionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari aliran data.

**Mengekstrak Caption dari Frame Video**

Untuk mengekstrak caption dari frame video:

1. Muat presentasi yang berisi video.
2. Temukan objek [IVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/) target.
3. Iterasi melalui koleksi [CaptionTracks](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/captiontracks/).
4. Simpan setiap trek caption ke file `.vtt`.

Kode berikut menunjukkan cara mengekstrak caption dari frame video:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // Menyimpan trek caption ke file WebVTT.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Setiap objek [ICaptions](https://reference.aspose.com/slides/id/net/aspose.slides/icaptions/) menampilkan identifier caption, label, data biner, dan teks caption sebagai string UTF-8.

**Menghapus Caption dari Frame Video**

Untuk menghapus caption dari frame video:

1. Muat presentasi yang berisi video.
2. Dapatkan objek [IVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/) target.
3. Hapus trek caption dari koleksi [CaptionTracks](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/captiontracks/).
4. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara menghapus semua caption dari frame video:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Menghapus semua caption dari frame video.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Jika Anda perlu menghapus hanya satu trek caption, gunakan metode [Remove](https://reference.aspose.com/slides/id/net/aspose.slides/captionscollection/remove/) atau [RemoveAt](https://reference.aspose.com/slides/id/net/aspose.slides/captionscollection/removeat/) alih-alih [Clear](https://reference.aspose.com/slides/id/net/aspose.slides/captionscollection/clear/).

## **Mengekstrak Video dari Slide**
Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) untuk memuat presentasi yang berisi video. 
2. Iterasi melalui semua objek [ISlide](https://reference.aspose.com/slides/id/net/aspose.slides/islide).
3. Iterasi melalui semua objek [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape) untuk menemukan objek [VideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/videoframe). 
4. Simpan video ke disk.

Kode C# berikut menunjukkan cara mengekstrak video pada slide presentasi:

```c#
 // Membuat instance objek Presentation yang mewakili file presentasi 
 Presentation presentation = new Presentation("Video.pptx");

 // Mengiterasi slide
 foreach (ISlide slide in presentation.Slides)
 {
     // Mengiterasi shape
     foreach (IShape shape in presentation.Slides[0].Shapes)
     {
         // Menyimpan video ke disk setelah VideoFrame yang berisi video ditemukan
         if (shape is VideoFrame)
         {
             IVideoFrame vf = shape as IVideoFrame;
             String type = vf.EmbeddedVideo.ContentType;
             int ss = type.LastIndexOf('/');
             type = type.Remove(0, type.LastIndexOf('/') + 1);
             Byte[] buffer = vf.EmbeddedVideo.BinaryData;
             using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
             {                                                     
                 stream.Write(buffer, 0, buffer.Length);
             }
         }
     }
 }
```

## **FAQ**

**Parameter pemutaran video apa yang dapat diubah untuk VideoFrame?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/id/net/aspose.slides/videoframe/playmode/) (otomatis atau saat klik) dan [pengulangan](https://reference.aspose.com/slides/id/net/aspose.slides/videoframe/playloopmode/). Opsi ini tersedia melalui properti objek [VideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/videoframe/).

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Saat Anda menyematkan video lokal, data biner dimasukkan ke dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Saat Anda menambahkan video daring, tautan dan thumbnail disematkan, sehingga peningkatan ukuran lebih kecil.

**Bisakah saya mengganti video dalam VideoFrame yang ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/id/net/aspose.slides/videoframe/embeddedvideo/) di dalam frame sambil mempertahankan geometri bentuk; ini adalah skenario umum untuk memperbarui media dalam tata letak yang sudah ada.

**Apakah tipe konten (MIME) video yang disematkan dapat ditentukan?**

Ya. Video yang disematkan memiliki [tipe konten](https://reference.aspose.com/slides/id/net/aspose.slides/video/contenttype/) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.