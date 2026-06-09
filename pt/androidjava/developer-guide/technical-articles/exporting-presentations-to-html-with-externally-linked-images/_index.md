---
title: Exportar apresentações para HTML com imagens vinculadas externamente
type: docs
weight: 100
url: /pt/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- Android
- Java
- Aspose.Slides
description: "Exportar apresentações PowerPoint e OpenDocument para HTML no Android via Java usando Aspose.Slides com imagens e outros recursos salvos como arquivos vinculados externamente."
---
## **Visão geral**

Por padrão, o Aspose.Slides exporta uma apresentação para um arquivo HTML autônomo. Imagens e outros recursos são gravados diretamente no HTML, geralmente como dados Base64. Isso é conveniente quando você precisa de um único arquivo portátil, mas nem sempre é o melhor formato para visualização na web, um CMS ou um pipeline de conversão no lado do servidor que publica a saída posteriormente.

Use recursos vinculados externamente quando você quiser:

- reduzir o tamanho do documento HTML;
- armazenar em cache imagens, fontes, áudio ou vídeo separadamente em um navegador ou CDN;
- inspecionar, substituir, compactar ou pós‑processar recursos gerados após a exportação;
- manter a estrutura de saída mais próxima do que uma aplicação web espera.

Para o fluxo de trabalho geral de conversão HTML, veja [Convert PowerPoint Presentations to HTML](/slides/pt/androidjava/convert-powerpoint-to-html/). Este artigo foca na parte de vinculação de recursos da exportação.

## **Como funciona a exportação com recursos vinculados**

[ILinkEmbedController](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilinkembedcontroller/) permite que sua aplicação decida, recurso por recurso, se o exportador incorpora os dados no HTML ou os salva externamente e grava um link.

A interface possui três métodos:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilinkembedcontroller/) decide se um recurso deve ser vinculado ou incorporado.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilinkembedcontroller/) retorna a URL que será escrita no HTML gerado ou em outro recurso vinculado.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilinkembedcontroller/) grava os dados do recurso vinculado no disco ou em outro destino de armazenamento.

O caminho no sistema de arquivos e a URL do navegador são preocupações separadas. Por exemplo, o exemplo abaixo grava arquivos de recursos em `html-output/assets` no armazenamento de arquivos da aplicação, enquanto o HTML contém URLs relativas como `assets/resource-1.svg`. Um navegador resolve essas URLs em relação ao arquivo que contém o link. Portanto, um link de `presentation.html` para um arquivo SVG usa `assets/resource-1.svg`, enquanto um link desse arquivo SVG para uma imagem salva na mesma pasta `assets` usa `resource-4.jpg`.

## **Exportar HTML com recursos vinculados**

O exemplo Android Java a seguir cria um diretório de saída, salva o arquivo HTML nele e armazena os recursos vinculados em um subdiretório `assets`. Passe um diretório de propriedade da aplicação, como `context.getFilesDir()`, como `applicationFilesDirectory`. O código evita APIs `java.nio.file`, portanto permanece compatível com Android `minSdk` 19.

O controlador vincula recursos comuns de imagem, fonte, áudio, vídeo e CSS quando o Aspose.Slides fornece ou pode inferir uma extensão de arquivo segura. Recursos que não são reconhecidos permanecem incorporados.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
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

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
        }

        private static String resolveExtension(String contentType, String recommendedExtension) {
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
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
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile.getAbsolutePath(),
                    exception);
        }
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

Os arquivos exatos dependem do conteúdo da apresentação e das opções de exportação. Por exemplo, imagens raster são geralmente exportadas como JPEG ou PNG. O Aspose.Slides pode escolher um codec de imagem diferente daquele usado na apresentação de origem quando isso produz um arquivo menor ou mais adequado. Imagens com transparência são exportadas como PNG.

## **Escolhendo URLs para implantação**

O exemplo usa um prefixo de URL relativo: `assets/`. Se `presentation.html` for aberto a partir de `html-output/presentation.html`, o navegador carregará `html-output/assets/resource-1.svg`.

Quando um recurso vinculado se refere a outro recurso vinculado, o exemplo usa o parâmetro `referrer` em [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilinkembedcontroller/) e retorna apenas o nome do arquivo. Por exemplo, se `resource-1.svg` e `resource-4.jpg` estiverem ambos na pasta `assets`, o arquivo SVG deve referir‑se a `resource-4.jpg`, não a `assets/resource-4.jpg`.

Use um prefixo de URL diferente quando os arquivos forem implantados em outro local:

- Use `assets/` quando o diretório de ativos estiver ao lado do arquivo HTML.
- Use `../assets/` quando o diretório de ativos estiver um nível acima do arquivo HTML.
- Use `https://cdn.example.com/presentations/job-123/assets/` quando os arquivos forem enviados para um CDN ou servidor de arquivos estático.

A URL retornada por [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilinkembedcontroller/) deve corresponder ao local final de implantação do arquivo escrito por [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilinkembedcontroller/). Em aplicações Android, use armazenamento específico da aplicação, um diretório de cache ou um diretório obtido através do Storage Access Framework de acordo com seu fluxo de publicação. Em aplicações de servidor, use um diretório de saída exclusivo ou um prefixo de armazenamento de objetos para cada trabalho de conversão, a fim de evitar sobrescrever arquivos de outra exportação.

## **Quando incorporar em vez disso**

HTML incorporado em Base64 ainda é útil quando a saída deve ser um único arquivo, como um anexo de e‑mail, uma pré‑visualização offline ou um documento que será movido sem uma pasta de ativos de suporte. Recursos vinculados são mais adequados quando o HTML será servido por uma aplicação web, armazenado em um CMS, otimizado por um pipeline de build ou armazenado em cache pelos navegadores de forma independente do HTML.

## **FAQ**

**Posso externalizar apenas imagens e manter os outros recursos incorporados?**

Sim. Em [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilinkembedcontroller/), retorne `Link` de [LinkEmbedDecision](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/linkembeddecision/) apenas para os tipos de conteúdo que você deseja salvar como arquivos separados, e retorne `Embed` para todo o resto.

**Por que a extensão da imagem exportada difere da apresentação original?**

O Aspose.Slides pode re‑codificar imagens raster durante a exportação HTML para melhorar o tamanho ou a compatibilidade com navegadores. Por exemplo, uma imagem do arquivo fonte pode ser gravada como JPEG ou PNG dependendo do resultado renderizado.

**Os URLs relativos funcionam depois que eu movo o arquivo HTML?**

URLs relativos funcionam somente quando a mesma estrutura de pastas relativa é preservada. Se o HTML referenciar `assets/resource-1.png`, a pasta `assets` deve permanecer ao lado do arquivo HTML, a menos que você gere um prefixo de URL diferente.

**Posso gravar recursos em armazenamento externo público no Android?**

Sim, se sua aplicação possuir um destino válido e modelo de permissão adequado para a versão do Android alvo. Para HTML gerado que é usado apenas pelo seu aplicativo, arquivos específicos da aplicação ou diretórios de cache geralmente são mais simples. Para saída visível ao usuário, use um local selecionado pelo usuário ou outra abordagem de armazenamento que se ajuste ao seu app.

**As aplicações de servidor devem reutilizar a mesma pasta de saída?**

Não. Use um diretório de saída exclusivo ou um prefixo de armazenamento para cada trabalho de conversão. Isso evita colisões de nomes de arquivos e impede que uma exportação sobrescreva recursos gerados por outra exportação.