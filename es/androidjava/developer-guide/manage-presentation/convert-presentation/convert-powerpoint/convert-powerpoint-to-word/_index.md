---
title: Convertir presentaciones de PowerPoint a documentos Word en Android
linktitle: PowerPoint a Word
type: docs
weight: 110
url: /es/androidjava/convert-powerpoint-to-word/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a Word
- presentación a Word
- diapositiva a Word
- PPT a Word
- PPTX a Word
- PowerPoint a DOCX
- presentación a DOCX
- diapositiva a DOCX
- PPT a DOCX
- PPTX a DOCX
- PowerPoint a DOC
- presentación a DOC
- diapositiva a DOC
- PPT a DOC
- PPTX a DOC
- guardar PPT como DOCX
- guardar PPTX como DOCX
- exportar PPT a DOCX
- exportar PPTX a DOCX
- Android
- Java
- Aspose.Slides
description: "Convertir diapositivas PowerPoint PPT y PPTX a documentos Word editables en Java usando Aspose.Slides para Android con un diseño preciso, imágenes y formato conservados."
---

Si planeas usar contenido textual o información de una presentación (PPT o PPTX) de nuevas maneras, podrías beneficiarte al convertir la presentación a Word (DOC o DOCX). 

* En comparación con Microsoft PowerPoint, la aplicación Microsoft Word está más equipada con herramientas o funcionalidades para el contenido. 
* Además de las funciones de edición en Word, también puedes beneficiarte de una mayor colaboración, impresión y características para compartir. 

{{% alert color="primary" %}} 

Puede que quieras probar nuestro [**Convertidor en línea de Presentación a Word**](https://products.aspose.app/slides/conversion/ppt-to-word) para ver lo que podrías ganar al trabajar con contenido textual de las diapositivas. 

{{% /alert %}} 

## **Aspose.Slides y Aspose.Words**

Para convertir un archivo PowerPoint (PPTX o PPT) a Word (DOCX o DOCX), necesitas tanto [Aspose.Slides para Android via Java](https://products.aspose.com/slides/androidjava/) como [Aspose.Words para Android via Java](https://products.aspose.com/words/android-java/).

Como API independiente, [Aspose.Slides](https://products.aspose.app/slides) para java ofrece funciones que permiten extraer textos de presentaciones. 

[Aspose.Words](https://docs.aspose.com/words/androidjava/) es una API avanzada de procesamiento de documentos que permite a las aplicaciones generar, modificar, convertir, renderizar, imprimir archivos y realizar otras tareas con documentos sin utilizar Microsoft Word.

## **Convertir PowerPoint a Word**

1. Descarga las librerías [Aspose.Slides para Android via Java](https://downloads.aspose.com/slides/java) y [Aspose.Words para Java](https://downloads.aspose.com/words/java).
2. Añade *aspose-slides-x.x-jdk16.jar* y *aspose-words-x.x-jdk16.jar* a tu CLASSPATH.
3. Utiliza este fragmento de código para convertir el PowerPoint a Word:
```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // genera una imagen de la diapositiva como flujo de bytes
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


## **Preguntas frecuentes**

**¿Qué componentes necesitan instalarse para convertir presentaciones PowerPoint y OpenDocument a documentos Word?**

Solo necesitas añadir el paquete correspondiente de [Aspose.Slides para Android via Java](https://releases.aspose.com/slides/androidjava/) y [Aspose.Words para Android via Java](https://releases.aspose.com/words/androidjava/) a tu proyecto. Ambas bibliotecas funcionan como APIs independientes y no es necesario que Microsoft Office esté instalado.

**¿Se admiten todos los formatos de presentación PowerPoint y OpenDocument?**

Aspose.Slides [admite todos los formatos de presentación](/slides/es/androidjava/supported-file-formats/), incluidos PPT, PPTX, ODP y otros tipos de archivo comunes. Esto garantiza que puedas trabajar con presentaciones creadas en distintas versiones de Microsoft PowerPoint.