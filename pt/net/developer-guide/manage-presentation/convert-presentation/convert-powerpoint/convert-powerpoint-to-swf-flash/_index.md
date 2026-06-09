---
title: Converter apresentações do PowerPoint para SWF Flash em .NET
linktitle: PowerPoint para SWF
type: docs
weight: 80
url: /pt/net/convert-powerpoint-to-swf-flash/
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
- .NET
- C#
- Aspose.Slides
description: "Converter PowerPoint (PPT/PPTX) para SWF Flash em .NET com Aspose.Slides. Exemplos de código C# passo a passo, saída rápida e de qualidade, sem automação do PowerPoint."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint para SWF usando o Aspose.Slides. Ele mostra como salvar uma apresentação como um arquivo SWF com o método [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) e como configurar a exportação com [SwfOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/swfoptions/), incluindo configurações do visualizador e layout de notas ou comentários.

## **Converter apresentações para Flash**

O método [Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/methods/save/index) exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) pode ser usado para converter toda a apresentação em um documento SWF. Você também pode incluir comentários no SWF gerado usando a classe [SWFOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/swfoptions) e a interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/inotescommentslayoutingoptions). O exemplo a seguir mostra como converter uma apresentação em um documento SWF usando as opções fornecidas pela classe SWFOptions.

```c#
// Instanciar um objeto Presentation que representa um arquivo de apresentação
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Salvando a apresentação e as páginas de notas
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

## **FAQ**

**Posso incluir slides ocultos no SWF?**

Sim. Ative a opção [ShowHiddenSlides](https://reference.aspose.com/slides/pt/net/aspose.slides.export/swfoptions/showhiddenslides/) em [SwfOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/swfoptions/). Por padrão, slides ocultos não são exportados.

**Como posso controlar a compressão e o tamanho final do SWF?**

Use a flag [Compressed](https://reference.aspose.com/slides/pt/net/aspose.slides.export/swfoptions/compressed/) (ativada por padrão) e ajuste [JpegQuality](https://reference.aspose.com/slides/pt/net/aspose.slides.export/swfoptions/jpegquality/) para equilibrar o tamanho do arquivo e a fidelidade da imagem.

**Para que serve 'ViewerIncluded' e quando devo desativá-lo?**

[ViewerIncluded](https://reference.aspose.com/slides/pt/net/aspose.slides.export/swfoptions/viewerincluded/) adiciona uma interface de player incorporada (controles de navegação, painéis, busca). Desative-a se planeja usar seu próprio player ou precisar de um quadro SWF simples sem interface.

**O que acontece se uma fonte de origem estiver ausente na máquina de exportação?**

Aspose.Slides substituirá a fonte que você especificar via [DefaultRegularFont](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveoptions/defaultregularfont/) em [SwfOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveoptions/) para evitar um fallback indesejado.