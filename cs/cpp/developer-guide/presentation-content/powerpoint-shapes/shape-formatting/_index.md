---
title: Formátování tvarů PowerPointu v C++
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/cpp/shape-formatting/
keywords:
- formátování tvaru
- formátování čáry
- skicový efekt
- skicová čára tvaru
- formátování stylu spojení
- gradientní výplň
- vzorová výplň
- obrázková výplň
- texturová výplň
- jednotnová výplň
- průhlednost tvaru
- černobílé vykreslení tvaru
- vykreslení v odstínech šedi
- otočení tvaru
- 3D efekt zkosení
- 3D efekt otáčení
- obnovení formátování
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, jak formátovat tvary PowerPointu v C++ pomocí Aspose.Slides - nastavit výplň, čáru a styly efektů pro soubory PPT a PPTX s přesností a plnou kontrolou."
---
## **Úvod**

Formátujte tvary v PowerPointu úpravou jejich obrysů, výplní a efektů. Aspose.Slides pro C++ vám umožňuje tato nastavení ovládat programově, včetně průhlednosti, otáčení a 3D formátování.

![Možnosti formátování tvaru v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides pro C++ poskytuje rozhraní a metody, které vám umožní formátovat tvary pomocí stejných možností dostupných v PowerPointu.

## **Formátování čar**

Použijte [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) k řízení obrysu tvaru. Tento příklad vytvoří nevyplněný obdélník s modrým, přerušovaným obrysem. [ILineFormat::set_Style](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_style/) vybírá složenou čáru tlustá‑ tenká, zatímco [ILineFormat::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) nastaví její šířku na 7 bodů a [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) vybírá vzor přerušení.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Formátované čáry v prezentaci](formatted-lines.png)

### **Nastavit vlastní vzory čárových přerušení**

Použijte [ILineFormat::set_CustomDashPattern](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_customdashpattern/) když předdefinované styly čar neposkytují požadované délky čárek a mezer, například pro značkové obrysy nebo technické diagramy. Přiřazením vzoru se automaticky změní styl čáry na [LineDashStyle::Custom](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/).

Položky pole střídavě uvádějí délky čárek a mezer, začínají čárou. Každá hodnota je násobkem šířky čáry: `{ 4, 2 }` při šířce 3 body vytváří 12‑bodovou čáru následovanou 6‑bodovou mezerou. Používejte dvojice konečných, nezáporných hodnot k definování kompletních úseků čára‑mezera. Příklad používá kladné hodnoty, aby byly všechny čáry a mezery viditelné.

Tento příklad vytvoří pět modrých čar se stejnou délkou a plochými konci. První tři porovnávají vzory při šířce 3 body. Čtvrtá opakuje první vzor při dvojnásobné šířce, čímž zdvojnásobí jak délky čárek, tak mezer. Pátá přepíná z vlastního vzoru na plnou čáru.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(600, 300, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto patterns = std::array<ArrayPtr<float>, 5>{
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 1, 2 }),
    MakeArray<float>({ 6, 2, 1, 2 }),
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 4, 2 })
};

for (auto i = 0; i < patterns.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 50, 50 + i * 50, 500, 0);
    line->get_LineFormat()->set_Width(i == 3 ? 6 : 3);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_CapStyle(LineCapStyle::Flat);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_CustomDashPattern(patterns[i]);
}

// Vrátit poslední čáru do plného stylu.
slide->get_Shape(4)->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);

presentation->Save(u"custom_dash_patterns.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Chcete-li se místo toho vrátit k předdefinovanému přerušovanému stylu, předávejte [LineDashStyle::Dash](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) do [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/). Vybraný styl řídí vzhled čáry.

Výsledek v PowerPointu, shora dolů: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; a **Solid, 3 pt**.

![Tři vlastní vzory čárových přerušení, širší čára používající první vzor a plná čára v PowerPointu](custom-dash-patterns.png)


### **Nastavit konce čar**

Použijte [ILineFormat::set_CapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_capstyle/) k nastavení konců otevřené čáry. Výčtové typy [LineCapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linecapstyle/) nabízí tři explicitní styly konců:

- `Flat`: Tah končí v koncovém bodě.
- `Round`: Polokruhový konec přesahuje za koncový bod o polovinu šířky čáry.
- `Square`: Čtvercový konec přesahuje za koncový bod o polovinu šířky čáry.

Výčet také obsahuje `NotDefined`, což znamená, že žádný styl konce není explicitně přiřazen.

Konce se liší od šipek, které přidávají symboly na konce čar, a od spojů, které řídí rohy mezi segmenty čar. Tento příklad vypíná šipky pomocí [ILineFormat::set_BeginArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_beginarrowheadstyle/) a [ILineFormat::set_EndArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_endarrowheadstyle/), aby se porovnávaly pouze tvary konců.

Následující příklad vytvoří tři jinak identické vodorovné čáry o šířce 20 bodů. Shora dolů používají konce flat, round a square. Jejich koncové body mají stejné horizontální souřadnice; kulaté a čtvercové konce přesahují o 10 bodů za každý koncový bod.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 240, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto capStyles = std::array<LineCapStyle, 3>{ LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square };

for (auto i = 0; i < capStyles.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 100, 50 + i * 70, 300, 0);
    line->get_LineFormat()->set_Width(20);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);
    line->get_LineFormat()->set_CapStyle(capStyles[i]);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
}

presentation->Save(u"line_caps.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek v PowerPointu, shora dolů: **Flat**, **Round** a **Square**.

![Plochý, kulatý a čtvercový konec na identických silných čarách v PowerPointu](line-caps.png)

## **Použít skicové efekty na čáry tvaru**

Skicový efekt způsobí, že čára tvaru vypadá ručně kreslená. Použijte [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) pro přístup k nastavením čáry, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) pro přístup k nastavením skici a [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) pro výběr hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/).

Následující kód C++ ukazuje, jak aplikovat efekt [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) , načíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();
sketchFormat->set_SketchType(LineSketchType::Curved);
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

Hodnota vrácená metodou [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavní snímku nebo rozložení, použijte [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), přistupte k [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), a načtěte [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení dědičnosti. Tento příklad vyžaduje existující prezentaci s alespoň jedním tvarem na prvním snímku a vypíše obě hodnoty:

```cpp
#include <DOM/ILineFormat.h>
#include <DOM/ILineFormatEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISketchFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto lineFormat = shape->get_LineFormat();
auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);
presentation->Dispose();
```

## **Formátování stylů spojů**

Zde jsou tři možnosti typu spojení:

* Round
* Miter
* Bevel

Styl spoje určuje, jak se dva obrysové segmenty setkávají v rohu. Použijte **Round** pro zaoblené rohy, **Miter** pro ostré rohy nebo **Bevel** pro zploštělé rohy.

![Styl spoje v prezentaci](join-style-powerpoint.png)

Tento příklad vytvoří tři černé obdélníky s modrými obrysy o šířce 15 bodů. Nastavuje [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) na hodnoty miter, bevel a round z [LineJoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/), aby porovnal, jak jsou rohy vykresleny.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto miterShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto bevelShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto roundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

miterShape->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
bevelShape->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
roundShape->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

miterShape->get_LineFormat()->set_Width(15);
bevelShape->get_LineFormat()->set_Width(15);
roundShape->get_LineFormat()->set_Width(15);

miterShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
bevelShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
roundShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

miterShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
bevelShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
roundShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

miterShape->get_TextFrame()->set_Text(u"Miter Join Style");
bevelShape->get_TextFrame()->set_Text(u"Bevel Join Style");
roundShape->get_TextFrame()->set_Text(u"Round Join Style");

presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Omezit miterové spoje u ostrých rohů**

Použijte [ILineFormat::set_MiterLimit](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_miterlimit/) spolu s [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) nastaveným na [LineJoinStyle::Miter](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/), aby omezil, jak daleko může ostrý roh vystupovat.

Limit je poměr vzdálenosti mezi vnitřním a vnějším rohem spoje k šířce čáry. Například hodnota `8` umožňuje délku miteru až osmkrát větší než šířka čáry; nejde o měření v bodech. Pokud by roh překročil limit, PowerPoint použije na tomto místě čelistový spoj. Větší limit umožňuje ostřejší špičky. Nastavení ovlivňuje pouze miterové spoje a jeho změna nemá viditelný efekt, pokud roh zůstává v rámci obou limitů.

Tento příklad vytvoří dva identické, nevyplněné trojúhelníky s obrysy o šířce 20 bodů. Levý trojúhelník používá limit `2` a pravý `8`. Každý trojúhelník je široký 80 bodů a vysoký 160 bodů, což dává jeho hornímu rohu poměr délky miteru k šířce čáry přibližně `4.12`. V důsledku toho PowerPoint zploští levý vrchol a zachová pravý vrchol.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 320, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto miterLimits = std::array<float, 2>{ 2.0f, 8.0f };

for (auto i = 0; i < miterLimits.size(); i++)
{
    auto triangle = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 90 + i * 240, 110, 80, 160);
    triangle->get_FillFormat()->set_FillType(FillType::NoFill);
    triangle->get_LineFormat()->set_Width(20);
    triangle->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    triangle->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    triangle->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
    triangle->get_LineFormat()->set_MiterLimit(miterLimits[i]);
}

presentation->Save(u"miter_limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek v PowerPointu: **Miter limit 2** vlevo a **miter limit 8** vpravo.

![Zploštělý vrchol s miter limitem 2 a špičatý vrchol s miter limitem 8 v PowerPointu](miter-limits.png)

## **Gradientní výplň**

Gradientní výplň míchá barvy přes tvar. Tento příklad vyplní elipsu lineárním gradientem pod úhlem 45 stupňů od červené po fialovou pomocí [IFillFormat::get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_gradientformat/). Metoda [IGradientStopCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/igradientstopcollection/add/) umístí barevné zastávky na 0 a 1, na začátek a konec gradientu. Vymazání existujících zastávek zajišťuje, že jsou použity jen tyto dvě barvy.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);
shape->get_FillFormat()->get_GradientFormat()->set_LinearGradientAngle(45);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Clear();
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Elipsa s gradientní výplní](gradient-fill.png)

Pokud gradient v exportovaném obrázku vypadá jinak než v PowerPointu, viz [Choose a Gradient Rendering Style](/slides/cs/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Můžete vybrat styl vykreslení bez změny gradientní výplně uložené v prezentaci.

### **Nastavit úhel lineárního gradientu**

Použijte [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) k řízení orientace výplně [GradientShape::Linear](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/). Úhel se měří ve stupních a roste po směru hodinových ručiček: `0` běží zleva doprava, `90` shora dolů, `180` zprava doleva a `270` zdola nahoru. Zlomkové úhly jsou podporovány. Konečné úhly mimo interval `[0, 360)` jsou normalizovány na jeden oběh; například `-45` se stane `315` a `360` se stane `0`.

Tento příklad vytvoří šest obdélníků se stejnými červenými, zelenými a modrými zastávkami na pozicích `0`, `0.5` a `1`. Škálování je vypnuto, aby se úhel mohl porovnávat nezávisle na proporcích obdélníků. Úhly, zleva doprava, jsou `0`, `45` a `90` v první řadě a `135`, `180` a `270` ve druhé řadě.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto angles = std::array<float, 6>{ 0, 45, 90, 135, 180, 270 };

for (auto i = 0; i < angles.size(); i++)
{
    auto x = 30 + (i % 3) * 230;
    auto y = 30 + (i / 3) * 190;

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 200, 150);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::False);
    gradient->set_LinearGradientAngle(angles[i]);
}

presentation->Save(u"linear_gradient_angles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek v PowerPointu:

![Lineární gradienty při 0, 45 a 90 stupních v horní řadě a 135, 180 a 270 stupních ve spodní řadě](linear-gradient-angles.png)

### **Škálovat lineární gradient s tvarem**

[IGradientFormat::set_LinearGradientScaled](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientscaled/) přijímá [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/). Nastavte jej explicitně na `False`, aby se geometrický úhel gradientu zachoval při změně proporcí tvaru, nebo na `True`, aby se gradient škáloval se šířkou a výškou tvaru. Při povoleném škálování se viditelný úhel může lišit od přiřazeného úhlu u nečtvercového tvaru.

Následující příklad používá úhel `45` stupňů a stejné barevné zastávky jako při porovnání úhlů. Levý sloupec používá `False`; pravý sloupec používá `True`. Každý sloupec obsahuje široký obdélník nad vysokým obdélníkem. Oba začínají se stejnými širokými rozměry; změna šířky a výšky druhého obdélníku ukazuje, jak výplň reaguje na změnu velikosti bez změny nastavení gradientu.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 460, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto scalingOptions = std::array<NullableBool, 2>{ NullableBool::False, NullableBool::True };

for (auto column = 0; column < scalingOptions.size(); column++)
{
    for (auto row = 0; row < 2; row++)
    {
        auto x = 30 + column * 360;
        auto y = row == 0 ? 30 : 150;

        auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 300, 90);
        shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
        shape->get_FillFormat()->set_FillType(FillType::Gradient);

        auto gradient = shape->get_FillFormat()->get_GradientFormat();
        gradient->set_GradientShape(GradientShape::Linear);
        gradient->get_GradientStops()->Clear();
        gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
        gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
        gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
        gradient->set_LinearGradientAngle(45);
        gradient->set_LinearGradientScaled(scalingOptions[column]);

        if (row == 1)
        {
            shape->set_Width(90);
            shape->set_Height(280);
        }
    }
}

presentation->Save(u"linear_gradient_scaling.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek v PowerPointu, se škálováním vypnutým vlevo a zapnutým vpravo:

![Široké a vysoké obdélníky s 45‑stupňovým gradientem, porovnání LinearGradientScaled False vlevo a True vpravo](linear-gradient-scaling.png)

Při vypnutém škálování diagonální barevné pásy zachovávají stejnou orientaci v obou obdélnících. Při zapnutém škálování se pásy natáhnou podle proporcí tvaru. To pomáhá reprodukovat gradient šablony při přizpůsobení tvaru na jinou velikost. U čtverce povolení škálování nemění vzhled tohoto `45`‑stupňového gradientu.

Jak úhel, tak nastavení škálování se vztahují na lineární gradienty. Neovlivňují výplně [GradientShape::Radial nebo GradientShape::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/).

### **Kombinovat úhel se směrem gradientu**

[IGradientFormat::set_GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_gradientdirection/) vybírá styl gradientu z výčtu [GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/gradientdirection/). Není náhradou za číselný úhel. Pro lineární gradient mohou styly rohů měnit oblast, na kterou jsou barvy rozloženy, aniž by se změnil úhel přiřazený pomocí [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/). Při porovnávání úhlů nebo škálování ponechte směr nezměněný.

Následující příklad aplikuje stejná nastavení v opačném pořadí. Oba obdélníky mají stejný vzhled: přiřazení směru před nebo po úhlu nemění výsledek.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30 + i * 140, 320, 100);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::True);

    if (i == 0)
    {
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
        gradient->set_LinearGradientAngle(30);
    }
    else
    {
        gradient->set_LinearGradientAngle(30);
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
    }
}

presentation->Save(u"linear_gradient_direction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Vzorová výplň**

Vzorová výplň aplikuje dvoubarevný design, například tečky, pruhy nebo šachovnici. Tento příklad používá [IPatternFormat::set_PatternStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/set_patternstyle/) , aby vybral vzor trellis. [IPatternFormat::get_BackColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) poskytuje světle šedé pozadí a [IPatternFormat::get_ForeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) poskytuje žlutou barvu vzoru.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Pattern);
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Obdélník s vzorovou výplní](pattern-fill.png)

## **Obrázková výplň**

Obrázková výplň používá obrázek uvnitř tvaru. Tento příklad vyžaduje místní obrázek a používá [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) , aby jej načetl do kolekce obrázků prezentace. Nastavení [IPictureFillFormat::set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) na režim dlaždic opakuje obrázek v obdélníku. Zdrojový obrázek použitý zde je zobrazen níže:

![Obrázek lotosu](lotus.png)

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

auto image = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(image);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(presentationImage);

presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
image->Dispose();
presentation->Dispose();
```

Výsledek:

![Tvar s obrázkovou výplní](picture-fill.png)

### **Umístit obrázek jako texturu**

Pokud chcete nastavit dlaždicový obrázek jako texturu a přizpůsobit chování dláždění, můžete použít následující metody rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) a třídy [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) :

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Nastavuje režim obrázkové výplně — buď `Tile`, nebo `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Určuje zarovnání dlaždic uvnitř tvaru.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Ovládá, zda je dlaždice převrácena horizontálně, vertikálně nebo obojí.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Nastavuje horizontální posun dlaždice (v bodech) od počátku tvaru.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Nastavuje vertikální posun dlaždice (v bodech) od počátku tvaru.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definuje horizontální škálování dlaždice v procentech.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definuje vertikální škálování dlaždice v procentech.

Tento příklad vyžaduje místní obrázek a konfiguruje [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) , aby jej opakoval na 50 % původní velikosti. Posuny −32 bodů posunou dlaždice horizontálně i vertikálně; zarovnání vpravo dole a převracení v obou směrech určuje, jak je opakovaná textura uspořádána.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);

auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
shape->get_FillFormat()->set_FillType(FillType::Picture);

auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);

auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

presentation->Save(u"tile.pptx", SaveFormat::Pptx);
sourceImage->Dispose();
presentation->Dispose();
```

Výsledek:

![Možnosti dláždění](tile-options.png)

## **Jednotnová výplň**

Jednotnová výplň dává tvaru jednu, jednotnou barvu. Tento příklad nastaví [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) , na režim jednotnové výplně a přiřadí žlutou barvu pomocí [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) , poté uloží obdélník do prezentace.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Tvar s jednotnovou výplní](solid-color-fill.png)

### **Kopírovat barvy při zachování odkazů na motiv**

Použijte [IColorFormat::CopyFrom](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/copyfrom/) , aby se zkopírovala definice barvy, včetně typu barvy, odkazu na motiv a transformací. To je užitečné při přenosu barvy výplně mezi tvary, které by měly nadále sledovat motiv prezentace. Metoda kopíruje pouze barvu: nekopíruje typ výplně, obrys ani jiné formátování tvaru. Nastavte typ výplně cíle explicitně pomocí [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) .

Tento příklad vytvoří tři obdélníky, zleva doprava: zdroj, kopii respektující motiv a pevnou RGB kopii. Zdroj používá [IColorFormat::set_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/set_schemecolor/) , aby odkazoval na první akcentní barvu a přidává odstín pomocí [IColorOperationCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icoloroperationcollection/add/) . RGB kopie používá efektivní výplňovou barvu zdroje, takže všechny tři vypadají zpočátku identicky. Voláním [IColorFormat::set_Color](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/set_color/) se nastaví pevná RGB hodnota a vymažou se všechny existující transformace barvy.

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(660, 220, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

presentation->get_MasterTheme()->get_ColorScheme()->get_Accent1()->set_Color(Color::get_RoyalBlue());

auto source = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
auto themeCopy = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
auto rgbCopy = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

for (auto shape : { source, themeCopy, rgbCopy })
{
    shape->get_FillFormat()->set_FillType(FillType::Solid);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
}

auto sourceColor = source->get_FillFormat()->get_SolidFillColor();
sourceColor->set_SchemeColor(SchemeColor::Accent1);
sourceColor->get_ColorTransform()->Add(ColorTransformOperation::Tint, 0.75f);

themeCopy->get_FillFormat()->get_SolidFillColor()->CopyFrom(sourceColor);
auto effectiveFill = source->get_FillFormat()->GetEffective();
rgbCopy->get_FillFormat()->get_SolidFillColor()->set_Color(effectiveFill->get_SolidFillColor());

auto before = slide->GetImage(1.0f, 1.0f);
before->Save(u"color-copy-before.png", ImageFormat::Png);
before->Dispose();

// Theme references follow the new accent color; the fixed RGB value does not.
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent1()->set_Color(Color::get_OrangeRed());

auto after = slide->GetImage(1.0f, 1.0f);
after->Save(u"color-copy-after.png", ImageFormat::Png);
after->Dispose();
presentation->Save(u"copied_colors.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Před změnou motivu všechny tři výplně odpovídají:

![Zdroj, cíl CopyFrom a pevný RGB cíl s identickými modrými výplněmi](color-copy-before.png)

Po změně motivu zdroj a kopie respektující motiv následují novou akcentní barvu a zachovávají svůj odstín. Pevná RGB kopie zůstává modrá:

![Zdroj a cíl CopyFrom s oranžovými výplněmi, zatímco pevný RGB cíl zůstává modrý](color-copy-after.png)

Zkopírovaná definice je nezávislá na zdroji. Následná změna odkazu zdroje na motiv, přiřazení jiné barvy nebo přidání či odebrání jeho transformací nemění cíl. Změna motivu stále ovlivní oba tvary, protože každý nezávisle odkazuje na stejnou barvu motivu.

Ukládání a opětovné otevření souboru PPTX zachovává typ zkopírované barvy, dostupný přes [IColorFormat::get_ColorType](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_colortype/) , její odkaz na motiv a kolekci transformací vrácenou metodou [IColorFormat::get_ColorTransform](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_colortransform/) . Definice se neflattenuje na RGB.

Při kopírování mezi různými kontexty motivů, například mezi prezentacemi s různými akcentními paletami, se zkopírován odkaz rozřeší vůči motivu cíle. Stejný odkaz a transformace tak mohou vytvořit jinou viditelnou barvu. Viz [Presentation Theme](/slides/cs/cpp/presentation-theme/) pro více informací o konfiguraci barev motivu.

## **Použít pozadí snímku jako výplň tvaru**

Použijte [IAutoShape::set_UseBackgroundFill](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/set_usebackgroundfill/) , když by tvar měl odpovídat pozadí snímku, například v šabloně prezentace. Nejprve nastavte [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) , na [FillType::NotDefined](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) , aby se odstranila jakákoli explicitní výplň. S touto kombinací tvar používá pozadí snímku místo své stylové výplně. Pouze povolení příznaku neodstraní existující explicitní výplň.

Liší se to od [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) : výplň pozadí zakrývá objekty za tvarem odpovídající oblastí pozadí snímku, zatímco žádná výplň ponechává tyto objekty viditelné. Gradient zůstává zarovnán se snímkem namísto restartování uvnitř každého tvaru.

Následující příklad vytvoří hlavní pozadí zděděné snímkem a umístí fialový pruh za tři obdélníky. Levý obdélník používá pozadí, prostřední obdélník nemá výplň a pravý obdélník přepíná z výplně pozadí na explicitní oranžovou výplň.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

// Zdědit gradient z masteru.
slide->get_Background()->set_Type(BackgroundType::NotDefined);
slide->get_LayoutSlide()->get_Background()->set_Type(BackgroundType::NotDefined);
auto background = slide->get_LayoutSlide()->get_MasterSlide()->get_Background();
background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Gradient);
auto gradient = background->get_FillFormat()->get_GradientFormat();
gradient->set_GradientShape(GradientShape::Linear);
gradient->set_LinearGradientAngle(0);
gradient->get_GradientStops()->Clear();
gradient->get_GradientStops()->Add(0, Color::get_DarkBlue());
gradient->get_GradientStops()->Add(1, Color::get_LightSkyBlue());

// Přidejte tento objekt jako první, aby byl za obdélníky.
auto band = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Magenta());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto backgroundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
backgroundShape->get_FillFormat()->set_FillType(FillType::NotDefined);
backgroundShape->set_UseBackgroundFill(true);

auto noFillShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
noFillShape->get_FillFormat()->set_FillType(FillType::NoFill);

auto explicitShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
explicitShape->get_FillFormat()->set_FillType(FillType::NotDefined);
explicitShape->set_UseBackgroundFill(true);

// Zakázat výplň pozadí před aplikací explicitní výplně.
explicitShape->set_UseBackgroundFill(false);
explicitShape->get_FillFormat()->set_FillType(FillType::Solid);
explicitShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

presentation->Save(u"background_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek, zleva doprava: **background fill**, **no fill** a **explicit fill**. Fialový pruh je skrytý levým a pravým obdélníkem, ale zůstává viditelný skrze prostřední obdélník.

![Výplň pozadí, žádná výplň a explicitní oranžová výplň nad fialovým pruhem](background-fill.png)

Stejné chování platí pro pozadí definované přímo na snímku nebo zděděné z rozvržení. Tvar používá rozpoznané pozadí snímku; v příkladu jsou pozadí snímku i rozvržení nedefinována, takže ho poskytuje hlavní šablona.

## **Nastavit průhlednost**

U jednotnové výplně komponenta alfa barvy řídí neprůhlednost: 0 je zcela průhledná a 255 je zcela neprůhledná. Tento příklad používá hodnotu alfa 128 pro žlutý obdélník, čímž je přibližně 50 % průhledný, takže pod ním ležící obdélník zůstává viditelný. Barva je přiřazena pomocí [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) .

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const int alpha = 128;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, Color::get_Yellow()));

presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Průhledný tvar](shape-transparency.png)

## **Otáčet tvary**

Použijte [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) , abyste otáčeli tvar v rovině snímku. Úhel se měří ve stupních; tento příklad otáčí obdélník o 5 stupňů po směru hodinových ručiček a uloží prezentaci.

```cpp
#include <DOM/IAutoShape>

#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto  slide  = presentation‑>  get_Slide( 0 ); 

auto  shape  = slide    ‑>  get_Shapes()‑>AddAutoShape( ShapeType::Rectangle, 50, 50, 150, 75 );
shape‑>set_Rotation(5);

presentation->Save(u"shape_rotation.pptx",  Save Format  ​  (Ppt ­ ­ ​ ​ ​ ​​‾
 
```

Výsledek:

![Otáčení tvaru](shape-rotation.png)

## **Přidat 3D efekty zkosení**

Použijte [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) , aby tvar získal hloubku a zkosené hrany. Tento příklad vytvoří zelenou elipsu s oranžovým obrysem, nastaví [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) na 4 body a aplikuje kruhový horní zkosení s šířkou a výškou 6 bodů pomocí [IThreeDFormat::get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) . Frontální ortografická kamera a tříbodové nasvícení zobrazí zkosení.

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);
shape->get_ThreeDFormat()->set_Depth(4);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![3D efekt zkosení](3D-bevel-effect.png)

## **Přidat 3D efekty otáčení**

3D pohled tvaru je řízen nastavením kamery. Tento příklad používá [ICamera::SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) s úhly latitude, longitude a revoluce 40, 35 a 20 stupňů. Vybere izometrickou kameru pomocí [ICamera::set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) a vyvážené osvětlení pomocí [ILightRig::set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) , poté uloží formátovaný obdélník.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
autoShape->get_TextFrame()->set_Text(u"Hello, Aspose!");
autoShape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
autoShape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
autoShape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![3D efekt otáčení](3D-rotation-effect.png)

## **Ovládat černobílé vykreslení pro tvary**

Metoda [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) určuje, jak je jednotlivý tvar vykreslen, když je prezentace zobrazována nebo zpracovávána v černobílém režimu. Sama o sobě neaktivuje černobílé zobrazení a nemění výplň, čáru ani jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu z výčtu [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) , abyste vybrali požadované chování. Například `Automatic` nechá aplikaci pro vykreslování zvolit konverzi, `Gray` a `LightGray` používají šedé zbarvení, `BlackWhite` používá jen černou a bílou, `Black` a `White` vynutí jedinou barvu, `Color` zachovává běžné barevné zobrazení a `Hidden` vynechá tvar v černobílém režimu. `NotDefined` znamená, že žádný režim na úrovni tvaru není přiřazen.

Tento příklad vytvoří oranžový obdélník a nastaví [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) na šedou. Uložený tvar si zachová oranžovou výplň pro běžné barevné zobrazení a požaduje šedé zbarvení od aplikací, které respektují nastavení černobílého zobrazení:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

V normálním barevném režimu obdélník zachovává oranžovou výplň. V černobílém pracovním postupu používá šedé zbarvení, protože jeho režim je nastaven na `Gray`. To vám umožní zachovat celobarevný snímek a zároveň definovat odlišný vzhled pro tisk, náhled nebo jiné pracovní postupy, které respektují nastavení černobílého zobrazení prezentace.

## **Obnovit formátování**

Použijte [ISlide::Reset](https://reference.aspose.com/slides/cpp/aspose.slides/islide/reset/) , abyste obnovili pozici, velikost a formátování zástupných objektů snímku z jejich odpovídajících zástupných objektů rozvržení. Tento příklad vyžaduje existující prezentaci s placeholdery propojenými s rozvržením a před uložením obnoví každý snímek. Tvary bez odpovídajících placeholderů rozvržení nejsou obnoveny.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Ovlivňuje formátování tvarů konečnou velikost souboru prezentace?**

Barvy, styly čar a nastavení efektů obecně přidávají málo dat ve srovnání se vloženými obrázky a médii. Obrázkové výplně mohou zvýšit velikost souboru, protože jejich obrázky jsou uloženy v prezentaci.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru — výplň, čáru a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky seskupte tyto tvary, což usnadní pozdější správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte vzorové tvary s požadovanými styly do šablony prezentace nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, naklonujte potřebné stylované tvary a znovu aplikujte jejich formátování tam, kde je potřeba.