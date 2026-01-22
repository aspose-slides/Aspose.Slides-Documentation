---
title: Importar presentaciones desde PDF o HTML en Android
linktitle: Importar presentación
type: docs
weight: 60
url: /es/androidjava/import-presentation/
keywords:
- importar presentación
- importar diapositiva
- importar PDF
- importar HTML
- PDF a presentación
- PDF a PPT
- PDF a PPTX
- PDF a ODP
- HTML a presentación
- HTML a PPT
- HTML a PPTX
- HTML a ODP
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Importar documentos PDF y HTML a presentaciones PowerPoint y OpenDocument en Java con Aspose.Slides para Android, para un procesamiento de diapositivas fluido y de alto rendimiento."
---

Usando [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/), puedes importar presentaciones desde archivos en otros formatos. Aspose.Slides proporciona la clase [SlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) para permitirte importar presentaciones desde PDF, documentos HTML, etc.

## **Importar PowerPoint desde PDF**

En este caso, puedes convertir un PDF en una presentación PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-a-powerpoint" style="zoom:50%;" />

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/).
2. Llama al método [addFromPdf()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) y pasa el archivo PDF.
3. Utiliza el método [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) para guardar el archivo en formato PowerPoint.

Este código Java muestra la operación de PDF a PowerPoint:
```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert  title="Tip" color="primary" %}} 

Puede que quieras probar la aplicación web gratuita de Aspose **PDF to PowerPoint**(https://products.aspose.app/slides/import/pdf-to-powerpoint) porque es una implementación en vivo del proceso descrito aquí. 

{{% /alert %}} 

## **Importar PowerPoint desde HTML**

En este caso, puedes convertir un documento HTML en una presentación PowerPoint.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/).
2. Llama al método [addFromHtml()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) y pasa el archivo HTML.
3. Utiliza el método [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) para guardar el archivo en formato PowerPoint.

Este código Java muestra la operación de HTML a PowerPoint: 
```java
Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Preguntas frecuentes**

**¿Se conservan las tablas al importar un PDF y se puede mejorar su detección?**

Las tablas pueden detectarse durante la importación; [PdfImportOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfimportoptions/) incluye un método [setDetectTables](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) que habilita el reconocimiento de tablas. La efectividad depende de la estructura del PDF.