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
- apresentação para stream
- tipo de visualização pré-definido
- Formato estrito Office Open XML
- modo Zip64
- atualizando miniatura
- progresso de salvamento
- Node.js
- JavaScript
- Aspose.Slides
description: "Salvar apresentações PowerPoint e OpenDocument em arquivos ou streams em JavaScript com Aspose.Slides, e configurar a saída PPTX e o relatório de progresso."
---
## **Visão geral**

Depois de criar uma apresentação ou [abrir uma existente](/slides/pt/nodejs-java/open-presentation/), use o método [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save) para gravar o resultado. Aspose.Slides for Node.js via Java pode salvar uma apresentação em um arquivo ou stream nos formatos PowerPoint, OpenDocument, PDF e outros. As seções a seguir cobrem as operações padrão de salvamento e as opções disponíveis para saída PPTX.

## **Salvar apresentações em arquivos**

Para salvar uma apresentação em um arquivo, passe o caminho de saída e um valor [SaveFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveformat/) para o método [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save). O valor de formato determina o tipo de arquivo que o Aspose.Slides cria.

O exemplo a seguir cria uma apresentação e a salva como um arquivo PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // Adicione ou modifique o conteúdo da apresentação aqui.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações no seu formato original**

Para exemplos de detecção de arquivos e streams, o comportamento de apresentações recém‑criadas e a distinção entre formatos de origem e de saída, veja [Determine the Original Presentation Format](/slides/pt/nodejs-java/detect-presentation-source-format/).

Em um aplicativo de processamento em lote, o formato de entrada pode não ser conhecido previamente. Após carregar um arquivo, leia seu formato original usando o método [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getSourceFormat). Passe o valor [SourceFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sourceformat/) resultante para [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideutil/#toSaveFormat) a fim de obter o correspondente valor [SaveFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveformat/), e então use [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save) para gravar a apresentação modificada.

O exemplo completo a seguir processa cada arquivo em um diretório de entrada, atualiza seu título e o salva em um diretório de saída no formato em que foi carregado:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideutil/#toSaveFormat) mapeia PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP e PowerPoint XML para seus respectivos formatos de salvamento de apresentação. Ele mapeia apenas formatos de origem de apresentação; não serve para selecionar formatos de exportação como PDF, HTML, TIFF ou imagens. Passar um valor [SourceFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sourceformat/) não suportado ou inválido resulta em erro.

Arquivos legados PPT, PPS e POT usam o mesmo contêiner binário. Quando tal apresentação é carregada de um stream sem extensão de arquivo, um arquivo PPS ou POT pode ser identificado como PPT. Se for necessário preservar esses subtipos legados, conserve o nome de arquivo ou metadados de formato originais separadamente e use‑os ao escolher o nome e o formato de saída.

## **Salvar apresentações em streams**

Para gravar uma apresentação sem depender de um caminho de arquivo final, passe um stream gravável e um valor [SaveFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveformat/) para o método [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save). Essa abordagem é útil quando a saída deve ser retornada de um serviço web, armazenada em um banco de dados ou processada na memória.

O exemplo a seguir salva uma nova apresentação em um stream de arquivo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações com um tipo de visualização pré‑definido**

Você pode especificar a visualização na qual o PowerPoint abre inicialmente uma apresentação salva. Use o método [ViewProperties.setLastView](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/viewproperties/#setLastView) com um valor [ViewType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/viewtype/) antes de salvar.

O exemplo a seguir configura a visualização Slide Master como visualização inicial:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações no formato estrito Office Open XML**

Para criar um arquivo PPTX que esteja em conformidade com o perfil Strict do Office Open XML, crie uma instância de [PptxOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxoptions/) e use seu método [setConformance](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxoptions/#setConformance) com [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict). Em seguida, passe as opções para o método [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações no formato Office Open XML no modo Zip64**

Um arquivo ZIP padrão limita o tamanho compactado e descompactado de cada entrada, o tamanho total do arquivo e o número de entradas. Como um arquivo PPTX é um ZIP, uma apresentação muito grande pode exceder esses limites. As extensões ZIP64 aumentam os limites de tamanho e contagem de entradas aplicáveis.

Use o método [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) para controlar se o Aspose.Slides grava extensões ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/zip64mode/#IfNecessary) usa ZIP64 apenas quando a apresentação excede os limites padrão do ZIP. Este é o modo padrão.
- [Never](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/zip64mode/#Never) desabilita extensões ZIP64.
- [Always](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/zip64mode/#Always) grava sempre extensões ZIP64.

O exemplo a seguir sempre habilita extensões ZIP64 para a apresentação de saída:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Se [Zip64Mode.Never](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/zip64mode/#Never) for usado e a apresentação não couber nos limites padrão do ZIP, a operação de salvamento lançará uma [PptxException](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Salvar apresentações no formato Office Open XML com níveis de compressão**

Para saída PPTX, você pode equilibrar a velocidade de salvamento em relação ao tamanho do arquivo usando o método [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel). A classe [CompressionLevel](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/) fornece estes valores:

- [None](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#None) armazena os dados sem compressão.
- [Level1](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level1) oferece a compressão mais rápida e a maior saída compactada.
- [Level2](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level2) até [Level5](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level5) favorecem progressivamente uma saída menor em detrimento da velocidade de salvamento.
- [Level6](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level6) equilibra velocidade de salvamento e tamanho do arquivo. Este é o nível padrão.
- [Level7](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level7) e [Level8](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level8) favorecem ainda mais uma saída menor sobre a velocidade.
- [Level9](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compressionlevel/#Level9) oferece a compressão mais forte e requer mais tempo de processamento.

O exemplo a seguir salva uma apresentação sem compressão:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

O exemplo a seguir usa o nível máximo de compressão:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações sem atualizar a miniatura**

Ao salvar uma apresentação como PPTX, o método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controla a miniatura do documento:

- `true` regenera a miniatura durante a operação de salvamento. Este é o valor padrão.
- `false` preserva a miniatura existente. Se a apresentação não possuir miniatura, o Aspose.Slides não gera uma.

O exemplo a seguir salva uma apresentação sem atualizar sua miniatura:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Desabilitar a atualização da miniatura pode reduzir o tempo necessário para salvar um arquivo PPTX.
{{% /alert %}}

## **Salvar atualizações de progresso em porcentagem**

Para monitorar uma operação de salvamento, implemente a interface [IProgressCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iprogresscallback/) com um proxy Java e passe a implementação para o método [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveoptions/#setProgressCallback). O Aspose.Slides então chama o método [IProgressCallback.reporting](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iprogresscallback/#reporting-double-) com valores de progresso durante a exportação.

O exemplo a seguir relata o progresso de uma exportação PDF no console:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
A Aspose oferece um [PowerPoint Splitter](https://products.aspose.app/slides/pt/splitter) gratuito construído com a API Aspose.Slides. Ele salva slides selecionados de uma apresentação como arquivos PPT ou PPTX separados.
{{% /alert %}}

## **Perguntas frequentes**

**O Aspose.Slides oferece suporte a salvamento incremental ou “salvamento rápido”?**

Não. Cada operação de salvamento grava um arquivo de saída completo em vez de atualizar apenas as partes alteradas.

**Vários threads podem salvar a mesma instância de Presentation?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) [não é thread‑safe](/slides/pt/nodejs-java/multithreading/). Acesse e salve cada instância apenas de um thread por vez.

**O que acontece com hiperlinks e arquivos vinculados externamente quando salvo uma apresentação?**

[Hyperlinks](/slides/pt/nodejs-java/manage-hyperlinks/) permanecem na apresentação. O Aspose.Slides não copia arquivos vinculados externamente, portanto a apresentação salva ainda precisa conseguir acessar seus locais.

**Posso salvar metadados do documento, como autor, título, empresa e data de criação?**

Sim. Defina as [propriedades do documento](/slides/pt/nodejs-java/presentation-properties/) apropriadas antes de salvar, e o Aspose.Slides as grava no arquivo de saída.