---
title: Localización de Presentaciones
type: docs
weight: 100
url: /php-java/presentation-localization/
---

## **Cambiar el Idioma del Texto en la Presentación y las Formas**
- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtener la referencia de una diapositiva usando su índice.
- Agregar una [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) de tipo [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) a la diapositiva.
- Agregar texto al TextFrame.
- [Configurar el ID del idioma](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) al texto.
- Guardar la presentación como un archivo PPTX.

La implementación de los pasos anteriores se demuestra a continuación en un ejemplo.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Texto para aplicar el idioma de revisión ortográfica");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```