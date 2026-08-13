---
title: Beheer dia‑overgangen in presentaties met Java
linktitle: Diaovergang
type: docs
weight: 80
url: /nl/java/slide-transition/
keywords:
- dia‑overgang
- dia‑overgang toevoegen
- dia‑overgang toepassen
- geavanceerde dia‑overgang
- morph‑overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Ontdek hoe u dia‑overgangen kunt aanpassen in Aspose.Slides voor Java, met stap‑voor‑stap begeleiding voor PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u dia‑overgangen in presentaties kunt beheren met Aspose.Slides. Het laat zien hoe u overgangstypen op dia’s kunt toepassen, het gedrag van de overgang kunt configureren, zoals voortzetten bij klik of na een opgegeven tijd, hoe u automatische voortzetting kunt controleren en uitschakelen, de Morph‑overgang en de verschillende typen kunt gebruiken, en overgangseffectopties kunt instellen. De voorbeelden tonen hoe u een presentatie kunt laden of maken, de overgangsinstellingen voor geselecteerde dia’s kunt wijzigen, en het resultaat kunt opslaan als een PPTX‑bestand. Het artikel beantwoordt ook veelgestelde vragen over de snelheid van de overgang, overgangsgeluiden, het toepassen van dezelfde overgang op meerdere dia’s en het controleren van de overgang die momenteel op een dia is ingesteld.

## **Dia‑overgang toevoegen**
Om een eenvoudig dia‑overgangseffect te maken, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse.  
2. Pas een Slide Transition Type toe op de dia uit een van de overgangseffecten die Aspose.Slides voor Java aanbiedt via de TransitionType‑enum.  
3. Schrijf het gewijzigde presentatie‑bestand.

```java
import com.aspose.slides.*;

// Instantieer de Presentation‑klasse om het bronpresentatie‑bestand te laden
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Pas een cirkel‑type overgang toe op dia 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Pas een kam‑type overgang toe op dia 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Schrijf de presentatie naar de schijf
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Geavanceerde dia‑overgang toevoegen**
In de bovenstaande sectie hebben we alleen een eenvoudig overgangseffect op de dia toegepast. Om dat eenvoudige effect nu nog beter en beter controleerbaar te maken, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse.  
2. Pas een Slide Transition Type toe op de dia uit een van de overgangseffecten die Aspose.Slides voor Java aanbiedt.  
3. U kunt de overgang ook instellen om te voortzetten bij klik, na een specifieke tijdsperiode of beide.  
4. Als de dia‑overgang is ingesteld om te voortzetten bij klik, zal de overgang alleen doorgaan wanneer er op de muis wordt geklikt. Bovendien, als de eigenschap Advance After Time is ingesteld, gaat de overgang automatisch door na de opgegeven wachttijd.  
5. Schrijf de gewijzigde presentatie naar een presentatie‑bestand.

```java
import com.aspose.slides.*;

// Instantieer de Presentation‑klasse die een presentatiedossier vertegenwoordigt
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Pas een cirkel‑type overgang toe op dia 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Stel de overgangstijd in op 3 seconden
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Pas een kam‑type overgang toe op dia 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Stel de overgangstijd in op 5 seconden
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Pas een zoom‑type overgang toe op dia 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Stel de overgangstijd in op 7 seconden
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Schrijf de presentatie naar de schijf
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph‑overgang**
{{% alert color="info" %}} 
Aspose.Slides for Java ondersteunt nu de [Morph Transition](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IMorphTransition). Ze vertegenwoordigen de nieuwe morph‑overgang geïntroduceerd in PowerPoint 2019.
{{% /alert %}} 

De Morph‑overgang maakt het mogelijk om een vloeiende beweging te animeren van de ene dia naar de andere. Dit artikel beschrijft het concept en hoe u de Morph‑overgang kunt gebruiken. Om de Morph‑overgang effectief te gebruiken, heeft u twee dia’s nodig met ten minste één gemeenschappelijk object. De eenvoudigste manier is om de dia te dupliceren en vervolgens het object op de tweede dia naar een andere plaats te verplaatsen.

Het volgende code‑fragment toont hoe u een kloon van de dia met enige tekst aan de presentatie toevoegt en een overgang van het [morph type](https://reference.aspose.com/slides/nl/java/com.aspose.slides/TransitionType) instelt op de tweede dia.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Morph‑overgangstypen**
De nieuwe enum [TransitionMorphType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/TransitionMorphType) is toegevoegd. Deze vertegenwoordigt verschillende typen Morph‑dia‑overgangen.

TransitionMorphType‑enum heeft drie leden:

- ByObject: De Morph‑overgang wordt uitgevoerd met inachtneming van vormen als ondeelbare objecten.  
- ByWord: De Morph‑overgang wordt uitgevoerd door tekst per woord over te dragen waar mogelijk.  
- ByChar: De Morph‑overgang wordt uitgevoerd door tekst per teken over te dragen waar mogelijk.

Het volgende code‑fragment toont hoe u een morph‑overgang op een dia instelt en het morph‑type wijzigt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Overgangseffecten instellen**
Aspose.Slides for Java ondersteunt het instellen van overgangseffecten zoals van zwart, van links, van rechts enzovoort. Om het overgangseffect in te stellen, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
- Verkrijg de referentie van de dia.  
- Stel het overgangseffect in.  
- Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

In het onderstaande voorbeeld hebben we de overgangseffecten ingesteld.

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Stel effect in
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Schrijf de presentatie naar de schijf
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Kan ik de afspeelsnelheid van een dia‑overgang regelen?

Ja. Stel de [speed](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) van de overgang in via de [TransitionSpeed](https://reference.aspose.com/slides/nl/java/com.aspose.slides/transitionspeed/) instelling (bijv. langzaam/middelmatig/snel).

### Kan ik geluid aan een overgang koppelen en laten herhalen?

Ja. U kunt een geluid voor de overgang insluiten en het gedrag regelen via instellingen zoals sound‑mode en looping (bijv. [setSound](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), plus metadata zoals [setSoundIsBuiltIn](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) en [setSoundName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?

Configureer het gewenste overgangstype in de overgangsinstellingen van elke dia; overgangen worden per dia opgeslagen, dus door hetzelfde type op alle dia’s toe te passen krijgt u een consistent resultaat.

### Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?

Inspecteer de [transition settings](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseslide/#getSlideShowTransition--) van de dia en lees het [transition type](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideshowtransition/#setType-int-); die waarde vertelt u precies welk effect is toegepast.