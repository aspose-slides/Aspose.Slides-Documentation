---
title: Exportera matematiska ekvationer från presentationer i .NET
linktitle: Exportera ekvationer
type: docs
weight: 30
url: /sv/net/exporting-math-equations/
keywords:
- exportera matematiska ekvationer
- MathML
- LaTeX
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Möjliggör sömlös export av matematiska ekvationer från PowerPoint till MathML med Aspose.Slides för .NET—bevara formatering och öka kompatibilitet."
---
## **Introduktion**

Aspose.Slides for .NET låter dig exportera matematiska ekvationer från presentationer. Till exempel kan du behöva extrahera de matematiska ekvationerna på bilder (från en specifik presentation) och använda dem i ett annat program eller plattform. 

{{% alert color="primary" %}} 

Du kan exportera ekvationer till MathML, ett populärt format eller standard för matematiska ekvationer och liknande innehåll som ses på webben och i många applikationer. 

{{% /alert %}}

## **Spara matematiska ekvationer som MathML**

Medan människor enkelt kan skriva koden för vissa ekvationsformat som LaTeX, har de svårt att skriva koden för MathML eftersom det senare är avsett att genereras automatiskt av appar. Program läser och parsar MathML enkelt eftersom dess kod är i XML, så MathML används ofta som ett utdata- och utskriftsformat i många områden. 

Den här exempelkoden visar hur du exporterar en matematisk ekvation från en presentation till MathML:

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **Vanliga frågor**

**Vad exporteras exakt till MathML—ett stycke eller ett enskilt formelblock?**

Du kan exportera antingen ett helt matematiskt stycke ([MathParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathparagraph/)) eller ett enskilt block ([MathBlock](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathblock/)) till MathML. Båda typerna erbjuder en metod för att skriva till MathML.

**Hur kan jag avgöra att ett objekt på en bild är en matematisk formel snarare än vanlig text eller en bild?**

En formel finns i en [MathPortion](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathportion/) och har ett [MathParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathparagraph/). Bilder och vanliga textdelar utan ett [MathParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathparagraph/) är inte exportbara formler.

**Varifrån kommer MathML i en presentation—är det specifikt för PowerPoint eller en standard?**

Exporten riktar sig mot standard‑MathML (XML). Aspose använder Presentation MathML—presentation‑delmängden av standarden—som är allmänt använd i många applikationer och på webben.

**Stöds export av formler i tabeller, SmartArt, grupper etc.?**

Ja, om dessa objekt innehåller textdelar med ett [MathParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathparagraph/) (dvs. riktiga PowerPoint‑formler) exporteras de. Om en formel är inbäddad som en bild exporteras den inte.

**Modifierar export till MathML den ursprungliga presentationen?**

Nej. Att skriva MathML är en serialisering av formelns innehåll; den ändrar inte presentationsfilen.