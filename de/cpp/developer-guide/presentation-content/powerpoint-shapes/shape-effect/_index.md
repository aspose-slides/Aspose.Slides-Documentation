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
- Weiche Kanten Effekt
- Effektformat
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Transformieren Sie Ihre PPT- und PPTX-Dateien mit erweiterten Formeffekten mithilfe von Aspose.Slides für C++ — erstellen Sie in Sekunden eindrucksvolle, professionelle Folien."
---
## **Einführung**

Während Effekte in PowerPoint dazu verwendet werden können, eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/cpp/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen auf einer Form erzeugen, das Leuchten einer Form verbreiten usw.

![Shape effect](shape-effect.png)

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einen oder mehrere Effekte auf eine Form anwenden.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund bietet PowerPoint Optionen unter **Preset**. Die Preset‑Optionen sind im Wesentlichen eine Kombination aus zwei oder mehr Effekten, von denen bekannt ist, dass sie gut zusammen aussehen. Auf diese Weise müssen Sie beim Auswählen eines Presets keine Zeit damit verschwenden, verschiedene Effekte zu testen oder zu kombinieren, um eine passende Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) bereit, mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Schatteneffekt anwenden**

Aspose.Slides für C++ unterstützt äußere und innere Schatten für Formen. Sie können deren Farbe, Richtung, Abstand und Weichzeichnungsradius an das Design Ihrer Präsentation anpassen.

### **Äußeren Schatten anwenden**

Verwenden Sie einen äußeren Schatten, um eine Karte oder ein Panel vor dem Folienhintergrund hervorzuheben. Der Schatten erstreckt sich über die Kanten der Form hinaus und erzeugt den Eindruck, dass die Form über der Folie schwebt. Passen Sie Farbe, Richtung, Abstand und Weichzeichnungsradius an die Beleuchtung und das Design Ihrer Vorlage an.

Dieser C++‑Code zeigt, wie man den [äußerer Schatteneffekt](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) auf ein Rechteck anwendet:

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

![Shadow effect](shadow_effect.png)

### **Inneren Schatten anwenden**

Wenn Sie das visuelle Design einer Vorlage nachbilden, verwenden Sie einen inneren Schatten, um einer Karte oder einem Panel ein vertieftes Erscheinungsbild zu verleihen. Ein äußerer Schatten erstreckt sich außerhalb der Form und lässt sie erhöht wirken, während ein innerer Schatten das Innere ihrer Kanten abdunkelt.

Rufen Sie [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) auf und konfigurieren Sie dann [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Größere Weichzeichnungsradius‑Werte erzeugen weichere Kanten.

Dieses C++‑Beispiel erstellt eine hellblaue Karte mit einem dunkelgrauen inneren Schatten und speichert sie als PPTX‑Datei:

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Um den inneren Schatten zu entfernen, rufen Sie [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) im EffectFormat der Form auf.

## **Reflexionseffekt anwenden**

Um in Aspose.Slides für C++ einen Reflexionseffekt anzuwenden, können Sie Formen eine spiegelähnliche Reflexion hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert die Ästhetik Ihrer Präsentationen, indem er Formen ein polierteres und anspruchsvolleres Aussehen verleiht. Er lässt sich mit einfachem Code leicht umsetzen und ermöglicht eine schnelle Anwendung auf mehrere Elemente für ein konsistentes Design.

Dieser C++‑Code zeigt, wie man den [Reflexionseffekt](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) auf eine Form anwendet:

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

![Reflection effect](reflection_effect.png)

## **Leuchteffekt anwenden**

Um in Aspose.Slides für C++ einen Leuchteffekt auf eine Form anzuwenden, können Sie eine weiche, leuchtende Aura um die Formen hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt lässt Formen hervortreten und fügt Ihrer Präsentation ein attraktives, auffälliges visuelles Element hinzu. Er lässt sich mit minimalem Code leicht implementieren und verbessert das Gesamtbild Ihrer Folien.

Dieser C++‑Code zeigt, wie man den [Leuchteffekt](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) auf eine Form anwendet:

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

![Glow effect](glow_effect.png)

## **Weiche Kanten anwenden**

Um in Aspose.Slides für C++ einen Weiche‑Kanten‑Effekt anzuwenden, können Sie einen glatten, verschwommenen Übergang rund um die Kanten einer Form erzeugen. Dieser Effekt verleiht ein subtileres und raffinierteres Aussehen, ideal für Designs, die ein sanftes, weicheres Erscheinungsbild benötigen. Sie können Parameter wie den Radius leicht anpassen, um den gewünschten Effekt auf verschiedene Formen in Ihrer Präsentation zu erzielen.

Dieser C++‑Code zeigt, wie man den [Weiche Kanten](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) auf eine Form anwendet:

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

![Soft edges effect](soft_edges_effect.png)

## **Unschärfeeffekt anwenden**

Verwenden Sie Formunschärfe, um die Füllung und Kontur einer Form zu weicher zu machen, wobei die Form bearbeitbar bleibt. Rufen Sie [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) im EffectFormat der Form auf. Der Radius wird in Punkten (1/72 Zoll) gemessen: Verwenden Sie einen nichtnegativen Wert, wobei größere Werte eine stärkere Unschärfe erzeugen. Ein Radius von null lässt das Aussehen unverändert.

Die Einstellung [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) steuert die sichtbaren Grenzen des Effekts. Bei `false` wird die Unschärfe auf die ursprünglich gemalten Grenzen, einschließlich der Kontur, zugeschnitten. Bei `true` kann die Unschärfe über diese Grenzen hinausgehen. Keine der beiden Einstellungen ändert die Position oder die Abmessungen der Form.

Der Vergleich unten verwendet durchgängig dieselbe Füllung, Kontur und Formabmessungen. Die obere Zeile verwendet `grow = false`; die untere Zeile verwendet `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Dieses C++‑Beispiel erstellt ein orangefarbenes Rechteck mit einer dunkelblauen Kontur, wendet eine 5‑Punkte‑Unschärfe an und aktualisiert es anschließend zu einer 15‑Punkte‑Unschärfe, indem es erneut [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) aufruft. Es speichert beide unscharfen Zustände, ruft dann [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) auf und speichert die Form ohne Unschärfe.

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

Formunschärfe wirkt sich gleichzeitig auf die Füllung und die Kontur aus. Ein Weiche‑Kanten‑Effekt verblasst die Kanten der Form, während Schatten‑Unschärfe nur den Schatten weicher macht. Bildtransformations‑Effekte wirken auf Bildinhalte; dieses Beispiel wendet Unschärfe direkt auf das EffectFormat der Form an, ohne die Form in ein Bild zu konvertieren.

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte, wie Schatten, Reflexion und Leuchten, auf einer einzelnen Form kombinieren, um ein dynamischeres Aussehen zu erzeugen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, einschließlich Autoformen, Diagrammen, Tabellen, Bildern, SmartArt‑Objekten, OLE‑Objekten und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.