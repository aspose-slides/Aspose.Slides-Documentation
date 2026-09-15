---
title: Multihilos en Aspose.Slides para Python mediante Java
linktitle: Multihilos
type: docs
weight: 310
url: /es/python-java/multithreading/
keywords:
- multihilos
- múltiples hilos
- trabajo paralelo
- convertir diapositivas
- diapositivas a imágenes
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "El multihilo en Aspose.Slides para Python mediante Java mejora el procesamiento de PowerPoint y OpenDocument. Descubra las mejores prácticas para flujos de trabajo de presentaciones eficientes."
---
## **Introducción**

Aunque el trabajo en paralelo con presentaciones es posible (excepto para el análisis, la carga y la clonación) y normalmente funciona bien, existe una pequeña posibilidad de obtener resultados incorrectos cuando se usa la biblioteca en varios hilos.

Recomendamos encarecidamente que **no** utilice una única instancia de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) en un entorno multihilo, ya que podría producir errores o fallos impredecibles que no se detectan fácilmente.

No es **seguro** cargar, guardar y/o clonar una instancia de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) en varios hilos. Dichas operaciones **no** están soportadas. Si necesita realizar esas tareas, debe paralelizar las operaciones utilizando varios procesos mono‑hilo, y cada uno de estos procesos debe usar su propia instancia de presentación.

## **Convertir diapositivas de presentación a imágenes en paralelo**

Supongamos que queremos convertir todas las diapositivas de una presentación de PowerPoint a imágenes PNG en paralelo. Dado que no es seguro usar una única instancia de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) en varios hilos, dividimos las diapositivas de la presentación en presentaciones separadas y convertimos las diapositivas a imágenes en paralelo, utilizando cada presentación en un hilo distinto. El siguiente ejemplo de código muestra cómo hacerlo.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # Extraer la diapositiva a una presentación separada.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Convertir la diapositiva a una imagen en una tarea separada.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Esperar a que se completen todas las tareas.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Necesito llamar a la configuración de licencia en cada hilo?**

No. Basta con hacerlo una vez por proceso antes de que se inicien los hilos. Si la [license setup](/slides/es/python-java/licensing/) pudiera invocarse simultáneamente (por ejemplo, durante la inicialización perezosa), sincronice esa llamada porque el propio método de configuración de licencia no es seguro para hilos.

**¿Puedo pasar objetos [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) o [Slide](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/) entre hilos?**

Pasar objetos de presentación "en vivo" entre hilos no se recomienda: utilice instancias independientes por hilo o cree presentaciones o contenedores de diapositivas separados para cada hilo con antelación. Este enfoque sigue la recomendación general de no compartir una única instancia de presentación entre hilos.

**¿Es seguro paralelizar la exportación a diferentes formatos (PDF, HTML, imágenes) siempre que cada hilo tenga su propia instancia de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/)?**

Sí. Con instancias independientes y rutas de salida separadas, dichas tareas suelen paralelizarse correctamente; evite cualquier objeto de presentación compartido y flujos de E/S compartidos.

**¿Qué debo hacer con la configuración global de fuentes (carpetas, sustituciones) en entornos multihilo?**

Inicialice toda la [font settings](/slides/es/python-java/powerpoint-fonts/) global antes de iniciar los hilos y no la modifique durante el trabajo en paralelo. Esto elimina condiciones de carrera al acceder a recursos de fuentes compartidos.