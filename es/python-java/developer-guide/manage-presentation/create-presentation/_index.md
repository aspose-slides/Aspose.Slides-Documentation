---
title: Crear presentaciones en Python via Java
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
description: "Crear presentaciones en Python via Java con Aspose.Slides—produzca archivos PPT, PPTX y ODP, aproveche el soporte OpenDocument y guárdelos programáticamente para obtener resultados fiables."
---
## **Visión general**

Este artículo muestra cómo crear una presentación con Aspose.Slides for Python via Java, añadir una forma con texto a la primera diapositiva y guardar el resultado como archivo PPTX. Las preguntas frecuentes cubren formatos de salida, plantillas, tamaño de diapositiva, uso de memoria, subprocesos, licencias, firmas digitales y compatibilidad con VBA.

## **Crear una presentación**

Crear un archivo PowerPoint desde cero en Aspose.Slides for Python via Java es tan sencillo como instanciar la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/). El constructor suministra automáticamente una presentación en blanco con una sola diapositiva, proporcionando un lienzo inmediato para formas, texto, gráficos o cualquier otro contenido que necesite su aplicación. Una vez que modifique esa diapositiva —o añada nuevas— puede persistir el resultado en PPTX, PPT legado o incluso en formatos OpenDocument. El breve ejemplo de código a continuación ilustra este flujo añadiendo una forma simple a la primera diapositiva.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener la primera diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) de tipo [ShapeType.Cloud](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#Cloud) usando [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Establecer el texto de la forma mediante [TextFrame.setText](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#setText).
1. Guardar la presentación mediante [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/#Pptx).

El siguiente ejemplo requiere Aspose.Slides for Python via Java y un tiempo de ejecución Java compatible. Inicia la JVM si aún no está en ejecución, añade una forma de nube a la primera diapositiva y guarda la presentación:

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

![The new presentation](new_presentation.png)

## **Preguntas frecuentes**

**¿En qué formatos puedo guardar una nueva presentación?**

Puede guardar en [PPTX, PPT y ODP](/slides/es/python-java/save-presentation/), y exportar a [PDF](/slides/es/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/es/python-java/convert-powerpoint-to-xps/), [HTML](/slides/es/python-java/convert-powerpoint-to-html/), [SVG](/slides/es/python-java/render-slide-as-svg/), y [imágenes](/slides/es/python-java/convert-powerpoint-to-png/), entre otros.

**¿Puedo iniciar desde una plantilla (POTX/POTM) y guardar como un PPTX normal?**

Sí. Cargue la plantilla y guarde en el formato deseado; los formatos POTX/POTM/PPTM y similares [están soportados](/slides/es/python-java/supported-file-formats/).

**¿Cómo controlo el tamaño/relación de aspecto de la diapositiva al crear una presentación?**

Configure el [tamaño de diapositiva](/slides/es/python-java/slide-size/) (incluyendo ajustes predefinidos como 4:3 y 16:9 o dimensiones personalizadas) y elija cómo debe escalar el contenido.

**¿En qué unidades se miden los tamaños y coordenadas?**

En puntos: 1 pulgada equivale a 72 unidades.

**¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?**

Utilice [estrategias de gestión de BLOB](/slides/es/python-java/manage-blob/), limite el almacenamiento en memoria aprovechando archivos temporales y prefiera flujos basados en archivos en lugar de solo flujos en memoria.

**¿Puedo crear/guardar presentaciones en paralelo?**

No puede operar sobre la misma instancia de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) desde [múltiples hilos](/slides/es/python-java/multithreading/). Ejecute instancias separadas e aisladas por hilo o proceso.

**¿Cómo elimino la marca de agua de prueba y las limitaciones?**

[Aplicar una licencia](/slides/es/python-java/licensing/) una vez por proceso. El XML de licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si varios hilos están involucrados.

**¿Puedo firmar digitalmente el PPTX que creo?**

Sí. Las [firmas digitales](/slides/es/python-java/digital-signature-in-powerpoint/) (añadir y verificar) son compatibles con presentaciones.

**¿Se admiten macros (VBA) en presentaciones creadas?**

Sí. Puede [crear/editar proyectos VBA](/slides/es/python-java/presentation-via-vba/) y guardar archivos habilitados para macros como PPTM/PPSM.