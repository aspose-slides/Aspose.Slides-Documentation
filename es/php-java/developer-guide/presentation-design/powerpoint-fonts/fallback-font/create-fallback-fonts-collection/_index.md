---
title: Crear Colección de Fuentes de Respaldo
type: docs
weight: 20
url: /es/php-java/create-fallback-fonts-collection/
---

Las instancias de la clase [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) se pueden organizar en [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection), que implementa la interfaz [IFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRulesCollection). Es posible agregar o eliminar reglas de la colección.

Luego, esta colección puede ser asignada al método [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) de la clase [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager). FontsManager controla las fuentes a través de la presentación. Lea más [Sobre FontsManager y FontsLoader](/slides/es/php-java/about-fontsmanager-and-fontsloader/).

Cada [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) tiene un método [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) con su propia instancia de la clase [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager).

Aquí hay un ejemplo de cómo crear una colección de reglas de fuentes de respaldo y asignarla al [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) de una presentación determinada:

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Después de que FontsManager se inicializa con la colección de fuentes de respaldo, las fuentes de respaldo se aplican durante el renderizado de la presentación.

{{% alert color="primary" %}} 
Lea más sobre cómo [Renderizar Presentación con Fuente de Respaldo](/slides/es/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}