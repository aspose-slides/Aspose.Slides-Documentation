---
title: Audio
type: docs
weight: 70
url: /id/cpp/examples/elements/audio/
keywords:
- contoh kode
- audio
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Temukan contoh audio Aspose.Slides untuk C++: sisipkan, putar, pangkas, dan ekstrak suara dalam presentasi PPT, PPTX, dan ODP dengan kode C++ yang jelas."
---
Artikel ini menunjukkan cara menyematkan bingkai audio dan mengontrol pemutaran dengan **Aspose.Slides for C++**. Contoh-contoh berikut menunjukkan operasi audio dasar.

## **Menambahkan Bingkai Audio**

Sisipkan bingkai audio kosong yang kemudian dapat menampung data suara tersemat.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Buat bingkai audio kosong (audio akan disematkan nanti).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Mengakses Bingkai Audio**

Kode ini mengambil bingkai audio pertama pada sebuah slide.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Akses bingkai audio pertama pada slide.
    auto firstAudio = SharedPtr<IAudioFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAudioFrame>(shape))
        {
            firstAudio = ExplicitCast<IAudioFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Menghapus Bingkai Audio**

Hapus bingkai audio yang sebelumnya telah ditambahkan.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Hapus bingkai audio.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Mengatur Pemutaran Audio**

Konfigurasikan bingkai audio agar diputar secara otomatis ketika slide muncul.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Putar secara otomatis ketika slide muncul.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```