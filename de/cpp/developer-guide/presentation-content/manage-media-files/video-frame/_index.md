---
title: Verwalten von Video‑Frames in Präsentationen mit C++
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
description: "Erfahren Sie, wie Sie programmgesteuert Video‑Frames in PowerPoint‑ und OpenDocument‑Folien mit Aspose.Slides für C++ hinzufügen und extrahieren. Schnell‑Anleitung."
---
## **Einleitung**

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihres Publikums erhöhen.  

PowerPoint ermöglicht das Hinzufügen von Videos zu einer Folie in einer Präsentation auf zwei Arten:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Computer gespeichert)
* Ein Online‑Video hinzufügen (aus einer Web‑Quelle wie YouTube).

Damit Sie Videos (Video‑Objekte) zu einer Präsentation hinzufügen können, stellt Aspose.Slides die Schnittstellen [IVideo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideo/) und [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/) sowie weitere relevante Typen zur Verfügung. 

## **Ein eingebettetes Video‑Frame erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie ein Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Holen Sie sich die Referenz einer Folie über deren Index. 
3. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten. 
4. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/)‑Objekt hinzu, um einen Frame für das Video zu erstellen.  
5. Speichern Sie die geänderte Präsentation. 

Dieser C++‑Code zeigt, wie ein lokal gespeichertes Video zu einer Präsentation hinzugefügt wird:

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

Alternativ können Sie ein Video hinzufügen, indem Sie seinen Dateipfad direkt an die Methode [AddVideoFrame()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addvideoframe/) übergeben:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **Ein Video‑Frame mit Video aus einer Web‑Quelle erstellen**

Neuere Versionen von Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) unterstützen Online‑Videos in Präsentationen. Wenn das gewünschte Video online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Web‑Link zu Ihrer Präsentation hinzufügen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Holen Sie sich die Referenz einer Folie über deren Index. 
3. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Link zum Video.
4. Legen Sie ein Vorschaubild für das Video‑Frame fest. 
5. Speichern Sie die Präsentation. 

Dieser C++‑Code zeigt, wie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzugefügt wird:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Erstellt ein Presentation-Objekt, das eine Präsentationsdatei darstellt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Fügt einen Video-Frame hinzu 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Setzt den Wiedergabemodus und die Lautstärke des Videos
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Speichert die Präsentation auf dem Datenträger
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ein Video‑Frame zuschneiden**

Aspose.Slides ermöglicht es Ihnen, den abgespielten Teil eines Videos über die Werte trim‑from‑start und trim‑from‑end über die Methoden [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/set_trimfromstart/) und [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/set_trimfromend/) zu steuern. Beide Werte werden in Millisekunden angegeben und bestimmen, wie viel Zeit zu Beginn bzw. am Ende des Videos übersprungen wird. Diese Einstellungen ändern die Wiedergabeparameter im Präsentations‑Dokument; sie schneiden das eingebettete Videomaterial nicht.

**Trim‑Einstellungen festlegen**

Um ein Video‑Frame zu erstellen und dessen Trim‑Einstellungen zu setzen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideo/)‑Objekt zur Präsentation hinzu.
3. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/)‑Objekt zu einer Folie hinzu.
4. Setzen Sie die Werte trim‑from‑start und trim‑from‑end über [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/set_trimfromstart/) und [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/set_trimfromend/).
5. Speichern Sie die geänderte Präsentation.

Der folgende Code überspringt die ersten 2,5 Sekunden und die letzte Sekunde eines eingebetteten Videos während der Wiedergabe:

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

**Trim‑Einstellungen auslesen**

Um vorhandene Trim‑Einstellungen zu prüfen, laden Sie eine Präsentation, suchen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/)‑Objekt auf der ersten Folie und lesen Sie die Werte über [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/get_trimfromstart/) und [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/get_trimfromend/).

Der folgende Code findet das erste Video‑Frame auf der ersten Folie und gibt dessen Trim‑Einstellungen in Millisekunden aus:

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

## **Video‑Untertitel verwalten**

Aspose.Slides ermöglicht das Verwalten von geschlossenen Untertiteln für Video‑Frames in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/get_captiontracks/) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

Um einem Video‑Frame Untertitel hinzuzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Fügen Sie ein Video zur Präsentation hinzu.
3. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/)‑Objekt zu einer Folie hinzu.
4. Verwenden Sie die von [get_CaptionTracks](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/get_captiontracks/) zurückgegebene [ICaptionsCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptionscollection/), um einen WebVTT‑Untertitel‑Track hinzuzufügen.
5. Speichern Sie die geänderte Präsentation.

Der folgende Code zeigt, wie Untertitel zu einem Video‑Frame hinzugefügt werden:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Fügt einen neuen Untertitel-Track aus einer WebVTT-Datei hinzu.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Die Schnittstelle [ICaptionsCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptionscollection/) bietet zudem eine Überladung, mit der Untertitel aus einem Stream hinzugefügt werden können.

**Untertitel aus einem Video‑Frame extrahieren**

Um Untertitel aus einem Video‑Frame zu extrahieren:

1. Laden Sie die Präsentation, die das Video enthält.
2. Finden Sie das Ziel‑[IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/)‑Objekt.
3. Durchlaufen Sie die von [get_CaptionTracks](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/get_captiontracks/) zurückgegebenen Untertitel‑Tracks.
4. Speichern Sie jeden Untertitel‑Track in einer `.vtt`‑Datei.

Der folgende Code zeigt, wie Untertitel aus einem Video‑Frame extrahiert werden:

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
            // Speichert den Untertitel-Track in einer WebVTT-Datei.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Jedes [ICaptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptions/)‑Objekt stellt die Untertitel‑Kennung, das Label, die Binärdaten und die Untertitel‑Daten als UTF‑8‑String bereit.

**Untertitel aus einem Video‑Frame entfernen**

Um Untertitel aus einem Video‑Frame zu entfernen:

1. Laden Sie die Präsentation, die das Video enthält.
2. Holen Sie das Ziel‑[IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/)‑Objekt.
3. Entfernen Sie Untertitel‑Tracks aus der von [get_CaptionTracks](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/get_captiontracks/) zurückgegebenen Sammlung.
4. Speichern Sie die geänderte Präsentation.

Der folgende Code zeigt, wie alle Untertitel aus einem Video‑Frame entfernt werden:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Entfernt alle Untertitel aus dem Video-Frame.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wenn Sie nur einen Untertitel‑Track entfernen möchten, verwenden Sie die Methoden [Remove](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptionscollection/remove/) oder [RemoveAt](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptionscollection/removeat/) anstelle von [Clear](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptionscollection/clear/).

## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/), um die Präsentation zu laden, die das Video enthält. 
2. Durchlaufen Sie alle [ISlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/)‑Objekte.
3. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/)‑Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/videoframe/) zu finden. 
4. Speichern Sie das Video auf dem Datenträger.

Dieser C++‑Code zeigt, wie das Video einer Präsentationsfolie extrahiert wird:

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

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/de/cpp/aspose.slides/videoframe/set_playmode/) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/de/cpp/aspose.slides/videoframe/set_playloopmode/) steuern. Diese Optionen stehen über die Eigenschaften des Objekts [VideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/videoframe/) zur Verfügung.

**Beeinflusst das Hinzufügen eines Videos die Dateigröße der PPTX?**

Ja. Beim Einbetten eines lokalen Videos werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Beim Hinzufügen eines Online‑Videos werden nur ein Link und ein Vorschaubild eingebettet, sodass die Größensteigerung geringer ist.

**Kann ich das Video in einem bestehenden Video‑Frame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/de/cpp/aspose.slides/videoframe/set_embeddedvideo/) im Frame austauschen, während die Geometrie der Form erhalten bleibt; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [Content‑Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/video/get_contenttype/), den Sie auslesen und z. B. beim Speichern auf dem Datenträger verwenden können.