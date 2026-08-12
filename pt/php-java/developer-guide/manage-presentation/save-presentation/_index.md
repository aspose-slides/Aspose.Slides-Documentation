---
title: Salvar apresentações em PHP
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
description: "Descubra como salvar apresentações usando Aspose.Slides para PHP via Java — exportar para PowerPoint ou OpenDocument mantendo layouts, fontes e efeitos."
---
## **Visão geral**

[Open Presentations in PHP](/slides/pt/php-java/open-presentation/) descreveu como usar a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) para abrir uma apresentação. Este artigo explica como criar e salvar apresentações. A classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) contém o conteúdo de uma apresentação. Seja criando uma apresentação do zero ou modificando uma existente, você desejará salvá‑la quando terminar. Com Aspose.Slides for PHP, você pode salvar em um **arquivo** ou **fluxo**. Este artigo explica as diferentes formas de salvar uma apresentação.

## **Salvar apresentações em arquivos**

Salve uma apresentação em um arquivo chamando o método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/). Passe o nome do arquivo e o formato de salvamento para o método. O exemplo a seguir mostra como salvar uma apresentação com Aspose.Slides.

```php
// Instanciar a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation();
try {
    // Faça algum trabalho aqui...

    // Salve a apresentação em um arquivo.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Salvar apresentações em fluxos**

Você pode salvar uma apresentação em um fluxo passando um fluxo de saída para o método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/). Uma apresentação pode ser escrita em diversos tipos de fluxo. No exemplo abaixo, criamos uma nova apresentação e a salvamos em um fluxo de arquivo.

```php
// Instanciar a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Salvar a apresentação no fluxo.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Salvar apresentações com um tipo de exibição pré‑definido**

Aspose.Slides permite definir a exibição inicial que o PowerPoint usa quando a apresentação gerada é aberta através da classe [ViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/). Use o método [setLastView](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/#setLastView) com um valor da enumeração [ViewType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewtype/).

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Salvar apresentações no formato Strict Office Open XML**

Aspose.Slides permite salvar uma apresentação no formato Strict Office Open XML. Use a classe [PptxOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxoptions/) e defina sua propriedade `conformance` ao salvar. Se você definir [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pt/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), o arquivo de saída será salvo no formato Strict Office Open XML.

O exemplo abaixo cria uma apresentação e a salva no formato Strict Office Open XML.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Instanciar a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation();
try {
    // Salvar a apresentação no formato Strict Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Salvar apresentações no formato Office Open XML no modo Zip64**

Um arquivo Office Open XML é um arquivo ZIP que impõe limites de 4 GB (2^32 bytes) ao tamanho não compactado de qualquer arquivo, ao tamanho compactado de qualquer arquivo e ao tamanho total do arquivo, além de limitar o arquivo a 65 535 (2^16‑1) itens. As extensões de formato ZIP64 aumentam esses limites para 2^64.

O método [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxoptions/#setZip64Mode) permite escolher quando usar as extensões de formato ZIP64 ao salvar um arquivo Office Open XML.

Este método pode ser usado com os modos a seguir:

- [IfNecessary](https://reference.aspose.com/slides/pt/php-java/aspose.slides/zip64mode/#IfNecessary) usa extensões ZIP64 somente se a apresentação exceder as limitações acima. Este é o modo padrão.
- [Never](https://reference.aspose.com/slides/pt/php-java/aspose.slides/zip64mode/#Never) nunca usa extensões ZIP64.
- [Always](https://reference.aspose.com/slides/pt/php-java/aspose.slides/zip64mode/#Always) sempre usa extensões ZIP64.

O código a seguir demonstra como salvar uma apresentação como um arquivo PPTX com extensões ZIP64 habilitadas:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Ao salvar com [Zip64Mode.Never](https://reference.aspose.com/slides/pt/php-java/aspose.slides/zip64mode/#Never), uma [PptxException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxexception/) é lançada se a apresentação não puder ser salva no formato ZIP32.
{{% /alert %}}

## **Salvar apresentações no formato Office Open XML com níveis de compressão**

Ao trabalhar com apresentações grandes, você pode ajustar o nível de compressão para equilibrar o tamanho do arquivo e o tempo de processamento. Dependendo de suas necessidades, pode preferir um processamento mais rápido ou arquivos de saída menores.

Aspose.Slides fornece o método [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxoptions/#setCompressionLevel), que permite especificar o nível de compressão usado ao salvar uma apresentação no formato Office Open XML.

Os níveis de compressão disponíveis são:

- [**None**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#None): Nenhuma compressão é aplicada. Os arquivos são armazenados como estão.
- [**Level1**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level1): A compressão mais rápida com a menor taxa de compressão.
- [**Level2**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level2): Compressão mais rápida com uma taxa de compressão ligeiramente melhor que **Level1**.
- [**Level3**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level3): Oferece melhor compressão que **Level2** com impacto moderado no tempo de processamento.
- [**Level4**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level4): Oferece melhor compressão que **Level3**.
- [**Level5**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level5): Fornece compressão aprimorada em relação ao **Level4** com tempo de processamento adicional.
- [**Level6**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level6): Compressão padrão que oferece um bom equilíbrio entre velocidade de processamento e tamanho do arquivo. Este é o *nível de compressão padrão*.
- [**Level7**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level7): Oferece melhor compressão que **Level6** com processamento mais lento.
- [**Level8**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level8): Oferece melhor compressão que **Level7**.
- [**Level9**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compressionlevel/#Level9): Compressão máxima. Produz o menor tamanho de arquivo ao custo do maior tempo de processamento.

O exemplo a seguir demonstra como salvar uma apresentação como um arquivo PPTX *sem compressão*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

Este exemplo mostra como salvar uma apresentação como um arquivo PPTX com *compressão máxima*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **Salvar apresentações sem atualizar a miniatura**

O método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controla a geração da miniatura ao salvar uma apresentação em PPTX:

- Se definido como `true`, a miniatura é atualizada durante a gravação. Este é o padrão.
- Se definido como `false`, a miniatura atual é preservada. Se a apresentação não possuir miniatura, nenhuma será gerada.

No código abaixo, a apresentação é salva em PPTX sem atualizar sua miniatura.

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Esta opção ajuda a reduzir o tempo necessário para salvar uma apresentação no formato PPTX.
{{% /alert %}}

## **Atualizações de progresso de salvamento em porcentagem**

O relatório de progresso de salvamento é configurado via o método [setProgressCallback](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveoptions/#setProgressCallback) em [SaveOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveoptions/) e suas subclasses. Forneça um proxy Java que implemente a interface [IProgressCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iprogresscallback/); durante a exportação, o callback recebe atualizações periódicas em porcentagem.

Os trechos de código a seguir mostram como usar `IProgressCallback`.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Use o valor percentual de progresso aqui.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
A Aspose desenvolveu um [app gratuito PowerPoint Splitter](https://products.aspose.app/slides/pt/splitter) usando sua própria API. O app permite dividir uma apresentação em vários arquivos salvando slides selecionados como novos arquivos PPTX ou PPT.
{{% /alert %}}

## **FAQ**

**O “salvamento rápido” (salvamento incremental) é suportado para que apenas as alterações sejam gravadas?**

Não. Cada salvamento cria o arquivo de destino completo; o “salvamento rápido” incremental não é suportado.

**É seguro salvar a mesma instância de Presentation a partir de múltiplas threads?**

Não. Uma [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) [não é thread‑safe](/slides/pt/php-java/multithreading/); salve-a a partir de uma única thread.

**O que acontece com hyperlinks e arquivos vinculados externamente ao salvar?**

[Hyperlinks](/slides/pt/php-java/manage-hyperlinks/) são preservados. Arquivos vinculados externamente (por exemplo, vídeos via caminhos relativos) não são copiados automaticamente — assegure‑se de que os caminhos referenciados permaneçam acessíveis.

**Posso definir/salvar metadados do documento (Autor, Título, Empresa, Data)?**

Sim. As propriedades padrão do [documento](/slides/pt/php-java/presentation-properties/) são suportadas e serão gravadas no arquivo ao salvar.