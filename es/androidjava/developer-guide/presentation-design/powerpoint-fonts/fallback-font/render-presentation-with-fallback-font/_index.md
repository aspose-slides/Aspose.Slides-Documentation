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
## **Descripción general**

Aspose.Slides permite renderizar presentaciones usando reglas de fuentes de reserva. Este artículo muestra cómo crear una colección de reglas de fuentes de reserva, modificar sus reglas eliminando o añadiendo fuentes de reserva, y asignar la colección mediante el método `FontsManager.setFontFallBackRulesCollection`.

Una vez que la colección de reglas de fuentes de reserva se asigna al `FontsManager` de la presentación, las reglas se aplican durante operaciones como guardar, renderizar y convertir la presentación. El ejemplo demuestra cómo usar las reglas configuradas al renderizar una miniatura de diapositiva y guardarla como imagen JPEG.

## **Renderizar una diapositiva usando reglas de fuentes de reserva**

El siguiente ejemplo incluye estos pasos:

1. [Crear colección de reglas de fuentes de reserva](/slides/es/androidjava/create-fallback-fonts-collection/).
2. [Eliminar](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) una regla de fuente de reserva y [addFallBackFonts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) a otra regla.
3. Establecer la colección de reglas en [getFontsManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) método.
4. Con el método [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) podemos guardar la presentación en el mismo formato, o guardarla en otro distinto. Después de que la colección de reglas de fuentes de reserva se asigna a [FontsManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontsManager), estas reglas se aplican durante cualquier operación sobre la presentación: guardar, renderizar, convertir, etc.

```java
import com.aspose.slides.*;

// Crear nueva instancia de una colección de reglas
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Intentar eliminar la fuente de reserva "Tahoma" de las reglas cargadas
    fallBackRule.remove("Tahoma");

    // Y actualizar las reglas para el rango especificado
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// También podemos eliminar cualquier regla existente de la lista, conservando al menos una regla para renderizar con
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // Asignar una lista de reglas preparada para su uso
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Renderizar la miniatura usando la colección de reglas inicializada y guardarla como JPEG
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

{{% alert color="info" %}} 
Lee más sobre [Convertir PPT y PPTX a JPG en Android](/slides/es/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}