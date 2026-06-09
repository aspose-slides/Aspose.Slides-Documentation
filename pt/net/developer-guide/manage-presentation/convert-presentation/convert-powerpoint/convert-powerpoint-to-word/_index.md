---
title: Converter apresentações PowerPoint para documentos Word em .NET
linktitle: PowerPoint para Word
type: docs
weight: 110
url: /pt/net/convert-powerpoint-to-word/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para Word
- apresentação para Word
- slide para Word
- PPT para Word
- PPTX para Word
- PowerPoint para DOCX
- apresentação para DOCX
- slide para DOCX
- PPT para DOCX
- PPTX para DOCX
- PowerPoint para DOC
- apresentação para DOC
- slide para DOC
- PPT para DOC
- PPTX para DOC
- salvar PPT como DOCX
- salvar PPTX como DOCX
- exportar PPT para DOCX
- exportar PPTX para DOCX
- .NET
- C#
- Aspose.Slides
description: "Converta slides PowerPoint PPT e PPTX em documentos Word editáveis em C# usando Aspose.Slides para .NET com layout preciso, imagens e formatação preservados."
---
## **Visão Geral**

Este artigo fornece uma solução para desenvolvedores sobre como converter apresentações PowerPoint e OpenDocument em documentos Word usando Aspose.Slides para .NET e Aspose.Words para .NET. O guia passo a passo orienta você por cada estágio do processo de conversão.

## **Converter uma Apresentação em um Documento Word**

Siga as instruções abaixo para converter uma apresentação PowerPoint ou OpenDocument em um documento Word:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e carregue um arquivo de apresentação.
2. Instancie as classes [Document](https://reference.aspose.com/words/net/aspose.words/document/) e [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) para gerar um documento Word.
3. Defina o tamanho da página do documento Word para corresponder ao da apresentação usando a propriedade [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
4. Defina as margens no documento Word usando a propriedade [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
5. Percorra todos os slides da apresentação usando a propriedade [Presentation.Slides](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/slides/pt/).
    - Gere uma imagem do slide usando o método `GetImage` da interface [ISlide](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/) e salve-a em um fluxo de memória.
    - Adicione a imagem do slide ao documento Word usando o método `InsertImage` da classe [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/).
6. Salve o documento Word em um arquivo.

Suponhamos que temos uma apresentação "sample.pptx" que se parece com isto:

![Apresentação PowerPoint](PowerPoint.png)

O exemplo de código C# a seguir demonstra como converter a apresentação PowerPoint em um documento Word:

```cs
// Carregar um arquivo de apresentação.
using var presentation = new Presentation("sample.pptx");

// Criar objetos Document e DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// Definir o tamanho da página no documento Word.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Definir margens no documento Word.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Go through all the presentation slides.
foreach (var slide in presentation.Slides)
{
    // Gerar uma imagem do slide e salvar em um fluxo de memória.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Adicionar a imagem do slide ao documento Word.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Salvar o documento Word em um arquivo.
document.Save("output.docx");
```

O resultado:

![Documento Word](Word.png)

{{% alert color="primary" %}} 

Experimente nosso [**Conversor Online de PPT para Word**](https://products.aspose.app/slides/pt/conversion/ppt-to-word) para ver o que você pode ganhar ao converter apresentações PowerPoint e OpenDocument em documentos Word. 

{{% /alert %}}

## **Perguntas Frequentes**

**Quais componentes precisam ser instalados para converter apresentações PowerPoint e OpenDocument em documentos Word?**

Você só precisa adicionar os respectivos pacotes NuGet para [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) e [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) ao seu projeto C#. Ambas as bibliotecas funcionam como APIs independentes, e não há necessidade de ter o Microsoft Office instalado.

**Todos os formatos de apresentação PowerPoint e OpenDocument são suportados?**

Aspose.Slides for .NET [suporta todos os formatos de apresentação](/slides/pt/net/supported-file-formats/), incluindo PPT, PPTX, ODP e outros tipos de arquivos comuns. Isso garante que você possa trabalhar com apresentações criadas em várias versões do Microsoft PowerPoint.