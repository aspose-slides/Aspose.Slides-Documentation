---
title: Restringir ediciones de la presentación con bloqueos de forma en PHP
linktitle: Restringir ediciones de la presentación
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
description: "Aprenda cómo bloquear y desbloquear formas en presentaciones PPTX con Aspose.Slides for PHP via Java para restringir la selección, el movimiento, el cambio de tamaño y la agrupación."
---
## **Visión general**

Un uso común de Aspose.Slides for PHP via Java es crear, actualizar y guardar presentaciones de PowerPoint (PPTX) como parte de un flujo de trabajo automatizado. Cuando los usuarios reciben estas presentaciones, restringir los cambios en las formas puede ayudar a preservar el diseño y el contenido previstos.

Este artículo explica cómo se organizan las formas en las diapositivas y cómo aplicar y quitar bloqueos de forma en una presentación PPTX. Estos bloqueos le permiten restringir operaciones de edición específicas en formas individuales.

## **Composición de una diapositiva**

Una diapositiva de presentación se compone de componentes como formas automáticas, tablas, objetos OLE, formas agrupadas, marcos de imagen, marcos de video, conectores y otros elementos utilizados para crear una presentación. En Aspose.Slides for PHP via Java, cada elemento de una diapositiva está representado por un objeto que hereda de la clase [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

Diferentes tipos de forma exponen distintas opciones de bloqueo. La clase [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) es la clase base para los bloqueos de forma. Aspose.Slides for PHP via Java proporciona las siguientes clases de bloqueo:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) bloquea formas automáticas.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) bloquea formas de conector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) bloquea objetos gráficos.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) bloquea formas agrupadas.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) bloquea marcos de imagen.  

Para aplicar bloqueos en una [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), recorra sus diapositivas y establezca los bloqueos apropiados en cada forma compatible.

## **Aplicar y eliminar protección**

Los editores de presentaciones compatibles utilizan bloqueos de forma para restringir operaciones de edición individuales. El cifrado de archivos y la protección contra escritura a nivel de documento son configuraciones de [configuraciones de protección de presentación](/slides/es/php-java/password-protected-presentation/) independientes.

### **Aplicar protección a formas PPTX**

Aspose.Slides for PHP via Java proporciona la clase [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) para trabajar con formas en una diapositiva.

El ejemplo llama a [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) y [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) con `true` para las formas automáticas, con bloqueos equivalentes para formas agrupadas, conectores y marcos de imagen. Los conectores utilizan [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) para el movimiento; los grupos también utilizan [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) para restringir la agrupación.

El ejemplo carga una presentación PPTX existente, verifica las formas en la colección de formas de cada diapositiva y guarda una copia con estas restricciones aplicadas. Las formas que no pertenecen a los cuatro tipos manejados se dejan sin cambios. El bucle no recorre las formas secundarias dentro de un grupo.

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

### **Eliminar protección**

Para eliminar un bloqueo de forma, establezca su valor a `false`. El siguiente ejemplo carga una presentación con bloqueos de forma y elimina las restricciones de selección, movimiento y redimensionado mediante [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) y [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). También elimina la restricción de agrupación pasando `false` a [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) y guarda una copia de la presentación. Otras configuraciones de bloqueo se mantienen sin cambios.

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

### **Conservar recorte de imagen**

Coloque una foto llamada `photo.jpg` en el directorio de trabajo. El ejemplo recorta un 12% por la izquierda y un 8% por la derecha, luego llama a [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) en el bloqueo del marco de imagen. Pasar `true` restringe recortes posteriores y conserva el recorte existente.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` almacena el bloqueo de recorte como `true`. En PowerPoint, el comando **Recortar** está deshabilitado cuando la foto está seleccionada.

### **Mantener un diagrama agrupado**

El ejemplo agrupa un rectángulo y una flecha, luego llama a [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) en el bloqueo del grupo para mantener los componentes del diagrama juntos. Otras ediciones, como mover el grupo o cambiar el relleno de un componente, siguen disponibles.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` almacena el bloqueo de desagrupación como `true`. En PowerPoint, el comando **Ungroup** está deshabilitado cuando todo el diagrama está seleccionado.

### **Informar bloqueos de forma existentes**

Para revisar una plantilla, ábrala y lea el objeto de bloqueo de cada forma. El método [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) devuelve `true` cuando todas las banderas de ese objeto están desactivadas y `false` cuando al menos una está habilitada. Un grupo y sus hijos tienen objetos de bloqueo separados, por lo que debe inspeccionar los hijos incluso cuando el grupo no tiene bloqueos.

Este ejemplo verifica el movimiento de formas automáticas, marcos de imagen y grupos. También verifica el recorte de imágenes y la desagrupación de los grupos. El informe enumera las banderas habilitadas que reconoce y marca los tipos de forma que no inspecciona.

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

Supongamos que la diapositiva 1 de `Sample.pptx` contiene un grupo llamado `Layout` con la desagrupación bloqueada, una foto llamada `Photo` dentro de él con el recorte bloqueado, y un rectángulo desbloqueado llamado `Free`. El informe omite `Free` y muestra estas dos líneas:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

El informe lee las banderas de edición a nivel de forma almacenadas sin modificarlas ni guardar la presentación. La protección contra escritura a nivel de documento es una configuración independiente, y la aplicación de cada bandera depende del editor.

## **Conclusión**

Aspose.Slides for PHP via Java le permite restringir operaciones de edición específicas en formas individuales o aplicar las mismas restricciones en todas las diapositivas. Elija los bloqueos compatibles con cada tipo de forma y establezca sus valores a `false` cuando necesite eliminar esas restricciones.

## **Preguntas frecuentes**

**¿Puedo combinar bloqueos de forma y protección con contraseña en la misma presentación?**

Sí. Los bloqueos de forma restringen operaciones de edición específicas, mientras que la [protección con contraseña](/slides/es/php-java/password-protected-presentation/) puede restringir la apertura o modificación de la presentación. Puede usar ambos en el mismo archivo.

**¿Puedo restringir la edición en diapositivas específicas sin afectar a otras?**

Sí. Aplique los bloqueos solo a las formas en las diapositivas seleccionadas. Esto no modifica la configuración de bloqueos en otras diapositivas.

**¿Cómo puedo aplicar bloqueos a formas individuales dentro de un grupo?**

Recorra la colección devuelta por el método [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) del grupo y aplique los bloqueos apropiados a cada forma hija. Repita esto para cualquier grupo anidado, siguiendo el recorrido del ejemplo de informe.