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
## **Pengantar**

Video dapat membantu menjelaskan ide dan melibatkan audiens. Aspose.Slides untuk .NET memungkinkan Anda menambahkan bingkai video ke slide, menyesuaikan pengaturan pemutaran, mengelola caption, dan mengekstrak data video yang disematkan.

PowerPoint mendukung video lokal dan tautan ke video daring, seperti video YouTube.

Untuk merepresentasikan data video dan bingkai video, Aspose.Slides menyediakan antarmuka [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) antarmuka [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) dan tipe relevan lainnya.

## **Membuat Bingkai Video Tertanam**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat bingkai video untuk menyematkan video dalam presentasi Anda.

Contoh ini menyematkan video lokal pada slide pertama dari presentasi yang ada dan menyimpan hasilnya. Koordinat dan dimensi bingkai dalam satuan poin. Stream tetap terbuka sampai penyimpanan selesai karena [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) menguncinya selama presentasi menggunakannya.

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

Anda juga dapat memberikan jalur video lokal langsung ke [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Contoh ini menyematkan video pada slide pertama dari presentasi baru. Video harus tetap dapat diakses sampai presentasi disimpan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Atur Volume Video Secara Presisi**

Pada Aspose.Slides untuk .NET 26.11 atau lebih baru, [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) menetapkan persentase floating-point dari 0 hingga 100. Gunakan ini ketika preset [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) terlalu kasar. Misalnya, `75.5f` meminta volume 75,5%.

Contoh ini membutuhkan [Aspose.Slides for .NET](/slides/id/net/installation/) 26.11 atau lebih baru dan video lokal `video.mp4`. Ia menyematkan video, secara eksplisit menginisialisasi pemutaran, menyimpan presentasi, dan membaca kembali persentase yang disimpan.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

Validasi input secara manual; jangan bergantung pada setter untuk menolak nilai di luar rentang yang didokumentasikan. Preset Low, Medium, dan Loud sesuai dengan 20, 50, dan 80 pada versi 26.11. Menetapkan preset dapat menggantikan persentase sebelumnya, jadi tetapkan persentase terakhir bila Anda memerlukan nilai yang tepat. Gunakan [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) untuk pengaturan mute eksplisit; nol numerik dan enum preset bukan keadaan yang dapat dipertukarkan.

Secara eksplisit setel [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) saat mengonfigurasi video terhubung juga, dan pastikan berkas medianya tersedia bagi pemirsa. Menyimpan dan membuka kembali memverifikasi pengaturan yang disimpan; pemutaran nyata dan tingkat kebisingannya bergantung pada pemutar presentasi dan pengaturan audio.

## **Membuat Bingkai Video dengan Video dari Sumber Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) mendukung video daring dalam presentasi. Anda dapat membuat bingkai video yang menautkan ke video daring, seperti video YouTube.

Contoh ini menambahkan tautan video YouTube dan thumbnail ke slide pertama. Ganti pengenal video untuk menggunakan video lain. Pengaturan [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) meminta pemutaran otomatis. Mengunduh thumbnail dan memutar video memerlukan akses internet. Penampil presentasi juga harus mendukung pemutaran video daring.

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

Dalam presentasi pelatihan, Anda dapat memutar demo perangkat lunak dalam mode layar penuh sehingga audiens dapat melihat detailnya. Setel [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) ke `true` untuk mengaktifkan perilaku ini selama pemutaran.

Contoh ini membuka sebuah presentasi, menemukan [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) pertama pada slide pertama, dan mengaktifkan pemutaran layar penuh. Presentasi input harus memiliki setidaknya satu slide dengan bingkai video yang ada pada slide pertama.

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

Pemutaran layar penuh mengontrol cara video ditampilkan. Secara terpisah, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) mengontrol apakah video mulai otomatis atau saat diklik, dan [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) mengontrol apakah video berulang. Untuk memilih perilaku mulai, setel mode pemutaran ke [VideoPlayModePreset.Auto atau VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Contoh ini mempertahankan pengaturan mulai dan loop yang ada.

## **Mundurkan Video Setelah Pemutaran**

Dalam presentasi pelatihan, mengembalikan video demo ke awalnya membuatnya siap bagi presenter untuk memutar kembali. Setel [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) ke `true` untuk mengembalikan video ke awal setelah pemutaran selesai.

Contoh ini membuka presentasi, menemukan [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) pertama pada slide pertama, dan mengaktifkan pemunduran. Ia menonaktifkan looping sehingga pemutaran dapat selesai dan mengatur pemutaran untuk mulai saat diklik. Presentasi input harus memiliki setidaknya satu slide dengan bingkai video yang ada pada slide pertama.

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

Mengembalikan video ke awal tidak memulai ulang video. Sebaliknya, mengaktifkan [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) membuat pemutaran berulang secara otomatis. Biarkan looping nonaktif ketika Anda ingin video selesai dan tetap siap untuk diputar ulang. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) secara terpisah mengontrol pemutaran otomatis atau saat diklik; contoh ini menggunakan [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) sehingga presenter yang mengontrol kapan pemutaran dimulai. Setel mode pemutaran setelah pengaturan loop, seperti yang ditunjukkan dalam contoh. Pemunduran bekerja terlepas dari [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Memangkas Bingkai Video**

Gunakan [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) dan [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) untuk melewatkan bagian awal atau akhir video selama pemutaran. Kedua nilai dalam milidetik. Pemangkasan mengubah pengaturan pemutaran tanpa memodifikasi data video yang disematkan.

**Atur Pengaturan Pemangkasan**

Contoh ini menyematkan video lokal dan melewatkan 2,5 detik pertama serta satu detik terakhir selama pemutaran. Gunakan video yang lebih panjang dari 3,5 detik agar segmen yang dapat diputar tetap ada.

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

Contoh ini mencetak nilai pemangkasan dari bingkai video pertama pada slide pertama dalam milidetik. Presentasi harus memiliki setidaknya satu slide. Jika slide tersebut tidak memiliki bingkai video, tidak ada yang dicetak. Contoh sebelumnya menghasilkan nilai 2500 dan 1000.

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

Aspose.Slides memungkinkan Anda mengelola closed caption untuk bingkai video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan diakses melalui properti [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

### **Menambahkan Caption ke Bingkai Video**

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

Antarmuka [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari sebuah stream.

### **Ekstrak Caption dari Bingkai Video**

Contoh ini menyimpan semua trek caption dari bingkai video pada slide pertama sebagai file WebVTT terpisah. Nomor berurutan menjaga file output tetap berbeda. Konsol melaporkan jumlah trek yang diekstrak. Presentasi harus memiliki setidaknya satu slide.

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

Setiap objek [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) menampilkan pengidentifikasi caption, label, data biner, dan teks caption sebagai string UTF-8.

### **Hapus Caption dari Bingkai Video**

Contoh ini menghapus semua caption dari bingkai video pada posisi shape pertama di slide pertama dan menyimpan hasilnya. Asumsinya slide dan shape ada serta shape tersebut adalah bingkai video.

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

### **Cari Caption Video**

[ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) mengembalikan trek WebVTT lengkap, termasuk header, baris timing, dan teks caption. Untuk menemukan frasa yang diucapkan dan stempel waktunya, baca cue dalam memori. Misalnya, trek English pada slide 2 mungkin berisi teks berikut:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Contoh ini mengunjungi setiap slide dan membaca trek bingkai video tingkat atas melalui [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/). Pada cue teks biasa, baris timing berisi `-->` dan baris kosong mengakhiri cue. Ketika teks caption berisi “café”, contoh ini mencetak nomor slide, label trek, baris timing asli, dan caption lengkap.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

Mencari “café” menghasilkan satu kecocokan untuk trek contoh. Header dan pengaturan timing berada di luar teks cue.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Ekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi.

Contoh ini mengekstrak video yang disematkan dari setiap slide ke dalam file biner terpisah dan bernomor. Video yang ditautkan dilewati karena tidak memiliki data yang disematkan. Konsol mencetak tipe MIME tiap video dan total jumlahnya. Output menggunakan ekstensi umum `.bin`; ubah sesuai tipe media yang dilaporkan jika diperlukan.

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

**Parameter pemutaran video mana yang dapat diubah untuk sebuah bingkai video?**

Anda dapat mengontrol [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (otomatis atau saat diklik) dan [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Opsi-opsi ini tersedia melalui properti objek [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Ketika Anda menyematkan video lokal, data biner disertakan dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Ketika Anda menautkan ke video daring dan menambahkan thumbnail, presentasi menyimpan tautan dan gambar pratinjau alih-alih data video, sehingga peningkatan ukuran biasanya lebih kecil.

**Bisakah saya mengganti video dalam bingkai video yang ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) di dalam bingkai sambil mempertahankan geometri shape; ini adalah skenario umum untuk memperbarui media dalam tata letak yang ada.

**Apakah tipe konten (MIME) dari video yang disematkan dapat ditentukan?**

Ya. Video yang disematkan memiliki [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.