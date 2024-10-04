---
title: Presentación 3D
type: docs
weight: 232
url: /es/net/3d-presentation/
keywords:
- 3D
- PowerPoint 3D
- presentación 3D
- rotación 3D
- profundidad 3D
- extrusion 3D
- gradiente 3D
- texto 3D
- presentación de PowerPoint
- C#
- Csharp
- Aspose.Slides para .NET
description: "Presentación de PowerPoint 3D en C# o .NET"
---


## Descripción general
¿Cómo sueles crear una presentación de PowerPoint 3D?
Microsoft PowerPoint permite crear presentaciones 3D en términos que podemos añadir modelos 3D, aplicar efectos 3D en formas, 
crear texto 3D, subir gráficos 3D a la presentación, crear animaciones 3D en PowerPoint. 

Crear efectos 3D tiene un gran impacto en la mejora de tu presentación a una presentación 3D y puede ser la implementación más fácil de una presentación 3D. 
Desde la versión 20.9 de Aspose.Slides, se ha añadido un **motor 3D multiplataforma** nuevo. El nuevo motor 3D permite 
exportar y rasterizar formas y texto con efectos 3D. En las versiones anteriores, 
las formas de las diapositivas con efectos 3D aplicados se habían renderizado de forma plana. Pero ahora es posible 
renderizar formas con un **3D completo**.
Además, ahora es posible crear formas con efectos 3D a través de la API pública de Slides.

En la API de Aspose.Slides, para hacer que 
una forma se convierta en una forma 3D de PowerPoint, utiliza la propiedad [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat), 
que hereda las características de la interfaz [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat):
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) 
y [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): establece el bisel en la forma, define el tipo de bisel (por ejemplo, Ángulo, Círculo, SuaveRedondeado), define la altura y el ancho del bisel.
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): se utiliza para imitar movimientos de cámara alrededor del objeto. En otras palabras, al establecer la rotación de la cámara, el zoom y otras propiedades, puedes jugar con tus 
formas como si fueran el modelo 3D en PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) 
y [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): establece propiedades de contorno para hacer que la forma parezca una forma 3D de PowerPoint.
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth), 
[ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 
y [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): se utilizan para hacer que la forma sea tridimensional, lo que significa convertir una forma 2D en una forma 3D, 
estableciendo su profundidad o extruyéndola.
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): puede crear un efecto de luz en una forma 3D. La lógica de esta propiedad está relacionada con la cámara; puedes establecer la rotación de la luz 
en relación con la forma 3D y elegir el tipo de luz.
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): establecer el tipo de material de la forma 3D puede darle un efecto más vivo. La propiedad proporciona un conjunto de materiales predefinidos, como: 
Metal, Plástico, Polvo, Mate, etc.  

Todas las características 3D se pueden aplicar tanto a formas como a texto. Veamos cómo acceder a las propiedades mencionadas anteriormente y luego las examinaremos en detalle paso a paso:
``` csharp 
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.TextFrame.Text = "3D";
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    shape.ThreeDFormat.Material = MaterialPresetType.Flat;
    shape.ThreeDFormat.ExtrusionHeight = 100;
    shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("sample_3d.png");
    }

    presentation.Save("sandbox_3d.pptx", SaveFormat.Pptx);
}
```

La miniatura renderizada se ve así:

![todo:texto alternativo de imagen](img_01_01.png)

## Rotación 3D
Es posible rotar las formas 3D de PowerPoint en un plano 3D, lo que aporta más interactividad. Para rotar una forma 3D en PowerPoint, generalmente usas el siguiente menú:

![todo:texto alternativo de imagen](img_02_01.png)

En la API de Aspose.Slides, la rotación de las formas 3D se puede gestionar utilizando la propiedad [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera):

``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... establece otros parámetros de escena 3D

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

## Profundidad y Extrusión 3D
Para dar la tercera dimensión a tu forma y convertirla en una forma 3D, utiliza [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 
y [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) propiedades:

``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... establece otros parámetros de escena 3D

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

Normalmente, usas el menú de Profundidad en PowerPoint para establecer la profundidad de la forma 3D de PowerPoint:

![todo:texto alternativo de imagen](img_02_02.png)


## Gradiente 3D
El gradiente se puede utilizar para rellenar el color de la forma 3D de PowerPoint. Vamos a crear una forma con un color de relleno de gradiente y aplicar un efecto 3D en ella:

``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.TextFrame.Text = "Gradiente 3D";
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
    shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);
    
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    shape.ThreeDFormat.ExtrusionHeight = 150;
    shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("sample_3d.png");
    }
}
```

Y aquí está el resultado:

![todo:texto alternativo de imagen](img_02_03.png)

Además de un color de relleno de gradiente, es posible rellenar formas con una imagen:
``` csharp
byte[] imageData = File.ReadAllBytes("image.jpg");
IPPImage image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
// ... configuraciones 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* propiedades

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

Así es como se ve:

![todo:texto alternativo de imagen](img_02_04.png)

## Texto 3D (WordArt)
Aspose.Slides permite aplicar 3D al texto también. Para crear un texto 3D, es posible usar el efecto de transformación de WordArt:

``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.TextFrame.Text = "Texto 3D";

    Portion portion = (Portion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

    ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
    // establecer el efecto de transformación de WordArt "Arco hacia arriba"
    textFrameFormat.Transform = TextShapeType.ArchUp;

    textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
    textFrameFormat.ThreeDFormat.Depth = 3;
    textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
    textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("text3d.png");
    }

    presentation.Save("text3d.pptx", SaveFormat.Pptx);
}
```

Aquí está el resultado:

![todo:texto alternativo de imagen](img_02_05.png)


## No admitido - Próximamente
Las siguientes características 3D de PowerPoint aún no son compatibles: 
- Bisel
- Material
- Contorno
- Iluminación

Continuamos mejorando nuestro motor 3D, y estas características son el objetivo de futuras implementaciones.