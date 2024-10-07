---
title: WordArt
type: docs
weight: 110
url: /cpp/wordart/
---

## **Über WordArt?**
WordArt oder Word Art ist eine Funktion, mit der Sie Texteffekte anwenden können, um Texte hervorzuheben. Mit WordArt können Sie beispielsweise einen Text umreißen oder ihn mit einer Farbe (oder einem Verlauf) füllen, 3D-Effekte hinzufügen usw. Sie können auch die Form eines Textes verzerren, biegen und strecken.

{{% alert color="primary" %}} 

WordArt ermöglicht es Ihnen, einen Text wie ein grafisches Objekt zu behandeln. Im Allgemeinen besteht WordArt aus Effekten oder speziellen Modifikationen, die an Texten vorgenommen werden, um sie attraktiver oder auffälliger zu machen.

{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu verwenden, müssen Sie eine der vordefinierten WordArt-Vorlagen auswählen. Eine WordArt-Vorlage ist eine Menge von Effekten, die auf einen Text oder seine Form angewendet werden.

**WordArt in Aspose.Slides**

In Aspose.Slides für C++ 20.10 haben wir die Unterstützung für WordArt implementiert und die Funktion in den nachfolgenden Versionen von Aspose.Slides für C++ verbessert.

Mit Aspose.Slides für C++ können Sie ganz einfach Ihre eigene WordArt-Vorlage (einen Effekt oder eine Kombination von Effekten) in C++ erstellen und auf Texte anwenden.

## Erstellen einer einfachen WordArt-Vorlage und Anwenden auf einen Text

**Mit Aspose.Slides**

Zuerst erstellen wir einen einfachen Text mit diesem C++-Code:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Jetzt setzen wir die Schriftgröße des Textes auf einen größeren Wert, um den Effekt durch diesen Code auffälliger zu machen:

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Mit Microsoft PowerPoint**

Gehen Sie zum WordArt-Effekte-Menü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Im Menü auf der rechten Seite können Sie einen vordefinierten WordArt-Effekt auswählen. Im Menü auf der linken Seite können Sie die Einstellungen für eine neue WordArt festlegen.

Dies sind einige der verfügbaren Parameter oder Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Mit Aspose.Slides**

Hier wenden wir die SmallGrid-Musterfarbe auf den Text an und fügen einen schwarzen Textumriss von 1 Breite mit diesem Code hinzu:

``` cpp 
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

## Andere WordArt-Effekte anwenden

**Mit Microsoft PowerPoint**

Von der Benutzeroberfläche des Programms aus können Sie diese Effekte auf einen Text, Textblock, eine Form oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Zum Beispiel können Schatten-, Reflexions- und Leuchteffekte auf einen Text angewendet werden; 3D-Format- und 3D-Drehungseffekte können auf einen Textblock angewendet werden; die Soft Edges-Eigenschaft kann auf ein Shape-Objekt angewendet werden (sie hat auch einen Effekt, wenn keine 3D-Format-Eigenschaft eingestellt ist).

### Schatteneffekte anwenden

Hier beabsichtigen wir, die Eigenschaften nur für einen Text festzulegen. Wir wenden den Schatteneffekt auf einen Text mit diesem Code in C++ an:

``` cpp 
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

Die Aspose.Slides-API unterstützt drei Arten von Schatten: OuterShadow, InnerShadow und PresetShadow. 

Mit PresetShadow können Sie einen Schatten für einen Text anwenden (unter Verwendung vordefinierter Werte).

**Mit Microsoft PowerPoint**

In PowerPoint können Sie eine Art von Schatten verwenden. Hier ist ein Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Mit Aspose.Slides**

Aspose.Slides ermöglicht es Ihnen tatsächlich, zwei Arten von Schatten gleichzeitig anzuwenden: InnerShadow und PresetShadow.

**Hinweise:**

- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow-Effekt angewendet. 
- Wenn OuterShadow und InnerShadow gleichzeitig verwendet werden, hängt der resultierende oder angewendete Effekt von der Version von PowerPoint ab. Zum Beispiel wird in PowerPoint 2013 der Effekt verdoppelt. Aber in PowerPoint 2007 wird der OuterShadow-Effekt angewendet.

### Anzeige auf Texten anwenden

Wir fügen dem Text durch dieses C++-Beispiel eine Anzeige hinzu:

``` cpp 
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

### Leuchteffekt auf Texten anwenden

Wir wenden den Leuchteffekt auf den Text an, um ihn zum Strahlen oder Hervorheben zu bringen, indem wir diesen Code verwenden:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Sie können die Parameter für Schatten, Anzeige und Leuchten ändern. Die Eigenschaften der Effekte werden für jeden Abschnitt des Textes separat festgelegt.

{{% /alert %}} 

### Transformationen in WordArt verwenden

Wir verwenden die set_Transform-Methode (die im gesamten Textblock vorhanden ist) durch diesen Code:

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Sowohl Microsoft PowerPoint als auch Aspose.Slides für C++ bieten eine bestimmte Anzahl von vordefinierten Transformationstypen.

{{% /alert %}} 

**Mit PowerPoint**

Um auf vordefinierte Transformationstypen zuzugreifen, gehen Sie zu: **Format** -> **TextEffekt** -> **Transformieren**

**Mit Aspose.Slides**

Um einen Transformationstyp auszuwählen, verwenden Sie die TextShapeType-Enum. 

### 3D-Effekte auf Texte und Formen anwenden

Wir setzen einen 3D-Effekt auf eine Textform mit diesem Beispielcode:

``` cpp 
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

Wir wenden einen 3D-Effekt auf den Text mit diesem C++-Code an:

``` cpp 
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

{{% alert color="primary" %}} 

Die Anwendung von 3D-Effekten auf Texte oder deren Formen und die Interaktionen zwischen Effekten basieren auf bestimmten Regeln.

Betrachten Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3D-Effekt enthält die 3D-Objektdarstellung und die Szene, auf der das Objekt platziert wurde.

- Wenn die Szene sowohl für die Figur als auch für den Text festgelegt ist, hat die Figurenszene die höchste Priorität—die Textszene wird ignoriert. 
- Wenn die Figur keine eigene Szene hat, aber eine 3D-Darstellung hat, wird die Textszene verwendet. 
- Andernfalls—wenn die Form ursprünglich keinen 3D-Effekt hat—ist die Form flach und der 3D-Effekt wird nur auf den Text angewendet. 

Diese Beschreibungen sind mit den Methoden ThreeDFormat.getLightRig() und ThreeDFormat.getCamera() verbunden.

{{% /alert %}} 

## **Äußere Schatteneffekte auf Texte anwenden**
Aspose.Slides für C++ bietet die [**IOuterShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_outer_shadow) und [**IInnerShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_inner_shadow) Klassen, die es Ihnen ermöglichen, Schatteneffekte auf einen Text anzuwenden, der von TextFrame getragen wird. Gehen Sie diese Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.
4. Greifen Sie auf das mit der AutoShape verbundene TextFrame zu.
5. Setzen Sie den FillType der AutoShape auf NoFill.
6. Instanzieren Sie die OuterShadow-Klasse.
7. Setzen Sie den BlurRadius des Schattens.
8. Setzen Sie die Richtung des Schattens.
9. Setzen Sie die Entfernung des Schattens.
10. Setzen Sie die RectangleAlign auf TopLeft.
11. Setzen Sie die PresetColor des Schattens auf Schwarz.
12. Speichern Sie die Präsentation als PPTX-Datei.

Dieser Beispielcode in C++—eine Implementierung der obigen Schritte—zeigt Ihnen, wie Sie den äußeren Schatteneffekt auf einen Text anwenden:

``` cpp
auto pres = System::MakeObject<Presentation>();
// Holen Sie sich die Referenz der Folie
auto sld = pres->get_Slides()->idx_get(0);

// Fügen Sie eine AutoShape vom Typ Rechteck hinzu
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Fügen Sie dem Rechteck ein TextFrame hinzu
ashp->AddTextFrame(u"Aspose TextBox");

// Deaktivieren Sie die Formfüllung, falls wir den Schatten des Textes erhalten möchten
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Fügen Sie äußeren Schatten hinzu und setzen Sie alle erforderlichen Parameter
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Präsentation auf der Festplatte speichern
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```


## **Innenschattierungseffekt auf Formen anwenden**
Gehen Sie diese Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Erhalten Sie eine Referenz der Folie.
3. Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
4. Aktivieren Sie den InnerShadowEffect.
5. Setzen Sie alle erforderlichen Parameter.
6. Setzen Sie den ColorType auf Scheme.
7. Setzen Sie die Schemenfarbe.
8. Speichern Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei.

Dieser Beispielcode (basierend auf den oben genannten Schritten) zeigt Ihnen, wie Sie einen Connector zwischen zwei Formen in C++ hinzufügen:

``` cpp
auto presentation = System::MakeObject<Presentation>();
// Holen Sie sich die Referenz einer Folie
auto slide = presentation->get_Slides()->idx_get(0);

// Fügen Sie eine AutoShape vom Typ Rechteck hinzu
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Fügen Sie dem Rechteck ein TextFrame hinzu
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Aktivieren Sie den InnerShadowEffect    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Setzen Sie alle notwendigen Parameter
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// Setzen Sie den ColorType auf Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Setzen Sie die Schemenfarbe
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Präsentation speichern
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```