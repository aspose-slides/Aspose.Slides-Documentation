---
title: Beheer dia‑overgangen in presentaties op Android
linktitle: Dia‑overgang
type: docs
weight: 80
url: /nl/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe u dia‑overgangen kunt aanpassen in Aspose.Slides voor Android via Java, met stapsgewijze begeleiding voor PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u dia‑overgangen in presentaties beheert met Aspose.Slides. Het laat zien hoe u overgangstypen op dia’s toepast, het gedrag van de overgang configureert, zoals voortzetten bij klikken of na een opgegeven tijd, hoe u automatische voortzetting controleert en uitschakelt, de Morph‑overgang en de verschillende typen gebruikt, en opties voor overgangseffecten instelt. De voorbeelden laten zien hoe u een presentatie laadt of maakt, de overgangsinstellingen voor geselecteerde dia’s wijzigt, en het resultaat opslaat als een PPTX‑bestand. Het artikel beantwoordt ook veelgestelde vragen over overgangssnelheid, overgangsgeluiden, dezelfde overgang op meerdere dia’s toepassen, en het controleren van de momenteel ingestelde overgang op een dia.

## **Diaovergang toevoegen**
Om een eenvoudig dia‑overgangseffect te maken, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse.  
2. Pas een Slide Transition Type toe op de dia vanuit een van de overgangseffecten die Aspose.Slides voor Android via Java biedt via de TransitionType‑enum.  
3. Schrijf het gewijzigde presentatie‑bestand.

```java
// Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Pas een cirkeltype overgang toe op dia 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Pas een comb-type overgang toe op dia 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Schrijf de presentatie naar schijf
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Geavanceerde diaovergang toevoegen**
In de bovenstaande sectie hebben we slechts een eenvoudige overgang toegepast op de dia. Om die eenvoudige overgang nog beter en gecontroleerder te maken, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse.  
2. Pas een Slide Transition Type toe op de dia vanuit een van de overgangseffecten die Aspose.Slides voor Android via Java biedt.  
3. U kunt de overgang ook instellen op **Advance On Click**, na een specifieke tijdsperiode of beide.  
4. Als de dia‑overgang is ingeschakeld op **Advance On Click**, gaat de overgang alleen verder wanneer iemand klikt met de muis. Als de eigenschap **Advance After Time** is ingesteld, gaat de overgang automatisch verder nadat de opgegeven tijd verstreken is.  
5. Schrijf de gewijzigde presentatie weg als een presentatiew bestand.

```java
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Pas een cirkeltype overgang toe op dia 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Stel de overgangstijd in op 3 seconden
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Pas een comb-type overgang toe op dia 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Stel de overgangstijd in op 5 seconden
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Pas een zoomtype overgang toe op dia 3
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

Aspose.Slides voor Android via Java ondersteunt nu de [Morph Transition](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IMorphTransition). Het is de nieuwe morph‑overgang die geïntroduceerd werd in PowerPoint 2019.

{{% /alert %}} 

De Morph‑overgang stelt u in staat om een soepele beweging van de ene dia naar de volgende te animeren. Dit artikel beschrijft het concept en hoe u de Morph‑overgang gebruikt. Om de Morph‑overgang effectief te gebruiken, moet u twee dia’s hebben met ten minste één gemeenschappelijk object. De eenvoudigste manier is om de dia te dupliceren en vervolgens het object op de tweede dia naar een andere plaats te verplaatsen.

De volgende code‑fragment toont hoe u een kloon van de dia met wat tekst toevoegt aan de presentatie en een overgang van het [morph type](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TransitionType) instelt op de tweede dia.

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
Nieuwe [TransitionMorphType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TransitionMorphType)‑enum is toegevoegd. Het representeert verschillende typen Morph‑dia‑overgangen.

TransitionMorphType‑enum heeft drie leden:

- ByObject: De morph‑overgang wordt uitgevoerd met vormen gezien als ondeelbare objecten.  
- ByWord: De morph‑overgang wordt uitgevoerd door tekst per woord over te dragen waar mogelijk.  
- ByChar: De morph‑overgang wordt uitgevoerd door tekst per teken over te dragen waar mogelijk.

De volgende code‑fragment toont hoe u een morph‑overgang op een dia instelt en het morph‑type wijzigt:

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

## **Instellen van overgangseffecten**
Aspose.Slides voor Android via Java ondersteunt het instellen van overgangseffecten zoals van zwart, van links, van rechts enz. Om het overgangseffect in te stellen, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.  
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

**Kan ik de afspeelsnelheid van een dia‑overgang regelen?**

Ja. Stel de overgang’s [speed](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) in via de [TransitionSpeed](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/transitionspeed/)‑instelling (bijv. langzaam/middelmatig/snel).

**Kan ik audio aan een overgang koppelen en laten herhalen?**

Ja. U kunt een geluid inbedden voor de overgang en het gedrag beheren via instellingen zoals sound‑mode en looping (bijv. [setSound](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), plus metadata zoals [setSoundIsBuiltIn](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) en [setSoundName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Configureer het gewenste overgangstype in de overgangsinstellingen van elke dia; overgangen worden per dia opgeslagen, dus dezelfde type toewijzen aan alle dia’s geeft een consistent resultaat.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Inspecteer de [transition settings](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) van de dia en lees het [transition type](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); die waarde vertelt u precies welk effect is toegepast.