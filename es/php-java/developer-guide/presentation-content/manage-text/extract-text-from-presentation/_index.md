---
title: Extracción avanzada de texto de presentaciones en PHP
linktitle: Extraer texto
type: docs
weight: 90
url: /es/php-java/extract-text-from-presentation/
keywords:
- extraer texto
- extraer texto de diapositiva
- extraer texto de presentación
- extraer texto de PowerPoint
- extraer texto de OpenDocument
- extraer texto de PPT
- extraer texto de PPTX
- extraer texto de ODP
- recuperar texto
- recuperar texto de diapositiva
- recuperar texto de presentación
- recuperar texto de PowerPoint
- recuperar texto de OpenDocument
- recuperar texto de PPT
- recuperar texto de PPTX
- recuperar texto de ODP
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Extraiga texto rápidamente de presentaciones PowerPoint y OpenDocument utilizando Aspose.Slides para PHP a través de Java. Siga nuestra guía simple, paso a paso, para ahorrar tiempo."
---

{{% alert color="primary" %}} 

No es raro que los desarrolladores necesiten extraer el texto de una presentación. Para hacerlo, es necesario extraer el texto de todas las formas en todas las diapositivas de una presentación. Este artículo explica cómo extraer texto de presentaciones Microsoft PowerPoint PPTX usando Aspose.Slides. 

{{% /alert %}} 
## **Extraer texto de diapositivas**
Aspose.Slides para PHP a través de Java proporciona la clase [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil). Esta clase expone varios métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer el texto de una diapositiva en una presentación PPTX, use el método estático sobrecargado [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) expuesto por la clase [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil). Este método acepta el objeto Slide como parámetro.
Al ejecutarse, el método Slide escanea todo el texto de la diapositiva pasada como parámetro y devuelve una matriz de objetos [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame). Esto significa que cualquier formato de texto asociado está disponible. El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:
```php
  # Instanciar la clase Presentation que representa un archivo PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # Obtener una matriz de objetos ITextFrame de todas las diapositivas en el PPTX
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # Recorrer la matriz de TextFrames
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # Recorrer los párrafos en el ITextFrame actual
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # Recorrer las porciones en el IParagraph actual
          foreach($para->getPortions() as $port) {
            # Mostrar el texto en la porción actual
            echo($port->getText());
            # Mostrar la altura de fuente del texto
            echo($port->getPortionFormat()->getFontHeight());
            # Mostrar el nombre de fuente del texto
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


## **Extraer texto de presentaciones**
Para escanear el texto de toda la presentación, use el método estático [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) expuesto por la clase SlideUtil. Toma dos parámetros:

1. En primer lugar, un objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) que representa la presentación de la que se extrae el texto.
2. En segundo lugar, un valor booleano que determina si se debe incluir la diapositiva maestra al escanear el texto de la presentación.  
   El método devuelve una matriz de objetos [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) con la información de formato del texto. El código a continuación escanea el texto y la información de formato de una presentación, incluidas las diapositivas maestras.
```php
  # Instanciar la clase Presentation que representa un archivo PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Obtener una matriz de objetos ITextFrame de todas las diapositivas en el PPTX
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # Recorrer la matriz de TextFrames
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # Recorrer los párrafos en el ITextFrame actual
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # Recorrer las porciones en el IParagraph actual
        foreach($para->getPortions() as $port) {
          # Mostrar el texto en la porción actual
          echo($port->getText());
          # Mostrar la altura de fuente del texto
          echo($port->getPortionFormat()->getFontHeight());
          # Mostrar el nombre de fuente del texto
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
Se ha añadido el nuevo método estático getPresentationText a la clase Presentation. Hay tres sobrecargas para este método:
```php

```


## **Preguntas frecuentes**

**¿Qué tan rápido procesa Aspose.Slides presentaciones grandes durante la extracción de texto?**

Aspose.Slides está optimizado para alto rendimiento y procesa de manera eficiente incluso [presentaciones grandes](/slides/es/php-java/open-presentation/), lo que lo hace adecuado para escenarios de procesamiento en tiempo real o por lotes.

**¿Puede Aspose.Slides extraer texto de tablas y gráficos dentro de presentaciones?**

Sí, Aspose.Slides admite completamente la extracción de texto de tablas, gráficos y otros elementos de diapositiva complejos, lo que le permite acceder y analizar todo el contenido textual fácilmente.

**¿Necesito una licencia especial de Aspose.Slides para extraer texto de presentaciones?**

Puede extraer texto utilizando la versión de prueba gratuita de Aspose.Slides, aunque tendrá ciertas limitaciones, como procesar solo un número limitado de diapositivas. Para uso sin restricciones y para manejar presentaciones más grandes, se recomienda adquirir una licencia completa.