---
title: Crear y aplicar efectos WordArt en .NET
linktitle: WordArt
type: docs
weight: 110
url: /es/net/wordart/
keywords:
- WordArt
- crear WordArt
- plantilla WordArt
- efecto WordArt
- efecto sombra
- efecto reflejo
- efecto resplandor
- transformación WordArt
- efecto 3D
- efecto sombra externa
- efecto sombra interna
- .NET
- C#
- Aspose.Slides
description: "Crear y personalizar efectos WordArt en Aspose.Slides para .NET. Esta guía paso a paso ayuda a los desarrolladores a mejorar presentaciones con texto profesional en C#."
---
## **Descripción general**

Los efectos WordArt le permiten dar estilo al texto con rellenos, contornos, sombras, reflejos, resplandores, transformaciones y formato 3D. Este artículo explica cómo crear y personalizar estos efectos en presentaciones de PowerPoint usando Aspose.Slides para .NET, sin necesidad de tener Microsoft Office instalado.

## **Crear una plantilla WordArt sencilla y aplicarla al texto**

Los siguientes ejemplos crean un estilo WordArt sencillo configurando el texto, la tipografía, el relleno de patrón y el contorno.

Cada ejemplo crea una nueva presentación y añade un rectángulo a su primera diapositiva; no se requiere archivo de entrada. El primer ejemplo establece el texto a "Aspose.Slides". La posición y dimensiones de la forma se miden en puntos:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

Establezca la tipografía a Arial Black a 36 puntos para que el formato sea más visible:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

Aplique un patrón [SmallGrid](https://reference.aspose.com/slides/es/net/aspose.slides/patternstyle/) con un primer plano naranja oscuro y un fondo blanco, y luego añada un contorno de texto negro con un ancho de 1 punto:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

El texto resultante:

![La plantilla WordArt simple](WordArt_template.png)

## **Aplicar otros efectos WordArt**

Los siguientes ejemplos demuestran cómo aplicar sombras, reflejos, resplandores, transformaciones y efectos 3D al texto.

### **Aplicar efectos de sombra externa**

Una sombra externa añade profundidad al colocar una sombra detrás del texto. Puede personalizar su color, dirección, distancia, radio de desenfoque, escala y sesgo.

Este ejemplo llama a [EnableOuterShadowEffect](https://reference.aspose.com/slides/es/net/aspose.slides/effectformat/enableoutershadoweffect/) y establece una sombra negra con un radio de desenfoque de 4 puntos, una dirección de 230 grados y una distancia de 30 puntos. Los valores de escala de 100 conservan el tamaño de la sombra, mientras que el sesgo horizontal la inclina 20 grados. La transformación alfa establece su opacidad al 32%:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
```

El texto resultante:

![El efecto de sombra externa](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Cuando se utilizan sombras externas y predefinidas juntas, solo se aplica la sombra externa.
- Si se usan sombras externas e internas simultáneamente, el efecto resultante depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013, el efecto se duplica, mientras que en PowerPoint 2007 solo se aplica la sombra externa.
{{% /alert %}}

### **Aplicar efectos de reflejo**

Un reflejo crea una copia espejo del texto. Ajuste su posición, escala, desenfoque y opacidad para controlar su apariencia.

Este ejemplo llama a [EnableReflectionEffect](https://reference.aspose.com/slides/es/net/aspose.slides/effectformat/enablereflectioneffect/) y voltea el reflejo verticalmente con una escala de -100 %. Usa un radio de desenfoque de 0,5 puntos y una distancia de 4,72 puntos. La opacidad disminuye del 60 % al 0,9 % entre las posiciones 0 % y 60 % a lo largo del reflejo:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
```

El texto resultante:

![El efecto de reflejo](reflection_effect.png)

### **Aplicar efectos de resplandor**

Un resplandor añade un contorno de color suave alrededor del texto. Ajuste su color, opacidad y radio para controlar el efecto.

Este ejemplo llama a [EnableGlowEffect](https://reference.aspose.com/slides/es/net/aspose.slides/effectformat/enablegloweffect/) y aplica un resplandor rojo con un 54 % de opacidad y un radio de 7 puntos:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

El texto resultante:

![El efecto de resplandor](glow_effect.png)

### **Aplicar transformaciones WordArt**

Las transformaciones WordArt doblan, estiran o deforman un bloque de texto.

Establezca [Transform](https://reference.aspose.com/slides/es/net/aspose.slides/textframeformat/transform/) a [ArchUpPour](https://reference.aspose.com/slides/es/net/aspose.slides/textshapetype/) para curvar todo el marco de texto hacia arriba:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

El texto resultante:

![La transformación WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET ofrece un conjunto de [tipos de transformación](https://reference.aspose.com/slides/es/net/aspose.slides/textshapetype/) predefinidos.
{{% /alert %}}

### **Aplicar efectos 3D a formas y texto**

Puede aplicar efectos 3D a una forma o a su texto. Los biseles, la extrusión, la iluminación y la configuración de la cámara controlan la apariencia resultante.

El siguiente ejemplo usa [ThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/threedformat/) para añadir biseles circulares, extrusión naranja y un contorno rojo oscuro al rectángulo. Las dimensiones del bisel, la altura de la extrusión, el ancho del contorno y la profundidad se miden en puntos. Un material plástico, iluminación equilibrada girada 40 grados alrededor del eje Z y una cámara en perspectiva definen su apariencia:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
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
```

La forma resultante:

![El efecto 3D de la forma](shape_3D_effect.png)

Este ejemplo aplica un formato 3D similar al texto mediante [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/textframeformat/threedformat/). Biseles más pequeños modelan los bordes de las letras, mientras que la extrusión y la iluminación le dan profundidad al texto:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
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
```

El texto resultante:

![El efecto 3D del texto](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
La aplicación de efectos 3D al texto o a sus formas —y la interacción entre estos efectos— está regida por reglas específicas. Considere una escena que incluya tanto el texto como la forma que lo contiene. Un efecto 3D incluye la representación 3D del objeto y la escena en la que se coloca.

- Si una escena está definida tanto para la forma como para el texto, la escena de la forma tiene prioridad y se ignora la escena del texto.
- Si la forma no tiene su propia escena pero sí una representación 3D, se utiliza la escena del texto.
- Si la forma no tiene ningún efecto 3D, se trata como plana y el efecto 3D se aplica solo al texto.

Estos comportamientos están relacionados con las propiedades [ThreeDFormat.LightRig](https://reference.aspose.com/slides/es/net/aspose.slides/threedformat/lightrig/) y [ThreeDFormat.Camera](https://reference.aspose.com/slides/es/net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Para mantener el texto plano y legible mientras se conserva el formato 3D de su forma, consulte [Mantener el texto plano en una forma 3D](/slides/es/net/3d-presentation/) para una comparación de ambas configuraciones y un ejemplo completo en C#.

## **Preguntas frecuentes**

**¿Puedo usar efectos WordArt con diferentes fuentes o escrituras (p. ej., árabe, chino)?**

Sí, Aspose.Slides for .NET admite Unicode y funciona con todas las fuentes y escrituras principales. Los efectos WordArt, como sombra, relleno y contorno, pueden aplicarse independientemente del idioma, aunque la disponibilidad de fuentes y el renderizado pueden depender de las fuentes del sistema.

**¿Puedo aplicar efectos WordArt a los elementos de la diapositiva maestra?**

Sí, puede aplicar efectos WordArt a las formas en las diapositivas maestras, incluidos los marcadores de posición de título, pies de página o texto de fondo. Los cambios realizados en el diseño maestro se reflejarán en todas las diapositivas asociadas.

**¿Los efectos WordArt afectan al tamaño del archivo de la presentación?**

Levemente. Los efectos WordArt, como sombras, resplandores y rellenos degradados, pueden aumentar ligeramente el tamaño del archivo debido a los metadatos de formato añadidos, aunque la diferencia suele ser insignificante.

**¿Puedo obtener una vista previa del resultado de los efectos WordArt sin guardar la presentación?**

Sí, puede renderizar las diapositivas que contienen WordArt a imágenes (p. ej., PNG, JPEG) mediante [ISlide.GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/islide/getimage/), o renderizar formas individuales mediante [IShape.GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/getimage/). Esto le permite previsualizar el resultado en memoria o en pantalla antes de guardar o exportar la presentación completa.