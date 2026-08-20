---
title: C++-ban a prezentáció alakzatainak kezelése
linktitle: Alakzatkezelés
type: docs
weight: 40
url: /hu/cpp/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentáció alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat ID lekérése
- alakzat alternatív szövege
- alakzat elrendezés formátumok
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan azonosíthatja, klónozhatja, eltávolíthatja, elrejtheti, átrendezheti, exportálhatja, igazíthatja és tükrözheti a prezentáció alakzatokat az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

Az Aspose.Slides for C++ a dián lévő alakzatokat rendezett [IShapeCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/) gyűjteményként képviseli. A gyűjtemény egyaránt a hely, ahol megtalálja és módosíthatja az alakzatokat, valamint a rétegzési sorrend forrása: a `0` indexű alakzat a leghátrabb, míg az utolsó index a legelőbbi.

Ez a cikk ezt a modellt követi. Először bemutatja, hogyan lehet egy alakzatot megbízhatóan azonosítani, majd megmutatja, hogyan lehet klónozni, eltávolítani, elrejteni és átrendezni az alakzatokat. Az utolsó szakaszok a layout-szintű formázást, az SVG exportot, az igazítást és a tükrözési beállításokat fedik le. Minden példa önálló, így csak azokat a műveleteket használhatja, amelyekre a munkafolyamatnak szüksége van.

## **Azonosítás és alakzatok keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozása során, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válasszon azonosítót a prezentáció szerkesztési és karbantartási módja alapján:

- [Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_name/) fejlesztő által vezérelt sablonokhoz hasznos, és könnyen ellenőrizhető a PowerPoint Kiválasztás ablaktáblájában. A neveket szerkeszthető, és nem garantált, hogy egyediek, ezért alakítson ki elnevezési konvenciót, ha a kód rá támaszkodik.
- [AlternativeText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_alternativetext/) akkor hasznos, ha egy hozzáférhetőségi leírás vagy a szerző által megadott címke már azonosítja az alakzatot. Felhasználók számára látható, lokalizálható vagy újraírható a hozzáférhetőség érdekében, és nem garantált, hogy egyedi. Ne használja csendben jelentős hozzáférhetőségi szöveget adatbáziskulcsként.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_officeinteropshapeid/) egy csak olvasható azonosító, amely egy dián belül egyedi, és a PowerPoint interop által használt alakzat-azonosítónak felel meg. Használja, ha PowerPointtel integrál, vagy ha egyértelmű hivatkozásra van szükség egy alakzat élettartama alatt. Egy klónozott vagy újra létrehozott alakzat egy másik alakzat, és saját azonosítót kap.

A kapcsolódó [UniqueId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_uniqueid/) tulajdonság prezentációszintű, de kiegészítőkhöz szánták, és újra hozzárendelhető. Nem szabad állandó külső kulcsként kezelni. Ha hosszú távú azonosításra van szükség, tartsa a leképezést alkalmazásadatokban, és ellenőrizze, hogy a várt alakzat még létezik-e.

Az alábbi példa a `Name` alapján keres, és a diára jellemző interop azonosítót jelenti. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt az eredményt jelenti a helytelen objektummal való folytatás helyett.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

Amikor egy művelet alakzat típusa szerint specifikus, ellenőrizze a felületet a típus-specifikus tagok használata előtt. Ez a példa csak akkor frissíti a szöveget és az alternatív szöveget, ha a név alapján hivatkozott objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **Alakzatgyűjtemény módosítása**

A hozzáadás, klónozás, eltávolítás és átrendezés metódusai azonnal a gyűjteményen működnek. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne folytassa a korábban rögzített indexek használatát.

### **Alakzat klónozása**

[AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addclone/) független másolatot hoz létre, és a célgyűjtemény végére fűzi. [InsertClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/insertclone/) szintén másolatot hoz létre, de egy megadott z-sorrend indexbe helyezi. A koordinátákat elfogadó túlterhelések a klónt áthelyezik a méret változtatása nélkül; a szélességet és magasságot megadó túlterhelések átméretezhetik is.

A példa egy céldiat hoz létre, egy címkézett téglalapot klónoz a frontra, majd egy második klónt szúr be a hátra. Bármelyik klón változtatása nem módosítja a forrásalakzatot.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A klónozás másolja az alakzat tartalmát és formázását, beleértve a nevét és az alternatív szöveget is. Ha ezeknek az értékeknek egyedinek kell lenniük, adjon új logikai azonosítókat a klónnak. Az összetett alakzatok által használt erőforrásokat a prezentáció kezeli, de a klón egy új gyűjteményelemként, új alakzat-azonosítóval jelenik meg.

### **Alakzatok eltávolítása**

[Remove](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/remove/) töröl egy konkrét alakzat objektumot a gyűjteményéből. Több egyezés eltávolítása indexelt iteráció során akkor javasolt, ha a végéről haladunk, hogy a fennmaradó indexek érvényben maradjanak.

Ez a példa minden megadott nevű alakzatot eltávolít. Az aktuális indexelt alakzatot olvassa, nem egy fix gyűjteményelemet, és nem kényszeríti a típust feleslegesen.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Eltávolítás után az alakzatszám és a későbbi alakzatok indexei megváltoznak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak a mentett indexeknél. Vegye figyelembe a csatlakozókat, animációkat és egyéb prezentációs funkciókat is, amelyek az eltávolított objektumra hivatkozhatnak; egy látható alakzat eltávolítása több mint a dia megjelenését változtathatja meg.

### **Alakzat elrejtése**

A [Hidden](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/set_hidden/) `true` értékre állítása az alakzatot a gyűjteményben hagyja, de megakadályozza, hogy a normál diavetítésben megjelenjen. Indexe, formázása és tartalma továbbra is elérhető a kód számára, így az elrejtés alkalmas opcionális elemekhez, amelyek később visszaállíthatók.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az elrejtés nem törlés vagy biztonsági intézkedés. Az objektum továbbra is felfedezhető és visszatölthető felhasználó vagy kód által, és része marad a prezentációfájlnak.

### **Z-sorrend módosítása**

Az átfedő alakzatok a gyűjtemény sorrendjében kerülnek lerajzolásra. [Reorder](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/reorder/) egy meglévő alakzatot egy célindexre helyez klónozás nélkül. A `0` index a hátul, a `Count - 1` az elöl.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A téglalap először létrejön, és kezdetben a kör mögött helyezkedik el. A végső indexre mozgatás a frontra helyezi. A z-sorrendet akkor finalizálja, amikor az összes kapcsolódó alakzat hozzáadásra vagy klónozásra került, mivel ezek a műveletek új elemeket adnak hozzá vagy szúrnak be, és megváltoztathatják a kívánt rétegzést.

## **Alakzatok vizsgálata elrendezési diákon**

A normál diák, elrendezési diák és mesterdiák külön alakzatgyűjteménnyel rendelkeznek. Egy elrendezési gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonlóan elhelyezkedő alakzat egy normál dián. Vizsgálja meg az elrendezési alakzatokat, ha a formázást meg kell érteni vagy módosítani, amelyet egy elrendezés biztosít.

Az alábbi példa minden elrendezési alakzat [FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_fillformat/) és [LineFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_lineformat/) tulajdonságát olvassa, anélkül, hogy feltételezné, hogy minden alakzat `AutoShape`.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

Egy elrendezés szerkesztése több diára is hatással lehet, amelyik azt használja. Mielőtt elrendezési alakzatot módosítana, határozza meg, hogy egy normál dia örökli-e az objektumot vagy helyi felülírást tartalmaz-e, és tesztelje az összes diát, amely az elrendezést használja.

## **Alakzat exportálása SVG-be**

[WriteAsSvg](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/writeassvg/) egy alakzat renderelt tartalmát írja egy adatfolyamba. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia hátterét vagy a szomszédos alakzatokat.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

Tartsa nyitva a prezentációt a renderelés közben. A kimenet az alakzat formázásától, valamint a betűkészletek és képek erőforrásaitól függ. Ha a teljes kompozícióra van szükség, exportálja a diát, nem egyetlen alakzatot. A hívó birtokolja az adatfolyamot, és be kell zárnia vagy el kell engednie azt.

## **Alakzatok igazítása**

A [SlideUtil::AlignShapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/alignshapes/) túlterhelései vagy az összes alakzatot, vagy a kiválasztott gyűjteményindexeket igazítják. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapesalignmenttype/) meghatározza az él, a középső vonal vagy az elosztási módot. A `alignToSlide` `true` értéke a dia széleinek használatát jelenti; `false` esetén a kiválasztott alakzatok egymáshoz viszonyított igazítását.

Ez a példa három alakzatot igazít a dia felső éléhez. A visszakapott alakzatreferenciákat az igazítás előtt az aktuális indexeikre konvertálja.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az igazítás a pozíciókat változtatja, nem a z-sorrendet. Relatív igazításhoz általában legalább két alakzat szükséges, míg a vízszintes vagy függőleges elosztáshoz elegendő alakzat kell ahhoz, hogy a távolságot meghatározza. Ha a gyűjteményt a metódus hívása előtt módosítja, számolja újra az indexeket.

## **Alakzat tükrözése**

A [ShapeFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, a vízszintes és függőleges tükrözési beállításokat, valamint a forgatást. A `FlipH` és `FlipV` értékek a [NullableBool](https://reference.aspose.com/slides/hu/cpp/aspose.slides/nullablebool/) típusúak: `True` engedélyezi a tükrözést, `False` letiltja, a `NotDefined` pedig megőrzi a nem definiált/alapértelmezett állapotot.

Az alábbi bemeneti prezentáció egy nem tükrözött alakzatot tartalmaz.

![Az alakzat a tükrözés előtt](shape_to_be_flipped.png)

A példa minden egyéb keretértéket változatlanul hagy, és csak a két tükrözési beállítást cseréli ki. Ez fontos, mert egy új [Frame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/set_frame/) hozzárendelése a teljes keretet felülírja.

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A mentett alakzat vízszintesen és függőlegesen tükröződik, miközben megőrzi a pozíciót, méretet és forgatást.

![Az alakzat a tükrözés után](flipped_shape.png)

## **GYIK**

**Használjak gyűjteményindexet alakzatazonosítóként?**

Csak rövid ideig tartó feldolgozásnál, amikor a gyűjtemény a használat előtt nem változik. Inkrementált `Name` vagy `AlternativeText` konvenciót részesítsen előnyben szerzői sablonok esetén, vagy `OfficeInteropShapeId`-t a diára vonatkozó interop munkához.

**Eltávolítja-e egy alakzat elrejtése a z-sorrendből?**

Nem. A rejtett alakzat a gyűjteményben marad ugyanazon az indexen. Megtalálható, átrendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik alakzat előtt?**

Az `AddClone` a klónt a gyűjtemény végére, azaz a z-sorrend frontjára fűzi. Használja az `InsertClone`-t a kezdeti index kiválasztásához, vagy a `Reorder`-t, miután az összes alakzat hozzá lett adva.