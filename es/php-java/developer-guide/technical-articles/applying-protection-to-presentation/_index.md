---
title: Restringir la edición de presentaciones con bloqueos de forma en PHP
linktitle: Restringir la edición de presentaciones
type: docs
weight: 60
url: /es/php-java/applying-protection-to-presentation/
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
- PHP
- Aspose.Slides
description: "Aprenda cómo bloquear y desbloquear formas en presentaciones PPTX con Aspose.Slides para PHP via Java para restringir la selección, el movimiento, el cambio de tamaño y la agrupación."
---
## **Visión general**

Un uso común de Aspose.Slides for PHP via Java es crear, actualizar y guardar presentaciones PowerPoint (PPTX) como parte de un flujo de trabajo automatizado. Cuando los usuarios reciben estas presentaciones, restringir los cambios en las formas puede ayudar a preservar el diseño y el contenido previstos.

Este artículo explica cómo se organizan las formas en las diapositivas y cómo aplicar y quitar bloqueos de forma en una presentación PPTX. Estos bloqueos le permiten restringir operaciones de edición específicas en formas individuales.

## **Composición de una diapositiva**

Una diapositiva de presentación se compone de componentes como formas automáticas, tablas, objetos OLE, formas agrupadas, marcos de imagen, marcos de vídeo, conectores y otros elementos utilizados para crear una presentación. En Aspose.Slides for PHP via Java, cada elemento de una diapositiva está representado por un objeto que hereda de la clase [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

Diferentes tipos de forma exponen distintas opciones de bloqueo. La clase [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) es la clase base para los bloqueos de forma. Aspose.Slides for PHP via Java proporciona las siguientes clases de bloqueo:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) bloquea formas automáticas.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) bloquea formas de conector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) bloquea objetos gráficos.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) bloquea formas agrupadas.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) bloquea marcos de imagen.  

Para aplicar bloqueos en una [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), recorra sus diapositivas y establezca los bloqueos apropiados en cada forma admitida.

## **Aplicar y quitar protección**

Los bloqueos de forma restringen operaciones como seleccionar, mover y cambiar el tamaño de las formas. No hacen que toda la presentación sea ineditable.

### **Aplicar protección a formas PPTX**

Aspose.Slides for PHP via Java proporciona la clase [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) para trabajar con formas en una diapositiva.

El ejemplo llama a [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) y [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) con `true` para formas automáticas, con bloqueos equivalentes para formas agrupadas, conectores y marcos de imagen. Los conectores utilizan [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) para el movimiento; los grupos también utilizan [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) para restringir la agrupación.

El ejemplo carga una presentación PPTX existente, comprueba las formas en la colección de formas de cada diapositiva y guarda una copia con estas restricciones aplicadas. Las formas que no pertenecen a los cuatro tipos manejados se dejan sin cambios. El bucle no recorre las formas hijas dentro de un grupo.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Quitar protección**

Para quitar un bloqueo de forma, establezca su valor a `false`. El siguiente ejemplo carga una presentación con bloqueos de forma y elimina las restricciones de selección, movimiento y cambio de tamaño mediante [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) y [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). También elimina la restricción de agrupación pasando `false` a [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) y guarda una copia de la presentación. Otras configuraciones de bloqueo permanecen sin cambios.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Conclusión**

Aspose.Slides for PHP via Java le permite restringir operaciones de edición específicas en formas individuales o aplicar las mismas restricciones en todas las diapositivas. Elija los bloqueos compatibles con cada tipo de forma y establezca sus valores a `false` cuando necesite eliminar esas restricciones.

## **Preguntas frecuentes**

**¿Puedo combinar bloqueos de forma y protección con contraseña en la misma presentación?**

Sí. Los bloqueos de forma restringen operaciones específicas de edición, mientras que [protección con contraseña](/slides/es/php-java/password-protected-presentation/) puede restringir la apertura o modificación de la presentación. Puede usar ambos en el mismo archivo.

**¿Puedo restringir la edición en diapositivas específicas sin afectar a otras?**

Sí. Aplique bloqueos solo a las formas de las diapositivas seleccionadas. Esto no modifica la configuración de bloqueos de las demás diapositivas.

**¿Cómo puedo aplicar bloqueos a formas individuales dentro de un grupo?**

Itere a través de la colección devuelta por el método [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) del grupo y aplique los bloqueos apropiados a cada forma hija. Repita esto para cualquier grupo anidado. Los ejemplos anteriores procesan solo la colección de formas de la diapositiva, por lo que no establecen bloqueos en miembros individuales del grupo.