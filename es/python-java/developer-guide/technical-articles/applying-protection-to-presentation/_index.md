---
title: Restringir ediciones de presentaciones con bloqueos de forma en Python
linktitle: Restringir ediciones de presentación
type: docs
weight: 60
url: /es/python-java/applying-protection-to-presentation/
keywords:
- evitar ediciones
- proteger de la edición
- bloquear forma
- bloquear posición
- bloquear selección
- bloquear cambio de tamaño
- bloquear agrupación
- PowerPoint
- PPTX
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda cómo bloquear y desbloquear formas en presentaciones PPTX con Aspose.Slides for Python via Java para restringir la selección, el movimiento, el cambio de tamaño y la agrupación."
---
## **Antecedentes**

Un uso común de Aspose.Slides for Python via Java es crear, actualizar y guardar presentaciones PowerPoint (PPTX) como parte de un flujo de trabajo automatizado. Cuando los usuarios reciben estas presentaciones, restringir los cambios en las formas puede ayudar a preservar el diseño y el contenido previstos.

Este artículo explica cómo se organizan las formas en las diapositivas y cómo aplicar y eliminar bloqueos de forma en una presentación PPTX. Estos bloqueos le permiten restringir operaciones de edición específicas en formas individuales.

## **Composición de una diapositiva**

Una diapositiva de presentación está compuesta por componentes como autoshapes, tablas, objetos OLE, formas agrupadas, marcos de imagen, marcos de vídeo, conectores y otros elementos utilizados para crear una presentación. En Aspose.Slides for Python via Java, cada elemento de una diapositiva está representado por un objeto que hereda de la clase [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/).

Los diferentes tipos de forma ofrecen distintas opciones de bloqueo. La clase [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) es la clase base para los bloqueos de forma. Aspose.Slides for Python via Java proporciona las siguientes clases de bloqueo:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) bloquea los autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) bloquea los conectores.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) bloquea los objetos gráficos.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) bloquea los grupos de formas.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) bloquea los marcos de imagen.  

Para aplicar bloqueos en una [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), recorra sus diapositivas y establezca los bloqueos apropiados en cada forma admitida.

## **Aplicar y eliminar protección**

Los bloqueos de forma restringen operaciones como seleccionar, mover y cambiar el tamaño de las formas. No hacen que toda la presentación sea ineditable.

### **Aplicar protección a formas PPTX**

Aspose.Slides for Python via Java proporciona la clase [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) para trabajar con formas en una diapositiva.

El ejemplo llama a [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) y [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) con `True` para los autoshapes, con bloqueos equivalentes para grupos de formas, conectores y marcos de imagen. Los conectores usan [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) para el movimiento; los grupos también usan [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) para restringir la agrupación.

El ejemplo carga una presentación PPTX existente, verifica las formas en la colección de formas de cada diapositiva y guarda una copia con estas restricciones aplicadas. Las formas que no pertenecen a los cuatro tipos manejados se dejan sin cambios. El bucle no recorre las formas hijas dentro de un grupo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Eliminar protección**

Para eliminar un bloqueo de forma, establezca su valor a `False`. El siguiente ejemplo carga una presentación con bloqueos de forma y elimina las restricciones de selección, movimiento y cambio de tamaño mediante [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) y [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). También elimina la restricción de agrupación pasando `False` a [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) y guarda una copia de la presentación. Los demás ajustes de bloqueo se dejan sin cambios.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Conclusión**

Aspose.Slides for Python via Java le permite restringir operaciones de edición específicas en formas individuales o aplicar las mismas restricciones en varias diapositivas. Elija los bloqueos compatibles con cada tipo de forma y establezca sus valores a `False` cuando necesite eliminar esas restricciones.

## **Preguntas frecuentes**

**¿Puedo combinar los bloqueos de forma y la protección con contraseña en la misma presentación?**  
Sí. Los bloqueos de forma restringen operaciones de edición específicas, mientras que la [protección con contraseña](/slides/es/python-java/password-protected-presentation/) puede restringir la apertura o modificación de la presentación. Puede usar ambos en el mismo archivo.

**¿Puedo restringir la edición en diapositivas específicas sin afectar a otras?**  
Sí. Aplique los bloqueos solo a las formas en las diapositivas seleccionadas. Esto no cambia la configuración de bloqueos en otras diapositivas.

**¿Cómo puedo aplicar bloqueos a formas individuales dentro de un grupo?**  
Recorra la colección devuelta por el método [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) del grupo y aplique los bloqueos apropiados a cada forma hija. Repita esto para cualquier grupo anidado. Los ejemplos anteriores procesan solo la colección de formas de la diapositiva, por lo que no establecen bloqueos en los miembros individuales del grupo.