---
title: Použití efektů tvarů v prezentacích pomocí C++
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
description: "Transformujte své soubory PPT a PPTX pomocí pokročilých efektů tvarů s Aspose.Slides pro C++ — vytvořte působivé, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [vyplnění](/slides/cs/cpp/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete na tvar vytvořit přesvědčivé odrazy, rozšířit záři tvaru atd.

![Shape effect](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Můžete použít jeden nebo více efektů na tvar.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu má PowerPoint možnosti pod **Preset**. Možnosti Preset jsou v podstatě kombinací dvou nebo více efektů, o kterých se ví, že spolu dobře ladí. Tímto způsobem, výběrem předvolby, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli vhodnou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/), které umožňují aplikovat stejné efekty na tvary v prezentacích PowerPoint.

## **Použití stínového efektu**

Aspose.Slides pro C++ podporuje vnější a vnitřní stíny pro tvary. Můžete přizpůsobit jejich barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly designu vaší prezentace.

### **Použití vnějšího stínu**

Použijte vnější stín, aby karta nebo panel vynikly oproti pozadí snímku. Stín přesahuje okraje tvaru a vytváří dojem, že je tvar nadsnímkem. Upravit jeho barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly osvětlení a stylu vaší šablony.

Tento kód C++ ukazuje, jak aplikovat [vnější stínový efekt](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) na obdélník:

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

![Shadow effect](shadow_effect.png)

### **Použití vnitřního stínu**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, abyste kartě nebo panelu dodali zapuštěný vzhled. Vnější stín se rozšiřuje mimo tvar a dává mu vzhled vyvýšeného, zatímco vnitřní stín stíní vnitřek jeho okrajů.

Zavolejte [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), poté nakonfigurujte [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Větší hodnoty poloměru rozostření produkují měkčí hrany.

Tento příklad C++ vytvoří světle modrou kartu s tmavě šedým vnitřním stínem a uloží ji jako soubor PPTX:

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Pro odebrání vnitřního stínu zavolejte [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) na formátu efektu tvaru.

## **Použití odrazového efektu**

Pro aplikaci odrazového efektu v Aspose.Slides pro C++ můžete přidat téměř zrcadlový odraz na tvary a upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt zlepšuje estetiku vašich prezentací tím, že tvarům dodává uhlazenější a sofistikovanější vzhled. Je snadný k implementaci pomocí jednoduchého kódu, což umožňuje rychlé použití napříč více prvky pro jednotný design.

Tento kód C++ ukazuje, jak aplikovat [odrazový efekt](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) na tvar:

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

![Reflection effect](reflection_effect.png)

## **Použití zářivého efektu**

Pro aplikaci zářivého efektu na tvar v Aspose.Slides pro C++ můžete přidat jemnou, světélkující auru kolem tvarů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá tvarům vyniknout a přidává atraktivní, poutavý vizuální prvek do vaší prezentace. Je snadný k implementaci s minimálním kódem a zlepšuje celkový vzhled vašich slidů.

Tento kód C++ ukazuje, jak aplikovat [zářivý efekt](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) na tvar:

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

![Glow effect](glow_effect.png)

## **Použití měkkých okrajů**

Pro aplikaci efektu měkkých okrajů v Aspose.Slides pro C++ můžete vytvořit plynulý, rozmazaný přechod kolem okrajů tvaru. Tento efekt přidává jemnější a vylepšený vzhled, ideální pro návrhy, které vyžadují jemný, měkčí vzhled. Jednoduše můžete upravit parametry jako poloměr, abyste dosáhli požadovaného efektu napříč různými tvary ve vaší prezentaci.

Tento kód C++ ukazuje, jak aplikovat [měkké okraje](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) na tvar:

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

![Soft edges effect](soft_edges_effect.png)

## **Použití rozostření**

Použijte rozostření tvaru k změkčení výplně a obrysu tvaru, přičemž tvar zůstane editovatelný. Zavolejte [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) na formátu efektu tvaru. Poloměr se měří v bodech (1/72 palce): použijte nezápornou hodnotu, větší hodnoty produkují silnější rozostření. Poloměr nula ponechá vzhled beze změny.

Nastavení [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) řídí viditelné hranice efektu. S `false` je rozostření oříznuto na původní malované hranice, včetně obrysu. S `true` může rozostření přesáhnout tyto hranice. Žádné nastavení nemění pozici ani rozměry tvaru.

Níže uvedené porovnání používá po celou dobu stejnou výplň, obrys a rozměry tvaru. Horní řada používá `grow = false`; spodní řada používá `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Tento příklad C++ vytvoří oranžový obdélník s tmavě modrým obrysem, použije rozostření 5 bodů a poté jej aktualizuje na rozostření 15 bodů opětovným zavoláním [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/). Uloží oba rozostřené stavy, pak zavolá [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) a uloží tvar bez rozostření.

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

Rozostření tvaru ovlivňuje výplň i obrys společně. Efekt měkkých okrajů zeslabení okrajů tvaru, zatímco rozostření stínu změkčuje jen stín. Efekty transformace obrazu pracují s obsahem obrázku; tento příklad aplikuje rozostření přímo na formát efektu tvaru, aniž by tvar převáděl na obrázek.

## **Často kladené otázky**

**Mohu na stejný tvar použít více efektů?**

Ano, můžete kombinovat různé efekty, jako stín, odraz a záři, na jednom tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty můžete aplikovat na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt se aplikuje na celou skupinu.