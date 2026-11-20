---
title: Kelola Kerangka Audio dalam Presentasi di .NET
linktitle: Kerangka Audio
type: docs
weight: 10
url: /id/net/audio-frame/
keywords:
- audio
- kerangka audio
- gambar mini
- tambahkan audio
- properti audio
- opsi audio
- ekstrak audio
- .NET
- C#
- Aspose.Slides
description: "Sematkan audio dalam slide, ubah ikon audio, konfigurasikan pemutaran, kelola caption WebVTT, dan ekstrak suara transisi slide dengan Aspose.Slides untuk .NET."
---
## **Ikhtisar**

Kerangka audio memungkinkan Anda memutar suara pada slide. Dengan Aspose.Slides untuk .NET, Anda dapat menyematkan klip audio, memilih gambar yang mewakilinya, menyesuaikan pemutaran, dan melampirkan caption. Anda juga dapat mengambil suara yang ditetapkan pada transisi slide.

## **Buat Kerangka Audio**

Gunakan [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) untuk menyematkan klip audio lokal pada slide pertama. Dua koordinat pertama menempatkan kerangka pada slide, dan dua nilai berikutnya menentukan lebar dan tinggi, semuanya dalam poin. Contoh ini mengatur [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) agar memulai klip secara otomatis dan [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) ke preset keras.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **Ubah Gambar Mini Kerangka Audio**

Secara default, kerangka audio menampilkan ikon speaker. Untuk menampilkan gambar mini khusus, tambahkan gambar ke presentasi dengan [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) dan tetapkan ke properti [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) kerangka. Contoh ini menggunakan JPEG sebagai gambar mini untuk klip audio yang disematkan.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **Ubah Opsi Pemutaran Audio**

Kontrol **Audio Options** PowerPoint menentukan kapan klip dimulai, seberapa keras suaranya, dan bagaimana perilakunya selama pertunjukan slide.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Kontrol PowerPoint | Properti Aspose.Slides |
| --- | --- |
| Start | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Volume preset | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Play Across Slides | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Loop until Stopped | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Hide During Show | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Rewind after Playing | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Fade In | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Fade Out | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Trim Audio start time | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Trim Audio end time | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Volume slider | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

Contoh ini menemukan kerangka audio pertama pada slide pertama, mengatur [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) agar memulai pemutaran saat diklik, dan memilih preset volume rendah. Klip berlanjut melintasi slide dengan looping dinonaktifkan. Ikon tetap tersembunyi selama pertunjukan, dan klip kembali ke awal setelah pemutaran.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

Untuk klip lebih lama dari 3,5 detik, contoh ini melewatkan 1,5 detik pertama dan 2 detik terakhir. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) mengukur durasi yang dihilangkan dari akhir klip. Untuk mendapatkan waktu akhir yang ditampilkan di PowerPoint, kurangi offset tersebut dari durasi penuh klip. Klip yang dipangkas memudar masuk selama 200 milidetik dan memudar keluar selama 500 milidetik. Keempat properti tersebut menerima nilai dalam milidetik.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

Untuk mengatur volume pemutaran ke persentase tertentu, gunakan [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/). Contoh ini mengatur kerangka audio pertama pada slide pertama menjadi 85%.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **Kelola Caption Audio**

Setiap kerangka audio memiliki koleksi [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/). Gunakan untuk melampirkan caption WebVTT ke klip, mengekspor trek yang ada, atau menghapusnya.

### **Tambah Caption Audio**

Contoh ini menyematkan klip audio pada slide pertama dan menggunakan [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) untuk melampirkan trek WebVTT lokal. Argumen pertama menyediakan label trek, dan argumen kedua mengidentifikasi file yang berisi caption berwaktu.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **Ekstrak Caption Audio**

Contoh ini mengekspor setiap trek caption yang dilampirkan ke kerangka audio pada slide pertama. Ia menulis [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) trek ke file WebVTT dan menggunakan [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) sebagai nama file sehingga setiap trek memiliki output terpisah.

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **Hapus Caption Audio**

Gunakan [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) atau [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) untuk menghapus satu trek. Contoh ini menggunakan [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) untuk menghapus semua caption dari kerangka audio pertama pada slide pertama sambil mempertahankan klip.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **Temukan Baris dalam Caption Audio**

Untuk menemukan baris dalam caption audio pada slide pertama, baca [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) setiap trek dalam memori. Dalam cue WebVTT teks biasa, baris waktu berisi `-->`, baris caption mengikutinya, dan baris kosong mengakhiri cue. Contoh ini mencetak label trek dan setiap baris caption yang berisi “café”.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **Ekstrak Audio**

Transisi slide dapat memiliki suara tersendiri. Untuk mengambilnya, baca properti [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) transisi. Contoh ini mengakses [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) suara dan mencetak ukuran dalam byte. Jika slide pertama tidak memiliki suara transisi, ia mencetak pesan sebagai gantinya.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **FAQ**

**Bisakah saya menggunakan kembali klip audio yang sama di banyak slide tanpa menggandakannya?**

Ya. Tambahkan klip sekali ke [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) presentasi dan berikan objek audio yang sama ke [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) untuk setiap slide.

**Bisakah saya mengganti suara dalam kerangka audio yang ada?**

Ya. Untuk suara yang ditautkan, perbarui [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) agar mengarah ke file pengganti. Untuk suara yang disematkan, tetapkan klip lain dari audio collection presentasi ke [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/). Kedua pendekatan mempertahankan kerangka yang ada.

**Apakah pemangkasan mengubah data audio yang disimpan dalam presentasi?**

Tidak. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) dan [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) mengatur batas pemutaran. Anda masih dapat mengambil klip penuh dari [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/).