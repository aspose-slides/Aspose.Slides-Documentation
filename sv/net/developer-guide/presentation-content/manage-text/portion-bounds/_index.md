---
title: Hämta gränser för textdelar i presentationer i .NET
linktitle: Delgränser
type: docs
weight: 47
url: /sv/net/portion-bounds/
keywords:
- gränser för textdel
- textdel
- textdel
- textkoordinater
- textposition
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du hämtar gränser för textdelar i PowerPoint-presentationer med Aspose.Slides för .NET."
---
## **Översikt**

En textdel representerar ett specifikt fragment av text i ett stycke och gör det möjligt att arbeta med det fragmentet oberoende av omgivande innehåll. I Aspose.Slides kan delar användas när du behöver hämta gränserna för ett textfragment, tillämpa formatering på endast en del av ett stycke eller kontrollera textbeteendet på en mer detaljerad nivå.

Denna artikel visar hur du får den omgivande rektangeln för en del genom att använda [IPortion.GetRect](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/getrect/). Den visar också hur du får koordinaterna för början av en del genom att använda [IPortion.GetCoordinates](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/getcoordinates/). Dessutom belyser den vanliga scenarier relaterade till delar, såsom att tillämpa en hyperlänk på ett enskilt textfragment, förstå hur formatering löses genom del, stycke, textruta och temaarv, samt hantera fall där ett angivet typsnitt saknas.

## **Hämta gränser för en textdel**

Använd [IPortion.GetRect](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/getrect/) för att hämta den omgivande rektangeln för en textdel:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **Hämta koordinater för en textdel**

Använd [IPortion.GetCoordinates](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/getcoordinates/) för att hämta koordinaterna för början av en textdel:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **Vanliga frågor**

**Kan jag tillämpa en hyperlänk på endast en del av texten i ett enda stycke?**

Ja, du kan [tilldela en hyperlänk](/slides/sv/net/manage-hyperlinks/) till en enskild del; endast det fragmentet blir klickbart, inte hela stycket.

**Hur fungerar stilärvning: vad åsidosätter en del, och vad tas från ett stycke eller en textruta?**

Egenskaper på delnivå har högsta prioritet. Om en egenskap inte är angiven på [IPortion](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/) hämtar Aspose.Slides den från [IParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/). Om den inte är angiven där heller använder Aspose.Slides stilen från [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/) eller [theme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/theme/).

**Vad händer om det typsnitt som angivits för en del saknas på målmaskinen eller servern?**

[Regler för typsnittssubstitution](/slides/sv/net/font-selection-sequence/) gäller. Texten kan flöda om: mått, avstavning och bredd kan förändras, vilket är viktigt för exakt positionering.

**Kan jag ställa in delspecifik textfyllnadstransparens eller ett gradient oberoende av resten av stycket?**

Ja, textfärg, fyllning och transparens på [IPortion](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/)-nivå kan skilja sig från närliggande fragment.