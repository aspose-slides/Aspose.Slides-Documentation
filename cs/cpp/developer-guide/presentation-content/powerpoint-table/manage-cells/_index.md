---
title: Správa buněk tabulky v prezentacích pomocí C++
linktitle: Správa buněk
type: docs
weight: 30
url: /cs/cpp/manage-cells/
keywords:
- buňka tabulky
- sloučit buňky
- odstranit okraj
- rozdělit buňku
- obrázek v buňce
- barva pozadí
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Spravujte buňky tabulky PowerPoint v C++: identifikujte sloučené buňky, odstraňujte okraje, rozdělte buňky a nastavte barvy pozadí a obrázky pomocí Aspose.Slides pro C++."
---
## **Přehled**

Aspose.Slides vám umožňuje přistupovat k buňkám tabulky a měnit je v prezentacích PowerPoint. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit okraje buněk, pracovat s číslováním buněk po sloučení nebo rozdělení buněk, změnit barvu pozadí buňky a přidat obrázek uvnitř buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buněk prostřednictvím vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.  
Aspose.Slides používá nulové indexy pro přístup k buňkám tabulky v pořadí `(column, row)`.

## **Identifikace sloučené buňky tabulky**

Příklad otevře existující prezentaci a přistoupí k prvnímu tvaru na první snímku jako k tabulce. Předpokládá, že snímek a tvar existují a že tvar je tabulka. Poté prochází všechny řádky a sloupce a pomocí [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) identifikuje buňky ve sloučených oblastech. Pro každou shodu vypíše souřadnice buňky v pořadí `row;column`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/) a počáteční souřadnice oblasti, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) a [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **Odstranění okrajů buňky tabulky**

Vytvořte objekt [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) a přidejte tabulku na první snímek pomocí [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). Šířky sloupců, výšky řádků a pozice tabulky jsou zadány v bodech. Příklad nastaví všechny čtyři okraje buňky na [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), čímž je učiní neviditelnými.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Sloučení buněk tabulky**

Použijte [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) k sloučení obdélníkového rozsahu buněk tabulky do jedné buňky. Uveďte buňky v levém horním a pravém dolním rohu rozsahu. Poslední argument určuje, zda sloučení může zahrnovat buňky mimo zadaný rozsah; `false` udržuje sloučení uvnitř tohoto rozsahu.

Příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů a následně sloučí čtyři centrální buňky od `(1, 1)` po `(2, 2)`. Výsledná buňka zabírá dva sloupce a dva řádky, zatímco podkladová mřížka tabulky si zachová čtyři sloupce a čtyři řádky. Pro přístup k obsahu nebo formátování sloučené buňky použijte její pozici v levém horním rohu: `table->idx_get(1, 1)` v tomto příkladu. Ostatní pozice ve sloučeném rozsahu zůstávají součástí mřížky tabulky, takže indexy buněk mimo rozsah se nezmění.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **Rozdělení buněk tabulky**

Sloučení buněk v předchozím příkladu zachovává mřížku tabulky. Rozdělení buňky může zavést nový sloupec v mřížce a změnit indexy sloupců buněk vpravo od ní. Aspose.Slides se řídí modelem mřížky tabulky v PowerPointu.

Tento příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů a zavolá [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) na buňku `(1, 1)`. Polovina šířky buňky 70 bodů je předána pro vytvoření dvou buňek stejné šířky.

Po tomto rozdělení jsou dvě poloviny přístupné jako `table->idx_get(1, 1)` a `table->idx_get(2, 1)`. Mřížka tabulky nyní má pět sloupců: buňky původně ve sloupcích 2 a 3 se přesunou do sloupců 3 a 4. Indexy řádků zůstávají beze změny. Používejte tyto aktualizované indexy sloupců při přístupu k buňkám po rozdělení.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

### **Rozdělení sloučených buněk podle řádku nebo sloupce**

Pro přípravu sloučených šablonových buněk na naplnění daty použijte [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) pro rozdělení podél existující řádkové hranice nebo [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) pro rozdělení podél sloupcové hranice.  

`index` argument počítá řádky v horní části nebo sloupce v levé části rozdělení; je relativní k sloučené oblasti:

- Rozdělení řádku: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Rozdělení sloupce: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

Příklad předpokládá, že prezentace má tabulku jako první tvar na první snímku, přičemž buňky `(1, 2)` a `(1, 3)` jsou sloučeny vertikálně. Začínaje od spodní pozice, používá [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) a [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) k nalezení počátku a kontroluje oba rozsahy. `SplitByRowSpan(1)` pak oddělí řádky 2 a 3 pro názvy produktů. Pro horizontální sloučení dvou sloupců použijte místo toho `SplitByColSpan(1)`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // Získejte výsledné buňky z tabulky po rozdělení.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

Mřížka tabulky a okolní indexy buněk zůstávají beze změny. Získejte výsledné buňky podle jejich souřadnic; v tomto případě mají oba rozsahy 1 a [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) vypíše `False`. Větší oblasti mohou po jednom rozdělení zůstat částečně sloučeny.  

Původní text a jeho formátování zůstávají v horní (nebo levé) buňce; nová buňka je prázdná, ale dědí formátování buňky, jako je výplň, okraje a okraje. Po rozdělení buňky naplňte a nastavení požadovaného formátování textu proveďte explicitně.  

Uložená prezentace obsahuje samostatné buňky „Product A“ a „Product B“ s zachovaným formátováním buňky ze šablony. Podrobnosti naleznete v [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/).

## **Změna barvy pozadí buňky tabulky**

Tento příklad vytvoří tabulku se sloupci o šířce 150 bodů a řádky o výšce 50 bodů. Použije [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) k výběru plné výplně a [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) k získání barvy výplně a nastaví ji na červenou pro buňku `(2, 3)`, ve třetím sloupci a čtvrtém řádku.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **Přidání obrázku do buňky tabulky**

Umístěte vstupní obrázek do pracovního adresáře před spuštěním tohoto příkladu. Načte obrázek pomocí [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) a přidá jej do kolekce obrázků prezentace pomocí [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Poté přiřadí obrázek jako výplň obrázku buňky `(0, 0)`, první buňky v tabulce.  

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) roztahuje obrázek tak, aby vyplnil buňku, což může změnit její poměr stran. Šířky sloupců a výšky řádků jsou v bodech. Načtený obrázek je uvolněn po jeho přidání do prezentace.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Mohu nastavit různou tloušťku čar a styly pro různé strany jedné buňky?**

Ano. Okraje [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) mají samostatné vlastnosti, takže tloušťka a styl každé strany se mohou lišit.

**Co se stane s obrázkem, pokud změním velikost sloupce/řádku po nastavení obrázku jako pozadí buňky?**

Chování závisí na [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). Při natažení se obrázek přizpůsobí nové buňce; při dláždění se dlaždice přepočítají.

**Mohu přiřadit hypertextový odkaz k celému obsahu buňky?**

[Hyperlinks](/slides/cs/cpp/manage-hyperlinks/) jsou nastaveny na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/tvaru. V praxi přiřadíte odkaz k části nebo k celému textu v buňce.

**Mohu nastavit různé písma v jedné buňce?**

Ano. Textový rámec buňky podporuje [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (běhy) s nezávislým formátováním – rodinu písma, styl, velikost a barvu.