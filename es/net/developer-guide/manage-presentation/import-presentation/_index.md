---
title: Importar PowerPoint desde PDF o HTML
linktitle: Importar presentación
type: docs
weight: 60
url: /es/net/import-presentation/
keywords: "Importar PowerPoint, PDF a PowerPoint, HTML a PowerPoint, PDF a PPT, HTML a PPT, C#, Csharp, Aspose.Slides for .NET"
description: "Importar PowerPoint desde PDF o HTML. Convertir PDF a PowerPoint. Convertir HTML a PowerPoint"
---

Usando [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/), puedes importar presentaciones desde archivos en otros formatos. Aspose.Slides proporciona la clase [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) para permitirte importar presentaciones desde documentos PDF.

## **Importar PowerPoint desde PDF**

En este caso, conviertes un PDF a una presentación PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). 
2. Llama al método [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) y pasa el archivo PDF. 
3. Usa el método [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) para guardar el archivo en formato PowerPoint.

Este código C# muestra la operación de PDF a PowerPoint:
```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert  title="TIP" color="primary" %}} 
Puede que quieras probar la aplicación web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) porque es una implementación en vivo del proceso descrito aquí. 
{{% /alert %}} 

## **Importar PowerPoint desde HTML**

En este caso, conviertes un documento HTML a una presentación PowerPoint.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). 
2. Llama al método [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) y pasa el archivo HTML. 
3. Usa el método [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) para guardar el archivo como documento PowerPoint.

Este código C# muestra la operación de HTML a PowerPoint: 
```c#
using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**¿Se conservan las tablas al importar un PDF y puede mejorarse su detección?**

Se pueden detectar tablas durante la importación; [PdfImportOptions](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/) incluye un parámetro [DetectTables](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/detecttables/) que habilita el reconocimiento de tablas. La efectividad depende de la estructura del PDF.

{{% alert title="Note" color="warning" %}} 
También puedes usar Aspose.Slides para convertir HTML a otros formatos de archivo populares: 

* [HTML to image](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}