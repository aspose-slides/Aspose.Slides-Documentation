---
title: Automatizar la localización de presentaciones en Android
linktitle: Localización de presentaciones
type: docs
weight: 100
url: /es/androidjava/presentation-localization/
keywords:
- cambiar idioma
- corrector ortográfico
- identificador de idioma
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Automatiza la localización de diapositivas de PowerPoint y OpenDocument en Java con Aspose.Slides para Android, utilizando ejemplos de código prácticos y consejos para un despliegue global más rápido."
---

## **Cambiar el idioma de una presentación y del texto de la forma**
- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtener la referencia de una diapositiva usando su índice.
- Añadir un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de tipo [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) a la diapositiva.
- Añadir texto al TextFrame.
- [Establecer Language Id](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) al texto.
- Guardar la presentación como archivo PPTX.

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

No. [Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) en Aspose.Slides almacena el idioma para la corrección ortográfica y de gramática, pero no traduce ni cambia el contenido del texto. Es metadata que PowerPoint entiende para la revisión.

**¿El ID de idioma afecta la separación en sílabas y los saltos de línea durante la renderización?**

En Aspose.Slides, el [language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) es para la revisión. La calidad de la separación en sílabas y el ajuste de línea dependen principalmente de la disponibilidad de [proper fonts](/slides/es/androidjava/powerpoint-fonts/) y de la configuración de diseño/saltos de línea para el sistema de escritura. Para asegurar una renderización correcta, haga que las fuentes requeridas estén disponibles, configure [font substitution rules](/slides/es/androidjava/font-substitution/) y/o [embed fonts](/slides/es/androidjava/embedded-font/) en la presentación.

**¿Puedo establecer diferentes idiomas dentro de un solo párrafo?**

Sí. El [Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) se aplica a nivel de porción de texto, por lo que un solo párrafo puede mezclar varios idiomas con distintas configuraciones de revisión.