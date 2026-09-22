---
title: Salvar Apresentações em PHP
linktitle: Salvar Apresentação
type: docs
weight: 80
url: /pt/php-java/save-presentation/
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
  - atualizando miniatura
  - progresso de salvamento
  - PHP
  - Aspose.Slides
description: "Salvar apresentações PowerPoint e OpenDocument em arquivos ou fluxos em PHP com Aspose.Slides, e configurar a saída PPTX e o relatório de progresso."
---
## **Visão geral**

Depois de criar uma apresentação ou [abrir uma existente](/slides/pt/php-java/open-presentation/), use o método [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#save) para gravar o resultado. Aspose.Slides for PHP via Java pode salvar uma apresentação em um arquivo ou fluxo nos formatos PowerPoint, OpenDocument, PDF e outros. As seções a seguir cobrem as operações padrão de salvamento e as opções disponíveis para a saída PPTX.

## **Salvar apresentações em arquivos**

Para salvar uma apresentação em um arquivo, passe o caminho de saída e um valor de [SaveFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveformat/) para o método [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#save). O valor de formato determina o tipo de arquivo que o Aspose.Slides cria.

O exemplo a seguir cria uma apresentação e a salva como um arquivo PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Adicionar ou modificar o conteúdo da apresentação aqui.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Salvar apresentações em seu formato original**

Para exemplos de detecção de arquivos e fluxos, o comportamento de apresentações recém‑criadas e a distinção entre formatos de origem e de saída, veja [Determine the Original Presentation Format](/slides/pt/php-java/detect-presentation-source-format/).

Em uma aplicação de processamento em lote, o formato de entrada pode não ser conhecido com antecedência. Após carregar um arquivo, leia seu formato original usando o método [Presentation::getSourceFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getSourceFormat). Passe o valor resultante de [SourceFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/sourceformat/) para [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideutil/#toSaveFormat) para obter o correspondente valor de [SaveFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveformat/), e então use [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#save) para gravar a apresentação modificada.

O exemplo completo a seguir processa cada arquivo em um diretório de entrada, atualiza seu título e o salva em um diretório de saída no mesmo formato em que foi carregado:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideutil/#toSaveFormat) mapeia PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP e PowerPoint XML para seus respectivos formatos de salvamento de apresentação. Ele mapeia apenas formatos de origem da apresentação; não é destinado a selecionar formatos de exportação como PDF, HTML, TIFF ou imagens. Passar um valor de [SourceFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/sourceformat/) não suportado ou inválido resulta em um [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Arquivos legados PPT, PPS e POT usam o mesmo contêiner binário. Quando tal apresentação é carregada a partir de um fluxo sem extensão de arquivo, um arquivo PPS ou POT pode ser identificado como PPT. Se for necessário preservar esses subtipos legados, mantenha o nome de arquivo original ou os metadados de formato separadamente e use‑os ao escolher o nome e o formato de saída.

## **Salvar apresentações em fluxos**

Para gravar uma apresentação sem depender de um caminho de arquivo final, passe um fluxo gravável e um valor de [SaveFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveformat/) para o método [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#save). Essa abordagem é útil quando a saída deve ser retornada de um serviço web, armazenada em um banco de dados ou processada na memória.

O exemplo a seguir salva uma nova apresentação em um fluxo de arquivo:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Salvar apresentações com um tipo de exibição predefinido**

É possível especificar a exibição na qual o PowerPoint abre inicialmente uma apresentação salva. Use o método [ViewProperties::setLastView](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/#setLastView) com um valor de [ViewType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewtype/) antes de salvar.

O exemplo a seguir configura a exibição Mestre de Slides como a exibição inicial:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Salvar apresentações no formato Strict Office Open XML**

Para criar um arquivo PPTX que esteja em conformidade com o perfil Strict do Office Open XML, crie uma instância de [PptxOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxoptions/) e use seu método [PptxOptions::setConformance](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxoptions/#setConformance) com [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/pt/php-java/aspose.slides/conformance/#Iso29500-2008-Strict). Em seguida, passe as opções para o método [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#save).

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Salvar apresentações no formato Office Open XML no modo Zip64**

Um arquivo ZIP padrão limita o tamanho compactado e descompactado de cada entrada, o tamanho total do arquivo e o número de entradas. Como um arquivo PPTX é um arquivo ZIP, uma apresentação muito grande pode exceder esses limites. As extensões ZIP64 aumentam os limites de tamanho e contagem de entradas aplicáveis.

Use o método [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxoptions/#setZip64Mode) para controlar se o Aspose.Slides grava extensões ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/pt/php-java/aspose.slides/zip64mode/#IfNecessary) usa ZIP64 somente quando a apresentação excede os limites padrão de ZIP. Este é o modo padrão.
- [Never](https://reference.aspose.com/slides/pt/php-java/aspose.slides/zip64mode/#Never) desabilita as extensões ZIP64.
- [Always](https://reference.aspose.com/slides/pt/php-java/aspose.slides/zip64mode/#Always) sempre grava extensões ZIP64.

O exemplo a seguir sempre habilita extensões ZIP64 para a apresentação de saída:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Aviso" %}}
Se [Zip64Mode::Never](https://reference.aspose.com/slides/pt/php-java/aspose.slides/zip64mode/#Never) for usado e a apresentação não couber dentro dos limites padrão de ZIP, a operação de salvamento lançará um [PptxException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Salvar apresentações no formato Office Open XML com níveis de compressão**

Para a saída PPTX, você pode equilibrar a velocidade de salvamento contra o tamanho do arquivo usando o método [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxoptions/#setCompressionLevel). A classe [CompressionLevel](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/) fornece estes valores:

- [None](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#None) armazena dados sem compressão.
- [Level1](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level1) fornece a compressão mais rápida e a maior saída compactada.
- [Level2](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level2) até [Level5](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level5) favorecem progressivamente uma saída menor em detrimento da velocidade de salvamento.
- [Level6](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level6) equilibra velocidade de salvamento e tamanho do arquivo. Este é o nível padrão.
- [Level7](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level7) e [Level8](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level8) favorecem ainda mais uma saída menor sobre a velocidade.
- [Level9](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level9) fornece a compressão mais forte e requer mais tempo de processamento.

O exemplo a seguir salva uma apresentação sem compressão:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

O exemplo a seguir usa o nível máximo de compressão:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Salvar apresentações sem atualizar a miniatura**

Quando uma apresentação é salva como PPTX, o método [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controla sua miniatura de documento:

- `true` regenera a miniatura durante a operação de salvamento. Este é o valor padrão.
- `false` preserva a miniatura existente. Se a apresentação não possuir miniatura, o Aspose.Slides não gera uma.

O exemplo a seguir salva uma apresentação sem atualizar sua miniatura:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Nota" %}}
Desabilitar a atualização da miniatura pode reduzir o tempo necessário para salvar um arquivo PPTX.
{{% /alert %}}

## **Atualizações de progresso de salvamento em porcentagem**

Para monitorar uma operação de salvamento, forneça um proxy Java que implemente a interface [IProgressCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iprogresscallback/) e passe o proxy ao método [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveoptions/#setProgressCallback). O Aspose.Slides então chama o método [IProgressCallback::reporting](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iprogresscallback/#reporting-double-) com valores de progresso durante a exportação.

O exemplo a seguir relata o progresso de uma exportação PDF no console:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Nota" %}}
A Aspose oferece um [PowerPoint Splitter](https://products.aspose.app/slides/pt/splitter) gratuito, construído com a API Aspose.Slides. Ele salva slides selecionados de uma apresentação como arquivos PPT ou PPTX separados.
{{% /alert %}}

## **FAQ**

**O Aspose.Slides suporta salvamento incremental ou “fast save”?**

Não. Cada operação de salvamento grava um arquivo de saída completo em vez de atualizar apenas as partes alteradas.

**Vários threads podem salvar a mesma instância de Presentation?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) **não é thread‑safe** (/slides/pt/php-java/multithreading/). Acesse e salve cada instância a partir de apenas um thread por vez.

**O que acontece com hyperlinks e arquivos vinculados externamente ao salvar uma apresentação?**

[Hyperlinks](/slides/pt/php-java/manage-hyperlinks/) permanecem na apresentação. O Aspose.Slides não copia arquivos vinculados externamente, portanto a apresentação salva ainda deve ser capaz de acessar suas localizações.

**Posso salvar metadados do documento como autor, título, empresa e data de criação?**

Sim. Defina as [propriedades do documento](/slides/pt/php-java/presentation-properties/) apropriadas antes de salvar, e o Aspose.Slides as grava no arquivo de saída.