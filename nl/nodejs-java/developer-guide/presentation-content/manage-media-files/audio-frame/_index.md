---
title: Audio beheren in presentaties met JavaScript
linktitle: Audioframe
type: docs
weight: 10
url: /nl/nodejs-java/audio-frame/
keywords:
- audio
- audioframe
- miniatuur
- audio toevoegen
- audio-eigenschappen
- audio-opties
- audio extraheren
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak en beheer audioframes in Aspose.Slides voor Node.js—voorbeelden om in te sluiten, te trimmen, te loopen en de weergave te configureren in PPT-, PPTX- en ODP-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u met audio‑frames werkt in Aspose.Slides. Het laat zien hoe u ingesloten audio aan dia's kunt toevoegen, de miniatuur van het audioframe kunt aanpassen, afspeelopties zoals volume, loopen, verbergen, trimmen en fade‑duur kunt configureren, en audio kunt extraheren die in diavoorstellingstransities wordt gebruikt.

## **Audioframes maken**

Aspose.Slides voor Node.js via Java stelt u in staat om audiobestanden aan dia's toe te voegen. De audiobestanden worden in de dia's ingebed als audio‑frames.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Laad de audiobestandsstroom die u in de dia wilt insluiten.  
4. Voeg het ingesloten audioframe (dat het audiobestand bevat) toe aan de dia.  
5. Stel [PlayMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AudioPlayModePreset) en `Volume` in die worden aangeboden door het [AudioFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AudioFrame) object.  
6. Sla de gewijzigde presentatie op.

Deze JavaScript‑code laat zien hoe u een ingesloten audioframe aan een dia toevoegt:

```javascript
// Instantieert een Presentation‑klasse die een presentatiebestand vertegenwoordigt
const pres = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op
    const sld = pres.getSlides().get_Item(0);
    // Laadt het .wav‑geluidsbestand naar een stream
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Voegt het audio‑frame toe
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Stelt de afspeelmodus en het volume van de audio in
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // Schrijft het PowerPoint‑bestand naar de schijf
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Audioframe‑miniatuur wijzigen**

Wanneer u een audiobestand aan een presentatie toevoegt, verschijnt de audio als een frame met een standaardafbeelding (zie de afbeelding in de onderstaande sectie). U kunt de voorbeeldafbeelding van het audioframe wijzigen (stel uw voorkeursafbeelding in).

Deze JavaScript‑code laat zien hoe u de miniatuur of voorbeeldafbeelding van een audioframe wijzigt:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Voegt een audioframe toe aan de dia met een opgegeven positie en grootte.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Voegt een afbeelding toe aan de presentatieresources.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Stelt de afbeelding in voor het audioframe.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Slaat de gewijzigde presentatie op schijf
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Audio‑afspeelopties wijzigen**

Aspose.Slides voor Node.js via Java stelt u in staat om opties te wijzigen die de weergave of eigenschappen van audio regelen. U kunt bijvoorbeeld het volume van audio aanpassen, de audio in een lus laten afspelen, of zelfs het audio‑icoon verbergen.

Het **Audio Options**‑paneel in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** die overeenkomen met de [AudioFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/)‑eigenschappen van Aspose.Slides:
- **Start**‑keuzelijst komt overeen met de [AudioFrame.setPlayMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/#setPlayMode) methode
- **Volume** komt overeen met de [AudioFrame.setVolume](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/#setVolume) methode
- **Play Across Slides** komt overeen met de [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) methode
- **Loop until Stopped** komt overeen met de [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) methode
- **Hide During Show** komt overeen met de [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) methode
- **Rewind after Playing** komt overeen met de [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/#setRewindAudio) methode


PowerPoint **Editing**‑opties die overeenkomen met de [AudioFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/)‑eigenschappen van Aspose.Slides:
- **Fade In** komt overeen met de [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) methode 
- **Fade Out** komt overeen met de [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) methode 
- **Trim Audio Start Time** komt overeen met de [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) methode 
- **Trim Audio End Time**‑waarde is gelijk aan de audioduurtijd min de waarde van de [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) methode

De PowerPoint **Volume controll** op het audio‑bedieningspaneel komt overeen met de [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/#setVolumeValue) methode. Hiermee kunt u het audiovolume als percentage wijzigen.

Zo wijzigt u de audio‑afspeelopties:

1. [Maak](#create-audio-frame) of haal het Audio‑frame op.  
2. Stel nieuwe waarden in voor de Audio‑frame‑eigenschappen die u wilt aanpassen.  
3. Sla het gewijzigde PowerPoint‑bestand op.

Deze JavaScript‑code toont een bewerking waarbij de opties van een audio worden aangepast:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Haalt de AudioFrame‑vorm op
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Stelt de afspeelmodus in op afspelen bij klikken
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Stelt het volume in op Laag
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Stelt de audio in om over dia's heen af te spelen
    audioFrame.setPlayAcrossSlides(true);
    // Schakelt het loopen van de audio uit
    audioFrame.setPlayLoopMode(false);
    // Verbergt de AudioFrame tijdens de diavoorstelling
    audioFrame.setHideAtShowing(true);
    // Spoelt de audio terug naar het begin na het afspelen
    audioFrame.setRewindAudio(true);
    // Slaat het PowerPoint‑bestand op schijf
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Dit JavaScript‑voorbeeld laat zien hoe u een nieuw audioframe met ingesloten audio toevoegt, het bijsnijdt, en de fade‑duur instelt:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Stelt de trim‑begin offset in op 1.5 seconden
    audioFrame.setTrimFromStart(1500);
    // Stelt de trim‑eind offset in op 2 seconden
    audioFrame.setTrimFromEnd(2000);

    // Stelt de fade‑in duur in op 200 ms
    audioFrame.setFadeInDuration(200);
    // Stelt de fade‑out duur in op 500 ms
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

De volgende codevoorbeeld toont hoe u een audioframe met ingesloten audio ophaalt en het volume instelt op 85 %:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Haalt een audioframe-vorm op
    const audioFrame = slide.getShapes().get_Item(0);

    // Stelt het audio-volume in op 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Audio‑bijschriften beheren**

Aspose.Slides maakt het mogelijk om ondertitelingen toe te voegen aan een audioframe via de [getCaptionTracks](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) methode. Deze methode retourneert een [CaptionsCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/), waarmee u WebVTT‑ondertitel‑tracks kunt toevoegen, door bestaande tracks kunt itereren, en ze indien nodig kunt verwijderen.

### **Audio‑bijschriften toevoegen**

Gebruik de [getCaptionTracks](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) methode om één of meerdere ondertitel‑tracks aan een audioframe toe te voegen. In het volgende voorbeeld wordt een audiobestand aan een dia toegevoegd, waarna een nieuwe ondertitel‑track wordt geladen uit een `.vtt`‑bestand.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Voeg een nieuw ondertitel‑track toe vanuit een WebVTT‑bestand.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Audio‑bijschriften extraheren**

U kunt door de ondertitel‑tracks die aan een audioframe gekoppeld zijn itereren en ze opslaan als `.vtt`‑bestanden. Elke ondertitel‑track geeft zijn binaire gegevens en unieke identifier vrij, die gebruikt kan worden bij het exporteren van ondertitels.

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
                // Sla het ondertitel‑track op als een .vtt‑bestand.
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

### **Audio‑bijschriften verwijderen**

Om ondertitels van een audioframe te verwijderen, gebruikt u de methoden die worden aangeboden door [CaptionsCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/), zoals [clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/#remove), of [removeAt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/#removeAt). Het volgende voorbeeld verwijdert alle ondertitel‑tracks van een audioframe.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // type: aspose.slides.AudioFrame

    // Verwijder alle ondertitel-tracks van het audioframe.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Audio extraheren**

Aspose.Slides voor Node.js via Java maakt het mogelijk om het geluid dat wordt gebruikt in diavoorstelling‑overgangen te extraheren. Bijvoorbeeld, u kunt het geluid van een specifieke dia extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse en laad de presentatie die de audio bevat.  
2. Haal de referentie van de betreffende dia op via de index.  
3. Benader de [slideshow transitions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) voor de dia.  
4. Extraheer het geluid als byte‑gegevens.

Deze JavaScript‑code laat zien hoe u de audio die in een dia wordt gebruikt, kunt extraheren:

```javascript
// Instantieert een Presentation‑klasse die een presentatiebestand vertegenwoordigt
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Benadert de gewenste dia
    const slide = pres.getSlides().get_Item(0);
    // Haalt de diavoorstellings‑overgangseffecten voor de dia op
    const transition = slide.getSlideShowTransition();
    // Extraheert het geluid als byte‑array
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan ik dezelfde audio‑resource hergebruiken in meerdere dia's zonder de bestandsgrootte te laten toenemen?**

Ja. Voeg de audio één keer toe aan de gedeelde [audio collection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getaudios/) van de presentatie en maak extra audioframes die naar dat bestaande asset verwijzen. Dit voorkomt het dupliceren van mediagegevens en houdt de bestandsgrootte van de presentatie onder controle.

**Kan ik het geluid in een bestaand audioframe vervangen zonder de vorm opnieuw te maken?**

Ja. Voor een gekoppeld geluid werkt u het [link path](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) bij zodat het naar het nieuwe bestand wijst. Voor een ingebed geluid vervangt u het [embedded audio](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) object door een ander uit de [audio collection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getaudios/) van de presentatie. De opmaak van het frame en de meeste afspeelinstellingen blijven behouden.

**Verandert trimmen de onderliggende audiogegevens die in de presentatie zijn opgeslagen?**

Nee. Trimmen past alleen de afspeelgrenzen aan. De oorspronkelijke audiobytes blijven onaangeroerd en zijn toegankelijk via de ingebedde audio of de audio‑collectie van de presentatie.