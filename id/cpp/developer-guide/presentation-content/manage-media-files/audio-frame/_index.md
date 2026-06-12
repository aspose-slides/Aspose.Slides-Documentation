---
title: Kelola Audio dalam Presentasi Menggunakan C++
linktitle: Bingkai Audio
type: docs
weight: 10
url: /id/cpp/audio-frame/
keywords:
- audio
- bingkai audio
- gambar mini
- tambahkan audio
- properti audio
- opsi audio
- ekstrak audio
- C++
- Aspose.Slides
description: "Buat dan kendalikan bingkai audio di Aspose.Slides untuk C++—contoh kode untuk menyematkan, memangkas, mengulang, dan mengonfigurasi pemutaran pada presentasi PPT, PPTX, dan ODP."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan bingkai audio di Aspose.Slides. Artikel ini menunjukkan cara menambahkan audio yang disematkan ke slide, menyesuaikan thumbnail bingkai audio, mengkonfigurasi opsi pemutaran seperti volume, pengulangan, penyembunyian, pemangkasan, dan durasi fade, serta mengekstrak audio yang digunakan dalam transisi slide show.

## **Buat Bingkai Audio**

Aspose.Slides untuk C++ memungkinkan Anda menambahkan file audio ke slide. File audio disematkan dalam slide sebagai bingkai audio. 

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Muat stream file audio yang ingin Anda sematkan ke slide.
4. Tambahkan bingkai audio yang disematkan (berisi file audio) ke slide.
5. Atur [PlayMode](https://reference.aspose.com/slides/id/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) dan `Volume` yang disediakan oleh objek [IAudioFrame](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_audio_frame).
6. Simpan presentasi yang telah diubah.

Kode C++ berikut menunjukkan cara menambahkan bingkai audio yang disematkan ke slide:

``` cpp
// Membuat instance kelas Presentation yang mewakili file presentasi
auto pres = System::MakeObject<Presentation>();

// Mengambil slide pertama
auto sld = pres->get_Slides()->idx_get(0);

// Memuat file suara wav ke aliran
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Menambahkan Bingkai Audio
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Mengatur Mode Putar dan Volume Audio
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Menulis file PowerPoint ke disk
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Ubah Thumbnail Bingkai Audio**

Saat Anda menambahkan file audio ke presentasi, audio muncul sebagai bingkai dengan gambar default standar (lihat gambar pada bagian di bawah). Anda dapat mengubah thumbnail bingkai audio (menetapkan gambar pilihan Anda).

Kode C++ berikut menunjukkan cara mengubah thumbnail atau gambar preview bingkai audio:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Menambahkan bingkai audio ke slide dengan posisi dan ukuran yang ditentukan.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Menambahkan gambar ke sumber daya presentasi.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Mengatur gambar untuk bingkai audio.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
// Menyimpan presentasi yang telah dimodifikasi ke disk
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ubah Opsi Pemutaran Audio**

Aspose.Slides untuk C++ memungkinkan Anda mengubah opsi yang mengontrol pemutaran atau properti audio. Misalnya, Anda dapat menyesuaikan volume audio, mengatur audio untuk diputar berulang, atau bahkan menyembunyikan ikon audio.

Panel **Audio Options** di Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opsi **Audio** PowerPoint yang sesuai dengan metode Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/audioframe/) :

- **Start** drop-down list cocok dengan metode [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/id/cpp/aspose.slides/audioframe/set_playmode/)
- **Volume** cocok dengan metode [AudioFrame::set_Volume](https://reference.aspose.com/slides/id/cpp/aspose.slides/audioframe/set_volume/)
- **Play Across Slides** cocok dengan metode [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/audioframe/set_playacrossslides/)
- **Loop until Stopped** cocok dengan metode [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/id/cpp/aspose.slides/audioframe/set_playloopmode/)
- **Hide During Show** cocok dengan metode [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/id/cpp/aspose.slides/audioframe/set_hideatshowing/)
- **Rewind after Playing** cocok dengan metode [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/id/cpp/aspose.slides/audioframe/set_rewindaudio/)

Opsi **Editing** PowerPoint yang sesuai dengan properti Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/audioframe/) :

- **Fade In** cocok dengan metode [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/id/cpp/aspose.slides/audioframe/set_fadeinduration/)
- **Fade Out** cocok dengan metode [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/id/cpp/aspose.slides/audioframe/set_fadeoutduration/)
- **Trim Audio Start Time** cocok dengan metode [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/id/cpp/aspose.slides/audioframe/set_trimfromstart/)
- **Trim Audio End Time** memiliki nilai yang sama dengan durasi audio dikurangi nilai metode [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/id/cpp/aspose.slides/audioframe/set_trimfromend/)

Kontrol **Volume** PowerPoint pada panel kontrol audio sesuai dengan metode [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/id/cpp/aspose.slides/audioframe/set_volumevalue/). Ini memungkinkan Anda mengubah volume audio dalam persentase.

Berikut cara mengubah opsi Pemutaran Audio:

1. [Create](#creating-audio-frame) atau dapatkan Audio Frame.
2. Atur nilai baru untuk properti Audio Frame yang ingin Anda sesuaikan.
3. Simpan file PowerPoint yang telah dimodifikasi.

Kode C++ berikut mendemonstrasikan operasi dimana opsi audio disesuaikan:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Dapatkan sebuah shape
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Mengkonversi shape menjadi shape AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Mengatur mode putar agar diputar saat diklik
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Mengatur volume menjadi rendah
audioFrame->set_Volume(AudioVolumeMode::Low);

// Mengatur audio agar diputar di seluruh slide
audioFrame->set_PlayAcrossSlides(true);

// Menonaktifkan pengulangan untuk audio
audioFrame->set_PlayLoopMode(false);

// Menyembunyikan AudioFrame selama pertunjukan slide
audioFrame->set_HideAtShowing(true);

// Memundurkan audio ke awal setelah diputar
audioFrame->set_RewindAudio(true);

// Menyimpan file PowerPoint ke disk
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

Contoh C++ ini menunjukkan cara menambahkan bingkai audio baru dengan audio yang disematkan, memangkasnya, dan mengatur durasi fade:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Sets the trimming start offset to 1.5 seconds
audioFrame->set_TrimFromStart(1500);
// Sets the trimming end offset to 2 seconds
audioFrame->set_TrimFromEnd(2000);

// Sets the fade-in duration to 200 ms
audioFrame->set_FadeInDuration(200);
// Sets the fade-out duration to 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

Contoh kode berikut menunjukkan cara mengambil bingkai audio dengan audio yang disematkan dan mengatur volumenya menjadi 85%:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Mendapatkan shape bingkai audio
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Mengatur volume audio menjadi 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **Kelola Caption Audio**

Aspose.Slides memungkinkan Anda menambahkan caption tertutup ke bingkai audio melalui metode [get_CaptionTracks](https://reference.aspose.com/slides/id/cpp/aspose.slides/iaudioframe/get_captiontracks/). Metode ini mengembalikan sebuah [ICaptionsCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptionscollection/), yang memungkinkan Anda menambahkan track caption WebVTT, mengiterasi track yang ada, dan menghapusnya bila diperlukan.

**Tambah Caption Audio**

Gunakan metode [get_CaptionTracks](https://reference.aspose.com/slides/id/cpp/aspose.slides/iaudioframe/get_captiontracks/) untuk melampirkan satu atau lebih track caption ke bingkai audio. Pada contoh berikut, file audio ditambahkan ke slide, kemudian track caption baru dimuat dari file `.vtt`.

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// Add a new caption track from a WebVTT file.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Ekstrak Caption Audio**

Anda dapat mengiterasi track caption yang terkait dengan bingkai audio dan menyimpannya sebagai file `.vtt`. Setiap track caption menampilkan data biner serta pengidentifikasi uniknya, yang dapat digunakan saat mengekspor caption.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // Simpan setiap track caption sebagai file .vtt.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**Hapus Caption Audio**

Untuk menghapus caption dari bingkai audio, gunakan metode yang disediakan oleh [ICaptionsCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptionscollection/), seperti [Clear](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptionscollection/remove/), atau [RemoveAt](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptionscollection/removeat/). Contoh berikut menghapus semua track caption dari sebuah bingkai audio.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// Hapus semua track caption dari bingkai audio.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ekstrak Audio**
Aspose.Slides memungkinkan Anda mengekstrak suara yang digunakan dalam transisi slide show. Misalnya, Anda dapat mengekstrak suara yang digunakan pada slide tertentu.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation) dan muat presentasi yang berisi audio.
2. Dapatkan referensi slide yang relevan melalui indeksnya.
3. Akses transisi slideshow untuk slide tersebut.
4. Ekstrak suara dalam bentuk data byte.

Kode C++ berikut menunjukkan cara mengekstrak audio yang digunakan pada sebuah slide:

``` cpp
String presName = u"AudioSlide.pptx";

// Membuat instance kelas Presentation yang mewakili file presentasi
auto pres = System::MakeObject<Presentation>(presName);

// Mengakses slide yang diinginkan
auto slide = pres->get_Slides()->idx_get(0);

// Mendapatkan efek transisi slideshow untuk slide
auto transition = slide->get_SlideShowTransition();

// Mengekstrak suara dalam array byte
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **FAQ**

**Apakah saya dapat menggunakan kembali aset audio yang sama di beberapa slide tanpa memperbesar ukuran file?**

Ya. Tambahkan audio sekali ke [koleksi audio](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_audios/) bersama presentasi dan buat bingkai audio tambahan yang merujuk ke aset yang sudah ada. Ini menghindari duplikasi data media dan menjaga ukuran presentasi tetap terkendali.

**Apakah saya dapat mengganti suara pada bingkai audio yang sudah ada tanpa membuat ulang bentuk?**

Ya. Untuk suara yang ditautkan, perbarui [link path](https://reference.aspose.com/slides/id/cpp/aspose.slides/audioframe/set_linkpathlong/) agar mengarah ke file baru. Untuk suara yang disematkan, ganti objek [embedded audio](https://reference.aspose.com/slides/id/cpp/aspose.slides/audioframe/set_embeddedaudio/) dengan yang lain dari [koleksi audio](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_audios/) presentasi. Format bingkai serta sebagian besar pengaturan pemutaran tetap tidak berubah.

**Apakah pemangkasan mengubah data audio dasar yang disimpan dalam presentasi?**

Tidak. Pemangkasan hanya menyesuaikan batas pemutaran. Byte audio asli tetap tidak terpengaruh dan dapat diakses melalui audio yang disematkan atau koleksi audio presentasi.