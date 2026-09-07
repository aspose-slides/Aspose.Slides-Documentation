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
description: "Convertir diapositivas de PowerPoint a imágenes PNG en Python mediante Java. Exportar presentaciones PPT, PPTX y ODP con escalas personalizadas o dimensiones de imagen exactas."
---
## **Visión general**

Este artículo explica cómo convertir presentaciones de PowerPoint a imágenes PNG usando Aspose.Slides for Python via Java. Puedes cargar archivos PPT, PPTX y ODP, renderizar cada diapositiva y guardarla como una imagen PNG independiente.

Los ejemplos también muestran cómo controlar las dimensiones de salida con factores de escala o con un ancho y alto exactos. Cada ejemplo inicia la máquina virtual Java si es necesario y libera los recursos de la presentación y de la imagen después de usarlos.

## **Convertir PowerPoint a PNG**

1. Carga el archivo de entrada con la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Obtén las diapositivas mediante [Presentation.getSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSlides).
3. Renderiza cada diapositiva usando [Slide.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage).
4. Guarda cada imagen renderizada con [ImageFormat.Png](https://reference.aspose.com/slides/es/python-java/aspose.slides/imageformat/#Png) y luego libera sus recursos.

El siguiente ejemplo en Python exporta todas las diapositivas con su tamaño predeterminado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Convertir PowerPoint a PNG con una escala personalizada**

Pasa factores de escala horizontal y vertical a [Slide.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage) para aumentar o disminuir las dimensiones de salida. Por ejemplo, una diapositiva de 720 × 540 puntos renderizada con un factor de escala de 2 en ambos ejes produce una imagen de 1440 × 1080 píxeles.

Utiliza factores de escala iguales para preservar la proporción de la diapositiva. Factores diferentes estiran la diapositiva horizontal o verticalmente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Convertir PowerPoint a PNG con un tamaño personalizado**

Para especificar dimensiones de píxel exactas, pasa un objeto Java `Dimension` con el ancho y alto deseados a [Slide.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage). Elige dimensiones con la misma proporción que la diapositiva original para evitar distorsiones.

El siguiente ejemplo guarda cada diapositiva como una imagen PNG de 960 × 720 píxeles:

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
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo exportar una forma individual, como un gráfico o una imagen, en lugar de toda la diapositiva?**

Sí. Aspose.Slides admite [generating thumbnails for individual shapes](/slides/es/python-java/create-shape-thumbnails/), que puedes guardar como imágenes PNG.

**¿Puedo convertir presentaciones en paralelo en un servidor?**

Utiliza una instancia de presentación independiente para cada hilo o proceso, y emplea rutas de salida únicas para evitar que los archivos se sobrescriban. No compartas una instancia de presentación entre hilos. Consulta [Multithreading](/slides/es/python-java/multithreading/).

**¿Cuáles son las limitaciones de la versión de prueba al exportar a PNG?**

El modo de evaluación añade una marca de agua a las imágenes de salida y aplica [other restrictions](/slides/es/python-java/licensing/). Aplica una licencia para eliminar estas limitaciones.