---
title: Alakzat hatékony tulajdonságainak lekérése a bemutatókban C++-ban
linktitle: Hatékony tulajdonságok
type: docs
weight: 50
url: /hu/cpp/shape-effective-properties/
keywords:
- alakzat tulajdonságai
- kamera tulajdonságok
- light rig
- bevel shape
- szövegdoboz
- szövegstílus
- betűmagasság
- kitöltési formátum
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan használhatja az Aspose.Slides for C++-ot a helyi, örökölt és hatékony alakzat formázásának megkülönböztetésére PowerPoint bemutatókban."
---
## **Helyi, örökölt és hatékony tulajdonságok megértése**

A PowerPoint formázás több helyről származhat. Az objektumon közvetlenül tárolt érték a **helyi érték**. Ha ez az érték nincs beállítva, a PowerPoint a szülő formázási forrásokat vizsgálja, például egy bekezdés alapértelmezését, egy szövegstílust, egy elrendezést vagy minta diát, egy témát vagy a bemutató szintű alapértelmezéseket. Ezek az értékek a **örökölt értékek**. Az az érték, ami a teljes hierarchia feloldása után megmarad, a **hatékony érték**—az objektum megjelenítéséhez használt érték.

Például egy szövegdarab nem definiálhatja a saját betűmagasságát. Ennek a helyi [font height](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/) értéke ekkor `std::numeric_limits<float>::quiet_NaN()`, ami azt jelenti, hogy „itt nincs beállítva”. A darab örökölhet magasságot a bekezdéséből, a bemutató alapértelmezett szövegstílusából vagy egy másik alkalmazható forrásból. A [GetEffective](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformat/) meghívása a darab formátumon visszaadja a végső feloldott magasságot.

Használja a kétféle formázási adatot különböző célokra:

- Olvassa vagy módosítsa a helyi formátumobjektumot, például a [IPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformat/), ha azt szeretné szabályozni, hogy hol van definiálva az érték.
- Olvassa a hatékony adatobjektumot, például a [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformateffectivedata/), ha a végső, megjelenített eredményre van szüksége. A hatékony adatok csak olvashatók.

## **Helyi, örökölt és hatékony értékek összehasonlítása**

Az alábbi teljes példa egy alakzatot hoz létre, és betűmagasságokat alkalmaz a bemutató, a bekezdés és a darab szintjén. Minden lépés kiírja az azon a szinten definiált értékeket és a ugyanarra a szövegdarabra vonatkozó hatékony értéket. Emellett bemutatja, miért kell a hatékony adatot a formázási változások után újra beolvasni.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// Határozza meg az örökölt értékeket két különböző szinten.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // Olvassa be a hatékony adatokat a korábbi módosítások után.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// A darab helyi értéke felülírja mindkét örökölt értéket.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Az örökölt érték módosítása nem felülírja a meglévő helyi értéket.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Törölje a helyi értéket. A darab most újra a bekezdésből örököl.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Törölje a bekezdés értékét. A bemutató alapértelmezése most adja az eredményt.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

E példában a prioritás a darab helyi formázása, majd a bekezdés formázása, végül a bemutató alapértelmezése. Más objektumoknak eltérő öröklődési láncaik lehetnek, de az elv ugyanaz: egy specifikusabb explicit érték nyer, és a [GetEffective](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformat/) visszaadja a végső eredményt.

## **Hatékony szövegtulajdonságok lekérése**

A szövegformázás több objektumra oszlik:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/) megoldja a szövegdoboz tulajdonságait, például a margókat, rögzítést, automatikus illesztést és a függőleges szövegirányt.
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextstyle/) megoldja a bekezdés formázását minden szövegstílus szintre.
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/) megoldja a bekezdés tulajdonságait, mint a igazítás, behúzás és felsorolásjel.
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformat/) megoldja a karaktertulajdonságokat, mint a betűmagasság, betűtípus, szín, félkövér és dőlt.

A következő példához a `text-formatting.pptx` fájlnak legalább egy diája és egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) kell tartalmaznia, amelynek nem üres a szövegdobozja. Az IAutoShape megjelenhet a alakzatsorozat bármely pozíciójában; a kód keres egy megfelelő objektumot és használat előtt ellenőrzi azt.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **Hatékony 3D tulajdonságok lekérése**

[AThreeDFormat::GetEffective](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/) egy [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformateffectivedata/) objektumot ad vissza, amely az összes feloldott 3D beállítást csoportosítja. Ennek a [camera](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icameraeffectivedata/), [light rig](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilightrigeffectivedata/), [top bevel](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapebeveleffectivedata/), és [bottom bevel](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapebeveleffectivedata/) adatainak segítségével megtekinthető a megfelelő hatékony beállítás. Ezeknek a kapcsolódó beállításoknak az egyszerre történő olvasása megkönnyíti a forma végső 3D megjelenésének megértését.

E példához a `shape-3d.pptx` fájlnak az első diáján legalább egy alakzatot kell tartalmaznia. Alkalmazzon 3D kamerát, világítást vagy letörést az alakzatra, ha azt szeretné, hogy a kimenet az alapértelmezetteken kívül értékeket tartalmazzon.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **Hatékony táblázatformázás lekérése**

A táblázatformázás származhat a táblázat stílusából és a teljes táblázatra, egy oszlopra, egy sorra vagy egy egyedi cellára alkalmazott formátumokból. Az explicit kitöltések közötti ütközések esetén a prioritás: cella, sor, oszlop, majd egész táblázat. Egy cella hatékony formátuma a végső formátum, amely a cella rajzolásához használatos.

E példához a `table-formatting.pptx` fájlnak az első diáján legalább egy táblázatot kell tartalmaznia. A táblázatnak legalább egy sort és egy oszlopot kell tartalmaznia. A kód egy [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) keresésével jár el, ahelyett, hogy azt feltételezné, hogy az első alakzat egy táblázat.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

Ha a színt kell lekérdezni, nem csak a kitöltés típusát, először ellenőrizze a hatékony [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifillformateffectivedata/), majd olvassa el a típusra vonatkozó tulajdonságot—például a [SolidFillColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifillformateffectivedata/) egy egyszínes kitöltésnél.

## **Hatékony adatok újraelolvasása változtatások után**

A hatékony adatok leírják a formázási hierarchiát a feloldás pillanatában. Hívja meg a `GetEffective`-et újra, miután megváltoztatott bármit, ami részt vehet ebben a hierarchiában, többek között:

- az objektum helyi formázását;
- bekezdés vagy szövegdoboz alapértelmezéseit;
- egy táblázat stílusát, táblázat, oszlop, sor vagy cella formátumát;
- elrendezés vagy minta dia formázását;
- témaadatokat vagy a bemutató szintű alapértelmezéseket;
- a diára rendelt elrendezést vagy mintát.

Ne tartson meg egy hatékony adatobjektumot állandó pillanatképként. Az Aspose.Slides belsőleg cache-ölhet bizonyos hatékony adatokat, és egy későbbi `GetEffective` hívás frissítheti azokat. Ha az értékeket változtatás előtt és után szeretné összehasonlítani, másolja a szükséges skaláris értékeket—például betűmagasságot, színt, igazítást vagy a letörés szélességét—saját változókba a módosítás előtt.

Egy érték módosításához frissítse a megfelelő helyi formátumobjektumot, majd hívja meg a `GetEffective`-et az eredmény ellenőrzéséhez. A hatékony adatobjektumok maguk csak olvashatók.

## **GYIK**

**Hogyan tudom megállapítani, melyik szint biztosította a hatékony értéket?**

A hatékony adatok csak a végső értéket tartalmazzák, nem annak forrását. Vizsgálja meg a releváns helyi objektumokat a legspecifikusabb szintről kifelé. Szöveg esetén ez lehet a darab, a bekezdés, a szövegdoboz, az elrendezés, a minta, a téma és a bemutató alapértelmezései. A nem definiált értékek, például `std::numeric_limits<float>::quiet_NaN()` vagy `nullptr` azt jelzik, hogy a keresés egy másik szintre folytatódik.

**Mi történik, ha egy szint sem definiálja a tulajdonságot?**

Az Aspose.Slides a megfelelő PowerPoint vagy könyvtári alapértelmezést oldja fel. Ez a feloldott érték megjelenik a hatékony adatokban, még akkor is, ha egy helyi objektum sem definiálta explicit módon.

**Miért egyezik néha a hatékony érték a helyi értékkel?**

A helyi érték nyerte meg az öröklődés számítását. Ez akkor várható, amikor a tulajdonság explicit módon be van állítva az objektumon, és nincs specifikusabb szabály, amely felülírná.

**Mikor érdemes helyi adatot használni a hatékony adat helyett?**

Használja a helyi adatokat egy adott formázási szint megtekintéséhez vagy szerkesztéséhez. Használja a hatékony adatokat, ha a végső megjelenésre van szüksége az öröklődés, a téma szabályok és a releváns stílusok feloldása után. A [complete comparison example](#compare-local-inherited-and-effective-values) mindkettőt bemutatja ugyanabban a munkafolyamatban.