---
title: Cadre Vidéo
type: docs
weight: 10
url: /cpp/video-frame/
keywords: "Ajouter vidéo, créer cadre vidéo, extraire vidéo, présentation PowerPoint, C++, CPP, Aspose.Slides pour C++"
description: "Ajouter un cadre vidéo à une présentation PowerPoint en C++"

---

Un vidéo bien placée dans une présentation peut rendre votre message plus convaincant et augmenter l'engagement de votre public.

PowerPoint vous permet d'ajouter des vidéos à une diapositive dans une présentation de deux manières :

* Ajouter ou intégrer une vidéo locale (stockée sur votre machine)
* Ajouter une vidéo en ligne (d'une source web telle que YouTube).

Pour vous permettre d'ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit l'interface [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/), l'interface [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) et d'autres types pertinents.

## **Créer un Cadre Vidéo Intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) et passez le chemin du fichier vidéo pour intégrer la vidéo avec la présentation.
1. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) pour créer un cadre pour la vidéo.
1. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment ajouter une vidéo stockée localement à une présentation :

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Charge la vidéo
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Obtient la première diapositive et ajoute un cadre vidéo
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Enregistre la présentation sur le disque
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

Alternativement, vous pouvez ajouter une vidéo en passant directement son chemin de fichier à la méthode [AddVideoFrame()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) :

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **Créer un Cadre Vidéo avec Vidéo d'une Source Web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par exemple sur YouTube), vous pouvez l'ajouter à votre présentation via son lien web.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) et passez le lien vers la vidéo.
1. Définissez une miniature pour le cadre vidéo.
1. Enregistrez la présentation.

Ce code C++ montre comment ajouter une vidéo du web à une diapositive dans une présentation PowerPoint :

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Instancie un objet Presentation qui représente un fichier de présentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Ajoute un Cadre Vidéo
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Définit le Mode de Lecture et le Volume de la Vidéo
vf->set_PlayMode(VideoPlayModePreset::Auto);

// Enregistre la présentation sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Extraire la Vidéo d'une Diapositive**

En plus d'ajouter des vidéos aux diapositives, Aspose.Slides vous permet d'extraire des vidéos intégrées dans des présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) pour charger la présentation contenant la vidéo.
2. Parcourez tous les objets [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/).
3. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).
4. Enregistrez la vidéo sur le disque.

Ce code C++ montre comment extraire la vidéo d'une diapositive de présentation :

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