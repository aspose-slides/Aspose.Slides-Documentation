---
title: Restringir ediciones de la presentación con bloqueos de forma en Python
linktitle: Restringir ediciones de la presentación
type: docs
weight: 70
url: /es/python-net/applying-protection-to-presentation/
keywords:
- prevenir ediciones
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
- Aspose.Slides
description: "Aprenda cómo bloquear y desbloquear formas en presentaciones PPTX con Aspose.Slides for Python via .NET para restringir la selección, el movimiento, el cambio de tamaño y la agrupación."
---
## **Antecedentes**

Un uso común de Aspose.Slides for Python via .NET es crear, actualizar y guardar presentaciones PowerPoint (PPTX) como parte de un flujo de trabajo automatizado. Cuando los usuarios reciben estas presentaciones, restringir los cambios en las formas puede ayudar a preservar el diseño y el contenido previstos.

Este artículo explica cómo se organizan las formas en las diapositivas y cómo aplicar y eliminar bloqueos de forma en una presentación PPTX. Estos bloqueos le permiten restringir operaciones específicas de edición en formas individuales.

## **Composición de una diapositiva**

Una diapositiva de presentación está compuesta por componentes como autoshapes, tablas, objetos OLE, formas agrupadas, marcos de imagen, marcos de video, conectores y otros elementos utilizados para crear una presentación. En Aspose.Slides for Python via .NET, cada elemento de una diapositiva está representado por un objeto que hereda de la clase [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

Los diferentes tipos de forma exponen distintas opciones de bloqueo. La clase [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) es la clase base para los bloqueos de forma. Aspose.Slides for Python via .NET proporciona las siguientes clases de bloqueo:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) bloquea autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) bloquea formas de conector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) bloquea objetos gráficos.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) bloquea formas agrupadas.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) bloquea marcos de imagen.  

Para aplicar bloqueos en una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), recorra sus diapositivas y establezca los bloqueos apropiados en cada forma compatible.

## **Aplicar y eliminar protección**

Los bloqueos de forma restringen operaciones como seleccionar, mover y cambiar el tamaño de las formas. No hacen que toda la presentación sea ineditable.

### **Aplicar protección a formas PPTX**

Aspose.Slides for Python via .NET proporciona la clase [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) para trabajar con formas en una diapositiva.

El ejemplo establece [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) y [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) a `True` para autoshapes, con bloqueos equivalentes para formas de grupo, conectores y marcos de imagen. Los conectores usan [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) para el movimiento; los grupos también usan [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) para restringir la agrupación.

El ejemplo carga una presentación PPTX existente, comprueba las formas en la colección de formas de cada diapositiva y guarda una copia con estas restricciones aplicadas. Las formas fuera de los cuatro tipos manejados se dejan sin cambios. El bucle no recorre las formas secundarias dentro de un grupo.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Eliminar protección**

Para eliminar un bloqueo de forma, establezca su valor a `False`. El siguiente ejemplo carga una presentación con bloqueos de forma y elimina las restricciones de selección, movimiento y cambio de tamaño mediante [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) y [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). También elimina [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) y guarda una copia de la presentación. Otras configuraciones de bloqueo se dejan sin cambios.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Conclusión**

Aspose.Slides for Python via .NET le permite restringir operaciones específicas de edición en formas individuales o aplicar las mismas restricciones en varias diapositivas. Elija los bloqueos compatibles con cada tipo de forma y establezca sus valores a `False` cuando necesite eliminar esas restricciones.

## **Preguntas frecuentes**

**¿Puedo combinar bloqueos de forma y protección con contraseña en la misma presentación?**

Sí. Los bloqueos de forma restringen operaciones específicas de edición, mientras que [protección con contraseña](/slides/es/python-net/password-protected-presentation/) puede restringir la apertura o modificación de la presentación. Puede usar ambos en el mismo archivo.

**¿Puedo restringir la edición en diapositivas específicas sin afectar a otras?**

Sí. Aplique los bloqueos solo a las formas de las diapositivas seleccionadas. Esto no cambia la configuración de bloqueos en otras diapositivas.

**¿Cómo puedo aplicar bloqueos a formas individuales dentro de un grupo?**

Recorra la colección de [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) del grupo y aplique los bloqueos apropiados a cada forma secundaria. Repita esto para cualquier grupo anidado. Los ejemplos anteriores procesan solo la colección de formas de la diapositiva, por lo que no establecen bloqueos en los miembros individuales del grupo.