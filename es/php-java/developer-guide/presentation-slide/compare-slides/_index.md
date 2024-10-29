---
title: Comparar Diapositivas
type: docs
weight: 50
url: /es/php-java/compare-slides/
---

## **Comparar Dos Diapositivas**
El método Equals ha sido agregado a la interfaz [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) y a la clase [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide). Devuelve verdadero para las diapositivas/layout y las diapositivas/master que son idénticas en su estructura y contenido estático.

Dos diapositivas son iguales si todas las formas, estilos, textos, animaciones y otras configuraciones, etc. son iguales. La comparación no tiene en cuenta los valores de identificador único, por ejemplo, SlideId y el contenido dinámico, por ejemplo, el valor de la fecha actual en el marcador de posición de fecha.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d es igual a SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```