---
title: Formatear formas de PowerPoint en .NET
linktitle: Formato de forma
type: docs
weight: 20
url: /es/net/shape-formatting/
keywords:
- formato de forma
- formato de línea
- efecto boceto
- línea de forma bocetada
- formato de estilo de unión
- relleno degradado
- relleno de patrón
- relleno de imagen
- relleno de textura
- relleno de color sólido
- transparencia de forma
- renderizado de forma en blanco y negro
- renderizado de forma en escala de grises
- rotar forma
- efecto de bisel 3D
- efecto de rotación 3D
- restablecer formato
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a formatear formas de PowerPoint en C# usando Aspose.Slides—establezca estilos de relleno, línea y efecto para archivos PPT y PPTX con precisión y control total."
---
## **Introducción**

En PowerPoint, puedes añadir formas a las diapositivas. Como las formas están compuestas por líneas, puedes formatearlas modificando o aplicando efectos a sus contornos. Además, puedes formatear las formas especificando configuraciones que controlan cómo se rellenan sus interiores.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET proporciona interfaces y propiedades que permiten formatear formas usando las mismas opciones disponibles en PowerPoint.

## **Formato de líneas**

Usando Aspose.Slides, puedes especificar un estilo de línea personalizado para una forma. Los pasos siguientes describen el procedimiento:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establece el [estilo de línea](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) de la forma.
1. Establece el ancho de línea.
1. Establece el [estilo de guión](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) de la línea.
1. Establece el color de línea para la forma.
1. Guarda la presentación modificada como un archivo PPTX.

El siguiente código C# muestra cómo formatear un rectángulo `AutoShape`:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Añadir una forma automática del tipo Rectángulo.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Establecer el color de relleno para la forma rectangular.
    shape.FillFormat.FillType = FillType.NoFill;

    // Aplicar formato a las líneas del rectángulo.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Establecer el color para la línea del rectángulo.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Guardar el archivo PPTX en disco.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

El resultado:

![Las líneas formateadas en la presentación](formatted-lines.png)

## **Aplicar efectos de boceto a las líneas de forma**

Un efecto de boceto hace que la línea de una forma parezca dibujada a mano. Usa [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) para acceder a la configuración de la línea, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) para acceder a la configuración de boceto, y [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) para seleccionar un valor de la enumeración [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

El siguiente código C# muestra cómo aplicar el efecto [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) , leer el valor asignado explícitamente y eliminar el efecto con [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) :

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

El valor devuelto por `ISketchFormat.SketchType` representa la configuración asignada directamente a la forma. Si el formato de línea puede heredarse de un tema, diapositiva maestra o diapositiva de diseño, usa [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/) , accede a [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) y lee [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/) . El valor efectivo refleja el formato que realmente se aplica después de resolver la herencia:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Formato de estilos de unión**

Estas son las tres opciones de tipo de unión:

* Round
* Miter
* Bevel

Por defecto, cuando PowerPoint une dos líneas en un ángulo (por ejemplo, en la esquina de una forma), utiliza la configuración **Round**. Sin embargo, si dibujas una forma con ángulos agudos, puede que prefieras la opción **Miter**.

![El estilo de unión en la presentación](join-style-powerpoint.png)

El siguiente código C# muestra cómo se crearon tres rectángulos (como se muestra en la imagen anterior) usando las configuraciones de unión Miter, Bevel y Round:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Añadir tres formas automáticas del tipo Rectángulo.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Establecer el color de relleno para cada forma rectangular.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Establecer el ancho de línea.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Establecer el color de la línea de cada rectángulo.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Establecer el estilo de unión.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Añadir texto a cada rectángulo.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Guardar el archivo PPTX en disco.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Relleno degradado**

En PowerPoint, el Gradient Fill es una opción de formato que permite aplicar una mezcla continua de colores a una forma. Por ejemplo, puedes aplicar dos o más colores de forma que uno se desvanezca gradualmente en otro.

Así es como se aplica un relleno degradado a una forma usando Aspose.Slides:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establece el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forma a `Gradient`.
1. Añade tus dos colores preferidos con posiciones definidas usando los métodos Add de la colección de paradas de degradado expuesta por la interfaz [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/) .
1. Guarda la presentación modificada como un archivo PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Añadir una forma automática del tipo Elipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Aplicar formato degradado a la elipse.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Establecer la dirección del degradado.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Añadir dos paradas de degradado.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Guardar el archivo PPTX en disco.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

El resultado:

![La elipse con relleno degradado](gradient-fill.png)

Si un degradado se ve diferente en una imagen exportada que en PowerPoint, consulta [Elegir un estilo de renderizado de degradado](/slides/es/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Puedes seleccionar un estilo de renderizado sin cambiar el relleno degradado almacenado en la presentación.

## **Relleno de patrón**

En PowerPoint, el Pattern Fill es una opción de formato que permite aplicar un diseño de dos colores—como puntos, rayas, tramas o cuadros—a una forma. Puedes elegir colores personalizados para el primer plano y el fondo del patrón.

Aspose.Slides ofrece más de 45 estilos de patrón predefinidos que puedes aplicar a las formas para mejorar el aspecto visual de tus presentaciones. Incluso después de seleccionar un patrón predefinido, todavía puedes especificar los colores exactos que debe usar.

Así es como se aplica un relleno de patrón a una forma usando Aspose.Slides:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establece el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forma a `Pattern`.
1. Elige un estilo de patrón de las opciones predefinidas.
1. Establece el [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) del patrón.
1. Establece el [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) del patrón.
1. Guarda la presentación modificada como un archivo PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Añadir una forma automática del tipo Rectángulo.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Establecer el tipo de relleno a Patrón.
    shape.FillFormat.FillType = FillType.Pattern;

    // Establecer el estilo de patrón.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Establecer los colores de fondo y de primer plano del patrón.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Guardar el archivo PPTX en disco.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

El resultado:

![El rectángulo con relleno de patrón](pattern-fill.png)

## **Relleno de imagen**

En PowerPoint, el Picture Fill es una opción de formato que permite insertar una imagen dentro de una forma—utilizando efectivamente la imagen como fondo de la forma.

Así es como usar Aspose.Slides para aplicar un relleno de imagen a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establece el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forma a `Picture`.
1. Establece el modo de relleno de imagen a `Tile` (u otro modo preferido).
1. Crea un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) a partir de la imagen que deseas usar.
1. Asigna esta imagen a la propiedad `Picture.Image` del `PictureFillFormat` de la forma.
1. Guarda la presentación modificada como un archivo PPTX.

Supongamos que tenemos un archivo "lotus.png" con la siguiente imagen:

![La imagen del loto](lotus.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Añadir una forma automática del tipo Rectángulo.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Establecer el tipo de relleno a Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Establecer el modo de relleno de imagen.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Cargar una imagen y añadirla a los recursos de la presentación.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    imageDispose();

    // Establecer la imagen.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Guardar el archivo PPTX en disco.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

El resultado:

![La forma con relleno de imagen](picture-fill.png)

### **Mosaico de imagen como textura**

Si deseas establecer una imagen en mosaico como textura y personalizar el comportamiento del mosaico, puedes usar las siguientes propiedades de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) y la clase [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) :

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) : PictureFillMode: Establece el modo de relleno de imagen—`Tile` o `Stretch` .
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/) : TileAlignment: Especifica la alineación de los mosaicos dentro de la forma.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/) : TileFlip: Controla si el mosaico se voltea horizontalmente, verticalmente o ambos.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/) : TileOffsetX: Establece el desplazamiento horizontal del mosaico (en puntos) desde el origen de la forma.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/) : TileOffsetY: Establece el desplazamiento vertical del mosaico (en puntos) desde el origen de la forma.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/) : TileScaleX: Define la escala horizontal del mosaico como un porcentaje.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/) : TileScaleY: Define la escala vertical del mosaico como un porcentaje.

El siguiente ejemplo de código muestra cómo añadir una forma rectangular con un relleno de imagen en mosaico y configurar las opciones de mosaico:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide firstSlide = presentation.Slides[0];

    // Añadir una forma automática rectangular.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Establecer el tipo de relleno de la forma a Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Cargar la imagen y añadirla a los recursos de la presentación.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Asignar la imagen a la forma.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Configurar el modo de relleno de imagen y las propiedades de mosaico.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Guardar el archivo PPTX en disco.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

El resultado:

![Las opciones de mosaico](tile-options.png)

## **Relleno de color sólido**

En PowerPoint, el Solid Color Fill es una opción de formato que rellena una forma con un único color uniforme. Este color de fondo simple se aplica sin degradados, texturas ni patrones.

Para aplicar un relleno de color sólido a una forma usando Aspose.Slides, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establece el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forma a `Solid`.
1. Asigna tu color de relleno preferido a la forma.
1. Guarda la presentación modificada como un archivo PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Añadir una forma automática del tipo Rectángulo.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Establecer el tipo de relleno a Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Establecer el color de relleno.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Guardar el archivo PPTX en disco.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

El resultado:

![La forma con relleno de color sólido](solid-color-fill.png)

## **Establecer transparencia**

En PowerPoint, cuando aplicas un relleno sólido, degradado, imagen o textura a las formas, también puedes establecer un nivel de transparencia para controlar la opacidad del relleno. Un valor de transparencia más alto hace que la forma sea más translúcida, permitiendo que el fondo u objetos subyacentes sean parcialmente visibles.

Aspose.Slides permite establecer el nivel de transparencia ajustando el valor alfa en el color usado para el relleno. Así es como se hace:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establece el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) a `Solid`.
1. Usa `Color.FromArgb(alpha, baseColor)` para definir un color con transparencia (el componente `alpha` controla la transparencia).
1. Guarda la presentación.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Añadir una forma automática rectangular sólida.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Añadir una forma automática rectangular transparente sobre la forma sólida.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Guardar el archivo PPTX en disco.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

El resultado:

![La forma transparente](shape-transparency.png)

## **Rotar formas**

Aspose.Slides permite rotar formas en presentaciones de PowerPoint. Esto puede ser útil al posicionar elementos visuales con necesidades específicas de alineación o diseño.

Para rotar una forma en una diapositiva, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establece la propiedad `Rotation` de la forma al ángulo deseado.
1. Guarda la presentación.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Añadir una forma automática del tipo Rectángulo.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotar la forma 5 grados.
    shape.Rotation = 5;

    // Guardar el archivo PPTX en disco.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

El resultado:

![La rotación de la forma](shape-rotation.png)

## **Añadir efectos de bisel 3D**

Aspose.Slides permite aplicar efectos de bisel 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) .

Para añadir efectos de bisel 3D a una forma, sigue estos pasos:

1. Instancia la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Configura el [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) de la forma para definir los ajustes de bisel.
1. Guarda la presentación.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Crear una instancia de la clase Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Añadir una forma a la diapositiva.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Establecer las propiedades ThreeDFormat de la forma.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Guardar la presentación como archivo PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

El resultado:

![El efecto de bisel 3D](3D-bevel-effect.png)

## **Añadir efectos de rotación 3D**

Aspose.Slides permite aplicar efectos de rotación 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) .

Para aplicar rotación 3D a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establece el [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) y el [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) de la forma para definir la rotación 3D.
1. Guarda la presentación.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Crear una instancia de la clase Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Guardar la presentación como archivo PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

El resultado:

![El efecto de rotación 3D](3D-rotation-effect.png)

## **Controlar el renderizado en blanco y negro para formas**

La propiedad [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) especifica cómo se renderiza una forma individual cuando una presentación se visualiza o procesa en modo blanco y negro. No habilita la visualización en blanco y negro por sí sola, y no cambia el relleno, la línea u otro formato de la forma en modo de color normal.

Utiliza un valor de la enumeración [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) para seleccionar el comportamiento deseado. Por ejemplo, `Automatic` permite que la aplicación de renderizado elija la conversión, `Gray` y `LightGray` usan tonos grises, `BlackWhite` usa solo negro y blanco, `Black` y `White` fuerzan un único color, `Color` conserva el color normal, y `Hidden` omite la forma en modo blanco y negro. `NotDefined` significa que no se ha asignado un modo a nivel de forma.

El siguiente código C# crea una forma coloreada y la hace aparecer gris en modo de visualización en blanco y negro:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Mantener el relleno naranja en modo color, pero renderizar la forma con color gris en modo blanco y negro.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

En modo de color normal, el rectángulo conserva su relleno naranja. En un flujo de trabajo de visualización en blanco y negro, usa color gris porque su modo está configurado a `Gray`. Esto te permite conservar una diapositiva a todo color mientras defines una apariencia distinta para impresión, vista previa u otros flujos que respeten la configuración de visualización en blanco y negro de la presentación.

## **Restablecer formato**

El siguiente código C# muestra cómo restablecer el formato de una diapositiva y revertir la posición, tamaño y formato de todas las formas con marcadores de posición en el [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) a sus valores predeterminados:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Restablecer cada forma en la diapositiva que tiene un marcador de posición en el diseño.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**¿Afecta el formato de las formas al tamaño final del archivo de la presentación?**

Solo de forma mínima. Las imágenes y los medios incrustados ocupan la mayor parte del espacio del archivo, mientras que los parámetros de las formas, como colores, efectos y degradados, se almacenan como metadatos y prácticamente no añaden tamaño adicional.

**¿Cómo puedo detectar formas en una diapositiva que comparten un formato idéntico para poder agruparlas?**

Compara las propiedades clave de formato de cada forma—relleno, línea y configuraciones de efectos. Si todos los valores correspondientes coinciden, considera sus estilos como idénticos y agrupa lógicamente esas formas, lo que simplifica la gestión de estilos posterior.

**¿Puedo guardar un conjunto de estilos de forma personalizados en un archivo separado para reutilizarlos en otras presentaciones?**

Sí. Guarda formas de ejemplo con los estilos deseados en una presentación de plantilla o en un archivo de plantilla .POTX. Al crear una nueva presentación, abre la plantilla, clona las formas con estilo que necesites y vuelve a aplicar su formato donde sea necesario.