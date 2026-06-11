---
title: Hantera bildövergångar i presentationer på Android
linktitle: Bildövergång
type: docs
weight: 80
url: /sv/androidjava/slide-transition/
keywords:
- bildövergång
- lägga till bildövergång
- tillämpa bildövergång
- avancerad bildövergång
- morph-övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Upptäck hur du anpassar bildövergångar i Aspose.Slides för Android via Java, med steg-för-steg-instruktioner för PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man hanterar bildövergångar i presentationer med Aspose.Slides. Den visar hur man tillämpar övergångstyper på bilder, konfigurerar övergångsbeteende såsom att gå vidare på klick eller efter en angiven tid, kontrollerar och inaktiverar automatisk vidaregång, använder Morph‑övergången och dess typer, samt ställer in alternativ för övergångseffekter. Exemplen demonstrerar hur man laddar eller skapar en presentation, ändrar övergångsinställningarna för valda bilder och sparar resultatet som en PPTX‑fil. Artikeln svarar också på vanliga frågor om övergångshastighet, övergångsljud, att tillämpa samma övergång på flera bilder och hur man kontrollerar vilken övergång som för närvarande är inställd på en bild.

## **Lägg till bildövergång**
1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) klass.  
2. Applicera en bildövergångstyp på bilden från en av de övergångseffekter som erbjuds av Aspose.Slides för Android via Java genom TransitionType‑enum.  
3. Skriv den modifierade presentationsfilen.  

```java
// Instansiera Presentation-klassen för att läsa in källpresentationsfilen
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Använd cirkeltyp övergång på bild 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Använd kombinationstyp övergång på bild 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Skriv presentationen till disk
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lägg till avancerad bildövergång**
1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) klass.  
2. Applicera en bildövergångstyp på bilden från en av de övergångseffekter som erbjuds av Aspose.Slides för Android via Java.  
3. Du kan också ställa in övergången att gå vidare på klick, efter en specifik tidsperiod eller båda.  
4. Om bildövergången är aktiverad för att gå vidare på klick, kommer övergången endast att gå vidare när någon klickar med musen. Dessutom, om egenskapen Advance After Time är angiven, kommer övergången att gå vidare automatiskt efter att den specificerade tiden har passerat.  
5. Skriv den modifierade presentationen som en presentationsfil.  

```java
// Instansiera Presentation-klassen som representerar en presentationsfil
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Använd cirkeltyp övergång på bild 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Ställ in övergångstiden till 3 sekunder
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Använd comb-typ övergång på bild 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Ställ in övergångstiden till 5 sekunder
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Använd zoom-typ övergång på bild 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Ställ in övergångstiden till 7 sekunder
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
Aspose.Slides för Android via Java stödjer nu [Morph Transition](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IMorphTransition). De representerar den nya morph‑övergång som introducerades i PowerPoint 2019. 
{{% /alert %}} 

Morph‑övergången låter dig animera en smidig rörelse från en bild till nästa. Den här artikeln beskriver konceptet och hur man använder Morph‑övergången. För att använda Morph‑övergången effektivt behöver du två bilder med minst ett gemensamt objekt. Det enklaste är att duplicera bilden och sedan flytta objektet på den andra bilden till en annan plats.

Följande kodexempel visar hur du lägger till en klon av bilden med lite text i presentationen och ställer in en övergång av [morph type](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TransitionType) på den andra bilden.

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
Den nya [TransitionMorphType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TransitionMorphType)‑enum har lagts till. Den representerar olika typer av Morph‑bildövergång.

TransitionMorphType‑enum har tre medlemmar:

- ByObject: Morph‑övergången utförs med hänsyn till former som odelbara objekt.  
- ByWord: Morph‑övergången utförs genom att överföra text ord för ord där det är möjligt.  
- ByChar: Morph‑övergången utförs genom att överföra text tecken för tecken där det är möjligt.  

Följande kodexempel visar hur du ställer in morph‑övergång på en bild och ändrar morph‑typ:

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
Aspose.Slides för Android via Java stöder att ställa in övergångseffekter såsom från svart, från vänster, från höger med mera. För att sätta en övergångseffekt, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) klass.  
- Hämta referensen till bilden.  
- Ställ in övergångseffekten.  
- Skriv presentationen som en [PPTX ](https://docs.fileformat.com/presentation/pptx/)‑fil.  

I exemplet nedan har vi ställt in övergångseffekterna.

```java
// Skapa en instans av Presentation-klassen
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Ange effekt
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Skriv presentationen till disk
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan jag kontrollera uppspelningshastigheten för en bildövergång?**

Ja. Ställ in övergångens [speed](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) med hjälp av [TransitionSpeed](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/transitionspeed/)-inställningen (t.ex. slow/medium/fast).

**Kan jag bifoga ljud till en övergång och få den att loopa?**

Ja. Du kan bädda in ett ljud för övergången och styra beteendet via inställningar såsom ljudläge och loopning (t.ex. [setSound](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), samt metadata som [setSoundIsBuiltIn](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) och [setSoundName](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Vad är det snabbaste sättet att tillämpa samma övergång på varje bild?**

Konfigurera önskad övergångstyp i varje bilds övergångsinställningar; övergångar lagras per bild, så att tillämpa samma typ på alla bilder ger ett enhetligt resultat.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Inspektera bildens [transition settings](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) och läs dess [transition type](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); det värdet visar exakt vilken effekt som är tillämpad.