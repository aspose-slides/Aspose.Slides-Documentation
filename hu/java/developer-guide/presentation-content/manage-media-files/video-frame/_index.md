---
title: Videókeretek kezelése prezentációkban Java használatával
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
- prezentáció
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan adjon programozottan videókereteket PowerPoint és OpenDocument diákhoz az Aspose.Slides for Java használatával. Gyors útmutató."
---
## **Bevezetés**

Egy jól elhelyezett videó a bemutatóban hatásosabbá teheti az üzenetét, és növelheti a közönség bevonódását. 

A PowerPoint két módon teszi lehetővé a videók hozzáadását egy diára a bemutatóban:

* Helyi videó hozzáadása vagy beágyazása (a gépén tárolt)
* Online videó hozzáadása (webes forrásból, például YouTube).

Ahhoz, hogy videókat (videoobjektumokat) adjon hozzá egy bemutatóhoz, az Aspose.Slides biztosítja az [IVideo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideo/) interfészt, az [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/) interfészt és további releváns típusokat. 

## **Beágyazott videókeretek létrehozása**

Ha a diára felvenni kívánt videófájl helyileg van tárolva, létrehozhat egy videókeretet a videó bemutatóba ágyazásához. 

1. Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból. 
1. Szerezze meg egy dia hivatkozását az indexe alapján. 
1. Adjon hozzá egy [IVideo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideo/) objektumot, és adja meg a videófájl útvonalát a videó a bemutatóba ágyazásához. 
1. Adjon hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/) objektumot a videó keret létrehozásához.  
1. Mentse el a módosított bemutatót. 

Ez a Java kód bemutatja, hogyan adhat hozzá egy helyileg tárolt videót a bemutatóhoz:

```java
// Példányosítja a Presentation osztályt
Presentation pres = new Presentation("pres.pptx");
try {
    // Betölti a videót
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Lekéri az első diát, és hozzáad egy videókeretet
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // A prezentációt lemezre menti
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternatív megoldásként egy videót is hozzáadhat, ha a fájl útvonalát közvetlenül átadja a [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) metódusnak:

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

A Microsoft [PowerPoint 2013 és újabb](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) támogatja a YouTube videókat a bemutatókban. Ha a használni kívánt videó online elérhető (például a YouTube-on), hozzáadhatja a bemutatóhoz a webes hivatkozásával. 

1. Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból 
1. Szerezze meg egy dia hivatkozását az indexe alapján. 
1. Adjon hozzá egy [IVideo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideo/) objektumot, és adja meg a videó hivatkozását. 
1. Állítson be egy bélyegképet a videókerethez. 
1. Mentse el a bemutatót. 

Ez a Java kód bemutatja, hogyan adhat hozzá egy webes videót egy diához egy PowerPoint bemutatóban:

```java
// Példányosít egy Presentation objektumot, amely egy prezentáció fájlt képvisel 
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

## **Videófeliratok kezelése**

Az Aspose.Slides lehetővé teszi a zárt feliratok kezelését a videókeretekhez PowerPoint bemutatókban. A feliratok WebVTT formátumban tárolódnak, és a [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) metóduson keresztül érhetők el. 

**Feliratok hozzáadása videókerethez**

Feliratok videókerethez hozzáadásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból. 
1. Adjon hozzá egy videót a bemutatóhoz. 
1. Adjon hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/) objektumot a diához. 
1. Használja a [ICaptionsCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/) által visszaadott [getCaptionTracks](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) objektumot WebVTT feliratsáv hozzáadásához. 
1. Mentse el a módosított bemutatót. 

Az alábbi kód bemutatja, hogyan adhat feliratokat egy videókerethez:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Új feliratsávot ad hozzá egy WebVTT fájlból.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az [ICaptionsCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/) interfész további túlterhelést is kínál, amely lehetővé teszi a feliratok stream‑ből történő hozzáadását. 

**Feliratok kinyerése videókeretből**

Feliratok kinyeréséhez egy videókeretből:

1. Töltse be a videót tartalmazó bemutatót. 
1. Keresse meg a cél [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/) objektumot. 
1. Iteráljon a [ICaptionsCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/) feliratsávjai között. 
1. Mentse el minden feliratsávot egy `.vtt` fájlba. 

Az alábbi kód bemutatja, hogyan nyerhet ki feliratokat egy videókeretből:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // A feliratsáv mentése egy WebVTT fájlba.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Minden [ICaptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptions/) objektum a felirat azonosítóját, címkéjét, bináris adatait és a felirat szövegét UTF‑8 karakterláncként teszi elérhetővé. 

**Feliratok eltávolítása videókeretből**

Feliratok eltávolításához egy videókeretből:

1. Töltse be a videót tartalmazó bemutatót. 
1. Szerezze meg a cél [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivideoframe/) objektumot. 
1. Távolítsa el a feliratsávokat a [ICaptionsCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/) gyűjteményből. 
1. Mentse el a módosított bemutatót. 

Az alábbi kód bemutatja, hogyan távolíthatja el az összes feliratot egy videókeretből:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Eltávolítja az összes feliratot a videókeretből.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha csak egy feliratsávot kell eltávolítania, használja a [remove](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) vagy a [removeAt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/#removeAt-int-) metódusokat a [clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/#clear--) helyett. 

## **Videó kinyerése diákból**

A videók diákhoz való hozzáadása mellett, az Aspose.Slides lehetővé teszi a bemutatókba ágyazott videók kinyerését is.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályú példányt a videót tartalmazó bemutató betöltéséhez. 
2. Iteráljon végig az összes [ISlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/) objektumon. 
3. Iteráljon az összes [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) objektumon a [VideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/videoframe/) megtalálásához. 
4. Mentse el a videót a lemezre. 

Ez a Java kód bemutatja, hogyan nyerheti ki a videót egy bemutató diaján:

```java
// Instantiates a Presentation object that represents a presentation file 
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

                // Lekéri a fájlkiterjesztést
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

**Mely video lejátszási paraméterek módosíthatók egy VideoFrame esetén?**

A [playback mode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/hu/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) beállításait vezérelheti. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el. 

**A videó hozzáadása befolyásolja a PPTX fájl méretét?**

Igen. Ha helyi videót ágyaz be, a bináris adat a dokumentumba kerül, így a bemutató mérete arányosan nő a fájl méretével. Ha online videót ad hozzá, egy hivatkozás és egy bélyegkép kerül beágyazásra, ezért a méretnövekedés kisebb. 

**Lecserélhetem egy meglévő VideoFrame videóját anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A kereten belül a [video content](https://reference.aspose.com/slides/hu/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) cserélhető, miközben a forma geometriai adatai megmaradnak; ez gyakori eset a média frissítésére egy meglévő elrendezésben. 

**Megállapítható a beágyazott videó tartalomtípusa (MIME)?**

Igen. A beágyazott videó rendelkezik egy [content type](https://reference.aspose.com/slides/hu/java/com.aspose.slides/video/#getContentType--) tulajdonsággal, amelyet kiolvashat és felhasználhat, például a lemezre mentéskor.