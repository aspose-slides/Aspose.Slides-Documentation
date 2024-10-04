---
title: Superíndices y Subíndices
type: docs
weight: 80
url: /java/superscript-and-subscript/
---

## **Gestionar texto de superíndice y subíndice**
Puedes agregar texto de superíndice y subíndice dentro de cualquier parte del párrafo. Para agregar texto de superíndice o subíndice en el marco de texto de Aspose.Slides, se debe utilizar el [**setEscapement**](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) del clase [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PortionFormat).

Esta propiedad devuelve o establece el texto de superíndice o subíndice (valor de -100% (subíndice) a 100% (superíndice)). Por ejemplo:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtén la referencia de una diapositiva utilizando su índice.
- Agrega un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) de tipo [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) a la diapositiva.
- Accede al [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) asociado con el [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
- Limpia los párrafos existentes.
- Crea un nuevo objeto de párrafo para contener texto de superíndice y agrégalo a la [colección IParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getParagraphs--) del [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame).
- Crea un nuevo objeto de porción.
- Establece la propiedad de Escapement para la porción entre 0 y 100 para agregar superíndice. (0 significa sin superíndice).
- Establece un texto para [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) y luego agrégalo a la colección de porciones del párrafo.
- Crea un nuevo objeto de párrafo para contener texto de subíndice y agrégalo a la colección IParagraphs del ITextFrame.
- Crea un nuevo objeto de porción.
- Establece la propiedad de Escapement para la porción entre 0 y -100 para agregar subíndice. (0 significa sin subíndice).
- Establece un texto para [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) y luego agrégalo a la colección de porciones del párrafo.
- Guarda la presentación como un archivo PPTX.

La implementación de los pasos anteriores se proporciona a continuación.

```java
// Instanciar una clase Presentation que representa un PPTX
Presentation pres = new Presentation();
try {
    // Obtener diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Crear cuadro de texto
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Crear párrafo para texto de superíndice
    IParagraph superPar = new Paragraph();

    // Crear porción con texto habitual
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Crear porción con texto de superíndice
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Crear párrafo para texto de subíndice
    IParagraph paragraph2 = new Paragraph();

    // Crear porción con texto habitual
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Crear porción con texto de subíndice
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Agregar párrafos al cuadro de texto
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```