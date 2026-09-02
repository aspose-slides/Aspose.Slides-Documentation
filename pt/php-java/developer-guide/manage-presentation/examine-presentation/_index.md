---
title: Recuperar e Atualizar Informações da Apresentação em PHP
linktitle: Informações da Apresentação
type: docs
weight: 30
url: /pt/php-java/examine-presentation/
keywords:
- formato da apresentação
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
- PHP
- Aspose.Slides
description: "Explore slides, estrutura e metadados em apresentações PowerPoint e OpenDocument usando Aspose.Slides para PHP, obtendo insights mais rápidos e auditorias de conteúdo mais inteligentes."
---
## **Visão geral**

Aspose.Slides pode identificar o formato de uma apresentação e ler seus metadados de documento sem criar um modelo de objeto de apresentação completo. Isso é útil quando você precisa classificar arquivos, montar um inventário ou inspecionar propriedades antes de decidir se carrega e processa o conteúdo da apresentação.

Este artigo demonstra a inspeção leve através de [PresentationFactory](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationfactory/) e [PresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/), bem como atualizações direcionadas através de [DocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/).

## **Verificar o formato de uma apresentação**

Use [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationfactory/) para inspecionar um arquivo sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/). O método [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#getLoadFormat) informa o formato detectado, como PPTX, PPT ou ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **Criar um inventário de apresentações leve**

Ao processar muitos arquivos de apresentação, pode ser necessário um inventário compacto para validação, indexação ou um sistema de gerenciamento de documentos. Nesse cenário, use [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationfactory/) para obter um objeto [PresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/) e, em seguida, chame [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#readDocumentProperties) para ler os metadados do documento. Essa abordagem não cria uma instância de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) nem exige que você percorra todo o modelo de objeto da apresentação.

As propriedades estendidas expostas por [DocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/) fornecem os seguintes valores de inventário:

| Método | Valor do inventário |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#getSlides) | número total de slides. |
| [getHiddenSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#getHiddenSlides) | número de slides ocultos. |
| [getNotes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#getNotes) | número de slides que contêm notas. |
| [getParagraphs](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#getParagraphs) | número total de parágrafos, quando disponível. |
| [getWords](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#getWords) | número total de palavras. |
| [getMultimediaClips](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#getMultimediaClips) | número total de clipes de áudio e vídeo. |

O exemplo a seguir lê esses valores sem criar um objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e imprime um inventário compacto. Ele também combina [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#getHeadingPairs) com [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#getTitlesOfParts) para exibir grupos de conteúdo como fontes, temas e títulos de slides.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

Cada [HeadingPair](https://reference.aspose.com/slides/pt/php-java/aspose.slides/headingpair/) fornece um nome de grupo e o número de itens nesse grupo. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#getTitlesOfParts) devolve um array plano e ordenado, portanto consuma o número de títulos consecutivos especificado por cada par de cabeçalho.

### **Metadados armazenados e limitações de formato**

As propriedades de inventário retornadas por [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#readDocumentProperties) refletem os metadados disponíveis no documento de origem. Aspose.Slides não carrega nem percorre o modelo de objeto da apresentação para recalcular esses valores nessa chamada. Propriedades ausentes são representadas por valores padrão, e os valores armazenados podem estar desatualizados se a aplicação que salvou o arquivo pela última vez não atualizou suas propriedades de documento.

- **PPTX:** o formato fornece propriedades de documento estendidas para contagens de slides, notas, slides ocultos, parágrafos, palavras e multimídia, além de pares de cabeçalhos e títulos de partes. A disponibilidade depende de quais propriedades foram escritas pelo produtor do documento.
- **PPT:** o formato binário pode armazenar propriedades correspondentes de resumo de documento. Se uma propriedade estiver ausente ou não for atualizada pelo produtor do documento, Aspose.Slides devolve seu valor armazenado ou padrão em vez de calculá‑lo a partir dos slides.
- **ODP:** os metadados do OpenDocument fornecem estatísticas gerais do documento, como contagens de páginas, parágrafos e palavras, mas esses valores não se mapeiam a todas as propriedades estendidas específicas do PowerPoint. Metadados de slides ocultos, notas, multimídia, pares de cabeçalhos e títulos de partes podem estar indisponíveis, e as propriedades de inventário podem retornar valores padrão. Não trate um valor zero ou um array vazio como prova autoritária de que o conteúdo correspondente está ausente.

Use a abordagem de metadados leves para inventários e verificações preliminares. Carregue a apresentação e inspecione seu modelo de objeto ativo quando o resultado precisar refletir alterações em memória ou quando for necessário verificar o conteúdo real da apresentação.

## **Atualizar propriedades da apresentação**

As propriedades retornadas por [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#readDocumentProperties) também podem ser alteradas sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/). Aplique as alterações com [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#updateDocumentProperties) e, em seguida, grave a apresentação vinculada com [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

A imagem a seguir mostra as propriedades de documento originais.

![Original document properties of the PowerPoint presentation](input_properties.png)

O exemplo a seguir altera o título e a hora da última gravação e grava o resultado em um novo arquivo:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

A imagem a seguir mostra as propriedades de documento atualizadas.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Links úteis**

Para verificações de segurança relacionadas e configurações de proteção, consulte os artigos a seguir:

- [Password-Protect Presentations](/slides/pt/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/pt/php-java/write-protected-presentation/)

## **FAQ**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Carregue a apresentação e use [Presentation::getFontsManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getFontsManager). Chame [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) para obter as fontes incorporadas e [FontsManager::getFonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/#getFonts) para obter as fontes usadas pela apresentação. Compare os dois resultados para encontrar fontes necessárias para renderização que não estejam incorporadas.

**Como posso dizer rapidamente se o arquivo tem slides ocultos e quantos?**

Quando os metadados armazenados do documento são suficientes, leia [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#getHiddenSlides) através de [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationfactory/) e [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#readDocumentProperties). Isso é adequado para um inventário leve. Se a apresentação foi modificada em memória, os metadados armazenados podem estar ausentes ou desatualizados, ou se precisar verificar valores ao vivo, itere através de [Presentation::getSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getSlides) e inspecione o método [Slide::getHidden](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#getHidden) de cada slide.

**Posso detectar se um tamanho de slide personalizado e orientação são usados, e se diferem dos padrões?**

Sim. Carregue a apresentação e chame [Presentation::getSlideSize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getSlideSize). Use [SlideSize::getType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidesize/#getSize) e [SlideSize::getOrientation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidesize/#getOrientation) para comparar as configurações atuais com o preset e as dimensões esperadas.

**Existe uma maneira rápida de ver se gráficos referenciam fontes de dados externas?**

Sim. Localize cada [Chart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/) e chame [ChartData::getDataSourceType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/#getDataSourceType). Para uma pasta de trabalho externa, chame [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). O tipo de fonte de dados e o caminho identificam uma referência externa, mas verificar se o alvo está disponível requer uma checagem de recurso separada.

**Como posso avaliar slides “pesados” que podem desacelerar a renderização ou a exportação para PDF?**

Não há uma única propriedade de complexidade. Percorra [Presentation::getSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getSlides) e a coleção [BaseSlide::getShapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/#getShapes) de cada slide. Use contagens de formas e a presença de imagens grandes, efeitos, animações ou multimídia como sinais de triagem e meça uma renderização ou exportação representativa antes de considerar um slide como um gargalo de desempenho confirmado.