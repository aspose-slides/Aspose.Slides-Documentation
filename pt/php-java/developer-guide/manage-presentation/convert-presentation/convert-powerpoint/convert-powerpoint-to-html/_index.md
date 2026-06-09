---
title: Converter Apresentações PowerPoint para HTML em PHP
linktitle: PowerPoint para HTML
type: docs
weight: 30
url: /pt/php-java/convert-powerpoint-to-html/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para HTML
- apresentação para HTML
- slide para HTML
- PPT para HTML
- PPTX para HTML
- salvar PowerPoint como HTML
- salvar apresentação como HTML
- salvar slide como HTML
- salvar PPT como HTML
- salvar PPTX como HTML
- exportar PPT para HTML
- exportar PPTX para HTML
- PHP
- Aspose.Slides
description: "Converter apresentações PowerPoint para HTML em PHP. Use Aspose.Slides para exportar arquivos PPT e PPTX, slides selecionados, notas, fontes, imagens, SVG e mídia."
---
## **Visão geral**

Aspose.Slides for PHP via Java pode salvar apresentações PowerPoint como HTML sem o Microsoft PowerPoint. A conversão básica consiste em um único carregamento de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e uma chamada `save` com [SaveFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveformat/). Use [HtmlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmloptions/) quando precisar controlar o layout exportado, fontes, imagens, notas, comentários, saída SVG ou recursos vinculados.

Este guia se concentra em cenários práticos de exportação HTML:

- Exportar uma apresentação completa ou slides selecionados.
- Gerar HTML de layout fixo, responsivo ou baseado em SVG.
- Incluir notas do apresentador e comentários.
- Controlar a qualidade da imagem e os dados de imagem recortados.
- Incorporar fontes ou salvar arquivos de fonte separadamente.
- Escolher como recursos externos e arquivos de mídia são gravados e referenciados.

Por padrão, a exportação HTML produz um documento HTML autônomo onde a maioria dos recursos está incorporada. Isso é conveniente para compartilhar um único arquivo, mas pode aumentar o tamanho da saída. Para publicação na web, considere recursos externos, DPI de imagem menor e incorporar apenas fontes que não estejam disponíveis de forma confiável no ambiente de destino.

## **Converter uma Apresentação para HTML**

Para exportar uma apresentação para HTML, carregue-a com [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e salve-a com [SaveFormat.Html](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Este exemplo grava um arquivo HTML. O objeto de apresentação é descartado no bloco `finally`, que libera manipuladores de arquivo e recursos de renderização após a exportação.

## **Usar HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmloptions/) é a classe principal de configuração para exportação HTML. Configurações comuns incluem:

- `SlidesLayoutOptions`: adiciona notas, comentários, folhetos ou outras informações de layout.
- `HtmlFormatter`: altera a estrutura do documento HTML ou delega a formatação a um controlador.
- `SlideImageFormat`: altera como os slides são representados, por exemplo como SVG.
- `PicturesCompression`: controla o DPI da imagem e o tamanho da saída.
- `DeletePicturesCroppedAreas`: mantém ou remove os dados de imagens recortadas.
- `SvgResponsiveLayout`: faz com que o conteúdo SVG exportado se adapte ao seu contêiner.
- `ShowHiddenSlides`: inclui slides ocultos quando necessário.

As seções a seguir mostram as opções mais comuns separadamente para que você possa combinar apenas as que seu fluxo de trabalho precisa.

## **Converter Slides Selecionados para HTML**

A sobrecarga `save` que aceita números de slide usa posições de slide baseadas em 1. O loop abaixo salva cada slide em um arquivo HTML separado.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

Use este padrão quando um site ou aplicativo precisar de uma página HTML por slide. Se cada slide deve ter o mesmo layout, crie uma instância de [HtmlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmloptions/) e passe‑a para cada chamada `save`.

## **Criar HTML Responsivo**

[ResponsiveHtmlController](https://reference.aspose.com/slides/pt/php-java/aspose.slides/responsivehtmlcontroller/) fornece saída HTML responsiva por meio de [HtmlFormatter](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmlformatter/). Use‑o quando a página exportada precisar se adaptar melhor à largura do navegador.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Para layout responsivo baseado em SVG, defina `SvgResponsiveLayout` em [HtmlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmloptions/). Isso é útil quando o conteúdo do slide é exportado como marcação SVG escalável.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Incluir Notas do Apresentador e Comentários**

Use [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notescommentslayoutingoptions/) através de `HtmlOptions.SlidesLayoutOptions` para incluir notas do apresentador ou comentários. Notas e comentários ficam ocultos por padrão, a menos que você escolha suas posições.

Suponha que a apresentação de origem contenha notas do apresentador:

![Slide com notas do apresentador no PowerPoint](slide_with_notes.png)

O código a seguir exporta o conteúdo do slide com as notas do apresentador abaixo do slide.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

A saída HTML inclui a área de notas:

![Saída HTML com o slide e notas do apresentador](HTML_with_notes.png)

Para exportar comentários, defina `CommentsPosition`, por exemplo para `CommentsPositions.Right` ou `CommentsPositions.Bottom`. Se precisar apenas de comentários, omita `NotesPosition`. Se precisar de notas e comentários, defina ambas as propriedades.

## **Controlar Qualidade de Imagem e Áreas Recortadas**

A exportação HTML pode comprimir imagens de slides para reduzir o tamanho da saída. Defina `PicturesCompression` com um valor de [PicturesCompression](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturescompression/) quando precisar de maior qualidade de imagem.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Por padrão, áreas recortadas de imagens podem ser removidas da saída exportada. Mantenha os dados recortados somente quando os usuários precisarem recuperar ou inspecionar essas partes ocultas da imagem. Mantê‑los pode aumentar o tamanho do HTML.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Adicionar CSS**

Para estilização simples, passe uma string CSS para [HtmlFormatter](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmlformatter/) através de `createDocumentFormatter`. Isso altera o documento HTML ao redor enquanto Aspose.Slides continua a renderizar o conteúdo dos slides.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Para um cabeçalho de documento personalizado, um arquivo CSS vinculado ou marcação personalizada ao redor de slides e formas, use um controlador de formatação personalizado e passe‑o para [HtmlFormatter](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmlformatter/) com `createCustomFormatter`.

## **Incorporar Fontes**

Se o ambiente de destino pode não ter as fontes da apresentação instaladas, incorpore fontes no HTML com [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pt/php-java/aspose.slides/embedallfontshtmlcontroller/). A incorporação melhora a fidelidade visual, mas aumenta o tamanho da saída.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Exclua fontes somente quando estiver confiante de que os navegadores ou sistemas de destino já as fornecem. Para fontes de marca ou fontes menos comuns, a incorporação costuma ser mais segura.

## **Vincular Arquivos de Fonte em vez de Incorporá‑los**

Para reduzir o tamanho do arquivo HTML, você pode gravar os dados da fonte em arquivos WOFF separados e adicionar regras `@font-face` ao HTML. Em PHP via Java, esse cenário geralmente é implementado com uma pequena classe auxiliar Java que estende [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pt/php-java/aspose.slides/embedallfontshtmlcontroller/), grava os bytes da fonte em um diretório de saída e injeta regras `@font-face` no HTML gerado. Compile esse auxiliar, adicione‑o ao classpath do PHP Java Bridge e então instancie‑o a partir do PHP com `new Java(...)`.

Ao criar esse auxiliar, escolha dois caminhos deliberadamente:

- O caminho de saída do sistema de arquivos, onde os arquivos de fonte gerados são gravados.
- O caminho URL, que é o que o navegador usa a partir do documento HTML para carregar esses arquivos de fonte.

## **Salvar Recursos Externamente**

HTML autônomo é fácil de mover, mas recursos incorporados em Base64 podem tornar o arquivo grande. Se seu aplicativo precisar de arquivos de imagem externos, forneça um controlador de link/incorporação personalizado ao construtor de [HtmlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmloptions/).

Ao externalizar recursos, escolha dois caminhos deliberadamente:

- O caminho de saída do sistema de arquivos, onde seu aplicativo grava imagens, fontes, áudio ou vídeo gerados.
- O caminho URL, que é o que o navegador usa a partir do documento HTML para carregar esses arquivos.

Mantenha esses caminhos consistentes com seu layout de implantação para que o HTML gerado possa carregar seus recursos externos após ser movido para um servidor web ou outro diretório.

## **Exportar Arquivos de Mídia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoplayerhtmlcontroller/) exporta arquivos de vídeo e áudio e grava HTML que pode reproduzi‑los em um navegador. Seu construtor recebe:

- `path`: o diretório de saída usado pelo HTML e pelos arquivos de mídia gerados.
- `fileName`: o nome do arquivo HTML que está sendo gerado.
- `baseUri`: o prefixo URI absoluto usado nos links HTML para arquivos de mídia.

Se o arquivo HTML for `html-output/presentation.html`, `path` deve apontar para `html-output`, e `baseUri` deve apontar para o mesmo diretório do ponto de vista do navegador. Para pré‑visualização local, você pode criar um URI `file:///` a partir do diretório de saída. Para um aplicativo implantado, use a URL absoluta do diretório publicado.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

Use diretórios de saída que sejam únicos por trabalho de exportação, especialmente em aplicativos de servidor. Caminhos de saída compartilhados podem fazer com que arquivos de diferentes conversões sobrescrevam uns aos outros.

## **Desempenho e Gerenciamento de Recursos**

A conversão HTML é uma operação de renderização, portanto o tempo de processamento e o uso de memória dependem da contagem de slides, resolução de imagens, fontes, efeitos, gráficos e mídia incorporada. Valores maiores de DPI em `PicturesCompression`, fontes incorporadas, saída SVG e áreas de imagem recortadas mantidas podem melhorar a fidelidade, mas geralmente aumentam o tamanho da saída.

Para conversão em lote:

- Liberar cada instância de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) prontamente.
- Usar diretórios de saída separados para trabalhos diferentes.
- Evitar incorporar fontes comuns, a menos que a fidelidade exija.
- Reduzir o DPI da imagem quando o HTML for para pré‑visualização ou miniaturas.
- Manter a apresentação fonte, o HTML gerado e os recursos externos juntos até que os caminhos de implantação estejam finais.

## **FAQ**

**Os hyperlinks são preservados na saída HTML?**

Sim. Hyperlinks da apresentação são exportados para HTML e permanecem clicáveis quando o URL de destino é válido.

**Posso converter apresentações para HTML em paralelo?**

Sim, mas não compartilhe uma única instância de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) entre threads. Proces​se arquivos diferentes com instâncias de apresentação, fluxos e diretórios de saída separados.

**Um objeto Presentation é thread‑safe?**

Não. Uma única instância de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) deve ser carregada, modificada, salva e descartada em um único thread. Para trabalho paralelo, crie uma instância independente por thread ou processo.

**Por que o arquivo HTML gerado é grande?**

A exportação padrão pode incorporar recursos diretamente no HTML. Fontes incorporadas, imagens de alta DPI, mídia, conteúdo SVG e áreas de imagem recortadas mantidas também aumentam o tamanho. Use recursos externos, exclua fontes comuns da incorporação e reduza `PicturesCompression` quando um tamanho menor for mais importante que a fidelidade máxima.

**Por que um tamanho de fonte do PowerPoint, como 24 pt, aparece como 17.999819 pt no HTML?**

Isso pode acontecer porque PowerPoint e HTML usam modelos de DPI diferentes. O PowerPoint armazena tamanhos de texto em pontos tipográficos baseados em 72 DPI, enquanto o layout HTML baseia‑se em pixels CSS num modelo de 96 DPI. Quando Aspose.Slides exporta uma apresentação para HTML, o tamanho da fonte é traduzido entre esses sistemas, e a conversão pode introduzir pequenas diferenças de arredondamento.

Esses valores não indicam uma mudança visual real no tamanho da fonte. São apenas um efeito colateral matemático da conversão de métricas de texto entre PowerPoint e HTML.

**Como devo escolher baseUri para exportação de mídia?**

Escolha `baseUri` do ponto de vista do navegador e passe‑o como um URI absoluto. Para pré‑visualização local, você pode obtê‑lo a partir do diretório de saída com um URI de arquivo Java. Para implantação, use a URL absoluta do diretório de mídia publicado. O caminho de sistema de arquivos `path` e o `baseUri` do navegador não precisam ser a mesma string, mas devem descrever a mesma localização de recurso.

**Posso incluir slides ocultos?**

Sim. Defina `ShowHiddenSlides` como `true` em [HtmlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmloptions/) quando slides ocultos precisarem ser exportados.