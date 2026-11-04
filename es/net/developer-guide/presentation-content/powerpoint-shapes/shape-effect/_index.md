---
title: Aplicar efectos de forma en presentaciones en .NET
linktitle: Efecto de forma
type: docs
weight: 30
url: /es/net/shape-effect/
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
## **Introducción**

Mientras los efectos en PowerPoint pueden usarse para que una forma destaque, difieren de los [rellenos](/slides/es/net/shape-formatting/#gradient-fill) o contornos. Con los efectos de PowerPoint, puedes crear reflexiones convincentes en una forma, difundir el resplandor de una forma, etc.

![Efecto de forma](shape-effect.png)

PowerPoint ofrece seis efectos que pueden aplicarse a las formas. Puedes aplicar uno o varios efectos a una forma.

Algunas combinaciones de efectos se ven mejor que otras. Por esta razón, PowerPoint tiene opciones bajo **Predefinido**. Las opciones Predefinido son esencialmente una combinación conocida y estética de dos o más efectos. De este modo, al seleccionar un predefinido, no tendrás que perder tiempo probando o combinando diferentes efectos para encontrar una buena combinación.

Aspose.Slides proporciona propiedades y métodos en la clase [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) que te permiten aplicar los mismos efectos a las formas en presentaciones de PowerPoint.

## **Aplicar un efecto de sombra**

Aspose.Slides para .NET admite sombras externas e internas para las formas. Puedes personalizar su color, dirección, distancia y radio de desenfoque para que coincida con el diseño de tu presentación.

### **Aplicar una sombra externa**

Utiliza una sombra externa para que una tarjeta o panel destaque sobre el fondo de la diapositiva. La sombra se extiende más allá de los bordes de la forma, creando la impresión de que la forma está elevada sobre la diapositiva. Ajusta su color, dirección, distancia y radio de desenfoque para que coincidan con la iluminación y el estilo de tu plantilla.

Este código C# muestra cómo aplicar el [efecto de sombra externa](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) a un rectángulo:

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

![Efecto de sombra](shadow_effect.png)

### **Aplicar una sombra interna**

Al reproducir el estilo visual de una plantilla, usa una sombra interna para dar a una tarjeta o panel una apariencia hundida. Una sombra externa se extiende fuera de la forma y la hace parecer elevada, mientras que una sombra interna sombrea el interior de sus bordes.

Llama a [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), luego configura [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Los valores más altos producen bordes más suaves.

Este ejemplo C# crea una tarjeta azul claro con una sombra interna gris oscuro y la guarda como un archivo PPTX:

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

![Rectángulo azul claro con una sombra interna](inner_shadow_effect.png)

Para eliminar la sombra interna, llama a [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) en el formato de efecto de la forma.

## **Aplicar un efecto de reflexión**

Para aplicar un efecto de reflexión en Aspose.Slides para .NET, puedes añadir una reflexión similar a un espejo a las formas, ajustando parámetros como distancia, transparencia y tamaño. Este efecto mejora la estética de tus presentaciones al dar a las formas un aspecto más pulido y sofisticado. Es fácil de implementar con código sencillo, permitiendo una aplicación rápida en varios elementos para un diseño coherente.

Este código C# muestra cómo aplicar el [efecto de reflexión](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) a una forma:

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

![Efecto de reflexión](reflection_effect.png)

## **Aplicar un efecto de resplandor**

Para aplicar un efecto de resplandor a una forma en Aspose.Slides para .NET, puedes añadir un aura suave y luminosa alrededor de las formas, ajustando propiedades como el color y el tamaño. Este efecto ayuda a que las formas destaquen y añade un elemento visual atractivo y llamativo a tu presentación. Es fácil de implementar con código mínimo, mejorando el aspecto general de tus diapositivas.

Este código C# muestra cómo aplicar el [efecto de resplandor](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) a una forma:

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

![Efecto de resplandor](glow_effect.png)

## **Aplicar un efecto de bordes suaves**

Para aplicar un efecto de bordes suaves en Aspose.Slides para .NET, puedes crear una transición lisa y difuminada alrededor de los bordes de una forma. Este efecto aporta una apariencia más sutil y refinada, perfecta para diseños que necesitan un aspecto delicado y más suave. Puedes ajustar fácilmente parámetros como el radio para lograr el efecto deseado en diversas formas de tu presentación.

Este código C# muestra cómo aplicar los [bordes suaves](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) a una forma:

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

![Efecto de bordes suaves](soft_edges_effect.png)

## **Aplicar un efecto de desenfoque**

Utiliza el desenfoque de forma para suavizar el relleno y contorno de una forma sin dejar de ser editable. Llama a [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) en el formato de efecto de la forma. El radio se mide en puntos (1/72 de pulgada): usa un valor no negativo, con valores mayores que producen un desenfoque más fuerte. Un radio de cero deja la apariencia sin cambios.

La configuración [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) controla los límites visibles del efecto. Con `false`, el desenfoque se recorta a los límites pintados originales, incluido el contorno. Con `true`, el desenfoque puede extenderse más allá de esos límites. Ninguna de las configuraciones cambia la posición o dimensiones de la forma.

La comparación a continuación utiliza el mismo relleno, contorno y dimensiones de la forma en todo momento. La fila superior usa `grow = false`; la fila inferior usa `grow = true`.

![Rectángulo original comparado con radios de desenfoque de 5 y 15 puntos, con grow desactivado y activado](shape_blur_comparison.png)

Este ejemplo C# crea un rectángulo naranja con un contorno azul oscuro, aplica un desenfoque de 5 puntos y luego lo actualiza a un desenfoque de 15 puntos llamando a [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) de nuevo. Guarda ambos estados desenfocados, luego llama a [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) y guarda la forma sin desenfoque.

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

El desenfoque de forma afecta el relleno y el contorno conjuntamente. Un efecto de bordes suaves desvanece los bordes de la forma, mientras que el desenfoque de sombra suaviza solo la sombra. Los efectos de transformación de imagen operan sobre el contenido de la imagen; este ejemplo aplica el desenfoque directamente al formato de efecto de la forma sin convertir la forma en una imagen.

## **Preguntas frecuentes**

**¿Puedo aplicar varios efectos a la misma forma?**

Sí, puedes combinar diferentes efectos, como sombra, reflexión y resplandor, en una sola forma para crear una apariencia más dinámica.

**¿A qué formas puedo aplicar efectos?**

Puedes aplicar efectos a diversas formas, incluidas autoshapes, gráficos, tablas, imágenes, objetos SmartArt, objetos OLE y más.

**¿Puedo aplicar efectos a formas agrupadas?**

Sí, puedes aplicar efectos a formas agrupadas. El efecto se aplicará a todo el grupo.