---
title: Videókeretek kezelése Android prezentációkban
linktitle: Videókeret
type: docs
weight: 10
url: /hu/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan lehet programozottan videókereteket hozzáadni és kinyerni a PowerPoint és OpenDocument diákban az Aspose.Slides for Android segítségével Java nyelven. Gyors útmutató."
---
## **Bevezetés**

Egy jól elhelyezett videó egy prezentációban hatékonyabbá teheti az üzenetet, és növelheti a közönség elköteleződését.

PowerPoint lehetővé teszi, hogy videókat adjunk hozzá egy diára a prezentációban két módon:
* Helyi videó hozzáadása vagy beágyazása (a gépen tárolt)
* Online videó hozzáadása (webes forrásból, például a YouTubeból).

Az Aspose.Slides lehetővé teszi, hogy videókat (video objektumokat) adjunk a prezentációhoz, és biztosítja az [IVideo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideo/) interfészt, a [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) interfészt, valamint egyéb kapcsolódó típusokat.

## **Beágyazott videókeret létrehozása**

Ha a diára felvenni kívánt videófájl helyileg van tárolva, létrehozhat egy videókeretet a videó prezentációba történő beágyazásához.

1. Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Szerezze meg egy dia referenciáját az indexe alapján.
1. Adjon hozzá egy [IVideo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideo/) objektumot, és adja át a videófájl útvonalát a videó prezentációba történő beágyazásához.
1. Adjon hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) objektumot a videó keret létrehozásához.
1. Mentse el a módosított prezentációt.

Ez a Java kód bemutatja, hogyan adjon hozzá egy helyileg tárolt videót a prezentációhoz:

```java
// Létrehozza a Presentation osztályt
Presentation pres = new Presentation("pres.pptx");
try {
    // Betölti a videót
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Lekéri az első diát és hozzáad egy videókeretet
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Mentse a prezentációt lemezre
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternatív megoldásként videót is hozzáadhat a fájl útvonalát közvetlenül a [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) metódusnak átadva:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Webforrásból származó videóval rendelkező videókeret létrehozása**

Az újabb Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) verziók támogatják az online videókat a prezentációkban. Ha a használandó videó online elérhető (például a YouTube-on), hozzáadhatja azt a prezentációhoz a webes hivatkozásán keresztül.

1. Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Szerezze meg egy dia referenciáját az indexe alapján.
1. Adjon hozzá egy [IVideo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideo/) objektumot, és adja át a videó hivatkozását.
1. Állítson be bélyegképet a videókerethez.
1. Mentse el a prezentációt.

Ez a Java kód bemutatja, hogyan adjon hozzá egy webes videót egy diára a PowerPoint prezentációban:

```java
// Létrehozza a Presentation objektumot, amely egy prezentációs fájlt képvisel
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
    // Videókeretet ad hozzá
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

## **Videókeret vágása**

Az Aspose.Slides lehetővé teszi, hogy a videó lejátszott részét a [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) és a [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) metódusokkal beállított trim-from-start és trim-from-end értékekkel szabályozza. Mindkét érték ezredmásodpercben van megadva, és meghatározza, mennyi időt hagyunk ki a videó elejéről illetve végéről. Ezek a beállítások a videó lejátszási paramétereit változtatják a prezentációban; a beágyazott videó bináris adatait nem vágják vagy módosítják.

**Vágási beállítások megadása**

A videókeret létrehozásához és vágási beállításainak megadásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Adjon hozzá egy [IVideo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideo/) objektumot a prezentációhoz.
1. Adjon hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) objektumot egy diára.
1. Állítsa be a trim-from-start és trim-from-end értékeket a [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) és a [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) segítségével.
1. Mentse el a módosított prezentációt.

Az alábbi kódrészlet kihagyja az első 2,5 másodpercet és az utolsó másodpercet egy beágyazott videó lejátszása során:

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

**Vágási beállítások olvasása**

A meglévő vágási beállítások megtekintéséhez töltse be a prezentációt, keresse meg az első dián az [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) objektumot, és olvassa ki az értékeket a [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) és a [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--) metódusokkal.

Az alábbi kódrészlet megtalálja az első videókeretet az első dián, és ezredmásodpercben jelzi a vágási beállításait:

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

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint prezentációkban lévő videókeretekhez zárt feliratokat kezeljünk. A feliratok WebVTT formátumban vannak tárolva, és a [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) metóduson keresztül érhetők el.

**Feliratok hozzáadása videókerethez**

A feliratok hozzáadásához egy videókerethez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Adjon hozzá egy videót a prezentációhoz.
1. Adjon hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) objektumot egy diára.
1. Használja a [ICaptionsCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptionscollection/) objektumot, amelyet a [getCaptionTracks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) ad vissza, egy WebVTT feliratsp track hozzáadásához.
1. Mentse el a módosított prezentációt.

Az alábbi kód bemutatja, hogyan adjon feliratokat egy videókerethez:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
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

Az [ICaptionsCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptionscollection/) felület további túlterhelést biztosít, amely lehetővé teszi feliratok hozzáadását adatfolyamból.

**Feliratok kinyerése videókeretből**

A feliratok kinyeréséhez egy videókeretből:

1. Töltse be a videót tartalmazó prezentációt.
1. Keresse meg a cél [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) objektumot.
1. Iteráljon a [getCaptionTracks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) által visszaadott feliratsp trackeken.
1. Mentse el minden feliratsp tracket egy `.vtt` fájlba.

Az alábbi kód bemutatja, hogyan kinyerje a feliratokat egy videókeretből:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Mentse a feliratsávot egy WebVTT fájlba.
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Minden [ICaptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptions/) objektum tartalmazza a felirat azonosítóját, címkéjét, bináris adatait, valamint a felirat adatát UTF-8 karakterláncként.

**Feliratok eltávolítása videókeretből**

A feliratok eltávolításához egy videókeretből:

1. Töltse be a videót tartalmazó prezentációt.
1. Szerezze meg a cél [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) objektumot.
1. Távolítsa el a feliratsp trackeket a [getCaptionTracks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) által visszaadott gyűjteményből.
1. Mentse el a módosított prezentációt.

Az alábbi kód bemutatja, hogyan távolítsa el az összes feliratot egy videókeretből:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Eltávolítja az összes feliratot a videókeretből.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha csak egy feliratsp tracket szeretne eltávolítani, használja a [remove](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) vagy a [removeAt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) metódust a [clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptionscollection/#clear--) helyett.

## **Videó kinyerése diából**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését is.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból a videót tartalmazó prezentáció betöltéséhez.
2. Iteráljon végig az összes [ISlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/) objektumon.
3. Iteráljon végig az összes [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) objektumon, hogy megtalálja a [VideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/videoframe/) elemet.
4. Mentse el a videót lemezre.

Ez a Java kód bemutatja, hogyan nyerje ki a videót egy prezentációs diáról:

```java
// Létrehozza a Presentation objektumot, amely egy prezentációs fájlt képvisel 
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

                //Lekéri a fájlkiterjesztést
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

## **FAQ**

**Mely videolejátszási paraméterek módosíthatók egy VideoFrame esetén?**

A [lejátszási módot](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automatikus vagy kattintásra) és a [hurok](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) beállítását szabályozhatja. Ezek az opciók a [VideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájl méretét?**

Igen. Ha helyi videót ágyaz be, a bináris adat a dokumentumba kerül, így a prezentáció mérete arányosan nő a fájlmérettel. Ha online videót ad hozzá, egy hivatkozás és egy bélyegkép kerül beágyazásra, így a méretnövekedés kisebb.

**Lecserélhetem a videót egy meglévő VideoFrame-ben anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A [video content](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) cseréjével a kereten belül megőrizheti a forma geometriai adatát; ez gyakori eset a média frissítésére egy meglévő elrendezésben.

**Meg lehet határozni egy beágyazott videó tartalomtípusát (MIME)?**

Igen. Egy beágyazott videónak van [content type](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/video/#getContentType--) attribútuma, amelyet olvashat és felhasználhat, például a lemezre mentéskor.