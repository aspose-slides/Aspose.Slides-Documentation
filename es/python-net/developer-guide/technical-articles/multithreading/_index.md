---
title: Multihilo en Aspose.Slides
type: docs
weight: 200
url: /python-net/multithreading/
keywords:
- PowerPoint
- presentación
- multihilo
- trabajo paralelo
- convertir diapositivas
- diapositivas a imágenes
- Python
- Aspose.Slides para Python
---

## **Introducción**

Si bien el trabajo paralelo con presentaciones es posible (además de analizar/cargar/clonar) y todo va bien (la mayoría de las veces), hay una pequeña posibilidad de que obtengas resultados incorrectos cuando utilizas la biblioteca en múltiples hilos.

Recomendamos encarecidamente que **no** utilices una única [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) en un entorno de multihilo, ya que puede resultar en errores o fallos impredecibles que no son fácilmente detectables.

No es **seguro** cargar, guardar y/o clonar una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) en múltiples hilos. Tales operaciones **no** están soportadas. Si necesitas realizar tales tareas, debes paralelizar las operaciones utilizando varios procesos de un solo hilo, y cada uno de estos procesos debería usar su propia instancia de presentación.

## **Convertir Diapositivas de Presentación a Imágenes en Paralelo**

Supongamos que queremos convertir todas las diapositivas de una presentación de PowerPoint a imágenes PNG en paralelo. Dado que no es seguro usar una única instancia de `Presentation` en múltiples hilos, dividimos las diapositivas de la presentación en presentaciones separadas y convertimos las diapositivas a imágenes en paralelo, utilizando cada presentación en un hilo separado. El siguiente ejemplo de código muestra cómo hacerlo.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Extraer la diapositiva i en una presentación separada.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Convertir la diapositiva en una imagen.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Esperar a que todas las tareas se completen.
for task in conversion_tasks:
    task.result()

del presentation
```