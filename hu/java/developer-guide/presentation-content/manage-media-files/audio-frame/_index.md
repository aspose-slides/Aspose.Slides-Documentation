---
title: Audio keretek kezelése prezentációkban Java-val
linktitle: Audio keret
type: docs
weight: 10
url: /hu/java/audio-frame/
keywords:
- hang
- hangkeret
- bélyegkép
- hang hozzáadása
- hang tulajdonságok
- hang beállítások
- hang kinyerése
- Java
- Aspose.Slides
description: "Beágyazzon hangot a diákba, változtassa meg a hangikonot, konfigurálja a lejátszást, kezelje a WebVTT feliratokat, és nyerje ki a diákátmenet hangjait az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Az audio keret lehetővé teszi, hogy hangot játssz le egy dián. Az Aspose.Slides for Java-val beágyazhatsz egy audio klipet, kiválaszthatod a képét, amely azt ábrázolja, beállíthatod a lejátszást, és feliratokat csatolhatsz. A diákátmenethez rendelt hangot is lekérheted.

## **Audio keretek létrehozása**

Használd a [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) a helyi audio klip beágyazásához az első dián. Az első két koordináta helyezi el a keretet a dián, a következő két érték a szélességét és magasságát állítja be, mind pontban. Ez a példa meghívja a [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) a klip automatikus indításához, és meghívja a [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) a hangos előre beállított érték kiválasztásához.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Az audio keret bélyegképének módosítása**

Alapértelmezés szerint egy audio keret egy hangszóró ikont jelenít meg. Egy egyéni bélyegkép megjelenítéséhez adj egy képet a prezentációhoz a [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) segítségével, és állítsd be a keret képként a [setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-) segítségével. A példa egy JPEG-et használ egy beágyazott audio klip bélyegképéhez.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav");
     FileInputStream imageStream = new FileInputStream("eagle.jpeg")) {
    IPPImage thumbnail = presentation.getImages().addImage(imageStream);

    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioFrame.getPictureFormat().getPicture().setImage(thumbnail);

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Az audio lejátszási beállítások módosítása**

A PowerPoint **Audio Options** vezérlői meghatározzák, hogy mikor indul a klip, mennyire hangos, és hogyan viselkedik a diavetítés során.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint vezérlő | Aspose.Slides for Java metódus |
| --- | --- |
| Indítás | [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Hangerő előbeállítása | [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Lejátszás diákon át | [setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Ismétlés leállításig | [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Elrejtés a vetítés alatt | [setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Visszatekerés lejátszás után | [setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Beúsztatás | [setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Kifakadás | [setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Audio vágás kezdési idő | [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Audio vágás befejezési idő | [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Hangerő csúszka | [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

A példa megtalálja az első audio keretet az első dián, meghívja a [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) a lejátszás indításához kattintásra, és kiválasztja az alacsony hangerő előbeállítást. A klip a diákon át folytatódik, a loopolás le van tiltva. Az ikon a vetítés során rejtve marad, és a klip lejátszás után visszatekeredik.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setPlayMode(AudioPlayModePreset.OnClick);
        audioFrame.setVolume(AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Egy 3,5 másodpercnél hosszabb klip esetén ez a példa kihagyja az első 1,5 másodpercet és az utolsó 2 másodpercet. A [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) a klip végéről elhagyandó időt veszi. A PowerPointban látható befejezési időhez vonja le ezt az eltolást a teljes klip időtartamából. A vágott klip 200 ms alatt beúszik és 500 ms alatt kifakul. Mind a négy metódus értékeket ezredmásodpercben vár.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
    audioFrame.setTrimFromStart(1500f);
    audioFrame.setTrimFromEnd(2000f);
    audioFrame.setFadeInDuration(200f);
    audioFrame.setFadeOutDuration(500f);

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A lejátszási hangerő egy adott százalékra állításához használd a [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-). Ez a példa az első audio keretet az első dián 85 %-ra állítja.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setVolumeValue(85f);
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Audio feliratok kezelése**

Minden audio keret hozzáférést biztosít a felirat sávjaihoz a [getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) segítségével. Használd a gyűjteményt WebVTT feliratok csatolásához a kliphez, meglévő sávok exportálásához vagy eltávolításához.

### **Audio feliratok hozzáadása**

A példa egy audio klipet ágyaz be az első dián, és a [add](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) segítségével csatol egy helyi WebVTT sávot. Az első argumentum a sáv címkéjét adja meg, a második a feliratokat tartalmazó fájlt határozza meg.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
    audioFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Audio feliratok kinyerése**

Ez a példa exportálja az első dián lévő audio kerethez csatolt minden felirat sávot. A [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getBinaryData--) által visszaadott bájtokat egy WebVTT fájlba írja, és a [getCaptionId](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getCaptionId--) által visszaadott azonosítót használja fájlnévként, hogy minden sáv külön fájlként kerüljön ki.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            Path output = Paths.get(track.getCaptionId() + ".vtt");
            Files.write(output, track.getBinaryData());
        }
    }
} finally {
    presentation.dispose();
}
```

### **Audio feliratok eltávolítása**

Használd a [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) vagy [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#removeAt-int-) metódust egy egyedi sáv törléséhez. A példa a [clear](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#clear--) segítségével eltávolítja az összes feliratot az első audio keretből az első dián, miközben megőrzi a klipet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Sor keresése audio feliratokban**

Az első dián lévő audio feliratokban egy sor megtalálásához keresd a [getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) által visszaadott szöveget a memóriában. Egy egyszerű szöveges WebVTT cue-ban az idővonal sort `-->` tartalmazza, a felirat sorok ezt követik, és egy üres sor zárja a cue-t. Ez a példa kiírja a sáv címkéjét és minden olyan feliratsort, amely „café” szót tartalmaz.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            boolean inCue = false;
            String captions = track.getDataAsString();
            for (String line : captions.split("\\R")) {
                if (line.isEmpty()) {
                    inCue = false;
                } else if (line.contains("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase(Locale.ROOT).contains("café")) {
                    System.out.println(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Audio kinyerése**

Egy diákátmenetnek saját hangja lehet. A lekéréshez hívd a [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSound--) metódust a diákátmeneten. A példa a [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) által visszaadott bájtokat használja, és kiírja a bájtok számát. Ha az első diáknak nincs átmeneti hangja, akkor egy üzenetet ír ki.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioSlide.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudio sound = slide.getSlideShowTransition().getSound();
    if (sound != null) {
        byte[] audioData = sound.getBinaryData();
        System.out.println("Transition sound: " + audioData.length + " bytes.");
    } else {
        System.out.println("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Újra felhasználhatom ugyanazt az audio klipet több dián anélkül, hogy megdupláznám?**

Igen. A klipet egyszer add hozzá a prezentáció [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) gyűjteményéhez, és minden diához a [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) ugyanazt az audio objektumot adod át.

**Lecserélhetem egy meglévő audio keret hangját?**

Igen. A hivatkozott hang esetén használd a [setLinkPathLong](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) metódust az új fájlra mutatáshoz. Beágyazott hang esetén válassz egy másik klipet a prezentáció audio gyűjteményéből a [setEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) segítségével. Mindkét módszer megőrzi a meglévő keretet.

**A vágás módosítja a prezentációban tárolt audio adatot?**

Nem. A [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) és a [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) a lejátszási határokat állítja be. A teljes klip továbbra is lekérhető a [getEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getEmbeddedAudio--) segítségével.