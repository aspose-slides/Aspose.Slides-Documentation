---
title: Video
type: docs
weight: 80
url: /id/cpp/examples/elements/video/
keywords:
- contoh kode
- video
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Tambahkan dan kendalikan video dengan Aspose.Slides untuk C++: sisipkan, putar, potong, atur frame poster, dan ekspor dengan contoh C++ untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menyematkan bingkai video dan mengatur opsi pemutaran menggunakan **Aspose.Slides for C++**.

## **Menambahkan Bingkai Video**

Sisipkan bingkai video kosong ke dalam slide.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Tambahkan video.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Mengakses Bingkai Video**

Ambil bingkai video pertama yang ditambahkan ke slide.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Akses bingkai video pertama pada slide.
    auto firstVideo = SharedPtr<IVideoFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            firstVideo = ExplicitCast<IVideoFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Menghapus Bingkai Video**

Hapus bingkai video dari slide.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Hapus bingkai video.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Mengatur Pemutaran Video**

Konfigurasikan video agar diputar secara otomatis saat slide ditampilkan.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Konfigurasikan video agar diputar otomatis.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```