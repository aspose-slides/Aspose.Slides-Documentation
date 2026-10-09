---
title: Kelola Bingkai Video dalam Presentasi di .NET
linktitle: Bingkai Video
type: docs
weight: 10
url: /id/net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengekstrak bingkai video secara programatik dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET. Panduan cara cepat."
---
## **Pendahuluan**

Video dapat membantu menjelaskan ide dan melibatkan audiens. Aspose.Slides untuk .NET memungkinkan Anda menambahkan bingkai video ke slide, menyesuaikan pengaturan pemutaran, mengelola caption, dan mengekstrak data video yang disematkan.

PowerPoint mendukung video lokal dan tautan ke video daring, seperti video YouTube.

Untuk merepresentasikan data video dan bingkai video, Aspose.Slides menyediakan antarmuka [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) antarmuka [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) dan tipe relevan lainnya.

## **Buat Bingkai Video yang Disematkan**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat bingkai video untuk menyematkan video dalam presentasi Anda.

Contoh ini menyematkan video lokal pada slide pertama dari presentasi yang ada dan menyimpan hasilnya. Koordinat dan dimensi bingkai dalam satuan poin. Aliran tetap terbuka hingga penyimpanan selesai karena [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) menguncinya selama presentasi menggunakannya.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

Anda juga dapat memberikan jalur video lokal langsung ke [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Contoh ini menyematkan video pada slide pertama dari presentasi baru. Video harus tetap dapat diakses hingga presentasi disimpan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Buat Bingkai Video dengan Video dari Sumber Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) mendukung video daring dalam presentasi. Anda dapat membuat bingkai video yang menautkan ke video daring, seperti video YouTube.

Contoh ini menambahkan tautan video YouTube dan thumbnail ke slide pertama. Ganti identifier video untuk menggunakan video lain. Pengaturan [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) meminta pemutaran otomatis. Mengunduh thumbnail dan memutar video memerlukan akses internet. Penampil presentasi juga harus mendukung pemutaran video daring.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **Putar Video dalam Mode Layar Penuh**

Dalam presentasi pelatihan, Anda dapat memutar demo perangkat lunak dalam mode layar penuh sehingga audiens dapat melihat detailnya. Atur [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) ke `true` untuk mengaktifkan perilaku ini selama pemutaran.

Contoh ini membuka sebuah presentasi, menemukan [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) pertama pada slide pertama, dan mengaktifkan pemutaran layar penuh. Presentasi input harus berisi setidaknya satu slide dengan bingkai video yang ada pada slide pertama.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

Pemutaran layar penuh mengontrol bagaimana video ditampilkan. Secara terpisah, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) mengontrol apakah video dimulai secara otomatis atau dengan klik, dan [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) mengontrol apakah video diulang. Untuk memilih perilaku awal, atur mode pemutaran ke [VideoPlayModePreset.Auto atau VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Contoh ini mempertahankan pengaturan awal dan pengulangan yang ada.

## **Mundurkan Video Setelah Pemutaran**

Dalam presentasi pelatihan, mengembalikan video demonstrasi ke awal membuatnya siap bagi presenter untuk memutar lagi. Atur [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) ke `true` untuk mengembalikan video ke awal setelah pemutaran selesai.

Contoh ini membuka sebuah presentasi, menemukan [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) pertama pada slide pertama, dan mengaktifkan mundur. Itu menonaktifkan pengulangan sehingga pemutaran dapat selesai dan mengatur pemutaran untuk dimulai dengan klik. Presentasi input harus berisi setidaknya satu slide dengan bingkai video yang ada pada slide pertama.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

Mundur mengembalikan video ke awal tanpa memulai kembali. Sebaliknya, mengaktifkan [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) mengulang pemutaran secara otomatis. Pertahankan pengulangan dinonaktifkan ketika Anda ingin video selesai dan siap diputar ulang. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) secara terpisah mengontrol pemutaran otomatis atau dengan klik; contoh ini menggunakan [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) sehingga presenter mengendalikan kapan pemutaran dimulai. Atur mode pemutaran setelah pengaturan loop, seperti yang ditunjukkan dalam contoh. Mundur bekerja secara independen dari [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Pangkas Bingkai Video**

Gunakan [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) dan [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) untuk melewati bagian awal atau akhir video selama pemutaran. Kedua nilai dalam milidetik. Pemangkasan mengubah pengaturan pemutaran tanpa memodifikasi data video yang disematkan.

**Atur Pengaturan Pemangkasan**

Contoh ini menyematkan video lokal dan melewati 2,5 detik pertama serta satu detik terakhir selama pemutaran. Gunakan video yang lebih panjang dari 3,5 detik agar segmen yang dapat diputar tetap ada.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Baca Pengaturan Pemangkasan**

Contoh ini mencetak nilai pemangkasan dari bingkai video pertama pada slide pertama dalam milidetik. Presentasi harus berisi setidaknya satu slide. Jika slide tersebut tidak memiliki bingkai video, tidak ada yang dicetak. Contoh sebelumnya menghasilkan nilai 2500 dan 1000.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **Kelola Caption Video**

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk bingkai video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui properti [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

**Tambahkan Caption ke Bingkai Video**

Contoh ini menyematkan video lokal dan menambahkan trek caption WebVTT dengan label English. Stempel waktu caption harus cocok dengan video. Presentasi yang disimpan mencakup video dan captionnya.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

Antarmuka [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari aliran.

**Ekstrak Caption dari Bingkai Video**

Contoh ini menyimpan semua trek caption dari bingkai video pada slide pertama sebagai file WebVTT terpisah. Nomor berurutan menjaga agar file output tetap berbeda. Konsol melaporkan jumlah trek yang diekstrak. Presentasi harus berisi setidaknya satu slide.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

Setiap objek [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) menampilkan identifier caption, label, data biner, dan teks caption sebagai string UTF-8.

**Hapus Caption dari Bingkai Video**

Contoh ini menghapus semua caption dari bingkai video pada posisi shape pertama di slide pertama dan menyimpan hasilnya. Asumsinya slide dan shape ada serta shape tersebut merupakan bingkai video.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

Jika Anda perlu menghapus hanya satu trek caption, gunakan metode [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) atau [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) alih-alih [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Ekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi.

Contoh ini mengekstrak video yang disematkan dari setiap slide ke file biner terpisah yang diberi nomor. Video yang ditautkan dilewati karena tidak memiliki data yang disematkan. Konsol mencetak tipe MIME setiap video dan total jumlahnya. Output menggunakan ekstensi `.bin` umum; ubah sesuai tipe media yang dilaporkan bila diperlukan.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **FAQ**

**Parameter pemutaran video apa yang dapat diubah untuk bingkai video?**

Anda dapat mengontrol [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (otomatis atau dengan klik) dan [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Opsi ini tersedia melalui properti objek [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Apakah menambahkan video mempengaruhi ukuran file PPTX?**

Ya. Saat Anda menyematkan video lokal, data biner termasuk dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Saat Anda menautkan ke video daring dan menambahkan thumbnail, presentasi menyimpan tautan dan gambar pratinjau alih-alih data video, sehingga peningkatan ukuran biasanya lebih kecil.

**Bisakah saya mengganti video dalam bingkai video yang ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) dalam bingkai sambil mempertahankan geometri shape; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang ada.

**Bisakah tipe konten (MIME) dari video yang disematkan diketahui?**

Ya. Video yang disematkan memiliki [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.