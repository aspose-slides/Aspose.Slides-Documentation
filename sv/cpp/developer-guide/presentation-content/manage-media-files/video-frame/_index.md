---
title: Hantera videoramar i presentationer med C++
linktitle: Videoram
type: docs
weight: 10
url: /sv/cpp/video-frame/
keywords:
- lägg till video
- skapa video
- bädda in video
- extrahera video
- hämta video
- videoram
- webbkälla
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lär dig programatiskt att lägga till och extrahera videoramar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++. Snabb guide."
---
## **Introduktion**

En välplacerad video i en presentation kan göra ditt budskap mer övertygande och öka engagemangsnivåerna hos din publik. 

PowerPoint låter dig lägga till videor i en bild i en presentation på två sätt:

* Lägg till eller bädda in en lokal video (lagrad på din maskin)
* Lägg till en online‑video (från en webbkälla såsom YouTube).

För att du ska kunna lägga till videor (videoobjekt) i en presentation tillhandahåller Aspose.Slides [IVideo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ivideo/)‑gränssnittet, [IVideoFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ivideoframe/)‑gränssnittet och andra relevanta typer. 

## **Skapa en inbäddad videoram**

Om videofilen du vill lägga till på din bild är lagrad lokalt kan du skapa ett videoram för att bädda in videon i din presentation. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta en bilds referens via dess index. 
3. Lägg till ett [IVideo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ivideo/)‑objekt och skicka videofilens sökväg för att bädda in videon i presentationen. 
4. Lägg till ett [IVideoFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ivideoframe/)‑objekt för att skapa ett ram för videon.  
5. Spara den modifierade presentationen. 

Denna C++‑kod visar hur du lägger till en lokalt lagrad video i en presentation:

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

Alternativt kan du lägga till en video genom att skicka dess filsökväg direkt till metoden [AddVideoFrame()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addvideoframe/):

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **Skapa ett videoram med video från en webbkälla**

Microsoft [PowerPoint 2013 och nyare](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) stöder YouTube‑videor i presentationer. Om videon du vill använda finns online (t.ex. på YouTube) kan du lägga till den i din presentation via dess webblänk. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta en bilds referens via dess index. 
3. Lägg till ett [IVideo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ivideo/)‑objekt och skicka länken till videon.
4. Ställ in en miniatyr för videoramen. 
5. Spara presentationen. 

Denna C++‑kod visar hur du lägger till en video från webben på en bild i en PowerPoint‑presentation:

```c++
// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Instansierar ett Presentation‑objekt som representerar en presentationsfil
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Hämtar den första bilden
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Lägger till ett videoram 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Ställer in uppspelningsläge och volym för videon
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Sparar presentationen till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Hantera video‑undertexter**

Aspose.Slides låter dig hantera stängda undertexter för videoramar i PowerPoint‑presentationer. Undertexterna lagras i WebVTT‑format och exponeras via metoden [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Lägg till undertexter i ett videoram**

För att lägga till undertexter i ett videoram:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Lägg till en video i presentationen.
3. Lägg till ett [IVideoFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ivideoframe/)‑objekt på en bild.
4. Använd den [ICaptionsCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icaptionscollection/) som returneras av [get_CaptionTracks](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ivideoframe/get_captiontracks/) för att lägga till ett WebVTT‑undertextspår.
5. Spara den modifierade presentationen.

Följande kod visar hur du lägger till undertexter i ett videoram:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Lägger till ett nytt undertextspår från en WebVTT-fil.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icaptionscollection/)‑gränssnittet tillhandahåller också en överlagring som låter dig lägga till undertexter från en ström.

**Extrahera undertexter från ett videoram**

För att extrahera undertexter från ett videoram:

1. Läs in presentationen som innehåller videon.
2. Hitta målobjektet [IVideoFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ivideoframe/).
3. Iterera genom de undertextspår som returneras av [get_CaptionTracks](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ivideoframe/get_captiontracks/).
4. Spara varje undertextspår till en `.vtt`‑fil.

Följande kod visar hur du extraherar undertexter från ett videoram:

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
            // Sparar undertextspåret till en WebVTT-fil.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Varje [ICaptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icaptions/)‑objekt exponerar undertextens identifierare, etikett, binärdata och undertextdata som en UTF‑8‑sträng.

**Ta bort undertexter från ett videoram**

För att ta bort undertexter från ett videoram:

1. Läs in presentationen som innehåller videon.
2. Hämta målobjektet [IVideoFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ivideoframe/).
3. Ta bort undertextspår från samlingen som returneras av [get_CaptionTracks](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ivideoframe/get_captiontracks/).
4. Spara den modifierade presentationen.

Följande kod visar hur du tar bort alla undertexter från ett videoram:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Tar bort alla undertexter från videoramen.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Om du bara behöver ta bort ett undertextspår, använd metoderna [Remove](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icaptionscollection/remove/) eller [RemoveAt](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icaptionscollection/removeat/) istället för [Clear](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icaptionscollection/clear/).

## **Extrahera video från en bild**

Förutom att lägga till videor på bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) för att läsa in presentationen som innehåller videon. 
2. Iterera genom alla [ISlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/)‑objekt.
3. Iterera genom alla [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/)‑objekt för att hitta ett [VideoFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/videoframe/). 
4. Spara videon till disk.

Denna C++‑kod visar hur du extraherar videon på en presentationsbild:

```c++
// Sökvägen till dokumentkatalogen.
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

**Vilka videouppspelningsparametrar kan ändras för ett VideoFrame?**

Du kan kontrollera [uppspelningsläget](https://reference.aspose.com/slides/sv/cpp/aspose.slides/videoframe/set_playmode/) (automatiskt eller vid klick) och [loopning](https://reference.aspose.com/slides/sv/cpp/aspose.slides/videoframe/set_playloopmode/). Dessa alternativ är tillgängliga via [VideoFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/videoframe/)-objektets egenskaper.

**Påverkar det att lägga till en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas binärdata i dokumentet, så presentationens storlek ökar i proportion till filens storlek. När du lägger till en online‑video bäddas en länk och en miniatyr in, så storleksökningen blir mindre.

**Kan jag ersätta videon i ett befintligt VideoFrame utan att ändra dess position och storlek?**

Ja. Du kan byta ut [videoinnehållet](https://reference.aspose.com/slides/sv/cpp/aspose.slides/videoframe/set_embeddedvideo/) i ramen medan du bevarar formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [innehållstyp](https://reference.aspose.com/slides/sv/cpp/aspose.slides/video/get_contenttype/) som du kan läsa och använda, till exempel när du sparar den till disk.