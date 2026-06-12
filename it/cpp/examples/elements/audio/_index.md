---
title: Audio
type: docs
weight: 70
url: /it/cpp/examples/elements/audio/
keywords:
- esempio di codice
- audio
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri gli esempi audio di Aspose.Slides for C++: inserire, riprodurre, ritagliare ed estrarre suoni in presentazioni PPT, PPTX e ODP con codice C++ chiaro."
---
Questo articolo dimostra come incorporare frame audio e controllare la riproduzione con **Aspose.Slides for C++**. Gli esempi seguenti mostrano operazioni audio di base.

## **Aggiungi un frame audio**

Inserisci un frame audio vuoto che può contenere in seguito dati audio incorporati.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Crea un frame audio vuoto (l'audio sarà incorporato in seguito).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Accedi a un frame audio**

Questo codice recupera il primo frame audio in una diapositiva.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Accedi al primo frame audio nella diapositiva.
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

## **Rimuovi un frame audio**

Elimina un frame audio precedentemente aggiunto.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Rimuovi il frame audio.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Imposta la riproduzione audio**

Configura il frame audio affinché venga riprodotto automaticamente quando la diapositiva appare.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Riproduci automaticamente quando la diapositiva appare.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```