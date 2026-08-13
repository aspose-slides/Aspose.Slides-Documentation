---
title: Renderizar presentaciones con fuentes de respaldo en Java
linktitle: Renderizar presentaciones
type: docs
weight: 30
url: /es/java/render-presentation-with-fallback-font/
keywords:
- fuente de respaldo
- renderizar PowerPoint
- renderizar presentación
- renderizar diapositiva
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Renderizar presentaciones con fuentes de respaldo en Aspose.Slides para Java – mantenga el texto coherente en PPT, PPTX y ODP con ejemplos de código Java paso a paso."
---
## **Visión general**

Aspose.Slides le permite renderizar presentaciones utilizando reglas de fuentes de respaldo. Este artículo muestra cómo crear una colección de reglas de fuentes de respaldo, modificar sus reglas eliminando o añadiendo fuentes de respaldo, y asignar la colección mediante el método `FontsManager.setFontFallBackRulesCollection`.

Una vez que la colección de reglas de fuentes de respaldo se asigna al `FontsManager` de la presentación, las reglas se aplican durante operaciones como guardar, renderizar y convertir la presentación. El ejemplo demuestra cómo usar las reglas configuradas al renderizar una miniatura de diapositiva y guardarla como una imagen JPEG.

## **Renderizar una diapositiva usando reglas de fuentes de respaldo**

El siguiente ejemplo incluye estos pasos:

1. Creamos la [colección de reglas de fuentes de respaldo](/slides/es/java/create-fallback-fonts-collection/).
1. [Remove](https://reference.aspose.com/slides/es/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) una regla de fuente de respaldo y [addFallBackFonts](https://reference.aspose.com/slides/es/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) a otra regla.
1. Establezca la colección de reglas en [getFontsManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) método.
1. Con el método [Presentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation#save-java.lang.String-int-) podemos guardar la presentación en el mismo formato o guardarla en otro. Después de que la colección de reglas de fuentes de respaldo se asigna al [FontsManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/FontsManager), estas reglas se aplican durante cualquier operación sobre la presentación: guardar, renderizar, convertir, etc.

```java
import com.aspose.slides.*;

// Crear una nueva instancia de una colección de reglas
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Intentar eliminar la fuente de respaldo "Tahoma" de las reglas cargadas
    fallBackRule.remove("Tahoma");

    //Y actualizar las reglas para el rango especificado
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

//También podemos eliminar cualquier regla existente de la lista, manteniendo al menos una regla para renderizar
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    //Asignar una lista de reglas preparada para su uso
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Renderizar una miniatura usando la colección de reglas inicializada y guardarla como JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //Guardar la imagen en disco en formato JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Obtenga más información sobre cómo [Convertir PPT y PPTX a JPG en Java](/slides/es/java/convert-powerpoint-to-jpg/).
{{% /alert %}}