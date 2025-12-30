---
title: Formas de presentación en grupo en PHP
linktitle: Grupo de formas
type: docs
weight: 40
url: /es/php-java/group/
keywords:
- forma de grupo
- grupo de formas
- agregar grupo
- texto alternativo
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprende a agrupar y desagrupar formas en presentaciones PowerPoint usando Aspose.Slides para PHP a través de Java — guía rápida, paso a paso, con código gratuito."
---

## **Añadir una forma de grupo**
Aspose.Slides admite trabajar con formas de grupo en diapositivas. Esta característica ayuda a los desarrolladores a crear presentaciones más completas. Aspose.Slides for PHP via Java permite agregar o acceder a formas de grupo. Es posible añadir formas a una forma de grupo añadida para completarla o acceder a cualquier propiedad de la forma de grupo. Para añadir una forma de grupo a una diapositiva usando Aspose.Slides for PHP via Java:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtener la referencia de una diapositiva mediante su índice
1. Añadir una forma de grupo a la diapositiva.
1. Añadir las formas a la forma de grupo añadida.
1. Guardar la presentación modificada como archivo PPTX.

El ejemplo a continuación añade una forma de grupo a una diapositiva.
```php
  # Instanciar la clase Presentation
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Acceder a la colección de formas de las diapositivas
    $slideShapes = $sld->getShapes();
    # Añadir una forma de grupo a la diapositiva
    $groupShape = $slideShapes->addGroupShape();
    # Añadir formas dentro de la forma de grupo añadida
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Añadir el marco de la forma de grupo
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
Este tema muestra pasos sencillos, completos con ejemplos de código, para añadir una forma de grupo y acceder a la propiedad AltText de las formas de grupo en diapositivas. Para acceder a AltText de una forma de grupo en una diapositiva usando Aspose.Slides for PHP via Java:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que representa el archivo PPTX.
1. Obtener la referencia de una diapositiva mediante su índice.
1. Acceder a la colección de formas de la diapositiva.
1. Acceder a la forma de grupo.
1. Acceder a la propiedad [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--).

El ejemplo a continuación accede al texto alternativo de la forma de grupo.
```php
  # Instanciar la clase Presentation que representa el archivo PPTX
  $pres = new Presentation("AltText.pptx");
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Acceder a la colección de formas de las diapositivas
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Acceder a la forma de grupo.
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


## **FAQ**

**¿Se admite la agrupación anidada (un grupo dentro de otro grupo)?**

Sí. [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) tiene un método [getParentGroup](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getparentgroup/) que indica directamente el soporte de jerarquía (un grupo puede ser hijo de otro grupo).

**¿Cómo controlo el orden Z del grupo respecto a otros objetos en la diapositiva?**

Utilice el método [getZOrderPosition](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) de [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) para inspeccionar su posición en la pila de visualización.

**¿Puedo impedir mover/editar/desagrupar?**

Sí. La sección de bloqueo del grupo está expuesta a través de [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/getgroupshapelock/), que permite restringir operaciones sobre el objeto.