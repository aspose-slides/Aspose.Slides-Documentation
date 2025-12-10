---
title: Formeffekte in Präsentationen mit C++ anwenden
linktitle: Formeffekt
type: docs
weight: 30
url: /de/cpp/shape-effect/
keywords:
- Formeffekt
- Schatteneffekt
- Reflexionseffekt
- Leuchteffekt
- Weiche Kanten-Effekt
- Effektformat
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Transformieren Sie Ihre PPT- und PPTX-Dateien mit erweiterten Formeffekten mithilfe von Aspose.Slides für C++ – erstellen Sie in Sekundenschnelle eindrucksvolle, professionelle Folien."
---

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/cpp/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen auf einer Form erzeugen, den Schein einer Form verbreiten usw.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einer Form ein oder mehrere Effekte zuweisen. 

* Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund gibt es unter PowerPoint die Optionen **Preset**. Die Preset‑Optionen stellen im Wesentlichen eine bewährte, gut aussehende Kombination aus zwei oder mehr Effekten dar. So müssen Sie beim Auswählen eines Presets keine Zeit damit verschwenden, verschiedene Effekte zu testen oder zu kombinieren, um eine ansprechende Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format/) bereit, mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Schatteneffekt anwenden**

Dieser C++‑Code zeigt, wie Sie den äußeren Schatteneffekt ([OuterShadowEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) auf ein Rechteck anwenden:
```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(System::Drawing::Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Reflexionseffekt anwenden**

Dieser C++‑Code zeigt, wie Sie den Reflexionseffekt auf eine Form anwenden:
```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(55);
reflectionEffect->set_BlurRadius(4);

pres->Save(u"reflection.pptx", SaveFormat::Pptx);
```


## **Leuchteffekt anwenden**

Dieser C++‑Code zeigt, wie Sie den Leuchteffekt auf eine Form anwenden:
```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(System::Drawing::Color::get_Magenta());
glowEffect->set_Radius(15);

pres->Save(u"glow.pptx", SaveFormat::Pptx);
```


## **Weiche Kanten‑Effekt anwenden**

Dieser C++‑Code zeigt, wie Sie weiche Kanten auf eine Form anwenden:
```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(15);

pres->Save(u"softEdges.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte, wie Schatten, Reflexion und Leuchteffekt, auf einer einzelnen Form kombinieren, um ein dynamischeres Aussehen zu erzeugen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, darunter Autoformen, Diagramme, Tabellen, Bilder, SmartArt‑Objekte, OLE‑Objekte und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.