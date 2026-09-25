---
title: Erstellen und Anwenden von WordArt‑Effekten in C++
linktitle: WordArt
type: docs
weight: 110
url: /de/cpp/wordart/
keywords:
- WordArt
- WordArt erstellen
- WordArt‑Vorlage
- WordArt‑Effekt
- Schatten‑Effekt
- Spiegelungs‑Effekt
- Leucht‑Effekt
- WordArt‑Transformation
- 3D‑Effekt
- Äußerer‑Schatten‑Effekt
- Innerer‑Schatten‑Effekt
- C++
- Aspose.Slides
description: "Erstellen und Anpassen von WordArt‑Effekten in Aspose.Slides für C++. Diese Schritt‑für‑Schritt‑Anleitung hilft Entwicklern, Präsentationen mit professionellem Text in C++ zu verbessern."
---
## **Übersicht**

WordArt‑Effekte ermöglichen das Gestalten von Text mit Füllungen, Konturen, Schatten, Spiegelungen, Leuchten, Transformationen und 3D‑Formatierung. Dieser Artikel erklärt, wie Sie diese Effekte in PowerPoint‑Präsentationen mit Aspose.Slides für C++ erstellen und anpassen, ohne Microsoft Office installiert zu haben.

## **Ein einfaches WordArt‑Template erstellen und auf Text anwenden**

Die folgenden Beispiele erstellen einen einfachen WordArt‑Stil, indem sie Text, Schriftart, Musterfüllung und Kontur festlegen.

Jedes Beispiel erzeugt eine neue Präsentation und fügt ihrer ersten Folie ein Rechteck hinzu; eine Eingabedatei ist nicht erforderlich. Das erste Beispiel setzt den Text auf „Aspose.Slides“. Position und Größe der Form werden in Punkten gemessen:

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

Setzen Sie die Schriftart auf Arial Black mit 36 Punkt, um die Formatierung deutlicher zu machen:

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

Wenden Sie ein [SmallGrid](https://reference.aspose.com/slides/de/cpp/aspose.slides/patternstyle/)‑Muster mit einem dunkelorangenen Vordergrund und weißem Hintergrund an und fügen Sie eine schwarze Textkontur mit einer Breite von 1 Punkt hinzu:

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

Der resultierende Text:

![Das einfache WordArt‑Template](WordArt_template.png)

## **Weitere WordArt‑Effekte anwenden**

Die folgenden Beispiele zeigen, wie Sie Schatten, Spiegelungen, Leuchten, Transformationen und 3D‑Effekte auf Text anwenden.

### **Äußere Schatteneffekte anwenden**

Ein äußerer Schatten verleiht Tiefe, indem er hinter dem Text platziert wird. Sie können Farbe, Richtung, Abstand, Unschärferadius, Skalierung und Schrägstellung anpassen.

Dieses Beispiel ruft [EnableOuterShadowEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides/ieffectformat/enableoutershadoweffect/) auf und setzt einen schwarzen Schatten mit einem Unschärferadius von 4 Punkt, einer Richtung von 230 Grad und einem Abstand von 30 Punkt. Skalierungswerte von 100 erhalten die Schattengröße, während eine horizontale Schrägstellung um 20 Grad kippt. Die Alpha‑Transformation setzt die Deckkraft auf 32 %:

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

Der resultierende Text:

![Der äußere Schatteneffekt](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Wenn äußere und vordefinierte Schatten zusammen verwendet werden, wird nur der äußere Schatten angewendet.
- Bei gleichzeitiger Verwendung von äußeren und inneren Schatten hängt das Ergebnis von der PowerPoint‑Version ab. In PowerPoint 2013 wird der Effekt verdoppelt, in PowerPoint 2007 wird nur der äußere Schatten angewendet.
{{% /alert %}}

### **Spiegelungseffekte anwenden**

Eine Spiegelung erzeugt eine gespiegelte Kopie des Textes. Passen Sie Position, Skalierung, Unschärfe und Deckkraft an, um das Erscheinungsbild zu steuern.

Dieses Beispiel ruft [EnableReflectionEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides/ieffectformat/enablereflectioneffect/) auf und kippt die Spiegelung vertikal mit einer Skalierung von –100 %. Es verwendet einen Unschärferadius von 0,5 Punkt und einen Abstand von 4,72 Punkt. Die Deckkraft nimmt von 60 % auf 0,9 % zwischen den Positionen 0 % und 60 % entlang der Spiegelung ab:

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

Der resultierende Text:

![Der Spiegelungseffekt](reflection_effect.png)

### **Leuchteffekte anwenden**

Ein Leuchten fügt eine weiche farbige Kontur um den Text hinzu. Passen Sie Farbe, Deckkraft und Radius an, um den Effekt zu steuern.

Dieses Beispiel ruft [EnableGlowEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides/ieffectformat/enablegloweffect/) auf und wendet ein rotes Leuchten mit 54 % Deckkraft und einem Radius von 7 Punkt an:

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

Der resultierende Text:

![Der Leuchteffekt](glow_effect.png)

### **WordArt‑Transformationen anwenden**

WordArt‑Transformationen biegen, strecken oder verzerren einen Textblock.

Setzen Sie [ITextFrameFormat::set_Transform](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/set_transform/) auf [ArchUpPour](https://reference.aspose.com/slides/de/cpp/aspose.slides/textshapetype/), um den gesamten Textrahmen nach oben zu biegen:

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

Der resultierende Text:

![Die WordArt‑Transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides für C++ bietet eine Reihe vordefinierter [Transformationsarten](https://reference.aspose.com/slides/de/cpp/aspose.slides/textshapetype/).
{{% /alert %}}

### **3D‑Effekte auf Formen und Text anwenden**

Sie können 3D‑Effekte auf eine Form oder auf deren Text anwenden. Abschrägungen, Extrusion, Beleuchtung und Kameraeinstellungen bestimmen das Ergebnis.

Das folgende Beispiel verwendet [IThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/), um runde Abschrägungen, orange Extrusion und eine dunkelrote Kontur zum Rechteck hinzuzufügen. Abschrägung‑Abmessungen, Extrusions‑höhe, Kontur‑Breite und Tiefe werden in Punkten angegeben. Ein Kunststoff‑Material, ausgewogene Beleuchtung, um 40 Grad um die Z‑Achse gedreht, und eine Perspektiv‑Kamera definieren das Aussehen:

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

Die resultierende Form:

![Der 3D‑Formeffekt](shape_3D_effect.png)

Dieses Beispiel wendet eine ähnliche 3D‑Formatierung auf den Text über [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/get_threedformat/) an. Kleinere Abschrägungen formen die Buchstabenränder, während Extrusion und Beleuchtung dem Text Tiefe verleihen:

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

Der resultierende Text:

![Der 3D‑Texteffekt](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Die Anwendung von 3D‑Effekten auf Text oder deren Formen – und die Wechselwirkung zwischen diesen Effekten – wird durch spezifische Regeln gesteuert. Betrachten Sie eine Szene, die sowohl Text als auch die enthaltende Form umfasst. Ein 3D‑Effekt beinhaltet die 3D‑Darstellung des Objekts und die Szene, in der es platziert ist.

- Ist für sowohl die Form als auch den Text eine Szene festgelegt, hat die Szene der Form Vorrang und die Szene des Textes wird ignoriert.
- Fehlt der Form eine eigene Szene, aber sie besitzt eine 3D‑Darstellung, wird die Szene des Textes verwendet.
- Hat die Form überhaupt keinen 3D‑Effekt, wird sie als flach behandelt und der 3D‑Effekt ausschließlich auf den Text angewendet.

Diese Verhaltensweisen beziehen sich auf die Methoden [IThreeDFormat::get_LightRig](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_lightrig/) und [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_camera/).
{{% /alert %}}

Um Text flach und lesbar zu halten und gleichzeitig die 3D‑Formatierung der Form beizubehalten, siehe [Keep Text Flat on a 3D Shape](/slides/de/cpp/3d-presentation/) für einen Vergleich beider Einstellungen und ein vollständiges C++‑Beispiel.

## **FAQ**

**Kann ich WordArt‑Effekte mit verschiedenen Schriften oder Skripten (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides für C++ unterstützt Unicode und funktioniert mit allen gängigen Schriften und Skripten. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit von Schriftarten und das Rendern vom System abhängen können.

**Kann ich WordArt‑Effekte auf Elemente des Folienmasters anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen in Master‑Folien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtext. Änderungen am Master‑Layout werden auf alle zugehörigen Folien übertragen.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. WordArt‑Effekte wie Schatten, Leuchten und Farbverläufe können die Dateigröße geringfügig erhöhen, da zusätzliche Formatierungs‑Metadaten hinzugefügt werden, der Unterschied ist jedoch in der Regel vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten anzeigen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien, die WordArt enthalten, in Bilder (z. B. PNG, JPEG) rendern mit [ISlide::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/getimage/), oder einzelne Formen mit [IShape::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/getimage/). So können Sie das Ergebnis im Speicher oder auf dem Bildschirm prüfen, bevor Sie die gesamte Präsentation speichern oder exportieren.