---
title: Aplikace efektů tvarů v prezentacích pomocí C++
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/cpp/shape-effect/
keywords:
- efekt tvaru
- efekt stínu
- efekt odrazu
- efekt záře
- efekt měkkých okrajů
- formát efektu
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Transformujte své soubory PPT a PPTX pomocí pokročilých efektů tvarů v Aspose.Slides pro C++ — vytvořte působivé, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [výplní](/slides/cs/cpp/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit záři tvaru atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Na tvar můžete použít jeden nebo více efektů.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu má PowerPoint možnosti pod **Preset**. Možnosti Preset jsou v podstatě kombinace dvou nebo více efektů, o nichž je známo, že vypadají dobře. Takto, výběrem předvolby, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů k nalezení pěkné kombinace.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/), které vám umožní použít stejné efekty na tvary v prezentacích PowerPoint.

## **Použití stínového efektu**

Aspose.Slides for C++ podporuje vnější a vnitřní stíny pro tvary. Můžete přizpůsobit jejich barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly návrhu vaší prezentace.

### **Použití vnějšího stínu**

Použijte vnější stín, aby karta nebo panel vynikl na pozadí snímku. Stín přesahuje okraje tvaru a vytváří dojem, že tvar je nad snímkem. Přizpůsobte jeho barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly osvětlení a stylu vaší šablony.

Tento C++ kód ukazuje, jak použít [vnější efekt stínu](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) na obdélník:

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

![Efekt stínu](shadow_effect.png)

### **Použití vnitřního stínu**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, který kartě nebo panelu dodá zapuštěný vzhled. Vnější stín se rozprostírá mimo tvar a dává dojem, že je zvýšený, zatímco vnitřní stín ztmavuje vnitřní část jeho okrajů.

Zavolejte [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), poté nakonfigurujte [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Větší hodnoty poloměru rozostření vytvářejí měkčí hrany.

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

Pro odebrání vnitřního stínu zavolejte [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) na formát efektu tvaru.

## **Použití odrazového efektu**

Chcete-li použít odrazový efekt v Aspose.Slides pro C++, můžete přidat zrcadlový odraz na tvary a upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt zvyšuje estetiku vašich prezentací tím, že tvary získají uhlazenější a sofistikovanější vzhled. Je snadné jej implementovat pomocí jednoduchého kódu, což umožňuje rychlé použití na více elementech pro jednotný design.

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

![Efekt odrazu](reflection_effect.png)

## **Použití efektu záře**

Chcete-li použít efekt záře na tvar v Aspose.Slides pro C++, můžete přidat měkkou, zářivou auru kolem tvarů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá zvýraznit tvary a přidává atraktivní, poutavý vizuální prvek do vaší prezentace. Je snadné jej implementovat s minimálním kódem, což vylepšuje celkový vzhled vašich snímků.

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

## **Použití efektu měkkých okrajů**

Chcete-li použít efekt měkkých okrajů v Aspose.Slides pro C++, můžete vytvořit plynulý, rozostřený přechod kolem okrajů tvaru. Tento efekt dodává jemnější a rafinovanější vzhled, ideální pro návrhy, které vyžadují jemný, měkčí vzhled. Parametry jako poloměr lze snadno upravit tak, aby se dosáhlo požadovaného efektu na různých tvarech ve vaší prezentaci.

Tento C++ kód ukazuje, jak použít [měkké okraje](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) na tvar:

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

![Efekt měkkých okrajů](soft_edges_effect.png)

## **FAQ**

**Mohu použít více efektů na stejný tvar?**

Ano, můžete kombinovat různé efekty, jako jsou stín, odraz a záře, na jednom tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu použít efekty?**

Efekty můžete použít na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu použít efekty na seskupené tvary?**

Ano, můžete použít efekty na seskupené tvary. Efekt bude aplikován na celou skupinu.