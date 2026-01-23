---
title: Formas de presentación de grupos en PHP
linktitle: Grupo de formas
type: docs
weight: 40
url: /es/php-java/group/
keywords:
- forma de grupo
- grupo de formas
- añadir grupo
- texto alternativo
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprende a agrupar y desagrupar formas en presentaciones de PowerPoint usando Aspose.Slides para PHP a través de Java — guía rápida, paso a paso, con código gratuito."
---

## **Añadir un Group Shape**
Aspose.Slides admite trabajar con group shapes en diapositivas. Esta característica ayuda a los desarrolladores a crear presentaciones más completas. Aspose.Slides for PHP via Java permite añadir o acceder a group shapes. Es posible agregar formas a un group shape añadido para completarlo o acceder a cualquier propiedad del group shape. Para añadir un group shape a una diapositiva usando Aspose.Slides for PHP via Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenga la referencia de una diapositiva mediante su índice
1. Añada un group shape a la diapositiva.
1. Añada las formas al group shape añadido.
1. Guarde la presentación modificada como un archivo PPTX.

El ejemplo siguiente añade un group shape a una diapositiva.
```php
  # Instanciar la clase Presentation
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Acceder a la colección de shapes de las diapositivas
    $slideShapes = $sld->getShapes();
    # Añadir un group shape a la diapositiva
    $groupShape = $slideShapes->addGroupShape();
    # Añadir shapes dentro del group shape añadido
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Añadir el marco del group shape
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Guardar el archivo PPTX en disco
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Acceder a la propiedad AltText**
Este tema muestra pasos sencillos, acompañados de ejemplos de código, para añadir un group shape y acceder a la propiedad AltText de los group shapes en diapositivas. Para acceder al AltText de un group shape en una diapositiva usando Aspose.Slides for PHP via Java:

1. Instancie la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que representa un archivo PPTX.
1. Obtenga la referencia de una diapositiva mediante su índice.
1. Acceda a la colección de shapes de la diapositiva.
1. Acceda al group shape.
1. Acceda a la propiedad [Alternative Text](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getAlternativeText).

El ejemplo siguiente accede al texto alternativo de un group shape.
```php
  # Instanciar la clase Presentation que representa un archivo PPTX
  $pres = new Presentation("AltText.pptx");
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Acceder a la colección de shapes de las diapositivas
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Acceder al group shape.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Acceder a la propiedad AltText
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Se admite la agrupación anidada (un group dentro de otro group)?**

Sí. [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) tiene un método [getParentGroup](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getparentgroup/) que indica directamente el soporte de jerarquía (un group puede ser hijo de otro group).

**¿Cómo controlo el orden Z del group respecto a otros objetos en la diapositiva?**

Utilice el método [getZOrderPosition](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) de [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) para inspeccionar su posición en la pila de visualización.

**¿Puedo impedir mover/editar/desagrupar?**

Sí. La sección de bloqueo del group se expone mediante [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/getgroupshapelock/), lo que le permite restringir operaciones sobre el objeto.