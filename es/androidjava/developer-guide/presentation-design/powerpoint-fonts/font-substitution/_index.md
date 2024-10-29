---
title: Sustitución de Fuentes - API de Java para PowerPoint
linktitle: Sustitución de Fuentes
type: docs
weight: 70
url: /es/androidjava/font-substitution/
keywords: "Fuente, fuente sustituta, presentación de PowerPoint, Java, Aspose.Slides para Android a través de Java"
description: "Sustituir fuente en PowerPoint en Java"
---

Aspose.Slides te permite establecer reglas para fuentes que determinan lo que debe hacerse en ciertas condiciones (por ejemplo, cuando no se puede acceder a una fuente) de la siguiente manera:

1. Carga la presentación relevante.
2. Carga la fuente que será reemplazada.
3. Carga la nueva fuente.
4. Agrega una regla para el reemplazo.
5. Agrega la regla a la colección de reglas de reemplazo de fuentes de la presentación.
6. Genera la imagen de la diapositiva para observar el efecto.

Este código de Java demuestra el proceso de sustitución de fuentes:

```java
// Carga una presentación
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Carga la fuente de origen que será reemplazada
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Carga la nueva fuente
    IFontData destFont = new FontData("Arial");
    
    // Agrega una regla de fuente para el reemplazo de fuentes
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Agrega la regla a la colección de reglas de sustitución de fuentes
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Agrega una colección de reglas de fuente a la lista de reglas
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Se utilizará la fuente Arial en lugar de SomeRareFont cuando esta última sea inaccesible
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Guarda la imagen en el disco en formato JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTA"  color="warning"   %}} 

Es posible que desees ver [**Reemplazo de Fuentes**](/slides/es/androidjava/font-replacement/).

{{% /alert %}}