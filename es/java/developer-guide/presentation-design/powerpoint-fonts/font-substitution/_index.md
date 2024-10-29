---
title: Sustitución de Fuentes - PowerPoint Java API
linktitle: Sustitución de Fuentes
type: docs
weight: 70
url: /es/java/font-substitution/
keywords: "Fuente, fuente sustituta, presentación de PowerPoint, Java, Aspose.Slides para Java"
description: "Sustitución de fuente en PowerPoint en Java"
---

Aspose.Slides te permite establecer reglas para las fuentes que determinan qué debe hacerse en ciertas condiciones (por ejemplo, cuando no se puede acceder a una fuente) de la siguiente manera:

1. Cargar la presentación relevante.
2. Cargar la fuente que será reemplazada.
3. Cargar la nueva fuente.
4. Añadir una regla para el reemplazo.
5. Añadir la regla a la colección de reglas de sustitución de fuentes de la presentación.
6. Generar la imagen de la diapositiva para observar el efecto.

Este código Java demuestra el proceso de sustitución de fuentes:

```java
// Carga una presentación
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Carga la fuente de origen que será reemplazada
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Carga la nueva fuente
    IFontData destFont = new FontData("Arial");
    
    // Añade una regla de fuente para la sustitución de fuentes
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Añade la regla a la colección de reglas de sustitución de fuentes
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Añade una colección de reglas de fuentes a la lista de reglas
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // La fuente Arial se utilizará en lugar de SomeRareFont cuando esta última sea inaccesible
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Guarda la imagen en disco en formato JPEG
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

Es posible que desees ver [**Reemplazo de Fuentes**](/slides/es/java/font-replacement/). 

{{% /alert %}}