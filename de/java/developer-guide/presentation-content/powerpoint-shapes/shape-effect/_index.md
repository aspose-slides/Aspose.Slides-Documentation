---
title: Formeffekte in Präsentationen mit Java anwenden
linktitle: Formeffekt
type: docs
weight: 30
url: /de/java/shape-effect/
keywords:
- Formeffekt
- Schatteneffekt
- Spiegelungseffekt
- Schein-Effekt
- Weiche Kanten-Effekt
- Effektformat
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Transformieren Sie Ihre PPT- und PPTX-Dateien mit erweiterten Formeffekten mithilfe von Aspose.Slides für Java – erstellen Sie in Sekundenschnelle eindrucksvolle, professionelle Folien."
---

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/java/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen einer Form erzeugen, den Schein einer Form verbreiten usw.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einen oder mehrere Effekte auf eine Form anwenden.  
* Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund gibt es in PowerPoint die Optionen unter **Preset**. Die Preset‑Optionen sind im Wesentlichen bekannte, gut aussehende Kombinationen von zwei oder mehr Effekten. Auf diese Weise müssen Sie durch Auswahl eines Presets keine Zeit damit verbringen, verschiedene Effekte zu testen oder zu kombinieren, um eine passende Kombination zu finden.

Aspose.Slides bietet Eigenschaften und Methoden in der [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat)-Klasse, die es ermöglichen, dieselben Effekte auf Formen in PowerPoint‑Präsentationen anzuwenden.

## **Schatteneffekt anwenden**

Dieser Java‑Code zeigt, wie der äußere Schatteneffekt ([OuterShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) auf ein Rechteck angewendet wird:
```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Spiegelungseffekt anwenden**

Dieser Java‑Code zeigt, wie der Spiegelungseffekt auf eine Form angewendet wird:
```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Schein‑Effekt anwenden**

Dieser Java‑Code zeigt, wie der Schein‑Effekt auf eine Form angewendet wird:
```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Weiche Kanten‑Effekt anwenden**

Dieser Java‑Code zeigt, wie weiche Kanten auf eine Form angewendet werden:
```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte wie Schatten, Spiegelung und Schein auf einer einzelnen Form kombinieren, um ein dynamischeres Erscheinungsbild zu erzeugen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, einschließlich Autoformen, Diagrammen, Tabellen, Bildern, SmartArt‑Objekten, OLE‑Objekten und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.