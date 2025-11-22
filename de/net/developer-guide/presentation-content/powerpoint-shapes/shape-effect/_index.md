---
title: Formeffekte in PowerPoint mit C#
linktitle: Formeffekt
type: docs
weight: 30
url: /de/net/shape-effect
keywords:
- Formeffekt
- Schatteneffekt
- Reflexionseffekt
- Leuchteffekt
- Weiche Kanten-Effekt
- Fasen-Effekt
- 3-D-Format
- 3-D-Rotation
- PowerPoint
- Präsentation
- C#
- .NET
- Aspose.Slides
description: "Verbessern Sie Ihre PowerPoint-Präsentationen mit beeindruckenden Formeffekten wie Schatten, Reflexionen und Leuchten mithilfe von Aspose.Slides für .NET. Automatisieren Sie visuelle Verbesserungen mit benutzerfreundlichem Code und erstellen Sie mühelos professionell aussehende Folien."
---

## **Übersicht**

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/net/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Reflexionen auf einer Form erzeugen, den Schein einer Form verbreiten usw.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einen oder mehrere Effekte auf eine Form anwenden.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund hat PowerPoint Optionen unter **Preset**. Die Preset‑Optionen sind im Wesentlichen eine bewährte, gut aussehende Kombination aus zwei oder mehr Effekten. Auf diese Weise müssen Sie beim Auswählen eines Presets keine Zeit damit verschwenden, verschiedene Effekte zu testen oder zu kombinieren, um eine schöne Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) bereit, mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Schatteneffekt anwenden**

Um einen Schatteneffekt auf eine Form in Aspose.Slides für .NET anzuwenden, können Sie Parameter wie Farbe, Weichzeichnungsradius und Richtung einfach anpassen. Dadurch erhalten Ihre Formen ein dynamischeres und professionelleres Erscheinungsbild, das Tiefe und Fokus hinzufügt. Mit einfachen Code‑Snippets können Sie diese Effekte auf mehrere Formen anwenden und die visuelle Attraktivität Ihrer Präsentationen insgesamt steigern.

Dieser C#‑Code zeigt, wie Sie den [äußeren Schatteneffekt](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) auf ein Rechteck anwenden:
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

Um in Aspose.Slides für .NET einen Reflexionseffekt anzuwenden, können Sie Formen eine spiegelähnliche Reflexion hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert die Ästhetik Ihrer Präsentationen, indem er Formen ein polierteres und anspruchsvolleres Aussehen verleiht. Er lässt sich mit einfachem Code leicht umsetzen, sodass er schnell auf mehrere Elemente angewendet werden kann, um ein konsistentes Design zu erzielen.

Dieser C#‑Code zeigt, wie Sie den [Reflexionseffekt](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) auf eine Form anwenden:
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

Um einen Leuchteffekt auf eine Form in Aspose.Slides für .NET anzuwenden, können Sie eine weiche, leuchtende Aura um Formen hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt hilft, Formen hervorzuheben und verleiht Ihrer Präsentation ein attraktives, auffälliges visuelles Element. Er lässt sich mit minimalem Code leicht umsetzen und verbessert das Gesamtbild Ihrer Folien.

Dieser C#‑Code zeigt, wie Sie den [Leuchteffekt](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) auf eine Form anwenden:
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

Um in Aspose.Slides für .NET einen weiche Kanten‑Effekt anzuwenden, können Sie einen glatten, unscharfen Übergang um die Ränder einer Form erzeugen. Dieser Effekt verleiht ein subtileres und raffinierteres Aussehen, ideal für Designs, die ein sanftes Erscheinungsbild benötigen. Sie können Parameter wie den Radius leicht anpassen, um den gewünschten Effekt über verschiedene Formen hinweg zu erzielen.

Dieser C#‑Code zeigt, wie Sie den [weiche Kanten](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) auf eine Form anwenden:
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

Ja, Sie können verschiedene Effekte wie Schatten, Reflexion und Leuchten auf einer einzelnen Form kombinieren, um ein dynamischeres Erscheinungsbild zu erzielen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, einschließlich Autoformen, Diagrammen, Tabellen, Bildern, SmartArt‑Objekten, OLE‑Objekten und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.