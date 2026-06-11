---
title: Hantera bildspel i PHP
linktitle: Bildspel
type: docs
weight: 90
url: /sv/php-java/manage-slide-show/
keywords:
- visningstyp
- presenterad av talare
- bläddrad av individ
- bläddrad i kiosk
- visningsalternativ
- upprepa kontinuerligt
- visa utan berättarröst
- visa utan animation
- penfärg
- visa bilder
- anpassad visning
- avancera bilder
- manuellt
- med tider
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du hanterar bildspel i Aspose.Slides för PHP via Java. Kontrollera bildövergångar, tidsinställningar och mer i PPT-, PPTX- och ODP-format med lätthet."
---
## **Introduktion**

I Microsoft PowerPoint är inställningarna för **Slide Show** ett viktigt verktyg för att förbereda och leverera professionella presentationer. En av de viktigaste funktionerna i detta avsnitt är **Set Up Show**, som låter dig anpassa din presentation till specifika förhållanden och målgrupper, vilket säkerställer flexibilitet och bekvämlighet. Med denna funktion kan du välja visningstyp (t.ex. presenterad av en talare, bläddrad av en individ eller bläddrad i en kiosk), aktivera eller inaktivera looping, välja specifika bilder att visa och använda tidsinställningar. Detta steg i förberedelsen är avgörande för att göra din presentation mer effektiv och professionell.

`getSlideShowSettings` är en metod i klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) som returnerar ett objekt av typen [SlideShowSettings](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideshowsettings/), vilket låter dig hantera bildspelsinställningarna i en PowerPoint-presentation. I den här artikeln kommer vi att utforska hur man använder metoden för att konfigurera och kontrollera olika aspekter av bildspelsinställningarna. 

## **Välj visningstyp**

`SlideShowSettings->setSlideShowType` definierar typen av bildspel, som kan vara en instans av följande klasser: [PresentedBySpeaker](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/sv/php-java/aspose.slides/browsedbyindividual/), eller [BrowsedAtKiosk](https://reference.aspose.com/slides/sv/php-java/aspose.slides/browsedatkiosk/). Med denna metod kan du anpassa presentationen för olika användningsscenario, såsom automatiserade kiosker eller manuella presentationer.

Kodexemplet nedan skapar en ny presentation och ställer in visningstypen till "Browsed by an individual" utan att visa rullningslisten.

```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Aktivera visningsalternativ**

`SlideShowSettings->setLoop` avgör om bildspelet ska upprepas i en slinga tills det stoppas manuellt. Detta är användbart för automatiserade presentationer som måste köras kontinuerligt. `SlideShowSettings->setShowNarration` avgör om röstberättelser ska spelas upp under bildspelet. Det är användbart för automatiserade presentationer som innehåller röstvägledning för publiken. `SlideShowSettings->setShowAnimation` avgör om animationer som lagts till bildobjekt ska spelas upp. Detta är användbart för att ge den fulla visuella effekten av presentationen.

Följande kodexempel skapar en ny presentation och loopar bildspelet.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Välj bilder att visa**

`SlideShowSettings->setSlides`‑metoden låter dig välja ett intervall av bilder som ska visas under presentationen. Detta är praktiskt när du bara vill visa en del av presentationen istället för alla bilder. Följande kodexempel skapar en ny presentation och anger bildintervallet så att bilder `2` till `9` visas.

```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Använd förinställda tider**

`SlideShowSettings->setUseTimings`‑metoden låter dig aktivera eller inaktivera användning av fördefinierade tider för varje bild. Detta är användbart för att automatiskt visa bilder med förbestämda visningstider. Kodexemplet nedan skapar en ny presentation och inaktiverar användning av tider.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Visa mediekontroller**

`SlideShowSettings->setShowMediaControls`‑metoden avgör om mediekontroller (såsom spela, pausa och stoppa) ska visas under bildspelet när multimediainnehåll (t.ex. video eller ljud) spelas upp. Detta är praktiskt när du vill ge presentatören kontroll över medieuppspelning under presentationen.

Följande kodexempel skapar en ny presentation och aktiverar visning av mediekontroller.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **FAQ**

**Kan jag spara en presentation så att den öppnas direkt i bildspelsläge?**

Ja. Spara filen som PPSX eller PPSM; dessa format startar direkt i bildspel när de öppnas i PowerPoint. I Aspose.Slides väljer du motsvarande sparaformat [under export](/slides/sv/php-java/save-presentation/).

**Kan jag exkludera enskilda bilder från visningen utan att ta bort dem från filen?**

Ja. Markera en bild som [hidden](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/sethidden/). Dolda bilder finns kvar i presentationen men visas inte under bildspelet.

**Kan Aspose.Slides spela upp ett bildspel eller kontrollera en livepresentation på skärmen?**

Nej. Aspose.Slides redigerar, analyserar och konverterar presentationsfiler; den faktiska uppspelningen hanteras av en visningsapplikation som PowerPoint.