---
title: Správa zvuku v prezentacích pomocí JavaScriptu
linktitle: Audio rámeček
type: docs
weight: 10
url: /cs/nodejs-java/audio-frame/
keywords:
- zvuk
- audio rámeček
- miniatura
- přidat zvuk
- vlastnosti zvuku
- možnosti zvuku
- extrahovat zvuk
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvářejte a ovládejte audio rámečky v Aspose.Slides pro Node.js — příklady pro vložení, ořezání, opakování a konfiguraci přehrávání v prezentacích PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s audio rámečky v Aspose.Slides. Ukazuje, jak přidat vložený zvuk do snímků, přizpůsobit miniaturu audio rámečku, nakonfigurovat možnosti přehrávání, jako je hlasitost, opakování, skrytí, ořezávání a trvání přechodů, a extrahovat zvuk použitý v přechodech prezentace.

## **Vytvoření audio rámečků**

Aspose.Slides for Node.js via Java vám umožňuje přidávat zvukové soubory do snímků. Zvukové soubory jsou vloženy do snímků jako audio rámečky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Načtěte stream zvukového souboru, který chcete vložit do snímku.
4. Přidejte vložený audio rámeček (obsahující zvukový soubor) na snímek.
5. Nastavte [PlayMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AudioPlayModePreset) a `Volume` vystavené objektem [AudioFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AudioFrame).
6. Uložte upravenou prezentaci.

Tento JavaScriptový kód ukazuje, jak přidat vložený audio rámeček na snímek:

```javascript
// Vytvoří instanci třídy Presentation, která představuje soubor prezentace
const pres = new aspose.slides.Presentation();
try {
    // Získá první snímek
    const sld = pres.getSlides().get_Item(0);
    // Načte wav zvukový soubor do proudu
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Přidá audio rámeček
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Nastaví režim přehrávání a hlasitost zvuku
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // Zapíše soubor PowerPoint na disk
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Změna miniatury audio rámečku**

Když do prezentace přidáte zvukový soubor, zvuk se zobrazí jako rámeček se standardním výchozím obrázkem (viz obrázek v následující sekci). Můžete změnit náhledový obrázek audio rámečku (nastavte svůj preferovaný obrázek).

Tento JavaScriptový kód ukazuje, jak změnit miniaturu nebo náhledový obrázek audio rámečku:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Přidá audio rámec na snímek s určenou pozicí a velikostí.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Přidá obrázek do zdrojů prezentace.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Nastaví obrázek pro audio rámec.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Uloží upravenou prezentaci na disk
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Změna možností přehrávání zvuku**

Aspose.Slides for Node.js via Java vám umožňuje měnit možnosti, které řídí přehrávání zvuku nebo jeho vlastnosti. Například můžete upravit hlasitost zvuku, nastavit opakování přehrávání nebo dokonce skrýt ikonu zvuku.

Panel **Audio Options** v Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, které odpovídají vlastnostem Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/):
- **Start** rozbalovací seznam odpovídá metodě [AudioFrame.setPlayMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** odpovídá metodě [AudioFrame.setVolume](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** odpovídá metodě [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** odpovídá metodě [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** odpovídá metodě [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** odpovídá metodě [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/#setRewindAudio)

PowerPoint **Editing** možnosti, které odpovídají vlastnostem Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/):

- **Fade In** odpovídá metodě [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** odpovídá metodě [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** odpovídá metodě [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** hodnota se rovná délce zvuku minus hodnota metody [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)

Ovládací prvek **Volume controll** na panelu ovládání zvuku odpovídá metodě [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Umožňuje změnit hlasitost zvuku v procentech.

Takto měníte možnosti přehrávání zvuku:

1. [Сreate](#create-audio-frame) nebo získejte Audio Frame.
2. Nastavte nové hodnoty pro vlastnosti Audio Frame, které chcete upravit.
3. Uložte upravený soubor PowerPoint.

Tento JavaScriptový kód demonstruje operaci, při které jsou upraveny možnosti zvuku:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Získá tvar AudioFrame
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Nastaví režim přehrávání na přehrání po kliknutí
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Nastaví hlasitost na Nízká
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Nastaví audio tak, aby se přehrávalo napříč snímky
    audioFrame.setPlayAcrossSlides(true);
    // Zakáže opakování pro audio
    audioFrame.setPlayLoopMode(false);
    // Skryje AudioFrame během prezentace
    audioFrame.setHideAtShowing(true);
    // Přetočí audio na začátek po přehrání
    audioFrame.setRewindAudio(true);
    // Uloží soubor PowerPoint na disk
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Tento JavaScriptový příklad ukazuje, jak přidat nový audio rámeček s vloženým zvukem, oříznout jej a nastavit trvání přechodů:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Nastaví počáteční offset ořezu na 1,5 sekundy
    audioFrame.setTrimFromStart(1500);
    // Nastaví koncový offset ořezu na 2 sekundy
    audioFrame.setTrimFromEnd(2000);

    // Nastaví dobu fade-in na 200 ms
    audioFrame.setFadeInDuration(200);
    // Nastaví dobu fade-out na 500 ms
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Následující ukázka kódu ukazuje, jak získat audio rámeček s vloženým zvukem a nastavit jeho hlasitost na 85 %:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Získá tvar audio rámce
    const audioFrame = slide.getShapes().get_Item(0);

    // Nastaví hlasitost zvuku na 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Správa titulků zvuku**

Aspose.Slides vám umožňuje přidávat uzavřené titulky k audio rámečku pomocí metody [getCaptionTracks](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Tato metoda vrací [CaptionsCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/captionscollection/), která vám umožní přidávat WebVTT titulky, iterovat přes existující stopy a odstraňovat je podle potřeby.

**Přidání titulků zvuku**

Použijte metodu [getCaptionTracks](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) k připojení jedné nebo více titulkových stop k audio rámečku. V následujícím příkladu je zvukový soubor přidán na snímek a následně je načtena nová titulková stopa ze souboru `.vtt`.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Přidá novou titulkovou stopu ze souboru WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Extrahování titulků zvuku**

Můžete iterovat přes titulkové stopy spojené s audio rámečkem a uložit je jako soubory `.vtt`. Každá titulková stopa poskytuje svá binární data a jedinečný identifikátor, který lze použít při exportu titulků.

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
                // Uloží titulkovou stopu jako soubor .vtt.
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

**Odstranění titulků zvuku**

Chcete-li odstranit titulky z audio rámečku, použijte metody poskytované [CaptionsCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/captionscollection/), jako jsou [clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/captionscollection/#remove) nebo [removeAt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/captionscollection/#removeAt). Následující příklad odstraňuje všechny titulkové stopy z audio rámečku.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // typ: aspose.slides.AudioFrame

    // Odstraní všechny titulkové stopy z audio rámce.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extrahování zvuku**

Aspose.Slides for Node.js via Java vám umožňuje extrahovat zvuk používaný v přechodech prezentace. Například můžete extrahovat zvuk použitého v konkrétním snímku.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) a načtěte prezentaci obsahující zvuk.
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přistupte k [slideshow transitions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) pro snímek.
4. Extrahujte zvuk v bajtových datech.

Tento JavaScriptový kód ukazuje, jak extrahovat zvuk použitý v snímku:

```javascript
// Vytvoří instanci třídy Presentation, která představuje soubor prezentace
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Přistoupí k požadovanému snímku
    const slide = pres.getSlides().get_Item(0);
    // Získá efekty přechodu prezentace pro snímek
    const transition = slide.getSlideShowTransition();
    // Extrahuje zvuk do pole bajtů
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Mohu opakovaně použít stejný zvukový prostředek na více snímcích, aniž by se zvětšila velikost souboru?**

Ano. Přidejte zvuk jednou do sdílené [audio collection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getaudios/) prezentace a vytvořte další audio rámečky, které odkazují na tento existující prostředek. Tím se zabrání duplikaci mediálních dat a velikost prezentace zůstane pod kontrolou.

**Mohu nahradit zvuk v existujícím audio rámečku, aniž bych znovu vytvářel tvar?**

Ano. Pro propojený zvuk aktualizujte [link path](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) tak, aby ukazoval na nový soubor. Pro vložený zvuk vyměňte objekt [embedded audio](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) za jiný z [audio collection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getaudios/) prezentace. Formátování rámečku a většina nastavení přehrávání zůstane nedotčena.

**Mění ořezávání podkladová data zvuku uložená v prezentaci?**

Ne. Ořezávání upravuje pouze hranice přehrávání. Původní bajty zvuku zůstávají nedotčeny a jsou přístupné prostřednictvím vloženého zvuku nebo audio kolekce prezentace.