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
description: "Configura una colección de fuentes de reserva en Aspose.Slides para Android mediante Java para mantener el texto coherente y nítido en presentaciones de PowerPoint y OpenDocument."
---
## **Visión general**

Aspose.Slides permite configurar una colección de reglas de fuentes de reserva para una presentación. Cada regla de reserva se representa con la clase `FontFallBackRule` y puede añadirse a una `FontFallBackRulesCollection`, que implementa la interfaz `IFontFallBackRulesCollection`.

Después de crear la colección, puede asignarla a la propiedad `FontFallBackRulesCollection` del `FontsManager` de la presentación. El `FontsManager` controla las fuentes en toda la presentación, y cada instancia de `Presentation` tiene su propio `FontsManager`.

Una vez que el `FontsManager` se inicializa con la colección de fuentes de reserva, las fuentes de reserva especificadas se aplican durante la renderización de la presentación.

## **Aplicar reglas de reserva**

Las instancias de la clase [FontFallBackRule](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontFallBackRule) pueden organizarse en una [FontFallBackRulesCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontFallBackRulesCollection), que implementa la interfaz [IFontFallBackRulesCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IFontFallBackRulesCollection). Es posible añadir o eliminar reglas de la colección.

A continuación, esta colección puede asignarse al método [FontFallBackRulesCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontFallBackRulesCollection) de la clase [FontsManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontsManager). FontsManager controla las fuentes en toda la presentación.

Cada [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation) tiene un método [getFontsManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation#getFontsManager--) con su propia instancia de la clase [FontsManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontsManager).

He aquí un ejemplo de cómo crear una colección de reglas de fuentes de reserva y asignarla al [FontsManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation#getFontsManager--) de una presentación concreta:  

```java
import com.aspose.slides.*;

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

Después de que FontsManager se inicialice con la colección de fuentes de reserva, estas fuentes se aplican durante la renderización de la presentación.

{{% alert color="info" %}} 
Lea más sobre [Render Presentation with Fallback Font](/slides/es/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### ¿Se incrustarán mis reglas de reserva en el archivo PPTX y serán visibles en PowerPoint después de guardar?

No. Las reglas de reserva son ajustes de renderizado en tiempo de ejecución; no se serializan en el PPTX y no aparecerán en la interfaz de PowerPoint.

### ¿La reserva se aplica a texto dentro de SmartArt, WordArt, gráficos y tablas?

Sí. El mismo mecanismo de sustitución de glifos se utiliza para cualquier texto en estos objetos.

### ¿Aspose distribuye fuentes con la biblioteca?

No. Usted añade y utiliza fuentes por su cuenta y bajo su propia responsabilidad.

### ¿Puede usarse conjuntamente el reemplazo/sustitución de fuentes faltantes y la reserva para glifos faltantes?

Sí. Son etapas independientes del mismo pipeline de resolución de fuentes: primero el motor resuelve la disponibilidad de fuentes ([replacement](/slides/es/androidjava/font-replacement/)/[substitution](/slides/es/androidjava/font-substitution/)), luego la reserva cubre los huecos de glifos faltantes en fuentes disponibles.