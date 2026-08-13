---
title: Beheer diaovergangen in presentaties op Android
linktitle: Diaovergang
type: docs
weight: 80
url: /nl/androidjava/slide-transition/
keywords:
- diaovergang
- diaovergang toevoegen
- diaovergang toepassen
- geavanceerde diaovergang
- morph‑overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe u diaovergangen kunt aanpassen in Aspose.Slides voor Android via Java, met stapsgewijze begeleiding voor PowerPoint- en OpenDocument‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u diavoorstellingsovergangen beheert met Aspose.Slides. Het laat zien hoe u overgangstypen op dia’s toepast, het overgangsgedrag configureert, zoals voortgang bij klik of na een opgegeven tijd, de Morph‑overgang en de verschillende typen ervan gebruikt, en opties voor overgangseffecten instelt. De voorbeelden demonstreren hoe u een presentatie laadt of maakt, overgangsinstellingen voor geselecteerde dia’s wijzigt, en het resultaat opslaat als een PPTX‑bestand. Het artikel beantwoordt ook veelgestelde vragen over de snelheid van overgangen, overgangsgeluiden, dezelfde overgang op meerdere dia’s toepassen, en hoe u de momenteel ingestelde overgang op een dia controleert.

## **Overgang aan dia toevoegen**
Om een eenvoudig overgangseffect toe te voegen, volgt u de onderstaande stappen:

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse.  
1. Pas een Slide Transition Type toe op de dia vanuit een van de overgangseffecten die Aspose.Slides voor Android via Java biedt via de TransitionType‑enum.  
1. Schrijf het gewijzigde presentatie‑bestand weg.

```java
import com.aspose.slides.*;

// Instantie van de Presentation-klasse om het bronpresentatiebestand te laden
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Pas een cirkeltype overgang toe op dia 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Pas een kamtype overgang toe op dia 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Schrijf de presentatie naar schijf
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Geavanceerde dia‑overgang toevoegen**
In de vorige sectie hebben we alleen een eenvoudig overgangseffect op de dia toegepast. Om dat effect nog beter en beter controleerbaar te maken, volgt u de onderstaande stappen:

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse.  
1. Pas een Slide Transition Type toe op de dia vanuit een van de overgangseffecten die Aspose.Slides voor Android via Java biedt.  
1. U kunt de overgang ook instellen op Advance On Click, na een specifieke tijdsperiode, of beide.  
1. Als de dia‑overgang is ingeschakeld op Advance On Click, wordt de overgang alleen voortgezet wanneer iemand klikt. Bovendien, als de Advance After Time‑eigenschap is ingesteld, wordt de overgang automatisch voortgezet nadat de opgegeven tijd is verstreken.  
1. Schrijf de gewijzigde presentatie weg als presentatiebestand.

```java
import com.aspose.slides.*;

// Instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Pas een cirkeltype overgang toe op dia 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Vooruit gaan bij klikken of automatisch na 3 seconden
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Pas een kamtype overgang toe op dia 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Vooruit gaan bij klikken of automatisch na 5 seconden
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Pas een zoomtype overgang toe op dia 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Vooruit gaan bij klikken of automatisch na 7 seconden
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Schrijf de presentatie naar schijf
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph‑overgang**
{{% alert color="info" %}} 

Aspose.Slides voor Android via Java ondersteunt nu de [Morph Transition](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IMorphTransition). Deze stelt de nieuwe morph‑overgang die is geïntroduceerd in PowerPoint 2019 voor.

{{% /alert %}} 

De Morph‑overgang maakt het mogelijk om een vloeiende beweging van de ene dia naar de andere te animeren. Dit artikel beschrijft het concept en hoe u de Morph‑overgang gebruikt. Om de Morph‑overgang effectief te gebruiken, heeft u twee dia’s nodig met ten minste één gemeenschappelijk object. De gemakkelijkste manier is om de dia te dupliceren en vervolgens het object op de tweede dia naar een andere plek te verplaatsen.

De onderstaande codefragment toont hoe u een kloon van de dia met wat tekst aan de presentatie toevoegt en een overgang van het type [morph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TransitionType) op de tweede dia instelt.

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
Nieuwe [TransitionMorphType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TransitionMorphType)‑enum is toegevoegd. Deze vertegenwoordigt verschillende typen Morph‑dia‑overgangen.

TransitionMorphType‑enum heeft drie leden:

- ByObject: Morph‑overgang wordt uitgevoerd met vormen als ondeelbare objecten.  
- ByWord: Morph‑overgang wordt uitgevoerd door tekst woord voor woord over te dragen waar mogelijk.  
- ByChar: Morph‑overgang wordt uitgevoerd door tekst teken voor teken over te dragen waar mogelijk.

Het volgende codefragment laat zien hoe u een morph‑overgang op een dia instelt en het morph‑type wijzigt:

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
Aspose.Slides voor Android via Java ondersteunt het instellen van overgangseffecten zoals van zwart, van links, van rechts, enzovoort. Volg de onderstaande stappen om een overgangseffect in te stellen:

- Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
- Verkrijg de referentie van de dia.  
- Stel het overgangseffect in.  
- Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

In het hieronder gegeven voorbeeld hebben we de overgangseffecten ingesteld.

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Stel het effect in
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Schrijf de presentatie naar schijf
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Kan ik de afspeelsnelheid van een dia‑overgang regelen?

Ja. Stel de [speed](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) van de overgang in met de [TransitionSpeed](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/transitionspeed/)‑instelling (bijv. langzaam/middelmatig/snel).

### Kan ik audio aan een overgang koppelen en laten herhalen?

Ja. U kunt een geluid voor de overgang insluiten en het gedrag regelen via instellingen zoals sound‑mode en looping (bijv. [setSound](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), plus metadata zoals [setSoundIsBuiltIn](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) en [setSoundName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?

Configureer het gewenste overgangstype in de overgangsinstellingen van elke dia; overgangen worden per dia opgeslagen, dus dezelfde type op alle dia’s toepassen levert een consistent resultaat op.

### Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?

Bekijk de [transition settings](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) van de dia en lees het [transition type](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); die waarde vertelt precies welk effect is toegepast.