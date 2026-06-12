---
title: Správa zvuku v prezentacích na Androidu
linktitle: Audio Rámec
type: docs
weight: 10
url: /cs/androidjava/audio-frame/
keywords:
- zvuk
- audio rámec
- miniatura
- přidat zvuk
- vlastnosti zvuku
- možnosti zvuku
- extrahovat zvuk
- Android
- Java
- Aspose.Slides
description: "Vytvořte a ovládejte audio rámce v Aspose.Slides pro Android — příklady v Javě pro vložení, ořezávání, smyčkování a nastavení přehrávání v prezentacích PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s audio rámci v Aspose.Slides. Ukazuje, jak přidat vložený zvuk do snímků, upravit miniaturu audio rámce, nastavit možnosti přehrávání, jako je hlasitost, smyčkování, skrytí, ořezávání a doby přechodů, a jak extrahovat zvuk použité při přechodech prezentace.

## **Vytvoření audio rámců**
Aspose.Slides pro Android prostřednictvím Java vám umožňuje přidávat zvukové soubory do snímků. Zvukové soubory jsou do snímků vloženy jako audio rámce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Načtěte stream zvukového souboru, který chcete do snímku vložit.
4. Přidejte vložený audio rámec (obsahující zvukový soubor) do snímku.
5. Nastavte [PlayMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/AudioPlayModePreset) a `Volume` poskytované objektem [IAudioFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IAudioFrame).
6. Uložte upravenou prezentaci.

Tento Java kód ukazuje, jak přidat vložený audio rámec do snímku:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation();
try {
    // Získá první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Načte soubor zvuku wav do streamu
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Přidá audio rámec
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Nastaví režim přehrávání a hlasitost zvuku
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Zapíše soubor PowerPoint na disk
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Změna miniatury audio rámce**

Když přidáte zvukový soubor do prezentace, zvuk se zobrazí jako rámec se standardním výchozím obrázkem (viz obrázek v následující sekci). Můžete změnit náhledový obrázek audio rámce (nastavit požadovaný obrázek).

Tento Java kód ukazuje, jak změnit miniaturu nebo náhledový obrázek audio rámce:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidá audio rámec na snímek s určenou polohou a velikostí.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Přidá obrázek do prostředků prezentace.
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

## **Změna možností přehrávání zvuku**

Aspose.Slides pro Android prostřednictvím Java vám umožňuje měnit možnosti, které řídí přehrávání nebo vlastnosti zvuku. Například můžete upravit hlasitost zvuku, nastavit přehrávání ve smyčce nebo dokonce skrýt ikonu zvuku.

Panel **Audio Options** v Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, které odpovídají vlastnostem Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/AudioFrame):

- **Start** rozbalovací seznam odpovídá vlastnosti [AudioFrame.PlayMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- **Volume** odpovídá vlastnosti [AudioFrame.Volume](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/AudioFrame#getVolume--) 
- **Play Across Slides** odpovídá vlastnosti [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- **Loop until Stopped** odpovídá vlastnosti [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 
- **Hide During Show** odpovídá vlastnosti [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 
- **Rewind after Playing** odpovídá vlastnosti [AudioFrame.RewindAudio](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 

PowerPoint **Editing** možnosti, které odpovídají vlastnostem Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/audioframe/):

- **Fade In** odpovídá vlastnosti [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 
- **Fade Out** odpovídá vlastnosti [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 
- **Trim Audio Start Time** odpovídá vlastnosti [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 
- **Trim Audio End Time** hodnota se rovná délce zvuku minus hodnota [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 

PowerPoint **Volume controll** na panelu ovládání zvuku odpovídá vlastnosti [AudioFrame.VolumeValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/audioframe/#getVolumeValue--). Umožňuje změnit hlasitost zvuku v procentech.

Takto můžete změnit možnosti přehrávání zvuku:

1. [Vytvořit](#create-audio-frame) nebo získat audio rámec.
2. Nastavte nové hodnoty vlastností audio rámce, které chcete upravit.
3. Uložte upravený soubor PowerPoint.

Tento Java kód demonstruje operaci, při níž jsou upraveny možnosti zvuku:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Získá tvar AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Nastaví režim přehrávání na přehrání po kliknutí
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Nastaví hlasitost na Nízká
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Nastaví přehrávání zvuku napříč snímky
    audioFrame.setPlayAcrossSlides(true);

    // Zakáže smyčku pro zvuk
    audioFrame.setPlayLoopMode(false);

    // Skryje AudioFrame během prezentace
    audioFrame.setHideAtShowing(true);

    // Přetočí zvuk na začátek po přehrání
    audioFrame.setRewindAudio(true);

    // Uloží soubor PowerPoint na disk
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Tento Java příklad ukazuje, jak přidat nový audio rámec s vloženým zvukem, ořezat jej a nastavit doby přechodů:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Nastaví počáteční offset ořezu na 1,5 sekundy
    audioFrame.setTrimFromStart(1500f);
    // Nastaví koncový offset ořezu na 2 sekundy
    audioFrame.setTrimFromEnd(2000f);

    // Nastaví dobu fade-in na 200 ms
    audioFrame.setFadeInDuration(200f);
    // Nastaví dobu fade-out na 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Následující ukázka kódu ukazuje, jak načíst audio rámec s vloženým zvukem a nastavit jeho hlasitost na 85 %:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Získá tvar audio rámce
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Nastaví hlasitost zvuku na 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Správa titulků zvuku**

Aspose.Slides umožňuje přidávat uzavřené titulky k audio rámci prostřednictvím metody [getCaptionTracks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--). Tato metoda vrací [ICaptionsCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptionscollection/), která umožňuje přidávat WebVTT titulkové stopy, procházet existující stopy a v případě potřeby je odstraňovat.

**Přidání titulků zvuku**

Použijte metodu [getCaptionTracks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) k připojení jedné nebo více titulkových stop k audio rámci. V následujícím příkladu je zvukový soubor přidán do snímku a poté je z `.vtt` souboru načtena nová titulková stopa.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Přidá novou titulkovou stopu ze souboru WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Extrahování titulků zvuku**

Můžete procházet titulkové stopy spojené s audio rámcem a ukládat je jako soubory `.vtt`. Každá titulková stopa zpřístupňuje svá binární data a jedinečný identifikátor, který lze použít při exportu titulků.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Uloží titulkovou stopu jako soubor .vtt.
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

**Odstranění titulků zvuku**

Pro odebrání titulků z audio rámce použijte metody poskytované rozhraním [ICaptionsCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptionscollection/), například [clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), nebo [removeAt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-). Následující příklad odstraňuje všechny titulkové stopy z audio rámce.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Odstraní všechny titulkové stopy z audio rámce.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extrahování zvuku**

Aspose.Slides pro Android prostřednictvím Java umožňuje extrahovat zvuk použitého při přechodech prezentace. Například můžete extrahovat zvuk použitý na konkrétním snímku.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) a načtěte prezentaci obsahující zvuk.
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přistupte k [slideshow transitions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) pro daný snímek.
4. Extrahujte zvuk v podobě binárních dat.

Tento Java kód ukazuje, jak extrahovat zvuk použitý na snímku:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Získá požadovaný snímek
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

## **Často kladené otázky**

**Mohu znovu použít stejný zvukový soubor na více snímcích, aniž by se zvětšila velikost souboru?**

Ano. Přidejte zvuk jednou do sdílené [audio collection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getAudios--) prezentace a vytvořte další audio rámce, které odkazují na tento existující zdroj. Tím se zabrání duplikaci mediálních dat a velikost prezentace zůstane pod kontrolou.

**Mohu v existujícím audio rámci vyměnit zvuk bez nutnosti znovu vytvářet tvar?**

Ano. U propojeného zvuku aktualizujte [link path](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) tak, aby ukazoval na nový soubor. U vloženého zvuku vyměňte objekt [embedded audio](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) za jiný ze [audio collection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getAudios--) prezentace. Formátování rámce a většina nastavení přehrávání zůstane zachována.

**Mění ořezávání podkladová zvuková data uložená v prezentaci?**

Ne. Ořezávání upravuje pouze hranice přehrávání. Původní zvukové bajty zůstávají nedotčeny a jsou přístupné přes vložený zvuk nebo kolekci zvuků prezentace.