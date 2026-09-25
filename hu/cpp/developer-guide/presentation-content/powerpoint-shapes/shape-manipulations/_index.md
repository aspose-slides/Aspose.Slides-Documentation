---
title: Prezentációs alakzatok kezelése C++-ban
linktitle: Alakzatkezelés
type: docs
weight: 40
url: /hu/cpp/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentációs alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat ID lekérése
- alakzat alternatív szövege
- alakzat korrekciós pontja
- előre definiált alakzatkorrekció
- alakzat geometria
- alakzat elrendezési formátumok
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan azonosítsa, állítsa be, klónozza, távolítsa el, rejtse el, módosítsa a sorrendet, exportálja, igazítsa és tükrözze a prezentációs alakzatokat az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

Az Aspose.Slides for C++ a dián lévő alakzatokat egy rendezett [IShapeCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/) reprezentálja. A gyűjtemény egyaránt a hely, ahol az alakzatokat megtalálja és módosítja, valamint a rétegezés sorrendjének forrása: a `0` indexű alakzat a leghátrébb lévő, míg az utolsó indexű a legelöl lévő.

Ez a cikk ezt a modellt követi. Először bemutatja, hogyan azonosítsunk biztonságosan egy alakzatot és módosítsuk az előre beállított alakzat‑korrekciós pontokat, majd megmutatja, hogyan klónozzunk, távolítsunk el, rejtsünk el és rendezzünk át alakzatokat. Az utolsó szakaszok a layout‑szintű formázást, SVG‑exportálást, igazítást és tükrözési beállításokat fedik le. Minden példa önálló, így csak a munkafolyamatához szükséges műveleteket használhatja.

## **Alakzatok azonosítása és keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozásakor, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válasszon azonosítót attól függően, hogy a prezentációt hogyan szerkesztik és tartják karban:

- [Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_name/) hasznos fejlesztő‑vezérelt sablonoknál, és könnyen ellenőrizhető a PowerPoint **Selection Pane**‑ben. A neveket szerkeszthetőek, és nem garantált a **unique** státuszuk, ezért ha a kód rá támaszkodik, alakíts ki névadási konvenciót.
- [AlternativeText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_alternativetext/) akkor hasznos, ha egy akadálymentesítési leírás vagy a szerző által megadott címke már azonosítja az alakzatot. A felhasználók számára látható, lokalizálható vagy átírható akadálymentesség miatt, és nem garantált egyedi. Ne használja néma módon a jelentős akadálymentesítési szöveget adatbáziskulcsként.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_officeinteropshapeid/) egy csak‑olvasású azonosító, amely egy dián belül egyedi, és a PowerPoint interop által használt alakzat‑azonosítónak felel meg. Használja, ha PowerPointhoz integrál, vagy ha egyértelmű hivatkozásra van szükség egy alakzat élettartama alatt. Egy klónozott vagy újra‑létrehozott alakzat más alakzat, és saját ID‑t kap.

A kapcsolódó [UniqueId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_uniqueid/) tulajdonság prezentáció‑szintű, de kiegészítőkhöz szánták, és újra‑hozzárendelhető. Nem szabad állandó külső kulcsként kezelni. Ha hosszú távú azonosításra van szükség, tárolja a leképezést az alkalmazás adatában, és ellenőrizze, hogy a várt alakzat még létezik‑e.

A [Manage Alternative Text Titles and Descriptions](/slides/hu/cpp/presentation-accessibility/) példában a cím és leírás alternatív szövegének olvasása és frissítése látható. Használja az alternatív szöveget a vizuális tartalom jelentésének elmagyarázására, és tartsa külön a kódban használt alakzatnevektől.

Az alábbi példa a `Name` alapján keres, és a diára jellemző interop ID‑t jeleníti meg. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt jelzi a helytelen objektum használata helyett.

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

Amikor egy művelet alakzat‑típustól függ, ellenőrizze a felületet, mielőtt típus‑specifikus tagokat használna. Ez a példa csak akkor frissíti a szöveget és az alternatív szöveget, ha a névvel jelölt objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) példány.

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

## **Alapértelmezett alakzat‑korrekciók azonosítása és módosítása**

Az előre definiált geometriai alakzatok olyan korrekciós pontokat (adjustment points) biztosíthatnak, amelyek a sarokméretet, nyíl arányokat vagy ív‑szögeket szabályozzák. Ezekhez a csak‑olvasású [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/hu/cpp/aspose.slides/igeometryshape/get_adjustments/) gyűjteményen keresztül férhet hozzá. Magát a gyűjteményt az alakzat biztosítja, de minden [IAdjustValue](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iadjustvalue/) tartalmaz egy módosítható értéket.

Ne csak egy rögzített gyűjtemény‑indexre támaszkodjon. Iteráljon a korrekciókon, és vizsgálja a csak‑olvasású [IAdjustValue::get_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iadjustvalue/get_type/) tulajdonságot, amelynek [ShapeAdjustmentType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapeadjustmenttype/) értéke leírja, mit szabályoz a korrekció. A csak‑olvasású [IAdjustValue::get_Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iadjustvalue/get_name/) további azonosítási információkat ad, és különösen hasznos, ha egy előre definiált alakzat több ugyanazon szemantikai típusú korrekciót tartalmaz.

Használja azt az értéktulajdonságot, amely megfelel a korrekció jelentésének:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | A lekerekített sarkok mérete | [RawValue](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | A nyíl farok vastagsága | `RawValue` |
| `ArrowheadLength` | A nyílhegy hossza | `RawValue` |
| `ArrowheadWidth` | A nyílhegy szélessége | `RawValue` |
| `StartAngle` | A szektor vagy ív kezdő szöge | [AngleValue](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | A szektor vagy ív befejező szöge | `AngleValue` |

A `Type` és `Name` nem állítható. A `RawValue` egy olvas‑/írható egész szám a beállított geometriai egységekben, míg az `AngleValue` fokban kifejezett olvas‑/írható szög. Az értékek száma, sorrendje, jelentése és érvényes tartománya az adott [ShapeType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/igeometryshape/get_shapetype/) alapján változik. Egy megadott presethez megfelelő érték egy másiknál érvénytelen lehet vagy más hatást eredményezhet.

Ha a `Type` értéke `ShapeAdjustmentType::Custom`, az API nem ismeri fel a szabványos szemantikai jelentést. Vizsgálja meg a `Name`‑et, a preset típusát és a meglévő értéket, és csak akkor változtassa meg a korrekciót, ha a jelentés és a tartomány ismert. Még a felismert típusok esetén is ellenőrizze, hogy ugyanaz a típus többször előfordul‑e, mielőtt értéket választana. A [Connector](/slides/hu/cpp/connector/) cikk bemutatja ezt a helyzetet a csatlakozó‑görbületi korrekciókkal.

Az alábbi teljes példa három preset alakzat alap‑ és módosított verzióját hozza létre. Iterál minden korrekción, kiírja a `Name`‑t és `Type`‑t, a méret‑kapcsolódó értékeket a `RawValue`‑val, a szögeket az `AngleValue`‑val módosítja, majd elmenti az eredményt. A bal oszlop a alap‑geometriát mutatja; a jobb oszlop a módosított lekerekített téglalapot, a négysíkú nyilat és a szelet mutatja.

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Fejlécet ad hozzá az alapértelmezett és a módosított alakzat oszlopokhoz.
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A szemantikai típus ellenőrzése érték módosítása előtt egyértelművé teszi a szándékot, és elkerüli, hogy egy adott gyűjtemény‑index ugyanazt a jelentést hordozza különböző preset alakzatoknál.

## **Alakzatgyűjtemény módosítása**

A hozzáadás, klónozás, eltávolítás és átrendezés metódusok azonnal a gyűjteményen dolgoznak. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne támaszkodjon a művelet előtt rögzített indexekre.

### **Alakzat klónozása**

[AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addclone/) egy független másolatot hoz létre, és a célgűjtemény végére fűzi. [InsertClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/insertclone/) szintén másolatot készít, de a megadott z‑order indexen helyezi el. A koordinátákat elfogadó túlterhelések a méretet nem változtatják; a szélesség‑magasságot megadó változatok átméretezhetik a klónt is.

A példa egy cél‑diát hoz létre, a felirattal ellátott téglalapot a frontra klónozza, majd egy második klónt a háttérbe illeszt be. Bármelyik klónt módosító változtatás nem érinti a forrás alakzatot.

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

A klónozás másolja az alakzat tartalmát és formázását, beleértve a nevet és az alternatív szöveget is. Ha ezeknek az értékeknek egyedinek kell lenniük, új logikai azonosítókat kell rendelnünk a klónnak. A komplex alakzatok által használt erőforrásokat a prezentáció kezeli, de a klón egy új gyűjtemény‑elem, új alakzat‑azonosítóval.

### **Alakzatok eltávolítása**

[Remove](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/remove/) egy konkrét alakzat‑objektumot töröl a gyűjteményéből. Több egyező elem eltávolításakor indexelt iteráció során haladjon visszafelé, hogy a fennmaradó indexek érvényben maradjanak.

Ez a példa minden megadott névvel rendelkező alakzatot eltávolít. Az aktuálisan indexelt alakzatot olvassa, nem egy rögzített gyűjtemény‑elemet, és nem kényszeríti a felesleges típuskonverziót.

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

Eltávolítás után a alakzatszám és a későbbi alakzatok indexei megváltoznak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak, mint a korábban mentett indexek. Fontolja meg a csatlakozók, animációk és egyéb prezentációs elemek hatását is, amelyek a törölt objektumra hivatkozhatnak; egy látható alakzat eltávolítása több mint csak a dia megjelenését változtathatja meg.

### **Alakzat elrejtése**

A [Hidden](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/set_hidden/) `true`‑ra állítása megtartja az alakzatot a gyűjteményben, de megakadályozza, hogy a normál diavetítésben megjelenjen. Indexe, formázása és tartalma továbbra is elérhető a kód számára, így az elrejtés alkalmas opcionális elemekre, amelyeket később vissza lehet állítani.

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

Az elrejtés nem törlés vagy biztonsági intézkedés. Az objektum továbbra is felfedezhető és újra láthatóvá tehető felhasználó vagy kód által, és része marad a prezentációs fájlnak.

### **Z‑rend módosítása**

Az átfedő alakzatok a gyűjtemény sorrendjében kerülnek megrajzolásra. A [Reorder](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/reorder/) egy meglévő alakzatot egy cél‑indexre helyez anélkül, hogy klónozná. A `0` index a hátul, a `Count - 1` az elöl.

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

A téglalap először jön létre, és eleinte a ellipszis mögött helyezkedik el. A végső indexre helyezve előrébb kerül. A z‑rendet a kapcsolódó alakzatok hozzáadása vagy klónozása után kell véglegesíteni, mivel ezek a műveletek új gyűjtemény‑elemeket illesztenek be, és módosíthatják a kívánt rétegsorrendet.

## **Layout diákon lévő alakzatok vizsgálata**

A normál diák, layout diák és master diák külön alakzatgyűjteményekkel rendelkeznek. Egy layout gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonló pozícióban lévő alakzat egy normál dián. Layout alakzatokat akkor vizsgálja, ha a layout által biztosított formázást kell megérteni vagy módosítani.

Az alábbi példa minden layout alakzat [FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_fillformat/) és [LineFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_lineformat/) tulajdonságát olvassa, anélkül, hogy feltételezné, minden alakzat `AutoShape`.

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

Egy layout szerkesztése több, azt használó diát is érinthet. Mielőtt módosítana egy layout alakzatot, határozza meg, hogy egy normál dia örökli‑e az objektumot vagy helyi felülírást tartalmaz‑e, és tesztelje az összes diát, amely azt a layoutot használja.

## **Alakzat exportálása SVG‑ként**

A [WriteAsSvg](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/writeassvg/) egy alakzat renderelt tartalmát írja egy streambe. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia háttérét vagy a szomszédos alakzatokat.

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

Tartsa nyitva a prezentációt a renderelés közben. A kimenet az alakzat formázását, valamint a betűtípusok és képekhez tartozó erőforrásokat is figyelembe veszi. Ha az egész kompozícióra van szükség, exportálja a diát, ne egyetlen alakzatot. A hívó birtokolja a streamet, és köteles azt lezárni vagy felszabadítani.

## **Alakzatok igazítása**

A [SlideUtil::AlignShapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/alignshapes/) túlterhelései vagy az összes alakzatot, vagy a kiválasztott gyűjtemény‑indexeket igazítják. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapesalignmenttype/) meghatározza a szél, középvonal vagy elosztási módot. Az `alignToSlide` `true`‑ra állítása a dia széleit használja; `false` esetén a kiválasztott alakzatok egymáshoz viszonyított igazítását végzi.

Ez a példa három alakzatot igazít a dia felső széléhez. A visszakapott alakzat‑referenciákat a igazítás előtt az aktuális indexeikre konvertálja.

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

Az igazítás a pozíciókat, nem a z‑rendet változtatja. Relatív igazításhoz általában legalább két alakzatra van szükség, míg a vízszintes vagy függőleges elosztáshoz elegendő alakzat szükséges a távolság meghatározásához. Ha a metódus meghívása előtt módosítja a gyűjteményt, számolja újra az indexeket.

## **Alakzat tükrözése**

A [ShapeFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, vízszintes‑ és függőleges tükrözési beállításokat, valamint a forgást. A `FlipH` és `FlipV` értékek a [NullableBool](https://reference.aspose.com/slides/hu/cpp/aspose.slides/nullablebool/) típusúak: `True` engedélyezi a tükrözést, `False` letiltja, a `NotDefined` megtartja a nem meghatározott/alapértelmezett állapotot.

Az alábbi bemeneti prezentáció egy nem tükrözött alakzatot tartalmaz.

![The shape before flipping](shape_to_be_flipped.png)

A példa minden egyéb keretértéket megtart, és csak a két tükrözési beállítást cseréli. Ez fontos, mert egy új [Frame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/set_frame/) hozzárendelése a teljes keret cseréjét jelenti.

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

A mentett alakzat vízszintesen és függőlegesen tükröződik, miközben megtartja a pozíciót, méretet és forgást.

![The shape after flipping](flipped_shape.png)

## **GYIK**

**Használjak-e gyűjtemény‑indexet alakzat azonosítóként?**

Csak rövid életű feldolgozás esetén, amikor a gyűjtemény nem változik az index használata előtt. Inkább validált `Name` vagy `AlternativeText` konvenciót alkalmazzon a szerkesztett sablonoknál, vagy `OfficeInteropShapeId`‑t a dia‑szintű interop munkához.

**Eltávolítja‑e egy elrejtett alakzat a z‑rendet?**

Nem. Egy elrejtett alakzat a gyűjteményben marad ugyanazon az indexen. Megtalálható, átrendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg a klónozott alakzat egy másik alakzat előtt?**

Az `AddClone` a klónt a gyűjtemény végére fűzi, ami a z‑rend előre lépését jelenti. Használja az `InsertClone`‑t a kezdeti index kiválasztásához, vagy a `Reorder`‑t az összes alakzat hozzáadása után.

**Használhatok‑e rögzített indexet egy előre definiált alakzatkorrekció azonosításához?**

Csak akkor, ha a pontos presetet és a gyűjtemény‑elrendezést előre validálta. Inkább iteráljon a `IGeometryShape::get_Adjustments`‑on, ellenőrizze a `IAdjustValue::get_Type`‑t; ha ugyanaz a szemantikai típus több alkalommal is előfordul, használja a `IAdjustValue::get_Name`‑t további információként.