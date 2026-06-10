---
title: Videokeretek kezelése Androidos bemutatókban
linktitle: Videokeret
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
- bemutató
- Android
- Java
- Aspose.Slides
description: "Tanulja meg programozott módon videókeretek hozzáadását és kinyerését PowerPoint és OpenDocument diákban az Aspose.Slides for Android Java használatával. Gyors útmutató."
---
## **Bevezetés**

Egy megfelelően elhelyezett videó a bemutatóban hatásosabbá teheti üzenetét, és növelheti a közönség elkötelezettségét. 

A PowerPoint lehetővé teszi, hogy videókat adjon a diára a bemutatóban két módon:

* Helyi videó hozzáadása vagy beágyazása (a gépén tárolt)
* Online videó hozzáadása (webes forrásból, például a YouTube-ról).

Ahhoz, hogy videókat (videóobjektumokat) adjon a bemutatóhoz, az Aspose.Slides a [IVideo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideo/) interfészt, a [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) interfészt és egyéb releváns típusokat biztosít.

## **Beágyazott videokeret létrehozása**

Ha a diára felvenni kívánt videófájl helyileg van tárolva, létrehozhat egy videokeretet a videó bemutatóba ágyazásához. 

1. Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Szerezze meg a dia referenciáját az indexe alapján. 
1. Adjon hozzá egy [IVideo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideo/) objektumot, és adja meg a videófájl útvonalát a videó a bemutatóhoz való beágyazásához.
1. Adjon hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) objektumot a videóhoz keret létrehozásához.
1. Mentse el a módosított bemutatót. 

Ez a Java kód bemutatja, hogyan adjon egy helyileg tárolt videót a bemutatóhoz:

```java
// Példányosítja a Presentation osztályt
Presentation pres = new Presentation("pres.pptx");
try {
    // Betölti a videót
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Lekéri az első diát és hozzáad egy videokeretet
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Mentés a bemutatót a lemezen
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternatív megoldásként egy videót hozzáadhat úgy, hogy közvetlenül átadja a fájl útvonalát a [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) metódusnak:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Videokeret létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint 2013 és újabb verziói](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) támogatják a YouTube videókat a bemutatókban. Ha a használni kívánt videó online érhető el (pl. a YouTube-on), hozzáadhatja a bemutatóhoz a webes hivatkozásán keresztül. 

1. Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Szerezze meg a dia referenciáját az indexe alapján. 
1. Adjon hozzá egy [IVideo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideo/) objektumot, és adja meg a videó hivatkozását.
1. Állítson be egy bélyegképet a videokerethez. 
1. Mentse el a bemutatót. 

Ez a Java kód bemutatja, hogyan adjon egy webes videót a PowerPoint bemutató egy diájához:

```java
// Példányosít egy Presentation objektumot, amely egy bemutató fájlt képvisel
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
    // Hozzáad egy videokeretet
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

## **Videófeliratok kezelése**

Az Aspose.Slides lehetővé teszi a zárt feliratok kezelését a PowerPoint videokeretekhez. A feliratok WebVTT formátumban tárolódnak, és a [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) metóduson keresztül érhetők el.

**Feliratok hozzáadása egy videokerethez**

Feliratok hozzáadásához egy videokerethez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Adjon hozzá egy videót a bemutatóhoz.
1. Adjon hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) objektumot egy diára.
1. Használja a [ICaptionsCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptionscollection/) objektumot, amelyet a [getCaptionTracks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) visszaad, egy WebVTT felirat sáv hozzáadásához.
1. Mentse el a módosított bemutatót.

A következő kód bemutatja, hogyan adjon feliratokat egy videokerethez:

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

Az [ICaptionsCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptionscollection/) interfész egy túlterhelést is biztosít, amely lehetővé teszi a feliratok streamből történő hozzáadását.

**Feliratok kinyerése egy videokeretből**

Feliratok kinyeréséhez egy videokeretből:

1. Töltse be a videót tartalmazó bemutatót.
1. Keresse meg a cél [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) objektumot.
1. Iteráljon a [getCaptionTracks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) által visszaadott feliratsávokon.
1. Mentse minden feliratsávot egy `.vtt` fájlba.

A következő kód bemutatja, hogyan nyerje ki a feliratokat egy videokeretből:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // A feliratsáv mentése WebVTT fájlba.
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

Minden [ICaptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptions/) objektum tartalmazza a felirat azonosítóját, címkéjét, bináris adatait és a felirat szövegét UTF‑8 karakterláncként.

**Feliratok eltávolítása egy videokeretből**

Feliratok eltávolításához egy videokeretből:

1. Töltse be a videót tartalmazó bemutatót.
1. Szerezze meg a cél [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) objektumot.
1. Távolítsa el a feliratsávokat a [getCaptionTracks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) által visszaadott gyűjteményből.
1. Mentse el a módosított bemutatót.

A következő kód bemutatja, hogyan távolítsa el az összes feliratot egy videokeretből:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Eltávolítja az összes feliratot a videokeretből.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha csak egy feliratsávot kell eltávolítania, használja a [remove](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) vagy a [removeAt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) metódust a [clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptionscollection/#clear--) helyett.

## **Videó kinyerése egy diáról**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a bemutatóba beágyazott videók kinyerését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból a videót tartalmazó bemutató betöltéséhez.
2. Iteráljon az összes [ISlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/) objektumon.
3. Iteráljon az összes [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) objektumon, hogy megtalálja a [VideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/videoframe/) elemet.
4. Mentse a videót a lemezre.

Ez a Java kód bemutatja, hogyan nyerje ki a videót egy bemutató diáról:

```java
// Példányosít egy Presentation objektumot, amely egy bemutató fájlt képvisel
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

                // A fájl kiterjesztésének lekérése
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

**Milyen videolejátszási paraméterek módosíthatók egy VideoFrame esetén?**

A [playback mode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) beállításokat vezérelheti. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.

**Milyen hatással van a videó hozzáadása a PPTX fájlméretre?**

Igen. Ha beágyaz egy helyi videót, a bináris adatok a dokumentumba kerülnek, így a bemutató mérete a fájlmérettel arányosan nő. Ha online videót ad hozzá, egy hivatkozás és egy bélyegkép kerül beágyazásra, ezért a méretnövekedés kisebb.

**Lecserélhetem a videót egy meglévő VideoFrame-ben anélkül, hogy megváltoztatnám a pozíciót és a méretet?**

Igen. A [video content](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) cserélhető a kereten belül, miközben megőrzi a forma geometriai adatait; ez gyakori eset a médiák frissítésére egy meglévő elrendezésben.

**Megállapítható a beágyazott videó tartalomtípusa (MIME)?**

Igen. A beágyazott videó rendelkezik egy [content type](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/video/#getContentType--) értékkel, amelyet kiolvashat és felhasználhat, például lemezre mentéskor.