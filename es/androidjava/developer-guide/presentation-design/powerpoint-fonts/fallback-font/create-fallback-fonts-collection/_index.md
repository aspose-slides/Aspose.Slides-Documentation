---
title: Configurar colecciones de fuentes de reserva en Android
linktitle: Colección de fuentes de reserva
type: docs
weight: 20
url: /es/androidjava/create-fallback-fonts-collection/
keywords:
- fuente de reserva
- regla de reserva
- colección de fuentes
- configurar fuente
- establecer fuente
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Configure una colección de fuentes de reserva en Aspose.Slides para Android mediante Java para mantener el texto consistente y nítido en presentaciones de PowerPoint y OpenDocument."
---

## **Aplicar reglas de reserva**

Las instancias de la clase [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) pueden organizarse en [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection), que implementa la interfaz [IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection). Es posible agregar o eliminar reglas de la colección.

Luego esta colección puede asignarse al método [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) de la clase [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager). FontsManager controla las fuentes en toda la presentación. Lee más [Acerca de FontsManager y FontsLoader](/slides/es/androidjava/about-fontsmanager-and-fontsloader/).

Cada [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) tiene un método [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) con su propia instancia de la clase [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager).

A continuación se muestra un ejemplo de cómo crear una colección de reglas de fuentes de reserva y asignarla al [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) de una presentación determinada:  
```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```


Después de que FontsManager se inicializa con la colección de fuentes de reserva, las fuentes de reserva se aplican durante la renderización de la presentación.

{{% alert color="primary" %}} 
Lee más cómo [Renderizar presentación con fuente de reserva](/slides/es/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se incrustarán mis reglas de reserva en el archivo PPTX y serán visibles en PowerPoint después de guardarlo?**

No. Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución; no se serializan en el PPTX y no aparecerán en la interfaz de PowerPoint.

**¿Se aplica la reserva a texto dentro de SmartArt, WordArt, gráficos y tablas?**

Sí. Se utiliza el mismo mecanismo de sustitución de glifos para cualquier texto en estos objetos.

**¿Distribuye Aspose alguna fuente con la biblioteca?**

No. Usted agrega y usa fuentes por su cuenta y bajo su propia responsabilidad.

**¿Se pueden usar conjuntamente el reemplazo/sustitución de fuentes faltantes y la reserva para glifos faltantes?**

Sí. Son etapas independientes del mismo proceso de resolución de fuentes: primero el motor resuelve la disponibilidad de fuentes ([replacement](/slides/es/androidjava/font-replacement/)/[substitution](/slides/es/androidjava/font-substitution/)), luego la reserva cubre los huecos de glifos faltantes en las fuentes disponibles.