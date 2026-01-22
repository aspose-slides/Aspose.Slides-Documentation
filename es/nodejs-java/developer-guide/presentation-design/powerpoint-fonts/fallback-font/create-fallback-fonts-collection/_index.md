---
title: Configurar colecciones de fuentes de sustitución en JavaScript
linktitle: Colección de fuentes de sustitución
type: docs
weight: 20
url: /es/nodejs-java/create-fallback-fonts-collection/
keywords:
- fuente de sustitución
- regla de sustitución
- colección de fuentes
- configurar fuente
- establecer fuente
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Configura una colección de fuentes de sustitución en JavaScript con Aspose.Slides para Node.js para mantener el texto coherente y nítido en presentaciones de PowerPoint y OpenDocument."
---

## **Aplicar reglas de sustitución**

Las instancias de la clase [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) pueden organizarse en una [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection), que implementa la clase [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection). Es posible añadir o eliminar reglas de la colección.

Luego esta colección puede asignarse al método [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) de la clase [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager). FontsManager controla las fuentes en toda la presentación.

Cada [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) dispone de un método [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) con su propia instancia de la clase [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager).

A continuación se muestra un ejemplo de cómo crear una colección de reglas de fuentes de sustitución y asignarla al [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) de una presentación determinada:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Una vez que FontsManager se inicializa con la colección de fuentes de sustitución, las fuentes de sustitución se aplican durante la renderización de la presentación.

{{% alert color="primary" %}} 
Obtenga más información sobre cómo [Renderizar presentación con fuente de sustitución](/slides/es/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se incrustarán mis reglas de sustitución en el archivo PPTX y serán visibles en PowerPoint después de guardar?**

No. Las reglas de sustitución son configuraciones de renderizado en tiempo de ejecución; no se serializan en el PPTX y no aparecerán en la interfaz de PowerPoint.

**¿Se aplica la sustitución al texto dentro de SmartArt, WordArt, gráficos y tablas?**

Sí. Se utiliza el mismo mecanismo de sustitución de glifos para cualquier texto en estos objetos.

**¿Aspose distribuye fuentes con la biblioteca?**

No. Usted añade y utiliza fuentes por su cuenta y bajo su propia responsabilidad.

**¿Se pueden usar conjuntamente el reemplazo/sustitución de fuentes faltantes y la sustitución para glifos faltantes?**

Sí. Son fases independientes del mismo canal de resolución de fuentes: primero el motor resuelve la disponibilidad de fuentes ([replacement](/slides/es/nodejs-java/font-replacement/)/[substitution](/slides/es/nodejs-java/font-substitution/)), luego la sustitución cubre los huecos de glifos faltantes en las fuentes disponibles.