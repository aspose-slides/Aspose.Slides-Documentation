---
title: Audio keretek kezelése prezentációkban Androidon
linktitle: Audio keret
type: docs
weight: 10
url: /hu/androidjava/audio-frame/
keywords:
- hang
- audio keret
- bélyegkép
- hang hozzáadása
- hang tulajdonságok
- hang beállítások
- hang kinyerése
- Android
- Java
- Aspose.Slides
description: "Beágyazza a hangot a diáknak, megváltoztatja a hang ikont, konfigurálja a lejátszást, kezeli a WebVTT feliratokat, és kinyeri a diák áttűnési hangjait az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

Az audio keret lehetővé teszi, hogy hangot játsszon le egy dián. Az Aspose.Slides for Android via Java segítségével beágyazhat egy hangklipet, kiválaszthatja azt ábrázoló képet, szabályozhatja a lejátszást, és feliratokat csatolhat. Szintén lekérdezhet egy diánkénti áttűnéshez rendelt hangot.

## **Audio keretek létrehozása**

Használja a [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) metódust, hogy beágyazzon egy helyi hangklipet az első diára. Az első két koordináta a keret pozícióját határozza meg a dián, a következő két érték a szélességét és magasságát állítja be, mind pontban. Ez a példa meghívja a [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) metódust a klip automatikus indításához, és meghívja a [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) metódust a hangos előre beállított érték kiválasztásához.

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

Alapértelmezés szerint egy audio keret a hangszóró ikont jeleníti meg. Egy egyéni bélyegkép megjelenítéséhez adjon hozzá egy képet a prezentációhoz a [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) metódussal, és állítsa be a keret képére a [setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-) metódussal. A példa egy JPEG-et használ bélyegképként a beágyazott hangkliphez.

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

A PowerPoint **Audio Options** vezérlői határozzák meg, mikor indul a klip, milyen hangos, és hogyan viselkedik a diavetítés során.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint vezérlő | Aspose.Slides for Android via Java metódus |
| --- | --- |
| Indítás | [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Hangerő előbeállítás | [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Lejátszás diákon át | [setPlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Ismétlés leállásig | [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Elrejtés a bemutató alatt | [setHideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Visszatekerés lejátszás után | [setRewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Fokozatos beúszás | [setFadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Fokozatos elhalás | [setFadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Hang levágása a kezdeti időtől | [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Hang levágása a végső időtől | [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Hangerő csúszka | [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

A példa megtalálja az első audio keretet az első dián, meghívja a [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) metódust a lejátszás kattintásra történő indításához, és kiválasztja az alacsony hangerő előbeállítást. A klip a diákon át folytatódik, a ciklus le van tiltva. Az ikon a bemutató során rejtve marad, és a klip lejátszás után visszatekeredik.

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

3,5 másodpercnél hosszabb klip esetén ez a példa kihagyja az első 1,5 másodpercet és az utolsó 2 másodpercet. A [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) a végéről elhagyandó időtartamot veszi. A PowerPoint-ban látható befejezési idő eléréséhez vonja ki ezt az eltolást a teljes klip időtartamából. A levágott klip 200 ms alatt fokozatosan beúszik és 500 ms alatt fokozatosan elhal. Mind a négy metódus értékét milliszekundumban várja.

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

A lejátszási hangerő adott százalékra állításához használja a [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) metódust. Ez a példa az első dián lévő első audio keretet 85 %-ra állítja be.

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

Minden audio keret hozzáférést biztosít a feliratpályáihoz a [getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) metóduson keresztül. A gyűjteményt használhatja WebVTT feliratok csatolására a kliphez, meglévő pályák exportálására vagy eltávolítására.

### **Audio feliratok hozzáadása**

A példa beágyaz egy audio klipet az első diára, és a [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) metódust használja egy helyi WebVTT pálya csatolásához. Az első argumentum adja a pálya címkéjét, a második pedig a időzített feliratokat tartalmazó fájlt határozza meg.

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

Ez a példa exportálja az első dián lévő audio kerethez csatolt minden feliratpályát. A [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getBinaryData--) által visszaadott bájtokat egy WebVTT fájlba írja, és a [getCaptionId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getCaptionId--) által visszaadott azonosítót használja fájlnéven, hogy minden pálya külön kimenettel rendelkezzen.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            try (FileOutputStream output = new FileOutputStream(track.getCaptionId() + ".vtt")) {
                output.write(track.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

### **Audio feliratok eltávolítása**

Használja a [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) vagy a [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) metódust egyedi pálya törléséhez. A példa a [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#clear--) metódust használja az első dián lévő első audio keret összes feliratának eltávolításához, miközben a klipet megőrzi.

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

### **Sor keresése az audio feliratokban**

Az első dián lévő audio feliratok sorának megtalálásához keresse meg a memóriában a [getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) által visszaadott szöveget. Egy egyszerű szöveges WebVTT jelben az idővonal `-->` karaktereket tartalmaz, a feliratsorok ezt követik, és egy üres sor zárja a jelzést. Ez a példa kiírja a pálya címkét és minden feliratsort, amely a “café” szót tartalmazza.

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
            for (String line : captions.split("\\r\\n|\\r|\\n")) {
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

Egy diátmenetnek saját hangja lehet. Ennek lekérdezéséhez hívja meg a [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSound--) metódust a diátmeneten. A példa a [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) által visszaadott bájtokat használja, és kiírja a bájtok számát. Ha az első diához nincs áttűnési hang, akkor helyette egy üzenetet ír ki.

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

**Újra felhasználhatom ugyanazt a hangklipet több dián anélkül, hogy duplikálnám?**

Igen. Adja hozzá a klipet egyszer a prezentáció [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) gyűjteményéhez, és minden dián adja át ugyanazt az audio objektumot az [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) metódusnak.

**Lecserélhetem egy meglévő audio keret hangját?**

Igen. Hivatkozott hang esetén használja a [setLinkPathLong](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) metódust a helyettesítő fájlra mutatáshoz. Beágyazott hang esetén válasszon egy másik klipet a prezentáció audio gyűjteményéből a [setEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) metódussal. Mindkét megközelítés megőrzi a meglévő keretet.

**A vágás megváltoztatja a prezentációban tárolt audio adatot?**

Nem. A [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) és a [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) a lejátszási határokat állítják be. A teljes klipet továbbra is lekérheti a [getEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getEmbeddedAudio--) metódussal.