---
title: "Shape-Effekte in Präsentationen in .NET anwenden"
linktitle: "Shape-Effekt"
type: docs
weight: 30
url: /de/net/shape-effect
keywords:
- "Shape-Effekt"
- "Schatten-Effekt"
- "Reflexionseffekt"
- "Glow-Effekt"
- "Weiche Kanten-Effekt"
- "Effektformat"
- "PowerPoint"
- "Präsentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Transformieren Sie Ihre PPT- und PPTX-Dateien mit erweiterten Shape-Effekten mithilfe von Aspose.Slides für .NET – erstellen Sie in Sekundenschnelle eindrucksvolle, professionelle Folien."
---

## **Übersicht**

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/net/shape-formatting/#gradient-fill) oder Umrandungen. Mit PowerPoint‑Effekten können Sie überzeugende Reflexionen einer Form erzeugen, den Schein einer Form verbreiten usw.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einen oder mehrere Effekte auf eine Form anwenden.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund bietet PowerPoint Optionen unter **Preset**. Die Preset‑Optionen sind im Wesentlichen eine bewährte, gut aussehende Kombination aus zwei oder mehr Effekten. Auf diese Weise müssen Sie durch Auswählen eines Presets keine Zeit damit verschwenden, verschiedene Effekte zu testen oder zu kombinieren, um eine passende Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) bereit, mit denen Sie die gleichen Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Schatteneffekt anwenden**

Um einen Schatteneffekt auf eine Form in Aspose.Slides für .NET anzuwenden, können Sie Parameter wie Farbe, Unschärferadius und Richtung einfach anpassen. Dadurch erhalten Ihre Formen ein dynamischeres und professionelleres Erscheinungsbild, das Tiefe und Fokus verleiht. Mit einfachen Code‑Snippets können Sie diese Effekte auf mehrere Formen anwenden und so die visuelle Attraktivität Ihrer Präsentationen steigern.

Dieser C#‑Code zeigt, wie Sie den [outer shadow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) auf ein Rechteck anwenden:
```c#
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

## **Reflexionseffekt anwenden**

Um einen Reflexionseffekt in Aspose.Slides für .NET anzuwenden, können Sie Formen eine spiegelähnliche Reflexion hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert das ästhetische Erscheinungsbild Ihrer Präsentationen, indem er Formen ein polierteres und anspruchsvolleres Aussehen verleiht. Die Implementierung ist mit einfachem Code leicht möglich und ermöglicht eine schnelle Anwendung auf mehrere Elemente für ein konsistentes Design.

Dieser C#‑Code zeigt, wie Sie den [reflection effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) auf eine Form anwenden:
```c#
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

## **Glow‑Effekt anwenden**

Um einen Glow‑Effekt auf eine Form in Aspose.Slides für .NET anzuwenden, können Sie eine weiche, leuchtende Aura um Formen hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt lässt Formen hervortreten und fügt Ihrer Präsentation ein attraktives, aufmerksamkeitsstarkes visuelles Element hinzu. Die Implementierung ist mit minimalem Code einfach und verbessert das Gesamtbild Ihrer Folien.

Dieser C#‑Code zeigt, wie Sie den [glow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) auf eine Form anwenden:
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```


![Glow‑Effekt](glow_effect.png)

## **Soft‑Edges‑Effekt anwenden**

Um einen Soft‑Edges‑Effekt in Aspose.Slides für .NET anzuwenden, können Sie einen sanften, unscharfen Übergang um die Kanten einer Form erzeugen. Dieser Effekt verleiht ein subtileres und raffinierteres Aussehen, ideal für Designs, die ein sanftes Erscheinungsbild benötigen. Sie können Parameter wie den Radius leicht anpassen, um den gewünschten Effekt auf verschiedene Formen in Ihrer Präsentation zu erzielen.

Dieser C#‑Code zeigt, wie Sie die [soft edges](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) auf eine Form anwenden:
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```


![Soft‑Edges‑Effekt](soft_edges_effect.png)

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte wie Schatten, Reflexion und Glow auf einer einzelnen Form kombinieren, um ein dynamischeres Erscheinungsbild zu erzeugen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, darunter Autoformen, Diagramme, Tabellen, Bilder, SmartArt‑Objekte, OLE‑Objekte und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.