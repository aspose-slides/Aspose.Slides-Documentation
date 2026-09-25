---
title: Skapa och tillämpa WordArt-effekter i C++
linktitle: WordArt
type: docs
weight: 110
url: /sv/cpp/wordart/
keywords:
- WordArt
- skapa WordArt
- WordArt-mall
- WordArt-effekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- WordArt-transformation
- 3D-effekt
- yttre skuggeffekt
- inre skuggeffekt
- C++
- Aspose.Slides
description: "Skapa och anpassa WordArt-effekter i Aspose.Slides för C++. Denna steg-för-steg-guide hjälper utvecklare att förbättra presentationer med professionell text i C++."
---
## **Översikt**

WordArt‑effekter låter dig formatera text med fyllningar, konturer, skuggor, reflektioner, glöd, transformationer och 3D‑formatering. Denna artikel förklarar hur du skapar och anpassar dessa effekter i PowerPoint‑presentationer med Aspose.Slides för C++, utan att Microsoft Office är installerat.

## **Skapa en enkel WordArt‑mall och tillämpa den på text**

Följande exempel bygger en enkel WordArt‑stil genom att ange text, teckensnitt, mönsterfyllning och kontur.

Varje exempel skapar en ny presentation och lägger till en rektangel på dess första bild; ingen indatafil krävs. Det första exemplet sätter texten till "Aspose.Slides". Formens position och dimensioner mäts i punkter:

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

Ställ in teckensnittet till Arial Black med 36 punkter för att göra formateringen tydligare:

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

Applicera ett [SmallGrid](https://reference.aspose.com/slides/sv/cpp/aspose.slides/patternstyle/)‑mönster med en mörkorange förgrund och en vit bakgrund, lägg sedan till en svart textkontur med en bredd på 1 punkt:

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

Den resulterande texten:

![Den enkla WordArt‑mallen](WordArt_template.png)

## **Tillämpa andra WordArt‑effekter**

Följande exempel visar hur man tillämpar skuggor, reflektioner, glöd, transformationer och 3D‑effekter på text.

### **Tillämpa yttre skuggeffekter**

En yttre skugga ger djup genom att placera en skugga bakom texten. Du kan anpassa dess färg, riktning, avstånd, oskärpe‑radie, skala och skevning.

Detta exempel anropar [EnableOuterShadowEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ieffectformat/enableoutershadoweffect/) och ställer in en svart skugga med en oskärpe‑radie på 4 punkter, en riktning på 230 grader och ett avstånd på 30 punkter. Skala‑värden på 100 behåller skuggans storlek, medan horisontell skevning lutar den 20 grader. Alfa‑transformen sätter dess opacitet till 32 %:

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

Den yttre skuggeffekten:

![Den yttre skuggeffekten](outer_shadow_effect.png)

{{% alert color="info" title="Obs" %}}
- När yttre och förinställda skuggor används tillsammans appliceras endast den yttre skuggan.
- Om yttre och inre skuggor används samtidigt beror den resulterande effekten på PowerPoint‑versionen. Till exempel, i PowerPoint 2013 fördubblas effekten, medan i PowerPoint 2007 appliceras bara den yttre skuggan.
{{% /alert %}}

### **Tillämpa reflektionseffekter**

En reflektion skapar en spegelvänd kopia av texten. Justera dess position, skala, oskärpa och opacitet för att styra dess utseende.

Detta exempel anropar [EnableReflectionEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ieffectformat/enablereflectioneffect/) och vänder reflektionen vertikalt med en skala på -100 %. Det använder en oskärpe‑radie på 0,5 punkt och ett avstånd på 4,72 punkt. Opaciteten minskar från 60 % till 0,9 % mellan positionerna 0 % och 60 % längs reflektionen:

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

Reflektionseffekten:

![Reflektionseffekten](reflection_effect.png)

### **Tillämpa glödeffekter**

En glöd ger en mjuk färgad kontur runt texten. Justera dess färg, opacitet och radie för att kontrollera effekten.

Detta exempel anropar [EnableGlowEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ieffectformat/enablegloweffect/) och applicerar en röd glöd med 54 % opacitet och en radie på 7 punkter:

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

Glödeffekten:

![Glödeffekten](glow_effect.png)

### **Tillämpa WordArt‑transformationer**

WordArt‑transformationer böjer, sträcker eller förvränger ett textblock.

Ställ in [ITextFrameFormat::set_Transform](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/set_transform/) till [ArchUpPour](https://reference.aspose.com/slides/sv/cpp/aspose.slides/textshapetype/) för att böja hela text‑ramen uppåt:

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

WordArt‑transformationen:

![WordArt‑transformationen](transform_effect.png)

{{% alert color="info" title="Obs" %}}
Aspose.Slides för C++ tillhandahåller en uppsättning fördefinierade [transformations‑typer](https://reference.aspose.com/slides/sv/cpp/aspose.slides/textshapetype/).
{{% /alert %}}

### **Tillämpa 3D‑effekter på former och text**

Du kan tillämpa 3D‑effekter på en form eller på dess text. Fällningar, extrudering, belysning och kamera‑inställningar styr det resulterande utseendet.

Följande exempel använder [IThreeDFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/) för att lägga till cirkulära fällningar, orange extrudering och en mörkröd kontur till rektangeln. Fällnings‑dimensioner, extruderings‑höjd, kontur‑bredd och djup mäts i punkter. Ett plastmaterial, balanserad belysning roterad 40 grader kring Z‑axeln, och en perspektivkamera definierar dess utseende:

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

Formens 3D‑effekt:

![Formens 3D‑effekt](shape_3D_effect.png)

Detta exempel applicerar liknande 3D‑formatering på texten via [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/get_threedformat/). Småare fällningar formar bokstavskanten, medan extrudering och belysning ger texten djup:

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

Textens 3D‑effekt:

![Textens 3D‑effekt](text_3D_effect.png)

{{% alert color="info" title="Obs" %}}
Tillämpningen av 3D‑effekter på text eller deras former – och interaktionen mellan dessa effekter – styrs av specifika regler. Tänk på en scen som involverar både text och den form som innehåller den. En 3D‑effekt inkluderar objektets 3D‑representation och scenen där den placeras.

- Om en scen är angiven för både formen och texten har formen företräde och textens scen ignoreras.
- Om formen saknar egen scen men har en 3D‑representation används textens scen.
- Om formen inte har någon 3D‑effekt alls behandlas den som platt, och 3D‑effekten appliceras endast på texten.

Dessa beteenden relaterar till metoderna [IThreeDFormat::get_LightRig](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_lightrig/) och [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ithreedformat/get_camera/).
{{% /alert %}}

För att hålla texten platt och läsbar samtidigt som dess formes 3D‑formatering behålls, se [Keep Text Flat on a 3D Shape](/slides/sv/cpp/3d-presentation/) för en jämförelse av båda inställningarna och ett komplett C++‑exempel.

## **Vanliga frågor**

**Kan jag använda WordArt‑effekter med olika teckensnitt eller skript (t.ex. arabiska, kinesiska)?**

Ja, Aspose.Slides för C++ stöder Unicode och fungerar med alla vanliga teckensnitt och skript. WordArt‑effekter som skugga, fyllning och kontur kan appliceras oavsett språk, även om tillgänglighet av teckensnitt och renderingen kan bero på systemets teckensnitt.

**Kan jag tillämpa WordArt‑effekter på master‑bildens element?**

Ja, du kan tillämpa WordArt‑effekter på former på mastern, inklusive titel‑platshållare, sidfötter eller bakgrundstext. Ändringar som görs i master‑layouten återspeglas på alla associerade bilder.

**Påverkar WordArt‑effekter presentationsfilens storlek?**

Lite grann. WordArt‑effekter såsom skuggor, glöd och gradientfyllningar kan öka filstorleken något på grund av extra formateringsmetadata, men skillnaden är vanligtvis försumbar.

**Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?**

Ja, du kan rendera bilder som innehåller WordArt till bildformat (t.ex. PNG, JPEG) med [ISlide::GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/getimage/), eller rendera enskilda former med [IShape::GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/getimage/). Detta låter dig förhandsgranska resultatet i minnet eller på skärmen innan du sparar eller exporterar hela presentationen.