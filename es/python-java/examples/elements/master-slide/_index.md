---
title: Diapositiva maestra
type: docs
weight: 30
url: /es/python-java/examples/elements/master-slide/
keywords:
- ejemplo de código
- diapositiva maestra
- añadir diapositiva maestra
- acceder a diapositiva maestra
- eliminar diapositiva maestra
- diapositiva maestra sin usar
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Gestiona diapositivas maestras con Aspose.Slides for Python via Java: crea, accede, elimina y limpia maestros en presentaciones PowerPoint y OpenDocument."
---
Las diapositivas maestras forman el nivel superior de la jerarquía de herencia de diapositivas en PowerPoint. Una **diapositiva maestra** define elementos de diseño comunes como fondos, logotipos y formato de texto. **Diapositivas de diseño** heredan de las diapositivas maestras, y las **diapositivas normales** heredan de las diapositivas de diseño.

Este artículo muestra cómo crear, modificar y administrar diapositivas maestras usando **Aspose.Slides for Python via Java**.

Instale el paquete como se describe en [Instalación](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM, y luego importa la API una vez que la JVM está en ejecución.

## **Add a Master Slide**

Este ejemplo muestra cómo crear una nueva diapositiva maestra clonando la predeterminada. Luego añade una pancarta con el nombre de la empresa a todas las diapositivas mediante la herencia de diseño.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Clona la diapositiva maestra predeterminada.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # Añade una pancarta con el nombre de la empresa en la parte superior de la diapositiva maestra.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # Asigna la nueva diapositiva maestra a una diapositiva de diseño.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # Asigna la diapositiva de diseño a la primera diapositiva de la presentación.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}}
Las diapositivas maestras proporcionan una forma de aplicar una marca consistente o elementos de diseño compartidos en todas las diapositivas. Los cambios realizados en una maestra se reflejan automáticamente en las diapositivas de diseño y normales dependientes.
{{% /alert %}}

{{% alert color="info" title="Nota" %}}
Las formas y el formato añadidos a una diapositiva maestra son heredados por las diapositivas de diseño y, a su vez, por todas las diapositivas normales que usan esos diseños. La imagen a continuación ilustra cómo un cuadro de texto añadido a una diapositiva maestra se renderiza automáticamente en la diapositiva final.
{{% /alert %}}

![Ejemplo de herencia de maestra](master-slide-banner.png)

## **Access a Master Slide**

Puede acceder a las diapositivas maestras a través de la colección master de la presentación. Este ejemplo recupera la primera diapositiva maestra y cambia su tipo de fondo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **Remove a Master Slide**

Una diapositiva maestra puede eliminarse por índice o por referencia una vez que ya no se usa. Este ejemplo asigna una diapositiva maestra clonada a la presentación y luego elimina la maestra original por índice.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # Elimina la diapositiva maestra original sin usar por índice.
    presentation.getMasters().removeAt(0)

    # Alternativamente, elimina una diapositiva maestra sin usar por referencia:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **Remove Unused Master Slides**

Algunas presentaciones contienen diapositivas maestras que no se usan. Eliminar estas diapositivas puede ayudar a reducir el tamaño del archivo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # Eliminar todas las diapositivas maestras sin usar, incluidas las marcadas como Preserve.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```