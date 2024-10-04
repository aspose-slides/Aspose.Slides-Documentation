---
title: Importar PowerPoint desde PDF o HTML
linktitle: Importar Presentación
type: docs
weight: 60
url: /es/net/import-presentation/
keywords: "Importar PowerPoint, PDF a PowerPoint, HTML a PowerPoint, PDF a PPT, HTML a PPT, C#, Csharp, Aspose.Slides para .NET"
description: "Importar PowerPoint desde PDF o HTML. Convertir PDF a PowerPoint. Convertir HTML a PowerPoint"
---

Usando [**Aspose.Slides para .NET**](https://products.aspose.com/slides/net/), puedes importar presentaciones desde archivos en otros formatos. Aspose.Slides proporciona la clase [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) para permitirte importar presentaciones desde documentos PDF.

## **Importar PowerPoint desde PDF**

En este caso, puedes convertir un PDF a una presentación de PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Llama al método [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) y pasa el archivo PDF.
3. Usa el método [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) para guardar el archivo en el formato de PowerPoint.

Este código C# demuestra la operación de PDF a PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="CONSEJO" color="primary" %}} 

Puede que desees consultar la aplicación web gratuita de **Aspose** [PDF a PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) porque es una implementación en vivo del proceso descrito aquí. 

{{% /alert %}} 

## **Importar PowerPoint desde HTML**

En este caso, puedes convertir un documento HTML a una presentación de PowerPoint.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Llama al método [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) y pasa el archivo HTML.
3. Usa el método [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) para guardar el archivo como un documento de PowerPoint.

Este código C# demuestra la operación de HTML a PowerPoint:

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

{{% alert title="Nota" color="warning" %}} 

También puedes usar Aspose.Slides para convertir HTML a otros formatos de archivo populares:

* [HTML a imagen](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}