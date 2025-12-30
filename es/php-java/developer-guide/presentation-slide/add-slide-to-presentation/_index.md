---
title: Añadir diapositivas a presentaciones en PHP
linktitle: Añadir diapositiva
type: docs
weight: 10
url: /es/php-java/add-slide-to-presentation/
keywords:
- añadir diapositiva
- crear diapositiva
- diapositiva vacía
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Añade fácilmente diapositivas a tus presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para PHP a través de Java — inserción de diapositivas sin problemas y eficiente en segundos."
---

## **Agregar una diapositiva a una presentación**
{{% alert color="primary" %}} 

Antes de hablar de cómo añadir diapositivas a los archivos de presentación, discutamos algunos hechos sobre las diapositivas. Cada archivo de presentación de PowerPoint contiene una diapositiva **Master / Layout** y otras diapositivas **Normal**. Esto significa que un archivo de presentación contiene al menos una o más diapositivas. Es importante saber que los archivos de presentación sin diapositivas no son compatibles con Aspose.Slides for PHP via Java. Cada diapositiva tiene un Id único y todas las diapositivas Normal se organizan en un orden especificado por el índice basado en cero.

{{% /alert %}} 

Aspose.Slides for PHP via Java permite a los desarrolladores añadir diapositivas vacías a su presentación. Para añadir una diapositiva vacía en la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) estableciendo una referencia a la propiedad [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) (colección de objetos Slide de contenido) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Añada una diapositiva vacía a la presentación al final de la colección de diapositivas de contenido llamando a los métodos [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) expuestos por el objeto [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection).
- Realice alguna operación con la diapositiva vacía recién añadida.
- Finalmente, escriba el archivo de presentación usando el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
```php
  # Instanciar la clase Presentation que representa el archivo de presentación
  $pres = new Presentation();
  try {
    # Instanciar la clase SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Añadir una diapositiva vacía a la colección Slides
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Realizar alguna operación con la diapositiva recién añadida
    # Guardar el archivo PPTX en el disco
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Preguntas frecuentes**

**¿Puedo insertar una nueva diapositiva en una posición específica, no solo al final?**

Sí. La biblioteca admite colecciones de diapositivas y operaciones de [insert](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertclone/) , por lo que puede añadir una diapositiva en el índice requerido en lugar de solo al final.

**¿Se conservan los temas/estilos al añadir una diapositiva basada en un diseño?**

Sí. Un diseño hereda el formato de su maestro, y la nueva diapositiva hereda del diseño seleccionado y su maestro asociado.

**¿Qué diapositiva está presente en una nueva presentación "vacía" antes de añadir diapositivas?**

Una presentación recién creada ya contiene una diapositiva en blanco con el índice cero. Esto es importante a tener en cuenta al calcular los índices de inserción.

**¿Cómo elijo el diseño "correcto" para una nueva diapositiva si el maestro tiene muchas opciones?**

Generalmente elija el [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) que coincida con la estructura requerida ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/php-java/aspose.slides/slidelayouttype/)). Si falta dicho diseño, puede [añádalo al maestro](/slides/es/php-java/slide-layout/) y luego usarlo.