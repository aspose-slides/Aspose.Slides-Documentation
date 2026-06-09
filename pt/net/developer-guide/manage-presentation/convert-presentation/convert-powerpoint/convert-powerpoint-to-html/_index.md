---
title: Converter apresentações PowerPoint para HTML em .NET
linktitle: PowerPoint para HTML
type: docs
weight: 30
url: /pt/net/convert-powerpoint-to-html/
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
- .NET
- C#
- Aspose.Slides
description: "Converter apresentações PowerPoint para HTML em .NET. Use Aspose.Slides para exportar arquivos PPT e PPTX, slides selecionados, notas, fontes, imagens, SVG e mídia."
---
## **Visão geral**

Aspose.Slides for .NET pode salvar apresentações PowerPoint como HTML sem o Microsoft PowerPoint. A conversão básica consiste em carregar uma única [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e chamar [Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) com [SaveFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/). Use [HtmlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/htmloptions/) quando precisar controlar o layout exportado, fontes, imagens, notas, comentários, saída SVG ou recursos vinculados.

Este guia foca em cenários práticos de exportação para HTML:

- Exportar uma apresentação inteira ou slides selecionados.
- Gerar HTML com layout fixo, responsivo ou baseado em SVG.
- Incluir anotações do apresentador e comentários.
- Controlar a qualidade da imagem e dados de imagens recortadas.
- Incorporar fontes ou salvar arquivos de fontes separadamente.
- Escolher como recursos externos e arquivos de mídia são gravados e referenciados.

Por padrão, a exportação para HTML produz um documento HTML autônomo onde a maioria dos recursos está incorporada. Isso é conveniente para compartilhar um único arquivo, mas pode aumentar o tamanho da saída. Para publicação na web, considere recursos externos, reduzir DPI da imagem e incorporar somente fontes que não estejam disponíveis de forma confiável no ambiente de destino.

## **Converter uma Apresentação para HTML**

Para exportar uma apresentação para HTML, carregue-a com [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e salve-a com [SaveFormat.Html](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

Este exemplo grava um arquivo HTML. O objeto presentation é descartado pela declaração `using`, que libera manipuladores de arquivo e recursos de renderização após a exportação.

## **Usar HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/htmloptions/) é a classe principal de configuração para exportação HTML. Configurações comuns incluem:

- `SlidesLayoutOptions`: adiciona notas, comentários, folhetos ou outras informações de layout.
- `HtmlFormatter`: altera a estrutura do documento HTML ou delega a formatação a um controlador.
- `SlideImageFormat`: altera como os slides são representados, por exemplo como SVG.
- `PicturesCompression`: controla DPI da imagem e tamanho da saída.
- `DeletePicturesCroppedAreas`: mantém ou remove dados de imagens recortadas.
- `SvgResponsiveLayout`: faz o conteúdo SVG exportado adaptar-se ao seu contêiner.
- `ShowHiddenSlides`: inclui slides ocultos quando necessário.

As seções a seguir mostram as opções mais comuns separadamente, para que você possa combinar apenas as que seu fluxo de trabalho necessita.

## **Converter Slides Selecionados para HTML**

A sobrecarga [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) que aceita números de slide usa posições de slide baseadas em 1. O loop abaixo salva cada slide em um arquivo HTML separado.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

Use este padrão quando um site ou aplicativo precisar de uma página HTML por slide. Se cada slide deve ter o mesmo layout, crie uma instância de [HtmlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/htmloptions/) e passe-a para cada chamada `Save`.

## **Criar HTML Responsivo**

[ResponsiveHtmlController](https://reference.aspose.com/slides/pt/net/aspose.slides.export/responsivehtmlcontroller/) fornece saída HTML responsiva através de [HtmlFormatter](https://reference.aspose.com/slides/pt/net/aspose.slides.export/htmlformatter/). Use-o quando a página exportada deve se adaptar melhor à largura do navegador.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

Para layout responsivo baseado em SVG, defina `SvgResponsiveLayout` em [HtmlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/htmloptions/). Isso é útil quando o conteúdo do slide é exportado como marcação SVG escalável.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **Incluir Notas do Apresentador e Comentários**

Use [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/notescommentslayoutingoptions/) através de `HtmlOptions.SlidesLayoutOptions` para incluir notas do apresentador ou comentários. Notas e comentários são ocultos por padrão, a menos que você escolha suas posições.

Suponha que a apresentação fonte contenha notas do apresentador:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

O código a seguir exporta o conteúdo do slide com notas do apresentador abaixo do slide.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Para exportar comentários, defina `CommentsPosition`, por exemplo para `CommentsPositions.Right` ou `CommentsPositions.Bottom`. Se precisar apenas de comentários, omita `NotesPosition`. Se precisar tanto de notas quanto de comentários, defina ambas as propriedades.

## **Controlar Qualidade da Imagem e Áreas Recortadas**

A exportação HTML pode comprimir imagens dos slides para reduzir o tamanho da saída. Defina `PicturesCompression` para um valor de [PicturesCompression](https://reference.aspose.com/slides/pt/net/aspose.slides.export/picturescompression/) quando precisar de maior qualidade de imagem.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

Por padrão, áreas recortadas de imagens podem ser removidas da saída exportada. Mantenha os dados recortados somente quando os usuários precisarem recuperar ou inspecionar essas partes ocultas da imagem. Mantê-los pode aumentar o tamanho do HTML.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **Adicionar CSS**

Para estilização simples, passe uma string CSS para [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/pt/net/aspose.slides.export/htmlformatter/createdocumentformatter/). Isso altera o documento HTML ao redor enquanto Aspose.Slides continua a renderizar o conteúdo do slide.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

Para um cabeçalho de documento customizado, um arquivo CSS vinculado ou marcação personalizada ao redor de slides e formas, implemente [IHtmlFormattingController](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ihtmlformattingcontroller/) e passe-o para [HtmlFormatter](https://reference.aspose.com/slides/pt/net/aspose.slides.export/htmlformatter/) com `CreateCustomFormatter`.

## **Incorporar Fontes**

Se o ambiente de destino pode não ter as fontes da apresentação instaladas, incorpore as fontes no HTML com [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pt/net/aspose.slides.export/embedallfontshtmlcontroller/). Incorporar melhora a fidelidade visual, mas aumenta o tamanho da saída.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

Exclua fontes somente quando estiver confiante de que os navegadores ou sistemas de destino já as fornecem. Para fontes de marca ou fontes menos comuns, incorporar costuma ser mais seguro.

## **Vincular Arquivos de Fonte em Vez de Incorporá-los**

Para reduzir o tamanho do arquivo HTML, você pode gravar os dados da fonte em arquivos WOFF separados e adicionar regras `@font-face` ao HTML. O helper abaixo estende [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pt/net/aspose.slides.export/embedallfontshtmlcontroller/) e substitui `WriteFont`.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

Neste exemplo, os arquivos de fonte são salvos em `html-output/fonts`, e o HTML os referencia com URLs como `fonts/BrandFont-normal-400.woff`. Se o arquivo HTML e as fontes forem implantados em outro local, escolha `fontUrlPrefix` de modo que corresponda ao caminho de URL implantado.

## **Salvar Recursos Externamente**

HTML autônomo é fácil de mover, mas recursos Base64 incorporados podem tornar o arquivo grande. Se sua aplicação precisar de arquivos de imagem externos, implemente [ILinkEmbedController](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ilinkembedcontroller/) e passe-o ao construtor [HtmlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/htmloptions/htmloptions/).

Ao externalizar recursos, escolha dois caminhos deliberadamente:

- O caminho de saída do sistema de arquivos, onde sua aplicação grava imagens, fontes, áudio ou vídeo gerados.
- O caminho URL, que é o que o navegador usa a partir do documento HTML para carregar esses arquivos.

Para uma implementação completa de link de imagens, veja [Exportar Apresentações para HTML com Imagens Vinculadas Externamente](/slides/pt/net/exporting-presentations-to-html-with-externally-linked-images/).

## **Exportar Arquivos de Mídia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/pt/net/aspose.slides.export/videoplayerhtmlcontroller/) exporta arquivos de vídeo e áudio e grava HTML que pode reproduzi-los em um navegador. Seu construtor recebe:

- `path`: o diretório onde os arquivos de mídia gerados serão gravados.
- `fileName`: o nome do arquivo HTML que está sendo gerado.
- `baseUri`: o prefixo URI absoluto usado nos links HTML para arquivos de mídia.

Se o arquivo HTML for `html-output/presentation.html` e os arquivos de mídia forem salvos em `html-output/media`, `path` deve apontar para o diretório de mídia no disco, enquanto `baseUri` deve apontar para o mesmo diretório do ponto de vista do navegador. Para pré‑visualização local, você pode construir um URI `file:///` a partir do diretório de mídia. Para uma aplicação implantada, use a URL absoluta do diretório de mídia publicado.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

Use diretórios de saída que sejam únicos por trabalho de exportação, especialmente em aplicações de servidor. Caminhos de saída compartilhados podem fazer com que arquivos de diferentes conversões sobrescrevam uns aos outros.

## **Desempenho e Gerenciamento de Recursos**

A conversão HTML é uma operação de renderização, portanto o tempo de processamento e o uso de memória dependem da quantidade de slides, resolução das imagens, fontes, efeitos, gráficos e mídia incorporada. Valores mais altos de DPI em `PicturesCompression`, fontes incorporadas, saída SVG e áreas de imagem recortadas mantidas podem melhorar a fidelidade, mas geralmente aumentam o tamanho da saída.

Para conversão em lote:

- Libere imediatamente cada instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
- Use diretórios de saída separados para trabalhos distintos.
- Evite incorporar fontes comuns, a menos que a fidelidade exija.
- Reduza o DPI das imagens quando o HTML for para pré‑visualização ou miniaturas.
- Mantenha a apresentação fonte, o HTML gerado e os recursos externos juntos até que os caminhos de implantação estejam definidos.

## **FAQ**

**Os hyperlinks são preservados na saída HTML?**

Sim. Os hyperlinks da apresentação são exportados para HTML e permanecem clicáveis quando a URL de destino é válida.

**Posso converter apresentações para HTML em paralelo?**

Sim, mas não compartilhe uma instância de [Presentation] entre threads. Procese arquivos diferentes com instâncias de apresentação separadas, fluxos separados e diretórios de saída distintos. Veja a [multithreading guidance](/slides/pt/net/multithreading/) para detalhes.

**Um objeto Presentation é thread‑safe?**

Não. Uma única instância de [Presentation] deve ser carregada, modificada, salva e descartada em uma única thread. Para trabalho paralelo, crie uma instância independente por thread ou processo.

**Por que o arquivo HTML gerado é grande?**

A exportação padrão pode incorporar recursos diretamente no HTML. Fontes incorporadas, imagens de alta DPI, mídia, conteúdo SVG e áreas de imagem recortadas mantidas também aumentam o tamanho. Use recursos externos, exclua fontes comuns da incorporação e reduza `PicturesCompression` quando um tamanho menor for mais importante que a fidelidade máxima.

**Por que um tamanho de fonte do PowerPoint, como 24 pt, aparece como 17,999819 pt no HTML?**

Isso pode acontecer porque o PowerPoint e o HTML usam modelos de DPI diferentes. O PowerPoint armazena tamanhos de texto em pontos tipográficos baseados em 72 DPI, enquanto o layout HTML é baseado em pixels CSS em um modelo de 96 DPI. Quando o Aspose.Slides exporta uma apresentação para HTML, o tamanho da fonte é traduzido entre esses sistemas, e a conversão pode introduzir pequenas diferenças de arredondamento.

Esses valores não indicam uma mudança real no tamanho visual da fonte. Eles são apenas um efeito colateral matemático da conversão de métricas de texto entre PowerPoint e HTML.

**Como devo escolher baseUri para exportação de mídia?**

Escolha `baseUri` do ponto de vista do navegador e passe-o como uma URI absoluta. Para pré‑visualização local, você pode derivá‑lo do diretório de saída com `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri`. Para implantação, use a URL absoluta do diretório de mídia publicado. O `path` do sistema de arquivos e o `baseUri` do navegador não precisam ser a mesma string, mas devem descrever a mesma localização de recurso.

**Posso incluir slides ocultos?**

Sim. Defina `ShowHiddenSlides = true` em [HtmlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/htmloptions/) quando slides ocultos precisam ser exportados.