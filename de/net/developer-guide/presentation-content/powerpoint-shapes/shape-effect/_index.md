---
title: Formeffekte in Präsentationen in .NET anwenden
linktitle: Formeffekt
type: docs
weight: 30
url: /de/net/shape-effect/
keywords:
- Formeffekt
- Schatteneffekt
- Spiegelungseffekt
- Leuchteffekt
- Weichkanteneffekt
- Effektformat
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Transformieren Sie Ihre PPT- und PPTX-Dateien mit fortschrittlichen Formeffekten mithilfe von Aspose.Slides für .NET—erstellen Sie in Sekundenschnelle eindrucksvolle, professionelle Folien."
---
## **Einleitung**

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/net/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen einer Form erzeugen, den Schein einer Form verbreiten usw.

![Formeffekt](shape-effect.png)

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einen oder mehrere Effekte auf eine Form anwenden.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund bietet PowerPoint Optionen unter **Preset**. Die Preset‑Optionen sind im Wesentlichen eine bewährte Kombination aus zwei oder mehr Effekten. Auf diese Weise müssen Sie beim Auswählen eines Presets nicht Zeit damit verbringen, verschiedene Effekte zu testen oder zu kombinieren, um eine gute Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) bereit, mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Einen Schatteneffekt anwenden**

Aspose.Slides für .NET unterstützt äußere und innere Schatten für Formen. Sie können deren Farbe, Richtung, Abstand und Unschärferadius an das Design Ihrer Präsentation anpassen.

### **Äußeren Schatten anwenden**

Verwenden Sie einen äußeren Schatten, um eine Karte oder ein Bedienfeld gegenüber dem Folienhintergrund hervorzuheben. Der Schatten erstreckt sich über die Ränder der Form hinaus und vermittelt den Eindruck, dass die Form über der Folie schwebt. Passen Sie Farbe, Richtung, Abstand und Unschärferadius an, um die Beleuchtung und das Styling Ihrer Vorlage zu ergänzen.

Dieser C#‑Code zeigt, wie Sie den [outer shadow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) auf ein Rechteck anwenden:

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

Wenn Sie das visuelle Styling einer Vorlage reproduzieren, verwenden Sie einen inneren Schatten, um einer Karte oder einem Bedienfeld ein vertieftes Aussehen zu verleihen. Ein äußerer Schatten erstreckt sich außerhalb der Form und lässt sie erhöht erscheinen, während ein innerer Schatten das Innere ihrer Kanten abdunkelt.

Rufen Sie [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) auf und konfigurieren Sie dann [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Größere Werte erzeugen weichere Kanten.

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

## **Einen Spiegelungseffekt anwenden**

Um einen Spiegelungseffekt in Aspose.Slides für .NET anzuwenden, können Sie Formen eine spiegelähnliche Reflexion hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert das ästhetische Erscheinungsbild Ihrer Präsentationen, indem er Formen ein polierteres und anspruchsvolleres Aussehen verleiht. Die Implementierung ist mit einfachem Code leicht zu realisieren und ermöglicht eine schnelle Anwendung auf mehrere Elemente für ein konsistentes Design.

Dieser C#‑Code zeigt, wie Sie den [reflection effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) auf eine Form anwenden:

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

![Spiegelungseffekt](reflection_effect.png)

## **Einen Leuchteffekt anwenden**

Um einen Leuchteffekt auf eine Form in Aspose.Slides für .NET anzuwenden, können Sie einen weichen, leuchtenden Aura um Formen hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt hilft, Formen hervorzuheben und fügt Ihrer Präsentation ein attraktives, auffälliges visuelles Element hinzu. Er lässt sich mit minimalem Code leicht implementieren und verbessert das Gesamterscheinungsbild Ihrer Folien.

Dieser C#‑Code zeigt, wie Sie den [glow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) auf eine Form anwenden:

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

## **Einen Weichkanteneffekt anwenden**

Um einen Weichkanteneffekt in Aspose.Slides für .NET anzuwenden, können Sie einen sanften, unscharfen Übergang um die Kanten einer Form erzeugen. Dieser Effekt verleiht ein subtileres und verfeinertes Aussehen, ideal für Designs, die ein sanftes, weicheres Erscheinungsbild benötigen. Sie können Parameter wie den Radius leicht anpassen, um den gewünschten Effekt bei verschiedenen Formen Ihrer Präsentation zu erzielen.

Dieser C#‑Code zeigt, wie Sie die [soft edges](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) auf eine Form anwenden:

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

![Weichkanteneffekt](soft_edges_effect.png)

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte wie Schatten, Spiegelung und Leuchten auf einer einzelnen Form kombinieren, um ein dynamischeres Aussehen zu erzeugen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, darunter Autoformen, Diagramme, Tabellen, Bilder, SmartArt‑Objekte, OLE‑Objekte und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.