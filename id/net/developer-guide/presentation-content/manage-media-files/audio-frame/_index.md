---
title: Kelola Bingkai Audio dalam Presentasi di .NET
linktitle: Bingkai Audio
type: docs
weight: 10
url: /id/net/audio-frame/
keywords:
- audio
- bingkai audio
- miniatur
- tambahkan audio
- properti audio
- opsi audio
- ekstrak audio
- .NET
- C#
- Aspose.Slides
description: "Buat dan kendalikan bingkai audio di Aspose.Slides untuk .NET—contoh C# untuk menyematkan, memotong, mengulang, dan mengonfigurasi pemutaran pada presentasi PPT, PPTX, dan ODP."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan bingkai audio di Aspose.Slides. Artikel ini menunjukkan cara menambahkan audio tersemat ke slide, menyesuaikan thumbnail bingkai audio, mengonfigurasi opsi pemutaran seperti volume, pengulangan, menyembunyikan, memotong, dan durasi fade, serta mengekstrak audio yang digunakan dalam transisi pertunjukan slide.

## **Membuat Bingkai Audio**

Aspose.Slides for .NET memungkinkan Anda menambahkan file audio ke slide. File audio disematkan dalam slide sebagai bingkai audio. 

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Muat aliran file audio yang ingin Anda sematkan ke slide.
4. Tambahkan bingkai audio tersemat (yang berisi file audio) ke slide.
5. Atur [PlayMode](https://reference.aspose.com/slides/id/net/aspose.slides/audioplaymodepreset) dan `Volume` yang disediakan oleh objek [IAudioFrame](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe).
6. Simpan presentasi yang telah dimodifikasi.

Kode C# berikut menunjukkan cara menambahkan bingkai audio tersemat ke slide:

```c#
// Membuat instance kelas presentasi yang mewakili file presentasi
using (Presentation pres = new Presentation())
{
    // Mendapatkan slide pertama
    ISlide sld = pres.Slides[0];
    
    // Memuat file suara wav ke stream
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Menambahkan Bingkai Audio
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Mengatur Mode Putar dan Volume Audio
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Menulis file PowerPoint ke disk
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Mengubah Thumbnail Bingkai Audio**

Saat Anda menambahkan file audio ke presentasi, audio muncul sebagai bingkai dengan gambar default standar (lihat gambar pada bagian di bawah). Anda dapat mengubah thumbnail bingkai audio (menetapkan gambar pilihan Anda).

Kode C# berikut menunjukkan cara mengubah thumbnail atau gambar pratinjau bingkai audio:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Menambahkan bingkai audio ke slide dengan posisi dan ukuran yang ditentukan.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Adds an image to presentation resources.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Sets the image for the audio frame.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	//Menyimpan presentasi yang telah dimodifikasi ke disk
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Mengubah Opsi Pemutaran Audio**

Aspose.Slides for .NET memungkinkan Anda mengubah opsi yang mengontrol pemutaran atau properti audio. Misalnya, Anda dapat menyesuaikan volume audio, mengatur audio untuk diputar berulang, atau bahkan menyembunyikan ikon audio.

Panel **Opsi Audio** di Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Opsi Audio** PowerPoint yang sesuai dengan properti [AudioFrame](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe) Aspose.Slides:

- **Start** pada menu drop-down cocok dengan properti [AudioFrame.PlayMode](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe/properties/playmode) 
- **Volume** cocok dengan properti [AudioFrame.Volume](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe/properties/volume) 
- **Play Across Slides** cocok dengan properti [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe/properties/playacrossslides) 
- **Loop until Stopped** cocok dengan properti [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe/properties/playloopmode) 
- **Hide During Show** cocok dengan properti [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe/properties/hideatshowing) 
- **Rewind after Playing** cocok dengan properti [AudioFrame.RewindAudio](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe/properties/rewindaudio) 

Opsi **Pengeditan** PowerPoint yang sesuai dengan properti [AudioFrame](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe) Aspose.Slides:

- **Fade In** cocok dengan properti [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe/fadeinduration/) 
- **Fade Out** cocok dengan properti [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe/fadeoutduration/) 
- **Trim Audio Start Time** cocok dengan properti [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe/trimfromstart/) 
- **Trim Audio End Time** nilainya sama dengan durasi audio dikurangi nilai properti [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe/trimfromend/) 

Kontrol **Volume** pada panel kontrol audio PowerPoint sesuai dengan properti [AudioFrame.VolumeValue](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe/volumevalue/) . Kontrol ini memungkinkan Anda mengubah volume audio dalam persentase.

Berikut cara mengubah opsi pemutaran audio:

1. [Сreate](#create-audio-frame) atau dapatkan Bingkai Audio.
2. Atur nilai baru untuk properti Bingkai Audio yang ingin Anda ubah.
3. Simpan file PowerPoint yang telah dimodifikasi.

Kode C# berikut mendemonstrasikan operasi di mana opsi audio disesuaikan:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Mendapatkan bentuk AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Mengatur mode Putar agar diputar saat diklik
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Mengatur volume menjadi Rendah
    audioFrame.Volume = AudioVolumeMode.Low;

    // Mengatur audio agar diputar melintasi slide
    audioFrame.PlayAcrossSlides = true;

    // Menonaktifkan pengulangan untuk audio
    audioFrame.PlayLoopMode = false;

    // Menyembunyikan AudioFrame selama pertunjukan slide
    audioFrame.HideAtShowing = true;

    // Memutar ulang audio ke awal setelah diputar
    audioFrame.RewindAudio = true;

    // Menyimpan file PowerPoint ke disk
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

Contoh C# ini menunjukkan cara menambahkan bingkai audio baru dengan audio tersemat, memotongnya, dan mengatur durasi fade:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Mengatur offset awal pemotongan ke 1,5 detik
    audioFrame.TrimFromStart = 1500f;
    // Mengatur offset akhir pemotongan ke 2 detik
    audioFrame.TrimFromEnd = 2000f;

    // Mengatur durasi fade-in menjadi 200 ms
    audioFrame.FadeInDuration = 200f;
    // Mengatur durasi fade-out menjadi 500 ms
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

Contoh kode berikut menunjukkan cara mengambil bingkai audio dengan audio tersemat dan mengatur volumenya menjadi 85%:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Mendapatkan bentuk AudioFrame
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Mengatur volume audio menjadi 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Mengelola Caption Audio**

Aspose.Slides memungkinkan Anda menambahkan caption tertutup ke bingkai audio melalui properti [CaptionTracks](https://reference.aspose.com/slides/id/net/aspose.slides/iaudioframe/captiontracks/). Properti ini mengembalikan sebuah [ICaptionsCollection](https://reference.aspose.com/slides/id/net/aspose.slides/icaptionscollection/), yang memungkinkan Anda menambahkan trek caption WebVTT, mengiterasi trek yang ada, dan menghapusnya bila diperlukan.

**Menambahkan Caption Audio**

Gunakan properti [CaptionTracks](https://reference.aspose.com/slides/id/net/aspose.slides/iaudioframe/captiontracks/) untuk melampirkan satu atau lebih trek caption ke bingkai audio. Pada contoh berikut, file audio ditambahkan ke slide, kemudian trek caption baru dimuat dari file `.vtt`.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Tambahkan trek caption baru dari file WebVTT
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**Mengekstrak Caption Audio**

Anda dapat mengiterasi trek caption yang terkait dengan bingkai audio dan menyimpannya sebagai file `.vtt`. Setiap trek caption mengekspor data biner dan pengidentifikasi uniknya, yang dapat digunakan saat mengekspor caption.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // Simpan trek caption sebagai file .vtt.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**Menghapus Caption Audio**

Untuk menghapus caption dari bingkai audio, gunakan metode yang disediakan oleh [ICaptionsCollection](https://reference.aspose.com/slides/id/net/aspose.slides/icaptionscollection/), seperti [Clear](https://reference.aspose.com/slides/id/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/id/net/aspose.slides/icaptionscollection/remove/), atau [RemoveAt](https://reference.aspose.com/slides/id/net/aspose.slides/icaptionscollection/removeat/). Contoh berikut menghapus semua trek caption dari bingkai audio.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // Hapus semua trek caption dari bingkai audio.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **Mengekstrak Audio**
Aspose.Slides for .NET memungkinkan Anda mengekstrak suara yang digunakan dalam transisi pertunjukan slide. Misalnya, Anda dapat mengekstrak suara yang digunakan pada slide tertentu.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dan muat presentasi yang berisi audio.
2. Dapatkan referensi slide yang relevan melalui indeksnya.
3. Akses transisi slideshow untuk slide tersebut.
4. Ekstrak suara dalam bentuk data byte.

Kode C# berikut menunjukkan cara mengekstrak audio yang digunakan pada sebuah slide:

```c#
string presName = "AudioSlide.pptx";

// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation(presName);

// Mengakses slide
ISlide slide = pres.Slides[0];

// Mendapatkan efek transisi slideshow untuk slide
ISlideShowTransition transition = slide.SlideShowTransition;

//Mengekstrak suara dalam array byte
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **FAQ**

**Apakah saya dapat menggunakan kembali aset audio yang sama di beberapa slide tanpa memperbesar ukuran file?**

Ya. Tambahkan audio sekali ke [koleksi audio](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/audios/) bersama presentasi dan buat bingkai audio tambahan yang merujuk ke aset yang sudah ada. Ini mencegah duplikasi data media dan menjaga ukuran presentasi tetap terkendali.

**Apakah saya dapat mengganti suara pada bingkai audio yang sudah ada tanpa membuat ulang bentuk?**

Ya. Untuk suara yang ditautkan, perbarui [link path](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe/linkpathlong/) agar menunjuk ke file baru. Untuk suara yang tersemat, ganti objek [embedded audio](https://reference.aspose.com/slides/id/net/aspose.slides/audioframe/embeddedaudio/) dengan yang lain dari [koleksi audio](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/audios/) presentasi. Format bingkai dan sebagian besar pengaturan pemutaran tetap tidak berubah.

**Apakah pemotongan mengubah data audio dasar yang disimpan dalam presentasi?**

Tidak. Pemotongan hanya menyesuaikan batas pemutaran. Byte audio asli tetap tidak tersentuh dan dapat diakses melalui audio tersemat atau koleksi audio presentasi.