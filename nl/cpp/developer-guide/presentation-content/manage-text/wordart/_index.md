---
title: Maak en pas WordArt-effecten toe in C++
linktitle: WordArt
type: docs
weight: 110
url: /nl/cpp/wordart/
keywords:
- WordArt
- WordArt maken
- WordArt-sjabloon
- WordArt-effect
- schaduw-effect
- reflectie-effect
- gloed-effect
- WordArt-transformatie
- 3D-effect
- buitenschaduw-effect
- binnenschaduw-effect
- C++
- Aspose.Slides
description: "Maak en pas WordArt-effecten aan in Aspose.Slides voor C++. Deze stapsgewijze handleiding helpt ontwikkelaars presentaties te verbeteren met professionele tekst in C++."
---
## **Overzicht**

WordArt-effecten stellen je in staat om tekst te stijlen met opvullingen, omtrekken, schaduwen, reflecties, gloed, transformaties en 3D-opmaak. Dit artikel legt uit hoe je deze effecten maakt en aanpast in PowerPoint‑presentaties met Aspose.Slides for C++, zonder Microsoft Office geïnstalleerd.

## **Maak een eenvoudige WordArt‑sjabloon en pas het toe op tekst**

De volgende voorbeelden creëren een eenvoudige WordArt‑stijl door de tekst, het lettertype, de patroonvulling en de omlijning in te stellen.

Elk voorbeeld maakt een nieuwe presentatie aan en voegt een rechthoek toe aan de eerste dia; er is geen invoerbestand vereist. Het eerste voorbeeld zet de tekst op "Aspose.Slides". De positie en afmetingen van de vorm worden gemeten in punten:

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

Stel het lettertype in op Arial Black met 36 punten om de opmaak duidelijker te maken:

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

Pas een [SmallGrid](https://reference.aspose.com/slides/nl/cpp/aspose.slides/patternstyle/) patroon toe met een donkeroranje voorgrond en een witte achtergrond, en voeg vervolgens een zwarte tekstomlijnning toe met een breedte van 1 punt:

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

De resulterende tekst:

![Het eenvoudige WordArt‑sjabloon](WordArt_template.png)

## **Pas andere WordArt‑effecten toe**

De volgende voorbeelden laten zien hoe je schaduwen, reflecties, gloed, transformaties en 3D‑effecten op tekst toepast.

### **Pas buitenschaduw‑effecten toe**

Een buitenschaduw voegt diepte toe door een schaduw achter de tekst te plaatsen. Je kunt de kleur, richting, afstand, onscherpte‑straal, schaal en scheefstand aanpassen.

Dit voorbeeld roept [EnableOuterShadowEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ieffectformat/enableoutershadoweffect/) aan en stelt een zwarte schaduw in met een onscherpte‑straal van 4 punten, een richting van 230 graden en een afstand van 30 punten. Schaalwaarden van 100 behouden de grootte van de schaduw, terwijl horizontale scheefstand deze 20 graden kantelt. De alfa‑transformatie zet de dekking op 32%:

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

De resulterende tekst:

![Het buitenschaduw‑effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Wanneer buitenschaduwen en voorgedefinieerde schaduwen samen worden gebruikt, wordt alleen de buitenschaduw toegepast.
- Als buitenschaduwen en binnenschaduwen gelijktijdig worden gebruikt, hangt het resulterende effect af van de PowerPoint‑versie. Bijvoorbeeld, in PowerPoint 2013 wordt het effect verdubbeld, terwijl in PowerPoint 2007 alleen de buitenschaduw wordt toegepast.
{{% /alert %}}

### **Pas reflectie‑effecten toe**

Een reflectie maakt een gespiegeld kopie van de tekst. Pas positie, schaal, onscherpte en dekking aan om het uiterlijk te regelen.

Dit voorbeeld roept [EnableReflectionEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ieffectformat/enablereflectioneffect/) aan en draait de reflectie verticaal met een schaal van -100%. Het gebruikt een onscherpte‑straal van 0.5 punt en een afstand van 4.72 punt. De dekking neemt af van 60% tot 0.9% tussen posities 0% en 60% langs de reflectie:

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

De resulterende tekst:

![Het reflectie‑effect](reflection_effect.png)

### **Pas gloed‑effecten toe**

Een gloed voegt een zachte gekleurde omlijning rond de tekst toe. Pas kleur, dekking en straal aan om het effect te regelen.

Dit voorbeeld roept [EnableGlowEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ieffectformat/enablegloweffect/) aan en past een rode gloed toe met 54% dekking en een straal van 7 punten:

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

De resulterende tekst:

![Het gloed‑effect](glow_effect.png)

### **Pas WordArt‑transformaties toe**

WordArt‑transformaties buigen, rekken of vervormen een tekstblok.

Stel [ITextFrameFormat::set_Transform](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/set_transform/) in op [ArchUpPour](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textshapetype/) om het hele tekstframe omhoog te buigen:

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

De resulterende tekst:

![De WordArt‑transformatie](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ biedt een reeks vooraf gedefinieerde [transformatietypen](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textshapetype/).
{{% /alert %}}

### **Pas 3D‑effecten toe op vormen en tekst**

Je kunt 3D‑effecten toepassen op een vorm of op de tekst ervan. Afschaling, extrusie, verlichting en camera‑instellingen bepalen het uiteindelijke uiterlijk.

Het volgende voorbeeld gebruikt [IThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/) om ronde afschalingen, oranje extrusie en een donkerrode contour toe te voegen aan de rechthoek. De afmetingen van de afschaling, extrusiehoogte, contourbreedte en diepte worden gemeten in punten. Een plastisch materiaal, gebalanceerde verlichting gedraaid 40 graden rond de Z‑as, en een perspectiefcamera bepalen het uiterlijk:

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

De resulterende vorm:

![Het 3D‑vormeffect](shape_3D_effect.png)

Dit voorbeeld past een vergelijkbare 3D‑opmaak toe op de tekst via [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/get_threedformat/). Kleinere afschalingen vormen de letterranden, terwijl extrusie en verlichting de tekst diepte geven:

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

De resulterende tekst:

![Het tekst‑3D‑effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Het toepassen van 3D‑effecten op tekst of hun vormen — en de interactie tussen deze effecten — wordt geregeld door specifieke regels. Beschouw een scène met zowel tekst als de vorm die de tekst bevat. Een 3D‑effect omvat de 3D‑representatie van het object en de scène waarin het wordt geplaatst.

- Als een scène is ingesteld voor zowel de vorm als de tekst, heeft de scène van de vorm voorrang en wordt de scène van de tekst genegeerd.
- Als de vorm geen eigen scène heeft maar wel een 3D‑representatie, wordt de scène van de tekst gebruikt.
- Als de vorm helemaal geen 3D‑effect heeft, wordt deze als plat beschouwd en wordt het 3D‑effect alleen op de tekst toegepast.

Deze gedragingen hebben betrekking op de methoden [IThreeDFormat::get_LightRig](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_lightrig/) en [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/get_camera/).
{{% /alert %}}

Zie [Tekst plat houden op een 3D‑vorm](/slides/nl/cpp/3d-presentation/) voor een vergelijking van beide instellingen en een volledig C++‑voorbeeld.

## **FAQ**

**Kan ik WordArt‑effecten gebruiken met verschillende lettertypen of schriften (bijv. Arabisch, Chinees)?**

Ja, Aspose.Slides for C++ ondersteunt Unicode en werkt met alle gangbare lettertypen en schriften. WordArt‑effecten zoals schaduw, vulling en omlijning kunnen worden toegepast ongeacht de taal, hoewel de beschikbaarheid van lettertypen en de weergave kunnen afhangen van de systeemlettertypen.

**Kan ik WordArt‑effecten toepassen op elementen van de slide‑master?**

Ja, je kunt WordArt‑effecten toepassen op vormen op master‑dia’s, inclusief titel‑plaatsaanduidingen, voetteksten of achtergrondtekst. Wijzigingen die je aanbrengt in de master‑lay-out worden doorgevoerd in alle bijbehorende dia’s.

**Beïnvloeden WordArt‑effecten de bestandsgrootte van de presentatie?**

Een beetje. WordArt‑effecten zoals schaduwen, gloed en gradientvullingen kunnen de bestandsgrootte licht verhogen vanwege extra opmaakmetadata, maar het verschil is meestal verwaarloosbaar.

**Kan ik het resultaat van WordArt‑effecten bekijken zonder de presentatie op te slaan?**

Ja, je kunt dia’s die WordArt bevatten renderen naar afbeeldingen (bijv. PNG, JPEG) met [ISlide::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/getimage/), of individuele vormen renderen met [IShape::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/getimage/). Hiermee kun je het resultaat in het geheugen of op het scherm bekijken voordat je de volledige presentatie opslaat of exporteert.