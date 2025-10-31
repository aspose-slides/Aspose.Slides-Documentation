---
title: Multihilo en Aspose.Slides para Python
linktitle: Multihilo
type: docs
weight: 200
url: /es/python-net/multithreading/
keywords:
- multihilo
- múltiples hilos
- trabajo paralelo
- convertir diapositivas
- diapositivas a imágenes
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aspose.Slides para Python mediante .NET con multihilo mejora el procesamiento de PowerPoint y OpenDocument. Descubra las mejores prácticas para flujos de trabajo de presentaciones eficientes."
---

## **Introducción**

Aunque el trabajo paralelo con presentaciones es posible (además del análisis/carga/clonación) y todo funciona bien (la mayoría de las veces), existe una pequeña probabilidad de obtener resultados incorrectos al usar la biblioteca en varios hilos.

Recomendamos encarecidamente que **no** use una única instancia de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) en un entorno de multihilo porque podría resultar en errores o fallos impredecibles que no se detectan fácilmente.

No es seguro cargar, guardar y/o clonar una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) en varios hilos. Tales operaciones **no** son compatibles. Si necesita realizar esas tareas, debe paralelizar las operaciones usando varios procesos de un solo hilo, y cada uno de esos procesos debe usar su propia instancia de presentación.

## **Convertir diapositivas de presentación a imágenes en paralelo**

Supongamos que queremos convertir todas las diapositivas de una presentación PowerPoint a imágenes PNG en paralelo. Dado que es inseguro usar una sola instancia de `Presentation` en varios hilos, dividimos las diapositivas de la presentación en presentaciones separadas y convertimos las diapositivas a imágenes en paralelo, usando cada presentación en un hilo distinto. El siguiente ejemplo de código muestra cómo hacerlo.

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

        # Convertir la diapositiva a una imagen.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Esperar a que se completen todas las tareas.
for task in conversion_tasks:
    task.result()

del presentation
```

## **Preguntas frecuentes**

**¿Necesito llamar a la configuración de licencia en cada hilo?**

No. Basta con hacerlo una vez por proceso o dominio de aplicación antes de que los hilos comiencen. Si la [configuración de licencia](/slides/es/python-net/licensing/) puede invocarse concurrentemente (por ejemplo, durante la inicialización perezosa), sincronice esa llamada porque el método de configuración de licencia en sí no es seguro para hilos.

**¿Puedo pasar objetos `Presentation` o `Slide` entre hilos?**

Pasar objetos de presentación “activos” entre hilos no se recomienda: utilice instancias independientes por hilo o pre‑cree presentaciones/contendedores de diapositivas separados para cada hilo. Este enfoque sigue la recomendación general de no compartir una única instancia de presentación entre hilos.

**¿Es seguro paralelizar la exportación a diferentes formatos (PDF, HTML, imágenes) siempre que cada hilo tenga su propia instancia de `Presentation`?**

Sí. Con instancias independientes y rutas de salida separadas, esas tareas normalmente se paralelizan correctamente; evite compartir objetos de presentación y flujos de E/S compartidos.

**¿Qué debo hacer con la configuración global de fuentes (carpetas, sustituciones) en multihilo?**

Inicialice toda la configuración global de fuentes antes de iniciar los hilos y no la modifique durante el trabajo paralelo. Esto elimina condiciones de carrera al acceder a recursos de fuentes compartidos.