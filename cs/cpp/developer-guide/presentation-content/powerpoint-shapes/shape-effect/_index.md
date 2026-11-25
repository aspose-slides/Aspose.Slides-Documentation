---
title: "Použití efektů tvarů v prezentacích pomocí C++"
linktitle: "Efekt tvaru"
type: docs
weight: 30
url: /cs/cpp/shape-effect/
keywords:
- "efekt tvaru"
- "efekt stínu"
- "efekt odrazu"
- "efekt záře"
- "efekt měkkých hran"
- "formát efektu"
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Transformujte své soubory PPT a PPTX pomocí pokročilých efektů tvarů s Aspose.Slides pro C++ — vytvořte působivé, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [vyplnění](/slides/cs/cpp/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete vytvořit věrohodné odrazy na tvaru, rozprostřít záři tvaru atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Na tvar můžete použít jeden nebo více efektů.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu má PowerPoint možnosti pod **Preset**. Přednastavené možnosti jsou v podstatě kombinací dvou nebo více efektů, o nichž je známo, že spolu dobře fungují. Tím, že vyberete přednastavení, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli vhodnou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/), které vám umožňují použít stejné efekty na tvary v PowerPoint prezentacích.

## **Použití stínového efektu**

Aspose.Slides pro C++ podporuje vnější a vnitřní stíny pro tvary. Můžete přizpůsobit jejich barvu, směr, vzdálenost a radius rozostření, aby odpovídaly designu vaší prezentace.

### **Použití vnějšího stínu**

Použijte vnější stín, aby karta nebo panel vynikly na pozadí snímku. Stín přesahuje okraje tvaru a vytváří dojem, že je tvar vyvýšen nad snímkem. Upravením jeho barvy, směru, vzdálenosti a radiusu rozostření můžete přizpůsobit osvětlení a styl vaší šablony.

Tento C++ kód ukazuje, jak použít [vnější stín](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) na obdélník:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

presentation->Save(u"shadow_effect.pptx", SaveFormat::Pptx);
```

![Stínový efekt](shadow_effect.png)

### **Použití vnitřního stínu**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, abyste kartě nebo panelu dodali zapuštěný vzhled. Vnější stín se rozprostírá mimo tvar a dává mu vzhled vyvýšeného, zatímco vnitřní stín stínuje vnitřek jeho okrajů.

Zavolejte [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), poté nakonfigurujte [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Větší hodnoty radiusu rozostření vytvářejí měkčí okraje.

Tento C++ příklad vytvoří světle modrou kartu s tmavě šedým vnitřním stínem a uloží ji jako soubor PPTX:

```cpp
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_LightBlue());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

shape->get_EffectFormat()->EnableInnerShadowEffect();
auto shadow = shape->get_EffectFormat()->get_InnerShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_DimGray());
shadow->set_Direction(225);
shadow->set_Distance(7);
shadow->set_BlurRadius(6);

presentation->Save(u"inner_shadow_effect.pptx", SaveFormat::Pptx);
```

![Světle modrý obdélník s vnitřním stínem](inner_shadow_effect.png)

Pro odstranění vnitřního stínu zavolejte [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) na formát efektu tvaru.

### **Použití, změna a odebrání přednastaveného stínu**

Zavolejte [EnablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/enablepresetshadoweffect/) a použijte [set_Preset](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ipresetshadow/set_preset/) k výběru [PresetShadowType](https://reference.aspose.com/slides/cpp/aspose.slides/presetshadowtype/). Pro změnu stylu změňte přednastavení na stejném tvaru. Zavolejte [DisablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disablepresetshadoweffect/) pro odebrání stínu při zachování výplně a obrysu.

Tento příklad uchovává kopii obdélníku v každé fázi. Oba stíny jsou posunuty o 10 bodů. Směr 225° umístí první stín nad a vlevo od obdélníku a 45° umístí druhý pod a vpravo.

```cpp
#include <DOM/Effects/IPresetShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/PresetShadowType.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/enum.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(800, 120, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
auto outline = shape->get_LineFormat()->get_FillFormat();
outline->set_FillType(FillType::Solid);
outline->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
auto textFrame = shape->get_TextFrame();
textFrame->set_Text(u"No shadow");
textFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(14);
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnablePresetShadowEffect();
auto shadow = effectFormat->get_PresetShadowEffect();
shadow->set_Preset(PresetShadowType::TopLeftDropShadow);
shadow->set_Distance(10);
shadow->set_Direction(225);
textFrame->set_Text(System::Enum<PresetShadowType>::GetName(shadow->get_Preset()));
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
shadow->set_Preset(PresetShadowType::BottomRightDropShadow);
shadow->set_Direction(45);
textFrame->set_Text(System::Enum<PresetShadowType>::GetName(shadow->get_Preset()));
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
effectFormat->DisablePresetShadowEffect();
textFrame->set_Text(u"No shadow");

presentation->Save(u"preset_shadows.pptx", SaveFormat::Pptx);
```

| Původní | První přednastavení | Druhé přednastavení | Po odebrání |
| :---: | :---: | :---: | :---: |
| ![Bez stínu](preset_shadow_original.png) | ![Stín vlevo nahoře](preset_shadow_top_left.png) | ![Stín vpravo dole](preset_shadow_bottom_right.png) | ![Bez stínu po odebrání](preset_shadow_removed.png) |

## **Použití odrazového efektu**

Pro použití odrazového efektu v Aspose.Slides pro C++ můžete přidat k tvarům zrcadlový odraz a upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt zvyšuje estetiku vašich prezentací tím, že tvary získají uhlazenější a sofistikovanější vzhled. Je snadné jej implementovat pomocí jednoduchého kódu, což umožňuje rychlé použití napříč více prvky pro jednotný design.

Tento C++ kód ukazuje, jak použít [odrazový efekt](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) na tvar:

```cpp
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(40);
reflectionEffect->set_BlurRadius(2);

presentation->Save(u"reflection_effect.pptx", SaveFormat::Pptx);
```

![Odrazový efekt](reflection_effect.png)

## **Použití efektu záře**

Pro použití efektu záře na tvar v Aspose.Slides pro C++ můžete přidat jemnou, zářivou auru kolem tvarů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá tvarům vyniknout a přidává atraktivní, poutavý vizuální prvek do vaší prezentace. Je snadné jej implementovat s minimálním kódem, což zlepšuje celkový vzhled vašich snímků.

Tento C++ kód ukazuje, jak použít [efekt záře](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) na tvar:

```cpp
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Magenta());
glowEffect->set_Radius(15);

presentation->Save(u"glow_effect.pptx", SaveFormat::Pptx);
```

![Efekt záře](glow_effect.png)

## **Použití efektu měkkých hran**

Pro použití efektu měkkých hran v Aspose.Slides pro C++ můžete vytvořit hladký, rozmazaný přechod kolem okrajů tvaru. Tento efekt přidává jemnější a rafinovanější vzhled, ideální pro návrhy, které vyžadují jemný, měkčí vzhled. Můžete snadno upravit parametry jako radius, abyste dosáhli požadovaného efektu u různých tvarů ve vaší prezentaci.

Tento C++ kód ukazuje, jak použít [měkké hrany](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) na tvar:

```cpp
#include <DOM/Effects/ISoftEdge.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(8);

presentation->Save(u"soft_edges_effect.pptx", SaveFormat::Pptx);
```

![Efekt měkkých hran](soft_edges_effect.png)

## **Použití rozostření**

Použijte rozostření tvaru ke změkčení výplně a obrysu tvaru při zachování možnosti úprav. Zavolejte [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) na formát efektu tvaru. Radius se měří v bodech (1/72 palce): použijte nezápornou hodnotu, přičemž větší hodnoty vytvářejí silnější rozostření. Radius nula ponechává vzhled beze změny.

Nastavení [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) ovládá viditelné hranice efektu. Při hodnotě `false` je rozostření oříznuto na původní namalované hranice, včetně obrysu. Při hodnotě `true` může rozostření přesáhnout tyto hranice. Žádné nastavení nemění pozici ani rozměry tvaru.

Níže uvedené srovnání používá po celou dobu stejnou výplň, obrys a rozměry tvaru. Horní řada používá `grow = false`; spodní řada používá `grow = true`.

![Původní obdélník porovnaný s radiusy rozostření 5 a 15 bodů, s vypnutým a zapnutým grow](shape_blur_comparison.png)

Tento C++ příklad vytvoří oranžový obdélník s tmavě modrým obrysem, aplikuje rozostření 5 bodů a poté jej aktualizuje na rozostření 15 bodů opětovným zavoláním [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/). Uloží oba rozostřené stavy, poté zavolá [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) a uloží tvar bez rozostření.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 80.0f, 160.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
shape->get_LineFormat()->set_Width(8);

shape->get_EffectFormat()->SetBlurEffect(5, false);
presentation->Save(u"shape_blur_5.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->SetBlurEffect(15, true);
presentation->Save(u"shape_blur_15.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->DisableBlurEffect();
presentation->Save(u"shape_blur_removed.pptx", SaveFormat::Pptx);
```

Rozostření tvaru ovlivňuje výplň i obrys najednou. Efekt měkkých hran zeslabuje okraje tvaru, zatímco rozostření stínu změkčuje jen stín. Efekty transformace obrazu působí na obsah obrázku; tento příklad aplikuje rozostření přímo na formát efektu tvaru, aniž by tvar převáděl na obrázek.

## **Často kladené otázky**

**Mohu použít více efektů na stejný tvar?**

Ano, můžete kombinovat různé efekty, jako jsou stín, odraz a záře, na jediném tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty můžete aplikovat na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt se použije na celou skupinu.