---
title: Videókeretek kezelése előadásokban Java használatával
linktitle: Videókeret
type: docs
weight: 10
url: /hu/java/video-frame/
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
- előadás
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan adhat hozzá és nyerhet ki programozottan videókereteket PowerPoint és OpenDocument diákba az Aspose.Slides for Java használatával. Gyors útmutató."
---
## **Bevezetés**

A megfelelően elhelyezett videó egy előadásban hatékonyabbá teheti az üzenetét, és növelheti a közönség elkötelezettségét. 

A PowerPoint két módon teszi lehetővé a videók hozzáadását egy diára egy előadásban:

* Helyi videó hozzáadása vagy beágyazása (a gépén tárolt)
* Online videó hozzáadása (webes forrásból, például a YouTube-ról).

Az Aspose.Slides lehetővé teszi, hogy videókat (video objektumokat) adjunk egy előadáshoz, és biztosítja az [IVideo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideo/) interfészt, az [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/) interfészt és egyéb releváns típusokat. 

## **Beágyazott videókeretek létrehozása**

Ha a diára felvenni kívánt videófájl helyileg van tárolva, létrehozhat egy videókeretet a videó előadásba való beágyazásához. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
1. Szerezze be egy dia referenciaját az indexe alapján.
1. Adjon hozzá egy [IVideo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideo/) objektumot, és adja meg a videófájl elérési útját a videó előadáshoz való beágyazásához.
1. Adjon hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/) objektumot a videó keretének létrehozásához.  
1. Mentse a módosított előadást. 

Ez a Java kód megmutatja, hogyan adhat hozzá egy helyileg tárolt videót egy előadáshoz:

```java
// Példányosítja a Presentation osztályt
Presentation pres = new Presentation("pres.pptx");
try {
    // Betölti a videót
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Lekéri az első diát és hozzáad egy videókeretet
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Mentse az előadást a lemezre
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternatív megoldásként a videót közvetlenül a fájl útvonalának átadásával adhatja hozzá az [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) metódusnak:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Videókeretek létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint 2013 és újabb](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) verziók támogatják a YouTube videókat az előadásokban. Ha a felhasználni kívánt videó online elérhető (például a YouTube-on), hozzáadhatja előadásához a webes hivatkozásán keresztül. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból
1. Szerezze be egy dia referenciaját az indexe alapján. 
1. Adjon hozzá egy [IVideo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideo/) objektumot, és adja meg a videó linkjét.
1. Állítson be bélyegképet a videókerethez. 
1. Mentse az előadást. 

Ez a Java kód megmutatja, hogyan adhat hozzá egy webes videót egy dia PowerPoint előadásban:

```java
// Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // Hozzáad egy videókeretet
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Betölti a bélyegképet
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **Videókeret levágása**

Az Aspose.Slides lehetővé teszi, hogy szabályozza, a videó mely része legyen lejátszva a trim-from-start és trim-from-end értékek beállításával a [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) és a [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) segítségével. Mindkét érték ezredmásodpercben van megadva, és meghatározza, mennyi időt hagy el a videó elejéről és végéről. Ezek a beállítások a videó lejátszási beállításait módosítják az előadásban; nem vágják vagy módosítják a beágyazott videó bináris adatait.

**Levágás beállítása**

Videókeret létrehozásához és a levágási beállítások megadásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Adjon hozzá egy [IVideo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideo/) objektumot az előadáshoz.
1. Adjon hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/) objektumot egy diára.
1. Állítsa be a trim-from-start és trim-from-end értékeket a [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) és a [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) segítségével.
1. Mentse a módosított előadást.

A következő kódrészlet kihagyja az első 2,5 másodpercet és az utolsó másodpercet egy beágyazott videó lejátszása során:

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Levágás beállításainak olvasása**

A meglévő levágási beállítások megtekintéséhez töltse be az előadást, keresse meg az első dián lévő alakzatok között az [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/) objektumot, és olvassa ki az értékeket a [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) és a [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--) segítségével.

A következő kódrészlet megtalálja az első videókeretet az első dián, és ezredmásodpercben jelzi a levágási beállításokat:

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Videó feliratok kezelése**

Az Aspose.Slides lehetővé teszi, hogy zárt feliratokat kezeljen a videókeretekhez PowerPoint előadásokban. A feliratok WebVTT formátumban vannak tárolva, és a [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) metóduson keresztül érhetők el.

**Feliratok hozzáadása egy videókerethez**

Feliratok egy videókerethez való hozzáadásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Adjon hozzá egy videót az előadáshoz.
1. Adjon hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/) objektumot egy diára.
1. Használja a [ICaptionsCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/) gyűjteményt, amelyet a [getCaptionTracks](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) visszaad, egy WebVTT feliratsáv hozzáadásához.
1. Mentse a módosított előadást.

A következő kód megmutatja, hogyan adhat feliratokat egy videókerethez:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Új feliratsáv hozzáadása egy WebVTT fájlból.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az [ICaptionsCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/) interfész további túlterhelést is biztosít, amely lehetővé teszi feliratok hozzáadását egy adatfolyamból.

**Feliratok kinyerése egy videókeretből**

Feliratok egy videókeretből való kinyeréséhez:

1. Töltse be azt az előadást, amely a videót tartalmazza.
1. Keresse meg a cél [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/) objektumot.
1. Iteráljon a feliratsávokon az [ICaptionsCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/) gyűjteményben.
1. Mentse el minden feliratsávot egy `.vtt` fájlba.

A következő kód megmutatja, hogyan nyerje ki a feliratokat egy videókeretből:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Mentse a feliratsávot egy WebVTT fájlba.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Minden [ICaptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptions/) objektum a felirat azonosítóját, címkéjét, bináris adatait és a felirat szövegét UTF-8 karakterláncként teszi elérhetővé.

**Feliratok eltávolítása egy videókeretből**

Feliratok egy videókeretből való eltávolításához:

1. Töltse be azt az előadást, amely a videót tartalmazza.
1. Szerezze meg a cél [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/) objektumot.
1. Távolítsa el a feliratsávokat az [ICaptionsCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/) gyűjteményből.
1. Mentse a módosított előadást.

A következő kód megmutatja, hogyan távolíthatja el az összes feliratot egy videókeretből:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Eltávolítja az összes feliratot a videókeretről.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha csak egy feliratsávot kíván eltávolítani, használja a [remove](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) vagy a [removeAt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/#removeAt-int-) metódust a [clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/#clear--) helyett.

## **Videó kinyerése diákból**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a beágyazott videók kinyerését az előadásokból.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból a videót tartalmazó előadás betöltéséhez. 
2. Iteráljon az összes [ISlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/) objektumon.
3. Iteráljon az összes [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) objektumon, hogy megtalálja a [VideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/videoframe/) elemet. 
4. Mentse a videót a lemezre.

Ez a Java kód megmutatja, hogyan nyerje ki a videót egy előadás diájáról:

```java
// Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                // Lekéri a fájl kiterjesztését
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Mely videólejátszási paraméterek módosíthatók egy VideoFrame esetén?**

A [playback mode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/hu/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) beállításait szabályozhatja. Ezek az opciók a [VideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájl méretét?**

Igen. Ha beágyaz egy helyi videót, a bináris adat a dokumentumba kerül, így az előadás mérete a fájl méretével arányosan nő. Ha online videót ad hozzá, egy hivatkozás és egy bélyegkép kerül beágyazásra, ezért a méretnövekedés kisebb.

**Lecserélhetem a videót egy meglévő VideoFrame-ben anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A keretben lévő [video content](https://reference.aspose.com/slides/hu/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) cserélhető a forma geometriai adatait megőrizve; ez gyakori eset a média frissítésére egy meglévő elrendezésben.

**Meghatározható-e egy beágyazott videó tartalomtípusa (MIME)?**

Igen. Egy beágyazott videónak van [content type](https://reference.aspose.com/slides/hu/java/com.aspose.slides/video/#getContentType--) tulajdonsága, amelyet kiolvashat és használhat, például a lemezre mentéskor.