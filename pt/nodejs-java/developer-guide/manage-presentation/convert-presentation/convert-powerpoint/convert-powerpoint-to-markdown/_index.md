---
title: Converter apresentações PowerPoint para Markdown em JavaScript
linktitle: PowerPoint para Markdown
type: docs
weight: 140
url: /pt/nodejs-java/convert-powerpoint-to-markdown/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converter apresentações PPT e PPTX para Markdown em JavaScript e controlar onde as imagens bitmap, metafile e SVG exportadas são salvas e referenciadas."
---
## **Visão geral**

Aspose.Slides for Node.js via Java pode converter apresentações PPT e PPTX para Markdown para documentação, sites estáticos, migração de conteúdo e fluxos de trabalho de controle de versão. Você pode escolher um sabor de Markdown, controlar como o conteúdo dos slides é renderizado e decidir onde as imagens exportadas são armazenadas e como o Markdown gerado as referencia.

Por padrão, a exportação de Markdown usa saída apenas de texto. Para exportar conteúdo visual, defina o tipo de exportação com o método [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownsaveoptions/) para o valor `Sequential` ou `Visual` da enumeração [MarkdownExportType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownexporttype/). `Sequential` renderiza os itens do slide separadamente e em ordem, enquanto `Visual` mantém os itens agrupados juntos para preservar sua relação visual. O valor `TextOnly` não gera recursos de imagem, portanto os callbacks de salvamento de imagem não são invocados nesse modo.

## **Converter uma apresentação para Markdown**

Carregue o arquivo de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e, em seguida, chame o método [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) com o valor `Md` da enumeração [SaveFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveformat/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Selecionar um sabor de Markdown**

O método [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownsaveoptions/) controla a especificação de Markdown usada na saída. A enumeração [Flavor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/flavor/) inclui CommonMark, GitHub Flavored Markdown e outras variantes suportadas.

O exemplo a seguir exporta uma apresentação como CommonMark:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Exportar imagens usando o comportamento padrão de salvamento local**

A classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownsaveoptions/) fornece dois métodos para configurar imagens salvas localmente:

- [setBasePath](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownsaveoptions/) especifica o diretório base para o documento Markdown e seus recursos.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownsaveoptions/) especifica o subdiretório de imagens. Seu valor padrão é `Images`.

O exemplo a seguir renderiza conteúdo visual, grava imagens em `output/assets` e cria referências de imagem relativas no documento Markdown:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Esse comportamento também serve como fallback quando um manipulador de salvamento de imagem personalizado retorna `false`.

## **Personalizar o salvamento de imagens e links Markdown**

Use o método [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownsaveoptions/) para registrar um callback para recursos bitmap e metafile que não são SVG emitidos durante a exportação de Markdown. Seu callback `MarkdownImageSavingHandler` recebe o objeto [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/), seu valor [ImageFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imageformat/) e o link Markdown gerado como um array de string com um elemento. Salve ou faça upload da imagem com o formato fornecido e substitua `link[0]` pela referência que deve aparecer na saída Markdown.

Recursos emitidos em formato SVG são tratados separadamente. Registre um callback com o método [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownsaveoptions/). Seu callback `MarkdownSvgImageSavingHandler` recebe um objeto `ISvgImage` e o array de um elemento `link`. Um SVG não possui argumento `ImageFormat`; escreva ou faça upload de seus dados XML a partir do método `ISvgImage.getSvgData`. Dependendo do modo de exportação e do agrupamento visual, um SVG na apresentação de origem pode ser rasterizado ou combinado com outro conteúdo; o recurso não‑SVG resultante é então passado ao callback de salvamento de imagem. Registre ambos os callbacks quando cada recurso visual exportado exigir processamento personalizado.

No Node.js, crie implementações dessas interfaces de callback com `java.newProxy`.

O valor de retorno do manipulador determina quem processa a imagem:

- Retorne `true` depois que o manipulador salvar, fizer upload, transformar ou de outra forma processar a imagem e atribuir um valor válido a `link[0]`. Aspose.Slides grava esse valor no documento Markdown e não executa o salvamento local padrão.
- Retorne `false` para que Aspose.Slides salve a imagem localmente e gere seu link de acordo com os valores definidos por [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownsaveoptions/) e [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Importante" %}}
Um manipulador que retorna `true` assume a responsabilidade pela imagem. Se ele retornar `true` sem atribuir um link válido e não vazio, a exportação falha com uma `InvalidOperationException`.
{{% /alert %}}

### **Salvar imagens em um diretório de origem CDN e usar URLs externas**

O exemplo a seguir trata `cdn-origin/presentations/quarterly-report` como um diretório de origem CDN montado ou sincronizado. Cada manipulador extrai o nome de arquivo gerado, salva a imagem nesse diretório personalizado e substitui a referência local gerada por uma URL CDN pública. O próprio exemplo não realiza upload de rede: a URL só se torna válida após o diretório ser montado como origem CDN ou seus arquivos serem publicados no CDN. Para armazenamento de objetos, substitua a gravação no sistema de arquivos pela operação de upload do SDK de armazenamento e atribua `link[0]` somente após o upload ser bem‑sucedido.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

O manipulador de bitmap retorna deliberadamente `false` para imagens menores que 128 × 128 pixels, de modo que Aspose.Slides salva essas imagens em `output/fallback-images` usando o comportamento padrão. Recursos bitmap e metafile maiores, bem como recursos SVG, são tratados pelo código personalizado. Por exemplo, uma referência local gerada como `fallback-images/image1.png` torna‑se `https://cdn.example.com/presentations/quarterly-report/image1.png`. Os manipuladores usam caminhos do sistema operacional apenas ao gravar arquivos; links escritos no Markdown usam barras (`/`) e nomes de arquivo escapados para URL. Aplique a mesma regra ao construir links relativos: use `/`, não o separador de diretório específico da plataforma.

## **FAQ**

**Um manipulador pode processar tanto imagens raster quanto imagens SVG?**

Não. Use [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownsaveoptions/) para recursos bitmap e metafile emitidos e [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownsaveoptions/) para recursos emitidos como SVG. O primeiro fornece um objeto [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/) e um valor [ImageFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imageformat/); o último fornece um objeto `ISvgImage` cujos dados SVG podem ser lidos com `ISvgImage.getSvgData`. Um SVG de origem que é rasterizado durante a exportação é processado pelo callback de salvamento de imagem.

**O que acontece quando um manipulador de salvamento de imagem retorna `false`?**

Aspose.Slides usa seu comportamento padrão de salvamento local. A localização da imagem e a referência gerada são controladas pelos valores definidos em [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownsaveoptions/) e [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/markdownsaveoptions/).

**Um manipulador pode fornecer uma URL sem salvar a imagem localmente?**

Sim. O manipulador pode fazer upload da imagem para armazenamento de objetos ou passá‑la para outro serviço, atribuir a URL resultante a `link[0]` e retornar `true`. O manipulador deve concluir o processamento por conta própria; retornar `true` impede o salvamento local padrão.

**Por que a exportação de Markdown lança uma `InvalidOperationException` a partir de um manipulador?**

Essa exceção ocorre quando o manipulador retorna `true` mas não fornece um link válido. Atribua o caminho relativo ou a URL externa que deve ser gravada no Markdown antes de retornar `true`.

**Qual separador de caminho os links de imagem devem usar?**

Use barras (`/`) em links Markdown e URLs. Use `path.join` apenas para caminhos do sistema de arquivos e, em seguida, construa ou normalize a referência Markdown separadamente.

**Os hiperlinks são preservados durante a exportação de Markdown?**

Sim. Hiperlinks de texto [hyperlinks](/slides/pt/nodejs-java/manage-hyperlinks/) são preservados como links Markdown padrão. Transições de slide [transitions](/slides/pt/nodejs-java/slide-transition/) e animações [animations](/slides/pt/nodejs-java/powerpoint-animation/) não são convertidas.

**As apresentações podem ser convertidas para Markdown em paralelo?**

Você pode processar diferentes arquivos de apresentação em paralelo, mas não compartilhe a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) entre threads. Siga as [multithreading guidelines](/slides/pt/nodejs-java/multithreading/) e use uma instância separada para cada arquivo.