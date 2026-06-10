---
title: "Hang kezelése prezentációkban Java használatával"
linktitle: "Audio keret"
type: docs
weight: 10
url: /hu/java/audio-frame/
keywords:
- hang
- audio keret
- bélyegkép
- hang hozzáadása
- audio tulajdonságok
- audio opciók
- hang kinyerése
- Java
- Aspose.Slides
description: "Készítsen és irányítson audio kereteket az Aspose.Slides for Java-ban – kódpéldák a beágyazáshoz, vágáshoz, ciklusozáshoz és a lejátszás beállításához PPT, PPTX és ODP prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet hangkeretekkel dolgozni az Aspose.Slides-ban. Megmutatja, hogyan lehet beágyazott hangot hozzáadni a diákhoz, testreszabni a hangkeret bélyegképét, beállítani a lejátszási opciókat, például a hangerőt, a ciklusozást, a rejtést, a vágást és a keresztülcsengés időtartamát, valamint kinyerni a diavetítés-átmenetekhez használt hangot.

## **Audio keretek létrehozása**

Az Aspose.Slides for Java lehetővé teszi, hogy hangfájlokat adjunk a diákhoz. A hangfájlok beágyazott audio keretként jelennek meg a diákon. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia referenciáját az indexe alapján.  
3. Töltse be a beágyazni kívánt hangfájl adatfolyamát.  
4. Adja hozzá a beágyazott audio keretet (amely a hangfájlt tartalmazza) a diához.  
5. Állítsa be a [PlayMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/AudioPlayModePreset) és a `Volume` értékeket, amelyeket az [IAudioFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAudioFrame) objektum biztosít.  
6. Mentse el a módosított prezentációt.

Ez a Java kód megmutatja, hogyan adhatunk beágyazott audio keretet egy diához:

```java
// Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Betölti a wav hangfájlt adatfolyamra
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Hozzáadja az Audio Frame-et
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Beállítja a lejátszási módot és a hangerőt a hanghoz
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Kiírja a PowerPoint fájlt a lemezre
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Az audio keret bélyegképének módosítása**

Amikor hangfájlt adunk egy prezentációhoz, a hang egy alapértelmezett képpel rendelkező keretként jelenik meg (lásd az alábbi képet). A bélyegképet (előnézeti képet) módosíthatja a saját preferált képré.

Ez a Java kód mutatja, hogyan változtathatja meg egy audio keret bélyegképét vagy előnézeti képét:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy audio keretet a diát meghatározott pozícióval és mérettel.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Képet ad a prezentáció erőforrásaihoz.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Beállítja a képet az audio kerethez.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Menti a módosított prezentációt a lemezre
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Audio lejátszási beállítások módosítása**

Az Aspose.Slides for Java lehetővé teszi, hogy módosítsa a hang lejátszását vagy tulajdonságait szabályozó opciókat. Például állíthatja a hangerőt, beállíthatja a ciklikus lejátszást, vagy akár elrejtheti a hang ikont.

Az **Audio Options** panel a Microsoft PowerPointben:

![example1_image](audio_frame_0.png)

A PowerPoint **Audio Options** beállításai, amelyek megfelelnek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/AudioFrame) tulajdonságainak:

- **Start** legördülő lista megfelel a [AudioFrame.setPlayMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/audioframe/#setPlayMode-int-) metódusnak  
- **Volume** megfelel a [AudioFrame.setVolume](https://reference.aspose.com/slides/hu/java/com.aspose.slides/audioframe/#setVolume-int-) metódusnak  
- **Play Across Slides** megfelel a [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-) metódusnak  
- **Loop until Stopped** megfelel a [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-) metódusnak  
- **Hide During Show** megfelel a [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/hu/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-) metódusnak  
- **Rewind after Playing** megfelel a [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/hu/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-) metódusnak  

A PowerPoint **Editing** opciók, amelyek megfelelnek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/AudioFrame) tulajdonságainak:

- **Fade In** megfelel a [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/hu/java/com.aspose.slides/audioframe/#setFadeInDuration-float-) metódusnak  
- **Fade Out** megfelel a [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/hu/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-) metódusnak  
- **Trim Audio Start Time** megfelel a [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/audioframe/#setTrimFromStart-float-) metódusnak  
- **Trim Audio End Time** értéke megegyezik a hanghosszúsággal mínusz a [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/hu/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-) metódus által megadott értékkel  

A PowerPoint **Volume control** a hangvezérlő panelen a [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/audioframe/#setVolumeValue-float-) metódusnak felel meg. Ez lehetővé teszi a hangerő százalékos módosítását.

Az audio lejátszási opciók módosítása:

1. [Созreate](#create-audio-frame) vagy szerezze be az Audio Frame-et.  
2. Állítson be új értékeket a módosítani kívánt Audio Frame tulajdonságokhoz.  
3. Mentse el a módosított PowerPoint fájlt.

Ez a Java kód bemutat egy műveletet, amelyben a hang opcióit módosítják:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Lekéri az AudioFrame alakzatot
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Beállítja a lejátszási módot kattintásra
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Beállítja a hangerőt alacsonyra
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Beállítja, hogy a hang diák között játsszon
    audioFrame.setPlayAcrossSlides(true);

    // Letiltja a ciklusozást a hangnál
    audioFrame.setPlayLoopMode(false);

    // Elrejti az AudioFrame-et a diavetítés során
    audioFrame.setHideAtShowing(true);

    // Visszatekeri a hangot az elejére a lejátszás után
    audioFrame.setRewindAudio(true);

    // Mentse a PowerPoint fájlt a lemezre
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ez a Java példa megmutatja, hogyan adjon hozzá új audio keretet beágyazott hanggal, vágja le, és állítsa be a keresztülcsengés időtartamát:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Beállítja a vágás kezdő eltolását 1,5 másodpercre
    audioFrame.setTrimFromStart(1500f);
    // Beállítja a vágás befejező eltolását 2 másodpercre
    audioFrame.setTrimFromEnd(2000f);

    // Beállítja a fade-in időtartamot 200 ms-re
    audioFrame.setFadeInDuration(200f);
    // Beállítja a fade-out időtartamot 500 ms-re
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Az alábbi kódrészlet azt mutatja, hogyan kérjünk le egy beágyazott hanggal ellátott audio keretet és állítsuk be a hangerőt 85%-ra:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Lekéri az audio keret alakzatot
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Beállítja a hanghangerőt 85%-ra
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Audio feliratok kezelése**

Az Aspose.Slides lehetővé teszi, hogy zárt feliratokat adjunk egy audio kerethez a [getCaptionTracks](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) metódus segítségével. Ez a metódus egy [ICaptionsCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/) objektumot ad vissza, amely lehetővé teszi WebVTT feliratcsatornák hozzáadását, a meglévő csatornák iterálását és szükség esetén azok eltávolítását.

**Audio feliratok hozzáadása**

Használja a [getCaptionTracks](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) metódust, hogy egy vagy több feliratcsatornát csatoljon egy audio kerethez. Az alábbi példában egy hangfájlt adunk a diára, majd egy új feliratcsatornát töltünk be egy `.vtt` fájlból.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Új feliratcsatorna hozzáadása egy WebVTT fájlból.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Audio feliratok kinyerése**

Iterálhat a audio kerethez kapcsolódó feliratcsatornákon, és mentheti őket `.vtt` fájlokként. Minden feliratcsatorna kiadja a bináris adatot és az egyedi azonosítót, amely exportáláskor felhasználható.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Mentse a feliratcsatornát .vtt fájlként.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Audio feliratok eltávolítása**

A feliratok eltávolításához egy audio keretből használja az [ICaptionsCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/) által biztosított metódusokat, például a [clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/#clear--), a [remove](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), vagy a [removeAt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icaptionscollection/#removeAt-int-) metódusokat. Az alábbi példa eltávolítja az összes feliratcsatornát egy audio keretből.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Eltávolítja az összes feliratcsatornát az audio keretből.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Audio kinyerése**

Az Aspose.Slides for Java lehetővé teszi, hogy kinyerje a diavetítés-átmenetekben használt hangot. Például egy adott diában használt hangot is kinyerhet.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) példányt, és töltse be a hangot tartalmazó prezentációt.  
2. Szerezze meg a megfelelő dia referenciáját az indexe alapján.  
3. Érje el a [slideshow transitions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) objektumot a dián.  
4. Kinyerje a hangot bájt adatként.

Ez a Java kód megmutatja, hogyan lehet kinyerni egy diában használt hangot:

```java
// Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Hozzáfér a kívánt diához
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lekéri a diavetítés átmeneti effektusait a diára
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Kivonja a hangot bájt tömbbe
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Újra felhasználhatom ugyanazt a hanganyagot több dián anélkül, hogy megnövelném a fájlméretet?**

Igen. Adja hozzá a hangot egyszer a prezentáció közös [audio collection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getAudios--) eleméhez, és hozzon létre további audio kereteket, amelyek erre az meglévő eszközre hivatkoznak. Ez megakadályozza a médiaadatok duplikálását, és a prezentáció méretét kontroll alatt tartja.

**Kicserélhetem a hangot egy meglévő audio keretben anélkül, hogy újra létrehoznám a formát?**

Igen. Egy hivatkozott hang esetén frissítse a [link path](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) értékét az új fájlra. Beágyazott hang esetén cserélje ki a [embedded audio](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) objektumot egy másikkal a prezentáció [audio collection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getAudios--) elemből. A keret formázása és a legtöbb lejátszási beállítás változatlan marad.

**A vágás módosítja a prezentációban tárolt alap hangadatokat?**

Nem. A vágás csak a lejátszási határokat állítja be. Az eredeti hangbájtok változatlanul megmaradnak, és a beágyazott hang vagy a prezentáció audio gyűjteménye révén továbbra is elérhetők.