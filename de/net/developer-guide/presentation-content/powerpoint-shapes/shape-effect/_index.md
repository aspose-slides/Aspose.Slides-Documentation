---
title: Formeffekte in Präsentationen mit .NET anwenden
linktitle: Formeffekt
type: docs
weight: 30
url: /de/net/shape-effect/
keywords:
- Formeffekt
- Schatteneffekt
- Reflexionseffekt
- Leuchteffekt
- Weiche Kanten Effekt
- Effektformat
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Transformieren Sie Ihre PPT- und PPTX-Dateien mit erweiterten Formeffekten mithilfe von Aspose.Slides für .NET – erstellen Sie in Sekunden eindrucksvolle, professionelle Folien."
---
## **Einleitung**

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/net/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen auf einer Form erzeugen, den Schein einer Form verbreiten usw.

![Formeffekt](shape-effect.png)

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können ein oder mehrere Effekte auf eine Form anwenden.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund bietet PowerPoint Optionen unter **Preset**. Die Preset‑Optionen sind im Wesentlichen eine bewährte, gut aussehende Kombination aus zwei oder mehr Effekten. Auf diese Weise müssen Sie durch Auswahl eines Presets keine Zeit damit verbringen, verschiedene Effekte zu testen oder zu kombinieren, um eine passende Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) bereit, mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Schatteneffekt anwenden**

Aspose.Slides für .NET unterstützt äußere und innere Schatten für Formen. Sie können deren Farbe, Richtung, Abstand und Unschärferadius an das Design Ihrer Präsentation anpassen.

### **Äußeren Schatten anwenden**

Verwenden Sie einen äußeren Schatten, um eine Karte oder ein Feld gegenüber dem Folienhintergrund hervorzuheben. Der Schatten erstreckt sich über die Kanten der Form hinaus und erzeugt den Eindruck, dass die Form über die Folie gehoben ist. Passen Sie Farbe, Richtung, Abstand und Unschärferadius an die Beleuchtung und das Styling Ihrer Vorlage an.

Dieser C#‑Code zeigt, wie Sie den [äußerer Schatten‑Effekt](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) auf ein Rechteck anwenden:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![Schatteneffekt](shadow_effect.png)

### **Inneren Schatten anwenden**

Beim Nachahmen des visuellen Stils einer Vorlage verwenden Sie einen inneren Schatten, um einer Karte oder einem Feld ein vertieftes Aussehen zu verleihen. Ein äußerer Schatten erstreckt sich außerhalb der Form und lässt sie erhaben wirken, während ein innerer Schatten die Innenseite ihrer Kanten schattiert.

Rufen Sie [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) auf und konfigurieren Sie anschließend [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Größere Werte erzeugen weichere Kanten.

Dieses C#‑Beispiel erstellt eine hellblaue Karte mit einem dunkelgrauen inneren Schatten und speichert sie als PPTX‑Datei:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![Hellblaues Rechteck mit innerem Schatten](inner_shadow_effect.png)

Um den inneren Schatten zu entfernen, rufen Sie [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) im Effektformat der Form auf.

## **Reflexionseffekt anwenden**

Um einen Reflexionseffekt in Aspose.Slides für .NET anzuwenden, können Sie Formen eine spiegelähnliche Reflexion hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert die Ästhetik Ihrer Präsentationen, indem er Formen ein polierteres und anspruchsvolleres Aussehen verleiht. Er lässt sich mit einfachem Code leicht implementieren, wodurch eine schnelle Anwendung auf mehrere Elemente für ein konsistentes Design ermöglicht wird.

Dieser C#‑Code zeigt, wie Sie den [Reflexionseffekt](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) auf eine Form anwenden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```

![Reflexionseffekt](reflection_effect.png)

## **Leuchteffekt anwenden**

Um einen Leuchteffekt auf eine Form in Aspose.Slides für .NET anzuwenden, können Sie eine weiche, leuchtende Aura um Formen hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt lässt Formen hervorstechen und fügt Ihrer Präsentation ein attraktives, auffälliges visuelles Element hinzu. Er lässt sich mit minimalem Code leicht implementieren und verbessert das Gesamterscheinungsbild Ihrer Folien.

Dieser C#‑Code zeigt, wie Sie den [Leuchteffekt](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) auf eine Form anwenden:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![Leuchteffekt](glow_effect.png)

## **Weiche Kanten-Effekt anwenden**

Um einen Weiche‑Kanten‑Effekt in Aspose.Slides für .NET anzuwenden, können Sie einen sanften, unscharfen Übergang um die Ränder einer Form erzeugen. Dieser Effekt verleiht ein subtileres und eleganteres Aussehen, ideal für Designs, die ein sanftes, weicheres Erscheinungsbild benötigen. Sie können Parameter wie den Radius einfach anpassen, um den gewünschten Effekt über verschiedene Formen in Ihrer Präsentation zu erzielen.

Dieser C#‑Code zeigt, wie Sie den [weiche Kanten](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) auf eine Form anwenden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Weiche Kanten-Effekt](soft_edges_effect.png)

## **Unschärfe-Effekt anwenden**

Verwenden Sie Formen‑Unschärfe, um die Füllung und Kontur einer Form zu erweichen, während die Form bearbeitbar bleibt. Rufen Sie [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) im Effektformat der Form auf. Der Radius wird in Punkten (1/72 Zoll) gemessen: Verwenden Sie einen nicht‑negativen Wert, wobei größere Werte stärkere Unschärfe erzeugen. Ein Radius von null lässt das Aussehen unverändert.

Die [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) Einstellung steuert die sichtbaren Grenzen des Effekts. Bei `false` wird die Unschärfe auf die ursprünglich gemalten Grenzen, einschließlich der Kontur, beschnitten. Bei `true` kann die Unschärfe über diese Grenzen hinausgehen. Keine der beiden Einstellungen verändert die Position oder die Abmessungen der Form.

Der Vergleich unten verwendet durchgehend dieselbe Füllung, Kontur und Formabmessungen. Die obere Reihe nutzt `grow = false`; die untere Reihe nutzt `grow = true`.

![Originales Rechteck im Vergleich mit Unschärferadien von 5 und 15 Punkten, mit deaktiviertem und aktiviertem Grow](shape_blur_comparison.png)

Dieses C#‑Beispiel erstellt ein orangefarbenes Rechteck mit einer dunkelblauen Kontur, wendet eine 5‑Punkt‑Unschärfe an und aktualisiert es anschließend zu einer 15‑Punkt‑Unschärfe, indem es erneut [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) aufruft. Es speichert beide unscharfen Zustände, ruft dann [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) auf und speichert die Form ohne Unschärfe.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

Form‑Unschärfe wirkt sich sowohl auf die Füllung als auch auf die Kontur aus. Ein Weiche‑Kanten‑Effekt verblasst die Kanten der Form, während Schatten‑Unschärfe nur den Schatten weichzeichnet. Bild‑Transformations‑Effekte wirken auf den Bildinhalt; dieses Beispiel wendet Unschärfe direkt auf das Effektformat der Form an, ohne die Form in ein Bild zu konvertieren.

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte, wie Schatten, Reflexion und Leuchteffekt, auf einer einzelnen Form kombinieren, um ein dynamischeres Aussehen zu erzeugen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, einschließlich Autoformen, Diagrammen, Tabellen, Bildern, SmartArt‑Objekten, OLE‑Objekten und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.