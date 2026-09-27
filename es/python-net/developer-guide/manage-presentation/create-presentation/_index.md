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
description: "Cree presentaciones de PowerPoint en Python con Aspose.Slides—produzca archivos PPT, PPTX y ODP, aproveche la compatibilidad con OpenDocument y guárdelos programáticamente para obtener resultados fiables."
---
## **Visión general**

Este artículo muestra cómo crear una presentación con Aspose.Slides para Python a través de .NET, añadir una forma con texto a su primera diapositiva y guardar el resultado como un archivo PPTX. La misma API también guarda presentaciones como PPT y ODP, por lo que puedes dirigirte a los formatos PowerPoint y OpenDocument desde una única base de código, sin necesidad de Microsoft Office. Al final hay una breve FAQ que cubre preguntas comunes sobre formatos, plantillas, tamaño de diapositiva, unidades, uso de memoria, subprocesos, licencias, firmas digitales y compatibilidad con VBA.

Antes de comenzar, instala el paquete desde PyPI con `pip install aspose.slides`. Consulta [Instalación](/slides/es/python-net/installation/) para conocer las bibliotecas que también requieren Linux y macOS, y para el entorno virtual que necesita el Python del sistema en Debian y Ubuntu.

## **Crear una presentación**

Para crear una presentación y colocar una forma con texto en su primera diapositiva, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/). Una nueva presentación ya contiene una diapositiva vacía.
2. Obtén esa diapositiva de la colección de [slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/slides/es/) por su índice, 0.
3. Añade una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) con forma de nube mediante el método [add_auto_shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_auto_shape/) de la colección de [shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/shapes/) de la diapositiva, y establece su [text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/text/).
4. Guarda la presentación como un archivo PPTX con el método [save](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/save/).

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir una autoforma del tipo CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Guardar la presentación como archivo PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

La esquina superior izquierda de la nube está a 20 puntos del borde izquierdo y a 20 puntos del borde superior de la diapositiva, y la nube tiene 200 puntos de ancho y 80 puntos de alto. La sentencia `with` libera los recursos de la presentación al finalizar el bloque. El script guarda *new_presentation.pptx* en la carpeta actual, con una diapositiva que contiene la nube y su texto. Sin una licencia, Aspose.Slides también añade una marca de agua de evaluación a cada diapositiva que guarda; consulta [Licencias](/slides/es/python-net/licensing/).

El resultado:

![La nueva presentación](new_presentation.png)

## **FAQ**

### ¿A qué formatos puedo guardar una nueva presentación?

Puedes guardar en [PPTX, PPT y ODP](/slides/es/python-net/save-presentation/), y exportar a [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/es/python-net/convert-powerpoint-to-xps/), [HTML](/slides/es/python-net/convert-powerpoint-to-html/), [SVG](/slides/es/python-net/render-a-slide-as-an-svg-image/) e [imágenes](/slides/es/python-net/convert-powerpoint-to-png/), entre otros.

### ¿Puedo partir de una plantilla (POTX/POTM) y guardar como PPTX normal?

Sí. Carga la plantilla y guárdala en el formato deseado; los formatos POTX/POTM/PPTM y similares [son compatibles](/slides/es/python-net/supported-file-formats/).

### ¿Cómo controlo el tamaño y la relación de aspecto de la diapositiva al crear una presentación?

Configura el [tamaño de la diapositiva](/slides/es/python-net/slide-size/) (incluyendo predefinidos como 4:3 y 16:9 o dimensiones personalizadas) y elige cómo debe escalar el contenido.

### ¿En qué unidades se miden los tamaños y coordenadas?

En puntos: 1 pulgada equivale a 72 unidades.

### ¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?

Utiliza [estrategias de gestión de BLOB](/slides/es/python-net/manage-blob/), limita el almacenamiento en memoria aprovechando archivos temporales y prefiere flujos basados en archivos sobre flujos puramente en memoria.

### ¿Puedo crear/guardar presentaciones en paralelo?

No puedes operar sobre la misma instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) desde [varios subprocesos](/slides/es/python-net/multithreading/). Ejecuta instancias separadas e independientes por subproceso o proceso.

### ¿Cómo elimino la marca de agua de prueba y sus limitaciones?

[Aplica una licencia](/slides/es/python-net/licensing/) una vez por proceso. El XML de la licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si intervienen varios subprocesos.

### ¿Puedo firmar digitalmente el PPTX que creo?

Sí. Las [firmas digitales](/slides/es/python-net/digital-signature-in-powerpoint/) (añadir y verificar) están soportadas para presentaciones.

### ¿Se admiten macros (VBA) en las presentaciones creadas?

Sí. Puedes [crear/editar proyectos VBA](/slides/es/python-net/presentation-via-vba/) y guardar archivos con macros como PPTM/PPSM.