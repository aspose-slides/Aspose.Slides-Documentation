---
title: Localización de Presentaciones
type: docs
weight: 100
url: /androidjava/presentation-localization/
---

## **Cambiar el Idioma para el Texto de la Presentación y de la Forma**
- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtener la referencia de una diapositiva utilizando su Índice.
- Agregar una [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de tipo [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) a la diapositiva.
- Agregar texto al TextFrame.
- [Establecer el Id del Idioma](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) al texto.
- Escribir la presentación como un archivo PPTX.

La implementación de los pasos anteriores se demuestra a continuación con un ejemplo.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Texto para aplicar idioma de corrección ortográfica");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```