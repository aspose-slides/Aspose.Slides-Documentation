---
title: Avancerad textutvinning från presentationer i .NET
linktitle: Extrahera text
type: docs
weight: 90
url: /sv/net/extract-text-from-presentation/
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
description: "Extrahera snabbt text från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET. Följ vår enkla steg-för-steg-guide för att spara tid."
---
## **Översikt**

Att extrahera text från presentationer är en vanlig men ändå viktig uppgift för utvecklare som arbetar med bildinnehåll. Oavsett om du hanterar Microsoft PowerPoint-filer i PPT- eller PPTX-format, eller OpenDocument-presentationer (ODP), kan åtkomst till och hämtning av textdata vara avgörande för analys, automatisering, indexering eller innehållsmigrering.

Denna artikel ger en omfattande guide om hur du effektivt extraherar text från olika presentationsformat, inklusive PPT, PPTX och ODP, med Aspose.Slides för .NET. Du kommer att lära dig hur du systematiskt itererar genom presentationselement för att exakt hämta den text som du behöver.

## **Extrahera text från en bild**

Aspose.Slides för .NET tillhandahåller namnutrymmet [Aspose.Slides.Util](https://reference.aspose.com/slides/sv/net/aspose.slides.util/) som innehåller klassen [SlideUtil](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/). Denna klass exponerar flera överlagrade statiska metoder för att extrahera all text från en presentation eller bild. För att extrahera text från en bild i en presentation, använd metoden [GetAllTextBoxes](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/getalltextboxes/). Denna metod accepterar ett objekt av typen [IBaseSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseslide/) som parameter. När den körs skannar metoden hela bilden efter text och returnerar en array av objekt av typen [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/), med bibehållen textformatering.

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

För att skanna text från hela presentationen, använd den statiska metoden [GetAllTextFrames](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/getalltextframes/) som exponeras av klassen [SlideUtil](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/). Den accepterar två parametrar:

1. Först ett [IPresentation](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/)‑objekt som representerar en PowerPoint‑ eller OpenDocument‑presentation som text ska extraheras från.
2. För det andra ett `Boolean`‑värde som anger om mastern bilder ska inkluderas vid skanning av text från presentationen.

Metoden returnerar en array av objekt av typen [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/), inklusive information om textformatering. Koden nedan skannar text och formateringsdetaljer från en presentation, inklusive mastern bilder.

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

Klassen [PresentationFactory](https://reference.aspose.com/slides/sv/net/aspose.slides/presentationfactory/) tillhandahåller också metoder för att extrahera all text från presentationer:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

Argumentet [TextExtractionArrangingMode](https://reference.aspose.com/slides/sv/net/aspose.slides/textextractionarrangingmode/) enum anger läget för att organisera resultatet av textutvinning och kan sättas till följande värden:
- `Unarranged` - Råtext utan hänsyn till dess position på bilden.
- `Arranged` - Texten är ordnad i samma följd som på bilden.

Det oordnade läget kan användas när hastighet är kritisk; det är snabbare än det ordnade läget.

[IPresentationText](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationtext/) representerar den råa text som extraherats från presentationen. Dess egenskap `SlidesText` returnerar en array av objekt av typen [ISlideText](https://reference.aspose.com/slides/sv/net/aspose.slides/islidetext/). Varje objekt representerar texten på motsvarande bild. Objektet av typen [ISlideText](https://reference.aspose.com/slides/sv/net/aspose.slides/islidetext/) har följande egenskaper:

- `Text` - Texten inom bildens former.
- `MasterText` - Texten inom masterbildens former som är associerade med denna bild.
- `LayoutText` - Texten inom layoutbildens former som är associerade med denna bild.
- `NotesText` - Texten inom noternas bilds former som är associerade med denna bild.
- `CommentsText` - Texten inom kommentarer som är associerade med denna bild.

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

## **Vanliga frågor**

**Hur snabbt bearbetar Aspose.Slides stora presentationer vid textutvinning?**

Aspose.Slides är optimerat för hög prestanda och kan bearbeta även [stora presentationer](/slides/sv/net/open-presentation/), vilket gör det lämpligt för realtidsscenarier eller massbearbetning.

**Kan Aspose.Slides extrahera text från tabeller och diagram i presentationer?**

Ja. Aspose.Slides kan extrahera text från många bildelement, inklusive tabeller och diagramrelaterade objekt, så att du kan komma åt och analysera textinnehåll i vanliga presentationsstrukturer.

**Behöver jag en särskild Aspose.Slides-licens för att extrahera text från presentationer?**

Du kan extrahera text med den kostnadsfria provversionen av Aspose.Slides, men den har [vissa begränsningar](/slides/sv/net/licensing/), exempelvis att endast bearbeta ett begränsat antal bilder. För obegränsad användning och för att hantera större presentationer rekommenderas att köpa en full licens.