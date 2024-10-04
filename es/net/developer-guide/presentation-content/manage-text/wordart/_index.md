---
title: WordArt
type: docs
weight: 110
url: /net/wordart/
keywords: "WordArt, Word Art, Crear WordArt, plantilla de WordArt, efectos de WordArt, efectos de sombra, efectos de visualización, efectos de brillo, transformaciones de WordArt, efectos 3D, efectos de sombra exterior, efectos de sombra interior, C#, Csharp, Aspose.Slides para .NET"
description: "Agrega, manipula y gestiona WordArt y efectos en presentaciones de PowerPoint en C# o Aspose.Slides para .NET"
---

## **¿Qué es WordArt?**
WordArt o Word Art es una característica que te permite aplicar efectos a los textos para hacer que se destaquen. Con WordArt, por ejemplo, puedes contornear un texto o rellenarlo con un color (o degradado), agregarle efectos 3D, etc. También puedes distorsionar, doblar y estirar la forma de un texto.

{{% alert color="primary" %}} 

WordArt te permite tratar un texto como si fuera un objeto gráfico. WordArt consiste en efectos o modificaciones especiales realizadas a los textos para hacerlos más atractivos o notables. 

{{% /alert %}} 

**WordArt en Microsoft PowerPoint**

Para usar WordArt en Microsoft PowerPoint, debes seleccionar una de las plantillas de WordArt predefinidas. Una plantilla de WordArt es un conjunto de efectos que se aplican a un texto o su forma.

**WordArt en Aspose.Slides**

En Aspose.Slides para .NET 20.10, implementamos soporte para WordArt y realizamos mejoras a la función en versiones posteriores de Aspose.Slides para .NET.

Con Aspose.Slides para .NET, puedes crear fácilmente tu propia plantilla de WordArt (un efecto o combinación de efectos) en C# y aplicarla a los textos.

## Creando una Plantilla de WordArt Simple y Aplicándola a un Texto

**Usando Aspose.Slides** 

Primero, creamos un texto simple usando este código C#:

``` csharp 
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    Portion portion = (Portion)textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```
Ahora, establecemos la altura de la fuente del texto a un valor más grande para hacer que el efecto sea más notable a través de este código:

``` csharp 
FontData fontData = new FontData("Arial Black");
portion.PortionFormat.LatinFont = fontData;
portion.PortionFormat.FontHeight = 36;
```

**Usando Microsoft PowerPoint**

Ve al menú de efectos de WordArt en Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Desde el menú de la derecha, puedes elegir un efecto de WordArt predefinido. Desde el menú de la izquierda, puedes especificar los ajustes para un nuevo WordArt. 

Estos son algunos de los parámetros u opciones disponibles:

![todo:image_alt_text](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aquí, aplicamos el color de patrón SmallGrid al texto y agregamos un borde negro de 1 de ancho al texto usando este código:

``` csharp 
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
            
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

El texto resultante:

![todo:image_alt_text](image-20200930114108-4.png)

## Aplicando Otros Efectos de WordArt

**Usando Microsoft PowerPoint**

Desde la interfaz del programa, puedes aplicar estos efectos a un texto, bloque de texto, forma o elemento similar:

![todo:image_alt_text](image-20200930114129-5.png)

Por ejemplo, los efectos de Sombra, Reflexión y Brillo se pueden aplicar a un texto; los efectos de Formato 3D y Rotación 3D se pueden aplicar a un bloque de texto; la propiedad de Bordes Suaves se puede aplicar a un Objeto de Forma (aún tiene un efecto cuando no se establece la propiedad de Formato 3D). 

### Aplicando Efectos de Sombra

Aquí, pretendemos establecer las propiedades relacionadas solo con un texto. Aplicamos el efecto de sombra a un texto usando este código en C#:

``` csharp 
portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 65;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4.73;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 2;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

Aspose.Slides API soporta tres tipos de sombras: OuterShadow, InnerShadow y PresetShadow.

Con PresetShadow, puedes aplicar una sombra a un texto (usando valores preestablecidos).

**Usando Microsoft PowerPoint**

En PowerPoint, puedes usar un tipo de sombra. Aquí hay un ejemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Usando Aspose.Slides**

Aspose.Slides en realidad te permite aplicar dos tipos de sombras a la vez: InnerShadow y PresetShadow.

**Notas:**

- Cuando se utilizan juntos OuterShadow y PresetShadow, solo se aplica el efecto de OuterShadow. 
- Si se utilizan simultáneamente OuterShadow y InnerShadow, el efecto resultante o aplicado depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013, el efecto se duplica. Pero en PowerPoint 2007, se aplica el efecto de OuterShadow.

### Aplicando Visualización a Textos

Agregamos visualización al texto a través de este código de muestra en C#:

``` csharp 
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

### Aplicando Efecto de Brillo a Textos

Aplicamos el efecto de brillo al texto para que brille o se destaque usando este código:

``` csharp 
portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

El resultado de la operación:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Puedes cambiar los parámetros para la sombra, visualización y brillo. Las propiedades de los efectos se establecen en cada porción del texto por separado. 

{{% /alert %}} 

### Usando Transformaciones en WordArt

Utilizamos la propiedad Transform (inherente en todo el bloque de texto) a través de este código:
``` csharp 
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

El resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Tanto Microsoft PowerPoint como Aspose.Slides para .NET proporcionan una cierta cantidad de tipos de transformación predefinidos. 

{{% /alert %}} 

**Usando PowerPoint**

Para acceder a los tipos de transformación predefinidos, ve a: **Formato** -> **Efecto de Texto** -> **Transformar**

**Usando Aspose.Slides**

Para seleccionar un tipo de transformación, utiliza el enum TextShapeType. 

### Aplicando efectos 3D a Textos y Formas

Establecemos un efecto 3D a una forma de texto utilizando este código de muestra:

``` csharp 
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

El texto resultante y su forma:

![todo:image_alt_text](image-20200930114816-9.png)

Aplicamos un efecto 3D al texto con este código C#:

``` csharp 
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

El resultado de la operación:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

La aplicación de efectos 3D a textos o sus formas y las interacciones entre efectos se basan en ciertas reglas.

Considera una escena para un texto y la forma que contiene ese texto. El efecto 3D contiene la representación del objeto 3D y la escena sobre la cual se colocó el objeto.

- Cuando la escena está configurada tanto para la figura como para el texto, la escena de la figura tiene mayor prioridad: la escena del texto se ignora. 
- Cuando la figura carece de su propia escena pero tiene representación 3D, se utiliza la escena del texto. 
- De lo contrario—cuando la forma originalmente no tiene efecto 3D—la forma es plana y el efecto 3D solo se aplica al texto.

Las descripciones están conectadas a las propiedades [ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/properties/lightrig) y [ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/properties/camera).

{{% /alert %}} 

## **Aplicar Efectos de Sombra Exterior a Textos**
Aspose.Slides para .NET proporciona las clases [**IOuterShadow**](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow) y [**IInnerShadow**](https://reference.aspose.com/slides/net/aspose.slides.effects/iinnershadow) que te permiten aplicar efectos de sombra a un texto llevado por TextFrame. Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtén la referencia de una diapositiva usando su índice.
3. Agrega una AutoShape de tipo Rectángulo a la diapositiva.
4. Accede al TextFrame asociado con la AutoShape.
5. Establece el FillType de la AutoShape a NoFill.
6. Instancia la clase OuterShadow.
7. Establece el BlurRadius de la sombra.
8. Establece la Dirección de la sombra.
9. Establece la Distancia de la sombra.
10. Establece el RectanglelAlign a TopLeft.
11. Establece el PresetColor de la sombra a Negro.
12. Escribe la presentación como un archivo PPTX.

Este código de muestra en C#—una implementación de los pasos anteriores—te muestra cómo aplicar el efecto de sombra exterior a un texto:

```c#
using (Presentation pres = new Presentation())
{

    // Obtener referencia de la diapositiva
    ISlide sld = pres.Slides[0];

    // Agregar una AutoShape de tipo Rectángulo
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Agregar TextFrame al rectángulo
    ashp.AddTextFrame("Aspose TextBox");

    // Deshabilitar el relleno de la forma en caso de que queramos obtener la sombra del texto
    ashp.FillFormat.FillType = FillType.NoFill;

    // Agregar sombra exterior y establecer todos los parámetros necesarios
    ashp.EffectFormat.EnableOuterShadowEffect();
    IOuterShadow shadow = ashp.EffectFormat.OuterShadowEffect;
    shadow.BlurRadius = 4.0;
    shadow.Direction = 45;
    shadow.Distance = 3;
    shadow.RectangleAlign = RectangleAlignment.TopLeft;
    shadow.ShadowColor.PresetColor = PresetColor.Black;

    // Escribir la presentación en disco
    pres.Save("pres_out.pptx", SaveFormat.Pptx);
}
```


## **Aplicar Efecto de Sombra Interior a Formas**
Sigue estos pasos:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtén una referencia de la diapositiva.
3. Agrega una AutoShape del tipo Rectángulo.
4. Habilita InnerShadowEffect.
5. Establece todos los parámetros necesarios.
6. Establece el ColorType como Esquema.
7. Establece el Color del Esquema.
8. Escribe la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Este código de muestra (basado en los pasos anteriores) te muestra cómo agregar un conector entre dos formas en C#:

```c#
using(Presentation presentation = new Presentation())
{
    // Obtener referencia de una diapositiva
    ISlide slide = presentation.Slides[0];

    // Agregar una AutoShape de tipo Rectángulo
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.FillFormat.FillType = FillType.NoFill;

    // Agregar TextFrame al rectángulo
    ashp.AddTextFrame("Aspose TextBox");
    IPortion port = ashp.TextFrame.Paragraphs[0].Portions[0];
    IPortionFormat pf = port.PortionFormat;
    pf.FontHeight = 50;

    // Habilitar InnerShadowEffect    
    IEffectFormat ef = pf.EffectFormat;
    ef.EnableInnerShadowEffect();

    // Establecer todos los parámetros necesarios
    ef.InnerShadowEffect.BlurRadius = 8.0;
    ef.InnerShadowEffect.Direction = 90.0F;
    ef.InnerShadowEffect.Distance = 6.0;
    ef.InnerShadowEffect.ShadowColor.B = 189;

    // Establecer ColorType como Esquema
    ef.InnerShadowEffect.ShadowColor.ColorType = ColorType.Scheme;

    // Establecer Color del Esquema
    ef.InnerShadowEffect.ShadowColor.SchemeColor = SchemeColor.Accent1;

    // Guardar Presentación
    presentation.Save("WordArt_out.pptx", SaveFormat.Pptx);
}
```