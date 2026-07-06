---
title: Hämta gränser för textdel i presentationer i C++
linktitle: Portionsgränser
type: docs
weight: 47
url: /sv/cpp/portion-bounds/
keywords:
- gränser för textdel
- textdel
- textdel
- textkoordinater
- textposition
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du hämtar gränser för textdel i PowerPoint-presentationer med Aspose.Slides för C++."
---
## **Översikt**

En textdel representerar ett specifikt fragment av text i ett stycke och låter dig arbeta med det fragmentet oberoende av omgivande innehåll. I Aspose.Slides kan delar användas när du behöver hämta gränserna för ett textfragment, tillämpa formatering endast på en del av ett stycke eller kontrollera textbeteende på en mer detaljerad nivå.

Den här artikeln visar hur man får den omgivande rektangeln för en del genom att använda [IPortion::GetRect](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/getrect/). Den visar också hur man får koordinaterna för början av en del genom att använda [IPortion::GetCoordinates](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/getcoordinates/). Dessutom belyser den vanliga scenarier relaterade till delar, såsom att tillämpa en hyperlänk på ett enskilt textfragment, förstå hur formatering löses genom del, stycke, textruta och temaarv, samt hantera fall där ett specificerat teckensnitt saknas.

## **Hämta gränser för en textdel**

Använd [IPortion::GetRect](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/getrect/) för att hämta den omgivande rektangeln för en textdel:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **Hämta koordinater för en textdel**

Använd [IPortion::GetCoordinates](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/getcoordinates/) för att hämta koordinaterna för början av en textdel:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **Vanliga frågor**

**Kan jag tillämpa en hyperlänk på endast en del av texten inom ett enda stycke?**

Ja, du kan [tilldela en hyperlänk](/slides/sv/cpp/manage-hyperlinks/) till en enskild del; endast det fragmentet blir klickbart, inte hela stycket.

**Hur fungerar stilarv: vad åsidosätter en del, och vad tas från ett stycke eller en textruta?**

Egenskaper på delnivå har högsta prioritet. Om en egenskap inte är inställd på [IPortion](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/), hämtar Aspose.Slides den från [IParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/). Om den inte är inställd där heller, använder Aspose.Slides stilen från [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) eller [theme](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/theme/).

**Vad händer om det teckensnitt som specificerats för en del saknas på målmaskinen eller servern?**

[Font substitution rules](/slides/sv/cpp/font-selection-sequence/) tillämpas. Texten kan omflöda: mått, avstavning och bredd kan ändras, vilket är viktigt för exakt positionering.

**Kan jag ställa in delspecifik textfyllnadsgenomskinlighet eller en gradient oberoende av resten av stycket?**

Ja, textfärg, fyllning och genomskinlighet på [IPortion](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/) nivå kan skilja sig från närliggande fragment.