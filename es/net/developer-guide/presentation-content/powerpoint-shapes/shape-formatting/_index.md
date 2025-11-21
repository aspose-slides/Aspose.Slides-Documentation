---
title: Formatear formas de PowerPoint en .NET
linktitle: Formato de formas
type: docs
weight: 20
url: /es/net/shape-formatting/
keywords:
- formato de forma
- formato de línea
- formato de estilo de unión
- relleno degradado
- relleno de patrón
- relleno de imagen
- relleno de textura
- relleno de color sólido
- transparencia de forma
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

## **Visión general**

En PowerPoint, puede añadir formas a las diapositivas. Dado que las formas están compuestas por líneas, puede formatearlas modificando o aplicando efectos a sus contornos. Además, puede formatear las formas especificando configuraciones que controlan cómo se rellenan sus interiores.

![formato de forma PowerPoint](format-shape-powerpoint.png)

Aspose.Slides para .NET proporciona interfaces y propiedades que le permiten formatear formas usando las mismas opciones disponibles en PowerPoint.

## **Formato de líneas**

Usando Aspose.Slides, puede especificar un estilo de línea personalizado para una forma. Los siguientes pasos describen el procedimiento:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) de la forma.
1. Establecer el ancho de línea.
1. Establecer el [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) de la línea.
1. Establecer el color de línea para la forma.
1. Guardar la presentación modificada como archivo PPTX.

El siguiente código C# muestra cómo formatear un `AutoShape` rectangular:
```c#
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

    // Establecer el color de la línea del rectángulo.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Guardar el archivo PPTX en disco.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```


El resultado:

![Las líneas formateadas en la presentación](formatted-lines.png)

## **Formato de estilos de unión**

Estas son las tres opciones de tipo de unión:

* Redondo
* Inglete
* Bisel

De forma predeterminada, cuando PowerPoint une dos líneas en un ángulo (como en la esquina de una forma), utiliza la configuración **Redondo**. Sin embargo, si está dibujando una forma con ángulos agudos, puede preferir la opción **Inglete**.

![El estilo de unión en la presentación](join-style-powerpoint.png)

El siguiente código C# muestra cómo se crearon tres rectángulos (como se muestra en la imagen anterior) usando los ajustes de tipo de unión Inglete, Bisel y Redondo:
```c#
// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Añadir tres formas automáticas del tipo Rectangle.
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

En PowerPoint, el Relleno degradado es una opción de formato que le permite aplicar una mezcla continua de colores a una forma. Por ejemplo, puede aplicar dos o más colores de modo que uno se desvanezca gradualmente en otro.

Así es como se aplica un relleno degradado a una forma usando Aspose.Slides:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forma a `Gradient`.
1. Agregue sus dos colores preferidos con posiciones definidas usando los métodos `Add` de la colección de paradas de degradado expuesta por la interfaz [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/).
1. Guardar la presentación modificada como archivo PPTX.

El siguiente código C# muestra cómo aplicar un efecto de relleno degradado a una elipse:
```c#
 // Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Añadir una forma automática del tipo Elipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Aplicar formato de degradado a la elipse.
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

## **Relleno de patrón**

En PowerPoint, el Relleno de patrón es una opción de formato que le permite aplicar un diseño de dos colores—como puntos, rayas, cruces o cuadros—a una forma. Puede elegir colores personalizados para el primer plano y el fondo del patrón.

Aspose.Slides proporciona más de 45 estilos de patrón predefinidos que puede aplicar a las formas para mejorar el atractivo visual de sus presentaciones. Incluso después de seleccionar un patrón predefinido, aún puede especificar los colores exactos que debe usar.

Así es como se aplica un relleno de patrón a una forma usando Aspose.Slides:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forma a `Pattern`.
1. Elegir un estilo de patrón de las opciones predefinidas.
1. Establecer el [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) del patrón.
1. Establecer el [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) del patrón.
1. Guardar la presentación modificada como archivo PPTX.

El siguiente código C# muestra cómo aplicar un relleno de patrón a un rectángulo:
```c#
 // Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Añadir una forma automática del tipo Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Establecer el tipo de relleno a Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Establecer el estilo del patrón.
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

En PowerPoint, el Relleno de imagen es una opción de formato que permite insertar una imagen dentro de una forma—usando efectivamente la imagen como fondo de la forma.

Así es como se usa Aspose.Slides para aplicar un relleno de imagen a una forma:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forma a `Picture`.
1. Establecer el modo de relleno de imagen a `Tile` (u otro modo preferido).
1. Crear un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) a partir de la imagen que desea usar.
1. Asignar esta imagen a la propiedad `Picture.Image` del `PictureFillFormat` de la forma.
1. Guardar la presentación modificada como archivo PPTX.

Supongamos que tenemos un archivo "lotus.png" con la siguiente imagen:

![La imagen de loto](lotus.png)

El siguiente código C# muestra cómo rellenar una forma con la imagen:
```c#
// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Añadir una forma automática del tipo Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Establecer el tipo de relleno a Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Establecer el modo de relleno de imagen.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Cargar una imagen y añadirla a los recursos de la presentación.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Establecer la imagen.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Guardar el archivo PPTX en disco.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```


El resultado:

![La forma con relleno de imagen](picture-fill.png)

### **Imagen de mosaico como textura**

Si desea establecer una imagen en mosaico como textura y personalizar el comportamiento del mosaicado, puede usar las siguientes propiedades de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) y la clase [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Establece el modo de relleno de imagen—`Tile` o `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Especifica la alineación de los mosaicos dentro de la forma.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Controla si el mosaico se voltea horizontalmente, verticalmente o ambos.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Establece el desplazamiento horizontal del mosaico (en puntos) desde el origen de la forma.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Establece el desplazamiento vertical del mosaico (en puntos) desde el origen de la forma.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Define la escala horizontal del mosaico como porcentaje.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Define la escala vertical del mosaico como porcentaje.

El siguiente fragmento de código muestra cómo añadir una forma rectangular con un relleno de imagen en mosaico y configurar las opciones de mosaico:
```c#
 // Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide firstSlide = presentation.Slides[0];

    // Añadir una forma automática de rectángulo.
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

En PowerPoint, el Relleno de color sólido es una opción de formato que llena una forma con un color único y uniforme. Este fondo liso se aplica sin degradados, texturas ni patrones.

Para aplicar un relleno de color sólido a una forma usando Aspose.Slides, siga estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forma a `Solid`.
1. Asignar el color de relleno preferido a la forma.
1. Guardar la presentación modificada como archivo PPTX.

El siguiente código C# muestra cómo aplicar un relleno de color sólido a un rectángulo en una diapositiva de PowerPoint:
```c#
// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Añadir una forma automática del tipo Rectangle.
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

En PowerPoint, cuando aplica un color sólido, degradado, imagen o textura a las formas, también puede establecer un nivel de transparencia para controlar la opacidad del relleno. Un valor de transparencia mayor hace que la forma sea más translúcida, permitiendo que el fondo o los objetos subyacentes sean parcialmente visibles.

Aspose.Slides le permite establecer el nivel de transparencia ajustando el valor alfa en el color usado para el relleno. Así es como se hace:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) a `Solid`.
1. Use `Color.FromArgb(alpha, baseColor)` para definir un color con transparencia (el componente `alpha` controla la transparencia).
1. Guardar la presentación.

El siguiente código C# muestra cómo aplicar un color de relleno transparente a un rectángulo:
```c#
const int alpha = 128;

// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Añadir una forma automática de rectángulo sólido.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Añadir una forma automática de rectángulo transparente sobre la forma sólida.
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

Aspose.Slides le permite rotar formas en presentaciones de PowerPoint. Esto puede ser útil al posicionar elementos visuales con requerimientos específicos de alineación o diseño.

Para rotar una forma en una diapositiva, siga estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establecer la propiedad `Rotation` de la forma al ángulo deseado.
1. Guardar la presentación.

El siguiente código C# muestra cómo rotar una forma 5 grados:
```c#
// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Añadir una forma automática del tipo Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotar la forma 5 grados.
    shape.Rotation = 5;

    // Guardar el archivo PPTX en disco.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```


El resultado:

![La rotación de la forma](shape-rotation.png)

## **Agregar efectos de bisel 3D**

Aspose.Slides permite aplicar efectos de bisel 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

Para añadir efectos de bisel 3D a una forma, siga estos pasos:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Configurar el [ThreeDFormat] de la forma para definir los ajustes de bisel.
1. Guardar la presentación.

El siguiente código C# muestra cómo aplicar efectos de bisel 3D a una forma:
```c#
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

## **Agregar efectos de rotación 3D**

Aspose.Slides permite aplicar efectos de rotación 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

Para aplicar rotación 3D a una forma:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) y el [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) de la forma para definir la rotación 3D.
1. Guardar la presentación.

El siguiente código C# muestra cómo aplicar efectos de rotación 3D a una forma:
```c#
// Crear una instancia de la clase Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Guardar la presentación como archivo PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```


El resultado:

![El efecto de rotación 3D](3D-rotation-effect.png)

## **Restablecer formato**

El siguiente código C# muestra cómo restablecer el formato de una diapositiva y revertir la posición, el tamaño y el formato de todas las formas con marcadores de posición en el [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) a sus configuraciones predeterminadas:
```c#
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


## **Preguntas frecuentes**

**¿El formato de la forma afecta al tamaño final del archivo de presentación?**

Solo de forma mínima. Las imágenes y los medios incrustados ocupan la mayor parte del espacio del archivo, mientras que los parámetros de la forma como colores, efectos y degradados se almacenan como metadatos y prácticamente no añaden tamaño extra.

**¿Cómo puedo detectar formas en una diapositiva que comparten el mismo formato para poder agruparlas?**

Compare las propiedades clave de formato de cada forma—relleno, línea y ajustes de efecto. Si todos los valores correspondientes coinciden, trate sus estilos como idénticos y agrupe lógicamente esas formas, lo que simplifica la gestión posterior del estilo.

**¿Puedo guardar un conjunto de estilos de forma personalizados en un archivo separado para reutilizarlos en otras presentaciones?**

Sí. Guarde formas de muestra con los estilos deseados en una presentación de plantilla o en un archivo de plantilla .POTX. Al crear una nueva presentación, abra la plantilla, clone las formas con estilo que necesite y reaplique su formato donde sea necesario.