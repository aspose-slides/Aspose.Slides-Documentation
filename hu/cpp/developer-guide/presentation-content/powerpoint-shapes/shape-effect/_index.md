---
title: Alakzat hatások alkalmazása bemutatókban C++ használatával
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/cpp/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- reflexiós hatás
- fénylő hatás
- lágy szélek hatás
- effektusformátum
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzateffektusokkal az Aspose.Slides for C++ segítségével - hozzon létre lenyűgöző, professzionális diákat másodpercek alatt."
---
## **Bevezetés**

Miközben a PowerPointban lévő effektusok segítségével egy alakzatot kiemel, különböznek a [kitöltésektől](/slides/hu/cpp/shape-formatting/#gradient-fill) vagy kontúroktól. PowerPoint effektusok használatával meggyőző tükröződéseket hozhat létre egy alakzaton, szórhatja az alakzat ragyogását stb.

![Alakzat hatás](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Bizonyos hatáskombinációk jobban néznek ki, mint mások. Emiatt a PowerPoint rendelkezik **Preset** opciókkal. A Preset beállítások lényegében két vagy több, együtt jól néző hatás kombinációját jelentik. Így egy előre beállított lehetőség kiválasztásával nem kell időt pazarolni különböző hatások tesztelésére vagy kombinálására egy jó kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) osztály alatt tulajdonságokat és metódusokat biztosít, amelyek lehetővé teszik ugyanazon hatások alkalmazását PowerPoint‑prezentációk alakzataira.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for C++ külső és belső árnyékokat támogat alakzatokhoz. Testreszabhatja azok színét, irányát, távolságát és elmosódási sugarát, hogy megfeleljen a bemutató tervezésének.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttérrel szemben. Az árnyék meghaladja az alakzat szélét, azt a benyomást keltve, hogy az alakzat a dia fölött emelkedik. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy illeszkedjen a sablon megvilágításához és stílusához.

Ez a C++ kód bemutatja, hogyan alkalmazzon [külső árnyékhatást](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) egy téglalapra:

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

![Árnyékhatás](shadow_effect.png)

### **Belső árnyék alkalmazása**

Sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy egy kártya vagy panel mélyedő megjelenést kapjon. A külső árnyék a forma kívülére nyúlik, és emelkedettnek mutatja, míg a belső árnyék az él belsejét árnyékolja.

Hívja meg a [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) metódust, majd konfigurálja a [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) beállításait. A nagyobb elmosódási sugár értékek lágyabb éleket eredményeznek.

Ez a C++ példa egy világos kék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti:

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

![Világoskék téglalap belső árnyékkal](inner_shadow_effect.png)

A belső árnyék eltávolításához hívja meg a [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) metódust az alakzat effektusformátumán.

## **Reflexiós hatás alkalmazása**

A reflexiós hatás alkalmazásához az Aspose.Slides for C++-ban tükröződéssel tudja ellátni az alakzatokat, a távolság, átlátszóság és méret paraméterek módosításával. Ez a hatás fokozza a bemutatók esztétikáját, kifinomultabb és polírozottabb megjelenést kölcsönözve az alakzatoknak. Egyszerű kóddal könnyen megvalósítható, gyorsan alkalmazható több elemre a konzisztens dizájn érdekében.

Ez a C++ kód bemutatja, hogyan alkalmazzon [reflexiós hatást](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) egy alakzatra:

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

![Reflexiós hatás](reflection_effect.png)

## **Ragyogás hatás alkalmazása**

A rágogás hatás egy alakzatra történő alkalmazásához az Aspose.Slides for C++‑ban lágy, fénylő aurát adhat az alakzatok köré, a szín és méret tulajdonságok beállításával. Ez a hatás segít kiemelni az alakzatokat, és vonzó, szemrevaló vizuális elemet ad a bemutatónak. Minimális kóddal könnyen megvalósítható, javítva a diák összképét.

Ez a C++ kód bemutatja, hogyan alkalmazzon [rágogás hatást](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) egy alakzatra:

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

![Ragyogás hatás](glow_effect.png)

## **Lágy szélek hatás alkalmazása**

A lágy szélek hatás alkalmazásához az Aspose.Slides for C++‑ban sima, elmosódott átmenetet hozhat létre az alakzat szélein. Ez a hatás finomabb és kifinomultabb megjelenést ad, tökéletes a gyengédebb, lágyabb kinézetet igénylő tervekhez. Könnyen állíthatja a paramétereket, például a sugárt, hogy a kívánt hatást elérje a bemutató különböző alakzatai között.

Ez a C++ kód bemutatja, hogyan alkalmazzon [lágy széleket](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) egy alakzatra:

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

![Lágy szélek hatás](soft_edges_effect.png)

## **Elmosódás hatás alkalmazása**

Használja az alakzat elmosódást a kitöltés és a kontúr lágyításához, miközben az alakzat szerkeszthető marad. Hívja meg a [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) metódust az alakzat effektusformátumán. A sugár pontokban van mérve (1/72 hüvelyk): használjon nem negatív értéket, a nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugár változatlanul hagyja a megjelenést.

A [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) beállítás szabályozza a hatás látható határait. `false` esetén az elmosódás az eredeti festett határokra, beleértve a kontúrt, lesz vágva. `true` esetén az elmosódás meghaladhatja ezeket a határokat. Egyik beállítás sem változtatja meg az alakzat pozícióját vagy méreteit.

Az alábbi összehasonlítás ugyanazt a kitöltést, kontúrt és alakzati méreteket használja mindenhol. A felső sor `grow = false` értéket, az alsó sor `grow = true` értéket alkalmazza.

![Eredeti téglalap 5 és 15 pont elmosódási sugárral összehasonlítva, a grow letiltva és engedélyezve](shape_blur_comparison.png)

Ez a C++ példa egy narancssárga téglalapot hoz létre sötétkék kontúrral, 5 pont elmosódást alkalmaz, majd egy újabb [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) hívással 15 pont elmosódásra frissíti. Mindkét elmosódott állapotot elmenti, majd a [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) hívás után elmenti az árnyék nélküli alakzatot.

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

Az alakzat elmosódás a kitöltést és a kontúrt együtt befolyásolja. A lágy szélek hatás elhalványítja az alakzat széleit, míg az árnyék elmosódás csak az árnyékot lágyítja. A képek átalakítási hatásai a kép tartalmán működnek; ez a példa közvetlenül az alakzat effektusformátumára alkalmaz elmosódást, anélkül, hogy az alakzatot képpé konvertálná.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, több különböző hatást, például árnyékot, reflexiót és ragyogást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, beleértve az automatikus alakzatokat, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok hatásokat csoportos alakzatokra?**

Igen, alkalmazhat hatásokat csoportos alakzatokra. A hatás az egész csoportra lesz alkalmazva.