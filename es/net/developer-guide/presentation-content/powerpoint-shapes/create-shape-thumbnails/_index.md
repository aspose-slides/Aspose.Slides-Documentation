---
title: Crear Miniaturas de Formas
type: docs
weight: 70
url: /es/net/create-shape-thumbnails/
keywords: 
- miniatura de forma
- imagen de forma
- PowerPoint
- presentación
- C#
- Csharp
- Aspose.Slides para .NET
description: "Extraer miniaturas de formas de presentaciones de PowerPoint en C# o .NET"
---

Aspose.Slides para .NET se utiliza para crear archivos de presentación donde cada página es una diapositiva. Estas diapositivas pueden ser vistas al abrir los archivos de presentación con Microsoft PowerPoint. Pero a veces, los desarrolladores pueden necesitar ver las imágenes de las formas por separado en un visor de imágenes. En tales casos, Aspose.Slides para .NET te ayuda a generar imágenes en miniatura de las formas de la diapositiva. Cómo usar esta función se describe en este artículo.  
Este artículo explica cómo generar miniaturas de diapositivas de diferentes maneras:

- Generar una miniatura de forma dentro de una diapositiva.
- Generar una miniatura de forma para una forma de diapositiva con dimensiones definidas por el usuario.
- Generar una miniatura de forma dentro de los límites de la apariencia de una forma.
- Generar una miniatura de un nodo hijo de SmartArt.


## **Generar Miniatura de Forma desde Diapositiva**
Para generar una miniatura de forma desde cualquier diapositiva utilizando Aspose.Slides para .NET:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtener la referencia de cualquier diapositiva usando su ID o índice.
1. Obtener la imagen de miniatura de la forma de la diapositiva referenciada en la escala predeterminada.
1. Guardar la imagen de miniatura en cualquier formato de imagen deseado.

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


## **Generar Miniatura con Factor de Escala Definido por el Usuario**
Para generar la miniatura de forma de cualquier forma de diapositiva utilizando Aspose.Slides para .NET:

1. Crear una instancia de la clase `Presentation`.
1. Obtener la referencia de cualquier diapositiva usando su ID o índice.
1. Obtener la imagen de miniatura de la diapositiva referenciada con límites de forma.
1. Guardar la imagen de miniatura en cualquier formato de imagen deseado.

El ejemplo a continuación genera una miniatura con un factor de escala definido por el usuario.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Escala a lo largo de los ejes X e Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```


## **Crear Miniatura de la Apariencia de los Límites de la Forma**
Este método para crear miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura de forma generada está restringida por los límites de la diapositiva. Para generar una miniatura de cualquier forma de diapositiva dentro de los límites de su apariencia, utiliza el siguiente código de ejemplo:

1. Crear una instancia de la clase `Presentation`.
1. Obtener la referencia de cualquier diapositiva usando su ID o índice.
1. Obtener la imagen de miniatura de la diapositiva referenciada con los límites de la forma como apariencia.
1. Guardar la imagen de miniatura en cualquier formato de imagen deseado.

El ejemplo a continuación crea una miniatura con un factor de escala definido por el usuario.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Escala a lo largo de los ejes X e Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```