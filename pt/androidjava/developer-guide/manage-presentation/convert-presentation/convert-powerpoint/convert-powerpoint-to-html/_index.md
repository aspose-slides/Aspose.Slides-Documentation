---
title: Converter apresentações PowerPoint para HTML no Android
linktitle: PowerPoint para HTML
type: docs
weight: 30
url: /pt/androidjava/convert-powerpoint-to-html/
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
- Android
- Java
- Aspose.Slides
description: "Converter apresentações PowerPoint para HTML no Android. Use Aspose.Slides para Android via Java para exportar arquivos PPT e PPTX, slides selecionados, notas, fontes, imagens, SVG e mídia."
---
## **Visão geral**

Aspose.Slides para Android via Java pode salvar apresentações PowerPoint como HTML sem o Microsoft PowerPoint. A conversão básica consiste em um único carregamento de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e uma chamada `save` com [SaveFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveformat/). Use [HtmlOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/htmloptions/) quando precisar controlar o layout exportado, fontes, imagens, notas, comentários, saída SVG ou recursos vinculados.

Este guia foca em cenários práticos de exportação HTML:

- Exportar uma apresentação inteira ou slides selecionados.
- Gerar HTML com layout fixo, responsivo ou baseado em SVG.
- Incluir notas do apresentador e comentários.
- Controlar a qualidade da imagem e os dados de imagens recortadas.
- Incorporar fontes ou salvar arquivos de fontes separadamente.
- Escolher como recursos externos e arquivos de mídia são gravados e referenciados.

Por padrão, a exportação HTML produz um documento HTML autossuficiente onde a maioria dos recursos está incorporada. Isso é conveniente para compartilhar um único arquivo, mas pode aumentar o tamanho da saída. Para publicação na web, considere recursos externos, DPI de imagem mais baixo e apenas incorporar fontes que não estejam disponíveis de forma confiável no ambiente de destino.

## **Converter uma Apresentação para HTML**

Para exportar uma apresentação para HTML, carregue-a com [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e salve-a com [SaveFormat.Html](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Este exemplo grava um arquivo HTML. O objeto de apresentação é descartado no bloco `finally`, que libera os manipuladores de arquivos e recursos de renderização após a exportação.

## **Usar HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/htmloptions/) é a principal classe de configuração para a exportação HTML. Configurações comuns incluem:

- `SlidesLayoutOptions`: adiciona notas, comentários, folhetos ou outras informações de layout.
- `HtmlFormatter`: altera a estrutura do documento HTML ou delega a formatação a um controlador.
- `SlideImageFormat`: altera a forma como os slides são representados, por exemplo como SVG.
- `PicturesCompression`: controla o DPI da imagem e o tamanho da saída.
- `DeletePicturesCroppedAreas`: mantém ou remove os dados de imagens recortadas.
- `SvgResponsiveLayout`: faz o conteúdo SVG exportado se adaptar ao seu contêiner.
- `ShowHiddenSlides`: inclui slides ocultos quando necessário.

As seções a seguir mostram as opções mais comuns separadamente, para que você possa combinar apenas as que seu fluxo de trabalho necessita.

## **Converter Slides Selecionados para HTML**

A sobrecarga `Presentation.save` que aceita números de slides usa posições de slide baseadas em 1. O loop abaixo salva cada slide em um arquivo HTML separado.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Use este padrão quando um site ou aplicativo precisar de uma página HTML por slide. Se cada slide deve ter o mesmo layout, crie uma instância de [HtmlOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/htmloptions/) e passe-a para cada chamada `save`.

## **Criar HTML Responsivo**

[ResponsiveHtmlController](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/responsivehtmlcontroller/) fornece saída HTML responsiva através de [HtmlFormatter](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/htmlformatter/). Use-o quando a página exportada precisar se adaptar melhor à largura do navegador.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Para layout responsivo baseado em SVG, defina `SvgResponsiveLayout` em [HtmlOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/htmloptions/). Isso é útil quando o conteúdo do slide é exportado como marcação SVG escalável.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Incluir Notas do Apresentador e Comentários**

Use [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/notescommentslayoutingoptions/) através de `HtmlOptions.SlidesLayoutOptions` para incluir notas do apresentador ou comentários. Notas e comentários ficam ocultos por padrão, a menos que você escolha suas posições.

Suponha que a apresentação de origem contenha notas do apresentador:

![Slide com notas do apresentador no PowerPoint](slide_with_notes.png)

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

O código a seguir exporta o conteúdo do slide com notas do apresentador abaixo do slide.

![Saída HTML com o slide e notas do apresentador](HTML_with_notes.png)

Para exportar comentários, defina `CommentsPosition`, por exemplo para `CommentsPositions.Right` ou `CommentsPositions.Bottom`. Se precisar apenas de comentários, omita `NotesPosition`. Se precisar de notas e comentários, defina ambas as propriedades.

## **Controlar Qualidade da Imagem e Áreas Recortadas**

A exportação HTML pode comprimir as imagens dos slides para reduzir o tamanho da saída. Defina `PicturesCompression` com um valor de [PicturesCompression](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/picturescompression/) quando precisar de maior qualidade de imagem.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Por padrão, áreas recortadas de imagens podem ser removidas da saída exportada. Mantenha os dados recortados somente quando os usuários precisarem recuperar ou inspecionar essas partes ocultas da imagem. Mantê‑los pode aumentar o tamanho do HTML.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Adicionar CSS**

Para estilização simples, passe uma string CSS para `HtmlFormatter.createDocumentFormatter`. Isso altera o documento HTML ao redor enquanto Aspose.Slides continua a renderizar o conteúdo do slide.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Para um cabeçalho de documento personalizado, um arquivo CSS vinculado ou marcação personalizada ao redor de slides e formas, implemente [IHtmlFormattingController](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ihtmlformattingcontroller/) e passe‑o para [HtmlFormatter](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/htmlformatter/) com `createCustomFormatter`.

## **Incorporar Fontes**

Se o ambiente de destino pode não ter as fontes da apresentação instaladas, incorpore as fontes no HTML com [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/embedallfontshtmlcontroller/). A incorporação melhora a fidelidade visual, mas aumenta o tamanho da saída.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Exclua fontes somente quando estiver confiante de que os navegadores ou sistemas de destino já as fornecem. Para fontes de marca ou fontes menos comuns, a incorporação costuma ser mais segura.

## **Vincular Arquivos de Fonte ao Em vez de Incorporá‑los**

Para reduzir o tamanho do arquivo HTML, você pode gravar os dados da fonte em arquivos WOFF separados e adicionar regras `@font-face` ao HTML. O auxiliar abaixo estende [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) e substitui `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Neste exemplo, os arquivos de fonte são salvos em `html-output/fonts`, e o HTML os referencia com URLs como `fonts/BrandFont-normal-400.woff`. Se o arquivo HTML e as fontes forem implantados em outro local, escolha `fontUrlPrefix` para que corresponda ao caminho de URL implantado.

## **Salvar Recursos Externamente**

HTML autossuficiente é fácil de mover, mas recursos incorporados em Base64 podem tornar o arquivo grande. Se sua aplicação precisar de arquivos de imagem externos, implemente [ILinkEmbedController](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilinkembedcontroller/) e passe‑o ao construtor de [HtmlOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/htmloptions/).

Ao externalizar recursos, escolha dois caminhos deliberadamente:

- O caminho de saída no sistema de arquivos, onde sua aplicação grava imagens, fontes, áudio ou vídeo gerados.
- O caminho de URL, que é o que o navegador usa a partir do documento HTML para carregar esses arquivos.

## **Exportar Arquivos de Mídia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) exporta arquivos de vídeo e áudio e grava HTML que pode reproduzi‑los em um navegador. Seu construtor recebe:

- `path`: o diretório onde os arquivos de mídia gerados serão gravados.
- `fileName`: o nome do arquivo HTML que está sendo gerado.
- `baseUri`: o prefixo de URI absoluto usado nos links HTML para os arquivos de mídia.

Se o arquivo HTML for `html-output/presentation.html` e os arquivos de mídia forem salvos em `html-output/media`, `path` deve apontar para o diretório de mídia no disco, enquanto `baseUri` deve apontar para o mesmo diretório do ponto de vista do navegador. Para pré‑visualização local, você pode criar uma URI `file:///` a partir do diretório de mídia. Para uma aplicação implantada, use a URL absoluta do diretório de mídia publicado.

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Use diretórios de saída que sejam únicos por tarefa de exportação, especialmente em aplicações de servidor. Caminhos de saída compartilhados podem fazer com que arquivos de diferentes conversões sobrescrevam uns aos outros.

## **Desempenho e Gerenciamento de Recursos**

A conversão HTML é uma operação de renderização, portanto o tempo de processamento e o uso de memória dependem da contagem de slides, resolução das imagens, fontes, efeitos, gráficos e mídia incorporada. Valores mais altos de DPI em `PicturesCompression`, fontes incorporadas, saída SVG e áreas de imagem recortadas retidas podem melhorar a fidelidade, mas geralmente aumentam o tamanho da saída.

Para conversão em lote:

- Descarte rapidamente cada instância de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
- Use diretórios de saída separados para trabalhos diferentes.
- Evite incorporar fontes comuns, a menos que a fidelidade exija.
- Reduza o DPI das imagens quando o HTML for para pré‑visualização ou miniaturas.
- Mantenha a apresentação fonte, o HTML gerado e os recursos externos juntos até que os caminhos de implantação sejam finais.

## **FAQ**

**Os hyperlinks são preservados na saída HTML?**

Sim. Os hyperlinks da apresentação são exportados para HTML e permanecem clicáveis quando o URL de destino é válido.

**Posso converter apresentações para HTML em paralelo?**

Sim, mas não compartilhe uma instância de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) entre threads. Processe arquivos diferentes com instâncias de apresentação separadas, streams separados e diretórios de saída distintos. Veja a [orientação de multithreading](/slides/pt/androidjava/multithreading/) para detalhes.

**Um objeto Presentation é thread‑safe?**

Não. Uma única instância de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) deve ser carregada, modificada, salva e descartada em um único thread. Para trabalho paralelo, crie uma instância independente por thread ou processo.

**Por que o arquivo HTML gerado é grande?**

A exportação padrão pode incorporar recursos diretamente no HTML. Fontes incorporadas, imagens de alta DPI, mídia, conteúdo SVG e áreas de imagem recortadas retidas também aumentam o tamanho. Use recursos externos, exclua fontes comuns da incorporação e reduza `PicturesCompression` quando um tamanho menor for mais importante que a máxima fidelidade.

**Por que um tamanho de fonte do PowerPoint como 24 pt aparece como 17.999819 pt no HTML?**

Isso pode acontecer porque o PowerPoint e o HTML usam modelos de DPI diferentes. O PowerPoint armazena os tamanhos de texto em pontos tipográficos baseados em 72 DPI, enquanto o layout HTML baseia‑se em pixels CSS em um modelo de 96 DPI. Quando o Aspose.Slides exporta uma apresentação para HTML, o tamanho da fonte é traduzido entre esses sistemas, e a conversão pode introduzir pequenas diferenças de arredondamento.

Esses valores não indicam uma mudança real no tamanho visual da fonte. Eles são apenas um efeito colateral matemático da conversão de métricas de texto entre PowerPoint e HTML.

**Como devo escolher baseUri para exportação de mídia?**

Escolha `baseUri` do ponto de vista do navegador e passe‑a como uma URI absoluta. Para pré‑visualização local, você pode derivá‑la do diretório de saída com `mediaDirectory.toUri().toString()`. Para implantação, use a URL absoluta do diretório de mídia publicado. O `path` do sistema de arquivos e o `baseUri` do navegador não precisam ser a mesma string, mas devem descrever a mesma localização de recurso.

**Posso incluir slides ocultos?**

Sim. Defina `ShowHiddenSlides` como `true` em [HtmlOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/htmloptions/) quando os slides ocultos precisarem ser exportados.