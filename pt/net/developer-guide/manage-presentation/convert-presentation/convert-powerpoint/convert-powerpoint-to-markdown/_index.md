---
title: Converter apresentações PowerPoint para Markdown em .NET
linktitle: PowerPoint para Markdown
type: docs
weight: 140
url: /pt/net/convert-powerpoint-to-markdown/
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
- exportação de imagens Markdown
- links de imagens CDN
- PowerPoint
- apresentação
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Converter apresentações PPT e PPTX para Markdown em .NET e controlar onde as imagens bitmap, metafile e SVG exportadas são salvas e referenciadas."
---
## **Visão geral**

Aspose.Slides for .NET pode converter apresentações PPT e PPTX para Markdown para documentação, sites estáticos, migração de conteúdo e fluxos de trabalho de controle de versão. Você pode escolher um sabor de Markdown, controlar como o conteúdo dos slides é renderizado e decidir onde as imagens exportadas são armazenadas e como o Markdown gerado as referencia.

Por padrão, a exportação para Markdown usa saída apenas de texto. Para exportar conteúdo visual, defina a propriedade [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownsaveoptions/exporttype/) para o valor `Sequential` ou `Visual` da enumeração [MarkdownExportType](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownexporttype/). `Sequential` renderiza os itens do slide separadamente e em ordem, enquanto `Visual` mantém os itens agrupados juntos para preservar sua relação visual. O valor `TextOnly` não emite recursos de imagem, portanto os eventos de salvamento de imagem não são invocados nesse modo.

## **Converter uma apresentação para Markdown**

Carregue o arquivo de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e, em seguida, chame o método [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) com o valor `Md` da enumeração [SaveFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Selecionar um sabor de Markdown**

A propriedade [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownsaveoptions/flavor/) controla a especificação de Markdown usada na saída. A enumeração [Flavor](https://reference.aspose.com/slides/pt/net/aspose.slides.export/flavor/) inclui CommonMark, GitHub Flavored Markdown e outras variantes suportadas.

O exemplo a seguir exporta uma apresentação como CommonMark:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **Exportar imagens usando o comportamento padrão de salvamento local**

A classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownsaveoptions/) fornece duas propriedades para imagens salvas localmente:

- [BasePath](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownsaveoptions/basepath/) especifica o diretório base para o documento Markdown e seus recursos.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) especifica o subdiretório de imagens. Seu valor padrão é `Images`.

O exemplo a seguir renderiza conteúdo visual, grava imagens em `output/assets` e cria referências de imagem relativas no documento Markdown:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Esse comportamento também serve como fallback quando um manipulador personalizado de salvamento de imagem retorna `false`.

## **Personalizar o salvamento de imagens e links Markdown**

Use o evento [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownsaveoptions/imagesaving/) para recursos bitmap e metafile que não sejam SVG emitidos durante a exportação para Markdown. Seu delegado [MarkdownImageSavingHandler](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) recebe o objeto [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/), seu [ImageFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/imageformat/), e o link Markdown gerado como parâmetro `ref string`. Salve ou faça o upload da imagem com o formato fornecido e substitua `link` pela referência que deve aparecer na saída Markdown.

Recursos emitidos em formato SVG são tratados separadamente. Assine o evento [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/), cujo delegado [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) recebe um objeto [ISvgImage](https://reference.aspose.com/slides/pt/net/aspose.slides/isvgimage/) e o parâmetro `ref string link`. Um SVG não possui argumento `ImageFormat`; escreva ou faça o upload de seus dados XML a partir da propriedade [ISvgImage.SvgData](https://reference.aspose.com/slides/pt/net/aspose.slides/isvgimage/svgdata/). Dependendo do modo de exportação e do agrupamento visual, um SVG na apresentação de origem pode ser rasterizado ou combinado com outro conteúdo; o recurso não‑SVG resultante é então passado para `ImageSaving`. Assine ambos os eventos quando cada recurso visual exportado exigir processamento personalizado.

O valor de retorno do manipulador determina quem processa a imagem:

- Retorne `true` após o manipulador ter salvo, enviado, transformado ou processado a imagem de outra forma e atribuído um valor válido a `link`. Aspose.Slides grava esse valor no documento Markdown e não realiza o salvamento local padrão.
- Retorne `false` para permitir que Aspose.Slides salve a imagem localmente e gere seu link de acordo com [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownsaveoptions/basepath/) e [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Um manipulador que retorna `true` assume a responsabilidade pela imagem. Se ele retornar `true` sem atribuir um link válido e não vazio, a exportação falhará com uma `InvalidOperationException`.
{{% /alert %}}

### **Salvar imagens em um diretório de origem CDN e usar URLs externas**

O exemplo a seguir trata `cdn-origin/presentations/quarterly-report` como um diretório de origem CDN montado ou sincronizado. Cada manipulador extrai o nome de arquivo gerado, salva a imagem nesse diretório personalizado e substitui a referência local gerada por uma URL pública de CDN. O próprio exemplo não realiza upload de rede: a URL torna‑se válida somente após o diretório ser montado como origem CDN ou seus arquivos serem publicados na CDN. Para armazenamento de objetos, substitua a gravação no sistema de arquivos pela operação de upload do SDK de armazenamento e atribua `link` somente após o upload ser bem‑sucedido.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

O manipulador de bitmap devolve deliberadamente `false` para imagens menores que 128 × 128 pixels, de modo que Aspose.Slides salva essas imagens em `output/fallback-images` usando o comportamento padrão. Recursos bitmap e metafile maiores, bem como recursos SVG, são tratados pelo código personalizado. Por exemplo, uma referência local gerada como `fallback-images/image1.png` passa a ser `https://cdn.example.com/presentations/quarterly-report/image1.png`. Os manipuladores usam caminhos do sistema operacional apenas ao gravar arquivos; os links gravados no Markdown utilizam barras (`/`) e nomes de arquivo escapados em URL. Aplique a mesma regra ao criar links relativos: use `/`, não o separador de diretório específico da plataforma.

## **FAQ**

**Um manipulador pode processar tanto imagens raster quanto imagens SVG?**

Não. Use [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownsaveoptions/imagesaving/) para recursos bitmap e metafile emitidos e [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) para recursos emitidos como SVG. O primeiro fornece um objeto [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) e um [ImageFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/imageformat/); o segundo fornece um objeto [ISvgImage](https://reference.aspose.com/slides/pt/net/aspose.slides/isvgimage/) cujo dados SVG podem ser lidos de [ISvgImage.SvgData](https://reference.aspose.com/slides/pt/net/aspose.slides/isvgimage/svgdata/). Um SVG de origem que é rasterizado durante a exportação é processado por `ImageSaving` em vez disso.

**O que acontece quando um manipulador de salvamento de imagem retorna `false`?**

Aspose.Slides usa seu comportamento padrão de salvamento local. A localização da imagem e a referência gerada são controladas por [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownsaveoptions/basepath/) e [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/pt/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

**Um manipulador pode fornecer uma URL sem salvar a imagem localmente?**

Sim. O manipulador pode fazer o upload da imagem para armazenamento de objetos ou enviá‑la a outro serviço, atribuir a URL resultante a `link` e retornar `true`. O manipulador deve concluir o processamento por conta própria; retornar `true` impede o salvamento local padrão.

**Por que a exportação para Markdown lança uma `InvalidOperationException` a partir de um manipulador?**

Essa exceção ocorre quando o manipulador retorna `true` mas não fornece um link válido. Atribua o caminho relativo ou a URL externa que deve ser gravada no Markdown antes de retornar `true`.

**Qual separador de caminho os links de imagem devem usar?**

Use barras (`/`) em links Markdown e URLs. Use `Path.Combine` apenas para caminhos do sistema de arquivos e, em seguida, construa ou normalize a referência Markdown separadamente.

**Os hiperlinks são preservados durante a exportação para Markdown?**

Sim. Hiperlinks de texto [hyperlinks](/slides/pt/net/manage-hyperlinks/) são preservados como links Markdown padrão. Transições de slide [transitions](/slides/pt/net/slide-transition/) e animações [animations](/slides/pt/net/powerpoint-animation/) não são convertidas.

**É possível converter apresentações para Markdown em paralelo?**

Você pode processar arquivos de apresentação diferentes em paralelo, mas não compartilhe a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) entre threads. Siga as [multithreading guidelines](/slides/pt/net/multithreading/) e use uma instância separada para cada arquivo.