---
title: Converter apresentações PowerPoint para Markdown em Python
linktitle: PowerPoint para Markdown
type: docs
weight: 140
url: /pt/python-net/convert-powerpoint-to-markdown/
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
- exportação de imagem Markdown
- links de imagem CDN
- PowerPoint
- apresentação
- Markdown
- Python
- Python via .NET
- Aspose.Slides
description: "Converter apresentações PPT e PPTX para Markdown em Python e controlar onde as imagens exportadas são salvas e como o Markdown gerado as referencia."
---
## **Visão geral**

Aspose.Slides for Python via .NET pode converter apresentações PPT e PPTX para Markdown para documentação, sites estáticos, migração de conteúdo e fluxos de trabalho de controle de versão. Você pode escolher um sabor de Markdown, controlar como o conteúdo dos slides é renderizado e decidir onde as imagens exportadas são armazenadas e como o Markdown gerado as referencia.

Por padrão, a exportação para Markdown usa saída somente de texto. Para exportar conteúdo visual, defina a propriedade [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/markdownsaveoptions/export_type/) para o valor `SEQUENTIAL` ou `VISUAL` da enumeração [MarkdownExportType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/markdownexporttype/). `SEQUENTIAL` renderiza os itens dos slides separadamente e em ordem, enquanto `VISUAL` mantém os itens agrupados juntos para preservar sua relação visual. O valor `TEXT_ONLY` não gera recursos de imagem.

## **Converter uma apresentação para Markdown**

Carregue o arquivo de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e, em seguida, chame o método [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ipresentation/save/) com o valor `MD` da enumeração [SaveFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Selecionar um sabor de Markdown**

A propriedade [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/markdownsaveoptions/flavor/) controla a especificação Markdown usada para a saída. A enumeração [Flavor](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/flavor/) inclui CommonMark, GitHub Flavored Markdown e outras variantes suportadas.

O exemplo a seguir exporta uma apresentação como CommonMark:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **Exportar imagens usando o comportamento padrão de salvamento local**

A classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/markdownsaveoptions/) fornece duas propriedades para imagens salvas localmente:

- [base_path](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/markdownsaveoptions/base_path/) especifica o diretório base para o documento Markdown e seus recursos.
- [images_save_folder_name](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) especifica o subdiretório de imagens. Seu valor padrão é `Images`.

O exemplo a seguir renderiza conteúdo visual, grava imagens em `output/assets` e cria referências de imagem relativas no documento Markdown:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Aspose.Slides cria o subdiretório de imagens quando a exportação produz recursos de imagem, mas a aplicação deve criar `base_path` antes de salvar o arquivo Markdown.

## **Preparar Markdown e imagens para publicação**

Aspose.Slides for Python via .NET não expõe os callbacks de salvamento de imagem do .NET para substituir cada link de imagem gerado durante a exportação. Em vez disso, exporte o documento Markdown e sua pasta de imagens para um diretório de publicação e, então, publique esse diretório sem alterar sua estrutura relativa.

O exemplo a seguir prepara `cdn-origin/presentations/quarterly-report` como um diretório de publicação montado ou sincronizado. O exemplo em si não realiza upload de rede: os links gerados se tornam válidos após o diretório ser publicado no site ou local de CDN pretendido.

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Publique `presentation.md` juntamente com o diretório `assets`. O documento Markdown usa referências de imagem relativas, portanto ambos os itens devem manter o mesmo relacionamento no destino. Se um sistema de publicação exigir URLs externas absolutas, reescreva os links gerados como uma etapa de pós‑processamento separada após todas as arquivos de imagem terem sido publicados.

## **FAQ**

**É possível personalizar arquivos de imagem individuais e links durante a exportação para Markdown usando callbacks em Python?**

Não. Aspose.Slides for Python via .NET não expõe os callbacks .NET `ImageSaving` e `SvgImageSaving`. Configure a saída local com [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/markdownsaveoptions/base_path/) e [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/), depois publique ou pós‑procese os recursos gerados.

**Onde as imagens exportadas são salvas?**

A localização da imagem é controlada por [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/markdownsaveoptions/base_path/) e [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/). O documento Markdown referencia essas imagens com caminhos relativos.

**Qual separador de caminho os links de imagem devem usar?**

Use barras `/` em links Markdown e URLs. Use `os.path.join` apenas para caminhos do sistema de arquivos e normalize qualquer link criado durante o pós‑processamento separadamente.

**Os hiperlinks são preservados durante a exportação para Markdown?**

Sim. Hiperlinks de texto [hyperlinks](/slides/pt/python-net/manage-hyperlinks/) são preservados como links padrão Markdown. Transições de slide [transitions](/slides/pt/python-net/slide-transition/) e animações [animations](/slides/pt/python-net/powerpoint-animation/) não são convertidas.

**É possível converter apresentações para Markdown em paralelo?**

Você pode processar diferentes arquivos de apresentação em paralelo, mas não compartilhe a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) entre threads. Siga as [multithreading guidelines](/slides/pt/python-net/multithreading/) e use uma instância separada para cada arquivo.