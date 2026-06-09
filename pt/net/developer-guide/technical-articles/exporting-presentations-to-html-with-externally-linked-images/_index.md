---
title: Exportar apresentações para HTML com imagens vinculadas externamente
type: docs
weight: 100
url: /pt/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar apresentação
- exportar slide
- exportar PPT
- exportar PPTX
- exportar ODP
- PowerPoint para HTML
- OpenDocument para HTML
- apresentação para HTML
- slide para HTML
- PPT para HTML
- PPTX para HTML
- ODP para HTML
- imagem vinculada
- imagem vinculada externamente
- recurso vinculado
- recurso externo
- .NET
- C#
- Aspose.Slides
description: "Exportar apresentações PowerPoint e OpenDocument para HTML em .NET usando Aspose.Slides com imagens e outros recursos salvos como arquivos vinculados externamente."
---
## **Visão geral**

Por padrão, o Aspose.Slides exporta uma apresentação para um arquivo HTML autônomo. Imagens e outros recursos são escritos diretamente no HTML, geralmente como dados Base64. Isso é conveniente quando você precisa de um único arquivo portátil, mas nem sempre é o melhor formato para um site, um CMS ou um pipeline de conversão do lado do servidor.

Use recursos vinculados externamente quando quiser:

- reduzir o tamanho do documento HTML;
- armazenar em cache imagens, fontes, áudio ou vídeo separadamente em um navegador ou CDN;
- inspecionar, substituir, compactar ou pós‑processar recursos gerados após a exportação;
- manter a estrutura de saída mais próxima do que uma aplicação web espera.

Para o fluxo de trabalho geral de conversão para HTML, veja [Converter apresentações do PowerPoint para HTML](/slides/pt/net/convert-powerpoint-to-html/). Este artigo foca na parte de vinculação de recursos da exportação.

## **Como funciona a exportação com recursos vinculados**

[ILinkEmbedController](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ilinkembedcontroller/) permite que sua aplicação decida, recurso por recurso, se o exportador incorpora os dados no HTML ou os salva externamente e grava um link.

A interface possui três métodos:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) decide se um recurso deve ser vinculado ou incorporado.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ilinkembedcontroller/geturl/) retorna a URL que será escrita no HTML gerado ou em outro recurso vinculado.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) grava os dados do recurso vinculado no disco ou em outro destino de armazenamento.

O caminho do sistema de arquivos e a URL do navegador são preocupações distintas. Por exemplo, o exemplo abaixo grava arquivos de recurso em `html-output/assets` no disco, enquanto o HTML contém URLs relativas como `assets/resource-1.svg`. Um navegador resolve essas URLs em relação ao arquivo que contém o link. Portanto, um link de `presentation.html` para um arquivo SVG usa `assets/resource-1.svg`, enquanto um link desse arquivo SVG para uma imagem salva na mesma pasta `assets` usa `resource-4.jpg`.

## **Exportar HTML com recursos vinculados**

O exemplo C# a seguir cria um diretório de saída, salva o arquivo HTML nele e armazena os recursos vinculados em um subdiretório `assets`. O controlador vincula recursos comuns de imagem, fonte, áudio, vídeo e CSS quando o Aspose.Slides fornece ou pode inferir uma extensão de arquivo segura. Recursos que não são reconhecidos permanecem incorporados.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Collections.Generic;
using System.IO;

var inputFilePath = "presentation.pptx";
var outputDirectory = "html-output";
var assetDirectoryName = "assets";
var assetDirectory = Path.Combine(outputDirectory, assetDirectoryName);

Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(assetDirectory);

var assetUrlPrefix = assetDirectoryName + "/";
var controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(string.Empty, false),
    SlideImageFormat = slideImageFormat
};

using var presentation = new Presentation(inputFilePath);

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);

public sealed class ExternalResourceController : ILinkEmbedController
{
    private static readonly Dictionary<string, string> ExtensionsByContentType = new(StringComparer.OrdinalIgnoreCase)
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/gif"] = ".gif",
        ["image/bmp"] = ".bmp",
        ["image/svg+xml"] = ".svg",
        ["image/tiff"] = ".tiff",
        ["image/x-emf"] = ".emf",
        ["image/x-wmf"] = ".wmf",
        ["font/woff"] = ".woff",
        ["font/woff2"] = ".woff2",
        ["font/ttf"] = ".ttf",
        ["application/font-woff"] = ".woff",
        ["application/vnd.ms-fontobject"] = ".eot",
        ["application/x-font-ttf"] = ".ttf",
        ["text/css"] = ".css",
        ["audio/mpeg"] = ".mp3",
        ["audio/mp4"] = ".m4a",
        ["audio/wav"] = ".wav",
        ["video/mp4"] = ".mp4",
        ["video/webm"] = ".webm"
    };

    private readonly string assetDirectory;
    private readonly string assetUrlPrefix;
    private readonly Dictionary<int, string> fileNamesByResourceId = new();

    public ExternalResourceController(string assetDirectory, string assetUrlPrefix)
    {
        if (string.IsNullOrWhiteSpace(assetDirectory))
        {
            throw new ArgumentException("The asset output directory must not be empty.", nameof(assetDirectory));
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
    }

    public LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        byte[] entityData,
        string semanticName,
        string contentType,
        string recommendedExtension)
    {
        var extension = ResolveExtension(contentType, recommendedExtension);
        if (extension == null)
        {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId[resourceId] = $"resource-{resourceId}{extension}";
        return LinkEmbedDecision.Link;
    }

    public string GetUrl(int resourceId, int referrer)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            return null;
        }

        if (fileNamesByResourceId.ContainsKey(referrer))
        {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    public void SaveExternal(int resourceId, byte[] entityData)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} was not registered for external storage.");
        }

        if (entityData == null || entityData.Length == 0)
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} contains no data and cannot be saved.");
        }

        Directory.CreateDirectory(assetDirectory);

        var filePath = Path.Combine(assetDirectory, fileName);
        File.WriteAllBytes(filePath, entityData);
    }

    private static string ResolveExtension(string contentType, string recommendedExtension)
    {
        if (!string.IsNullOrWhiteSpace(contentType) &&
            ExtensionsByContentType.TryGetValue(contentType, out var mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(contentType))
        {
            return null;
        }

        return NormalizeExtension(recommendedExtension);
    }

    private static bool IsSupportedContentType(string contentType)
    {
        return contentType != null &&
            (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("font/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase));
    }

    private static string NormalizeExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return null;
        }

        var extensionCharacters = extension.Trim().TrimStart('.');
        foreach (var character in extensionCharacters)
        {
            if (!char.IsLetterOrDigit(character))
            {
                return null;
            }
        }

        return "." + extensionCharacters.ToLowerInvariant();
    }

    private static string NormalizeUrlPrefix(string urlPrefix)
    {
        if (string.IsNullOrEmpty(urlPrefix))
        {
            return string.Empty;
        }

        var normalizedUrlPrefix = urlPrefix.Replace('\\', '/');
        return normalizedUrlPrefix.EndsWith("/")
            ? normalizedUrlPrefix
            : normalizedUrlPrefix + "/";
    }
}
```

Após a exportação, a pasta de saída tem esta estrutura:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Os arquivos exatos dependem do conteúdo da apresentação e das opções de exportação. Por exemplo, imagens raster são normalmente exportadas como JPEG ou PNG. O Aspose.Slides pode escolher um codec de imagem diferente do usado na apresentação original quando isso produz um arquivo menor ou mais adequado. Imagens com transparência são exportadas como PNG.

## **Escolhendo URLs para implantação**

O exemplo usa um prefixo de URL relativo: `assets/`. Se `presentation.html` for aberto a partir de `html-output/presentation.html`, o navegador carregará `html-output/assets/resource-1.svg`.

Quando um recurso vinculado faz referência a outro recurso vinculado, o exemplo usa o parâmetro `referrer` em [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ilinkembedcontroller/geturl/) e devolve apenas o nome do arquivo. Por exemplo, se `resource-1.svg` e `resource-4.jpg` estiverem ambos na pasta `assets`, o arquivo SVG deve referir‑se a `resource-4.jpg`, não a `assets/resource-4.jpg`.

Use um prefixo de URL diferente quando os arquivos forem implantados em outro local:

- Use `assets/` quando o diretório de ativos estiver ao lado do arquivo HTML.
- Use `../assets/` quando o diretório de ativos estiver um nível acima do arquivo HTML.
- Use `https://cdn.example.com/presentations/job-123/assets/` quando os arquivos forem enviados para um CDN ou servidor de arquivos estáticos.

A URL retornada por [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ilinkembedcontroller/geturl/) deve corresponder ao local final de implantação do arquivo escrito por [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ilinkembedcontroller/saveexternal/). Em aplicativos de servidor, use um diretório de saída exclusivo ou um prefixo de armazenamento de objetos para cada trabalho de conversão, a fim de evitar sobrescrever arquivos de outra exportação.

## **Quando incorporar em vez de vincular**

HTML incorporado em Base64 ainda é útil quando a saída deve ser um único arquivo, como um anexo de e‑mail, uma pré‑visualização offline ou um documento que será movido sem uma pasta de ativos de suporte. Recursos vinculados são mais adequados quando o HTML será servido por uma aplicação web, armazenado em um CMS, otimizado por um pipeline de build ou armazenado em cache por navegadores de forma independente do HTML.

## **FAQ**

**Posso externalizar apenas imagens e manter os outros recursos incorporados?**

Sim. Em [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/), retorne `LinkEmbedDecision.Link` somente para os tipos de conteúdo que você deseja salvar como arquivos separados, e retorne `LinkEmbedDecision.Embed` para todo o resto.

**Por que a extensão da imagem exportada difere da apresentação original?**

O Aspose.Slides pode re‑codificar imagens raster durante a exportação para HTML a fim de melhorar o tamanho ou a compatibilidade com navegadores. Por exemplo, uma imagem do arquivo original pode ser gravada como JPEG ou PNG dependendo do resultado renderizado.

**URLs relativas funcionam depois que eu movo o arquivo HTML?**

URLs relativas funcionam apenas quando a mesma estrutura de pastas relativa é preservada. Se o HTML referencia `assets/resource-1.png`, a pasta `assets` deve permanecer ao lado do arquivo HTML, a menos que você gere um prefixo de URL diferente.

**Aplicações de servidor devem reutilizar a mesma pasta de saída?**

Não. Use um diretório de saída exclusivo ou um prefixo de armazenamento para cada trabalho de conversão. Isso evita colisões de nomes de arquivos e impede que uma exportação sobrescreva recursos gerados por outra exportação.