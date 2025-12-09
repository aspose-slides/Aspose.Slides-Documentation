---
title: Crear presentaciones 3D en .NET
linktitle: Presentación 3D
type: docs
weight: 232
url: /es/net/3d-presentation/
keywords:
- PowerPoint 3D
- presentación 3D
- rotación 3D
- profundidad 3D
- extrusión 3D
- degradado 3D
- texto 3D
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Genere presentaciones 3D interactivas en .NET con Aspose.Slides sin esfuerzo. Exporte rápidamente a formatos PowerPoint y OpenDocument para usos versátiles."
---

## **Visión general**
¿Cómo suele crear una presentación de PowerPoint en 3D?  
Microsoft PowerPoint permite crear presentaciones 3D al agregar modelos 3D, aplicar efectos 3D a formas, crear texto 3D, cargar gráficos 3D en la presentación y crear animaciones 3D en PowerPoint.

Crear efectos 3D tiene un gran impacto en la mejora de su presentación, convirtiéndola en una presentación 3D, y puede ser la forma más sencilla de implementar una presentación 3D.  
Desde la versión 20.9 de Aspose.Slides, se ha añadido un **motor 3D multiplataforma**. El nuevo motor 3D permite exportar y rasterizar formas y texto con efectos 3D. En versiones anteriores, las formas de Slides con efectos 3D aplicados se renderizaban de forma plana. Ahora es posible renderizar formas con un **3D completo**.  
Además, ahora es posible crear formas con efectos 3D mediante la API pública de Slides.

En la API de Aspose.Slides, para convertir una forma en una forma 3D de PowerPoint use la propiedad [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat), que hereda las características de la interfaz [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat):
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) y [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): establezca el bisel de la forma, defina el tipo de bisel (p. ej., Angle, Circle, SoftRound), la altura y el ancho del bisel.
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): se usa para imitar movimientos de cámara alrededor del objeto. En otras palabras, al establecer rotación, zoom y otras propiedades puede “entretener” sus formas como con el modelo 3D en PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) y [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): establezca propiedades de contorno para que la forma parezca una forma 3D de PowerPoint.
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth), [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) y [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): se usan para dar a la forma una tercera dimensión, lo que significa convertir una forma 2D en una forma 3D, estableciendo su profundidad o extrusión.
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): puede crear un efecto de luz en una forma 3D. La lógica de esta propiedad es similar a la de Camera; puede establecer la rotación de la luz en relación con la forma 3D y elegir el tipo de luz.
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): establecer el tipo de material de la forma 3D aporta un efecto más realista. La propiedad ofrece un conjunto de materiales predefinidos, como Metal, Plastic, Powder, Matte, etc.

Todas las funciones 3D pueden aplicarse tanto a formas como a texto. Veamos cómo acceder a las propiedades mencionadas y, a continuación, analicémoslas paso a paso:
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

![todo:image_alt_text](img_01_01.png)

## **Rotación 3D**
Es posible rotar formas 3D de PowerPoint en un plano 3D, lo que brinda mayor interactividad. Para rotar una forma 3D en PowerPoint, normalmente se utiliza el siguiente menú:

![todo:image_alt_text](img_02_01.png)

En la API de Aspose.Slides, la rotación de formas 3D puede gestionarse mediante la propiedad [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera):
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... establecer otros parámetros de la escena 3D

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


## **Profundidad 3D y Extrusión**
Para añadir la tercera dimensión a su forma y convertirla en una forma 3D, use las propiedades [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) y [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor):
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... establecer otros parámetros de la escena 3D

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


Normalmente, se usa el menú Depth en PowerPoint para establecer la profundidad de una forma 3D de PowerPoint:

![todo:image_alt_text](img_02_02.png)


## **Gradiente 3D**
El gradiente puede usarse para rellenar el color de una forma 3D de PowerPoint. Creemos una forma con relleno de gradiente y apliquemos un efecto 3D:
``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.TextFrame.Text = "3D Gradient";
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

![todo:image_alt_text](img_02_03.png)

Además de un relleno de gradiente, es posible rellenar formas con una imagen:
``` csharp
byte[] imageData = File.ReadAllBytes("image.jpg");
IPPImage image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
// ... configurar 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* propiedades

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


Así es como se ve:

![todo:image_alt_text](img_02_04.png)

## **Texto 3D (WordArt)**
Aspose.Slides permite aplicar 3D al texto también. Para crear texto 3D es posible usar el efecto de transformación WordArt:
``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.TextFrame.Text = "3D Text";

    Portion portion = (Portion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

    ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
    // establecer el efecto de transformación WordArt "Arch Up"
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


Este es el resultado:

![todo:image_alt_text](img_02_05.png)

## **Preguntas frecuentes**

**¿Se conservarán los efectos 3D al exportar una presentación a imágenes/PDF/HTML?**

Sí. El motor 3D de Slides renderiza los efectos 3D al exportar a los formatos compatibles ([images](/slides/es/net/convert-powerpoint-to-png/), [PDF](/slides/es/net/convert-powerpoint-to-pdf/), [HTML](/slides/es/net/convert-powerpoint-to-html/), etc.).

**¿Puedo obtener los valores “efectivos” (finales) de los parámetros 3D que tienen en cuenta temas, herencia, etc.?**

Sí. Slides proporciona API para [read effective values](/slides/es/net/shape-effective-properties/) (incluyendo 3D—iluminación, biseles, etc.) de modo que pueda ver la configuración final aplicada.

**¿Los efectos 3D funcionan al convertir una presentación a video?**

Sí. Al [generar fotogramas para el video](/slides/es/net/convert-powerpoint-to-video/), los efectos 3D se renderizan igual que en las [imágenes exportadas](/slides/es/net/convert-powerpoint-to-png/).