---
title: Hang kezelése prezentációkban JavaScript használatával
linktitle: Hangkeret
type: docs
weight: 10
url: /hu/nodejs-java/audio-frame/
keywords:
- hang
- hangkeret
- bélyegkép
- hang hozzáadása
- hang tulajdonságok
- hang beállítások
- hang kinyerése
- Node.js
- JavaScript
- Aspose.Slides
description: "Hangkeretek létrehozása és vezérlése az Aspose.Slides for Node.js-ben – példák a beágyazásra, vágásra, ciklikus lejátszásra és a lejátszás beállítására PPT, PPTX és ODP prezentációkban."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozzunk hangkeretekkel az Aspose.Slides-ben. Bemutatja, hogyan adhatunk beágyazott hangot a diákhoz, hogyan testreszabhatjuk a hangkeret bélyegképét, hogyan konfigurálhatjuk a lejátszási beállításokat, például a hangerőt, a ciklikus lejátszást, a rejtést, a vágást és a halványulási időket, valamint hogyan nyerhetünk ki hangot a diavetítés átmeneteihez.

## **Hangkeretek létrehozása**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy hangfájlokat adjunk a diákhoz. A hangfájlok beágyazott audio keretként kerülnek a diákra.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze be a dia hivatkozását az indexe alapján.
3. Töltse be a beágyazni kívánt hangfájl adatfolyamát a diára.
4. Adja hozzá a beágyazott audio keretet (amely a hangfájlt tartalmazza) a diához.
5. Állítsa be a [PlayMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AudioPlayModePreset) és a `Volume` értékeket, amelyeket a [AudioFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AudioFrame) objektum biztosít.
6. Mentse a módosított bemutatót.

Ez a JavaScript kód megmutatja, hogyan adjon hozzá beágyazott audio keretet egy diához:

```javascript
// Példányosít egy Presentation osztályt, amely egy prezentációs fájlt képvisel
const pres = new aspose.slides.Presentation();
try {
    // Lekéri az első diát
    const sld = pres.getSlides().get_Item(0);
    // Betölti a wav hangfájlt adatfolyamba
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Hozzáadja a hangkeretet
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Beállítja a hang lejátszási módját és hangerőét
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // A PowerPoint fájlt a lemezre írja
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hangkeret bélyegképének módosítása**

Amikor hangfájlt ad a bemutatóhoz, a hang egy keretként jelenik meg egy alapértelmezett képpel (lásd a lenti képet). Megváltoztathatja a hangkeret előnézeti képét (állítsa be a kívánt képet).

Ez a JavaScript kód megmutatja, hogyan változtassa meg egy hangkeret bélyegképét vagy előnézeti képét:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Hangkeretet ad a diára a megadott pozícióval és mérettel.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Képet ad a prezentáció erőforrásaihoz.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Beállítja a képet a hangkerethez.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // A módosított prezentációt lemezre menti
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Hang lejátszási beállításainak módosítása**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy megváltoztassa a hang lejátszását vagy tulajdonságait szabályozó beállításokat. Például állíthatja a hangerőt, beállíthatja a hang ciklikus lejátszását, vagy akár elrejtheti a hang ikont.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

A PowerPoint **Audio Options** beállítások, amelyek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/) tulajdonságainak felelnek meg:
- **Start** legördülő lista megfelel az [AudioFrame.setPlayMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/#setPlayMode) metódusnak
- **Volume** megfelel az [AudioFrame.setVolume](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/#setVolume) metódusnak
- **Play Across Slides** megfelel az [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) metódusnak
- **Loop until Stopped** megfelel az [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) metódusnak
- **Hide During Show** megfelel az [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) metódusnak
- **Rewind after Playing** megfelel az [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/#setRewindAudio) metódusnak

A PowerPoint **Editing** beállítások, amelyek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/) tulajdonságainak felelnek meg:
- **Fade In** megfelel az [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) metódusnak
- **Fade Out** megfelel az [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) metódusnak
- **Trim Audio Start Time** megfelel az [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) metódusnak
- **Trim Audio End Time** értéke megegyezik a hang időtartamával mínusz az [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) metódus értékével

A PowerPoint **Volume controll** a hangvezérlő panelen az [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/#setVolumeValue) metódusnak felel meg. Lehetővé teszi a hangerő százalékos módosítását.

Így módosíthatja a hang lejátszási beállításait:
1. [Létrehozni](#create-audio-frame) vagy szerezze be az Audio Frame-et.
2. Állítson be új értékeket a kívánt Audio Frame tulajdonságokhoz.
3. Mentse a módosított PowerPoint fájlt.

Ez a JavaScript kód egy olyan műveletet mutat be, amelyben a hang beállításait módosítják:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Lekéri a AudioFrame alakzatot
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Beállítja a lejátszási módot kattintásra
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Beállítja a hangerőt alacsonyra
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Beállítja a hangot, hogy a diákon át lejátszódjon
    audioFrame.setPlayAcrossSlides(true);
    // Letiltja a ciklus lejátszást a hangnál
    audioFrame.setPlayLoopMode(false);
    // Elrejti a AudioFrame-et a diavetítés során
    audioFrame.setHideAtShowing(true);
    // Visszatekeri a hangot a kezdéshez a lejátszás után
    audioFrame.setRewindAudio(true);
    // A PowerPoint fájlt lemezre menti
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ez a JavaScript példa megmutatja, hogyan adjon hozzá új audio keretet beágyazott hanggal, vágja meg, és állítsa be a halványulási időket:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Beállítja a vágás kezdő eltolását 1,5 másodpercre
    audioFrame.setTrimFromStart(1500);
    // Beállítja a vágás befejező eltolását 2 másodpercre
    audioFrame.setTrimFromEnd(2000);

    // Beállítja a fade-in időtartamot 200 ms-re
    audioFrame.setFadeInDuration(200);
    // Beállítja a fade-out időtartamot 500 ms-re
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

A következő kódrészlet megmutatja, hogyan szerezzen be egy beágyazott hanggal rendelkező audio keretet, és állítsa be a hangerőt 85%-ra:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Lekéri az audio keret alakzatot
    const audioFrame = slide.getShapes().get_Item(0);

    // Beállítja a hang hangerő értékét 85%-ra
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Hang feliratok kezelése**

Az Aspose.Slides lehetővé teszi, hogy a [getCaptionTracks](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) metódus segítségével zárt feliratokat adjon egy audio kerethez. Ez a metódus egy [CaptionsCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/) objektumot ad vissza, amely lehetővé teszi WebVTT felirat sávok hozzáadását, a létező sávok bejárását és szükség esetén azok eltávolítását.

### **Hang feliratok hozzáadása**

Használja a [getCaptionTracks](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) metódust, hogy egy vagy több feliratsávot csatoljon egy audio kerethez. A következő példában egy hangfájlt adnak hozzá egy diához, majd egy új feliratsávot tölt be egy `.vtt` fájlból.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Új feliratsáv hozzáadása egy WebVTT fájlból.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Hang feliratok kinyerése**

Bejárhatja az audio kerethez tartozó feliratsávokat, és elmentheti őket `.vtt` fájlokként. Minden feliratsáv elérhető bináris adatként és egyedi azonosítóval, amely a feliratok exportálásakor felhasználható.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // Mentse a feliratsávot .vtt fájlként.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

### **Hang feliratok eltávolítása**

A feliratok egy audio keretről történő eltávolításához használja a [CaptionsCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/) által biztosított módszereket, például a [clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/#remove), vagy a [removeAt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/#removeAt). A következő példa eltávolítja az összes feliratsávot egy audio keretből.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // típus: aspose.slides.AudioFrame

    // Távolítsa el az összes feliratsávot a hangkeretből.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hang kinyerése**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy kinyerje a diavetítés átmeneteihez használt hangot. Például kinyerheti egy adott dia hangját.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, és töltse be a hangot tartalmazó bemutatót.
2. Szerezze be a megfelelő dia hivatkozását az indexe alapján.
3. Érje el a dia [slideshow transitions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) beállításait.
4. Nyissa ki a hangot bájt adatként.

Ez a JavaScript kód megmutatja, hogyan nyerje ki egy dia által használt hangot:

```javascript
// Példányosít egy Presentation osztályt, amely egy prezentációs fájlt képvisel
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Eléri a kívánt diát
    const slide = pres.getSlides().get_Item(0);
    // Lekéri a dia diavetítés átmeneti effektjeit
    const transition = slide.getSlideShowTransition();
    // Kinyeri a hangot bájt tömbként
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Újra felhasználhatom ugyanazt a hangeszközt több dián anélkül, hogy megnövelném a fájlméretet?**

Igen. Adja hozzá a hangot egyszer a bemutató megosztott [audio collection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getaudios/)‑hoz, és hozzon létre további audio kereteket, amelyek hivatkoznak erre a meglévő eszközre. Ez megakadályozza a médiaadat duplikálását és a bemutató méretét kontroll alatt tartja.

**Lecserélhetem egy meglévő audio keret hangját anélkül, hogy újra létrehoznám az alakzatot?**

Igen. A hivatkozott hang esetén frissítse a [link path](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/setlinkpathlong/)‑t, hogy az új fájlra mutasson. Beágyazott hang esetén cserélje le a [embedded audio](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) objektumot egy másikra a bemutató [audio collection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getaudios/)‑ből. A keret formázása és a legtöbb lejátszási beállítás változatlan marad.

**A vágás megváltoztatja-e a bemutatóban tárolt alapul szolgáló hangadatot?**

Nem. A vágás csak a lejátszási határokat módosítja. Az eredeti hangbájtok érintetlenek maradnak, és továbbra is elérhetők a beágyazott hang vagy a bemutató audio collection segítségével.