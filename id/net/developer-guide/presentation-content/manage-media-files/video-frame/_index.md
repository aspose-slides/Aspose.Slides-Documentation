---
title: Kelola Bingkai Video dalam Presentasi di .NET
linktitle: Bingkai Video
type: docs
weight: 10
url: /id/net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengekstrak bingkai video secara programatik dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET. Panduan singkat cara cepat."
---
## **Pendahuluan**

Video yang ditempatkan dengan tepat dalam presentasi dapat membuat pesan Anda lebih menarik dan meningkatkan tingkat keterlibatan dengan audiens Anda. 

PowerPoint memungkinkan Anda menambahkan video ke slide dalam presentasi dengan dua cara:

* Tambahkan atau sematkan video lokal (disimpan di mesin Anda)
* Tambahkan video daring (dari sumber web seperti YouTube).

Untuk memungkinkan Anda menambahkan video (objek video) ke presentasi, Aspose.Slides menyediakan antarmuka [IVideo](https://reference.aspose.com/slides/id/net/aspose.slides/ivideo/) , antarmuka [IVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/) , dan tipe relevan lainnya. 

## **Buat Bingkai Video Tertanam**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat bingkai video untuk menanamkan video dalam presentasi Anda. 

1. Buat sebuah instance dari kelas [Presentation ](https://reference.aspose.com/slides/id/net/aspose.slides/presentation)class.
1. Dapatkan referensi slide melalui indeksnya. 
1. Tambahkan objek [IVideo](https://reference.aspose.com/slides/id/net/aspose.slides/ivideo/) dan berikan path file video untuk menanamkan video ke dalam presentasi. 
1. Tambahkan objek [IVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/) untuk membuat bingkai bagi video.  
1. Simpan presentasi yang telah dimodifikasi. 

Kode C# berikut menunjukkan cara menambahkan video yang disimpan secara lokal ke presentasi:

```c#
// Membuat instance kelas Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Memuat video
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Mendapatkan slide pertama dan menambahkan bingkai video
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Menyimpan presentasi ke disk
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Sebagai alternatif, Anda dapat menambahkan video dengan memberikan path filenya secara langsung ke metode [AddVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addvideoframe/) :

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Buat Bingkai Video dengan Video dari Sumber Web**
Versi terbaru Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) mendukung video daring dalam presentasi. Jika video yang ingin Anda gunakan tersedia secara online (misalnya di YouTube), Anda dapat menambahkannya ke presentasi melalui tautan webnya.

1. Buat sebuah instance dari kelas [Presentation ](https://reference.aspose.com/slides/id/net/aspose.slides/presentation)class
1. Dapatkan referensi slide melalui indeksnya. 
1. Tambahkan objek [IVideo](https://reference.aspose.com/slides/id/net/aspose.slides/ivideo/) dan berikan tautan ke video.
1. Atur thumbnail untuk bingkai video. 
1. Simpan presentasi. 

Kode C# berikut menunjukkan cara menambahkan video dari web ke slide dalam presentasi PowerPoint:

```c#
public static void Run()
{
    // Membuat instance objek Presentation yang merepresentasikan file presentasi 
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

## **Potong Bingkai Video**

Aspose.Slides memungkinkan Anda mengontrol bagian video yang diputar dengan mengatur nilai trim-from-start dan trim-from-end melalui [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/trimfromstart/) dan [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/trimfromend/). Kedua nilai ditentukan dalam milidetik dan menentukan berapa banyak waktu yang dilewati dari awal dan akhir video, masing‑masing. Pengaturan ini mengubah pengaturan pemutaran video dalam presentasi; mereka tidak memotong atau mengubah data biner video yang tertanam.

**Atur Pengaturan Pemotongan**

Untuk membuat bingkai video dan mengatur pengaturan pemotongannya:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
1. Tambahkan objek [IVideo](https://reference.aspose.com/slides/id/net/aspose.slides/ivideo/) ke presentasi.
1. Tambahkan objek [IVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/) ke sebuah slide.
1. Atur nilai trim-from-start dan trim-from-end melalui [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/trimfromstart/) dan [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/trimfromend/) .
1. Simpan presentasi yang telah dimodifikasi.

Contoh kode berikut melewatkan 2,5 detik pertama dan satu detik terakhir dari video yang tertanam saat diputar:

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Baca Pengaturan Pemotongan**

Untuk memeriksa pengaturan pemotongan yang ada, muat sebuah presentasi, temukan objek [IVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/) di antara bentuk pada slide pertama, dan baca nilai melalui [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/trimfromstart/) dan [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/trimfromend/) .

Contoh kode berikut menemukan bingkai video pertama pada slide pertama dan melaporkan pengaturan pemotongannya dalam milidetik:

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **Kelola Teks Keterangan Video**

Aspose.Slides memungkinkan Anda mengelola teks keterangan tertutup untuk bingkai video dalam presentasi PowerPoint. Teks keterangan disimpan dalam format WebVTT dan tersedia melalui properti [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/captiontracks/) .

**Tambahkan Teks Keterangan ke Bingkai Video**

Untuk menambahkan teks keterangan ke bingkai video:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
1. Tambahkan video ke presentasi.
1. Tambahkan objek [IVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/) ke sebuah slide.
1. Gunakan koleksi [CaptionTracks](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/captiontracks/) untuk menambahkan trek teks keterangan WebVTT.
1. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara menambahkan teks keterangan ke bingkai video:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Menambahkan trek teks keterangan baru dari file WebVTT.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

Antarmuka [ICaptionsCollection](https://reference.aspose.com/slides/id/net/aspose.slides/icaptionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan teks keterangan dari sebuah stream.

**Ekstrak Teks Keterangan dari Bingkai Video**

Untuk mengekstrak teks keterangan dari bingkai video:

1. Muat presentasi yang berisi video.
1. Temukan objek [IVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/) target.
1. Iterasi melalui koleksi [CaptionTracks](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/captiontracks/) .
1. Simpan setiap trek teks keterangan ke file `.vtt` .

Kode berikut menunjukkan cara mengekstrak teks keterangan dari bingkai video:

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
                // Menyimpan trek teks keterangan ke file WebVTT.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Setiap objek [ICaptions](https://reference.aspose.com/slides/id/net/aspose.slides/icaptions/) menampilkan pengenal teks keterangan, label, data biner, dan teks keterangan sebagai string UTF‑8.

**Hapus Teks Keterangan dari Bingkai Video**

Untuk menghapus teks keterangan dari bingkai video:

1. Muat presentasi yang berisi video.
1. Dapatkan objek [IVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/) target.
1. Hapus trek teks keterangan dari koleksi [CaptionTracks](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/captiontracks/) .
1. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara menghapus semua teks keterangan dari bingkai video:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Menghapus semua teks keterangan dari bingkai video.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Jika Anda perlu menghapus hanya satu trek teks keterangan, gunakan metode [Remove](https://reference.aspose.com/slides/id/net/aspose.slides/captionscollection/remove/) atau [RemoveAt](https://reference.aspose.com/slides/id/net/aspose.slides/captionscollection/removeat/) alih‑alih [Clear](https://reference.aspose.com/slides/id/net/aspose.slides/captionscollection/clear/) .

## **Ekstrak Video dari Slide**
Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang tertanam dalam presentasi.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) untuk memuat presentasi yang berisi video. 
2. Iterasi melalui semua objek [ISlide](https://reference.aspose.com/slides/id/net/aspose.slides/islide) .
3. Iterasi melalui semua objek [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape) untuk menemukan sebuah [VideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/videoframe) . 
4. Simpan video ke disk.

Kode C# berikut menunjukkan cara mengekstrak video pada slide presentasi:

```c#
// Membuat instance objek Presentation yang merepresentasikan file presentasi 
Presentation presentation = new Presentation("Video.pptx");

// Iterasi melalui slide
foreach (ISlide slide in presentation.Slides)
{
    // Iterasi melalui shape
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

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/id/net/aspose.slides/videoframe/playmode/) (otomatis atau saat klik) dan [pengulangan](https://reference.aspose.com/slides/id/net/aspose.slides/videoframe/playloopmode/) . Opsi‑opsi ini tersedia melalui properti objek [VideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/videoframe/) .

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Ketika Anda menyematkan video lokal, data biner termasuk dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Ketika Anda menambahkan video daring, sebuah tautan dan thumbnail disematkan, sehingga peningkatan ukuran lebih kecil.

**Bisakah saya mengganti video dalam VideoFrame yang ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/id/net/aspose.slides/videoframe/embeddedvideo/) dalam bingkai sambil mempertahankan geometrinya; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang ada.

**Apakah tipe konten (MIME) dari video yang tertanam dapat ditentukan?**

Ya. Video yang tertanam memiliki [tipe konten](https://reference.aspose.com/slides/id/net/aspose.slides/video/contenttype/) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.