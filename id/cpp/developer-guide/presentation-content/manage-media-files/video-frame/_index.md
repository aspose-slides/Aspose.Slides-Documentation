---
title: Kelola Bingkai Video dalam Presentasi Menggunakan C++
linktitle: Bingkai Video
type: docs
weight: 10
url: /id/cpp/video-frame/
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
- C++
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengekstrak bingkai video secara programatis dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk C++. Panduan cepat cara melakukannya."
---
## **Pendahuluan**

Video yang ditempatkan dengan tepat dalam presentasi dapat membuat pesan Anda lebih menarik dan meningkatkan tingkat keterlibatan dengan audiens.

PowerPoint memungkinkan Anda menambahkan video ke sebuah slide dalam presentasi dengan dua cara:

* Menambahkan atau menyematkan video lokal (disimpan di mesin Anda)
* Menambahkan video daring (dari sumber web seperti YouTube).

Untuk memungkinkan Anda menambahkan video (objek video) ke presentasi, Aspose.Slides menyediakan antarmuka [IVideo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideo/), antarmuka [IVideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/) , dan tipe relevan lainnya. 

## **Buat Bingkai Video Tersemat**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat bingkai video untuk menyematkan video dalam presentasi Anda. 

1. Buat instance dari kelas [Presentation ](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan objek [IVideo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideo/) dan berikan jalur file video untuk menyematkan video ke presentasi. 
4. Tambahkan objek [IVideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/) untuk membuat bingkai bagi video.  
5. Simpan presentasi yang telah dimodifikasi. 

Kode C++ berikut menunjukkan cara menambahkan video yang disimpan secara lokal ke presentasi:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Memuat video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Mendapatkan slide pertama dan menambahkan bingkai video
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Menyimpan presentasi ke disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

Sebagai alternatif, Anda dapat menambahkan video dengan langsung memberikan jalur file ke metode [AddVideoFrame()](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/addvideoframe/) :

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **Buat Bingkai Video dengan Video dari Sumber Web**

Versi terbaru Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) mendukung video daring dalam presentasi. Jika video yang ingin Anda gunakan tersedia secara daring (misalnya di YouTube), Anda dapat menambahkannya ke presentasi melalui tautan webnya.

1. Buat instance dari kelas [Presentation ](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) 
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan objek [IVideo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideo/) dan berikan tautan ke video. 
4. Atur thumbnail untuk bingkai video. 
5. Simpan presentasi. 

Kode C++ berikut menunjukkan cara menambahkan video dari web ke slide dalam presentasi PowerPoint:

```c++
// Jalur ke direktori dokumen.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Membuat objek Presentation yang mewakili file presentasi
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Mengakses slide pertama
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Menambahkan Bingkai Video 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Mengatur Mode Putar dan Volume Video
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Menyimpan presentasi ke disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Pangkas Bingkai Video**

Aspose.Slides memungkinkan Anda mengontrol bagian video yang diputar dengan mengatur nilai trim-from-start dan trim-from-end melalui [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/set_trimfromstart/) dan [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/set_trimfromend/). Kedua nilai ditentukan dalam milidetik dan mendefinisikan berapa banyak waktu yang dilewati dari awal dan akhir video masing‑masing. Pengaturan ini mengubah cara pemutaran video dalam presentasi; mereka tidak memotong atau mengubah data biner video yang disematkan.

**Atur Pengaturan Pangkas**

Untuk membuat bingkai video dan mengatur pengaturan pangkasnya:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) . 
2. Tambahkan objek [IVideo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideo/) ke presentasi. 
3. Tambahkan objek [IVideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/) ke sebuah slide. 
4. Atur nilai trim-from-start dan trim-from-end melalui [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/set_trimfromstart/) dan [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/set_trimfromend/). 
5. Simpan presentasi yang telah dimodifikasi.

Contoh kode berikut melewatkan 2,5 detik pertama dan 1 detik terakhir dari video yang disematkan saat diputar:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);

videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Baca Pengaturan Pangkas**

Untuk memeriksa pengaturan pangkas yang ada, muat presentasi, temukan objek [IVideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/) di antara shape pada slide pertama, dan baca nilainya melalui [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/get_trimfromstart/) dan [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/get_trimfromend/).

Contoh kode berikut menemukan bingkai video pertama pada slide pertama dan melaporkan pengaturan pangkasnya dalam milidetik:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");

auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        auto trimFromStart = videoFrame->get_TrimFromStart();
        auto trimFromEnd = videoFrame->get_TrimFromEnd();

        Console::WriteLine(u"Trim from start: {0} ms", trimFromStart);
        Console::WriteLine(u"Trim from end: {0} ms", trimFromEnd);

        break;
    }
}

presentation->Dispose();
```

## **Kelola Caption Video**

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk bingkai video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui metode [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/get_captiontracks/) .

**Tambahkan Caption ke Bingkai Video**

Untuk menambahkan caption ke bingkai video:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) .
2. Tambahkan video ke presentasi. 
3. Tambahkan objek [IVideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/) ke sebuah slide. 
4. Gunakan [ICaptionsCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptionscollection/) yang dikembalikan oleh [get_CaptionTracks](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/get_captiontracks/) untuk menambahkan track caption WebVTT. 
5. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara menambahkan caption ke bingkai video:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Menambahkan track caption baru dari file WebVTT.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Antarmuka [ICaptionsCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari aliran (stream).

**Ekstrak Caption dari Bingkai Video**

Untuk mengekstrak caption dari bingkai video:

1. Muat presentasi yang berisi video. 
2. Temukan objek [IVideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/) yang ditargetkan. 
3. Iterasi melalui track caption yang dikembalikan oleh [get_CaptionTracks](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/get_captiontracks/). 
4. Simpan setiap track caption ke file `.vtt` .

Kode berikut menunjukkan cara mengekstrak caption dari bingkai video:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : videoFrame->get_CaptionTracks())
        {
            // Menyimpan track caption ke file WebVTT.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Setiap objek [ICaptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptions/) menampilkan identifier caption, label, data biner, dan data caption sebagai string UTF‑8.

**Hapus Caption dari Bingkai Video**

Untuk menghapus caption dari bingkai video:

1. Muat presentasi yang berisi video. 
2. Dapatkan objek [IVideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/) yang ditargetkan. 
3. Hapus track caption dari koleksi yang dikembalikan oleh [get_CaptionTracks](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/get_captiontracks/) . 
4. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara menghapus semua caption dari bingkai video:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Menghapus semua caption dari bingkai video.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Jika Anda perlu menghapus hanya satu track caption, gunakan metode [Remove](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptionscollection/remove/) atau [RemoveAt](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptionscollection/removeat/) alih-alih [Clear](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptionscollection/clear/) .

## **Ekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) untuk memuat presentasi yang berisi video. 
2. Iterasi melalui semua objek [ISlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/) . 
3. Iterasi melalui semua objek [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/) untuk menemukan sebuah [VideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/videoframe/) . 
4. Simpan video ke disk.

Kode C++ berikut menunjukkan cara mengekstrak video pada slide presentasi:

```c++
// Jalur ke direktori dokumen.
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```

## **FAQ**

**Parameter pemutaran video apa yang dapat diubah untuk VideoFrame?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/id/cpp/aspose.slides/videoframe/set_playmode/) (otomatis atau pada klik) dan [pengulangan](https://reference.aspose.com/slides/id/cpp/aspose.slides/videoframe/set_playloopmode/). Opsi‑opsi ini tersedia melalui properti objek [VideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/videoframe/) .

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Saat Anda menyematkan video lokal, data biner termasuk dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Saat Anda menambahkan video daring, tautan dan thumbnail disematkan, sehingga peningkatan ukuran lebih kecil.

**Bisakah saya mengganti video dalam VideoFrame yang ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/id/cpp/aspose.slides/videoframe/set_embeddedvideo/) dalam bingkai sambil mempertahankan geometri shape; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang sudah ada.

**Apakah tipe konten (MIME) dari video yang disematkan dapat ditentukan?**

Ya. Video yang disematkan memiliki [tipe konten](https://reference.aspose.com/slides/id/cpp/aspose.slides/video/get_contenttype/) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.