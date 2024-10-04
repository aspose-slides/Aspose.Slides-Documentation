---
title: Formato de Forma
type: docs
weight: 20
url: /net/shape-formatting/
keywords:
- formato de forma
- formato de líneas
- formato de estilos de unión
- relleno de degradado
- relleno de patrón
- relleno de imagen
- relleno de color sólido
- rotar formas
- efectos de bisel 3D
- efecto de rotación 3D
- presentación de PowerPoint
- C#
- Csharp
- Aspose.Slides para .NET
description: "Formatear forma en presentación de PowerPoint en C# o .NET"
---

En PowerPoint, puedes agregar formas a las diapositivas. Dado que las formas están compuestas de líneas, puedes formatear formas modificando o aplicando ciertos efectos a sus líneas constituyentes. Además, puedes formatear formas especificando configuraciones que determinan cómo se rellenan (el área en ellas).

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides para .NET** proporciona interfaces y propiedades que te permiten formatear formas según opciones conocidas en PowerPoint.

## **Formato de Líneas**

Usando Aspose.Slides, puedes especificar tu estilo de línea preferido para una forma. Estos pasos describen un procedimiento así:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) a la diapositiva.
4. Establece un color para las líneas de la forma.
5. Establece el ancho para las líneas de la forma.
6. Establece el [estilo de línea](https://reference.aspose.com/slides/net/aspose.slides/linestyle) para la línea de la forma.
7. Establece el [estilo de guiones](http://aspose.com/api/net/slides/aspose.slides/linedashstyle) para la línea de la forma.
8. Escribe la presentación modificada como un archivo PPTX.

Este código C# demuestra una operación donde formateamos un rectángulo `AutoShape`:

```c#
// Instancia una clase de presentación que representa un archivo de presentación
using (Presentation pres = new Presentation())
{
    // Obtiene la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Agrega una autoshape de tipo rectángulo
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Establece el color de relleno para la forma rectángulo
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.White;

    // Aplica algún formato a las líneas del rectángulo
    shp.LineFormat.Style = LineStyle.ThickThin;
    shp.LineFormat.Width = 7;
    shp.LineFormat.DashStyle = LineDashStyle.Dash;

    // Establece el color para la línea del rectángulo
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Escribe el archivo PPTX en disco
    pres.Save("RectShpLn_out.pptx", SaveFormat.Pptx);
}
```

## **Formato de Estilos de Unión**
Estas son las 3 opciones de tipo de unión:

* Redondo
* Miter
* Bisel

Por defecto, cuando PowerPoint une dos líneas en un ángulo (o en la esquina de una forma), utiliza la configuración **Redondo**. Sin embargo, si buscas dibujar una forma con ángulos muy agudos, puedes seleccionar **Miter**.

![join-style-powerpoint](join-style-powerpoint.png)

Este C# demuestra una operación donde se crearon 3 rectángulos (la imagen de arriba) con las configuraciones de tipo de unión Miter, Bisel y Redondo:

```c#
// Instancia una clase de presentación que representa un archivo de presentación
using (Presentation pres = new Presentation())
{

	// Obtiene la primera diapositiva
	ISlide sld = pres.Slides[0];

	// Agrega 3 autoshapes de rectángulo
	IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
	IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
	IShape shp3 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

	// Establece el color de relleno para la forma rectángulo
	shp1.FillFormat.FillType = FillType.Solid;
	shp1.FillFormat.SolidFillColor.Color = Color.Black;
	shp2.FillFormat.FillType = FillType.Solid;
	shp2.FillFormat.SolidFillColor.Color = Color.Black;
	shp3.FillFormat.FillType = FillType.Solid;
	shp3.FillFormat.SolidFillColor.Color = Color.Black;

	// Establece el ancho de la línea
	shp1.LineFormat.Width = 15;
	shp2.LineFormat.Width = 15;
	shp3.LineFormat.Width = 15;

	// Establece el color para la línea del rectángulo
	shp1.LineFormat.FillFormat.FillType = FillType.Solid;
	shp1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
	shp2.LineFormat.FillFormat.FillType = FillType.Solid;
	shp2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
	shp3.LineFormat.FillFormat.FillType = FillType.Solid;
	shp3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	// Establece el Estilo de Unión
	shp1.LineFormat.JoinStyle = LineJoinStyle.Miter;
	shp2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
	shp3.LineFormat.JoinStyle = LineJoinStyle.Round;

	// Agrega texto a cada rectángulo
	((IAutoShape)shp1).TextFrame.Text = "Estilo de Unión Miter";
	((IAutoShape)shp2).TextFrame.Text = "Estilo de Unión Bisel";
	((IAutoShape)shp3).TextFrame.Text = "Estilo de Unión Redondo";

	// Escribe el archivo PPTX en disco
	pres.Save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
}
```

## **Relleno de Degradado**
En PowerPoint, el Relleno de Degradado es una opción de formato que permite aplicar una mezcla continua de colores a una forma. Por ejemplo, puedes aplicar dos o más colores en una configuración donde un color se desvanede gradualmente y cambia a otro color.

Así es como usas Aspose.Slides para aplicar un relleno de degradado a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) de la forma a `Gradient`.
5. Agrega tus 2 colores preferidos con posiciones definidas usando los métodos `Add` expuestos por la colección `GradientStops` asociada con la clase `GradientFormat`.
6. Escribe la presentación modificada como un archivo PPTX.

Este código C# demuestra una operación donde se utilizó el efecto de relleno de degradado en una elipse:

```c#
// Instancia una clase de presentación que representa un archivo de presentación
using (Presentation pres = new Presentation())
{
    // Obtiene la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Agrega una autoshape de elipse
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // Aplica el formato de degradado a la elipse
    shp.FillFormat.FillType = FillType.Gradient;
    shp.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Establece la dirección del degradado
    shp.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Agrega 2 puntos de degradado
    shp.FillFormat.GradientFormat.GradientStops.Add((float)1.0, PresetColor.Purple);
    shp.FillFormat.GradientFormat.GradientStops.Add((float)0, PresetColor.Red);

    // Escribe el archivo PPTX en disco
    pres.Save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
}
```

## **Relleno de Patrón**
En PowerPoint, el Relleno de Patrón es una opción de formato que te permite aplicar un diseño de dos colores que consta de puntos, rayas, tramas cruzadas o cuadros a una forma. Además, puedes seleccionar tus colores preferidos para el primer plano y el fondo de tu patrón.

Aspose.Slides proporciona más de 45 estilos predefinidos que se pueden usar para formatear formas y enriquecer presentaciones. Incluso después de elegir un patrón predefinido, aún puedes especificar los colores que el patrón debe contener.

Así es como usas Aspose.Slides para aplicar un relleno de patrón a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) de la forma a `Pattern`.
5. Establece tu estilo de patrón preferido para la forma.
6. Establece el [Color de Fondo](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/backcolor) para el [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat).
7. Establece el [Color de Primer Plano](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/forecolor) para el [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat).
8. Escribe la presentación modificada como un archivo PPTX.

Este código C# demuestra una operación donde se utilizó un relleno de patrón para embellecer un rectángulo:

```c#
// Instancia una clase de presentación que representa un archivo de presentación
using (Presentation pres = new Presentation())
{

    // Obtiene la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Agrega una autoshape de rectángulo
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Establece el tipo de relleno a Patrón
    shp.FillFormat.FillType = FillType.Pattern;

    // Establece el estilo de patrón
    shp.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Establece los colores de patrón de fondo y primer plano
    shp.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shp.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Escribe el archivo PPTX en disco
    pres.Save("RectShpPatt_out.pptx", SaveFormat.Pptx);
}
```

## **Relleno de Imagen**
En PowerPoint, el Relleno de Imagen es una opción de formato que te permite colocar una imagen dentro de una forma. Esencialmente, puedes usar una imagen como fondo de la forma.

Así es como usas Aspose.Slides para rellenar una forma con una imagen:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) de la forma a `Picture`.
5. Establece el modo de relleno de imagen a Tile.
6. Crea un objeto `IPPImage` usando la imagen que se usará para rellenar la forma.
7. Establece la propiedad `Picture.Image` del objeto `PictureFillFormat` al `IPPImage` creado recientemente.
8. Escribe la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo rellenar una forma con una imagen:

```c#
// Instancia la clase Presentation que representa un archivo de presentación
using (Presentation presentation = new Presentation())
{
    // Obtiene la primera diapositiva
    ISlide slide = presentation.Slides[0];

    // Agrega una autoshape de rectángulo
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Establece el tipo de relleno a Imagen
    shape.FillFormat.FillType = FillType.Picture;

    // Establece el modo de relleno de imagen
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Carga una imagen y la agrega a los recursos de la presentación
    IImage image = Images.FromFile("Tulips.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Establece la imagen
    shape.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Escribe el archivo PPTX en disco
    presentation.Save("RectShpPic_out.pptx", SaveFormat.Pptx);
}
```

## **Relleno de Color Sólido**
En PowerPoint, el Relleno de Color Sólido es una opción de formato que permite llenar una forma con un solo color. El color elegido es típicamente un color plano. El color se aplica a la forma de fondo con cualquier efecto o modificación especial.

Así es como usas Aspose.Slides para aplicar un relleno de color sólido a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) de la forma a `Solid`.
5. Establece tu color preferido para la forma.
6. Escribe la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo aplicar el relleno de color sólido a un cuadro en PowerPoint:

```c#
// Instancia una clase de presentación que representa un archivo de presentación
using (Presentation presentation = new Presentation())
{

// Obtiene la primera diapositiva
    ISlide slide = presentation.Slides[0];

// Agrega una autoshape de rectángulo
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

// Establece el tipo de relleno a Sólido
    shape.FillFormat.FillType = FillType.Solid;

// Establece el color para el rectángulo
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

// Escribe el archivo PPTX en disco
    presentation.Save("RectShpSolid_out.pptx", SaveFormat.Pptx);
}
```

## **Establecer Transparencia**

En PowerPoint, cuando rellenas formas con colores sólidos, degradados, imágenes o texturas, puedes especificar el nivel de transparencia que determina la opacidad de un relleno. De este modo, por ejemplo, si estableces un nivel de transparencia bajo, el objeto de diapositiva o fondo detrás (de la forma) se muestra a través.

Aspose.Slides te permite establecer el nivel de transparencia para una forma de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) a la diapositiva.
4. Usa `Color.FromArgb` con el componente alfa establecido.
5. Guarda el objeto como un archivo de PowerPoint.

Este código C# demuestra el proceso:

```c#
// Instancia una clase de presentación que representa un archivo de presentación
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // Agrega una forma sólida
    IShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // Agrega una forma transparente sobre la forma sólida
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 204, 102, 0);
    
    // Escribe el archivo PPTX en disco
    presentation.Save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
}
```

## **Rotar Formas**
Aspose.Slides te permite rotar una forma agregada a una diapositiva de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) a la diapositiva.
4. Rota la forma por los grados necesarios.
5. Escribe la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo rotar una forma 90 grados:

```c#
// Instancia una clase de presentación que representa un archivo de presentación
using (Presentation pres = new Presentation())
{
    // Obtiene la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Agrega una autoshape de rectángulo
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Rota la forma 90 grados
    shp.Rotation = 90;

    // Escribe el archivo PPTX en disco
    pres.Save("RectShpRot_out.pptx", SaveFormat.Pptx);
}
```

## **Agregar Efectos de Bisel 3D**
Aspose.Slides te permite agregar efectos de bisel 3D a una forma modificando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) a la diapositiva.
4. Establece tus parámetros preferidos para las propiedades [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) de la forma.
5. Escribe la presentación en disco.

Este código C# te muestra cómo agregar efectos de bisel 3D a una forma:

```c#
// Crea una instancia de la clase Presentation
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    
    // Agrega una forma a la diapositiva
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    ILineFillFormat format = shape.LineFormat.FillFormat;
    format.FillType = FillType.Solid;
    format.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;
    
    // Establece las propiedades ThreeDFormat de la forma
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    
    // Escribe la presentación como un archivo PPTX
    pres.Save("Bavel_out.pptx", SaveFormat.Pptx);
}
```

## **Agregar Efecto de Rotación 3D**
Aspose.Slides te permite aplicar efectos de rotación 3D a una forma modificando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) a la diapositiva.
4. Especifica tus figuras preferidas para [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/properties/cameratype) y [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/properties/lighttype).
5. Escribe la presentación en disco.

Este código C# te muestra cómo aplicar efectos de rotación 3D a una forma:

```c#
// Crea una instancia de la clase Presentation
using (Presentation pres = new Presentation())
{
    IShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);
    
    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    
    autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Line, 30, 300, 200, 200);
    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(0, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    
    // Escribe la presentación como un archivo PPTX
    pres.Save("Rotation_out.pptx", SaveFormat.Pptx);
}
```

## **Restablecer Formato**

Este código C# te muestra cómo restablecer el formato en una diapositiva y revertir la posición, tamaño y formato de cada forma que tiene un marcador de posición en [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) a sus valores predeterminados:

```c#
using (Presentation pres = new Presentation())
{
    foreach (ISlide slide in pres.Slides)
    {
        // cada forma en la diapositiva que tiene un marcador de posición en el diseño será revertida
        slide.Reset();
    }
}
```