---
title: Renderizar presentaciones con fuentes de reserva en JavaScript
linktitle: Renderizar presentaciones
type: docs
weight: 30
url: /es/nodejs-java/render-presentation-with-fallback-font/
keywords:
- fuente de reserva
- renderizar PowerPoint
- renderizar presentación
- renderizar diapositiva
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Renderizar presentaciones con fuentes de reserva en Aspose.Slides para Node.js – mantener el texto coherente en PPT, PPTX y ODP con ejemplos de código JavaScript paso a paso."
---

El siguiente ejemplo incluye estos pasos:

1. Creamos la [colección de reglas de fuentes de reserva](/slides/es/nodejs-java/create-fallback-fonts-collection/).
1. [Eliminar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) una regla de fuente de reserva y [addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) a otra regla.
1. Establecer la colección de reglas en [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) método.
1. Con el método [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) podemos guardar la presentación en el mismo formato, o guardarla en otro diferente. Después de que la colección de reglas de fuentes de reserva se establezca en [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager), estas reglas se aplican durante cualquier operación sobre la presentación: guardar, renderizar, convertir, etc.
```javascript
// Crear una nueva instancia de una colección de reglas
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// crear un número de reglas
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Intentando eliminar la fuente de sustitución "Tahoma" de las reglas cargadas
    fallBackRule.remove("Tahoma");
    // Y actualizar las reglas para el rango especificado
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// También podemos eliminar cualquier regla existente de la lista
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Asignando una lista de reglas preparada para usar
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Renderizando una miniatura usando la colección de reglas inicializada y guardando en JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Guardar la imagen en disco en formato JPEG
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}}
Obtenga más información sobre cómo [Convertir PPT y PPTX a JPG en JavaScript](/slides/es/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}