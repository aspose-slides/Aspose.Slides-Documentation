---
title: Exportera matematiska ekvationer från presentationer i .NET
linktitle: Exportera ekvationer
type: docs
weight: 30
url: /sv/net/exporting-math-equations/
keywords:
- exportera matematiska ekvationer
- exportera ekvationer till LaTeX
- PowerPoint till LaTeX
- MathML
- LaTeX
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Exportera matematiska ekvationer från PowerPoint-presentationer till LaTeX eller MathML direkt med Aspose.Slides för .NET."
---
## **Introduktion**

Aspose.Slides för .NET låter dig exportera matematiska ekvationer från presentationer. Till exempel kan du behöva extrahera de matematiska ekvationerna på bildspel (från en specifik presentation) och använda dem i ett annat program eller plattform. 

{{% alert color="info" %}} 

Du kan exportera ekvationer direkt till LaTeX eller till MathML, en populär standard för matematiskt innehåll som används på webben och i många applikationer.

{{% /alert %}}

## **Exportera matematiska ekvationer till LaTeX**

Aspose.Slides kan konvertera en PowerPoint-matematisk ekvation direkt till LaTeX; en mellanliggande MathML-fil och en extern konverterare krävs inte. En matematisk ekvation lagras i en textram i en [MathPortion](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathportion/). Använd [MathPortion.MathParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathportion/mathparagraph/) för att få ett [IMathParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathparagraph/), och anropa sedan [IMathParagraph.ToLatex](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathparagraph/tolatex/). Metoden returnerar en sträng som du kan spara, visa, skicka till ett annat program eller bearbeta vidare.

Följande exempel går igenom varje textram på varje bild, hittar alla matematiska delar och skriver varje ekvation till en separat `.tex`-fil:

```csharp
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Util;

using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/getalltextboxes/) returnerar alla textram som hittas på en bild. Typkontrollen för [MathPortion] separerar äkta redigerbara ekvationer från vanlig text och bilder.

LaTeX-motorer och dokumentmallar stödjer inte alla samma kommandon, paket eller Unicode-tecken. Testa den returnerade strängen med den LaTeX-motor som används av din applikation. Om en symbol eller Office Math‑element saknar lämplig representation i den miljön, ersätt den i den returnerade strängen med ett projekt‑specifikt kommando eller hoppa över ekvationen och registrera problemet för granskning.

## **Spara matematiska ekvationer som MathML**

Medan människor enkelt kan skriva koden för vissa ekvationsformat som LaTeX, har de svårt att skriva koden för MathML eftersom det senare är avsett att genereras automatiskt av program. Program läser och analyserar MathML enkelt eftersom dess kod är i XML, så MathML används ofta som ett utskrifts- och utskriftsformat i många områden. 

Detta exempelprogram visar hur du exporterar en matematisk ekvation från en presentation till MathML:

```c#
using Aspose.Slides;
using Aspose.Slides.MathText;

using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **FAQ**

**Vad exporteras exakt till MathML—ett stycke eller ett enskilt formelblock?**

Du kan exportera antingen ett helt matematiskt stycke ([MathParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathparagraph/)) eller ett enskilt block ([MathBlock](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathblock/)) till MathML. Båda typerna har en metod för att skriva till MathML.

**Hur kan jag avgöra att ett objekt på en bild är en matematisk formel snarare än vanlig text eller en bild?**

En formel finns i en [MathPortion](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathportion/) och har ett [MathParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathparagraph/). Bilder och vanliga textdelar utan ett [MathParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathparagraph/) kan inte exporteras som formler.

**Varifrån kommer MathML i en presentation—är det PowerPoint‑specifikt eller en standard?**

Exporten riktar sig mot standard‑MathML (XML). Aspose använder Presentation MathML—presentationssubdelen av standarden—som är allmänt använd i program och på webben.

**Stöds export av formler i tabeller, SmartArt, grupper osv.?**

Ja, om dessa objekt innehåller textdelar med ett [MathParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathparagraph/) (dvs. äkta PowerPoint‑formler) exporteras de. Om en formel är inbäddad som en bild, exporteras den inte.

**Modifierar export till MathML den ursprungliga presentationen?**

Nej. Att skriva MathML är en serialisering av formulans innehåll; den ändrar inte presentationsfilen.