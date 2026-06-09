---
title: Converter Apresentações PowerPoint para Markdown em Java
linktitle: PowerPoint para Markdown
type: docs
weight: 140
url: /pt/java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "Converter slides PowerPoint—PPT, PPTX—para Markdown limpo com Aspose.Slides para Java, automatizar documentação e manter a formatação."
---
## **Introdução**

Aspose.Slides permite converter apresentações PowerPoint para Markdown, o que pode ser útil em fluxos de trabalho de documentação, geração de sites estáticos, migração de conteúdo e publicação de texto versionado. A API oferece exportação direta de apresentações PPT e PPTX para arquivos MD e fornece opções adicionais para controlar como o conteúdo dos slides é representado no documento Markdown resultante.

Você pode exportar apresentações como Markdown simples, escolher entre vários sabores de Markdown como CommonMark e GitHub Flavored Markdown, e configurar como as imagens são tratadas durante a exportação. Para apresentações que contêm conteúdo visual, o Aspose.Slides também permite salvar imagens em uma pasta separada e referenciá‑las no arquivo Markdown gerado.

{{% alert color="warning" %}}
A exportação de PowerPoint para markdown é **sem imagens** por padrão. Se desejar exportar um documento PowerPoint que contenha imagens, é necessário usar `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` e também usar `setBasePath`, onde as imagens referenciadas no documento markdown serão salvas.
{{% /alert %}}

## **Converter PowerPoint para Markdown**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) para representar um objeto de apresentação.
2. Use o método [Save ](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) para salvar o objeto como um arquivo markdown.

Este código Java mostra como converter PowerPoint para markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Converter PowerPoint para Sabor de Markdown**

O Aspose.Slides permite converter PowerPoint para markdown (contendo sintaxe básica), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab e mais 17 outros sabores de markdown.

Este código Java mostra como converter PowerPoint para CommonMark:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

Os 23 sabores de markdown suportados estão [listados na enumeração Flavor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/flavor/) da classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/markdownsaveoptions/).

## **Converter uma Apresentação com Imagens para Markdown**

A classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/markdownsaveoptions/) fornece propriedades e enumerações que permitem usar determinadas opções ou configurações para o arquivo markdown resultante. O enum [MarkdownExportType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/markdownexporttype/), por exemplo, pode ser definido com valores que determinam como as imagens são renderizadas ou tratadas: `Sequential`, `TextOnly`, `Visual`.

### **Converter Imagens Sequencialmente**

Se desejar que as imagens apareçam individualmente, uma após a outra, no markdown resultante, você deve escolher a opção sequencial. Este código Java mostra como converter uma apresentação contendo imagens para markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Converter Imagens Visualmente**

Se desejar que as imagens apareçam juntas no markdown resultante, você deve escolher a opção visual. Nesse caso, as imagens serão salvas no diretório atual da aplicação (e um caminho relativo será criado para elas no documento markdown), ou você pode especificar o caminho e o nome da pasta de sua preferência.

Este código Java demonstra a operação:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas Frequentes**

**Os hiperlinks sobrevivem à exportação para Markdown?**

Sim. Os [hiperlinks](/slides/pt/java/manage-hyperlinks/) de texto são preservados como links Markdown padrão. As [transições](/slides/pt/java/slide-transition/) e [animações](/slides/pt/java/powerpoint-animation/) de slides não são convertidas.

**Posso acelerar a conversão executando‑la em múltiplas threads?**

Você pode paralelizar por arquivos, mas [não compartilhe](/slides/pt/java/multithreading/) a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) entre threads. Use instâncias/processos separados por arquivo para evitar contenção.

**O que acontece com as imagens — onde são salvas e os caminhos são relativos?**

[Imagens](/slides/pt/java/image/) são exportadas para uma pasta dedicada, e o arquivo Markdown as referencia com caminhos relativos por padrão. Você pode configurar o caminho de saída base e o nome da pasta de recursos para manter uma estrutura de repositório previsível.