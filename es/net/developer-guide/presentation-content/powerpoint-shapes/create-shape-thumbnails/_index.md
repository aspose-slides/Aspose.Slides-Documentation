---
title: Crear miniaturas de formas de presentación en .NET
linktitle: Miniaturas de formas
type: docs
weight: 70
url: /es/net/create-shape-thumbnails/
keywords:
- miniatura de forma
- imagen de forma
- renderizar forma
- renderizado de forma
- límites visuales
- límites de forma
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Genere miniaturas de forma de alta calidad a partir de diapositivas de PowerPoint con Aspose.Slides para .NET – cree y exporte fácilmente miniaturas de presentaciones."
---
## **Introducción**

Aspose.Slides for .NET se utiliza para crear archivos de presentación donde cada página es una diapositiva. Estas diapositivas pueden verse abriendo los archivos de presentación con Microsoft PowerPoint. Pero a veces, los desarrolladores pueden necesitar ver las imágenes de las formas por separado en un visor de imágenes. En esos casos, Aspose.Slides for .NET le ayuda a generar imágenes en miniatura de las formas de la diapositiva. Cómo usar esta característica se describe en este artículo.  
Este artículo explica cómo generar miniaturas de diapositivas de diferentes maneras:

- Generar una miniatura de una forma dentro de una diapositiva.  
- Generar una miniatura de una forma para una forma de diapositiva con dimensiones definidas por el usuario.  
- Generar una miniatura de una forma dentro de los límites de la apariencia de la forma.

## **Generar una miniatura de forma a partir de una diapositiva**
Para generar una miniatura de forma a partir de cualquier diapositiva usando Aspose.Slides for .NET:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. Obtenga la imagen en miniatura de la forma de la diapositiva referenciada con la escala predeterminada.
1. Guarde la imagen en miniatura en el formato de imagen que desee.

El ejemplo a continuación genera una miniatura de forma.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Generar una miniatura con factor de escala definido por el usuario**
Para generar la miniatura de forma de cualquier forma de diapositiva usando Aspose.Slides for .NET:

1. Cree una instancia de la clase `Presentation`.
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con los límites de la forma.
1. Guarde la imagen en miniatura en el formato de imagen que desee.

El ejemplo a continuación genera una miniatura con un factor de escala definido por el usuario.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Escalado en los ejes X e Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Crear una miniatura de forma basada en los límites de la apariencia**
Este método para crear miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura de la forma generada está restringida por los límites de la diapositiva. Para generar una miniatura de cualquier forma de diapositiva dentro de los límites de su apariencia, utilice el siguiente código de ejemplo:

1. Cree una instancia de la clase `Presentation`.
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con los límites de la forma como apariencia.
1. Guarde la imagen en miniatura en el formato de imagen que desee.

El ejemplo a continuación crea una miniatura generando una miniatura con factor de escala definido por el usuario.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Escalado en los ejes X e Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **Obtener los límites visuales reales de una forma**

Las propiedades del marco de [IShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/) — sus propiedades `X`, `Y`, `Width` y `Height` — describen el rectángulo almacenado en el modelo de la presentación. El contenido que realmente se renderiza puede extenderse más allá de ese marco o ocupar un rectángulo alineado con los ejes diferente. La rotación, los contornos, las puntas de flecha, el diseño y desbordamiento del texto, la geometría generada de SmartArt y otros efectos de renderizado pueden modificar el área ocupada.  
Utilice [GetVisualBounds](https://reference.aspose.com/slides/es/net/aspose.slides/shape/getvisualbounds/) para calcular esa zona ocupada sin crear una imagen. El método devuelve un [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) en coordenadas de diapositiva. El rectángulo devuelto no está recortado a la diapositiva, por lo que sus coordenadas pueden ser negativas cuando el contenido se extiende más allá del origen de la diapositiva.  
[GetVisualBounds](https://reference.aspose.com/slides/es/net/aspose.slides/shape/getvisualbounds/) no está declarada actualmente en la interfaz [IShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/). Por lo tanto, conserve la forma obtenida de la colección de formas de la diapositiva como un valor de interfaz y conviértala (cast) sólo al llamar al método.  
El siguiente ejemplo obtiene y compara los límites del marco y los visuales:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

La misma [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) puede usarse para alinear formas cercanas a su borde `Left`, `Right`, `Top` o `Bottom`; reservar suficiente espacio en un diseño generado; o detectar contenido fuera de una región permitida. Los límites visuales son especialmente útiles para SmartArt, cuadros de texto, flechas, imágenes, formas giradas y grupos de formas, donde el marco almacenado puede no representar el resultado renderizado completo.  
Utilice [GetVisualBounds](https://reference.aspose.com/slides/es/net/aspose.slides/shape/getvisualbounds/) cuando necesite coordenadas para el diseño o la validación y no necesite un bitmap. Utilice [IShape.GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/getimage/) cuando necesite renderizar la forma. Con [ShapeThumbnailBounds](https://reference.aspose.com/slides/es/net/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` dimensiona la imagen a partir de los límites de la forma, incluyendo la configuración del contorno, mientras que `ShapeThumbnailBounds.Appearance` la dimensiona a partir de la apariencia de la forma y restringe el resultado a los límites de la diapositiva. En contraste, [GetVisualBounds](https://reference.aspose.com/slides/es/net/aspose.slides/shape/getvisualbounds/) solo devuelve el rectángulo calculado y no lo recorta a la diapositiva.

## **FAQ**

**¿Qué formatos de imagen se pueden usar al guardar miniaturas de formas?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/es/net/aspose.slides/imageformat/), y otros. Las formas también pueden ser [exportadas como SVG vectorial](https://reference.aspose.com/slides/es/net/aspose.slides/shape/writeassvg/) guardando el contenido de la forma como SVG.

**¿Cuál es la diferencia entre los límites Shape y Appearance al renderizar una miniatura?**  
`Shape` utiliza la geometría de la forma; `Appearance` tiene en cuenta los [efectos visuales](/slides/es/net/shape-effect/) (sombras, brillos, etc.).

**¿Qué ocurre si una forma está marcada como oculta? ¿Se seguirá renderizando como miniatura?**  
Una forma oculta sigue formando parte del modelo y puede renderizarse; la marca oculta afecta la visualización en la presentación pero no impide generar la imagen de la forma.

**¿Se admiten formas agrupadas, gráficos, SmartArt y otros objetos complejos?**  
Sí. Cualquier objeto representado como [Shape](https://reference.aspose.com/slides/es/net/aspose.slides/shape/) (incluyendo [GroupShape](https://reference.aspose.com/slides/es/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/es/net/aspose.slides.charts/chart/), y [SmartArt](https://reference.aspose.com/slides/es/net/aspose.slides.smartart/smartart/)) puede guardarse como una miniatura o como SVG.

**¿Afectan las fuentes instaladas en el sistema a la calidad de las miniaturas de formas de texto?**  
Sí. Debe [proporcionar las fuentes necesarias](/slides/es/net/custom-font/) (o [configurar sustituciones de fuentes](/slides/es/net/font-substitution/)) para evitar sustituciones no deseadas y reflujo de texto.