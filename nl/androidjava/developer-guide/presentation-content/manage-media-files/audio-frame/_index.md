---
title: Audio beheren in presentaties op Android
linktitle: Audioframe
type: docs
weight: 10
url: /nl/androidjava/audio-frame/
keywords:
- audio
- audioframe
- miniatuur
- audio toevoegen
- audio-eigenschappen
- audio-opties
- audio extraheren
- Android
- Java
- Aspose.Slides
description: "Maak en beheer audioframes in Aspose.Slides voor Android—Java-voorbeelden om in te voegen, bij te snijden, te laten herhalen en afspelen te configureren in PPT, PPTX en ODP-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u met audioframes werkt in Aspose.Slides. Het laat zien hoe u ingebedde audio aan dia's kunt toevoegen, de miniatuur van het audioframe kunt aanpassen, afspeelopties zoals volume, herhalen, verbergen, bijsnijden en vervagingsduur kunt configureren, en audio die in diavoorstellingovergangen wordt gebruikt, kunt extraheren.

## **Audioframes maken**
Aspose.Slides for Android via Java stelt u in staat audio‑bestanden aan dia's toe te voegen. De audio‑bestanden worden ingevoegd in dia's als audioframes.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
2. Haal een referentie naar een dia op via de index.
3. Laad de audiobestandsstroom die u in de dia wilt inbedden.
4. Voeg het ingebedde audioframe (bevat het audiobestand) toe aan de dia.
5. Stel [PlayMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/AudioPlayModePreset) en `Volume` in die beschikbaar zijn via het [IAudioFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAudioFrame) object.
6. Sla de gewijzigde presentatie op.

Deze Java‑code toont u hoe u een ingebed audioframe aan een dia kunt toevoegen:

```java
// Instantieert een Presentation-klasse die een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);

    // Laadt het wav-geluidsbestand naar een stream
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Voegt het Audio-frame toe
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

## **Miniatuur van het audioframe wijzigen**

Wanneer u een audiobestand aan een presentatie toevoegt, verschijnt de audio als een frame met een standaard‑beeld (zie de afbeelding in de onderstaande sectie). U kunt de voorbeeldafbeelding van het audioframe wijzigen (stel uw gewenste afbeelding in).

Deze Java‑code toont u hoe u de miniatuur of voorbeeldafbeelding van een audioframe kunt wijzigen:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voegt een audioframe toe aan de dia met een gespecificeerde positie en grootte.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Voegt een afbeelding toe aan de presentatiemiddelen.
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

## **Afspeelopties voor audio wijzigen**

Aspose.Slides for Android via Java stelt u in staat opties te wijzigen die de weergave of eigenschappen van audio regelen. U kunt bijvoorbeeld het volume van audio aanpassen, audio laten afspelen in een lus, of zelfs het audio‑icoon verbergen.

Het **Audio Options**‑paneel in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** die overeenkomen met de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/AudioFrame) eigenschappen:

- **Start**‑keuzelijst correspondeert met de [AudioFrame.PlayMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) eigenschap
- **Volume** correspondeert met de [AudioFrame.Volume](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/AudioFrame#getVolume--) eigenschap
- **Play Across Slides** correspondeert met de [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) eigenschap
- **Loop until Stopped** correspondeert met de [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) eigenschap
- **Hide During Show** correspondeert met de [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) eigenschap
- **Rewind after Playing** correspondeert met de [AudioFrame.RewindAudio](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) eigenschap

PowerPoint **Editing**‑opties die overeenkomen met de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/audioframe/) eigenschappen:

- **Fade In** correspondeert met de [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) eigenschap 
- **Fade Out** correspondeert met de [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) eigenschap 
- **Trim Audio Start Time** correspondeert met de [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) eigenschap 
- **Trim Audio End Time** waarde is gelijk aan de audioduur min de waarde van [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) eigenschap

De PowerPoint **Volume controle** op het audio‑bedieningspaneel komt overeen met de [AudioFrame.VolumeValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) eigenschap. Hiermee kunt u het audiovolume als percentage wijzigen.

Zo wijzigt u de audio‑afspeelopties:

1. [Maak](#create-audio-frame) of haal het audioframe op.
2. Stel nieuwe waarden in voor de audioframe‑eigenschappen die u wilt aanpassen.
3. Sla het gewijzigde PowerPoint‑bestand op.

Deze Java‑code demonstreert een bewerking waarbij audio‑opties worden aangepast:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Haalt de AudioFrame-vorm op
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Stelt de afspeelmodus in op afspelen bij klikken
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Stelt het volume in op Laag
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Stelt in dat de audio over dia's heen wordt afgespeeld
    audioFrame.setPlayAcrossSlides(true);

    // Schakelt herhalen voor de audio uit
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

Dit Java‑voorbeeld laat zien hoe u een nieuw audioframe met ingebedde audio toevoegt, het bijsnijdt en de vervagingsduur instelt:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Stelt de trimstartoffset in op 1,5 seconden
    // Stelt de trimendoffset in op 2 seconden

    // Stelt de fade-in‑duur in op 200 ms
    // Stelt de fade-out‑duur in op 500 ms

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

De volgende codevoorbeeld laat zien hoe u een audioframe met ingebedde audio ophaalt en het volume instelt op 85%:

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

## **Audio‑bijschriften beheren**

Aspose.Slides stelt u in staat gesloten bijschriften toe te voegen aan een audioframe via de [getCaptionTracks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--)‑methode. Deze methode retourneert een [ICaptionsCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptionscollection/), waarmee u WebVTT‑bijschriftsporen kunt toevoegen, door bestaande sporen kunt itereren en ze indien nodig kunt verwijderen.

### **Audio‑bijschriften toevoegen**

Gebruik de [getCaptionTracks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--)‑methode om een of meer bijschriftsporen aan een audioframe te koppelen. In het volgende voorbeeld wordt een audiobestand aan een dia toegevoegd en vervolgens wordt een nieuw bijschriftspoor geladen vanuit een `.vtt`‑bestand.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Voeg een nieuw ondertitelspoor toe vanuit een WebVTT‑bestand.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Audio‑bijschriften extraheren**

U kunt door de bijschriftsporen die aan een audioframe zijn gekoppeld itereren en ze opslaan als `.vtt`‑bestanden. Elk bijschriftspoor geeft zijn binaire gegevens en unieke identifier vrij, die bij het exporteren van bijschriften kan worden gebruikt.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Sla het ondertitelspoor op als een .vtt‑bestand.
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

### **Audio‑bijschriften verwijderen**

Om bijschriften van een audioframe te verwijderen, gebruikt u de methoden die worden aangeboden door [ICaptionsCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptionscollection/), zoals [clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), of [removeAt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-). Het volgende voorbeeld verwijdert alle bijschriftsporen van een audioframe.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Verwijder alle ondertitelsporen van het audioframe.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Audio extraheren**

Aspose.Slides for Android via Java stelt u in staat het geluid dat wordt gebruikt in diavoorstelling‑overgangen te extraheren. U kunt bijvoorbeeld het geluid extraheren dat in een specifieke dia wordt gebruikt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse en laad de presentatie die de audio bevat.
2. Haal de referentie naar de betreffende dia op via de index.
3. Toegang tot de [slideshow transitions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) voor de dia.
4. Extraheer het geluid als byte‑data.

Deze Java‑code toont u hoe u de audio die in een dia wordt gebruikt, kunt extraheren:

```java
// Instantieert een Presentation-klasse die een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Toegang tot de gewenste dia
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Haalt de diavoorstellingovergangseffecten op voor de dia
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // Extraheert het geluid in een byte-array
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik hetzelfde audio‑bestand opnieuw gebruiken op meerdere dia's zonder de bestandsgrootte te vergroten?**

Ja. Voeg de audio één keer toe aan de gedeelde [audio‑collectie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getAudios--) van de presentatie en maak extra audioframes aan die naar dat bestaande bestand verwijzen. Dit voorkomt duplicatie van mediagegevens en houdt de presentatiegrootte onder controle.

**Kan ik het geluid in een bestaand audioframe vervangen zonder de vorm opnieuw te maken?**

Ja. Voor een gekoppeld geluid, werk het [link path](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) bij zodat het naar het nieuwe bestand verwijst. Voor een ingebed geluid, verwissel het [embedded audio](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) object met een ander object uit de [audio‑collectie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getAudios--) van de presentatie. De opmaak van het frame en de meeste afspeelinstellingen blijven behouden.

**Verandert bijsnijden de onderliggende audio‑gegevens die in de presentatie zijn opgeslagen?**

Nee. Bijsnijden past alleen de afspeelgrenzen aan. De oorspronkelijke audio‑bytes blijven onveranderd en zijn toegankelijk via de ingebedde audio of de audio‑collectie van de presentatie.