---
title: Mengelola Frame Video dalam Presentasi Menggunakan C++
linktitle: Frame Video
type: docs
weight: 10
url: /id/cpp/video-frame/
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
- C++
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengekstrak frame video secara programatis dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk C++. Panduan cepat."
---
## **Pendahuluan**

Video yang ditempatkan dengan tepat dalam presentasi dapat membuat pesan Anda lebih menarik dan meningkatkan tingkat keterlibatan audiens.

PowerPoint memungkinkan Anda menambahkan video ke slide dalam presentasi dengan dua cara:

* Menambahkan atau menyematkan video lokal (disimpan di mesin Anda)
* Menambahkan video daring (dari sumber web seperti YouTube).

Untuk memungkinkan Anda menambahkan video (objek video) ke presentasi, Aspose.Slides menyediakan antarmuka [IVideo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideo/), antarmuka [IVideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/) , dan tipe terkait lainnya. 

## **Membuat Frame Video Tertanam**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat frame video untuk menyematkan video ke dalam presentasi.

1. Buat instance kelas [Presentation ](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) .
1. Dapatkan referensi slide melalui indeksnya. 
1. Tambahkan objek [IVideo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideo/) dan berikan jalur file video untuk menyematkan video ke presentasi. 
1. Tambahkan objek [IVideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/) untuk membuat frame bagi video.  
1. Simpan presentasi yang telah dimodifikasi. 

Kode C++ berikut menunjukkan cara menambahkan video yang disimpan secara lokal ke presentasi:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Memuat video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Mengambil slide pertama dan menambahkan frame video
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


## **Membuat Frame Video dengan Video dari Sumber Web**

Microsoft [PowerPoint 2013 dan yang lebih baru](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) mendukung video YouTube dalam presentasi. Jika video yang ingin Anda gunakan tersedia secara daring (mis. di YouTube), Anda dapat menambahkannya ke presentasi melalui tautan webnya. 

1. Buat instance kelas [Presentation ](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) 
1. Dapatkan referensi slide melalui indeksnya. 
1. Tambahkan objek [IVideo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideo/) dan berikan tautan ke video. 
1. Tetapkan thumbnail untuk frame video. 
1. Simpan presentasi. 

Kode C++ berikut menunjukkan cara menambahkan video dari web ke slide dalam presentasi PowerPoint:

```c++
// Jalur ke direktori dokumen.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Membuat instance objek Presentation yang mewakili file presentasi
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Mengakses slide pertama
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Menambahkan Frame Video 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Mengatur Mode Pemutaran dan Volume Video
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Menyimpan presentasi ke disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Mengelola Caption Video**

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk frame video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui metode [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/get_captiontracks/). 

**Menambahkan Caption ke Frame Video**

Untuk menambahkan caption ke frame video:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) . 
1. Tambahkan video ke presentasi. 
1. Tambahkan objek [IVideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/) ke slide. 
1. Gunakan [ICaptionsCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptionscollection/) yang dikembalikan oleh [get_CaptionTracks](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/get_captiontracks/) untuk menambahkan trek caption WebVTT. 
1. Simpan presentasi yang telah dimodifikasi. 

Kode berikut menunjukkan cara menambahkan caption ke frame video:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Adds a new captions track from a WebVTT file.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Antarmuka [ICaptionsCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari aliran data.

**Mengekstrak Caption dari Frame Video**

Untuk mengekstrak caption dari frame video:

1. Muat presentasi yang berisi video. 
1. Temukan objek [IVideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/) target. 
1. Iterasi melalui trek caption yang dikembalikan oleh [get_CaptionTracks](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/get_captiontracks/). 
1. Simpan setiap trek caption ke file `.vtt`. 

Kode berikut menunjukkan cara mengekstrak caption dari frame video:

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
            // Menyimpan trek caption ke file WebVTT.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Setiap objek [ICaptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptions/) menampilkan pengidentifikasi caption, label, data biner, dan data caption sebagai string UTF-8.

**Menghapus Caption dari Frame Video**

Untuk menghapus caption dari frame video:

1. Muat presentasi yang berisi video. 
1. Dapatkan objek [IVideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/) target. 
1. Hapus trek caption dari koleksi yang dikembalikan oleh [get_CaptionTracks](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/get_captiontracks/). 
1. Simpan presentasi yang telah dimodifikasi. 

Kode berikut menunjukkan cara menghapus semua caption dari frame video:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Menghapus semua caption dari frame video.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Jika Anda hanya perlu menghapus satu trek caption, gunakan metode [Remove](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptionscollection/remove/) atau [RemoveAt](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptionscollection/removeat/) alih-alih [Clear](https://reference.aspose.com/slides/id/cpp/aspose.slides/icaptionscollection/clear/).

## **Mengekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) untuk memuat presentasi yang berisi video. 
2. Iterasi melalui semua objek [ISlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/). 
3. Iterasi melalui semua objek [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/) untuk menemukan [VideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/videoframe/). 
4. Simpan video ke disk. 

Kode C++ berikut menunjukkan cara mengekstrak video dari slide presentasi:

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

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/id/cpp/aspose.slides/videoframe/set_playmode/) (otomatis atau klik) dan [pengulangan](https://reference.aspose.com/slides/id/cpp/aspose.slides/videoframe/set_playloopmode/). Opsi-opsi ini tersedia melalui properti objek [VideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/videoframe/). 

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Ketika Anda menyematkan video lokal, data biner dimasukkan ke dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Ketika Anda menambahkan video daring, tautan dan thumbnail disematkan, sehingga peningkatan ukuran lebih kecil. 

**Bisakah saya mengganti video dalam VideoFrame yang sudah ada tanpa mengubah posisi dan ukuran?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/id/cpp/aspose.slides/videoframe/set_embeddedvideo/) dalam frame sambil mempertahankan geometri bentuk; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang sudah ada. 

**Apakah tipe konten (MIME) video yang disematkan dapat ditentukan?**

Ya. Video yang disematkan memiliki [tipe konten](https://reference.aspose.com/slides/id/cpp/aspose.slides/video/get_contenttype/) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.