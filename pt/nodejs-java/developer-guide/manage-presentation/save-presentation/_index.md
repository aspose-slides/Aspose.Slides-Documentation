---
title: Salvar apresentações em JavaScript
linktitle: Salvar apresentação
type: docs
weight: 80
url: /pt/nodejs-java/save-presentation/
keywords:
- salvar PowerPoint
- salvar OpenDocument
- salvar apresentação
- salvar slide
- salvar PPT
- salvar PPTX
- salvar ODP
- apresentação para arquivo
- apresentação para fluxo
- tipo de visualização predefinido
- Formato Strict Office Open XML
- modo Zip64
- atualizar miniatura
- progresso de salvamento
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra como salvar apresentações usando Aspose.Slides para Node.js via Java - exporte para PowerPoint ou OpenDocument mantendo layouts, fontes e efeitos."
---
## **Visão geral**

[Open Presentations in JavaScript](/slides/pt/nodejs-java/open-presentation/) descreveu como usar a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) para abrir uma apresentação. Este artigo explica como criar e salvar apresentações. A classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) contém o conteúdo de uma apresentação. Seja criando uma apresentação do zero ou modificando uma existente, você desejará salvá‑la quando terminar. Com Aspose.Slides for Node.js, você pode salvar em um **arquivo** ou **fluxo**. Este artigo explica as diferentes maneiras de salvar uma apresentação.

## **Salvar apresentações em arquivos**

Salve uma apresentação em um arquivo chamando o método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/). Passe o nome do arquivo e o formato de salvamento para o método. O exemplo a seguir mostra como salvar uma apresentação com Aspose.Slides.

```js
// Instancie a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Faça algum trabalho aqui...
    
    // Salve a apresentação em um arquivo.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações em fluxos**

Você pode salvar uma apresentação em um fluxo passando um fluxo de saída para o método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/). Uma apresentação pode ser gravada em vários tipos de fluxo. No exemplo abaixo, criamos uma nova apresentação e a salvamos em um fluxo de arquivo.

```js
// Instancie a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Salve a apresentação no fluxo.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações com um tipo de visualização predefinido**

O Aspose.Slides permite definir a visualização inicial que o PowerPoint usa quando a apresentação gerada é aberta por meio da classe [ViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/viewproperties/). Use o método [setLastView](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/viewproperties/#setLastView) com um valor da enumeração [ViewType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/viewtype/).

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações no formato Strict Office Open XML**

O Aspose.Slides permite salvar uma apresentação no formato Strict Office Open XML. Use a classe [PptxOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxoptions/) e defina sua propriedade conformance ao salvar. Se você definir [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), o arquivo de saída será salvo no formato Strict Office Open XML.

O exemplo abaixo cria uma apresentação e a salva no formato Strict Office Open XML.

```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Instancie a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Salve a apresentação no formato Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações no formato Office Open XML no modo Zip64**

Um arquivo Office Open XML é um arquivo ZIP que impõe limites de 4 GB (2^32 bytes) no tamanho descompactado de qualquer arquivo, no tamanho compactado de qualquer arquivo e no tamanho total do arquivo, além de limitar o arquivo a 65 535 (2^16‑1) arquivos. As extensões do formato ZIP64 elevam esses limites para 2^64.

O método [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) permite escolher quando usar as extensões do formato ZIP64 ao salvar um arquivo Office Open XML.

Este método pode ser usado com os seguintes modos:

- [IfNecessary](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/zip64mode/#IfNecessary) usa as extensões do formato ZIP64 somente se a apresentação exceder as limitações acima. Este é o modo padrão.
- [Never](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/zip64mode/#Never) nunca usa as extensões do formato ZIP64.
- [Always](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/zip64mode/#Always) sempre usa as extensões do formato ZIP64.

O código a seguir demonstra como salvar uma apresentação como PPTX com as extensões do formato ZIP64 ativadas:

```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTA" color="warning" %}}
Quando você salva com [Zip64Mode.Never](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/zip64mode/#Never), uma [PptxException](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxexception/) é lançada se a apresentação não puder ser salva no formato ZIP32.
{{% /alert %}}

## **Salvar apresentações sem atualizar a miniatura**

O método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controla a geração de miniaturas ao salvar uma apresentação em PPTX:

- Se definido como `true`, a miniatura é atualizada durante o salvamento. Este é o padrão.
- Se definido como `false`, a miniatura atual é preservada. Se a apresentação não tiver miniatura, nenhuma será gerada.

No código abaixo, a apresentação é salva em PPTX sem atualizar sua miniatura.

```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Informação" color="info" %}}
Esta opção ajuda a reduzir o tempo necessário para salvar uma apresentação no formato PPTX.
{{% /alert %}}

## **Salvar atualizações de progresso em porcentagem**

O relatório de progresso de salvamento é configurado via o método [setProgressCallback](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) em [SaveOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveoptions/) e suas subclasses. Forneça um proxy Java que implemente a interface [IProgressCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iprogresscallback/); durante a exportação, o callback recebe atualizações periódicas de porcentagem.

Os trechos de código a seguir mostram como usar `IProgressCallback`.

```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Use o valor percentual de progresso aqui.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Informação" color="info" %}}
A Aspose desenvolveu um aplicativo gratuito PowerPoint Splitter usando sua própria API. O aplicativo permite dividir uma apresentação em vários arquivos salvando os slides selecionados como novos arquivos PPTX ou PPT.
{{% /alert %}}

## **Perguntas Frequentes**

**O "fast save" (salvamento incremental) é suportado para que apenas as alterações sejam gravadas?**

Não. Cada salvamento cria o arquivo completo de destino; o “fast save” incremental não é suportado.

**É seguro em termos de thread salvar a mesma instância de Presentation a partir de múltiplas threads?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) não é segura para uso em múltiplas threads; salve‑a a partir de uma única thread.

**O que acontece com hyperlinks e arquivos vinculados externamente ao salvar?**

[Hyperlinks](/slides/pt/nodejs-java/manage-hyperlinks/) são preservados. Arquivos vinculados externamente (por exemplo, vídeos via caminhos relativos) não são copiados automaticamente — certifique‑se de que os caminhos referenciados permaneçam acessíveis.

**Posso definir/salvar metadados do documento (Autor, Título, Empresa, Data)?**

Sim. As [propriedades do documento](/slides/pt/nodejs-java/presentation-properties/) padrão são suportadas e serão gravadas no arquivo ao salvar.