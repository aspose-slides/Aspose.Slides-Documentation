---
title: Správa tvarů v prezentaci v C++
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/cpp/shape-manipulations/
keywords:
- tvar PowerPoint
- tvar prezentace
- tvar na snímku
- najít tvar
- klonovat tvar
- odstranit tvar
- skrýt tvar
- změnit pořadí tvaru
- získat ID interop tvaru
- alternativní text tvaru
- formáty rozvržení tvaru
- tvar jako SVG
- převést tvar na SVG
- zarovnat tvar
- převrátit tvar
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak identifikovat, klonovat, odstraňovat, skrývat, měnit pořadí, exportovat, zarovnávat a převracet tvary v prezentaci pomocí Aspose.Slides pro C++."
---
## **Přehled**

Aspose.Slides pro C++ představuje tvary na snímku jako uspořádanou [IShapeCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/). Kolekce je zároveň místem, kde najdete a upravujete tvary, i zdrojem jejich pořadí v zásobníku: index `0` je nejzadnější tvar, zatímco poslední index je nejpřednější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar, pak ukazuje, jak klonovat, odstraňovat, skrývat a měnit pořadí tvarů. Poslední sekce pokrývají formátování na úrovni rozvržení, export do SVG, zarovnání a nastavení převrácení. Každý příklad je nezávislý, takže můžete použít jen operace, které váš proces vyžaduje.

## **Identifikovat a najít tvary**

Indexy kolekcí jsou pohodlné při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odebrání nebo změna pořadí tvaru může změnit jeho index. Vyberte identifikátor podle toho, jak je prezentace vytvářena a spravována:

- [Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_name/) je užitečné pro šablony řízené vývojářem a snadno jej lze zobrazit v panelu výběru PowerPointu. Jména lze upravovat a není zaručeno, že jsou jedinečná, proto si nastavte konvenci pojmenování, pokud na nich kód závisí.
- [AlternativeText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_alternativetext/) je užitečné, když již popis přístupnosti nebo autorovo označení identifikuje tvar. Je viditelné uživatelům, může být lokalizováno nebo přepsáno pro přístupnost a také není zaručeno, že je jedinečné. Nepřevádějte tiše významný text přístupnosti na klíč databáze.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_officeinteropshapeid/) je jen pro čtení a jedinečný v rámci snímku; odpovídá ID tvaru používanému v PowerPoint interop. Použijte jej při integraci s PowerPointem nebo když potřebujete jednoznačný odkaz během životnosti tvaru. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá své vlastní ID.

Související vlastnost [UniqueId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_uniqueid/) má rozsah celé prezentace, ale je určena pro doplňky a může být přeřazena. Neměla by být považována za trvalý externí klíč. Pokud je dlouhodobá identita podstatná, uložte mapování v aplikačních datech a ověřte, že očekávaný tvar stále existuje.

Níže uvedený příklad vyhledává podle `Name` a vrací ID interopu v rámci snímku. Když šablona neobsahuje očekávaný tvar, kód místo toho vypíše výsledek místo pokračování se špatným objektem.

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

Když je operace specifická pro typ tvaru, zkontrolujte rozhraní před použitím členů specifických pro typ. Tento příklad aktualizuje text a alternativní text pouze pokud pojmenovaný objekt je [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).

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

## **Upravit kolekci tvarů**

Metody přidání, klonování, odebrání a změny pořadí operují přímo na kolekci. Pokud operace mění počet nebo pořadí tvarů, nespoléhejte se na indexy zachycené před touto operací.

### **Klonovat tvar**

[AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addclone/) vytvoří nezávislou kopii a přidá ji na konec cílové kolekce. [InsertClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/insertclone/) také vytvoří kopii, ale umístí ji na zadaný index v z‑řádu. Přetížení, která přijímají souřadnice, přesouvají klon bez změny velikosti; přetížení s šířkou a výškou jej mohou také změnit.

Příklad vytvoří cílový snímek, klonuje označený obdélník do popředí a vloží druhý klon dozadu. Změny v libovolném klonu neovlivní zdrojový tvar.

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

Klonování kopíruje obsah a formátování tvaru, včetně jeho jména a alternativního textu. Při potřebě jedinečných hodnot přiřaďte novým klonům nové logické identifikátory. Zdrojové prostředky komplexních tvarů spravuje prezentace, ale klon zůstává novou položkou v kolekci s novou identitou tvaru.

### **Odstranit tvary**

[Remove](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/remove/) smaže konkrétní objekt tvaru z jeho kolekce. Při odstraňování více shod během iterace s indexy procházejte od konce, aby každý zbývající index zůstal platný.

Tento příklad odstraňuje každý tvar s určeným jménem. Čte aktuální indexovaný tvar, nikoli pevnou položku kolekce, a nepotřebně nepřetypovává tvar.

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

Po odebrání se počet tvarů a indexy následujících tvarů změní. Odkazy na nedotčené tvary zůstávají spolehlivější než uložené indexy. Zvažte také konektory, animace a další funkce prezentace, které mohou odkazovat na odebraný objekt; odebrání viditelného tvaru může změnit více než jen vzhled snímku.

### **Skrýt tvar**

Nastavení [Hidden](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/set_hidden/) na `true` ponechá tvar v kolekci, ale zabrání jeho zobrazení v normálním režimu prezentace. Jeho index, formátování a obsah zůstávají k dispozici kódu, takže skrytí je vhodné pro volitelné prvky, které mohou být později obnoveny.

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

Skrývání není smazání ani zabezpečení. Objekt lze stále najít a znovu zobrazit uživatelem nebo kódem a zůstává součástí souboru prezentace.

### **Změnit z‑řád**

Překrývající se tvary jsou vykreslovány v pořadí kolekce. [Reorder](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/reorder/) přesune existující tvar na cílový index bez jeho klonování. Index `0` je zadní; `Count - 1` je přední.

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

Obdélník je vytvořen nejprve a zpočátku leží za eliptou. Přesunutí na poslední index jej umístí dopředu. Dokončete z‑řád po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky do kolekce a mohou změnit zamýšlený zásobník.

## **Prozkoumat tvary na snímcích rozvržení**

Normální snímky, snímky rozvržení i hlavní snímky mají oddělené kolekce tvarů. Tvar v kolekci rozvržení není stejný objekt jako podobně umístěný tvar na normálním snímku. Prozkoumejte tvary rozvržení, když potřebujete pochopit nebo změnit formátování poskytnuté rozvržením.

Níže uvedený příklad čte každého tvaru rozvržení jeho [FillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_fillformat/) a [LineFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_lineformat/) aniž by předpokládal, že každý tvar je `AutoShape`.

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

Úprava rozvržení může ovlivnit více snímků, které jej používají. Před změnou tvaru rozvržení zjistěte, zda normální snímek dědí objekt nebo obsahuje lokální přepsání, a otestujte každý snímek, který rozvržení používá.

## **Exportovat tvar do SVG**

[WriteAsSvg](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/writeassvg/) zapisuje vykreslený obsah jednoho tvaru do proudu. Výsledek obsahuje tvar, ne celé pozadí snímku ani sousední tvary.

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

Udržujte prezentaci otevřenou během renderování. Výstup závisí na formátování tvaru a na prostředcích jako jsou fonty a obrázky. Pokud potřebujete celou kompozici, exportujte snímek místo jednotlivého tvaru. Volající vlastní proud a musí jej zavřít nebo uvolnit.

## **Zarovnat tvary**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides.util/slideutil/alignshapes/) má přetížení, která zarovnávají buď všechny tvary, nebo vybrané indexy kolekce. [ShapesAlignmentType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapesalignmenttype/) určuje hranu, středovou čáru nebo režim rozdělení. Nastavte `alignToSlide` na `true` pro použití okrajů snímku; nastavte na `false` pro zarovnání vybraných tvarů relativně k sobě navzájem.

Tento příklad zarovnává tři tvary k horní hraně snímku. Vrácené odkazy na tvary jsou před zarovnáním okamžitě převedeny na jejich aktuální indexy.

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

Zarovnání mění pozice, nikoli z‑řád. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco horizontální nebo vertikální rozdělení potřebuje dostatek tvarů pro definování rozestupů. Přepočítejte indexy, pokud před voláním metody upravujete kolekci.

## **Převrátit tvar**

Třída [ShapeFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapeframe/) ukládá polohu, velikost, vodorovné a svislé nastavení převrácení a rotaci. Její hodnoty `FlipH` a `FlipV` používají [NullableBool](https://reference.aspose.com/slides/cs/cpp/aspose.slides/nullablebool/): `True` zapíná převrácení, `False` jej vypíná a `NotDefined` zachovává neurčený/výchozí stav.

Vstupní prezentace níže obsahuje jeden netransformovaný tvar.

![Tvar před převrácením](shape_to_be_flipped.png)

Příklad zachovává všechny ostatní hodnoty rámce a mění pouze dvě nastavení převrácení. To je důležité, protože při přiřazení nového [Frame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/set_frame/) se nahradí celý rámec.

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

Uložený tvar je horizontálně a vertikálně zrcadlený, přičemž si zachovává polohu, velikost a rotaci.

![Tvar po převrácení](flipped_shape.png)

## **Často kladené otázky**

**Mám používat index kolekce jako identifikátor tvaru?**

Pouze pro krátkodobé zpracování, kdy se kolekce před použitím indexu už nezmění. Upřednostněte ověřenou konvenci `Name` nebo `AlternativeText` pro vytvořené šablony, nebo `OfficeInteropShapeId` pro práci s interopem v rámci snímku.

**Odstraňuje skrytí tvaru jeho pozici v z‑řádu?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Lze jej najít, změnit pořadí, upravit nebo znovu zobrazit.

**Proč se klonovaný tvar objevil před jiným tvarem?**

`AddClone` přidá klon na konec kolekce, což je přední část z‑řádu. Použijte `InsertClone` pro volbu počátečního indexu nebo `Reorder` po přidání všech tvarů.