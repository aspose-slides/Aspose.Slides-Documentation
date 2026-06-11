---
title: Hantera textdelar i presentationer med C++
linktitle: Textdel
type: docs
weight: 70
url: /sv/cpp/portion/
keywords:
- textdel
- textavsnitt
- textkoordinater
- textposition
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du hanterar textdelar i PowerPoint-presentationer med Aspose.Slides för C++, vilket förbättrar prestanda och anpassning."
---
## **Introduktion**

En textdel representerar ett specifikt fragment av text i ett stycke och låter dig arbeta med det fragmentet oberoende av omgivande innehåll. I Aspose.Slides kan textdelar användas när du behöver hämta positionen för ett textfragment, applicera formatering på endast en del av ett stycke, eller styra textbeteende på en mer detaljerad nivå.

## **Hämta koordinater för en textdel**
**GetCoordinates()** metoden har lagts till i IPortion och Portion‑klass som möjliggör att hämta koordinaterna för början av textdelen:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **Vanliga frågor**

**Kan jag applicera en hyperlänk på endast en del av texten i ett enda stycke?**

Ja, du kan [tilldela en hyperlänk](/slides/sv/cpp/manage-hyperlinks/) till en enskild textdel; bara det fragmentet blir klickbart, inte hela stycket.

**Hur fungerar stilarv: vad åsidosätter en Portion, och vad tas från Paragraph/TextFrame?**

Egenskaper på textdelnivå har högsta prioritet. Om en egenskap inte är angiven på [Portion](https://reference.aspose.com/slides/sv/cpp/aspose.slides/portion/), hämtar motorn den från [Paragraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/paragraph/); om den inte är angiven där heller, från [TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/textframe/) eller från [theme](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/theme/)‑stilen.

**Vad händer om det teckensnitt som specificerats för en Portion saknas på målmaskinen/servern?**

[Regler för typsnittsersättning](/slides/sv/cpp/font-selection-sequence/) tillämpas. Texten kan flöda om: metrik, avstavning och bredd kan förändras, vilket är viktigt för exakt positionering.

**Kan jag ange en Portion‑specifik textfyllnads‑transparens eller gradient oberoende av resten av stycket?**

Ja, textfärg, fyllning och transparens på [Portion](https://reference.aspose.com/slides/sv/cpp/aspose.slides/portion/)‑nivå kan skilja sig från intilliggande fragment.