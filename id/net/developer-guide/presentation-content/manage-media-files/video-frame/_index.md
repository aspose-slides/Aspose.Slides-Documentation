---
title: Kelola Frame Video dalam Presentasi di .NET
linktitle: Frame Video
type: docs
weight: 10
url: /id/net/video-frame/
keywords:
- menambah video
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
description: "Pelajari cara menambahkan dan mengekstrak frame video secara terprogram dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET. Panduan singkat cara cepat."
---
## **Pendahuluan**

Video dapat membantu menjelaskan ide dan menarik perhatian audiens. Aspose.Slides for .NET memungkinkan Anda menambahkan frame video ke slide, mengatur pengaturan pemutaran, mengelola caption, dan mengekstrak data video yang tertanam.

PowerPoint mendukung video lokal dan tautan ke video daring, seperti video YouTube.

Untuk merepresentasikan data video dan frame video, Aspose.Slides menyediakan antarmuka [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/), antarmuka [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/), dan tipe relevan lainnya.

## **Buat Frame Video Tertanam**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat frame video untuk menyematkan video dalam presentasi Anda.

Contoh ini menyematkan video lokal pada slide pertama dari presentasi yang ada dan menyimpan hasilnya. Koordinat dan dimensi frame dalam satuan poin. Stream tetap terbuka hingga proses penyimpanan selesai karena [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) menguncinya selama presentasi menggunakannya.

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

Anda juga dapat memberikan jalur video lokal secara langsung ke [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Contoh ini menyematkan video pada slide pertama dari presentasi baru. Video harus tetap dapat diakses hingga presentasi disimpan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Atur Volume Video Secara Tepat**

Pada Aspose.Slides for .NET 26.11 atau yang lebih baru, [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) menetapkan persentase floating-point dari 0 hingga 100. Gunakan ini ketika preset [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) terlalu kasar. Misalnya, `75.5f` meminta volume 75.5%.

Contoh ini memerlukan [Aspose.Slides for .NET](/slides/id/net/installation/) 26.11 atau yang lebih baru serta file `video.mp4` lokal. Ia menyematkan video, secara eksplisit menginisialisasi pemutaran, menyimpan presentasi, dan membaca kembali persentase yang disimpan.

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

Validasi masukan sendiri; jangan bergantung pada setter untuk menolak nilai di luar rentang yang didokumentasikan. Preset Low, Medium, dan Loud sesuai dengan 20, 50, dan 80 pada versi 26.11. Menetapkan preset dapat menggantikan persentase sebelumnya, sehingga tetapkan persentase terakhir ketika Anda memerlukan nilai yang tepat. Gunakan [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) untuk pengaturan mute eksplisit; angka nol dan enum preset tidak dapat dipertukarkan.

Juga setel [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) secara eksplisit saat mengonfigurasi video yang ditautkan, dan pastikan berkas media tersedia bagi pemirsa. Menyimpan dan membuka kembali memverifikasi pengaturan yang tersimpan; pemutaran sebenarnya dan tingkat kebisingan tergantung pada pemutar presentasi serta pengaturan audio-nya.

## **Buat Frame Video dengan Video dari Sumber Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) mendukung video daring dalam presentasi. Anda dapat membuat frame video yang menautkan ke video daring, seperti video YouTube.

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

Dalam presentasi pelatihan, Anda dapat memutar demonstrasi perangkat lunak dalam mode layar penuh sehingga audiens dapat melihat detailnya. Setel [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) ke `true` untuk mengaktifkan perilaku ini selama pemutaran.

Contoh ini membuka sebuah presentasi, menemukan [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) pertama pada slide pertama, dan mengaktifkan pemutaran layar penuh. Presentasi masukan harus memiliki setidaknya satu slide dengan frame video yang ada pada slide pertama.

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

Pemutaran layar penuh mengontrol cara video ditampilkan. Secara terpisah, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) mengontrol apakah video dimulai secara otomatis atau saat diklik, dan [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) mengontrol apakah video berulang. Untuk memilih perilaku mulai, setel mode pemutaran ke [VideoPlayModePreset.Auto atau VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Contoh ini mempertahankan pengaturan mulai dan loop yang ada.

## **Mundurkan Video Setelah Pemutaran**

Dalam presentasi pelatihan, mengembalikan video demonstrasi ke awalnya membuatnya siap untuk diputar lagi oleh presenter. Setel [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) ke `true` untuk mengembalikan video ke awal setelah pemutaran selesai.

Contoh ini membuka presentasi, menemukan [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) pertama pada slide pertama, dan mengaktifkan pengembalian mundur. Ia menonaktifkan looping agar pemutaran dapat selesai dan mengatur pemutaran mulai saat klik. Presentasi masukan harus memiliki setidaknya satu slide dengan frame video yang ada pada slide pertama.

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

Pengembalian mundur mengembalikan video ke awalnya tanpa memulai kembali. Sebaliknya, mengaktifkan [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) membuat pemutaran berulang secara otomatis. Biarkan looping nonaktif ketika Anda ingin video selesai dan siap diputar kembali. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) secara terpisah mengontrol pemutaran otomatis atau saat klik; contoh ini menggunakan [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) sehingga presenter mengontrol kapan pemutaran dimulai. Tetapkan mode pemutaran setelah pengaturan loop, seperti yang ditunjukkan dalam contoh. Pengembalian mundur berfungsi terpisah dari [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Pangkas Frame Video**

Gunakan [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) dan [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) untuk melewatkan bagian awal atau akhir video selama pemutaran. Kedua nilai dalam milidetik. Pemangkasan mengubah pengaturan pemutaran tanpa memodifikasi data video yang tertanam.

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

Contoh ini mencetak nilai pemangkasan dari frame video pertama pada slide pertama dalam milidetik. Presentasi harus memiliki setidaknya satu slide. Jika slide tersebut tidak memiliki frame video, tidak ada yang dicetak. Contoh sebelumnya menghasilkan nilai 2500 dan 1000.

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

Aspose.Slides memungkinkan Anda mengelola closed caption untuk frame video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui properti [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

**Tambahkan Caption ke Frame Video**

Contoh ini menyematkan video lokal dan menambahkan track caption WebVTT berlabel English. Stempel waktu caption harus cocok dengan video. Presentasi yang disimpan mencakup video dan caption-nya.

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

Antarmuka [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari stream.

**Ekstrak Caption dari Frame Video**

Contoh ini menyimpan semua track caption dari frame video pada slide pertama sebagai file WebVTT terpisah. Nomor berurutan menjaga file output tetap berbeda. Konsol melaporkan jumlah track yang diekstrak. Presentasi harus memiliki setidaknya satu slide.

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

**Hapus Caption dari Frame Video**

Contoh ini menghapus semua caption dari frame video pada posisi shape pertama pada slide pertama dan menyimpan hasilnya. Ia mengasumsikan bahwa slide dan shape ada serta shape tersebut adalah frame video.

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

Jika Anda perlu menghapus hanya satu track caption, gunakan metode [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) atau [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) alih-alih [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Ekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang tertanam dalam presentasi.

Contoh ini mengekstrak video yang tertanam dari setiap slide ke dalam file biner terpisah yang bernomor. Video yang ditautkan dilewati karena tidak memiliki data tertanam. Konsol mencetak tipe MIME setiap video dan total jumlahnya. Output menggunakan ekstensi umum `.bin`; ubah sesuai tipe media yang dilaporkan bila diperlukan.

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

**Parameter pemutaran video apa yang dapat diubah untuk frame video?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (otomatis atau saat klik) dan [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Opsi-opsi ini tersedia melalui properti objek [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Ketika Anda menyematkan video lokal, data biner disertakan dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran berkas. Ketika Anda menautkan ke video daring dan menambahkan thumbnail, presentasi menyimpan tautan dan gambar pratinjau alih-alih data video, sehingga peningkatan ukuran biasanya lebih kecil.

**Apakah saya dapat mengganti video dalam frame video yang ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) di dalam frame sambil mempertahankan geometri shape; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang ada.

**Apakah tipe konten (MIME) dari video yang tertanam dapat diketahui?**

Ya. Video yang tertanam memiliki [tipe konten](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.