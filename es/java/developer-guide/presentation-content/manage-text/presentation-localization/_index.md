---
title: Automatizar la localización de presentaciones en Java
linktitle: Localización de presentaciones
type: docs
weight: 100
url: /es/java/presentation-localization/
keywords:
- cambiar idioma
- revisión ortográfica
- identificador de idioma
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Automatiza la localización de diapositivas PowerPoint y OpenDocument en Java con Aspose.Slides, usando ejemplos de código prácticos y consejos para un despliegue global más rápido."
---

## **Cambiar el idioma de una presentación y dar forma al texto**
- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtener la referencia de una diapositiva utilizando su índice.
- Agregar un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) de tipo [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) a la diapositiva.
- Agregar texto al TextFrame.
- [Establecer Id de idioma](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) al texto.
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

No. [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) en Aspose.Slides almacena el idioma para la corrección ortográfica y de gramática, pero no traduce ni modifica el contenido del texto. Es metadatos que PowerPoint interpreta para la revisión.

**¿El ID de idioma afecta la separación silábica y los saltos de línea durante la representación?**

En Aspose.Slides, [language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) se utiliza para la revisión. La calidad de la separación silábica y el ajuste de líneas dependen principalmente de la disponibilidad de [fuentes adecuadas](/slides/es/java/powerpoint-fonts/) y de la configuración de diseño/ruptura de línea para el sistema de escritura. Para garantizar una representación correcta, haga que las fuentes necesarias estén disponibles, configure [reglas de sustitución de fuentes](/slides/es/java/font-substitution/) y/o [incorpore fuentes](/slides/es/java/embedded-font/) en la presentación.

**¿Puedo establecer diferentes idiomas dentro de un solo párrafo?**

Sí. [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) se aplica a nivel de porción de texto, por lo que un solo párrafo puede mezclar varios idiomas con configuraciones de revisión distintas.