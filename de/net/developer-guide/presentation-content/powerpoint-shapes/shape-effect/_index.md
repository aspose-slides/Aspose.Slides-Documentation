---
title: Formeffekte in Präsentationen in .NET anwenden
linktitle: Formeffekt
type: docs
weight: 30
url: /de/net/shape-effect
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
description: "Transformieren Sie Ihre PPT- und PPTX-Dateien mit fortgeschrittenen Formeffekten mithilfe von Aspose.Slides für .NET – erstellen Sie in Sekundenschnelle eindrucksvolle, professionelle Folien."
---

## **Übersicht**

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/net/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen einer Form erzeugen, den Schein einer Form verbreiten usw.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einen oder mehrere Effekte auf eine Form anwenden.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund bietet PowerPoint Optionen unter **Preset**. Die Preset‑Optionen sind im Wesentlichen eine bewährte, gut aussehende Kombination von zwei oder mehr Effekten. Auf diese Weise müssen Sie durch Auswahl eines Presets keine Zeit damit verschwenden, verschiedene Effekte zu testen oder zu kombinieren, um eine passende Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) bereit, mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Schatteneffekt anwenden**

Um einen Schatteneffekt auf eine Form in Aspose.Slides für .NET anzuwenden, können Sie leicht Parameter wie Farbe, Unschärferadius und Richtung anpassen. Dadurch erhalten Ihre Formen ein dynamischeres und professionelleres Erscheinungsbild, das Tiefe und Fokus verleiht. Mit einfachen Code‑Snippets können Sie diese Effekte auf mehrere Formen anwenden und damit die visuelle Gesamterscheinung Ihrer Präsentationen verbessern.

Dieser C#‑Code zeigt, wie man den [Außen‑Schatten‑Effekt](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) auf ein Rechteck anwendet:
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

Um einen Reflexionseffekt in Aspose.Slides für .NET anzuwenden, können Sie Formen eine spiegelnde Reflexion hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert die Ästhetik Ihrer Präsentationen, indem er Formen ein raffinierteres und eleganteres Aussehen verleiht. Er lässt sich mit einfachem Code leicht implementieren und ermöglicht eine schnelle Anwendung auf mehrere Elemente für ein konsistentes Design.

Dieser C#‑Code zeigt, wie man den [Reflexionseffekt](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) auf eine Form anwendet:
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

## **Leuchteffekt anwenden**

Um einen Leuchteffekt auf eine Form in Aspose.Slides für .NET anzuwenden, können Sie um Formen eine sanfte, leuchtende Aura hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt lässt Formen hervorstechen und fügt Ihrer Präsentation ein attraktives, auffälliges visuelles Element hinzu. Er lässt sich mit minimalem Code leicht umsetzen und verbessert das Gesamterscheinungsbild Ihrer Folien.

Dieser C#‑Code zeigt, wie man den [Leuchteffekt](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) auf eine Form anwendet:
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```


![Leuchteffekt](glow_effect.png)

## **Weiche Kanten‑Effekt anwenden**

Um einen weichen Kanten‑Effekt in Aspose.Slides für .NET anzuwenden, können Sie einen sanften, unscharfen Übergang um die Kanten einer Form erzeugen. Dieser Effekt verleiht ein dezenteres und raffinierteres Aussehen, ideal für Designs, die eine sanfte, weichere Optik benötigen. Sie können Parameter wie den Radius leicht anpassen, um den gewünschten Effekt auf verschiedene Formen Ihrer Präsentation zu erzielen.

Dieser C#‑Code zeigt, wie man den [Weiche‑Kanten‑Effekt](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) auf eine Form anwendet:
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```


![Weiche Kanten](soft_edges_effect.png)

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte wie Schatten, Reflexion und Leuchten auf eine einzelne Form kombinieren, um ein dynamischeres Erscheinungsbild zu erzeugen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, einschließlich Autoformen, Diagrammen, Tabellen, Bildern, SmartArt‑Objekten, OLE‑Objekten und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.