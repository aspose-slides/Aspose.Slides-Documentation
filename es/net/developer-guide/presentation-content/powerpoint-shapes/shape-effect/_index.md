---
title: Aplicar efectos de forma en presentaciones en .NET
linktitle: Efecto de forma
type: docs
weight: 30
url: /es/net/shape-effect
keywords:
- efecto de forma
- efecto de sombra
- efecto de reflexión
- efecto de resplandor
- efecto de bordes suaves
- formato de efecto
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Transforma tus archivos PPT y PPTX con efectos de forma avanzados usando Aspose.Slides para .NET—crea diapositivas impactantes y profesionales en segundos."
---

## **Resumen**

Aunque los efectos en PowerPoint pueden usarse para que una forma destaque, difieren de los [rellenos](/slides/es/net/shape-formatting/#gradient-fill) o contornos. Con los efectos de PowerPoint, puedes crear reflejos convincentes en una forma, difundir el resplandor de una forma, etc.

<img src="shape-effect.png" alt="efecto-de-forma" style="zoom:50%;" />

PowerPoint ofrece seis efectos que pueden aplicarse a las formas. Puedes aplicar uno o más efectos a una forma.

Algunas combinaciones de efectos se ven mejor que otras. Por esta razón, PowerPoint tiene opciones bajo **Preajuste**. Las opciones de Preajuste son esencialmente una combinación conocida de dos o más efectos que luce bien. De esta manera, al seleccionar un preajuste, no tendrás que perder tiempo probando o combinando diferentes efectos para encontrar una buena combinación.

Aspose.Slides proporciona propiedades y métodos bajo la clase [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) que le permiten aplicar los mismos efectos a las formas en presentaciones de PowerPoint.

## **Aplicar un efecto de sombra**

Para aplicar un efecto de sombra a una forma en Aspose.Slides para .NET, puedes ajustar fácilmente parámetros como color, radio de desenfoque y dirección. Esto brinda a tus formas una apariencia más dinámica y profesional, añadiendo profundidad y foco. Con fragmentos de código simples, puedes aplicar estos efectos a múltiples formas, mejorando el atractivo visual general de tus presentaciones.

Este código C# muestra cómo aplicar el [efecto de sombra externa](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) a un rectángulo:
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


![Efecto de sombra](shadow_effect.png)

## **Aplicar un efecto de reflexión**

Para aplicar un efecto de reflexión en Aspose.Slides para .NET, puedes añadir una reflexión similar a un espejo en las formas, ajustando parámetros como distancia, transparencia y tamaño. Este efecto realza la estética de tus presentaciones al proporcionar a las formas un aspecto más pulido y sofisticado. Es fácil de implementar con código simple, lo que permite una aplicación rápida en varios elementos para un diseño coherente.

Este código C# muestra cómo aplicar el [efecto de reflexión](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) a una forma:
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


![Efecto de reflexión](reflection_effect.png)

## **Aplicar un efecto de resplandor**

Para aplicar un efecto de resplandor a una forma en Aspose.Slides para .NET, puedes añadir un aura suave y luminosa alrededor de las formas, ajustando propiedades como el color y el tamaño. Este efecto ayuda a que las formas destaquen y añade un elemento visual atractivo y llamativo a tu presentación. Es fácil de implementar con un código mínimo, mejorando el aspecto general de tus diapositivas.

Este código C# muestra cómo aplicar el [efecto de resplandor](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) a una forma:
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```


![Efecto de resplandor](glow_effect.png)

## **Aplicar un efecto de bordes suaves**

Para aplicar un efecto de bordes suaves en Aspose.Slides para .NET, puedes crear una transición suave y difuminada alrededor de los bordes de una forma. Este efecto aporta un aspecto más sutil y refinado, perfecto para diseños que requieren una apariencia suave y delicada. Puedes ajustar fácilmente parámetros como el radio para lograr el efecto deseado en varias formas de tu presentación.

Este código C# muestra cómo aplicar los [bordes suaves](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) a una forma:
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```


![Efecto de bordes suaves](soft_edges_effect.png)

## **Preguntas frecuentes**

**¿Puedo aplicar varios efectos a la misma forma?**

Sí, puedes combinar diferentes efectos, como sombra, reflexión y resplandor, en una sola forma para crear una apariencia más dinámica.

**¿A qué formas puedo aplicar efectos?**

Puedes aplicar efectos a varias formas, incluidas autoshapes, gráficos, tablas, imágenes, objetos SmartArt, objetos OLE y más.

**¿Puedo aplicar efectos a formas agrupadas?**

Sí, puedes aplicar efectos a formas agrupadas. El efecto se aplicará a todo el grupo.