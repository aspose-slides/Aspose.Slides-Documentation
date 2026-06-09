---
title: Converter apresentações PowerPoint para HTML em C++
linktitle: PowerPoint para HTML
type: docs
weight: 30
url: /pt/cpp/convert-powerpoint-to-html/
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
- C++
- Aspose.Slides
description: "Converter apresentações PowerPoint para HTML em C++. Use Aspose.Slides para exportar arquivos PPT e PPTX, slides selecionados, notas, fontes, imagens, SVG e mídia."
---
## **Visão geral**

Aspose.Slides for C++ pode salvar apresentações PowerPoint como HTML sem o Microsoft PowerPoint. A conversão básica consiste em um único carregamento de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e uma chamada `Save` com [SaveFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveformat/). Use [HtmlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/htmloptions/) quando precisar controlar o layout exportado, fontes, imagens, notas, comentários, saída SVG ou recursos vinculados.

Este guia foca em cenários práticos de exportação HTML:

- Exportar uma apresentação completa ou slides selecionados.
- Gerar HTML com layout fixo, responsivo ou baseado em SVG.
- Incluir notas do apresentador e comentários.
- Controlar a qualidade de imagens e dados de imagens recortadas.
- Incorporar fontes ou salvar arquivos de fontes separadamente.
- Escolher como recursos externos e arquivos de mídia são gravados e referenciados.

Por padrão, a exportação HTML produz um documento HTML autônomo onde a maioria dos recursos são incorporados. Isso é conveniente para compartilhar um único arquivo, mas pode aumentar o tamanho da saída. Para publicação web, considere recursos externos, DPI de imagem menor e incorpore apenas fontes que não estejam disponíveis de forma confiável no ambiente de destino.

## **Converter uma Apresentação para HTML**

Para exportar uma apresentação para HTML, carregue‑a com [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e salve‑a com `SaveFormat::Html`.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

Este exemplo grava um arquivo HTML. A chamada a `Dispose` libera os manipuladores de arquivo e os recursos de renderização após a exportação.

## **Usar HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/htmloptions/) é a classe principal de configuração para exportação HTML. Configurações comuns incluem:

- `SlidesLayoutOptions`: adiciona notas, comentários, folhetos ou outras informações de layout.
- `HtmlFormatter`: altera a estrutura do documento HTML ou delega a formatação a um controlador.
- `SlideImageFormat`: altera a forma como os slides são representados, por exemplo como SVG.
- `PicturesCompression`: controla a DPI das imagens e o tamanho da saída.
- `DeletePicturesCroppedAreas`: mantém ou remove dados de imagens recortadas.
- `SvgResponsiveLayout`: faz o conteúdo SVG exportado adaptar‑se ao seu contêiner.
- `ShowHiddenSlides`: inclui slides ocultos quando necessário.

As seções a seguir mostram as opções mais comuns separadamente para que você possa combinar apenas as que seu fluxo de trabalho necessita.

## **Converter Slides Selecionados para HTML**

A sobrecarga `Presentation::Save` que aceita números de slide usa posições baseadas em 1. O laço abaixo salva cada slide em um arquivo HTML separado.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

Use este padrão quando um site ou aplicação precisar de uma página HTML por slide. Se cada slide deve ter o mesmo layout, crie uma instância de [HtmlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/htmloptions/) e passe‑a a cada chamada `Save`.

## **Criar HTML Responsivo**

[ResponsiveHtmlController](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/responsivehtmlcontroller/) fornece saída HTML responsiva através de [HtmlFormatter](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/htmlformatter/). Use‑o quando a página exportada precisar adaptar‑se melhor à largura do navegador.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Para layout responsivo baseado em SVG, defina `SvgResponsiveLayout` em [HtmlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/htmloptions/). Isso é útil quando o conteúdo do slide é exportado como marcação SVG escalável.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Incluir Notas do Apresentador e Comentários**

Use [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/notescommentslayoutingoptions/) através de `HtmlOptions.SlidesLayoutOptions` para incluir notas do apresentador ou comentários. Notas e comentários são ocultos por padrão, a menos que você escolha suas posições.

Suponha que a apresentação de origem contenha notas do apresentador:

![Slide com notas do apresentador no PowerPoint](slide_with_notes.png)

O código a seguir exporta o conteúdo do slide com as notas do apresentador abaixo do slide.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

A saída HTML inclui a área de notas:

![Saída HTML com o slide e notas do apresentador](HTML_with_notes.png)

Para exportar comentários, defina `CommentsPosition`, por exemplo para `CommentsPositions::Right` ou `CommentsPositions::Bottom`. Se precisar apenas de comentários, omita `NotesPosition`. Se precisar de notas e comentários, defina ambas as propriedades.

## **Controlar Qualidade de Imagem e Áreas Recortadas**

A exportação HTML pode comprimir imagens de slides para reduzir o tamanho da saída. Defina `PicturesCompression` para um valor de [PicturesCompression](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/picturescompression/) quando precisar de maior qualidade de imagem.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Por padrão, áreas recortadas de imagens podem ser removidas da saída exportada. Mantenha os dados recortados apenas quando os usuários precisarem recuperar ou inspecionar essas partes ocultas da imagem. Mantê‑los pode aumentar o tamanho do HTML.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Adicionar CSS**

Para estilização simples, passe uma string CSS para `HtmlFormatter::CreateDocumentFormatter`. Isso altera o documento HTML ao redor enquanto Aspose.Slides continua a renderizar o conteúdo do slide.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Para um cabeçalho de documento personalizado, um arquivo CSS vinculado ou marcação personalizada ao redor de slides e formas, implemente [IHtmlFormattingController](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/ihtmlformattingcontroller/) e passe‑o para [HtmlFormatter](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/htmlformatter/) com `CreateCustomFormatter`.

## **Incorporar Fontes**

Se o ambiente de destino pode não ter as fontes da apresentação instaladas, incorpore fontes no HTML com [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/embedallfontshtmlcontroller/). Incorporar melhora a fidelidade visual, mas aumenta o tamanho da saída.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Exclua fontes apenas quando estiver confiante de que os navegadores ou sistemas de destino já as fornecem. Para fontes de marca ou fontes menos comuns, a incorporação costuma ser mais segura.

## **Vincular Arquivos de Fonte Em Vez de Incorporá-los**

Para reduzir o tamanho do arquivo HTML, você pode gravar os dados da fonte em arquivos WOFF separados e adicionar regras `@font-face` ao HTML. O ajudante abaixo estende [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/embedallfontshtmlcontroller/) e sobrescreve `WriteFont`.

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Neste exemplo, os arquivos de fonte são salvos em `html-output/fonts`, e o HTML os referencia com URLs como `fonts/BrandFont-normal-400.woff`. Se o arquivo HTML e as fontes forem implantados em outro local, escolha `fontUrlPrefix` de modo que corresponda ao caminho URL implantado.

## **Salvar Recursos Externamente**

HTML autônomo é fácil de mover, mas recursos incorporados em Base64 podem tornar o arquivo grande. Se sua aplicação precisar de arquivos de imagem externos, implemente [ILinkEmbedController](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/ilinkembedcontroller/) e passe‑o ao construtor de [HtmlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/htmloptions/).

Ao externalizar recursos, escolha dois caminhos deliberadamente:

- O caminho de saída no sistema de arquivos, onde sua aplicação grava imagens, fontes, áudio ou vídeo gerados.
- O caminho URL, que é o que o navegador usa no documento HTML para carregar esses arquivos.

## **Exportar Arquivos de Mídia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/videoplayerhtmlcontroller/) exporta arquivos de vídeo e áudio e grava HTML que pode reproduzi‑los em um navegador. Seu construtor recebe:

- `path`: o diretório onde os arquivos de mídia gerados serão gravados.
- `fileName`: o nome do arquivo HTML que está sendo gerado.
- `baseUri`: o prefixo URI absoluto usado nos links HTML para os arquivos de mídia.

Se o arquivo HTML for `html-output/presentation.html` e os arquivos de mídia forem salvos em `html-output/media`, `path` deve apontar para o diretório de mídia no disco, enquanto `baseUri` deve apontar para o mesmo diretório do ponto de vista do navegador. Para visualização local, você pode montar um URI `file:///` a partir do diretório de mídia. Para uma aplicação implantada, use a URL absoluta do diretório de mídia publicado.

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

Use diretórios de saída que sejam exclusivos por tarefa de exportação, especialmente em aplicações de servidor. Caminhos de saída compartilhados podem fazer com que arquivos de diferentes conversões sobrescrevam uns aos outros.

## **Desempenho e Gerenciamento de Recursos**

A conversão HTML é uma operação de renderização, portanto o tempo de processamento e o uso de memória dependem da quantidade de slides, resolução das imagens, fontes, efeitos, gráficos e mídia incorporada. Valores mais altos de DPI em `PicturesCompression`, fontes incorporadas, saída SVG e áreas de imagem recortadas retidas podem melhorar a fidelidade, mas geralmente aumentam o tamanho da saída.

Para conversão em lote:

- Dispose de cada instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) prontamente.
- Use diretórios de saída separados para trabalhos distintos.
- Evite incorporar fontes comuns a menos que a fidelidade exija.
- Reduza a DPI das imagens quando o HTML for para visualização ou miniaturas.
- Mantenha a apresentação fonte, o HTML gerado e os recursos externos juntos até que os caminhos de implantação estejam definidos.

## **FAQ**

**Os hiperlinks são preservados na saída HTML?**

Sim. Os hiperlinks da apresentação são exportados para HTML e permanecem clicáveis quando o URL de destino é válido.

**Posso converter apresentações para HTML em paralelo?**

Sim, mas não compartilhe uma única instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) entre threads. Procese arquivos diferentes com instâncias de apresentação separadas, streams separados e diretórios de saída distintos. Consulte a [multithreading guidance](/slides/pt/cpp/multithreading/) para detalhes.

**Um objeto Presentation é thread‑safe?**

Não. Uma única instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) deve ser carregada, modificada, salva e descartada em uma única thread. Para trabalho paralelo, crie uma instância independente por thread ou processo.

**Por que o arquivo HTML gerado é grande?**

A exportação padrão pode incorporar recursos diretamente no HTML. Fontes incorporadas, imagens de alta DPI, mídia, conteúdo SVG e áreas de imagem recortadas retidas também aumentam o tamanho. Use recursos externos, exclua fontes comuns da incorporação e reduza `PicturesCompression` quando uma saída menor for mais importante que a fidelidade máxima.

**Por que um tamanho de fonte do PowerPoint como 24 pt aparece como 17.999819 pt no HTML?**

Isso pode acontecer porque PowerPoint e HTML utilizam modelos de DPI diferentes. O PowerPoint armazena tamanhos de texto em pontos tipográficos baseados em 72 DPI, enquanto o layout HTML baseia‑se em pixels CSS em um modelo de 96 DPI. Quando Aspose.Slides exporta uma apresentação para HTML, o tamanho da fonte é traduzido entre esses sistemas, e a conversão pode introduzir pequenas diferenças de arredondamento.

Esses valores não indicam uma mudança visual real no tamanho da fonte. Eles são apenas um efeito colateral matemático da conversão de métricas de texto entre PowerPoint e HTML.

**Como devo escolher baseUri para exportação de mídia?**

Escolha `baseUri` a partir do ponto de vista do navegador e passe‑o como uma URI absoluta. Para visualização local, você pode obtê‑la a partir do diretório de saída com `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()`. Para implantação, use a URL absoluta do diretório de mídia publicado. O caminho de sistema de arquivos `path` e o `baseUri` do navegador não precisam ser a mesma string, mas devem referir‑se ao mesmo local de recurso.

**Posso incluir slides ocultos?**

Sim. Defina `ShowHiddenSlides` como `true` em [HtmlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/htmloptions/) quando slides ocultos precisam ser exportados.