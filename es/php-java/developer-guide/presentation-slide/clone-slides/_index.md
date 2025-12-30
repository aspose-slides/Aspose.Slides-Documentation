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
Clonar es el proceso de crear una copia exacta o réplica de algo. Aspose.Slides for PHP via Java también permite crear una copia o clon de cualquier diapositiva y luego insertar esa diapositiva clonada en la presentación actual o en cualquier otra presentación abierta. El proceso de clonación de diapositivas crea una nueva diapositiva que puede ser modificada por los desarrolladores sin cambiar la diapositiva original. Existen varias formas posibles de clonar una diapositiva:

- Clonar al final dentro de una presentación.
- Clonar en otra posición dentro de la presentación.
- Clonar al final en otra presentación.
- Clonar en otra posición en otra presentación.
- Clonar en una posición específica en otra presentación.

En Aspose.Slides for PHP via Java, (una colección de [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) objetos) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) proporciona los métodos [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) y [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) para realizar los tipos de clonación de diapositivas descritos anteriormente.

## **Clonar una diapositiva al final de una presentación**
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación al final de las diapositivas existentes, utiliza el método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) siguiendo los pasos enumerados a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Instancia la clase [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) haciendo referencia a la colección Slides expuesta por el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Llama al método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) y pasa la diapositiva a clonar como parámetro al método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Escribe el archivo de presentación modificado.

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
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una posición distinta, utiliza el método [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Instancia la clase haciendo referencia a la colección [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Llama al método [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) y pasa la diapositiva a clonar junto con el índice para la nueva posición como parámetro al método [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Escribe la presentación modificada como archivo PPTX.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (situada en el índice cero – posición 1 – de la presentación) al índice 1 – Posición 2 – de la presentación.
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
Si necesitas clonar una diapositiva de una presentación y usarla en otro archivo de presentación, al final de las diapositivas existentes:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que contenga la presentación de la que se clonará la diapositiva.
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que contenga la presentación de destino a la que se añadirá la diapositiva.
1. Instancia la clase [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) haciendo referencia a la colección [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) expuesta por el objeto Presentation de la presentación de destino.
1. Llama al método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) y pasa la diapositiva de la presentación origen como parámetro al método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Escribe el archivo de presentación de destino modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (del primer índice de la presentación fuente) al final de la presentación de destino.
```php
  # Instanciar la clase Presentation para cargar el archivo de presentación origen
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanciar la clase Presentation para el PPTX de destino (donde se clonará la diapositiva)
    $destPres = new Presentation();
    try {
      # Clonar la diapositiva deseada de la presentación origen al final de la colección de diapositivas en la presentación de destino
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
Si necesitas clonar una diapositiva de una presentación y usarla en otro archivo de presentación, en una posición específica:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que contenga la presentación fuente de la que se clonará la diapositiva.
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que contenga la presentación a la que se añadirá la diapositiva.
1. Instancia la clase [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) haciendo referencia a la colección Slides del objeto Presentation de la presentación de destino.
1. Llama al método [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) y pasa la diapositiva de la presentación origen junto con la posición deseada como parámetro al método [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Escribe el archivo de presentación de destino modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (del índice cero de la presentación fuente) al índice 1 (posición 2) de la presentación de destino.
```php
  # Instanciar la clase Presentation para cargar el archivo de presentación origen
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanciar la clase Presentation para el PPTX de destino (donde se clonará la diapositiva)
    $destPres = new Presentation();
    try {
      # Clonar la diapositiva deseada de la presentación origen al final de la colección de diapositivas en la presentación de destino
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
Si necesitas clonar una diapositiva con una diapositiva maestra de una presentación y usarla en otra presentación, primero debes clonar la diapositiva maestra deseada de la presentación origen a la presentación destino. Luego debes usar esa diapositiva maestra para clonar la diapositiva con maestra. El método [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) espera una diapositiva maestra de la presentación destino, no de la presentación origen. Para clonar la diapositiva con maestra, sigue los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que contenga la presentación fuente de la que se clonará la diapositiva.
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que contenga la presentación de destino a la que se clonará la diapositiva.
1. Accede a la diapositiva a clonar junto con la diapositiva maestra.
1. Instancia la clase [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) haciendo referencia a la colección Masters expuesta por el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) de la presentación de destino.
1. Llama al método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) expuesto por el objeto [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) y pasa la maestra del PPTX origen que se va a clonar como parámetro al método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Instancia la clase [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) estableciendo la referencia a la colección Slides del objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) de la presentación de destino.
1. Llama al método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) y pasa la diapositiva de la presentación origen que se va a clonar y la diapositiva maestra como parámetros al método [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Escribe el archivo de presentación de destino modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva con maestra (situada en el índice cero de la presentación fuente) al final de la presentación de destino usando una maestra de la diapositiva fuente.
```php
  # Instanciar la clase Presentation para cargar el archivo de presentación origen
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Instanciar la clase Presentation para la presentación de destino (donde se va a clonar la diapositiva)
    $destPres = new Presentation();
    try {
      # Instanciar ISlide a partir de la colección de diapositivas en la presentación origen junto con
      # diapositiva maestra
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clonar la diapositiva maestra deseada de la presentación origen a la colección de maestras en la
      # presentación de destino
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clonar la diapositiva maestra deseada de la presentación origen a la colección de maestras en la
      # presentación de destino
      $iSlide = $masters->addClone($SourceMaster);
      # Clonar la diapositiva deseada de la presentación origen con la maestra deseada al final de la
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
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una sección distinta, utiliza el método [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) expuesto por la interfaz [**ISlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection). Aspose.Slides for PHP via Java permite clonar una diapositiva de la primera sección e insertarla en la segunda sección de la misma presentación.

El siguiente fragmento de código muestra cómo clonar una diapositiva e insertarla en una sección especificada.
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


## **FAQ**

**¿Se clonan las notas del orador y los comentarios de revisión?**

Sí. La página de notas y los comentarios de revisión se incluyen en el clon. Si no los deseas, [elimínalos](/slides/es/php-java/presentation-notes/) después de la inserción.

**¿Cómo se manejan los gráficos y sus fuentes de datos?**

El objeto gráfico, su formato y los datos incrustados se copian. Si el gráfico estaba vinculado a una fuente externa (p. ej., un libro de trabajo incrustado como OLE), ese vínculo se conserva como un [objeto OLE](/slides/es/php-java/manage-ole/). Tras moverlo entre archivos, verifica la disponibilidad de los datos y el comportamiento de actualización.

**¿Puedo controlar la posición de inserción y las secciones del clon?**

Sí. Puedes insertar el clon en un índice de diapositiva específico y colocarlo en una [sección](/slides/es/php-java/slide-section/) elegida. Si la sección de destino no existe, créala primero y luego mueve la diapositiva a ella.