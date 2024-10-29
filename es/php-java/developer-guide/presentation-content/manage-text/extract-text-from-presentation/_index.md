---
title: Extraer texto de la presentación
type: docs
weight: 90
url: /es/php-java/extract-text-from-presentation/
---

{{% alert color="primary" %}}

No es raro que los desarrolladores necesiten extraer el texto de una presentación. Para ello, debe extraer texto de todas las formas en todas las diapositivas de una presentación. Este artículo explica cómo extraer texto de presentaciones PPTX de Microsoft PowerPoint utilizando Aspose.Slides.

{{% /alert %}} 
## **Extraer texto de la diapositiva**
Aspose.Slides para PHP a través de Java proporciona la clase [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil). Esta clase expone una serie de métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer el texto de una diapositiva en una presentación PPTX, use el método estático sobrecargado [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) expuesto por la clase [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil). Este método acepta el objeto Slide como parámetro. Al ejecutarse, el método Slide escanea todo el texto de la diapositiva pasada como parámetro y devuelve un arreglo de objetos [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame). Esto significa que cualquier formato de texto asociado con el texto está disponible. El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:

```php
  # Instanciar la clase Presentation que representa un archivo PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # Obtener un arreglo de objetos ITextFrame de todas las diapositivas en el PPTX
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # Recorrer el arreglo de TextFrames
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # Recorrer párrafos en el ITextFrame actual
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # Recorrer porciones en el IParagraph actual
          foreach($para->getPortions() as $port) {
            # Mostrar texto en la porción actual
            echo($port->getText());
            # Mostrar altura de la fuente del texto
            echo($port->getPortionFormat()->getFontHeight());
            # Mostrar nombre de la fuente del texto
            if (!java_is_null($port->getPortionFormat()->getLatinFont())) {
              echo($port->getPortionFormat()->getLatinFont()->getFontName());
            }
          }
        }
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **Extraer texto de la presentación**
Para escanear el texto de toda la presentación, use el método estático [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) expuesto por la clase SlideUtil. Toma dos parámetros:

1. Primero, un objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) que representa la presentación de la cual se está extrayendo el texto.
2. Segundo, un valor booleano que determina si se debe incluir la diapositiva maestra al escanear el texto de la presentación. 
   El método devuelve un arreglo de objetos [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame), completo con información de formato de texto. El código a continuación escanea el texto y la información de formato de una presentación, incluyendo las diapositivas maestras.

```php
  # Instanciar la clase Presentation que representa un archivo PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Obtener un arreglo de objetos ITextFrame de todas las diapositivas en el PPTX
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # Recorrer el arreglo de TextFrames
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # Recorrer párrafos en el ITextFrame actual
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # Recorrer porciones en el IParagraph actual
        foreach($para->getPortions() as $port) {
          # Mostrar texto en la porción actual
          echo($port->getText());
          # Mostrar altura de la fuente del texto
          echo($port->getPortionFormat()->getFontHeight());
          # Mostrar nombre de la fuente del texto
          if (!java_is_null($port->getPortionFormat()->getLatinFont())) {
            echo($port->getPortionFormat()->getLatinFont()->getFontName());
          }
        }
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **Extracción de texto categorizada y rápida**
Se ha añadido un nuevo método estático getPresentationText a la clase Presentation. Hay tres sobrecargas para este método:

```php

``` 

El argumento de enumeración [TextExtractionArrangingMode](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode) indica el modo para organizar la salida del resultado de texto y se puede establecer en los siguientes valores:
- [Unarranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - El texto en bruto sin respeto a la posición en la diapositiva
- [Arranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Arranged) - El texto se posiciona en el mismo orden que en la diapositiva

El modo **Unarranged** se puede usar cuando la velocidad es crítica, es más rápido que el modo Arranged.

[IPresentationText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) representa el texto en bruto extraído de la presentación. Contiene un método [getSlidesText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText#getSlidesText--) que devuelve un arreglo de objetos [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText). Cada objeto representa el texto en la diapositiva correspondiente. Los objetos [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) tienen los siguientes métodos:

- [ISlideText.getText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getText--) - El texto en las formas de la diapositiva
- [ISlideText.getMasterText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getMasterText--) - El texto en las formas de la página maestra para esta diapositiva
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getLayoutText--) - El texto en las formas de la página de diseño para esta diapositiva
- [ISlideText.getNotesText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getNotesText--) - El texto en las formas de la página de notas para esta diapositiva

También hay una clase [SlideText](https://reference.aspose.com/slides/php-java/aspose.slides/SlideText) que implementa la interfaz [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText).

La nueva API se puede usar así:

```php
  $text1 = PresentationFactory->getInstance()->getPresentationText("presentation.pptx", TextExtractionArrangingMode->Unarranged);
  echo($text1->getSlidesText()[0]->getText());
  echo($text1->getSlidesText()[0]->getLayoutText());
  echo($text1->getSlidesText()[0]->getMasterText());
  echo($text1->getSlidesText()[0]->getNotesText());

```