---
title: Videókeretek kezelése prezentációkban .NET-ben
linktitle: Videókeret
type: docs
weight: 10
url: /hu/net/video-frame/
keywords:
- videó hozzáadása
- videó létrehozása
- videó beágyazása
- videó kinyerése
- videó lekérése
- videókeret
- web forrás
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tanulja meg, hogyan adhat hozzá és nyerhet ki programozottan videókereteket PowerPoint és OpenDocument diákban az Aspose.Slides for .NET használatával. Gyors útmutató."
---
## **Bevezetés**

A videók segíthetnek az ötletek magyarázatában és a közönség bevonásában. Az Aspose.Slides for .NET lehetővé teszi, hogy videókereteket adjunk a diákhoz, beállítsuk a lejátszási opciókat, kezeljük a feliratokat, és kinyerjük a beágyazott videóadatokat.

A PowerPoint helyi videókat és online videókra mutató hivatkozásokat (például YouTube‑videók) is támogat.

A videóadatok és videókeretek ábrázolásához az Aspose.Slides biztosítja az [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) interfészt, az [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) interfészt és egyéb kapcsolódó típusokat.

## **Beágyazott videókeret létrehozása**

Ha a diára felvenni kívánt videófájl helyileg van tárolva, létrehozhat egy videókeretet a videó beágyazásához a prezentációba.

Ez a példa egy helyi videót ágyaz be az első diára egy meglévő prezentációban, és elmenti az eredményt. A keret koordinátái és méretei pontokban vannak megadva. A folyam (stream) nyitva marad a mentés befejezéséig, mert a [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) zárolva tartja, amíg a prezentáció használja.

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

Átadhatja a helyi videó elérési útját közvetlenül az [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/)-nek is. Ez a példa a videót az első diára ágyazza be egy új prezentációban. A videónak elérhetőnek kell maradnia a prezentáció mentéséig.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **A videó hangerő pontos beállítása**

Az Aspose.Slides for .NET 26.11‑től kezdődően a [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) egy 0‑tól 100‑ig terjedő lebegőpontos százalékot állít be. Használja, ha a [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) előre beállított értékei túl durvák. Például a `75.5f` 75,5 % hangerőt kér.

Ez a példa az [Aspose.Slides for .NET](/slides/hu/net/installation/) 26.11‑es vagy újabb verzióját és egy helyi `video.mp4`‑t igényel. A videót beágyazza, kifejezetten inicializálja a lejátszást, elmenti a prezentációt, és visszaolvassa a tárolt százalékot.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

Ellenőrizze a bemenetet saját maga; ne bízzon abban, hogy a setter elutasítja a dokumentált tartományon kívüli értékeket. Az Alacsony, Közepes és Hangos előre beállítások 26.11‑ben 20, 50 és 80 értéknek felelnek meg. Egy előre beállított érték beállítása felülírhat egy korábban megadott százalékot, ezért a pontos érték esetén a százalékot állítsa be utoljára. Használja az [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) beállítást a kifejezett némításra; a numerikus nulla és az előre beállított enum nem cserélhető ki egymással.

A [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) beállítást explicit módon is állítsa be összekapcsolt videó konfigurálásakor, és tartsa a médiafájlt a néző számára elérhetően. A mentés és újranyitás ellenőrzi a tárolt beállítást; a tényleges lejátszás és hangerő a prezentációs lejátszó és annak audio beállításain múlik.

## **Videókeret létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) online videókat is támogat a prezentációkban. Létrehozhat egy videókeretet, amely egy online videóra (például YouTube‑videóra) mutat.

Ez a példa egy YouTube‑videó hivatkozást és miniatűr képet ad az első diához. Cserélje ki a videóazonosítót, ha másik videót szeretne használni. A [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) beállítás automatikus lejátszást kér. A miniatűr letöltése és a videó lejátszása internetkapcsolatot igényel. A prezentációs nézőnek támogatnia kell az online videó lejátszását is.

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

## **Videó lejátszása teljes képernyős módban**

Képzési prezentációban egy szoftverbemutató lejátszható teljes képernyős módban, hogy a közönség lássa a részleteket. Állítsa a [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/)‑t `true`‑ra a lejátszás során.

Ez a példa megnyit egy prezentációt, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)‑t az első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen már létezik videókeret az első dián.

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

A teljes képernyős lejátszás szabályozza, hogyan jelenik meg a videó. Ezzel párhuzamosan a [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) határozza meg, hogy automatikusan vagy kattintásra induljon, a [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) pedig a ismétlést. A kezdési viselkedés kiválasztásához állítsa a lejátszási módot a [VideoPlayModePreset.Auto vagy VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/)-ra. A példa megőrzi a meglévő kezdési és ismétlési beállításokat.

## **Videó visszatekerése a lejátszás után**

Képzési prezentációban a bemutató videó visszatekerése a kezdeti állapotba lehetővé teszi a bemondó számára, hogy újból elindítsa. Állítsa a [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/)‑t `true`‑ra, hogy a lejátszás befejezése után a videó a kezdetre térjen.

Ez a példa megnyit egy prezentációt, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)‑t az első dián, és engedélyezi a visszatekerést. Kikapcsolja a ciklusismétlést, hogy a lejátszás befejeződhessen, és a lejátszást kattintásra állítja. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen már létezik videókeret az első dián.

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

A visszatekerés a videót a kezdeti állapotba hozza anélkül, hogy újraindítaná. Ezzel szemben a [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) engedélyezése automatikusan ismétli a lejátszást. Tartsa letiltva a ciklust, ha azt szeretné, hogy a videó befejeződjön, és készen álljon az újra lejátszásra. A [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) függetlenül szabályozza az automatikus vagy kattintásos indítást; ez a példa a [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/)‑t használja, így a bemondó kontrollálja a lejátszás indítását. Állítsa be a lejátszási módot a ciklus beállítása után, ahogy a példában látható. A visszatekerés független a [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/)-tól.

## **Videókeret vágása**

Használja az [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) és az [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) metódusokat, hogy a lejátszás során kihagyja a videó elejének vagy végének egy részét. Mindkét érték ezredmásodpercben van megadva. A vágás módosítja a lejátszási beállításokat anélkül, hogy a beágyazott videóadatokat változtatná.

**Vágási beállítások megadása**

Ez a példa egy helyi videót ágyaz be, és a lejátszás során kihagyja az első 2,5 másodpercet illetve az utolsó másodpercet. Használjon legalább 3,5 másodperc hosszú videót, hogy legyen lejátszható szegmens.

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

**Vágási beállítások kiolvasása**

Ez a példa kiírja az első videókeret vágási értékeit az első dián ezredmásodpercben. A prezentációnak legalább egy diát kell tartalmaznia. Ha az adott dián nincs videókeret, semmi sem kerül kiírásra. Az előző példa 2500 és 1000 értékeket ad.

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

## **Videó feliratok kezelése**

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint‑prezentációk videókereteihez zárt feliratokat kezeljünk. A feliratok WebVTT formátumban tárolódnak, és a [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) tulajdonságon keresztül érhetők el.

### **Feliratok hozzáadása egy video kerethez**

Ez a példa egy helyi videót ágyaz be, és egy „English” címkéjű WebVTT feliratsp track‑et ad hozzá. A felirat időbélyegeinek meg kell egyezniük a videóval. A mentett prezentáció tartalmazni fogja mind a videót, mind a feliratokat.

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

Az [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) interfész egy olyan túlterhelést is nyújt, amely lehetővé teszi a feliratok áramlásból (stream) történő hozzáadását.

### **Feliratok kinyerése egy video keretből**

Ez a példa az első dián található videókeretek összes feliratsp track‑jét különálló WebVTT fájlokként menti. A sorozatszámok biztosítják, hogy a kimeneti fájlok megkülönböztethetők legyenek. A konzol kiírja a kinyert track‑ek számát. A prezentációnak legalább egy diát kell tartalmaznia.

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

Minden [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) objektum elérhetővé teszi a felirat azonosítóját, címkéjét, bináris adatait és a felirat szövegét UTF‑8 karakterláncként.

### **Feliratok eltávolítása egy video keretből**

Ez a példa eltávolítja az összes feliratot az első dián lévő első alakzat pozíciójában található videókeretből, majd elmenti az eredményt. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat videókeret.

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

Ha csak egy feliratsp track‑et szeretne eltávolítani, használja a [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) vagy a [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) metódust a [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/) helyett.

### **Videó feliratok keresése**

Az [ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) visszaadja a teljes WebVTT track‑et, beleértve a fejlécet, az időzítési sorokat és a felirat szövegét. Egy kimondott kifejezés és annak időbélyegének megtalálásához olvassa be a cue‑kat a memóriában. Például egy angol track a 2. dián a következő szöveget tartalmazhatja:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

A példa minden diát bejár, és a felső szintű videókeretek track‑eit a [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) segítségével olvassa. Egy sima‑szöveges cue‑ban az időzítési sor `-->`‑t tartalmaz, és egy üres sor zárja a cue‑t. Ha a felirat szövegében a „café” szó szerepel, a példa kiírja a dia számát, a track címkét, az eredeti időzítési sort és a teljes feliratot.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

A „café” keresése egy egyezést ad a mintatrack‑hez. A fejléc és az időzítési beállítás a cue szövege kívül van.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Videó kinyerése egy diából**

A videók diákhoz adása mellett az Aspose.Slides lehetővé teszi a prezentációkban beágyazott videók kinyerését is.

Ez a példa minden diáról kinyeri a beágyazott videókat, és külön‑számozott bináris fájlokba menti őket. A hivatkozott videók kimaradnak, mivel nincs beágyazott adatuk. A konzol kiírja minden videó MIME‑típusát és a teljes számot. A kimenet általános `.bin` kiterjesztést használ; ha szükséges, cserélje le a jelentett média‑típusnak megfelelő kiterjesztésre.

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

## **GYIK**

**Melyik videólejátszási paraméter módosítható egy videókeretben?**

A [lejátszási mód](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automatikus vagy kattintásra) és a [ciklus](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) szabályozható. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájl méretét?**

Igen. Amikor egy helyi videót ágyaz be, a bináris adat a dokumentumba kerül, így a prezentáció mérete arányosan nő a videó méretével. Amikor egy online videóra hivatkozik, és egy miniatűr képet ad hozzá, a prezentáció csak a hivatkozást és a preview képet tárolja a videó adat helyett, ezért a méretnövekedés általában kisebb.

**Lecserélhetem a videót egy meglévő videókeretben anélkül, hogy megváltoztatnám a pozíciót és méretet?**

Igen. A [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) cseréjével a keret geometriáját megőrizheti; ez gyakori művelet a meglévő elrendezésben lévő média frissítéséhez.

**Megállapítható-e egy beágyazott videó tartalom típusa (MIME)?**

Igen. Egy beágyazott videó rendelkezik [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) tulajdonsággal, amely kiolvasható és felhasználható, például a lemezre mentéskor.