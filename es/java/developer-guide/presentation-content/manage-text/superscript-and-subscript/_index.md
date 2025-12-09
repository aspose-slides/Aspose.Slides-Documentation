---
title: Administrar superíndice y subíndice en presentaciones usando Java
linktitle: Superíndice y subíndice
type: docs
weight: 80
url: /es/java/superscript-and-subscript/
keywords:
- superíndice
- subíndice
- agregar superíndice
- agregar subíndice
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Domina el superíndice y el subíndice en Aspose.Slides para Java y mejora tus presentaciones con un formato de texto profesional para lograr el máximo impacto."
---

## **Gestionar texto en superíndice y subíndice**
Puede agregar texto en superíndice y subíndice dentro de cualquier porción de párrafo. Para agregar texto en superíndice o subíndice en el marco de texto de Aspose.Slides, debe usar el método [**setEscapement**](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) de la clase [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PortionFormat).

Esta propiedad devuelve o establece el texto en superíndice o subíndice (valor de -100% (subíndice) a 100% (superíndice)). Por ejemplo:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Agregue un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) de tipo [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) a la diapositiva.
- Acceda al [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) asociado con el [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
- Borre los párrafos existentes.
- Cree un nuevo objeto de párrafo para contener texto en superíndice y agréguelo a la [IParagraphs collection](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getParagraphs--) del [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame).
- Cree un nuevo objeto Portion.
- Establezca la propiedad Escapement para la porción entre 0 y 100 para agregar superíndice. (0 significa sin superíndice)
- Establezca algún texto para [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) y luego agréguelo a la colección de porciones del párrafo.
- Cree un nuevo objeto de párrafo para contener texto en subíndice y agréguelo a la IParagraphs collection del ITextFrame.
- Cree un nuevo objeto Portion.
- Establezca la propiedad Escapement para la porción entre 0 y -100 para agregar subíndice. (0 significa sin subíndice)
- Establezca algún texto para [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) y luego agréguelo a la colección de porciones del párrafo.
- Guarde la presentación como archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```java
// Instanciar una clase Presentation que representa un PPTX
Presentation pres = new Presentation();
try {
    // Obtener la diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Crear cuadro de texto
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Crear párrafo para texto en superíndice
    IParagraph superPar = new Paragraph();

    // Crear porción con texto normal
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Crear porción con texto en superíndice
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Crear párrafo para texto en subíndice
    IParagraph paragraph2 = new Paragraph();

    // Crear porción con texto normal
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Crear porción con texto en subíndice
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


## **Preguntas frecuentes**

**¿Se conservará el superíndice y el subíndice al exportar a PDF u otros formatos?**

Sí, Aspose.Slides conserva correctamente el formato de superíndice y subíndice al exportar presentaciones a PDF, PPT/PPTX, imágenes y otros formatos compatibles. El formato especializado permanece intacto en todos los archivos de salida.

**¿Se pueden combinar superíndice y subíndice con otros estilos de formato como negrita o cursiva?**

Sí, Aspose.Slides permite mezclar varios estilos de texto dentro de una única porción. Puede habilitar negrita, cursiva, subrayado y, simultáneamente, aplicar superíndice o subíndice configurando las propiedades correspondientes en [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/).

**¿El formato de superíndice y subíndice funciona para texto dentro de tablas, gráficos o SmartArt?**

Sí, Aspose.Slides admite el formato dentro de la mayoría de los objetos, incluidas tablas y elementos de gráficos. Al trabajar con SmartArt, debe acceder a los elementos correspondientes (como [SmartArtNode](https://reference.aspose.com/slides/java/com.aspose.slides/smartartnode/)) y sus contenedores de texto, y luego configurar las propiedades de [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) de manera similar.