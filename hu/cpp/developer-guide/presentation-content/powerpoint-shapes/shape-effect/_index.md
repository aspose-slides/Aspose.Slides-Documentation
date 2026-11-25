---
title: Alakzat hatások alkalmazása prezentációkban C++ használatával
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/cpp/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- visszaverő hatás
- ragyogás hatás
- lágy szélek hatás
- hatásformátum
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat hatásokkal az Aspose.Slides for C++ segítségével — készítsen lenyűgöző, professzionális diákat másodpercek alatt."
---
## **Bevezetés**

Miközben a PowerPoint hatásait arra lehet használni, hogy egy alakzat kitűnjön, eltérnek a [kitöltésektől](/slides/hu/cpp/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint‑hatások segítségével meggyőző tükröződéseket hozhat létre egy alakzaton, szórhatja az alakzat fénylődését stb.

![Alakzat hatás](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Néhány hatáskombináció jobban néz ki, mint mások. Emiatt a PowerPoint a **Preset** alatt lehetőségeket kínál. A Preset beállítások lényegében két vagy több, együtt jól kinéző hatás kombinációi. Így, amikor egy előre beállított variánst választ, nem kell időt vesztegetnie a különböző hatások tesztelésével vagy kombinálásával, hogy szép kombinációt találjon.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) osztály alatt biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik, hogy ugyanazokat a hatásokat alkalmazza a PowerPoint‑prezentációk alakzataira.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for C++ támogatja a külső és belső árnyékokat az alakzatoknál. Testreszabhatja azok színét, irányát, távolságát és elmosódási sugárát, hogy illeszkedjen a prezentációja kialakításához.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttérből. Az árnyék túlcsordul az alakzat szélén, így azt az érzetet kelti, mintha az alakzat a dia felett lenne. Állítsa be a színét, irányát, távolságát és elmosódási sugárát, hogy megfeleljen a sablon fényviszonyainak és stílusának.

Ez a C++ kód bemutatja, hogyan kell alkalmazni a [külső árnyékhatást](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) egy téglalapra:

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

A sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy egy kártya vagy panel recesszív megjelenést kapjon. A külső árnyék az alakzat kívülére nyúlik, és azt az érzetet kelti, hogy emelkedett, míg a belső árnyék az élek belsejét árnyékolja.

Hívja meg a [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), majd konfigurálja a [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). A nagyobb elmosódási sugár értékek lágyabb éleket eredményeznek.

Ez a C++ példa egy világoskék kártyát hoz létre sötét szürke belső árnyékkal, és PPTX fájlként menti:

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

A belső árnyék eltávolításához hívja meg a [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) metódust az alakzat effectformat objektumán.

### **Presettárnyék alkalmazása, módosítása és eltávolítása**

Hívja meg a [EnablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/enablepresetshadoweffect/) metódust, és használja a [set_Preset](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ipresetshadow/set_preset/) metódust egy [PresetShadowType](https://reference.aspose.com/slides/cpp/aspose.slides/presetshadowtype/) kiválasztásához. A stílus váltásához módosítsa a presetet ugyanazon alakzaton. A [DisablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disablepresetshadoweffect/) hívásával eltávolíthatja az árnyékot, miközben megőrzi a kitöltést és a körvonalat.

Ez a példa a téglalap minden lépésnél egy másolatát tartja. Mindkét árnyék 10 ponttal van eltolva. A 225° irányú első árnyék a téglalap fölé és balra helyezkedik el, míg a 45° irányú a második alulra és jobbra.

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

| Eredeti | Első preset | Második preset | Eltávolítás után |
| :---: | :---: | :---: | :---: |
| ![Nincs árnyék](preset_shadow_original.png) | ![Bal felső árnyék](preset_shadow_top_left.png) | ![Jobb alsó árnyék](preset_shadow_bottom_right.png) | ![Nincs árnyék eltávolítás után](preset_shadow_removed.png) |

## **Visszaverő hatás alkalmazása**

A visszaverő hatás használatával az Aspose.Slides for C++ lehetővé teszi, hogy tükörszerű tükröződést adjon az alakzatoknak, állítva például a távolságot, átlátszóságot és méretet. Ez a hatás fokozza a prezentációk esztétikáját, elegánsabbá téve az alakzatokat. Egyszerű kóddal könnyen megvalósítható, ami gyors alkalmazást tesz lehetővé több elemre a konzisztens megjelenés érdekében.

Ez a C++ kód bemutatja, hogyan kell alkalmazni a [visszaverő hatást](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) egy alakzatra:

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

![Visszaverő hatás](reflection_effect.png)

## **Ragyogás hatás alkalmazása**

A ragyogás hatás segítségével puha, fénylő aurát adhat az alakzatok köré, szín és méret beállításával. Ez a hatás segít kiemelni az alakzatokat, vonzó, szemrevaló vizuális elemet biztosítva a prezentációban. Könnyen megvalósítható minimális kóddal, amely javítja a diák összképét.

Ez a C++ kód bemutatja, hogyan kell alkalmazni a [ragyogás hatást](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) egy alakzatra:

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

A lágy szélek hatással sima, elmosódott átmenetet hozhat létre az alakzat szélén. Ez a hatás finomabb, kifinomultabb megjelenést biztosít, amely ideális azoknak a terveknek, amelyeknek enyhe, lágyabb kinézetre van szükségük. Könnyen állíthatja a sugár paramétereit a kívánt hatás eléréséhez különböző alakzatok számára a prezentációban.

Ez a C++ kód bemutatja, hogyan kell alkalmazni a [lágy széleket](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) egy alakzatra:

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

Az alakzati elmosódással lágyíthatja egy alakzat kitöltését és körvonalát, miközben az alakzat szerkeszthető marad. Hívja meg a [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) metódust az alakzat effectformat objektumán. A sugarat pontban (1/72 hüvelyk) mérik: használjon nemnegatív értéket, a nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugár változatlan megjelenést hagy.

A [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) beállítás szabályozza a hatás látható határait. `false` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat, lesz levágva. `true` esetén az elmosódás túlnyúlhat ezeken a határokon. Egyik beállítás sem változtatja meg az alakzat pozícióját vagy méreteit.

Az alábbi összehasonlítás ugyanazt a kitöltést, körvonalat és alakzati méreteket használja minden esetben. A felső sor `grow = false`; az alsó sor `grow = true`.

![Eredeti téglalap a 5 és 15 pont elmosódási sugárral, a 'grow' kikapcsolt és bekapcsolt állapottal összehasonlítva](shape_blur_comparison.png)

Ez a C++ példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5 pont elmosódást alkalmaz, majd egy 15 pontos elmosódásra frissíti a [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) újbóli meghívásával. Mindkét elmosódott állapotot menti, majd a [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) hívásával menti az alakzatot elmosódás nélkül.

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

Az alakzati elmosódás egyszerre érinti a kitöltést és a körvonalat. A lágy szélek hatás a forma széleit halványítja, míg az árnyék elmosódása csak az árnyékot lágyítja. A képek átalakítási hatásai a képtartalmon működnek; ez a példa közvetlenül az alakzat effectformat objektumára alkalmaz elmosódást anélkül, hogy az alakzatot képpé konvertálná.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat, például árnyékot, visszaverő hatást és ragyogást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, többek között autoshape‑ekre, diagramokra, táblázatokra, képekre, SmartArt objektumokra, OLE objektumokra és egyéb elemekre.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, a hatásokat csoportosított alakzatokra is alkalmazhatja. A hatás a teljes csoportra lesz érvényes.