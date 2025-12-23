---
title: Automatizar la localización de presentaciones en PHP
linktitle: Localización de presentaciones
type: docs
weight: 100
url: /es/php-java/presentation-localization/
keywords:
- cambiar idioma
- corrector ortográfico
- ID de idioma
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Automatiza la localización de diapositivas PowerPoint y OpenDocument con Aspose.Slides para PHP mediante Java, utilizando ejemplos de código prácticos y consejos para un despliegue global más rápido."
---

## **Cambiar el idioma de una presentación y del texto de una forma**
- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Agregue un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) de tipo [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) a la diapositiva.
- Agregue texto al TextFrame.
- [Establecer Language Id](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) al texto.
- Guarde la presentación como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación en un ejemplo.
```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿El ID de idioma activa la traducción automática del texto?**

No. [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) en Aspose.Slides almacena el idioma para la corrección ortográfica y la comprobación gramatical, pero no traduce ni cambia el contenido del texto. Es metadatos que PowerPoint entiende para la revisión.

**¿El ID de idioma afecta la separación silábica y los saltos de línea durante la renderización?**

En Aspose.Slides, [language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) es para la revisión. La calidad de la separación silábica y el ajuste de líneas dependen principalmente de la disponibilidad de [fuentes adecuadas](/slides/es/php-java/powerpoint-fonts/) y de la configuración de diseño/saltos de línea para el sistema de escritura. Para garantizar una renderización correcta, haga que las fuentes necesarias estén disponibles, configure [reglas de sustitución de fuentes](/slides/es/php-java/font-substitution/) y/o [incorporar fuentes](/slides/es/php-java/embedded-font/) en la presentación.

**¿Puedo establecer diferentes idiomas dentro de un solo párrafo?**

Sí. [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) se aplica a nivel de porción de texto, por lo que un solo párrafo puede mezclar varios idiomas con configuraciones de revisión distintas.