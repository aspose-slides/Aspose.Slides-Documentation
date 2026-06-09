---
title: Converter Apresentações PowerPoint para Markdown em Python
linktitle: PowerPoint para Markdown
type: docs
weight: 140
url: /pt/python-net/convert-powerpoint-to-markdown/
keywords:
- converter PowerPoint para Markdown
- converter OpenDocument para Markdown
- converter apresentação para Markdown
- converter slide para Markdown
- converter PPT para Markdown
- converter PPTX para Markdown
- converter ODP para Markdown
- converter PowerPoint para MD
- converter OpenDocument para MD
- converter apresentação para MD
- converter slide para MD
- converter PPT para MD
- converter PPTX para MD
- converter ODP para MD
- PowerPoint
- OpenDocument
- apresentação
- Markdown
- Python
- Aspose.Slides
description: "Converter slides PowerPoint e OpenDocument — PPT, PPTX, ODP — para Markdown limpo com Aspose.Slides para Python via .NET, automatizar documentação e manter a formatação."
---
## **Introdução**

Aspose.Slides permite converter apresentações PowerPoint para Markdown, o que pode ser útil para fluxos de documentação, geração de sites estáticos, migração de conteúdo e publicação de texto versionado. A API oferece exportação direta de apresentações PPT e PPTX para arquivos MD e fornece opções adicionais para controlar como o conteúdo dos slides é representado no documento Markdown resultante.

Você pode exportar apresentações como Markdown puro, escolher entre vários sabores de Markdown como CommonMark e GitHub Flavored Markdown, e configurar como as imagens são tratadas durante a exportação. Para apresentações que contêm conteúdo visual, Aspose.Slides também permite salvar imagens em uma pasta separada e referenciá‑las a partir do arquivo Markdown gerado.

{{% alert color="warning" %}}
A exportação de PowerPoint para Markdown é **sem imagens** por padrão. Se você quiser exportar um documento PowerPoint contendo imagens, precisa definir `export_type = MarkdownExportType.VISUAL` e especificar `base_path`, onde as imagens referenciadas no documento Markdown serão salvas.
{{% /alert %}}

## **Converter Apresentações para Markdown**

O exemplo abaixo mostra a maneira mais simples de converter uma apresentação PowerPoint para Markdown usando Aspose.Slides for Python via .NET com configurações padrão.

1. Instancie um [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) para carregar a apresentação.
1. Chame `save` para exportá‑la como um arquivo Markdown.

Use o trecho Python abaixo para realizar a conversão:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Converter Apresentações para Sabor de Markdown**

Aspose.Slides permite converter apresentações para formatos Markdown, incluindo Markdown básico, CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab e 17 outros sabores de Markdown.

O exemplo Python a seguir mostra como converter uma apresentação PowerPoint para CommonMark:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

Os 23 sabores de Markdown suportados são listados na enumeração [Flavor](https://reference.aspose.com/slides/pt/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) da classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Converter Apresentações que Contêm Imagens para Markdown**

A classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) fornece propriedades e enumerações que permitem configurar o arquivo Markdown resultante. Por exemplo, o enum [MarkdownExportType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) controla como as imagens são tratadas: `SEQUENTIAL`, `TEXT_ONLY` ou `VISUAL`.

### **Converter Imagens Sequencialmente**

Se você quiser que as imagens apareçam individualmente —uma após a outra— no Markdown gerado, escolha a opção `SEQUENTIAL`. O exemplo Python abaixo demonstra como converter uma apresentação com imagens para Markdown.

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```

### **Converter Imagens Visualmente**

Se você quiser que as imagens apareçam juntas no Markdown resultante, escolha a opção `VISUAL`. Nesse modo, as imagens são salvas no diretório atual da aplicação (e o documento Markdown usa caminhos relativos), ou você pode especificar um caminho de saída personalizado e o nome da pasta.

O exemplo Python abaixo demonstra esta operação:

```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```

## **FAQ**

**Os hiperlinks sobrevivem à exportação para Markdown?**

Sim. Texto [hiperlinks](/slides/pt/python-net/manage-hyperlinks/) são preservados como links Markdown padrão. [transições](/slides/pt/python-net/slide-transition/) e [animações](/slides/pt/python-net/powerpoint-animation/) não são convertidas.

**Posso acelerar a conversão executando‑a em múltiplas threads?**

Você pode paralelizar por arquivos, mas [não compartilhe](/slides/pt/python-net/multithreading/) a mesma [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) entre threads. Use instâncias/processos separados por arquivo para evitar contenção.

**O que acontece com as imagens — onde são salvas e os caminhos são relativos?**

[Imagens](/slides/pt/python-net/image/) são exportadas para uma pasta dedicada, e o arquivo Markdown as referencia com caminhos relativos por padrão. Você pode configurar o caminho de saída base e o nome da pasta de ativos para manter uma estrutura de repositório previsível.