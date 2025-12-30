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
description: "Comparar presentaciones PowerPoint y OpenDocument de forma programática con Aspose.Slides para PHP mediante Java. Identificar rápidamente las diferencias de diapositivas en el código."
---

## **Compare Two Slides**
El método Equals se ha añadido a la interfaz [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) y a la clase [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide). Devuelve true para las diapositivas/páginas maestras y de diseño que son idénticas en cuanto a su estructura y contenido estático. 

Dos diapositivas son iguales si todas las formas, estilos, textos, animaciones y demás configuraciones, etc., son iguales. La comparación no tiene en cuenta los valores de identificadores únicos, por ejemplo SlideId, ni el contenido dinámico, como el valor de fecha actual en un marcador de posición de fecha.
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


## **FAQ**

**Does the fact that a slide is hidden affect the comparison of the slides themselves?**

[Hidden status](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) es una propiedad a nivel de presentación/reproducción, no de contenido visual. La igualdad de dos diapositivas específicas se determina por su estructura y contenido estático; el simple hecho de que una diapositiva esté oculta no hace que las diapositivas sean diferentes.

**Are hyperlinks and their parameters taken into account?**

Sí. Los enlaces forman parte del contenido estático de una diapositiva. Si la URL o la acción del hipervínculo difiere, normalmente se considera una diferencia en el contenido estático.

**If a chart refers to an external Excel file, will the contents of that file be taken into account?**

No. La comparación se realiza basándose en las propias diapositivas. Las fuentes de datos externas generalmente no se leen en el momento de la comparación; solo se considera lo que está presente en la estructura y el estado estático de la diapositiva.