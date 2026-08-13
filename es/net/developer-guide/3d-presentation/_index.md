---
title: Crear efectos 3D en presentaciones usando .NET
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
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aplicar y representar efectos 3D para formas y texto de PowerPoint en .NET con Aspose.Slides. Configurar cámara, iluminación, material, extrusión, rellenos y texto 3D."
---
## **Visión general**

Aspose.Slides para .NET puede crear, editar, conservar y representar el formato 3D al estilo PowerPoint para formas y texto. Este artículo cubre efectos 3D como rotación, extrusión, biseles, iluminación, material, rellenos degradados o de imagen, y texto 3D.

{{% alert color="info" %}}
Este artículo trata sobre los efectos de formato 3D en formas y texto de PowerPoint. No trata sobre la inserción o edición de archivos de modelo 3D independientes. Cuando exporta una diapositiva a una imagen, PDF o HTML, Aspose.Slides representa esos efectos 3D en la salida 2D exportada.
{{% /alert %}}

## **Conceptos de formato 3D**

Utilice la propiedad [IShape.ThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/properties/threedformat) para aplicar formato 3D a una forma. La propiedad expone [IThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat), que controla la escena 3D para esa forma.

Para texto, utilice la propiedad [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/properties/threedformat). Esto aplica formato 3D al marco de texto en lugar del cuerpo de la forma.

Las propiedades más importantes son:

| Propiedad | Qué controla | Cuándo usarla |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/camera) | Punto de vista, tipo de cámara predefinida, rotación, zoom y perspectiva. | Rotar el objeto en el espacio 3D o coincidir con un ajuste predefinido de rotación 3D de PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/lightrig) | Luz predefinida, dirección y rotación de la luz. | Cambiar cómo aparecen los reflejos y sombras en la superficie 3D. |
| [Material](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/material) | Material de la superficie, como plano, mate, plástico o metal. | Hacer que la misma geometría parezca más plana, suave, brillante o metálica. |
| [ExtrusionHeight](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/extrusionheight) | Cuán lejos se extiende la forma hacia atrás desde su cara frontal. | Convertir una forma plana en un objeto 3D visiblemente grueso. |
| [ExtrusionColor](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Color de los lados extruidos. | Hacer visible la profundidad o coordinar el color del lado con el relleno frontal. |
| [Depth](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/depth) | Profundidad 3D adicional usada por el formato 3D de PowerPoint. | Ajustar finamente la profundidad para formas o texto, sobre todo junto con ajustes de bisel y material. |
| [BevelTop](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/beveltop) y [BevelBottom](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/bevelbottom) | Bordes levantados o redondeados en las caras frontal y trasera. | Añadir un borde suavizado o moldeado en lugar de una cara plana y afilada. |
| [ContourColor](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/contourcolor) y [ContourWidth](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/contourwidth) | Contorno alrededor del objeto 3D. | Realzar el límite del objeto en la salida renderizada. |

## **Crear una forma 3D**

Una forma normalmente necesita cuatro tipos de ajustes antes de verse convincentemente 3D:

- Ajustes de cámara, porque la vista frontal predeterminada puede ocultar la extrusión.
- Ajustes de luz, porque la iluminación hace que las caras y los lados sean legibles.
- Ajustes de material, porque la superficie afecta cómo se representa la luz.
- Ajustes de extrusión o profundidad, porque una forma plana necesita grosor.

El siguiente ejemplo crea un rectángulo, añade texto a su cara frontal, aplica formato 3D, guarda la presentación como PPTX y representa la diapositiva en una imagen PNG.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

La imagen de la diapositiva renderizada muestra el rectángulo como un bloque 3D grueso:

![Rectángulo 3D azul renderizado con texto 3D blanco en la cara frontal](img_01_01.png)

## **Rotar una forma con la cámara**

En PowerPoint, la rotación 3D se configura desde el panel **3‑D Rotation**. Los valores de rotación X, Y y Z corresponden a la rotación que establece a través de la API de cámara.

![Panel 3‑D Rotation de PowerPoint con los valores de rotación X, Y y Z resaltados](img_02_01.png)

En Aspose.Slides, establezca el tipo de cámara y la rotación mediante [IThreeDFormat.Camera](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/camera):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Use la cámara cuando necesite cambiar la forma en que el observador ve el objeto. No modifica la geometría 2D de la forma en la diapositiva. Cambia el punto de vista 3D usado por PowerPoint y por Aspose.Slides al renderizar.

## **Añadir extrusión y profundidad**

La extrusión hace que una forma parezca gruesa al extenderla detrás de la cara frontal. En PowerPoint, el control de profundidad establece este grosor visible, y el control de color define el color de las caras laterales.

![Controles de profundidad de PowerPoint mapeados a las propiedades extrusionColor y extrusionHeight](img_02_02.png)

Establezca [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/extrusionheight) para el grosor y [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/extrusioncolor) para el color lateral:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Utilice [IThreeDFormat.Depth](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/depth) cuando necesite trabajar directamente con el valor de profundidad de PowerPoint o combinar profundidad con bisel, material y efectos de texto. En muchos escenarios de forma, `ExtrusionHeight` es el ajuste más claro porque expresa directamente la extrusión visible.

## **Usar rellenos degradados o de imagen con efectos 3D**

El formato 3D es independiente del relleno de la forma. Puede aplicar un color sólido, degradado, patrón o relleno de imagen a la cara frontal y seguir usando la misma cámara, luz, material y ajustes de extrusión.

Este ejemplo aplica un relleno degradado a la forma y un color de extrusión más oscuro a los lados:

```csharp
using System.Drawing;
using Aspose.Slides;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

La salida renderizada conserva el degradado en la cara frontal y representa la extrusión por separado:

![Rectángulo 3D renderizado con un degradado azul‑naranja y extrusión naranja](img_02_03.png)

Para usar un relleno de imagen, añada la imagen a la presentación y asígnela al relleno de la forma:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

La imagen se renderiza en la cara frontal, mientras que la extrusión se muestra como la superficie lateral 3D:

![Rectángulo 3D renderizado con una foto en la cara frontal y extrusión naranja](img_02_04.png)

## **Aplicar formato 3D al texto**

El formato 3D de la forma afecta al cuerpo de la forma. El formato 3D del texto afecta al marco de texto. Esto es útil para efectos al estilo WordArt donde las propias letras necesitan extrusión, material, iluminación y ajustes de cámara.

El siguiente ejemplo crea texto con un relleno de patrón, aplica una transformación de WordArt y configura los ajustes 3D en [ITextFrameFormat](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat):

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

El texto se renderiza como letras 3D curvadas y extruidas:

![Texto 3D renderizado con una transformación de WordArt arqueada, relleno de patrón naranja y extrusión oscura](img_02_05.png)

## **Comportamiento de exportación y renderizado**

Aspose.Slides conserva el formato 3D al guardar en formatos de PowerPoint como PPTX. Al renderizar o exportar a formatos de diseño fijo, la escena 3D se rasteriza o dibuja en la salida como un resultado 2D. Esto se aplica cuando renderiza diapositivas a [PNG](/slides/es/net/convert-powerpoint-to-png/), exporta a [PDF](/slides/es/net/convert-powerpoint-to-pdf/), exporta a [HTML](/slides/es/net/convert-powerpoint-to-html/), o genera fotogramas para [conversión de vídeo](/slides/es/net/convert-powerpoint-to-video/).

Tenga en cuenta estos puntos:

- Las imágenes y PDFs exportados no son interactivos. El objeto no puede rotarse por el espectador después de la exportación.
- La apariencia final depende de la combinación de cámara, conjunto de luces, material, extrusión, relleno y escala de la diapositiva.
- Si necesita inspeccionar los valores de formato heredados o basados en el tema, lea las [propiedades efectivas de la forma](/slides/es/net/shape-effective-properties/).
- Algunos formatos de salida no pueden almacenar el formato 3D editable de PowerPoint. En esos formatos, el resultado visual se renderiza en lugar de conservarse como ajustes 3D editables.

## **FAQ**

### ¿Puede Aspose.Slides crear presentaciones 3D interactivas?

Aspose.Slides crea y representa efectos 3D de PowerPoint para formas y texto. No convierte imágenes, PDFs o páginas HTML exportadas en escenas 3D interactivas que un espectador pueda rotar. En PPTX, el formato 3D permanece editable en PowerPoint donde el formato lo permite.

### ¿Cuál es la diferencia entre un modelo 3D y un efecto 3D?

Un modelo 3D es un objeto 3D independiente insertado en una presentación. Un efecto 3D es un formato aplicado a una forma o texto normal de PowerPoint, como rotación, extrusión, bisel, iluminación y material. Este artículo trata sobre efectos 3D.

### ¿Qué ajustes son necesarios para que una forma 3D sea visible?

Como mínimo, establezca una rotación de cámara y ya sea extrusión o profundidad. En la práctica, también configure un conjunto de luces y material para que las caras renderizadas tengan reflejos y sombras claros.

### ¿Puedo aplicar efectos 3D tanto a formas como a texto?

Sí. Use [IShape.ThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/properties/threedformat) para el cuerpo de la forma y [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/properties/threedformat) para el texto.

### ¿Aparecerán los efectos 3D al exportar a imágenes, PDF, HTML o fotogramas de vídeo?

Sí. Aspose.Slides representa los efectos 3D al generar imágenes de diapositivas, salida PDF, salida HTML y fotogramas usados para la conversión a vídeo. La salida exportada contiene la apariencia renderizada, no un objeto 3D editable.

### ¿Puedo leer los valores 3D finales tras aplicar la herencia y los ajustes del tema?

Sí. Utilice las API de formato efectivo descritas en [Propiedades efectivas de la forma](/slides/es/net/shape-effective-properties/) para leer la cámara final, conjunto de luces, bisel y valores 3D relacionados.