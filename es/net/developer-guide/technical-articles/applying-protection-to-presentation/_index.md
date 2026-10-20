---
title: Restringir la edición de presentaciones con bloqueos de forma en .NET
linktitle: Restringir la edición de presentaciones
type: docs
weight: 70
url: /es/net/applying-protection-to-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo bloquear y desbloquear formas en presentaciones PPTX con Aspose.Slides for .NET para restringir la selección, el movimiento, el cambio de tamaño y la agrupación."
---
## **Contexto**

Un uso común de Aspose.Slides for .NET es crear, actualizar y guardar presentaciones PowerPoint (PPTX) como parte de un flujo de trabajo automatizado. Cuando los usuarios reciben estas presentaciones, restringir los cambios en las formas puede ayudar a preservar el diseño y el contenido previstos.

Este artículo explica cómo se organizan las formas en las diapositivas y cómo aplicar y eliminar bloqueos de formas en una presentación PPTX. Estos bloqueos le permiten restringir operaciones de edición específicas en formas individuales.

## **Composición de una diapositiva**

Una diapositiva de una presentación se compone de componentes como formas automáticas, tablas, objetos OLE, formas agrupadas, marcos de imagen, marcos de video, conectores y otros elementos utilizados para crear una presentación. En Aspose.Slides for .NET, cada elemento de una diapositiva está representado por un objeto que implementa la interfaz [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) o hereda de una clase que lo hace.

Diferentes tipos de forma exponen distintas opciones de bloqueo. La interfaz [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) es la interfaz base para los bloqueos de forma. Aspose.Slides for .NET proporciona las siguientes interfaces de bloqueo:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) bloquea las formas automáticas.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) bloquea las formas de conector.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) bloquea los objetos gráficos.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) bloquea las formas agrupadas.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) bloquea los marcos de imagen.  

Para aplicar bloqueos en una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), recorra sus diapositivas y establezca los bloqueos apropiados en cada forma compatible.

## **Aplicar y eliminar protección**

Los bloqueos de forma restringen operaciones como seleccionar, mover y cambiar el tamaño de las formas. No hacen que toda la presentación sea no editable.

### **Aplicar protección a formas PPTX**

Aspose.Slides for .NET proporciona la interfaz [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) para trabajar con formas en una diapositiva.

El ejemplo establece [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) y [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) en `true` para las formas automáticas, con bloqueos equivalentes para las formas agrupadas, los conectores y los marcos de imagen. Los conectores utilizan [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) para el movimiento; los grupos también utilizan [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) para restringir la agrupación.

El ejemplo carga una presentación PPTX existente, verifica las formas en la colección de formas de cada diapositiva y guarda una copia con estas restricciones aplicadas. Las formas que no pertenecen a los cuatro tipos manejados se dejan sin cambios. El bucle no recorre las formas hijas dentro de un grupo.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Eliminar protección**

Para eliminar un bloqueo de forma, establezca su valor en `false`. El siguiente ejemplo carga una presentación con bloqueos de forma y elimina las restricciones de selección, movimiento y cambio de tamaño mediante [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) y [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). También elimina [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) y guarda una copia de la presentación. Otras configuraciones de bloqueo se dejan sin cambios.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Conclusión**

Aspose.Slides for .NET le permite restringir operaciones de edición específicas en formas individuales o aplicar las mismas restricciones en todas las diapositivas. Elija los bloqueos compatibles con cada tipo de forma y establezca sus valores en `false` cuando necesite eliminar esas restricciones.

## **Preguntas frecuentes**

**¿Puedo combinar bloqueos de forma y protección con contraseña en la misma presentación?**

Sí. Los bloqueos de forma restringen operaciones de edición específicas, mientras que la [protección con contraseña](/slides/es/net/password-protected-presentation/) puede restringir la apertura o modificación de la presentación. Puede utilizar ambos en el mismo archivo.

**¿Puedo restringir la edición en diapositivas específicas sin afectar a otras?**

Sí. Aplique bloqueos solo a las formas de las diapositivas seleccionadas. Esto no cambia la configuración de bloqueos en otras diapositivas.

**¿Cómo puedo aplicar bloqueos a formas individuales dentro de un grupo?**

Recorra la colección [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) del grupo y aplique los bloqueos apropiados a cada forma hija. Repita esto para cualquier grupo anidado. Los ejemplos anteriores procesan solo la colección de formas de la diapositiva, por lo que no establecen bloqueos en los miembros individuales del grupo.