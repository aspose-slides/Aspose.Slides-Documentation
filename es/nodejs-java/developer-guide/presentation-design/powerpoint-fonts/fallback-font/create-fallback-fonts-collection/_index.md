---
title: Crear colección de fuentes de reserva
type: docs
weight: 20
url: /es/nodejs-java/create-fallback-fonts-collection/
---

## **Aplicar reglas de reserva**

Instancias de [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) pueden organizarse en [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection), que implementa la clase [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection). Es posible agregar o eliminar reglas de la colección.

Luego esta colección puede asignarse al método [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) de la clase [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager). FontsManager controla las fuentes en toda la presentación. Lee más [About FontsManager and FontsLoader](/slides/es/nodejs-java/about-fontsmanager-and-fontsloader/).

Cada [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) tiene un método [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) con su propia instancia de la clase [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager).

Aquí hay un ejemplo de cómo crear una colección de reglas de fuentes de reserva y asignarla al [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) de una presentación concreta:  
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


Después de que FontsManager se inicialice con la colección de fuentes de reserva, las fuentes de reserva se aplican durante la renderización de la presentación.

{{% alert color="primary" %}} 
Lee más cómo [Render Presentation with Fallback Font](/slides/es/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**¿Se incrustarán mis reglas de reserva en el archivo PPTX y serán visibles en PowerPoint después de guardar?**

No. Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución; no se serializan en el PPTX y no aparecerán en la interfaz de PowerPoint.

**¿La reserva se aplica al texto dentro de SmartArt, WordArt, gráficos y tablas?**

Sí. Se utiliza el mismo mecanismo de sustitución de glifos para cualquier texto en estos objetos.

**¿Aspose distribuye fuentes con la biblioteca?**

No. Usted agrega y usa fuentes por su cuenta y bajo su propia responsabilidad.

**¿Se pueden usar conjuntamente el reemplazo/sustitución de fuentes faltantes y la reserva para glifos faltantes?**

Sí. Son etapas independientes del mismo proceso de resolución de fuentes: primero el motor resuelve la disponibilidad de fuentes ([replacement](/slides/es/nodejs-java/font-replacement/)/[substitution](/slides/es/nodejs-java/font-substitution/)), luego la reserva llena los huecos de glifos faltantes en las fuentes disponibles.