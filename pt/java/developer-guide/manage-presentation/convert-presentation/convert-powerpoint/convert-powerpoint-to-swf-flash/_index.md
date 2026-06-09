---
title: Converter apresentações PowerPoint para SWF Flash em Java
linktitle: PowerPoint para SWF
type: docs
weight: 80
url: /pt/java/convert-powerpoint-to-swf-flash/
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
- Java
- Aspose.Slides
description: "Converta PowerPoint (PPT/PPTX) para SWF Flash em Java com Aspose.Slides. Exemplos de código passo a passo, saída de alta qualidade e rápida, sem automação do PowerPoint."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint para SWF usando Aspose.Slides. Ele mostra como salvar uma apresentação como um arquivo SWF com o método [Presentation.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) e como configurar a exportação com [SwfOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/swfoptions/), incluindo configurações do visualizador e layout de notas ou comentários.

## **Converter apresentações para Flash**

O método [save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation) pode ser usado para converter a apresentação inteira em um documento **SWF**. O exemplo a seguir demonstra como converter uma apresentação em documento **SWF** usando opções fornecidas pela classe [**SWFOptions**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SwfOptions). Você também pode incluir comentários no SWF gerado usando a classe [**ISWFOptions**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISwfOptions) e a interface [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INotesCommentsLayoutingOptions).

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Salvando a apresentação
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso incluir slides ocultos no SWF?**

Sim. Ative os slides ocultos usando o método [setShowHiddenSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) em [SwfOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/swfoptions/). Por padrão, slides ocultos não são exportados.

**Como posso controlar a compactação e o tamanho final do SWF?**

Use o método [setCompressed](https://reference.aspose.com/slides/pt/java/com.aspose.slides/swfoptions/#setCompressed-boolean-) e ajuste a qualidade JPEG com [setJpegQuality](https://reference.aspose.com/slides/pt/java/com.aspose.slides/swfoptions/#setJpegQuality-int-) para equilibrar o tamanho do arquivo e a fidelidade da imagem.

**Para que serve 'setViewerIncluded' e quando devo desativá-lo?**

[setViewerIncluded](https://reference.aspose.com/slides/pt/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) adiciona uma UI de player incorporada (controles de navegação, painéis, busca). Desative-a se você planeja usar seu próprio player ou precisar de um quadro SWF sem UI.

**O que acontece se uma fonte de origem estiver ausente na máquina de exportação?**

Aspose.Slides substituirá a fonte especificada via [setDefaultRegularFont](https://reference.aspose.com/slides/pt/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) em [SwfOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/swfoptions/) para evitar um fallback indesejado.