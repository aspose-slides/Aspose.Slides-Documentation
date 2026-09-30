---
title: Správa tabulek prezentací v C++
linktitle: Správa tabulky
type: docs
weight: 10
url: /cs/cpp/manage-table/
keywords:
- přidat tabulku
- vytvořit tabulku
- přístup k tabulce
- poměr stran
- zarovnání textu
- formátování textu
- styl tabulky
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Vytvářejte a upravujte tabulky v PowerPoint snímcích pomocí Aspose.Slides pro C++. Objevte jednoduché ukázky kódu, které zjednoduší vaše pracovní postupy s tabulkami."
---
## **Úvod**

Tabulky v PowerPointu organizují informace do řádků a sloupců, což usnadňuje čtení a porovnávání hodnot.

Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) , rozhraní [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) , třídu [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) , rozhraní [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) a další typy, které vám umožní vytvářet, aktualizovat a spravovat tabulky v prezentacích.

## **Vytvoření tabulky od začátku**

Vytvořte tabulku zadáním její pozice, šířek sloupců a výšek řádků. Po přidání na snímek můžete formátovat okraje buněk, slučovat buňky a vkládat text.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Definujte pole šířek sloupců v bodech.
4. Definujte pole výšek řádků v bodech.
5. Přidejte objekt [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) na snímek pomocí metody [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. Projděte každou [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) a aplikujte formátování na horní, spodní, pravý a levý okraj.
7. Sloučte první dvě buňky v první řadě tabulky.
8. Získejte přístup k sloučené buňce pomocí její metody [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/).
9. Nastavte text ve sloučené buňce.
10. Uložte upravenou prezentaci.

Níže uvedený příklad vytvoří tabulku se třemi sloupci a pěti řádky v bodových souřadnicích (100, 50). Aplikuje červené okraje šířky 5 bodů, sloučí první dvě buňky v první řadě a výsledek uloží jako `table.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Číslování ve standardní tabulce**

V standardní tabulce jsou indexy buněk založeny na nule a používají pořadí (sloupec, řádek). První buňka má index (0, 0).

Například buňky v tabulce se 4 sloupci a 4 řádky jsou číslovány takto:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Tento příklad vytvoří výše ilustrovanou 4 × 4 tabulku se šířkami sloupců a výškami řádků 70 bodů a červenými okraji buněk šířky 5 bodů. Souřadnice zobrazují indexy buněk; příklad nechává buňky prázdné a uloží tabulku jako `StandardTables_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Přístup k existující tabulce**

Tabulky jsou uloženy ve sbírce tvarů snímku. Projděte tvary, abyste našli tabulku, a pak použijte rozhraní [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) k načtení nebo aktualizaci jejích buněk.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek obsahující tabulku podle jeho indexu.
3. Projděte objekty [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) a zastavte se, když je nalezena tabulka. Pokud snímek obsahuje několik tabulek, použijte [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) k identifikaci té, kterou potřebujete.
4. Aktualizujte text v cílové buňce.
5. Uložte upravenou prezentaci.

Příklad níže otevře `UpdateExistingTable.pptx` a najde první tabulku na prvním snímku. Nastaví buňku ve sloupci 0, řádku 1 na `New` a výsledek uloží jako `table1_out.pptx`. Vstup musí obsahovat alespoň jeden snímek a první tabulka na tomto snímku musí mít alespoň jeden sloupec a dva řádky.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

Pro změnu velikosti řádku v existující tabulce a pochopení, proč může jeho skutečná výška překročit požadované minimum, viz [Control Row Height](/slides/cs/cpp/manage-rows-and-columns/#control-row-height).

## **Najděte buňku, která vlastní textový rámec**

Když obecný kód pro zpracování textu získá [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) z tabulky, použijte [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) k získání vlastnící [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/). Pro textový rámec buňky tabulky [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) vrací vlastníka a [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) vrací `nullptr`, i když samotná tabulka je tvar.

Souřadnice buňky jsou dostupné prostřednictvím metod pouze pro čtení [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) a [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/). [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) také poskytuje navigaci jen pro čtení: vrací vlastníka, ale nemění vlastnictví. Vždy zkontrolujte, zda vrácená buňka není `nullptr`, před jejím použitím.

Pro kompletní příklad, který identifikuje vlastníky buňky tabulky a tvaru, včetně tvarů spojených s uzly SmartArt, viz [Search and Replace Text](/slides/cs/cpp/search-and-replace-text/).

## **Zarovnání textu v tabulce**

Můžete řídit vertikální ukotvení a směr textu jednotlivých buněk tabulky. Příklad v této sekci vycentruje text v první buňce a otočí jej o 270 stupňů.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte objekt [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) na snímek.
4. Získejte objekt [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) z tabulky.
5. Získejte první [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) a nastavte jeho text a barvu.
6. Nastavte vertikální ukotvení buňky a směr textu pomocí [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) a [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/).
7. Uložte upravenou prezentaci.

Tento příklad vytvoří 4 × 4 tabulku se šířkami sloupců 120 bodů a výškami řádků 100 bodů. Formátuje text v buňce (0, 0), přidá hodnoty do zbylých buněk v první řadě a výsledek uloží jako `Vertical_Align_Text_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Nastavení formátování textu na úrovni tabulky**

Použijte [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) k aplikaci formátování textu na všechny buňky v tabulce. Jeho přetížení přijímají formátování části, odstavce a textového rámce, takže můžete nastavit tyto vlastnosti bez iterace jednotlivých buněk.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Získejte objekt [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) z snímku.
4. Nastavte velikost písma pomocí [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) pro text.
5. Nastavte zarovnání odstavce a pravý okraj pomocí [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) a [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. Nastavte směr textu pomocí [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Uložte upravenou prezentaci.

Příklad níže otevře `table.pptx`, který musí obsahovat alespoň jeden snímek s tabulkou jako jejím prvním tvarem. Nastaví velikost písma na 25 bodů, zarovná odstavce vpravo s pravým okrajem 20 bodů a nastaví text vertikálně. Formátovaná prezentace je uložena jako `result.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Získání vlastností stylu tabulky**

Použijte [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) k načtení přednastaveného stylu tabulky a [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) k jeho přiřazení. Tento příklad aplikuje [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) na jednu tabulku, vytiskne název přednastavení a přiřadí stejný preset druhé tabulce. Obě tabulky jsou uloženy v `table-style.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **Uzamčení poměru stran tabulky**

Poměr stran tabulky je poměr její šířky k výšce. Použijte [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) k uzamčení tohoto poměru pro tabulku.

Příklad níže otevře `pres.pptx`, který musí obsahovat alespoň jeden snímek s tabulkou jako jejím prvním tvarem. Vytiskne aktuální stav uzamčení, zapne uzamčení poměru stran, vytiskne aktualizovaný stav (`True`) a výsledek uloží jako `pres-out.pptx`.

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Mohu povolit směr čtení zprava doleva (RTL) pro celou tabulku a text v jejích buňkách?**

Ano. Tabulka poskytuje metodu [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/), a odstavce mají [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/). Použitím obou zajistíte správné RTL pořadí a vykreslení uvnitř buněk.

**Jak mohu zabránit uživatelům v přesouvání nebo změně velikosti tabulky v konečném souboru?**

Použijte [shape locks](/slides/cs/cpp/applying-protection-to-presentation/) k zakázání přesouvání, změny velikosti, výběru atd. Tyto zámky platí i pro tabulky.

**Je podporováno vložení obrázku do buňky jako pozadí?**

Ano. Můžete nastavit [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) pro buňku; obrázek pokryje oblast buňky podle zvoleného režimu (roztažení nebo dlaždice).