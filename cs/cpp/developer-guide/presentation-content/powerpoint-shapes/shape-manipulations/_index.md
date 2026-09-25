---
title: Správa tvarů prezentace v C++
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
- bod úpravy tvaru
- přednastavená úprava tvaru
- geometrie tvaru
- formáty rozvržení tvaru
- tvar jako SVG
- tvar do SVG
- zarovnat tvar
- převrátit tvar
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak identifikovat, upravovat, klonovat, odstraňovat, skrývat, přeskupovat, exportovat, zarovnávat a převracet tvary prezentace pomocí Aspose.Slides pro C++."
---
## **Přehled**

Aspose.Slides for C++ představuje tvary na snímku jako uspořádanou [IShapeCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/). Kolekce je zároveň místem, kde můžete tvary najít a upravit, a zdrojem jejich pořadí vrstvení: index `0` je nejzadnější tvar, zatímco poslední index je nejčelnější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar a upravit přednastavené body úprav tvaru, poté ukazuje, jak klonovat, odstraňovat, skrývat a přeskupovat tvary. Poslední sekce pokrývají formátování na úrovni rozvržení, export do SVG, zarovnání a nastavení převrácení. Každý příklad je nezávislý, takže můžete použít jen operace, které váš pracovní postup vyžaduje.

## **Identifikace a vyhledání tvarů**

Indexy v kolekci jsou pohodlné při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odebrání nebo přeuspořádání tvaru může změnit jeho index. Vyberte identifikátor podle toho, jak je prezentace vytvořena a udržována:

- [Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_name/) je užitečné pro šablony ovládané vývojáři a je snadno viditelné v panelu výběru PowerPointu. Jména lze upravovat a není zaručeno, že jsou jedinečná, proto si stanovte konvenci pojmenování, pokud na nich kód závisí.
- [AlternativeText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_alternativetext/) je užitečné, když už existuje popis přístupnosti nebo autorův štítek, který tvar identifikuje. Je viditelné uživatelům, může být lokalizováno nebo přepsáno pro přístupnost a není zaručeno, že je jedinečné. Nepřevádějte významný text přístupnosti na klíč databáze bez výslovného souhlasu.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_officeinteropshapeid/) je jen‑čtení identifikátor, který je jedinečný v rámci snímku a odpovídá ID tvaru používanému v PowerPoint interop. Použijte jej při integraci s PowerPointem nebo když potřebujete jednoznačný odkaz po celou životnost tvaru. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá své vlastní ID.

Související vlastnost [UniqueId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_uniqueid/) má rozsah celé prezentace, ale je určena pro doplňky a může být přidělena nově. Neměla by být považována za trvalý externí klíč. Pokud je dlouhodobá identita podstatná, uchovejte mapování v aplikačních datech a ověřte, že očekávaný tvar stále existuje.

Pro praktický příklad čtení a aktualizace jak titulku alternativního textu, tak popisu, viz [Manage Alternative Text Titles and Descriptions](/slides/cs/cpp/presentation-accessibility/). Používejte alternativní text k vysvětlení významu vizuálu čtenářům a oddělte ho od názvů tvarů, které kód používá k vyhledání tvarů.

Následující příklad vyhledává podle `Name` a vypisuje interop ID v rámci snímku. Pokud šablona neobsahuje očekávaný tvar, kód vypíše tento výsledek místo pokračování s nesprávným objektem.

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

Když je operace specifická pro typ tvaru, zkontrolujte rozhraní před použitím typově specifických členů. Tento příklad aktualizuje text a alternativní text pouze pokud je pojmenovaný objekt typu [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).

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

## **Identifikace a úprava přednastavených úprav tvaru**

Tvary s přednastavenou geometrií mohou mít body úprav, které řídí například velikost rohu, proporce šipky nebo úhly oblouku. Přistupujte k nim přes jen‑čtení kolekci [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/cs/cpp/aspose.slides/igeometryshape/get_adjustments/). Kolekce je poskytována tvarem, ale každá položka [IAdjustValue](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iadjustvalue/) obsahuje hodnotu, kterou lze změnit.

Nespoléhejte se pouze na pevný index v kolekci. Projděte všechny úpravy a podívejte se na jen‑čtení vlastnost [IAdjustValue::get_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iadjustvalue/get_type/), jejíž hodnota [ShapeAdjustmentType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapeadjustmenttype/) popisuje, co úprava ovlivňuje. Jen‑čtení vlastnost [IAdjustValue::get_Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iadjustvalue/get_name/) poskytuje doplňující identifikační informace a je zvláště užitečná, když přednastavení obsahuje více úprav se stejným sémantickým typem.

Použijte hodnotovou vlastnost, která odpovídá významu úpravy:

| Typ úpravy | Účel | Hodnota ke změně |
|---|---|---|
| `CornerSize` | Velikost zaoblených rohů | [RawValue](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Tloušťka ocasu šipky | `RawValue` |
| `ArrowheadLength` | Délka hrotu šipky | `RawValue` |
| `ArrowheadWidth` | Šířka hrotu šipky | `RawValue` |
| `StartAngle` | Počáteční úhel výseče nebo oblouku | [AngleValue](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Konečný úhel výseče nebo oblouku | `AngleValue` |

`Type` a `Name` nelze přiřazovat. `RawValue` je čtení‑zápis celé číslo v jednotkách nativní geometrie přednastavení, zatímco `AngleValue` je čtení‑zápis úhel ve stupních. Počet, pořadí, význam a platný rozsah úprav závisí na přednastavení [ShapeType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/igeometryshape/get_shapetype/). Hodnota, která je platná pro jedno přednastavení, může být pro jiné neplatná nebo mít jiný účinek.

Když je `Type` rovno `ShapeAdjustmentType::Custom`, API nerozpozná standardní sémantický význam. Prohlédněte `Name`, typ přednastavení a existující hodnotu a nechte úpravu beze změny, pokud neznáte očekávaný význam a rozsah. I pro rozpoznané typy ověřte, zda se stejný typ nevyskytuje vícekrát, než vyberete hodnotu. Článek o [Connector](/slides/cs/cpp/connector/) ukazuje tuto situaci u úprav ohybu konektoru.

Následující úplný příklad vytváří výchozí i upravené verze tří přednastavených tvarů. Prochází každou úpravu, vypisuje její `Name` a `Type`, mění hodnoty související s velikostí pomocí `RawValue`, mění úhly pomocí `AngleValue` a ukládá výsledek. Levý sloupec zachovává výchozí geometrii; pravý sloupec ukazuje upravený zaoblený obdélník, čtyřcestnou šipku a výseč.

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

// Přidá záhlaví pro výchozí a upravené sloupce tvarů.
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

Kontrola sémantického typu před změnou hodnoty činí kód explicitním ohledně záměru a zabraňuje předpokladu, že konkrétní index kolekce má stejný význam napříč různými přednastavenými tvary.

## **Úprava kolekce tvarů**

Metody pro přidání, klonování, odebrání a přeskupení operují přímo na kolekci. Pokud operace změní počet nebo pořadí tvarů, již se nespoléhejte na indexy zachycené před touto operací.

### **Klonování tvaru**

[AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addclone/) vytvoří nezávislou kopii a připojí ji k cílové kolekci. [InsertClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/insertclone/) také vytvoří kopii, ale umístí ji na zadaný index z‑řazení. Přetížení, která přijímají souřadnice, přesunou klon bez změny jeho velikosti; přetížení s šířkou a výškou jej mohou také změnit.

Příklad vytvoří cílový snímek, klonuje obdélník s popiskem do popředí a vloží druhý klon do pozadí. Změny v kterémkoli klonu neovlivní zdrojový tvar.

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

Klonování kopíruje obsah a formátování tvaru, včetně jeho názvu a alternativního textu. Přidělte novým klonům logické identifikátory, pokud musí být tyto hodnoty jedinečné. Zdroje používané složitými tvary spravuje prezentace, ale klon zůstává novou položkou kolekce s novou identitou tvaru.

### **Odstranění tvarů**

[Remove](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/remove/) smaže konkrétní objekt tvaru z jeho kolekce. Při odstraňování více shodných tvarů během indexované iterace procházejte kolekci od konce, aby každý zbývající index zůstal platný.

Tento příklad odstraňuje každý tvar s určeným názvem. Čte aktuální indexovaný tvar, ne pevně danou položku kolekce, a nepřetypovává tvar zbytečně.

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

Po odstranění se počet tvarů a indexy pozdějších tvarů změní. Odkazy na nedotčené tvary zůstávají spolehlivější než uložené indexy. Také zvažte konektory, animace a další prvky prezentace, které mohou odkazovat na odstraněný objekt; odstranění viditelného tvaru může změnit více než jen vzhled snímku.

### **Skrytí tvaru**

Nastavení [Hidden](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/set_hidden/) na `true` ponechá tvar v kolekci, ale zabrání jeho zobrazení v normálním režimu prezentace. Jeho index, formátování i obsah zůstávají k dispozici kódu, takže skrytí je vhodné pro volitelné elementy, které mohou být později obnoveny.

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

Skrytí není smazání ani bezpečnostní opatření. Objekt může být stále objeven a odskryt uživatelem nebo kódem a zůstává součástí souboru prezentace.

### **Změna Z‑řazení**

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

Obdélník je vytvořen nejprve a zpočátku leží za elipsou. Přesunutí na poslední index jej umístí dopředu. Dokončete z‑řazení po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky do kolekce a mohou změnit zamýšlený stack.

## **Prohlížení tvarů na rozvrhových snímcích**

Normální snímky, rozvrhové snímky a hlavní snímky mají oddělené kolekce tvarů. Tvar v kolekci rozvrhu není stejný objekt jako podobně umístěný tvar na normálním snímku. Prohlédněte tvar rozvrhu, když potřebujete pochopit nebo změnit formátování dodané rozvržením.

Následující příklad čte [FillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_fillformat/) a [LineFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_lineformat/) každého tvaru v rozvrhu, aniž by předpokládal, že každý tvar je `AutoShape`.

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

Úprava rozvrhu může ovlivnit více snímků, které jej používají. Před změnou tvaru v rozvrhu zjistěte, zda normální snímek dědí objekt nebo obsahuje lokální přepsání, a otestujte každý snímek, který dané rozvržení používá.

## **Export tvaru do SVG**

[WriteAsSvg](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/writeassvg/) zapíše vykreslený obsah jednoho tvaru do proudu. Výsledek obsahuje pouze tvar, ne celé pozadí snímku ani sousední tvary.

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

Udržujte prezentaci otevřenou během renderování. Výstup závisí na formátování tvaru a na zdrojích, jako jsou písma a obrázky. Pokud potřebujete celý kompozit, exportujte snímek místo jednotlivého tvaru. Volající vlastní proud a musí jej uzavřít nebo uvolnit.

## **Zarovnání tvarů**

[Přetížení](https://reference.aspose.com/slides/cs/cpp/aspose.slides.util/slideutil/alignshapes/) metody [SlideUtil::AlignShapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides.util/slideutil/alignshapes/) zarovnávají buď všechny tvary, nebo vybrané indexy kolekce. [ShapesAlignmentType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapesalignmenttype/) určuje okraj, středovou čáru nebo režim distribuce. Nastavte `alignToSlide` na `true`, chcete‑li použít okraje snímku; nastavte na `false`, chcete‑li zarovnat vybrané tvary vzhledem k sobě navzájem.

Tento příklad zarovnává tři tvary k hornímu okraji snímku. Odkazy na tvary jsou převedeny na jejich aktuální indexy těsně před zarovnáním.

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

Zarovnání mění pozice, ne Z‑řazení. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco horizontální nebo vertikální distribuce potřebuje dostatek tvarů pro definování mezery. Při úpravě kolekce před voláním metody přepočítejte indexy.

## **Převrácení tvaru**

Třída [ShapeFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapeframe/) ukládá pozici, velikost, horizontální a vertikální nastavení převrácení a rotaci. Její hodnoty `FlipH` a `FlipV` používají [NullableBool](https://reference.aspose.com/slides/cs/cpp/aspose.slides/nullablebool/): `True` zapíná převrácení, `False` jej vypíná a `NotDefined` zachovává nevy definovaný / výchozí stav.

Vstupní prezentace níže obsahuje jeden nepřevrácený tvar.

![Tvar před převrácením](shape_to_be_flipped.png)

Příklad zachovává všechny ostatní hodnoty rámce a nahrazuje pouze dvě nastavení převrácení. To je důležité, protože při nastavení nového [Frame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/set_frame/) se nahradí celý rámec.

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

Uložený tvar je zrcadlen horizontálně i vertikálně při zachování pozice, velikosti a rotace.

![Tvar po převrácení](flipped_shape.png)

## **Často kladené otázky**

**Mám používat index kolekce jako identifikátor tvaru?**

Pouze pro krátkodobé zpracování, kdy se kolekce během používání indexu nezmění. Upřednostněte ověřenou konvenci `Name` nebo `AlternativeText` pro vytvořené šablony, nebo `OfficeInteropShapeId` pro práci s interopem na úrovni snímku.

**Odstraňuje skrytí tvaru jeho pozici v Z‑řazení?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Může být nalezen, přeskupen, upraven nebo znovu zviditelněn.

**Proč se klonovaný tvar objevil před jiným tvarem?**

`AddClone` přidá klon na konec kolekce, což je přední část Z‑řazení. Použijte `InsertClone` k určení počátečního indexu nebo `Reorder` po přidání všech tvarů.

**Mohu použít pevný index k identifikaci úpravy přednastaveného tvaru?**

Pouze po ověření konkrétního přednastavení a rozložení kolekce. Upřednostněte iteraci přes `IGeometryShape::get_Adjustments` a kontrolu `IAdjustValue::get_Type`; použijte `IAdjustValue::get_Name` jako doplňující informaci, když se stejný sémantický typ vyskytuje vícekrát.