---
title: Sustitución de fuentes - API de Java de PowerPoint
linktitle: Sustitución de fuentes
type: docs
weight: 60
url: /java/font-replacement/
description: Aprende a reemplazar fuentes utilizando el método de reemplazo explícito en PowerPoint usando la API de Java.
---

Si cambias de opinión sobre el uso de una fuente, puedes reemplazar esa fuente por otra fuente. Todas las instancias de la fuente antigua serán reemplazadas por la nueva fuente.

Aspose.Slides te permite reemplazar una fuente de esta manera:

1. Carga la presentación relevante. 
2. Carga la fuente que será reemplazada.
3. Carga la nueva fuente. 
4. Reemplaza la fuente. 
5. Guarda la presentación modificada como un archivo PPTX.

Este código Java demuestra la sustitución de fuentes:

```java
// Carga una presentación
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Carga la fuente de origen que será reemplazada
    IFontData sourceFont = new FontData("Arial");
    
    // Carga la nueva fuente
    IFontData destFont = new FontData("Times New Roman");
    
    // Reemplaza las fuentes
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Guarda la presentación
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Nota" color="warning" %}} 

Para establecer reglas que determinen qué sucede en ciertas condiciones (si una fuente no puede ser accedida, por ejemplo), consulta [**Sustitución de fuentes**](/slides/java/font-substitution/). 

{{% /alert %}}