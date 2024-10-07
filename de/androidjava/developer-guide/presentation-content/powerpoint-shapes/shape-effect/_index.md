---
title: Formeffekt
type: docs
weight: 30
url: /androidjava/shape-effect
keywords: "Formeffekt, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "Effekt auf PowerPoint-Form in Java anwenden"
---

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/androidjava/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint-Effekten können Sie überzeugende Reflexionen auf einer Form erzeugen, den Schein einer Form verbreiten usw.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einen oder mehrere Effekte auf eine Form anwenden.

* Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund bietet PowerPoint Optionen unter **Voreinstellung**. Die Voreinstellungsoptionen sind im Wesentlichen eine bekannte gut aussehende Kombination aus zwei oder mehr Effekten. Auf diese Weise müssen Sie beim Auswählen einer Voreinstellung keine Zeit mit dem Testen oder Kombinieren verschiedener Effekte verschwenden, um eine ansprechende Kombination zu finden.

Aspose.Slides bietet Eigenschaften und Methoden unter der Klasse [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectFormat), die es Ihnen ermöglichen, dieselben Effekte auf Formen in PowerPoint-Präsentationen anzuwenden.

## **Schattensatz anwenden**

Dieser Java-Code zeigt Ihnen, wie Sie den äußeren Schattensatz ([OuterShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) auf ein Rechteck anwenden:

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

## **Reflexionseffekt anwenden**

Dieser Java-Code zeigt Ihnen, wie Sie den Reflexionseffekt auf eine Form anwenden:

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

## **Leuchteffekt anwenden**

Dieser Java-Code zeigt Ihnen, wie Sie den Leuchteffekt auf eine Form anwenden:

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

## **Weiche Kanten anwenden**

Dieser Java-Code zeigt Ihnen, wie Sie die weichen Kanten auf eine Form anwenden:

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