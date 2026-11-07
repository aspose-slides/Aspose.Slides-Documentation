---
title: Správa video rámců v prezentacích v .NET
linktitle: Video rámec
type: docs
weight: 10
url: /cs/net/video-frame/
keywords:
- přidat video
- vytvořit video
- vložit video
- extrahovat video
- získat video
- video rámec
- webový zdroj
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video rámce v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro .NET. Rychlý návod krok za krokem."
---
## **Úvod**

Videa mohou pomoci vysvětlit myšlenky a zapojit publikum. Aspose.Slides pro .NET vám umožňuje přidávat video rámečky do snímků, upravovat nastavení přehrávání, spravovat popisky a získávat vložená video data.

PowerPoint podporuje lokální videa i odkazy na online videa, například videa z YouTube.

Pro reprezentaci video dat a video rámců poskytuje Aspose.Slides rozhraní [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) , rozhraní [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) a další související typy.

## **Vytvoření vloženého video rámce**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit video rámec pro vložení videa do vaší prezentace.

Tento příklad vloží lokální video na první snímek existující prezentace a výsledek uloží. Souřadnice a rozměry rámce jsou v bodech. Stream zůstává otevřený až do dokončení uložení, protože [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) jej zamyká, dokud jej prezentace používá.

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

Můžete také předat cestu k lokálnímu videu přímo metodě [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Tento příklad vloží video na první snímek nové prezentace. Video musí zůstat přístupné, dokud není prezentace uložena.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Přesné nastavení hlasitosti videa**

V Aspose.Slides pro .NET 26.11 nebo novějším se pomocí [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) nastavuje desetinné procento od 0 do 100. Použijte jej, když jsou předvolby [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) příliš hrubé. Například `75.5f` požaduje hlasitost 75,5 %.

Tento příklad vyžaduje [Aspose.Slides pro .NET](/slides/cs/net/installation/) 26.11 nebo novější a lokální soubor `video.mp4`. Vloží video, explicitně inicializuje přehrávání, uloží prezentaci a načte zpět uložené procento.

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

Ověřte vstupy sami; nespoléhejte se na nastavení, aby odmítlo hodnoty mimo dokumentovaný rozsah. Předvolby Low, Medium a Loud odpovídají hodnotám 20, 50 a 80 ve verzi 26.11. Nastavení předvolby může nahradit předchozí procento, proto při potřebě přesné hodnoty přiřaďte procento jako poslední. Pro explicitní ztlumení použijte [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/); číselná nula a předvolba výčtu nejsou zaměnitelné stavy.

Explicitně nastavte [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) i při konfiguraci propojeného videa a udržujte jeho mediální soubor dostupný pro diváka. Uložení a opětovné otevření ověří uložené nastavení; skutečné přehrávání a hlasitost závisí na přehrávači prezentace a jeho nastavení zvuku.

## **Vytvoření video rámce s videem z webového zdroje**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) podporuje online videa v prezentacích. Můžete vytvořit video rámec, který odkazuje na online video, například video z YouTube.

Tento příklad přidá odkaz na YouTube video a náhled na první snímek. Nahraďte identifikátor videa, chcete-li použít jiné video. Nastavení [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) požaduje automatické přehrávání. Stahování náhledu a přehrávání videa vyžaduje přístup k internetu. Prohlížeč prezentace musí také podporovat přehrávání online videí.

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

## **Přehrát video v režimu celé obrazovky**

V tréninkové prezentaci můžete přehrát ukázku softwaru v režimu celé obrazovky, aby publikum vidělo detaily. Nastavte [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) na `true`, aby se během přehrávání toto chování aktivovalo.

Tento příklad otevře prezentaci, najde první [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) na první snímek a povolí přehrávání na celou obrazovku. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video rámcem na první straně.

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

Přehrávání na celou obrazovku určuje, jak je video zobrazeno. Nezávisle na tom [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) řídí, zda se spustí automaticky nebo po kliknutí, a [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) určuje, zda se opakuje. Pro výběr chování spuštění nastavte režim přehrávání na [VideoPlayModePreset.Auto nebo VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Příklad zachovává stávající nastavení spuštění a opakování.

## **Přetočit video po přehrání**

V tréninkové prezentaci vrácení demonstračního videa na začátek připraví video k dalšímu přehrání. Nastavte [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) na `true`, aby se video po ukončení přehrávání vrátilo na začátek.

Tento příklad otevře prezentaci, najde první [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) na první snímek a povolí přetáčení. Vypne opakování, aby přehrávání mohlo skončit, a nastaví spuštění po kliknutí. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video rámcem na první straně.

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

Přetáčení vrací video na jeho začátek, aniž by jej znovu spustilo. Naopak povolení [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) způsobí automatické opakování přehrávání. Ponechte opakování vypnuté, když chcete, aby video skončilo a zůstalo připravené k přehrání. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) nezávisle řídí automatické nebo klikací spuštění; tento příklad používá [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/), takže prezentující kontroluje, kdy se přehrávání spustí. Nastavte režim přehrávání po nastavení opakování, jak je ukázáno v příkladu. Přetáčení funguje nezávisle na [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Oříznutí video rámce**

Použijte [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) a [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) k přeskočení části začátku nebo konce videa během přehrávání. Obě hodnoty jsou v milisekundách. Oříznutí mění nastavení přehrávání, aniž by měnilo vložená video data.

**Nastavení oříznutí**

Tento příklad vloží lokální video a během přehrávání přeskočí první 2,5 sekundy a poslední sekundu. Použijte video delší než 3,5 sekundy, aby zůstala přehratelná část.

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

**Čtení nastavení oříznutí**

Tento příklad vytiskne hodnoty oříznutí prvního video rámce na první snímek v milisekundách. Prezentace musí obsahovat alespoň jeden snímek. Pokud tento snímek neobsahuje video rámec, nic se netiskne. Předchozí příklad produkuje hodnoty 2500 a 1000.

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

## **Správa titulků videí**

Aspose.Slides umožňuje spravovat uzavřené titulky pro video rámečky v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou vystaveny přes vlastnost [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

**Přidání titulků do video rámce**

Tento příklad vloží lokální video a přidá stopu WebVTT titulků označenou English. Časové značky titulků by měly odpovídat videu. Uložená prezentace obsahuje jak video, tak jeho titulky.

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

Rozhraní [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) také poskytuje přetížení, které umožňuje přidat titulky ze streamu.

**Extrahování titulků z video rámce**

Tento příklad uloží všechny titulkové stopy z video rámců na první snímek jako samostatné soubory WebVTT. Sekvenční čísla udržují výstupní soubory odlišné. Konzole vypíše počet extrahovaných stop. Prezentace musí obsahovat alespoň jeden snímek.

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

Každý objekt [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) vystavuje identifikátor titulku, popisek, binární data i text titulku jako řetězec UTF‑8.

**Odstranění titulků z video rámce**

Tento příklad odstraní všechny titulky z video rámce na první pozici tvaru na první snímek a výsledek uloží. Předpokládá, že snímek a tvar existují a že tvar je video rámec.

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

Pokud potřebujete odstranit jen jednu titulkovou stopu, použijte metody [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) nebo [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) místo [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Extrahování videa ze snímku**

Kromě přidávání videí do snímků umožňuje Aspose.Slides také extrahovat videa vložená v prezentacích.

Tento příklad extrahuje vložená videa ze všech snímků do samostatných, číslovaných binárních souborů. Propojená videa jsou přeskočena, protože neobsahují vložená data. Konzole vypíše MIME typ každého videa a celkový počet. Výstup používá obecnou příponu `.bin`; změňte ji podle hlášeného typu média, je‑li to potřeba.

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

## **Časté otázky**

**Které parametry přehrávání videa lze u video rámce změnit?**

Můžete kontrolovat [režim přehrávání](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (auto nebo po kliknutí) a [opakování](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Tyto možnosti jsou k dispozici přes vlastnosti objektu [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Zvyšuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte lokální video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když odkazujete na online video a přidáte náhled, prezentace uloží jen odkaz a obraz náhledu místo video dat, takže nárůst velikosti je obvykle menší.

**Mohu nahradit video v existujícím video rámci, aniž bych změnil jeho pozici a velikost?**

Ano. Můžete vyměnit [video obsah](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) v rámci při zachování geometrie tvaru; to je běžný scénář pro aktualizaci médií v existujícím rozvržení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/), který můžete přečíst a použít, například při ukládání na disk.