---
title: Converter apresentações PowerPoint para Markdown em PHP
linktitle: PowerPoint para Markdown
type: docs
weight: 140
url: /pt/php-java/convert-powerpoint-to-markdown/
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
- exportarPPTX para MD
- PowerPoint
- apresentação
- Markdown
- PHP
- Aspose.Slides
description: "Converter slides PowerPoint — PPT, PPTX — para Markdown limpo com Aspose.Slides para PHP via Java, automatizar documentação e manter a formatação."
---
## **Introdução**

Aspose.Slides permite converter apresentações do PowerPoint para Markdown, o que pode ser útil para fluxos de trabalho de documentação, geração de sites estáticos, migração de conteúdo e publicação de texto versionado. A API oferece exportação direta de apresentações PPT e PPTX para arquivos MD e fornece opções adicionais para controlar como o conteúdo dos slides é representado no documento Markdown resultante.

Você pode exportar apresentações como Markdown puro, escolher entre múltiplos sabores de Markdown como CommonMark e GitHub Flavored Markdown, e configurar como as imagens são tratadas durante a exportação. Para apresentações que contêm conteúdo visual, Aspose.Slides também permite salvar imagens em uma pasta separada e referenciá‑las a partir do arquivo Markdown gerado.

{{% alert color="warning" %}}
A exportação de PowerPoint para Markdown é **sem imagens** por padrão. Se quiser exportar um documento PowerPoint que contém imagens, é necessário definir `ExportType = MarkdownExportType::Visual` e especificar `BasePath`, onde as imagens referenciadas no documento Markdown serão salvas.
{{% /alert %}}

## **Converter uma Apresentação para Markdown**

Esta seção explica como Aspose.Slides converte apresentações PowerPoint e OpenDocument (PPT, PPTX, ODP) em Markdown limpo, preservando a hierarquia original dos slides, o texto e a formatação principal, para que você possa reutilizar o conteúdo em documentação ou fluxos de trabalho versionados sem esforço manual adicional.

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) para representar a apresentação.  
2. Use o método [save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#save) para exportá‑la como um arquivo Markdown.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Converter uma Apresentação para um Sabor de Markdown**

Aspose.Slides permite converter apresentações PowerPoint para Markdown com sintaxe básica, bem como para CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab e dezessete outros sabores de Markdown.

O código PHP a seguir demonstra como converter uma apresentação PowerPoint para CommonMark:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

Os 23 sabores de Markdown suportados estão listados na [enumeração Flavor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/flavor/).

## **Converter uma Apresentação contendo Imagens para Markdown**

A classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownsaveoptions/) expõe propriedades e enumerações que permitem configurar o arquivo Markdown resultante. Por exemplo, a enumeração [MarkdownExportType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownexporttype/) especifica como as imagens são tratadas: `Sequential`, `TextOnly` ou `Visual`.

{{% alert color="warning" %}}
Por padrão, a exportação de PowerPoint para Markdown **não inclui imagens**. Para incorporar imagens, chame `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` e defina o `BasePath` que indica onde as imagens referenciadas no arquivo Markdown serão salvas.
{{% /alert %}}

### **Converter Imagens Sequencialmente**

Se desejar que as imagens apareçam individualmente, uma após a outra, no Markdown resultante, escolha a opção `Sequential`. O código PHP a seguir mostra como converter uma apresentação contendo imagens para Markdown:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **Converter Imagens Visualmente**

Se desejar que as imagens apareçam juntas no Markdown resultante, escolha a opção `Visual`. Nesse caso, as imagens são salvas no diretório atual da aplicação (e um caminho relativo é gerado para elas no documento Markdown), ou você pode especificar o diretório e o nome da pasta de sua preferência.

O código PHP a seguir demonstra a operação:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **Perguntas Frequentes**

**Os hyperlinks sobrevivem à exportação para Markdown?**

Sim. Textos [hyperlinks](/slides/pt/php-java/manage-hyperlinks/) são preservados como links Markdown padrão. Slide [transitions](/slides/pt/php-java/slide-transition/) e [animations](/slides/pt/php-java/powerpoint-animation/) não são convertidos.

**Posso acelerar a conversão executando‑a em múltiplas threads?**

É possível paralelizar por arquivos, mas [não compartilhar](/slides/pt/php-java/multithreading/) a mesma [Apresentação](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) entre threads. Use instâncias/processos separados por arquivo para evitar contenção.

**O que acontece com as imagens — onde são salvas e os caminhos são relativos?**

[Images](/slides/pt/php-java/image/) são exportadas para uma pasta dedicada, e o arquivo Markdown as referencia com caminhos relativos por padrão. Você pode configurar o caminho de saída base e o nome da pasta de ativos para manter uma estrutura de repositório previsível.