---
title: Prezentációs táblázatok kezelése C++-ban
linktitle: Táblázat kezelése
type: docs
weight: 10
url: /hu/cpp/manage-table/
keywords:
- táblázat hozzáadása
- tábla létrehozása
- tábla elérése
- méretarány
- szöveg igazítása
- szövegformázás
- tábla stílus
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Táblázatok létrehozása és szerkesztése PowerPoint diáknál az Aspose.Slides C++-hoz. Fedezze fel az egyszerű kódrészleteket, amelyek egyszerűsítik a táblázatok munkafolyamatait."
---
## **Bevezetés**

A PowerPoint táblázatai sorokba és oszlopokba rendezik az információkat, megkönnyítve az értékek olvasását és összehasonlítását.

Az Aspose.Slides biztosítja a [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) osztályt, a [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) interfészt, a [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) osztályt, a [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) interfészt és egyéb típusokat, amelyek lehetővé teszik táblázatok létrehozását, frissítését és kezelését a prezentációkban.

## **Táblázat létrehozása semmiből**

Hozzon létre egy táblázatot a pozíció, az oszlopszélességek és a sormagasságok megadásával. A diához való hozzáadás után formázhatja a cellahatárokat, egyesítheti a cellákat, és szöveget illeszthet be.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezzen referenciát a diára az indexe alapján.  
3. Határozzon meg egy tömböt, amely pontban kifejezett oszlopszélességeket tartalmaz.  
4. Határozzon meg egy tömböt, amely pontban kifejezett sormagasságokat tartalmaz.  
5. Adjon egy [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) objektumot a diára a [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) metóduson keresztül.  
6. Iteráljon minden [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) objektumon, hogy formázza a felső, alsó, jobb és bal határokat.  
7. Egyesítse a táblázat első sorának első két celláját.  
8. Hozza el az egyesített cellát a [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) metódusával.  
9. Állítsa be a szöveget az egyesített cellában.  
10. Mentse el a módosított prezentációt.

Az alábbi példa egy három oszlopos és öt soros táblázatot hoz létre (100, 50) pontban. Piros szegélyeket alkalmaz 5 pont szélességgel, egyesíti az első sor első két celláját, és a végeredményt `table.pptx` néven menti.

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

## **Számozás egy szabványos táblázatban**

Egy szabványos táblázatban a cellaindexek nullától indulnak, és (oszlop, sor) sorrendet követnek. Az első cella indexe (0, 0).

Például a 4 oszlopos és 4 soros táblázat celláit így számozzák:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a példa létrehozza a fent ábrázolt 4 × 4‑es táblázatot, ahol az oszlopszélességek és sormagasságok 70 pontot tesznek ki, és a cellák piros szegélye 5 pont széles. A koordináták a cellaindexeket mutatják; a példa üresen hagyja a cellákat, és a táblázatot `StandardTables_out.pptx` néven menti.

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

## **Meglévő táblázat elérése**

A táblázatok a diák alakzatgyűjteményében tárolódnak. Iteráljon az alakzatokon, hogy megtalálja a táblázatot, majd használja az [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) interfészt a cellák olvasásához vagy frissítéséhez.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztály segítségével.  
2. Szerezzen referenciát a táblázatot tartalmazó diára az indexe alapján.  
3. Iteráljon a [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) objektumokon, és álljon meg, amikor táblázatot talál. Ha a dián több táblázat van, használja a [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) metódust a szükséges azonosításához.  
4. Frissítse a szöveget a célcellában.  
5. Mentse el a módosított prezentációt.

Az alábbi példa megnyitja az `UpdateExistingTable.pptx` fájlt, és megtalálja az első táblázatot az első dián. A 0. oszlop, 1. sor celláját `New` értékre állítja, és a végeredményt `table1_out.pptx` néven menti. A bemenetnek legalább egy diát kell tartalmaznia, és az első táblázatnak legalább egy oszloppal és két sorral kell rendelkeznie.

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

Egy meglévő táblázat sorának átméretezéséhez, és ahhoz, hogy megértse, miért lehet a tényleges magasság a kért minimumot meghaladó, tekintse meg a [Sor magasságának vezérlése](/slides/hu/cpp/manage-rows-and-columns/#control-row-height) oldalt.

## **A szövegdobozot tartalmazó cella megtalálása**

Amikor általános szövegfeldolgozó kód egy táblázatból kap egy [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) objektumot, használja a [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) metódust a tulajdonos [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) lekéréséhez. Egy táblázatcella szövegdoboz esetén a [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) visszaadja a tulajdonost, és a [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) `nullptr` értéket ad, bár maga a táblázat is egy alakzat.

A cellakoordináták a csak olvasható [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) és [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) metódusokon keresztül érhetők el. A [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) szintén csak olvasható navigációt biztosít: visszaadja a tulajdonost, de nem módosítja a tulajdonjogot. Mindig ellenőrizze, hogy a visszakapott cella `nullptr`‑e, mielőtt használná.

A táblázatcella és alakzat tulajdonosok azonosítását bemutató teljes példáért, beleértve a SmartArt csomópontokhoz kapcsolódó alakzatokat, tekintse meg a [Szöveg keresése és cseréje](/slides/hu/cpp/search-and-replace-text/).

## **Szöveg igazítása egy táblázatban**

Egyes táblázatcellák vertikális rögzítését és szövegirányát vezérelheti. Ennek a szakasznak a példája középre helyezi a szöveget az első cellában, és 270 fokkal elforgatja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezzen referenciát a diára az indexe alapján.  
3. Adjon egy [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) objektumot a diára.  
4. Hozza el a táblázatból egy [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) objektumot.  
5. Hozza el az első [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) objektumot, és állítsa be a szövegét és színét.  
6. Állítsa be a cella vertikális rögzítését és szövegirányát a [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) és a [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/) segítségével.  
7. Mentse el a módosított prezentációt.

Ez a példa egy 4 × 4‑es táblázatot hoz létre, ahol az oszlopszélességek 120 pont, a sormagasságok 100 pont. Formázza a (0, 0) cella szövegét, értékeket ad a maradék első sorbeli cellákhoz, és a végeredményt `Vertical_Align_Text_out.pptx` néven menti.

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

## **Szövegformázás beállítása táblázatszinten**

Használja a [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) módszert a szövegformázás alkalmazásához a táblázat összes cellájára. A túlterhelései tartománnyal, bekezdéssel és szövegdoboz formázással dolgoznak, így ezeket a tulajdonságokat anélkül állíthatja be, hogy egyes cellákon iterálna.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztály segítségével.  
2. Szerezzen referenciát a diára az indexe alapján.  
3. Hozza el a diárról egy [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) objektumot.  
4. Állítsa be a betűméretet a [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) segítségével a szöveghez.  
5. Állítsa be a bekezdés igazítását és a jobb margót a [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) és a [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) segítségével.  
6. Állítsa be a szöveg irányát a [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) használatával.  
7. Mentse el a módosított prezentációt.

Az alábbi példa megnyitja a `table.pptx` fájlt, amelynek legalább egy diája van, és abban a táblázat az első alakzat. A betűméretet 25 pontra állítja, a bekezdéseket jobbra igazítja 20 pontos jobb margóval, és a szöveget függőlegessé teszi. A formázott prezentáció `result.pptx` néven kerül mentésre.

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

## **Táblázat stílus tulajdonságainak lekérése**

Használja a [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) metódust a táblázat előre beállított stílusának olvasásához, és a [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) metódust a hozzárendeléshez. Ez a példa a [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) előre beállítást alkalmaz egy táblázatra, kiírja az előre beállítás nevét, és ugyanazt az előre beállítást a második táblázatra is alkalmazza. Mindkét táblázat `table-style.pptx` néven kerül mentésre.

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

## **Táblázat méretarányának zárolása**

A táblázat méretaránya a szélesség és magasság aránya. Használja a [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) metódust a méretarány zárolásához egy táblázatra.

Az alábbi példa megnyitja a `pres.pptx` fájlt, amelynek legalább egy diája van, és abban a táblázat az első alakzat. Kiírja a jelenlegi zárolási állapotot, engedélyezi a méretarány‑zárolást, kiírja a frissített állapotot (`True`), és a végeredményt `pres-out.pptx` néven menti.

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

**Engedélyezhetem a jobb‑balra (RTL) olvasási irányt egy teljes táblázat és annak celláiban lévő szöveg számára?**

Igen. A táblázat rendelkezik egy [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) metódussal, és a bekezdéseknek is van [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/) metódusa. Mindkettő használata biztosítja a megfelelő RTL sorrendet és megjelenítést a cellákon belül.

**Hogyan akadályozhatom meg, hogy a felhasználók mozgatni vagy átméretezni a táblázatot a végleges fájlban?**

Használja az [alakzatzárolásokat](/slides/hu/cpp/applying-protection-to-presentation/) a mozgatás, átméretezés, kiválasztás stb. letiltásához. Ezek a zárolások a táblázatokra is érvényesek.

**Támogatott‑e egy kép beillesztése egy cellába háttérként?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) kitöltést egy cellához; a kép a kiválasztott mód (nyújtás vagy csempézés) szerint lefedi a cellaterületet.