---
title: Converter Apresentações PowerPoint para Markdown em PHP
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
- exportar PPTX para MD
- exportação de imagem Markdown
- links de imagem CDN
- PowerPoint
- apresentação
- Markdown
- PHP
- Aspose.Slides
description: "Converta apresentações PPT e PPTX para Markdown em PHP e controle onde as imagens bitmap, metafile e SVG exportadas são salvas e referenciadas."
---
## **Visão geral**

Aspose.Slides for PHP via Java pode converter apresentações PPT e PPTX para Markdown para documentação, sites estáticos, migração de conteúdo e fluxos de trabalho de controle de versão. Você pode escolher um sabor de Markdown, controlar como o conteúdo dos slides é renderizado e decidir onde as imagens exportadas são armazenadas e como o Markdown gerado as referencia.

Por padrão, a exportação para Markdown usa saída apenas de texto. Para exportar conteúdo visual, defina o tipo de exportação com o método [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownsaveoptions/) para o valor `Sequential` ou `Visual` da enumeração [MarkdownExportType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownexporttype/). `Sequential` renderiza os itens dos slides separadamente e em ordem, enquanto `Visual` mantém os itens agrupados juntos para preservar seu relacionamento visual. O valor `TextOnly` não gera recursos de imagem, portanto os callbacks de salvamento de imagem não são invocados nesse modo.

## **Converter uma apresentação para Markdown**

Carregue o arquivo de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e, em seguida, chame o método [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) com o valor `Md` da enumeração [SaveFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveformat/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Selecionar um sabor de Markdown**

O método [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownsaveoptions/) controla a especificação de Markdown usada na saída. A enumeração [Flavor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/flavor/) inclui CommonMark, GitHub Flavored Markdown e outras variantes suportadas.

O exemplo a seguir exporta uma apresentação como CommonMark:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **Exportar imagens usando o comportamento padrão de salvamento local**

A classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownsaveoptions/) fornece dois métodos para configurar imagens salvas localmente:

- [setBasePath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownsaveoptions/) especifica o diretório base para o documento Markdown e seus recursos.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownsaveoptions/) especifica o subdiretório de imagens. Seu valor padrão é `Images`.

O exemplo a seguir renderiza conteúdo visual, grava imagens em `output/assets` e cria referências de imagem relativas no documento Markdown:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Esse comportamento também serve como fallback quando um manipulador de salvamento de imagem personalizado retorna `false`.

## **Personalizar o salvamento de imagens e links Markdown**

Use o método [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownsaveoptions/) para registrar um callback para recursos bitmap e metafile que não sejam SVG emitidos durante a exportação para Markdown. Seu callback `MarkdownImageSavingHandler` recebe o objeto [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/), seu valor [ImageFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imageformat/) e o link Markdown gerado como um array Java de uma única string. Salve ou envie a imagem com o formato fornecido e substitua `$link[0]` pela referência que deve aparecer na saída Markdown.

Recursos emitidos no formato SVG são tratados separadamente. Registre um callback com o método [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownsaveoptions/). Seu callback `MarkdownSvgImageSavingHandler` recebe um objeto [ISvgImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/isvgimage/) e o array Java de uma única string `$link`. Um SVG não possui argumento `ImageFormat`; escreva ou envie seus dados XML a partir do método [ISvgImage::getSvgData](https://reference.aspose.com/slides/pt/php-java/aspose.slides/isvgimage/) em vez disso. Dependendo do modo de exportação e do agrupamento visual, um SVG na apresentação de origem pode ser rasterizado ou combinado com outro conteúdo; o recurso não‑SVG resultante é então passado para o callback de salvamento de imagem. Registre ambos os callbacks quando todo recurso visual exportado exigir processamento customizado.

Em PHP via Java, implemente cada callback em uma classe PHP e use `java_closure` para expor esse objeto como a interface Java correspondente.

{{% alert color="info" title="Note" %}}
Inicialize o PHP/Java Bridge com `JAVA_PREFER_VALUES` habilitado antes de carregar `Java.inc`. O método [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) retorna `void`, e o modo de fluxo padrão da ponte não pode invocar um callback PHP durante essa chamada enfileirada. O exemplo completo abaixo inclui a inicialização necessária.
{{% /alert %}}

O valor de retorno do manipulador determina quem processa a imagem:

- Retorne `true` depois que o manipulador tiver salvo, enviado, transformado ou de outra forma processado a imagem e atribuído um valor válido a `$link[0]`. Aspose.Slides grava esse valor no documento Markdown e não realiza o salvamento local padrão.
- Retorne `false` para que Aspose.Slides salve a imagem localmente e gere seu link de acordo com os valores definidos por [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownsaveoptions/) e [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Um manipulador que retorna `true` assume a responsabilidade pela imagem. Se ele retornar `true` sem atribuir um link válido e não vazio, a exportação falhará com uma `InvalidOperationException`.
{{% /alert %}}

### **Salvar imagens em um diretório de origem CDN e usar URLs externas**

O exemplo a seguir trata `cdn-origin/presentations/quarterly-report` como um diretório de origem CDN montado ou sincronizado. Cada manipulador extrai o nome de arquivo gerado, salva a imagem nesse diretório personalizado e substitui a referência local gerada por uma URL pública do CDN. O próprio exemplo não realiza upload de rede: a URL só se torna válida após o diretório ser montado como origem CDN ou seus arquivos serem publicados no CDN. Para armazenamento de objetos, substitua a gravação no sistema de arquivos pela operação de upload do SDK de armazenamento e atribua `$link[0]` somente após o upload ser bem‑sucedido.

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

O manipulador de bitmap retorna deliberadamente `false` para imagens menores que 128 × 128 pixels, de modo que Aspose.Slides salva essas imagens em `output/fallback-images` usando o comportamento padrão. Recursos bitmap e metafile maiores, bem como recursos SVG, são tratados pelo código customizado. Por exemplo, uma referência local gerada como `fallback-images/image1.png` torna‑se `https://cdn.example.com/presentations/quarterly-report/image1.png`. Os manipuladores usam caminhos do sistema operacional apenas ao gravar arquivos; links gravados no Markdown utilizam barras (`/`) e nomes de arquivo escapados para URL. Aplique a mesma regra ao construir links relativos: use `/`, não o separador de diretórios específico da plataforma.

## **FAQ**

**Um manipulador pode processar tanto imagens raster quanto imagens SVG?**

Não. Use [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownsaveoptions/) para recursos bitmap e metafile emitidos e [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownsaveoptions/) para recursos emitidos como SVG. O primeiro fornece um objeto [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/) e um valor [ImageFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imageformat/); o segundo fornece um objeto [ISvgImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/isvgimage/) cujo dado SVG pode ser lido com [ISvgImage::getSvgData](https://reference.aspose.com/slides/pt/php-java/aspose.slides/isvgimage/). Um SVG de origem que é rasterizado durante a exportação é processado pelo callback de salvamento de imagem em vez disso.

**O que acontece quando um manipulador de salvamento de imagem retorna `false`?**

Aspose.Slides usa seu comportamento padrão de salvamento local. A localização da imagem e a referência gerada são controladas pelos valores definidos com [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownsaveoptions/) e [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/pt/php-java/aspose.slides/markdownsaveoptions/).

**Um manipulador pode fornecer uma URL sem salvar a imagem localmente?**

Sim. O manipulador pode enviar a imagem para armazenamento de objetos ou passá‑la a outro serviço, atribuir a URL resultante a `$link[0]` e retornar `true`. O manipulador deve concluir o processamento por conta própria; retornar `true` impede o salvamento local padrão.

**Por que a exportação para Markdown lança uma `InvalidOperationException` a partir de um manipulador?**

Essa exceção ocorre quando o manipulador retorna `true` mas não fornece um link válido. Atribua o caminho relativo ou a URL externa que deve ser escrito no Markdown antes de retornar `true`.

**Qual separador de caminho os links de imagem devem usar?**

Use barras (`/`) em links Markdown e URLs. Use `DIRECTORY_SEPARATOR` apenas para caminhos do sistema de arquivos e, em seguida, construa ou normalize a referência Markdown separadamente.

**Os hiperlinks são preservados durante a exportação para Markdown?**

Sim. Os [hiperlinks de texto](/slides/pt/php-java/manage-hyperlinks/) são preservados como links Markdown padrão. As [transições de slides](/slides/pt/php-java/slide-transition/) e [animações](/slides/pt/php-java/powerpoint-animation/) não são convertidas.

**As apresentações podem ser convertidas para Markdown em paralelo?**

Você pode processar diferentes arquivos de apresentação em paralelo, mas não compartilhe a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) entre threads. Siga as [diretrizes de multithreading](/slides/pt/php-java/multithreading/) e use uma instância separada para cada arquivo.