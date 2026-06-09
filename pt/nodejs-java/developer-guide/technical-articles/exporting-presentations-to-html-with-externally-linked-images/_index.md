---
title: Exportar apresentações para HTML com imagens vinculadas externamente
type: docs
weight: 100
url: /pt/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
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
- JavaScript
- Node.js
- Aspose.Slides
description: "Exportar apresentações PowerPoint e OpenDocument para HTML em JavaScript usando Aspose.Slides para Node.js via Java com imagens e outros recursos salvos como arquivos vinculados externamente."
---
## **Visão geral**

Por padrão, o Aspose.Slides exporta uma apresentação para um arquivo HTML autônomo. Imagens e outros recursos são gravados diretamente no HTML, normalmente como dados Base64. Isso é conveniente quando você precisa de um único arquivo portátil, mas nem sempre é o melhor formato para um site, um CMS ou um pipeline de conversão do lado do servidor.

Use recursos vinculados externamente quando você quiser:

- reduzir o tamanho do documento HTML;
- armazenar em cache imagens, fontes, áudio ou vídeo separadamente em um navegador ou CDN;
- inspecionar, substituir, compactar ou pós-processar recursos gerados após a exportação;
- manter a estrutura de saída mais próxima do que uma aplicação web espera.

Para o fluxo de trabalho geral de conversão HTML, veja [Converter apresentações PowerPoint para HTML](/slides/pt/nodejs-java/convert-powerpoint-to-html/). Este artigo foca na parte de vinculação de recursos da exportação.

## **Como funciona a exportação com recursos vinculados**

Um proxy Java para [ILinkEmbedController](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilinkembedcontroller/) permite que sua aplicação decida, recurso por recurso, se o exportador incorpora os dados no HTML ou os salva externamente e grava um link.

O controlador possui três métodos:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilinkembedcontroller/) decide se um recurso deve ser vinculado ou incorporado.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilinkembedcontroller/) retorna a URL que será escrita no HTML gerado ou em outro recurso vinculado.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilinkembedcontroller/) grava os dados do recurso vinculado no disco ou em outro destino de armazenamento.

O caminho do sistema de arquivos e a URL do navegador são preocupações separadas. Por exemplo, o exemplo abaixo grava arquivos de recursos em `html-output/assets` no disco, enquanto o HTML contém URLs relativas como `assets/resource-1.svg`. Um navegador resolve essas URLs em relação ao arquivo que contém o link. Portanto, um link de `presentation.html` para um arquivo SVG usa `assets/resource-1.svg`, enquanto um link desse arquivo SVG para uma imagem salva na mesma pasta `assets` usa `resource-4.jpg`.

## **Exportar HTML com recursos vinculados**

O exemplo JavaScript a seguir cria um diretório de saída, salva o arquivo HTML nele e armazena os recursos vinculados em um subdiretório `assets`. O controlador vincula recursos comuns de imagem, fonte, áudio, vídeo e CSS quando o Aspose.Slides fornece ou pode inferir uma extensão de arquivo segura. Recursos que não são reconhecidos permanecem incorporados.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
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

Os arquivos exatos dependem do conteúdo da apresentação e das opções de exportação. Por exemplo, imagens raster são tipicamente exportadas como JPEG ou PNG. O Aspose.Slides pode escolher um codec de imagem diferente do usado na apresentação original quando isso produz um arquivo menor ou mais adequado. Imagens com transparência são exportadas como PNG.

## **Escolhendo URLs para implantação**

O exemplo usa um prefixo de URL relativo: `assets/`. Se `presentation.html` for aberto a partir de `html-output/presentation.html`, o navegador carregará `html-output/assets/resource-1.svg`.

Quando um recurso vinculado faz referência a outro recurso vinculado, o exemplo usa o parâmetro `referrer` em [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilinkembedcontroller/) e retorna apenas o nome do arquivo. Por exemplo, se `resource-1.svg` e `resource-4.jpg` estiverem ambos na pasta `assets`, o arquivo SVG deve referir‑se a `resource-4.jpg`, e não a `assets/resource-4.jpg`.

Use um prefixo de URL diferente quando os arquivos forem implantados em outro local:

- Use `assets/` quando o diretório de ativos está ao lado do arquivo HTML.
- Use `../assets/` quando o diretório de ativos está um nível acima do arquivo HTML.
- Use `https://cdn.example.com/presentations/job-123/assets/` quando os arquivos são enviados para um CDN ou servidor de arquivos estático.

A URL retornada por [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilinkembedcontroller/) deve corresponder ao local final de implantação do arquivo gravado por [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilinkembedcontroller/). Em aplicações de servidor, use um diretório de saída exclusivo ou um prefixo de armazenamento de objetos para cada tarefa de conversão, a fim de evitar sobrescrever arquivos de outra exportação.

## **Quando incorporar em vez de vincular**

HTML com Base64 incorporado ainda é útil quando a saída deve ser um único arquivo, como um anexo de e‑mail, uma pré‑visualização offline ou um documento que será movido sem uma pasta de ativos de suporte. Recursos vinculados são mais adequados quando o HTML será servido por uma aplicação web, armazenado em um CMS, otimizado por um pipeline de build ou armazenado em cache pelos navegadores de forma independente do HTML.

## **FAQ**

**Posso externalizar apenas imagens e manter os outros recursos incorporados?**

Sim. Em [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilinkembedcontroller/), retorne `LinkEmbedDecision.Link` apenas para os tipos de conteúdo que você deseja salvar como arquivos separados, e retorne `LinkEmbedDecision.Embed` para o restante.

**Por que a extensão da imagem exportada difere da apresentação original?**

O Aspose.Slides pode re‑codificar imagens raster durante a exportação HTML para melhorar o tamanho ou a compatibilidade com navegadores. Por exemplo, uma imagem do arquivo original pode ser gravada como JPEG ou PNG dependendo do resultado renderizado.

**URLs relativas funcionam após eu mover o arquivo HTML?**

URLs relativas funcionam apenas quando a mesma estrutura de pastas relativa é preservada. Se o HTML fizer referência a `assets/resource-1.png`, a pasta `assets` deve permanecer ao lado do arquivo HTML, a menos que você gere um prefixo de URL diferente.

**Aplicações de servidor devem reutilizar a mesma pasta de saída?**

Não. Use um diretório de saída único ou um prefixo de armazenamento para cada tarefa de conversão. Isso evita colisões de nomes de arquivos e impede que uma exportação sobrescreva recursos gerados por outra exportação.