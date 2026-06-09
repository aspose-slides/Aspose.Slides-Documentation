---
title: Converter apresentações PowerPoint para SWF Flash em Python
linktitle: PowerPoint para SWF Flash
type: docs
weight: 80
url: /pt/python-net/convert-powerpoint-to-swf-flash/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- PowerPoint para SWF
- apresentação para SWF
- slide para SWF
- PPT para SWF
- PPTX para SWF
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Converter PowerPoint (PPT/PPTX) para SWF Flash em Python com Aspose.Slides. Exemplos de código passo a passo, saída de alta qualidade e rápida, sem automação do PowerPoint."
---
## **Visão geral**

Este artigo explica como converter apresentações PowerPoint para SWF usando Aspose.Slides. Ele mostra como salvar uma apresentação como um arquivo SWF com o método [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/) e como configurar a exportação com [SwfOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/swfoptions/), incluindo configurações do visualizador e layout de notas ou comentários.

## **Converter apresentações para Flash**

O método [save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/) exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) pode ser usado para converter toda a apresentação em um documento SWF. Você também pode incluir comentários no SWF gerado usando a classe [SWFOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/swfoptions/) e a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/notescommentslayoutingoptions/). O exemplo a seguir mostra como converter uma apresentação em um documento SWF usando as opções fornecidas pela classe SWFOptions.

```py
import aspose.slides as slides

# Instanciar um objeto Presentation que representa um arquivo de apresentação
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Salvando a apresentação e páginas de notas
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **FAQ**

**Posso incluir slides ocultos no SWF?**

Sim. Ative a opção [show_hidden_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) em [SwfOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/swfoptions/). Por padrão, slides ocultos não são exportados.

**Como posso controlar a compressão e o tamanho final do SWF?**

Use o sinalizador [compressed](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/swfoptions/compressed/) (ativado por padrão) e ajuste [jpeg_quality](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/swfoptions/jpeg_quality/) para equilibrar o tamanho do arquivo e a fidelidade da imagem.

**Para que serve 'viewer_included' e quando devo desativá-lo?**

[viewer_included](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/swfoptions/viewer_included/) adiciona uma interface de usuário de player incorporada (controles de navegação, painéis, busca). Desative-a se planeja usar seu próprio player ou precisar de um quadro SWF sem UI.

**O que acontece se uma fonte de origem estiver ausente na máquina de exportação?**

Aspose.Slides substituirá a fonte especificada via [default_regular_font](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/swfoptions/default_regular_font/) em [SwfOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/swfoptions/) para evitar um fallback inesperado.