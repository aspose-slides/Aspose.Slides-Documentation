---
title: Crear presentaciones en Python
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
description: "Cree presentaciones de PowerPoint en Python con Aspose.Slides—genere archivos PPT, PPTX y ODP, aproveche el soporte OpenDocument y guárdelos programáticamente para obtener resultados fiables."
---

## **Resumen**

Aspose.Slides for Python le permite crear un archivo de presentación completamente nuevo únicamente con código. Este artículo muestra el flujo de trabajo principal: crear un objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), obtener la primera diapositiva, insertar una forma sencilla y guardar el resultado, para que pueda ver lo poco que se necesita para generar una presentación sin Microsoft Office. Como la misma API escribe archivos PPT, PPTX y ODP, puede dirigir tanto a formatos tradicionales de PowerPoint como a OpenDocument desde una única base de código. Aspose.Slides es adecuado para entornos de escritorio, web o servidor, proporcionando a su aplicación Python un punto de partida eficiente para añadir contenido más rico como texto, imágenes o gráficos una vez que la presentación inicial está preparada.

## **Crear una presentación**

Crear un archivo PowerPoint desde cero en Aspose.Slides for Python es tan directo como instanciar la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). El constructor suministra automáticamente una presentación en blanco con una sola diapositiva, dándole un lienzo inmediato para formas, texto, gráficos o cualquier otro contenido que su aplicación requiera. Una vez que modifique esa diapositiva—o añada nuevas—puede guardar el resultado en PPTX, PPT heredado o incluso en formatos OpenDocument. El breve fragmento de código a continuación ilustra este flujo de trabajo al agregar una forma sencilla a la primera diapositiva.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a la diapositiva por su índice.
1. Añada un objeto [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) de tipo `CLOUD` usando el método `add_auto_shape` expuesto por la colección `shapes`.
1. Añada texto a la auto‑forma.
1. Guarde la presentación modificada como archivo PPTX.

En el ejemplo siguiente, se añade una forma de nube a la primera diapositiva de la presentación.
```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Agregar una autoforma de tipo CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Guardar la presentación como archivo PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```


El resultado:

![La nueva presentación](new_presentation.png)

## **Preguntas frecuentes**

**¿A qué formatos puedo guardar una nueva presentación?**

Puede guardar en [PPTX, PPT y ODP](/slides/es/python-net/save-presentation/), y exportar a [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/es/python-net/convert-powerpoint-to-xps/), [HTML](/slides/es/python-net/convert-powerpoint-to-html/), [SVG](/slides/es/python-net/convert-powerpoint-to-png/) y [imágenes](/slides/es/python-net/convert-powerpoint-to-png/), entre otros.

**¿Puedo iniciar a partir de una plantilla (POTX/POTM) y guardarla como PPTX normal?**

Sí. Cargue la plantilla y guárdela en el formato deseado; los formatos POTX/POTM/PPTM y similares [son compatibles](/slides/es/python-net/supported-file-formats/).

**¿Cómo controlo el tamaño/relación de aspecto de la diapositiva al crear una presentación?**

Establezca el [tamaño de la diapositiva](/slides/es/python-net/slide-size/) (incluyendo valores predefinidos como 4:3 y 16:9 o dimensiones personalizadas) y elija cómo debe escalar el contenido.

**¿En qué unidades se miden los tamaños y coordenadas?**

En puntos: 1 pulgada equivale a 72 unidades.

**¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?**

Utilice [estrategias de gestión de BLOB](/slides/es/python-net/manage-blob/), limite el almacenamiento en memoria mediante archivos temporales y prefiera flujos basados en archivos en lugar de solo en memoria.

**¿Puedo crear/guardar presentaciones en paralelo?**

No puede operar sobre la misma instancia de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) desde [múltiples hilos](/slides/es/python-net/multithreading/). Ejecute instancias separadas y aisladas por hilo o proceso.

**¿Cómo elimino la marca de agua de prueba y sus limitaciones?**

[Aplica una licencia](/slides/es/python-net/licensing/) una vez por proceso. El XML de la licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si intervienen varios hilos.

**¿Puedo firmar digitalmente el PPTX que creo?**

Sí. Las [firmas digitales](/slides/es/python-net/digital-signature-in-powerpoint/) (agregar y verificar) son compatibles con las presentaciones.

**¿Se admiten macros (VBA) en las presentaciones creadas?**

Sí. Puede [crear/editar proyectos VBA](/slides/es/python-net/presentation-via-vba/) y guardar archivos con macros como PPTM/PPSM.