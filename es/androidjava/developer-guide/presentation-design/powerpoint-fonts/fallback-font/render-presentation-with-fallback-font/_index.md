---
title: Renderizar presentaciones con fuentes de reserva en Android
linktitle: Renderizar presentaciones
type: docs
weight: 30
url: /es/androidjava/render-presentation-with-fallback-font/
keywords:
- fuente de reserva
- renderizar PowerPoint
- renderizar presentación
- renderizar diapositiva
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Renderiza presentaciones con fuentes de reserva en Aspose.Slides para Android – mantiene el texto coherente en PPT, PPTX y ODP con ejemplos de código Java paso a paso."
---

El siguiente ejemplo incluye estos pasos:

1. Nosotros [creamos la colección de reglas de fuentes de reserva](/slides/es/androidjava/create-fallback-fonts-collection/).
1. [Eliminar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) una regla de fuente de reserva y [addFallBackFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) a otra regla.
1. Establecer la colección de reglas en el método [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) .
1. Con el método [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) podemos guardar la presentación en el mismo formato o en otro diferente. Después de que la colección de reglas de fuentes de reserva se establece en [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager), esas reglas se aplican durante cualquier operación sobre la presentación: guardar, renderizar, convertir, etc.
```java
// Crear una nueva instancia de una colección de reglas
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Intentar eliminar la fuente de reserva "Tahoma" de las reglas cargadas
    fallBackRule.remove("Tahoma");

    // Y actualizar las reglas para el rango especificado
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Also we can remove any existing rules from list
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Asignar una lista de reglas preparada para su uso
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Renderizar la miniatura usando la colección de reglas inicializada y guardarla en JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Guardar la imagen en disco en formato JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
Lea más sobre [Convert PPT and PPTX to JPG on Android](/slides/es/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}