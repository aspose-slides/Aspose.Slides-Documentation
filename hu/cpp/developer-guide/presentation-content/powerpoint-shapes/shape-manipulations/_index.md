---
title: Prezentáció alakzatok kezelése C++-ban
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
- alakzat igazítási pont
- előre beállított alakzat igazítás
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
description: "Ismerje meg, hogyan azonosíthatja, módosíthatja, klónozhatja, eltávolíthatja, elrejtheti, átrendezheti, exportálhatja, igazíthatja és tükrözheti a prezentáció alakzatait az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

Az Aspose.Slides for C++ a dián lévő alakzatokat egy rendezett [IShapeCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/) segítségével ábrázolja. A gyűjtemény egyszerre a hely, ahol az alakzatokat megtalálja és módosíthatja, és a rétegezési sorrend forrása: a `0` index a leghátsó alakzatot jelöli, míg az utolsó index a legelöl lévő alakzatot.

Ez a cikk ezt a modellt követi. Először bemutatja, hogyan azonosíthat egy alakzatot megbízhatóan és módosíthatja az előre beállított alakzategyesztési pontokat, majd megmutatja, hogyan klónozhat, távolíthat el, rejthet el és módosíthatja az alakzatok sorrendjét. Az utolsó szakaszok a elrendezés‑szintű formázást, SVG‑exportot, igazítást és tükrözési beállításokat fedik le. Minden példa önálló, így csak azokat a műveleteket használhatja, amelyekre a munkafolyamatának szüksége van.

## **Az alakzatok azonosítása és keresése**

A gyűjtemény indexei kényelmesek, ha egy ismert fájlt dolgoz fel, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válasszon azonosítót a prezentáció szerkesztési és karbantartási módja szerint:

- **[Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_name/)** hasznos a fejlesztő által vezérelt sablonok esetén, és könnyen megtekinthető a PowerPoint **Selection Pane**‑ben. A neveket szerkeszthető, és nem garantált, hogy egyediek, ezért vezessen be névkonvenciót, ha a kód ezekre támaszkodik.
- **[AlternativeText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_alternativetext/)** akkor hasznos, ha egy hozzáférhetőségi leírás vagy szerző által megadott címke már azonosítja az alakzatot. A felhasználók számára látható, lokalizálható vagy hozzáférhetőség‑célra átírható, de nem garantált, hogy egyedi. Ne használja csendben a jelentős hozzáférhetőségi szöveget adatbáziskulcsként.
- **[OfficeInteropShapeId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_officeinteropshapeid/)** egy csak‑olvasású azonosító, amely egy dián belül egyedi, és a PowerPoint interop által használt alakzat‑azonosítónak felel meg. Használja, ha PowerPoint‑integrációt valósít meg, vagy ha a forma élettartama során egyértelmű hivatkozásra van szüksége. Egy klónozott vagy újra‑létrehozott alakzat egy másik alakzat, és saját ID‑t kap.

A kapcsolódó **[UniqueId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_uniqueid/)** tulajdonság prezentáció‑szintű, de kiegészítőknek szánt, és újra‑hozzárendelhető. Nem szabad állandó külső kulcsként kezelni. Ha hosszú távú azonosításra van szükség, tárolja a leképezést az alkalmazás adataiban, és ellenőrizze, hogy a várt alakzat még létezik‑e.

Az alábbi példa a **Name** alapján keres, és a dián‑szintű interop ID‑t jelzi. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt az eredményt jelenti ahelyett, hogy a helytelen objektummal folytatná a műveletet.

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

Amikor egy művelet egy adott alakzattípusra vonatkozik, ellenőrizze a felületet, mielőtt típus‑specifikus tagokat használna. Ez a példa csak akkor frissíti a szöveget és az alternatív szöveget, ha a nevű objektum egy **[IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/)**.

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

## **Az előre beállított alakzat‑igazítások azonosítása és módosítása**

Az előre definiált geometriai alakzatok olyan igazítási pontokat fedhetnek fel, amelyek a sarokméretet, nyíl arányait vagy ívhöket szabályozzák. Ezekhez a csak‑olvasású **[IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/hu/cpp/aspose.slides/igeometryshape/get_adjustments/)** gyűjteményen keresztül férhet hozzá. A gyűjteményt maga az alakzat biztosítja, de minden **[IAdjustValue](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iadjustvalue/)** tartalmaz egy változtatható értéket.

Ne csak egy rögzített gyűjtemény‑indexre támaszkodjon. Iteráljon végig az igazításokon, és vizsgálja meg a csak‑olvasású **[IAdjustValue::get_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iadjustvalue/get_type/)** tulajdonságot, amelynek **[ShapeAdjustmentType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapeadjustmenttype/)** értéke leírja, mit szabályoz az igazítás. A csak‑olvasású **[IAdjustValue::get_Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iadjustvalue/get_name/)** további azonosításhoz nyújt információt, és különösen hasznos, ha egy előre beállítás több azonos szemantikai típusú igazítást tartalmaz.

Használja a jelentésnek megfelelő értéktulajdonságot:

| Igazítás típusa | Cél | Módosítandó érték |
|---|---|---|
| `CornerSize` | Kerekített sarkok mérete | [RawValue](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Nyílfarok vastagsága | `RawValue` |
| `ArrowheadLength` | Nyílhegy hossza | `RawValue` |
| `ArrowheadWidth` | Nyílhegy szélessége | `RawValue` |
| `StartAngle` | Körív vagy ív kezdőszöge | [AngleValue](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Körív vagy ív végszöge | `AngleValue` |

A `Type` és `Name` értékek nem módosíthatók. A `RawValue` egy csak‑olvasás/írás egész szám a beállítás natív geometriai egységeiben, míg az `AngleValue` egy csak‑olvasás/írás fokban megadott szög. Az igazítások száma, sorrendje, jelentése és érvényes tartománya a konkrét **[ShapeType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/igeometryshape/get_shapetype/)**‑től függ. Egy bizonyos előre beállításban érvényes érték egy másiknál érvénytelen vagy más hatást válthat ki.

Ha a `Type` **ShapeAdjustmentType::Custom**, az API nem ismeri fel a szabványos szemantikai jelentést. Vizsgálja meg a `Name`‑et, a beállítás típusát és a meglévő értéket, és csak akkor változtassa meg, ha a várt jelentés és tartomány ismert. Még a felismert típusok esetén is ellenőrizze, hogy ugyanaz a típus többször is előfordul‑e, mielőtt értéket választana. A **[Connector](/slides/hu/cpp/connector/)** cikk bemutatja ezt a helyzetet a csatlakozó‑görbületi igazításoknál.

Az alábbi teljes példa létrehozza egy alap‑ és egy módosított változatát három előre beállított alakzatnak. Végigiterál minden igazításon, kiírja a `Name` és `Type` értékeket, a mérettel kapcsolatos értékeket a `RawValue`‑val, a szögeket az `AngleValue`‑val módosítja, és menti az eredményt. A bal oszlop az alap geometriai adatot tartja; a jobb oszlop a módosított lekerekített téglalapot, a négy irányú nyilat és a körívet mutatja.

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

// Fejléc hozzáadása az alap és a módosított alakzatoszlopokhoz.
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

Az érték módosítása előtt a szemantikai típus ellenőrzése egyértelművé teszi a kód szándékát, és elkerüli, hogy egy adott gyűjtemény‑index különböző előre beállított alakzatoknál más jelentéssel bírjon.

## **Az alakzatgyűjtemény módosítása**

A hozzáadás, klónozás, eltávolítás és átrendezés metódusok azonnal a gyűjteményen hatnak. Ha egy művelet módosítja az alakzatok számát vagy sorrendjét, ne támaszkodjon tovább a művelet előtt rögzített indexekre.

### **Alakzat klónozása**

**[AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addclone/)** egy független másolatot hoz létre, és a célgyűjtemény végére fűzi. **[InsertClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/insertclone/)** szintén másolatot készít, de a megadott z‑rendezési indexre helyezi. Az olyan túlterhelések, amelyek koordinátákat fogadnak, a méretet változtatás nélkül mozgatják a klónt; a szélességet és magasságot megadók pedig átméretezhetik.

A példa egy cél‑diát hoz létre, egy címkézett téglalapot klónoz a frontra, és egy második klónt szúr be a hátulra. Az egyik vagy másik klónon végzett módosítás nem befolyásolja a forrás‑alakzatot.

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

A klónozás a forma tartalmát és formázását, köztük a nevét és az alternatív szöveget is másolja. Ha ezeknek az értékeknek egyedinek kell lenniük, új logikai azonosítót kell adni a klónnak. Az összetett alakzatok által használt erőforrások a prezentáció által kerülnek kezelésre, de egy klón új gyűjteményelem, új alakzat‑azonosítóval.

### **Alakzatok eltávolítása**

**[Remove](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/remove/)** egy konkrét alakzat‑objektumot töröl a saját gyűjteményéből. Több egyező elem eltávolítása során indexelt iterációkor haladjon a vég felől, hogy a maradó indexek érvényben maradjanak.

Ez a példa minden, meghatározott névvel rendelkező alakzatot eltávolít. A jelenlegi indexelt alakzatot olvassa, nem egy rögzített gyűjtemény‑elemet, és nem kényszeríti a típust feleslegesen.

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

Eltávolítás után a alakzatok száma és a későbbi elemek indexei változnak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak, mint a tárolt indexek. Vegye figyelembe a csatlakozókat, animációkat és egyéb prezentációs elemeket, amelyek az eltávolított objektumra hivatkozhatnak; egy látható alakzat eltávolítása több mint a dia megjelenését is megváltoztathatja.

### **Alakzat elrejtése**

A **[Hidden](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/set_hidden/)** értékének `true`‑ra állítása megtartja az alakzatot a gyűjteményben, de megakadályozza, hogy a normál diavetítésben megjelenjen. Az indexe, formázása és tartalma továbbra is elérhető a kódból, ezért a rejtés alkalmas opcionális elemekre, amelyeket később vissza lehet állítani.

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

A rejtés nem törlés vagy biztonsági funkció. Az objektum továbbra is felfedezhető és feltártható felhasználó vagy kód által, és része marad a prezentáció fájlnak.

### **Z‑rend sorrend módosítása**

Az átfedő alakzatok a gyűjtemény sorrendjében kerülnek kirajzolásra. **[Reorder](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/reorder/)** egy meglévő alakzatot a kívánt indexre mozgat klónozás nélkül. A `0` index a hátul, a `Count - 1` az elöl helyezkedik el.

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

A téglalapot előbb hozták létre, és kezdetben a kör alatti helyen volt. A végső indexre helyezve előre kerül. Z‑rendet érdemes az összes kapcsolódó alakzat hozzáadása vagy klónozása után véglegesíteni, mert ezek a műveletek új gyűjteményelemeket fűznek a sorhoz, és megváltoztathatják a kívánt rétegsorrendet.

## **Elrendezési diákon lévő alakzatok ellenőrzése**

A normál diák, elrendezési diák és master‑diák saját alakzatgyűjteménnyel rendelkezik. Egy elrendezési gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonlóan elhelyezett alakzat egy normál dián. Ellenőrizze az elrendezési alakzatokat, ha a formázást, amelyet egy elrendezés biztosít, meg kell érteni vagy módosítani.

Az alábbi példa minden elrendezési alakzat **[FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_fillformat/)** és **[LineFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_lineformat/)** tulajdonságát olvassa, anélkül, hogy azt feltételezné, hogy minden alakzat egy `AutoShape`.

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

Egy elrendezés szerkesztése több diát is érinthet, amelyik használja azt. Mielőtt egy elrendezési alakzatot módosítana, határozza meg, hogy egy normál dia örökli‑e az objektumot vagy helyi felülírással rendelkezik‑e, és tesztelje az összes olyan diát, amely az elrendezést használja.

## **Alakzat exportálása SVG‑be**

**[WriteAsSvg](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/writeassvg/)** egy alakzat megjelenített tartalmát egy adatfolyamba írja. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia háttérjét vagy a szomszédos alakzatokat.

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

Tartsa nyitva a prezentációt a renderelés alatt. A kimenet az alakzat formázásától, valamint a betűkészletek és képek erőforrásoktól függ. Ha a teljes kompozícióra van szüksége, exportálja a diát, ne pedig az egyedi alakzatot. A hívó tulajdonában van a stream, és azt be kell zárni vagy el kell dobni.

## **Alakzatok igazítása**

A **[SlideUtil::AlignShapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/alignshapes/)** túlterhelései vagy az összes alakzatot, vagy a kiválasztott gyűjtemény‑indexeket igazítják. A **[ShapesAlignmentType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapesalignmenttype/)** meghatározza a szegélyt, középvonalat vagy elosztási módot. Az `alignToSlide` értéket `true`‑ra állítva a dia széléhez igazít, `false`‑ra állítva a kiválasztott alakzatok egymáshoz viszonyított igazítása történik.

Ez a példa három alakzatot a dia felső széléhez igazít. A visszaadott alakzat‑referenciákat közvetlenül az igazítás előtt aktuális indexeikre konvertálja.

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

Az igazítás a pozíciókat, nem a z‑rendet változtatja. Relatív igazításhoz általában legalább két alakzat szükséges, míg a vízszintes vagy függőleges elosztáshoz elegendő alakzat kell ahhoz, hogy a távolságot meghatározza. Ha a metódus hívása előtt módosítja a gyűjteményt, számolja újra az indexeket.

## **Alakzat tükrözése**

A **[ShapeFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapeframe/)** osztály tárolja a pozíciót, méretet, vízszintes és függőleges tükrözési beállításokat, valamint a forgást. A `FlipH` és `FlipV` értékek **[NullableBool](https://reference.aspose.com/slides/hu/cpp/aspose.slides/nullablebool/)** típusúak: `True` engedélyezi a tükrözést, `False` letiltja, `NotDefined` pedig megtartja a nem definiált/alapértelmezett állapotot.

Az alábbi bemeneti prezentáció egy nem tükrözött alakzatot tartalmaz.

![The shape before flipping](shape_to_be_flipped.png)

A példa minden más keretértéket változatlanul hagy, és csak a két tükrözési beállítást cseréli le. Ez fontos, mert egy új **[Frame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/set_frame/)** hozzárendelése a teljes keret felülírását eredményezi.

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

A mentett alakzat vízszintesen és függőlegesen is tükröződik, miközben megtartja a pozícióját, méretét és forgását.

![The shape after flipping](flipped_shape.png)

## **GYIK**

**Használjak gyűjtemény‑indexet alakzat azonosítóként?**

Csak rövid‑élettartamú feldolgozás esetén, amikor a gyűjtemény nem változik az index használata előtt. Sablonok esetén részesítsen előnyben egy ellenőrzött `Name` vagy `AlternativeText` konvenciót, illetve slide‑szintű interop munkához `OfficeInteropShapeId`‑t.

**Eltávolítja-e egy rejtett alakzat a z‑rendet?**

Nem. Egy rejtett alakzat ugyanazon az indexen marad a gyűjteményben. Megtalálható, átrendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik előtt?**

Az `AddClone` a klónt a gyűjtemény végére fűzi, ami a z‑rend eleje. Használja az `InsertClone`‑t, ha kezdeti indexet szeretne megadni, vagy a `Reorder`‑t a hozzáadás után.

**Használhatok rögzített indexet előre beállított alakzat‑igazítás azonosításához?**

Csak akkor, ha a pontos előre beállítás és a gyűjtemény elrendezése előre validálva van. Inkább iteráljon a `IGeometryShape::get_Adjustments`‑on, és ellenőrizze a `IAdjustValue::get_Type`‑t; ha ugyanaz a szemantikai típus többször is előfordul, használja a `IAdjustValue::get_Name`‑t további információként.