---
title: Crear y aplicar efectos de WordArt en .NET
linktitle: WordArt
type: docs
weight: 110
url: /es/net/wordart/
keywords:
- WordArt
- crear WordArt
- plantilla de WordArt
- efecto de WordArt
- efecto de sombra
- efecto de visualización
- efecto de brillo
- transformación de WordArt
- efecto 3D
- efecto de sombra externa
- efecto de sombra interna
- .NET
- C#
- Aspose.Slides
description: "Crear y personalizar efectos de WordArt en Aspose.Slides para .NET. Esta guía paso a paso ayuda a los desarrolladores a mejorar presentaciones con texto profesional en C#."
---
## **Visión general**

Los efectos de WordArt le permiten añadir texto visualmente atractivo y estilizado a sus presentaciones de PowerPoint. Con Aspose.Slides for .NET, los desarrolladores pueden crear, personalizar y gestionar WordArt de forma programática, como en Microsoft PowerPoint, sin necesidad de tener Office instalado. Este artículo ofrece una visión general del trabajo con WordArt en .NET, incluyendo cómo aplicar transformaciones de texto, estilos de relleno, contornos, sombras y otras opciones de formato para que el contenido de su presentación sea más expresivo y atractivo. WordArt le permite tratar el texto como un objeto gráfico. Consiste en efectos o modificaciones especiales aplicadas al texto para hacerlo más atractivo o llamativo.

## **Crear una plantilla simple de WordArt y aplicarla al texto**

En esta sección, exploraremos cómo crear una plantilla simple de WordArt y aplicarla al texto utilizando Aspose.Slides for .NET. WordArt ofrece una forma sencilla de mejorar la apariencia del texto con efectos visuales impactantes y estilos. Al aprender los pasos básicos para crear y usar WordArt, podrá adaptar fácilmente estas técnicas a cualquier proyecto, haciendo sus presentaciones más vibrantes y memorables.

Primero, creamos un texto sencillo con el siguiente código C#:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

Ahora, establecemos la altura de fuente del texto a un valor mayor para que el efecto sea más visible con el siguiente código:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";

    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
}
```

Aquí, aplicamos el relleno de patrón SmallGrid al texto y añadimos un contorno negro de ancho 1 con el siguiente código:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
}
```

El texto resultante:

![La plantilla simple de WordArt](WordArt_template.png)

## **Aplicar otros efectos de WordArt**

Además de las transformaciones básicas, Aspose.Slides for .NET le permite aplicar una variedad de efectos avanzados de WordArt para mejorar la apariencia de su texto. Estos incluyen contornos, rellenos, sombras, reflejos y efectos de brillo. Al combinar estas características, puede crear estilos de texto llamativos que destaquen en sus presentaciones. Esta sección muestra cómo aplicar estos efectos de forma programática mediante ejemplos de código simples y claros.

### **Aplicar efectos de sombra externa**

Los efectos de sombra externa hacen que el texto destaque añadiendo una sombra detrás de su contorno, creando una sensación de profundidad y separación del fondo. Aspose.Slides for .NET permite aplicar y personalizar fácilmente sombras externas en texto WordArt. En esta sección aprenderá a establecer el color de la sombra, la dirección, la distancia, el radio de difuminado y más para lograr el impacto visual deseado.

El siguiente fragmento de código C# aplica un efecto de sombra al texto creado anteriormente.

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
}
```

El texto resultante:

![El efecto de sombra externa](outer_shadow_effect.png)

{{% alert color="info" %}} 

- Cuando se usan together OuterShadow y PresetShadow, solo se aplica el efecto OuterShadow.
- Si se usan simultáneamente OuterShadow e InnerShadow, el efecto resultante depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013 el efecto se duplica, mientras que en PowerPoint 2007 solo se aplica OuterShadow.

{{% /alert %}}

### **Aplicar efectos de reflexión**

En esta sección, exploraremos cómo aplicar efectos de reflexión en sus diapositivas utilizando Aspose.Slides for .NET. Los efectos de reflexión pueden ser una forma eficaz de dar a su texto o formas un aspecto elegante y moderno, ayudando a que los elementos clave destaquen y añadiendo profundidad a su presentación. Al comprender el proceso de aplicación y personalización de estos efectos, podrá adaptarlos fácilmente a sus necesidades de diseño y requisitos de marca.

Añada un efecto de reflexión al texto con este ejemplo de código C#:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableReflectionEffect();
    portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
    portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
    portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
    portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
    portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
    portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
}
```

El texto resultante:

![El efecto de reflexión](reflection_effect.png)

### **Aplicar efectos de brillo**

En esta sección, exploraremos cómo aplicar un efecto de brillo al texto mediante Aspose.Slides for .NET. El efecto de brillo puede hacer que su texto destaque con un contorno luminoso, mejorando el atractivo visual de sus diapositivas. Ajustando configuraciones como el color y la intensidad, puede adaptar fácilmente el brillo a su diseño y a las necesidades de marca, asegurando que los puntos clave de su presentación capturen la atención del público.

Aplique un efecto de brillo al texto para que brille o destaque utilizando el siguiente código:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
}
```

El texto resultante:

![El efecto de brillo](glow_effect.png)

### **Aplicar transformaciones de WordArt**

En esta sección, exploraremos cómo usar transformaciones en WordArt con Aspose.Slides for .NET. Las transformaciones le permiten doblar, estirar o deformar el texto, creando efectos únicos y visualmente impactantes. Al dominar estas técnicas, podrá adaptar fácilmente la forma y el estilo del texto a su marca o visión creativa, asegurando una presentación convincente y pulida.

Utilice la propiedad `Transform` (que se aplica a todo el bloque de texto) con el siguiente código:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
}
```

El texto resultante:

![La transformación de WordArt](transform_effect.png)

{{% alert color="info" %}} 

Aspose.Slides for .NET proporciona un conjunto de [tipos de transformación](https://reference.aspose.com/slides/es/net/aspose.slides/textshapetype/) predefinidos.

{{% /alert %}} 

### **Aplicar efectos 3D a formas y texto**

Crear visuales realistas y llamativos puede mejorar significativamente el impacto de sus presentaciones. En esta sección, exploraremos cómo aplicar efectos tridimensionales (3D) a formas utilizando Aspose.Slides for .NET. Al manipular parámetros como profundidad, ángulo e iluminación, puede producir transformaciones 3D impresionantes que captarán de inmediato la atención de su audiencia. Ya sea que busque resaltados sutiles o ilusiones dramáticas, estas funciones ofrecen formas flexibles de elevar su diseño y transmitir ideas de manera más cautivadora.

Utilice el siguiente código de ejemplo para establecer un efecto 3D en la forma:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.TextFrame.Text = "Aspose.Slides";

    autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
    autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

    autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    autoShape.ThreeDFormat.BevelTop.Height = 12.5;
    autoShape.ThreeDFormat.BevelTop.Width = 11;

    autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    autoShape.ThreeDFormat.ExtrusionHeight = 6;

    autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    autoShape.ThreeDFormat.ContourWidth = 1.5;

    autoShape.ThreeDFormat.Depth = 3;

    autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

    autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
}
```

La forma resultante:

![El efecto 3D de la forma](shape_3D_effect.png)

Utilice el siguiente código de ejemplo para establecer un efecto 3D en el texto:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
}
```

El texto resultante:

![El efecto 3D del texto](text_3D_effect.png)

{{% alert color="info" %}} 

La aplicación de efectos 3D al texto o a sus formas—y la interacción entre estos efectos—está regida por reglas específicas. Considere una escena que incluya tanto un texto como la forma que contiene ese texto. Un efecto 3D incluye la representación 3D del objeto y la escena en la que se coloca.

- Si se establece una escena tanto para la forma como para el texto, la escena de la forma tiene prioridad y la escena del texto se ignora.
- Si la forma no tiene su propia escena pero dispone de una representación 3D, se utiliza la escena del texto.
- Si la forma no tiene ningún efecto 3D, se trata como plana y el efecto 3D se aplica solo al texto.

Estos comportamientos se relacionan con las propiedades [ThreeDFormat.LightRig](https://reference.aspose.com/slides/es/net/aspose.slides/threedformat/lightrig/) y [ThreeDFormat.Camera](https://reference.aspose.com/slides/es/net/aspose.slides/threedformat/camera/).

{{% /alert %}} 

## **FAQ**

### ¿Puedo usar efectos de WordArt con diferentes fuentes o escrituras (p. ej., árabe, chino)?

Sí, Aspose.Slides for .NET admite Unicode y funciona con todas las fuentes y escrituras principales. Los efectos de WordArt como sombra, relleno y contorno se pueden aplicar independientemente del idioma, aunque la disponibilidad de fuentes y el renderizado pueden depender de las fuentes del sistema.

### ¿Puedo aplicar efectos de WordArt a elementos del patrón de diapositivas?

Sí, puede aplicar efectos de WordArt a las formas de las diapositivas maestras, incluidos los marcadores de posición de título, pies de página o texto de fondo. Los cambios realizados en el diseño maestro se reflejarán en todas las diapositivas asociadas.

### ¿Los efectos de WordArt afectan al tamaño del archivo de la presentación?

Levemente. Los efectos de WordArt como sombras, brillos y rellenos degradados pueden aumentar ligeramente el tamaño del archivo debido a los metadatos de formato añadidos, pero la diferencia suele ser insignificante.

### ¿Puedo previsualizar el resultado de los efectos de WordArt sin guardar la presentación?

Sí, puede renderizar las diapositivas que contienen WordArt a imágenes (p. ej., PNG, JPEG) utilizando el método `GetImage` de las interfaces [IShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/) o [ISlide](https://reference.aspose.com/slides/es/net/aspose.slides/islide/). Esto le permite previsualizar el resultado en memoria o en pantalla antes de guardar o exportar la presentación completa.