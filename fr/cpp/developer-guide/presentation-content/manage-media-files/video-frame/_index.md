---
title: Gestion des cadres vidéo dans les présentations avec C++
linktitle: Cadre vidéo
type: docs
weight: 10
url: /fr/cpp/video-frame/
keywords:
- ajouter vidéo
- créer vidéo
- intégrer vidéo
- extraire vidéo
- récupérer vidéo
- cadre vidéo
- source web
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmatiquement des cadres vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour C++. Guide pratique rapide."
---
## **Introduction**

Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre audience. 

PowerPoint vous permet d’ajouter des vidéos à une diapositive d’une présentation de deux manières :

* Ajouter ou incorporer une vidéo locale (stockée sur votre ordinateur)
* Ajouter une vidéo en ligne (provenant d’une source Web telle que YouTube).

Pour vous permettre d’ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit les interfaces [IVideo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideo/) et [IVideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/), ainsi que d’autres types pertinents. 

## **Créer un cadre vidéo incorporé**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour incorporer la vidéo dans votre présentation. 

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) .
1. Obtenez la référence d’une diapositive via son indice. 
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideo/) et transmettez le chemin du fichier vidéo pour incorporer la vidéo à la présentation. 
1. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/) pour créer un cadre pour la vidéo.  
1. Enregistrez la présentation modifiée. 

Ce code C++ montre comment ajouter une vidéo stockée localement à une présentation :

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

Alternativement, vous pouvez ajouter une vidéo en transmettant directement son chemin de fichier à la méthode [AddVideoFrame()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/addvideoframe/) :

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **Créer un cadre vidéo avec une vidéo provenant d’une source web**

Les versions récentes de Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) prennent en charge les vidéos en ligne dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (p. ex. sur YouTube), vous pouvez l’ajouter à votre présentation via son lien web.

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) 
1. Obtenez la référence d’une diapositive via son indice. 
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideo/) et transmettez le lien de la vidéo.
1. Définissez une vignette pour le cadre vidéo. 
1. Enregistrez la présentation. 

Ce code C++ montre comment ajouter une vidéo depuis le web à une diapositive d’une présentation PowerPoint :

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Instancie un objet Presentation qui représente un fichier de présentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Ajoute un cadre vidéo 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Définit le mode de lecture et le volume de la vidéo
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Enregistre la présentation sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Rogner un cadre vidéo**

Aspose.Slides vous permet de contrôler la partie d’une vidéo qui est lue en définissant les valeurs trim-from-start et trim-from-end via [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/set_trimfromstart/) et [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/set_trimfromend/). Les deux valeurs sont exprimées en millisecondes et indiquent le temps à ignorer au début et à la fin de la vidéo, respectivement. Ces paramètres modifient les réglages de lecture de la vidéo dans la présentation ; ils ne découpent ni ne modifient les données binaires de la vidéo incorporée.

**Définir les paramètres de rognage**

Pour créer un cadre vidéo et définir ses paramètres de rognage :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) .
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideo/) à la présentation.
1. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/) à une diapositive.
1. Définissez les valeurs trim-from-start et trim-from-end via [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/set_trimfromstart/) et [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/set_trimfromend/).
1. Enregistrez la présentation modifiée.

L’exemple de code suivant saute les 2,5 premières secondes et la dernière seconde d’une vidéo incorporée lors de la lecture :

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

**Lire les paramètres de rognage**

Pour examiner les paramètres de rognage existants, chargez une présentation, trouvez un objet [IVideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/) parmi les formes de la première diapositive, et lisez les valeurs via [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/get_trimfromstart/) et [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/get_trimfromend/).

L’exemple de code suivant trouve le premier cadre vidéo sur la première diapositive et indique ses paramètres de rognage en millisecondes :

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

## **Gérer les sous-titres vidéo**

Aspose.Slides vous permet de gérer les sous-titres fermés pour les cadres vidéo dans les présentations PowerPoint. Les sous-titres sont stockés au format WebVTT et sont accessibles via la méthode [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Ajouter des sous-titres à un cadre vidéo**

Pour ajouter des sous-titres à un cadre vidéo :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) .
1. Ajoutez une vidéo à la présentation.
1. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/) à une diapositive.
1. Utilisez la [ICaptionsCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icaptionscollection/) renvoyée par [get_CaptionTracks](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/get_captiontracks/) pour ajouter une piste de sous-titres WebVTT.
1. Enregistrez la présentation modifiée.

Le code suivant montre comment ajouter des sous-titres à un cadre vidéo :

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Ajoute une nouvelle piste de sous-titres à partir d'un fichier WebVTT.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

L’interface [ICaptionsCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icaptionscollection/) propose également une surcharge qui vous permet d’ajouter des sous-titres à partir d’un flux.

**Extraire les sous-titres d’un cadre vidéo**

Pour extraire les sous-titres d’un cadre vidéo :

1. Chargez la présentation contenant la vidéo.
1. Trouvez l’objet [IVideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/) cible.
1. Parcourez les pistes de sous-titres renvoyées par [get_CaptionTracks](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Enregistrez chaque piste de sous-titres dans un fichier `.vtt`.

Le code suivant montre comment extraire les sous-titres d’un cadre vidéo :

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
            // Enregistre la piste de sous-titres dans un fichier WebVTT.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Chaque objet [ICaptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icaptions/) expose l’identifiant du sous-titre, le libellé, les données binaires et les données du sous-titre sous forme de chaîne UTF‑8.

**Supprimer les sous-titres d’un cadre vidéo**

Pour supprimer les sous-titres d’un cadre vidéo :

1. Chargez la présentation contenant la vidéo.
1. Récupérez l’objet [IVideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/) cible.
1. Supprimez les pistes de sous-titres de la collection renvoyée par [get_CaptionTracks](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Enregistrez la présentation modifiée.

Le code suivant montre comment supprimer tous les sous-titres d’un cadre vidéo :

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Supprime tous les sous-titres du cadre vidéo.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Si vous devez supprimer une seule piste de sous-titres, utilisez les méthodes [Remove](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icaptionscollection/remove/) ou [RemoveAt](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icaptionscollection/removeat/) au lieu de [Clear](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icaptionscollection/clear/).

## **Extraire la vidéo d’une diapositive**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos incorporées dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) pour charger la présentation contenant la vidéo. 
2. Parcourez tous les objets [ISlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/). 
3. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/videoframe/). 
4. Enregistrez la vidéo sur le disque.

Ce code C++ montre comment extraire la vidéo d’une diapositive d’une présentation :

```c++
// Le chemin vers le répertoire des documents.
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

**Quels paramètres de lecture vidéo peuvent être modifiés pour un VideoFrame ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/fr/cpp/aspose.slides/videoframe/set_playmode/) (automatique ou au clic) et la [boucle](https://reference.aspose.com/slides/fr/cpp/aspose.slides/videoframe/set_playloopmode/). Ces options sont disponibles via les propriétés de l’objet [VideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/videoframe/).

**L’ajout d’une vidéo affecte-t‑il la taille du fichier PPTX ?**

Oui. Lorsque vous incorporez une vidéo locale, les données binaires sont incluses dans le document, ce qui fait que la taille de la présentation augmente proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une vignette sont incorporés, de sorte que l’augmentation de taille est moindre.

**Puis‑je remplacer la vidéo d’un VideoFrame existant sans modifier sa position et sa taille ?**

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/videoframe/set_embeddedvideo/) à l’intérieur du cadre tout en conservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une mise en page existante.

**Peut‑on déterminer le type de contenu (MIME) d’une vidéo incorporée ?**

Oui. Une vidéo incorporée possède un [type de contenu](https://reference.aspose.com/slides/fr/cpp/aspose.slides/video/get_contenttype/) que vous pouvez lire et utiliser, par exemple lors de l’enregistrement sur le disque.