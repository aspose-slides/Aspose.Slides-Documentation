---
title: Beheer dia‑overgangen in presentaties met JavaScript
linktitle: Dia‑overgang
type: docs
weight: 80
url: /nl/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Pas dia‑overgangen aan in JavaScript met Aspose.Slides voor Node.js via Java, met stapsgewijze begeleiding voor PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u dia‑overgangen in presentaties kunt beheren met Aspose.Slides. Het toont hoe u overgangstypen toepast op dia’s, het gedrag van de overgang configureert (bijvoorbeeld voortzetten bij een klik of na een opgegeven tijd), automatische voortzetting controleert en uitschakelt, de Morph‑overgang en de verschillende typen ervan gebruikt, en opties voor overgangseffecten instelt. De voorbeelden demonstreren hoe een presentatie wordt geladen of aangemaakt, overgangsinstellingen voor geselecteerde dia’s worden aangepast, en het resultaat wordt opgeslagen als een PPTX‑bestand. Het artikel beantwoordt ook veelgestelde vragen over de snelheid van overgangen, overgangsgeluiden, het toepassen van dezelfde overgang op meerdere dia’s, en het controleren van de momenteel ingestelde overgang op een dia.

## **Slide‑overgang toevoegen**
Om een eenvoudige dia‑overgangseffect te creëren, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation) klasse.  
2. Pas een Slide Transition Type toe op de dia van een van de overgangseffecten die door Aspose.Slides for Node.js via Java worden aangeboden via de TransitionType‑enum.  
3. Schrijf het gewijzigde presentatie‑bestand.

```javascript
// Maak een instantie van de Presentation‑klasse om het bronpresentatie‑bestand te laden
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Pas een cirkeltype‑overgang toe op dia 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Pas een kamtype‑overgang toe op dia 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Schrijf de presentatie naar de schijf
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Geavanceerde dia‑overgang toevoegen**
In de bovenstaande sectie hebben we een eenvoudige overgang op de dia toegepast. Om die eenvoudige overgang nog beter en beter te beheersen, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation) klasse.  
2. Pas een Slide Transition Type toe op de dia van een van de overgangseffecten die door Aspose.Slides for Node.js via Java worden aangeboden.  
3. U kunt de overgang ook instellen op Advance On Click, na een specifieke tijdsperiode of beide.  
4. Als de dia‑overgang is ingeschakeld voor Advance On Click, wordt de overgang alleen voortgezet wanneer iemand klikt. Bovendien, als de eigenschap Advance After Time is ingesteld, wordt de overgang automatisch voortgezet zodra de opgegeven tijd is verstreken.  
5. Schrijf de gewijzigde presentatie weg als een presentatie‑bestand.

```javascript
// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // Pas een cirkeltype‑overgang toe op dia 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Stel de overgangstijd in op 3 seconden
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // Pas een kamtype‑overgang toe op dia 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Stel de overgangstijd in op 5 seconden
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // Pas een zoomtype‑overgang toe op dia 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // Stel de overgangstijd in op 7 seconden
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // Schrijf de presentatie naar de schijf
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph‑overgang**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java ondersteunt nu de [Morph Transition](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/MorphTransition). Ze vertegenwoordigen de nieuwe morph‑overgang die is geïntroduceerd in PowerPoint 2019.

{{% /alert %}} 

De Morph‑overgang maakt het mogelijk om een soepele beweging te animeren van de ene dia naar de volgende. Dit artikel beschrijft het concept en hoe u de Morph‑overgang gebruikt. Om de Morph‑overgang effectief te gebruiken, heeft u twee dia’s nodig met ten minste één gemeenschappelijk object. De makkelijkste manier is om de dia te dupliceren en vervolgens het object op de tweede dia naar een andere plaats te verplaatsen.

De volgende code‑fragment toont hoe u een kloon van de dia met een stukje tekst aan de presentatie toevoegt en een overgang van het type [morph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TransitionType) instelt voor de tweede dia.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph‑overgangstypen**
Er is een nieuwe enum [TransitionMorphType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TransitionMorphType) geïntroduceerd. Deze vertegenwoordigt verschillende typen Morph‑dia‑overgangen.

De TransitionMorphType‑enum heeft drie leden:

- **ByObject**: Morph‑overgang wordt uitgevoerd met vormen als ondeelbare objecten.  
- **ByWord**: Morph‑overgang wordt uitgevoerd door tekst woord voor woord over te dragen waar mogelijk.  
- **ByChar**: Morph‑overgang wordt uitgevoerd door tekst teken voor teken over te dragen waar mogelijk.

De volgende code‑fragment toont hoe u een morph‑overgang op een dia instelt en het morph‑type wijzigt:

```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Overgangseffecten instellen**
Aspose.Slides for Node.js via Java ondersteunt het instellen van overgangseffecten zoals “van zwart”, “van links”, “van rechts”, enzovoort. Volg de onderstaande stappen om een overgangseffect in te stellen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.  
- Haal de referentie van de dia op.  
- Stel het overgangseffect in.  
- Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

In het onderstaande voorbeeld hebben we de overgangseffecten ingesteld.

```javascript
// Maak een instantie van de Presentation-klasse
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Stel effect in
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // Schrijf de presentatie naar de schijf
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan ik de afspeelsnelheid van een dia‑overgang regelen?**

Ja. Stel de [speed](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/setspeed/) van de overgang in via de instelling [TransitionSpeed](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/transitionspeed/) (bijv. slow/medium/fast).

**Kan ik audio aan een overgang koppelen en laten herhalen?**

Ja. U kunt een geluid voor de overgang insluiten en het gedrag via instellingen zoals geluidsmodus en looping regelen (bijv. [setSound](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/), plus metadata zoals [setSoundIsBuiltIn](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) en [setSoundName](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/setsoundname/)).

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Configureer het gewenste overgangstype op de overgangsinstellingen van elke dia; overgangen worden per dia opgeslagen, dus door hetzelfde type op alle dia’s toe te passen krijgt u een consistent resultaat.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Inspecteer de [transition settings](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) van de dia en lees het [transition type](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/gettype/); die waarde vertelt u precies welk effect is toegepast.