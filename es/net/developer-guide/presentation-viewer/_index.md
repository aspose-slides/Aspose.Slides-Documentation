---
title: Crear un visor de presentaciones en C#
linktitle: Visor de presentaciones
type: docs
weight: 50
url: /es/net/presentation-viewer/
keywords:
- ver presentación
- visor de presentaciones
- crear visor de presentaciones
- ver PPT
- ver PPTX
- ver ODP
- PowerPoint
- OpenDocument
- C#
- Csharp
- Aspose.Slides for .NET
description: "Aprenda cómo crear un visor de presentaciones personalizado en .NET usando Aspose.Slides. Visualice fácilmente archivos PowerPoint (PPTX, PPT) y OpenDocument (ODP) sin Microsoft PowerPoint u otro software de oficina."
---

## **Visión general**

Aspose.Slides para .NET se utiliza para crear archivos de presentación con diapositivas. Estas diapositivas pueden verse abriendo las presentaciones en Microsoft PowerPoint, por ejemplo. Sin embargo, los desarrolladores a veces pueden necesitar ver las diapositivas como imágenes en su visor de imágenes preferido o utilizarlas en un visor de presentaciones personalizado. En esos casos, Aspose.Slides le permite exportar diapositivas individuales como imágenes. Este artículo explica cómo hacerlo.

## **Generar una imagen SVG a partir de una diapositiva**

Para generar una imagen SVG a partir de una diapositiva de una presentación usando Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenga una referencia a la diapositiva por su índice.
1. Abra un flujo de archivo.
1. Guarde la diapositiva como una imagen SVG en el flujo de archivo.
```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```


## **Generar un SVG con un ID de forma personalizado**

Aspose.Slides se puede usar para generar un [SVG](https://docs.fileformat.com/page-description-language/svg/) a partir de una diapositiva con un `ID` de forma personalizado. Para lograrlo, use la propiedad Id de la interfaz [ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape). La clase `CustomSvgShapeFormattingController` se puede usar para establecer el ID de la forma.
```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```


## **Crear una imagen miniatura de diapositiva**

Aspose.Slides le ayuda a generar imágenes en miniatura de diapositivas. Para generar una miniatura de una diapositiva usando Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenga una referencia a la diapositiva por su índice.
1. Cree una imagen en miniatura de la diapositiva referenciada con la escala deseada.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.
```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```


## **Crear una miniatura de diapositiva con dimensiones definidas por el usuario**

Para crear una imagen miniatura de diapositiva con dimensiones definidas por el usuario, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenga una referencia a la diapositiva por su índice.
1. Genere una imagen en miniatura de la diapositiva referenciada con las dimensiones especificadas.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.
```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```


## **Crear una miniatura de diapositiva con notas del presentador**

Para generar una miniatura de una diapositiva con notas del presentador usando Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la clase [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/).
1. Utilice la propiedad `RenderingOptions.SlidesLayoutOptions` para establecer la posición de las notas del presentador.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenga una referencia a la diapositiva por su índice.
1. Genere una imagen en miniatura de la diapositiva referenciada usando las opciones de renderizado.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.
```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```


## **Ejemplo en vivo**

Pruebe la aplicación gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) para ver lo que puede implementar con la API de Aspose.Slides:

[![Visor de PowerPoint en línea](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **Preguntas frecuentes**

**¿Puedo incrustar un visor de presentaciones en una aplicación web ASP.NET?**

Sí. Puede usar Aspose.Slides en el lado del servidor para renderizar diapositivas como imágenes o HTML y mostrarlas en el navegador. Las funciones de navegación y zoom pueden implementarse con JavaScript para una experiencia interactiva.

**¿Cuál es la mejor manera de mostrar diapositivas dentro de un visor .NET personalizado?**

El enfoque recomendado es renderizar cada diapositiva como una imagen (p. ej., PNG o SVG) o convertirla a HTML usando Aspose.Slides, y luego mostrar el resultado dentro de un picture box (para escritorio) o un contenedor HTML (para web).

**¿Cómo manejo presentaciones grandes con muchas diapositivas?**

Para presentaciones extensas, considere la carga diferida o el renderizado bajo demanda de las diapositivas. Esto significa generar el contenido de una diapositiva solo cuando el usuario navega a ella, reduciendo el uso de memoria y el tiempo de carga.