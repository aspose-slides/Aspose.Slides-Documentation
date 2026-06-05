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
description: "Extrae texto rápidamente de presentaciones PowerPoint y OpenDocument utilizando Aspose.Slides para PHP a través de Java. Sigue nuestra guía simple, paso a paso, para ahorrar tiempo."
---
## **Descripción general**

Extraer texto de presentaciones es una tarea común pero esencial para los desarrolladores que trabajan con contenido de diapositivas. Tanto si se trata de archivos de Microsoft PowerPoint en formato PPT o PPTX, como de presentaciones OpenDocument (ODP), acceder y recuperar datos textuales puede ser fundamental para análisis, automatización, indexación o migración de contenido.

Este artículo ofrece una guía completa sobre cómo extraer texto de manera eficiente de varios formatos de presentación, incluidos PPT, PPTX y ODP, utilizando Aspose.Slides para PHP a través de Java. Aprenderá a iterar sistemáticamente a través de los elementos de la presentación para obtener con precisión el contenido de texto que necesita.

## **Extraer texto de una diapositiva**

Aspose.Slides para PHP a través de Java proporciona la clase [SlideUtil](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideutil/). Esta clase expone varios métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer texto de una diapositiva en una presentación, utilice el método [getAllTextBoxes](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideutil/#getAllTextBoxes). Este método acepta como parámetro un objeto de tipo [BaseSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslide/). Cuando se ejecuta, el método escanea toda la diapositiva en busca de texto y devuelve una matriz de objetos de tipo [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/), preservando cualquier formato de texto.

El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extraer texto de una presentación**

Para escanear texto de toda la presentación, utilice el método estático [getAllTextFrames](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideutil/#getAllTextFrames) expuesto por la clase [SlideUtil](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideutil/). Acepta dos parámetros:

1. Primero, un objeto [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) que representa una presentación PowerPoint o OpenDocument de la que se extraerá el texto.
2. Segundo, un valor `boolean` que indica si se deben incluir las diapositivas maestras al escanear el texto de la presentación.

El método devuelve una matriz de objetos de tipo [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/), incluida la información de formato del texto. El código a continuación escanea el texto y los detalles de formato de una presentación, incluidas las diapositivas maestras.

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extracción de texto categorizada y rápida**

La clase [PresentationFactory](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationfactory/) también ofrece métodos para extraer todo el texto de presentaciones:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

El argumento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/es/php-java/aspose.slides/textextractionarrangingmode/) indica el modo para organizar el resultado de la extracción de texto y puede establecerse en los siguientes valores:
- `Unarranged` - El texto sin procesar sin considerar su posición en la diapositiva.
- `Arranged` - El texto está ordenado en el mismo orden que aparece en la diapositiva.

El modo sin organizar puede usarse cuando la velocidad es crítica; es más rápido que el modo organizado.

[PresentationText](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationtext/) representa el texto sin procesar extraído de la presentación. Su método `getSlidesText` devuelve una matriz de objetos donde cada objeto representa el texto de la diapositiva correspondiente. Cada objeto devuelto tiene los siguientes métodos:

- `getText` - El texto dentro de las formas de la diapositiva.
- `getMasterText` - El texto dentro de las formas de la diapositiva maestra asociada a esta diapositiva.
- `getLayoutText` - El texto dentro de las formas de la diapositiva de diseño asociada a esta diapositiva.
- `getNotesText` - El texto dentro de las formas de la diapositiva de notas asociada a esta diapositiva.
- `getCommentsText` - El texto dentro de los comentarios asociados a esta diapositiva.

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **Preguntas frecuentes**

**¿Qué tan rápido procesa Aspose.Slides presentaciones grandes durante la extracción de texto?**

Aspose.Slides está optimizado para alto rendimiento y puede procesar incluso [presentaciones grandes](/slides/es/php-java/open-presentation/), lo que lo hace adecuado para escenarios de procesamiento en tiempo real o por lotes.

**¿Puede Aspose.Slides extraer texto de tablas y gráficos dentro de presentaciones?**

Sí. Aspose.Slides puede extraer texto de muchos elementos de diapositiva, incluidas tablas y objetos relacionados con gráficos, para que pueda acceder y analizar el contenido textual en estructuras de presentación comunes.

**¿Necesito una licencia especial de Aspose.Slides para extraer texto de presentaciones?**

Puede extraer texto utilizando la versión de prueba gratuita de Aspose.Slides, aunque tendrá [ciertas limitaciones](/slides/es/php-java/licensing/), como procesar solo un número limitado de diapositivas. Para un uso sin restricciones y para manejar presentaciones más extensas, se recomienda adquirir una licencia completa.