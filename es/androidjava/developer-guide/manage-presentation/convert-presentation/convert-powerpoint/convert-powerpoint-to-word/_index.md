---
title: Convertir PowerPoint a Word
type: docs
weight: 110
url: /es/androidjava/convert-powerpoint-to-word/
keywords: "Convertir PowerPoint, PPT, PPTX, Presentación, Word, DOCX, DOC, PPTX a DOCX, PPT a DOC, PPTX a DOC, PPT a DOCX, Java, java, Aspose.Slides"
description: "Convertir Presentación de PowerPoint a Word en Java"
---

Si planeas usar contenido textual o información de una presentación (PPT o PPTX) de nuevas maneras, podrías beneficiarte al convertir la presentación a Word (DOC o DOCX).

* En comparación con Microsoft PowerPoint, la aplicación Microsoft Word está más equipada con herramientas o funcionalidades para el contenido. 
* Además de las funciones de edición en Word, también puedes beneficiarte de una colaboración mejorada, impresión y características de compartición.

{{% alert color="primary" %}} 

Puede que desees probar nuestro [**Convertidor en Línea de Presentación a Word**](https://products.aspose.app/slides/conversion/ppt-to-word) para ver qué podrías ganar al trabajar con contenido textual de las diapositivas.

{{% /alert %}} 

## **Aspose.Slides y Aspose.Words**

Para convertir un archivo de PowerPoint (PPTX o PPT) a Word (DOCX o DOC), necesitas tanto [Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) como [Aspose.Words for Java](https://products.aspose.com/words/java/).

Como una API independiente, [Aspose.Slides](https://products.aspose.app/slides) para Java proporciona funciones que te permiten extraer textos de presentaciones.

[Aspose.Words](https://docs.aspose.com/words/java/) es una API avanzada de procesamiento de documentos que permite a las aplicaciones generar, modificar, convertir, renderizar, imprimir archivos y realizar otras tareas con documentos sin utilizar Microsoft Word.

## **Convertir PowerPoint a Word**

1. Descarga las bibliotecas [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/java) y [Aspose.Words for Java](https://downloads.aspose.com/words/java).
2. Agrega *aspose-slides-x.x-jdk16.jar* y *aspose-words-x.x-jdk16.jar* a tu CLASSPATH.
3. Usa este fragmento de código para convertir PowerPoint a Word:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // genera una imagen de la diapositiva como un flujo de bytes
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // inserta los textos de la diapositiva
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```