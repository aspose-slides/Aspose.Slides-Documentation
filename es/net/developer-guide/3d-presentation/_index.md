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
- gradiente 3D
- texto 3D
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Genere presentaciones 3D interactivas en .NET con Aspose.Slides de forma sencilla. Exporte rápidamente a formatos PowerPoint y OpenDocument para un uso versátil."
---

## **Descripción general**
¿Cómo suele crear una presentación de PowerPoint en 3D?  
Microsoft PowerPoint permite crear presentaciones en 3D en los que podemos añadir modelos 3D, aplicar efectos 3D a las formas, crear texto en 3D, subir gráficos 3D a la presentación y crear animaciones 3D en PowerPoint.  

Crear efectos 3D tiene un gran impacto al mejorar su presentación a una presentación en 3D, y puede ser la forma más sencilla de implementar una presentación 3D.  
Desde la versión 20.9 de Aspose.Slides, se ha añadido un nuevo **motor 3D multiplataforma**. El nuevo motor 3D permite exportar y rasterizar formas y texto con efectos 3D. En versiones anteriores, las formas de Slides con efectos 3D aplicados se renderizaban de forma plana. Pero ahora es posible renderizar formas con un **3D completo**.  
Además, ahora es posible crear formas con efectos 3D mediante la API pública de Slides.  

En la API de Aspose.Slides, para convertir una forma en una forma 3D de PowerPoint use la propiedad [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat), que hereda las características de la interfaz [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat):
- [BevelBottom] y [BevelTop]: establece el bisel en la forma, define el tipo de bisel (p. ej., Angle, Circle, SoftRound), define la altura y el ancho del bisel.  
- [Camera]: se usa para imitar los movimientos de cámara alrededor del objeto. En otras palabras, al establecer la rotación, el zoom y otras propiedades de la cámara, puede manipular sus formas como con el modelo 3D en PowerPoint.  
- [ContourColor] y [ContourWidth]: establecen las propiedades de contorno para que la forma parezca una forma 3D de PowerPoint.  
- [Depth], [ExtrusionColor] y [ExtrusionHeight]: se usan para dar a la forma tres dimensiones, lo que significa convertir una forma 2D en una forma 3D, configurando su profundidad o extrusión.  
- [LightRig]: puede crear un efecto de luz en una forma 3D. La lógica de esta propiedad es similar a la de Camera; puede establecer la rotación de la luz en relación con la forma 3D y elegir el tipo de luz.  
- [Material]: establecer el tipo de material de la forma 3D puede aportar un efecto más realista. La propiedad proporciona un conjunto de materiales predefinidos, como: Metal, Plastic, Powder, Matte, etc.  

Todas las funciones 3D pueden aplicarse tanto a formas como a texto. Veamos cómo acceder a las propiedades mencionadas anteriormente y luego revisémoslas en detalle paso a paso:
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
Es posible rotar las formas 3D de PowerPoint en un plano 3D, lo que aporta mayor interactividad. Para rotar una forma 3D en PowerPoint, normalmente se usa el siguiente menú:

![todo:image_alt_text](img_02_01.png)

En la API de Aspose.Slides, la rotación de formas 3D se puede gestionar mediante la propiedad [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera):
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


Normalmente, se utiliza el menú Depth en PowerPoint para establecer la profundidad de una forma 3D de PowerPoint:

![todo:image_alt_text](img_02_02.png)


## **Gradiente 3D**
El gradiente puede usarse para rellenar el color de una forma 3D de PowerPoint. Creemos una forma con color de relleno degradado y apliquemos un efecto 3D sobre ella:
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

Además de un color de relleno degradado, es posible rellenar las formas con una imagen:
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
Aspose.Slides también permite aplicar 3D al texto. Para crear un texto 3D es posible usar el efecto de transformación WordArt:
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


Aquí está el resultado:

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**¿Se conservarán los efectos 3D al exportar una presentación a imágenes/PDF/HTML?**

Sí. El motor 3D de Slides renderiza los efectos 3D al exportar a los formatos compatibles ([images](/slides/es/net/convert-powerpoint-to-png/), [PDF](/slides/es/net/convert-powerpoint-to-pdf/), [HTML](/slides/es/net/convert-powerpoint-to-html/), etc.).

**¿Puedo obtener los valores "effective" (finales) de los parámetros 3D que tienen en cuenta temas, herencia, etc.?**

Sí. Slides ofrece API para [read effective values](/slides/es/net/shape-effective-properties/) (incluyendo 3D—iluminación, biseles, etc.) para que pueda ver la configuración final aplicada.

**¿Funcionan los efectos 3D al convertir una presentación a video?**

Sí. Cuando [generating frames for the video](/slides/es/net/convert-powerpoint-to-video/), los efectos 3D se renderizan igual que para [exported images](/slides/es/net/convert-powerpoint-to-png/).