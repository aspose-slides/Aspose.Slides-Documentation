---
title: Convertir diapositivas de PowerPoint a PNG en .NET
linktitle: PowerPoint a PNG
type: docs
weight: 30
url: /es/net/convert-powerpoint-to-png/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a PNG
- presentación a PNG
- diapositiva a PNG
- PPT a PNG
- PPTX a PNG
- guardar PPT como PNG
- guardar PPTX como PNG
- exportar PPT a PNG
- exportar PPTX a PNG
- .NET
- C#
- Aspose.Slides
description: "Convierta presentaciones de PowerPoint a imágenes PNG de alta calidad rápidamente con Aspose.Slides para .NET, garantizando resultados precisos y automatizados."
---
## **Descripción general**

Este artículo explica cómo convertir diapositivas de presentaciones a imágenes PNG usando Aspose.Slides para .NET. Puede cargar presentaciones en formatos como PPT, PPTX y ODP, renderizar cada diapositiva y guardarla como una imagen PNG independiente.

Los ejemplos a continuación demuestran cómo renderizar miniaturas, establecer factores de escala, especificar las dimensiones de salida en píxeles y elegir un estilo de renderizado de degradado.

## **Convertir PowerPoint a PNG**

Cargue una presentación con la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y acceda a sus diapositivas mediante la colección [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). El ejemplo renderiza cada diapositiva con [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) sin parámetros para crear una miniatura. Luego llama a [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) con [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) para guardar cada diapositiva renderizada como una imagen PNG.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
La sobrecarga sin parámetros de [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) renderiza a una escala de 0.2. Por ejemplo, una diapositiva de 720 × 540 puntos produce una miniatura de 144 × 108 píxeles. Para controlar las dimensiones de salida, use las sobrecargas con factores de escala o un tamaño de imagen explícito que se muestra a continuación.
{{% /alert %}}

## **Convertir PowerPoint a PNG con dimensiones personalizadas**

Pase factores de escala horizontales y verticales a [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) para controlar las dimensiones renderizadas. En este ejemplo, ambos factores son 2, por lo que una diapositiva de 720 × 540 puntos produce una imagen de 1440 × 1080 píxeles. Los factores de escala iguales conservan la relación de aspecto de la diapositiva. Cada imagen se guarda en formato PNG con [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Convertir PowerPoint a PNG con tamaño personalizado**

Para especificar las dimensiones de salida en píxeles, pase un tamaño a [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) en lugar de factores de escala. Este ejemplo renderiza cada diapositiva a 960 × 720 píxeles y guarda el resultado con [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Elija dimensiones que coincidan con la relación de aspecto de la diapositiva para evitar estirar la imagen.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Elegir un estilo de renderizado de degradado**

Suponga que una diapositiva contiene rellenos con degradado, pero las transiciones en el PNG exportado aparecen más claras o diferentes de lo que ve en PowerPoint. Puede usar la propiedad [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) de [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) para elegir cómo se renderizan los degradados.

Descargue [gradient-styles.pptx](gradient-styles.pptx) y colóquelo en el directorio de trabajo de la aplicación. Su primera diapositiva contiene dos degradados lineales: cian a naranja en la parte superior y azul a amarillo en la parte inferior. Cada degradado tiene dos paradas, al 0 % y al 100 %.

El siguiente ejemplo carga esta presentación y renderiza la misma primera diapositiva en ambos modos con [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

Las imágenes a continuación muestran la salida de la misma diapositiva, con ambos degradados en cada imagen:

| Predeterminado | PowerPointUI |
| --- | --- |
| ![Degradados de cian a naranja y de azul a amarillo renderizados con Predeterminado](gradient-Default.png) | ![Los mismos degradados renderizados con PowerPointUI](gradient-PowerPointUI.png) |

En este ejemplo, `Predeterminado` produce colores intermedios más claros, mientras que `PowerPointUI` produce colores intermedios más oscuros. La diferencia depende de los colores y de las paradas del degradado.

Elija `Predeterminado` cuando la salida estándar de Aspose.Slides se ajuste a sus necesidades. Pruebe `PowerPointUI` cuando su prioridad sea que coincida la apariencia con PowerPoint. Compare ambas salidas con el resultado deseado; ningún modo es universalmente preferible.

## **Preguntas frecuentes**

**¿Cómo puedo exportar una forma específica, como un gráfico o una imagen, en lugar de toda la diapositiva?**

Aspose.Slides admite [generar miniaturas para formas individuales](/slides/es/net/create-shape-thumbnails/), lo que le permite renderizar una forma como una imagen PNG.

**¿Se admite la conversión paralela en un servidor?**

Sí. Utilice una instancia de presentación separada para cada hilo o proceso; [no comparta una única instancia entre hilos](/slides/es/net/multithreading/).

**¿Cuáles son las limitaciones de evaluación al exportar a PNG?**

El modo de evaluación añade una marca de agua a las imágenes de salida y aplica [otras restricciones](/slides/es/net/licensing/) hasta que se aplique una licencia.