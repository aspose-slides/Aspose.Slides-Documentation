---
title: Video‑Frames in Präsentationen mit C++ verwalten
linktitle: Video‑Frame
type: docs
weight: 10
url: /de/cpp/video-frame/
keywords:
- Video hinzufügen
- Video erstellen
- Video einbetten
- Video extrahieren
- Video abrufen
- Video‑Frame
- Web‑Quelle
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie programmgesteuert Video‑Frames in PowerPoint‑ und OpenDocument‑Folien mit Aspose.Slides für C++ hinzufügen und extrahieren. Schnelle Anleitung."
---
Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihres Publikums steigern. 

PowerPoint ermöglicht das Hinzufügen von Videos zu einer Folie in einer Präsentation auf zwei Arten:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online‑Video hinzufügen (von einer Web‑Quelle wie YouTube).

Damit Sie Videos (Videoobjekte) zu einer Präsentation hinzufügen können, stellt Aspose.Slides das Interface [IVideo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideo/) und das Interface [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/) sowie weitere relevante Typen bereit. 

## **Ein eingebettetes Video‑Frame erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie ein Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)Klasse.  
2. Holen Sie sich über den Index eine Referenz auf eine Folie.  
3. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten.  
4. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/)‑Objekt hinzu, um einen Frame für das Video zu erstellen.  
5. Speichern Sie die geänderte Präsentation.  

Dieser C++‑Code zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Lädt das Video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Holt die erste Folie und fügt ein Video-Frame hinzu
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Speichert die Präsentation auf dem Datenträger
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

Alternativ können Sie ein Video hinzufügen, indem Sie dessen Dateipfad direkt an die Methode [AddVideoFrame()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addvideoframe/) übergeben:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **Ein Video‑Frame mit Video aus einer Web‑Quelle erstellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das gewünschte Video online verfügbar ist (z. B. auf YouTube), können Sie es über dessen Web‑Link in Ihre Präsentation einfügen. 

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)Klasse.  
2. Holen Sie sich über den Index eine Referenz auf eine Folie.  
3. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Link zum Video.  
4. Legen Sie ein Vorschaubild für das Video‑Frame fest.  
5. Speichern Sie die Präsentation.  

Dieser C++‑Code zeigt, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Erstellt ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Fügt ein Video-Frame hinzu
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Legt den Wiedergabemodus und die Lautstärke des Videos fest
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Speichert die Präsentation auf dem Datenträger
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Video‑Untertitel verwalten**

Aspose.Slides ermöglicht die Verwaltung von Closed‑Captions für Video‑Frames in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/get_captiontracks/) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

So fügen Sie einem Video‑Frame Untertitel hinzu:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse.  
2. Fügen Sie ein Video zur Präsentation hinzu.  
3. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/)‑Objekt zu einer Folie hinzu.  
4. Verwenden Sie die über [get_CaptionTracks](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/get_captiontracks/) zurückgegebene [ICaptionsCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptionscollection/), um eine WebVTT‑Untertitelspur hinzuzufügen.  
5. Speichern Sie die geänderte Präsentation.

Der folgende Code zeigt, wie Sie Untertitel zu einem Video‑Frame hinzufügen:

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

Die Schnittstelle [ICaptionsCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptionscollection/) bietet zudem eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Video‑Frame extrahieren**

So extrahieren Sie Untertitel aus einem Video‑Frame:

1. Laden Sie die Präsentation, die das Video enthält.  
2. Finden Sie das gewünschte [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/)‑Objekt.  
3. Iterieren Sie über die über [get_CaptionTracks](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/get_captiontracks/) zurückgegebenen Untertitelspuren.  
4. Speichern Sie jede Untertitelspur in einer `.vtt`‑Datei.

Der folgende Code zeigt, wie Sie Untertitel aus einem Video‑Frame extrahieren:

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
            // Speichert die Untertitelspur in einer WebVTT-Datei.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Jedes [ICaptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptions/)‑Objekt stellt die Untertitel‑Kennung, das Label, die Binärdaten und die Untertitel‑Daten als UTF‑8‑Zeichenfolge bereit.

**Untertitel aus einem Video‑Frame entfernen**

So entfernen Sie Untertitel aus einem Video‑Frame:

1. Laden Sie die Präsentation, die das Video enthält.  
2. Holen Sie sich das gewünschte [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/)‑Objekt.  
3. Entfernen Sie Untertitelspuren aus der über [get_CaptionTracks](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/get_captiontracks/) zurückgegebenen Sammlung.  
4. Speichern Sie die geänderte Präsentation.

Der folgende Code zeigt, wie Sie alle Untertitel aus einem Video‑Frame entfernen:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Entfernt alle Untertitel aus dem Video‑Frame.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Möchten Sie nur eine Untertitelspur entfernen, verwenden Sie die Methoden [Remove](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptionscollection/remove/) oder [RemoveAt](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptionscollection/removeat/), anstatt [Clear](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptionscollection/clear/) zu nutzen.

## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse, um die Präsentation mit dem Video zu laden.  
2. Durchlaufen Sie alle [ISlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/)‑Objekte.  
3. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/)‑Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/videoframe/) zu finden.  
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

**Welche Wiedergabe‑Parameter können für ein Video‑Frame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/de/cpp/aspose.slides/videoframe/set_playmode/) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/de/cpp/aspose.slides/videoframe/set_playloopmode/) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/videoframe/)‑Objekts zur Verfügung.

**Wirkt sich das Hinzufügen eines Videos auf die PPTX‑Dateigröße aus?**

Ja. Beim Einbetten eines lokalen Videos werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Beim Hinzufügen eines Online‑Videos werden ein Link und ein Vorschaubild eingebettet, wodurch die Größenzunahme geringer ist.

**Kann ich ein Video in einem bestehenden Video‑Frame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/de/cpp/aspose.slides/videoframe/set_embeddedvideo/) innerhalb des Frames austauschen und dabei die Geometrie der Form beibehalten; dies ist ein übliches Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video besitzt einen [Content‑Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/video/get_contenttype/), den Sie auslesen und beispielsweise beim Speichern auf dem Datenträger verwenden können.