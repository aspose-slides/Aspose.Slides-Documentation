---
title: "Prezentációs táblázatok kezelése C++-ban"
linktitle: "Táblázat kezelése"
type: docs
weight: 10
url: /hu/cpp/manage-table/
keywords:
- "táblázat hozzáadása"
- "táblázat létrehozása"
- "táblázat elérése"
- "méretarány"
- "szöveg igazítása"
- "szövegformázás"
- "táblázat stílus"
- "PowerPoint"
- "bemutató"
- "C++"
- "Aspose.Slides"
description: "Hozzon létre és szerkesszen táblázatokat PowerPoint diákon az Aspose.Slides for C++ segítségével. Fedezzen fel egyszerű kódrészleteket, amelyek egyszerűsítik a táblázat-kezelési folyamatokat."
---
## **Bevezetés**

A PowerPoint táblázat hatékony módja az információk megjelenítésének és ábrázolásának. A cellák (sorokba és oszlopokba rendezett) rácsában lévő információ egyértelmű és könnyen érthető.

Az Aspose.Slides biztosítja a [Table](https://reference.aspose.com/slides/hu/cpp/aspose.slides/table/) osztályt, az [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) interfészt, a [Cell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/cell/) osztályt, az [ICell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icell/) interfészt és egyéb típusokat, amelyek lehetővé teszik táblázatok létrehozását, frissítését és kezelését a különféle bemutatókban. 

## **Táblázat létrehozása az alapoktól**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezze meg a diát index alapján.  
3. Határozzon meg egy `columnWidth` tömböt.  
4. Határozzon meg egy `rowHeight` tömböt.  
5. Adjon egy [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektumot a diára a [AddTable()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addtable/) metódus segítségével.  
6. Iteráljon minden [ICell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icell/) objektumon, hogy beállítsa a felső, alsó, jobb és bal szegélyek formázását.  
7. Fésülje össze a táblázat első sorának első két celláját.  
8. Érje el egy [ICell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframe/).  
9. Adjon hozzá szöveget a [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframe/).  
10. Mentse el a módosított bemutatót.

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

// Létrehoz egy Presentation osztály példányt, amely egy PPTX fájlt képvisel
auto pres = System::MakeObject<Presentation>();

// Eléri az első diát
auto sld = pres->get_Slides()->idx_get(0);

// Meghatározza az oszlopok szélességét és a sorok magasságát
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Táblázat alakzatot ad hozzá a diára
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Beállítja minden cella szegélyformátumát
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
// Egyesíti az 1. sor 1. és 2. celláját
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Szöveget ad a egyesített cellához
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Mentse a bemutatót a lemezre
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Számozás egy szabványos táblázatban**

Egy szabványos táblázatban a cellák számozása egyszerű és nullától indul. Az első cella indexe 0,0 (oszlop 0, sor 0).

Például egy 4 oszlopos és 4 soros táblázat cellái így vannak számozva:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a C++ kód megmutatja, hogyan adhat meg számozást a táblázat celláihoz:

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

// Létrehoz egy Presentation osztályt, amely egy PPTX fájlt képvisel
auto pres = System::MakeObject<Presentation>();

// Eléri az első diát
auto sld = pres->get_Slides()->idx_get(0);

// Meghatározza az oszlopok szélességét és a sorok magasságát
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Táblázat alakzatot ad hozzá a diához
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Beállítja minden cella szegélyformátumát
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

// Mentse a bemutatót a lemezre
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Meglévő táblázat elérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezze meg annak a diáknak a referenciáját, amelyik a táblázatot tartalmazza, index alapján.  
3. Hozzon létre egy [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektumot, és állítsa null értékre.  
4. Iteráljon az összes [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) objektumon, amíg meg nem találja a táblázatot.  

   Ha úgy gondolja, hogy a kezelt dia csak egy táblázatot tartalmaz, egyszerűen ellenőrizheti az összes benne lévő alakzatot. Ha egy alakzat táblázatként van azonosítva, akkor átkastelheti [Table](https://reference.aspose.com/slides/hu/cpp/aspose.slides/table/) objektummá. Ha azonban a dia több táblázatot tartalmaz, célsőbb a szükséges táblázatot a [set_AlternativeText()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/set_alternativetext/) metódus segítségével keresni.  

5. Használja az [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektumot a táblázattal való munkához. Az alábbi példában egy új sort adtunk hozzá a táblázathoz.  
6. Mentse el a módosított bemutatót.

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

// Létrehoz egy Presentation osztályt, amely egy PPTX fájlt képvisel
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Eléri az első diát
auto sld = pres->get_Slides()->idx_get(0);

// Inicializál null táblát
System::SharedPtr<ITable> tbl;

// Iterál a alakzatokon, és beállítja a megtalált táblázatra mutató hivatkozást
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Beállítja a szöveget a második sor első oszlopában
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Mentse a módosított bemutatót a lemezre
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **A szövegkeretet tartalmazó cella megtalálása**

Amikor általános szövegfeldolgozó kód egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumot kap egy táblázattól, használja az [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_parentcell/) metódust a tulajdonos [ICell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icell/) lekéréséhez. Egy táblázatcella szövegkeret esetén az [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_parentcell/) visszaadja a tulajdonost, míg az [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_parentshape/) `nullptr`-t ad, még akkor is, ha a táblázat maga alakzat.

A cellakoordináták a csak olvasható [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icell/get_firstcolumnindex/) és [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icell/get_firstrowindex/) metódusokkal érhetők el. Az [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_parentcell/) szintén csak-olvasás módú navigációt biztosít: visszaadja a tulajdonost, de nem változtat a tulajdonjogon. Mindig ellenőrizze, hogy a visszakapott cella nem `nullptr`-e, mielőtt használná.

Egy teljes példáért, amely azonosítja a táblázatcella és alakzat tulajdonosait, beleértve a SmartArt csomópontokhoz kapcsolódó alakzatokat, lásd a [Search and Replace Text](/slides/hu/cpp/search-and-replace-text/) oldalt.

## **Szöveg igazítása a táblázatban**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezze meg a diát index alapján.  
3. Adjon egy [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektumot a diához.  
4. Érje el egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumot a táblázatból.  
5. Érje el a [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) elemét.  
6. Igazítsa a szöveget függőlegesen.  
7. Mentse el a módosított bemutatót.

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

// Létrehoz egy Presentation osztály példányt
auto presentation = System::MakeObject<Presentation>();

// Eléri az első diát
auto slide = presentation->get_Slides()->idx_get(0);

// Meghatározza az oszlopok szélességét és a sorok magasságát
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Táblázat alakzatot ad hozzá a diára
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Eléri a szövegkeretet
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Létrehozza a bekezdés objektumot a szövegkerethez
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Létrehozza a rész (Portion) objektumot a bekezdéshez
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Függőlegesen igazítja a szöveget
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Mentse a bemutatót a lemezre
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Szövegformázás beállítása táblázatszinten**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezze meg a diát index alapján.  
3. Érje el egy [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektumot a Diáról.  
4. Állítsa be a szöveg [set_FontHeight()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_fontheight/) értékét.  
5. Állítsa be a [set_Alignment()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_alignment/) és a [set_MarginRight()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginright/) értékeket.  
6. Állítsa be a [set_TextVerticalType()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframeformat/set_textverticaltype/) értéket.  
7. Mentse el a módosított bemutatót. 

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

// Létrehoz egy Presentation osztály példányt
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Tegyük fel, hogy az első dia első alakzata egy táblázat
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Beállítja a táblázat celláinak betűmagasságát
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Beállítja a táblázat celláinak szövegigazítását és jobb margóját egy hívásban
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Beállítja a táblázat celláinak szöveg függőleges típusát
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Táblázat stílus tulajdonságok lekérése**

Aspose.Slides lehetővé teszi, hogy lekérje egy táblázat stílus tulajdonságait, hogy ezeket a részleteket egy másik táblázathoz vagy máshová felhasználhassa. Ez a C++ kód bemutatja, hogyan nyerhetők ki a stílus tulajdonságok egy táblázat előre beállított stílusából:

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

## **Táblázat méretarányának zárolása**

A geometriai alakzat méretarányát a különböző dimenziók méretének aránya határozza meg. Az Aspose.Slides biztosítja az `AspectRatioLocked()` tulajdonságot, amely lehetővé teszi a táblázatok és egyéb alakzatok méretarány beállításának zárolását.

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

## **GYIK**

**Engedélyezhetem a jobbról balra (RTL) írásirányt egy egész táblázatban és annak celláiban lévő szöveghez?**

Igen. A táblázat rendelkezik egy [set_RightToLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/table/set_righttoleft/) metódussal, a bekezdések pedig a [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraphformat/set_righttoleft/) metódust. Mindkettő használata biztosítja a helyes RTL sorrendet és a cellákon belüli megjelenítést.

**Hogyan akadályozhatom meg, hogy a felhasználók mozgatni vagy átméretezni a táblázatot a végleges fájlban?**

Használja a [shape locks](/slides/hu/cpp/applying-protection-to-presentation/) funkciót a mozgatás, átméretezés, kijelölés stb. letiltásához. Ezek a zárolások a táblázatokra is vonatkoznak.

**Támogatott-e egy kép beillesztése egy cellába háttérként?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/hu/cpp/aspose.slides/picturefillformat/) kitöltést a cellához; a kép a választott mód (nyújtás vagy csempézés) szerint a cella területét lefedi.