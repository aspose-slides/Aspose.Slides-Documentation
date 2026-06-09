---
title: Converter Apresentações PowerPoint para SWF Flash em C++
linktitle: PowerPoint para SWF
type: docs
weight: 80
url: /pt/cpp/convert-powerpoint-to-swf-flash/
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
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Converter PowerPoint (PPT/PPTX) para SWF Flash em C++ com Aspose.Slides. Exemplos de código passo a passo, saída de alta qualidade e rápida, sem automação do PowerPoint."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint para SWF usando Aspose.Slides. Ele mostra como salvar uma apresentação como um arquivo SWF com o método [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/) e como configurar a exportação com [SwfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/swfoptions/), incluindo as configurações do visualizador e o layout de notas ou comentários.

## **Converter apresentações para Flash**

O método [Save](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) pode ser usado para converter toda a apresentação em um documento SWF. Você também pode incluir comentários no SWF gerado usando a classe [SWFOptions](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.export.swf_options) e a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/notescommentslayoutingoptions/). O exemplo a seguir mostra como converter uma apresentação em um documento SWF usando as opções fornecidas pela classe SWFOptions.

``` cpp
// O caminho para o diretório de documentos.
    System::String dataDir = GetDataPath();

    // Instanciar um objeto Presentation que representa um arquivo de apresentação
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Salvando a apresentação e as páginas de notas
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **Perguntas frequentes**

**Posso incluir slides ocultos no SWF?**

Sim. Use o método [set_ShowHiddenSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) na classe [SwfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/swfoptions/). Por padrão, slides ocultos não são exportados.

**Como posso controlar a compactação e o tamanho final do SWF?**

Use o método [set_Compressed](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/swfoptions/set_compressed/) e ajuste a [JPEG quality](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/swfoptions/set_jpegquality/) para equilibrar o tamanho do arquivo e a fidelidade da imagem.

**Para que serve 'set_ViewerIncluded' e quando devo usá-lo?**

[set_ViewerIncluded](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) adiciona uma interface de player incorporada (controles de navegação, painéis, pesquisa). Desative-a se planeja usar seu próprio player ou precisar de um quadro SWF simples sem interface.

**O que acontece se uma fonte de origem estiver ausente na máquina de exportação?**

Aspose.Slides substituirá a fonte que você especificar via [set_DefaultRegularFont](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) em [SwfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/swfoptions/) para evitar uma substituição indesejada.