---
title: Crear Colección de Fuentes de Respaldo
type: docs
weight: 20
url: /es/androidjava/create-fallback-fonts-collection/
---

Las instancias de la clase [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) pueden organizarse en [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection), que implementa la interfaz [IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection). Es posible agregar o quitar reglas de la colección.

Luego, esta colección puede asignarse al método [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) de la clase [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager). FontsManager controla las fuentes a través de la presentación. Lee más [Acerca de FontsManager y FontsLoader](/slides/es/androidjava/about-fontsmanager-and-fontsloader/).

Cada [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) tiene un método [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) con su propia instancia de la clase [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager).

Aquí hay un ejemplo de cómo crear una colección de reglas de fuentes de respaldo y asignarla al [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) de una presentación determinada:  

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

Después de que FontsManager se inicializa con la colección de fuentes de respaldo, las fuentes de respaldo se aplican durante la representación de la presentación.

{{% alert color="primary" %}} 
Lee más sobre cómo [Renderizar Presentación con Fuente de Respaldo](/slides/es/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}