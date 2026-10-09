---
title: Alakzat hatások alkalmazása bemutatókban C++ használatával
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/cpp/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- tükröződés hatás
- ragyogás hatás
- lágy szél hatás
- hatás formátum
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat-hatásokkal az Aspose.Slides for C++ segítségével — percek alatt hozhat létre figyelemfelkeltő, professzionális diákat."
---
## **Bevezetés**

Miközben a PowerPoint hatásait arra lehet használni, hogy egy alakzat kiemelkedjen, különböznek a [kitöltésektől](/slides/hu/cpp/shape-formatting/#gradient-fill) vagy a körvonalaktól. PowerPoint hatásokkal meggyőző tükröződéseket hozhat létre egy alakzaton, elnyúló ragyogást stb.

![Alakzat hatás](shape-effect.png)

A PowerPoint hat hat effektust biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást alkalmazhat egy alakzatra.

Egyes hatáskombinációk jobban néznek ki, mint mások. Emiatt a PowerPointnek vannak **Preset** opciói. A Preset opciók lényegében egy olyan kombinációt jelentenek, amelyik két vagy több hatásból áll és jó vizuálisan. Így egy előbeállítást kiválasztva nem kell időt vesztegetnie a különböző hatások tesztelésével vagy kombinálásával, hogy szép kombinációt találjon.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) osztályban biztosít tulajdonságokat és metódusokat, amelyekkel ugyanazokat a hatásokat alkalmazhatja a PowerPoint bemutatók alakzataira.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for C++ támogatja a külső és belső árnyékokat alakzatoknál. Testreszabhatja a színüket, irányukat, távolságukat és elmosódási sugarukat, hogy illeszkedjenek a bemutató dizájnjához.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttéréből. Az árnyék meghaladja az alakzat szélét, így úgy tűnik, mintha az alakzat a dia fölött lenne. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy megfeleljen a sablon megvilágításának és stílusának.

Ez a C++ kód bemutatja, hogyan lehet a [külső árnyék hatást](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) egy téglalapra alkalmazni:
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

![Árnyék hatás](shadow_effect.png)

### **Belső árnyék alkalmazása**

Ha egy sablon vizuális stílusát reprodukálja, használjon belső árnyékot, hogy a kártya vagy panel recesszív megjelenést kapjon. A külső árnyék az alakzat kívülére nyúlik, és azt a benyomást kelti, hogy az fel van emelve, míg a belső árnyék az alakzat belső széleit árnyékolja.

Hívja meg az [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) függvényt, majd konfigurálja az [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) beállítást. A nagyobb elmosódási sugár értékek lágyabb szegélyeket eredményeznek.

Ez a C++ példa egy világoskék kártyát hoz létre sötét szürke belső árnyékkal, majd PPTX fájlként menti:
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

A belső árnyék eltávolításához hívja meg a [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) függvényt az alakzat effektusformátumán.

## **Tükröződés hatás alkalmazása**

A PowerPoint prezentációkban a tükröződés hatás javítja a vizuális megjelenést, egy tükörszerű visszaverődést ad az alakzatoknak, állítható a távolság, átlátszatlanság és méret. Ez a hatás elegánsabbá és professzionálisabbá teszi a diákat, könnyen megvalósítható egyszerű kóddal, és gyorsan alkalmazható több elemre a konzisztens dizájn érdekében.

Ez a C++ kód bemutatja, hogyan lehet a [tükröződés hatást](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) egy alakzatra alkalmazni:
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

![Tükröződés hatás](reflection_effect.png)

## **Ragyogás hatás alkalmazása**

A C++-ban a ragyogás hatással lágy, fényes aurát adhat az alakzatok köré, beállítható a szín és a méret. Ez a hatás segít kiemelni az alakzatokat, és vonzó, szemfelkeltő vizuális elemet ad a prezentációnak. Könnyen megvalósítható minimális kóddal, növelve a diák teljes megjelenését.

Ez a C++ kód bemutatja, hogyan lehet a [ragyogás hatást](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) egy alakzatra alkalmazni:
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

## **Lágy szél hatás alkalmazása**

A C++-ban a lágy szél hatással sima, elmosódott átmenetet hozhat létre az alakzat szélén. Ez a hatás finomabb, kifinomultabb megjelenést ad, tökéletes azokhoz a tervezésekhez, amelyeknek enyhe, lágy megjelenésre van szükségük. A sugár paraméter egyszerűen állítható, hogy a kívánt hatást elérje a prezentáció különböző alakzataiban.

Ez a C++ kód bemutatja, hogyan lehet a [lágy szél](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) hatást egy alakzatra alkalmazni:
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

![Lágy szél hatás](soft_edges_effect.png)

## **FAQ**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat, például árnyékot, tükröződést és ragyogást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, köztük autoshape-ekre, diagramokra, táblázatokra, képekre, SmartArt objektumokra, OLE objektumokra és egyebekre.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, a hatás a teljes csoportra lesz alkalmazva.