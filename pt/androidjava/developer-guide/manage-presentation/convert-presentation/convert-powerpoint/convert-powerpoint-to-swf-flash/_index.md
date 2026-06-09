---
title: Converter apresentações PowerPoint para SWF Flash no Android
linktitle: PowerPoint para SWF
type: docs
weight: 80
url: /pt/androidjava/convert-powerpoint-to-swf-flash/
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
- Android
- Java
- Aspose.Slides
description: "Converter PowerPoint (PPT/PPTX) para SWF Flash em Java com Aspose.Slides para Android. Exemplos de código passo a passo, saída rápida e de alta qualidade, sem automação do PowerPoint."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint para SWF usando Aspose.Slides. Ele mostra como salvar uma apresentação como um arquivo SWF com o [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) método e como configurar a exportação com [SwfOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/swfoptions/), incluindo configurações do visualizador e layout de notas ou comentários.

## **Converter PPT(X) para SWF**
O método [Save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation) pode ser usado para converter toda a apresentação em um documento **SWF**. O exemplo a seguir mostra como converter uma apresentação em um documento **SWF** usando as opções fornecidas pela classe [**SWFOptions**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SwfOptions). Você também pode incluir comentários no SWF gerado usando [**ISWFOptions**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISwfOptions) e a interface [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions).

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

Sim. Ative os slides ocultos usando o método [setShowHiddenSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) em [SwfOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/swfoptions/). Por padrão, slides ocultos não são exportados.

**Como posso controlar a compressão e o tamanho final do SWF?**

Use o método [setCompressed](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) e ajuste a qualidade JPEG com [adjust JPEG quality](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) para equilibrar o tamanho do arquivo e a fidelidade da imagem.

**Para que serve 'setViewerIncluded' e quando devo desativá-lo?**

[setViewerIncluded](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) adiciona uma UI de player incorporada (controles de navegação, painéis, pesquisa). Desative-o se você pretende usar seu próprio player ou precisar de um quadro SWF simples sem UI.

**O que acontece se uma fonte de origem estiver faltando na máquina de exportação?**

Aspose.Slides substituirá a fonte especificada via [setDefaultRegularFont](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) em [SwfOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/swfoptions/) para evitar um fallback inesperado.