---
title: Geavanceerde teksextractie uit presentaties in .NET
linktitle: Tekst extraheren
type: docs
weight: 90
url: /nl/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/nl/
keywords:
- tekst extraheren
- tekst extraheren uit dia
- tekst extraheren uit presentatie
- tekst extraheren uit PowerPoint
- tekst extraheren uit OpenDocument
- tekst extraheren uit PPT
- tekst extraheren uit PPTX
- tekst extraheren uit ODP
- tekst ophalen
- tekst ophalen uit dia
- tekst ophalen uit presentatie
- tekst ophalen uit PowerPoint
- tekst ophalen uit OpenDocument
- tekst ophalen uit PPT
- tekst ophalen uit PPTX
- tekst ophalen uit ODP
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Extraheer snel tekst uit PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor .NET. Volg onze eenvoudige, stapsgewijze gids om tijd te besparen."
---
## **Overzicht**

Tekst extraheren uit presentaties is een veelvoorkomende maar essentiële taak voor ontwikkelaars die met dia‑inhoud werken. Of je nu met Microsoft PowerPoint‑bestanden in PPT‑ of PPTX‑formaat werkt, of met OpenDocument‑presentaties (ODP), het benaderen en ophalen van tekstgegevens kan cruciaal zijn voor analyse, automatisering, indexering of content‑migratie.

Dit artikel biedt een uitgebreide gids over hoe je efficiënt tekst kunt extraheren uit verschillende presentatieformaten, waaronder PPT, PPTX en ODP, met behulp van Aspose.Slides voor .NET. Je leert hoe je systematisch door presentatie‑elementen kunt itereren om nauwkeurig de gewenste tekstinhoud op te halen.

## **Tekst extraheren uit een dia**

Aspose.Slides voor .NET biedt de [Aspose.Slides.Util](https://reference.aspose.com/slides/nl/net/aspose.slides.util/) namespace, die de [SlideUtil](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/)‑klasse bevat. Deze klasse stelt verschillende overladen statische methoden beschikbaar voor het extraheren van alle tekst uit een presentatie of dia. Om tekst uit een dia in een presentatie te extraheren, gebruik je de [GetAllTextBoxes](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/getalltextboxes/)‑methode. Deze methode accepteert een object van het type [IBaseSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/) als parameter. Bij uitvoering scant de methode de volledige dia op tekst en retourneert een array van objecten van het type [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/), waarbij eventuele opmaak behouden blijft.

De volgende code‑fragment extrahert alle tekst van de eerste dia van de presentatie:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Tekst extraheren uit een presentatie**

Om tekst van de volledige presentatie te scannen, gebruik je de statische methode [GetAllTextFrames](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/getalltextframes/) die wordt aangeboden door de klasse [SlideUtil](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/). Deze accepteert twee parameters:

1. Ten eerste een [IPresentation](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/) object dat een PowerPoint‑ of OpenDocument‑presentatie vertegenwoordigt waaruit tekst wordt gehaald.
1. Ten tweede een `Boolean`‑waarde die aangeeft of de master‑dia's moeten worden meegegleden bij het scannen van tekst uit de presentatie.

De methode retourneert een array van objecten van het type [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/), inclusief informatie over tekstopmaak. De code hieronder scant de tekst en opmaakdetails uit een presentatie, inclusief de master‑dia's.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Gecategoriseerde en snelle teksextractie**

De klasse [PresentationFactory](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/) biedt ook methoden om alle tekst uit presentaties te extraheren:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

Het enum‑argument [TextExtractionArrangingMode](https://reference.aspose.com/slides/nl/net/aspose.slides/textextractionarrangingmode/) geeft de modus aan voor het organiseren van het resultaat van de teksextractie en kan op de volgende waarden worden ingesteld:
- `Unarranged` – De ruwe tekst, los van de positie op de dia.
- `Arranged` – De tekst wordt gerangschikt in dezelfde volgorde als op de dia.

De `Unarranged`‑modus kan worden gebruikt wanneer snelheid cruciaal is; deze is sneller dan de `Arranged`‑modus.

[IPresentationText](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationtext/) vertegenwoordigt de ruwe tekst die uit de presentatie is geëxtraheerd. De eigenschap `SlidesText` retourneert een array van objecten van het type [ISlideText](https://reference.aspose.com/slides/nl/net/aspose.slides/islidetext/). Elk object vertegenwoordigt de tekst op de overeenkomstige dia. Het object van het type [ISlideText](https://reference.aspose.com/slides/nl/net/aspose.slides/islidetext/) heeft de volgende eigenschappen:

- `Text` – De tekst binnen de vormen van de dia.
- `MasterText` – De tekst binnen de vormen van de master‑dia die bij deze dia horen.
- `LayoutText` – De tekst binnen de vormen van de lay‑out‑dia die bij deze dia horen.
- `NotesText` – De tekst binnen de vormen van de notities‑dia die bij deze dia horen.
- `CommentsText` – De tekst binnen de opmerkingen die bij deze dia horen.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **FAQ**

**Hoe snel verwerkt Aspose.Slides grote presentaties tijdens teksextractie?**

Aspose.Slides is geoptimaliseerd voor hoge prestaties en kan zelfs [grote presentaties](/slides/nl/net/open-presentation/) verwerken, waardoor het geschikt is voor realtime‑ of bulkverwerkingsscenario’s.

**Kan Aspose.Slides tekst extraheren uit tabellen en grafieken binnen presentaties?**

Ja. Aspose.Slides kan tekst extraheren uit vele dia‑elementen, waaronder tabellen en grafiekgerelateerde objecten, zodat je de tekstinhoud in gangbare presentatiestructuren kunt benaderen en analyseren.

**Heb ik een speciale Aspose.Slides‑licentie nodig om tekst uit presentaties te extraheren?**

Je kunt tekst extraheren met de gratis proefversie van Aspose.Slides, hoewel deze [bepaalde beperkingen](/slides/nl/net/licensing/) heeft, zoals het verwerken van slechts een beperkt aantal dia's. Voor onbeperkt gebruik en om grotere presentaties aan te kunnen, wordt aangeraden een volledige licentie aan te schaffen.