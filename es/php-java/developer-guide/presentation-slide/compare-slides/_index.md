---
title: Comparar diapositivas de presentación en PHP
linktitle: Comparar diapositivas
type: docs
weight: 50
url: /es/php-java/compare-slides/
keywords:
- comparar diapositivas
- comparación de diapositivas
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Compare presentaciones PowerPoint y OpenDocument programáticamente con Aspose.Slides para PHP a través de Java. Identifique rápidamente las diferencias de diapositivas en el código."
---

## **Comparar dos diapositivas**
Se ha añadido el método Equals a la clase [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide). Devuelve true para las diapositivas/disposición y las diapositivas maestras que son idénticas por su estructura y contenido estático.

Dos diapositivas son iguales si todas las formas, estilos, textos, animaciones y otros ajustes, etc., son iguales. La comparación no tiene en cuenta los valores de identificadores únicos, p.ej. SlideId y el contenido dinámico, p.ej. el valor de la fecha actual en el marcador de posición de fecha.
```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
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


## **Preguntas frecuentes**

**¿El hecho de que una diapositiva esté oculta afecta la comparación de las propias diapositivas?**

[Estado oculto](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) es una propiedad a nivel de presentación/reproducción, no de contenido visual. La igualdad de dos diapositivas específicas se determina por su estructura y contenido estático; el mero hecho de que una diapositiva esté oculta no hace que las diapositivas sean diferentes.

**¿Se tienen en cuenta los hipervínculos y sus parámetros?**

Sí. Los enlaces forman parte del contenido estático de una diapositiva. Si la URL o la acción del hipervínculo difieren, generalmente se considera una diferencia en el contenido estático.

**Si un gráfico hace referencia a un archivo Excel externo, ¿se tendrá en cuenta el contenido de ese archivo?**

No. La comparación se realiza basándose en las propias diapositivas. Las fuentes de datos externas generalmente no se leen en el momento de la comparación; solo se considera lo que está presente en la estructura y el estado estático de la diapositiva.