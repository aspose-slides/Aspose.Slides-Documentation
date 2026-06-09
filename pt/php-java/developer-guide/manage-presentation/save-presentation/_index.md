---
title: Salvar apresentações em PHP
linktitle: Salvar apresentação
type: docs
weight: 80
url: /pt/php-java/save-presentation/
keywords:
- Salvar PowerPoint
- Salvar OpenDocument
- Salvar apresentação
- Salvar slide
- Salvar PPT
- Salvar PPTX
- Salvar ODP
- Apresentação para arquivo
- Apresentação para fluxo
- Tipo de visualização predefinido
- Formato Strict Office Open XML
- Modo Zip64
- Atualizando miniatura
- Progresso de salvamento
- PHP
- Aspose.Slides
description: "Descubra como salvar apresentações usando Aspose.Slides para PHP via Java — exporte para PowerPoint ou OpenDocument preservando layouts, fontes e efeitos."
---
## **Visão geral**

[Open Presentations in PHP](/slides/pt/php-java/open-presentation/) descreve como usar a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) para abrir uma apresentação. Este artigo explica como criar e salvar apresentações. A classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) contém o conteúdo de uma apresentação. Seja criando uma apresentação do zero ou modificando uma existente, você desejará salvá‑la quando terminar. Com Aspose.Slides para PHP, você pode salvar em **arquivo** ou **fluxo**. Este artigo explica as diferentes maneiras de salvar uma apresentação.

## **Salvar apresentações em arquivos**

Salve uma apresentação em um arquivo chamando o método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/). Passe o nome do arquivo e o formato de salvamento para o método. O exemplo a seguir mostra como salvar uma apresentação com Aspose.Slides.

```php
// Instancie a classe Presentation que representa um arquivo de apresentação.
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

Você pode salvar uma apresentação em um fluxo passando um fluxo de saída para o método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/). Uma apresentação pode ser gravada em diversos tipos de fluxo. No exemplo abaixo, criamos uma nova apresentação e a salvamos em um fluxo de arquivo.

```php
// Instancie a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Salve a apresentação no fluxo.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Salvar apresentações com um tipo de visualização predefinido**

Aspose.Slides permite definir a visualização inicial que o PowerPoint usa quando a apresentação gerada é aberta por meio da classe [ViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/). Use o método [setLastView](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/#setLastView) com um valor da enumeração [ViewType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewtype/).

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

Aspose.Slides permite salvar uma apresentação no formato Strict Office Open XML. Use a classe [PptxOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxoptions/) e defina sua propriedade de conformidade ao salvar. Se você definir [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pt/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), o arquivo de saída será salvo no formato Strict Office Open XML.

O exemplo abaixo cria uma apresentação e a salva no formato Strict Office Open XML.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Instancie a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation();
try {
    // Salve a apresentação no formato Strict Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Salvar apresentações no formato Office Open XML no modo Zip64**

Um arquivo Office Open XML é um arquivo ZIP que impõe limites de 4 GB (2^32 bytes) ao tamanho não compactado de qualquer arquivo, ao tamanho compactado de qualquer arquivo e ao tamanho total do arquivo, além de limitar o arquivo a 65.535 (2^16‑1) arquivos. As extensões de formato ZIP64 aumentam esses limites para 2^64.

O método [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxoptions/#setZip64Mode) permite escolher quando usar as extensões de formato ZIP64 ao salvar um arquivo Office Open XML.

Este método pode ser usado com os seguintes modos:

- [IfNecessary](https://reference.aspose.com/slides/pt/php-java/aspose.slides/zip64mode/#IfNecessary) usa as extensões de formato ZIP64 somente se a apresentação exceder as limitações acima. Este é o modo padrão.
- [Never](https://reference.aspose.com/slides/pt/php-java/aspose.slides/zip64mode/#Never) nunca usa extensões de formato ZIP64.
- [Always](https://reference.aspose.com/slides/pt/php-java/aspose.slides/zip64mode/#Always) sempre usa extensões de formato ZIP64.

O código a seguir demonstra como salvar uma apresentação como PPTX com extensões de formato ZIP64 ativadas:

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

## **Salvar apresentações sem atualizar a miniatura**

O método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controla a geração de miniaturas ao salvar uma apresentação em PPTX:

- Se definido como `true`, a miniatura é atualizada durante a gravação. Este é o padrão.
- Se definido como `false`, a miniatura atual é preservada. Se a apresentação não tem miniatura, nenhuma será gerada.

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

O relatório de progresso de salvamento é configurado via o método [setProgressCallback](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveoptions/#setProgressCallback) em [SaveOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveoptions/) e suas subclasses. Forneça um proxy Java que implemente a interface [IProgressCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iprogresscallback/); durante a exportação, o callback recebe atualizações periódicas de porcentagem.

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
A Aspose desenvolveu um [app gratuito de divisão de PowerPoint](https://products.aspose.app/slides/pt/splitter) usando sua própria API. O app permite dividir uma apresentação em vários arquivos salvando os slides selecionados como novos arquivos PPTX ou PPT.
{{% /alert %}}

## **Perguntas frequentes**

**É o "fast save" (salvamento incremental) suportado para que apenas as alterações sejam gravadas?**

Não. Cada gravação cria o arquivo completo de destino; o "fast save" incremental não é suportado.

**É seguro usar múltiplas threads para salvar a mesma instância de Presentation?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) [não é thread‑safe](/slides/pt/php-java/multithreading/); salve‑a a partir de uma única thread.

**O que acontece com hyperlinks e arquivos vinculados externamente ao salvar?**

[Hyperlinks](/slides/pt/php-java/manage-hyperlinks/) são preservados. Arquivos vinculados externamente (por exemplo, vídeos via caminhos relativos) não são copiados automaticamente — certifique‑se de que os caminhos referenciados permaneçam acessíveis.

**Posso definir/salvar metadados do documento (Autor, Título, Empresa, Data)?**

Sim. As [propriedades padrão do documento](/slides/pt/php-java/presentation-properties/) são suportadas e serão gravadas no arquivo ao salvar.