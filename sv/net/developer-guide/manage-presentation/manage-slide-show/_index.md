---
title: Hantera bildspel i .NET
linktitle: Bildspel
type: docs
weight: 90
url: /sv/net/manage-slide-show/
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
- med tidsinställningar
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du hanterar bildspel i Aspose.Slides för .NET. Kontrollera bildövergångar, tidsinställningar och mer i PPT-, PPTX- och ODP-format med lätthet."
---
## **Introduktion**

I Microsoft PowerPoint är inställningarna för **Bildspel** ett viktigt verktyg för att förbereda och leverera professionella presentationer. En av de mest betydelsefulla funktionerna i detta avsnitt är **Set Up Show**, som låter dig anpassa din presentation till specifika förhållanden och målgrupper, vilket säkerställer flexibilitet och bekvämlighet. Med den här funktionen kan du välja visningstyp (t.ex. presenterad av en talare, bläddrad av en individ eller bläddrad i en kiosk), aktivera eller inaktivera loopning, välja specifika bilder att visa och använda tidsinställningar. Detta steg i förberedelsen är avgörande för att göra din presentation mer effektiv och professionell.

`SlideShowSettings` är en egenskap i klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) av typen [SlideShowSettings](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/slideshowsettings/), som låter dig hantera bildspelsinställningarna i en PowerPoint-presentation. I den här artikeln kommer vi att utforska hur du använder den här egenskapen för att konfigurera och kontrollera olika aspekter av bildspelsinställningarna. 

## **Välj visningstyp**

`SlideShowSettings.SlideShowType` definierar typen av bildspel, vilket kan vara en instans av följande klasser: [PresentedBySpeaker](https://reference.aspose.com/slides/sv/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/sv/net/aspose.slides/browsedbyindividual/) eller [BrowsedAtKiosk](https://reference.aspose.com/slides/sv/net/aspose.slides/browsedatkiosk/). Genom att använda denna egenskap kan du anpassa presentationen för olika användningsscenario, såsom automatiserade kiosker eller manuella presentationer.

Kodexemplet nedan skapar en ny presentation och sätter visningstypen till ”Bläddrad av en individ” utan att visa rullningslisten.

```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Aktivera visningsalternativ**

`SlideShowSettings.Loop` avgör om bildspelet ska upprepas i en slinga tills det stoppas manuellt. Detta är användbart för automatiserade presentationer som måste köras kontinuerligt. `SlideShowSettings.ShowNarration` avgör om röstberättelser ska spelas upp under bildspelet. Det är användbart för automatiserade presentationer som innehåller röstinstruktioner för publiken. `SlideShowSettings.ShowAnimation` avgör om animationer som lagts till i bildobjekt ska spelas upp. Detta är användbart för att ge den fulla visuella effekten av presentationen.

Följande kodexempel skapar en ny presentation och loopar bildspelet.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Välj bilder att visa**

`SlideShowSettings.Slides`‑egenskapen låter dig välja ett intervall av bilder som ska visas under presentationen. Detta är användbart när du bara vill visa en del av presentationen istället för alla bilder. Följande kodexempel skapar en ny presentation och sätter bildintervallet till att visas från bild `2` till `9`.

```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Använd fördefinierade tider**

`SlideShowSettings.UseTimings`‑egenskapen låter dig aktivera eller inaktivera användning av förinställda tider för varje bild. Detta är användbart för att automatiskt visa bilder med fördefinierade visningstider. Kodexemplet nedan skapar en ny presentation och inaktiverar användning av tider.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Visa mediekontroller**

`SlideShowSettings.ShowMediaControls`‑egenskapen avgör om mediekontroller (såsom spela, pausa och stoppa) ska visas under bildspelet när multimediainnehåll (t.ex. video eller ljud) spelas upp. Detta är användbart när du vill ge presentatören kontroll över medieuppspelning under presentationen.

Följande kodexempel skapar en ny presentation och aktiverar visning av mediekontroller.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Kan jag spara en presentation så att den öppnas direkt i bildspelsläge?**

Ja. Spara filen som PPSX eller PPSM; dessa format startar direkt i bildspelsläge när de öppnas i PowerPoint. I Aspose.Slides väljer du motsvarande sparaformat [during export](/slides/sv/net/save-presentation/).

**Kan jag exkludera enskilda bilder från visningen utan att ta bort dem från filen?**

Ja. Markera en bild som [Hidden](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/hidden/). Dolda bilder finns kvar i presentationen men visas inte under bildspelet.

**Kan Aspose.Slides spela upp ett bildspel eller kontrollera en levande presentation på skärmen?**

Nej. Aspose.Slides redigerar, analyserar och konverterar presentationsfiler; den faktiska uppspelningen hanteras av ett visningsprogram såsom PowerPoint.