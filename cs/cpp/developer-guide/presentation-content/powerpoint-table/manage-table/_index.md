---
title: Správa tabulek v prezentaci v C++
linktitle: Spravovat tabulku
type: docs
weight: 10
url: /cs/cpp/manage-table/
keywords:
- přidat tabulku
- vytvořit tabulku
- přístup k tabulce
- poměr stran
- zarovnat text
- formátování textu
- styl tabulky
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Vytvářejte a upravujte tabulky v PowerPoint snímcích pomocí Aspose.Slides pro C++. Objevte jednoduché příklady kódu, které zjednoduší vaše pracovní postupy s tabulkami."
---
## **Úvod**

Tabulka v PowerPointu je efektivní způsob, jak zobrazit a představit informace. Informace v mřížce buněk (uspořádaných do řádků a sloupců) jsou přehledné a snadno pochopitelné.

Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/cs/cpp/aspose.slides/table/) , rozhraní [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) , třídu [Cell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/cell/) , rozhraní [ICell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icell/) a další typy, které vám umožní vytvářet, aktualizovat a spravovat tabulky ve všech typech prezentací. 

## **Vytvořit tabulku od začátku**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Definujte pole `columnWidth` .
4. Definujte pole `rowHeight` .
5. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) na snímek pomocí metody [AddTable()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addtable/) .
6. Projděte každou [ICell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icell/) a použijte formátování na horní, dolní, pravý a levý okraj.
7. Sloučte první dvě buňky v první řadě tabulky. 
8. Přistupte k [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframe/) buňky [ICell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icell/) .
9. Přidejte nějaký text do [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframe/) .
10. Uložte upravenou prezentaci.

Tento C++ kód ukazuje, jak vytvořit tabulku v prezentaci:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Vytváří instanci třídy Presentation, která představuje soubor PPTX
auto pres = System::MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
auto sld = pres->get_Slides()->idx_get(0);

// Definuje sloupce s šířkami a řádky s výškami
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Přidává tvar tabulky na snímek
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Nastavuje formát ohraničení pro každou buňku
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
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
// Sloučuje buňky 1 a 2 v řádku 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Přidává text do sloučené buňky
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Ukládá prezentaci na disk
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Číslování ve standardní tabulce**

V standardní tabulce je číslování buněk jednoduché a nulově založené. První buňka v tabulce má index 0,0 (sloupec 0, řádek 0). 

Například buňky v tabulce se 4 sloupci a 4 řádky jsou číslovány takto:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Tento C++ kód ukazuje, jak určit číslování buněk v tabulce:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Vytváří instanci třídy Presentation, která představuje soubor PPTX
auto pres = System::MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
auto sld = pres->get_Slides()->idx_get(0);

// Definuje sloupce s šířkami a řádky s výškami
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Přidává tvar tabulky na snímek
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Nastavuje formát ohraničení pro každou buňku
for (const auto& row : tbl->get_Rows())
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

// Ukládá prezentaci na disk
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Přístup k existující tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
2. Získejte referenci na snímek obsahující tabulku pomocí jeho indexu. 
3. Vytvořte objekt [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) a nastavte jej na null.
4. Procházejte všechny objekty [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/) , dokud nenajdete tabulku.

   Pokud máte podezření, že snímek, se kterým pracujete, obsahuje jedinou tabulku, můžete jednoduše zkontrolovat všechny tvary, které obsahuje. Když je tvar identifikován jako tabulka, můžete jej přetypovat na objekt [Table](https://reference.aspose.com/slides/cs/cpp/aspose.slides/table/) . Pokud však snímek obsahuje několik tabulek, je lepší vyhledat požadovanou tabulku pomocí její metody [set_AlternativeText()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/set_alternativetext/) .
5. Použijte objekt [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) k práci s tabulkou. V níže uvedeném příkladu jsme přidali nový řádek do tabulky.
6. Uložte upravenou prezentaci.

Tento C++ kód ukazuje, jak přistupovat k existující tabulce a pracovat s ní:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Vytváří instanci třídy Presentation, která představuje soubor PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Přistupuje k prvnímu snímku
auto sld = pres->get_Slides()->idx_get(0);

// Inicializuje nulovou tabulku
System::SharedPtr<ITable> tbl;

// Prochází tvary a nastavuje referenci na nalezenou tabulku
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Nastavuje text pro první sloupec druhého řádku
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Ukládá upravenou prezentaci na disk
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Najít buňku, která vlastní textový rámec**

Když obecný kód pro zpracování textu získá objekt [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) z tabulky, použijte [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/get_parentcell/) k získání vlastnící [ICell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icell/) . Pro textový rámec buňky tabulky vrací [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/get_parentcell/) vlastníka a [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/get_parentshape/) vrací `nullptr`, i když tabulka sama je tvar.

Souřadnice buňky jsou k dispozici prostřednictvím metod [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icell/get_firstcolumnindex/) a [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icell/get_firstrowindex/) , které jsou pouze pro čtení. [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/get_parentcell/) také poskytuje navigaci pouze pro čtení: vrací vlastníka, ale nemění vlastnictví. Vždy před použitím zkontrolujte, zda vrácená buňka není `nullptr` .

Pro kompletní příklad, který identifikuje vlastníky buňky tabulky a tvaru, včetně tvarů spojených se SmartArt uzly, viz [Search and Replace Text](/slides/cs/cpp/search-and-replace-text/) .

## **Zarovnat text v tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) na snímek. 
4. Získejte objekt [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) z tabulky. 
5. Přistupte k [IParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/) v [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) .
6. Zarovnejte text vertikálně.
7. Uložte upravenou prezentaci.

Tento C++ kód ukazuje, jak zarovnat text v tabulce:

```c++
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
#include <DOM/ISlideCollection.h>
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

// Vytváří instanci třídy Presentation
auto presentation = System::MakeObject<Presentation>();

// Získává první snímek
auto slide = presentation->get_Slides()->idx_get(0);

// Definuje sloupce s šířkami a řádky s výškami
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Přidává tvar tabulky na snímek
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Přistupuje k textovému rámci
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Vytváří objekt Paragraph pro textový rámec
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Vytváří objekt Portion pro odstavec
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Zarovnává text vertikálně
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Ukládá prezentaci na disk
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Nastavit formátování textu na úrovni tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Získejte objekt [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) ze snímku.
4. Nastavte [set_FontHeight()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseportionformat/set_fontheight/) pro text. 
5. Nastavte [set_Alignment()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_alignment/) a [set_MarginRight()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_marginright/) . 
6. Nastavte [set_TextVerticalType()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframeformat/set_textverticaltype/) .
7. Uložte upravenou prezentaci. 

Tento C++ kód ukazuje, jak použít preferované formátovací možnosti na text v tabulce:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Vytváří instanci třídy Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Předpokládejme, že první tvar na prvním snímku je tabulka
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Nastavuje výšku písma buněk tabulky
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Nastavuje zarovnání textu buněk tabulky a pravý okraj v jednom volání
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Nastavuje vertikální typ textu buněk tabulky
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Získat vlastnosti stylu tabulky**

Aspose.Slides vám umožňuje načíst vlastnosti stylu tabulky, abyste je mohli použít pro jinou tabulku nebo jinde. Tento C++ kód ukazuje, jak získat vlastnosti stylu z předdefinovaného stylu tabulky:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Uzamknout poměr stran tabulky**

Poměr stran geometrického tvaru je poměr jeho rozměrů v různých dimenzích. Aspose.Slides poskytuje vlastnost `AspectRatioLocked()` , která vám umožní uzamknout nastavení poměru stran pro tabulky a další tvary. 

Tento C++ kód ukazuje, jak uzamknout poměr stran pro tabulku:

```c++
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Mohu povolit směr čtení zprava doleva (RTL) pro celou tabulku a text v jejích buňkách?**

Ano. Tabulka poskytuje metodu [set_RightToLeft](https://reference.aspose.com/slides/cs/cpp/aspose.slides/table/set_righttoleft/) a odstavce mají [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraphformat/set_righttoleft/) . Použití obou zajišťuje správné pořadí RTL a vykreslení uvnitř buněk.

**Jak mohu zabránit uživatelům v přesunu nebo změně velikosti tabulky v konečném souboru?**

Použijte [shape locks](/slides/cs/cpp/applying-protection-to-presentation/) , abyste zakázali přesun, změnu velikosti, výběr atd. Tyto zámky se vztahují i na tabulky.

**Je podporováno vložení obrázku uvnitř buňky jako pozadí?**

Ano. Můžete nastavit [picture fill](https://reference.aspose.com/slides/cs/cpp/aspose.slides/picturefillformat/) pro buňku; obrázek pokryje oblast buňky podle zvoleného režimu (roztáhnout nebo dláždění).