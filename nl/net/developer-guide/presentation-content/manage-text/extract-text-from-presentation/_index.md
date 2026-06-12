---
title: Geavanceerde tekstextractie uit presentaties in .NET
linktitle: Tekst extraheren
type: docs
weight: 90
url: /nl/net/extract-text-from-presentation/
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

Tekst uit presentaties extraheren is een gewone maar essentiële taak voor ontwikkelaars die met dia-inhoud werken. Of je nu werkt met Microsoft PowerPoint-bestanden in PPT- of PPTX-formaat, of met OpenDocument-presentaties (ODP), toegang krijgen tot en het ophalen van tekstuele gegevens kan cruciaal zijn voor analyse, automatisering, indexering of content-migratie.

Dit artikel biedt een uitgebreide gids over hoe je efficiënt tekst kunt extraheren uit verschillende presentatieformaten, waaronder PPT, PPTX en ODP, met behulp van Aspose.Slides voor .NET. Je leert hoe je systematisch door presentatie-elementen kunt itereren om de benodigde tekstinhoud nauwkeurig op te halen.

## **Tekst extraheren van een dia**

Aspose.Slides voor .NET levert de [Aspose.Slides.Util](https://reference.aspose.com/slides/nl/net/aspose.slides.util/) namespace, die de [SlideUtil](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/)-klasse bevat. Deze klasse biedt verschillende overladen statische methoden om alle tekst uit een presentatie of dia te extraheren. Om tekst uit een dia in een presentatie te extraheren, gebruik je de [GetAllTextBoxes](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/getalltextboxes/)-methode. Deze methode accepteert een object van het type [IBaseSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/) als parameter. Bij uitvoering scant de methode de volledige dia op tekst en geeft een array van objecten van het type [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) terug, waarbij eventuele tekstopmaak behouden blijft.

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

Om tekst uit de volledige presentatie te scannen, gebruik je de statische methode [GetAllTextFrames](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/getalltextframes/) die wordt aangeboden door de [SlideUtil](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/)-klasse. Deze methode accepteert twee parameters:

1. Ten eerste een [IPresentation](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/) object dat een PowerPoint- of OpenDocument-presentatie voorstelt waaruit de tekst wordt geëxtraheerd.
1. Ten tweede een `Boolean`-waarde die aangeeft of de master-dias moeten worden meegenomen bij het scannen van tekst uit de presentatie.

De methode retourneert een array van objecten van het type [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/), inclusief informatie over tekstopmaak. De code hieronder scant de tekst en opmaakinformatie uit een presentatie, inclusief de masters.

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

## **Gecategoriseerde en snelle tekstextractie**

De klasse [PresentationFactory](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/) biedt tevens methoden om alle tekst uit presentaties te extraheren:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

Het enum-argument [TextExtractionArrangingMode](https://reference.aspose.com/slides/nl/net/aspose.slides/textextractionarrangingmode/) geeft de modus aan voor het ordenen van het resultaat van de tekstextractie en kan de volgende waarden aannemen:
- `Unarranged` - De ruwe tekst zonder rekening te houden met de positie op de dia.
- `Arranged` - De tekst wordt gerangschikt in dezelfde volgorde als op de dia.

De `Unarranged`-modus kan worden gebruikt wanneer snelheid cruciaal is; deze is sneller dan de `Arranged`-modus.

[IPresentationText](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationtext/) vertegenwoordigt de ruwe tekst die uit de presentatie is geëxtraheerd. De eigenschap `SlidesText` retourneert een array van objecten van het type [ISlideText](https://reference.aspose.com/slides/nl/net/aspose.slides/islidetext/). Elk object vertegenwoordigt de tekst op de overeenkomstige dia. Het object van het type [ISlideText](https://reference.aspose.com/slides/nl/net/aspose.slides/islidetext/) heeft de volgende eigenschappen:

- `Text` - De tekst binnen de vormen van de dia.
- `MasterText` - De tekst binnen de vormen van de master-dias die bij deze dia horen.
- `LayoutText` - De tekst binnen de vormen van de layout-dias die bij deze dia horen.
- `NotesText` - De tekst binnen de vormen van de notes-dias die bij deze dia horen.
- `CommentsText` - De tekst binnen de opmerkingen die bij deze dia horen.

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

**Hoe snel verwerkt Aspose.Slides grote presentaties tijdens tekstextractie?**

Aspose.Slides is geoptimaliseerd voor hoge prestaties en kan zelfs [grote presentaties](/slides/nl/net/open-presentation/) verwerken, waardoor het geschikt is voor real-time of bulk-verwerking scenario's.

**Kan Aspose.Slides tekst extraheren uit tabellen en grafieken binnen presentaties?**

Ja. Aspose.Slides kan tekst extraheren uit vele dia-elementen, waaronder tabellen en grafiek-gerelateerde objecten, zodat je de tekstuele inhoud in gangbare presentatiestructuren kunt benaderen en analyseren.

**Heb ik een speciale Aspose.Slides-licentie nodig om tekst uit presentaties te extraheren?**

Je kunt tekst extraheren met de gratis proefversie van Aspose.Slides, hoewel deze [bepaalde beperkingen](/slides/nl/net/licensing/) heeft, zoals het verwerken van slechts een beperkt aantal dia's. Voor onbeperkt gebruik en om grotere presentaties te kunnen verwerken, wordt aangeraden een volledige licentie aan te schaffen.