---
title: Crear una presentación en Python
linktitle: Crear presentación
type: docs
weight: 10
url: /es/python-net/create-presentation/
keywords:
- crear presentación
- nueva presentación
- crear PPT
- nuevo PPT
- crear PPTX
- nuevo PPTX
- crear ODP
- nuevo ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Cree presentaciones de PowerPoint en Python con Aspose.Slides: genere archivos PPT, PPTX y ODP, aproveche el soporte OpenDocument y guárdelos programáticamente para obtener resultados fiables."
---

## **Visión general**

Aspose.Slides for Python le permite crear un archivo de presentación completamente nuevo mediante código. Este artículo muestra el flujo de trabajo básico: crear un objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), obtener la primera diapositiva, insertar una forma sencilla y guardar el resultado, de modo que pueda ver lo poca configuración que se necesita para generar una presentación sin Microsoft Office. Como la misma API escribe archivos PPT, PPTX y ODP, puede dirigirse tanto a los formatos tradicionales de PowerPoint como a los de OpenDocument desde una única base de código. Aspose.Slides es adecuado para entornos de escritorio, web o servidor, proporcionando a su aplicación Python un punto de partida eficiente para añadir contenido más rico, como texto, imágenes o gráficos, una vez que la presentación inicial está preparada.

## **Crear una presentación**

Crear un archivo PowerPoint desde cero en Aspose.Slides for Python es tan directo como instanciar la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). El constructor suministra automáticamente una presentación en blanco con una sola diapositiva, dándole un lienzo inmediato para formas, texto, gráficos o cualquier otro contenido que su aplicación necesite. Después de modificar esa diapositiva —o añadir nuevas— puede guardar el resultado en formato PPTX, PPT heredado o incluso en formatos OpenDocument. El breve ejemplo de código a continuación ilustra este flujo de trabajo añadiendo una forma sencilla a la primera diapositiva.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener una referencia a la diapositiva por su índice.
1. Añadir un objeto [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) de tipo `CLOUD` mediante el método `add_auto_shape` expuesto por la colección `shapes`.
1. Añadir texto a la autoforma.
1. Guardar la presentación modificada como archivo PPTX.

En el ejemplo a continuación, se añade una forma de nube a la primera diapositiva de la presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir una autoforma del tipo CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Guardar la presentación como un archivo PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![La nueva presentación](new_presentation.png)

## **Preguntas frecuentes**

**¿Qué formatos puedo utilizar para guardar una nueva presentación?**

Puede guardar en [PPTX, PPT y ODP](/slides/es/python-net/save-presentation/), y exportar a [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/es/python-net/convert-powerpoint-to-xps/), [HTML](/slides/es/python-net/convert-powerpoint-to-html/), [SVG](/slides/es/python-net/convert-powerpoint-to-png/), y [imágenes](/slides/es/python-net/convert-powerpoint-to-png/), entre otros.

**¿Puedo iniciar a partir de una plantilla (POTX/POTM) y guardar como un PPTX normal?**

Sí. Cargue la plantilla y guárdela en el formato deseado; los formatos POTX/POTM/PPTM y similares [son compatibles](/slides/es/python-net/supported-file-formats/).

**¿Cómo controlo el tamaño/relación de aspecto de la diapositiva al crear una presentación?**

Configure el [slide size](/slides/es/python-net/slide-size/) (incluyendo preajustes como 4:3 y 16:9 o dimensiones personalizadas) y elija cómo debe escalase el contenido.

**¿En qué unidades se miden los tamaños y coordenadas?**

En puntos: 1 pulgada equivale a 72 unidades.

**¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?**

Utilice [BLOB management strategies](/slides/es/python-net/manage-blob/), limite el almacenamiento en memoria aprovechando archivos temporales y prefiera flujos de trabajo basados en archivos sobre streams puramente en memoria.

**¿Puedo crear/guardar presentaciones en paralelo?**

No puede operar sobre la misma [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) desde [multiple threads](/slides/es/python-net/multithreading/). Ejecute instancias separadas e aisladas por hilo o proceso.

**¿Cómo elimino la marca de agua de prueba y sus limitaciones?**

[Apply a license](/slides/es/python-net/licensing/) una vez por proceso. El XML de licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si varios hilos están involucrados.

**¿Puedo firmar digitalmente el PPTX que creo?**

Sí. Las [Digital signatures](/slides/es/python-net/digital-signature-in-powerpoint/) (añadir y verificar) son compatibles con las presentaciones.

**¿Se admiten macros (VBA) en las presentaciones creadas?**

Sí. Puede [create/edit VBA projects](/slides/es/python-net/presentation-via-vba/) y guardar archivos con macros activas como PPTM/PPSM.