---
title: Hantera presentationstillgänglighet i .NET
linktitle: Presentationstillgänglighet
type: docs
weight: 30
url: /sv/net/presentation-accessibility/
keywords:
- presentationstillgänglighet
- alternativ text
- alternativ texttitel
- alternativ textbeskrivning
- markera som dekorativ
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Automatisera kontroller av presentationstillgänglighet i PPT-, PPTX- och ODP-filer med Aspose.Slides för .NET—förbättra skärmläsarupplevelsen och öka efterlevnaden."
---
## **Introduktion**

Alternativ text hjälper personer som använder hjälpmedel att förstå betydelsen av bilder, diagram och andra informativa former. Denna artikel förklarar hur man läser och uppdaterar alternativa texttitlar och beskrivningar med Aspose.Slides för .NET, skiljer åt tillgänglighetsbeskrivningar från formnamn som används i kod, och kontrollerar om en form är markerad som dekorativ.

Dessa funktioner stödjer presentationens tillgänglighet, men garanterar den inte. Läsordning, färgkontrast, läsbarhet av text och andra tillgänglighetskrav måste också granskas.

## **Hantera alternativa texttitlar och beskrivningar**

Använd alternativ text för att förklara betydelsen av bilder, diagram och andra informativa former för personer som inte kan se dem. Följande egenskaper har olika syften:

| Egenskap eller innehåll | Syfte |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/alternativetexttitle/) | En kort titel för den alternativa beskrivningen. |
| [AlternativeText](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/alternativetext/) | En meningsfull beskrivning av formens innehåll eller syfte i bildens sammanhang. |
| [Name](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/name/) | Formens namn, som kod kan använda för att hitta en specifik form i presentationen. |
| Synlig text | Innehåll som visas på bilden, t.ex. en forms text eller ett diagrammets titel och etiketter. Uppdatering av alternativ text ändrar inte detta innehåll. |

När en presentation återanvänds som en mall kan kod hitta en form via dess [Name](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/name/) innan den uppdateras. Detta namn har ett annat syfte än alternativ text, som förklarar vad det visuella förmedlar till läsaren. Sökning på namn gör att författare kan förbättra eller översätta beskrivningar utan att ändra hur kod hittar formen. Namn kan redigeras och är inte garanterat unika, så kontrollera att namnet motsvarar den avsedda formen; se [Identify and Find Shapes](/slides/sv/net/shape-manipulations/#identify-and-find-shapes).

Följande exempel kräver `input.pptx` med en bild av en kontorsentré som den första formen på den första bilden. Bilden bör inte vara markerad som dekorativ. Exemplet läser och skriver ut dess nuvarande alternativa texttitel och beskrivning, uppdaterar båda värdena och sparar presentationen som `output.pptx`. Anpassa formuleringen till den faktiska bilden och den information den förmedlar.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Att bara lägga till alternativ text garanterar inte presentationens tillgänglighet eller efterlevnad av tillgänglighetsstandarder. Granska beskrivningarna för noggrannhet och relevans, och kontrollera även läsordning, färgkontrast, läsbar text och andra tillgänglighetskrav. Informativa visuella element bör inte märkas som dekorativa; nästa avsnitt visar hur man läser [IsDecorative](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/isdecorative/).

## **Markera som dekorativ**

Markera som dekorativ flaggar rent dekorativa visuella element så att skärmläsare hoppar över dem, vilket minskar brus och håller fokus på meningsfullt innehåll. Applicera det på bakgrunder, utsmyckningar och avståndsmarkörer—aldrig på diagram, ikoner eller bilder som förmedlar information. Aspose.Slides exponerar denna flagga för upptäckt och validering, vilket möjliggör automatiska tillgänglighetskontroller och rensning.

![Mark as Decorative](mark_as_decorative.png)

Följande kodexempel visar hur man avgör om en form är markerad som dekorativ.

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **FAQ**

**Vad bör jag ha i den alternativa texttiteln och beskrivningen?**

Använd en kort titel för att identifiera ämnet och en beskrivning för att förklara informationen som den visuella delen förmedlar i bildens sammanhang. För ett diagram, beskriv den relevanta trenden eller jämförelsen istället för att bara säga "diagram".

**Ska jag använda alternativ text för att lokalisera former i en mall?**

Föredra att hitta formen via dess [Name](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/name/) och kontrollera att det är den förväntade formen. Alternativ text kan redigeras eller översättas, vilket kan bryta kod som söker efter en exakt beskrivning; se [Identify and Find Shapes](/slides/sv/net/shape-manipulations/).

**När bör en form markeras som dekorativ?**

Använd den dekorativa flaggan för visuella element som inte tillför någon information, såsom ornamentala utsmyckningar. Bilder och diagram som förmedlar betydelse behöver en lämplig beskrivning istället.

**Gör tillägg av alternativ text en presentation helt tillgänglig?**

Nej. Alternativ text täcker bara en del av tillgängligheten. Granska även läsordning, färgkontrast, textens läsbarhet och andra tillämpliga krav; att endast sätta dessa egenskaper skapar inte efterlevnad.