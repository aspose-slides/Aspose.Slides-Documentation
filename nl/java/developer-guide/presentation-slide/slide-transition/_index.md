---
title: Diaovergangen beheren in presentaties met Java
linktitle: Diaovergang
type: docs
weight: 80
url: /nl/java/slide-transition/
keywords:
- diaovergang
- diaovergang toevoegen
- diaovergang toepassen
- geavanceerde diaovergang
- morph-overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Ontdek hoe u diaovergangen kunt aanpassen in Aspose.Slides for Java, met stapsgewijze begeleiding voor PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe je diaovergangen in presentaties beheert met Aspose.Slides. Het laat zien hoe je overgangstypen toepast op dia's, het gedrag van de overgang configureert, zoals doorgaan bij klikken of na een opgegeven tijd, controleert en automatische voortgang uitschakelt, de Morph‑overgang en de bijbehorende types gebruikt, en opties voor overgangseffecten instelt. De voorbeelden tonen hoe je een presentatie laadt of maakt, de overgangsinstellingen voor geselecteerde dia's wijzigt, en het resultaat opslaat als een PPTX‑bestand. Het artikel beantwoordt ook veelgestelde vragen over de snelheid van de overgang, overgangsgeluiden, hetzelfde overgangstype toepassen op meerdere dia's, en hoe je de momenteel ingestelde overgang op een dia controleert.

## **Diaovergang toevoegen**
Om een eenvoudig diaovergangseffect te maken, volg de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse.  
2. Pas een Slide Transition Type toe op de dia uit een van de overgangseffecten die door Aspose.Slides for Java worden aangeboden via de TransitionType‑enum.  
3. Schrijf het gewijzigde presentatie‑bestand.

```java
// Instantieer de Presentation-klasse om het bronpresentatie-bestand te laden
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Pas een cirkeltype-overgang toe op dia 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Pas een kamtype-overgang toe op dia 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Schrijf de presentatie naar schijf
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Geavanceerde diaovergang toevoegen**
In de vorige sectie hebben we een eenvoudige overgang toegepast op de dia. Nu, om die eenvoudige overgang nog beter en gecontroleerder te maken, volg je de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse.  
2. Pas een Slide Transition Type toe op de dia uit een van de overgangseffecten die door Aspose.Slides for Java worden aangeboden.  
3. Je kunt de overgang ook instellen op Doorgaan bij klikken, na een specifieke tijdsperiode of beide.  
4. Als de diaovergang is ingeschakeld om door te gaan bij klikken, gaat de overgang alleen verder wanneer iemand klikt met de muis. Bovendien, als de eigenschap Advance After Time is ingesteld, gaat de overgang automatisch verder nadat de opgegeven tijd is verstreken.  
5. Schrijf de gewijzigde presentatie weg als een presentatiebestand.

```java
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Pas een cirkeltype-overgang toe op dia 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Stel de overgangstijd in op 3 seconden
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Pas een kamtype-overgang toe op dia 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Stel de overgangstijd in op 5 seconden
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Pas een zoomtype-overgang toe op dia 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Stel de overgangstijd in op 7 seconden
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Schrijf de presentatie naar schijf
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph‑overgang**
{{% alert color="primary" %}} 

Aspose.Slides for Java ondersteunt nu de [Morph Transition](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IMorphTransition). Ze vertegenwoordigen de nieuwe morph‑overgang geïntroduceerd in PowerPoint 2019.

{{% /alert %}} 

De Morph‑overgang maakt het mogelijk om een vloeiende beweging van de ene dia naar de volgende te animeren. Dit artikel beschrijft het concept en hoe je de Morph‑overgang gebruikt. Om de Morph‑overgang effectief te gebruiken, heb je twee dia's nodig met ten minste één gemeenschappelijk object. De makkelijkste manier is om de dia te dupliceren en vervolgens het object op de tweede dia naar een andere plek te verplaatsen.

De volgende code‑fragment toont hoe je een kloon van de dia met wat tekst toevoegt aan de presentatie en een overgang van het type morph instelt op de tweede dia.

```java
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
Er is een nieuwe enum [TransitionMorphType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/TransitionMorphType) toegevoegd. Deze vertegenwoordigt verschillende typen Morph‑diaovergangen.

TransitionMorphType‑enum heeft drie leden:

- ByObject: Morph‑overgang wordt uitgevoerd met vormen als ondeelbare objecten.  
- ByWord: Morph‑overgang wordt uitgevoerd door tekst per woord over te dragen waar mogelijk.  
- ByChar: Morph‑overgang wordt uitgevoerd door tekst per teken over te dragen waar mogelijk.

De volgende code‑fragment toont hoe je een morph‑overgang instelt op een dia en het morph‑type wijzigt:

```java
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
Aspose.Slides for Java ondersteunt het instellen van overgangseffecten zoals van zwart, van links, van rechts, enz. Om het overgangseffect in te stellen, volg de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
- Haal de referentie van de dia op.  
- Stel het overgangseffect in.  
- Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

In het onderstaande voorbeeld hebben we de overgangseffecten ingesteld.

```java
// Maak een instantie van de Presentation-klasse
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Stel effect in
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Schrijf de presentatie naar schijf
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan ik de afspeelsnelheid van een diaovergang regelen?**

Ja. Stel de [speed](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) van de overgang in met de [TransitionSpeed](https://reference.aspose.com/slides/nl/java/com.aspose.slides/transitionspeed/)‑instelling (bijv. langzaam/medium/snel).

**Kan ik audio aan een overgang koppelen en laten herhalen?**

Ja. Je kunt een geluid voor de overgang insluiten en het gedrag regelen via instellingen zoals sound‑mode en looping (bijv. [setSound](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), plus metadata zoals [setSoundIsBuiltIn](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) en [setSoundName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Configureer het gewenste overgangstype in de overgangsinstellingen van elke dia; overgangen worden per dia opgeslagen, dus door hetzelfde type op alle dia's toe te passen krijg je een consistent resultaat.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Bekijk de [transition settings](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseslide/#getSlideShowTransition--) van de dia en lees het [transition type](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideshowtransition/#setType-int-); die waarde vertelt precies welk effect is toegepast.