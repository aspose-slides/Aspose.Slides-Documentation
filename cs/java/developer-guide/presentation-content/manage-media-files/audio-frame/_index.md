---
title: Správa audia v prezentacích pomocí Javy
linktitle: Audio rámeček
type: docs
weight: 10
url: /cs/java/audio-frame/
keywords:
- audio
- audio rámeček
- náhled
- přidat audio
- vlastnosti audia
- možnosti audia
- extrahovat audio
- Java
- Aspose.Slides
description: "Vytvořte a ovládejte audio rámečky v Aspose.Slides pro Java — příklady kódu pro vložení, ořezání, smyčkování a konfiguraci přehrávání v prezentacích PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s audio rámečky v Aspose.Slides. Ukazuje, jak přidat vložený audio soubor do snímků, přizpůsobit náhled audio rámce, nakonfigurovat možnosti přehrávání jako hlasitost, smyčkování, skrytí, ořezávání a dobu prolínání a jak extrahovat audio použité v přechodech prezentace.

## **Vytvoření audio rámců**

Aspose.Slides pro Java umožňuje přidávat audio soubory do snímků. Audio soubory jsou do snímků vloženy jako audio rámečky. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Načtěte proud audio souboru, který chcete vložit do snímku.
4. Přidejte vložený audio rámec (obsahující audio soubor) do snímku.
5. Nastavte [PlayMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/AudioPlayModePreset) a `Volume`, které jsou vystaveny objektem [IAudioFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAudioFrame).
6. Uložte upravenou prezentaci.

Tento Java kód ukazuje, jak přidat vložený audio rámec do snímku:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation();
try {
    // Získá první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Načte WAV zvukový soubor do proudu
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Přidá audio rámec
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Nastaví režim přehrávání a hlasitost audia
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Zapíše soubor PowerPoint na disk
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Změna náhledu audio rámce**

Když přidáte audio soubor do prezentace, audio se zobrazí jako rámec se standardním výchozím obrázkem (viz obrázek v následující sekci). Změníte náhledový obrázek audio rámce (nastavte vámi preferovaný obrázek).

Tento Java kód ukazuje, jak změnit náhled audio rámce nebo preview image:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidá audio rámec na snímek se zadanou pozicí a rozměry.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Přidá obrázek do zdrojů prezentace.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Nastaví obrázek pro audio rámec.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Uloží upravenou prezentaci na disk
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Změna možností přehrávání audio**

Aspose.Slides pro Java umožňuje měnit možnosti, které řídí přehrávání nebo vlastnosti audio souboru. Například můžete upravit hlasitost audio, nastavit audio k přehrávání ve smyčce nebo dokonce skrýt ikonu audio.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/AudioFrame) properties:

- **Start** rozbalovací seznam odpovídá metodě [AudioFrame.setPlayMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/audioframe/#setPlayMode-int-)
- **Volume** odpovídá metodě [AudioFrame.setVolume](https://reference.aspose.com/slides/cs/java/com.aspose.slides/audioframe/#setVolume-int-)
- **Play Across Slides** odpovídá metodě [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-)
- **Loop until Stopped** odpovídá metodě [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-)
- **Hide During Show** odpovídá metodě [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/cs/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-)
- **Rewind after Playing** odpovídá metodě [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/cs/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-)

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/AudioFrame) properties:

- **Fade In** odpovídá metodě [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/cs/java/com.aspose.slides/audioframe/#setFadeInDuration-float-)
- **Fade Out** odpovídá metodě [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/cs/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-)
- **Trim Audio Start Time** odpovídá metodě [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/audioframe/#setTrimFromStart-float-)
- **Trim Audio End Time** hodnota se rovná délce audio minus hodnota metody [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/cs/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-)

Ovládací prvek **Volume** v panelu audio v PowerPointu odpovídá metodě [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Umožňuje změnit hlasitost audio jako procento.

Takto změníte možnosti přehrávání audio:

1. [Vytvořit](#create-audio-frame) nebo získat Audio Frame.
2. Nastavte nové hodnoty pro vlastnosti Audio Frame, které chcete upravit.
3. Uložte upravený PowerPoint soubor.

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Získá tvar AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Nastaví režim přehrávání na přehrání po kliknutí
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Nastaví hlasitost na nízkou
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Nastaví audio tak, aby se přehrávalo napříč snímky
    audioFrame.setPlayAcrossSlides(true);

    // Zakáže smyčku pro audio
    audioFrame.setPlayLoopMode(false);

    // Skryje AudioFrame během předvádění
    audioFrame.setHideAtShowing(true);

    // Přetočí audio na začátek po přehrání
    audioFrame.setRewindAudio(true);

    // Uloží soubor PowerPoint na disk
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Tento Java příklad ukazuje, jak přidat nový audio rámec s vloženým audio, oříznout jej a nastavit doby prolínání:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Nastaví počáteční posun ořezu na 1,5 sekundy
    audioFrame.setTrimFromStart(1500f);
    // Nastaví koncový posun ořezu na 2 sekundy
    audioFrame.setTrimFromEnd(2000f);

    // Nastaví dobu trvání fade-in na 200 ms
    audioFrame.setFadeInDuration(200f);
    // Nastaví dobu trvání fade-out na 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Následující ukázka kódu ukazuje, jak získat audio rámec s vloženým audio a nastavit jeho hlasitost na 85 %:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Získá tvar audio rámečku
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Nastaví hlasitost audia na 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Správa titulků audio**

Aspose.Slides umožňuje přidávat uzavřené titulky k audio rámci pomocí metody [getCaptionTracks](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) . Tato metoda vrací [ICaptionsCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icaptionscollection/), což umožňuje přidávat WebVTT titulkové stopy, procházet existující stopy a odstraňovat je podle potřeby.

### **Přidání audio titulků**

Použijte metodu [getCaptionTracks](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) k připojení jedné nebo více titulkových stop k audio rámci. V následujícím příkladu je audio soubor přidán do snímku a poté je nová titulková stopa načtena ze souboru `.vtt`.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Přidejte novou titulkovou stopu ze souboru WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Extrahování audio titulků**

Můžete procházet titulkové stopy spojené s audio rámcem a uložit je jako soubory `.vtt`. Každá titulková stopa poskytuje svá binární data a jedinečný identifikátor, který může být použit při exportu titulků.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Uložit titulkovou stopu jako soubor .vtt.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

### **Odstranění audio titulků**

Pro odstranění titulků z audio rámce použijte metody poskytované v [ICaptionsCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icaptionscollection/), například [clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), nebo [removeAt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icaptionscollection/#removeAt-int-). Následující příklad odstraňuje všechny titulkové stopy z audio rámce.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Odstraňuje všechny titulkové stopy z audio rámce.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extrahování audio**

Aspose.Slides pro Java umožňuje extrahovat zvuk použité v přechodech prezentace. Například můžete extrahovat zvuk použitý v konkrétním snímku.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) a načtěte prezentaci obsahující audio.
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přistupte k [slideshow transitions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) pro snímek.
4. Extrahujte zvuk v podobě bajtových dat.

```java
// Vytvoří instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Přistoupí k požadovanému snímku
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Získá efekty přechodu prezentace pro snímek
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // Extrahuje zvuk do pole bajtů
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Mohu použít stejný audio soubor na více snímcích, aniž bych zvětšil velikost souboru?**

Ano. Přidejte audio jednou do sdílené [audio collection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getAudios--) prezentace a vytvořte další audio rámečky, které odkazují na tuto existující položku. Tím se zabrání duplikaci mediálních dat a velikost prezentace zůstane pod kontrolou.

**Mohu nahradit zvuk v existujícím audio rámečku, aniž bych znovu vytvářel tvar?**

Ano. Pro propojený zvuk aktualizujte [link path](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) tak, aby ukazoval na nový soubor. Pro vložený zvuk vyměňte objekt [embedded audio](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) za jiný z [audio collection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getAudios--) prezentace. Formátování rámce a většina nastavení přehrávání zůstane beze změny.

**Mění ořezávání podkladová audio data uložená v prezentaci?**

Ne. Ořezávání upravuje pouze hranice přehrávání. Originální audio bajty zůstávají nedotčeny a jsou přístupné přes vložené audio nebo audio kolekci prezentace.