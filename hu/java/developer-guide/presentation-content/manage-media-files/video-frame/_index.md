---
title: Prezentációk videókeretének kezelése Java használatával
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
description: "Tanulja meg programozottan videókeretek hozzáadását és kinyerését PowerPoint és OpenDocument diákon az Aspose.Slides for Java használatával. Gyors útmutató."
---
## **Bevezetés**

A videók segíthetnek a gondolatok magyarázatában és a közönség bevonásában. Az Aspose.Slides for Java lehetővé teszi, hogy videókereteket adjunk a diákhoz, módosítsuk a lejátszási beállításokat, kezeljük a feliratokat, és kinyerjük a beágyazott videó adatokat.

A PowerPoint támogatja a helyi videókat és az online videókra mutató hivatkozásokat, például a YouTube videókat.

Az Aspose.Slides a [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) és a [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) interfész, valamint más releváns típusok segítségével képviseli a videó adatokat és videókereteket.

## **Beágyazott videókeret létrehozása**

Ha a diára felvenni kívánt videófájl helyileg van tárolva, létrehozhat egy videókeretet a videó beágyazásához a prezentációba.

Ez a példa egy helyi videót ágyaz be egy meglévő prezentáció első diájára, és elmenti az eredményt. A keret koordinátái és méretei pontban vannak megadva. A stream nyitva marad, amíg a mentés be nem fejeződik, mivel a [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) zárolva tartja, amíg a prezentáció használja.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Közvetlenül is megadhatja a helyi videó elérési útját az [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) metódusnak. Ez a példa egy új prezentáció első diájára ágyazza be a videót. A videónak elérhetőnek kell maradnia, amíg a prezentáció mentésre kerül.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Videókeret létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) támogatja az online videókat a prezentációkban. Létrehozhat egy videókeretet, amely egy online videóra, például egy YouTube videóra hivatkozik.

Ez a példa egy YouTube videó hivatkozást és bélyegképet ad hozzá az első diához. Cserélje le a videóazonosítót egy másik videó használatához. A [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) metódus automatikus lejátszást kér. A bélyegkép letöltése és a videó lejátszása internetkapcsolatot igényel. A prezentáció megjelenítőnek is támogatnia kell az online videó lejátszást.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Videó lejátszása teljes képernyős módban**

Egy képzési prezentációban szoftverbemutatót játszhat le teljes képernyős módban, hogy a közönség lássa a részleteket. Hívja meg a [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) metódust `true` értékkel, hogy a lejátszás során ez a viselkedés legyen engedélyezve.

Ez a példa megnyit egy prezentációt, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) elemet az első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen az első dián már létezik videókeret.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A teljes képernyős lejátszás szabályozza, hogyan jelenik meg a videó. Függetlenül a [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) beállítja, automatikusan vagy kattintásra indul-e, a [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) pedig azt szabályozza, ismétlődik-e. A kezdési viselkedés kiválasztásához állítsa be a lejátszási módot a [VideoPlayModePreset.Auto vagy VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) egyikére. A példa megőrzi a meglévő kezdő- és ismétlődésbeállításokat.

## **Videó visszatekerése lejátszás után**

Egy képzési prezentációban a bemutatóvideó visszaállítása az elejére azt teszi lehetővé, hogy a előadó újra lejátszhassa. Hívja meg a [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) metódust `true` értékkel, hogy a lejátszás befejeződése után a videó az elejére térjen vissza.

Ez a példa megnyit egy prezentációt, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) elemet az első dián, és engedélyezi a visszatekerést. Letiltja a hurkot, hogy a lejátszás befejeződhessen, és a lejátszást kattintásra állítja. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen az első dián már létezik videókeret.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A visszatekerés a videót az elejére helyezi anélkül, hogy újra elindulna. Ezzel szemben a [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) `true` értékkel hívása automatikusan ismétli a lejátszást. Tartsa letiltva a hurkot, ha azt szeretné, hogy a videó befejeződjön és készen álljon az újrajátszásra. A [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) önállóan szabályozza az automatikus vagy kattintásos indítást; ez a példa a [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) beállítást használja, így a bemondó dönt a lejátszás indításáról. Állítsa be a lejátszási módot a hurkolás beállítása után, ahogy a példában látható. A visszatekerés független a [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) működésétől.

## **Videókeret vágása**

Használja a [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) és a [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) metódusokat a videó elejéről vagy végéről egy rész kihagyásához a lejátszás során. Mindkét érték ezredmásodpercben van megadva. A vágás a lejátszási beállításokat módosítja anélkül, hogy a beágyazott videó adatot megváltoztatná.

**Trim beállítások**

Ez a példa egy helyi videót ágyaz be, és a lejátszás során kihagyja az első 2,5 másodpercet és az utolsó másodpercet. Használjon 3,5 másodpercnél hosszabb videót, hogy maradjon lejátszható szegmens.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Trim beállítások lekérdezése**

Ez a példa kiírja az első videókeret trimértékeit az első dián ezredmásodpercben. A prezentációnak legalább egy diát kell tartalmaznia. Ha az adott dián nincs videókeret, semmi sem kerül kiírásra. Az előző példa 2500 és 1000 értékeket eredményez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Videó feliratok kezelése**

Az Aspose.Slides lehetővé teszi a videókeretekhez tartozó zárt feliratok kezelését a PowerPoint prezentációkban. A feliratok WebVTT formátumban tárolódnak, és a [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) metódussal érhetők el.

**Feliratok hozzáadása egy videókerethez**

Ez a példa egy helyi videót ágyaz be, és egy "English" címkével ellátott WebVTT feliratsávot ad hozzá. A felirat időbélyegének meg kell egyeznie a videóéval. A mentett prezentáció tartalmazza mind a videót, mind a feliratokat.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) interfész további túlterhelést is biztosít, amely lehetővé teszi feliratok hozzáadását egy streamből.

**Feliratok kinyerése egy videókeretből**

Ez a példa az első dián lévő videókeretek összes feliratsávját különálló WebVTT fájlokként menti. A sorozatszámok biztosítják a kimeneti fájlok egyediségét. A konzol jelzi a kinyert sávok számát. A prezentációnak legalább egy diát kell tartalmaznia.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Minden [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) objektum ki mutatja a felirat azonosítóját, címkéjét, bináris adatát és a feliratszöveget UTF‑8 karakterláncként.

**Feliratok eltávolítása egy videókeretből**

Ez a példa eltávolítja az összes feliratot az első dián az első alakzat pozíciójában lévő videókeretről, és elmenti az eredményt. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat videókeret.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha csak egy feliratsávot szeretne eltávolítani, használja a [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) vagy a [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) metódust a [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--) helyett.

## **Videó kinyerése diáról**

A videók diákhoz adása mellett az Aspose.Slides lehetővé teszi a prezentációkba ágyazott videók kinyerését is.

Ez a példa minden diáról kinyeri a beágyazott videókat külön, számozott bináris fájlokba. A hivatkozott videók ki vannak hagyva, mivel nincs beágyazott adatuk. A konzol kiírja minden videó MIME‑típusát és az összes számát. A kimenet a generikus `.bin` kiterjesztést használja; szükség esetén módosítsa a jelentett médiatípusnak megfelelően.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mely videó lejátszási paraméterek módosíthatók egy videókereten?**  
A [playback mode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) vezérelhető. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) objektum metódusaiban érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájlméretet?**  
Igen. Ha beágyaz egy helyi videót, a bináris adat a dokumentumba kerül, így a prezentáció mérete azonos arányban növekszik a fájlmérettel. Ha online videóra hivatkozik, és bélyegképet ad hozzá, a prezentáció csak a hivatkozást és a preview képet tárolja, így a méretnövekedés általában kisebb.

**Lecserélhetem a videót egy meglévő videókeretben anélkül, hogy megváltoztatnám a pozícióját és méretét?**  
Igen. A [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) cseréjével a keretben megőrizhető az alakzat geometriai adatainak változatlansága; ez egy gyakori forgatókönyv a média frissítésére egy meglévő elrendezésben.

**Megállapítható a beágyazott videó tartalomtípusa (MIME)?**  
Igen. A beágyazott videónak van egy [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) attribútuma, amely kiolvasható és felhasználható, például fájlba mentéskor.