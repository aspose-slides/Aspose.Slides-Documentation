---
title: Verwalten von Video-Frames in Präsentationen mit C++
linktitle: Video-Frame
type: docs
weight: 10
url: /de/cpp/video-frame/
keywords:
- Video hinzufügen
- Video erstellen
- Video einbetten
- Video extrahieren
- Video abrufen
- Video-Frame
- Web-Quelle
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Lernen Sie, wie Sie programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für C++ hinzufügen und extrahieren. Schnelle Anleitung."
---

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und die Engagement‑Level Ihres Publikums erhöhen. 

PowerPoint ermöglicht das Hinzufügen von Videos zu einer Folie in einer Präsentation auf zwei Arten:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online‑Video hinzufügen (von einer Web‑Quelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Video‑Objekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides das Interface [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/), das Interface [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) und weitere relevante Typen bereit. 

## **Ein eingebettetes Video‑Frame erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie ein Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich über den Index eine Referenz auf eine Folie.  
3. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/)-Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten.  
4. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/)-Objekt hinzu, um ein Frame für das Video zu erstellen.  
5. Speichern Sie die geänderte Präsentation.  

Dieser C++‑Code zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Lädt das Video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Holt die erste Folie und fügt einen Video-Frame hinzu
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Speichert die Präsentation auf dem Datenträger
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```


Alternativ können Sie ein Video hinzufügen, indem Sie seinen Dateipfad direkt an die Methode [AddVideoFrame()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) übergeben:
``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```



## **Ein Video‑Frame mit Video aus einer Web‑Quelle erstellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützen YouTube‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Web‑Link zu Ihrer Präsentation hinzufügen. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich über den Index eine Referenz auf eine Folie.  
3. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/)-Objekt hinzu und übergeben Sie den Link zum Video.  
4. Legen Sie ein Vorschaubild für das Video‑Frame fest.  
5. Speichern Sie die Präsentation.  

Dieser C++‑Code zeigt, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:
```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Fügt ein Video-Frame hinzu 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Setzt den Wiedergabemodus und die Lautstärke des Videos
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Speichert die Präsentation auf dem Datenträger
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse, um die Präsentation zu laden, die das Video enthält.  
2. Durchlaufen Sie alle [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/)-Objekte.  
3. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)-Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) zu finden.  
4. Speichern Sie das Video auf dem Datenträger.  

Dieser C++‑Code zeigt, wie Sie das Video einer Präsentationsfolie extrahieren:
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


## **FAQ**

**Welche Wiedergabe‑Parameter können für ein VideoFrame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/)-Objekts zur Verfügung.

**Wirkt sich das Hinzufügen eines Videos auf die Dateigröße der PPTX aus?**

Ja. Beim Einbetten eines lokalen Videos werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Beim Hinzufügen eines Online‑Videos werden lediglich ein Link und ein Vorschaubild eingebettet, sodass der Größenzuwachs geringer ist.

**Kann ich das Video in einem bestehenden VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Videoinhalt](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) im Frame austauschen und dabei die Geometrie der Form beibehalten; das ist ein häufiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der MIME‑Typ eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video besitzt einen [Content‑Type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/), den Sie auslesen und beispielsweise beim Speichern auf dem Datenträger verwenden können.