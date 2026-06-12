---
title: Beheer diaovergangen in presentaties in .NET
linktitle: Diaovergang
type: docs
weight: 90
url: /nl/net/slide-transition/
keywords:
- diaovergang
- diaovergang toevoegen
- diaovergang toepassen
- geavanceerde diaovergang
- morph‑overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek hoe u diaovergangen kunt aanpassen in Aspose.Slides voor .NET, met stapsgewijze begeleiding voor PowerPoint- en OpenDocument‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u diaovergangen in presentaties kunt beheren met Aspose.Slides. Het laat zien hoe u overgangstypen op dia's toepast, het gedrag van de overgang configureert, zoals doorgaan bij een muisklik of na een opgegeven tijd, controleert en automatische doorgang uitschakelt, de Morph‑overgang en de verschillende typen ervan gebruikt, en opties voor overgangseffecten instelt. De voorbeelden laten zien hoe u een presentatie laadt of maakt, de overgangsinstellingen voor geselecteerde dia's wijzigt, en het resultaat opslaat als een PPTX‑bestand. Het artikel beantwoordt ook veelgestelde vragen over de snelheid van de overgang, overgangsgeluiden, dezelfde overgang op meerdere dia's toepassen en controleren welke overgang momenteel op een dia is ingesteld.

## **Diaovergang toevoegen**
Om het begrip te vergemakkelijken hebben we een voorbeeld getoond van het gebruik van Aspose.Slides voor .NET om eenvoudige diaovergangen te beheren. Ontwikkelaars kunnen niet alleen verschillende diaovergangseffecten op de dia's toepassen, maar ook het gedrag van deze overgangseffecten aanpassen. Om een eenvoudig diaovergangseffect te maken, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
2. Pas een diaovergangstype toe op de dia vanuit een van de overgangseffecten die Aspose.Slides voor .NET biedt via de TransitionType‑enum.
3. Schrijf het gewijzigde presentatiebestand weg.

```c#
// Instantieer Presentation‑klasse om het bronpresentatie‑bestand te laden
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Pas cirkeltype‑overgang toe op dia 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Pas comb‑type overgang toe op dia 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Schrijf de presentatie naar schijf
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

## **Geavanceerde diaovergang toevoegen**
In de bovenstaande sectie hebben we enkel een eenvoudig overgangseffect op de dia toegepast. Om dat eenvoudige overgangseffect nu nog beter en beter bestuurbaar te maken, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
2. Pas een diaovergangstype toe op de dia vanuit een van de overgangseffecten die Aspose.Slides voor .NET biedt.
3. U kunt de overgang ook instellen om door te gaan bij een muisklik, na een specifieke tijdsperiode of beide.
4. Als de diaovergang is ingesteld op “Doorlopen bij klik”, zal de overgang alleen doorgaan wanneer iemand klikt met de muis. Bovendien, als de eigenschap AdvanceAfterTime is ingesteld, loopt de overgang automatisch door na de opgegeven tijd.
5. Schrijf de gewijzigde presentatie weg als een presentatiedocument.

```c#
// Instantieer Presentation-klasse die een presentatie-bestand vertegenwoordigt
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Pas cirkeltype-overgang toe op dia 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Stel de overgangstijd in op 3 seconden
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Pas comb-type overgang toe op dia 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Stel de overgangstijd in op 5 seconden
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Pas zoomtype-overgang toe op dia 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Stel de overgangstijd in op 7 seconden
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Schrijf de presentatie naar schijf
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

Bovendien kunt u met de [AdvanceAfter](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/advanceafter/)‑eigenschap controleren of een diaovergang is geconfigureerd om naar de volgende dia te gaan of de instelling uitschakelen.

Deze C#‑code demonstreert de werking:

```c#
// Instantieert een Presentation-klasse die een presentatie-bestand vertegenwoordigt
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Haalt de dia-Transition op
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Controleert of de instelling Advance After Time is ingeschakeld
        if (slideTransition.AdvanceAfter)
        {
            // Print de waarde van Advance After Time
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Schakelt de overgang uit na een specifieke tijd als de waarde van AdvanceAfterTime groter is dan 2 seconden
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Morph‑overgang**
Aspose.Slides voor .NET ondersteunt nu de [Morph Transition](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/imorphtransition). Ze vertegenwoordigen een nieuwe morph‑overgang geïntroduceerd in PowerPoint 2019. De Morph‑overgang maakt het mogelijk om een soepele beweging van de ene dia naar de andere te animeren. Dit artikel beschrijft het concept en hoe u de Morph‑overgang gebruikt. Om de Morph‑overgang effectief te gebruiken, moet u twee dia's hebben met ten minste één gemeenschappelijk object. De gemakkelijkste manier is om de dia te dupliceren en vervolgens het object op de tweede dia naar een andere plaats te verplaatsen.

De volgende codefragment toont hoe u een kloon van de dia met wat tekst aan de presentatie toevoegt en een overgang van het [morph type](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) instelt op de tweede dia.

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

## **Morph‑overgangstypen**
Niewe enum Aspose.Slides.SlideShow.TransitionMorphType is toegevoegd. Het vertegenwoordigt verschillende typen van Morph‑diaovergangen.

TransitionMorphType‑enum heeft drie leden:

- ByObject: Morph‑overgang wordt uitgevoerd met vormen als ondeelbare objecten.
- ByWord: Morph‑overgang wordt uitgevoerd door tekst waar mogelijk per woord over te dragen.
- ByChar: Morph‑overgang wordt uitgevoerd door tekst waar mogelijk per teken over te dragen.

Het onderstaande codefragment toont hoe u een morph‑overgang op een dia instelt en het morph‑type wijzigt:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Overgangseffecten instellen**
Aspose.Slides voor .NET ondersteunt het instellen van overgangseffecten zoals “van zwart”, “van links”, “van rechts”, enz. Om het overgangseffect in te stellen, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
- Haal de referentie van de dia op.
- Stel het overgangseffect in.
- Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

In het onderstaande voorbeeld hebben we de overgangseffecten ingesteld.

```c#
// Maak een instantie van de Presentation-klasse
Presentation presentation = new Presentation("AccessSlides.pptx");

// Stel effect in
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Schrijf de presentatie naar schijf
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Kan ik de afspeelsnelheid van een diaovergang regelen?**

Ja. Stel de [Speed](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/speed/) van de overgang in via de [TransitionSpeed](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/transitionspeed/)‑instelling (bijv. langzaam/middelhoog/snel).

**Kan ik audio aan een overgang toevoegen en deze laten herhalen?**

Ja. U kunt een geluid inbedden voor de overgang en het gedrag beheren via instellingen zoals geluidsmodus en herhaling (bijv. [Sound](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/soundloop/), plus metadata zoals [SoundIsBuiltIn](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) en [SoundName](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/soundname/)).

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Configureer het gewenste overgangstype in de overgangsinstellingen van elke dia; overgangen worden per dia opgeslagen, dus het toepassen van hetzelfde type op alle dia’s levert een consistent resultaat op.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Bekijk de [transition settings](https://reference.aspose.com/slides/nl/net/aspose.slides/baseslide/slideshowtransition/) van de dia en lees het [transition type](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/type/); die waarde vertelt u precies welk effect is toegepast.