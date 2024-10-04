---
title: Convertir PowerPoint a Word
type: docs
weight: 110
url: /net/convert-powerpoint-to-word/
keywords:
- Convertir PowerPoint
- PPT
- PPTX
- Presentación
- Word
- DOCX
- DOC
- PPTX a DOCX
- PPT a DOC
- PPTX a DOC
- PPT a DOCX
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Convertir presentación de PowerPoint a Word en C# o .NET "
---

Si planeas usar contenido textual o información de una presentación (PPT o PPTX) de nuevas maneras, puedes beneficiarte al convertir la presentación a Word (DOC o DOCX).

* En comparación con Microsoft PowerPoint, la aplicación Microsoft Word está más equipada con herramientas o funcionalidades para el contenido.
* Además de las funciones de edición en Word, también puedes beneficiarte de funciones mejoradas de colaboración, impresión y compartición.

{{% alert color="primary" %}} 

Puedes querer probar nuestro [**Convertidor de Presentación a Word en Línea**](https://products.aspose.app/slides/conversion/ppt-to-word) para ver lo que podrías ganar al trabajar con contenido textual de las diapositivas.

{{% /alert %}} 

### **Aspose.Slides y Aspose.Words**

Para convertir un archivo de PowerPoint (PPTX o PPT) a Word (DOCX o DOCX), necesitas tanto [Aspose.Slides para .NET](https://products.aspose.com/slides/net/) como [Aspose.Words para .NET](https://products.aspose.com/words/net/).

Como API independiente, [Aspose.Slides](https://products.aspose.app/slides) para .NET proporciona funciones que te permiten extraer textos de presentaciones.

[Aspose.Words](https://docs.aspose.com/words/net/) es una API avanzada de procesamiento de documentos que permite a las aplicaciones generar, modificar, convertir, renderizar, imprimir archivos y realizar otras tareas con documentos sin utilizar Microsoft Word.

## **Convertir PowerPoint a Word**

1. Agrega estos espacios de nombres a tu archivo program.cs:

```c#
using Aspose.Slides;
using Aspose.Words;
using System.IO;
```

2. Usa este fragmento de código para convertir PowerPoint a Word:

```c#
using var presentation = new Presentation("sample.pptx");

var doc = new Document();
var builder = new DocumentBuilder(doc);

foreach (var slide in presentation.Slides)
{
    // genera una imagen de la diapositiva y la guarda en un flujo de memoria
    using var image = slide.GetImage(1, 1);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray());

    // inserta los textos de la diapositiva
    foreach (var shape in slide.Shapes)
    {
        if (shape is AutoShape autoShape)
        {
            builder.Writeln(autoShape.TextFrame.Text);
        }
    }

    builder.InsertBreak(BreakType.PageBreak);
}

doc.Save("output.docx");
```