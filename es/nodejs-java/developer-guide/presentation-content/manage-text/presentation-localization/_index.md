---
title: Localización de la presentación
type: docs
weight: 100
url: /es/nodejs-java/presentation-localization/
---

## **Cambiar el idioma de la presentación y del texto de la forma**

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Obtener la referencia de una diapositiva usando su índice.
- Agregar un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) de tipo [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) a la diapositiva.
- Añadir texto al TextFrame.
- [Setting Language Id](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-) al texto.
- Guardar la presentación como archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación en un ejemplo.
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿El ID de idioma activa la traducción automática del texto?**

No. [setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) en Aspose.Slides almacena el idioma para la corrección ortográfica y de gramática, pero no traduce ni modifica el contenido del texto. Son metadatos que PowerPoint entiende para la revisión.

**¿El ID de idioma afecta la hifenación y los saltos de línea durante el renderizado?**

En Aspose.Slides, [setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) es para la revisión. La calidad de la hifenación y el ajuste de línea dependen principalmente de la disponibilidad de [proper fonts](/slides/es/nodejs-java/powerpoint-fonts/) y de la configuración de diseño/salto de línea para el sistema de escritura. Para garantizar un renderizado correcto, haga que las fuentes requeridas estén disponibles, configure [font substitution rules](/slides/es/nodejs-java/font-substitution/) y/o [embed fonts](/slides/es/nodejs-java/embedded-font/) en la presentación.

**¿Puedo establecer diferentes idiomas dentro de un solo párrafo?**

Sí. [setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) se aplica a nivel de porción de texto, por lo que un solo párrafo puede mezclar varios idiomas con configuraciones de revisión distintas.