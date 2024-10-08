---
title: Video Frame
type: docs
weight: 10
url: /de/cpp/video-frame/
keywords: "Video hinzufügen, Video-Frame erstellen, Video extrahieren, PowerPoint-Präsentation, C++, CPP, Aspose.Slides für C++"
description: "Fügen Sie einen Video-Frame zu einer PowerPoint-Präsentation in C++ hinzu"

---

Ein gut platzierter Video in einer Präsentation kann Ihre Botschaft überzeugender machen und die Engagement-Levels Ihres Publikums erhöhen.

PowerPoint ermöglicht es Ihnen, Videos auf zwei Arten zu einer Folie in einer Präsentation hinzuzufügen:

* Fügen Sie ein lokales Video hinzu oder betten Sie es ein (auf Ihrem Computer gespeichert)
* Fügen Sie ein Online-Video hinzu (aus einer Webquelle wie YouTube).

Um es Ihnen zu ermöglichen, Videos (Videoobjekte) zu einer Präsentation hinzuzufügen, bietet Aspose.Slides die [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) Schnittstelle, die [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) Schnittstelle und andere relevante Typen.

## **Eingebetteten Video-Frame erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video-Frame erstellen, um das Video in Ihre Präsentation einzubetten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz auf die Folie über ihren Index.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video mit der Präsentation einzubetten.
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) Objekt hinzu, um einen Frame für das Video zu erstellen.
1. Speichern Sie die modifizierte Präsentation.

Dieser C++ Code zeigt Ihnen, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Lädt das Video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Holt die erste Folie und fügt einen Video-Frame hinzu
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Speichert die Präsentation auf der Festplatte
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

Alternativ können Sie ein Video hinzufügen, indem Sie den Pfad zur Datei direkt an die [AddVideoFrame()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) Methode übergeben:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **Video-Frame mit Video aus Webquelle erstellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube-Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über den Weblink zu Ihrer Präsentation hinzufügen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz auf die Folie über ihren Index.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) Objekt hinzu und übergeben Sie den Link zum Video.
1. Legen Sie ein Thumbnail für den Video-Frame fest.
1. Speichern Sie die Präsentation.

Dieser C++ Code zeigt Ihnen, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint-Präsentation hinzufügen:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Erstellt ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Fügt einen Video-Frame hinzu 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Legt den Abspielmodus und die Lautstärke des Videos fest
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Speichert die Präsentation auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Video von Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht es Aspose.Slides Ihnen, Videos, die in Präsentationen eingebettet sind, zu extrahieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse, um die Präsentation zu laden, die das Video enthält.
2. Iterieren Sie durch alle [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) Objekte.
3. Iterieren Sie durch alle [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) Objekte, um einen [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) zu finden.
4. Speichern Sie das Video auf der Festplatte.

Dieser C++ Code zeigt Ihnen, wie Sie das Video auf einer Präsentationsfolie extrahieren:

```c++
// Der Pfad zum Dokumentenverzeichnis.
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