---
title: Convertir diapositivas de PowerPoint a PNG en Python
linktitle: PowerPoint a PNG
type: docs
weight: 30
url: /es/python-java/convert-powerpoint-to-png/
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
- Python
- Java
- Aspose.Slides
description: "Convierte diapositivas de PowerPoint a imágenes PNG en Python a través de Java. Exporta presentaciones PPT, PPTX y ODP con escalas personalizadas o dimensiones exactas de imagen."
---
## **Visión general**

Este artículo explica cómo convertir diapositivas de presentación a imágenes PNG mediante Aspose.Slides para Python a través de Java. Puede cargar presentaciones en formatos como PPT, PPTX y ODP, renderizar cada diapositiva y guardarla como una imagen PNG independiente.

Los ejemplos a continuación demuestran la renderización a escala predeterminada, el aumento de la escala, la especificación de las dimensiones de salida en píxeles y la selección de un estilo de renderizado de degradado.

## **Convertir PowerPoint a PNG**

Cargue una presentación con la clase [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) y acceda a sus diapositivas a través de la colección [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides). El ejemplo renderiza cada diapositiva con [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) sin parámetros para crear una miniatura. A continuación, llama a [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) con [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) para guardar cada diapositiva renderizada como una imagen PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}}

La sobrecarga sin parámetros de [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) renderiza a una escala de 0.2. Por ejemplo, una diapositiva de 720 × 540 puntos produce una miniatura de 144 × 108 píxeles. Para controlar las dimensiones de salida, utilice las sobrecargas con factores de escala o un tamaño de imagen explícito que se muestra a continuación.

{{% /alert %}}

## **Convertir PowerPoint a PNG con dimensiones personalizadas**

Pase factores de escala horizontal y vertical a [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) para controlar las dimensiones renderizadas. En este ejemplo, ambos factores son 2, de modo que una diapositiva de 720 × 540 puntos produce una imagen de 1440 × 1080 píxeles. Los factores de escala iguales conservan la relación de aspecto de la diapositiva. Cada imagen renderizada se guarda en formato PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Convertir PowerPoint a PNG con tamaño personalizado**

Para especificar dimensiones de salida en píxeles, pase un tamaño a [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) en lugar de los factores de escala. Este ejemplo renderiza cada diapositiva a 960 × 720 píxeles y guarda el resultado en formato PNG. Elija dimensiones que coincidan con la relación de aspecto de la diapositiva para evitar estirar la imagen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Seleccionar un estilo de renderizado de degradado**

Suponga que una diapositiva contiene rellenos degradados, pero las transiciones en el PNG exportado aparecen más claras o diferentes de lo que ve en PowerPoint. Puede usar el método [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) heredado por [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) para elegir cómo se renderizan los degradados.

Descargue [gradient-styles.pptx](gradient-styles.pptx) y colóquelo en el directorio de trabajo de la aplicación. Su primera diapositiva contiene dos degradados lineales: cian a naranja en la parte superior y azul a amarillo en la parte inferior. Cada degradado tiene dos paradas, al 0 % y al 100 %.

El siguiente ejemplo carga esta presentación y renderiza la misma primera diapositiva en ambos modos con [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

Las imágenes a continuación muestran la salida de la misma diapositiva, con ambos degradados en cada imagen:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-to-orange and blue-to-yellow gradients rendered with Default](gradient-Default.png) | ![The same gradients rendered with PowerPointUI](gradient-PowerPointUI.png) |

En este ejemplo, `Default` produce colores intermedios más claros, mientras que `PowerPointUI` produce colores intermedios más oscuros. La diferencia depende de los colores y las paradas del degradado.

Elija `Default` cuando la salida estándar de Aspose.Slides satisfaga sus necesidades. Pruebe `PowerPointUI` cuando su prioridad sea que coincida la apariencia con PowerPoint. Compare ambas salidas con el resultado deseado; ninguno de los modos es universalmente preferible.

## **FAQ**

**¿Cómo puedo exportar una forma específica, como un gráfico o una imagen, en lugar de toda la diapositiva?**

Aspose.Slides admite [generar miniaturas para formas individuales](/slides/es/python-java/create-shape-thumbnails/), lo que le permite renderizar una forma como una imagen PNG.

**¿Se admite la conversión paralela en un servidor?**

Sí. Use una instancia de presentación separada para cada subproceso o proceso; [no comparta una única instancia entre hilos](/slides/es/python-java/multithreading/).

**¿Cuáles son las limitaciones de evaluación al exportar a PNG?**

El modo de evaluación añade una marca de agua a las imágenes de salida y aplica [otras restricciones](/slides/es/python-java/licensing/) hasta que se aplique una licencia.