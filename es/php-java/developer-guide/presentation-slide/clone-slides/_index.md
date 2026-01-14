---
title: Clonar diapositivas de presentación en PHP
linktitle: Clonar diapositivas
type: docs
weight: 35
url: /es/php-java/clone-slides/
keywords:
- clonar diapositiva
- copiar diapositiva
- guardar diapositiva
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Duplica rápidamente diapositivas de PowerPoint con Aspose.Slides para PHP. Sigue nuestros claros ejemplos de código para automatizar la creación de PPT en segundos y eliminar el trabajo manual."
---

## **Clonar diapositivas en una presentación**
Clonar es el proceso de crear una copia exacta o réplica de algo. Aspose.Slides for PHP via Java también permite crear una copia o clon de cualquier diapositiva y luego insertar esa diapositiva clonada en la presentación actual o en cualquier otra presentación abierta. El proceso de clonación de diapositivas crea una nueva diapositiva que los desarrolladores pueden modificar sin cambiar la diapositiva original. Existen varias formas posibles de clonar una diapositiva:

- Clonar al final dentro de una presentación.
- Clonar en otra posición dentro de la presentación.
- Clonar al final en otra presentación.
- Clonar en otra posición en otra presentación.
- Clonar en una posición específica en otra presentación.

En Aspose.Slides for PHP via Java, (una colección de objetos [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) ) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) proporciona los métodos [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) y [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone) para realizar los tipos de clonación de diapositivas descritos anteriormente.

## **Clonar una diapositiva al final de una presentación**
Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación al final de las diapositivas existentes, utilice el método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) según los pasos enumerados a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenga el objeto [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) haciendo referencia a la colección de diapositivas expuesta por el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Llame al método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) expuesto por el objeto [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) y pase la diapositiva a clonar como parámetro del método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone).
1. Guarde el archivo de presentación modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (situada en la primera posición – índice cero – de la presentación) al final de la presentación.
```php
  # Instanciar la clase Presentation que representa un archivo de presentación
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Clonar la diapositiva deseada al final de la colección de diapositivas en la misma presentación
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Guardar la presentación modificada en disco
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Clonar una diapositiva a otra posición dentro de una presentación**
Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una posición diferente, utilice el método [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone):

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenga el objeto [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection) haciendo referencia a la colección [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Llame al método [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone) expuesto por el objeto [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) y pase la diapositiva a clonar junto con el índice de la nueva posición como parámetro del método [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone).
1. Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (situada en el índice cero – posición 1 – de la presentación) al índice 1 – posición 2 – de la presentación.
```php
  # Instanciar la clase Presentation que representa un archivo de presentación
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Clonar la diapositiva deseada al final de la colección de diapositivas en la misma presentación
    $slds = $pres->getSlides();
    # Clonar la diapositiva deseada al índice especificado en la misma presentación
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Guardar la presentación modificada en disco
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Clonar una diapositiva al final de otra presentación**
Si necesita clonar una diapositiva de una presentación y usarla en otro archivo de presentación, al final de las diapositivas existentes:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que contenga la presentación de la cual se clonará la diapositiva.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que contenga la presentación de destino a la que se añadirá la diapositiva.
1. Obtenga el objeto [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection) haciendo referencia a la colección [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) expuesta por el objeto Presentation de la presentación de destino.
1. Llame al método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) expuesto por el objeto [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) y pase la diapositiva de la presentación origen como parámetro del método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone).
1. Guarde el archivo de presentación de destino modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (del primer índice de la presentación origen) al final de la presentación de destino.
```php
  # Instanciar la clase Presentation para cargar el archivo de presentación de origen
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanciar la clase Presentation para el PPTX de destino (donde se clonará la diapositiva)
    $destPres = new Presentation();
    try {
      # Clonar la diapositiva deseada de la presentación de origen al final de la colección de diapositivas en la presentación de destino
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Guardar la presentación de destino en disco
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **Clonar una diapositiva a otra posición en otra presentación**
Si necesita clonar una diapositiva de una presentación y usarla en otro archivo de presentación, en una posición específica:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que contenga la presentación origen de la cual se clonará la diapositiva.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que contenga la presentación a la que se añadirá la diapositiva.
1. Obtenga la clase [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) haciendo referencia a la colección Slides expuesta por el objeto Presentation de la presentación de destino.
1. Llame al método [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone) expuesto por el objeto [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) y pase la diapositiva de la presentación origen junto con la posición deseada como parámetro del método [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone).
1. Guarde el archivo de presentación de destino modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (del índice cero de la presentación origen) al índice 1 (posición 2) de la presentación de destino.
```php
  # Instanciar la clase Presentation para cargar el archivo de presentación de origen
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanciar la clase Presentation para el PPTX de destino (donde se clonará la diapositiva)
    $destPres = new Presentation();
    try {
      # Clonar la diapositiva deseada de la presentación de origen al final de la colección de diapositivas en la presentación de destino
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Guardar la presentación de destino en disco
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **Clonar una diapositiva en una posición específica en otra presentación**
Si necesita clonar una diapositiva con una diapositiva maestra de una presentación y usarla en otra presentación, primero debe clonar la diapositiva maestra deseada de la presentación origen a la presentación de destino. Luego debe usar esa diapositiva maestra para clonar la diapositiva con maestra. El método [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) espera una diapositiva maestra de la presentación de destino en lugar de la presentación origen. Para clonar la diapositiva con una maestra, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que contenga la presentación origen de la cual se clonará la diapositiva.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que contenga la presentación de destino a la que se clonará la diapositiva.
1. Acceda a la diapositiva que se va a clonar junto con la diapositiva maestra.
1. Instancie la clase [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection) haciendo referencia a la colección Masters expuesta por el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) de la presentación de destino.
1. Llame al método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) expuesto por el objeto [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection) y pase la maestra del PPTX origen que se va a clonar como parámetro del método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone).
1. Instancie la clase [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) estableciendo la referencia a la colección Slides expuesta por el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) de la presentación de destino.
1. Llame al método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) expuesto por el objeto [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) y pase la diapositiva de la presentación origen que se va a clonar y la diapositiva maestra como parámetro del método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone).
1. Guarde el archivo de presentación de destino modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva con una maestra (situada en el índice cero de la presentación origen) al final de la presentación de destino usando una maestra de la diapositiva origen.
```php
  # Instanciar la clase Presentation para cargar el archivo de presentación de origen
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Instanciar la clase Presentation para la presentación de destino (donde se clonará la diapositiva)
    $destPres = new Presentation();
    try {
      # Instanciar ISlide a partir de la colección de diapositivas de la presentación de origen junto con
      # Diapositiva maestra
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clonar la diapositiva maestra deseada de la presentación de origen a la colección de maestras en la
      # presentación de destino
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clonar la diapositiva maestra deseada de la presentación de origen a la colección de maestras en la
      # presentación de destino
      $iSlide = $masters->addClone($SourceMaster);
      # Clonar la diapositiva deseada de la presentación de origen con la maestra deseada al final de la
      # colección de diapositivas en la presentación de destino
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Guardar la presentación de destino en disco
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **Clonar una diapositiva al final de una sección especificada**
Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una sección diferente, utilice el método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) expuesto por la clase [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection). Aspose.Slides for PHP via Java permite clonar una diapositiva de la primera sección y luego insertar esa diapositiva clonada en la segunda sección de la misma presentación.

El fragmento de código siguiente muestra cómo clonar una diapositiva e insertar la diapositiva clonada en una sección especificada.
```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Guardar la presentación de destino en disco
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Se clonan las notas del orador y los comentarios del revisor?**

Sí. La página de notas y los comentarios de revisión se incluyen en el clon. Si no los desea, [elimínelos](/slides/es/php-java/presentation-notes/) después de la inserción.

**¿Cómo se manejan los gráficos y sus fuentes de datos?**

El objeto del gráfico, su formato y los datos incrustados se copian. Si el gráfico estaba vinculado a una fuente externa (p. ej., un libro de trabajo incrustado como OLE), ese vínculo se conserva como un [objeto OLE](/slides/es/php-java/manage-ole/). Tras moverlo entre archivos, verifique la disponibilidad de los datos y el comportamiento de actualización.

**¿Puedo controlar la posición de inserción y las secciones del clon?**

Sí. Puede insertar el clon en un índice de diapositiva específico y colocarlo en una [sección](/slides/es/php-java/slide-section/) elegida. Si la sección de destino no existe, créela primero y luego mueva la diapositiva a ella.