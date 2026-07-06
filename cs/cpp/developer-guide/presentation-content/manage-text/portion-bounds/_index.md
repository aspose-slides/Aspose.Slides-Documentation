---
title: Získání ohraničení textových úseků v prezentacích v C++
linktitle: Ohraničení úseku
type: docs
weight: 47
url: /cs/cpp/portion-bounds/
keywords:
- ohraničení textových úseků
- textový úsek
- textová část
- souřadnice textu
- pozice textu
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak získat ohraničení textových úseků v prezentacích PowerPoint pomocí Aspose.Slides pro C++."
---
## **Přehled**

Textový úsek představuje konkrétní fragment textu uvnitř odstavce a umožňuje s tímto fragmentem pracovat nezávisle na okolním obsahu. V Aspose.Slides lze úseky použít, když potřebujete získat ohraničení textového fragmentu, aplikovat formátování pouze na část odstavce nebo řídit chování textu na podrobnější úrovni.

Tento článek ukazuje, jak získat ohraničující obdélník úseku pomocí [IPortion::GetRect](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/getrect/). Také ukazuje, jak získat souřadnice začátku úseku pomocí [IPortion::GetCoordinates](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/getcoordinates/). Navíc zdůrazňuje běžné scénáře související s úseky, jako je aplikace hypertextového odkazu na jediný textový fragment, pochopení toho, jak se formátování řeší prostřednictvím úseku, odstavce, textového rámce a dědičnosti motivu, a řešení situací, kdy je požadované písmo nedostupné.

## **Získání ohraničení textového úseku**

Použijte [IPortion::GetRect](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/getrect/) k získání ohraničujícího obdélníku textového úseku:

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

## **Získání souřadnic textového úseku**

Použijte [IPortion::GetCoordinates](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/getcoordinates/) k získání souřadnic začátku textového úseku:

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

## **Často kladené otázky**

**Mohu použít hypertextový odkaz pouze na část textu v jednom odstavci?**

Ano, můžete [přiřadit hypertextový odkaz](/slides/cs/cpp/manage-hyperlinks/) jednotlivému úseku; pouze tento fragment bude klikací, ne celý odstavec.

**Jak funguje dědičnost stylů: co úsek přepisuje a co je převzato z odstavce nebo textového rámce?**

Vlastnosti na úrovni úseku mají nejvyšší prioritu. Pokud není vlastnost nastavena na [IPortion](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/), Aspose.Slides ji převezme z [IParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/). Pokud není nastavena ani tam, Aspose.Slides použije styl z [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) nebo [theme](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/theme/).

**Co se stane, pokud je písmo určené pro úsek na cílovém počítači nebo serveru chybějící?**

[Pravidla nahrazování písem](/slides/cs/cpp/font-selection-sequence/) se použijí. Text se může přeuspořádat: mohou se změnit metriky, dělení slov a šířka, což je důležité pro přesné umístění.

**Mohu nastavit specifickou průhlednost výplně textu nebo gradient úseku nezávisle na zbytku odstavce?**

Ano, barva textu, výplň a průhlednost na úrovni [IPortion](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/) se mohou lišit od sousedních fragmentů.