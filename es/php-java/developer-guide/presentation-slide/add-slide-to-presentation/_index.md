---
title: Agregar Diapositiva a la Presentación
type: docs
weight: 10
url: /php-java/add-slide-to-presentation/
---

## **Agregar Diapositiva a la Presentación**
{{% alert color="primary" %}} 

Antes de hablar sobre cómo agregar diapositivas a los archivos de presentación, hablemos de algunos hechos sobre las diapositivas. Cada archivo de presentación de PowerPoint contiene una diapositiva **Maestra / Diseño** y otras diapositivas **Normales**. Esto significa que un archivo de presentación contiene al menos una o más diapositivas. Es importante saber que los archivos de presentación sin diapositivas no son compatibles con Aspose.Slides para PHP a través de Java. Cada diapositiva tiene una Id única y todas las Diapositivas Normales están organizadas en un orden especificado por el índice basado en cero.

{{% /alert %}} 

Aspose.Slides para PHP a través de Java permite a los desarrolladores agregar diapositivas vacías a su presentación. Para agregar una diapositiva vacía en la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) configurando una referencia a la propiedad [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) (colección de objetos Slide de contenido) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Agregue una diapositiva vacía a la presentación al final de la colección de diapositivas de contenido llamando a los métodos [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) expuestos por el objeto [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection).
- Haga algo con la nueva diapositiva vacía añadida.
- Finalmente, escriba el archivo de presentación usando el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).

```php
  # Instanciar la clase Presentation que representa el archivo de presentación
  $pres = new Presentation();
  try {
    # Instanciar la clase SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Agregar una diapositiva vacía a la colección de Diapositivas
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Hacer algo en la diapositiva recién añadida
    # Guardar el archivo PPTX en el Disco
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```