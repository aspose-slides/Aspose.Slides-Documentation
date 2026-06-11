---
title: Hantera ljud i presentationer på Android
linktitle: Ljudram
type: docs
weight: 10
url: /sv/androidjava/audio-frame/
keywords:
- ljud
- ljudram
- miniatyr
- lägga till ljud
- ljudegenskaper
- ljudalternativ
- extrahera ljud
- Android
- Java
- Aspose.Slides
description: "Skapa och kontrollera ljudramar i Aspose.Slides för Android—Java‑exempel för att bädda in, trimma, loopa och konfigurera uppspelning i PPT-, PPTX- och ODP‑presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med ljudramar i Aspose.Slides. Den visar hur man lägger till inbäddat ljud i bilder, anpassar ljudramens miniatyr, konfigurerar uppspelningsalternativ som volym, loopning, dölja, trimning och toningslängder, och extraherar ljud som används i bildspelsövergångar.

## **Skapa ljudramar**
Aspose.Slides för Android via Java låter dig lägga till ljudfiler i bilder. Ljudfilerna bäddas in i bilder som ljudramar.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Läs in ljudfilströmmen som du vill bädda in i bilden.
4. Lägg till den inbäddade ljudramen (som innehåller ljudfilen) till bilden.
5. Ställ in [PlayMode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/AudioPlayModePreset) och `Volume` som exponeras av objektet [IAudioFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAudioFrame).
6. Spara den modifierade presentationen.

Denna Java-kod visar hur du lägger till en inbäddad ljudram i en bild:

```java
// Instansierar en Presentation-klass som representerar en presentationsfil
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Laddar wav-ljudfilen till en ström
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Lägger till ljudramen
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Ställer in uppspelningsläge och volym för ljudet
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Skriver PowerPoint-filen till disk
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ändra ljudramens miniatyr**

När du lägger till en ljudfil i en presentation visas ljudet som en ram med en standardstandardbild (se bilden i avsnittet nedan). Du kan ändra ljudramens förhandsbild (ange din föredragna bild).

Denna Java-kod visar hur du ändrar en ljudramens miniatyr eller förhandsbild:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägger till en ljudram på bilden med en specificerad position och storlek.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Lägger till en bild i presentationens resurser.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Ställer in bilden för ljudramen.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Sparar den ändrade presentationen till disk
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ändra ljuduppspelningsalternativ**

Aspose.Slides för Android via Java låter dig ändra alternativ som styr ett ljüds uppspelning eller egenskaper. Till exempel kan du justera ett ljüds volym, sätta ljüdet på loop eller till och med dölja ljüdikonen.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/AudioFrame) properties:

- **Start**-rullgardinslistan motsvarar egenskapen [AudioFrame.PlayMode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- **Volym** motsvarar egenskapen [AudioFrame.Volume](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/AudioFrame#getVolume--) 
- **Spela över bilder** motsvarar egenskapen [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- **Loopa tills stoppad** motsvarar egenskapen [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 
- **Dölj under presentation** motsvarar egenskapen [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 
- **Spola tillbaka efter uppspelning** motsvarar egenskapen [AudioFrame.RewindAudio](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/audioframe/) properties:

- **Tona in** motsvarar egenskapen [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 
- **Tona ut** motsvarar egenskapen [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 
- **Trimma ljud starttid** motsvarar egenskapen [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 
- **Trimma ljud sluttid** värdet är lika med ljudets varaktighet minus värdet av egenskapen [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 

PowerPoint **volymkontroll** på ljudpanel motsvarar egenskapen [AudioFrame.VolumeValue](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) . Den låter dig ändra ljudvolymen i procent.

Så här ändrar du ljuduppspelningsalternativen:

1. [Skapa](#create-audio-frame) eller hämta Audio Frame.
2. Ange nya värden för de Audio Frame‑egenskaper du vill justera.
3. Spara den modifierade PowerPoint‑filen.

Denna Java-kod demonstrerar en operation där ljudalternativen justeras:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Hämtar AudioFrame-formen
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Ställer in uppspelningsläget till att spela vid klick
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Ställer in volymen till Låg
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Ställer in ljudet att spela över bilder
    audioFrame.setPlayAcrossSlides(true);

    // Inaktiverar loopning för ljudet
    audioFrame.setPlayLoopMode(false);

    // Döljer AudioFrame under bildspelet
    audioFrame.setHideAtShowing(true);

    // Spolar tillbaka ljudet till början efter uppspelning
    audioFrame.setRewindAudio(true);

    // Sparar PowerPoint-filen till disk
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Detta Java‑exempel visar hur man lägger till en ny ljudram med inbäddat ljud, trimmar den och anger toningslängderna:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Ställer in trimningens startoffset till 1,5 sekunder
    audioFrame.setTrimFromStart(1500f);
    // Ställer in trimningens slutoffset till 2 sekunder
    audioFrame.setTrimFromEnd(2000f);

    // Ställer in toningens intagslängd till 200 ms
    audioFrame.setFadeInDuration(200f);
    // Ställer in toningens uttoningslängd till 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Följande kodexempel visar hur man hämtar en ljudram med inbäddat ljud och sätter dess volym till 85 %:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Hämtar en ljudramform
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Ställer in ljudvolymen till 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Hantera ljudtextning**

Aspose.Slides låter dig lägga till stängda bildtexter till en ljudram via metoden [getCaptionTracks](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) . Denna metod returnerar en [ICaptionsCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icaptionscollection/), som låter dig lägga till WebVTT‑textspår, iterera genom befintliga spår och ta bort dem vid behov.

**Lägg till ljudtextning**

Använd metoden [getCaptionTracks](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) för att bifoga ett eller flera textspår till en ljudram. I följande exempel läggs en ljudfil till en bild och därefter laddas ett nytt textspår från en `.vtt`‑fil.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Lägg till ett nytt textspår från en WebVTT-fil.
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Extrahera ljudtextning**

Du kan iterera genom de textspår som är associerade med en ljudram och spara dem som `.vtt`‑filer. Varje textspår exponerar sin binära data och unika identifierare, vilket kan användas vid export av textning.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Spara textspåret som en .vtt-fil.
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

**Ta bort ljudtextning**

För att ta bort textning från en ljudram, använd metoderna som tillhandahålls av [ICaptionsCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icaptionscollection/), såsom [clear](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), eller [removeAt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-). Följande exempel tar bort alla textspår från en ljudram.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Ta bort alla textspår från ljudramen.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extrahera ljud**

Aspose.Slides för Android via Java låter dig extrahera ljudet som används i bildspelsövergångar. Till exempel kan du extrahera ljudet som används i en specifik bild.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) och läs in presentationen som innehåller ljudet.
2. Hämta den relevanta bildens referens via dess index.
3. Åtkomst till [slideshow transitions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) för bilden.
4. Extrahera ljudet i byte‑data.

Denna kod i Java visar hur du extraherar ljudet som används i en bild:

```java
// Instansierar en Presentation-klass som representerar en presentationsfil
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Hämtar den önskade bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hämtar bildspelsövergångseffekterna för bilden
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Extraherar ljudet i byte array
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan jag återanvända samma ljudresurs på flera bilder utan att öka filstorleken?**

Ja. Lägg till ljudet en gång i presentationens delade [audio collection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getAudios--) och skapa ytterligare ljudramar som refererar till den befintliga resursen. Detta undviker duplicering av mediadata och håller presentationens storlek under kontroll.

**Kan jag byta ut ljudet i en befintlig ljudram utan att återskapa formen?**

Ja. För ett länkat ljud, uppdatera [link path](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) så att det pekar på den nya filen. För ett inbäddat ljud, byt ut det [embedded audio](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-)‑objektet mot ett annat från presentationens [audio collection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getAudios--). Ramens formatering och de flesta uppspelningsinställningar förblir intakta.

**Ändrar trimning den underliggande ljuddata som lagras i presentationen?**

Nej. Trimning justerar endast uppspelningsgränserna. De ursprungliga ljudbytarna förblir orörda och kan nås via det inbäddade ljudet eller presentationens ljudsamling.