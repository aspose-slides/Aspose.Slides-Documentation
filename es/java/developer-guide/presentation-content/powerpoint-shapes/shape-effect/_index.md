---
title: Efecto de Forma
type: docs
weight: 30
url: /java/shape-effect
keywords: "Efecto de forma, presentación de PowerPoint, Java, Aspose.Slides para Java"
description: "Aplica efectos a la forma de PowerPoint en Java"
---

Mientras que los efectos en PowerPoint pueden usarse para hacer que una forma destaque, son diferentes de [rellenos](/slides/java/shape-formatting/#gradient-fill) o contornos. Usando efectos de PowerPoint, puedes crear reflejos convincentes en una forma, difundir el resplandor de una forma, etc.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint proporciona seis efectos que se pueden aplicar a las formas. Puedes aplicar uno o más efectos a una forma. 

* Algunas combinaciones de efectos se ven mejor que otras. Por esta razón, PowerPoint tiene opciones bajo **Preestablecido**. Las opciones de Preestablecido son esencialmente una combinación conocida y atractiva de dos o más efectos. Así, al seleccionar un preestablecido, no perderás tiempo probando o combinando diferentes efectos para encontrar una buena combinación.

Aspose.Slides proporciona propiedades y métodos en la clase [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat) que te permiten aplicar los mismos efectos a las formas en las presentaciones de PowerPoint.

## **Aplicar Efecto de Sombra**

Este código Java te muestra cómo aplicar el efecto de sombra exterior ([OuterShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) a un rectángulo:

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

## **Aplicar Efecto de Reflexión**

Este código Java te muestra cómo aplicar el efecto de reflexión a una forma:

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

## **Aplicar Efecto de Resplandor**

Este código Java te muestra cómo aplicar el efecto de resplandor a una forma:

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

## **Aplicar Efecto de Bordes Suaves**

Este código Java te muestra cómo aplicar bordes suaves a una forma:

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