---
title: Video
type: docs
weight: 80
url: /it/cpp/examples/elements/video/
keywords:
- esempio di codice
- video
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Aggiungi e controlla i video con Aspose.Slides per C++: inserisci, riproduci, ritaglia, imposta i frame poster e esporta con esempi C++ per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come incorporare frame video e impostare le opzioni di riproduzione utilizzando **Aspose.Slides for C++**.

## **Aggiungi un frame video**

Inserisci un frame video vuoto su una diapositiva.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Aggiungi un video.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Accedi a un frame video**

Recupera il primo frame video aggiunto a una diapositiva.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Accedi al primo frame video sulla diapositiva.
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

## **Rimuovi un frame video**

Elimina un frame video dalla diapositiva.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Rimuovi il frame video.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Imposta la riproduzione del video**

Configura il video per essere riprodotto automaticamente quando la diapositiva viene visualizzata.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Configura il video per la riproduzione automatica.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```