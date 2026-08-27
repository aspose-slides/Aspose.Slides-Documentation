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
- vyhledat tvar
- klonovat tvar
- odstranit tvar
- skrýt tvar
- změnit pořadí tvaru
- získat interop ID tvaru
- alternativní text tvaru
- bod úpravy tvaru
- přednastavená úprava tvaru
- geometrie tvaru
- formáty rozvržení tvaru
- tvar jako SVG
- tvar do SVG
- zarovnat tvar
- otočit tvar
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak identifikovat, upravovat, klonovat, odstraňovat, skrývat, měnit pořadí, exportovat, zarovnávat a otáčet tvary prezentace pomocí Aspose.Slides pro C++."
---
## **Přehled**

Aspose.Slides pro C++ představuje tvary na snímku jako uspořádanou [IShapeCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/). Kolekce je zároveň místem, kde můžete tvary vyhledávat a upravovat, a zdrojem jejich vrstvení: index `0` označuje nejzadnější tvar, zatímco poslední index označuje nejpřednější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar a upravit přednastavené body úpravy tvaru, poté ukazuje, jak klonovat, odstraňovat, skrývat a měnit pořadí tvarů. Závěrečné sekce se zabývají formátováním na úrovni rozvržení, exportem do SVG, zarovnáním a nastavením otáčení. Každý příklad je nezávislý, takže můžete použít pouze operace, které váš pracovní postup vyžaduje.

## **Identifikace a vyhledání tvarů**

Indexy v kolekci jsou praktické při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odebrání nebo změna pořadí tvaru může změnit jeho index. Zvolte identifikátor podle toho, jak je prezentace vytvořena a spravována:

- [Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_name/) je užitečný pro šablony řízené vývojářem a snadno jej lze zkontrolovat v panelu výběru PowerPointu. Názvy lze upravovat a nejsou garantovány jako jedinečné, proto si stanovte konvenci pojmenování, pokud na nich kód závisí.
- [AlternativeText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_alternativetext/) je užitečný, když popis přístupnosti nebo autorovo označení již tvar identifikuje. Je viditelný pro uživatele, může být lokalizován nebo přepsán pro přístupnost a není garantován jako jedinečný. Nepřevádějte tiše smysluplný text přístupnosti na klíč databáze.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_officeinteropshapeid/) je identifikátor jen pro čtení, který je jedinečný v rámci snímku a odpovídá ID tvaru používanému v interop PowerPointu. Použijte jej při integraci s PowerPointem nebo když potřebujete jednoznačný odkaz po celou životnost tvaru. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá své vlastní ID.

Související vlastnost [UniqueId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_uniqueid/) má rozsah celé prezentace, ale je určena pro doplňky a může být znovu přiřazena. Neměla by být považována za trvalý externí klíč. Pokud je dlouhodobá identita nezbytná, udržujte mapování v aplikačních datech a ověřujte, že očekávaný tvar stále existuje.

Následující příklad vyhledává podle `Name` a vypisuje interop ID v rámci snímku. Když šablona neobsahuje očekávaný tvar, kód vypíše tento výsledek místo toho, aby pokračoval se špatným objektem.

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

## **Identifikace a úprava přednastavených úprav tvaru**

Tvary s přednastavenou geometrií mohou odhalovat body úpravy, které řídí funkce jako velikost rohu, proporce šipky nebo úhly oblouku. Přistupujte k nim přes jen pro čtení kolekci [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/cs/cpp/aspose.slides/igeometryshape/get_adjustments/). Kolekci poskytuje samotný tvar, ale každý [IAdjustValue](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iadjustvalue/) obsahuje hodnotu, kterou lze změnit.

 Nespoléhejte se jen na pevný index kolekce. Procházejte úpravy a kontrolujte jen pro čtení vlastnost [IAdjustValue::get_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iadjustvalue/get_type/), jejíž hodnota [ShapeAdjustmentType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapeadjustmenttype/) popisuje, co úprava ovládá. Jen pro čtení vlastnost [IAdjustValue::get_Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iadjustvalue/get_name/) poskytuje doplňující identifikační informace a je zvláště užitečná, když přednastavení obsahuje více úprav se stejným sémantickým typem.

Použijte vlastnost hodnoty, která odpovídá významu úpravy:

| Typ úpravy | Účel | Hodnota ke změně |
|---|---|---|
| `CornerSize` | Velikost zaoblených rohů | [RawValue](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Tloušťka ocasu šipky | `RawValue` |
| `ArrowheadLength` | Délka hrotu šipky | `RawValue` |
| `ArrowheadWidth` | Šířka hrotu šipky | `RawValue` |
| `StartAngle` | Počáteční úhel výseče nebo oblouku | [AngleValue](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Koncový úhel výseče nebo oblouku | `AngleValue` |

`Type` a `Name` nelze přiřadit. `RawValue` je čtení/zápis celé číslo v nativních jednotkách geometrie přednastavení, zatímco `AngleValue` je čtení/zápis úhel ve stupních. Počet, pořadí, význam a platný rozsah úprav závisí na přednastaveném [ShapeType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/igeometryshape/get_shapetype/). Hodnota platná pro jedno přednastavení může být neplatná nebo mít jiný efekt pro jiné.

Když je `Type` `ShapeAdjustmentType::Custom`, API nerozpozná standardní sémantický význam. Prohlédněte `Name`, typ přednastavení a existující hodnotu a nechte úpravu beze změny, pokud není znám očekávaný význam a rozsah. I pro rozpoznané typy zkontrolujte, zda se stejný typ neobjevuje vícekrát, než vyberete hodnotu. Článek [Connector](/slides/cs/cpp/connector/) ukazuje tuto situaci s úpravami ohybu spojníku.

Následující kompletní příklad vytváří výchozí a upravené verze tří přednastavených tvarů. Prochází každou úpravu, vypisuje její `Name` a `Type`, mění hodnoty související s velikostí přes `RawValue`, mění úhly přes `AngleValue` a ukládá výsledek. Levý sloupec zachovává výchozí geometrii; pravý sloupec ukazuje upravený zaoblený obdélník, čtyřcestnou šipku a výseč.

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

Kontrola sémantického typu před změnou hodnoty dělá kód explicitním ohledně jeho záměru a zabraňuje předpokladu, že konkrétní index kolekce má stejný význam napříč různými přednastavenými tvary.

## **Úprava kolekce tvarů**

Metody pro přidání, klonování, odstraňování a změnu pořadí operují na kolekci okamžitě. Pokud operace změní počet nebo pořadí tvarů, nepokračujte v spolehání se na indexy zachycené před touto operací.

### **Klonování tvaru**

[AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addclone/) vytvoří nezávislou kopii a připojí ji do cílové kolekce. [InsertClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/insertclone/) také vytvoří kopii, ale umístí ji na zadaný index z‑order. Přetížení, která přijímají souřadnice, přesouvají klon bez změny velikosti; přetížení s šířkou a výškou jej mohou také změnit.

Příklad vytvoří cílový snímek, naklonuje označený obdélník dopředu a vloží druhý klon dozadu. Změny v libovolném klonu neovlivní zdrojový tvar.

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

Klonování kopíruje obsah a formátování tvaru, včetně jeho názvu a alternativního textu. Přidělte nové logické identifikátory klonu, pokud musí být tyto hodnoty jedinečné. Prostředky používané složitými tvary spravuje prezentace, ale klon zůstává novou položkou v kolekci s novou identitou tvaru.

### **Odstranění tvarů**

[Remove](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/remove/) odstraní konkrétní objekt tvaru z jeho kolekce. Při odstraňování více shod během indexované iterace procházejte kolekci od konce, aby každý zbývající index zůstal platný.

Tento příklad odstraňuje každý tvar s určeným názvem. Čte aktuální indexovaný tvar, nikoli pevnou položku kolekce, a neprovádí zbytečné přetypování tvaru.

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

Po odstranění se počet tvarů a indexy následujících tvarů změní. Odkazy na nedotčené tvary zůstávají spolehlivější než uložené indexy. Také zvažte spojníky, animace a další prvky prezentace, které mohou odkazovat na odebraný objekt; odstranění viditelného tvaru může změnit více než jen vzhled snímku.

### **Skrytí tvaru**

Nastavení [Hidden](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/set_hidden/) na `true` ponechá tvar v kolekci, ale zabrání jeho zobrazení v běžném režimu prezentace. Jeho index, formátování i obsah zůstávají pro kód dostupné, takže skrytí je vhodné pro volitelné elementy, které mohou být později obnoveny.

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

Skrytí není smazání ani zabezpečení. Objekt může být i nadále objeven a znovu zobrazen uživatelem nebo kódem a stále patří do souboru prezentace.

### **Změna Z‑orderu**

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

Obdélník je vytvořený jako první a původně leží za elipsou. Přesunutím na poslední index se dostane dopředu. Finalizujte Z‑order po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky do kolekce a mohou změnit zamýšlený zásobník.

## **Prohlížení tvarů na rozvržovacích snímcích**

Normální snímky, rozvržovací snímky a hlavní snímky mají oddělené kolekce tvarů. Tvar v rozvržovací kolekci není stejný objekt jako podobně umístěný tvar na normálním snímku. Prohlédněte tvar rozvržení, když potřebujete pochopit nebo změnit formátování poskytované rozvržením.

Následující příklad čte pro každý tvar rozvržení jeho [FillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_fillformat/) a [LineFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_lineformat/) bez předpokladu, že každý tvar je `AutoShape`.

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

Úprava rozvržení může ovlivnit více snímků, které jej používají. Před změnou tvaru rozvržení zjistěte, zda normální snímek dědí objekt nebo obsahuje lokální přepsání, a otestujte každý snímek používající toto rozvržení.

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

Udržujte prezentaci otevřenou během vykreslování. Výstup závisí na formátování tvaru a na prostředcích jako jsou písma a obrázky. Pokud potřebujete celou kompozici, exportujte snímek místo jednotlivého tvaru. Volající vlastní proud a musí jej uzavřít nebo uvolnit.

## **Zarovnání tvarů**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides.util/slideutil/alignshapes/) má přetížení, která zarovnají buď všechny tvary, nebo vybrané indexy kolekce. [ShapesAlignmentType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapesalignmenttype/) určuje okraj, středovou čáru nebo režim rozdělení. Nastavte `alignToSlide` na `true`, pokud chcete použít okraje snímku; nastavte jej na `false` pro zarovnání vybraných tvarů vzhledem k sobě navzájem.

Tento příklad zarovnává tři tvary k hornímu okraji snímku. Vrácené odkazy na tvary jsou před zarovnáním okamžitě převedeny na jejich aktuální indexy.

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

Zarovnání mění pozice, ne Z‑order. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco horizontální nebo vertikální rozdělení potřebuje dostatek tvarů k definování mezery. Přepočítejte indexy, pokud před voláním metody upravujete kolekci.

## **Otočení tvaru**

Třída [ShapeFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapeframe/) ukládá pozici, velikost, nastavení horizontálního a vertikálního otočení a rotaci. Její hodnoty `FlipH` a `FlipV` používají [NullableBool](https://reference.aspose.com/slides/cs/cpp/aspose.slides/nullablebool/): `True` povolí otočení, `False` ho zakáže a `NotDefined` zachová nedefinovaný/výchozí stav.

Vstupní prezentace níže obsahuje jeden neotočený tvar.

![The shape before flipping](shape_to_be_flipped.png)

Příklad zachovává všechny ostatní hodnoty rámce a nahrazuje pouze dvě nastavení otočení. To je důležité, protože přiřazení nového [Frame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/set_frame/) nahrazuje celý rámec.

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

![The shape after flipping](flipped_shape.png)

## **Často kladené otázky**

**Mám používat index kolekce jako identifikátor tvaru?**

Pouze pro krátkodobé zpracování, kdy se kolekce před použitím indexu nezmění. Upřednostněte ověřenou konvenci `Name` nebo `AlternativeText` pro vytvořené šablony nebo `OfficeInteropShapeId` pro práci s interopem na úrovni snímku.

**Odstraňuje skrytí tvaru jeho pozici v Z‑orderu?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Lze jej najít, změnit pořadí, upravit nebo znovu zobrazit.

**Proč se klonovaný tvar objevil před jiným tvarem?**

`AddClone` přidá klon na konec kolekce, což představuje přední část Z‑orderu. Použijte `InsertClone` pro volbu počátečního indexu nebo `Reorder` po přidání všech tvarů.

**Mohu použít pevný index k identifikaci přednastavené úpravy tvaru?**

Pouze po ověření přesného přednastavení a rozložení kolekce. Upřednostněte iteraci přes `IGeometryShape::get_Adjustments` a kontrolu `IAdjustValue::get_Type`; použijte `IAdjustValue::get_Name` jako doplňující informaci, pokud se stejný sémantický typ vyskytuje vícekrát.