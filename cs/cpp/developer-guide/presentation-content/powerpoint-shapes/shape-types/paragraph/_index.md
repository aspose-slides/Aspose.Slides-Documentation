---
title: Získání ohraničení odstavce z prezentací v C++
linktitle: Odstavec
type: docs
weight: 60
url: /cs/cpp/paragraph/
keywords:
- ohraničení odstavce
- ohraničení části textu
- souřadnice odstavce
- souřadnice části
- velikost odstavce
- velikost části textu
- textový rámec
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak získat ohraničení odstavců a částí textu v Aspose.Slides pro C++ a optimalizovat umístění textu v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak získat ohraničení, velikost a souřadnice odstavců a částí textu v Aspose.Slides. Ukazuje, jak pomocí `GetRect()` získat obdélník odstavce v `TextFrame`, jak získat souřadnice odstavců a částí uvnitř textového rámce buňky tabulky, a zdůrazňuje důležité podrobnosti, jako jsou jednotky měření, vliv zalamování textu na ohraničení, převod na pixely a hodnoty efektivního formátování odstavců.

## **Získání souřadnic odstavce a části v TextFrame**

S pomocí Aspose.Slides pro C++ mohou vývojáři nyní získat obdélníkové souřadnice odstavce ve sbírce odstavců TextFrame. Umožňuje také získat souřadnice části ve sbírce částí odstavce. V této kapitole ukážeme na příkladu, jak získat obdélníkové souřadnice odstavce spolu s polohou části uvnitř odstavce.

## **Získání obdélníkových souřadnic odstavce**

Byla přidána nová metoda **GetRect()**. Umožňuje získat obdélník ohraničující odstavec.

``` cpp
// Vytvořte objekt Presentation, který představuje soubor prezentace
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Získání velikosti odstavce a části uvnitř textového rámce buňky tabulky**

Chcete-li získat velikost a souřadnice [Portion](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.portion) nebo [Paragraph](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.paragraph) v textovém rámci buňky tabulky, můžete použít metody [IPortion::GetRect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) a [IParagraph::GetRect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t).

Tento ukázkový kód demonstruje popsanou operaci:

``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```

## **Často kladené otázky**

**V jakých jednotkách jsou vráceny souřadnice odstavce a částí textu?**

V bodech (points), kde 1 palec = 72 bodů. Toto platí pro všechny souřadnice a rozměry na snímku.

**Má zalamování textu vliv na ohraničení odstavce?**

Ano. Pokud je v [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframe/) povoleno [wrapping](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframeformat/set_wraptext/), text se zalamuje tak, aby se vešel do šířky oblasti, což mění skutečné ohraničení odstavce.

**Lze souřadnice odstavce spolehlivě převést na pixely v exportovaném obrazu?**

Ano. Převod bodů na pixely provádějte pomocí: pixels = points × (DPI / 72). Výsledek závisí na DPI zvoleném pro vykreslování/export.

**Jak získám „efektivní“ parametry formátování odstavce s ohledem na dědičnost stylů?**

Použijte [effective paragraph formatting data structure](/slides/cs/cpp/shape-effective-properties/); vrací konečné konsolidované hodnoty pro odsazení, mezery, zalamování, RTL a další.