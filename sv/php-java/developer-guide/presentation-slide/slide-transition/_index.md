---
title: Hantera bildövergångar i presentationer med PHP
linktitle: Bildövergång
type: docs
weight: 80
url: /sv/php-java/slide-transition/
keywords:
- bildövergång
- lägga till bildövergång
- applicera bildövergång
- avancerad bildövergång
- morph‑övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Upptäck hur du anpassar bildövergångar i Aspose.Slides för PHP via Java, med steg‑för‑steg‑vägledning för PowerPoint‑ och OpenDocument‑presentationer."
---
## **Översikt**

Denna artikel förklarar hur man hanterar bildövergångar i presentationer med Aspose.Slides. Den visar hur man applicerar övergångstyper på bilder, konfigurerar övergångsbeteende såsom att gå vidare på klick eller efter en angiven tid, kontrollerar och inaktiverar automatisk vidaregång, använder Morph‑övergången och dess typer, samt ställer in alternativ för övergångseffekter. Exemplen demonstrerar hur man läser in eller skapar en presentation, modifierar övergångsinställningar för valda bilder och sparar resultatet som en PPTX‑fil. Artikeln svarar också på vanliga frågor om övergångshastighet, övergångsljud, att applicera samma övergång på flera bilder och hur man kontrollerar vilken övergång som för närvarande är inställd på en bild.

## **Lägg till bildövergång**
För att skapa en enkel bildövergångseffekt, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation) klass.
2. Applicera en Bildövergångstyp på bilden från en av övergångseffekterna som erbjuds av Aspose.Slides för PHP via Java via enumen TransitionType
3. Skriv den modifierade presentationsfilen.

```php
  # Instansiera Presentation-klassen för att läsa in källpresentationsfilen
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Applicera cirkeltyp övergång på bild 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Applicera kamtyp övergång på bild 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Skriv presentationen till disk
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Lägg till avancerad bildövergång**
I avsnittet ovan applicerade vi bara en enkel övergångseffekt på bilden. Nu, för att göra den enkla övergångseffekten ännu bättre och mer kontrollerad, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation) klass.
2. Applicera en Bildövergångstyp på bilden från en av övergångseffekterna som erbjuds av Aspose.Slides för PHP via Java
3. Du kan också ställa in övergången att gå vidare på klick, efter en specifik tidsperiod eller båda.
4. Om bildövergången är aktiverad för Att gå vidare på klick, kommer övergången endast att gå vidare när någon klickar med musen. Dessutom, om egenskapen Advance After Time är inställd, kommer övergången att gå vidare automatiskt efter att den angivna tiden har passerat.
5. Skriv den modifierade presentationen som en presentationsfil.

```php
  # Instansiera Presentation-klass som representerar en presentationsfil
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Applicera cirkeltyp övergång på bild 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Ställ in övergångstiden till 3 sekunder
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Applicera kamtyp övergång på bild 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Ställ in övergångstiden till 5 sekunder
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Applicera zoomtyp övergång på bild 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Ställ in övergångstiden till 7 sekunder
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Skriv presentationen till disk
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Morph‑övergång**
{{% alert color="primary" %}} 

Aspose.Slides för PHP via Java stöder nu [Morph Transition](https://reference.aspose.com/slides/sv/php-java/aspose.slides/morphtransition/). De representerar den nya morph‑övergången som introducerades i PowerPoint 2019.

{{% /alert %}} 

Morph‑övergången låter dig animera en jämn rörelse från en bild till nästa. Denna artikel beskriver konceptet och hur man använder Morph‑övergången. För att använda Morph‑övergången effektivt behöver du två bilder med minst ett gemensamt objekt. Det enklaste sättet är att duplicera bilden och sedan flytta objektet på den andra bilden till en annan plats.

Följande kodexempel visar hur du lägger till en klon av bilden med lite text i presentationen och ställer in en övergång av [morph type](https://reference.aspose.com/slides/sv/php-java/aspose.slides/TransitionType) på den andra bilden.

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Morph‑övergångstyper**
Ny enum [TransitionMorphType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/TransitionMorphType) har lagts till. Den representerar olika typer av Morph‑bildövergång.

TransitionMorphType‑enum har tre medlemmar:

- ByObject: Morph‑övergången utförs med hänsyn till former som odelbara objekt.
- ByWord: Morph‑övergången utförs genom att överföra text ord för ord där det är möjligt.
- ByChar: Morph‑övergången utförs genom att överföra text tecken för tecken där det är möjligt.

Följande kodexempel visar hur du ställer in en morph‑övergång på en bild och ändrar morph‑typ:

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Ställ in övergångseffekter**
Aspose.Slides för PHP via Java stödjer att ställa in övergångseffekter såsom från svart, från vänster, från höger etc. För att sätta övergångseffekten, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) klass.
- Hämta referensen till bilden.
- Ställ in övergångseffekten.
- Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/) fil.

I exemplet nedan har vi ställt in övergångseffekterna.

```php
  # Skapa en instans av Presentation-klassen
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Ställ in effekt
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Skriv presentationen till disk
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Vanliga frågor**

**Kan jag styra uppspelningshastigheten för en bildövergång?**

Ja. Ställ in övergångens [speed](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/setspeed/) med hjälp av inställningen [TransitionSpeed](https://reference.aspose.com/slides/sv/php-java/aspose.slides/transitionspeed/) (t.ex. långsam/medel/snabb).

**Kan jag bifoga ljud till en övergång och låta den loopa?**

Ja. Du kan bädda in ett ljud för övergången och styra beteendet via inställningar som ljudläge och looping (t.ex. [setSound](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/setsoundloop/), samt metadata såsom [setSoundIsBuiltIn](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) och [setSoundName](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**Vad är det snabbaste sättet att applicera samma övergång på varje bild?**

Konfigurera önskad övergångstyp i varje bilds övergångsinställningar; övergångar lagras per bild, så att applicera samma typ på alla bilder ger ett konsekvent resultat.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Inspektera bildens [transition settings](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslide/#getSlideShowTransition) och läs dess [transition type](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowtransition/settype/); det värdet visar exakt vilken effekt som är tillämpad.