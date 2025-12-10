---
title: WordArt-Effekte in C++ erstellen und anwenden
linktitle: WordArt
type: docs
weight: 110
url: /de/cpp/wordart/
keywords:
- WordArt
- WordArt erstellen
- WordArt-Vorlage
- WordArt-Effekt
- Schatteneffekt
- Darstellungseffekt
- Leuchteffekt
- WordArt-Transformation
- 3D-Effekt
- äußerer Schatteneffekt
- innerer Schatteneffekt
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erstellen und Anpassen von WordArt-Effekten in Aspose.Slides für C++. Dieser Schritt-für-Schritt-Leitfaden hilft Entwicklern, Präsentationen mit professionellem Text in C++ zu verbessern."
---

## **Über WordArt?**
WordArt oder Word Art ist ein Feature, das Ihnen ermöglicht, Effekte auf Texte anzuwenden, damit sie hervorstechen. Mit WordArt können Sie zum Beispiel einen Text umreißen oder ihn mit einer Farbe (oder einem Farbverlauf) füllen, 3D‑Effekte hinzufügen usw. Außerdem können Sie die Form eines Textes schräg stellen, biegen und strecken. 

{{% alert color="primary" %}} 

WordArt erlaubt es Ihnen, einen Text so zu behandeln, wie Sie ein grafisches Objekt behandeln würden. Im Allgemeinen besteht WordArt aus Effekten oder speziellen Modifikationen, die auf Texte angewendet werden, um sie ansprechender oder auffälliger zu machen. 

{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu nutzen, müssen Sie eine der vordefinierten WordArt‑Vorlagen auswählen. Eine WordArt‑Vorlage ist ein Satz von Effekten, die auf einen Text oder dessen Form angewendet werden. 

**WordArt in Aspose.Slides**

In Aspose.Slides für C++ 20.10 haben wir Unterstützung für WordArt implementiert und das Feature in nachfolgenden Aspose.Slides‑Releases für C++ weiter verbessert. 

Mit Aspose.Slides für C++ können Sie ganz einfach Ihre eigene WordArt‑Vorlage (ein einzelner Effekt oder eine Kombination von Effekten) in C++ erstellen und sie auf Texte anwenden. 

## **Eine einfache WordArt‑Vorlage erstellen und auf Text anwenden**

**Mit Aspose.Slides** 

Zuerst erstellen wir einen einfachen Text mit folgendem C++‑Code: 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```


Nun setzen wir die Schriftgröße des Textes auf einen größeren Wert, damit der Effekt besser sichtbar wird, mittels dieses Codes:
``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```


**Mit Microsoft PowerPoint**

Gehen Sie zum WordArt‑Effekte‑Menü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Im rechten Bereich können Sie einen vordefinierten WordArt‑Effekt auswählen. Im linken Bereich können Sie die Einstellungen für ein neues WordArt festlegen. 

Dies sind einige der verfügbaren Parameter oder Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Mit Aspose.Slides**

Hier wenden wir die SmallGrid‑Musterfarbe auf den Text an und fügen einen 1‑Punkt‑breiten schwarzen Textrahmen mit folgendem Code hinzu:
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

## **Weitere WordArt‑Effekte anwenden**

**Mit Microsoft PowerPoint**

Über die Benutzeroberfläche des Programms können Sie diese Effekte auf einen Text, Textblock, eine Form oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Beispielsweise können Schatten-, Reflexions‑ und Leuchteffekte auf einen Text angewendet werden; 3D‑Format‑ und 3D‑Drehungseffekte auf einen Textblock; die Eigenschaft „Weiche Kanten“ kann auf ein Formobjekt angewendet werden (sie wirkt weiterhin, wenn keine 3D‑Format‑Eigenschaft gesetzt ist). 

### **Schatteneﬀekte auf Text anwenden**

Hier wollen wir nur die Eigenschaften eines Textes setzen. Wir wenden den Schatteneffekt auf einen Text mit folgendem C++‑Code an:
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


Die Aspose.Slides‑API unterstützt drei Schattenarten: OuterShadow, InnerShadow und PresetShadow. 

Mit PresetShadow können Sie einen Schatten für einen Text anwenden (unter Verwendung voreingestellter Werte). 

**Mit Microsoft PowerPoint**

In PowerPoint können Sie nur einen Schatten­typ verwenden. Hier ein Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Mit Aspose.Slides**

Aspose.Slides ermöglicht es Ihnen, gleichzeitig zwei Schattenarten anzuwenden: InnerShadow und PresetShadow.

**Hinweise:**

- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow‑Effekt angewendet. 
- Bei gleichzeitiger Verwendung von OuterShadow und InnerShadow hängt der resultierende Effekt von der PowerPoint‑Version ab. In PowerPoint 2013 wird der Effekt verdoppelt, in PowerPoint 2007 wird der OuterShadow‑Effekt angewendet. 

### **Reflexions‑Effekte anwenden**

Wir fügen dem Text mit folgendem C++‑Code eine Reflexion hinzu:
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


### **Leuchte‑Effekte anwenden**

Wir wenden den Leuchte‑Effekt auf den Text an, damit er leuchtet oder hervorsticht, mittels dieses Codes:
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

Sie können die Parameter für Schatten, Reflexion und Leuchte ändern. Die Eigenschaften der Effekte werden für jeden Textabschnitt separat gesetzt. 

{{% /alert %}} 

### **Transformationen in WordArt verwenden**

Wir verwenden die Methode set_Transform (gelten für den gesamten Textblock) mit folgendem Code:
``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```


Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Sowohl Microsoft PowerPoint als auch Aspose.Slides für C++ bieten eine Reihe vordefinierter Transformationstypen. 

{{% /alert %}} 

**Mit PowerPoint**

Um vordefinierte Transformationstypen zu öffnen, gehen Sie zu: **Format** → **TextEffect** → **Transform** 

**Mit Aspose.Slides**

Zur Auswahl eines Transformationstyps verwenden Sie das Enum TextShapeType. 

### **3D‑Effekte auf Text und Formen anwenden**

Wir setzen einen 3D‑Effekt auf eine Textform mit folgendem Beispielcode:
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

Wir wenden einen 3D‑Effekt auf den Text mit diesem C++‑Code an:
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

Die Anwendung von 3D‑Effekten auf Texte oder deren Formen und die Wechselwirkungen zwischen Effekten basieren auf bestimmten Regeln. 

Betrachten Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3D‑Effekt enthält die 3D‑Objektrepräsentation und die Szene, in der das Objekt platziert wurde. 

- Wenn die Szene sowohl für die Form als auch für den Text festgelegt ist, hat die Form‑Szene höhere Priorität – die Text‑Szene wird ignoriert. 
- Wenn die Form keine eigene Szene hat, aber eine 3D‑Repräsentation, wird die Text‑Szene verwendet. 
- Andernfalls – wenn die Form ursprünglich keinen 3D‑Effekt hat – ist die Form flach und der 3D‑Effekt wird nur auf den Text angewendet. 

Diese Beschreibungen hängen mit den Methoden ThreeDFormat.getLightRig() und ThreeDFormat.getCamera() zusammen.

{{% /alert %}} 

## **Äußere Schatten‑Effekte auf Formen anwenden**
Aspose.Slides für C++ stellt die Klassen [**IOuterShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_outer_shadow) und [**IInnerShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_inner_shadow) bereit, mit denen Sie Schatten‑Effekte auf einen Text im TextFrame anwenden können. Vorgehensweise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)-Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie der Folie eine AutoShape vom Typ Rectangle hinzu.  
4. Greifen Sie auf das TextFrame der AutoShape zu.  
5. Setzen Sie den FillType der AutoShape auf NoFill.  
6. Instanziieren Sie die Klasse OuterShadow.  
7. Setzen Sie den BlurRadius des Schattens.  
8. Setzen Sie die Direction des Schattens.  
9. Setzen Sie den Distance des Schattens.  
10. Setzen Sie RectanglelAlign auf TopLeft.  
11. Setzen Sie PresetColor des Schattens auf Black.  
12. Schreiben Sie die Präsentation als PPTX‑Datei.

Dieser C++‑Beispielcode – eine Umsetzung der obigen Schritte – zeigt, wie Sie den äußeren Schatten‑Effekt auf einen Text anwenden:
``` cpp
auto pres = System::MakeObject<Presentation>();
// Referenz der Folie erhalten
auto sld = pres->get_Slides()->idx_get(0);

// AutoShape vom Typ Rechteck hinzufügen
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// TextFrame zum Rechteck hinzufügen
ashp->AddTextFrame(u"Aspose TextBox");

// Füllung der Form deaktivieren, falls wir den Textschatten erhalten wollen
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Äußeren Schatten hinzufügen und alle erforderlichen Parameter festlegen
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



## **Innere Schatten‑Effekte auf Formen anwenden**
Vorgehensweise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)-Klasse.  
2. Holen Sie die Referenz der Folie.  
3. Fügen Sie eine AutoShape vom Typ Rectangle hinzu.  
4. Aktivieren Sie InnerShadowEffect.  
5. Setzen Sie alle notwendigen Parameter.  
6. Setzen Sie ColorType auf Scheme.  
7. Setzen Sie die Scheme‑Farbe.  
8. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Dieser Beispielcode (basierend auf den obigen Schritten) zeigt, wie Sie in C++ einen Connector zwischen zwei Formen hinzufügen:
``` cpp
auto presentation = System::MakeObject<Presentation>();
// Referenz einer Folie erhalten
auto slide = presentation->get_Slides()->idx_get(0);

// AutoShape vom Typ Rechteck hinzufügen
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// TextFrame zum Rechteck hinzufügen
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// InnerShadowEffect aktivieren    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Alle erforderlichen Parameter festlegen
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// ColorType auf Schema setzen
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Scheme-Farbe setzen
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Präsentation speichern
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Kann ich WordArt‑Effekte mit verschiedenen Schriften oder Skripten (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides unterstützt Unicode und arbeitet mit allen gängigen Schriftarten und Skripten. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung der Schriftarten vom System abhängen können.

**Kann ich WordArt‑Effekte auf Elemente des Folienmasters anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen im Master‑Layout anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtexten. Änderungen am Master‑Layout werden auf alle zugehörigen Folien übertragen.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. Schatten, Leuchteffekte und Farbverläufe können die Dateigröße geringfügig erhöhen, da zusätzliche Formatierungs‑Metadaten gespeichert werden, doch in der Regel ist der Unterschied vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten ansehen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien mit WordArt in Bildformate (z. B. PNG, JPEG) rendern, indem Sie die `GetImage`‑Methode der [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)‑ bzw. [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/)‑Schnittstelle verwenden. So können Sie das Ergebnis im Speicher oder auf dem Bildschirm prüfen, bevor Sie die vollständige Präsentation speichern oder exportieren.