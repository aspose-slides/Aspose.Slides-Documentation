---
title: Crear presentaciones en Python vía Java
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
description: "Crear presentaciones en Python vía Java con Aspose.Slides—generar archivos PPT, PPTX y ODP, beneficiarse del soporte OpenDocument y guardarlos programáticamente para obtener resultados fiables."
---
## **Visión general**

Este artículo muestra cómo crear una presentación con Aspose.Slides for Python via Java, añadir una forma con texto a la primera diapositiva y guardar el resultado como un archivo PPTX. Las preguntas frecuentes cubren formatos de salida, plantillas, tamaño de diapositiva, uso de memoria, subprocesos, licencias, firmas digitales y compatibilidad con VBA.

Antes de comenzar, instala Python, un JDK, JPype y Aspose.Slides for Python via Java. Consulta [Instalación](/slides/es/python-java/installation/) para los pasos en Windows, Linux y macOS.

## **Crear una presentación**

Crear un archivo PowerPoint desde cero en Aspose.Slides for Python via Java es tan sencillo como instanciar la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/). El constructor proporciona automáticamente una presentación en blanco con una única diapositiva, dándote un lienzo inmediato para formas, texto, gráficos o cualquier otro contenido que necesite tu aplicación. Una vez que modifiques esa diapositiva —o añadas nuevas— puedes guardar el resultado en formato PPTX, PPT heredado o incluso en formatos OpenDocument. El breve ejemplo de código a continuación ilustra este flujo de trabajo añadiendo una forma sencilla a la primera diapositiva.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtén la primera diapositiva por su índice, 0.
1. Añade un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) de tipo [ShapeType.Cloud](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#Cloud) utilizando [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Establece el texto de la forma usando [TextFrame.setText](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#setText).
1. Guarda la presentación usando [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/#Pptx).

El siguiente ejemplo inicia la Máquina Virtual Java (JVM) si aún no está en ejecución, añade una forma de nube con texto a la primera diapositiva y guarda la presentación. Guárdalo como *create_presentation.py*:

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

    # Guardar la presentación como un archivo PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ejecuta el script en el entorno donde instalaste los paquetes:

```sh
python create_presentation.py
```

La esquina superior izquierda de la nube está a 20 puntos de los bordes izquierdo y superior de la diapositiva, y la nube tiene 200 puntos de ancho y 80 puntos de alto. El script guarda *new_presentation.pptx* en el directorio de trabajo actual, con una sola diapositiva que contiene la nube y su texto. La JVM permanece en ejecución hasta que el proceso de Python finaliza; consulta [Limitaciones y diferencias de API](/slides/es/python-java/limitations-and-api-differences/#import-the-library). Sin una licencia, Aspose.Slides también añade un cuadro de texto de marca de agua de evaluación a cada diapositiva que guarda; consulta [Licencias](/slides/es/python-java/licensing/).

El resultado:

![La nueva presentación](new_presentation.png)

## **Preguntas frecuentes**

**¿Qué formatos puedo usar para guardar una nueva presentación?**

Puedes guardarlo en [PPTX, PPT y ODP](/slides/es/python-java/save-presentation/), y exportarlo a [PDF](/slides/es/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/es/python-java/convert-powerpoint-to-xps/), [HTML](/slides/es/python-java/convert-powerpoint-to-html/), [SVG](/slides/es/python-java/render-a-slide-as-an-svg-image/) y [imágenes](/slides/es/python-java/convert-powerpoint-to-png/), entre otros.

**¿Puedo empezar a partir de una plantilla (POTX/POTM) y guardarla como un PPTX normal?**

Sí. Carga la plantilla y guárdala en el formato deseado; los formatos POTX/POTM/PPTM y similares [son compatibles](/slides/es/python-java/supported-file-formats/).

**¿Cómo controlo el tamaño/relación de aspecto de la diapositiva al crear una presentación?**

Define el [tamaño de diapositiva](/slides/es/python-java/slide-size/) (incluidos los valores predefinidos como 4:3 y 16:9 o dimensiones personalizadas) y elige cómo debe escalar el contenido.

**¿En qué unidades se miden los tamaños y coordenadas?**

En puntos: 1 pulgada equivale a 72 unidades.

**¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?**

Utiliza [estrategias de gestión de BLOB](/slides/es/python-java/manage-blob/), limita el almacenamiento en memoria aprovechando archivos temporales y prefiere flujos de trabajo basados en archivos en lugar de transmisiones puramente en memoria.

**¿Puedo crear/guardar presentaciones en paralelo?**

No puedes operar sobre la misma instancia de [Presentation](/slides/es/python-java/supported-file-formats/) desde [múltiples hilos](/slides/es/python-java/multithreading/). Ejecuta instancias separadas e aisladas por hilo o proceso.

**¿Cómo elimino la marca de agua de prueba y las limitaciones?**

[Aplica una licencia](/slides/es/python-java/licensing/) una vez por proceso. El XML de la licencia debe permanecer sin modificar y la configuración de la licencia debe sincronizarse si hay varios hilos involucrados.

**¿Puedo firmar digitalmente el PPTX que creo?**

Sí. Las [firmas digitales](/slides/es/python-java/digital-signature-in-powerpoint/) (añadir y verificar) son compatibles con las presentaciones.

**¿Se admiten macros (VBA) en las presentaciones creadas?**

Sí. Puedes [crear/editar proyectos VBA](/slides/es/python-java/presentation-via-vba/) y guardar archivos habilitados para macros como PPTM/PPSM.