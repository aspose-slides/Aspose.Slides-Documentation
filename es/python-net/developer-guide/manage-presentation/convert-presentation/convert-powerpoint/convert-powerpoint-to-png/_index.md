---
title: Convertir diapositivas de PowerPoint a PNG en Python
linktitle: Diapositiva a PNG
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
description: "Convierta presentaciones de PowerPoint y OpenDocument a imágenes PNG de alta calidad rápidamente con Aspose.Slides para Python a través de .NET, garantizando resultados precisos y automatizados."
---

## **Visión general**

Aspose.Slides for Python via .NET facilita la conversión de presentaciones de PowerPoint a PNG. Carga una presentación, recorre sus diapositivas, renderiza cada una a una imagen rasterizada y guarda el resultado como archivos PNG. Esto es ideal para generar vistas previas de diapositivas, incrustar diapositivas en páginas web o crear activos estáticos para procesamiento posterior.

## **Convertir diapositivas a PNG**

Esta sección muestra el ejemplo más simple posible de conversión de una presentación de PowerPoint a imágenes PNG usando Aspose.Slides for Python via .NET.

Siga estos pasos:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener una diapositiva de la colección `Presentation.slides` (ver la clase [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/)).
3. Utilizar el método `Slide.get_image` para generar una miniatura de la diapositiva.
4. Utilizar el método `Presentation.save` para guardar la miniatura de la diapositiva en formato PNG.

Este código Python muestra cómo convertir una presentación de PowerPoint a PNG:
```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


## **Convertir diapositivas a PNG con dimensiones personalizadas**

Para exportar diapositivas a PNG con una escala personalizada, llame a `Slide.get_image` con factores de escala horizontal y vertical. Estos multiplicadores redimensionan la salida respecto a las dimensiones originales de la diapositiva; por ejemplo, `2.0` duplica tanto el ancho como la altura. Use valores iguales para `scale_x` y `scale_y` para preservar la relación de aspecto.

Este código Python demuestra la operación descrita:
```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


## **Convertir diapositivas a PNG con tamaño personalizado**

Si desea generar archivos PNG con un tamaño específico, proporcione los valores deseados de `width` y `height`. El código a continuación muestra cómo convertir un PowerPoint a PNG especificando el tamaño de la imagen: 
```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


{{% alert title="Tip" color="primary" %}}
Puede que desee probar los conversores gratuitos de **PowerPoint a PNG** de Aspose—[PPTX a PNG](https://products.aspose.app/slides/conversion/pptx-to-png) y [PPT a PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Proporcionan una implementación en vivo del proceso descrito en esta página.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cómo puedo exportar solo una forma específica (p. ej., un gráfico o una imagen) en lugar de toda la diapositiva?**

Aspose.Slides admite [generar miniaturas para formas individuales](/slides/es/python-net/create-shape-thumbnails/); puede renderizar una forma a una imagen PNG.

**¿Se admite la conversión paralela en un servidor?**

Sí, pero [no comparta](/slides/es/python-net/multithreading/) una única instancia de presentación entre hilos. Use una instancia separada por hilo o proceso.

**¿Cuáles son las limitaciones de la versión de prueba al exportar a PNG?**

El modo de evaluación agrega una marca de agua a las imágenes de salida y aplica [otras restricciones](/slides/es/python-net/licensing/) hasta que se aplique una licencia.