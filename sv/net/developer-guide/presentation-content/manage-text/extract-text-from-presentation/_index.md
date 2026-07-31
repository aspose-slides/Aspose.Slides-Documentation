---
title: Avancerad textutvinning från presentationer i .NET
linktitle: Extrahera text
type: docs
weight: 90
url: /sv/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/sv/
keywords:
- extrahera text
- extrahera text från bild
- extrahera text från presentation
- extrahera text från PowerPoint
- extrahera text från OpenDocument
- extrahera text från PPT
- extrahera text från PPTX
- extrahera text från ODP
- hämta text
- hämta text från bild
- hämta text från presentation
- hämta text från PowerPoint
- hämta text från OpenDocument
- hämta text från PPT
- hämta text från PPTX
- hämta text från ODP
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Extrahera snabbt text från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET. Följ vår enkla, steg-för-steg-guide för att spara tid."
---
## **Översikt**

Att extrahera text från presentationer är en vanlig men ändå viktig uppgift för utvecklare som arbetar med bildspelsinnehåll. Oavsett om du hanterar Microsoft PowerPoint‑filer i PPT‑ eller PPTX‑format, eller OpenDocument‑presentationer (ODP), kan åtkomst till och hämtning av textdata vara avgörande för analys, automatisering, indexering eller innehållsmigrering.

Denna artikel ger en omfattande guide för hur du på ett effektivt sätt extraherar text från olika presentationsformat, inklusive PPT, PPTX och ODP, med hjälp av Aspose.Slides för .NET. Du kommer att lära dig hur du systematiskt itererar igenom presentations‑element för att exakt återvinna den text som du behöver.

## **Extrahera text från en bild**

Aspose.Slides för .NET tillhandahåller namnutrymmet [Aspose.Slides.Util](https://reference.aspose.com/slides/sv/net/aspose.slides.util/), som innehåller klassen [SlideUtil](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/). Denna klass erbjuder flera överlagrade statiska metoder för att extrahera all text från en presentation eller en bild. För att extrahera text från en bild i en presentation, använd metoden [GetAllTextBoxes](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/getalltextboxes/). Metoden tar ett objekt av typen [IBaseSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseslide/) som parameter. När den körs skannar metoden hela bilden efter text och returnerar en matris av objekt av typen [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/), där eventuell textformatering bevaras.

Följande kodsnutt extraherar all text från den första bilden i presentationen:

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

## **Extrahera text från en presentation**

För att skanna text från hela presentationen, använd den statiska metoden [GetAllTextFrames](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/getalltextframes/) som exponeras av klassen [SlideUtil](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/). Den tar två parametrar:

1. Först ett [IPresentation](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/)-objekt som representerar en PowerPoint‑ eller OpenDocument‑presentation som texten ska extraheras från.  
2. För det andra ett `Boolean`‑värde som anger om master‑bilderna ska inkluderas när texten skannas i presentationen.

Metoden returnerar en matris av objekt av typen [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/), inklusive information om textformatering. Koden nedan skannar text‑ och formateringsdetaljer från en presentation, inklusive master‑bilderna.

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

## **Kategoriserad och snabb textutvinning**

Klassen [PresentationFactory](https://reference.aspose.com/slides/sv/net/aspose.slides/presentationfactory/) erbjuder också metoder för att extrahera all text från presentationer:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

Argumentet av enum‑typen [TextExtractionArrangingMode](https://reference.aspose.com/slides/sv/net/aspose.slides/textextractionarrangingmode/) anger vilket sätt som resultatet av textutvinning ska organiseras och kan sättas till följande värden:
- `Unarranged` – Den råa texten utan hänsyn till dess position på bilden.  
- `Arranged` – Texten ordnas i samma sekvens som på bilden.

Det oordnade läget kan användas när hastigheten är avgörande; det är snabbare än det ordnade läget.

[IPresentationText](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationtext/) representerar den råa text som extraherats från presentationen. Dess egenskap `SlidesText` returnerar en matris av objekt av typen [ISlideText](https://reference.aspose.com/slides/sv/net/aspose.slides/islidetext/). Varje objekt representerar texten på den motsvarande bilden. Objektet av typen [ISlideText](https://reference.aspose.com/slides/sv/net/aspose.slides/islidetext/) har följande egenskaper:

- `Text` – Texten i bildens former.  
- `MasterText` – Texten i master‑bildens former som är knutna till denna bild.  
- `LayoutText` – Texten i layout‑bildens former som är knutna till denna bild.  
- `NotesText` – Texten i noterings‑bildens former som är knutna till denna bild.  
- `CommentsText` – Texten i kommentarer som är knutna till denna bild.

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

**Hur snabbt bearbetar Aspose.Slides stora presentationer vid textutvinning?**

Aspose.Slides är optimerat för hög prestanda och kan bearbeta även [stora presentationer](/slides/sv/net/open-presentation/), vilket gör det lämpligt för realtids‑ eller massbearbetningsscenarier.

**Kan Aspose.Slides extrahera text från tabeller och diagram i presentationer?**

Ja. Aspose.Slides kan extrahera text från många bildelement, inklusive tabeller och diagramrelaterade objekt, så att du kan komma åt och analysera textinnehåll i vanliga presentationsstrukturer.

**Behöver jag en speciell Aspose.Slides‑licens för att extrahera text från presentationer?**

Du kan extrahera text med den kostnadsfria provversionen av Aspose.Slides, men den har [vissa begränsningar](/slides/sv/net/licensing/), till exempel att endast ett begränsat antal bilder kan bearbetas. För obegränsad användning och för att hantera större presentationer rekommenderas inköp av en fullständig licens.