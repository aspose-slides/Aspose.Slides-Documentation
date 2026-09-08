---
title: Crear presentaciones en Python mediante Java
linktitle: Crear presentación
type: docs
weight: 10
url: /es/python-java/create-presentation/
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
- presentación
- Python
- Java
- Aspose.Slides
description: "Crear presentaciones en Python mediante Java con Aspose.Slides—produzca archivos PPT, PPTX y ODP, aproveche la compatibilidad con OpenDocument y guárdelos programáticamente para obtener resultados fiables."
---
## **Visión general**

Este artículo muestra cómo crear una presentación con Aspose.Slides for Python via Java, añadir una forma con texto a la primera diapositiva y guardar el resultado como archivo PPTX. Las preguntas frecuentes incluyen formatos de salida, plantillas, tamaño de diapositivas, uso de memoria, subprocesos, licenciamiento, firmas digitales y compatibilidad con VBA.

## **Crear una presentación**

Crear un archivo PowerPoint desde cero en Aspose.Slides for Python via Java es tan directo como instanciar la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/). El constructor suministra automáticamente una presentación en blanco con una única diapositiva, proporcionándote un lienzo inmediato para formas, texto, gráficos o cualquier otro contenido que necesite tu aplicación. Una vez que modifies esa diapositiva —o añadas nuevas— puedes guardar el resultado en PPTX, PPT heredado o incluso en formatos OpenDocument. El breve ejemplo de código a continuación ilustra este flujo añadiendo una forma sencilla a la primera diapositiva.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener la primera diapositiva por su índice.
1. Agregar un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) del tipo [ShapeType.Cloud](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#Cloud) usando [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Establecer el texto de la forma usando [TextFrame.setText](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#setText).
1. Guardar la presentación usando [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/#Pptx).

El siguiente ejemplo requiere Aspose.Slides for Python via Java y un tiempo de ejecución Java compatible. Inicia la JVM si aún no está en ejecución, agrega una forma de nube a la primera diapositiva y guarda la presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Crear una presentación con una diapositiva en blanco.
presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir una forma de nube y establecer su texto.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Guardar la presentación como archivo PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![La nueva presentación](new_presentation.png)

## **Preguntas frecuentes**

**¿En qué formatos puedo guardar una nueva presentación?**

Puedes guardar en [PPTX, PPT y ODP](/slides/es/python-java/save-presentation/), y exportar a [PDF](/slides/es/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/es/python-java/convert-powerpoint-to-xps/), [HTML](/slides/es/python-java/convert-powerpoint-to-html/), [SVG](/slides/es/python-java/render-slide-as-svg/), y [imágenes](/slides/es/python-java/convert-powerpoint-to-png/), entre otros.

**¿Puedo iniciar a partir de una plantilla (POTX/POTM) y guardarla como un PPTX normal?**

Sí. Carga la plantilla y guárdala en el formato deseado; los formatos POTX/POTM/PPTM y similares [son compatibles](/slides/es/python-java/supported-file-formats/).

**¿Cómo controlo el tamaño/relación de aspecto de la diapositiva al crear una presentación?**

Establece el [tamaño de la diapositiva](/slides/es/python-java/slide-size/) (incluidos valores predefinidos como 4:3 y 16:9 o dimensiones personalizadas) y elige cómo debe escalar el contenido.

**¿En qué unidades se miden los tamaños y coordenadas?**

En puntos: 1 pulgada equivale a 72 unidades.

**¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?**

Utiliza [estrategias de gestión de BLOB](/slides/es/python-java/manage-blob/), limita el almacenamiento en memoria aprovechando archivos temporales y prefiere flujos de trabajo basados en archivos en lugar de transmisiones puramente en memoria.

**¿Puedo crear/guardar presentaciones en paralelo?**

No puedes operar sobre la misma instancia de [Presentation] desde [múltiples subprocesos](/slides/es/python-java/multithreading/). Ejecuta instancias separadas e aisladas por subproceso o proceso.

**¿Cómo elimino la marca de agua de prueba y las limitaciones?**

[Aplica una licencia](/slides/es/python-java/licensing/) una vez por proceso. El XML de licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si participan varios subprocesos.

**¿Puedo firmar digitalmente el PPTX que creo?**

Sí. Las [firmas digitales](/slides/es/python-java/digital-signature-in-powerpoint/) (añadir y verificar) son compatibles con las presentaciones.

**¿Se admiten macros (VBA) en presentaciones creadas?**

Sí. Puedes [crear/editar proyectos VBA](/slides/es/python-java/presentation-via-vba/) y guardar archivos con macros habilitadas como PPTM/PPSM.