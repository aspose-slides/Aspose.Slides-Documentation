---
title: Superíndice y Subíndice
type: docs
weight: 80
url: /es/nodejs-java/superscript-and-subscript/
---

## **Administrar texto superíndice y subíndice**

Puede agregar texto superíndice y subíndice dentro de cualquier porción de párrafo. Para agregar texto superíndice o subíndice en el marco de texto de Aspose.Slides se debe usar el método [**setEscapement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) de la clase [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat).

Esta propiedad devuelve o establece el texto superíndice o subíndice (valor de -100 % (subíndice) a 100 % (superíndice)). Por ejemplo:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Agregue una [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) de tipo [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) a la diapositiva.
- Acceda al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) asociado con la [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
- Elimine los párrafos existentes.
- Cree un nuevo objeto de párrafo para contener texto superíndice y agréguelo a la [Paragraphs collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getParagraphs--) del [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).
- Cree un nuevo objeto de porción.
- Establezca la propiedad Escapement para la porción entre 0 y 100 para agregar superíndice. (0 significa sin superíndice)
- Establezca algún texto para [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) y luego agréguelo a la colección de porciones del párrafo.
- Cree un nuevo objeto de párrafo para contener texto subíndice y agréguelo a la colección IParagraphs del ITextFrame.
- Cree un nuevo objeto de porción.
- Establezca la propiedad Escapement para la porción entre 0 y -100 para agregar subíndice. (0 significa sin subíndice)
- Establezca algún texto para [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) y luego agréguelo a la colección de porciones del párrafo.
- Guarde la presentación como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```javascript
// Instanciar una clase Presentation que representa un PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtener diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Crear cuadro de texto
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // Crear párrafo para texto superíndice
    var superPar = new aspose.slides.Paragraph();
    // Crear porción con texto normal
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // Crear porción con texto superíndice
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // Crear párrafo para texto subíndice
    var paragraph2 = new aspose.slides.Paragraph();
    // Crear porción con texto normal
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // Crear porción con texto subíndice
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // Agregar párrafos al cuadro de texto
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Se conservará el superíndice y subíndice al exportar a PDF u otros formatos?**

Sí, Aspose.Slides conserva correctamente el formato de superíndice y subíndice al exportar presentaciones a PDF, PPT/PPTX, imágenes y otros formatos compatibles. El formato especializado permanece intacto en todos los archivos de salida.

**¿Se pueden combinar superíndice y subíndice con otros estilos de formato como negrita o cursiva?**

Sí, Aspose.Slides le permite mezclar varios estilos de texto dentro de una única porción. Puede activar negrita, cursiva, subrayado y, simultáneamente, aplicar superíndice o subíndice configurando las propiedades correspondientes en [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/).

**¿Funciona el formato de superíndice y subíndice para texto dentro de tablas, gráficos o SmartArt?**

Sí, Aspose.Slides admite el formato dentro de la mayoría de los objetos, incluidas tablas y elementos de gráficos. Al trabajar con SmartArt, debe acceder a los elementos apropiados (como [SmartArtNode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/)) y sus contenedores de texto, y luego configurar las propiedades de [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) de manera similar.