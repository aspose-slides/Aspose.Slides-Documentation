---
title: Renderizar Presentación con Fuente de Respaldo
type: docs
weight: 30
url: /es/php-java/render-presentation-with-fallback-font/
---

El siguiente ejemplo incluye estos pasos:

1. [Creamos una colección de reglas de fuente de respaldo](/slides/es/php-java/create-fallback-fonts-collection/).
1. [Eliminar](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) una regla de fuente de respaldo y [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) a otra regla.
1. Establecer la colección de reglas en [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) método.
1. Con el método [Presentation.save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) podemos guardar la presentación en el mismo formato o guardarla en otro. Después de que la colección de reglas de fuentes de respaldo está establecida en [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager), estas reglas se aplican durante cualquier operación sobre la presentación: guardar, renderizar, convertir, etc.

```php
  # Crear una nueva instancia de una colección de reglas
  $rulesList = new FontFallBackRulesCollection();
  # crear un número de reglas
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Intentando eliminar la fuente de respaldo "Tahoma" de las reglas cargadas
    $fallBackRule->remove("Tahoma");
    # Y actualizar las reglas para el rango especificado
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # También podemos eliminar cualquier regla existente de la lista
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Asignando una lista de reglas preparadas para usar
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Renderizando una miniatura utilizando la colección de reglas inicializada y guardando en JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Guardar la imagen en el disco en formato JPEG
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
Lee más sobre [Guardar y Conversión en Presentación](/slides/es/php-java/creating-saving-and-converting-a-presentation/).
{{% /alert %}}