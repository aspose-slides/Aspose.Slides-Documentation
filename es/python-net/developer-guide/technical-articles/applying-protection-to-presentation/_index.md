---
title: Restringir la edición de presentaciones con bloqueos de forma en Python
linktitle: Restringir la edición de presentaciones
type: docs
weight: 70
url: /es/python-net/applying-protection-to-presentation/
keywords:
- evitar ediciones
- proteger contra la edición
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
## **Contexto**

Un uso común de Aspose.Slides for Python via .NET es crear, actualizar y guardar presentaciones PowerPoint (PPTX) como parte de un flujo de trabajo automatizado. Cuando los usuarios reciben estas presentaciones, restringir los cambios en las formas puede ayudar a preservar el diseño y contenido previstos.

Este artículo explica cómo se organizan las formas en las diapositivas y cómo aplicar y eliminar bloqueos de forma en una presentación PPTX. Estos bloqueos le permiten restringir operaciones de edición específicas en formas individuales.

## **Composición de una diapositiva**

Una diapositiva de presentación está compuesta por componentes como autoshapes, tablas, objetos OLE, formas agrupadas, marcos de imágenes, marcos de vídeo, conectores y otros elementos utilizados para construir una presentación. En Aspose.Slides for Python via .NET, cada elemento en una diapositiva está representado por un objeto que hereda de la clase [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

Los diferentes tipos de forma exponen diferentes opciones de bloqueo. La clase [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) es la clase base para los bloqueos de forma. Aspose.Slides for Python via .NET proporciona las siguientes clases de bloqueo:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) bloquea las formas automáticas.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) bloquea los conectores.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) bloquea los objetos gráficos.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) bloquea los grupos de forma.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) bloquea los marcos de imagen.  

Para aplicar bloqueos en una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), recorra sus diapositivas y establezca los bloqueos apropiados en cada forma admitida.

## **Aplicar y eliminar protección**

Los editores de presentaciones compatibles usan bloqueos de forma para restringir operaciones de edición individuales. La encriptación de archivos y la protección contra escritura a nivel de documento son [ajustes de protección de la presentación](/slides/es/python-net/password-protected-presentation/).

### **Aplicar protección a formas PPTX**

Aspose.Slides for Python via .NET proporciona la clase [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) para trabajar con formas en una diapositiva.

El ejemplo establece [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), y [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) a `True` para las autoshapes, con bloqueos equivalentes para grupos de forma, conectores y marcos de imagen. Los conectores usan [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) para el movimiento; los grupos también usan [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) para restringir la agrupación.

El ejemplo carga una presentación PPTX existente, comprueba las formas en la colección de formas de cada diapositiva y guarda una copia con estas restricciones aplicadas. Las formas fuera de los cuatro tipos tratados se dejan sin cambios. El bucle no recorre las formas hijas dentro de un grupo.

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

Para eliminar un bloqueo de forma, establezca su valor a `False`. El siguiente ejemplo carga una presentación con bloqueos de forma y elimina las restricciones de selección, movimiento y cambio de tamaño a través de [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), y [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). También elimina [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) y guarda una copia de la presentación. Otras configuraciones de bloqueo se dejan sin cambios.

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

### **Conservar un recorte de imagen**

Coloque una foto llamada `photo.jpg` en el directorio de trabajo. El ejemplo recorta un 12% por la izquierda y un 8% por la derecha, luego establece [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) en el marco de imagen. Esta bandera restringe futuros recortes y conserva el recorte existente.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` almacena el bloqueo de recorte como `True`. En PowerPoint, el comando **Crop** está deshabilitado cuando la foto está seleccionada.

### **Mantener un diagrama agrupado**

El ejemplo agrupa un rectángulo y una flecha, luego establece [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) en el propio grupo para mantener los componentes del diagrama juntos. Otras ediciones, como mover el grupo o cambiar el relleno de un componente, siguen disponibles.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` almacena el bloqueo de desagrupación como `True`. En PowerPoint, el comando **Ungroup** está deshabilitado cuando todo el diagrama está seleccionado.

### **Informar bloqueos de forma existentes**

Para revisar una plantilla, ábrala y lea el objeto de bloqueo de cada forma. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) es `True` cuando todas las banderas de ese objeto están desactivadas y `False` cuando al menos una está activada. Un grupo y sus hijos tienen objetos de bloqueo independientes, por lo que inspeccione los hijos incluso cuando el grupo no tenga bloqueos.

Este ejemplo comprueba el movimiento de autoshapes, marcos de imagen y grupos, el recorte de imágenes y la desagrupación de grupos. Informa de las banderas que reconoce y marca los tipos de forma que no inspecciona.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

Supongamos que la diapositiva 1 de `Sample.pptx` contiene un grupo llamado `Layout` con desagrupación bloqueada, una imagen llamada `Photo` dentro de él con recorte bloqueado y un rectángulo sin bloqueo llamado `Free`. El informe omite `Free` e imprime estas dos líneas:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

El informe lee las banderas de edición a nivel de forma almacenadas sin modificarlas ni guardar la presentación. La protección contra escritura a nivel de documento es una configuración separada, y la aplicación de cada bandera depende del editor.

### **Conclusión**

Aspose.Slides for Python via .NET le permite restringir operaciones de edición específicas en formas individuales o aplicar las mismas restricciones en todas las diapositivas. Elija los bloqueos compatibles con cada tipo de forma y establezca sus valores a `False` cuando necesite eliminar esas restricciones.

## **FAQ**

**¿Puedo combinar bloqueos de forma y protección con contraseña en la misma presentación?**

Sí. Los bloqueos de forma restringen operaciones de edición específicas, mientras que la [protección con contraseña](/slides/es/python-net/password-protected-presentation/) puede restringir la apertura o modificación de la presentación. Puede usar ambos en el mismo archivo.

**¿Puedo restringir la edición en diapositivas específicas sin afectar a otras?**

Sí. Aplique bloqueos solo a las formas de las diapositivas seleccionadas. Esto no cambia la configuración de bloqueo en otras diapositivas.

**¿Cómo puedo aplicar bloqueos a formas individuales dentro de un grupo?**

Recorra la colección de [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) del grupo y aplique los bloqueos apropiados a cada forma hija. Repita esto para cualquier grupo anidado, siguiendo el recorrido del ejemplo de informe.