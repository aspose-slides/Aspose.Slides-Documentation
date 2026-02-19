---
title: Audio
type: docs
weight: 70
url: /fr/cpp/examples/elements/audio/
keywords:
- exemple de code
- audio
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Découvrez les exemples audio d'Aspose.Slides for C++: insertion, lecture, découpage et extraction du son dans les présentations PPT, PPTX et ODP avec du code C++ clair."
---
Cet article montre comment intégrer des cadres audio et contrôler la lecture avec **Aspose.Slides for C++**. Les exemples suivants illustrent les opérations audio de base.

## **Ajouter un cadre audio**

Insérez un cadre audio vide qui pourra ensuite contenir des données sonores intégrées.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Créer un cadre audio vide (le son sera intégré plus tard).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Accéder à un cadre audio**

Ce code récupère le premier cadre audio d’une diapositive.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Accéder au premier cadre audio sur la diapositive.
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

## **Supprimer un cadre audio**

Supprimez un cadre audio ajouté précédemment.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Supprimer le cadre audio.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Définir la lecture audio**

Configurez le cadre audio pour qu’il se lance automatiquement lorsque la diapositive apparaît.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Lire automatiquement lorsque la diapositive apparaît.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```