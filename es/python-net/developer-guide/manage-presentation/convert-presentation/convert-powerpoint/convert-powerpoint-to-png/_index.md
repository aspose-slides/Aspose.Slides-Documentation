---
title: Convertir diapositivas de PowerPoint a PNG en Python
linktitle: PowerPoint a PNG
type: docs
weight: 30
url: /es/python-net/convert-powerpoint-to-png/
keywords:
- convertir PowerPoint a PNG
- convertir presentación a PNG
- convertir diapositiva a PNG
- convertir PPT a PNG
- convertir PPTX a PNG
- convertir ODP a PNG
- PowerPoint a PNG
- presentación a PNG
- diapositiva a PNG
- PPT a PNG
- PPTX a PNG
- ODP a PNG
- Python
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint y OpenDocument a imágenes PNG de alta calidad rápidamente con Aspose.Slides para Python a través de .NET, garantizando resultados precisos y automatizados."
---
## **Visión general**

Este artículo explica cómo convertir diapositivas de presentación a imágenes PNG usando Aspose.Slides para Python a través de .NET. Puede cargar presentaciones en formatos como PPT, PPTX y ODP, renderizar cada diapositiva y guardarla como una imagen PNG independiente.

Los ejemplos a continuación demuestran la renderización a escala predeterminada, el aumento de la escala, la especificación de las dimensiones de salida en píxeles y la elección de un estilo de renderizado de degradado.

## **Convertir PowerPoint a PNG**

Cargue una presentación con la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y acceda a sus diapositivas a través de la colección [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/). El ejemplo renderiza cada diapositiva con [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) sin parámetros para crear una miniatura. A continuación llama a [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) con [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) para guardar cada diapositiva renderizada como una imagen PNG.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
La sobrecarga sin parámetros de [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) renderiza a una escala de 0.2. Por ejemplo, una diapositiva que mide 720 × 540 puntos produce una miniatura de 144 × 108 píxeles. Para controlar las dimensiones de salida, utilice las sobrecargas con factores de escala o un tamaño de imagen explícito que se muestra a continuación.
{{% /alert %}}

## **Convertir PowerPoint a PNG con dimensiones personalizadas**

Pase factores de escala horizontal y vertical a [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) para controlar las dimensiones renderizadas. En este ejemplo, ambos factores son 2, por lo que una diapositiva que mide 720 × 540 puntos produce una imagen de 1440 × 1080 píxeles. Los factores de escala iguales conservan la relación de aspecto de la diapositiva. Cada imagen se guarda en formato PNG con [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/).

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Convertir PowerPoint a PNG con tamaño personalizado**

Para especificar las dimensiones de salida en píxeles, pase un tamaño a [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) en lugar de factores de escala. Este ejemplo renderiza cada diapositiva a 960 × 720 píxeles y guarda el resultado con [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Elija dimensiones que coincidan con la relación de aspecto de la diapositiva para evitar que la imagen se deforme.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Elegir un estilo de renderizado de degradado**

Supongamos que una diapositiva contiene rellenos de degradado, pero las transiciones en el PNG exportado aparecen más claras o diferentes de lo que se ve en PowerPoint. Puede usar la propiedad [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) de [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) para elegir cómo se renderizan los degradados.

Descargue [gradient-styles.pptx](gradient-styles.pptx) y colóquelo en el directorio de trabajo de la aplicación. Su primera diapositiva contiene dos degradados lineales: de cian a naranja en la parte superior y de azul a amarillo en la parte inferior. Cada degradado tiene dos paradas, al 0 % y al 100 %.

El siguiente ejemplo carga esta presentación y renderiza la misma primera diapositiva en ambos modos con [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/).

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

Las imágenes siguientes muestran la salida de la misma diapositiva, con ambos degradados en cada imagen:

| Predeterminado | PowerPointUI |
| --- | --- |
| ![Degradados de cian a naranja y de azul a amarillo renderizados con Predeterminado](gradient-Default.png) | ![Los mismos degradados renderizados con PowerPointUI](gradient-PowerPointUI.png) |

En este ejemplo, `DEFAULT` produce colores intermedios más claros, mientras que `POWER_POINT_UI` produce colores intermedios más oscuros. La diferencia depende de los colores y de las paradas del degradado.

Elija `DEFAULT` cuando la salida estándar de Aspose.Slides se ajuste a sus necesidades. Pruebe `POWER_POINT_UI` cuando su prioridad sea que la apariencia coincida con la de PowerPoint. Compare ambas salidas con el resultado que desea; ninguno de los modos es universalmente preferible.

## **Preguntas frecuentes**

**¿Cómo puedo exportar una forma específica, como un gráfico o una imagen, en lugar de toda la diapositiva?**

Aspose.Slides admite [generar miniaturas para formas individuales](/slides/es/python-net/create-shape-thumbnails/), lo que le permite renderizar una forma como una imagen PNG.

**¿Se admite la conversión paralela en un servidor?**

Sí. Utilice una instancia de presentación separada para cada hilo o proceso; [no comparta una única instancia entre hilos](/slides/es/python-net/multithreading/).

**¿Cuáles son las limitaciones de la versión de evaluación al exportar a PNG?**

El modo de evaluación añade una marca de agua a las imágenes de salida y aplica [otras restricciones](/slides/es/python-net/licensing/) hasta que se aplique una licencia.