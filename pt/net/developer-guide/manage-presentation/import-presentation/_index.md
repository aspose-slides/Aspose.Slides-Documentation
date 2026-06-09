---
title: Importar apresentações de PDF ou HTML em .NET
linktitle: Importar apresentação
type: docs
weight: 60
url: /pt/net/import-presentation/
keywords:
- importar apresentação
- importar slide
- importar PDF
- importar HTML
- PDF para apresentação
- PDF para PPT
- PDF para PPTX
- PDF para ODP
- HTML para apresentação
- HTML para PPT
- HTML para PPTX
- HTML para ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Importe documentos PDF e HTML para apresentações PowerPoint e OpenDocument no .NET com Aspose.Slides, proporcionando processamento de slides rápido e sem esforço."
---
## **Introdução**

Usando o Aspose.Slides, você pode importar apresentações a partir de arquivos em outros formatos. O Aspose.Slides fornece a classe [SlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/slidecollection/) que permite importar apresentações de documentos PDF e HTML.

## **Importar PowerPoint de PDF**

Neste caso, você converte um PDF em uma apresentação PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). 
2. Chame o método [AddFromPdf](https://reference.aspose.com/slides/pt/net/aspose.slides.slidecollection/addfrompdf/methods/1) e forneça o arquivo PDF. 
3. Use o método [Save](https://reference.aspose.com/slides/pt/net/aspose.slides.presentation/save/methods/5) para salvar o arquivo no formato PowerPoint.

Este código C# demonstra a operação de PDF para PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="primary" %}} 

Você pode querer conferir o **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/pt/import/pdf-to-powerpoint) web app porque ele é uma implementação ao vivo do processo descrito aqui. 

{{% /alert %}} 

## **Importar PowerPoint de HTML**

Neste caso, você converte um documento HTML em uma apresentação PowerPoint.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). 
2. Chame o método [AddFromHtml](https://reference.aspose.com/slides/pt/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) e forneça o arquivo HTML. 
3. Use o método [Save](https://apireference.aspose.com/slides/pt/net/aspose.slides.presentation/save/methods/5) para salvar o arquivo como um documento PowerPoint.

Este código C# demonstra a operação de HTML para PowerPoint: 

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

## **Perguntas Frequentes**

**As tabelas são preservadas ao importar um PDF, e a detecção delas pode ser aprimorada?**

As tabelas podem ser detectadas durante a importação; [PdfImportOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.import/pdfimportoptions/) inclui um parâmetro [DetectTables] que permite o reconhecimento de tabelas. A eficácia depende da estrutura do PDF.

{{% alert title="Note" color="warning" %}} 

Você também pode usar o Aspose.Slides para converter HTML em outros formatos de arquivo populares: 

* [HTML para imagem](https://products.aspose.com/slides/pt/net/conversion/html-to-image/)
* [HTML para JPG](https://products.aspose.com/slides/pt/net/conversion/html-to-jpg/)
* [HTML para XML](https://products.aspose.com/slides/pt/net/conversion/html-to-xml/)
* [HTML para TIFF](https://products.aspose.com/slides/pt/net/conversion/html-to-tiff/)

{{% /alert %}}