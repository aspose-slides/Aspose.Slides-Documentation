---
title: Hantera bildövergångar i presentationer på Android
linktitle: Bildövergång
type: docs
weight: 80
url: /sv/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "Upptäck hur du anpassar bildövergångar i Aspose.Slides för Android via Java, med steg‑för‑steg‑vägledning för PowerPoint‑ och OpenDocument‑presentationer."
---
## **Översikt**

Den här artikeln förklarar hur du hanterar bildövergångar i presentationer med Aspose.Slides. Den visar hur du tillämpar övergångstyper på bilder, konfigurerar övergångsbeteende såsom att gå vidare vid klick eller efter en angiven tid, använder Morph‑övergången och dess typer samt anger alternativ för övergångseffekter. Exemplen demonstrerar hur du laddar eller skapar en presentation, ändrar övergångsinställningar för utvalda bilder och sparar resultatet som en PPTX‑fil. Artikeln svarar också på vanliga frågor om övergångshastighet, övergångsljud, att tillämpa samma övergång på flera bilder och hur du kontrollerar vilken övergång som för närvarande är inställd på en bild.

## **Lägg till bildövergång**
För att skapa en enkel bildövergångseffekt, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) klassen.
2. Tillämpa en Slide Transition Type på bilden från någon av de övergångseffekter som Aspose.Slides for Android via Java erbjuder via enumen TransitionType.
3. Skriv den modifierade presentationsfilen.

```java
import com.aspose.slides.*;

// Instansiera Presentation‑klassen för att läsa in källpresentationen
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Tillämpa Circle‑typ‑övergång på bild 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Tillämpa Comb‑typ‑övergång på bild 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Spara presentationen till disk
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lägg till avancerad bildövergång**
I avsnittet ovan applicerade vi bara en enkel övergångseffekt på bilden. För att göra den enkla övergången ännu bättre och mer kontrollerad, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) klassen.
2. Tillämpa en Slide Transition Type på bilden från någon av de övergångseffekter som Aspose.Slides for Android via Java erbjuder.
3. Du kan också ställa in övergången på Advance On Click, efter en specifik tidsperiod eller båda.
4. Om bildövergången är aktiverad för Advance On Click kommer övergången endast att gå vidare när någon klickar med musen. Om egenskapen Advance After Time är inställd, kommer övergången automatiskt att gå vidare efter den angivna tiden har passerat.
5. Spara den modifierade presentationen som en presentationsfil.

```java
import com.aspose.slides.*;

// Instansiera Presentation‑klassen som representerar en presentationsfil
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Tillämpa Circle‑typ‑övergång på bild 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Gå vidare vid klick eller automatiskt efter 3 sekunder
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Tillämpa Comb‑typ‑övergång på bild 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Gå vidare vid klick eller automatiskt efter 5 sekunder
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Tillämpa Zoom‑typ‑övergång på bild 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Gå vidare vid klick eller automatiskt efter 7 sekunder
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Spara presentationen till disk
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph‑övergång**
{{% alert color="info" %}} 

Aspose.Slides for Android via Java stödjer nu [Morph Transition](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IMorphTransition). De representerar den nya morph‑övergång som introducerades i PowerPoint 2019.

{{% /alert %}} 

Morph‑övergången låter dig animera en mjuk förflyttning från en bild till nästa. Denna artikel beskriver konceptet och hur du använder Morph‑övergången. För att använda Morph‑övergången effektivt behöver du två bilder med minst ett gemensamt objekt. Det enklaste sättet är att duplicera bilden och sedan flytta objektet på den andra bilden till en annan plats.

Följande kodsnutt visar hur du lägger till en klon av bilden med lite text i presentationen och anger en övergång av [morph type](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TransitionType) på den andra bilden.

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

## **Morph‑övergångstyper**
Den nya enumen [TransitionMorphType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TransitionMorphType) har lagts till. Den representerar olika typer av Morph‑bildövergång.

Enumen TransitionMorphType har tre medlemmar:

- ByObject: Morph‑övergången utförs med bildobjekt betraktade som odelbara objekt.
- ByWord: Morph‑övergången utförs genom att överföra text ord för ord där det är möjligt.
- ByChar: Morph‑övergången utförs genom att överföra text tecken för tecken där det är möjligt.

Följande kodsnutt visar hur du anger en morph‑övergång på en bild och ändrar morph‑typ:

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

## **Ställ in övergångseffekter**
Aspose.Slides for Android via Java stödjer att ange övergångseffekter som från svart, från vänster, från höger osv. För att ställa in övergångseffekten, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) klassen.
- Hämta referensen till bilden.
- Ställ in övergångseffekten.
- Skriv presentationen som en [PPTX ](https://docs.fileformat.com/presentation/pptx/)fil.

I exemplet nedan har vi ställt in övergångseffekterna.

```java
import com.aspose.slides.*;

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

### Kan jag kontrollera uppspelningshastigheten för en bildövergång?

Ja. Ange övergångens [speed](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) med hjälp av inställningen [TransitionSpeed](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/transitionspeed/) (t.ex. långsam/medel/fast).

### Kan jag bifoga ljud till en övergång och låta den loopa?

Ja. Du kan bädda in ett ljud för övergången och styra beteendet via inställningar som ljudläge och loopning (t.ex. [setSound](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), samt metadata som [setSoundIsBuiltIn](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) och [setSoundName](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Vad är det snabbaste sättet att tillämpa samma övergång på varje bild?

Konfigurera önskad övergångstyp i varje bilds övergångsinställningar; övergångar lagras per bild, så att tillämpa samma typ på alla bilder ger ett enhetligt resultat.

### Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?

Inspektera bildens [transition settings](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) och läs dess [transition type](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); det värdet visar exakt vilken effekt som är applicerad.