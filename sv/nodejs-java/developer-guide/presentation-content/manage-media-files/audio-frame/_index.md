---
title: Hantera ljud i presentationer med JavaScript
linktitle: Ljudram
type: docs
weight: 10
url: /sv/nodejs-java/audio-frame/
keywords:
- ljud
- ljudram
- miniatyrbild
- lägg till ljud
- ljudegenskaper
- ljudalternativ
- extrahera ljud
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa och kontrollera ljudramar i Aspose.Slides för Node.js—exempel för att bädda in, trimma, loopa och konfigurera uppspelning i PPT-, PPTX- och ODP-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med ljudramar i Aspose.Slides. Den visar hur du lägger till inbäddat ljud i bilder, anpassar miniatyrbilden för ljudramen, konfigurerar uppspelningsalternativ såsom volym, loopning, döljande, trimning och fade‑varaktigheter, samt extraherar ljud som används i bildspelsövergångar.

## **Skapa ljudramar**

Aspose.Slides för Node.js via Java låter dig lägga till ljudfiler i bilder. Ljudfilerna bäddas in i bilder som ljudramar.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Läs in ljudfilens ström som du vill bädda in i bilden.
4. Lägg till den inbäddade ljudramen (innehållande ljudfilen) till bilden.
5. Ställ in [PlayMode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AudioPlayModePreset) och `Volume` som exponeras av objektet [AudioFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AudioFrame).
6. Spara den ändrade presentationen.

Den här JavaScript-koden visar hur du lägger till en inbäddad ljudram i en bild:

```javascript
// Instansierar en Presentation-klass som representerar en presentationsfil
const pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden
    const sld = pres.getSlides().get_Item(0);
    // Laddar wav-ljudfilen till en ström
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Lägger till ljudramen
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Ställer in uppspelningsläge och volym för ljudet
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // Skriver PowerPoint-filen till disk
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ändra miniatyrbild för ljudram**

När du lägger till en ljudfil i en presentation visas ljudet som en ram med en standardstandardbild (se bilden i avsnittet nedan). Du kan ändra ramens förhandsgranskningsbild (ange din föredragna bild).

Den här JavaScript-koden visar hur du ändrar en ljudramens miniatyr eller förhandsgranskningsbild:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Lägger till en ljudram på bilden med specificerad position och storlek.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Lägger till en bild i presentationens resurser.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Ställer in bilden för ljudramen.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Sparar den ändrade presentationen till disk
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Ändra ljuduppspelningsalternativ**

Aspose.Slides för Node.js via Java låter dig ändra alternativ som styr ett ljuds uppspelning eller egenskaper. Till exempel kan du justera ett ljuds volym, ställa in att ljudet spelas i loop, eller till och med dölja ljudikonen.

Rutan **Audio Options** i Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** som motsvarar Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/) egenskaper:
- **Start**-rullgardinslistan motsvarar metoden [AudioFrame.setPlayMode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** motsvarar metoden [AudioFrame.setVolume](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** motsvarar metoden [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** motsvarar metoden [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** motsvarar metoden [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** motsvarar metoden [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/#setRewindAudio)

PowerPoint **Editing**-alternativ som motsvarar Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/) egenskaper:
- **Fade In** motsvarar metoden [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** motsvarar metoden [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** motsvarar metoden [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** värdet motsvarar ljudets varaktighet minus värdet från metoden [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)

PowerPoint **Volume control** på ljudkontrollpanelen motsvarar metoden [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Den låter dig ändra ljudvolymen i procent.

Så här ändrar du ljuduppspelningsalternativen:
1. [Create](#create-audio-frame) eller hämta ljudramen.
2. Ställ in nya värden för de Audio Frame‑egenskaper du vill justera.
3. Spara den ändrade PowerPoint-filen.

Den här JavaScript-koden demonstrerar en operation där ett ljuds alternativ justeras:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Hämtar AudioFrame-formen
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Ställer in uppspelningsläge till att spela på klick
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Ställer in volymen till Låg
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Ställer in att ljudet spelas över bilder
    audioFrame.setPlayAcrossSlides(true);
    // Inaktiverar loopning för ljudet
    audioFrame.setPlayLoopMode(false);
    // Döljer AudioFrame under bildspelet
    audioFrame.setHideAtShowing(true);
    // Spolar tillbaka ljudet till början efter uppspelning
    audioFrame.setRewindAudio(true);
    // Sparar PowerPoint-filen till disk
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Det här JavaScript‑exemplet visar hur du lägger till en ny ljudram med inbäddat ljud, trimmar den och anger fade‑varaktigheterna:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Ställer in trimningsstartoffset till 1,5 sekunder
    audioFrame.setTrimFromStart(1500);
    // Ställer in trimningsslutoffset till 2 sekunder
    audioFrame.setTrimFromEnd(2000);

    // Ställer in fade-in-varaktighet till 200 ms
    audioFrame.setFadeInDuration(200);
    // Ställer in fade-out-varaktighet till 500 ms
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Följande kodexempel visar hur du hämtar en ljudram med inbäddat ljud och sätter dess volym till 85 %:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Hämtar en ljudram-form
    const audioFrame = slide.getShapes().get_Item(0);

    // Ställer in ljudvolymen till 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Hantera ljudundertexter**

Aspose.Slides låter dig lägga till stängda undertexter till en ljudram via metoden [getCaptionTracks](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Denna metod returnerar en [CaptionsCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/), som låter dig lägga till WebVTT‑undertextspår, iterera igenom befintliga spår och ta bort dem vid behov.

**Lägg till ljudundertexter**

Använd metoden [getCaptionTracks](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) för att bifoga ett eller flera undertextspår till en ljudram. I följande exempel läggs en ljudfil till en bild och därefter laddas ett nytt undertextspår från en `.vtt`‑fil.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Lägg till ett nytt undertextspår från en WebVTT-fil.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Extrahera ljudundertexter**

Du kan iterera igenom de undertextspår som är knutna till en ljudram och spara dem som `.vtt`‑filer. Varje undertextspår avslöjar sin binära data och unika identifierare, vilket kan användas vid export av undertexter.

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
                // Spara undertextspåret som en .vtt-fil.
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

**Ta bort ljudundertexter**

För att ta bort undertexter från en ljudram, använd metoderna som tillhandahålls av [CaptionsCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/), såsom [clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/#remove), eller [removeAt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/#removeAt). Följande exempel tar bort alla undertextspår från en ljudram.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // typ: aspose.slides.AudioFrame

    // Ta bort alla undertextspår från ljudramen.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extrahera ljud**

Aspose.Slides för Node.js via Java låter dig extrahera ljudet som används i bildspelsövergångar. Till exempel kan du extrahera ljudet som används i en specifik bild.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) och läs in presentationen som innehåller ljudet.
2. Hämta den relevanta bildens referens via dess index.
3. Få åtkomst till bildspels­övergångarna [slideshow transitions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) för bilden.
4. Extrahera ljudet som byte‑data.

Den här koden i JavaScript visar hur du extraherar ljudet som används i en bild:

```javascript
// Instansierar en Presentation-klass som representerar en presentationsfil
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Kommer åt den önskade bilden
    const slide = pres.getSlides().get_Item(0);
    // Hämtar bildspelets övergångseffekter för bilden
    const transition = slide.getSlideShowTransition();
    // Extraherar ljudet i byte-array
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan jag återanvända samma ljudresurs på flera bilder utan att öka filstorleken?**

Ja. Lägg till ljudet en gång i presentationens delade [audio collection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getaudios/) och skapa ytterligare ljudramar som refererar till den befintliga resursen. Detta förhindrar duplicering av mediedata och håller presentationens storlek under kontroll.

**Kan jag ersätta ljudet i en befintlig ljudram utan att återskapa formen?**

Ja. För ett länkat ljud, uppdatera [link path](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) så att den pekar på den nya filen. För ett inbäddat ljud, byt ut objektet [embedded audio](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) mot ett annat från presentationens [audio collection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getaudios/). Ramens formatering och de flesta uppspelningsinställningar förblir intakta.

**Ändrar trimning den underliggande ljuddata som lagras i presentationen?**

Nej. Trimning justerar endast uppspelningsgränserna. De ursprungliga ljudbyten förblir orörda och är tillgängliga via det inbäddade ljudet eller presentationens ljudsamling.