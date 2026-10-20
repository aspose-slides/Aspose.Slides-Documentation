---
title: Restringir la edición de presentaciones con bloqueos de forma en Java
linktitle: Restringir la edición de presentaciones
type: docs
weight: 60
url: /es/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Aprenda a bloquear y desbloquear formas en presentaciones PPTX con Aspose.Slides para Java para restringir la selección, el movimiento, el cambio de tamaño y la agrupación."
---
## **Contexto**

Un uso frecuente de Aspose.Slides for Java es crear, actualizar y guardar presentaciones PowerPoint (PPTX) como parte de un flujo de trabajo automatizado. Cuando los usuarios reciben estas presentaciones, restringir los cambios en las formas puede ayudar a preservar el diseño y el contenido previstos.

Este artículo explica cómo se organizan las formas en las diapositivas y cómo aplicar y eliminar bloqueos de formas en una presentación PPTX. Estos bloqueos le permiten restringir operaciones de edición específicas en formas individuales.

## **Composición de una diapositiva**

Una diapositiva de una presentación se compone de componentes como autoshapes, tablas, objetos OLE, formas agrupadas, marcos de imagen, marcos de vídeo, conectores y otros elementos utilizados para crear una presentación. En Aspose.Slides for Java, cada elemento de una diapositiva está representado por un objeto que implementa la interfaz [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) o hereda de una clase que lo hace.

Los distintos tipos de forma exponen diferentes opciones de bloqueo. La interfaz [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) es la interfaz base para los bloqueos de forma. Aspose.Slides for Java proporciona las siguientes interfaces de bloqueo:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) bloquea autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) bloquea formas de conector.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) bloquea objetos gráficos.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) bloquea formas de grupo.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) bloquea marcos de imagen.  

Para aplicar bloqueos a lo largo de una [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), itere a través de sus diapositivas y establezca los bloqueos apropiados en cada forma compatible.

## **Aplicar y eliminar protección**

Los bloqueos de forma restringen operaciones como seleccionar, mover y cambiar el tamaño de las formas. No hacen que toda la presentación sea no editable.

### **Aplicar protección a formas PPTX**

Aspose.Slides for Java proporciona la interfaz [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) para trabajar con formas en una diapositiva.

El ejemplo llama a [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), y [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) con `true` para autoshapes, con bloqueos equivalentes para formas de grupo, conectores y marcos de imagen. Los conectores usan [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) para el movimiento; los grupos también usan [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) para restringir la agrupación.

El ejemplo carga una presentación PPTX existente, comprueba las formas en la colección de formas de cada diapositiva y guarda una copia con estas restricciones aplicadas. Las formas que no pertenecen a los cuatro tipos manejados se dejan sin cambios. El bucle no recorre las formas hijas dentro de un grupo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Eliminar protección**

Para eliminar un bloqueo de forma, establezca su valor a `false`. El siguiente ejemplo carga una presentación con bloqueos de forma y despeja las restricciones de selección, movimiento y cambio de tamaño a través de [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/), y [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). También elimina la restricción de agrupación pasando `false` a [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) y guarda una copia de la presentación. Otras configuraciones de bloqueo se dejan sin cambios.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Conclusión**

Aspose.Slides for Java le permite restringir operaciones de edición específicas en formas individuales o aplicar las mismas restricciones en todas las diapositivas. Elija los bloqueos admitidos por cada tipo de forma y establezca sus valores a `false` cuando necesite eliminar esas restricciones.

## **Preguntas frecuentes**

**¿Puedo combinar bloqueos de forma y protección con contraseña en la misma presentación?**

Sí. Los bloqueos de forma restringen operaciones de edición específicas, mientras que [protección con contraseña](/slides/es/java/password-protected-presentation/) puede restringir la apertura o la modificación de la presentación. Puede usar ambos en el mismo archivo.

**¿Puedo restringir la edición en diapositivas específicas sin afectar a otras?**

Sí. Aplique los bloqueos solo a las formas de las diapositivas seleccionadas. Esto no cambia la configuración de bloqueos en otras diapositivas.

**¿Cómo puedo aplicar bloqueos a formas individuales dentro de un grupo?**

Itere a través de la colección devuelta por el método [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) del grupo y aplique los bloqueos apropiados a cada forma hija. Repita esto para cualquier grupo anidado. Los ejemplos anteriores procesan solo la colección de formas de la diapositiva, por lo que no establecen bloqueos en los miembros individuales del grupo.