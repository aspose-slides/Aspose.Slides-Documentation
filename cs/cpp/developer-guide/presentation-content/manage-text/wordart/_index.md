---
title: Vytvoření a použití WordArt efektů v C++
linktitle: WordArt
type: docs
weight: 110
url: /cs/cpp/wordart/
keywords:
- WordArt
- vytváření WordArt
- šablona WordArt
- efekt WordArt
- efekt stínu
- efekt odrazu
- efekt záře
- transformace WordArt
- 3D efekt
- efekt vnějšího stínu
- efekt vnitřního stínu
- C++
- Aspose.Slides
description: "Vytvořte a přizpůsobte WordArt efekty v Aspose.Slides pro C++. Tento krok-za-krokem průvodce pomáhá vývojářům vylepšit prezentace profesionálním textem v C++."
---
## **Přehled**

Efekty WordArt vám umožňují stylovat text pomocí výplní, obrysů, stínů, odrazů, záře, transformací a 3D formátování. Tento článek vysvětluje, jak vytvářet a přizpůsobovat tyto efekty v prezentacích PowerPoint pomocí Aspose.Slides pro C++, aniž by byl nainstalován Microsoft Office.

## **Vytvoření jednoduché šablony WordArt a její použití na text**

Následující příklady vytvoří jednoduchý styl WordArt nastavením textu, písma, vzorové výplně a obrysu.

Každý příklad vytvoří novou prezentaci a přidá obdélník na první snímek; není vyžadován žádný vstupní soubor. První příklad nastaví text na „Aspose.Slides“. Pozice a rozměry tvaru jsou měřeny v bodech:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Nastavte písmo na Arial Black o velikosti 36 bodů, aby bylo formátování výraznější:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

Použijte vzor [SmallGrid](https://reference.aspose.com/slides/cs/cpp/aspose.slides/patternstyle/) s tmavě oranžovým popředím a bílým pozadím, poté přidejte černý obrys textu šířky 1 bod:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IPatternFormat.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

portion->get_PortionFormat()->get_LineFormat()->set_Width(1);
auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

Výsledný text:

![Jednoduchá šablona WordArt](WordArt_template.png)

## **Použití dalších efektů WordArt**

Následující příklady ukazují, jak aplikovat stíny, odrazy, záři, transformace a 3D efekty na text.

### **Použití vnějších stínových efektů**

Vnější stín přidává hloubku tím, že umístí stín za text. Můžete přizpůsobit jeho barvu, směr, vzdálenost, poloměr rozostření, měřítko a zkosení.

Tento příklad volá [EnableOuterShadowEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ieffectformat/enableoutershadoweffect/) a nastaví černý stín s poloměrem rozostření 4 body, směrem 230 stupňů a vzdáleností 30 bodů. Hodnoty měřítka 100 zachovají velikost stínu, zatímco horizontální zkosení ji nakloní o 20 stupňů. Alfa transformace nastaví jeho neprůhlednost na 32%:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(100);
outerShadowEffect->set_BlurRadius(4);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(30);
outerShadowEffect->set_SkewHorizontal(20);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

Výsledný text:

![Efekt vnějšího stínu](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Když jsou použity vnější a přednastavené stíny současně, použije se pouze vnější stín.
- Pokud jsou použity vnější a vnitřní stíny najednou, výsledek závisí na verzi PowerPointu. Například v PowerPointu 2013 se efekt zdvojí, zatímco v PowerPointu 2007 se použije pouze vnější stín.
{{% /alert %}}

### **Použití odrazových efektů**

Odraz vytvoří zrcadlovou kopii textu. Upravte jeho pozici, měřítko, rozostření a neprůhlednost, abyste řídili jeho vzhled.

Tento příklad volá [EnableReflectionEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ieffectformat/enablereflectioneffect/) a převrátí odraz vertikálně se měřítkem -100%. Používá poloměr rozostření 0.5 bodu a vzdálenost 4.72 bodu. Neprůhlednost klesá z 60% na 0.9% mezi pozicemi 0% a 60% podél odrazu:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

Výsledný text:

![Efekt odrazu](reflection_effect.png)

### **Použití zářivých efektů**

Záře přidává měkký barevný obrys kolem textu. Upravte její barvu, neprůhlednost a poloměr, abyste řídili efekt.

Tento příklad volá [EnableGlowEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ieffectformat/enablegloweffect/) a použije červenou záři s neprůhledností 54% a poloměrem 7 bodů:

```cpp
#include <drawing/color.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Red());
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

Výsledný text:

![Efekt záře](glow_effect.png)

### **Použití WordArt transformací**

WordArt transformace ohýbají, roztahují nebo deformují blok textu.

Nastavte [ITextFrameFormat::set_Transform](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/set_transform/) na [ArchUpPour](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textshapetype/), aby se celý textový rámec zakřivil vzhůru:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);

auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Výsledný text:

![WordArt transformace](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides pro C++ poskytuje sadu předdefinovaných [typů transformací](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textshapetype/).
{{% /alert %}}

### **Použití 3D efektů na tvary a text**

Můžete aplikovat 3D efekty na tvar nebo na jeho text. Šikmé řezání, extruze, osvětlení a nastavení kamery řídí výsledný vzhled.

Následující příklad používá [IThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/) k přidání kulatých šikmých řezů, oranžové extruze a tmavě červeného obrysu k obdélníku. Rozměry šikmých řezů, výška extruze, šířka obrysu a hloubka jsou měřeny v bodech. Plastový materiál, vyvážené osvětlení otočené o 40 stupňů kolem osy Z a perspektivní kamera definují jeho vzhled:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
autoShape->get_TextFrame()->set_Text(u"Aspose.Slides");

auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

![3D efekt tvaru](shape_3D_effect.png)

Tento příklad aplikuje podobné 3D formátování na text pomocí [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/get_threedformat/). Menší šikmé řezání tvarují hrany písmen, zatímco extruze a osvětlení dodávají textu hloubku:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);

auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

![3D efekt textu](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Aplikace 3D efektů na text nebo jejich tvary — a interakce mezi těmito efekty — je řízena specifickými pravidly. Zvažte scénu zahrnující jak text, tak tvar, který jej obsahuje. 3D efekt zahrnuje 3D reprezentaci objektu a scénu, ve které je umístěn.

- Pokud je scéna nastavena jak pro tvar, tak pro text, scéna tvaru má přednost a scéna textu je ignorována.
- Pokud tvar nemá vlastní scénu, ale má 3D reprezentaci, použije se scéna textu.
- Pokud tvar nemá žádný 3D efekt, je považován za plochý a 3D efekt se aplikuje pouze na text.

Tyto chování souvisejí s metodami [IThreeDFormat::get_LightRig](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_lightrig/) a [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ithreedformat/get_camera/).
{{% /alert %}}

Chcete‑li udržet text plochý a čitelný při zachování 3D formátování tvaru, podívejte se na [Keep Text Flat on a 3D Shape](/slides/cs/cpp/3d-presentation/) pro srovnání obou nastavení a kompletní C++ příklad.

## **Často kladené otázky**

**Mohu používat WordArt efekty s různými fonty nebo skripty (např. arabština, čínština)?**

Ano, Aspose.Slides pro C++ podporuje Unicode a funguje se všemi hlavními fonty a skripty. Efekty WordArt, jako stín, výplň a obrys, lze použít bez ohledu na jazyk, ačkoli dostupnost fontů a jejich vykreslení mohou záviset na systémových fontech.

**Mohu aplikovat WordArt efekty na prvky master slide?**

Ano, můžete aplikovat WordArt efekty na tvary na master slide, včetně zástupných symbolů pro titul, zápatí nebo text na pozadí. Změny provedené v rozložení masteru se projeví na všech přidružených slidech.

**Ovlivňují WordArt efekty velikost souboru prezentace?**

Mírně. WordArt efekty, jako stíny, záře a gradientové výplně, mohou o něco zvýšit velikost souboru kvůli přidaným metadatům formátování, ale rozdíl je obvykle zanedbatelný.

**Mohu si prohlédnout výsledek WordArt efektů bez ukládání prezentace?**

Ano, můžete vykreslit snímky obsahující WordArt do obrázků (např. PNG, JPEG) pomocí [ISlide::GetImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/getimage/), nebo vykreslit jednotlivé tvary pomocí [IShape::GetImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/getimage/). To vám umožní náhled výsledku v paměti nebo na obrazovce před uložením či exportem celé prezentace.