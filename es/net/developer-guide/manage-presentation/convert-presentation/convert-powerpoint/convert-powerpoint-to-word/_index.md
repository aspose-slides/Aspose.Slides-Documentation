---
title: Convertir presentaciones de PowerPoint a documentos Word en .NET
linktitle: PowerPoint a Word
type: docs
weight: 110
url: /es/net/convert-powerpoint-to-word/
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
- .NET
- C#
- Aspose.Slides
description: "Convierta diapositivas PowerPoint PPT y PPTX a documentos Word editables en C# usando Aspose.Slides para .NET con diseño, imágenes y formato precisos preservados."
---

## **Visión general**

Este artículo ofrece una solución para desarrolladores sobre cómo convertir presentaciones PowerPoint y OpenDocument a documentos Word utilizando Aspose.Slides para .NET y Aspose.Words para .NET. La guía paso a paso lo acompaña en cada etapa del proceso de conversión.

## **Convertir una presentación a un documento Word**

Siga las instrucciones a continuación para convertir una presentación PowerPoint o OpenDocument a un documento Word:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y cargar un archivo de presentación.
2. Instanciar las clases [Document](https://reference.aspose.com/words/net/aspose.words/document/) y [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) para generar un documento Word.
3. Establecer el tamaño de página del documento Word para que coincida con el de la presentación utilizando la propiedad [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
4. Establecer los márgenes en el documento Word usando la propiedad [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
5. Recorrer todas las diapositivas de la presentación mediante la propiedad [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/):
    - Generar una imagen de la diapositiva usando el método `GetImage` de la interfaz [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) y guardarla en un flujo de memoria.
    - Agregar la imagen de la diapositiva al documento Word mediante el método `InsertImage` de la clase [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/).
6. Guardar el documento Word en un archivo.

Supongamos que tenemos una presentación "sample.pptx" que se ve así:

![Presentación PowerPoint](PowerPoint.png)

El siguiente ejemplo de código C# demuestra cómo convertir la presentación PowerPoint a un documento Word:
```cs
// Cargar un archivo de presentación.
using var presentation = new Presentation("sample.pptx");

// Crear objetos Document y DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// Establecer el tamaño de página en el documento Word.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Establecer los márgenes en el documento Word.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Go through all the presentation slides.
foreach (var slide in presentation.Slides)
{
    // Generar una imagen de diapositiva y guardarla en un flujo de memoria.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Agregar la imagen de la diapositiva al documento Word.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Guardar el documento Word en un archivo.
document.Save("output.docx");
```



El resultado:

![Documento Word](Word.png)

{{% alert color="primary" %}} 

Pruebe nuestro [**Convertidor en línea de PPT a Word**](https://products.aspose.app/slides/conversion/ppt-to-word) para ver lo que puede obtener al convertir presentaciones PowerPoint y OpenDocument a documentos Word. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué componentes deben instalarse para convertir presentaciones PowerPoint y OpenDocument a documentos Word?**

Solo necesita agregar los paquetes NuGet correspondientes para [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) y [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) a su proyecto C#. Ambas bibliotecas funcionan como API independientes y no es necesario tener Microsoft Office instalado.

**¿Se admiten todos los formatos de presentación PowerPoint y OpenDocument?**

Aspose.Slides for .NET [soporta todos los formatos de presentación](/slides/es/net/supported-file-formats/), incluidos PPT, PPTX, ODP y otros tipos de archivo comunes. Esto garantiza que pueda trabajar con presentaciones creadas en diversas versiones de Microsoft PowerPoint.