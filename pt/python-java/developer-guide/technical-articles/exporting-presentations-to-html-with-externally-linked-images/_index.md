---
title: Exportar apresentações para HTML com imagens vinculadas externamente
type: docs
weight: 100
url: /pt/python-java/exporting-presentations-to-html-with-externally-linked-images/
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
- Python
- Java
- Aspose.Slides
description: "Exportar apresentações PowerPoint e OpenDocument para HTML em Python usando Aspose.Slides, com imagens e outros recursos salvos como arquivos vinculados externamente."
---
## **Visão geral**

Por padrão, o Aspose.Slides exporta uma apresentação para um arquivo HTML autônomo. Imagens e outros recursos são inseridos diretamente no HTML, geralmente como dados Base64. Isso é conveniente quando você precisa de um único arquivo portátil, mas nem sempre é o melhor formato para um site, um CMS ou um pipeline de conversão do lado do servidor.

Use recursos vinculados externamente quando quiser:

- reduzir o tamanho do documento HTML;
- armazenar em cache imagens, fontes, áudio ou vídeo separadamente em um navegador ou CDN;
- inspecionar, substituir, compactar ou pós‑processar recursos gerados após a exportação;
- manter a estrutura de saída mais próxima do que uma aplicação web espera.

Para o fluxo de trabalho geral de conversão para HTML, veja [Converter apresentações PowerPoint para HTML](/slides/pt/python-java/convert-powerpoint-to-html/). Este artigo foca na parte de vinculação de recursos da exportação.

## **Como funciona a exportação com recursos vinculados**

`ILinkEmbedController` permite que sua aplicação decida, recurso por recurso, se o exportador incorpora os dados no HTML ou os salva externamente e grava um link.

A interface possui três métodos:

- `ILinkEmbedController.getObjectStoringLocation` decide se um recurso deve ser vinculado ou incorporado.
- `ILinkEmbedController.getUrl` devolve a URL que será escrita no HTML gerado ou em outro recurso vinculado.
- `ILinkEmbedController.saveExternal` grava os dados do recurso vinculado em disco ou em outro destino de armazenamento.

O caminho no sistema de arquivos e a URL do navegador são preocupações distintas. Por exemplo, o exemplo abaixo grava arquivos de recurso em `html-output/assets` no disco, enquanto o HTML contém URLs relativas como `assets/resource-1.svg`. Um navegador resolve essas URLs em relação ao arquivo que contém o link. Portanto, um link de `presentation.html` para um arquivo SVG usa `assets/resource-1.svg`, enquanto um link desse arquivo SVG para uma imagem salva na mesma pasta `assets` usa `resource-4.jpg`.

## **Exportar HTML com recursos vinculados**

O exemplo Python a seguir cria um diretório de saída, salva o arquivo HTML nele e armazena os recursos vinculados em um subdiretório `assets`. O controlador vincula recursos comuns de imagem, fonte, áudio, vídeo e CSS quando o Aspose.Slides fornece ou pode inferir uma extensão de arquivo segura. Recursos que não são reconhecidos permanecem incorporados.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Após a exportação, a pasta de saída tem a seguinte estrutura:

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

Quando um recurso vinculado faz referência a outro recurso vinculado, o exemplo usa o parâmetro `referrer` em `ILinkEmbedController.getUrl` e devolve apenas o nome do arquivo. Por exemplo, se `resource-1.svg` e `resource-4.jpg` estiverem ambos na pasta `assets`, o arquivo SVG deve referir‑se a `resource-4.jpg`, e não a `assets/resource-4.jpg`.

Use um prefixo de URL diferente quando os arquivos forem implantados em outro local:

- Use `assets/` quando o diretório de ativos estiver ao lado do arquivo HTML.
- Use `../assets/` quando o diretório de ativos estiver um nível acima do arquivo HTML.
- Use `https://cdn.exemplo.com/presentations/job-123/assets/` quando os arquivos forem enviados a um CDN ou servidor de arquivos estático.

A URL devolvida por `ILinkEmbedController.getUrl` deve corresponder ao local final de implantação do arquivo gravado por `ILinkEmbedController.saveExternal`. Em aplicações de servidor, use um diretório de saída exclusivo ou um prefixo de armazenamento de objetos para cada tarefa de conversão, a fim de evitar sobrescrever arquivos de outra exportação.

## **Quando incorporar em vez de vincular**

HTML incorporado em Base64 ainda é útil quando a saída deve ser um único arquivo, como um anexo de e‑mail, uma pré‑visualização offline ou um documento que será movido sem uma pasta de ativos de suporte. Recursos vinculados são mais adequados quando o HTML será servido por uma aplicação web, armazenado em um CMS, otimizado por um pipeline de build ou armazenado em cache pelos navegadores de forma independente do HTML.

## **FAQ**

**Posso externalizar somente imagens e manter os outros recursos incorporados?**

Sim. Em `ILinkEmbedController.getObjectStoringLocation`, devolva [LinkEmbedDecision.Link](https://reference.aspose.com/slides/pt/python-java/aspose.slides/linkembeddecision/#Link) apenas para os tipos de conteúdo que você deseja salvar como arquivos separados, e devolva [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/pt/python-java/aspose.slides/linkembeddecision/#Embed) para todo o resto.

**Por que a extensão da imagem exportada difere da apresentação original?**

O Aspose.Slides pode re‑codificar imagens raster durante a exportação para HTML para melhorar o tamanho ou a compatibilidade com navegadores. Por exemplo, uma imagem do arquivo original pode ser gravada como JPEG ou PNG dependendo do resultado renderizado.

**URLs relativas funcionam após mover o arquivo HTML?**

URLs relativas funcionam somente quando a mesma estrutura de pastas relativa é preservada. Se o HTML referencia `assets/resource-1.png`, a pasta `assets` deve permanecer ao lado do arquivo HTML, a menos que você gere um prefixo de URL diferente.

**Aplicações de servidor devem reutilizar a mesma pasta de saída?**

Não. Use um diretório de saída exclusivo ou um prefixo de armazenamento para cada tarefa de conversão. Isso evita colisões de nomes de arquivo e impede que uma exportação sobrescreva recursos gerados por outra exportação.