---
title: Localización de Presentaciones
type: docs
weight: 100
url: /java/presentation-localization/
---

## **Cambiar el idioma del texto de la presentación y de las formas**
- Crear una instancia de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) clase.
- Obtener la referencia de una diapositiva utilizando su índice.
- Añadir una [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) de tipo [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) a la diapositiva.
- Añadir texto al TextFrame.
- [Establecer el Id del idioma](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) al texto.
- Guardar la presentación como un archivo PPTX.

La implementación de los pasos anteriores se demuestra a continuación en un ejemplo.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Texto para aplicar el idioma de corrección ortográfica");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```