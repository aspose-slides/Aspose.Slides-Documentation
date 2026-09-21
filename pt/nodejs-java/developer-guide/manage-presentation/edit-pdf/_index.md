---
title: Editar Documentos PDF em JavaScript
linktitle: Editar PDF
type: docs
weight: 65
url: /pt/nodejs-java/edit-pdf/
keywords:
- editar PDF
- substituir texto PDF
- PDF para PPTX
- PPTX para PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "Edite documentos PDF em JavaScript importando-os para o Aspose.Slides, substituindo texto e salvando a apresentação modificada de volta em PDF."
---
## **Visão Geral**

Aspose.Slides for Node.js via Java permite editar o conteúdo de PDF importando suas páginas como slides, modificando a apresentação e exportando-a de volta para PDF. Este artigo mostra uma substituição simples de texto. A apresentação permanece na memória, portanto salvar um arquivo PPTX intermediário é opcional.

## **Substituir Texto em um PDF**

Use [addFromPdf](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/#addFromPdf) para importar as páginas, [replaceText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#replaceText) para atualizar o texto e [save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save) para exportar o resultado.

O exemplo a seguir espera que o `input.pdf` contenha a palavra "Draft" como texto editável após a importação. Ele substitui essa palavra por "Final" e grava `edited.pdf`. Limpar o slide inicial antes da importação evita uma página em branco extra na saída. A pesquisa corresponde a palavras completas com a mesma capitalização; `null` significa que nenhum callback de resultado é necessário.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Para mais opções, veja [Pesquisar e Substituir Texto](/slides/pt/nodejs-java/search-and-replace-text/) e [Converter PowerPoint para PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
A substituição de texto funciona em texto importado, não em texto dentro de imagens escaneadas. A conversão pode afetar o layout e a formatação, portanto revise a saída, especialmente quando o texto de substituição for mais longo que o original.
{{% /alert %}}

## **Perguntas Frequentes**

**Preciso salvar um arquivo PPTX antes de exportar o PDF?**

Não. Você pode editar e exportar a mesma apresentação na memória. Salve uma cópia PPTX somente se também quiser continuar editando-a no PowerPoint; veja [Salvar Apresentações](/slides/pt/nodejs-java/save-presentation/).

**Por que algum texto pode permanecer inalterado?**

O exemplo corresponde à palavra completa "Draft" com capitalização exata. Texto importado como imagem ou dividido em quadros de texto separados não corresponderá necessariamente à pesquisa. Verifique o conteúdo importado e ajuste a pesquisa para o seu documento.