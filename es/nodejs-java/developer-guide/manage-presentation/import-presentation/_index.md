---
title: Importar Presentación
type: docs
weight: 60
url: /es/nodejs-java/import-presentation/
keywords: "Importar PowerPoint, PDF a Presentación, PDF a PPTX, PDF a PPT, Java, Aspose.Slides for Node.js via Java"
description: "Importar presentación PowerPoint desde PDF. Convertir PDF a PowerPoint"
---

Usando [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), puedes importar presentaciones desde archivos en otros formatos. Aspose.Slides proporciona la clase [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) para permitirte importar presentaciones desde PDFs, documentos HTML, etc.

## **Importar PowerPoint desde PDF**

En este caso, conviertes un PDF a una presentación PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/).
2. Llama al método [addFromPdf()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) y pasa el archivo PDF.
3. Utiliza el método [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) para guardar el archivo en formato PowerPoint.

Este código JavaScript demuestra la operación de PDF a PowerPoint:
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert  title="Tip" color="primary" %}} 
Puede que quieras echar un vistazo a la aplicación web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) porque es una implementación en vivo del proceso descrito aquí. 
{{% /alert %}} 

## **Importar PowerPoint desde HTML**

En este caso, conviertes un documento HTML a una presentación PowerPoint.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/).
2. Llama al método [addFromHtml()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) y pasa el archivo PDF.
3. Utiliza el método [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) para guardar el archivo en formato PowerPoint.

Este código JavaScript demuestra la operación de HTML a PowerPoint:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var htmlStream = java.newInstanceSync("java.io.FileInputStream", "page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) {
            htmlStream.close();
        }
    }
    presentation.save("MyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**¿Se conservan las tablas al importar un PDF, y puede mejorarse su detección?**

Las tablas pueden detectarse durante la importación; [PdfImportOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/) incluye un método [setDetectTables](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) que habilita el reconocimiento de tablas. La efectividad depende de la estructura del PDF.

{{% alert title="Note" color="warning" %}} 
También puedes usar Aspose.Slides para convertir HTML a otros formatos de archivo populares: 

* [HTML a imagen](https://products.aspose.com/slides/nodejs-java/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/nodejs-java/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/nodejs-java/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/nodejs-java/conversion/html-to-tiff/)

{{% /alert %}}