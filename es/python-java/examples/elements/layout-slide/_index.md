---
title: Diapositiva de diseño
type: docs
weight: 20
url: /es/python-java/examples/elements/layout-slide/
keywords:
- ejemplo de código
- diapositiva de diseño
- agregar diapositiva de diseño
- acceder a diapositiva de diseño
- eliminar diapositiva de diseño
- diapositiva de diseño no utilizada
- clonar diapositiva de diseño
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Gestiona diapositivas de diseño con Aspose.Slides para Python a través de Java: agrega, accede, elimina, limpia y clona diseños en presentaciones PowerPoint y OpenDocument."
---
Este artículo muestra cómo trabajar con **diapositivas de diseño** usando Aspose.Slides para Python a través de Java. Una diapositiva de diseño define el aspecto y el formato que heredan las diapositivas normales. Puede añadir, acceder, clonar y eliminar diapositivas de diseño, así como limpiar las que no se usan para reducir el tamaño de la presentación.

Instale el paquete como se describe en [Instalación](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM y luego importa la API una vez que la JVM está en ejecución.

## **Agregar una diapositiva de diseño**

Cree una diapositiva de diseño personalizada para definir un formato reutilizable. El siguiente ejemplo agrega un cuadro de texto a un nuevo diseño y luego crea dos diapositivas que lo utilizan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Crea una diapositiva de diseño con un tipo de diseño en blanco y un nombre personalizado.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # Añade un cuadro de texto a la diapositiva de diseño.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # Añade dos diapositivas que heredan el texto del diseño.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Nota 1:** Las diapositivas de diseño actúan como plantillas para diapositivas individuales. Puede definir elementos comunes una vez y reutilizarlos en muchas diapositivas.

> 💡 **Nota 2:** Cuando añade formas o texto a una diapositiva de diseño, todas las diapositivas basadas en ese diseño muestran el contenido compartido automáticamente.  
> La captura de pantalla a continuación muestra dos diapositivas que heredan un cuadro de texto del mismo diseño de diapositiva.

![Diapositivas heredando contenido de diseño](layout-slide-result.png)

## **Acceder a una diapositiva de diseño**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Acceder a una diapositiva de diseño por índice.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # Acceder a una diapositiva de diseño por tipo.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **Eliminar una diapositiva de diseño**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **Eliminar diapositivas de diseño no usadas**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **Clonar una diapositiva de diseño**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Resumen:** Las diapositivas de diseño ayudan a mantener un formato coherente en toda la presentación. Aspose.Slides le permite crear, gestionar, reutilizar y limpiar diseños según sea necesario.