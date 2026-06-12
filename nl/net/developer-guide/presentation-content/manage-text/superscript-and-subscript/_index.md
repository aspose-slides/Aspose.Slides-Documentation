---
title: Beheer superscript en subscript in presentaties in .NET
linktitle: Superscript en subscript
type: docs
weight: 80
url: /nl/net/superscript-and-subscript/
keywords:
- superscript
- subscript
- superscript toevoegen
- subscript toevoegen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheers superscript en subscript in Aspose.Slides voor .NET en til uw presentaties naar een hoger niveau met professionele tekstopmaak voor maximale impact."
---
## **Overzicht**

Aspose.Slides voor .NET biedt functies voor het integreren van superscript‑ en subscript‑tekst in uw PowerPoint‑ (PPT, PPTX) en OpenDocument‑ (ODP) presentaties. Of u nu chemische formules, wiskundige vergelijkingen wilt benadrukken of inhoud wilt annoteren met voetnoten, deze gespecialiseerde opmaakopties helpen duidelijkheid en precisie te behouden. In dit artikel leert u hoe u superscript‑ en subscript‑stijlen naadloos toepast en professioneel resultaat bereikt op elke dia.

## **Superscript‑ en subscripttekst toevoegen**

U kunt superscript‑ en subscript‑tekst toevoegen binnen elke alinea in een presentatie. Om dit met Aspose.Slides te doen, moet u de `Escapement`‑eigenschap van de [PortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/portionformat/)‑klasse gebruiken.

Deze eigenschap stelt u in staat superscript‑ of subscript‑tekst in te stellen, met waarden variërend van -100 % (subscript) tot 100 % (superscript).

Implementatiestappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia met behulp van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) van het type `Rectangle` toe aan de dia.
1. Benader het [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) dat bij de [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) hoort.
1. Wis bestaande alinea's.
1. Maak een nieuwe [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraph/) voor superscript‑tekst en voeg deze toe aan de alinea‑collectie van het [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/).
1. Maak een nieuw tekst‑portion‑object.
1. Stel de `Escapement`‑eigenschap voor het tekst‑portion in tussen 0 en 100 om superscript toe te passen (0 betekent geen superscript).
1. Stel wat tekst in voor de [Portion](https://reference.aspose.com/slides/nl/net/aspose.slides/portion/) en voeg deze toe aan de portion‑collectie van de alinea.
1. Maak een andere [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraph/) voor subscript‑tekst en voeg deze toe aan de alinea‑collectie.
1. Maak een nieuw tekst‑portion‑object.
1. Stel de `Escapement`‑eigenschap voor het tekst‑portion in tussen 0 en -100 om subscript toe te passen (0 betekent geen subscript).
1. Stel wat tekst in voor de [Portion](https://reference.aspose.com/slides/nl/net/aspose.slides/portion/) en voeg deze toe aan de portion‑collectie van de alinea.
1. Sla de presentatie op als een PPTX‑bestand.

De volgende C#‑code realiseert deze stappen:

```c#
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Maak een tekstvak.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Maak een alinea voor superscript‑tekst.
    IParagraph superPar = new Paragraph();

    // Maak een tekst‑portion met gewone tekst.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Maak een tekst‑portion met superscript‑tekst.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Maak een alinea voor subscript‑tekst.
    IParagraph paragraph2 = new Paragraph();

    // Maak een tekst‑portion met gewone tekst.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Maak een tekst‑portion met subscript‑tekst.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Voeg de alinea’s toe aan het tekstvak.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![Superscript en subscript](superscript_and_subscript.png)

## **Veelgestelde vragen**

**Worden superscript en subscript behouden bij het exporteren naar PDF of andere formaten?**

Ja, Aspose.Slides voor .NET behoudt superscript‑ en subscript‑opmaak correct bij het exporteren van presentaties naar PDF, PPT/PPTX, afbeeldingen en andere ondersteunde formaten. De gespecialiseerde opmaak blijft ongewijzigd in alle uitvoerbestanden.

**Kunnen superscript en subscript worden gecombineerd met andere opmaakstijlen zoals vet of cursief?**

Ja, Aspose.Slides maakt het mogelijk om verschillende tekststijlen te mengen binnen één portion tekst. U kunt vet, cursief, onderstrepen en tegelijkertijd superscript of subscript toepassen door de overeenkomstige eigenschappen in [PortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/portionformat/) in te stellen.

**Werkt superscript‑ en subscript‑opmaak voor tekst in tabellen, diagrammen of SmartArt?**

Ja, Aspose.Slides voor .NET ondersteunt opmaak binnen de meeste objecten, inclusief tabellen en diagram‑elementen. Bij het werken met SmartArt moet u de juiste elementen (zoals [SmartArtNode](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/smartartnode/)) en hun tekstcontainers benaderen, en vervolgens de [PortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/portionformat/)‑eigenschappen op dezelfde manier configureren.