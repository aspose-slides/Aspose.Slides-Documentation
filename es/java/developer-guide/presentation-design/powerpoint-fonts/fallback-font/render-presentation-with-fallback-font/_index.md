---
title: Renderizar Presentación con Fuente de Respaldo
type: docs
weight: 30
url: /es/java/render-presentation-with-fallback-font/
---

El siguiente ejemplo incluye estos pasos:

1. [Creamos una colección de reglas de fuentes de respaldo](/slides/es/java/create-fallback-fonts-collection/).
1. [Eliminar](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) una regla de fuente de respaldo y [addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) a otra regla.
1. Establecer la colección de reglas en [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) método.
1. Con el método [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) podemos guardar la presentación en el mismo formato, o guardarla en otro. Después de que la colección de reglas de fuentes de respaldo se establece en [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager), estas reglas se aplican durante cualquier operación sobre la presentación: guardar, renderizar, convertir, etc.

```java
// Crear nueva instancia de una colección de reglas
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// crear una serie de reglas
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Intentando eliminar la fuente de respaldo "Tahoma" de las reglas cargadas
    fallBackRule.remove("Tahoma");

    //Y actualizar reglas para el rango especificado
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

//También podemos eliminar cualquier regla existente de la lista
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    //Asignando una lista de reglas preparadas para su uso
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Renderización de la miniatura utilizando la colección de reglas inicializadas y guardando en JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //Guardar la imagen en el disco en formato JPEG
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
Lee más sobre [Guardar y Conversión en Presentación](/slides/es/java/creating-saving-and-converting-a-presentation/).
{{% /alert %}}