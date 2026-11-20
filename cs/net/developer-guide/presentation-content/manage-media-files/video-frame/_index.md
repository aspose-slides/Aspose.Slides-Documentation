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
description: "Naučte se programově přidávat a extrahovat video rámce v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro .NET. Rychlý průvodce."
---
## **Úvod**

Videa mohou pomoci vysvětlit nápady a zapojit publikum. Aspose.Slides pro .NET vám umožňuje přidávat video rámečky do snímků, upravovat nastavení přehrávání, spravovat titulky a extrahovat vložená video data.

PowerPoint podporuje lokální videa i odkazy na online videa, například videa na YouTube.

Pro reprezentaci video dat a video rámců Aspose.Slides poskytuje rozhraní [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) , rozhraní [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) a další související typy.

## **Vytvořit vložený video rámec**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit video rámec pro vložení videa do vaší prezentace.

Tento příklad vloží lokální video na první snímek existující prezentace a uloží výsledek. Souřadnice a rozměry rámce jsou v bodech. Proud zůstává otevřený až do dokončení ukládání, protože [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) jej udrží zamčený, dokud jej prezentace používá.

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

Můžete také předat lokální cestu k videu přímo metodě [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Tento příklad vloží video na první snímek nové prezentace. Video musí zůstat přístupné až do uložení prezentace.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Nastavit hlasitost videa přesně**

V Aspose.Slides pro .NET 26.11 nebo novějším nastavuje [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) desetinné procento v rozmezí 0 až 100. Použijte jej, pokud jsou předvolby [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) příliš hrubé. Například `75.5f` požaduje hlasitost 75,5%.

Tento příklad vyžaduje [Aspose.Slides for .NET](/slides/cs/net/installation/) 26.11 nebo novější a lokální `video.mp4`. Vloží video, explicitně inicializuje přehrávání, uloží prezentaci a načte zpět uložené procento.

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

Ověřte vstup sami; nespoléhejte na setter, který odmítne hodnoty mimo dokumentovaný rozsah. Předvolby Low, Medium a Loud odpovídají hodnotám 20, 50 a 80 ve verzi 26.11. Nastavení předvolby může nahradit dříve nastavené procento, takže při potřebě přesné hodnoty přiřaďte procento jako poslední. Použijte [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) pro explicitní ztlumení; číselná nula a předvolený výčet nejsou zaměnitelné stavy.

Explicitně nastavte [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) i při konfiguraci propojeného videa a udržujte jeho mediální soubor dostupný pro diváka. Uložení a opětovné otevření ověří uložené nastavení; skutečné přehrávání a hlasitost závisí na přehrávači prezentace a jeho audio nastaveních.

## **Vytvořit video rámec s videem z webového zdroje**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) podporuje online videa v prezentacích. Můžete vytvořit video rámec, který odkazuje na online video, například na YouTube video.

Tento příklad přidá odkaz na YouTube video a miniaturu na první snímek. Vyměňte identifikátor videa pro použití jiného videa. Nastavení [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) požaduje automatické přehrávání. Stažení miniatury a přehrání videa vyžadují přístup k internetu. Prohlížeč prezentací musí také podporovat přehrávání online videí.

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

V tréninkové prezentaci můžete přehrát ukázku softwaru v režimu celé obrazovky, aby publikum vidělo detaily. Nastavte [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) na `true`, čímž povolíte toto chování během přehrávání.

Tento příklad otevře prezentaci, najde první [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) na prvním snímku a povolí přehrávání na celé obrazovce. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video rámcem na prvním snímku.

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

Přehrávání na celé obrazovce určuje, jak je video zobrazováno. Samostatně [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) řídí, zda se spustí automaticky nebo po kliknutí, a [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) určuje, zda se opakuje. Pro výběr chování spouštění nastavte režim přehrávání na [VideoPlayModePreset.Auto nebo VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Příklad zachovává stávající nastavení spouštění a smyčky.

## **Přetočit video po přehrání**

V tréninkové prezentaci vrácení demonstračního videa na začátek připraví video k opětovnému přehrání prezentátorem. Nastavte [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) na `true`, aby se video po dokončení přehrávání vrátilo na začátek.

Tento příklad otevře prezentaci, najde první [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) na prvním snímku a povolí převíjení. Vypne smyčku, aby přehrávání mohlo skončit, a nastaví spouštění přehrávání na kliknutí. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video rámcem na prvním snímku.

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

Převíjení vrací video na začátek, aniž by ho znovu spustilo. Naopak povolení [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) opakuje přehrávání automaticky. Udržujte smyčku vypnutou, když chcete, aby video skončilo a bylo připraveno k opětovnému přehrání. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) samostatně řídí automatické nebo klikací spuštění; tento příklad používá [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) , takže prezentátor řídí, kdy se přehrávání spustí. Nastavte režim přehrávání po nastavení smyčky, jak je ukázáno v příkladu. Převíjení funguje nezávisle na [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Oříznout video rámec**

Použijte [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) a [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) , abyste během přehrávání přeskočili část začátku nebo konce videa. Obě hodnoty jsou v milisekundách. Oříznutí mění nastavení přehrávání, aniž by modifikovalo vložená video data.

**Nastavit nastavení oříznutí**

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

**Přečíst nastavení oříznutí**

Tento příklad vypíše hodnoty oříznutí prvního video rámce na prvním snímku v milisekundách. Prezentace musí obsahovat alespoň jeden snímek. Pokud tento snímek nemá video rámec, nevypíše se nic. Předchozí příklad produkuje hodnoty 2500 a 1000.

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

## **Spravovat titulky videa**

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro video rámečky v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou přístupné přes vlastnost [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

### **Přidat titulky do video rámce**

Tento příklad vloží lokální video a přidá WebVTT titulkovou stopu označenou English. Časové razítka titulků by měla odpovídat videu. Uložená prezentace obsahuje jak video, tak jeho titulky.

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

### **Extrahovat titulky z video rámce**

Tento příklad uloží všechny titulkové stopy z video rámců na prvním snímku jako samostatné soubory WebVTT. Pořadová čísla udrží výstupní soubory odlišné. Konzole vypíše počet extrahovaných stop. Prezentace musí obsahovat alespoň jeden snímek.

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

Každý objekt [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) zpřístupňuje identifikátor titulku, štítek, binární data a text titulku jako řetězec UTF-8.

### **Odstranit titulky z video rámce**

Tento příklad odstraní všechny titulky z video rámce na první pozici tvaru na prvním snímku a uloží výsledek. Předpokládá, že snímek a tvar existují a že tvar je video rámec.

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

Pokud potřebujete odstranit pouze jednu titulkovou stopu, použijte metody [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) nebo [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) místo [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

### **Vyhledat titulky videa**

[ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) vrací kompletní WebVTT stopu, včetně hlavičky, časových řádků a textu titulku. Pro nalezení mluvené fráze a jejího časového razítka přečtěte nápovědy v paměti. Například anglická stopa na snímku 2 může obsahovat následující text:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Příklad navštíví každý snímek a čte stopy jeho vrcholových video rámců pomocí [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/). V prostém textovém cue obsahuje časová řádka `-->` a prázdný řádek ukončuje cue. Když text titulku obsahuje „café“, příklad vypíše číslo snímku, štítek stopy, původní časovou řádku a celý titulek.

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

Vyhledávání „café“ vytvoří jeden výsledek pro ukázkovou stopu. Hlavička a nastavení času jsou mimo text cue.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extrahovat video ze snímku**

Kromě přidávání videí do snímků umožňuje Aspose.Slides extrahovat videa vložená v prezentacích.

Tento příklad extrahuje vložená videa ze všech snímků do samostatných, číslovaných binárních souborů. Propojená videa jsou přeskočena, protože neobsahují vložená data. Konzole vypíše MIME typ každého videa a celkový počet. Výstup používá obecnou příponu `.bin`; v případě potřeby ji změňte tak, aby odpovídala nahlášenému typu média.

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

## **Často kladené otázky**

**Které parametry přehrávání videa lze změnit pro video rámec?**

Můžete řídit [režim přehrávání](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automaticky nebo na kliknutí) a [opakování](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Tyto možnosti jsou dostupné přes vlastnosti objektu [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) .

**Ovlivňuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte lokální video, binární data jsou zahrnuta do dokumentu, takže se velikost prezentace zvětší úměrně velikosti souboru. Když se odkážete na online video a přidáte miniaturu, prezentace uloží odkaz a náhledový obrázek místo video dat, takže nárůst velikosti je obvykle menší.

**Mohu nahradit video v existujícím video rámci, aniž bych změnil jeho pozici a velikost?**

Ano. Můžete vyměnit [video obsah](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) v rámci při zachování geometrie tvaru; to je běžný scénář pro aktualizaci médií v existujícím rozvržení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) , který můžete přečíst a použít, například při ukládání na disk.