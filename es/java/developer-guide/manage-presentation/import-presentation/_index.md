---
title: Importar Presentación
type: docs
weight: 60
url: /es/java/import-presentation/
keywords: "Importar PowerPoint, PDF a Presentación, PDF a PPTX, PDF a PPT, Java, Aspose.Slides para Java"
description: "Importar presentación de PowerPoint desde PDF. Convertir PDF a PowerPoint"
---

Usando [**Aspose.Slides para Java**](https://products.aspose.com/slides/java/), puedes importar presentaciones de archivos en otros formatos. Aspose.Slides proporciona la clase [SlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/) para permitirte importar presentaciones desde PDFs, documentos HTML, etc.

## **Importar PowerPoint desde PDF**

En este caso, puedes convertir un PDF en una presentación de PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/). 
2. Llama al método [addFromPdf()](https://reference.aspose.com/slides/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) y pasa el archivo PDF. 
3. Utiliza el método [save()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) para guardar el archivo en formato de PowerPoint.

Este código Java demuestra la operación de PDF a PowerPoint:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Consejo" color="primary" %}} 

Puede que quieras revisar la aplicación web **Aspose gratuita** [PDF a PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) porque es una implementación en vivo del proceso descrito aquí. 

{{% /alert %}} 

## **Importar PowerPoint desde HTML**

En este caso, puedes convertir un documento HTML en una presentación de PowerPoint.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/). 
2. Llama al método [addFromHtml()](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) y pasa el archivo HTML. 
3. Utiliza el método [save()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) para guardar el archivo en formato de PowerPoint.

Este código Java demuestra la operación de HTML a PowerPoint: 

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

{{% alert title="Nota" color="warning" %}} 

También puedes usar Aspose.Slides para convertir HTML a otros formatos de archivo populares: 

* [HTML a imagen](https://products.aspose.com/slides/java/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/java/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/java/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/java/conversion/html-to-tiff/)

{{% /alert %}}