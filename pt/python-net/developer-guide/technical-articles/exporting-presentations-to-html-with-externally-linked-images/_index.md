---
title: Exportar apresentações para HTML com imagens vinculadas externamente em Python
linktitle: Exportar apresentações para HTML com imagens vinculadas externamente
type: docs
weight: 100
url: /pt/python-net/exporting-presentations-to-html-with-externally-linked-images/
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
- Aspose.Slides
description: "Exportar apresentações PowerPoint e OpenDocument para HTML em Python usando Aspose.Slides com imagens salvas como arquivos vinculados externamente."
---
## **Visão geral**

Por padrão, o Aspose.Slides exporta uma apresentação para um arquivo HTML autônomo. Imagens e outros recursos são gravados diretamente no HTML, geralmente como dados Base64. Isso é conveniente quando você precisa de um único arquivo portátil, mas nem sempre é o melhor formato para um site, um CMS ou um pipeline de conversão do lado do servidor.

Use imagens vinculadas externamente quando desejar:

- reduzir o tamanho do documento HTML;
- armazenar em cache as imagens separadamente em um navegador ou CDN;
- inspecionar, substituir, compactar ou pós‑processar as imagens geradas após a exportação;
- manter a estrutura de saída mais próxima do que uma aplicação web espera.

Para o fluxo de trabalho geral de conversão para HTML, veja [Converter apresentações PowerPoint para HTML](/slides/pt/python-net/convert-powerpoint-to-html/). Este artigo foca na parte de vinculação de imagens da exportação.

## **Como funciona a exportação de imagens vinculadas**

No .NET e no Java, [ILinkEmbedController](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/ilinkembedcontroller/) representa a interface de retorno de chamada usada pelo exportador para decidir se um recurso deve ser incorporado ou vinculado. No Python via .NET, as classes Python não podem atualmente implementar essa interface de retorno de chamada .NET diretamente, então o fluxo de trabalho prático é:

1. Exportar a apresentação para HTML com [HtmlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/htmloptions/).
1. Usar [SlideImageFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/slideimageformat/) com [SVGOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgoptions/) para que os slides sejam representados como SVG no HTML.
1. Mover os dados de imagem Base64 de URLs `data:` no HTML para arquivos separados.
1. Substituir as URLs `data:` originais por links relativos, como `assets/resource-1.jpg`.

O caminho do sistema de arquivos e a URL do navegador são preocupações distintas. Por exemplo, o exemplo abaixo grava arquivos de imagem em `html-output/assets` no disco, enquanto o HTML contém URLs relativas como `assets/resource-1.jpg`. Um navegador resolve essas URLs em relação ao arquivo HTML que contém o link.

## **Exportar HTML com imagens vinculadas**

O exemplo Python a seguir cria um diretório de saída, salva o arquivo HTML nele, armazena as imagens extraídas em um subdiretório `assets` e reescreve as URLs de imagem Base64 para links relativos. O exemplo extrai formatos comuns de imagem Base64 quando o Aspose.Slides fornece uma extensão de arquivo segura. URLs de dados que não são reconhecidas permanecem incorporadas.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

Depois da exportação, a pasta de saída pode ter esta estrutura:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

Os arquivos exatos dependem do conteúdo da apresentação e das opções de exportação. Por exemplo, imagens raster são tipicamente exportadas como JPEG ou PNG. O Aspose.Slides pode escolher um codec de imagem diferente do usado na apresentação original quando isso produz um arquivo menor ou mais adequado. Imagens com transparência são exportadas como PNG.

## **Escolhendo URLs para implantação**

O exemplo usa um prefixo de URL relativo: `assets/`. Se `presentation.html` for aberto a partir de `html-output/presentation.html`, o navegador carrega `html-output/assets/resource-1.jpg`.

Use um nome de diretório de ativos diferente ou reescreva os links gerados quando os arquivos forem implantados em outro local:

- Use `assets/` quando o diretório de ativos estiver ao lado do arquivo HTML.
- Use `../assets/` quando o diretório de ativos estiver um nível acima do arquivo HTML.
- Use `https://cdn.example.com/presentations/job-123/assets/` quando os arquivos forem enviados para um CDN ou servidor de arquivos estáticos.

Em aplicações de servidor, use um diretório de saída exclusivo ou um prefixo de armazenamento de objetos para cada tarefa de conversão, a fim de evitar sobrescrita de arquivos de outra exportação.

## **Quando incorporar em vez de vincular**

HTML com Base64 incorporado ainda é útil quando a saída deve ser um único arquivo, como um anexo de e‑mail, uma pré‑visualização offline ou um documento que será movido sem uma pasta de ativos de suporte. Imagens vinculadas são mais adequadas quando o HTML será servido por uma aplicação web, armazenado em um CMS, otimizado por um pipeline de construção ou armazenado em cache pelos navegadores de forma independente do HTML.

## **FAQ**

**Posso externalizar apenas imagens e manter outros recursos incorporados?**

Sim. O exemplo extrai apenas URLs de dados Base64 `image/*` cujos tipos de conteúdo estão listados em `EXTENSIONS_BY_CONTENT_TYPE`. Outras URLs de dados permanecem incorporadas.

**Por que a extensão da imagem exportada difere da apresentação original?**

O Aspose.Slides pode recodificar imagens raster durante a exportação para HTML a fim de melhorar o tamanho ou a compatibilidade com navegadores. Por exemplo, uma imagem do arquivo fonte pode ser gravada como JPEG ou PNG dependendo do resultado renderizado.

**URLs relativos funcionam após mover o arquivo HTML?**

URLs relativos funcionam somente quando a mesma estrutura de pastas relativa é preservada. Se o HTML referenciar `assets/resource-1.png`, a pasta `assets` deve permanecer ao lado do arquivo HTML, a menos que você gere um prefixo de URL diferente.

**Aplicações de servidor devem reutilizar a mesma pasta de saída?**

Não. Use um diretório de saída exclusivo ou um prefixo de armazenamento para cada tarefa de conversão. Isso evita colisões de nomes de arquivo e impede que uma exportação sobrescreva recursos gerados por outra exportação.