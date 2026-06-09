---
title: Converter apresentações PowerPoint para HTML em Node.js
linktitle: PowerPoint para HTML
type: docs
weight: 30
url: /pt/nodejs-java/convert-powerpoint-to-html/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converter apresentações PowerPoint para HTML em Node.js. Use Aspose.Slides para Node.js via Java para exportar arquivos PPT e PPTX, slides selecionados, notas, fontes, imagens, SVG e mídia."
---
## **Visão geral**

Aspose.Slides for Node.js via Java pode salvar apresentações do PowerPoint como HTML sem o Microsoft PowerPoint. A conversão básica consiste em um único carregamento de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e uma chamada `save` com [SaveFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveformat/). Use [HtmlOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/htmloptions/) quando precisar controlar o layout exportado, fontes, imagens, notas, comentários, saída SVG ou recursos vinculados.

Este guia foca em cenários práticos de exportação HTML:

- Exportar uma apresentação completa ou slides selecionados.  
- Gerar HTML de layout fixo, responsivo ou baseado em SVG.  
- Incluir notas do apresentador e comentários.  
- Controlar a qualidade da imagem e os dados de imagens recortadas.  
- Incorporar fontes ou salvar arquivos de fontes separadamente.  
- Escolher como recursos externos e arquivos de mídia são gravados e referenciados.

Por padrão, a exportação HTML produz um documento HTML autocontido onde a maioria dos recursos está incorporada. Isso é conveniente para compartilhar um único arquivo, mas pode aumentar o tamanho da saída. Para publicação na web, considere recursos externos, DPI de imagem menor e incorpore somente fontes que não estejam disponíveis de forma confiável no ambiente de destino.

## **Converter uma Presentation para HTML**

Para exportar uma apresentação para HTML, carregue-a com [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e salvá‑la com [SaveFormat.Html](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Este exemplo grava um arquivo HTML. O objeto Presentation é descartado no bloco `finally`, que libera os manipuladores de arquivo e recursos de renderização após a exportação.

## **Usar HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/htmloptions/) é a classe principal de configuração para exportação HTML. Configurações comuns incluem:

- `SlidesLayoutOptions`: adiciona notas, comentários, folhetos ou outras informações de layout.  
- `HtmlFormatter`: altera a estrutura do documento HTML ou delega a formatação a um controlador.  
- `SlideImageFormat`: altera a forma como os slides são representados, por exemplo como SVG.  
- `PicturesCompression`: controla a DPI da imagem e o tamanho da saída.  
- `DeletePicturesCroppedAreas`: mantém ou remove os dados de imagens recortadas.  
- `SvgResponsiveLayout`: faz com que o conteúdo SVG exportado se adapte ao seu contêiner.  
- `ShowHiddenSlides`: inclui slides ocultos quando necessário.

As seções a seguir mostram as opções mais comuns separadamente, para que você possa combinar apenas aquelas que seu fluxo de trabalho necessita.

## **Converter slides selecionados para HTML**

A sobrecarga `Presentation.save` que aceita números de slide usa posições baseadas em 1. O loop abaixo salva cada slide em um arquivo HTML separado.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Use esse padrão quando um site ou aplicativo precisar de uma página HTML por slide. Se cada slide deverá ter o mesmo layout, crie uma instância de [HtmlOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/htmloptions/) e passe‑a para cada chamada `save`.

## **Criar HTML responsivo**

[ResponsiveHtmlController](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/responsivehtmlcontroller/) fornece saída HTML responsiva por meio de [HtmlFormatter](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/htmlformatter/). Use‑o quando a página exportada precisar adaptar‑se melhor à largura do navegador.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Para layout responsivo baseado em SVG, defina `SvgResponsiveLayout` em [HtmlOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/htmloptions/). Isso é útil quando o conteúdo do slide é exportado como marcação SVG escalável.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Incluir notas do apresentador e comentários**

Use [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notescommentslayoutingoptions/) através de `HtmlOptions.setSlidesLayoutOptions` para incluir notas do apresentador ou comentários. Notas e comentários ficam ocultos por padrão, a menos que você escolha suas posições.

Suponha que a apresentação de origem contenha notas do apresentador:

![Slide com notas do apresentador no PowerPoint](slide_with_notes.png)

O código a seguir exporta o conteúdo do slide com notas do apresentador abaixo do slide.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

O HTML exportado inclui a área de notas:

![Saída HTML com o slide e notas do apresentador](HTML_with_notes.png)

Para exportar comentários, defina `CommentsPosition`, por exemplo `CommentsPositions.Right` ou `CommentsPositions.Bottom`. Se precisar somente de comentários, omita `NotesPosition`. Se precisar de notas e comentários, defina ambas as propriedades.

## **Controlar qualidade da imagem e áreas recortadas**

A exportação HTML pode comprimir imagens dos slides para reduzir o tamanho da saída. Defina `PicturesCompression` com um valor de [PicturesCompression](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturescompression/) quando precisar de maior qualidade de imagem.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Por padrão, áreas recortadas de imagens podem ser removidas da saída exportada. Mantenha os dados recortados apenas quando for necessário que os usuários recuperem ou inspecionem essas partes ocultas da imagem. Mantê‑los pode aumentar o tamanho do HTML.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Adicionar CSS**

Para estilização simples, passe uma string CSS para `HtmlFormatter.createDocumentFormatter`. Isso altera o documento HTML ao redor enquanto o Aspose.Slides continua a renderizar o conteúdo dos slides.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Para um cabeçalho de documento personalizado, um arquivo CSS vinculado ou marcação personalizada ao redor de slides e formas, use [HtmlFormatter](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/htmlformatter/) com um controlador de formatação.

## **Incorporar fontes**

Se o ambiente de destino puder não ter as fontes da apresentação instaladas, incorpore as fontes no HTML com [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/embedallfontshtmlcontroller/). A incorporação melhora a fidelidade visual, mas aumenta o tamanho da saída.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Exclua fontes apenas quando estiver confiante de que os navegadores ou sistemas de destino já as fornecem. Para fontes da marca ou fontes menos comuns, a incorporação costuma ser mais segura.

## **Vincular arquivos de fontes em vez de incorporá‑los**

Para reduzir o tamanho do arquivo HTML, você pode gravar os dados das fontes em arquivos WOFF separados e adicionar regras `@font-face` ao HTML. No Node.js via Java, esse cenário costuma ser implementado com uma pequena classe auxiliar Java que estende [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/embedallfontshtmlcontroller/), grava os bytes das fontes em um diretório de saída e injeta regras `@font-face` no HTML gerado. Compile essa classe auxiliar, adicione‑a ao classpath do módulo Node.js e então instancie‑a a partir do JavaScript com `java.newInstanceSync`.

Ao construir essa classe auxiliar, escolha dois caminhos deliberadamente:

- O caminho de saída do sistema de arquivos, onde os arquivos de fonte gerados são gravados.  
- O caminho URL, que é o que o navegador usa a partir do documento HTML para carregar esses arquivos de fonte.

## **Gravar recursos externamente**

HTML autocontido é fácil de mover, mas recursos Base64 incorporados podem tornar o arquivo grande. Se sua aplicação precisar de arquivos externos de imagem, fonte, áudio ou vídeo, use um controlador de exportação que grava recursos em um diretório escolhido e emite URLs visíveis ao navegador. Mantenha o caminho do sistema de arquivos e o caminho URL alinhados com o layout de implantação.

## **Exportar arquivos de mídia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) exporta arquivos de vídeo e áudio e grava HTML que pode reproduzi‑los no navegador. Seu construtor recebe:

- `path`: o diretório onde os arquivos de mídia gerados serão gravados.  
- `fileName`: o nome do arquivo HTML que está sendo gerado.  
- `baseUri`: o prefixo URI absoluto usado nos links HTML para os arquivos de mídia.

Se o arquivo HTML for `html-output/presentation.html` e os arquivos de mídia forem salvos em `html-output/media`, `path` deve apontar para o diretório de mídia no disco, enquanto `baseUri` deve apontar para o mesmo diretório do ponto de vista do navegador. Para pré‑visualização local, você pode criar um URI `file:///` a partir do diretório de mídia. Para uma aplicação implantada, use a URL absoluta do diretório de mídia publicado.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Use diretórios de saída que sejam exclusivos por trabalho de exportação, especialmente em aplicações de servidor. Caminhos de saída compartilhados podem fazer com que arquivos de diferentes conversões sobrescrevam uns aos outros.

## **Desempenho e gerenciamento de recursos**

A conversão HTML é uma operação de renderização, portanto o tempo de processamento e o uso de memória dependem da contagem de slides, resolução das imagens, fontes, efeitos, gráficos e mídia incorporada. Valores de DPI mais altos em `PicturesCompression`, fontes incorporadas, saída SVG e áreas de imagem recortadas retidas podem melhorar a fidelidade, mas normalmente aumentam o tamanho da saída.

Para conversão em lote:

- Descarte cada instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) prontamente.  
- Use diretórios de saída separados para trabalhos separados.  
- Evite incorporar fontes comuns a menos que a fidelidade exija.  
- Reduza a DPI da imagem quando o HTML for para pré‑visualização ou miniaturas.  
- Mantenha a apresentação origem, o HTML gerado e os recursos externos juntos até que os caminhos de implantação estejam definidos.

## **FAQ**

**Os hyperlinks são preservados na saída HTML?**

Sim. Hyperlinks da apresentação são exportados para HTML e permanecem clicáveis quando a URL de destino é válida.

**Posso converter apresentações para HTML em paralelo?**

Sim, mas não compartilhe uma instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) entre workers. Processe arquivos diferentes com instâncias de apresentação distintas, fluxos separados e diretórios de saída diferentes. Consulte a [orientação de multithreading](/slides/pt/nodejs-java/multithreading/) para detalhes.

**Um objeto Presentation é thread‑safe?**

Não. Uma única instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) deve ser carregada, modificada, salva e descartada em um único worker. Para trabalho paralelo, crie uma instância independente por worker ou processo.

**Por que o arquivo HTML gerado é grande?**

A exportação padrão pode incorporar recursos diretamente no HTML. Fontes incorporadas, imagens de alta DPI, mídia, conteúdo SVG e áreas de imagem recortadas retidas também aumentam o tamanho. Use recursos externos, exclua fontes comuns da incorporação e diminua `PicturesCompression` quando um tamanho menor for mais importante que a fidelidade máxima.

**Por que um tamanho de fonte do PowerPoint como 24 pt aparece como 17,999819 pt no HTML?**

Isso pode acontecer porque PowerPoint e HTML usam modelos de DPI diferentes. O PowerPoint armazena tamanhos de texto em pontos tipográficos baseados em 72 DPI, enquanto o layout HTML baseia‑se em pixels CSS em um modelo de 96 DPI. Quando o Aspose.Slides exporta uma apresentação para HTML, o tamanho da fonte é convertido entre esses sistemas, e a conversão pode introduzir pequenas diferenças de arredondamento.

Esses valores não indicam uma mudança visual real no tamanho da fonte. São apenas um efeito colateral matemático da conversão de métricas de texto entre PowerPoint e HTML.

**Como devo escolher o baseUri para exportação de mídia?**

Escolha `baseUri` do ponto de vista do navegador e passe‑o como uma URI absoluta. Para pré‑visualização local, você pode derivá‑lo do diretório de saída com uma URI `file:///`. Para implantação, use a URL absoluta do diretório de mídia publicado. O caminho de sistema de arquivos `path` e o `baseUri` do navegador não precisam ser a mesma string, mas devem descrever a mesma localização de recurso.

**Posso incluir slides ocultos?**

Sim. Defina `ShowHiddenSlides` como `true` em [HtmlOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/htmloptions/) quando slides ocultos precisarem ser exportados.