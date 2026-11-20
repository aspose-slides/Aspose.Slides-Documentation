---
title: Videókeretek kezelése prezentációkban Androidon
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
- web forrás
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Tanulja meg programozottan videókeretek hozzáadását és kinyerését PowerPoint és OpenDocument diákat használva az Aspose.Slides for Android via Java segítségével. Gyors gyakorlati útmutató."
---
## **Bevezetés**

A videók segíthetnek az elképzelések magyarázatában és a közönség bevonásában. Az Aspose.Slides for Android Java segítségével lehetővé teszi videókeretek hozzáadását a diákhoz, a lejátszási beállítások módosítását, feliratok kezelését és a beágyazott videóadatok kinyerését.

A PowerPoint támogatja a helyi videókat és az online videókra mutató hivatkozásokat, például a YouTube videókat.

A videóadatok és videókeretek ábrázolásához az Aspose.Slides biztosítja a [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) interfészt, a [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) interfészt és egyéb kapcsolódó típusokat.

## **Beágyazott videókeret létrehozása**

Ha a diára felvenni kívánt videofájl helyi tárolású, létrehozhat egy videókeretet a videó bemutatóba való beágyazásához.

Ez a példa egy helyi videót ágyaz be a meglévő prezentáció első diájára, majd elmenti az eredményt. A keret koordinátái és méretei pontban vannak megadva. A stream nyitva marad a mentés befejezéséig, mivel a [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) zárolva tartja, amíg a prezentáció használja.

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

A helyi videó útvonalát közvetlenül átadhatja a [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) metódusnak. Ez a példa a videót egy új prezentáció első diájára ágyazza be. A videónak a prezentáció mentéséig hozzáférhetőnek kell maradnia.

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

Ez a példa egy YouTube videó hivatkozást és előnézeti képet ad hozzá az első diához. Cserélje ki a videó azonosítót másik videó használatához. A [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) metódus automatikus lejátszást kér. Az előnézet letöltése és a videó lejátszása internetkapcsolatot igényel. A prezentáció megjelenítőnek szintén támogatnia kell az online videó lejátszást.

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

## **Videó lejátszása teljes képernyő módban**

Egy oktatási prezentációban a szoftverbemutatót teljes képernyő módban lejátszhatja, hogy a közönség lássa a részleteket. Hívja meg a [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) metódust `true` értékkel a lejátszás során ennek a viselkedésnek a bekapcsolásához.

Ez a példa megnyit egy prezentációt, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) objektumot az első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen már létezik videókeret az első dián.

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

A teljes képernyős lejátszás szabályozza, hogyan jelenik meg a videó. Függetlenül, a [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) határozza meg, automatikusan vagy kattintásra indul-e, a [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) pedig azt, hogy ismétlődik-e. A kezdési viselkedés kiválasztásához állítsa a lejátszási módot [VideoPlayModePreset.Auto vagy VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) értékre. A példa megőrzi a meglévő kezdési és ismétlődési beállításokat.

## **Videó visszatekerése lejátszás után**

Egy oktatási prezentációban a bemutatóvideó visszatekerése a kezdetére azt készen állítja, hogy a bemondó újra lejátszhassa. Hívja a [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) metódust `true` értékkel, hogy a lejátszás befejezése után a videó a kezdetére térjen vissza.

Ez a példa megnyit egy prezentációt, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) objektumot az első dián, és engedélyezi a visszatekerést. Kikapcsolja az ismétlést, hogy a lejátszás befejeződhessen, és úgy állítja be a lejátszást, hogy kattintásra induljon. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen már létezik videókeret az első dián.

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

A visszatekerés a videót a kezdetére állítja anélkül, hogy újra elindulna. Ezzel szemben a [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) `true` értékkel történő hívása automatikusan ismétli a lejátszást. Kapcsolja ki az ismétlést, ha azt szeretné, hogy a videó befejeződjön és készen álljon az újrajátszásra. A [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) függetlenül szabályozza az automatikus vagy kattintásra való indítást; ez a példa a [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) módot használja, így a bemondó dönt a lejátszás indításáról. Állítsa be a lejátszási módot az ismétlés beállítása után, ahogy a példában látható. A visszatekerés független a [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) működésétől.

## **Videókeret vágása**

Használja az [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) és az [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) metódusokat, hogy a lejátszás során kihagyja a videó elejének vagy végének egy részét. Mindkét érték ezredmásodpercben van megadva. A vágás módosítja a lejátszási beállításokat anélkül, hogy a beágyazott videó adatot módosítaná.

**Vágási beállítások megadása**

Ez a példa egy helyi videót ágyaz be, és a lejátszás során kihagyja az első 2,5 másodpercet és az utolsó másodpercet. Használjon 3,5 másodpercnél hosszabb videót, hogy maradjon lejátszható szegmens.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Vágási beállítások olvasása**

Ez a példa kiírja az első dián lévő első videókeret vágási értékeit ezredmásodpercben. A prezentációnak legalább egy diát kell tartalmaznia. Ha az a dia nem tartalmaz videókeretet, semmi sem kerül kiírásra. Az előző példa 2500 és 1000 értékeket ad.

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

## **Videófeliratok kezelése**

Az Aspose.Slides lehetővé teszi a videókeretekhez tartozó zárt feliratok kezelését a PowerPoint prezentációkban. A feliratok WebVTT formátumban tárolódnak, és a [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) metóduson keresztül érhetők el.

### **Feliratok hozzáadása videókerethez**

Ez a példa egy helyi videót ágyaz be, és hozzáad egy 'English' címkéjű WebVTT feliratspontot. A felirat időbélyegeinek a videóval kell egyezniük. A mentett prezentáció tartalmazza a videót és a feliratokat is.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) interfész további overload-ot is biztosít, amely lehetővé teszi feliratok hozzáadását streamből.

### **Feliratok kinyerése videókeretből**

Ez a példa az első dián lévő videókeretek összes feliratsávját különálló WebVTT fájlokként menti. A sorozatszámok biztosítják a kimeneti fájlok egyediségét. A konzol jelzi a kinyert sávok számát. A prezentációnak legalább egy diát kell tartalmaznia.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Minden [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) objektum tartalmazza a felirat azonosítóját, címkéjét, bináris adatát és a felirat szövegét UTF-8 karakterláncként.

### **Feliratok eltávolítása videókeretből**

Ez a példa eltávolítja az összes feliratot az első dián az első alakzat pozíciójában lévő videókeretről, majd elmenti az eredményt. Feltételezi, hogy a dia és az alakzat létezik, és az alakzat videókeret.

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

Ha csak egy feliratsávot szeretne eltávolítani, használja a [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) vagy a [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) metódusokat a [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--) helyett.

### **Videófeliratok keresése**

Az [ICaptions.getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) visszaadja a teljes WebVTT sávot, beleértve a fejlécet, az időzítési sorokat és a felirat szövegét. A memóriában lévő cue-kat keresve megtalálhat egy kimondott kifejezést és annak időbélyegét. Például a 2. dián lévő angol sáv a következő szöveget tartalmazhatja.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

A példa megnyitja a `captioned_media.pptx` fájlt, és a [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) segítségével beolvassa minden dia felső szintű videókeretének sávjait. Egy egyszerű szöveges cue-ban az időzítési sor `-->` karaktert tartalmaz, és egy üres sor zárja a cue-t. Ha a felirat bármilyen nagy- vagy kisbetűben tartalmazza a “café” kifejezést, a példa kiírja a dia számát, a sáv címkéjét, az eredeti időzítési sort és a teljes feliratot.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringBuilder caption = new StringBuilder();
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            if (caption.length() > 0) {
                                caption.append('\n');
                            }
                            caption.append(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

A “café” keresése egy találatot eredményez a mintasávra. A keresés kizárja a sávfejlécet, és megőrzi az időzítési beállítást a kimenetben.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Videó kinyerése diáról**

A videók diákhoz adása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését.

Ez a példa minden diáról kinyeri a beágyazott videókat különálló, számozott bináris fájlokba. A hivatkozott videók kimaradnak, mivel nincs beágyazott adatuk. A konzol kiírja minden videó MIME típusát és a teljes darabszámot. A kimenet általános `.bin` kiterjesztést használ; szükség esetén módosítsa, hogy megfeleljen a jelentett média típusnak.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

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
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
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

**Mely videólejátszási paraméterek változtathatók egy videókeretnél?**  
A [lejátszási módot](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automatikus vagy kattintásra) és az [ismétlést](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) lehet szabályozni. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) objektum metódusain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájl méretét?**  
Igen. Ha helyi videót ágyaz be, a bináris adat a dokumentumba kerül, így a prezentáció mérete arányosan nő a fájl méretével. Ha online videóra hivatkozik és előnézeti képet ad hozzá, a prezentáció a hivatkozást és a képet tárolja a videó adat helyett, ezért a méretnövekedés általában kisebb.

**Lecserélhetem a videót egy meglévő videókereten anélkül, hogy megváltoztatnám a pozícióját és méretét?**  
Igen. A [videótartalmat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) kicserélheti a kereten belül, miközben megőrzi az alakzat geometriáját; ez gyakori eset a meglévő elrendezésben lévő média frissítésére.

**Megállapítható a beágyazott videó tartalom típusa (MIME)?**  
Igen. A beágyazott videónak van egy [content type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) attribútuma, amelyet leolvashat és felhasználhat, például lemezre mentéskor.