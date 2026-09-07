---
title: Converter apresentações PowerPoint para SWF Flash em Python via Java
linktitle: PowerPoint para SWF
type: docs
weight: 80
url: /pt/python-java/convert-powerpoint-to-swf-flash/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para SWF
- apresentação para SWF
- slide para SWF
- PPT para SWF
- PPTX para SWF
- PowerPoint para Flash
- apresentação para Flash
- slide para Flash
- PPT para Flash
- PPTX para Flash
- salvar PPT como SWF
- salvar PPTX como SWF
- exportar PPT para SWF
- exportar PPTX para SWF
- Python
- Java
- Aspose.Slides
description: "Converta apresentações PowerPoint para SWF Flash em Python via Java com Aspose.Slides. Configure o visualizador, notas, slides ocultos, compressão e fontes."
---
## **Visão geral**

Aspose.Slides para Python via Java permite converter apresentações PowerPoint em SWF sem o Microsoft PowerPoint. Use [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) para exportar a apresentação e [SwfOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/swfoptions/) para configurar as opções do visualizador, a qualidade da imagem e o layout de anotações ou comentários.

## **Converter apresentações para Flash**

Carregue o arquivo de origem com [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/), configure [SwfOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/swfoptions/) e salve-o usando [SaveFormat.Swf](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/#Swf).

O exemplo a seguir exporta `presentation.pptx` para `presentation.swf`. Ele desabilita o visualizador incorporado com [setViewerIncluded](https://reference.aspose.com/slides/pt/python-java/aspose.slides/swfoptions/#setViewerIncluded) e inclui notas do apresentador abaixo dos slides usando [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notescommentslayoutingoptions/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

Antes de executar o exemplo, [instale Aspose.Slides para Python via Java](/slides/pt/python-java/installation/) e coloque `presentation.pptx` no diretório de trabalho. A JVM é iniciada uma vez por processo Python.

O exemplo aplica [NotesPositions.BottomFull](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notespositions/#BottomFull) através de [setNotesPosition](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) e passa o layout para [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). Para incluir comentários também, configure [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) antes da exportação.

## **FAQ**

**Posso incluir slides ocultos no SWF?**

Sim. Chame SwfOptions.setShowHiddenSlides com `True`. Por padrão, slides ocultos não são exportados.

**Como posso controlar a compressão e o tamanho final do SWF?**

Use SwfOptions.setCompressed para habilitar ou desabilitar a compressão e SwfOptions.setJpegQuality para ajustar a qualidade da imagem JPEG. Uma qualidade JPEG mais baixa pode reduzir o tamanho do arquivo ao custo da fidelidade da imagem.

**Para que serve o visualizador incorporado e quando devo desativá-lo?**

SwfOptions.setViewerIncluded controla se o SWF gerado inclui o visualizador. Passe `False` quando precisar das slides exportadas sem o visualizador incorporado, como no exemplo acima.

**O que acontece se uma fonte de origem estiver ausente na máquina de exportação?**

Você pode especificar uma fonte regular padrão com setDefaultRegularFont, herdada por SwfOptions. Escolha uma fonte disponível para o processo de exportação; a substituição de fontes pode alterar a aparência do texto e o layout.