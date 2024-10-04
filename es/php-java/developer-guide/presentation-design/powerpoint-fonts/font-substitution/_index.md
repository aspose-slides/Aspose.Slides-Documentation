---
title: Sustitución de Fuentes - API de PowerPoint para Java
linktitle: Sustitución de Fuentes
type: docs
weight: 70
url: /php-java/font-substitution/
keywords: "Fuente, fuente sustituta, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Sustituir fuente en PowerPoint"
---

Aspose.Slides te permite establecer reglas para las fuentes que determinan qué se debe hacer en ciertas condiciones (por ejemplo, cuando una fuente no puede ser accedida) de la siguiente manera:

1. Carga la presentación relevante.
2. Carga la fuente que será reemplazada.
3. Carga la nueva fuente.
4. Agrega una regla para el reemplazo.
5. Agrega la regla a la colección de reglas de reemplazo de fuentes de la presentación.
6. Genera la imagen de la diapositiva para observar el efecto.

Este código PHP demuestra el proceso de sustitución de fuentes:

```php
  # Carga una presentación
  $pres = new Presentation("Fonts.pptx");
  try {
    # Carga la fuente de origen que será reemplazada
    $sourceFont = new FontData("SomeRareFont");
    # Carga la nueva fuente
    $destFont = new FontData("Arial");
    # Agrega una regla de fuente para el reemplazo de fuentes
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # Agrega la regla a la colección de reglas de sustitución de fuentes
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # Agrega una colección de reglas de fuentes a la lista de reglas
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # Se usará la fuente Arial en lugar de SomeRareFont cuando esta última sea inaccesible
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Guarda la imagen en disco en formato JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
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

{{%  alert title="NOTA"  color="warning"   %}} 

Puede que desees ver [**Reemplazo de Fuentes**](/slides/php-java/font-replacement/).

{{% /alert %}}