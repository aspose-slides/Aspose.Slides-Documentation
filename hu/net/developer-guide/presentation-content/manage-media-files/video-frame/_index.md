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
description: "Tanulja meg, hogyan adhat hozzá és nyerhet ki programozott módon videókereteket a PowerPoint és OpenDocument diáknak az Aspose.Slides for .NET segítségével. Gyors útmutató."
---
## **Bevezetés**

Egy megfelelően elhelyezett videó egy prezentációban meggyőzőbbé teheti az üzenetét, és növelheti a közönségével való elköteleződés szintjét. 

A PowerPoint két módon teszi lehetővé, hogy videókat adjon hozzá egy diára a prezentációban:

* Helyi videó hozzáadása vagy beágyazása (a gépen tárolt)
* Online videó hozzáadása (web forrásból, például YouTube).

Az Aspose.Slides lehetővé teszi, hogy videókat (videoobjektumokat) adjon hozzá egy prezentációhoz, és biztosítja az [IVideo](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideo/) interfészt, az [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) interfészt, valamint egyéb releváns típusokat.

## **Beágyazott videókeret létrehozása**

Ha a diára kívánt videófájl helyileg van tárolva, létrehozhat egy videókeretet a videó beágyazásához a prezentációba. 

1. Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)osztályból.  
1. Szerezze meg a dia referenciajét az indexe alapján.  
1. Adjon hozzá egy [IVideo](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideo/) objektumot, és adja meg a videófájl elérési útját a videó beágyazásához a prezentációval.  
1. Adjon hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) objektumot a videó keret létrehozásához.  
1. Mentse el a módosított prezentációt.  

Ez a C# kód bemutatja, hogyan adjon hozzá lokálisan tárolt videót egy prezentációhoz:

```c#
// Létrehozza a Presentation osztályt
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Betölti a videót
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Lekéri az első diát és hozzáad egy videókeretet
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Elmenti a prezentációt a lemezre
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Alternatívaként közvetlenül a fájl útvonalát adhatja át a [AddVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addvideoframe/) metódusnak:

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Videókeret létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint 2013 és újabb](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) támogatja a YouTube videókat a prezentációkban. Ha a felhasználandó videó online érhető el (például YouTube-on), a webes hivatkozásával adhatja hozzá a prezentációhoz. 

1. Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)osztályból.  
1. Szerezze meg a dia referenciajét az indexe alapján.  
1. Adjon hozzá egy [IVideo](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideo/) objektumot, és adja meg a videó hivatkozását.  
1. Állítson be egy bélyegképet a videókerethez.  
1. Mentse el a prezentációt.  

Ez a C# kód bemutatja, hogyan adjon hozzá egy webes videót egy PowerPoint diára:

```c#
public static void Run()
{
    // Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Videókeretet ad hozzá
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Betölti a bélyegképet
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Videó feliratok kezelése**

Az Aspose.Slides lehetővé teszi a zárt feliratok kezelését a PowerPoint prezentációk videókereteiben. A feliratok WebVTT formátumban tárolódnak, és a [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/captiontracks/) tulajdonságon keresztül érhetők el.

**Feliratok hozzáadása videókerethez**

A feliratok videókerethez való hozzáadásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Adjon hozzá egy videót a prezentációhoz.  
1. Adjon hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) objektumot egy diára.  
1. Használja a [CaptionTracks](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/captiontracks/) gyűjteményt WebVTT feliratpálya hozzáadásához.  
1. Mentse el a módosított prezentációt.  

Az alábbi kód megmutatja, hogyan adjon feliratokat egy videókerethez:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Új feliratpályát ad hozzá egy WebVTT fájlból.
    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

Az [ICaptionsCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/icaptionscollection/) interfész egy olyan túlterhelést is biztosít, amely lehetővé teszi feliratok hozzáadását egy adatfolyamból.

**Feliratok kinyerése videókeretből**

A feliratok videókeretből való kinyeréséhez:

1. Töltse be a videót tartalmazó prezentációt.  
1. Keresse meg a célzott [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) objektumot.  
1. Iteráljon végig a [CaptionTracks](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/captiontracks/) gyűjteményen.  
1. Mentse el minden feliratpályát egy `.vtt` fájlba.  

Az alábbi kód megmutatja, hogyan kinyerje a feliratokat egy videókeretből:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // A feliratpályát egy WebVTT fájlba menti.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Minden [ICaptions](https://reference.aspose.com/slides/hu/net/aspose.slides/icaptions/) objektum a felirat azonosítót, címkét, bináris adatot és a felirat szöveget UTF‑8 stringként teszi elérhetővé.

**Feliratok eltávolítása videókeretből**

A feliratok videókeretből való eltávolításához:

1. Töltse be a videót tartalmazó prezentációt.  
1. Szerezze meg a célzott [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) objektumot.  
1. Távolítsa el a feliratpályákat a [CaptionTracks](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/captiontracks/) gyűjteményből.  
1. Mentse el a módosított prezentációt.  

Az alábbi kód megmutatja, hogyan távolítsa el az összes feliratot egy videókeretből:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Eltávolítja az összes feliratot a videókeretből.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Ha csak egy feliratpályát kell eltávolítania, használja a [Remove](https://reference.aspose.com/slides/hu/net/aspose.slides/captionscollection/remove/) vagy a [RemoveAt](https://reference.aspose.com/slides/hu/net/aspose.slides/captionscollection/removeat/) metódust a [Clear](https://reference.aspose.com/slides/hu/net/aspose.slides/captionscollection/clear/) helyett.

## **Videó kinyerése diából**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését is.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) példányt a videót tartalmazó prezentáció betöltéséhez.  
2. Iteráljon végig az összes [ISlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide) objektumon.  
3. Iteráljon végig az összes [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape) objektumon, hogy megtalálja a [VideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/videoframe) elemet.  
4. Mentse el a videót a lemezre.  

Ez a C# kód bemutatja, hogyan nyerje ki a videót egy prezentációs diához:

```c#
// Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel 
Presentation presentation = new Presentation("Video.pptx");

// Végigiterál a diákon
foreach (ISlide slide in presentation.Slides)
{
    // Végigiterál az alakzatokon
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Mentse a videót lemezre, amint megtalál egy videót tartalmazó VideoFrame-et
        if (shape is VideoFrame)
        {
            IVideoFrame vf = shape as IVideoFrame;
            String type = vf.EmbeddedVideo.ContentType;
            int ss = type.LastIndexOf('/');
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            Byte[] buffer = vf.EmbeddedVideo.BinaryData;
            using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
            {                                                     
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
```

## **FAQ**

**Mely videolejátszási paraméterek módosíthatók egy VideoFrame esetén?**

A [playback mode](https://reference.aspose.com/slides/hu/net/aspose.slides/videoframe/playmode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/hu/net/aspose.slides/videoframe/playloopmode/) vezérelhető a [VideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/videoframe/) objektum tulajdonságain keresztül.

**A videó hozzáadása befolyásolja a PPTX fájlméretet?**

Igen. Ha helyi videót ágyaz be, a bináris adat a dokumentumba kerül, így a prezentáció mérete arányosan nő a fájlmérettel. Online videó esetén egy hivatkozás és egy bélyegkép kerül beágyazásra, ezért a méretnövekedés kisebb.

**Lecserélhetem a videót egy már létező VideoFrame-ben anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A [video content](https://reference.aspose.com/slides/hu/net/aspose.slides/videoframe/embeddedvideo/) cseréjével a keretben megőrizhető a forma geometriai adata; ez gyakori megoldás a már meglévő elrendezés médiaanyagainak frissítésére.

**Meghatározható-e a beágyazott videó tartalomtípusa (MIME)?**

Igen. Egy beágyazott videó rendelkezik [content type](https://reference.aspose.com/slides/hu/net/aspose.slides/video/contenttype/) információval, amely olvasható és felhasználható például lemezre mentéskor.