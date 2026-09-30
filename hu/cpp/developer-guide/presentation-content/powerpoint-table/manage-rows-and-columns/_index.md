---
title: Sorok és oszlopok kezelése PowerPoint táblázatokban C++ használatával
linktitle: Sorok és oszlopok
type: docs
weight: 20
url: /hu/cpp/manage-rows-and-columns/
keywords:
- táblázat sor
- táblázat oszlop
- első sor
- táblázat fejléc
- sor klónozása
- oszlop klónozása
- sor másolása
- oszlop másolása
- sor eltávolítása
- oszlop eltávolítása
- sor szövegformázás
- oszlop szövegformázás
- táblázat stílus
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Kezelete a táblázat sorait és oszlopait PowerPoint-ban az Aspose.Slides for C++ segítségével, és felgyorsítja a prezentáció szerkesztését és az adatok frissítését."
---
## **Bevezetés**

Az Aspose.Slides for C++ lehetővé teszi, hogy a PowerPoint‑prezentációk táblázat‑szerkezetét és formázását a [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) osztály és az [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) interfész segítségével kezelje. Megjelölhet egy fejlécsorát, klónozhat vagy eltávolíthat sorokat és oszlopokat, valamint szövegformázást alkalmazhat egy teljes sorra vagy oszlopra.

Ez a cikk elmagyarázza ezeket a műveleteket C++ példákkal. Továbbá bemutatja, hogyan lehet lekérni egy táblázat stílus‑előbeállítását, hogy újból felhasználhassa. A táblázat sor‑ és oszlopindexei 0‑bázisúak.

## **Sormagasság vezérlése**

Használja az [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) metódust a sor minimális magasságának pontban való beállításához. Ez egy alsó határ, nem fix magasság. Az [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) visszaadja a tényleges magasságot; ezt az értéket nem lehet közvetlenül beállítani. A sor eléréséhez használja az [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/) metódust.

Az példa betölti a [row-height-input.pptx](row-height-input.pptx) fájlt, amelyben a táblázat az első dián az első alakzatként szerepel. Az első sor 70 pontnál kezdődik. A cellák 18 pontos Arial szöveget, sortörést és 6 pontos felső és alsó margót használnak; a második oszlopban a hosszabb szöveg több sorra törik. A példa a minimumot 100 pontra növeli, majd 20 pontra csökkenti, minden módosítás után kiírja a tényleges magasságot, és elmenti mindkét eredményt.

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

A mellékelt prezentációval a minimum növelése helyet ad a sornak. A csökkentés eltávolítja ezt a felesleges helyet, de a tényleges magasság továbbra is nagyobb, mint 20 pont, mivel a szöveg és a cellamargók több helyet igényelnek. A minimum önmagában csökkentése nem képes a sort a tartalom által igényelt hely alá kényszeríteni.

Több tényező befolyásolja a tényleges magasságot:

- **Szöveg és betűméret:** a hosszabb szöveg, a kifejezett sortörések vagy a nagyobb betűméret több függőleges helyet igényelhet.
- **Sortörés és oszlopszélesség:** a sortörés engedélyezése esetén az oszlopszélesség csökkentése az [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) metódussal több sort eredményezhet. Egy szélesebb oszlop csökkentheti a függőleges helyigényt.
- **Cellamargók:** az [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) és az [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) szabályozzák a függőleges helyet növelő margókat. Az [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) és az [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) a szöveg számára elérhető szélességet csökkentő margókat szabályozzák, és további sortörést okozhatnak.

Egy, egyesített cellákat nem tartalmazó táblázatnál az a cella, amelyik a legtöbb függőleges helyet igényli, meghatározza a sor egészének tartalom‑alapú alsó határát. A sor rövidebbé tételéhez esetleg rövidíteni kell a szöveget, csökkenteni a betűméretet vagy a margókat, vagy szélesíteni egy oszlopot.

Az alábbi képek ugyanazt a táblázatot ugyanabban a méretezésben mutatják. A bemutatott .NET futtatásban a tényleges magasságok 70, 100 és 55,2 pont voltak: az utolsó sor továbbra is magasabb maradt, mint a 20 pontos minimum. A pontos szövegméretezés a környezetben elérhető betűtípusoktól függően változhat. Töltse le a mentett eredményeket: [növelt minimum](row-height-increased.pptx) és [csökkentett minimum](row-height-decreased.pptx).

| Eredeti: minimum 70 pt, tényleges 70 pt | Növelt: minimum 100 pt, tényleges 100 pt | Csökkentett: minimum 20 pt, tényleges 55.2 pt |
| --- | --- | --- |
| ![Eredeti táblázat 70 pontos első sorral.](row-height-before.png) | ![Táblázat az első sor minimum 100 pontra növelése után.](row-height-increased.png) | ![Táblázat az első sor minimum 20 pontra csökkentése után; a sortörött szöveg a sort magasabbá teszi a minimumnál.](row-height-decreased.png) |

## **Az első sor beállítása fejlécként**

Használja a [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) metódust az első sor fejlécre formázásra való megjelöléséhez. A megjelenése a táblázatra alkalmazott táblastílustól függ.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztállyal.
2. Szerezze meg az első diát.
3. Szerezze meg a táblázatot, amely az első alakzatként van tárolva a dián.
4. Engedélyezze a fejlécformázást az első sorra.
5. Mentse el a módosított prezentációt.

A példához `table.pptx` fájl szükséges, amelyben a táblázat az első dián az első alakzatként szerepel. Engedélyezi a fejlécformázást az első sorra, és elmenti a `First_row_header.pptx` fájlt.

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

## **Táblázatsor vagy oszlop klónozása**

Klónozzon sorokat vagy oszlopokat a tartalmuk és formázásuk újbóli felhasználásához. A másolatot hozzáfűzheti a táblázat végéhez vagy beszúrhatja egy adott pozícióba.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztállyal.
2. Szerezze meg az első diát.
3. Határozza meg az oszlopok szélességét és a sorok magasságát.
4. Adjon hozzá egy táblázatot a [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) metódussal.
5. Klónozza a szükséges sorokat.
6. Klónozza a szükséges oszlopokat.
7. Mentse el a módosított prezentációt.

A példához `Test.pptx` fájl szükséges, amely legalább egy diát tartalmaz. Létrehoz egy három oszlopos és öt soros táblázatot, a méreteket pontban megadva. Hozzáfűzi az első sor és oszlop másolatait, majd a második sor és oszlop másolatait a 3‑as indexnél (a negyedik pozíció) szúrja be. Az eredményül kapott táblázat hét sorral és öt oszloppal rendelkezik. A `false` argumentum letiltja a klónozást a szomszédos egyesített sorokba vagy oszlopokba; ez a táblázat nem tartalmaz egyesített cellákat.

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

## **Sor vagy oszlop eltávolítása a táblázatból**

Távolítsa el a táblázatban már nem szükséges sorokat vagy oszlopokat. Egy elem eltávolítása eltolja a mögötte lévő sorok vagy oszlopok indexeit.

1. Hozzon létre egy prezentációt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztállyal.
2. Szerezze meg az első diát.
3. Határozza meg az oszlopok szélességét és a sorok magasságát.
4. Adjon hozzá egy táblázatot a [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) metódussal.
5. Távolítsa el a második sort és a második oszlopot.
6. Mentse el a módosított prezentációt.

Ez a példa egy három‑háromas táblázatot hoz létre, és az 1‑es indexű sort és oszlopot eltávolítja, így egy két‑kétas táblázat marad a `TestTable_out.pptx` fájlban. A méretek pontban vannak. A `false` argumentum letiltja a szomszédos egyesített sorok vagy oszlopok eltávolítását; ez a táblázat nem tartalmaz egyesített cellákat.

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

## **Szövegformázás beállítása a táblázat sor szintjén**

Alkalmazzon szövegformázást egy teljes sorra, hogy a cellák egységesek legyenek. Beállíthatja a betűtulajdonságokat, bekezdésformázást és a szövegirányt anélkül, hogy egyesével formázná a cellákat.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztállyal.
2. Szerezze meg a táblázatot az első dián.
3. Állítsa be a betűmagasságot a [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) metódussal az első sorra.
4. Állítsa be az igazítást és a jobb bekezdésmargót a [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) és a [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) metódusokkal az első sorra.
5. Állítsa be a szövegirányt a [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) metódussal a második sorra.
6. Mentse el a módosított prezentációt.

A példához `table.pptx` fájl szükséges, amelyben a táblázat az első dián az első alakzatként szerepel, és legalább két sor van. 25 pontos szöveget, jobb igazítást és 20 pontos jobb bekezdésmargót alkalmaz az első sorra, majd a második sorra függőleges szöveget állít be.

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

## **Szövegformázás beállítása a táblázat oszlop szintjén**

Alkalmazzon szövegformázást egy teljes oszlopra, hogy a cellák egységesek legyenek. Beállíthatja a betűtulajdonságokat, bekezdésformázást és a szövegirányt anélkül, hogy egyesével formázná a cellákat.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztállyal.
2. Szerezze meg a táblázatot az első dián.
3. Állítsa be a betűmagasságot a [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) metódussal az első oszlopra.
4. Állítsa be az igazítást és a jobb bekezdésmargót a [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) és a [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) metódusokkal az első oszlopra.
5. Állítsa be a szövegirányt a [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) metódussal a második oszlopra.
6. Mentse el a módosított prezentációt.

A példához `table.pptx` fájl szükséges, amelyben a táblázat az első dián az első alakzatként szerepel, és legalább két oszlop van. 25 pontos szöveget, jobb igazítást és 20 pontos jobb bekezdésmargót alkalmaz az első oszlopra, majd a második oszlopra függőleges szöveget állít be.

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

## **Táblázat stílusjellemzőinek lekérése**

Használja a [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) metódust egy táblázatra alkalmazott előbeállítás lekéréséhez és annak egy másik táblázaton való újrahasználatához. Ez az előbeállítást azonosítja, nem pedig az egyedi cellaformázási felülírásokat.

A példa létrehoz egy táblázatot, alkalmazza a [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) előbeállítást, és visszaolvassa azt. Kiírja a `DarkStyle1` értéket, és elmenti a táblázatot a `table.pptx` fájlba.

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

## **GYIK**

**Alkalmazhatok PowerPoint témákat/stílusokat egy már létrehozott táblázatra?**

Igen. A táblázat örökli a dia/oldal/mester téma beállításait, és továbbra is felülírhatja a kitöltéseket, szegélyeket és szövegszíneket a téma fölött.

**Rendezhetem a táblázatsorokat úgy, mint az Excelben?**

Nem, az Aspose.Slides táblázatok nem rendelkeznek beépített rendezéssel vagy szűrőkkel. Először rendezze az adatokat a memóriában, majd töltse újra a táblázatsorokat ebben a sorrendben.

**Lehetnek csíkos (sávos) oszlopok, miközben egyedi színeket tartok meg bizonyos cellákban?**

Igen. Kapcsolja be a csíkos oszlopokat, majd felülírja a specifikus cellákat helyi formázással; a cellaszintű formázás előnyben részesül a táblastílus felett.