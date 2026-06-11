---
title: Hantera textavsnitt i presentationer i .NET
linktitle: Textavsnitt
type: docs
weight: 70
url: /sv/net/portion/
keywords:
- textavsnitt
- textdel
- textkoordinater
- textposition
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du hanterar textavsnitt i PowerPoint-presentationer med Aspose.Slides för .NET, vilket förbättrar prestanda och anpassning."
---
## **Översikt**

Ett textavsnitt representerar ett specifikt fragment av text i ett stycke och låter dig arbeta med det fragmentet oberoende av omgivande innehåll. I Aspose.Slides kan avsnitt användas när du behöver hämta positionen för ett textfragment, tillämpa formatering på endast en del av ett stycke eller styra textbeteende på en mer detaljerad nivå.

Denna artikel visar hur du får koordinaterna för början av ett avsnitt med metoden `GetCoordinates()`. Den belyser också vanliga scenarier relaterade till avsnitt, såsom att tillämpa en hyperlänk på ett enskilt textfragment, förstå hur formatering löser sig genom avsnitt, stycke, textram och temaarv, samt hantera situationer där ett angivet teckensnitt saknas. Dessutom noteras att textfyllning, färg och transparens kan sättas olika för enskilda avsnitt inom samma stycke.

## **Hämta koordinater för en textdel**
**GetCoordinates()**‑metoden har lagts till i IPortion och Portion‑klassen och möjliggör att hämta koordinaterna för början av avsnittet:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```

## **Vanliga frågor**

**Kan jag tillämpa en hyperlänk endast på en del av texten i ett enda stycke?**

Ja, du kan [tilldela en hyperlänk](/slides/sv/net/manage-hyperlinks/) till ett enskilt avsnitt; endast det fragmentet blir klickbart, inte hela stycket.

**Hur fungerar stilarv: vad åsidosätter ett avsnitt, och vad tas från Stycke/Textram?**

Egenskaper på avsnittsnivå har högsta prioritet. Om en egenskap inte är angiven på [Portion](https://reference.aspose.com/slides/sv/net/aspose.slides/portion/), hämtas den från [Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraph/); om den inte är angiven där heller, från [TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/) eller temastilen [theme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/theme/).

**Vad händer om teckensnittet som anges för ett avsnitt saknas på målmaskinen/servern?**

[Font substitution rules](/slides/sv/net/font-selection-sequence/) tillämpas. Texten kan flöda om: mått, avstavning och bredd kan förändras, vilket är viktigt för exakt positionering.

**Kan jag ange en avsnittsspecifik textfyllnings‑transparens eller gradient oberoende av resten av stycket?**

Ja, textfärg, fyllning och transparens på [Portion](https://reference.aspose.com/slides/sv/net/aspose.slides/portion/)-nivå kan skilja sig från närliggande fragment.