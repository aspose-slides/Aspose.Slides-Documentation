---
title: Hantera bildövergångar i presentationer i .NET
linktitle: Bildövergång
type: docs
weight: 90
url: /sv/net/slide-transition/
keywords:
- bildövergång
- lägg till bildövergång
- tillämpa bildövergång
- avancerad bildövergång
- morph-övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck hur du anpassar bildövergångar i Aspose.Slides för .NET, med steg-för-steg-vägledning för PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man hanterar bildövergångar i presentationer med Aspose.Slides. Den visar hur man tillämpar övergångstyper på bilder, konfigurerar övergångsbeteende såsom att gå vidare vid klick eller efter en angiven tid, kontrollerar och inaktiverar automatisk vidaregång, använder Morph‑övergången och dess typer samt ställer in alternativ för övergångseffekter. Exemplen demonstrerar hur man laddar eller skapar en presentation, ändrar övergångsinställningar för utvalda bilder och sparar resultatet som en PPTX‑fil. Artikeln svarar även på vanliga frågor om övergångshastighet, övergångsljud, att tillämpa samma övergång på flera bilder och att kontrollera vilken övergång som för närvarande är inställd på en bild.

## **Lägg till bildövergång**
För att göra det lättare att förstå har vi demonstrerat användningen av Aspose.Slides för .NET för att hantera enkla bildövergångar. Utvecklare kan inte bara tillämpa olika bildövergångseffekter på bilderna utan också anpassa beteendet för dessa övergångseffekter. För att skapa en enkel bildövergångseffekt, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) klassen.
1. Tillämpa en Slide Transition Type på bilden från ett av de övergångseffekter som erbjuds av Aspose.Slides för .NET via TransitionType‑enum.
1. Skriv den modifierade presentationsfilen.

```c#
// Instansiera Presentation-klassen för att läsa in källpresentationen
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Tillämpa cirkeltyp övergång på bild 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Tillämpa comb-typ övergång på bild 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Skriv presentationen till disk
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


## **Lägg till avancerad bildövergång**
I avsnittet ovan använde vi bara en enkel övergångseffekt på bilden. Nu, för att göra den enkla övergångseffekten ännu bättre och mer kontrollerad, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) klassen.
1. Tillämpa en Slide Transition Type på bilden från ett av de övergångseffekter som erbjuds av Aspose.Slides för .NET.
1. Du kan också ställa in övergången till Advance On Click, efter en specifik tidsperiod eller båda.
1. Om bildövergången är aktiverad för Advance On Click, kommer övergången bara att gå vidare när någon klickar med musen. Dessutom, om egenskapen Advance After Time är satt, kommer övergången att gå vidare automatiskt efter den angivna tiden har passerat.
1. Skriv den modifierade presentationen som en presentationsfil.

```c#
// Instansiera Presentation-klassen som representerar en presentationsfil
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Tillämpa cirkeltyp övergång på bild 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Ställ in övergångstiden till 3 sekunder
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Tillämpa comb-typ övergång på bild 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Ställ in övergångstiden till 5 sekunder
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Tillämpa zoom-typ övergång på bild 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Ställ in övergångstiden till 7 sekunder
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Skriv presentationen till disk
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

Dessutom kan du med hjälp av egenskapen [AdvanceAfter](https://reference.aspose.com/slides/sv/net/aspose.slides/islideshowtransition/advanceafter/) kontrollera om en bildövergång har konfigurerats för att gå till nästa bild eller inaktivera inställningen.

Den här C#‑koden demonstrerar operationen:

```c#
// Instansierar en Presentation-klass som representerar en presentationsfil
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Hämtar bildens övergång
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Kontrollerar om inställningen Advance After Time är aktiverad
        if (slideTransition.AdvanceAfter)
        {
            // Skriver ut värdet för Advance After Time
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Inaktiverar övergången efter en viss tid om värdet för AdvanceAfterTime är större än 2 sekunder
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Morph‑övergång**
Aspose.Slides för .NET stöder nu [Morph Transition](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/imorphtransition). Den representerar en ny morph‑övergång som introducerades i PowerPoint 2019. Morph‑övergången låter dig animera en smidig rörelse från en bild till nästa. Den här artikeln beskriver konceptet och hur man använder Morph‑övergången. För att använda Morph‑övergången effektivt behöver du två bilder med minst ett objekt gemensamt. Det enklaste sättet är att duplicera bilden och sedan flytta objektet på den andra bilden till en annan plats.

Följande kodsnutt visar hur du lägger till en klon av bilden med lite text i presentationen och sätter en övergång av [morph type](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) till den andra bilden.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **Morph‑övergångstyper**
Den nya [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/transitionmorphtype) enum har lagts till. Den representerar olika typer av Morph‑bildövergång.

TransitionMorphType‑enum har tre medlemmar:

- ByObject: Morph‑övergången utförs med hänsyn till former som odelbara objekt.
- ByWord: Morph‑övergången utförs genom att överföra text ord för ord där det är möjligt.
- ByChar: Morph‑övergången utförs genom att överföra text tecken för tecken där det är möjligt.

Följande kodsnutt visar hur du sätter morph‑övergång på en bild och ändrar morph‑typ:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```



## **Ställ in övergångseffekter**
Aspose.Slides för .NET stöder att ställa in övergångseffekter som från svart, från vänster, från höger osv. För att ställa in Transition Effect, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) klassen.
- Hämta referensen till bilden.
- Ställ in övergångseffekten.
- Skriv presentationen som en [PPTX ](https://docs.fileformat.com/presentation/pptx/)fil.

I exemplet nedan har vi ställt in övergångseffekterna.

```c#
// Skapa en instans av Presentation-klassen
Presentation presentation = new Presentation("AccessSlides.pptx");

// Ställ in effekt
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Skriv presentationen till disk
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Kan jag kontrollera uppspelningshastigheten för en bildövergång?**

Ja. Ställ in övergångens [Speed](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/speed/) med inställningen [TransitionSpeed](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/transitionspeed/) (t.ex. slow/medium/fast).

**Kan jag bifoga ljud till en övergång och få den att loopa?**

Ja. Du kan bädda in ett ljud för övergången och kontrollera beteendet via inställningar som ljudläge och loopning (t.ex. [Sound](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/soundloop/), samt metadata som [SoundIsBuiltIn](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) och [SoundName](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/soundname/)).

**Vad är det snabbaste sättet att tillämpa samma övergång på alla bilder?**

Konfigurera önskad övergångstyp i varje bilds övergångsinställningar; övergångar lagras per bild, så att tillämpa samma typ på alla bilder ger ett konsekvent resultat.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Inspektera bildens [transition settings](https://reference.aspose.com/slides/sv/net/aspose.slides/baseslide/slideshowtransition/) och läs dess [transition type](https://reference.aspose.com/slides/sv/net/aspose.slides.slideshow/slideshowtransition/type/); det värdet visar exakt vilken effekt som är tillämpad.