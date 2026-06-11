---
title: "Hantera bildövergångar i presentationer med Java"
linktitle: "Bildövergång"
type: docs
weight: 80
url: /sv/java/slide-transition/
keywords:
- bildövergång
- lägg till bildövergång
- tillämpa bildövergång
- avancerad bildövergång
- morph‑övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Upptäck hur du anpassar bildövergångar i Aspose.Slides för Java, med steg‑för‑steg‑instruktioner för PowerPoint‑ och OpenDocument‑presentationer."
---
## **Översikt**

Denna artikel förklarar hur du hanterar bildövergångar i presentationer med Aspose.Slides. Den visar hur du tillämpar övergångstyper på bilder, konfigurerar övergångsbeteende såsom att gå vidare vid klick eller efter en angiven tid, kontrollerar och inaktiverar automatisk förflyttning, använder Morph‑övergången och dess typer samt ställer in alternativ för övergångseffekter. Exemplen visar hur du laddar eller skapar en presentation, modifierar övergångsinställningar för valda bilder och sparar resultatet som en PPTX‑fil. Artikeln svarar också på vanliga frågor om övergångshastighet, övergångsljud, att applicera samma övergång på flera bilder och hur du kontrollerar vilken övergång som för närvarande är inställd på en bild.

## **Lägg till bildövergång**
För att skapa en enkel bildövergångseffekt, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
2. Applicera en bildövergångstyp på bilden från ett av de övergångseffekter som erbjuds av Aspose.Slides för Java via enumen TransitionType.
3. Skriv den modifierade presentationsfilen.

```java
// Instansiera Presentation-klassen för att läsa in källpresentationen
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Tillämpa cirkel-typövergång på bild 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Tillämpa kam-typövergång på bild 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Spara presentationen till disk
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lägg till avancerad bildövergång**
I föregående avsnitt applicerade vi bara en enkel övergångseffekt på bilden. Nu, för att göra den enkla övergången ännu bättre och mer kontrollerad, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
2. Applicera en bildövergångstyp på bilden från ett av de övergångseffekter som erbjuds av Aspose.Slides för Java.
3. Du kan också sätta övergången att gå vidare vid klick, efter en specifik tidsperiod eller båda.
4. Om bildövergången är aktiverad för att gå vidare vid klick, kommer övergången endast att gå vidare när någon klickar med musen. Dessutom, om egenskapen Advance After Time är satt, kommer övergången automatiskt att gå vidare efter den angivna tiden har förflutit.
5. Skriv den modifierade presentationen som en presentationsfil.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Tillämpa cirkel-typövergång på bild 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Sätt övergångstiden till 3 sekunder
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Tillämpa kam-typövergång på bild 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Sätt övergångstiden till 5 sekunder
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Tillämpa zoom-typövergång på bild 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Sätt övergångstiden till 7 sekunder
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Skriv presentationen till disk
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph‑övergång**
{{% alert color="primary" %}} 

Aspose.Slides för Java stöder nu [Morph‑övergången](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IMorphTransition). De representerar den nya morph‑övergången som introducerades i PowerPoint 2019.

{{% /alert %}} 

Morph‑övergången låter dig animera en smidig förflyttning från en bild till nästa. Denna artikel beskriver konceptet och hur du använder Morph‑övergången. För att använda Morph‑övergången effektivt behöver du två bilder med minst ett gemensamt objekt. Det enklaste sättet är att duplicera bilden och sedan flytta objektet på den andra bilden till en annan plats.

Följande kodsnutt visar hur du lägger till en klon av bilden med lite text i presentationen och sätter en övergång av [morph‑typ](https://reference.aspose.com/slides/sv/java/com.aspose.slides/TransitionType) på den andra bilden.

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

## **Morph‑övergångstyper**
Den nya enumen [TransitionMorphType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/TransitionMorphType) har lagts till. Den representerar olika typer av Morph‑bildövergång.

Enumen TransitionMorphType har tre medlemmar:

- ByObject: Morph‑övergången utförs med hänsyn till former som odelbara objekt.
- ByWord: Morph‑övergången utförs genom att överföra text ord för ord där det är möjligt.
- ByChar: Morph‑övergången utförs genom att överföra text tecken för tecken där det är möjligt.

Följande kodsnutt visar hur du sätter en morph‑övergång på en bild och ändrar morph‑typ:

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

## **Ställ in övergångseffekter**
Aspose.Slides för Java stöder att ställa in övergångseffekter såsom från svart, från vänster, från höger osv. För att sätta en övergångseffekt, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
- Hämta referensen till bilden.
- Ställ in övergångseffekten.
- Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.

I exemplet nedan har vi satt övergångseffekterna.

```java
// Skapa en instans av Presentation-klassen
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Ställ in effekt
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Spara presentationen till disk
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vanliga frågor**

**Kan jag kontrollera uppspelningshastigheten för en bildövergång?**

Ja. Ställ in övergångens [speed](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) med hjälp av inställningen [TransitionSpeed](https://reference.aspose.com/slides/sv/java/com.aspose.slides/transitionspeed/) (t.ex. slow/medium/fast).

**Kan jag bifoga ljud till en övergång och få den att loopa?**

Ja. Du kan bädda in ett ljud för övergången och styra beteendet via inställningar som ljudläge och loopning (t.ex. [setSound](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), samt metadata som [setSoundIsBuiltIn](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) och [setSoundName](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Vad är det snabbaste sättet att applicera samma övergång på varje bild?**

Konfigurera önskad övergångstyp i varje bilds övergångsinställningar; övergångar lagras per bild, så att applicera samma typ på alla bilder ger ett enhetligt resultat.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Inspektera bildens [transition settings](https://reference.aspose.com/slides/sv/java/com.aspose.slides/baseslide/#getSlideShowTransition--) och läs dess [transition type](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideshowtransition/#setType-int-); det värdet visar exakt vilken effekt som är applicerad.