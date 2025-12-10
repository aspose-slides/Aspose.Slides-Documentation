---
title: Evitar ediciones de presentación con bloqueos de forma
linktitle: Evitar ediciones de presentación
type: docs
weight: 60
url: /es/java/applying-protection-to-presentation/
keywords:
- evitar ediciones
- proteger de la edición
- bloquear forma
- bloquear posición
- bloquear selección
- bloquear tamaño
- bloquear agrupación
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Descubra cómo Aspose.Slides for Java bloquea o desbloquea formas en archivos PPT, PPTX y ODP, asegurando presentaciones mientras permite ediciones controladas y una entrega más rápida."
---

## **Antecedentes**

Un uso común de Aspose.Slides es crear, actualizar y guardar presentaciones de Microsoft PowerPoint (PPTX) como parte de un flujo de trabajo automatizado. Los usuarios de aplicaciones que emplean Aspose.Slides de esta manera tienen acceso a las presentaciones generadas, por lo que protegerlas contra la edición es una preocupación frecuente. Es importante que las presentaciones generadas automáticamente mantengan su formato y contenido originales.

Este artículo explica cómo están estructuradas las presentaciones y diapositivas y cómo Aspose.Slides for Java puede aplicar protección a una presentación y luego eliminarla. Proporciona a los desarrolladores una forma de controlar cómo se usan las presentaciones que sus aplicaciones generan.

## **Composición de una diapositiva**

Una diapositiva de presentación se compone de componentes como formas automáticas, tablas, objetos OLE, formas agrupadas, marcos de imagen, marcos de video, conectores y otros elementos utilizados para crear una presentación. En Aspose.Slides for Java, cada elemento en una diapositiva está representado por un objeto que implementa la interfaz [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) o hereda de una clase que lo hace.

La estructura de PPTX es compleja, por lo que, a diferencia de PPT, donde se puede usar un bloqueo genérico para todos los tipos de formas, diferentes tipos de forma requieren bloqueos distintos. La interfaz [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) es la clase de bloqueo genérica para PPTX. Los siguientes tipos de bloqueos son compatibles en Aspose.Slides for Java para PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) bloquea formas automáticas.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) bloquea formas de conector.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) bloquea objetos gráficos.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) bloquea formas agrupadas.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) bloquea marcos de imagen.  

Cualquier acción realizada sobre todos los objetos de forma en un objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) se aplica a toda la presentación.

## **Aplicar y eliminar protección**

Aplicar protección garantiza que una presentación no pueda ser editada. Es una técnica útil para proteger el contenido de la presentación.

### **Aplicar protección a formas PPTX**

Aspose.Slides for Java proporciona la interfaz [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) para trabajar con formas en una diapositiva.

Como se mencionó anteriormente, cada clase de forma tiene una clase de bloqueo de forma asociada para la protección. Este artículo se centra en los bloqueos NoSelect, NoMove y NoResize. Estos bloqueos aseguran que las formas no puedan ser seleccionadas (mediante clics del mouse u otros métodos de selección) y que no puedan moverse ni redimensionarse.

El ejemplo de código que sigue aplica protección a todos los tipos de forma en una presentación.
```java
// Instanciar la clase Presentation que representa un archivo PPTX.
Presentation presentation = new Presentation("Sample.pptx");

// Recorrer todas las diapositivas de la presentación.
for (ISlide slide : presentation.getSlides()) {

    // Recorrer todas las formas en la diapositiva.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Convertir la forma a una autoshape y obtener su bloqueo de forma.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // Convertir la forma a una shape de grupo y obtener su bloqueo de forma.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // Convertir la forma a una forma conector y obtener su bloqueo de forma.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // Convertir la forma a un marco de imagen y obtener su bloqueo de forma.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// Guardar el archivo de presentación.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **Eliminar protección**

Para desbloquear una forma, establezca el valor del bloqueo aplicado a `false`. El siguiente ejemplo de código muestra cómo desbloquear formas en una presentación bloqueada.
```java
// Instanciar la clase Presentation que representa un archivo PPTX.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// Recorrer todas las diapositivas de la presentación.
for (ISlide slide : presentation.getSlides()) {

    // Recorrer todas las formas en la diapositiva.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Convertir la forma a una autoshape y obtener su bloqueo de forma.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // Convertir la forma a una forma de grupo y obtener su bloqueo de forma.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // Convertir la forma a una forma conector y obtener su bloqueo de forma.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // Convertir la forma a un marco de imagen y obtener su bloqueo de forma.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// Guardar el archivo de presentación.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Conclusión**

Aspose.Slides ofrece varias opciones para proteger formas en una presentación. Puede bloquear una forma individual o iterar a través de todas las formas en una presentación y bloquear cada una para asegurar efectivamente todo el archivo. Puede eliminar la protección estableciendo el valor del bloqueo a `false`.

## **Preguntas frecuentes**

**¿Puedo combinar bloqueos de forma y protección con contraseña en la misma presentación?**

Sí. Los bloqueos limitan la edición de objetos dentro del archivo, mientras que la [protección con contraseña](/slides/es/java/password-protected-presentation/) controla el acceso para abrir y/o guardar cambios. Estos mecanismos se complementan y funcionan juntos.

**¿Puedo restringir la edición en diapositivas específicas sin afectar a las demás?**

Sí. Aplique bloqueos a las formas en las diapositivas seleccionadas; las diapositivas restantes seguirán siendo editables.

**¿Los bloqueos de forma se aplican a objetos agrupados y conectores?**

Sí. Se admiten tipos de bloqueo dedicados para grupos, conectores, objetos gráficos y otros tipos de forma.