---
title: Exportar apresentações para HTML com imagens vinculadas externamente
type: docs
weight: 100
url: /pt/php-java/exporting-presentations-to-html-with-externally-linked-images/
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
- PHP
- Aspose.Slides
description: "Exportar apresentações PowerPoint e OpenDocument para HTML em PHP via Java usando Aspose.Slides, com imagens e outros recursos salvos como arquivos vinculados externamente."
---
## **Visão geral**

Por padrão, o Aspose.Slides exporta uma apresentação para um arquivo HTML autônomo. Imagens e outros recursos são gravados diretamente no HTML, geralmente como dados Base64. Isso é conveniente quando você precisa de um único arquivo portátil, mas nem sempre é o melhor formato para um site, um CMS ou um pipeline de conversão do lado do servidor.

Use recursos vinculados externamente quando você deseja:

- reduzir o tamanho do documento HTML;
- armazenar em cache imagens, fontes, áudio ou vídeo separadamente em um navegador ou CDN;
- inspecionar, substituir, comprimir ou pós-processar recursos gerados após a exportação;
- manter a estrutura de saída mais próxima do que uma aplicação web espera.

Para o fluxo de trabalho geral de conversão HTML, veja [Convert PowerPoint Presentations to HTML](/slides/pt/php-java/convert-powerpoint-to-html/). Este artigo se concentra na parte de vinculação de recursos da exportação.

## **Como funciona a exportação com recursos vinculados**

[HtmlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmloptions/) pode usar um controlador customizado de link/incorporação quando o Aspose.Slides exporta uma apresentação para HTML. Em PHP via Java, esse cenário geralmente é implementado com uma pequena classe auxiliar Java. Compile essa classe auxiliar, adicione‑a ao classpath da PHP Java Bridge e instancie‑a a partir do PHP com `new Java(...)`.

A classe auxiliar decide, recurso por recurso, se o exportador incorpora os dados no HTML ou os salva externamente e grava um link. Ela precisa de três métodos de retorno de chamada:

- `ExternalResourceController.getObjectStoringLocation` decide se um recurso deve ser vinculado ou incorporado.
- `ExternalResourceController.getUrl` retorna a URL que será escrita no HTML gerado ou em outro recurso vinculado.
- `ExternalResourceController.saveExternal` grava os dados do recurso vinculado no disco ou em outro destino de armazenamento.

O caminho do sistema de arquivos e a URL do navegador são preocupações distintas. Por exemplo, o exemplo abaixo grava arquivos de recursos em `html-output/assets` no disco, enquanto o HTML contém URLs relativas como `assets/resource-1.svg`. Um navegador resolve essas URLs em relação ao arquivo que contém o link. Portanto, um link de `presentation.html` para um arquivo SVG usa `assets/resource-1.svg`, enquanto um link desse arquivo SVG para uma imagem salva na mesma pasta `assets` usa `resource-4.jpg`.

## **Criar a classe auxiliar Java**

Crie uma classe Java como `com.example.slides.ExternalResourceController`, compile‑a com o Aspose.Slides para Java no classpath e torne a classe compilada ou o JAR disponível para a PHP Java Bridge.

O auxiliar abaixo vincula recursos comuns de imagem, fonte, áudio, vídeo e CSS quando o Aspose.Slides fornece ou pode inferir uma extensão de arquivo segura. Recursos que não são reconhecidos permanecem incorporados.

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
    }

    @Override
    public int getObjectStoringLocation(
            int resourceId,
            byte[] entityData,
            String semanticName,
            String contentType,
            String recommendedExtension) {
        String extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
        return LinkEmbedDecision.Link;
    }

    @Override
    public String getUrl(int resourceId, int referrer) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (fileNamesByResourceId.containsKey(referrer)) {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    @Override
    public void saveExternal(int resourceId, byte[] entityData) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length == 0) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " contains no data and cannot be saved.");
        }

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
    }

    private static String resolveExtension(String contentType, String recommendedExtension) {
        if (contentType != null && !contentType.trim().isEmpty()) {
            String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
            if (mappedExtension != null) {
                return mappedExtension;
            }
        }

        if (!isSupportedContentType(contentType)) {
            return null;
        }

        return normalizeExtension(recommendedExtension);
    }

    private static boolean isSupportedContentType(String contentType) {
        return contentType != null &&
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
                return null;
            }
        }

        return "." + extensionCharacters.toLowerCase(Locale.ROOT);
    }

    private static String normalizeUrlPrefix(String urlPrefix) {
        if (urlPrefix == null || urlPrefix.isEmpty()) {
            return "";
        }

        String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
        return normalizedUrlPrefix.endsWith("/")
                ? normalizedUrlPrefix
                : normalizedUrlPrefix + "/";
    }
}
```

## **Exportar HTML com recursos vinculados**

O código PHP a seguir cria um diretório de saída, salva o arquivo HTML nele e armazena os recursos vinculados em um subdiretório `assets`. Ele combina [HtmlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideimageformat/) e [SaveFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveformat/) para a exportação.

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
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

Quando um recurso vinculado refere‑se a outro recurso vinculado, o exemplo usa o parâmetro `referrer` em `ExternalResourceController.getUrl` e retorna apenas o nome do arquivo. Por exemplo, se `resource-1.svg` e `resource-4.jpg` estiverem ambos na pasta `assets`, o arquivo SVG deve referir‑se a `resource-4.jpg`, não a `assets/resource-4.jpg`.

Use um prefixo de URL diferente quando os arquivos forem implantados em outro local:

- Use `assets/` quando o diretório de ativos estiver ao lado do arquivo HTML.
- Use `../assets/` quando o diretório de ativos estiver um nível acima do arquivo HTML.
- Use `https://cdn.example.com/presentations/job-123/assets/` quando os arquivos forem enviados para um CDN ou servidor de arquivos estáticos.

A URL retornada por `ExternalResourceController.getUrl` deve corresponder ao local final de implantação do arquivo gravado por `ExternalResourceController.saveExternal`. Em aplicações de servidor, use um diretório de saída exclusivo ou um prefixo de armazenamento de objetos para cada tarefa de conversão, a fim de evitar sobrescrever arquivos de outra exportação.

## **Quando incorporar em vez disso**

O HTML incorporado em Base64 ainda é útil quando a saída deve ser um único arquivo, como um anexo de e‑mail, uma pré‑visualização offline ou um documento que será movido sem uma pasta de ativos de suporte. Recursos vinculados são mais adequados quando o HTML será servido por uma aplicação web, armazenado em um CMS, otimizado por um pipeline de construção ou armazenado em cache pelos navegadores de forma independente do HTML.

## **FAQ**

**Posso externalizar apenas imagens e manter outros recursos incorporados?**

Sim. Em `ExternalResourceController.getObjectStoringLocation`, retorne o valor `Link` de [LinkEmbedDecision](https://reference.aspose.com/slides/pt/php-java/aspose.slides/linkembeddecision/) apenas para os tipos de conteúdo que você deseja salvar como arquivos separados, e retorne o valor `Embed` para todo o resto.

**Por que a extensão da imagem exportada difere da apresentação original?**

O Aspose.Slides pode re‑codificar imagens raster durante a exportação para HTML para melhorar o tamanho ou a compatibilidade com navegadores. Por exemplo, uma imagem do arquivo original pode ser gravada como JPEG ou PNG dependendo do resultado renderizado.

**URLs relativas funcionam depois que eu movo o arquivo HTML?**

URLs relativas funcionam apenas quando a mesma estrutura de pastas relativa é preservada. Se o HTML referenciar `assets/resource-1.png`, a pasta `assets` deve permanecer ao lado do arquivo HTML, a menos que você gere um prefixo de URL diferente.

**Aplicações de servidor devem reutilizar a mesma pasta de saída?**

Não. Use um diretório de saída exclusivo ou um prefixo de armazenamento para cada tarefa de conversão. Isso evita colisões de nomes de arquivos e impede que uma exportação sobrescreva recursos gerados por outra exportação.