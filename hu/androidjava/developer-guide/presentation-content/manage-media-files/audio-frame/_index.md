---
title: Hang kezelése a prezentációkban Androidon
linktitle: Hangkeret
type: docs
weight: 10
url: /hu/androidjava/audio-frame/
keywords:
- hang
- hangkeret
- bélyegkép
- hang hozzáadása
- hang tulajdonságok
- hang beállítások
- hang kinyerése
- Android
- Java
- Aspose.Slides
description: "Hangkeretek létrehozása és vezérlése az Aspose.Slides for Androidban – Java példák beágyazásra, vágásra, ismétlésre és lejátszás konfigurálására PPT, PPTX és ODP prezentációkban."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan kell dolgozni hangkeretekkel az Aspose.Slides-ban. Bemutatja, hogyan lehet beágyazott hangot hozzáadni a diákhoz, testreszabni a hangkeret bélyegképét, konfigurálni a lejátszási beállításokat, például hangerőt, ismétlést, elrejtést, vágást és elhalványulási időtartamokat, valamint kinyerni a diavetítés-átmenetekben használt hangot.

## **Hangkeretek létrehozása**
Az Aspose.Slides for Android via Java lehetővé teszi, hogy hangfájlokat adjunk a diákhoz. A hangfájlok beágyazott hangkeretekként kerülnek a diákba.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2. Szerezze meg egy dia hivatkozását az indexe alapján.
3. Töltse be a hangfájl adatfolyamát, amelyet be akar ágyazni a diába.
4. Adja hozzá a beágyazott hangkeretet (amely a hangfájlt tartalmazza) a diához.
5. Állítsa be a [PlayMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/AudioPlayModePreset) és a `Volume` értékeket a [IAudioFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAudioFrame) objektumon.
6. Mentse el a módosított prezentációt.

Ez a Java‑kód megmutatja, hogyan lehet beágyazott hangkeretet hozzáadni egy diához:

```java
// Létrehozza a Presentation osztály példányát, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Betölti a wav hangfájlt adatfolyamra
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Hozzáadja a Hangkeretet
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Beállítja a Hang lejátszási módját és hangerőjét
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // A PowerPoint fájlt leírja a lemezre
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **A hangkeret bélyegképének módosítása**

Amikor hangfájlt adunk egy prezentációhoz, a hang egy alapértelmezett képpel rendelkező keretként jelenik meg (lásd az alábbi ábrát). A hangkeret előnézeti képét (a kívánt képet) módosíthatja.

Ez a Java‑kód megmutatja, hogyan lehet megváltoztatni egy hangkeret bélyegképét vagy előnézeti képét:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy hangkeretet a diához megadott pozícióval és mérettel.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Hozzáad egy képet a prezentáció erőforrásaihoz.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Beállítja a képet a hangkerethez.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Mentés a módosított prezentáció lemezre
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Hanglejátszási beállítások módosítása**

Az Aspose.Slides for Android via Java lehetővé teszi a hang lejátszását vagy tulajdonságait befolyásoló beállítások módosítását. Például beállíthatja a hangerőt, a folyamatos lejátszást, vagy elrejtheti a hang ikont.

A **Hangbeállítások** panel a Microsoft PowerPointben:

![example1_image](audio_frame_0.png)

A PowerPoint **Hangbeállítások**, amelyek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/AudioFrame) tulajdonságainak felelnek meg:

- **Start** legördülő lista a [AudioFrame.PlayMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) tulajdonságnak megfelelő
- **Volume** a [AudioFrame.Volume](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/AudioFrame#getVolume--) tulajdonságnak megfelelő
- **Play Across Slides** a [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) tulajdonságnak megfelelő
- **Loop until Stopped** a [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) tulajdonságnak megfelelő
- **Hide During Show** a [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) tulajdonságnak megfelelő
- **Rewind after Playing** a [AudioFrame.RewindAudio](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) tulajdonságnak megfelelő

A PowerPoint **Szerkesztés** beállításai, amelyek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/audioframe/) tulajdonságainak felelnek meg:

- **Fade In** a [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) tulajdonságnak megfelelő 
- **Fade Out** a [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) tulajdonságnak megfelelő 
- **Trim Audio Start Time** a [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) tulajdonságnak megfelelő 
- **Trim Audio End Time** értéke megegyezik a hang teljes időtartamával mínusz a [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) tulajdonság értékével

A PowerPoint **Volume controll** a hangvezérlő panelen a [AudioFrame.VolumeValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) tulajdonságnak megfelelő. Ez lehetővé teszi a hangerő százalékos változtatását.

Így módosíthatja a hang lejátszási beállításait:

1. [Сreate](#create-audio-frame) vagy szerezze be a Hangkeretet.
2. Állítson be új értékeket a módosítani kívánt Hangkeret‑tulajdonságoknál.
3. Mentse el a módosított PowerPoint‑fájlt.

Ez a Java‑kód bemutat egy műveletet, amelyben a hang beállításait állítják át:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Lekéri az AudioFrame alakzatot
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Beállítja a lejátszási módot kattintásra
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Beállítja a hangerőt alacsonyra
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Beállítja, hogy a hang a diákon át lejátszódjon
    audioFrame.setPlayAcrossSlides(true);

    // Kikapcsolja a hang ismétlését
    audioFrame.setPlayLoopMode(false);

    // Elrejti az AudioFrame-et a diavetítés során
    audioFrame.setHideAtShowing(true);

    // Visszatekeri a hangot az elejére a lejátszás után
    audioFrame.setRewindAudio(true);

    // Mentés a PowerPoint fájl lemezre
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ez a Java‑példa megmutatja, hogyan lehet új hangkeretet hozzáadni beágyazott hanggal, vágni, és beállítani a be- és kimenet időtartamát:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Beállítja a vágás kezdőeltolását 1,5 másodpercre
    audioFrame.setTrimFromStart(1500f);
    // Beállítja a vágás befejező eltérését 2 másodpercre
    audioFrame.setTrimFromEnd(2000f);

    // Beállítja a beolvadás időtartamát 200 ms-re
    audioFrame.setFadeInDuration(200f);
    // Beállítja a kikapcsolás időtartamát 500 ms-re
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Az alábbi kódrészlet bemutatja, hogyan lehet egy beágyazott hangot tartalmazó hangkeretet lekérni, és a hangerőt 85 %‑ra állítani:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Lekéri a hangkeret alakzatot
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Beállítja a hang hangerőjét 85%-ra
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Hangfeliratok kezelése**

Az Aspose.Slides lehetővé teszi, hogy zárt feliratokat adjunk egy hangkerethez a [getCaptionTracks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) metóduson keresztül. Ez a metódus egy [ICaptionsCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptionscollection/)‑t ad vissza, amely lehetővé teszi WebVTT feliratok hozzáadását, létező sávok bejárását és azok eltávolítását szükség esetén.

**Hangfeliratok hozzáadása**

Használja a [getCaptionTracks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) metódust, hogy egy vagy több feliratsávot csatoljon egy hangkerethez. Az alábbi példában egy hangfájl kerül a diára, majd egy új feliratsávot tölt be egy `.vtt` fájlból.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Új feliratsáv hozzáadása egy WebVTT fájlból.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Hangfeliratok kinyerése**

Bejárhatja a hangkerethez tartozó feliratsávokat, és `.vtt` fájlokként mentheti őket. Minden feliratsáv bináris adatot és egyedi azonosítót biztosít, amely a feliratok exportálásához használható.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Mentse a feliratsávot .vtt fájlként.
                FileOutputStream fos = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                fos.write(captionTrack.getBinaryData());
                fos.close();
            }
        }
    }
} catch (IOException e){
} finally {
    presentation.dispose();
}
```

**Hangfeliratok eltávolítása**

A feliratok eltávolításához egy hangkeretből használja az [ICaptionsCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptionscollection/) által biztosított módszereket, például a [clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptionscollection/#clear--) , a [remove](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) vagy a [removeAt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) metódusokat. Az alábbi példa eltávolítja az összes feliratsávot egy hangkeretből.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Eltávolítja az összes feliratsávot a hangkeretből.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hang kinyerése**

Az Aspose.Slides for Android via Java lehetővé teszi a diavetítés-átmenetekben használt hangok kinyerését. Például egy adott dián használt hangot is kinyerhet.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, és töltse be a hangot tartalmazó prezentációt.
2. Szerezze meg a megfelelő dia hivatkozását az indexe alapján.
3. Érje el a [slideshow transitions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) objektumot a dián.
4. Kinyerje a hangot bájt adatként.

Ez a Java‑kód megmutatja, hogyan lehet kinyerni egy dián használt hangot:

```java
// Létrehozza a Presentation osztály példányát, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Hozzáfér a kívánt diához
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lekéri a diavetítési átmeneti effektusokat a diához
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Kinyeri a hangot bájt tömbként
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Újra felhasználhatom ugyanazt a hangfájlt több dián anélkül, hogy megnövelném a fájlméretet?**

Igen. Adja hozzá a hangot egyszer a prezentáció közös [audio collection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getAudios--)‑hez, majd hozzon létre további hangkereteket, amelyek erre a meglévő eszközre hivatkoznak. Így elkerülhető a média adat duplikálása, és a prezentáció mérete kontrollált marad.

**Lecserélhetem a hangot egy meglévő hangkeretben anélkül, hogy újból létrehoznám az alakzatot?**

Igen. Egy hivatkozott hang esetén frissítse a [link path](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) értékét az új fájlra mutatva. Egy beágyazott hang esetén cserélje ki a [embedded audio](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) objektumot a prezentáció [audio collection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getAudios--)‑ből származó másik hangra. A keret formázása és a legtöbb lejátszási beállítás megmarad.

**A vágás módosítja a prezentációban tárolt alaphang adatot?**

Nem. A vágás csak a lejátszási határokat állítja be. Az eredeti hangbájtok változatlanok maradnak, és elérhetők a beágyazott hang vagy a prezentáció hanggyűjteménye révén.