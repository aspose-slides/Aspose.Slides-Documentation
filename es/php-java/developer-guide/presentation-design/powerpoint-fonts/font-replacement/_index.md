---
title: Reemplazo de fuentes - PowerPoint Java API
linktitle: Reemplazo de fuentes
type: docs
weight: 60
url: /es/php-java/font-replacement/
description: Aprenda a reemplazar fuentes utilizando el método de reemplazo explícito en PowerPoint usando la API de Java.
---

Si cambias de opinión sobre el uso de una fuente, puedes reemplazar esa fuente por otra fuente. Todas las instancias de la fuente antigua serán reemplazadas por la nueva fuente.

Aspose.Slides te permite reemplazar una fuente de esta manera:

1. Carga la presentación relevante.
2. Carga la fuente que será reemplazada.
3. Carga la nueva fuente. 
4. Reemplaza la fuente. 
5. Escribe la presentación modificada como un archivo PPTX.

Este código PHP demuestra el reemplazo de fuentes:

```php
  # Carga una presentación
  $pres = new Presentation("Fonts.pptx");
  try {
    # Carga la fuente de origen que será reemplazada
    $sourceFont = new FontData("Arial");
    # Carga la nueva fuente
    $destFont = new FontData("Times New Roman");
    # Reemplaza las fuentes
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Guarda la presentación
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Nota" color="warning" %}} 

Para establecer reglas que determinan qué sucede en ciertas condiciones (si una fuente no se puede acceder, por ejemplo), consulta [**Sustitución de Fuentes**](/slides/es/php-java/font-substitution/).

{{% /alert %}}