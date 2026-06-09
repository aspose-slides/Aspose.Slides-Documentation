---
title: Converter apresentações PowerPoint para Markdown em .NET
linktitle: PowerPoint para Markdown
type: docs
weight: 140
url: /pt/net/convert-powerpoint-to-markdown/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para MD
- apresentação para MD
- slide para MD
- PPT para MD
- PPTX para MD
- salvar PowerPoint como Markdown
- salvar apresentação como Markdown
- salvar slide como Markdown
- salvar PPT como MD
- salvar PPTX como MD
- exportar PPT para MD
- exportar PPTX para MD
- PowerPoint
- apresentação
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Converter slides PowerPoint—PPT, PPTX—para Markdown limpo com Aspose.Slides para .NET, automatizar a documentação e manter a formatação."
---
## **Introdução**

Aspose.Slides permite converter apresentações PowerPoint para Markdown, o que pode ser útil em fluxos de documentação, geração de sites estáticos, migração de conteúdo e publicação de texto sob controle de versão. A API oferece exportação direta de apresentações PPT e PPTX para arquivos MD e fornece opções adicionais para controlar como o conteúdo dos slides é representado no documento Markdown resultante.

Você pode exportar apresentações como Markdown simples, escolher entre vários sabores de Markdown, como CommonMark e GitHub Flavored Markdown, e configurar como as imagens são tratadas durante a exportação. Para apresentações que contêm conteúdo visual, Aspose.Slides também permite salvar imagens em uma pasta separada e referenciá‑las a partir do arquivo Markdown gerado.

{{% alert color="warning" %}}
A exportação de PowerPoint para Markdown é **sem imagens** por padrão. Se desejar exportar um documento PowerPoint que contenha imagens, é necessário definir `ExportType = MarkdownExportType.Visual` e especificar `BasePath`, onde as imagens referenciadas no documento Markdown serão salvas.
{{% /alert %}}

## **Converter PowerPoint para Markdown**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) para representar um objeto de apresentação.  
2. Use o método [Save ](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/methods/save)para salvar o objeto como um arquivo markdown.

Este código C# mostra como converter PowerPoint para markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **Converter PowerPoint para um Sabor de Markdown**

Aspose.Slides permite converter PowerPoint para markdown (contendo sintaxe básica), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab e 17 outros sabores de markdown.

Este código C# mostra como converter PowerPoint para CommonMark:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

Os 23 sabores de markdown suportados estão [listados na enumeração Flavor](https://reference.aspose.com/slides/pt/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) da classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Converter uma Apresentação que Contém Imagens para Markdown**

A classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) fornece propriedades e enumerações que permitem usar determinadas opções ou configurações para o arquivo markdown resultante. O enum [MarkdownExportType](https://reference.aspose.com/slides/pt/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/), por exemplo, pode ser definido com valores que determinam como as imagens são renderizadas ou tratadas: `Sequential`, `TextOnly`, `Visual`.

### **Converter Imagens Sequencialmente**

Se desejar que as imagens apareçam individualmente, uma após a outra, no markdown resultante, escolha a opção sequencial. Este código C# mostra como converter uma apresentação que contém imagens para markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **Converter Imagens Visualmente**

Se deseja que as imagens apareçam juntas no markdown resultante, escolha a opção visual. Nesse caso, as imagens serão salvas no diretório atual da aplicação (e um caminho relativo será criado para elas no documento markdown), ou você pode especificar o caminho e o nome da pasta de sua preferência.

Este código C# demonstra a operação:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```

## **Perguntas Frequentes**

**Os hiperlinks são mantidos na exportação para Markdown?**

Sim. Texto [hyperlinks](/slides/pt/net/manage-hyperlinks/) são preservados como links Markdown padrão. Transições de slide [transitions](/slides/pt/net/slide-transition/) e [animations](/slides/pt/net/powerpoint-animation/) não são convertidos.

**Posso acelerar a conversão executando-a em múltiplas threads?**

Você pode paralelizar por arquivos, mas [don’t share](/slides/pt/net/multithreading/) a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) entre threads. Use instâncias/processos separados por arquivo para evitar contenção.

**O que acontece com as imagens — onde são salvas e os caminhos são relativos?**

[Images](/slides/pt/net/image/) são exportadas para uma pasta dedicada, e o arquivo Markdown as referencia com caminhos relativos por padrão. Você pode configurar o caminho base de saída e o nome da pasta de ativos para manter uma estrutura de repositório previsível.