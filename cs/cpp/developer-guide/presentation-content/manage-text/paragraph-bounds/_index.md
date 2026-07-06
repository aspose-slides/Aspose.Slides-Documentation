---
title: Získání ohraničení odstavců z prezentací v C++
linktitle: Ohraničení odstavců
type: docs
weight: 43
url: /cs/cpp/paragraph-bounds/
keywords:
- ohraničení odstavce
- souřadnice odstavce
- velikost odstavce
- textový rámec
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak v Aspose.Slides pro C++ získat ohraničení odstavců a optimalizovat umístění textu v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak získat ohraničení, velikost a souřadnice odstavců v Aspose.Slides. Ukazuje, jak pomocí [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) získat obdélník odstavce pomocí [IParagraph::GetRect](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/getrect/), jak získat souřadnice odstavce uvnitř textového rámce buňky tabulky, a zdůrazňuje důležité podrobnosti, jako jsou jednotky měření, vliv zalamování textu na ohraničení, převod na pixely a hodnoty efektivního formátování odstavce.

## **Získání obdélníkových souřadnic odstavce**

Použijte [IParagraph::GetRect](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/getrect/) k získání ohraničujícího obdélníku odstavce.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **Získání velikosti odstavce uvnitř textového rámce buňky tabulky**

Chcete‑li získat velikost a souřadnice [IParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/) v textovém rámci buňky tabulky, použijte [IParagraph::GetRect](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/getrect/). Vrácený obdélník je relativní k textovému rámci buňky tabulky, takže když potřebujete souřadnice na úrovni snímku, přidejte pozici tabulky a posun buňky.

Následující příklad získá ohraničení odstavce uvnitř buňky tabulky a vykreslí obdélníky na snímku pro vizualizaci těchto ohraničení:

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

## **Často kladené otázky**

**V jakých jednotkách se měří souřadnice odstavce?**

Měří se v bodech, kde 1 palec odpovídá 72 bodům. Toto platí pro všechny souřadnice a rozměry na snímku.

**Ovlivňuje zalamování textu ohraničení odstavce?**

Ano. Pokud je pro [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) povoleno [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/set_wraptext/), text se zalamuje tak, aby se vešel do šířky oblasti, což mění skutečné ohraničení odstavce.

**Lze souřadnice odstavce spolehlivě převést na pixely v exportovaném obrázku?**

Ano. Převést body na pixely pomocí tohoto vzorce: pixely = body × (DPI / 72). Výsledek závisí na DPI zvoleném pro vykreslování nebo export.

**Jak získat „efektivní“ parametry formátování odstavce s ohledem na dědičnost stylu?**

Použijte [effective paragraph formatting data structure](/slides/cs/cpp/shape-effective-properties/); vrací konečné konsolidované hodnoty odsazení, mezery, zalamování, RTL a další.