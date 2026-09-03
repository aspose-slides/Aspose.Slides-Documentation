---
title: Hantera bildövergångar i presentationer i .NET
linktitle: Bildövergång
type: docs
weight: 90
url: /sv/net/slide-transition/
keywords:
- bildövergång
- lägga till bildövergång
- tillämpa bildövergång
- avancerad bildövergång
- Morph-övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Tillämpa bildövergångar, konfigurera automatisk bildavancemang och anpassa Morph- och andra övergångseffekter med Aspose.Slides för .NET."
---
## **Översikt**

Bildövergångar styr hur bilder visas under en bildspelspresentation. Med Aspose.Slides för .NET kan du välja en övergångseffekt för varje bild, konfigurera avancerande med musklick eller timer och justera alternativ som är specifika för en effekt. Den här artikeln använder C#-exempel för att tillämpa övergångar, ange exakta övergångsdurationer, hantera bildens timing och skapa en Morph‑övergång mellan två bilder. Exemplen visar också hur du sparar inställningarna till en PPTX‑fil.

## **Lägg till bildövergång**

För att tillämpa en övergång, ladda en presentation med klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) och kom åt bildens egenskap [SlideShowTransition](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseslide/slideshowtransition/). Sätt dess [Type](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/type/) till ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/transitiontype/), och spara sedan presentationen.

Följande exempel tillämpar en Circle‑övergång på den första bilden och en Comb‑övergång på den andra. Använd en `input.pptx`‑fil med minst två bilder.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Lägg till avancerad bildövergång**

Du kan konfigurera hur länge en bild förblir på skärmen och om ett musklick avancerar bildspelsvisningen. Följande egenskaper styr detta beteende:

- [AdvanceOnClick](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/advanceonclick/) låter betraktaren gå vidare genom att klicka med musen.
- [AdvanceAfter](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/advanceafter/) möjliggör automatisk avancerning.
- [AdvanceAfterTime](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/advanceaftertime/) anger fördröjningen innan automatisk avancerning, i millisekunder.

Aktivera både klick‑ och tidsbaserad avancerning så att betraktaren kan gå vidare med ett klick eller vänta på timern. För att bara använda timern, sätt [AdvanceOnClick](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/advanceonclick/) till `false`. Fördröjningen styr när bildspelsvisningen avancerar; den anger inte varaktigheten för den visuella övergångseffekten.

Detta exempel tilldelar olika effekter till de tre första bilderna och aktiverar automatisk avancerning efter 3, 5 respektive 7 sekunder. Mus‑klick kan också gå vidare dessa bilder. Använd en `input.pptx`‑fil med minst tre bilder.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

För att kontrollera om tidsbaserad avancerning är aktiverad, läs [AdvanceAfter](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/advanceafter/). En lagrad fördröjning ensam indikerar inte att timern är aktiv.

Nästa exempel öppnar filen som sparades ovan, rapporterar varje aktiverad timer och inaktiverar automatisk avancerning för bilder med en fördröjning på mer än två sekunder. Det möjliggör mus‑klick för dessa bilder och sparar de uppdaterade inställningarna.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Styr övergångstid exakt**

Använd [Duration](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/duration/) för att ange den exakta längden på en övergångseffekt i millisekunder. Bildens egenskap [SlideShowTransition](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseslide/slideshowtransition/) visar dessa inställningar via [ISlideShowTransition](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/):

| Property | Syfte |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/duration/) | Anger varaktigheten för själva övergångseffekten, i millisekunder. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Anger fördröjningen innan bilden avancerar automatiskt, i millisekunder. Aktivera [AdvanceAfter](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/advanceafter/) för att slå på denna timer. |
| [Speed](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/speed/) | Väljer en fördefinierad hastighetskategori från [TransitionSpeed](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium eller Fast. Den används när ingen exakt varaktighet specificeras. |

[Duration](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/duration/) styr endast övergångseffekten; den bestämmer inte hur länge bilden förblir synlig. Konfigurera den automatiska avanceringsfördröjningen separat. När ingen explicit varaktighet är angiven bestämmer Aspose.Slides effektens varaktighet utifrån övergångstypen och [Speed](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/speed/)-värdet.

### **Tilldela samma varaktighet till varje bild**

För en jämn takt, tillämpa samma effekt och exakt varaktighet på varje bild. Detta exempel laddar `input.pptx`, väljer Fade från [TransitionType](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/transitiontype/), och ger varje övergång en varaktighet på 750 millisekunder. Det aktiverar separat automatisk avancerning efter 5 000 millisekunder och inaktiverar avancerning med musklick, och sparar sedan resultatet som PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // Konfigurera automatisk avancering oberoende av effektens varaktighet.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Ange olika varaktigheter för enskilda bilder**

Olika bilder kan ha olika effektvaraktigheter. Till exempel kan en kort övergång användas för en titelsida och en längre övergång för en sektionens introduktion. Detta exempel anger 500 millisekunder för den första bilden och 1 200 millisekunder för den andra. Använd en `input.pptx`‑fil med minst två bilder.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Koordinera övergångar med animerad output**

När du förbereder en [animated GIF](/slides/sv/net/convert-powerpoint-to-animated-gif/), [HTML5‑presentation](/slides/sv/net/export-to-html5/) eller [video](/slides/sv/net/convert-powerpoint-to-video/), ange exakta övergångsvaraktigheter innan export för att matcha den avsedda takten. Till exempel, använd en 600‑millisekunders fade mellan scener och justera varje bilds avanceringsfördröjning separat för att ge tid åt dess uppläsning eller innehåll.

För GIF och video, samordna output‑bildhastigheten med effektens varaktighet: 600 millisekunder motsvarar 18 bildrutor vid 30 fps. I HTML5, aktivera animerade övergångar i exportinställningarna. Kontrollera vilka effekter och tidsalternativ som stöds av det valda exportformatet och förhandsgranska resultatet för att bekräfta synkronisering.

### **Läs en befintlig övergångsvaraktighet**

Läs [Duration](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/duration/) innan du ändrar övergången för att avgöra om ett explicit värde är sparat. Ett värde på `-1` betyder att ingen explicit varaktighet är angiven; ett icke‑negativt värde specificerar den lagrade varaktigheten i millisekunder. Det icke‑satta värdet är inte den beräknade uppspelningsvaraktigheten: Aspose.Slides använder övergångstypen och [Speed](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/speed/) för att bestämma den varaktigheten. Att sätta en övergångstyp kan initiera en varaktighet, så inspektera de ursprungliga inställningarna först.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Morph‑övergång**

Morph‑övergången animera förändringar mellan objekt på på varandra följande bilder. För att skapa en enkel Morph‑effekt, klona en bild, flytta eller ändra storlek på ett objekt i klonen och tillämpa Morph‑övergången på den andra bilden. Detta ger övergången motsvarande objekt att animera mellan deras ursprungliga och modifierade tillstånd.

Följande exempel skapar en bild med en textruta, klonar bilden och ändrar rektangelns position och storlek i klonen. Sedan väljer det Morph från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/transitiontype/) för den andra bilden. Öppna den sparade filen i en presentationsvisare som stödjer Morph för att se effekten under ett bildspel.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Morph‑övergångstyper**

Uppräkningen [TransitionMorphType](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/transitionmorphtype/) styr hur Morph matchar och animera innehåll:

- [ByObject](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/transitionmorphtype/) behandlar varje form som ett helt objekt.
- [ByWord](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/transitionmorphtype/) animera text genom att matcha ord där det är möjligt.
- [ByChar](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/transitionmorphtype/) animera text genom att matcha tecken där det är möjligt.

Sätt övergångens [Type](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/type/) till Morph innan du får åtkomst till dess [Value](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/value/). Värdet ger då gränssnittet [IMorphTransition](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/imorphtransition/), vars egenskap [MorphType](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/imorphtransition/morphtype/) väljer matchningsläget.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Ställ in övergångseffekter**

Vissa övergångar exponerar ytterligare alternativ, såsom riktning eller om effekten startar från en svart skärm. Tillgängliga alternativ beror på den valda övergångens [Type](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/type/). Sätt typen först, och använd sedan det lämpliga gränssnittet från dess [Value](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/value/).

Följande exempel tillämpar en Cut‑övergång på den första bilden i `input.pptx`. Det sätter [FromBlack](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) via [IOptionalBlackTransition](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/ioptionalblacktransition/) så att övergången startar från en svart skärm.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**Kan jag kontrollera uppspelningshastigheten för en bildövergång?**

Ja. Föredra [Duration](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/duration/) när du behöver en exakt effektvaraktighet i millisekunder. Använd [Speed](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/speed/) när en fördefinierad kategori i [TransitionSpeed](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium eller Fast räcker och ingen explicit varaktighet är angiven. Dessa inställningar styr övergångseffekten oberoende av den automatiska avanceringsfördröjningen.

**Kan jag bifoga ljud till en övergång och få den att loopa?**

Ja. Tilldela inbäddat ljud till [Sound](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/sound/), sätt [SoundMode](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/soundmode/) till StartSound från uppräkningen [TransitionSoundMode](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/transitionsoundmode/), och aktivera [SoundLoop](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/soundloop/). Ljudet loopar tills nästa ljudhändelse i bildspelsvisningen.

**Vad är det snabbaste sättet att tillämpa samma övergång på varje bild?**

Loopa igenom presentationens [Slides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/slides/sv/)‑samling och sätt varje bilds övergångs[Type](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/type/) till samma värde. Sätt eventuella timing‑ och effektalternativ i samma loop för att hålla beteendet konsekvent över bilderna.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Läs egenskapen [Type](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/type/) från bildens [SlideShowTransition](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseslide/slideshowtransition/). Den returnerar ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/transitiontype/), och None betyder att ingen övergångseffekt är applicerad.