---
title: Hantera bildspel i JavaScript
linktitle: Bildspel
type: docs
weight: 90
url: /sv/nodejs-java/manage-slide-show/
keywords:
- visningstyp
- presenterad av talare
- bläddrad av enskild
- bläddrad i kiosk
- visningsalternativ
- loopa kontinuerligt
- visa utan berättarröst
- visa utan animation
- pennfärg
- visa bilder
- anpassad visning
- avancera bilder
- manuellt
- med tidsinställningar
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera bildspel i JavaScript med Aspose.Slides för Node.js. Kontrollera bildövergångar, tidsinställningar och mer i PPT-, PPTX- och ODP-format med lätthet."
---
## **Introduktion**

I Microsoft PowerPoint är inställningarna för **Slide Show** ett nyckelverktyg för att förbereda och leverera professionella presentationer. En av de viktigaste funktionerna i detta avsnitt är **Set Up Show**, som låter dig anpassa presentationen till specifika förhållanden och målgrupper, vilket säkerställer flexibilitet och bekvämlighet. Med den här funktionen kan du välja visningstyp (t.ex. presenterad av en talare, bläddrad av en enskild person eller bläddrad i en kiosk), aktivera eller inaktivera looping, välja specifika bilder att visa samt använda tidsinställningar. Detta steg i förberedelsen är avgörande för att göra din presentation mer effektiv och professionell.

`getSlideShowSettings` är en metod i klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) som returnerar ett objekt av typen [SlideShowSettings](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowsettings/), vilket gör att du kan hantera bildspelsinställningarna i en PowerPoint-presentation. I den här artikeln kommer vi att utforska hur du använder denna metod för att konfigurera och kontrollera olika aspekter av bildspelsinställningarna. 

## **Välj visningstyp**

`SlideShowSettings.setSlideShowType` definierar typen av bildspel, som kan vara en instans av följande klasser: [PresentedBySpeaker](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/browsedbyindividual/) eller [BrowsedAtKiosk](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/browsedatkiosk/). Genom att använda denna metod kan du anpassa presentationen för olika användningsscenarier, såsom automatiska kiosker eller manuella presentationer.

Kodexemplet nedan skapar en ny presentation och ställer in visningstypen till "Browsed by an individual" utan att visa rullningslisten.

```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Aktivera visningsalternativ**

`SlideShowSettings.setLoop` bestämmer om bildspelet ska upprepas i en loop tills det stoppas manuellt. Detta är användbart för automatiska presentationer som måste köras kontinuerligt. `SlideShowSettings.setShowNarration` bestämmer om röstberättelser ska spelas upp under bildspelet. Det är användbart för automatiska presentationer som innehåller röstvägledning för publiken. `SlideShowSettings.setShowAnimation` bestämmer om animationer som lagts till bildobjekt ska spelas upp. Detta är användbart för att ge den fulla visuella effekten av presentationen.

Följande kodexempel skapar en ny presentation och loopar bildspelet.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Välj bilder att visa**

`SlideShowSettings.setSlides`-metoden låter dig välja ett intervall av bilder som ska visas under presentationen. Detta är användbart när du bara behöver visa en del av presentationen snarare än alla bilder. Följande kodexempel skapar en ny presentation och anger bildintervallet att visa från bilder `2` till `9`.

```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Använd förskjutna bilder**

`SlideShowSettings.setUseTimings`-metoden låter dig aktivera eller inaktivera användningen av förinställda tidsinställningar för varje bild. Detta är användbart för att automatiskt visa bilder med fördefinierade visningstider. Kodexemplet nedan skapar en ny presentation och inaktiverar användningen av tidsinställningar.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Visa mediakontroller**

`SlideShowSettings.setShowMediaControls`-metoden bestämmer om mediakontroller (såsom spela, pausa och stoppa) ska visas under bildspelet när multimediainnehåll (t.ex. video eller ljud) spelas. Detta är användbart när du vill ge presentatören kontroll över mediuppspelning under presentationen.

Följande kodexempel skapar en ny presentation och aktiverar visning av mediakontroller.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Kan jag spara en presentation så att den öppnas direkt i bildspelsläge?**

Ja. Spara filen som PPSX eller PPSM; dessa format startar direkt i bildspelsläge när de öppnas i PowerPoint. I Aspose.Slides, välj motsvarande sparaformat [under export](/slides/sv/nodejs-java/save-presentation/).

**Kan jag utesluta enskilda bilder från visningen utan att radera dem från filen?**

Ja. Markera en bild som [hidden](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/sethidden/). Dolda bilder finns kvar i presentationen men visas inte under bildspelet.

**Kan Aspose.Slides spela upp ett bildspel eller kontrollera en live‑presentation på skärmen?**

Nej. Aspose.Slides redigerar, analyserar och konverterar presentationsfiler; den faktiska uppspelningen hanteras av ett visningsprogram såsom PowerPoint.