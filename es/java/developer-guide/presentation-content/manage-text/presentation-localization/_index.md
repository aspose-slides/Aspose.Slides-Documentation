---
title: Automatizar la localización de presentaciones en Java
linktitle: Localización de presentaciones
type: docs
weight: 100
url: /es/java/presentation-localization/
keywords:
- cambiar idioma
- corrector ortográfico
- id de idioma
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Automatiza la localización de diapositivas PowerPoint y OpenDocument en Java con Aspose.Slides, usando ejemplos de código prácticos y consejos para un despliegue global más rápido."
---

## **Cambiar el idioma para la presentación y el texto de la forma**
- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtener la referencia de una diapositiva usando su índice.
- Agregar un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) de tipo [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) a la diapositiva.
- Agregar texto al TextFrame.
- [Setting Language Id](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) al texto.
- Guardar la presentación como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación en un ejemplo.
```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿El ID de idioma activa la traducción automática del texto?**

No. El [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) en Aspose.Slides almacena el idioma para la corrección ortográfica y la revisión gramatical, pero no traduce ni cambia el contenido del texto. Es metadatos que PowerPoint entiende para la revisión.

**¿El ID de idioma afecta la separación silábica y los saltos de línea durante la renderización?**

En Aspose.Slides, el [language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) se usa para la revisión. La calidad de la separación silábica y el ajuste de línea dependen principalmente de la disponibilidad de [proper fonts](/slides/es/java/powerpoint-fonts/) y la configuración de diseño/saltos de línea para el sistema de escritura. Para asegurar una renderización correcta, haga que las fuentes requeridas estén disponibles, configure las [font substitution rules](/slides/es/java/font-substitution/) y/o [embed fonts](/slides/es/java/embedded-font/) en la presentación.

**¿Puedo establecer diferentes idiomas dentro de un solo párrafo?**

Sí. El [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) se aplica a nivel de porción de texto, por lo que un solo párrafo puede mezclar varios idiomas con configuraciones de revisión distintas.