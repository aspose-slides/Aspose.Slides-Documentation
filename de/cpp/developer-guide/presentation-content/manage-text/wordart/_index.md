---
title: WordArt‑Effekte in C++ erstellen und anwenden
linktitle: WordArt
type: docs
weight: 110
url: /de/cpp/wordart/
keywords:
- WordArt
- WordArt erstellen
- WordArt‑Vorlage
- WordArt‑Effekt
- Schatteneffekt
- Anzeigeeffekt
- Leuchteffekt
- WordArt‑Transformation
- 3D‑Effekt
- Außenschatteneﬀekt
- Innenschatteneﬀekt
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "WordArt‑Effekte in Aspose.Slides für C++ erstellen und anpassen. Dieser schrittweise Leitfaden hilft Entwicklern, Präsentationen mit professionellem Text in C++ zu verbessern."
---
## **Übersicht**

WordArt‑Effekte ermöglichen es Ihnen, Ihren PowerPoint‑Präsentationen visuell ansprechenden, stilisierten Text hinzuzufügen. Mit Aspose.Slides können Entwickler programmatisch WordArt erstellen, anpassen und verwalten, genau wie in Microsoft PowerPoint – ohne dass Office installiert sein muss. Dieser Artikel bietet einen Überblick über die Arbeit mit WordArt, einschließlich der Anwendung von Texttransformationen, Füllstilen, Konturen, Schatten und anderen Formatierungsoptionen, um Ihre Präsentationsinhalte ausdrucksstärker und ansprechender zu gestalten. WordArt erlaubt es, Text als grafisches Objekt zu behandeln. Es besteht aus Effekten oder speziellen Modifikationen, die auf Text angewendet werden, um ihn attraktiver oder auffälliger zu machen.

## **Erstellen einer einfachen WordArt‑Vorlage und Anwendung auf Text**

**Verwendung von Aspose.Slides** 

Zuerst erstellen wir einen einfachen Text mit diesem C++‑Code: 

``` cpp 
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Jetzt setzen wir die Schriftgröße des Textes auf einen größeren Wert, um den Effekt deutlicher zu machen, mit diesem Code:

``` cpp 
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Verwendung von Microsoft PowerPoint**

Öffnen Sie das WordArt‑Effekte‑Menü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Im rechten Menü können Sie einen vordefinierten WordArt‑Effekt auswählen. Im linken Menü können Sie die Einstellungen für ein neues WordArt festlegen. 

Dies sind einige der verfügbaren Parameter oder Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Verwendung von Aspose.Slides**

Hier wenden wir die SmallGrid‑Musterfarbe auf den Text an und fügen mit diesem Code einen ein‑Pixel‑breiten schwarzen Textrand hinzu:

``` cpp 
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
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/IPatternFormat.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

Der resultierende Text:

![todo:image_alt_text](image-20200930114108-4.png)

## **Weitere WordArt‑Effekte anwenden**

**Verwendung von Microsoft PowerPoint**

Über die Benutzeroberfläche des Programms können Sie diese Effekte auf einen Text, Textblock, eine Form oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Beispielsweise können Schatten-, Reflexions‑ und Leuchteffekte auf einen Text angewendet werden; 3D‑Format‑ und 3D‑Drehungseffekte können auf einen Textblock angewendet werden; die Eigenschaft Weiche Kanten kann auf ein Shape‑Objekt angewendet werden (sie hat weiterhin Wirkung, wenn keine 3D‑Format‑Eigenschaft gesetzt ist). 

### **Schatteneﬀekte auf Text anwenden**

Hier wollen wir ausschließlich die Eigenschaften eines Textes setzen. Wir wenden den Schattierungseffekt auf einen Text mit diesem C++‑Code an:

``` cpp 
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
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

Die Aspose.Slides‑API unterstützt drei Arten von Schatten: OuterShadow, InnerShadow und PresetShadow. 
Mit PresetShadow können Sie einen Schatten für einen Text anwenden (unter Verwendung vordefinierter Werte). 

**Verwendung von Microsoft PowerPoint**

In PowerPoint können Sie einen Schattentyp verwenden. Hier ein Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Verwendung von Aspose.Slides**

Aspose.Slides ermöglicht tatsächlich, gleichzeitig zwei Schattenarten anzuwenden: InnerShadow und PresetShadow.

**Hinweise:**

- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow‑Effekt angewendet. 
- Wird OuterShadow zusammen mit InnerShadow verwendet, hängt der resultierende bzw. angewendete Effekt von der PowerPoint‑Version ab. Beispielsweise wird der Effekt in PowerPoint 2013 verdoppelt, in PowerPoint 2007 wird jedoch nur der OuterShadow‑Effekt angewendet. 

### **Reflexionseffekte anwenden**

Wir fügen dem Text mit diesem C++‑Beispiel eine Reflexion hinzu:

``` cpp 
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
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

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

### **Leuchteffekte anwenden**

Wir wenden den Leuchteffekt auf den Text an, damit er leuchtet oder hervorsticht, mit diesem Code:

``` cpp 
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
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
<DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 
Sie können die Parameter für Schatten, Anzeige und Leuchten ändern. Die Eigenschaften der Effekte werden für jeden Textabschnitt separat gesetzt. 
{{% /alert %}} 

### **Transformationen in WordArt verwenden**

Wir verwenden die set_Transform‑Methode (gilt für den gesamten Textblock) mit diesem Code:

``` cpp 
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 
Sowohl Microsoft PowerPoint als auch Aspose.Slides für C++ bieten eine Reihe vordefinierter Transformationstypen. 
{{% /alert %}} 

**Verwendung von PowerPoint**

Um auf vordefinierte Transformationstypen zuzugreifen, gehen Sie zu: **Format** -> **TextEffect** -> **Transform**

**Verwendung von Aspose.Slides**

Um einen Transformationstyp auszuwählen, verwenden Sie das Enum TextShapeType. 

### **3D‑Effekte auf Text und Formen anwenden**

Wir setzen einen 3D‑Effekt auf eine Textform mit diesem Beispielcode:

``` cpp 
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
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

Der resultierende Text und seine Form:

![todo:image_alt_text](image-20200930114816-9.png)

Wir wenden einen 3D‑Effekt auf den Text mit diesem C++‑Code an:

``` cpp 
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
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

Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 
Die Anwendung von 3D‑Effekten auf Texte oder deren Formen und die Interaktionen zwischen Effekten basieren auf bestimmten Regeln.

Betrachten Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3D‑Effekt enthält die 3D‑Objektrepräsentation und die Szene, in der das Objekt platziert ist.

- Wenn die Szene sowohl für die Form als auch für den Text festgelegt ist, hat die Form‑Szene höhere Priorität – die Text‑Szene wird ignoriert. 
- Wenn die Form keine eigene Szene hat, aber eine 3D‑Repräsentation besitzt, wird die Text‑Szene verwendet. 
- Andernfalls – wenn die Form ursprünglich keinen 3D‑Effekt hat – ist die Form flach und der 3D‑Effekt wird nur auf den Text angewendet. 

Diese Beschreibungen stehen in Zusammenhang mit den Methoden ThreeDFormat.getLightRig() und ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Außenschatteneﬀekte auf Formen anwenden**
Aspose.Slides für C++ stellt die Klassen [**IOuterShadow**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.effects.i_outer_shadow) und [**IInnerShadow**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.effects.i_inner_shadow) bereit, die das Anwenden von Schatteneffekten auf einen Text in einem TextFrame ermöglichen. Führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation) .
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Fügen Sie der Folie ein AutoShape vom Typ Rectangle hinzu.
4. Greifen Sie auf das dem AutoShape zugehörige TextFrame zu.
5. Setzen Sie den FillType des AutoShape auf NoFill.
6. Instanziieren Sie die Klasse OuterShadow.
7. Setzen Sie den BlurRadius des Schattens.
8. Setzen Sie die Direction des Schattens.
9. Setzen Sie die Distance des Schattens.
10. Setzen Sie RectanglelAlign auf TopLeft.
11. Setzen Sie PresetColor des Schattens auf Black.
12. Schreiben Sie die Präsentation als PPTX‑Datei.

Dieser C++‑Beispielcode – eine Umsetzung der obigen Schritte – zeigt, wie Sie den Außenschatten‑Effekt auf einen Text anwenden:

``` cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
// Referenz der Folie erhalten
auto sld = pres->get_Slides()->idx_get(0);

// Ein AutoShape vom Typ Rechteck hinzufügen
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Ein TextFrame zum Rechteck hinzufügen
ashp->AddTextFrame(u"Aspose TextBox");

// Füllung der Form deaktivieren, falls wir den Schatten des Textes erhalten wollen
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Äußeren Schatten hinzufügen und alle erforderlichen Parameter setzen
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Präsentation auf Festplatte speichern
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **Innenschatteneﬀekte auf Formen anwenden**
Führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation) .
2. Holen Sie die Referenz der Folie.
3. Fügen Sie ein AutoShape vom Typ Rectangle hinzu.
4. Aktivieren Sie InnerShadowEffect.
5. Setzen Sie alle notwendigen Parameter.
6. Setzen Sie ColorType auf Scheme.
7. Setzen Sie die Scheme‑Farbe.
8. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Dieser Beispielcode (basierend auf den oben genannten Schritten) zeigt, wie Sie einen Connector zwischen zwei Formen in C++ hinzufügen:

``` cpp
#include <DOM/ColorType.h>
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// Referenz einer Folie erhalten
auto slide = presentation->get_Slides()->idx_get(0);

// Ein AutoShape vom Typ Rechteck hinzufügen
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// TextFrame zum Rechteck hinzufügen
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Innere Schatten-Effekt aktivieren    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Alle erforderlichen Parameter setzen
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// ColorType als Scheme festlegen
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Scheme-Farbe festlegen
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Präsentation speichern
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

### Kann ich WordArt‑Effekte mit unterschiedlichen Schriften oder Skripten (z. B. Arabisch, Chinesisch) verwenden?

Ja, Aspose.Slides unterstützt Unicode und funktioniert mit allen gängigen Schriften und Skripten. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung von Schriften von den System‑Schriften abhängen können.

### Kann ich WordArt‑Effekte auf Folienmaster‑Elemente anwenden?

Ja, Sie können WordArt‑Effekte auf Formen in Folienmaster‑Folien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtext. Änderungen am Master‑Layout wirken sich auf alle zugehörigen Folien aus.

### Wirken sich WordArt‑Effekte auf die Dateigröße der Präsentation aus?

Leicht. WordArt‑Effekte wie Schatten, Leuchten und Verlaufsfüllungen können die Dateigröße durch zusätzliche Formatierungs‑Metadaten geringfügig erhöhen, der Unterschied ist jedoch in der Regel vernachlässigbar.

### Kann ich das Ergebnis von WordArt‑Effekten anzeigen, ohne die Präsentation zu speichern?

Ja, Sie können Folien mit WordArt in Bilder (z. B. PNG, JPEG) rendern, indem Sie die Methode `GetImage` aus den Schnittstellen [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/) oder [ISlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/) verwenden. Damit können Sie das Ergebnis im Speicher oder auf dem Bildschirm anzeigen, bevor Sie die vollständige Präsentation speichern oder exportieren.