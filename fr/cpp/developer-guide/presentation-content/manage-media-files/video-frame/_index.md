---
title: Gérer les cadres vidéo dans les présentations avec C++
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

Les vidéos peuvent aider à expliquer des idées et à capter un public. Aspose.Slides for C++ vous permet d’ajouter des cadres vidéo aux diapositives, d’ajuster les paramètres de lecture, de gérer les sous‑titres et d’extraire les données vidéo incorporées.

PowerPoint prend en charge les vidéos locales et les liens vers des vidéos en ligne, telles que les vidéos YouTube.

Pour représenter les données vidéo et les cadres vidéo, Aspose.Slides fournit les interfaces [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) , [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) , et d’autres types pertinents.

## **Créer un cadre vidéo incorporé**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour incorporer la vidéo dans votre présentation.

Cet exemple intègre une vidéo locale sur la première diapositive d’une présentation existante et enregistre le résultat. Les coordonnées et les dimensions du cadre sont exprimées en points. Le flux reste ouvert jusqu’à la fin de l’enregistrement parce que [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) le maintient verrouillé pendant que la présentation l’utilise.

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

Vous pouvez également passer un chemin vidéo local directement à [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/). Cet exemple intègre la vidéo sur la première diapositive d’une nouvelle présentation. La vidéo doit rester accessible jusqu’à ce que la présentation soit enregistrée.

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

## **Créer un cadre vidéo avec une vidéo provenant d’une source Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) prend en charge les vidéos en ligne dans les présentations. Vous pouvez créer un cadre vidéo qui lie à une vidéo en ligne, telle qu’une vidéo YouTube.

Cet exemple ajoute un lien vidéo YouTube et une miniature à la première diapositive. Remplacez l’identifiant vidéo pour utiliser une autre vidéo. La méthode [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) demande une lecture automatique. Le téléchargement de la miniature et la lecture de la vidéo nécessitent un accès Internet. Le visualiseur de présentation doit également prendre en charge la lecture de vidéos en ligne.

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

## **Lire une vidéo en mode plein écran**

Dans une présentation de formation, vous pouvez lire une démonstration logicielle en mode plein écran afin que le public puisse voir les détails. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) accepte `true` pour activer ce comportement pendant la lecture.

Cet exemple ouvre une présentation, trouve le premier [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) sur la première diapositive et active la lecture en plein écran. La présentation d’entrée doit contenir au moins une diapositive avec un cadre vidéo existant sur la première diapositive.

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

La lecture en plein écran contrôle la façon dont la vidéo est affichée. De façon indépendante, [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) contrôle si elle démarre automatiquement ou au clic, et [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) contrôle si elle se répète. Pour choisir le comportement de démarrage, définissez le mode de lecture sur [VideoPlayModePreset::Auto ou VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/). L’exemple conserve les paramètres de démarrage et de boucle existants.

## **Rembobiner une vidéo après la lecture**

Dans une présentation de formation, ramener une vidéo de démonstration au début la rend prête pour que le présentateur la relance. Appelez [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) avec `true` pour ramener la vidéo au début après la fin de la lecture.

Cet exemple ouvre une présentation, trouve le premier [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) sur la première diapositive et active le rembobinage. Il désactive la boucle afin que la lecture puisse se terminer et définit le démarrage de la lecture au clic. La présentation d’entrée doit contenir au moins une diapositive avec un cadre vidéo existant sur la première diapositive.

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

Le rembobinage ramène la vidéo à son début sans la relancer. En revanche, l’activation de [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) répète la lecture automatiquement. Gardez la boucle désactivée lorsque vous voulez que la vidéo se termine et reste prête à être relancée. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) contrôle indépendamment le démarrage automatique ou au clic ; cet exemple utilise [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) afin que le présentateur contrôle le moment du début. Définissez le mode de lecture après le réglage de la boucle, comme le montre l’exemple. Le rembobinage fonctionne indépendamment de [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/).

## **Rogner un cadre vidéo**

Utilisez [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) et [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) pour sauter une partie du début ou de la fin d’une vidéo pendant la lecture. Les deux valeurs sont exprimées en millisecondes. Le rognage modifie les paramètres de lecture sans modifier les données vidéo incorporées.

**Définir les paramètres de rognage**

Cet exemple intègre une vidéo locale et saute les 2,5 premières secondes ainsi que la dernière seconde pendant la lecture. Utilisez une vidéo de plus de 3,5 secondes afin qu’un segment lisible reste.

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

**Lire les paramètres de rognage**

Cet exemple affiche les valeurs de rognage du premier cadre vidéo sur la première diapositive en millisecondes. La présentation doit contenir au moins une diapositive. Si cette diapositive ne comporte aucun cadre vidéo, rien n’est affiché. L’exemple précédent produit les valeurs 2500 et 1000.

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

## **Gérer les sous‑titres vidéo**

Aspose.Slides vous permet de gérer les sous‑titrés fermés pour les cadres vidéo dans les présentations PowerPoint. Les sous‑titres sont stockés au format WebVTT et sont exposés via la méthode [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) .

**Ajouter des sous‑titres à un cadre vidéo**

Cet exemple intègre une vidéo locale et ajoute une piste de sous‑titres WebVTT intitulée English. Les horodatages des sous‑titres doivent correspondre à la vidéo. La présentation enregistrée inclut à la fois la vidéo et ses sous‑titres.

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

L’interface [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) propose également une surcharge qui vous permet d’ajouter des sous‑titres à partir d’un flux.

**Extraire les sous‑titres d’un cadre vidéo**

Cet exemple enregistre toutes les pistes de sous‑titres des cadres vidéo de la première diapositive en fichiers WebVTT distincts. Des numéros séquentiels maintiennent les fichiers de sortie distincts. La console indique le nombre de pistes extraites. La présentation doit contenir au moins une diapositive.

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

Chaque objet [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) expose l’identifiant du sous‑titre, le libellé, les données binaires et le texte du sous‑titre sous forme de chaîne UTF‑8.

**Supprimer les sous‑titres d’un cadre vidéo**

Cet exemple supprime tous les sous‑titres du cadre vidéo à la première position de forme sur la première diapositive et enregistre le résultat. Il suppose que la diapositive et la forme existent et que la forme est un cadre vidéo.

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

Si vous devez supprimer une seule piste de sous‑titres, utilisez les méthodes [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) ou [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) au lieu de [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/) .

## **Extraire une vidéo d’une diapositive**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos incorporées dans les présentations.

Cet exemple extrait les vidéos incorporées de chaque diapositive en fichiers binaires séparés et numérotés. Les vidéos liées sont ignorées car elles ne contiennent pas de données incorporées. La console affiche le type MIME de chaque vidéo ainsi que le nombre total. La sortie utilise l’extension générique `.bin` ; modifiez‑la pour correspondre au type de média signalé si besoin.

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

## **FAQ**

**Quels paramètres de lecture vidéo peuvent être modifiés pour un cadre vidéo ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (auto ou au clic) et le [bouclage](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). Ces options sont disponibles via les méthodes de l’objet [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) .

**L’ajout d’une vidéo affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, de sorte que la taille de la présentation augmente proportionnellement à la taille du fichier. Lorsque vous liez à une vidéo en ligne et ajoutez une miniature, la présentation stocke le lien et l’image de prévisualisation plutôt que les données vidéo, ce qui rend l’augmentation de taille généralement plus faible.

**Puis‑je remplacer la vidéo d’un cadre vidéo existant sans modifier sa position et sa taille ?**

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) à l’intérieur du cadre tout en préservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une disposition existante.

**Peut‑on déterminer le type de contenu (MIME) d’une vidéo incorporée ?**

Oui. Une vidéo incorporée possède un [type de contenu](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur disque.