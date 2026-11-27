---
title: "Alakzati hatások alkalmazása előadásokban C++ használatával"
linktitle: "Alakzati hatás"
type: docs
weight: 30
url: /hu/cpp/shape-effect/
keywords:
- alakzati hatás
- árnyékhatás
- reflexióhatás
- ragyogáshatás
- lágy szegélyhatás
- hatásformátum
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Alakítsd át PPT és PPTX fájljaidat fejlett alakzati hatásokkal az Aspose.Slides for C++ segítségével — készíts lenyűgöző, professzionális diákat másodpercek alatt."
---
## **Bevezetés**

Miközben a PowerPoint hatásai használhatók egy alakzat kiemelésére, különböznek a [kitöltésektől](/slides/hu/cpp/shape-formatting/#gradient-fill) vagy körvonalaktól. PowerPoint hatásokat használva meggyőző tükröződéseket hozhatsz létre egy alakzaton, terjesztheted az alakzat fénylő ragyogását stb.

![Alakzati effektus](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhatsz egy alakzatra.

Néhány hatáskombináció szebben néz ki, mint mások. Emiatt a PowerPoint a **Előre beállított** menüpont alatt kínál lehetőségeket. Az előre beállított opciók lényegében két vagy több jól együtt működő hatás kombinációja. Így egy előre beállított kiválasztásával nem kell időt pazarolnod a különböző hatások tesztelésére vagy kombinálására a megfelelő kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) osztályban olyan tulajdonságokat és metódusokat biztosít, amelyek lehetővé teszik ugyanezeknek a hatásoknak az alkalmazását PowerPoint előadásban lévő alakzatokra.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for C++ támogatja a külső és belső árnyékokat alakzatokhoz. Testreszabhatod azok színét, irányát, távolságát és elmosódási sugarát, hogy illeszkedjenek az előadásod dizájnjához.

### **Külső árnyék alkalmazása**

Használj külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a diáktól. Az árnyék túlnyúlik az alakzat szélén, így azt a benyomást keltve, hogy az alakzat a dia fölött felemelkedett. Állítsd be annak színét, irányát, távolságát és elmosódási sugarát, hogy megfeleljen a sablonod világításának és stílusának.

Ez a C++ kód bemutatja, hogyan kell alkalmazni a [külső árnyék hatást](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) egy téglalapra:
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

#### **Az árnyék irányának vezérlése alakzat forgatásakor**

Alapértelmezés szerint a külső árnyék a saját alakzatával fordul. Ahhoz, hogy a különböző forgatású alakzatok ugyanabból az irányból legyenek megvilágítva, hívd a [set_RotateShadowWithShape](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ioutershadow/set_rotateshadowwithshape/) metódust `false` értékkel, és használd a [set_Direction](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ioutershadow/set_direction/) metódust, hogy ugyanazt a szöget állítsd be az árnyékoknak.

A példa két nyilat hoz létre szürke árnyékokkal, amelyek jobbra vannak eltolva (0°). Ezután duplikálja a diát, és mindkét nyilat 90°-kal az óramutató járásával megegyező irányba forgatja.
```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto before = presentation->get_Slide(0);

auto left = before->get_Shapes()->AddAutoShape(ShapeType::RightArrow, 55, 130, 110, 60);
left->get_FillFormat()->set_FillType(FillType::Solid);
left->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
left->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

left->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = left->get_EffectFormat()->get_OuterShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_Gray());
shadow->set_Direction(0);
shadow->set_Distance(42);
shadow->set_BlurRadius(0);
shadow->set_RotateShadowWithShape(true);

auto right = before->get_Shapes()->AddClone(left);
right->set_X(395);
right->get_EffectFormat()->get_OuterShadowEffect()->set_RotateShadowWithShape(false);

auto after = presentation->get_Slides()->AddClone(before);
for (auto i = 0; i < after->get_Shapes()->get_Count(); ++i)
{
    after->get_Shape(i)->set_Rotation(90);
}

presentation->Save(u"arrow_shadows.pptx", SaveFormat::Pptx);
```

A második dián a bal nyíl árnyéka lefelé vetül, míg a jobb nyíl árnyéka továbbra is jobbra mutat. A beállított irány mindkét árnyéknál 0° marad.

![PowerPoint renderelés 90° forgatás előtt és után. Mindkét árnyék jobbra kezd. Forgatás után az árnyék a bal nyíl alá kerül, a jobb nyíl mellett marad jobbra.](arrow-shadow-rotation.png)

### **Belső árnyék alkalmazása**

Sablon vizuális stílusának reprodukálásakor használj belső árnyékot, hogy a kártya vagy panel recesszív megjelenést kapjon. A külső árnyék az alakzat külső részén terjed, és felemelkedett hatást kölcsönöz, míg a belső árnyék az élének belsejét árnyékolja.

Hívd a [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) metódust, majd állítsd be a [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) beállításait. A nagyobb elmosódási sugár értékek lágyabb éleket eredményeznek.

Ez a C++ példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti el:
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

A belső árnyék eltávolításához hívd a [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) metódust az alakzat effektusformátumán.

### **Előre beállított árnyék alkalmazása, módosítása és eltávolítása**

Hívd a [EnablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/enablepresetshadoweffect/) metódust, és használd a [set_Preset](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ipresetshadow/set_preset/) metódust egy [PresetShadowType](https://reference.aspose.com/slides/cpp/aspose.slides/presetshadowtype/) kiválasztásához. A stílusok váltásához módosítsd az előre beállított értéket ugyanazon az alakzaton. Hívd a [DisablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disablepresetshadoweffect/) metódust az árnyék eltávolításához, miközben megőrzöd a kitöltést és a körvonalat.

Ez a példa minden lépésnél megőriz egy másolatot a téglalapról. Mindkét árnyékot 10 ponttal eltolják. A 225° irány az első árnyékot a téglalap fölé és balra helyezi, a 45° a másodikat alá és jobbra.
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

| Eredeti | Első előre beállított | Második előre beállított | Eltávolítás után |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **Reflexió hatás alkalmazása**

Az Aspose.Slides for C++-ban a reflexió hatás alkalmazásához hozzáadhatsz tükörszerű tükröződést alakzatokhoz, beállítva például a távolságot, átlátszóságot és méretet. Ez a hatás javítja az előadások esztétikáját az alakzatok kifinomultabb megjelenésével. Egyszerű kóddal könnyen megvalósítható, lehetővé téve a gyors alkalmazást több elemre a következetes dizájn érdekében.

Ez a C++ kód bemutatja, hogyan kell alkalmazni a [reflexió hatást](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) egy alakzatra:
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

![Reflexió hatás](reflection_effect.png)

## **Ragyogás hatás alkalmazása**

Az Aspose.Slides for C++-ban a ragyogás hatás alkalmazásához egy puha, fénylő aurát adhatsz az alakzat köré, beállítva például a színt és a méretet. Ez a hatás segít kiemelni az alakzatokat, és vonzó, szemfelébbhúzó vizuális elemet ad az előadásodhoz. Minimális kóddal könnyen megvalósítható, javítva a diák összképét.

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

## **Lágy szegélyek hatás alkalmazása**

Az Aspose.Slides for C++-ban a lágy szegélyek hatás alkalmazásához létrehozhatsz egy sima, elmosódott átmenetet az alakzat szélén. Ez a hatás finomabb és kifinomultabb megjelenést ad, amely tökéletes a finom, lágyabb megjelenést igénylő tervekhez. Könnyen beállíthatod a paramétereket, például a sugarat, hogy a kívánt hatást elérd a különböző alakzatoknál az előadásodban.

Ez a C++ kód bemutatja, hogyan kell alkalmazni a [lágy szegélyeket](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) egy alakzatra:
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

![Lágy szegélyek hatás](soft_edges_effect.png)

## **Elmosódás hatás alkalmazása**

Használd a forma elmosódást a forma kitöltésének és körvonalának lágyításához, miközben a forma szerkeszthető marad. Hívd a [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) metódust a forma effektusformátumán. A sugár pontban van mérve (1/72 hüvelyk): használj nem negatív értéket, a nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugár változatlanul hagyja a megjelenést.

A [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) beállítás szabályozza a hatás látható határait. `false` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat, van levágva. `true` esetén az elmosódás túl is terjedhet ezeken a határokon. Egyik beállítás sem változtatja a forma pozícióját vagy méreteit.

Az alábbi összehasonlítás során mindenhol ugyanazt a kitöltést, körvonalat és forma méreteket használják. A felső sor `grow = false`-t használ; az alsó sor `grow = true`-t.

![Eredeti téglalap elmosódási sugárral 5 és 15 pont, grow ki- és bekapcsolva](shape_blur_comparison.png)

Ez a C++ példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5 pontos elmosódást alkalmaz, majd egy újabb [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) hívással 15 pontra növeli. Mindkét elmosódott állapotot elmenti, majd meghívja a [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) metódust, és elmenti a formát elmosódás nélkül.
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

A forma elmosódás a kitöltést és a körvonalat együtt érinti. A lágy szegélyek hatás a forma széleit halványítja, míg az árnyék elmosódás csak az árnyékot lágyítja. A képek átalakítási hatások a kép tartalmán működnek; ez a példa közvetlenül a forma effektusformátumára alkalmaz elmosódást, anélkül, hogy a formát képpé konvertálná.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat, például árnyékot, reflexiót és ragyogást kombinálhatsz egyetlen alakzaton, hogy dinamikusabb megjelenést érj el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különböző alakzatokra alkalmazhatsz hatásokat, beleértve az automatikus alakzatokat, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és még sok mást.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, a csoportosított alakzatokra is alkalmazhatsz hatásokat. A hatás az egész csoportra vonatkozik.