---
title: Salvar apresentações em JavaScript
linktitle: Salvar Apresentação
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
- apresentação para stream
- tipo de visualização predefinido
- Formato Strict Office Open XML
- modo Zip64
- atualização de miniatura
- progresso de salvamento
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra como salvar apresentações usando Aspose.Slides para Node.js via Java — exporte para PowerPoint ou OpenDocument mantendo layouts, fontes e efeitos."
---
## **Visão geral**

[Open Presentations in JavaScript](/slides/pt/nodejs-java/open-presentation/) descreveu como usar a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) para abrir uma apresentação. Este artigo explica como criar e salvar apresentações. A classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) contém o conteúdo de uma apresentação. Seja criando uma apresentação do zero ou modificando uma existente, você desejará salvá‑la quando terminar. Com Aspose.Slides para Node.js, você pode salvar em um **arquivo** ou **stream**. Este artigo explica as diferentes formas de salvar uma apresentação.

## **Salvar Apresentações em Arquivos**

Salve uma apresentação em um arquivo chamando o método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/). Passe o nome do arquivo e o formato de salvamento para o método. O exemplo a seguir mostra como salvar uma apresentação com Aspose.Slides.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanciar a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Faça algum trabalho aqui...

    // Salve a apresentação em um arquivo.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvar Apresentações em Streams**

Você pode salvar uma apresentação em um stream passando um stream de saída para o método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/). Uma apresentação pode ser gravada em vários tipos de stream. No exemplo abaixo, criamos uma nova apresentação e a salvamos em um stream de arquivo.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Salvar a apresentação no stream.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Salvar Apresentações com um Tipo de Visualização Predefinido**

Aspose.Slides permite definir a visualização inicial que o PowerPoint usa quando a apresentação gerada é aberta por meio da classe [ViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/viewproperties/). Use o método [setLastView](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/viewproperties/#setLastView) com um valor da enumeração [ViewType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/viewtype/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvar Apresentações no Formato Strict Office Open XML**

Aspose.Slides permite salvar uma apresentação no formato Strict Office Open XML. Use a classe [PptxOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxoptions/) e defina sua propriedade **conformance** ao salvar. Se você definir [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), o arquivo de saída será salvo no formato Strict Office Open XML.

O exemplo abaixo cria uma apresentação e a salva no formato Strict Office Open XML.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Instanciar a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Salvar a apresentação no formato Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Salvar Apresentações no Formato Office Open XML no Modo Zip64**

Um arquivo Office Open XML é um arquivo ZIP que impõe limites de 4 GB (2^32 bytes) para o tamanho descompactado de qualquer arquivo, o tamanho compactado de qualquer arquivo e o tamanho total do arquivo, além de limitar o arquivo a 65 535 (2^16‑1) arquivos. As extensões de formato ZIP64 aumentam esses limites para 2^64.

O método [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) permite escolher quando usar as extensões de formato ZIP64 ao salvar um arquivo Office Open XML.

Este método pode ser usado com os seguintes modos:

- [IfNecessary](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/zip64mode/#IfNecessary) usa extensões ZIP64 somente se a apresentação exceder as limitações acima. Este é o modo padrão.
- [Never](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/zip64mode/#Never) nunca usa extensões ZIP64.
- [Always](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/zip64mode/#Always) sempre usa extensões ZIP64.

O código a seguir demonstra como salvar uma apresentação como um arquivo PPTX com as extensões de formato ZIP64 habilitadas:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Ao salvar com [Zip64Mode.Never](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/zip64mode/#Never), uma [PptxException](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxexception/) é lançada se a apresentação não puder ser salva no formato ZIP32.
{{% /alert %}}

## **Salvar Apresentações no Formato Office Open XML com Níveis de Compressão**

Ao trabalhar com apresentações grandes, você pode ajustar o nível de compressão para equilibrar o tamanho do arquivo e o tempo de processamento. Dependendo dos requisitos, pode preferir processamento mais rápido ou arquivos de saída menores.

Aspose.Slides fornece o método [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel), que permite especificar o nível de compressão usado ao salvar uma apresentação no formato Office Open XML.

Os seguintes níveis de compressão estão disponíveis:

- [**None**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#None): Nenhuma compressão é aplicada. Os arquivos são armazenados como estão.
- [**Level1**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level1): A compressão mais rápida com a menor taxa de compressão.
- [**Level2**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level2): Compressão mais rápida com uma taxa de compressão ligeiramente melhor que **Level1**.
- [**Level3**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level3): Oferece compressão melhor que **Level2** com impacto moderado no tempo de processamento.
- [**Level4**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level4): Oferece compressão melhor que **Level3**.
- [**Level5**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level5): Proporciona compressão aprimorada em relação ao **Level4** com tempo de processamento adicional.
- [**Level6**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level6): Compressão padrão que oferece um bom equilíbrio entre velocidade de processamento e tamanho do arquivo. Este é o *nível de compressão padrão*.
- [**Level7**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level7): Oferece compressão melhor que **Level6** com processamento mais lento.
- [**Level8**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level8): Oferece compressão melhor que **Level7**.
- [**Level9**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level9): Compressão máxima. Produz o menor tamanho de arquivo ao custo do maior tempo de processamento.

O exemplo a seguir demonstra como salvar uma apresentação como um arquivo PPTX *sem compressão*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Este exemplo mostra como salvar uma apresentação como um arquivo PPTX com *compressão máxima*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Salvar Apresentações sem Atualizar a Miniatura**

O método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controla a geração de miniaturas ao salvar uma apresentação em PPTX:

- Se definido como `true`, a miniatura é atualizada durante a gravação. Este é o padrão.
- Se definido como `false`, a miniatura atual é preservada. Se a apresentação não possuir miniatura, nenhuma será gerada.

No código abaixo, a apresentação é salva em PPTX sem atualizar sua miniatura.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert title="Info" color="info" %}}
Esta opção ajuda a reduzir o tempo necessário para salvar uma apresentação no formato PPTX.
{{% /alert %}}

## **Salvar Atualizações de Progresso em Percentual**

O relatório de progresso de salvamento é configurado via o método [setProgressCallback](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) em [SaveOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveoptions/) e suas subclasses. Forneça um proxy Java que implemente a interface [IProgressCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iprogresscallback/); durante a exportação, o callback recebe atualizações periódicas de percentual.

Os trechos de código a seguir mostram como usar `IProgressCallback`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

{{% alert title="Info" color="info" %}}
A Aspose desenvolveu um [free PowerPoint Splitter app](https://products.aspose.app/slides/pt/splitter) usando sua própria API. O aplicativo permite dividir uma apresentação em vários arquivos salvando slides selecionados como novos arquivos PPTX ou PPT.
{{% /alert %}}

## **FAQ**

**O “salvamento rápido” (salvamento incremental) é suportado para que apenas as alterações sejam gravadas?**

Não. O salvamento cria o arquivo de destino completo a cada vez; o “salvamento rápido” incremental não é suportado.

**É thread‑safe salvar a mesma instância de Presentation a partir de múltiplas threads?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) **não é thread‑safe** (/slides/pt/nodejs-java/multithreading/); salve-a a partir de uma única thread.

**O que acontece com hyperlinks e arquivos vinculados externamente ao salvar?**

[Hyperlinks](/slides/pt/nodejs-java/manage-hyperlinks/) são preservados. Arquivos vinculados externamente (por exemplo, vídeos via caminhos relativos) não são copiados automaticamente — certifique‑se de que os caminhos referenciados permaneçam acessíveis.

**Posso definir/salvar metadados do documento (Autor, Título, Empresa, Data)?**

Sim. As propriedades padrão do documento [/slides/pt/nodejs-java/presentation-properties/] são suportadas e serão gravadas no arquivo ao salvar.