---
title: Restringir la edición de presentaciones con bloqueos de forma en Node.js
linktitle: Restringir la edición de presentaciones
type: docs
weight: 60
url: /es/nodejs-java/applying-protection-to-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda cómo bloquear y desbloquear formas en presentaciones PPTX con Aspose.Slides for Node.js via Java para restringir la selección, el movimiento, el cambio de tamaño y la agrupación."
---
## **Resumen**

Un uso frecuente de Aspose.Slides for Node.js via Java es crear, actualizar y guardar presentaciones PowerPoint (PPTX) como parte de un flujo de trabajo automatizado. Cuando los usuarios reciben estas presentaciones, restringir los cambios en las formas puede ayudar a preservar el diseño y el contenido previstos.

Este artículo explica cómo se organizan las formas en las diapositivas y cómo aplicar y eliminar bloqueos de forma en una presentación PPTX. Estos bloqueos le permiten restringir operaciones de edición específicas en formas individuales.

## **Composición de una diapositiva**

Una diapositiva de una presentación está compuesta por componentes como autoshapes, tablas, objetos OLE, formas agrupadas, marcos de imagen, marcos de vídeo, conectores y otros elementos utilizados para crear una presentación. En Aspose.Slides for Node.js via Java, cada elemento de una diapositiva está representado por un objeto que hereda de la clase [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) .

Los distintos tipos de forma exponen diferentes opciones de bloqueo. La clase [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) es la clase base para los bloqueos de forma. Aspose.Slides for Node.js via Java proporciona las siguientes clases de bloqueo:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) bloquea los autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) bloquea las formas conectoras.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) bloquea los objetos gráficos.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) bloquea las formas agrupadas.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) bloquea los marcos de imagen.  

Para aplicar bloqueos en una [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), recorra sus diapositivas y establezca los bloqueos apropiados en cada forma admitida.

## **Aplicar y eliminar protección**

Los bloqueos de forma restringen operaciones como seleccionar, mover y cambiar el tamaño de las formas. No hacen que toda la presentación sea ineditable.

### **Aplicar protección a formas PPTX**

Aspose.Slides for Node.js via Java proporciona la clase [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) para trabajar con formas en una diapositiva.

El ejemplo llama a [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) y [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) con `true` para los autoshapes, con bloqueos equivalentes para las formas agrupadas, los conectores y los marcos de imagen. Los conectores utilizan [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) para el movimiento; los grupos también usan [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) para restringir la agrupación.

El ejemplo carga una presentación PPTX existente, comprueba las formas en la colección de formas de cada diapositiva y guarda una copia con estas restricciones aplicadas. Las formas que no pertenecen a los cuatro tipos gestionados se dejan sin cambios. El bucle no recorre las formas hijas dentro de un grupo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Eliminar protección**

Para eliminar un bloqueo de forma, establezca su valor a `false`. El siguiente ejemplo carga una presentación con bloqueos de forma y elimina las restricciones de selección, movimiento y cambio de tamaño mediante [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) y [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). También elimina la restricción de agrupación pasando `false` a [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) y guarda una copia de la presentación. Los demás ajustes de bloqueo se dejan sin cambios.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Conclusión**

Aspose.Slides for Node.js via Java le permite restringir operaciones de edición específicas en formas individuales o aplicar las mismas restricciones en todas las diapositivas. Elija los bloqueos compatibles con cada tipo de forma y establezca sus valores a `false` cuando necesite eliminar esas restricciones.

## **Preguntas frecuentes**

**¿Puedo combinar bloqueos de forma y protección con contraseña en la misma presentación?**

Sí. Los bloqueos de forma restringen operaciones de edición específicas, mientras que la [protección con contraseña](/slides/es/nodejs-java/password-protected-presentation/) puede restringir la apertura o modificación de la presentación. Puede utilizar ambos en el mismo archivo.

**¿Puedo restringir la edición en diapositivas específicas sin afectar a otras?**

Sí. Aplique los bloqueos solo a las formas de las diapositivas seleccionadas. Esto no modifica la configuración de bloqueos en otras diapositivas.

**¿Cómo puedo aplicar bloqueos a formas individuales dentro de un grupo?**

Itere a través de la colección devuelta por el método [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) del grupo y aplique los bloqueos apropiados a cada forma hija. Repita esto para los grupos anidados. Los ejemplos anteriores procesan solo la colección de formas de la diapositiva, por lo que no establecen bloqueos en los miembros individuales del grupo.