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
description: "Aplicar y renderizar efectos 3D para formas y texto de PowerPoint en .NET con Aspose.Slides. Configurar cámara, iluminación, material, extrusión, rellenos y texto 3D."
---
## **Visión general**

Aspose.Slides para .NET puede crear, editar, conservar y renderizar formato 3D al estilo de PowerPoint para formas y texto. Este artículo cubre efectos 3D como rotación, extrusión, biseles, iluminación, material, rellenos de degradado o imagen y texto 3D.

{{% alert color="info" title="Note" %}}
Este artículo trata sobre los efectos de formato 3D en formas y texto de PowerPoint. No trata de insertar o editar archivos de modelos 3D independientes. Cuando exportas una diapositiva a una imagen, PDF o HTML, Aspose.Slides renderiza esos efectos 3D en la salida 2D exportada.
{{% /alert %}}

## **Conceptos de formato 3D**

Utiliza la propiedad [IShape.ThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/properties/threedformat) para aplicar formato 3D a una forma. La propiedad expone [IThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat), que controla la escena 3D de esa forma.

Para texto, utiliza la propiedad [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/properties/threedformat). Esto aplica formato 3D al marco de texto en lugar del cuerpo de la forma.

| Propiedad | Qué controla | Cuándo usarla |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/camera) | Punto de vista, tipo de cámara predefinido, rotación, zoom y perspectiva. | Rotar el objeto en el espacio 3D o coincidir con un preset de rotación 3D de PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/lightrig) | Predefinido de luz, dirección y rotación de la luz. | Cambiar cómo aparecen los reflejos y sombras en la superficie 3D. |
| [Material](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/material) | Material de la superficie, como plano, mate, plástico o metal. | Hacer que la misma geometría parezca más plana, suave, brillante o metálica. |
| [ExtrusionHeight](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/extrusionheight) | Cuán lejos la forma se extiende hacia atrás desde su cara frontal. | Convertir una forma plana en un objeto 3D visiblemente grueso. |
| [ExtrusionColor](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Color de los lados extruidos. | Hacer visible la profundidad o coordinar el color de los lados con el relleno frontal. |
| [Depth](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/depth) | Profundidad 3D adicional utilizada por el formato 3D de PowerPoint. | Ajustar finamente la profundidad de formas o texto, especialmente junto con los ajustes de bisel y material. |
| [BevelTop](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/beveltop) and [BevelBottom](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/bevelbottom) | Bordes elevados o redondeados en las caras frontal y trasera. | Agregar un borde suavizado o moldeado en lugar de una cara plana y afilada. |
| [ContourColor](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/contourcolor) and [ContourWidth](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/contourwidth) | Contorno alrededor del objeto 3D. | Resaltar el límite del objeto en la salida renderizada. |

## **Crear una forma 3D**

Una forma normalmente necesita cuatro tipos de ajustes antes de que parezca convincentemente 3D:

- Configuraciones de cámara, porque la vista frontal predeterminada puede ocultar la extrusión.
- Configuraciones de luz, porque la iluminación hace que las caras y los lados sean visibles.
- Configuraciones de material, porque la superficie afecta cómo se renderiza la luz.
- Configuraciones de extrusión o profundidad, porque una forma plana necesita grosor.

El siguiente ejemplo crea un rectángulo, añade texto a su cara frontal y aplica formato 3D. Los valores de rotación de la cámara están en grados, y la altura de extrusión es de 100 puntos. El ejemplo renderiza la diapositiva a una imagen PNG al doble de sus dimensiones predeterminadas y guarda la presentación como PPTX.

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

En PowerPoint, la rotación 3D se configura desde el panel de Rotación 3-D. Los valores de rotación X, Y y Z corresponden a la rotación que estableces mediante la API de cámara.

![Panel de rotación 3-D de PowerPoint con los valores de rotación X, Y y Z resaltados](img_02_01.png)

En Aspose.Slides, accede a la cámara mediante [IThreeDFormat.Camera](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/camera). Este ejemplo crea un rectángulo, selecciona una vista frontal ortográfica y establece sus rotaciones X, Y y Z en 20, 30 y 40 grados, respectivamente. Configura la forma en memoria sin guardar un archivo:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Utiliza la cámara cuando necesites cambiar cómo el observador ve el objeto. No cambia la geometría 2D de la forma en la diapositiva. Cambia el punto de vista 3D utilizado por PowerPoint y por Aspose.Slides al renderizar.

## **Añadir extrusión y profundidad**

La extrusión hace que una forma parezca gruesa al extenderla detrás de la cara frontal. En PowerPoint, el control de profundidad establece esta grosor visible, y el control de color define el color de las caras laterales.

![Controles de profundidad de PowerPoint asignados a las propiedades de color de extrusión y altura de extrusión](img_02_02.png)

Establece [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/extrusionheight) para el grosor y [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/extrusioncolor) para el color de los lados. Este ejemplo da a un rectángulo una extrusión de 100 puntos con lados púrpuras y rota la cámara para revelar su grosor. Configura la forma en memoria sin guardar un archivo:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

La propiedad [IThreeDFormat.Depth](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/depth) establece la profundidad de una forma 3D. La propiedad [ExtrusionHeight](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/properties/extrusionheight) controla la altura del efecto de extrusión, como se muestra en este ejemplo.

## **Usar rellenos de degradado o imagen con efectos 3D**

El formato 3D es independiente del relleno de la forma. Puedes aplicar un color sólido, degradado, patrón o relleno de imagen a la cara frontal y seguir usando los mismos ajustes de cámara, luz, material y extrusión.

Este ejemplo aplica un degradado de azul a naranja en la cara frontal y un color naranja oscuro a la extrusión de 150 puntos. Las paradas del degradado en 0 y 100 marcan el inicio y el final del degradado. Los valores de rotación de la cámara están en grados. La diapositiva se renderiza a una imagen PNG al doble de sus dimensiones predeterminadas:

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

![Rectángulo 3D renderizado con relleno degradado de azul a naranja y extrusión naranja](img_02_03.png)

Para usar un relleno de imagen en su lugar, añade la imagen a la presentación y asígnala al relleno de la forma. Este ejemplo requiere un archivo existente llamado "image.jpg" en el directorio de trabajo. Estira la imagen para llenar el rectángulo, aplica una extrusión de 150 puntos y establece la rotación de la cámara en grados. Configura la forma en memoria sin guardar ni renderizar un archivo:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

![Rectángulo 3D renderizado con relleno fotográfico en la cara frontal y extrusión naranja](img_02_04.png)

## **Aplicar formato 3D al texto**

El formato 3D de la forma afecta al cuerpo de la forma. El formato 3D del texto afecta al marco de texto. Esto es útil para efectos similares a WordArt donde las propias letras necesitan extrusión, material, iluminación y ajustes de cámara.

El siguiente ejemplo crea texto con un patrón de cuadrícula naranja y blanco, aplica un arco ascendente y configura los ajustes 3D a través de [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/properties/threedformat). La altura de extrusión y la profundidad están en puntos, y la rotación de la luz está en grados. El relleno y el contorno de la forma están ocultos para que solo sea visible el texto. El ejemplo renderiza una imagen PNG al doble de las dimensiones predeterminadas de la diapositiva y guarda la presentación como PPTX:

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

![Texto 3D renderizado con una transformación de WordArt arqueada, relleno de patrón naranja y extrusión oscura](img_02_05.png)

## **Mantener el texto plano en una forma 3D**

Para mantener el texto legible mientras se conserva la apariencia 3D de una forma, establece [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/keeptextflat/) a través de [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/textframeformat/). Cuando el valor es `true`, el texto permanece fuera de la escena 3D. Cuando es `false`, el texto participa en la escena y sigue su orientación 3D.

Este ajuste no elimina el formato 3D de la forma: su cámara, iluminación, material y extrusión siguen configurados mediante [IShape.ThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/threedformat/). También es diferente de la rotación habitual. [IShape.Rotation](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/rotation/) rota la forma en el plano de la diapositiva, mientras que [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/rotationangle/) controla la rotación personalizada del texto dentro de su cuadro delimitador. Mantener el texto fuera de la escena 3D no restablece ninguno de esos ángulos.

El siguiente ejemplo autónomo crea un rectángulo azul con texto y lo clona al lado del original. Ambas formas tienen el mismo formato 3D; solo difiere el ajuste de texto: `false` a la izquierda y `true` a la derecha. Los ángulos de la cámara están en grados, y la altura de extrusión es de 40 puntos. El ejemplo guarda la presentación como PPTX y renderiza la diapositiva de comparación a PNG al doble de sus dimensiones predeterminadas.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

A la izquierda, el texto sigue la orientación 3D. A la derecha, permanece plano y más fácil de leer. Ambos rectángulos conservan la misma extrusión visible y orientación 3D.

![Rectángulos 3D lado a lado: KeepTextFlat es false a la izquierda y true a la derecha](keep_text_flat.png)

## **Comportamiento de exportación y renderizado**

Aspose.Slides conserva el formato 3D al guardar en formatos de PowerPoint como PPTX. Al renderizar o exportar a formatos de diseño fijo, la escena 3D se rasteriza o dibuja en la salida como un resultado 2D. Esto se aplica cuando renderizas diapositivas a [PNG](/slides/es/net/convert-powerpoint-to-png/), exportas a [PDF](/slides/es/net/convert-powerpoint-to-pdf/), exportas a [HTML](/slides/es/net/convert-powerpoint-to-html/), o generas fotogramas para [video conversion](/slides/es/net/convert-powerpoint-to-video/).

- Las imágenes y PDFs exportados no son interactivos. El objeto no puede ser rotado por el espectador después de la exportación.
- La apariencia final depende de la combinación de cámara, luz, material, extrusión, relleno y escala de la diapositiva.
- Si necesitas inspeccionar los valores de formato heredados o basados en el tema, lee las [propiedades efectivas de la forma](/slides/es/net/shape-effective-properties/).
- Algunos formatos de salida no pueden almacenar el formato 3D editable de PowerPoint. En esos formatos, el resultado visual se renderiza en lugar de preservarse como configuraciones 3D editables.

## **Preguntas frecuentes**

**¿Puede Aspose.Slides crear presentaciones 3D interactivas?**

Aspose.Slides crea y renderiza efectos 3D de PowerPoint para formas y texto. No convierte las imágenes, PDFs o páginas HTML exportadas en escenas 3D interactivas que el espectador pueda rotar. En PPTX, el formato 3D sigue siendo editable en PowerPoint siempre que el formato lo admita.

**¿Cuál es la diferencia entre un modelo 3D y un efecto 3D?**

Un modelo 3D es un objeto 3D independiente insertado en una presentación. Un efecto 3D es un formato aplicado a una forma o texto estándar de PowerPoint, como rotación, extrusión, bisel, iluminación y material. Este artículo trata sobre los efectos 3D.

**¿Qué ajustes son necesarios para una forma 3D visible?**

Como mínimo, establece una rotación de cámara y ya sea extrusión o profundidad. En la práctica, también configura una luz y material para que las caras renderizadas tengan reflejos y sombras claros.

**¿Puedo aplicar efectos 3D tanto a formas como a texto?**

Sí. Utiliza [IShape.ThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/properties/threedformat) para el cuerpo de la forma y [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/properties/threedformat) para el texto.

**¿Aparecerán los efectos 3D al exportar a imágenes, PDF, HTML o fotogramas de vídeo?**

Sí. Aspose.Slides renderiza los efectos 3D al generar imágenes de diapositivas, salida PDF, salida HTML y fotogramas utilizados para la conversión a vídeo. La salida exportada contiene la apariencia renderizada, no un objeto 3D editable.

**¿Puedo leer los valores finales 3D después de aplicar la herencia y la configuración del tema?**

Sí. Utiliza las API de formato efectivo descritas en [Shape Effective Properties](/slides/es/net/shape-effective-properties/) para leer los valores finales de cámara, luz, bisel y demás valores 3D relacionados.