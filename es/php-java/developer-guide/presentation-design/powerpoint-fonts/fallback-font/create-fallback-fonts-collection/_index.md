---
title: Configurar colecciones de fuentes de reserva en PHP
linktitle: Colección de fuentes de reserva
type: docs
weight: 20
url: /es/php-java/create-fallback-fonts-collection/
keywords:
- fuente de reserva
- regla de reserva
- colección de fuentes
- configurar fuente
- establecer fuente
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Configure una colección de fuentes de reserva en Aspose.Slides para PHP mediante Java para mantener el texto consistente y nítido en presentaciones de PowerPoint y OpenDocument."
---

## **Aplicar reglas de reserva**

Las instancias de la clase [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) pueden organizarse en una [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection). Es posible añadir o eliminar reglas de la colección.

Luego esta colección puede asignarse al método [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) de la clase [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager). FontsManager controla las fuentes en toda la presentación.

Cada [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) dispone de un método [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) con su propia instancia de la clase [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager).

Aquí hay un ejemplo de cómo crear una colección de reglas de fuentes de reserva y asignarla al [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) de una presentación determinada:  
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


Una vez que FontsManager se inicializa con la colección de fuentes de reserva, las fuentes de reserva se aplican durante la renderización de la presentación.

{{% alert color="primary" %}} 
Obtén más información sobre cómo [Renderizar presentación con fuente de reserva](/slides/es/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se incorporarán mis reglas de reserva al archivo PPTX y serán visibles en PowerPoint después de guardar?**

No. Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución; no se serializan en el PPTX y no aparecerán en la interfaz de PowerPoint.

**¿Se aplica la reserva al texto dentro de SmartArt, WordArt, gráficos y tablas?**

Sí. Se utiliza el mismo mecanismo de sustitución de glifos para cualquier texto en estos objetos.

**¿Aspose distribuye alguna fuente con la biblioteca?**

No. Usted añade y utiliza las fuentes por su cuenta y bajo su propia responsabilidad.

**¿Se pueden usar conjuntamente la sustitución/reemplazo de fuentes faltantes y la reserva de glifos faltantes?**

Sí. Son etapas independientes del mismo pipeline de resolución de fuentes: primero el motor resuelve la disponibilidad de fuentes ([replacement](/slides/es/php-java/font-replacement/)/[substitution](/slides/es/php-java/font-substitution/)), luego la reserva cubre los vacíos de glifos faltantes en las fuentes disponibles.