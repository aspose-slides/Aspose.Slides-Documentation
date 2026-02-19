---
title: Vidéo
type: docs
weight: 80
url: /fr/cpp/examples/elements/video/
keywords:
- exemple de code
- vidéo
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Ajoutez et contrôlez des vidéos avec Aspose.Slides for C++ : insérez, lisez, découpez, définissez des images d'affiche et exportez avec des exemples C++ pour les présentations PPT, PPTX et ODP."
---
Cet article démontre comment intégrer des cadres vidéo et définir les options de lecture à l'aide de **Aspose.Slides for C++**.

## **Add a Video Frame**
Ajouter un cadre vidéo

Insérer un cadre vidéo vide sur une diapositive.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Ajouter une vidéo.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Access a Video Frame**
Accéder à un cadre vidéo

Récupérer le premier cadre vidéo ajouté à une diapositive.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Accédez au premier cadre vidéo sur la diapositive.
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

## **Remove a Video Frame**
Supprimer un cadre vidéo

Supprimer un cadre vidéo de la diapositive.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Supprimer le cadre vidéo.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Set Video Playback**
Définir la lecture vidéo

Configurer la vidéo pour qu'elle se lance automatiquement lorsque la diapositive est affichée.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Configurer la vidéo pour qu'elle se lise automatiquement.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```