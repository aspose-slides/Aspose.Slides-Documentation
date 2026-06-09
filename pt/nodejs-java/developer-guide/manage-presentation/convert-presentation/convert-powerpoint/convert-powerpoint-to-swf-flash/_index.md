---
title: Converter apresentações PowerPoint para SWF Flash em JavaScript
linktitle: PowerPoint para SWF
type: docs
weight: 80
url: /pt/nodejs-java/convert-powerpoint-to-swf-flash/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converter PowerPoint (PPT/PPTX) para SWF Flash com Aspose.Slides para Node.js. Exemplos de código passo a passo, saída de alta qualidade e rapidez, sem automação do PowerPoint."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint para SWF usando Aspose.Slides. Ele mostra como salvar uma apresentação como um arquivo SWF com o método [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save) e como configurar a exportação com [SwfOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/swfoptions/), incluindo configurações do visualizador e layout de notas ou comentários.

## **Converter PPT(X) para SWF**
O método [save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation) pode ser usado para converter a apresentação inteira em um documento **SWF**. O exemplo a seguir mostra como converter uma apresentação em documento **SWF** usando as opções fornecidas pela classe [**SWFOptions**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SwfOptions). Você também pode incluir comentários no SWF gerado usando a classe [**SWFOptions**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SwfOptions) e a classe [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions).

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Salvando a apresentação
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso incluir slides ocultos no SWF?**

Sim. Use o método [setShowHiddenSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) em [SwfOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/swfoptions/). Por padrão, slides ocultos não são exportados.

**Como posso controlar a compressão e o tamanho final do SWF?**

Use os métodos [setCompressed](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/swfoptions/setcompressed/) e [setJpegQuality](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/swfoptions/setjpegquality/) para equilibrar o tamanho do arquivo e a fidelidade da imagem.

**Para que serve 'setViewerIncluded' e quando devo usá‑lo?**

[setViewerIncluded](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) adiciona uma interface de player embutida (controles de navegação, painéis, busca). Use‑o se você pretende usar seu próprio player ou precisar de um quadro SWF sem UI.

**O que acontece se uma fonte de origem estiver ausente na máquina de exportação?**

Aspose.Slides substituirá a fonte especificada via [setDefaultRegularFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) em [SwfOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/swfoptions/) para evitar um fallback inesperado.