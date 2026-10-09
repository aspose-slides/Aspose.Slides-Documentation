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
- webes forrás
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és nyerhet ki programozottan videókereteket PowerPoint és OpenDocument diákba az Aspose.Slides for .NET használatával. Gyors útmutató."
---
## **Bevezetés**

A videók segíthetnek az ötletek magyarázatában és a közönség bevonásában. Az Aspose.Slides for .NET lehetővé teszi videókeretek hozzáadását a diákhoz, a lejátszási beállítások módosítását, a feliratozás kezelését és a beágyazott videóadatok kinyerését.

A PowerPoint támogatja a helyi videókat és az online videókra mutató hivatkozásokat, például a YouTube videókat.

A videóadatok és videókeretek ábrázolásához az Aspose.Slides biztosítja az [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) interfészt, az [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) interfészt és más kapcsolódó típusokat.

## **Beágyazott videókeret létrehozása**

Ha a diára felvenni kívánt videófájl helyileg van tárolva, létrehozhat egy videókeretet a videó beágyazásához a prezentációba.

Ez a példa beágyaz egy helyi videót az első diára egy meglévő prezentációban, és elmenti az eredményt. A keret koordinátái és méretei pontban vannak megadva. A stream nyitva marad amíg a mentés befejeződik, mert a [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) zárolva tartja, amíg a prezentáció használja.

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

Átadhatja a helyi videó elérési útját közvetlenül a [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) metódusnak is. Ez a példa beágyazza a videót egy új prezentáció első diájára. A videónak a mentés befejezéséig elérhetőnek kell maradnia.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Videókeret létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) támogatja az online videókat a prezentációkban. Létrehozhat egy videókeretet, amely egy online videóra, például egy YouTube videóra mutat.

Ez a példa egy YouTube videó hivatkozását és miniatűrjét adja hozzá az első diához. Cserélje ki a videóazonosítót, ha másik videót szeretne használni. A [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) beállítás automatikus lejátszást kér. A miniatűr letöltése és a videó lejátszása internetkapcsolatot igényel. A prezentáció megjelenítőnek szintén támogatnia kell az online videó lejátszást.

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

## **Videó lejátszása teljes képernyő módban**

Egy képzési prezentációban lejátszhat egy szoftverbemutatót teljes képernyő módban, hogy a közönség lássa a részleteket. Állítsa a [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) értékét `true`‑ra a viselkedés engedélyezéséhez lejátszás közben.

Ez a példa megnyit egy prezentációt, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) elemet az első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen az első dián már létezik videókeret.

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

A teljes képernyős lejátszás szabályozza, hogyan jelenik meg a videó. Függetlenül a [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) szabályozza, automatikusan vagy kattintásra indul-e, a [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) pedig azt, hogy ismétlődik‑e. A kezdési viselkedés kiválasztásához állítsa a lejátszási módot a [VideoPlayModePreset.Auto vagy VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) értékre. A példa megőrzi a meglévő kezdési és ismétlési beállításokat.

## **Videó visszatekerése lejátszás után**

Egy képzési prezentációban a bemutató videójának visszatekerése a kezdetre lehetővé teszi, hogy az előadó újból lejátszhassa. Állítsa a [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) értékét `true`‑ra, hogy a videó a lejátszás befejezése után visszatérjen a kezdethez.

Ez a példa megnyit egy prezentációt, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) elemet az első dián, és engedélyezi a visszatekerést. Letiltja az ismétlést, hogy a lejátszás befejeződhessen, és a lejátszást kattintásra állítja. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen az első dián már létezik videókeret.

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

A visszatekerés a videót a kezdetére állítja anélkül, hogy újraindítaná. Ezzel szemben a [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) engedélyezése automatikusan ismétli a lejátszást. Tartsa letiltva a ciklust, ha azt szeretné, hogy a videó befejeződjön, és készen álljon az újbóli lejátszásra. A [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) önállóan vezérli az automatikus vagy kattintásra történő indítást; ez a példa a [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) értéket használja, így az előadó dönt a lejátszás kezdetéről. Állítsa be a lejátszási módot a ciklus beállítása után, ahogy a példában látható. A visszatekerés független a [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) beállítástól.

## **Videókeret vágása**

Használja a [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) és a [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) metódusokat a videó elejének vagy végének kihagyásához a lejátszás során. Mindkét érték ezredmásodpercben van megadva. A vágás a lejátszási beállításokat módosítja anélkül, hogy a beágyazott videóadatot megváltoztatná.

**Vágási beállítások beállítása**

Ez a példa beágyaz egy helyi videót, és a lejátszás során kihagyja az első 2,5 másodpercet és az utolsó másodpercet. Használjon egy 3,5 másodpercnél hosszabb videót, hogy lejátszható szegmens maradjon.

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

**Vágási beállítások olvasása**

Ez a példa kiírja az első videókeret vágási értékeit az első dián ezredmásodpercben. A prezentációnak legalább egy diát kell tartalmaznia. Ha az adott dián nincs videókeret, semmi sem kerül kiírásra. Az előző példa 2500 és 1000 értékeket eredményez.

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

Az Aspose.Slides lehetővé teszi a videókeretekhez tartozó zárt feliratok (closed captions) kezelését a PowerPoint prezentációkban. A feliratok WebVTT formátumban tárolódnak, és a [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) tulajdonságon keresztül érhetők el.

**Feliratok hozzáadása videókerethez**

Ez a példa beágyaz egy helyi videót, és hozzáad egy "English" címkéjű WebVTT feliratsp tracket. A felirat időbélyegeinek egyezniük kell a videóval. A mentett prezentáció a videót és a feliratokat is tartalmazza.

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

Az [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) interfész további túlterhelést is biztosít, amely lehetővé teszi feliratok hozzáadását streamből.

**Feliratok kinyerése videókeretből**

Ez a példa minden feliratsávot a videókeretekből az első dián különálló WebVTT fájlokként ment el. A sorozatszámok biztosítják, hogy a kimeneti fájlok megkülönböztethetők legyenek. A konzol kiírja a kinyert sávok számát. A prezentációnak legalább egy diát kell tartalmaznia.

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

Minden [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) objektum tartalmazza a felirat azonosítóját, címkéjét, bináris adatait és a felirat szövegét UTF‑8 karakterláncként.

**Feliratok eltávolítása videókeretből**

Ez a példa eltávolítja az összes feliratot az első dián az első alakzat pozíciójában található videókeretből, majd elmenti az eredményt. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat videókeret.

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

Ha csak egy feliratsávot szeretne eltávolítani, használja a [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) vagy a [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) metódusokat a [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/) helyett.

## **Videó kinyerése egy diáról**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését is.

Ez a példa minden diáról kinyeri a beágyazott videókat különálló, számozott bináris fájlokba. A hivatkozott videók kimaradnak, mivel nincs bennük beágyazott adat. A konzol kiírja minden videó MIME‑típusát és a teljes számot. A kimenet a generikus `.bin` kiterjesztést használja; szükség esetén módosítsa a jelentett média típusnak megfelelően.

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

**Milyen videólejátszási paraméterek módosíthatók egy videókeretnél?**  
A [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) vezérelhető. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájlméretet?**  
Igen. Ha helyi videót ágyaz be, a bináris adat a dokumentumba kerül, így a prezentáció mérete arányosan nő a fájlmérettel. Ha online videóra hivatkozik, és csak egy miniatűr képet ad hozzá, a prezentáció csak a hivatkozást és a előnézeti képet tárolja, ezért a méretnövekedés általában kisebb.

**Lecserélhetem a videót egy meglévő videókeretben anélkül, hogy megváltoztatnám a pozícióját és méretét?**  
Igen. A [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) cserélhető a kereten belül, miközben megmarad az alakzat geometriai beállítása; ez gyakori megoldás a médiatartalom frissítésére egy meglévő elrendezésben.

**Megállapítható egy beágyazott videó tartalomtípusa (MIME)?**  
Igen. Egy beágyazott videó rendelkezik [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) tulajdonsággal, amely kiolvasható és felhasználható például a lemezre mentéskor.