---
title: Spravujte řádky a sloupce v tabulkách PowerPoint pomocí C++
linktitle: Řádky a sloupce
type: docs
weight: 20
url: /cs/cpp/manage-rows-and-columns/
keywords:
- řádek tabulky
- sloupec tabulky
- první řádek
- záhlaví tabulky
- klonovat řádek
- klonovat sloupec
- kopírovat řádek
- kopírovat sloupec
- odstranit řádek
- odstranit sloupec
- formátování textu řádku
- formátování textu sloupce
- styl tabulky
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Spravujte řádky a sloupce tabulky v PowerPointu pomocí Aspose.Slides pro C++ a urychlete úpravy prezentací a aktualizace dat."
---
## **Úvod**

Aspose.Slides pro C++ vám umožňuje spravovat strukturu tabulky a formátování v prezentacích PowerPoint prostřednictvím třídy [Tabulka](https://reference.aspose.com/slides/cpp/aspose.slides/table/) a rozhraní [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) . Můžete určit řádek záhlaví, klonovat nebo odstraňovat řádky a sloupce a aplikovat formátování textu na celý řádek nebo sloupec.

Tento článek vysvětluje tyto operace pomocí příkladů v C++. Také ukazuje, jak získat přednastavený styl tabulky, abyste jej mohli znovu použít. Indexy řádků a sloupců tabulky jsou nulové.

## **Ovládání výšky řádku**

Použijte [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) k nastavení minimální výšky řádku v bodech. Jedná se o dolní mez, nikoli pevnou výšku. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) vrací skutečnou výšku; tuto hodnotu nelze nastavit přímo. Přístup k řádku získáte přes [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/).

Příklad načte [row-height-input.pptx](row-height-input.pptx), který obsahuje tabulku jako první tvar na první snímku. Její první řádek začíná na 70 bodech. Buňky používají text Arial o velikosti 18 bodů, zalamování a okraje nahoře i dole po 6 bodech; delší text ve druhém sloupci se zalamuje do více řádků. Příklad zvýší minimum na 100 bodů, potom ho sníží na 20 bodů, po každé změně vytiskne skutečnou výšku a uloží oba výsledky.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

V dodané prezentaci zvýšení minima přidá řádku prostor. Jeho snížení tento prostor odstraní, ale skutečná výška zůstává větší než 20 bodů, protože text a okraje buňky vyžadují více místa. Pouhé snížení minima nemůže řádek vtlačit pod prostor potřebný pro jeho obsah.

Několik faktorů ovlivňuje skutečnou výšku:

- **Text a velikost písma:** delší text, explicitní zalomení řádku nebo větší písmo mohou vyžadovat více vertikálního prostoru.
- **Zalamování a šířka sloupce:** při povoleném zalamování může snížení šířky sloupce pomocí [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) vytvořit více řádků. Širší sloupec může snížit požadovaný vertikální prostor.
- **Okraje buňky:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) a [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) řídí okraje, které přidávají vertikální prostor. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) a [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) řídí okraje, které zmenšují šířku dostupnou pro text a mohou způsobit další zalamování.

Pro tuto tabulku bez sloučených buněk určuje buňka, která potřebuje nejvíce vertikálního prostoru, obsahově podmíněný dolní limit pro celý řádek. Pro zkrácení řádku může být také nutné zkrátit text, snížit velikost písma nebo okraje, nebo rozšířit sloupec.

Obrázky níže ukazují stejnou tabulku ve stejném měřítku. V referenčním .NET běhu zobrazeném zde byly skutečné výšky 70, 100 a 55,2 bodu: poslední řádek zůstal vyšší než jeho minimum 20 bodů. Přesná měření textu se mohou lišit podle písem dostupných ve vašem prostředí. Stáhněte si uložené výsledky: [zvýšené minimum](row-height-increased.pptx) a [snížené minimum](row-height-decreased.pptx).

| Původní: minimum 70 pt, skutečná 70 pt | Zvýšené: minimum 100 pt, skutečná 100 pt | Snížené: minimum 20 pt, skutečná 55.2 pt |
| --- | --- | --- |
| ![Původní tabulka s prvním řádkem o 70 bodech.](row-height-before.png) | ![Tabulka po zvýšení minima prvního řádku na 100 bodů.](row-height-increased.png) | ![Tabulka po snížení minima prvního řádku na 20 bodů; zalomený text udržuje řádek vyšší než minimum.](row-height-decreased.png) |

## **Nastavit první řádek jako záhlaví**

Použijte metodu [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) k označení prvního řádku pro formátování záhlaví. Jeho vzhled závisí na stylu tabulky, který je na tabulku aplikován.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte první snímek.
3. Získejte tabulku uloženou jako první tvar na snímku.
4. Povolte formátování záhlaví pro její první řádek.
5. Uložte upravenou prezentaci.

Příklad vyžaduje `table.pptx` s tabulkou jako prvním tvarem na prvním snímku. Povolením formátování záhlaví pro první řádek uloží `First_row_header.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **Klonovat řádek nebo sloupec tabulky**

Klonujte řádky nebo sloupce, abyste znovu použili jejich obsah a formátování. Kopii můžete připojit na konec tabulky nebo vložit na konkrétní pozici.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte první snímek.
3. Definujte šířky sloupců a výšky řádků.
4. Přidejte tabulku pomocí metody [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Klonujte požadované řádky.
6. Klonujte požadované sloupce.
7. Uložte upravenou prezentaci.

Příklad vyžaduje `Test.pptx` s alespoň jedním snímkem. Vytvoří tabulku se třemi sloupci a pěti řádky, s rozměry zadáním v bodech. Přidá kopie prvního řádku a sloupce, poté vloží kopie druhého řádku a sloupce na index 3 (čtvrtá pozice). Výsledná tabulka má sedm řádků a pět sloupců. Argument `false` zakazuje klonování do sousedních sloučených řádků nebo sloupců; tato tabulka nemá sloučené buňky.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Odstranit řádek nebo sloupec z tabulky**

Odstraňte řádky nebo sloupce, které již v tabulce nejsou potřeba. Odstranění položky posune indexy následných řádků nebo sloupců.

1. Vytvořte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte první snímek.
3. Definujte šířky sloupců a výšky řádků.
4. Přidejte tabulku pomocí metody [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Odstraňte druhý řádek a druhý sloupec.
6. Uložte upravenou prezentaci.

Tento příklad vytvoří tabulku 3 × 3 a odstraní řádek a sloupec s indexem 1, čímž vznikne tabulka 2 × 2 v souboru `TestTable_out.pptx`. Rozměry jsou v bodech. Argument `false` zakazuje odstraňování sousedních sloučených řádků nebo sloupců; tato tabulka nemá sloučené buňky.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **Nastavit formátování textu na úrovni řádku tabulky**

Použijte formátování textu na celý řádek, aby buňky byly jednotné. Můžete nastavit vlastnosti písma, formátování odstavců a směr textu, aniž byste formátovali každou buňku zvlášť.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte tabulku na prvním snímku.
3. Nastavte výšku písma pomocí [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) pro první řádek.
4. Nastavte zarovnání a pravý okraj odstavce pomocí [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) a [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) pro první řádek.
5. Nastavte směr textu pomocí [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) pro druhý řádek.
6. Uložte upravenou prezentaci.

Příklad vyžaduje `table.pptx` s tabulkou jako prvním tvarem na prvním snímku a alespoň dvěma řádky. Použije 25‑bodový text, pravé zarovnání a pravý okraj odstavce 20 bodů pro první řádek, poté nastaví vertikální text ve druhém řádku.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **Nastavit formátování textu na úrovni sloupce tabulky**

Použijte formátování textu na celý sloupec, aby buňky byly jednotné. Můžete nastavit vlastnosti písma, formátování odstavců a směr textu, aniž byste formátovali každou buňku zvlášť.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte tabulku na prvním snímku.
3. Nastavte výšku písma pomocí [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) pro první sloupec.
4. Nastavte zarovnání a pravý okraj odstavce pomocí [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) a [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) pro první sloupec.
5. Nastavte směr textu pomocí [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) pro druhý sloupec.
6. Uložte upravenou prezentaci.

Příklad vyžaduje `table.pptx` s tabulkou jako prvním tvarem na prvním snímku a alespoň dvěma sloupci. Použije 25‑bodový text, pravé zarovnání a pravý okraj odstavce 20 bodů pro první sloupec, poté nastaví vertikální text ve druhém sloupci.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **Získat vlastnosti stylu tabulky**

Použijte metodu [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) k získání přednastaveného stylu aplikovaného na tabulku a jeho znovupoužití na jiné tabulce. Identifikuje přednastavení namísto jednotlivých přepsání formátování buněk.

Příklad vytvoří tabulku, použije [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/), a načte zpět přednastavení. Vytiskne `DarkStyle1` a uloží tabulku do `table.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Mohu na již vytvořenou tabulku použít motivy/styly PowerPointu?**

Ano. Tabulka dědí motiv snímku/layoutu/mistra a přesto můžete přepsat výplně, okraje a barvy textu nad tímto motivem.

**Mohu řadit řádky tabulky jako v Excelu?**

Ne, tabulky Aspose.Slides nemají vestavěné řazení ani filtry. Nejprve seřaďte data v paměti a poté znovu naplňte řádky tabulky v tomto pořadí.

**Mohu mít pruhované (proužkované) sloupce a zároveň zachovat vlastní barvy v konkrétních buňkách?**

Ano. Zapněte pruhované sloupce a poté přepište konkrétní buňky lokálním formátováním; formátování na úrovni buňky má přednost před stylem tabulky.