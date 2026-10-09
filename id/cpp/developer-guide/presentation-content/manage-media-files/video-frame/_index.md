---
title: Mengelola Frame Video dalam Presentasi Menggunakan C++
linktitle: Frame Video
type: docs
weight: 10
url: /id/cpp/video-frame/
keywords:
- menambahkan video
- membuat video
- menanamkan video
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

Video dapat membantu menjelaskan ide dan menarik perhatian audiens. Aspose.Slides untuk C++ memungkinkan Anda menambahkan frame video ke slide, mengatur pengaturan pemutaran, mengelola caption, dan mengekstrak data video yang tertanam.

PowerPoint mendukung video lokal dan tautan ke video daring, seperti video YouTube.

Untuk merepresentasikan data video dan frame video, Aspose.Slides menyediakan antarmuka [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/), antarmuka [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) , dan tipe relevan lainnya.

## **Membuat Frame Video Tertanam**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat frame video untuk menanamkan video dalam presentasi Anda.

Contoh ini menanamkan video lokal pada slide pertama dari presentasi yang sudah ada dan menyimpan hasilnya. Koordinat dan dimensi frame dalam satuan point. Stream tetap terbuka hingga proses penyimpanan selesai karena [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) menguncinya selama presentasi menggunakannya.

```cpp
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <Export/SaveFormat.h>
#include <LoadingStreamBehavior.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto videoStream = File::OpenRead(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::KeepLocked);
slide->get_Shapes()->AddVideoFrame(10, 10, 150, 250, video);

presentation->Save(u"embedded_video.pptx", SaveFormat::Pptx);

presentation->Dispose();
videoStream->Dispose();
```

Anda juga dapat memberikan jalur video lokal langsung ke [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/). Contoh ini menanamkan video pada slide pertama dari presentasi baru. Video harus tetap dapat diakses sampai presentasi disimpan.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

slide->get_Shapes()->AddVideoFrame(50, 150, 300, 150, u"video.avi");

presentation->Save(u"video_from_path.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Membuat Frame Video dengan Video dari Sumber Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) mendukung video daring dalam presentasi. Anda dapat membuat frame video yang menautkan ke video daring, seperti video YouTube.

Contoh ini menambahkan tautan video YouTube dan thumbnail ke slide pertama. Ganti identifier video untuk menggunakan video lain. Metode [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) meminta pemutaran otomatis. Mengunduh thumbnail dan memutar video memerlukan akses internet. Penampil presentasi juga harus mendukung pemutaran video daring.

```cpp
#include <net/web_client.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/VideoPlayModePreset.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);


auto webClient = MakeObject<System::Net::WebClient>();

String videoId = u"aqz-KE-bpKQ";
auto videoUrl = String::Format(u"https://www.youtube.com/embed/{0}", videoId);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

auto thumbnailUrl = String::Format(u"https://img.youtube.com/vi/{0}/hqdefault.jpg", videoId);
auto thumbnailData = webClient->DownloadData(thumbnailUrl);
auto thumbnail = presentation->get_Images()->AddImage(thumbnailData);
videoFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"online_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Memutar Video dalam Mode Layar Penuh**

Dalam presentasi pelatihan, Anda dapat memutar demo perangkat lunak dalam mode layar penuh sehingga audiens dapat melihat detailnya. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) menerima `true` untuk mengaktifkan perilaku ini selama pemutaran.

Contoh ini membuka presentasi, menemukan [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) pertama pada slide pertama, dan mengaktifkan pemutaran layar penuh. Presentasi input harus berisi setidaknya satu slide dengan frame video yang ada pada slide pertama.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_FullScreenMode(true);
        break;
    }
}

presentation->Save(u"full_screen_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pemutaran layar penuh mengontrol cara video ditampilkan. Secara terpisah, [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) mengontrol apakah video dimulai secara otomatis atau dengan klik, dan [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) mengontrol apakah video berulang. Untuk memilih perilaku awal, setel mode pemutaran ke [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/). Contoh ini mempertahankan pengaturan awal dan loop yang ada.

## **Memutar Ulang Video Setelah Pemutaran**

Dalam presentasi pelatihan, mengembalikan video demo ke awalnya membuatnya siap untuk diputar lagi oleh presenter. Panggil [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) dengan `true` untuk mengembalikan video ke awal setelah pemutaran selesai.

Contoh ini membuka presentasi, menemukan [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) pertama pada slide pertama, dan mengaktifkan pemutaran ulang. Ia menonaktifkan pengulangan sehingga pemutaran dapat selesai dan mengatur pemutaran untuk dimulai dengan klik. Presentasi input harus berisi setidaknya satu slide dengan frame video yang ada pada slide pertama.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <DOM/VideoPlayModePreset.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_RewindVideo(true);
        videoFrame->set_PlayLoopMode(false);
        videoFrame->set_PlayMode(VideoPlayModePreset::OnClick);
        break;
    }
}

presentation->Save(u"rewind_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pemutaran ulang mengembalikan video ke awalnya tanpa memulai lagi. Sebaliknya, mengaktifkan [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) membuat pemutaran berulang secara otomatis. Jaga agar pengulangan tetap nonaktif ketika Anda menginginkan video selesai dan siap diputar ulang. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) secara terpisah mengontrol pemutaran otomatis atau pada klik; contoh ini menggunakan [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) sehingga presenter mengontrol kapan pemutaran dimulai. Tetapkan mode pemutaran setelah pengaturan loop, seperti yang ditunjukkan dalam contoh. Pemutaran ulang bekerja terpisah dari [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/).

## **Memangkas Frame Video**

Gunakan [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) dan [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) untuk melewati bagian awal atau akhir video selama pemutaran. Kedua nilai dalam milidetik. Pemangkasan mengubah pengaturan pemutaran tanpa memodifikasi data video yang tertanam.

**Atur Pengaturan Pemangkasan**

Contoh ini menanamkan video lokal dan melewati 2,5 detik pertama serta 1 detik terakhir selama pemutaran. Gunakan video yang lebih lama dari 3,5 detik agar segmen yang dapat diputar tetap ada.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);
videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Baca Pengaturan Pemangkasan**

Contoh ini mencetak nilai pemangkasan dari frame video pertama pada slide pertama dalam milidetik. Presentasi harus berisi setidaknya satu slide. Jika slide tersebut tidak memiliki frame video, tidak ada yang dicetak. Contoh sebelumnya menghasilkan nilai 2500 dan 1000.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        Console::WriteLine(String::Format(u"Trim from start: {0} ms", videoFrame->get_TrimFromStart()));
        Console::WriteLine(String::Format(u"Trim from end: {0} ms", videoFrame->get_TrimFromEnd()));
        break;
    }
}

presentation->Dispose();
```

## **Mengelola Caption Video**

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk frame video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui metode [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Menambahkan Caption ke Frame Video**

Contoh ini menanamkan video lokal dan menambahkan track caption WebVTT berlabel English. Stempel waktu caption harus cocok dengan video. Presentasi yang disimpan mencakup video dan captionnya.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Antarmuka [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari stream.

**Mengekstrak Caption dari Frame Video**

Contoh ini menyimpan semua track caption dari frame video pada slide pertama sebagai file WebVTT terpisah. Nomor berurutan menjaga file output tetap unik. Konsol melaporkan jumlah track yang diekstrak. Presentasi harus berisi setidaknya satu slide.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto trackCount = 0;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : IterateOver(videoFrame->get_CaptionTracks()))
        {
            trackCount++;
            auto outputPath = String::Format(u"captions_{0}.vtt", trackCount);
            File::WriteAllBytes(outputPath, captionTrack->get_BinaryData());
        }
    }
}

Console::WriteLine(String::Format(u"Caption tracks extracted: {0}", trackCount));

presentation->Dispose();
```

Setiap objek [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) menampilkan identifier caption, label, data biner, dan teks caption sebagai string UTF-8.

**Menghapus Caption dari Frame Video**

Contoh ini menghapus semua caption dari frame video pada posisi shape pertama di slide pertama dan menyimpan hasilnya. Asumsinya slide dan shape ada serta shape tersebut merupakan frame video.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Jika Anda hanya perlu menghapus satu track caption, gunakan metode [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) atau [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) alih-alih [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/).

## **Mengekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang tertanam dalam presentasi.

Contoh ini mengekstrak video tertanam dari setiap slide ke dalam file biner terpisah yang diberi nomor. Video yang ditautkan dilewati karena tidak memiliki data tertanam. Konsol mencetak tipe MIME setiap video dan total jumlahnya. Output menggunakan ekstensi umum `.bin`; ubah sesuai tipe media yang dilaporkan bila diperlukan.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideo.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation_with_videos.pptx");

auto videoCount = 0;
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            auto videoFrame = ExplicitCast<IVideoFrame>(shape);
            auto video = videoFrame->get_EmbeddedVideo();
            if (video == nullptr)
            {
                Console::WriteLine(u"Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            auto outputPath = String::Format(u"extracted_video_{0}.bin", videoCount);
            File::WriteAllBytes(outputPath, video->get_BinaryData());
            Console::WriteLine(String::Format(u"Video {0}: {1}", videoCount, video->get_ContentType()));
        }
    }
}

Console::WriteLine(String::Format(u"Embedded videos extracted: {0}", videoCount));

presentation->Dispose();
```

## **Tanya Jawab**

**Parameter pemutaran video apa yang dapat diubah untuk frame video?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (otomatis atau pada klik) dan [pengulangan](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). Opsi ini tersedia melalui metode objek [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Saat Anda menanamkan video lokal, data biner disertakan dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Saat Anda menautkan ke video daring dan menambahkan thumbnail, presentasi menyimpan tautan dan gambar pratinjau alih-alih data video, sehingga peningkatan ukuran biasanya lebih kecil.

**Bisakah saya mengganti video dalam frame video yang ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) di dalam frame sambil mempertahankan geometri shape; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang ada.

**Dapatkah tipe konten (MIME) dari video tertanam ditentukan?**

Ya. Video tertanam memiliki [tipe konten](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.