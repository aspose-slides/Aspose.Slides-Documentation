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
description: "Tanulja meg, hogyan adhat hozzá és nyerhet ki programozott módon videókereteket PowerPoint és OpenDocument diákba az Aspose.Slides for .NET használatával. Gyors gyakorlati útmutató."
---
## **Bevezetés**

Egy megfelelően elhelyezett videó a prezentációban meggyőzőbbé teszi az üzenetedet, és növeli a közönség elköteleződését.

A PowerPoint két módon teszi lehetővé a videók hozzáadását egy diára a prezentációban:

* Helyi videó hozzáadása vagy beágyazása (a gépeden tárolva)
* Online videó hozzáadása (webes forrásból, például a YouTube-ról).

Az Aspose.Slides lehetővé teszi, hogy videókat (videoobjektumokat) adjunk hozzá egy prezentációhoz, a [IVideo](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideo/) interfészt, a [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) interfészt és egyéb releváns típusokat biztosít.

## **Beágyazott videókeret létrehozása**

Ha a diára felvenni kívánt videófájl helyileg van tárolva, létrehozhatsz egy videókeretet a videó prezentációba ágyazásához.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Szerezd meg egy dia referenciaindexét.
3. Adj hozzá egy [IVideo](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideo/) objektumot, és add meg a videófájl útvonalát a videó prezentációba ágyazásához.
4. Adj hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) objektumot a videó keret létrehozásához.
5. Mentsd el a módosított prezentációt.

Ez a C# kód megmutatja, hogyan adhatunk hozzá egy helyileg tárolt videót a prezentációhoz:

```c#
// Példányosítja a Presentation osztályt
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
Alternatívaként közvetlenül a videó fájlútvonalát átadva is hozzáadhatsz egy videót a [AddVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addvideoframe/) metódusnak:

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Videókeret létrehozása webes forrásból származó videóval**

Az újabb Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) verziók támogatják az online videókat a prezentációkban. Ha a felhasználandó videó online érhető el (például a YouTube-on), hozzáadhatod a prezentációhoz a webes hivatkozáson keresztül.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Szerezd meg egy dia referenciaindexét.
3. Adj hozzá egy [IVideo](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideo/) objektumot, és adja meg a videó linkjét.
4. Állíts be egy miniatűrt a videókerethez.
5. Mentsd el a prezentációt.

Ez a C# kód megmutatja, hogyan adhatunk hozzá egy webes videót egy PowerPoint diához:

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

    // Betölti a miniatűrt
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Videókeret levágása**

Az Aspose.Slides lehetővé teszi, hogy a videó lejátszott részét a [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/trimfromstart/) és a [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/trimfromend/) értékek beállításával szabályozd. Mindkét érték ezredmásodpercben van megadva, és meghatározza, mennyi időt hagyunk ki a videó elejéről illetve végéről. Ezek a beállítások a videó lejátszási beállításait módosítják a prezentációban; a beágyazott videó bináris adatait nem vágják vagy módosítják.

**Trim beállítások beállítása**

Egy videókeret létrehozásához és a trim beállítások megadásához:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
2. Adj hozzá egy [IVideo](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideo/) objektumot a prezentációhoz.
3. Adj hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) objektumot egy diára.
4. Állítsd be a trim-from-start és trim-from-end értékeket a [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/trimfromstart/) és a [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/trimfromend/) segítségével.
5. Mentsd el a módosított prezentációt.

A következő kódrészlet kilépteti az első 2,5 másodpercet és az utolsó másodpercet egy beágyazott videó lejátszása közben:

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Trim beállítások lekérdezése**

A meglévő trim beállítások megtekintéséhez tölts be egy prezentációt, keresd meg az első dián az [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) objektumot, és olvasd ki az értékeket a [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/trimfromstart/) és a [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/trimfromend/) segítségével.

A következő kódrészlet megtalálja az első videókeretet az első dián, és ezredmásodpercben jelzi a trim beállításait:

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **Videó feliratok kezelése**

Az Aspose.Slides lehetővé teszi, hogy zárt feliratokat kezelj videókeretekhez PowerPoint prezentációkban. A feliratok WebVTT formátumban tárolódnak, és a [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/captiontracks/) tulajdonságon keresztül érhetők el.

**Feliratok hozzáadása videókerethez**

Feliratok hozzáadásához egy videókerethez:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
2. Adj hozzá egy videót a prezentációhoz.
3. Adj hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) objektumot egy diára.
4. Használd a [CaptionTracks](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/captiontracks/) gyűjteményt egy WebVTT feliratsptrack hozzáadásához.
5. Mentsd el a módosított prezentációt.

A következő kód megmutatja, hogyan adhatunk feliratokat egy videókerethez:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Új feliratsptrack hozzáadása WebVTT fájlból.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

Az [ICaptionsCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/icaptionscollection/) interfész további túlterhelést is biztosít, amely lehetővé teszi, hogy a feliratokat streamből adjuk hozzá.

**Feliratok kinyerése videókeretből**

Feliratok kinyeréséhez egy videókeretből:

1. Töltsd be azt a prezentációt, amely tartalmazza a videót.
2. Találd meg a cél [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) objektumot.
3. Iterálj végig a [CaptionTracks](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/captiontracks/) gyűjteményen.
4. Mentsd el minden feliratsptracket egy `.vtt` fájlba.

A következő kód megmutatja, hogyan nyerhetőek ki a feliratok egy videókeretből:

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
                // Mentse a feliratsptrack-et WebVTT fájlba.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Minden [ICaptions](https://reference.aspose.com/slides/hu/net/aspose.slides/icaptions/) objektum a felirat azonosítóját, címkéjét, bináris adatát és a felirat szövegét UTF‑8 stringként szolgáltatja.

**Feliratok eltávolítása videókeretből**

Feliratok eltávolításához egy videókeretből:

1. Töltsd be azt a prezentációt, amely tartalmazza a videót.
2. Szerezd meg a cél [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) objektumot.
3. Távolítsd el a feliratsptrackeket a [CaptionTracks](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/captiontracks/) gyűjteményből.
4. Mentsd el a módosított prezentációt.

A következő kód megmutatja, hogyan távolíthatók el az összes felirat egy videókeretből:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Eltávolítja az összes feliratot a videókeretről.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Ha csak egy feliratsptracket szeretnél eltávolítani, használd a [Remove](https://reference.aspose.com/slides/hu/net/aspose.slides/captionscollection/remove/) vagy a [RemoveAt](https://reference.aspose.com/slides/hu/net/aspose.slides/captionscollection/removeat/) metódust a [Clear](https://reference.aspose.com/slides/hu/net/aspose.slides/captionscollection/clear/) helyett.

## **Videó kinyerése diáról**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését is.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból a videót tartalmazó prezentáció betöltéséhez.
2. Iterálj végig az összes [ISlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide) objektumon.
3. Iterálj végig az összes [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape) objektumon, hogy megtaláld a [VideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/videoframe) elemet.
4. Mentsd el a videót a lemezre.

Ez a C# kód megmutatja, hogyan nyerhető ki a videó egy prezentációs diáról:

```c#
 // Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel 
 Presentation presentation = new Presentation("Video.pptx");

 // Végigiterál a diákon
 foreach (ISlide slide in presentation.Slides)
 {
     // Végigiterál az alakzatokon
     foreach (IShape shape in presentation.Slides[0].Shapes)
     {
         // Elmenti a videót a lemezre, amint megtalálja a videót tartalmazó VideoFrame-et
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

## **GYIK**

**Mely videólejátszási paraméterek módosíthatók egy VideoFrame‑ben?**

A [playback mode](https://reference.aspose.com/slides/hu/net/aspose.slides/videoframe/playmode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/hu/net/aspose.slides/videoframe/playloopmode/) beállítható a [VideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/videoframe/) objektum tulajdonságain keresztül.

**A videó hozzáadása befolyásolja a PPTX fájlméretet?**

Igen. Ha helyi videót ágyazol be, a bináris adat a dokumentumba kerül, így a prezentáció mérete a fájlmérettel arányosan nő. Online videó esetén csak egy hivatkozás és egy miniatűr kerül beágyazásra, így a méretnövekedés kisebb.

**Lecserélhetem a videót egy meglévő VideoFrame‑ben anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A [video content](https://reference.aspose.com/slides/hu/net/aspose.slides/videoframe/embeddedvideo/) cserélhető a kereten belül, miközben a forma geometriai adatai változatlanok maradnak; ez gyakori eljárás a meglévő elrendezés médiatartalmának frissítésére.

**Megállapítható-e egy beágyazott videó tartalom típusa (MIME)?**

Igen. Egy beágyazott videó rendelkezik [content type](https://reference.aspose.com/slides/hu/net/aspose.slides/video/contenttype/) információval, amely leolvasható és felhasználható, például a lemezre mentéskor.