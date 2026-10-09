---
title: Hantera videoramar i presentationer i .NET
linktitle: Videoram
type: docs
weight: 10
url: /sv/net/video-frame/
keywords:
- lägga till video
- skapa video
- bädda in video
- extrahera video
- hämta video
- videoram
- webbkälla
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig programatiskt lägga till och extrahera videoramar i PowerPoint- och OpenDocument-bilder med Aspose.Slides för .NET. Snabb handledning."
---
## **Introduktion**

Videor kan hjälpa till att förklara idéer och engagera en publik. Aspose.Slides for .NET låter dig lägga till videoramar i bilder, justera uppspelningsinställningar, hantera undertexter och extrahera inbäddade videodata.

PowerPoint stöder lokala videor och länkar till online‑videor, till exempel YouTube‑videor.

För att representera videodata och videoramar tillhandahåller Aspose.Slides [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/)‑gränssnittet, [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)‑gränssnittet och andra relevanta typer.

## **Skapa en inbäddad videoram**

Om videofilen du vill lägga till i din bild lagras lokalt kan du skapa en videoram för att bädda in videon i din presentation.

Detta exempel bäddar in en lokal video på den första bilden i en befintlig presentation och sparar resultatet. Ramens koordinater och dimensioner är i punkter. Strömmen förblir öppen tills sparandet är klart eftersom [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) låser den medan presentationen använder den.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

Du kan också skicka en lokal videoväg direkt till [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Detta exempel bäddar in videon på den första bilden i en ny presentation. Videon måste förbli tillgänglig tills presentationen sparas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Skapa en videoram med video från en webbkälla**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) stöder online‑videor i presentationer. Du kan skapa en videoram som länkar till en online‑video, t.ex. en YouTube‑video.

Detta exempel lägger till en YouTube‑videolänk och miniatyrbild på den första bilden. Ersätt videobehörigheten för att använda en annan video. Inställningen [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) begär automatisk uppspelning. Nedladdning av miniatyrbilden och uppspelning av videon kräver internetåtkomst. Visningsprogrammet för presentationen måste också stödja uppspelning av online‑videor.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **Spela upp en video i helskärmsläge**

I en träningspresentation kan du spela upp en mjukvarudemonstration i helskärmsläge så att publiken kan se detaljerna. Ställ in [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) till `true` för att aktivera detta beteende under uppspelning.

Detta exempel öppnar en presentation, hittar den första [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) på den första bilden och aktiverar helskärmsuppspelning. Indatapresentationen måste innehålla minst en bild med en befintlig videoram på den första bilden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

Helskärmsuppspelning styr hur videon visas. Oberoende styr [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) om den startar automatiskt eller vid klick, och [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) styr om den upprepas. För att välja startbeteende, sätt uppspelningsläget till [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Exemplet bevarar de befintliga start- och loopinställningarna.

## **Spola tillbaka en video efter uppspelning**

I en träningspresentation gör att återföra en demonstrationsvideo till början den redo för presentatören att spela igen. Ställ in [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) till `true` för att återföra videon till början efter att uppspelningen avslutats.

Detta exempel öppnar en presentation, hittar den första [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) på den första bilden och aktiverar spolning tillbaka. Det inaktiverar loopning så att uppspelningen kan avslutas och sätter uppspelning att starta vid klick. Indatapresentationen måste innehålla minst en bild med en befintlig videoram på den första bilden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

Spolning tillbaka returnerar videon till början utan att starta den igen. I motsats till detta gör att aktivera [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) att uppspelningen upprepas automatiskt. Håll loopning inaktiverad när du vill att videon ska avslutas och förbli redo för återuppspelning. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) styr oberoende automatisk eller klickbaserad start; detta exempel använder [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) så presentatören kontrollerar när uppspelningen startar. Ställ in uppspelningsläget efter loopinställningen, som visas i exemplet. Spolning tillbaka fungerar oberoende av [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Trimma en videoram**

Använd [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) och [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) för att hoppa över en del av början eller slutet av en video under uppspelning. Båda värdena är i millisekunder. Trimning ändrar uppspelningsinställningarna utan att modifiera den inbäddade videodatan.

**Ställ in triminställningar**

Detta exempel bäddar in en lokal video och hoppar över de första 2,5 sekunderna och den sista sekunden under uppspelning. Använd en video som är längre än 3,5 sekunder så att ett spelbart segment återstår.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Läs triminställningar**

Detta exempel skriver ut trimvärdena för den första videoramen på den första bilden i millisekunder. Presentationen måste innehålla minst en bild. Om den bilden saknar videoram skrivs inget ut. Det föregående exemplet ger värdena 2500 och 1000.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **Hantera videoundertexter**

Aspose.Slides låter dig hantera stängda undertexter för videoramar i PowerPoint‑presentationer. Undertexter lagras i WebVTT‑format och exponeras via egenskapen [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

**Lägg till undertexter i en videoram**

Detta exempel bäddar in en lokal video och lägger till ett WebVTT‑undertextspår märkt English. Undertextens tidsstämplar bör matcha videon. Den sparade presentationen innehåller både videon och dess undertexter.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

[ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/)‑gränssnittet erbjuder också en överlagring som låter dig lägga till undertexter från en ström.

**Extrahera undertexter från en videoram**

Detta exempel sparar alla undertextspår från videoramar på den första bilden som separata WebVTT‑filer. Sekventiella nummer håller utdatafilerna separata. Konsolen rapporterar antalet extraherade spår. Presentationen måste innehålla minst en bild.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

Varje [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/)‑objekt exponerar undertextens identifierare, etikett, binär data och undertext som en UTF‑8‑sträng.

**Ta bort undertexter från en videoram**

Detta exempel tar bort alla undertexter från videoramen vid den första formens position på den första bilden och sparar resultatet. Det förutsätter att bilden och formen finns samt att formen är en videoram.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

Om du bara behöver ta bort ett undertextspår, använd metoderna [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) eller [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) istället för [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Extrahera video från en bild**

Förutom att lägga till videor i bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

Detta exempel extraherar inbäddade videor från varje bild till separata, numrerade binära filer. Länkade videor hoppas över eftersom de saknar inbäddad data. Konsolen skriver ut varje videos MIME‑typ och det totala antalet. Utdata använder den generiska filändelsen `.bin`; ändra den för att matcha den rapporterade mediatypen vid behov.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **FAQ**

**Vilka videouppspelningsparametrar kan ändras för en videoram?**

Du kan styra [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automatisk eller vid klick) och [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Dessa alternativ är tillgängliga via egenskaperna för objektet [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas binärdata i dokumentet, så presentationsstorleken växer proportionellt mot filens storlek. När du länkar till en online‑video och lägger till en miniatyrbild lagrar presentationen länken och förhandsbilden istället för videodata, så storleksökningen är vanligtvis mindre.

**Kan jag ersätta videon i en befintlig videoram utan att ändra dess position och storlek?**

Ja. Du kan byta ut [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) inom ramen samtidigt som du bevarar formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) som du kan läsa och använda, till exempel när du sparar den till disk.