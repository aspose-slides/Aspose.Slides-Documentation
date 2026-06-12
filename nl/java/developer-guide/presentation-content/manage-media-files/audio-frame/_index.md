---  
title: Beheer audio in presentaties met Java  
linktitle: Audioframe  
type: docs  
weight: 10  
url: /nl/java/audio-frame/  
keywords:  
- audio  
- audioframe  
- miniatuur  
- audio toevoegen  
- audio-eigenschappen  
- audio-opties  
- audio extraheren  
- Java  
- Aspose.Slides  
description: "Maak en beheer audioframes in Aspose.Slides for Java—codevoorbeelden om in te sluiten, bij te snijden, te herhalen en de weergave te configureren in PPT-, PPTX- en ODP-presentaties."  
---
## **Overzicht**

Dit artikel legt uit hoe u met audioframes in Aspose.Slides kunt werken. Het toont hoe u ingesloten audio aan dia's kunt toevoegen, de miniatuur van het audioframe kunt aanpassen, afspeelopties zoals volume, herhalen, verbergen, bijsnijden en vervagingsduur kunt configureren, en hoe u audio die wordt gebruikt in diavoorstellingsovergangen kunt extraheren.

## **Audioframes maken**

Aspose.Slides for Java maakt het mogelijk om audiobestanden aan dia's toe te voegen. De audiobestanden worden als audioframes in de dia's ingesloten. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Laad de audiobestandsstroom die u in de dia wilt insluiten.
4. Voeg het ingesloten audioframe (dat het audiobestand bevat) toe aan de dia.
5. Stel [PlayMode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/AudioPlayModePreset) en `Volume` in die worden aangeboden door het [IAudioFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAudioFrame) object.
6. Sla de gewijzigde presentatie op.

```java
// Instantieert een Presentation-klasse die een presentatiebestand voorstelt
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);

    // Laadt het wav-geluidsbestand naar een stream
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Voegt het Audio Frame toe
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Stelt de afspeelmodus en het volume van de audio in
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Schrijft het PowerPoint-bestand naar schijf
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Miniatuur van audioframe wijzigen**

Wanneer u een audiobestand aan een presentatie toevoegt, wordt de audio weergegeven als een frame met een standaard afbeelding (zie de afbeelding in de sectie hieronder). U kunt de voorbeeldafbeelding van het audioframe wijzigen (stel uw voorkeursafbeelding in).

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voegt een audioframe toe aan de dia met een gespecificeerde positie en grootte.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Voegt een afbeelding toe aan de presentatiebronnen.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Stelt de afbeelding in voor het audioframe.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Slaat de gewijzigde presentatie op schijf
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Audioweergaveopties wijzigen**

Aspose.Slides for Java maakt het mogelijk om opties te wijzigen die de weergave of eigenschappen van audio sturen. U kunt bijvoorbeeld het volume van de audio aanpassen, de audio in een lus laten afspelen, of zelfs het audio‑icoon verbergen.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** die overeenkomen met de eigenschappen van Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/AudioFrame) :

- **Start** vervolgkeuzelijst komt overeen met de [AudioFrame.setPlayMode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/audioframe/#setPlayMode-int-) methode
- **Volume** komt overeen met de [AudioFrame.setVolume](https://reference.aspose.com/slides/nl/java/com.aspose.slides/audioframe/#setVolume-int-) methode
- **Play Across Slides** komt overeen met de [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-) methode
- **Loop until Stopped** komt overeen met de [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-) methode
- **Hide During Show** komt overeen met de [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/nl/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-) methode
- **Rewind after Playing** komt overeen met de [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/nl/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-) methode

PowerPoint **Editing** opties die overeenkomen met de eigenschappen van Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/AudioFrame) :

- **Fade In** komt overeen met de [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/nl/java/com.aspose.slides/audioframe/#setFadeInDuration-float-) methode 
- **Fade Out** komt overeen met de [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/nl/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-) methode 
- **Trim Audio Start Time** komt overeen met de [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/audioframe/#setTrimFromStart-float-) methode 
- **Trim Audio End Time** waarde is gelijk aan de audioduur min de waarde van de [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/nl/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-) methode

De PowerPoint **Volume control** op het audio‑bedieningspaneel correspondeert met de [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/audioframe/#setVolumeValue-float-) methode. Hiermee kunt u het audio‑volume als percentage aanpassen.

Zo wijzigt u de audioweergave‑opties:

1. [Maak](#create-audio-frame) of haal het audioframe op.
2. Stel nieuwe waarden in voor de audioframe‑eigenschappen die u wilt aanpassen.
3. Sla het gewijzigde PowerPoint‑bestand op.

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Haalt de AudioFrame-vorm op
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Stelt de afspeelmodus in op afspelen bij klik
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Stelt het volume in op Laag
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Stelt in dat de audio over dia's heen wordt afgespeeld
    audioFrame.setPlayAcrossSlides(true);

    // Schakelt het herhalen voor de audio uit
    audioFrame.setPlayLoopMode(false);

    // Verbergt de AudioFrame tijdens de diavoorstelling
    audioFrame.setHideAtShowing(true);

    // Spoelt de audio terug naar het begin na het afspelen
    audioFrame.setRewindAudio(true);

    // Slaat het PowerPoint-bestand op schijf
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dit Java‑voorbeeld toont hoe u een nieuw audioframe met ingesloten audio kunt toevoegen, bijsnijden en de vervagingsduur kunt instellen:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Stelt de startverschuiving voor bijsnijden in op 1,5 seconden
    audioFrame.setTrimFromStart(1500f);
    // Stelt de eindverschuiving voor bijsnijden in op 2 seconden
    audioFrame.setTrimFromEnd(2000f);

    // Stelt de fade-in duur in op 200 ms
    audioFrame.setFadeInDuration(200f);
    // Stelt de fade-out duur in op 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

De volgende code‑voorbeeld laat zien hoe u een audioframe met ingesloten audio kunt ophalen en het volume op 85 % kunt instellen:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Haalt een audioframe-vorm op
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Stelt het audio-volume in op 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Audiobijschriften beheren**

Aspose.Slides maakt het mogelijk om ondertitels aan een audioframe toe te voegen via de [getCaptionTracks](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) methode. Deze methode retourneert een [ICaptionsCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/), waarmee u WebVTT‑ondertitelsporen kunt toevoegen, door bestaande sporen kunt itereren en ze kunt verwijderen wanneer dat nodig is.

**Audiobijschriften toevoegen**

Gebruik de [getCaptionTracks](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) methode om één of meer ondertitelsporen aan een audioframe toe te voegen. In het volgende voorbeeld wordt een audiobestand aan een dia toegevoegd en vervolgens wordt een nieuw ondertitelspoor geladen uit een `.vtt`‑bestand.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Voeg een nieuw ondertitelingsspoor toe vanuit een WebVTT‑bestand.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Audiobijschriften extraheren**

U kunt door de ondertitelsporen die aan een audioframe zijn gekoppeld itereren en ze opslaan als `.vtt`‑bestanden. Elk ondertitelspoor geeft zijn binaire gegevens en unieke identifier vrij, die bij het exporteren van ondertitels gebruikt kunnen worden.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Bewaar het ondertitelingsspoor als een .vtt-bestand.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Audiobijschriften verwijderen**

Om ondertitels van een audioframe te verwijderen, gebruikt u de methoden van [ICaptionsCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/), zoals [clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), of [removeAt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/#removeAt-int-). Het volgende voorbeeld verwijdert alle ondertitelsporen van een audioframe.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Verwijder alle ondertitelingssporen van het audioframe.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Audio extraheren**

Aspose.Slides for Java maakt het mogelijk om het geluid dat wordt gebruikt in diavoorstelling‑overgangen te extraheren. U kunt bijvoorbeeld het geluid van een specifieke dia extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse en laad de presentatie die de audio bevat.
2. Verkrijg de referentie naar de betreffende dia via de index.
3. Open de [slideshow transitions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) voor de dia.
4. Extraheer het geluid als byte‑gegevens.

```java
// Instantieert een Presentation-klasse die een presentatiebestand voorstelt
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Toegang tot de gewenste dia
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Haalt de diavoorstellingsovergangseffecten voor de dia op
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // Extraheert het geluid in een byte-array
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik dezelfde audio‑asset op meerdere dia's hergebruiken zonder de bestandsgrootte op te blazen?**

Ja. Voeg de audio één keer toe aan de gedeelde [audio collection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getAudios--) van de presentatie en maak extra audioframes die naar die bestaande asset verwijzen. Dit voorkomt duplicatie van mediagegevens en houdt de presentiegrootte onder controle.

**Kan ik het geluid in een bestaand audioframe vervangen zonder de vorm opnieuw te maken?**

Ja. Voor een gekoppeld geluid werkt u het [link path](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) bij zodat het naar het nieuwe bestand wijst. Voor een ingesloten geluid verwisselt u het [embedded audio](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) object met een ander uit de [audio collection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getAudios--) van de presentatie. De opmaak van het frame en de meeste afspeelinstellingen blijven behouden.

**Verandert bijsnijden de onderliggende audio‑gegevens die in de presentatie zijn opgeslagen?**

Nee. Bijsnijden past alleen de afspeelgrenzen aan. De oorspronkelijke audiobytes blijven ongewijzigd en zijn toegankelijk via de ingesloten audio of de audio‑collectie van de presentatie.