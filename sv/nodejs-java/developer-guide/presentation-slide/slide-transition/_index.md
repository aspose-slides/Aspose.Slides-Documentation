---
title: Hantera bildövergångar i presentationer med JavaScript
linktitle: Bildövergång
type: docs
weight: 80
url: /sv/nodejs-java/slide-transition/
keywords:
- bildövergång
- lägg till bildövergång
- tillämpa bildövergång
- avancerad bildövergång
- Morph‑övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Anpassa bildövergångar i JavaScript med Aspose.Slides för Node.js via Java, med steg‑för‑steg‑vägledning för PowerPoint‑ och OpenDocument‑presentationer."
---
## **Översikt**

Denna artikel förklarar hur man hanterar bildspelsövergångar i presentationer med Aspose.Slides. Den visar hur man tillämpar övergångstyper på bilder, konfigurerar övergångsbeteende såsom att gå vidare vid klick eller efter en angiven tid, kontrollerar och inaktiverar automatisk vidaregång, använder Morph‑övergången och dess typer, samt ställer in alternativ för övergångseffekter. Exemplen demonstrerar hur man laddar eller skapar en presentation, modifierar övergångsinställningar för valda bilder och sparar resultatet som en PPTX‑fil. Artikeln svarar också på vanliga frågor om övergångshastighet, övergångsljud, att använda samma övergång på flera bilder och hur man kontrollerar vilken övergång som för närvarande är inställd på en bild.

## **Lägg till bildövergång**
För att skapa en enkel bildövergångseffekt, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) klass.
2. Applicera en Slide Transition Type på bilden från ett av övergångseffekterna som erbjuds av Aspose.Slides för Node.js via Java genom TransitionType‑enum
3. Skriv den modifierade presentationsfilen.

```javascript
// Skapa en instans av Presentation-klassen för att ladda källpresentationen
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Applicera cirkeltyp övergång på bild 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Applicera kamtyp övergång på bild 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Skriv presentationen till disk
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lägg till avancerad bildövergång**
I föregående avsnitt tillämpade vi bara en enkel övergångseffekt på bilden. Nu, för att göra den enkla övergångseffekten ännu bättre och kontrollerad, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) klass.
2. Applicera en Slide Transition Type på bilden från ett av övergångseffekterna som erbjuds av Aspose.Slides för Node.js via Java
3. Du kan också ställa in övergången att gå vidare vid klick, efter en specifik tidsperiod eller båda.
4. Om bildövergången är aktiverad för Advance On Click, kommer övergången bara att gå vidare när någon klickar med musen. Dessutom, om egenskapen Advance After Time är inställd, kommer övergången att gå vidare automatiskt efter att den angivna tiden har passerat.
5. Skriv den modifierade presentationen som en presentationsfil.

```javascript
// Skapa en instans av Presentation-klassen som representerar en presentationsfil
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // Applicera cirkeltyp övergång på bild 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Ställ in övergångstiden till 3 sekunder
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // Applicera kamtyp övergång på bild 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Ställ in övergångstiden till 5 sekunder
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // Applicera zoomtyp övergång på bild 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // Ställ in övergångstiden till 7 sekunder
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // Skriv presentationen till disk
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph‑övergång**
{{% alert color="primary" %}} 

Aspose.Slides för Node.js via Java stöder nu [Morph Transition](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/MorphTransition). De representerar den nya morph‑övergången som infördes i PowerPoint 2019.

{{% /alert %}} 

Morph‑övergången låter dig animera en smidig förflyttning från en bild till nästa. Denna artikel beskriver konceptet och hur man använder Morph‑övergången. För att använda Morph‑övergången effektivt behöver du två bilder med minst ett gemensamt objekt. Det enklaste sättet är att duplicera bilden och sedan flytta objektet på den andra bilden till en annan plats.

Följande kodsnutt visar hur du lägger till en klon av bilden med någon text till presentationen och anger en övergång av [morph type](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TransitionType) till den andra bilden.

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

## **Morph‑övergångstyper**
Den nya enum‑typen [TransitionMorphType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TransitionMorphType) har lagts till. Den representerar olika typer av Morph‑bildövergång.

TransitionMorphType‑enum har tre medlemmar:

- ByObject: Morph‑övergången utförs med hänsyn till former som odelbara objekt.
- ByWord: Morph‑övergången utförs genom att överföra text ord för ord där det är möjligt.
- ByChar: Morph‑övergången utförs genom att överföra text tecken för tecken där det är möjligt.

Följande kodsnutt visar hur du ställer in morph‑övergång på en bild och ändrar morph‑typ:

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

## **Ställ in övergångseffekter**
Aspose.Slides för Node.js via Java stöder att ställa in övergångseffekter som från svart, från vänster, från höger etc. För att ställa in övergångseffekten, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) klass.
- Hämta referensen till bilden.
- Ställ in övergångseffekten.
- Skriv presentationen som en [PPTX ](https://docs.fileformat.com/presentation/pptx/)fil.

I exemplet nedan har vi ställt in övergångseffekterna.

```javascript
// Skapa en instans av Presentation-klassen
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Ställ in effekt
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // Skriv presentationen till disk
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan jag kontrollera uppspelningshastigheten för en bildövergång?**

Ja. Ställ in övergångens [speed](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/setspeed/) med hjälp av inställningen [TransitionSpeed](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/transitionspeed/) (t.ex. slow/medium/fast).

**Kan jag bifoga ljud till en övergång och låta den loopa?**

Ja. Du kan bädda in ett ljudeffekts för övergången och kontrollera beteendet via inställningar som ljudläge och loopning (t.ex. [setSound](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/), samt metadata såsom [setSoundIsBuiltIn](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) och [setSoundName](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/setsoundname/)).

**Vad är det snabbaste sättet att tillämpa samma övergång på varje bild?**

Konfigurera önskad övergångstyp i varje bilds övergångsinställningar; övergångar lagras per bild, så att tillämpa samma typ på alla bilder ger ett konsekvent resultat.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Inspektera bildens [transition settings](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) och läs dess [transition type](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/gettype/); det värdet visar exakt vilken effekt som har tillämpats.