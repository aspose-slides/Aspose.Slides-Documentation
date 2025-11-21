---
title: Prevenir Ediciones de Presentación con Bloqueos de Forma en Python
linktitle: Prevenir Ediciones de Presentación
type: docs
weight: 70
url: /es/python-net/applying-protection-to-presentation/
keywords:
- evitar ediciones
- proteger contra la edición
- bloquear forma
- bloquear posición
- bloquear selección
- bloquear tamaño
- bloquear agrupación
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para Python a través de .NET bloquea o desbloquea formas en archivos PPT, PPTX y ODP, asegurando presentaciones mientras permite ediciones controladas y una entrega más rápida."
---

## **Antecedentes**

Un uso frecuente de Aspose.Slides es crear, actualizar y guardar presentaciones de Microsoft PowerPoint (PPTX) como parte de un flujo de trabajo automatizado. Los usuarios de aplicaciones que emplean Aspose.Slides de esta manera tienen acceso a las presentaciones generadas, por lo que protegerlas contra la edición es una preocupación común. Es importante que las presentaciones generadas automáticamente mantengan su formato y contenido original.

Este artículo explica cómo están estructuradas las presentaciones y las diapositivas y cómo Aspose.Slides for Python puede aplicar protección a una presentación y eliminarla posteriormente. Proporciona a los desarrolladores una forma de controlar el uso de las presentaciones que sus aplicaciones generan.

## **Composición de una diapositiva**

Una diapositiva de presentación está compuesta por componentes como autoshapes, tablas, objetos OLE, shapes agrupados, marcos de imagen, marcos de video, conectores y otros elementos usados para crear una presentación. En Aspose.Slides for Python, cada elemento en una diapositiva está representado por un objeto que hereda de la clase [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

La estructura de PPTX es compleja, por lo que, a diferencia de PPT, donde se puede usar un bloqueo genérico para todos los tipos de shapes, diferentes tipos de shapes requieren bloqueos diferentes. La clase [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) es la clase de bloqueo genérica para PPTX. Los siguientes tipos de bloqueos son compatibles en Aspose.Slides for Python para PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) bloquea autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) bloquea shapes de conectores.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) bloquea objetos gráficos.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) bloquea shapes de grupo.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) bloquea marcos de imagen.  

Cualquier acción realizada sobre todos los objetos shape en un objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) se aplica a toda la presentación.

## **Aplicar y eliminar protección**

Aplicar protección garantiza que una presentación no pueda ser editada. Es una técnica útil para proteger el contenido de la presentación.

### **Aplicar protección a shapes PPTX**

Aspose.Slides for Python proporciona la clase [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) para trabajar con shapes en una diapositiva.

Como se mencionó anteriormente, cada clase de shape tiene una clase de bloqueo de shape asociada para la protección. Este artículo se centra en los bloqueos NoSelect, NoMove y NoResize. Estos bloqueos aseguran que los shapes no puedan ser seleccionados (mediante clics del mouse u otros métodos de selección) y que no puedan moverse ni cambiar de tamaño.

El ejemplo de código que sigue aplica protección a todos los tipos de shape en una presentación.
```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo PPTX.
with slides.Presentation("Sample.pptx") as presentation:
    # Recorriendo todas las diapositivas de la presentación.
    for slide in presentation.slides:
        # Recorriendo todas las formas de la diapositiva.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # Guardando el archivo de la presentación.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```


### **Eliminar protección**

Para desbloquear un shape, establezca el valor del bloqueo aplicado en `False`. El siguiente ejemplo de código muestra cómo desbloquear shapes en una presentación bloqueada.
```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo PPTX.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # Recorrer todas las diapositivas de la presentación.
    for slide in presentation.slides:
        # Recorrer todas las formas de la diapositiva.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # Guardar el archivo de la presentación.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```


### **Conclusión**

Aspose.Slides ofrece varias opciones para proteger shapes en una presentación. Puede bloquear un shape individual o iterar sobre todos los shapes de una presentación y bloquear cada uno para asegurar eficazmente todo el archivo. Puede eliminar la protección estableciendo el valor del bloqueo en `False`.

## **Preguntas frecuentes**

**¿Puedo combinar bloqueos de shape y protección con contraseña en la misma presentación?**

Sí. Los bloqueos limitan la edición de objetos dentro del archivo, mientras que la [password protection](/slides/es/python-net/password-protected-presentation/) controla el acceso para abrir y/o guardar cambios. Estos mecanismos se complementan y funcionan juntos.

**¿Puedo restringir la edición en diapositivas específicas sin afectar a las demás?**

Sí. Aplique bloqueos a los shapes de las diapositivas seleccionadas; las diapositivas restantes seguirán siendo editables.

**¿Los bloqueos de shape se aplican a objetos agrupados y conectores?**

Sí. Se admiten tipos de bloqueo dedicados para grupos, conectores, objetos gráficos y otros tipos de shape.