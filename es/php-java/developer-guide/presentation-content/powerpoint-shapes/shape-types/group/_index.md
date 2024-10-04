---
title: Grupo
type: docs
weight: 40
url: /php-java/group/
---

## **Agregar Forma de Grupo**
Aspose.Slides admite el trabajo con formas de grupo en diapositivas. Esta característica ayuda a los desarrolladores a soportar presentaciones más ricas. Aspose.Slides para PHP a través de Java admite agregar o acceder a formas de grupo. Es posible agregar formas a una forma de grupo agregada para poblarla o acceder a cualquier propiedad de la forma de grupo. Para agregar una forma de grupo a una diapositiva utilizando Aspose.Slides para PHP a través de Java:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtén la referencia de una diapositiva utilizando su índice.
1. Agrega una forma de grupo a la diapositiva.
1. Agrega las formas a la forma de grupo agregada.
1. Guarda la presentación modificada como un archivo PPTX.

El siguiente ejemplo agrega una forma de grupo a una diapositiva.

```php
  # Instanciar la clase Presentation
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Accediendo a la colección de formas de las diapositivas
    $slideShapes = $sld->getShapes();
    # Agregando una forma de grupo a la diapositiva
    $groupShape = $slideShapes->addGroupShape();
    # Agregando formas dentro de la forma de grupo agregada
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Agregando marco de forma de grupo
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Escribir el archivo PPTX en disco
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acceder a la Propiedad AltText**
Este tema muestra pasos simples, completos con ejemplos de código, para agregar una forma de grupo y acceder a la propiedad AltText de las formas de grupo en las diapositivas. Para acceder al AltText de una forma de grupo en una diapositiva utilizando Aspose.Slides para PHP a través de Java:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que representa el archivo PPTX.
1. Obtén la referencia de una diapositiva utilizando su índice.
1. Accediendo a la colección de formas de las diapositivas.
1. Accediendo a la forma de grupo.
1. Accediendo a la propiedad [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--).

El siguiente ejemplo accede al texto alternativo de la forma de grupo.

```php
  # Instanciar la clase Presentation que representa el archivo PPTX
  $pres = new Presentation("AltText.pptx");
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Accediendo a la colección de formas de las diapositivas
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Accediendo a la forma de grupo.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Accediendo a la propiedad AltText
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