---
title: .NET-ben videókeretek kezelése prezentációkban
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
description: "Tanulja meg programozottan videókeretek hozzáadását és kinyerését PowerPoint és OpenDocument diákban az Aspose.Slides for .NET használatával. Gyors útmutató."
---
## **Bevezetés**

A videók segíthetnek megmagyarázni az ötleteket és lekötni a közönséget. Az Aspose.Slides for .NET lehetővé teszi videókeretek hozzáadását a diákhoz, a lejátszási beállítások módosítását, feliratok kezelését és a beágyazott videóadatok kinyerését.

A PowerPoint támogatja a helyi videókat és az online videókra mutató hivatkozásokat, például a YouTube videókat.

A videóadatok és videókeretek reprezentálásához az Aspose.Slides a [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) interfészt, a [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) interfészt és további releváns típusokat biztosít.

## **Beágyazott videókeret létrehozása**

Ha a diához hozzáadni kívánt videófájl helyileg van tárolva, létrehozhat egy videókeretet a videó bemutatóba történő beágyazásához.

Ez a példa egy helyi videót ágyaz be egy meglévő bemutató első diájára, és elmenti az eredményt. A keret koordinátái és méretei pontban vannak megadva. A stream nyitva marad, amíg a mentés be nem fejeződik, mivel a [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) zárolva tartja, amíg a bemutató használja.

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

A helyi videó útvonalát közvetlenül is átadhatja az [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) metódusnak. Ez a példa a videót egy új bemutató első diájára ágyazza be. A videónak elérhetőnek kell maradnia, amíg a bemutató el nem mentésre kerül.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **A videóhangerő pontos beállítása**

Az Aspose.Slides for .NET 26.11 vagy újabb verziójában a [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) egy 0‑tól 100‑ig terjedő lebegőpontos százalékot állít be. Akkor használja, ha a [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) előre beállított értékek túl durvák. Például a `75.5f` 75,5 % hangerőt kér.

Ez a példa a [Aspose.Slides for .NET](/slides/hu/net/installation/) 26.11 vagy újabb verzióját és egy helyi `video.mp4` fájlt igényel. A videót beágyazza, kifejezetten inicializálja a lejátszást, elmenti a bemutatót, és visszaolvassa a tárolt százalékértéket.

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

Ellenőrizze a bemenetet saját maga; ne bízza a beállítót, hogy elutasítsa a dokumentált tartományon kívüli értékeket. Az Alacsony, Közepes és Hangos előre beállított értékek a 26.11‑ben 20‑nak, 50‑nek és 80‑nak felelnek meg. Egy előre beállított érték beállítása felülírhat egy korábbi százalékot, ezért ha pontos értékre van szükség, adja meg a százalékot utoljára. Az [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) használatával explicit némítást állíthat be; a numerikus nulla és az előre beállított enum nem felcserélhető állapotok.

Explicit módon állítsa be a [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) értéket, amikor egy csatolt videót konfigurál, és tartsa a médiafájlt elérhetően a néző számára. A mentés és újranyitás ellenőrzi a tárolt beállítást; a tényleges lejátszás és hangerő a bemutatólejátszó és annak hangbeállításaitól függ.

## **Videókeret létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) támogatja az online videókat a prezentációkban. Létrehozhat egy videókeretet, amely egy online videóra, például egy YouTube‑videóra hivatkozik.

Ez a példa egy YouTube videóhivatkozást és bélyegképet ad az első diához. Cserélje ki a videó azonosítót egy másik videó használatához. A [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) beállítás automatikus lejátszást kér. A bélyegkép letöltése és a videó lejátszása internetkapcsolatot igényel. A prezentáció megjelenítőnek szintén támogatnia kell az online videó lejátszását.

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

Egy oktató prezentációban a szoftverbemutatót teljes képernyő módban játszhatja le, így a közönség láthatja a részleteket. Állítsa a [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) értékét `true`‑ra, hogy ez a viselkedés a lejátszás során engedélyezve legyen.

Ez a példa megnyit egy prezentációt, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)‑et az első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen az első dián már létezik videókeret.

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

A teljes képernyős lejátszás szabályozza, hogyan jelenik meg a videó. Függetlenül ettől a [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) szabályozza, automatikusan vagy kattintásra indul-e, a [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) pedig azt, hogy ismétlődik‑e. A kezdési viselkedés kiválasztásához állítsa a lejátszási módot a [VideoPlayModePreset.Auto vagy VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) értékre. A példa megtartja a meglévő kezdési és ismétlődési beállításokat.

## **Videó visszatekerése lejátszás után**

Egy oktató prezentációban a bemutatóvideó elejére való visszahozása azt teszi lehetővé, hogy az előadó újra lejátszhassa. Állítsa a [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) értékét `true`‑ra, hogy a lejátszás befejezése után a videó a kezdőpontra térjen.

Ez a példa megnyit egy prezentációt, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)‑et az első dián, és engedélyezi a visszatekerést. Kikapcsolja az ismétlést, hogy a lejátszás befejeződhessen, és beállítja a lejátszást kattintásra indítandó módra. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen az első dián már létezik videókeret.

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

A visszatekerés a videót a kezdetére viszi anélkül, hogy újra elindulna. Ezzel szemben a [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) engedélyezése automatikusan ismétli a lejátszást. Tartsa az ismétlést letiltva, ha azt szeretné, hogy a videó befejeződjön, és készen álljon az újra lejátszásra. A [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) önállóan szabályozza az automatikus vagy kattintásra indítandó indítást; ez a példa a [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) értéket használja, így az előadó irányítja a lejátszás indítását. A lejátszási módot állítsa be az ismétlési beállítás után, ahogy a példában látható. A visszatekerés független a [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) beállítástól.

## **Videókeret vágása**

Használja az [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) és az [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) metódusokat, hogy a lejátszás során kihagyja a videó elejének vagy végének egy részét. Mindkét érték ezredmásodpercben van. A vágás a lejátszási beállításokat módosítja anélkül, hogy a beágyazott videó adatot változtatná.

**Vágási beállítások megadása**

Ez a példa egy helyi videót ágyaz be, és a lejátszás során kihagyja az első 2,5 másodpercet és az utolsó másodpercet. Használjon 3,5 másodpercnél hosszabb videót, hogy maradjon lejátszható rész.

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

Ez a példa kiírja az első videókeret vágási értékeit az első dián ezredmásodpercben. A prezentációnak legalább egy diát kell tartalmaznia. Ha azon a dián nincs videókeret, semmi sem kerül kiírásra. Az előző példa 2500 és 1000 értékeket állít elő.

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

## **Videófeliratok kezelése**

Az Aspose.Slides lehetővé teszi a lezárt feliratok kezelését a PowerPoint prezentációk videókereteihez. A feliratok WebVTT formátumban tárolódnak, és a [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) tulajdonságon keresztül érhetők el.

**Feliratok hozzáadása videókerethez**

Ez a példa egy helyi videót ágyaz be, és egy 'English' címkéjű WebVTT feliratsávot ad hozzá. A felirat időbélyegeinek meg kell egyezniük a videóval. A mentett prezentáció tartalmazza mind a videót, mind a feliratokat.

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

Az [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) interfész további túlterhelést is biztosít, amely lehetővé teszi feliratok hozzáadását egy stream‑ből.

**Feliratok kinyerése videókeretből**

Ez a példa az első dián lévő videókeretek összes feliratsávját külön WebVTT fájlokba menti. A sorban következő számok biztosítják, hogy a kimeneti fájlok különállóak legyenek. A konzol jelzi a kinyert sávok számát. A prezentációnak legalább egy diát kell tartalmaznia.

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

Minden [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) objektum a felirat azonosítóját, címkéjét, bináris adatát és a felirat szövegét UTF‑8 karakterláncként teszi elérhetővé.

**Feliratok eltávolítása videókeretből**

Ez a példa az első dián az első alakzat pozíciójában lévő videókeretről eltávolít minden feliratot, majd elmenti az eredményt. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat videókeret.

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

Ha csak egy feliratsávot kell eltávolítani, használja a [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) vagy a [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) metódusokat a [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/) helyett.

## **Videó kinyerése diából**

A videók diákhoz adása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését.

Ez a példa a beágyazott videókat minden diáról külön, számozott bináris fájlokba nyeri ki. A csatolt videók kihagyásra kerülnek, mivel nem tartalmaznak beágyazott adatot. A konzol minden videó MIME‑típusát és az összes darabszámát kiírja. A kimenet a generikus `.bin` kiterjesztést használja; szükség esetén változtassa meg a jelentett média típusnak megfelelően.

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

**Mely videólejátszási paraméterek módosíthatók egy videókeret esetén?**

A [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) szabályozható. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájl méretét?**

Igen. Ha helyi videót ágyaz be, a bináris adatok a dokumentumba kerülnek, ezért a prezentáció mérete arányosan nő a fájl méretével. Ha online videóra hivatkozik és bélyegképet ad hozzá, a prezentáció a hivatkozást és az előnézeti képet tárolja a videóadatok helyett, így a méretnövekedés általában kisebb.

**Lecserélhetem a videót egy meglévő videókeretben anélkül, hogy megváltoztatnám a pozíciót és a méretet?**

Igen. A [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) cserélhető a kereten belül, miközben megőrzöd az alakzat geometriáját; ez gyakori eset a média frissítésére egy meglévő elrendezésben.

**Megállapítható a beágyazott videó tartalomtípusa (MIME)?**

Igen. A beágyazott videónak van egy [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) , amelyet kiolvashat és felhasználhat, például mentéskor a lemezre.