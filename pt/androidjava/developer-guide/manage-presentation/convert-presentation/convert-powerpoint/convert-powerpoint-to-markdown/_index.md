---
title: "Converter apresentações PowerPoint para Markdown no Android"
linktitle: "PowerPoint para Markdown"
type: docs
weight: 140
url: /pt/androidjava/convert-powerpoint-to-markdown/
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
- Android
- Java
- Aspose.Slides
description: "Converter apresentações PPT e PPTX para Markdown no Android via Java e controlar onde as imagens exportadas (bitmap, metafile e SVG) são salvas e referenciadas."
---
## **Visão geral**

Aspose.Slides for Android via Java pode converter apresentações PPT e PPTX para Markdown para documentação, sites estáticos, migração de conteúdo e fluxos de trabalho de controle de versão. Você pode escolher um sabor de Markdown, controlar como o conteúdo dos slides é renderizado e decidir onde as imagens exportadas são armazenadas e como o Markdown gerado as referencia.

Por padrão, a exportação para Markdown usa saída apenas de texto. Para exportar conteúdo visual, defina o tipo de exportação com o método [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/markdownsaveoptions/) para o valor `Sequential` ou `Visual` da enumeração [MarkdownExportType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/markdownexporttype/). `Sequential` renderiza os itens do slide separadamente e em ordem, enquanto `Visual` mantém os itens agrupados juntos para preservar seu relacionamento visual. O valor `TextOnly` não gera recursos de imagem, portanto os callbacks de salvamento de imagem não são invocados nesse modo.

## **Converter uma Apresentação para Markdown**

Carregue o arquivo de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e então chame o método [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) com o valor `Md` da enumeração [SaveFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveformat/).

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Selecionar um Sabor de Markdown**

O método [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/markdownsaveoptions/) controla a especificação de Markdown usada para a saída. A enumeração [Flavor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/flavor/) inclui CommonMark, GitHub Flavored Markdown e outras variantes suportadas.

O exemplo a seguir exporta uma apresentação como CommonMark:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Exportar Imagens Usando o Comportamento Padrão de Salvamento Local**

A classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/markdownsaveoptions/) fornece dois métodos para configurar imagens salvas localmente:

- [setBasePath](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/markdownsaveoptions/) especifica o diretório base para o documento Markdown e seus recursos.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/markdownsaveoptions/) especifica o subdiretório de imagens. Seu valor padrão é `Images`.

O exemplo a seguir renderiza conteúdo visual, grava imagens em `output/assets` e cria referências de imagem relativas no documento Markdown:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Esse comportamento também serve como fallback quando um manipulador de salvamento de imagem personalizado retorna `false`.

## **Personalizar o Salvamento de Imagens e Links Markdown**

Use o método [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/markdownsaveoptions/) para registrar um callback para recursos bitmap e metafile que não sejam SVG emitidos durante a exportação para Markdown. Seu callback `MarkdownImageSavingHandler` recebe o objeto [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/), seu valor [ImageFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imageformat/) e o link Markdown gerado como um parâmetro `String[]` de um elemento. Salve ou faça upload da imagem com o formato fornecido e substitua `link[0]` pela referência que deve aparecer na saída Markdown.

Recursos emitidos em formato SVG são tratados separadamente. Registre um callback com o método [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/markdownsaveoptions/). Seu callback `MarkdownSvgImageSavingHandler` recebe um objeto [ISvgImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgimage/) e o parâmetro `String[] link` de um elemento. Um SVG não possui argumento `ImageFormat`; escreva ou faça upload de seus dados XML usando o método [ISvgImage.getSvgData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgimage/) em vez disso. Dependendo do modo de exportação e do agrupamento visual, um SVG na apresentação de origem pode ser rasterizado ou combinado com outro conteúdo; o recurso não‑SVG resultante é então passado ao callback de salvamento de imagem. Registre ambos os callbacks quando cada recurso visual exportado exigir processamento customizado.

O valor de retorno do manipulador determina quem processa a imagem:

- Retorne `true` depois que o manipulador tiver salvo, feito upload, transformado ou processado a imagem de outra forma e atribuído um valor válido a `link[0]`. Aspose.Slides grava esse valor no documento Markdown e não realiza o salvamento local padrão.
- Retorne `false` para que Aspose.Slides salve a imagem localmente e gere seu link de acordo com os valores definidos por [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/markdownsaveoptions/) e [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Importante" %}}

Um manipulador que retorna `true` assume a responsabilidade pela imagem. Se ele retornar `true` sem atribuir um link válido e não vazio, a exportação falhará com uma `InvalidOperationException`.

{{% /alert %}}

### **Salvar Imagens em um Diretório de Origem CDN e Usar URLs Externas**

O exemplo a seguir trata `cdn-origin/presentations/quarterly-report` como um diretório de origem CDN montado ou sincronizado. Cada manipulador extrai o nome de arquivo gerado, salva a imagem nesse diretório customizado e substitui a referência local gerada por uma URL pública do CDN. O exemplo em si não realiza upload de rede: a URL só se torna válida após o diretório ser montado como origem CDN ou seus arquivos serem publicados no CDN. Para armazenamento de objetos, substitua a gravação no sistema de arquivos pela operação de upload do SDK de armazenamento e atribua `link[0]` somente após o upload ser bem‑sucedido.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

O manipulador de bitmap retorna deliberadamente `false` para imagens menores que 128 × 128 pixels, de modo que Aspose.Slides salva essas imagens em `output/fallback-images` usando o comportamento padrão. Recursos bitmap e metafile maiores, bem como recursos SVG, são tratados pelo código customizado. Por exemplo, uma referência local gerada como `fallback-images/image1.png` torna‑se `https://cdn.example.com/presentations/quarterly-report/image1.png`. Os manipuladores utilizam caminhos do sistema operacional apenas ao gravar arquivos; os links gravados no Markdown usam barras normais e nomes de arquivo escapados para URL. Aplique a mesma regra ao construir links relativos: use `/`, não o separador de diretório específico da plataforma.

## **Perguntas Frequentes**

**Um manipulador pode processar tanto imagens raster quanto imagens SVG?**

Não. Use [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/markdownsaveoptions/) para recursos bitmap e metafile emitidos e [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/markdownsaveoptions/) para recursos emitidos como SVG. O primeiro fornece um objeto [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/) e um valor [ImageFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imageformat/); o segundo fornece um objeto [ISvgImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgimage/) cujo dado SVG pode ser lido com [ISvgImage.getSvgData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgimage/). Um SVG de origem que é rasterizado durante a exportação é processado pelo callback de salvamento de imagem em vez disso.

**O que acontece quando um manipulador de salvamento de imagem retorna `false`?**

Aspose.Slides usa seu comportamento padrão de salvamento local. O local da imagem e a referência gerada são controlados pelos valores definidos em [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/markdownsaveoptions/) e [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/markdownsaveoptions/).

**Um manipulador pode fornecer uma URL sem salvar a imagem localmente?**

Sim. O manipulador pode fazer upload da imagem para armazenamento de objetos ou enviá‑la a outro serviço, atribuir a URL resultante a `link[0]` e retornar `true`. O manipulador deve concluir o processamento por conta própria; retornar `true` impede o salvamento local padrão.

**Por que a exportação para Markdown lança uma `InvalidOperationException` a partir de um manipulador?**

Essa exceção ocorre quando o manipulador retorna `true` mas não fornece um link válido. Atribua o caminho relativo ou a URL externa que deve ser gravada no Markdown antes de retornar `true`.

**Qual separador de caminho os links de imagem devem usar?**

Use barras normais (`/`) em links Markdown e URLs. Use `Path.resolve` apenas para caminhos do sistema de arquivos e, em seguida, construa ou normalize a referência Markdown separadamente.

**Os hyperlinks são preservados durante a exportação para Markdown?**

Sim. Hyperlinks de texto [hyperlinks](/slides/pt/androidjava/manage-hyperlinks/) são preservados como links Markdown padrão. Transições de slide [transitions](/slides/pt/androidjava/slide-transition/) e animações [animations](/slides/pt/androidjava/powerpoint-animation/) não são convertidas.

**As apresentações podem ser convertidas para Markdown em paralelo?**

Você pode processar arquivos de apresentação diferentes em paralelo, mas não compartilhe a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) entre threads. Siga as [multithreading guidelines](/slides/pt/androidjava/multithreading/) e use uma instância separada para cada arquivo.