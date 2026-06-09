---
title: Converter Apresentações PowerPoint para Markdown em JavaScript
linktitle: PowerPoint para Markdown
type: docs
weight: 140
url: /pt/nodejs-java/convert-powerpoint-to-markdown/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converter slides PowerPoint em JavaScript — PPT, PPTX — para Markdown limpo com Aspose.Slides para Node.js via Java, automatizar a documentação e manter a formatação."
---
## **Introdução**

Aspose.Slides permite converter apresentações PowerPoint para Markdown, o que pode ser útil em fluxos de documentação, geração de sites estáticos, migração de conteúdo e publicação de texto sob controle de versão. A API oferece exportação direta de apresentações PPT e PPTX para arquivos MD e fornece opções adicionais para controlar como o conteúdo dos slides é representado no documento Markdown resultante.

É possível exportar apresentações como Markdown simples, escolher entre vários sabores de Markdown como CommonMark e GitHub Flavored Markdown, e configurar como as imagens são tratadas durante a exportação. Para apresentações que contêm conteúdo visual, Aspose.Slides também permite salvar imagens em uma pasta separada e referenciá‑las a partir do arquivo Markdown gerado.

{{% alert color="warning" %}} 
A exportação de PowerPoint para markdown é **sem imagens** por padrão. Se você quiser exportar um documento PowerPoint contendo imagens, precisa chamar `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` e também definir o `BasePath` onde as imagens referenciadas no documento markdown serão salvas.
{{% /alert %}} 

## **Converter PowerPoint para Markdown**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) para representar um objeto de apresentação.  
2. Use o método [save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) para salvar o objeto como um arquivo markdown.

Este código JavaScript mostra como converter PowerPoint para markdown:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Converter PowerPoint para um Sabor de Markdown**

Aspose.Slides permite converter PowerPoint para markdown (contendo sintaxe básica), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab e 17 outros sabores de markdown.

Este código JavaScript mostra como converter PowerPoint para CommonMark:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Os 23 sabores de markdown suportados estão [listados na enumeração Flavor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/flavor/) da classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownsaveoptions/).

## **Converter Apresentação contendo Imagens para Markdown**

A classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownsaveoptions/) fornece propriedades e enumerações que permitem usar determinadas opções ou configurações para o arquivo markdown resultante. O enum [MarkdownExportType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownexporttype/), por exemplo, pode ser definido com valores que determinam como as imagens são renderizadas ou tratadas: `Sequential`, `TextOnly`, `Visual`.

### **Converter Imagens Sequencialmente**

Se você quiser que as imagens apareçam individualmente, uma após a outra, no markdown resultante, deve escolher a opção sequencial. Este código JavaScript demonstra como converter uma apresentação contendo imagens para markdown:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Converter Imagens Visualmente**

Se você quiser que as imagens apareçam juntas no markdown resultante, deve escolher a opção visual. Nesse caso, as imagens serão salvas no diretório atual da aplicação (e um caminho relativo será criado para elas no documento markdown), ou você pode especificar o caminho e o nome da pasta de sua preferência.

Este código JavaScript demonstra a operação:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Os hiperlinks sobrevivem à exportação para Markdown?**

Sim. Os [hiperlinks](/slides/pt/nodejs-java/manage-hyperlinks/) de texto são preservados como links padrão Markdown. As [transições](/slides/pt/nodejs-java/slide-transition/) e as [animações](/slides/pt/nodejs-java/powerpoint-animation/) não são convertidas.

**Posso acelerar a conversão executando‑a em várias threads?**

Você pode paralelizar por arquivos, mas [não compartilhe](/slides/pt/nodejs-java/multithreading/) a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) entre threads. Use instâncias ou processos separados por arquivo para evitar contenção.

**O que acontece com as imagens — onde são salvas e os caminhos são relativos?**

As [imagens](/slides/pt/nodejs-java/image/) são exportadas para uma pasta dedicada, e o arquivo Markdown as referencia com caminhos relativos por padrão. Você pode configurar o caminho base de saída e o nome da pasta de ativos para manter uma estrutura de repositório previsível.