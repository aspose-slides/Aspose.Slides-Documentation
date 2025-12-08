---
title: Crear miniaturas de formas
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
- Aspose.Slides for .NET
description: "Extraiga miniaturas de formas de presentaciones PowerPoint en C# o .NET"
---

Aspose.Slides for .NET se utiliza para crear archivos de presentación donde cada página es una diapositiva. Estas diapositivas pueden verse abriendo los archivos de presentación con Microsoft PowerPoint. Pero a veces, los desarrolladores pueden necesitar ver las imágenes de las formas por separado en un visor de imágenes. En esos casos, Aspose.Slides for .NET le ayuda a generar imágenes en miniatura de las formas de la diapositiva. Cómo usar esta función se describe en este artículo.  
Este artículo explica cómo generar miniaturas de diapositivas de diferentes maneras:

- Generar una miniatura de una forma dentro de una diapositiva.  
- Generar una miniatura de una forma para una forma de diapositiva con dimensiones definidas por el usuario.  
- Generar una miniatura de una forma dentro de los límites de la apariencia de la forma.  
- Generar una miniatura del nodo hijo de SmartArt.  


## **Generar miniatura de forma desde la diapositiva**
Para generar una miniatura de forma de cualquier diapositiva usando Aspose.Slides for .NET:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
1. Obtenga la referencia de cualquier diapositiva mediante su ID o índice.  
1. Obtenga la imagen en miniatura de la forma de la diapositiva referenciada con la escala predeterminada.  
1. Guarde la imagen en miniatura en el formato de imagen deseado.  

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



## **Generar miniatura con factor de escala definido por el usuario**
Para generar la miniatura de una forma de cualquier forma de diapositiva usando Aspose.Slides for .NET:

1. Cree una instancia de la clase `Presentation`.  
1. Obtenga la referencia de cualquier diapositiva mediante su ID o índice.  
1. Obtenga la imagen en miniatura de la diapositiva referenciada con los límites de la forma.  
1. Guarde la imagen en miniatura en el formato de imagen deseado.  

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



## **Crear miniatura de la apariencia de la forma dentro de sus límites**
Este método para crear miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura de la forma generada está limitada por los bordes de la diapositiva. Para generar una miniatura de cualquier forma de diapositiva dentro de los límites de su apariencia, utilice el siguiente código de ejemplo:

1. Cree una instancia de la clase `Presentation`.  
1. Obtenga la referencia de cualquier diapositiva mediante su ID o índice.  
1. Obtenga la imagen en miniatura de la diapositiva referenciada con los límites de la forma como apariencia.  
1. Guarde la imagen en miniatura en el formato de imagen deseado.  

El ejemplo a continuación crea una miniatura con un factor de escala definido por el usuario.  
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


## **FAQ**

**¿Qué formatos de imagen se pueden usar al guardar miniaturas de formas?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), y otros. Las formas también pueden ser [exportadas como SVG vectorial](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) guardando el contenido de la forma como SVG.

**¿Cuál es la diferencia entre los límites de Shape y Appearance al renderizar una miniatura?**

`Shape` utiliza la geometría de la forma; `Appearance` tiene en cuenta los [efectos visuales](/slides/es/net/shape-effect/) (sombras, brillos, etc.).

**¿Qué ocurre si una forma está marcada como oculta? ¿Se seguirá renderizando como miniatura?**

Una forma oculta sigue formando parte del modelo y puede renderizarse; la bandera de oculto afecta la presentación de diapositivas pero no impide generar la imagen de la forma.

**¿Se admiten formas agrupadas, gráficos, SmartArt y otros objetos complejos?**

Sí. Cualquier objeto representado como [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) (incluidos [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), y [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) puede guardarse como miniatura o como SVG.

**¿Las fuentes instaladas en el sistema afectan la calidad de las miniaturas de formas de texto?**

Sí. Debe [proporcionar las fuentes necesarias](/slides/es/net/custom-font/) (o [configurar sustituciones de fuentes](/slides/es/net/font-substitution/)) para evitar sustituciones no deseadas y reflujo de texto.