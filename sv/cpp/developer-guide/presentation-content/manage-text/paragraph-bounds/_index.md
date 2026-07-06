---
title: Hämta styckesgränser från presentationer i C++
linktitle: Styckesgränser
type: docs
weight: 43
url: /sv/cpp/paragraph-bounds/
keywords:
- styckesgränser
- styckeskoordinat
- styckesstorlek
- textram
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du hämtar styckesgränser i Aspose.Slides för C++ för att optimera textpositionering i PowerPoint-presentationer."
---
## **Översikt**

Denna artikel förklarar hur man får gränserna, storleken och koordinaterna för stycken i Aspose.Slides. Den visar hur man hämtar ett styckesrektangel från en [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) genom att använda [IParagraph::GetRect](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/getrect/), hur man får styckekoordinater i en tabellcells textram, och belyser viktiga detaljer såsom mätenheter, effekten av radbrytning på gränser, pixelkonvertering och effektiva formateringsvärden för stycken.

## **Hämta rektangulära koordinater för ett stycke**

Använd [IParagraph::GetRect](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/getrect/) för att få det omgivande rektangeln för ett stycke.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **Hämta storleken på ett stycke i en tabellcells TextFrame**

För att hämta storlek och koordinater för ett [IParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/) i en tabellcells textram, använd [IParagraph::GetRect](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/getrect/). Det returnerade rektangeln är relativt tabellcellens textram, så lägg till tabellens position och cellens offset när du behöver koordinater på bildnivå.

Följande exempel hämtar styckets gränser i en tabellcell och ritar rektanglar på bilden för att visualisera dessa gränser:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**I vilka enheter mäts styckekoordinaterna?**

De mäts i punkter, där 1 tum motsvarar 72 punkter. Detta gäller för alla koordinater och dimensioner på bilden.

**Påverkar radbrytning ett styckes gränser?**

Ja. Om [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/set_wraptext/) är aktiverat för [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/), bryts texten för att passa områdets bredd, vilket förändrar styckets faktiska gränser.

**Kan styckekoordinater tillförlitligt mappas till pixlar i den exporterade bilden?**

Ja. Konvertera punkter till pixlar med formeln: pixlar = punkter x (DPI / 72). Resultatet beror på den DPI som valts för rendering eller export.

**Hur får jag de "effektiva" formateringsparametrarna för ett stycke, med hänsyn till stilärv?**

Använd [effective paragraph formatting data structure](/slides/sv/cpp/shape-effective-properties/); den returnerar de slutgiltiga konsoliderade värdena för indrag, avstånd, radbrytning, RTL och mer.