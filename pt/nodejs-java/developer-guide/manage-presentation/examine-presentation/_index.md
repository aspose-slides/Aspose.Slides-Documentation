---
title: Recuperar e Atualizar Informações da Apresentação em JavaScript
linktitle: Informações da Apresentação
type: docs
weight: 30
url: /pt/nodejs-java/examine-presentation/
keywords:
- formato de apresentação
- propriedades da apresentação
- propriedades do documento
- obter propriedades
- ler propriedades
- alterar propriedades
- modificar propriedades
- atualizar propriedades
- examinar PPTX
- examinar PPT
- examinar ODP
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Explore slides, estrutura e metadados em apresentações PowerPoint e OpenDocument usando JavaScript para obter insights mais rápidos e auditorias de conteúdo mais inteligentes."
---
## **Visão geral**

O Aspose.Slides pode identificar o formato de uma apresentação e ler seus metadados de documento sem criar um modelo completo de objeto de apresentação. Isso é útil quando você precisa classificar arquivos, criar um inventário ou inspecionar propriedades antes de decidir se deve carregar e processar o conteúdo da apresentação.

Este artigo demonstra inspeção leve através de [PresentationFactory](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/) e [PresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/), bem como atualizações direcionadas através de [DocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/).

## **Verificar o formato de uma apresentação**

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) para inspecionar um arquivo sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/). O método [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/getloadformat/) relata o formato detectado, como PPTX, PPT ou ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **Criar um inventário leve de apresentações**

Ao processar muitos arquivos de apresentação, você pode precisar de um inventário compacto para validação, indexação ou um sistema de gerenciamento de documentos. Nesse cenário, use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) para obter um objeto [PresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/), e então chame [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) para ler os metadados do documento. Essa abordagem não cria uma instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) nem exige que você percorra o modelo completo de objeto da apresentação.

As propriedades estendidas expostas por [DocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/) fornecem os seguintes valores de inventário:

| Método | Valor do inventário |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/#getSlides) | Número total de slides. |
| [getHiddenSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Número de slides ocultos. |
| [getNotes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/#getNotes) | Número de slides que contêm notas. |
| [getParagraphs](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Número total de parágrafos, quando disponível. |
| [getWords](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/#getWords) | Número total de palavras. |
| [getMultimediaClips](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Número total de clipes de áudio e vídeo. |

O exemplo a seguir lê esses valores sem criar um objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e imprime um inventário compacto. Ele também combina [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) com [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) para exibir grupos de conteúdo como fontes, temas e títulos de slides.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

Cada [HeadingPair](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/headingpair/) fornece um nome de grupo através de [HeadingPair.getName](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/headingpair/#getName) e o número de itens nesse grupo através de [HeadingPair.getCount](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) retorna um array plano e ordenado, então consuma o número de títulos consecutivos especificado por cada par de cabeçalho.

### **Metadados armazenados e limitações de formato**

As propriedades de inventário retornadas por [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) refletem os metadados disponíveis no documento de origem. O Aspose.Slides não carrega e percorre o modelo de objeto da apresentação para recalcular esses valores para esta chamada. Propriedades ausentes são representadas por valores padrão, e os valores armazenados podem estar desatualizados se o aplicativo que salvou o arquivo pela última vez não atualizou suas propriedades de documento.

- **PPTX:** O formato fornece propriedades de documento estendidas para contagens de slides, notas, slides ocultos, parágrafos, palavras e multimídia, bem como pares de cabeçalhos e títulos de partes. A disponibilidade depende de quais propriedades foram gravadas pelo produtor do documento.
- **PPT:** O formato binário pode armazenar propriedades de resumo de documento correspondentes. Se uma propriedade estiver ausente ou não for atualizada pelo produtor do documento, o Aspose.Slides retorna seu valor armazenado ou padrão em vez de calculá-lo a partir dos slides.
- **ODP:** Os metadados do OpenDocument fornecem estatísticas gerais de documento, como contagens de páginas, parágrafos e palavras, mas esses valores não correspondem a todas as propriedades estendidas específicas do PowerPoint. Metadados de slide oculto, slide de notas, multimídia, pares de cabeçalhos e títulos de partes podem estar indisponíveis, e as propriedades de inventário podem retornar valores padrão. Não trate um valor zero ou um array vazio como prova autoritária de que o conteúdo correspondente está ausente.

Use a abordagem de metadados leves para inventários e verificações preliminares. Carregue a apresentação e inspecione seu modelo de objeto ao vivo quando o resultado precisar refletir alterações em memória ou quando precisar verificar o conteúdo real da apresentação.

## **Atualizar propriedades da apresentação**

As propriedades retornadas por [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) também podem ser alteradas sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/). Aplique as alterações com [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/), e então grave a apresentação vinculada com [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

A imagem a seguir mostra as propriedades originais do documento.

![Propriedades originais do documento da apresentação PowerPoint](input_properties.png)

O exemplo a seguir altera o título e a hora da última gravação e grava o resultado em um novo arquivo:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

A imagem a seguir mostra as propriedades atualizadas do documento.

![Propriedades alteradas do documento da apresentação PowerPoint](output_properties.png)

## **Links úteis**

Para verificações de segurança relacionadas e configurações de proteção, consulte os artigos a seguir:

- [Apresentações protegidas por senha](/slides/pt/nodejs-java/password-protected-presentation/)
- [Apresentações protegidas contra gravação](/slides/pt/nodejs-java/write-protected-presentation/)

## **FAQ**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Carregue a apresentação e use [Presentation.getFontsManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getfontsmanager/). Chame [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) para obter as fontes incorporadas e [FontsManager.getFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getfonts/) para obter as fontes usadas pela apresentação. Compare os dois resultados para encontrar fontes que são necessárias para renderização, mas não estão incorporadas.

**Como posso rapidamente saber se o arquivo tem slides ocultos e quantos?**

Quando os metadados do documento armazenado são suficientes, leia [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) através de [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) e [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Isso é adequado para um inventário leve. Se a apresentação foi modificada na memória, os metadados armazenados podem estar ausentes ou desatualizados, ou se precisar verificar valores ao vivo, percorra [Presentation.getSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getslides/) e inspecione o método [Slide.getHidden](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/gethidden/) de cada slide em vez disso.

**Posso detectar se um tamanho e orientação de slide personalizados estão sendo usados e se diferem dos padrões?**

Sim. Carregue a apresentação e chame [Presentation.getSlideSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getslidesize/). Use [SlideSize.getType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidesize/getsize/), e [SlideSize.getOrientation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidesize/getorientation/) para comparar as configurações atuais com o preset esperado e as dimensões.

**Existe uma maneira rápida de ver se os gráficos referenciam fontes de dados externas?**

Sim. Localize cada [Chart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/) e chame [ChartData.getDataSourceType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). Para uma pasta de trabalho externa, chame [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). O tipo de fonte de dados e o caminho identificam uma referência externa, mas verificar se o alvo está disponível requer uma verificação de recurso separada.

**Como posso avaliar slides 'pesados' que podem desacelerar a renderização ou exportação para PDF?**

Não há uma única propriedade de complexidade. Percorra [Presentation.getSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getslides/) e a coleção [BaseSlide.getShapes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/#getShapes) de cada slide. Use contagens de formas e a presença de imagens grandes, efeitos, animações ou multimídia como sinais de triagem, e meça uma renderização ou exportação representativa antes de considerar um slide como um gargalo de desempenho confirmado.