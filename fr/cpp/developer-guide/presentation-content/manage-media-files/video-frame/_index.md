---
title: Gérer les cadres vidéo dans les présentations avec C++
linktitle: Cadre vidéo
type: docs
weight: 10
url: /fr/cpp/video-frame/
keywords:
- ajouter une vidéo
- créer une vidéo
- incorporer une vidéo
- extraire une vidéo
- récupérer une vidéo
- cadre vidéo
- source web
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmatique des cadres vidéo dans les diapositives PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour C++. Guide pratique rapide."
---
Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre public. 

PowerPoint vous permet d'ajouter des vidéos à une diapositive d'une présentation de deux manières :

* Ajouter ou incorporer une vidéo locale (stockée sur votre ordinateur)
* Ajouter une vidéo en ligne (provenant d'une source Web telle que YouTube).

Pour vous permettre d'ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit les interfaces [IVideo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideo/) et [IVideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/), ainsi que d'autres types pertinents. 

## **Créer un cadre vidéo intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour incorporer la vidéo dans votre présentation. 

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) .
2. Obtenez la référence d’une diapositive via son indice. 
3. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideo/) et transmettez le chemin du fichier vidéo pour incorporer la vidéo à la présentation. 
4. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/) pour créer un cadre pour la vidéo.  
5. Enregistrez la présentation modifiée. 

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


## **Créer un cadre vidéo à partir d’une source Web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par exemple sur YouTube), vous pouvez l’ajouter à votre présentation via son lien Web. 

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) .
2. Obtenez la référence d’une diapositive via son indice. 
3. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideo/) et transmettez le lien vers la vidéo.
4. Définissez une vignette pour le cadre vidéo. 
5. Enregistrez la présentation. 

Ce code C++ montre comment ajouter une vidéo depuis le Web à une diapositive d’une présentation PowerPoint :

```c++
// Le chemin du répertoire des documents.
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

## **Gérer les sous-titres vidéo**

Aspose.Slides vous permet de gérer les sous‑titres fermés pour les cadres vidéo dans les présentations PowerPoint. Les sous‑titres sont stockés au format WebVTT et sont accessibles via la méthode [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Ajouter des sous-titres à un cadre vidéo**

Pour ajouter des sous‑titres à un cadre vidéo :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) .
2. Ajoutez une vidéo à la présentation.
3. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/) à une diapositive.
4. Utilisez la [ICaptionsCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icaptionscollection/) retournée par [get_CaptionTracks](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/get_captiontracks/) pour ajouter une piste de sous‑titres WebVTT.
5. Enregistrez la présentation modifiée.

Le code suivant montre comment ajouter des sous‑titres à un cadre vidéo :

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

L’interface [ICaptionsCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icaptionscollection/) fournit également une surcharge qui vous permet d’ajouter des sous‑titres à partir d’un flux.

**Extraire les sous‑titres d’un cadre vidéo**

Pour extraire les sous‑titres d’un cadre vidéo :

1. Chargez la présentation contenant la vidéo.
2. Trouvez l’objet [IVideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/) cible.
3. Parcourez les pistes de sous‑titres renvoyées par [get_CaptionTracks](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/get_captiontracks/).
4. Enregistrez chaque piste de sous‑titres dans un fichier `.vtt`.

Le code suivant montre comment extraire les sous‑titres d’un cadre vidéo :

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
            // Enregistre la piste de sous‑titres dans un fichier WebVTT.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Chaque objet [ICaptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icaptions/) expose l’identifiant du sous‑titre, le libellé, les données binaires et le texte du sous‑titre sous forme de chaîne UTF-8.

**Supprimer les sous‑titres d’un cadre vidéo**

Pour supprimer les sous‑titres d’un cadre vidéo :

1. Chargez la présentation contenant la vidéo.
2. Obtenez l’objet [IVideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/) cible.
3. Supprimez les pistes de sous‑titres de la collection renvoyée par [get_CaptionTracks](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/get_captiontracks/).
4. Enregistrez la présentation modifiée.

Le code suivant montre comment supprimer tous les sous‑titres d’un cadre vidéo :

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Supprime toutes les pistes de sous-titres du cadre video.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Si vous devez supprimer une seule piste de sous‑titres, utilisez les méthodes [Remove](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icaptionscollection/remove/) ou [RemoveAt](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icaptionscollection/removeat/) au lieu de [Clear](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icaptionscollection/clear/).

## **Extraire la vidéo d’une diapositive**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos incorporées dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) pour charger la présentation contenant la vidéo. 
2. Parcourez tous les objets [ISlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/). 
3. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/videoframe/). 
4. Enregistrez la vidéo sur le disque.

Ce code C++ montre comment extraire la vidéo d’une diapositive de présentation :

```c++
// Le chemin du répertoire des documents.
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

**L’ajout d’une vidéo affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ce qui fait croître la taille de la présentation proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une vignette sont incorporés, de sorte que l’augmentation de taille est moindre.

**Puis‑je remplacer la vidéo dans un VideoFrame existant sans changer sa position et sa taille ?**

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/videoframe/set_embeddedvideo/) à l’intérieur du cadre tout en conservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une mise en page existante.

**Peut‑on déterminer le type de contenu (MIME) d’une vidéo intégrée ?**

Oui. Une vidéo intégrée possède un [type de contenu](https://reference.aspose.com/slides/fr/cpp/aspose.slides/video/get_contenttype/) que vous pouvez lire et utiliser, par exemple lors de l’enregistrement sur le disque.