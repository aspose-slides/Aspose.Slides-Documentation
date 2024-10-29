---
title: Efecto de Forma
type: docs
weight: 30
url: /es/net/shape-effect
keywords: "Efecto de forma, presentación de PowerPoint C#, Csharp, Aspose.Slides para .NET"
description: "Aplicar efecto a la forma de PowerPoint en C# o .NET"
---

Si bien los efectos en PowerPoint pueden utilizarse para resaltar una forma, se diferencian de los [rellenos](/slides/es/net/shape-formatting/#gradient-fill) o contornos. Usando efectos de PowerPoint, puedes crear reflejos convincentes en una forma, extender el resplandor de una forma, etc.

<img src="shape-effect.png" alt="efecto-de-forma" style="zoom:50%;" />

* PowerPoint proporciona seis efectos que se pueden aplicar a las formas. Puedes aplicar uno o más efectos a una forma.

* Algunas combinaciones de efectos se ven mejor que otras. Por esta razón, PowerPoint ofrece opciones bajo **Preestablecido**. Las opciones Preestablecidas son esencialmente una combinación bella conocida de dos o más efectos. De esta manera, al seleccionar un preestablecido, no tendrás que perder tiempo probando o combinando diferentes efectos para encontrar una bonita combinación.

Aspose.Slides proporciona propiedades y métodos bajo la clase [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) que te permiten aplicar los mismos efectos a las formas en presentaciones de PowerPoint.

## **Aplicar Efecto de Sombra**

Este código C# te muestra cómo aplicar el efecto de sombra externa ([OuterShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/)) a un rectángulo:

```c#
using (var pres = new Presentation())
{
    var shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableOuterShadowEffect();
    shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
    shape.EffectFormat.OuterShadowEffect.Distance = 10;
    shape.EffectFormat.OuterShadowEffect.Direction = 45;

    pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Aplicar Efecto de Reflexión**

Este código C# te muestra cómo aplicar el efecto de reflexión a una forma: 

```c#
using (var pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableReflectionEffect();
    shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
    shape.EffectFormat.ReflectionEffect.Direction = 90;
    shape.EffectFormat.ReflectionEffect.Distance = 55;
    shape.EffectFormat.ReflectionEffect.BlurRadius = 4;

    pres.Save("reflection.pptx", SaveFormat.Pptx);
}
```

## **Aplicar Efecto de Resplandor**

Este código C# te muestra cómo aplicar el efecto de resplandor a una forma: 

```c#
using (var pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableGlowEffect();
    shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
    shape.EffectFormat.GlowEffect.Radius = 15;

    pres.Save("glow.pptx", SaveFormat.Pptx);
}
```

## **Aplicar Efecto de Bordes Suaves**

Este código C# te muestra cómo aplicar bordes suaves a una forma: 

```c#
using (var pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableSoftEdgeEffect();
    shape.EffectFormat.SoftEdgeEffect.Radius = 15;

    pres.Save("softEdges.pptx", SaveFormat.Pptx);
}
```